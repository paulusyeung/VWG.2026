namespace CompanionKit.Controls.GoogleMap.Features
{
    partial class MapAddressPropertyPage
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
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAddressTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSetAddressButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondaryLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjContainerPanel.SuspendLayout();
            this.mobjSecondaryLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGoogleMap
            // 
            this.mobjGoogleMap.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            this.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGoogleMap.Location = new System.Drawing.Point(30, 30);
            this.mobjGoogleMap.MapAddress = "golden gate bridge";
            this.mobjGoogleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.mobjGoogleMap.Name = "mobjGoogleMap";
            this.mobjGoogleMap.Size = new System.Drawing.Size(412, 230);
            this.mobjGoogleMap.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjLabel.Location = new System.Drawing.Point(0, 20);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(168, 30);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Address";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjAddressTextBox
            // 
            this.mobjAddressTextBox.AllowDrag = false;
            this.mobjAddressTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjAddressTextBox.Location = new System.Drawing.Point(171, 17);
            this.mobjAddressTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjAddressTextBox.Name = "mobjAddressTextBox";
            this.mobjAddressTextBox.Size = new System.Drawing.Size(238, 30);
            this.mobjAddressTextBox.TabIndex = 2;
            this.mobjAddressTextBox.Text = "golden gate bridge";
            // 
            // mobjSetAddressButton
            // 
            this.mobjSetAddressButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSetAddressButton.Location = new System.Drawing.Point(30, 320);
            this.mobjSetAddressButton.Name = "mobjSetAddressButton";
            this.mobjSetAddressButton.Size = new System.Drawing.Size(412, 50);
            this.mobjSetAddressButton.TabIndex = 3;
            this.mobjSetAddressButton.Text = "Set Address";
            this.mobjSetAddressButton.UseVisualStyleBackColor = true;
            this.mobjSetAddressButton.Click += new System.EventHandler(this.mobjSetAddressButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.Controls.Add(this.mobjGoogleMap, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetAddressButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerPanel, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(472, 400);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.Controls.Add(this.mobjSecondaryLayoutPanel);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.Location = new System.Drawing.Point(30, 260);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Size = new System.Drawing.Size(412, 50);
            this.mobjContainerPanel.TabIndex = 0;
            // 
            // mobjSecondaryLayoutPanel
            // 
            this.mobjSecondaryLayoutPanel.ColumnCount = 2;
            this.mobjSecondaryLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.8F));
            this.mobjSecondaryLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 59.2F));
            this.mobjSecondaryLayoutPanel.Controls.Add(this.mobjAddressTextBox, 1, 0);
            this.mobjSecondaryLayoutPanel.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjSecondaryLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSecondaryLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjSecondaryLayoutPanel.Name = "mobjSecondaryLayoutPanel";
            this.mobjSecondaryLayoutPanel.RowCount = 1;
            this.mobjSecondaryLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjSecondaryLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjSecondaryLayoutPanel.Size = new System.Drawing.Size(412, 50);
            this.mobjSecondaryLayoutPanel.TabIndex = 0;
            // 
            // MapAddressPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Location = new System.Drawing.Point(0, -51);
            this.Size = new System.Drawing.Size(472, 400);
            this.Text = "MapAddressPropertyPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjContainerPanel.ResumeLayout(false);
            this.mobjSecondaryLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Professional.GoogleMap mobjGoogleMap;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjAddressTextBox;
        private Gizmox.WebGUI.Forms.Button mobjSetAddressButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjSecondaryLayoutPanel;



    }
}