namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapLocationPropertyPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLonLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLatLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSetCoordinatesButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjLongitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLatitudeNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLabelPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButtonPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).BeginInit();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.mobjLabelPanel.SuspendLayout();
            this.mobjButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            this.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(30, 30);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722D, -122.478611D);
            this.mobjGoogleMap.Name = "mobjGoogleMap";
            this.mobjGoogleMap.Size = new System.Drawing.Size(532, 195);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AutoSize = true;
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(132, 13);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Enter location coordinates";
            // 
            // mobjLonLabel
            // 
            this.mobjLonLabel.AutoSize = true;
            this.mobjLonLabel.Location = new System.Drawing.Point(0, 37);
            this.mobjLonLabel.Name = "mobjLonLabel";
            this.mobjLonLabel.Size = new System.Drawing.Size(54, 13);
            this.mobjLonLabel.TabIndex = 2;
            this.mobjLonLabel.Text = "Longitude";
            // 
            // mobjLatLabel
            // 
            this.mobjLatLabel.AutoSize = true;
            this.mobjLatLabel.Location = new System.Drawing.Point(0, 74);
            this.mobjLatLabel.Name = "mobjLatLabel";
            this.mobjLatLabel.Size = new System.Drawing.Size(46, 13);
            this.mobjLatLabel.TabIndex = 3;
            this.mobjLatLabel.Text = "Latitude";
            // 
            // mobjSetCoordinatesButton
            // 
            this.mobjSetCoordinatesButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSetCoordinatesButton.Location = new System.Drawing.Point(0, 0);
            this.mobjSetCoordinatesButton.Name = "mobjSetCoordinatesButton";
            this.mobjSetCoordinatesButton.Size = new System.Drawing.Size(532, 39);
            this.mobjSetCoordinatesButton.TabIndex = 6;
            this.mobjSetCoordinatesButton.Text = "Set Coordinates";
            this.mobjSetCoordinatesButton.UseVisualStyleBackColor = true;
            this.mobjSetCoordinatesButton.Click += new System.EventHandler(this.mobjSetCoordinatesButton_Click);
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
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
            this.mobjLongitudeNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLongitudeNUD.Location = new System.Drawing.Point(266, 37);
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
            this.mobjLongitudeNUD.Size = new System.Drawing.Size(266, 21);
            this.mobjLongitudeNUD.TabIndex = 7;
            // 
            // mobjLatitudeNUD
            // 
            this.mobjLatitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjLatitudeNUD.CurrentValue = new decimal(new int[] {
            38,
            0,
            0,
            0});
            this.mobjLatitudeNUD.DecimalPlaces = 6;
            this.mobjLatitudeNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLatitudeNUD.Location = new System.Drawing.Point(266, 74);
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
            this.mobjLatitudeNUD.Size = new System.Drawing.Size(266, 21);
            this.mobjLatitudeNUD.TabIndex = 8;
            this.mobjLatitudeNUD.Value = new decimal(new int[] {
            38,
            0,
            0,
            0});
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjAdditionalLayoutPanel, 1, 3);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 5;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 150F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(592, 425);
            this.mobjCommonLayoutPanel.TabIndex = 9;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.ColumnCount = 2;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLabelPanel, 0, 0);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjButtonPanel, 0, 3);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLonLabel, 0, 1);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLongitudeNUD, 1, 1);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLatitudeNUD, 1, 2);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLatLabel, 0, 2);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(30, 245);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 4;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(532, 150);
            this.mobjAdditionalLayoutPanel.TabIndex = 10;
            // 
            // mobjLabelPanel
            // 
            this.mobjAdditionalLayoutPanel.SetColumnSpan(this.mobjLabelPanel, 2);
            this.mobjLabelPanel.Controls.Add(this.mobjInfoLabel);
            this.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabelPanel.Name = "mobjLabelPanel";
            this.mobjLabelPanel.Size = new System.Drawing.Size(532, 37);
            this.mobjLabelPanel.TabIndex = 0;
            // 
            // mobjButtonPanel
            // 
            this.mobjAdditionalLayoutPanel.SetColumnSpan(this.mobjButtonPanel, 2);
            this.mobjButtonPanel.Controls.Add(this.mobjSetCoordinatesButton);
            this.mobjButtonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButtonPanel.Location = new System.Drawing.Point(0, 111);
            this.mobjButtonPanel.Name = "mobjButtonPanel";
            this.mobjButtonPanel.Size = new System.Drawing.Size(532, 39);
            this.mobjButtonPanel.TabIndex = 0;
            // 
            // MapLocationPropertyPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Size = new System.Drawing.Size(592, 425);
            this.Text = "MapLocationPropertyPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjLongitudeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjLatitudeNUD)).EndInit();
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.mobjLabelPanel.ResumeLayout(false);
            this.mobjButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Label mobjLonLabel;
        private Gizmox.WebGUI.Forms.Label mobjLatLabel;
        private Gizmox.WebGUI.Forms.Button mobjSetCoordinatesButton;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjLongitudeNUD;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjLatitudeNUD;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjLabelPanel;
        private Gizmox.WebGUI.Forms.Panel mobjButtonPanel;



    }
}