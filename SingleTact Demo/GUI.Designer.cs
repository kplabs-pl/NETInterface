﻿//-----------------------------------------------------------------------------
//  Copyright (c) 2015 Pressure Profile Systems
//
//  Licensed under the MIT license. This file may not be copied, modified, or
//  distributed except according to those terms.
//-----------------------------------------------------------------------------

﻿namespace SingleTact_Demo
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
         this.RefreshFlashSettings = new System.Windows.Forms.Button();
         this.SetSettingsButton = new System.Windows.Forms.Button();
         this.SetBaselineButton = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.textAddress = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.textScale = new System.Windows.Forms.TextBox();
         this.textTare = new System.Windows.Forms.TextBox();
         this.textGain = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.buttonSave = new System.Windows.Forms.Button();
         this.AcquisitionWorker = new System.ComponentModel.BackgroundWorker();
         this.i2cAddressInputComboBox_ = new System.Windows.Forms.ComboBox();
         this.scaleInputTrackBar_ = new System.Windows.Forms.TrackBar();
         this.ScaleInputValueLabel = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.sensorTypeSelector = new System.Windows.Forms.ComboBox();
         this.ResetSensorButton = new System.Windows.Forms.Button();
         this.guiTimer_ = new System.Windows.Forms.Timer(this.components);
         this.LockButton = new System.Windows.Forms.Button();
         this.singleTact_ = new SingleTactLibrary.SingleTact(this.components);
         this.arduinoSingleTactDriver = new SingleTactLibrary.ArduinoSingleTactDriver(this.components);
         this.picPpsLogo = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.scaleInputTrackBar_)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picPpsLogo)).BeginInit();
         this.SuspendLayout();
         // 
         // graph_
         // 
         this.graph_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.graph_.IsEnableHPan = false;
         this.graph_.IsEnableHZoom = false;
         this.graph_.Location = new System.Drawing.Point(261, 22);
         this.graph_.Name = "graph_";
         this.graph_.ScrollGrace = 0D;
         this.graph_.ScrollMaxX = 0D;
         this.graph_.ScrollMaxY = 0D;
         this.graph_.ScrollMaxY2 = 0D;
         this.graph_.ScrollMinX = 0D;
         this.graph_.ScrollMinY = 0D;
         this.graph_.ScrollMinY2 = 0D;
         this.graph_.Size = new System.Drawing.Size(561, 500);
         this.graph_.TabIndex = 1;
         // 
         // RefreshFlashSettings
         // 
         this.RefreshFlashSettings.Location = new System.Drawing.Point(58, 128);
         this.RefreshFlashSettings.Name = "RefreshFlashSettings";
         this.RefreshFlashSettings.Size = new System.Drawing.Size(104, 23);
         this.RefreshFlashSettings.TabIndex = 4;
         this.RefreshFlashSettings.Text = "Refresh";
         this.RefreshFlashSettings.UseVisualStyleBackColor = true;
         this.RefreshFlashSettings.Click += new System.EventHandler(this.RefreshFlashSettings_Click);
         // 
         // SetSettingsButton
         // 
         this.SetSettingsButton.Location = new System.Drawing.Point(9, 135);
         this.SetSettingsButton.Name = "SetSettingsButton";
         this.SetSettingsButton.Size = new System.Drawing.Size(102, 23);
         this.SetSettingsButton.TabIndex = 5;
         this.SetSettingsButton.Text = "Set Configuration";
         this.SetSettingsButton.UseVisualStyleBackColor = true;
         this.SetSettingsButton.Click += new System.EventHandler(this.SetSettingsButton_Click);
         // 
         // SetBaselineButton
         // 
         this.SetBaselineButton.Location = new System.Drawing.Point(114, 135);
         this.SetBaselineButton.Name = "SetBaselineButton";
         this.SetBaselineButton.Size = new System.Drawing.Size(102, 23);
         this.SetBaselineButton.TabIndex = 8;
         this.SetBaselineButton.Text = "Update Baseline";
         this.SetBaselineButton.UseVisualStyleBackColor = true;
         this.SetBaselineButton.Click += new System.EventHandler(this.SetBaselineButton_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(13, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(79, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "I2C Address:";
         // 
         // textAddress
         // 
         this.textAddress.BackColor = System.Drawing.SystemColors.Control;
         this.textAddress.Location = new System.Drawing.Point(116, 19);
         this.textAddress.Name = "textAddress";
         this.textAddress.Size = new System.Drawing.Size(102, 20);
         this.textAddress.TabIndex = 10;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(13, 100);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(83, 13);
         this.label9.TabIndex = 36;
         this.label9.Text = "Scale Factor:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(13, 74);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(59, 13);
         this.label8.TabIndex = 35;
         this.label8.Text = "Baseline:";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(13, 48);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(100, 13);
         this.label7.TabIndex = 34;
         this.label7.Text = "Reference Gain:";
         // 
         // textScale
         // 
         this.textScale.BackColor = System.Drawing.SystemColors.Control;
         this.textScale.Location = new System.Drawing.Point(116, 97);
         this.textScale.Name = "textScale";
         this.textScale.Size = new System.Drawing.Size(102, 20);
         this.textScale.TabIndex = 33;
         // 
         // textTare
         // 
         this.textTare.BackColor = System.Drawing.SystemColors.Control;
         this.textTare.Location = new System.Drawing.Point(116, 71);
         this.textTare.Name = "textTare";
         this.textTare.Size = new System.Drawing.Size(102, 20);
         this.textTare.TabIndex = 32;
         // 
         // textGain
         // 
         this.textGain.BackColor = System.Drawing.SystemColors.Control;
         this.textGain.Location = new System.Drawing.Point(116, 45);
         this.textGain.Name = "textGain";
         this.textGain.Size = new System.Drawing.Size(102, 20);
         this.textGain.TabIndex = 31;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(17, 28);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(79, 13);
         this.label5.TabIndex = 43;
         this.label5.Text = "I2C Address:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(15, 84);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(83, 13);
         this.label4.TabIndex = 39;
         this.label4.Text = "Scale Factor:";
         // 
         // buttonSave
         // 
         this.buttonSave.Location = new System.Drawing.Point(23, 496);
         this.buttonSave.Name = "buttonSave";
         this.buttonSave.Size = new System.Drawing.Size(207, 23);
         this.buttonSave.TabIndex = 45;
         this.buttonSave.Text = "Export Chart Data";
         this.buttonSave.UseVisualStyleBackColor = true;
         this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
         // 
         // AcquisitionWorker
         // 
         this.AcquisitionWorker.WorkerReportsProgress = true;
         this.AcquisitionWorker.WorkerSupportsCancellation = true;
         this.AcquisitionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AcquisitionWorker_DoWork);
         this.AcquisitionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AcquisitionWorker_RunWorkerCompleted);
         // 
         // i2cAddressInputComboBox_
         // 
         this.i2cAddressInputComboBox_.FormattingEnabled = true;
         this.i2cAddressInputComboBox_.Location = new System.Drawing.Point(116, 25);
         this.i2cAddressInputComboBox_.Name = "i2cAddressInputComboBox_";
         this.i2cAddressInputComboBox_.Size = new System.Drawing.Size(102, 21);
         this.i2cAddressInputComboBox_.TabIndex = 47;
         // 
         // scaleInputTrackBar_
         // 
         this.scaleInputTrackBar_.Location = new System.Drawing.Point(110, 84);
         this.scaleInputTrackBar_.Maximum = 6400;
         this.scaleInputTrackBar_.Minimum = 100;
         this.scaleInputTrackBar_.Name = "scaleInputTrackBar_";
         this.scaleInputTrackBar_.Size = new System.Drawing.Size(113, 45);
         this.scaleInputTrackBar_.TabIndex = 49;
         this.scaleInputTrackBar_.TickFrequency = 640;
         this.scaleInputTrackBar_.Value = 100;
         this.scaleInputTrackBar_.Scroll += new System.EventHandler(this.scaleInputTrackBar__Scroll);
         // 
         // ScaleInputValueLabel
         // 
         this.ScaleInputValueLabel.AutoSize = true;
         this.ScaleInputValueLabel.Location = new System.Drawing.Point(39, 102);
         this.ScaleInputValueLabel.Name = "ScaleInputValueLabel";
         this.ScaleInputValueLabel.Size = new System.Drawing.Size(21, 13);
         this.ScaleInputValueLabel.TabIndex = 50;
         this.ScaleInputValueLabel.Text = "##";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.ScaleInputValueLabel);
         this.groupBox1.Controls.Add(this.SetBaselineButton);
         this.groupBox1.Controls.Add(this.scaleInputTrackBar_);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.i2cAddressInputComboBox_);
         this.groupBox1.Controls.Add(this.SetSettingsButton);
         this.groupBox1.Location = new System.Drawing.Point(14, 287);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(229, 174);
         this.groupBox1.TabIndex = 51;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Update Flash";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.textAddress);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this.textGain);
         this.groupBox2.Controls.Add(this.textTare);
         this.groupBox2.Controls.Add(this.label9);
         this.groupBox2.Controls.Add(this.RefreshFlashSettings);
         this.groupBox2.Controls.Add(this.textScale);
         this.groupBox2.Controls.Add(this.label8);
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Location = new System.Drawing.Point(12, 99);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(229, 167);
         this.groupBox2.TabIndex = 52;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Settings On Flash";
         // 
         // sensorTypeSelector
         // 
         this.sensorTypeSelector.FormattingEnabled = true;
         this.sensorTypeSelector.Location = new System.Drawing.Point(124, 528);
         this.sensorTypeSelector.Name = "sensorTypeSelector";
         this.sensorTypeSelector.Size = new System.Drawing.Size(121, 21);
         this.sensorTypeSelector.TabIndex = 53;
         this.sensorTypeSelector.Visible = false;
         // 
         // ResetSensorButton
         // 
         this.ResetSensorButton.Location = new System.Drawing.Point(13, 526);
         this.ResetSensorButton.Name = "ResetSensorButton";
         this.ResetSensorButton.Size = new System.Drawing.Size(105, 22);
         this.ResetSensorButton.TabIndex = 54;
         this.ResetSensorButton.Text = "Reset Sensor As:";
         this.ResetSensorButton.UseVisualStyleBackColor = true;
         this.ResetSensorButton.Visible = false;
         this.ResetSensorButton.Click += new System.EventHandler(this.ResetSensorButton_Click);
         // 
         // guiTimer_
         // 
         this.guiTimer_.Interval = 50;
         this.guiTimer_.Tick += new System.EventHandler(this.guiTimer__Tick);
         // 
         // LockButton
         // 
         this.LockButton.Location = new System.Drawing.Point(23, 467);
         this.LockButton.Name = "LockButton";
         this.LockButton.Size = new System.Drawing.Size(207, 23);
         this.LockButton.TabIndex = 55;
         this.LockButton.Text = "Lock";
         this.LockButton.UseVisualStyleBackColor = true;
         this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
         // 
         // singleTact_
         // 
         this.singleTact_.I2cAddressForCommunications = ((byte)(4));
         // 
         // picPpsLogo
         // 
         this.picPpsLogo.Image = ((System.Drawing.Image)(resources.GetObject("picPpsLogo.Image")));
         this.picPpsLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picPpsLogo.InitialImage")));
         this.picPpsLogo.Location = new System.Drawing.Point(23, 22);
         this.picPpsLogo.Margin = new System.Windows.Forms.Padding(2);
         this.picPpsLogo.Name = "picPpsLogo";
         this.picPpsLogo.Size = new System.Drawing.Size(172, 55);
         this.picPpsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.picPpsLogo.TabIndex = 46;
         this.picPpsLogo.TabStop = false;
         // 
         // GUI
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(834, 562);
         this.Controls.Add(this.LockButton);
         this.Controls.Add(this.ResetSensorButton);
         this.Controls.Add(this.sensorTypeSelector);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.picPpsLogo);
         this.Controls.Add(this.buttonSave);
         this.Controls.Add(this.graph_);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimumSize = new System.Drawing.Size(845, 498);
         this.Name = "GUI";
         this.Text = "PPS SingleTact Demo [XXHz]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
         ((System.ComponentModel.ISupportInitialize)(this.scaleInputTrackBar_)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picPpsLogo)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl graph_;
        private System.Windows.Forms.Button RefreshFlashSettings;
        private System.Windows.Forms.Button SetSettingsButton;
        private System.Windows.Forms.Button SetBaselineButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textScale;
        private System.Windows.Forms.TextBox textTare;
        private System.Windows.Forms.TextBox textGain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.ComponentModel.BackgroundWorker AcquisitionWorker;
        private SingleTactLibrary.SingleTact singleTact_;
        private SingleTactLibrary.ArduinoSingleTactDriver arduinoSingleTactDriver;
        private System.Windows.Forms.ComboBox i2cAddressInputComboBox_;
        private System.Windows.Forms.TrackBar scaleInputTrackBar_;
        private System.Windows.Forms.Label ScaleInputValueLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox sensorTypeSelector;
        private System.Windows.Forms.Button ResetSensorButton;
        private System.Windows.Forms.Timer guiTimer_;
        private System.Windows.Forms.Button LockButton;
        private System.Windows.Forms.PictureBox picPpsLogo;
    }
}
