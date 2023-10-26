//-----------------------------------------------------------------------------
//  Copyright (c) 2015 Pressure Profile Systems
//
//  Licensed under the MIT license. This file may not be copied, modified, or
//  distributed except according to those terms.
//-----------------------------------------------------------------------------

using System;

namespace SingleTact_Demo
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.graph_ = new ZedGraph.ZedGraphControl();
            this.AcquisitionWorker = new System.ComponentModel.BackgroundWorker();
            this.guiTimer_ = new System.Windows.Forms.Timer(this.components);
            this.picPpsLogo = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.memorySpaceBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.textScale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firmwareLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textGain = new System.Windows.Forms.Label();
            this.textTare = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scaleNumUp = new System.Windows.Forms.NumericUpDown();
            this.gainBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.i2cAddressInputComboBox_ = new System.Windows.Forms.ComboBox();
            this.SetSettingsButton = new System.Windows.Forms.Button();
            this.ActiveSensor = new System.Windows.Forms.ComboBox();
            this.ActiveSensorLabel = new System.Windows.Forms.Label();
            this.sensorRange = new System.Windows.Forms.ComboBox();
            this.sensorRangeLabel = new System.Windows.Forms.Label();
            this.tareAll = new System.Windows.Forms.Button();
            this.SetBaselineButton = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStartStopAutosave = new System.Windows.Forms.Button();
            this.cbConvertToPressure = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPpsLogo)).BeginInit();
            this.Settings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumUp)).BeginInit();
            this.SuspendLayout();
            // 
            // graph_
            // 
            this.graph_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph_.AutoScroll = true;
            this.graph_.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.graph_.AutoSize = true;
            this.graph_.IsEnableHPan = false;
            this.graph_.IsEnableHZoom = false;
            this.graph_.Location = new System.Drawing.Point(255, 27);
            this.graph_.Margin = new System.Windows.Forms.Padding(13, 11, 13, 11);
            this.graph_.Name = "graph_";
            this.graph_.ScrollGrace = 0D;
            this.graph_.ScrollMaxX = 0D;
            this.graph_.ScrollMaxY = 0D;
            this.graph_.ScrollMaxY2 = 0D;
            this.graph_.ScrollMinX = 0D;
            this.graph_.ScrollMinY = 0D;
            this.graph_.ScrollMinY2 = 0D;
            this.graph_.Size = new System.Drawing.Size(771, 559);
            this.graph_.TabIndex = 1;
            // 
            // AcquisitionWorker
            // 
            this.AcquisitionWorker.WorkerReportsProgress = true;
            this.AcquisitionWorker.WorkerSupportsCancellation = true;
            this.AcquisitionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AcquisitionWorker_DoWork);
            this.AcquisitionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AcquisitionWorker_RunWorkerCompleted);
            // 
            // guiTimer_
            // 
            this.guiTimer_.Interval = 1;
            this.guiTimer_.Tick += new System.EventHandler(this.guiTimer__Tick);
            // 
            // picPpsLogo
            // 
            this.picPpsLogo.Image = ((System.Drawing.Image)(resources.GetObject("picPpsLogo.Image")));
            this.picPpsLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picPpsLogo.InitialImage")));
            this.picPpsLogo.Location = new System.Drawing.Point(9, 27);
            this.picPpsLogo.Name = "picPpsLogo";
            this.picPpsLogo.Size = new System.Drawing.Size(229, 68);
            this.picPpsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPpsLogo.TabIndex = 46;
            this.picPpsLogo.TabStop = false;
            this.picPpsLogo.DoubleClick += new System.EventHandler(this.picPpsLogo_DoubleClick);
            // 
            // Settings
            // 
            this.Settings.AccessibleName = "Settings";
            this.Settings.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Settings.Controls.Add(this.tabPage1);
            this.Settings.Controls.Add(this.tabPage2);
            this.Settings.Location = new System.Drawing.Point(9, 339);
            this.Settings.Margin = new System.Windows.Forms.Padding(1);
            this.Settings.Name = "Settings";
            this.Settings.SelectedIndex = 0;
            this.Settings.Size = new System.Drawing.Size(236, 247);
            this.Settings.TabIndex = 56;
            this.Settings.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.memorySpaceBar);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textScale);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.firmwareLabel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textAddress);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textGain);
            this.tabPage1.Controls.Add(this.textTare);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(228, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            // 
            // memorySpaceBar
            // 
            this.memorySpaceBar.Location = new System.Drawing.Point(131, 169);
            this.memorySpaceBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.memorySpaceBar.Name = "memorySpaceBar";
            this.memorySpaceBar.Size = new System.Drawing.Size(79, 13);
            this.memorySpaceBar.TabIndex = 53;
            this.memorySpaceBar.Click += new System.EventHandler(this.memorySpaceBar_Click);
            this.memorySpaceBar.MouseHover += new System.EventHandler(this.memorySpaceBar_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Buffer Use:";
            // 
            // textScale
            // 
            this.textScale.BackColor = System.Drawing.Color.Transparent;
            this.textScale.Location = new System.Drawing.Point(131, 137);
            this.textScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textScale.Name = "textScale";
            this.textScale.Size = new System.Drawing.Size(79, 13);
            this.textScale.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Scale:";
            // 
            // firmwareLabel
            // 
            this.firmwareLabel.AutoSize = true;
            this.firmwareLabel.Location = new System.Drawing.Point(131, 13);
            this.firmwareLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.firmwareLabel.Name = "firmwareLabel";
            this.firmwareLabel.Size = new System.Drawing.Size(40, 13);
            this.firmwareLabel.TabIndex = 49;
            this.firmwareLabel.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Firmware Version:";
            // 
            // textAddress
            // 
            this.textAddress.BackColor = System.Drawing.Color.Transparent;
            this.textAddress.Location = new System.Drawing.Point(131, 41);
            this.textAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(79, 13);
            this.textAddress.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "I2C Address:";
            // 
            // textGain
            // 
            this.textGain.BackColor = System.Drawing.Color.Transparent;
            this.textGain.Location = new System.Drawing.Point(131, 73);
            this.textGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textGain.Name = "textGain";
            this.textGain.Size = new System.Drawing.Size(79, 13);
            this.textGain.TabIndex = 40;
            // 
            // textTare
            // 
            this.textTare.BackColor = System.Drawing.Color.Transparent;
            this.textTare.Location = new System.Drawing.Point(131, 105);
            this.textTare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textTare.Name = "textTare";
            this.textTare.Size = new System.Drawing.Size(79, 13);
            this.textTare.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Baseline:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Reference Gain:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.scaleNumUp);
            this.tabPage2.Controls.Add(this.gainBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.i2cAddressInputComboBox_);
            this.tabPage2.Controls.Add(this.SetSettingsButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage2.Size = new System.Drawing.Size(228, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Setting";
            // 
            // scaleNumUp
            // 
            this.scaleNumUp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scaleNumUp.Location = new System.Drawing.Point(115, 66);
            this.scaleNumUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scaleNumUp.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.scaleNumUp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleNumUp.Name = "scaleNumUp";
            this.scaleNumUp.Size = new System.Drawing.Size(100, 20);
            this.scaleNumUp.TabIndex = 57;
            this.scaleNumUp.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleNumUp.Visible = false;
            // 
            // gainBox
            // 
            this.gainBox.FormattingEnabled = true;
            this.gainBox.Items.AddRange(new object[] {
            "1",
            "5"});
            this.gainBox.Location = new System.Drawing.Point(10, 66);
            this.gainBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gainBox.Name = "gainBox";
            this.gainBox.Size = new System.Drawing.Size(99, 21);
            this.gainBox.TabIndex = 56;
            this.gainBox.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 71);
            this.label2.TabIndex = 55;
            this.label2.Text = "Warning: changing the I2C Address can damage the hardware. Only update this if yo" +
    "u are sure it is necessary.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "I2C Address:";
            // 
            // i2cAddressInputComboBox_
            // 
            this.i2cAddressInputComboBox_.FormattingEnabled = true;
            this.i2cAddressInputComboBox_.Location = new System.Drawing.Point(115, 91);
            this.i2cAddressInputComboBox_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.i2cAddressInputComboBox_.Name = "i2cAddressInputComboBox_";
            this.i2cAddressInputComboBox_.Size = new System.Drawing.Size(101, 21);
            this.i2cAddressInputComboBox_.TabIndex = 54;
            // 
            // SetSettingsButton
            // 
            this.SetSettingsButton.Location = new System.Drawing.Point(8, 118);
            this.SetSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetSettingsButton.Name = "SetSettingsButton";
            this.SetSettingsButton.Size = new System.Drawing.Size(204, 28);
            this.SetSettingsButton.TabIndex = 51;
            this.SetSettingsButton.Text = "Update I2C Address";
            this.SetSettingsButton.UseVisualStyleBackColor = true;
            this.SetSettingsButton.Click += new System.EventHandler(this.SetSettingsButton_Click);
            // 
            // ActiveSensor
            // 
            this.ActiveSensor.FormattingEnabled = true;
            this.ActiveSensor.Location = new System.Drawing.Point(108, 157);
            this.ActiveSensor.Margin = new System.Windows.Forms.Padding(1);
            this.ActiveSensor.Name = "ActiveSensor";
            this.ActiveSensor.Size = new System.Drawing.Size(135, 21);
            this.ActiveSensor.TabIndex = 69;
            this.ActiveSensor.SelectedIndexChanged += new System.EventHandler(this.ActiveSensor_SelectedIndexChanged);
            // 
            // ActiveSensorLabel
            // 
            this.ActiveSensorLabel.AutoSize = true;
            this.ActiveSensorLabel.Location = new System.Drawing.Point(5, 159);
            this.ActiveSensorLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ActiveSensorLabel.Name = "ActiveSensorLabel";
            this.ActiveSensorLabel.Size = new System.Drawing.Size(85, 13);
            this.ActiveSensorLabel.TabIndex = 70;
            this.ActiveSensorLabel.Text = "Selected Sensor";
            // 
            // sensorRange
            // 
            this.sensorRange.FormattingEnabled = true;
            this.sensorRange.Location = new System.Drawing.Point(108, 157);
            this.sensorRange.Margin = new System.Windows.Forms.Padding(1);
            this.sensorRange.Name = "sensorRange";
            this.sensorRange.Size = new System.Drawing.Size(135, 21);
            this.sensorRange.TabIndex = 69;
            this.sensorRange.Visible = false;
            this.sensorRange.SelectedIndexChanged += new System.EventHandler(this.sensorRange_SelectedIndexChanged);
            // 
            // sensorRangeLabel
            // 
            this.sensorRangeLabel.AutoSize = true;
            this.sensorRangeLabel.Location = new System.Drawing.Point(5, 159);
            this.sensorRangeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.sensorRangeLabel.Name = "sensorRangeLabel";
            this.sensorRangeLabel.Size = new System.Drawing.Size(92, 13);
            this.sensorRangeLabel.TabIndex = 70;
            this.sensorRangeLabel.Text = "Sensor Range (N)";
            this.sensorRangeLabel.Visible = false;
            // 
            // tareAll
            // 
            this.tareAll.Location = new System.Drawing.Point(9, 219);
            this.tareAll.Margin = new System.Windows.Forms.Padding(1);
            this.tareAll.Name = "tareAll";
            this.tareAll.Size = new System.Drawing.Size(231, 28);
            this.tareAll.TabIndex = 68;
            this.tareAll.Text = "Tare All Sensors";
            this.tareAll.UseVisualStyleBackColor = true;
            this.tareAll.Click += new System.EventHandler(this.tareAllButton_Click);
            // 
            // SetBaselineButton
            // 
            this.SetBaselineButton.Location = new System.Drawing.Point(9, 186);
            this.SetBaselineButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetBaselineButton.Name = "SetBaselineButton";
            this.SetBaselineButton.Size = new System.Drawing.Size(231, 28);
            this.SetBaselineButton.TabIndex = 67;
            this.SetBaselineButton.Text = "Tare Selected Sensor";
            this.SetBaselineButton.UseVisualStyleBackColor = true;
            this.SetBaselineButton.Click += new System.EventHandler(this.SetBaselineButton_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(9, 253);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(231, 28);
            this.buttonSave.TabIndex = 63;
            this.buttonSave.Text = "Export Chart Data";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(7, 311);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(68, 13);
            this.linkLabel1.TabIndex = 71;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "▼ Advanced";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // btnStartStopAutosave
            // 
            this.btnStartStopAutosave.Location = new System.Drawing.Point(6, 101);
            this.btnStartStopAutosave.Name = "btnStartStopAutosave";
            this.btnStartStopAutosave.Size = new System.Drawing.Size(232, 23);
            this.btnStartStopAutosave.TabIndex = 72;
            this.btnStartStopAutosave.Text = "Start autosave";
            this.btnStartStopAutosave.UseVisualStyleBackColor = true;
            this.btnStartStopAutosave.Click += new System.EventHandler(this.btnStartStopAutosave_Click);
            // 
            // cbConvertToPressure
            // 
            this.cbConvertToPressure.AutoSize = true;
            this.cbConvertToPressure.Location = new System.Drawing.Point(6, 130);
            this.cbConvertToPressure.Name = "cbConvertToPressure";
            this.cbConvertToPressure.Size = new System.Drawing.Size(118, 17);
            this.cbConvertToPressure.TabIndex = 73;
            this.cbConvertToPressure.Text = "Convert to pressure";
            this.cbConvertToPressure.UseVisualStyleBackColor = true;
            this.cbConvertToPressure.CheckedChanged += new System.EventHandler(this.sensorRange_SelectedIndexChanged);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1048, 606);
            this.Controls.Add(this.cbConvertToPressure);
            this.Controls.Add(this.btnStartStopAutosave);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ActiveSensor);
            this.Controls.Add(this.ActiveSensorLabel);
            this.Controls.Add(this.tareAll);
            this.Controls.Add(this.SetBaselineButton);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.picPpsLogo);
            this.Controls.Add(this.graph_);
            this.Controls.Add(this.sensorRange);
            this.Controls.Add(this.sensorRangeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(510, 212);
            this.Name = "GUI";
            this.Text = "PPS SingleTact Demo [XXHz]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPpsLogo)).EndInit();
            this.Settings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private ZedGraph.ZedGraphControl graph_;
        private System.ComponentModel.BackgroundWorker AcquisitionWorker;
        private System.Windows.Forms.Timer guiTimer_;
        private System.Windows.Forms.PictureBox picPpsLogo;
        private System.Windows.Forms.TabControl Settings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox i2cAddressInputComboBox_;
        private System.Windows.Forms.Button SetSettingsButton;
        private System.Windows.Forms.Label textAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label textGain;
        private System.Windows.Forms.Label textTare;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ActiveSensor;
        private System.Windows.Forms.Label ActiveSensorLabel;
        private System.Windows.Forms.ComboBox sensorRange;
        private System.Windows.Forms.Label sensorRangeLabel;
        private System.Windows.Forms.Button tareAll;
        private System.Windows.Forms.Button SetBaselineButton;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label firmwareLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label textScale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar memorySpaceBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox gainBox;
        private System.Windows.Forms.NumericUpDown scaleNumUp;
        private System.Windows.Forms.Button btnStartStopAutosave;
        private System.Windows.Forms.CheckBox cbConvertToPressure;
    }
}
