namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapTypePropertyPage
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
            this.mobjMapTypeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjGoogleMap = new Gizmox.WebGUI.Forms.Professional.GoogleMap();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMapTypeComboBox
            // 
            this.mobjMapTypeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMapTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjMapTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjMapTypeComboBox.FormattingEnabled = true;
            this.mobjMapTypeComboBox.Location = new System.Drawing.Point(0, 60);
            this.mobjMapTypeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMapTypeComboBox.Name = "mobjMapTypeComboBox";
            this.mobjMapTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjMapTypeComboBox.TabIndex = 2;
            this.mobjMapTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjMapTypeComboBox_SelectedIndexChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjLabel.Location = new System.Drawing.Point(0, 17);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(625, 13);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Please select MapType";
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
            this.mobjGoogleMap.Size = new System.Drawing.Size(625, 231);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjAdditionalLayoutPanel, 1, 2);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 4;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(685, 351);
            this.mobjCommonLayoutPanel.TabIndex = 3;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.ColumnCount = 1;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjMapTypeComboBox, 0, 1);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(30, 261);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 2;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(625, 60);
            this.mobjAdditionalLayoutPanel.TabIndex = 0;
            // 
            // MapTypePropertyPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Size = new System.Drawing.Size(685, 351);
            this.Text = "MapTypePropertyPage";
            this.Load += new System.EventHandler(this.MapTypePropertyPage_Load);
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjMapTypeComboBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;



    }
}