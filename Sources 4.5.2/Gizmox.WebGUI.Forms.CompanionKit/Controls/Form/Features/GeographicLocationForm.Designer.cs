using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.Form.Features
{
    partial class GeographicLocationForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjTimeoutNullCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMaxAgeNullCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTimeoutNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjMaxAgeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjRepeatCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjHighAccuracyCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTimeoutLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaximumAgeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjGoogleMap = new Gizmox.WebGUI.Forms.Professional.GoogleMap();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjTimeoutNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxAgeNUD)).BeginInit();
            this.mobjGroupBox.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTimeoutNullCheckBox
            // 
            this.mobjTimeoutNullCheckBox.AccessibleDescription = "";
            this.mobjTimeoutNullCheckBox.AccessibleName = "";
            this.mobjTimeoutNullCheckBox.AutoSize = true;
            this.mobjTimeoutNullCheckBox.Checked = true;
            this.mobjTimeoutNullCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjTimeoutNullCheckBox.Location = new System.Drawing.Point(237, 116);
            this.mobjTimeoutNullCheckBox.Name = "objTimeoutNullCheckBox";
            this.mobjTimeoutNullCheckBox.Size = new System.Drawing.Size(43, 17);
            this.mobjTimeoutNullCheckBox.TabIndex = 5;
            this.mobjTimeoutNullCheckBox.Text = "Null";
            this.mobjTimeoutNullCheckBox.CheckedChanged += new System.EventHandler(this.mobjTimeoutNullCheckBox_CheckedChanged);
            // 
            // mobjMaxAgeNullCheckBox
            // 
            this.mobjMaxAgeNullCheckBox.AccessibleDescription = "";
            this.mobjMaxAgeNullCheckBox.AccessibleName = "";
            this.mobjMaxAgeNullCheckBox.AutoSize = true;
            this.mobjMaxAgeNullCheckBox.Checked = true;
            this.mobjMaxAgeNullCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjMaxAgeNullCheckBox.Location = new System.Drawing.Point(237, 91);
            this.mobjMaxAgeNullCheckBox.Name = "objMaxAgeNullCheckBox";
            this.mobjMaxAgeNullCheckBox.Size = new System.Drawing.Size(43, 17);
            this.mobjMaxAgeNullCheckBox.TabIndex = 4;
            this.mobjMaxAgeNullCheckBox.Text = "Null";
            this.mobjMaxAgeNullCheckBox.CheckedChanged += new System.EventHandler(this.mobjMaxAgeNullCheckBox_CheckedChanged);
            // 
            // mobjTimeoutNUD
            // 
            this.mobjTimeoutNUD.AccessibleDescription = "";
            this.mobjTimeoutNUD.AccessibleName = "";
            this.mobjTimeoutNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjTimeoutNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjTimeoutNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjTimeoutNUD.Enabled = false;
            this.mobjTimeoutNUD.Location = new System.Drawing.Point(153, 115);
            this.mobjTimeoutNUD.Name = "objTimeoutNUD";
            this.mobjTimeoutNUD.Size = new System.Drawing.Size(77, 17);
            this.mobjTimeoutNUD.TabIndex = 3;
            this.mobjTimeoutNUD.ValueChanged += new System.EventHandler(this.mobjTimeoutNUD_ValueChanged);
            // 
            // mobjMaxAgeNUD
            // 
            this.mobjMaxAgeNUD.AccessibleDescription = "";
            this.mobjMaxAgeNUD.AccessibleName = "";
            this.mobjMaxAgeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMaxAgeNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjMaxAgeNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMaxAgeNUD.Enabled = false;
            this.mobjMaxAgeNUD.Location = new System.Drawing.Point(153, 90);
            this.mobjMaxAgeNUD.Name = "objMaxAgeNUD";
            this.mobjMaxAgeNUD.Size = new System.Drawing.Size(77, 17);
            this.mobjMaxAgeNUD.TabIndex = 2;
            this.mobjMaxAgeNUD.ValueChanged += new System.EventHandler(this.mobjMaxAgeNUD_ValueChanged);
            // 
            // mobjRepeatCheckBox
            // 
            this.mobjRepeatCheckBox.AccessibleDescription = "";
            this.mobjRepeatCheckBox.AccessibleName = "";
            this.mobjRepeatCheckBox.AutoSize = true;
            this.mobjRepeatCheckBox.Location = new System.Drawing.Point(19, 61);
            this.mobjRepeatCheckBox.Name = "objRepeatCheckBox";
            this.mobjRepeatCheckBox.Size = new System.Drawing.Size(90, 17);
            this.mobjRepeatCheckBox.TabIndex = 1;
            this.mobjRepeatCheckBox.Text = "RepeatCheck";
            this.mobjRepeatCheckBox.CheckedChanged += new System.EventHandler(this.mobjRepeatCheckBox_CheckedChanged);
            // 
            // mobjHighAccuracyCheckBox
            // 
            this.mobjHighAccuracyCheckBox.AccessibleDescription = "";
            this.mobjHighAccuracyCheckBox.AccessibleName = "";
            this.mobjHighAccuracyCheckBox.AutoSize = true;
            this.mobjHighAccuracyCheckBox.Location = new System.Drawing.Point(19, 30);
            this.mobjHighAccuracyCheckBox.Name = "objHighAccuracyCheckBox";
            this.mobjHighAccuracyCheckBox.Size = new System.Drawing.Size(123, 17);
            this.mobjHighAccuracyCheckBox.TabIndex = 0;
            this.mobjHighAccuracyCheckBox.Text = "EnableHighAccuracy";
            this.mobjHighAccuracyCheckBox.CheckedChanged += new System.EventHandler(this.mobjHighAccuracyCheckBox_CheckedChanged);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.AccessibleDescription = "";
            this.mobjGroupBox.AccessibleName = "";
            this.mobjGroupBox.Controls.Add(this.mobjTimeoutLabel);
            this.mobjGroupBox.Controls.Add(this.mobjMaximumAgeLabel);
            this.mobjGroupBox.Controls.Add(this.mobjTimeoutNullCheckBox);
            this.mobjGroupBox.Controls.Add(this.mobjMaxAgeNullCheckBox);
            this.mobjGroupBox.Controls.Add(this.mobjTimeoutNUD);
            this.mobjGroupBox.Controls.Add(this.mobjMaxAgeNUD);
            this.mobjGroupBox.Controls.Add(this.mobjRepeatCheckBox);
            this.mobjGroupBox.Controls.Add(this.mobjHighAccuracyCheckBox);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(20, 20);
            this.mobjGroupBox.Name = "objGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(332, 146);
            this.mobjGroupBox.TabIndex = 1;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "GeographicLocationOptions";
            // 
            // mobjTimeoutLabel
            // 
            this.mobjTimeoutLabel.AccessibleDescription = "";
            this.mobjTimeoutLabel.AccessibleName = "";
            this.mobjTimeoutLabel.AutoSize = true;
            this.mobjTimeoutLabel.Location = new System.Drawing.Point(16, 120);
            this.mobjTimeoutLabel.Name = "objTimeoutLabel";
            this.mobjTimeoutLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjTimeoutLabel.TabIndex = 7;
            this.mobjTimeoutLabel.Text = "Timeout";
            // 
            // mobjMaximumAgeLabel
            // 
            this.mobjMaximumAgeLabel.AccessibleDescription = "";
            this.mobjMaximumAgeLabel.AccessibleName = "";
            this.mobjMaximumAgeLabel.AutoSize = true;
            this.mobjMaximumAgeLabel.Location = new System.Drawing.Point(16, 95);
            this.mobjMaximumAgeLabel.Name = "objMaximumAgeLabel";
            this.mobjMaximumAgeLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjMaximumAgeLabel.TabIndex = 6;
            this.mobjMaximumAgeLabel.Text = "MaximumAge";
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.AccessibleDescription = "";
            this.mobjGoogleMap.AccessibleName = "";
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(20, 20);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.MapZoomLevel = 15;
            this.mobjGoogleMap.Name = "objGoogleMap";
            this.mobjGoogleMap.Size = new System.Drawing.Size(332, 240);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.Controls.Add(this.mobjGoogleMap);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.DockPadding.All = 20;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.MaximumSize = new System.Drawing.Size(440, 280);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mobjTopPanel.Size = new System.Drawing.Size(372, 280);
            this.mobjTopPanel.TabIndex = 2;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjGroupBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.All = 20;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 284);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mobjBottomPanel.Size = new System.Drawing.Size(372, 186);
            this.mobjBottomPanel.TabIndex = 3;
            // 
            // GeographicLocationForm
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Location = new System.Drawing.Point(0, -37);
            this.Size = new System.Drawing.Size(372, 466);
            this.Text = "GeographicLocationForm";
            this.GeographicLocationChanged += new Gizmox.WebGUI.Forms.GeographicLocationChangedEventHandler(this.GeographicLocationForm_GeographicLocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mobjTimeoutNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxAgeNUD)).EndInit();
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjTimeoutNullCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjMaxAgeNullCheckBox;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjTimeoutNUD;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMaxAgeNUD;
        private Gizmox.WebGUI.Forms.CheckBox mobjRepeatCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjHighAccuracyCheckBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.Label mobjTimeoutLabel;
        private Gizmox.WebGUI.Forms.Label mobjMaximumAgeLabel;
        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;

    }
}