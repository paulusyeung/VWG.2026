namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapLayersCollectionPage
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
            this.mobjCheckedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(30, 30);
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722D, -122.478611D);
            this.mobjGoogleMap.Name = "mobjGoogleMap";
            this.mobjGoogleMap.Size = new System.Drawing.Size(634, 245);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjCheckedListBox
            // 
            this.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckedListBox.Location = new System.Drawing.Point(15, 29);
            this.mobjCheckedListBox.Name = "mobjCheckedListBox";
            this.mobjCheckedListBox.Size = new System.Drawing.Size(604, 180);
            this.mobjCheckedListBox.TabIndex = 1;
            this.mobjCheckedListBox.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.mobjCheckedListBox_ItemCheck);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjCheckedListBox);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(30, 295);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjGroupBox.Size = new System.Drawing.Size(634, 225);
            this.mobjGroupBox.TabIndex = 2;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "MapLayers";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupBox, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 225F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(694, 540);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // MapLayersCollectionPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(694, 540);
            this.Text = "MapLayersCollectionPage";
            this.Load += new System.EventHandler(this.MapLayersCollectionPage_Load);
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckedListBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}