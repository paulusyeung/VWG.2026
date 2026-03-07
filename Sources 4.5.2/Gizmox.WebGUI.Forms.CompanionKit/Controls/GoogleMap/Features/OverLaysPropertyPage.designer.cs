namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class OverLaysPropertyPage
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mobjGoogleMap = new Gizmox.WebGUI.Forms.Professional.GoogleMap();
            this.mobjOverlaysLabel = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjMapLocationGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjAddressLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLocationNameAddressTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLocationNameAddressRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjSetMapLocationButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCoordinatesRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLatitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLatitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLongitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLongitudeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMapOverlaysGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjEditButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjMapLocationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).BeginInit();
            this.mobjMapOverlaysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            this.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjGoogleMap.Location = new System.Drawing.Point(12, 11);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722D, -122.478611D);
            this.mobjGoogleMap.MapZoomControlType = Gizmox.WebGUI.Forms.Google.GoogleMapZoomControlType.Large;
            this.mobjGoogleMap.Name = "googleMap1";
            this.mobjGoogleMap.Size = new System.Drawing.Size(630, 480);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjOverlaysLabel
            // 
            this.mobjOverlaysLabel.DisplayMember = "WindowInfoContent";
            this.mobjOverlaysLabel.Location = new System.Drawing.Point(10, 17);
            this.mobjOverlaysLabel.Name = "lbOverlays";
            this.mobjOverlaysLabel.Size = new System.Drawing.Size(180, 433);
            this.mobjOverlaysLabel.TabIndex = 1;
            this.mobjOverlaysLabel.ValueMember = "WindowInfoContent";
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjMapLocationGroupBox
            // 
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjAddressLabel);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLocationNameAddressTextBox);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLocationNameAddressRadioButton);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjSetMapLocationButton);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjCoordinatesRadioButton);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLatitudeNUD);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLatitudeLabel);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLongitudeNUD);
            this.mobjMapLocationGroupBox.Controls.Add(this.mobjLongitudeLabel);
            this.mobjMapLocationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjMapLocationGroupBox.Location = new System.Drawing.Point(12, 491);
            this.mobjMapLocationGroupBox.Name = "gtbMapLocation";
            this.mobjMapLocationGroupBox.Size = new System.Drawing.Size(630, 125);
            this.mobjMapLocationGroupBox.TabIndex = 5;
            this.mobjMapLocationGroupBox.TabStop = false;
            this.mobjMapLocationGroupBox.Text = "Map Location";
            // 
            // mobjAddressLabel
            // 
            this.mobjAddressLabel.AutoSize = true;
            this.mobjAddressLabel.Location = new System.Drawing.Point(30, 98);
            this.mobjAddressLabel.Name = "mobjAddressLabel";
            this.mobjAddressLabel.Size = new System.Drawing.Size(46, 13);
            this.mobjAddressLabel.TabIndex = 3;
            this.mobjAddressLabel.Text = "Name / Address:";
            // 
            // mobjLocationNameAddressTextBox
            // 
            this.mobjLocationNameAddressTextBox.AllowDrag = false;
            this.mobjLocationNameAddressTextBox.Enabled = false;
            this.mobjLocationNameAddressTextBox.Location = new System.Drawing.Point(115, 95);
            this.mobjLocationNameAddressTextBox.Name = "mobjLocationNameAddressTextBox";
            this.mobjLocationNameAddressTextBox.Size = new System.Drawing.Size(316, 20);
            this.mobjLocationNameAddressTextBox.TabIndex = 10;
            // 
            // mobjLocationNameAddressRadioButton
            // 
            this.mobjLocationNameAddressRadioButton.AutoSize = true;
            this.mobjLocationNameAddressRadioButton.Location = new System.Drawing.Point(13, 69);
            this.mobjLocationNameAddressRadioButton.Name = "mobjLocationNameAddressRadioButton";
            this.mobjLocationNameAddressRadioButton.Size = new System.Drawing.Size(250, 17);
            this.mobjLocationNameAddressRadioButton.TabIndex = 9;
            this.mobjLocationNameAddressRadioButton.Text = "Location name / address";
            this.mobjLocationNameAddressRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjSetMapLocationButton
            // 
            this.mobjSetMapLocationButton.Location = new System.Drawing.Point(512, 96);
            this.mobjSetMapLocationButton.Name = "btnSetMapLocation";
            this.mobjSetMapLocationButton.Size = new System.Drawing.Size(112, 23);
            this.mobjSetMapLocationButton.TabIndex = 3;
            this.mobjSetMapLocationButton.Text = "Set Map Location";
            this.mobjSetMapLocationButton.Click += new System.EventHandler(this.mobjSetMapLocationButton_Click);
            // 
            // mobjCoordinatesRadioButton
            // 
            this.mobjCoordinatesRadioButton.AutoSize = true;
            this.mobjCoordinatesRadioButton.Checked = true;
            this.mobjCoordinatesRadioButton.Location = new System.Drawing.Point(13, 15);
            this.mobjCoordinatesRadioButton.Name = "mobjCoordinatesRadioButton";
            this.mobjCoordinatesRadioButton.Size = new System.Drawing.Size(83, 17);
            this.mobjCoordinatesRadioButton.TabIndex = 9;
            this.mobjCoordinatesRadioButton.Text = "Coordinates";
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
            this.mobjLatitudeNUD.Location = new System.Drawing.Point(331, 42);
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
            this.mobjLatitudeNUD.Name = "nudLatitude";
            this.mobjLatitudeNUD.Size = new System.Drawing.Size(100, 21);
            this.mobjLatitudeNUD.TabIndex = 8;
            // 
            // mobjLatitudeLabel
            // 
            this.mobjLatitudeLabel.AutoSize = true;
            this.mobjLatitudeLabel.Location = new System.Drawing.Point(262, 44);
            this.mobjLatitudeLabel.Name = "mobjLatitudeLabel";
            this.mobjLatitudeLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLatitudeLabel.TabIndex = 3;
            this.mobjLatitudeLabel.Text = "Latitude:";
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
            this.mobjLongitudeNUD.Location = new System.Drawing.Point(115, 42);
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
            // mobjLongitudeLabel
            // 
            this.mobjLongitudeLabel.AutoSize = true;
            this.mobjLongitudeLabel.Location = new System.Drawing.Point(30, 44);
            this.mobjLongitudeLabel.Name = "mobjLongitudeLabel";
            this.mobjLongitudeLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLongitudeLabel.TabIndex = 2;
            this.mobjLongitudeLabel.Text = "Longitude:";
            // 
            // mobjMapOverlaysGroupBox
            // 
            this.mobjMapOverlaysGroupBox.Controls.Add(this.mobjRemoveButton);
            this.mobjMapOverlaysGroupBox.Controls.Add(this.mobjEditButton);
            this.mobjMapOverlaysGroupBox.Controls.Add(this.mobjAddButton);
            this.mobjMapOverlaysGroupBox.Controls.Add(this.mobjOverlaysLabel);
            this.mobjMapOverlaysGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjMapOverlaysGroupBox.Location = new System.Drawing.Point(650, 11);
            this.mobjMapOverlaysGroupBox.Name = "mobjMapOverlaysGroupBox";
            this.mobjMapOverlaysGroupBox.Size = new System.Drawing.Size(200, 480);
            this.mobjMapOverlaysGroupBox.TabIndex = 6;
            this.mobjMapOverlaysGroupBox.TabStop = false;
            this.mobjMapOverlaysGroupBox.Text = "Map Overlays";
            // 
            // mobjRemoveButton
            // 
            this.mobjRemoveButton.Location = new System.Drawing.Point(130, 454);
            this.mobjRemoveButton.Name = "mobjRemoveButton";
            this.mobjRemoveButton.Size = new System.Drawing.Size(60, 23);
            this.mobjRemoveButton.TabIndex = 4;
            this.mobjRemoveButton.Text = "Remove";
            this.mobjRemoveButton.UseVisualStyleBackColor = true;
            this.mobjRemoveButton.Click += new System.EventHandler(this.mobjRemoveButton_Click);
            // 
            // mobjEditButton
            // 
            this.mobjEditButton.Location = new System.Drawing.Point(70, 454);
            this.mobjEditButton.Name = "mobjEditButton";
            this.mobjEditButton.Size = new System.Drawing.Size(60, 23);
            this.mobjEditButton.TabIndex = 3;
            this.mobjEditButton.Text = "Edit";
            this.mobjEditButton.UseVisualStyleBackColor = true;
            this.mobjEditButton.Click += new System.EventHandler(this.mobjEditButton_Click);
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Location = new System.Drawing.Point(10, 454);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(60, 23);
            this.mobjAddButton.TabIndex = 2;
            this.mobjAddButton.Text = "Add";
            this.mobjAddButton.UseVisualStyleBackColor = true;
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // OverLaysPropertyPage
            // 
            this.Controls.Add(this.mobjMapOverlaysGroupBox);
            this.Controls.Add(this.mobjMapLocationGroupBox);
            this.Controls.Add(this.mobjGoogleMap);
            this.Size = new System.Drawing.Size(715, 650);
            this.Text = "OverLaysPropertyPage";
            this.Load += new System.EventHandler(this.OverLaysPropertyPage_Load);
            this.mobjMapLocationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).EndInit();
            this.mobjMapOverlaysGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.ListBox mobjOverlaysLabel;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.GroupBox mobjMapLocationGroupBox;
        private Gizmox.WebGUI.Forms.Button mobjSetMapLocationButton;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjLatitudeNUD;
        private Gizmox.WebGUI.Forms.Label mobjLatitudeLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjLongitudeNUD;
        private Gizmox.WebGUI.Forms.Label mobjLongitudeLabel;
        private Gizmox.WebGUI.Forms.GroupBox mobjMapOverlaysGroupBox;
        private Gizmox.WebGUI.Forms.Button mobjRemoveButton;
        private Gizmox.WebGUI.Forms.Button mobjEditButton;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjCoordinatesRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjLocationNameAddressRadioButton;
        private Gizmox.WebGUI.Forms.Label mobjAddressLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjLocationNameAddressTextBox;





    }
}