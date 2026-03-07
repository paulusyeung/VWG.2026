using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.GoogleMap.Features
{
    partial class NewOverlayForm
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
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDescriptionTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLongitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLatitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLongitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLatitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjOverlayLocationGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjLocationNameAddressTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjAddressLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLocationNameAddressRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjCoordinatesRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjOverlayDescriptionGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjCancelButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).BeginInit();
            this.mobjOverlayLocationGroupBox.SuspendLayout();
            this.mobjOverlayDescriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Location = new System.Drawing.Point(7, 272);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(100, 23);
            this.mobjAddButton.TabIndex = 3;
            this.mobjAddButton.Text = "Add Overlay";
            this.mobjAddButton.UseVisualStyleBackColor = true;
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
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
            // mobjLocationNameAddressTextBox
            // 
            this.mobjLocationNameAddressTextBox.AllowDrag = false;
            this.mobjLocationNameAddressTextBox.Enabled = false;
            this.mobjLocationNameAddressTextBox.Location = new System.Drawing.Point(99, 124);
            this.mobjLocationNameAddressTextBox.Name = "mobjLocationNameAddressTextBox";
            this.mobjLocationNameAddressTextBox.Size = new System.Drawing.Size(161, 20);
            this.mobjLocationNameAddressTextBox.TabIndex = 10;
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
            // mobjCancelButton
            // 
            this.mobjCancelButton.Location = new System.Drawing.Point(173, 272);
            this.mobjCancelButton.Name = "mobjCancelButton";
            this.mobjCancelButton.Size = new System.Drawing.Size(100, 23);
            this.mobjCancelButton.TabIndex = 3;
            this.mobjCancelButton.Text = "Cancel";
            this.mobjCancelButton.Click += new System.EventHandler(this.mobjCancelButton_Click);
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // NewOverlayForm
            // 
            this.Controls.Add(this.mobjCancelButton);
            this.Controls.Add(this.mobjOverlayDescriptionGroupBox);
            this.Controls.Add(this.mobjOverlayLocationGroupBox);
            this.Controls.Add(this.mobjAddButton);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(280, 300);
            this.Text = "NewOverlayForm";
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).EndInit();
            this.mobjOverlayLocationGroupBox.ResumeLayout(false);
            this.mobjOverlayDescriptionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button mobjAddButton;
        private TextBox mobjDescriptionTextBox;
        private Label mobjLongitudeLabel;
        private Label mobjLatitudeLabel;
        private NumericUpDown mobjLongitudeNUD;
        private NumericUpDown mobjLatitudeNUD;
        private GroupBox mobjOverlayLocationGroupBox;
        private TextBox mobjLocationNameAddressTextBox;
        private Label mobjAddressLabel;
        private RadioButton mobjLocationNameAddressRadioButton;
        private RadioButton mobjCoordinatesRadioButton;
        private GroupBox mobjOverlayDescriptionGroupBox;
        private Button mobjCancelButton;
        private ErrorProvider mobjErrorProvider;


    }
}