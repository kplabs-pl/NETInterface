//-----------------------------------------------------------------------------
//  Copyright (c) 2015 Pressure Profile Systems
//
//  Licensed under the MIT license. This file may not be copied, modified, or
//  distributed except according to those terms.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using ZedGraph;
using System.Threading;
using SingleTactLibrary;
using System.Management;

namespace SingleTact_Demo
{
    public partial class GUI : Form
    {
        private bool backgroundIsFinished_ = false;  // Flag to check background thread is finished
        private double measuredFrequency_ = 50;  // Sensor update rate
        private int timerItr_ = 0;  // Some things are slower that the timer frequency
        private bool isFirstFrame_ = true; // Is first frame after boot
        private const int graphXRange_ = 30; // 30 seconds
        private int memorySpaceUse = 0;
        private const int reservedAddresses = 4; // Don't use I2C addresses 0 to 3
        private Object workThreadLock = new Object(); //Thread synchronization
        private List<USBdevice_GUI> USBdevices = new List<USBdevice_GUI>();
        private List<string> comPortList = new List<string>();
        private SingleTact activeSingleTact;
        private delegate void CloseMainFormDelegate(); //Used to close the program if hardware is not connected
        private double NBtoForceFactor = 0;
        private bool convertToPressure = false;
        private DateTime systemStartTime = new DateTime();
        private bool hasStartTime = false;

        private StreamWriter autoSaveOutput = null;
        public GUI()
        {
            string exceptionMessage = null;

            InitializeComponent();
            var finder = new ComPortFinder();
            // Get available serial ports.
            comPortList = finder.findSingleTact();
            if (comPortList.Count == 0)
            {
                MessageBox.Show(
                "Failed to start sensor: no serial ports found.\n\nPlease ensure Arduino drivers are installed.\nThis can be checked by looking if the Arduino is identified in Device Manager.\n\nPlease connect the device then restart this application.",
               "Hardware initialisation failed",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
                // There's no point showing the GUI.  Force the app to auto-close.
                Environment.Exit(-1);
            }
            else
            {
                for (int i = 0; i < comPortList.Count; i++)
                {
                    USBdevice_GUI USB = new USBdevice_GUI();
                    USB.Initialise(finder.prettyToComPort(comPortList[i]));
                    USBdevices.Add(USB);
                }
                if (comPortList.Count == 1)
                    updateUIforOneDevice();
            }

            try
            {
                PopulateGUIFields();
                foreach (USBdevice USB in USBdevices)
                {
                    USB.singleTact.PushSettingsToHardware();
                    RefreshFlashSettings_Click(this, null); //Get the settings from flash
                }
                CreateStripChart();
                AcquisitionWorker.RunWorkerAsync(); //Start the acquisition thread

                guiTimer_.Start();
            }
            catch
            {
                string summary = "Failed to start sensor";

                if (comPortList.Count == 0)
                    summary += ": no serial ports detected.";
                else
                    summary += " on " + comPortList[0] + ".";

                summary += "\n\n";

                if (exceptionMessage != null)
                    summary += exceptionMessage;
                else
                    summary += "Please connect the device then restart this application.";

                MessageBox.Show(
                    summary,
                    "Hardware initialisation failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                // There's no point showing the GUI.  Force the app to auto-close.
                Environment.Exit(-1);
            }
        }

        private void updateUIforOneDevice()
        {
            //hide GUI elements intended for multiple USBs
            //hide GUI elements intended for multiple USBs         
            tareAll.Text = "Tare";
            int UIOffset = 60;
            if (USBdevices[0].isCalibrated == true && USBdevices[0].singleTact.Settings.FirmwareVersion > 0)
            {
                sensorRange.Visible = true;
                sensorRangeLabel.Visible = true;
                if (USBdevices[0].singleTact.Settings.ReferenceGain == 1)
                {
                    sensorRange.Items.Add(' ');
                    sensorRange.Items.Add("4.5");
                    sensorRange.Items.Add("45");
                    sensorRange.Items.Add("450");
                    sensorRange.Items.Add("1");
                    sensorRange.Items.Add("10");
                    sensorRange.Items.Add("100");
                }
                if (USBdevices[0].singleTact.Settings.ReferenceGain == 5)
                {
                    sensorRange.Items.Add(' ');
                    sensorRange.Items.Add("1");
                    sensorRange.Items.Add("10");
                    sensorRange.Items.Add("100");
                    sensorRange.Items.Add("4.5");
                    sensorRange.Items.Add("45");
                    sensorRange.Items.Add("450");
                }
                UIOffset = 30;
            }          
            tareAll.Top -= UIOffset;
            buttonSave.Top -= UIOffset;
            Settings.Top -= UIOffset;
            linkLabel1.Top -= UIOffset;
            Settings.Height += UIOffset;
            SetBaselineButton.Visible = false;
            ActiveSensorLabel.Visible = false;
            ActiveSensor.Visible = false;
        }

        /// <summary>
        /// Fill appropriate Values into GUI Comboboxes
        /// </summary>
        private void PopulateGUIFields()
        {

            // Populate i2c addresses
            i2cAddressInputComboBox_.Items.Clear();

            //TODO appears to be race condition to populate combo box
            // This causes the invalid settings warning
            for (int i = reservedAddresses; i < 128; i++)
            {
                i2cAddressInputComboBox_.Items
                                        .Add("0x" + i.ToString("X2"));
            }

            //Populate active sensor combobox
            int j = 0;
            foreach (string port in comPortList)
            {
                string[] portSplit = port.Split('-');
                // replace COM port with index
                String name = portSplit[1] + " " + (comPortList.IndexOf(port) + 1).ToString();

                if (USBdevices[j].singleTact.firmwareVersion > 0)
                {
                    if (USBdevices[j].isCalibrated)
                    {
                        name = name + "(calibrated)";
                    }                   
                }

                ActiveSensor.Items.Add(name);
                j++;
            }
            ActiveSensor.SelectedIndex = 0;
            activeSingleTact = USBdevices[0].singleTact;

            if(activeSingleTact.Settings.Scaling < 100)
            {
                activeSingleTact.Settings.Scaling = 100;
            }

            int maxWidth = 0;
            System.Windows.Forms.Label dummy = new System.Windows.Forms.Label();
            // find widest label to resize dropdown dynamically
            foreach (var obj in ActiveSensor.Items)
            {
                dummy.Text = obj.ToString();
                int temp = dummy.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            ActiveSensor.DropDownWidth = maxWidth;

            // Get firmware version
            byte fwRev = activeSingleTact.firmwareVersion;
            firmwareLabel.Text = fwRev.ToString();

        }

        /// <summary>
        /// Using ZedGraph, create a stripchart
        /// More info on Zedgraph can be found at: http://zedgraph.sourceforge.net/index.html
        /// </summary>
        void CreateStripChart()
        {
            // This is to remove all plots
            graph_.GraphPane.CurveList.Clear();

            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = graph_.GraphPane;

            // Draw a box item to highlight the valid range
            BoxObj box = new BoxObj(0, 512, 30, 512, Color.Empty,
                                    Color.FromArgb(150, Color.LightGreen));
            box.Fill = new Fill(Color.FromArgb(200, Color.LightGreen),
                                Color.FromArgb(200, Color.LightGreen), 45.0F);
            // Use the BehindGrid zorder to draw the highlight beneath the grid lines
            box.ZOrder = ZOrder.F_BehindGrid;
            myPane.GraphObjList.Add(box);

            //Lables
            myPane.XAxis.Title.Text = "Time (s)";
            myPane.YAxis.Title.Text = "Output (511 = Full Scale Range)";

            myPane.Title.IsVisible = false;
            myPane.Legend.IsVisible = true;

            //Set scale
            myPane.XAxis.Scale.Max = 20; //Show 30s of data
            myPane.XAxis.Scale.Min = -10;

            //Set scale
            myPane.YAxis.Scale.Max = 768; //Valid range
            myPane.YAxis.Scale.Min = -255;


            // Set font sizes
            myPane.XAxis.Title.FontSpec.Size = 10;
            myPane.YAxis.Title.FontSpec.Size = 10;
            myPane.XAxis.Scale.FontSpec.Size = 7;
            myPane.YAxis.Scale.FontSpec.Size = 7;

            //Make grid visible
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;

            // Refeshes the plot.
            graph_.AxisChange();
            graph_.Invalidate();
            graph_.Refresh();
        }

        /// <summary>
        /// Add new measurements to the graph
        /// </summary>
        /// <param name="time"></param>
        /// <param name="measurements"></param>
        private void AddData(double time, double[] measurements, USBdevice_GUI USB)
        {
            const double Radius = 15.0 / 2;
            const double Ntopsi = 145.03773773 / (Math.PI * Radius * Radius);

            if (NBtoForceFactor != 0)
            {
                if (convertToPressure)
                {
                    for (int i = 0; i < measurements.Length; i++)
                    {
                        measurements[i] = measurements[i] * NBtoForceFactor * Ntopsi / 512;
                    }
                }
                else
                {
                    for (int i = 0; i < measurements.Length; i++)
                        measurements[i] = measurements[i] * NBtoForceFactor / 512;
                }
            }

            memorySpaceUse = USB.dataBuffer.AddData(measurements, time);  // update

            if(autoSaveOutput != null)
            {
                foreach(var measurement in measurements)
                {
                    autoSaveOutput.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.f};{measurement}");
                }
                autoSaveOutput.Flush();
            }
        }

        private void updateGraph(USBdevice_GUI USB)
        {
            int index = USBdevices.IndexOf(USB); // get current sensor number
            SingleTactData data_pt = USB.dataBuffer;
            Color[] colours = { Color.Blue, Color.Orange, Color.DarkViolet, Color.Red, Color.DeepPink, Color.DarkSlateGray  };

            if (data_pt.data.Count > 0 && index < colours.Length)
            {
                // start graphing
                GraphPane graphPane = graph_.GraphPane;

                if (graphPane.CurveList.Count <= index)  // initialise curves
                {
                    string name = comPortList[index].ToString().Split('-')[1] + " " + (index + 1).ToString();
                    if (USBdevices[index].singleTact.firmwareVersion > 0)
                    {
                        if (USBdevices[index].isCalibrated)
                        {
                            name = name + "(calibrated)";
                        }
                        if (USB.singleTact.Settings.SerialNumber != 0)
                            name += " SN" + USB.singleTact.Settings.SerialNumber.ToString("D5");
                    }
                    LineItem myCurve = new LineItem(
                        name,
                        new PointPairList(),
                        colours[index],
                        SymbolType.None,
                        3.0f);
                    graphPane.CurveList.Add(myCurve);
                }
                else
                {
                    // update curve data with new readings
                    if (data_pt.data[0].Count > 1)
                    {
                        graphPane.CurveList[index].AddPoint(data_pt.data[0].Peek());//grab the latest value from the buffer.
                        if (graphPane.CurveList[index].NPts > 100 * 60) //only keep 6000 points on the screen
                            graphPane.CurveList[index].RemovePoint(0);
                    }
                }

                // This is to update the max and min value
                if (isFirstFrame_)
                {
                    graphPane.XAxis.Scale.Min = data_pt.MostRecentTime;
                    graphPane.XAxis.Scale.Max = graphPane.XAxis.Scale.Min + graphXRange_;
                    isFirstFrame_ = false;
                }

                if (data_pt.MostRecentTime >= graphPane.XAxis.Scale.Max)
                {
                    graphPane.XAxis.Scale.Max = data_pt.MostRecentTime;
                    graphPane.XAxis.Scale.Min = graphPane.XAxis.Scale.Max - graphXRange_;
                    //Update green valid region box
                    BoxObj b = (BoxObj)graphPane.GraphObjList[0];
                    b.Location.X = graphPane.XAxis.Scale.Max - graphXRange_;
                    if (NBtoForceFactor != 0)
                    {
                        b.Location.Y = Math.Min(graphPane.YAxis.Scale.Max, NBtoForceFactor);
                        b.Location.Height = Math.Min(graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min, NBtoForceFactor);
                    }
                    else
                    {
                        b.Location.Y = Math.Min(graphPane.YAxis.Scale.Max, 512);
                        b.Location.Height = Math.Min(graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min, 512);
                    }
                    try
                    {
                        graph_.AxisChange();
                    }
                    catch { }

                }
                graph_.Refresh();
            }
        }

        /// <summary>
        /// Finds a character to separate exported values.
        /// </summary>
        /// <returns>A semi-colon for locales where comma is the decimal 
        /// separator; otherwise a comma.</returns>
        private string safeSeparator()
        {
            double testValue = 3.14;
            string testText = testValue.ToString();

            if (testText.IndexOf(',') < 0)
                return ",";

            return ";";
        }

        //Save data to CSV
        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool backgroundWasRunning = AcquisitionWorker.IsBusy;

            if (backgroundWasRunning)
            {
                StopAcquisitionThread();
            }

            // Initialize the Dialog to save the file
            SaveFileDialog saveDataDialog = new SaveFileDialog();
            saveDataDialog.Filter = "*.csv|*.csv";
            saveDataDialog.RestoreDirectory = true;
            string fileName = "SingleTactSampleData";
            if (hasStartTime)
                fileName += "_" + ((DateTimeOffset)systemStartTime).ToUnixTimeSeconds();
            saveDataDialog.FileName = fileName;
            Invoke((Action)(() => { 
                if (saveDataDialog.ShowDialog() == DialogResult.OK)
                {
                    // To fix Issue 3, separate exported values by semi-colon instead
                    // of comma if current locale's decimal separator is comma.
                    string separator = safeSeparator();
                    string saveFileName = saveDataDialog.FileName;
                    StreamWriter dataWriter = new StreamWriter(saveFileName, false, Encoding.Default);
                    if (hasStartTime)
                    {
                        dataWriter.WriteLine("Start Time" + separator + systemStartTime.ToString());
                        dataWriter.WriteLine("");
                    }
                    // write column headers
                    string columnNames = "Time(s)" + separator;
                    // populate columns with serial port names
                    foreach(string portName in comPortList)
                    {
                        int index = comPortList.IndexOf(portName);
                        string name = portName.ToString().Split('-')[1] + " " + (index + 1).ToString();
                        if (USBdevices[index].singleTact.firmwareVersion > 0)
                        {
                            if (USBdevices[index].isCalibrated)
                            {
                                name = name + "(calibrated)";
                            }                            
                        }
                        if (NBtoForceFactor != 0)
                        {
                            columnNames += portName + " (N)" + separator;
                        }
                        else
                        {
                            columnNames += portName + " (NB)" + separator;
                        }
                    }
                    if (NBtoForceFactor == 0)
                    {
                        columnNames += "NB (0 = 0 PSI;  511 = Full Scale Range)";
                    }
                    else
                    {
                        columnNames += "(Selected Full Scale Range: " + NBtoForceFactor + "N)";
                    }
                    dataWriter.WriteLine(columnNames);

                    // write data
                    string row = "";
                    int data_length = USBdevices[0].dataBuffer.data[0].Count;
                    for (int i = 0; i < data_length; i++)  // for each sensor reading
                    {
                        bool first = true;
                        foreach (USBdevice_GUI USB in USBdevices)
                        {
                            try
                            {
                                SingleTactData data = USB.dataBuffer;
                                PointPair dataPoint = data.data[0][i];
                                if (first) // only save the time the first sensor's reading was taken
                                {
                                    // round the time value to mitigate any uncertainty around sampling time
                                    row += Math.Round(dataPoint.X, 3) + separator + dataPoint.Y + separator;
                                    first = false;
                                }
                                else
                                {
                                    row += dataPoint.Y + separator;
                                }
                            }
                            catch  // index out of range, unequal number of sensor readings
                            {
                                row += "null" + separator;
                            }
                        }
                        dataWriter.WriteLine(row);
                        row = "";
                    }

                    dataWriter.Close();
                }
            }));

            if (backgroundWasRunning)
            {
                StartAcquisitionThread();
            }
        }

        private void tareAllButton_Click(object sender, EventArgs e)
        {
            tareAll.Enabled = false;
            StopAcquisitionThread();
            foreach (USBdevice USB in USBdevices)
            {
                SingleTact singletact = USB.singleTact;
                if (singletact.Tare())
                {
                    RefreshFlashSettings_Click(null, null);
                }
            }
            StartAcquisitionThread();
            tareAll.Enabled = true;
        }

        /// <summary>
        /// Stop acquisition thread
        /// </summary>
        private void StopAcquisitionThread()
        {
            AcquisitionWorker.CancelAsync();
            while (false == backgroundIsFinished_)
            {
                System.Windows.Forms.Application.DoEvents(); //Wait for us to finish
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Start the Acquisition Thread
        /// </summary>
        private void StartAcquisitionThread()
        {
            AcquisitionWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Do work - process sensor data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcquisitionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundIsFinished_ = false;
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending) //Do the work
            {
                foreach (USBdevice_GUI USB in USBdevices)
                {
                    SingleTact singleTact = USB.singleTact;
                    SingleTactFrame newFrame = singleTact.ReadSensorData(); //Get sensor data

                    if (null != newFrame) //If we have data
                    {
                        USB.addFrame(newFrame);

                        // use first timestamp only to quantise readings and match csv output
                        AddData(USBdevices[0].lastTimeStamp, newFrame.SensorData, USB); //Add to stripchart

                        if (!hasStartTime)
                        {
                            systemStartTime = DateTime.Now - TimeSpan.FromSeconds(USBdevices[0].lastTimeStamp);
                            hasStartTime = true;
                        }
                    }
                    else  // USB has been unplugged
                    {
                        new Thread(() =>
                        {
                            guiTimer_.Stop();
                            backgroundIsFinished_ = true;
                            var index = USBdevices.IndexOf(USB);                            
                            var comPort = comPortList[index];
                            var result = MessageBox.Show(
                                comPort.ToString() + " has been unplugged.\nWould you like to save your data before exiting?",
                                "Error!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error);
                            if (result == DialogResult.Yes)
                            {
                                buttonSave_Click(this, null);
                            }
                            Application.Exit();
                        }).Start();
                        backgroundIsFinished_ = false;
                        StopAcquisitionThread();
                        break;
                    }

                    //Calculate rate
                    double delta = newFrame.TimeStamp - USB.lastTimeStamp; // calculate delta relative to previous sensor's last reading
                        if (delta != 0)
                            measuredFrequency_ = measuredFrequency_ * 0.95 + 0.05 * (1.0 / (delta));  //Averaging
                            //measuredFrequency_ = 1/delta;
                        USB.setTimestamp(newFrame.TimeStamp);
                }
            }
        }

        /// <summary>
        /// Update plot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guiTimer__Tick(object sender, EventArgs e)
        {

            foreach (USBdevice_GUI USB in USBdevices)
            {
                if(!backgroundIsFinished_)
                    updateGraph(USB);
            }                

            //Update update rate
            timerItr_++;
            if (0 == timerItr_ % 5)
                this.Text = Application.ProductName + " - Version " + Application.ProductVersion + " [ " + measuredFrequency_.ToString("##0") + " Hz ]";
            memorySpaceBar.Value = memorySpaceUse;
        }

        /// <summary>
        /// Done - we are closing down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcquisitionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundIsFinished_ = true;
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(AcquisitionWorker.IsBusy)
                StopAcquisitionThread();
        }

        /// <summary>
        /// Get settings from sensor flash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshFlashSettings_Click(object sender, EventArgs e)
        {
            SetBaselineButton.Enabled = false;
            bool backgroundWasRunning = AcquisitionWorker.IsBusy;

            if (backgroundWasRunning)
            StopAcquisitionThread();

            if (!activeSingleTact.PullSettingsFromHardware())
            {
                MessageBox.Show(
                    "Failed to retrieve current settings.",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    byte fwRev = activeSingleTact.firmwareVersion;
                    firmwareLabel.Text = fwRev.ToString();
                    textAddress.Text = "0x" + activeSingleTact.Settings.I2CAddress.ToString("X2");
                    textGain.Text = activeSingleTact.Settings.ReferenceGain.ToString("00") + " (" + (activeSingleTact.Settings.ReferenceGain + 1).ToString("0") + "x)";
                    textTare.Text = activeSingleTact.Settings.Baselines.ElementAt(0).ToString("0000");
                    textScale.Text = activeSingleTact.Settings.Scaling.ToString();
                    i2cAddressInputComboBox_.SelectedIndex = activeSingleTact.Settings.I2CAddress - reservedAddresses;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Invalid settings", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (activeSingleTact.Settings.ReferenceGain == 0 && activeSingleTact.isCalibrated == true)
                {
                    MessageBox.Show("The calibration appears to be corrupt. \nPlease try power cycling the electronics by unplugging and then plugging in the USB. \nIf the problem still persists, please contact SingleTact Tech Support.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Process.Start("https://www.singletact.com/support/");
                }
            }
            

            if (backgroundWasRunning)
            {
                StartAcquisitionThread();
            }
            SetBaselineButton.Enabled = true;
        }

        /// <summary>
        /// Set settings to sensor flash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSettingsButton_Click(object sender, EventArgs e)
        {
            SetSettingsButton.Enabled = false;
            bool backgroundWasRunning = AcquisitionWorker.IsBusy;

            if (backgroundWasRunning)
            StopAcquisitionThread();

            try
            {
                // ReferenceGain still has value from PullSettingsFromHardware
                // which is OK because the firmware fully controls this anyway.
                activeSingleTact.Settings.I2CAddress = (byte)(i2cAddressInputComboBox_.SelectedIndex + reservedAddresses);
                activeSingleTact.Settings.Accumulator = 5;
                if (gainBox.Visible == true)
                {                   
                    activeSingleTact.Settings.ReferenceGain = Convert.ToByte(gainBox.Text);
                }
                if (scaleNumUp.Visible == true)
                {
                    activeSingleTact.Settings.Scaling = (ushort)scaleNumUp.Value;
                }
                activeSingleTact.PushSettingsToHardware();

                RefreshFlashSettings_Click(this, null);

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid settings", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            


            if (backgroundWasRunning)
            {
                StartAcquisitionThread();
            }
        }

        /// <summary>
        /// Update the sensor baseline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBaselineButton_Click(object sender, EventArgs e)
        {
            StopAcquisitionThread();
            if (activeSingleTact.Tare())
            {
                RefreshFlashSettings_Click(null, null);
            }

            StartAcquisitionThread();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var text = linkLabel1.Text;
            if (linkLabel1.Text.Contains((char)0x25BC))
            {
                linkLabel1.Text = text.Replace((char)0x25BC, (char)0x25B2);
            }
            else
            {
                linkLabel1.Text = text.Replace((char)0x25B2, (char)0x25BC);
            }
            Settings.Visible = !Settings.Visible;
        }

        private void ActiveSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeSingleTact = USBdevices[ActiveSensor.SelectedIndex].singleTact;
            if (activeSingleTact.isUSB && activeSingleTact.isCalibrated)
            {
                linkLabel1.Visible = true;
                if (Settings.TabPages.Count > 1)
                {
                    Settings.TabPages.RemoveAt(Settings.TabPages.Count - 1);
                }
            }
            else if (activeSingleTact.isUSB && !activeSingleTact.isCalibrated)
            {
                linkLabel1.Visible = true;
                SetSettingsButton.Enabled = true;
            }
            else if (!activeSingleTact.isUSB && activeSingleTact.isCalibrated)
            {
                linkLabel1.Visible = true;
                SetSettingsButton.Enabled = true;
            }
            else
            {
                linkLabel1.Visible = true;
                SetSettingsButton.Enabled = true;
            }
            RefreshFlashSettings_Click(this, null); //Update display
        }
        private void sensorRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tempFactor = 0;
            try
            {
                tempFactor = Convert.ToDouble(sensorRange.SelectedItem);
            }
            catch
            {
                tempFactor = 0;
            }
            if (tempFactor == NBtoForceFactor && convertToPressure == cbConvertToPressure.Checked)
                return;
            NBtoForceFactor = tempFactor;
            convertToPressure = cbConvertToPressure.Checked;
            double greenBoxMax = 0;
            if (NBtoForceFactor != 0)
            {
                if (cbConvertToPressure.Checked)
                {
                    // TODO
                    graph_.GraphPane.YAxis.Title.Text = "Pressure (psi)";
                    graph_.GraphPane.YAxis.Scale.Max = 10 * NBtoForceFactor; //Valid range
                    graph_.GraphPane.YAxis.Scale.Min = 0 * NBtoForceFactor;
                    greenBoxMax = NBtoForceFactor;
                }
                else
                {
                    graph_.GraphPane.YAxis.Title.Text = "Force (N)";
                    graph_.GraphPane.YAxis.Scale.Max = 1.5 * NBtoForceFactor; //Valid range
                    graph_.GraphPane.YAxis.Scale.Min = -0.5 * NBtoForceFactor;
                    greenBoxMax = NBtoForceFactor;
                }
                
            }
            else
            {
                graph_.GraphPane.YAxis.Title.Text = "Output (511 = Full Scale Range)";
                graph_.GraphPane.YAxis.Scale.Max = 768; //Valid range
                graph_.GraphPane.YAxis.Scale.Min = -255;               
                greenBoxMax = 512;
            }
            BoxObj b = (BoxObj)graph_.GraphPane.GraphObjList[0];
            b.Location.X = 0;
            b.Location.Y = Math.Min(graph_.GraphPane.YAxis.Scale.Max, greenBoxMax);
            b.Location.Height = Math.Min(graph_.GraphPane.YAxis.Scale.Max - graph_.GraphPane.YAxis.Scale.Min, greenBoxMax);
            graph_.GraphPane.XAxis.Scale.Max = 30;
            graph_.GraphPane.XAxis.Scale.Min = 0;
            USBdevices[0].setTimestamp(0);
            USBdevices[0].removeAllFrame();
            USBdevices[0].singleTact.resetTimeStamp();
            hasStartTime = false;
            graph_.GraphPane.CurveList[0].Clear();
            graph_.AxisChange();
            graph_.Invalidate();
            graph_.Refresh();
        }

        private void memorySpaceBar_Click(object sender, EventArgs e)
        {
            foreach (USBdevice_GUI USB in USBdevices)
            {
                USB.dataBuffer.data[0].Clear();
            }
            hasStartTime = false;
        }

        private void memorySpaceBar_MouseHover(object sender, EventArgs e)
        {            
            toolTip1.Show("Click here to clear the buffer.", memorySpaceBar);
        }

        private void picPpsLogo_DoubleClick(object sender, EventArgs e)
        {
            if (activeSingleTact.isCalibrated)
            {
                scaleNumUp.Visible = true;
                gainBox.Visible = true;
                gainBox.SelectedIndex = 0;
                SetSettingsButton.Text = "Program";

                label2.Text = "Gain / Scale";
                label5.Visible = false;
                i2cAddressInputComboBox_.Visible = false;

                if (activeSingleTact.isUSB && activeSingleTact.isCalibrated)
                {
                    Settings.TabPages.Insert(1, tabPage2);

                    linkLabel1.Visible = true;
                    SetSettingsButton.Enabled = true;
                    i2cAddressInputComboBox_.Enabled = false;
                }
            }
        }

        private void btnStartStopAutosave_Click(object sender, EventArgs e)
        {
            if(autoSaveOutput == null)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "*.csv|*.csv";
                    dialog.RestoreDirectory = true;
                    dialog.FileName = $"SingleTact Data {DateTime.Now:yyyy-MM-dd HHmmss}.csv";
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    autoSaveOutput = new StreamWriter(dialog.OpenFile());
                    autoSaveOutput.WriteLine("Time;Value");
                }
                btnStartStopAutosave.Text = "Stop autosave";
            }
            else
            {
                btnStartStopAutosave.Text = "Start autosave";
                autoSaveOutput.Close();
                autoSaveOutput = null;
            }
        }
    }

}
