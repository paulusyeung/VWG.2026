namespace CompanionKit.Controls.SearchTextBox.Functionality
{
    partial class SearchingPage
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
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnHeader = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjSearchTextBox = new Gizmox.WebGUI.Forms.SearchTextBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListView
            // 
            this.mobjListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.HeaderSize;
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnHeader});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(113, 37);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Scrollable = false;
            this.mobjListView.Size = new System.Drawing.Size(180, 173);
            this.mobjListView.TabIndex = 0;
            // 
            // mobjColumnHeader
            // 
            this.mobjColumnHeader.Text = "Fruit";
            this.mobjColumnHeader.Width = 152;
            // 
            // mobjSearchTextBox
            // 
            this.mobjSearchTextBox.AllowDrag = false;
            this.mobjSearchTextBox.CustomStyle = "STB";
            this.mobjSearchTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSearchTextBox.Location = new System.Drawing.Point(116, 293);
            this.mobjSearchTextBox.Name = "mobjSearchTextBox";
            this.mobjSearchTextBox.Size = new System.Drawing.Size(174, 24);
            this.mobjSearchTextBox.TabIndex = 1;
            this.mobjSearchTextBox.Search += new System.EventHandler(this.objSearchTextBox_Search);
            this.mobjSearchTextBox.TextChanged += new System.EventHandler(this.mobjSearchTextBox_TextChanged);
            // 
            // mobjLabel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjLabel, 3);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 220);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(407, 60);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Enter text and press button with \"Magnifier\" icon";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 180F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjListView, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel, 0, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjSearchTextBox, 1, 5);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(407, 358);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // SearchingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(407, 358);
            this.Text = "SearchingPage";
            this.Load += new System.EventHandler(this.SearchingPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnHeader;
        private Gizmox.WebGUI.Forms.SearchTextBox mobjSearchTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}