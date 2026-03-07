namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapControlTypePropertyPage
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
            this.mobjFirstLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMapControlTypeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjSecondLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMapZoomControlTypeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjBottomLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjTopLayoutPanel.SuspendLayout();
            this.mobjBottomLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            this.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(30, 30);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, true, true, true);
            this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722D, -122.478611D);
            this.mobjGoogleMap.Name = "mobjGoogleMap";
            this.mobjGoogleMap.Size = new System.Drawing.Size(523, 324);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjFirstLabel
            // 
            this.mobjFirstLabel.AutoSize = true;
            this.mobjFirstLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjFirstLabel.Location = new System.Drawing.Point(0, 17);
            this.mobjFirstLabel.Name = "mobjFirstLabel";
            this.mobjFirstLabel.Size = new System.Drawing.Size(523, 13);
            this.mobjFirstLabel.TabIndex = 1;
            this.mobjFirstLabel.Text = "Please select MapControlType";
            // 
            // mobjMapControlTypeComboBox
            // 
            this.mobjMapControlTypeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMapControlTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjMapControlTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjMapControlTypeComboBox.FormattingEnabled = true;
            this.mobjMapControlTypeComboBox.Items.AddRange(new object[] {
            "Default",
            "DropdownMenu ",
            "HorizontalBar"});
            this.mobjMapControlTypeComboBox.Location = new System.Drawing.Point(0, 60);
            this.mobjMapControlTypeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMapControlTypeComboBox.Name = "mobjMapControlTypeComboBox";
            this.mobjMapControlTypeComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjMapControlTypeComboBox.TabIndex = 2;
            this.mobjMapControlTypeComboBox.Text = "Default";
            this.mobjMapControlTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjMapControlTypeComboBox_SelectedIndexChanged);
            // 
            // mobjSecondLabel
            // 
            this.mobjSecondLabel.AutoSize = true;
            this.mobjSecondLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSecondLabel.Location = new System.Drawing.Point(0, 17);
            this.mobjSecondLabel.Name = "mobjSecondLabel";
            this.mobjSecondLabel.Size = new System.Drawing.Size(523, 13);
            this.mobjSecondLabel.TabIndex = 3;
            this.mobjSecondLabel.Text = "Please select MapZoomControlType";
            // 
            // mobjMapZoomControlTypeComboBox
            // 
            this.mobjMapZoomControlTypeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMapZoomControlTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjMapZoomControlTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjMapZoomControlTypeComboBox.FormattingEnabled = true;
            this.mobjMapZoomControlTypeComboBox.Items.AddRange(new object[] {
            "Default",
            "Large",
            "Small"});
            this.mobjMapZoomControlTypeComboBox.Location = new System.Drawing.Point(0, 39);
            this.mobjMapZoomControlTypeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMapZoomControlTypeComboBox.Name = "mobjMapZoomControlTypeComboBox";
            this.mobjMapZoomControlTypeComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjMapZoomControlTypeComboBox.TabIndex = 4;
            this.mobjMapZoomControlTypeComboBox.Text = "Default";
            this.mobjMapZoomControlTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjMapZoomControlTypeComboBox_SelectedIndexChanged);
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjTopLayoutPanel, 1, 2);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjBottomLayoutPanel, 1, 3);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 5;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(583, 504);
            this.mobjCommonLayoutPanel.TabIndex = 5;
            // 
            // mobjTopLayoutPanel
            // 
            this.mobjTopLayoutPanel.ColumnCount = 1;
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjTopLayoutPanel.Controls.Add(this.mobjFirstLabel, 0, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjMapControlTypeComboBox, 0, 1);
            this.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopLayoutPanel.Location = new System.Drawing.Point(30, 354);
            this.mobjTopLayoutPanel.Name = "mobjTopLayoutPanel";
            this.mobjTopLayoutPanel.RowCount = 2;
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.Size = new System.Drawing.Size(523, 60);
            this.mobjTopLayoutPanel.TabIndex = 0;
            // 
            // mobjBottomLayoutPanel
            // 
            this.mobjBottomLayoutPanel.ColumnCount = 1;
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjSecondLabel, 0, 0);
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjMapZoomControlTypeComboBox, 0, 1);
            this.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomLayoutPanel.Location = new System.Drawing.Point(30, 414);
            this.mobjBottomLayoutPanel.Name = "mobjBottomLayoutPanel";
            this.mobjBottomLayoutPanel.RowCount = 2;
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.Size = new System.Drawing.Size(523, 60);
            this.mobjBottomLayoutPanel.TabIndex = 0;
            // 
            // MapControlTypePropertyPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Location = new System.Drawing.Point(0, -194);
            this.Size = new System.Drawing.Size(583, 504);
            this.Text = "MapControlTypePropertyPage";
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjTopLayoutPanel.ResumeLayout(false);
            this.mobjBottomLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.Label mobjFirstLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjMapControlTypeComboBox;
        private Gizmox.WebGUI.Forms.Label mobjSecondLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjMapZoomControlTypeComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTopLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjBottomLayoutPanel;



    }
}