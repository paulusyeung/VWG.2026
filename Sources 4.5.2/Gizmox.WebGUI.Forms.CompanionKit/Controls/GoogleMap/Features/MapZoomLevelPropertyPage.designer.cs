namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapZoomLevelPropertyPage
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
            this.mobjGoogleMap = new Gizmox.WebGUI.Forms.Professional.GoogleMap();
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(30, 30);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722D, -122.478611D);
            this.mobjGoogleMap.Name = "mobjGoogleMap";
            this.mobjGoogleMap.ShowMapZoomControl = false;
            this.mobjGoogleMap.Size = new System.Drawing.Size(676, 242);
            this.mobjGoogleMap.TabIndex = 0;
            this.mobjGoogleMap.MapZoomLevelChanged += new System.EventHandler(this.mobjGoogleMap_MapZoomLevelChanged);
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjNumericUpDown.Location = new System.Drawing.Point(30, 352);
            this.mobjNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mobjNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.Name = "mobjNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjNumericUpDown.TabIndex = 1;
            this.mobjNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.ValueChanged += new System.EventHandler(this.mobjNumericUpDown_ValueChanged);
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjCheckBox.Location = new System.Drawing.Point(30, 375);
            this.mobjCheckBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(250, 17);
            this.mobjCheckBox.TabIndex = 2;
            this.mobjCheckBox.Text = "MapDoubleClickZooms";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjLabel.Location = new System.Drawing.Point(30, 299);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(676, 13);
            this.mobjLabel.TabIndex = 3;
            this.mobjLabel.Text = "ZoomLevel:";
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjLabel, 1, 2);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjCheckBox, 1, 4);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjNumericUpDown, 1, 3);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 6;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(736, 422);
            this.mobjCommonLayoutPanel.TabIndex = 4;
            // 
            // MapZoomLevelPropertyPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Size = new System.Drawing.Size(736, 422);
            this.Text = "MapZoomLevelPropertyPage";
            this.Load += new System.EventHandler(this.MapZoomLevelPropertyPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;



    }
}