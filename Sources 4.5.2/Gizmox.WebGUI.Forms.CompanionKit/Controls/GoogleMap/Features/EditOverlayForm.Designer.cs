using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.GoogleMap.Features
{
    partial class EditOverlayForm
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
            this.components = new System.ComponentModel.Container();
            this.mobjCancelButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAddressLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLocationNameAddressTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDescriptionTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjOverlayDescriptionGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjSaveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLocationNameAddressRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjCoordinatesRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLatitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLongitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLatitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLongitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjOverlayLocationGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjOverlayDescriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).BeginInit();
            this.mobjOverlayLocationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCancelButton
            // 
            this.mobjCancelButton.Location = new System.Drawing.Point(173, 272);
            this.mobjCancelButton.Name = "mobjCancelButton";
            this.mobjCancelButton.Size = new System.Drawing.Size(100, 23);
            this.mobjCancelButton.TabIndex = 3;
            this.mobjCancelButton.Text = "Cancel";
            this.mobjCancelButton.Click += new System.EventHandler(this.mobjCancelButton_Click);
            // 
            // mobjAddressLabel
            // 
            this.mobjAddressLabel.AutoSize = true;
            this.mobjAddressLabel.Location = new System.Drawing.Point(3, 127);
            this.mobjAddressLabel.Name = "mobjAddressLabel";
            this.mobjAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.mobjAddressLabel.TabIndex = 3;
            this.mobjAddressLabel.Text = "Name / Address";
            // 
            // mobjLocationNameAddressTextBox
            // 
            this.mobjLocationNameAddressTextBox.AllowDrag = false;
            this.mobjLocationNameAddressTextBox.Enabled = false;
            this.mobjLocationNameAddressTextBox.Location = new System.Drawing.Point(99, 124);
            this.mobjLocationNameAddressTextBox.Name = "mobjLocationNameAddressTextBox";
            this.mobjLocationNameAddressTextBox.Size = new System.Drawing.Size(161, 20);
            this.mobjLocationNameAddressTextBox.TabIndex = 10;
            // 
            // mobjDescriptionTextBox
            // 
            this.mobjDescriptionTextBox.AllowDrag = false;
            this.mobjDescriptionTextBox.Location = new System.Drawing.Point(6, 20);
            this.mobjDescriptionTextBox.Multiline = true;
            this.mobjDescriptionTextBox.Name = "mobjDescriptionTextBox";
            this.mobjDescriptionTextBox.Size = new System.Drawing.Size(254, 74);
            this.mobjDescriptionTextBox.TabIndex = 9;
            // 
            // mobjOverlayDescriptionGroupBox
            // 
            this.mobjOverlayDescriptionGroupBox.Controls.Add(this.mobjDescriptionTextBox);
            this.mobjOverlayDescriptionGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjOverlayDescriptionGroupBox.Location = new System.Drawing.Point(7, 168);
            this.mobjOverlayDescriptionGroupBox.Name = "mobjOverlayDescriptionGroupBox";
            this.mobjOverlayDescriptionGroupBox.Size = new System.Drawing.Size(266, 100);
            this.mobjOverlayDescriptionGroupBox.TabIndex = 10;
            this.mobjOverlayDescriptionGroupBox.TabStop = false;
            this.mobjOverlayDescriptionGroupBox.Text = "Overlay description";
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjSaveButton
            // 
            this.mobjSaveButton.Location = new System.Drawing.Point(7, 272);
            this.mobjSaveButton.Name = "mobjSaveButton";
            this.mobjSaveButton.Size = new System.Drawing.Size(100, 23);
            this.mobjSaveButton.TabIndex = 3;
            this.mobjSaveButton.Text = "Save";
            this.mobjSaveButton.Click += new System.EventHandler(this.mobjSaveButton_Click);
            // 
            // mobjLocationNameAddressRadioButton
            // 
            this.mobjLocationNameAddressRadioButton.AutoSize = true;
            this.mobjLocationNameAddressRadioButton.Location = new System.Drawing.Point(3, 100);
            this.mobjLocationNameAddressRadioButton.Name = "mobjLocationNameAddressRadioButton";
            this.mobjLocationNameAddressRadioButton.Size = new System.Drawing.Size(250, 17);
            this.mobjLocationNameAddressRadioButton.TabIndex = 9;
            this.mobjLocationNameAddressRadioButton.Text = "Location name / address";
            this.mobjLocationNameAddressRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjCoordinatesRadioButton
            // 
            this.mobjCoordinatesRadioButton.AutoSize = true;
            this.mobjCoordinatesRadioButton.Checked = true;
            this.mobjCoordinatesRadioButton.Location = new System.Drawing.Point(3, 19);
            this.mobjCoordinatesRadioButton.Name = "mobjCoordinatesRadioButton";
            this.mobjCoordinatesRadioButton.Size = new System.Drawing.Size(83, 17);
            this.mobjCoordinatesRadioButton.TabIndex = 9;
            this.mobjCoordinatesRadioButton.Text = "Coordinates";
            this.mobjCoordinatesRadioButton.UseVisualStyleBackColor = true;
            this.mobjCoordinatesRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjLatitudeNUD
            // 
            this.mobjLatitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjLatitudeNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjLatitudeNUD.DecimalPlaces = 6;
            this.mobjLatitudeNUD.Location = new System.Drawing.Point(65, 71);
            this.mobjLatitudeNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjLatitudeNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.mobjLatitudeNUD.Name = "mobjLatitudeNUD";
            this.mobjLatitudeNUD.Size = new System.Drawing.Size(100, 21);
            this.mobjLatitudeNUD.TabIndex = 8;
            // 
            // mobjLongitudeLabel
            // 
            this.mobjLongitudeLabel.AutoSize = true;
            this.mobjLongitudeLabel.Location = new System.Drawing.Point(3, 47);
            this.mobjLongitudeLabel.Name = "mobjLongitudeLabel";
            this.mobjLongitudeLabel.Size = new System.Drawing.Size(54, 13);
            this.mobjLongitudeLabel.TabIndex = 2;
            this.mobjLongitudeLabel.Text = "Longitude";
            // 
            // mobjLatitudeLabel
            // 
            this.mobjLatitudeLabel.AutoSize = true;
            this.mobjLatitudeLabel.Location = new System.Drawing.Point(3, 73);
            this.mobjLatitudeLabel.Name = "mobjLatitudeLabel";
            this.mobjLatitudeLabel.Size = new System.Drawing.Size(46, 13);
            this.mobjLatitudeLabel.TabIndex = 3;
            this.mobjLatitudeLabel.Text = "Latitude";
            // 
            // mobjLongitudeNUD
            // 
            this.mobjLongitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjLongitudeNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjLongitudeNUD.DecimalPlaces = 6;
            this.mobjLongitudeNUD.Location = new System.Drawing.Point(65, 45);
            this.mobjLongitudeNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjLongitudeNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.mobjLongitudeNUD.Name = "mobjLongitudeNUD";
            this.mobjLongitudeNUD.Size = new System.Drawing.Size(100, 21);
            this.mobjLongitudeNUD.TabIndex = 7;
            // 
            // mobjOverlayLocationGroupBox
            // 
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLocationNameAddressTextBox);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjAddressLabel);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLocationNameAddressRadioButton);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjCoordinatesRadioButton);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLongitudeLabel);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLatitudeLabel);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLongitudeNUD);
            this.mobjOverlayLocationGroupBox.Controls.Add(this.mobjLatitudeNUD);
            this.mobjOverlayLocationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjOverlayLocationGroupBox.Location = new System.Drawing.Point(7, 9);
            this.mobjOverlayLocationGroupBox.Name = "mobjOverlayLocationGroupBox";
            this.mobjOverlayLocationGroupBox.Size = new System.Drawing.Size(266, 153);
            this.mobjOverlayLocationGroupBox.TabIndex = 4;
            this.mobjOverlayLocationGroupBox.TabStop = false;
            this.mobjOverlayLocationGroupBox.Text = "Overlay location";
            // 
            // EditOverlayForm
            // 
            this.Controls.Add(this.mobjOverlayLocationGroupBox);
            this.Controls.Add(this.mobjSaveButton);
            this.Controls.Add(this.mobjOverlayDescriptionGroupBox);
            this.Controls.Add(this.mobjCancelButton);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(280, 300);
            this.Text = "EditOverlayForm";
            this.Load += new System.EventHandler(this.EditOverlayForm_Load);
            this.mobjOverlayDescriptionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).EndInit();
            this.mobjOverlayLocationGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button mobjCancelButton;
        private Label mobjAddressLabel;
        private TextBox mobjLocationNameAddressTextBox;
        private TextBox mobjDescriptionTextBox;
        private GroupBox mobjOverlayDescriptionGroupBox;
        private ErrorProvider mobjErrorProvider;
        private Button mobjSaveButton;
        private RadioButton mobjLocationNameAddressRadioButton;
        private RadioButton mobjCoordinatesRadioButton;
        private NumericUpDown mobjLatitudeNUD;
        private Label mobjLongitudeLabel;
        private Label mobjLatitudeLabel;
        private NumericUpDown mobjLongitudeNUD;
        private GroupBox mobjOverlayLocationGroupBox;


    }
}