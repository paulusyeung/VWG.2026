namespace CompanionKit.Controls.ListView.Features
{
    partial class ItemPositionPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.listViewItem1 = new Gizmox.WebGUI.Forms.ListViewItem("item1");
            this.listViewItem2 = new Gizmox.WebGUI.Forms.ListViewItem("item2");
            this.listViewItem3 = new Gizmox.WebGUI.Forms.ListViewItem("item3");
            this.listViewItem4 = new Gizmox.WebGUI.Forms.ListViewItem("item4");
            this.mobjViewCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjXNumeric = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjYNumeric = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjXLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjYLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjXNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjYNumeric)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "NumericUpDowns show X and Y position of selected item:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Items.AddRange(new Gizmox.WebGUI.Forms.ListViewItem[] {
            this.listViewItem1,
            this.listViewItem2,
            this.listViewItem3,
            this.listViewItem4});
            this.mobjListView.Location = new System.Drawing.Point(0, 60);
            this.mobjListView.MultiSelect = false;
            this.mobjListView.Name = "mobjListView";
            this.mobjTLP.SetRowSpan(this.mobjListView, 2);
            this.mobjListView.Size = new System.Drawing.Size(160, 220);
            this.mobjListView.TabIndex = 1;
            this.mobjListView.SelectedIndexChanged += new System.EventHandler(this.mobjListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            this.columnHeader1.Width = 150;
            // 
            // listViewItem1
            // 
            this.listViewItem1.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem1.Text = "item1";
            // 
            // listViewItem2
            // 
            this.listViewItem2.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem2.Text = "item2";
            // 
            // listViewItem3
            // 
            this.listViewItem3.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem3.Text = "item3";
            // 
            // listViewItem4
            // 
            this.listViewItem4.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem4.Text = "item4";
            // 
            // mobjViewCB
            // 
            this.mobjViewCB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjViewCB.FormattingEnabled = true;
            this.mobjViewCB.Location = new System.Drawing.Point(165, 189);
            this.mobjViewCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjViewCB.Name = "mobjViewCB";
            this.mobjViewCB.Size = new System.Drawing.Size(150, 25);
            this.mobjViewCB.TabIndex = 2;
            this.mobjViewCB.Text = "Details";
            this.mobjViewCB.SelectedIndexChanged += new System.EventHandler(this.mobjViewCB_SelectedIndexChanged);
            // 
            // mobjViewLabel
            // 
            this.mobjViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjViewLabel.Location = new System.Drawing.Point(160, 60);
            this.mobjViewLabel.Name = "mobjViewLabel";
            this.mobjViewLabel.Size = new System.Drawing.Size(160, 60);
            this.mobjViewLabel.TabIndex = 3;
            this.mobjViewLabel.Text = "View:";
            this.mobjViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjXNumeric
            // 
            this.mobjXNumeric.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjXNumeric.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjXNumeric.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjXNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mobjXNumeric.Location = new System.Drawing.Point(160, 299);
            this.mobjXNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjXNumeric.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjXNumeric.Name = "mobjXNumeric";
            this.mobjXNumeric.Size = new System.Drawing.Size(160, 21);
            this.mobjXNumeric.TabIndex = 4;
            this.mobjXNumeric.ValueChanged += new System.EventHandler(this.mobjXNumeric_ValueChanged);
            // 
            // mobjYNumeric
            // 
            this.mobjYNumeric.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjYNumeric.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjYNumeric.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjYNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mobjYNumeric.Location = new System.Drawing.Point(160, 359);
            this.mobjYNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjYNumeric.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjYNumeric.Name = "mobjYNumeric";
            this.mobjYNumeric.Size = new System.Drawing.Size(160, 21);
            this.mobjYNumeric.TabIndex = 5;
            this.mobjYNumeric.ValueChanged += new System.EventHandler(this.mobjYNumeric_ValueChanged);
            // 
            // mobjXLabel
            // 
            this.mobjXLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjXLabel.Location = new System.Drawing.Point(0, 280);
            this.mobjXLabel.Name = "mobjXLabel";
            this.mobjXLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjXLabel.Size = new System.Drawing.Size(160, 60);
            this.mobjXLabel.TabIndex = 6;
            this.mobjXLabel.Text = "X";
            this.mobjXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjYLabel
            // 
            this.mobjYLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjYLabel.Location = new System.Drawing.Point(0, 340);
            this.mobjYLabel.Name = "mobjYLabel";
            this.mobjYLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjYLabel.Size = new System.Drawing.Size(160, 60);
            this.mobjYLabel.TabIndex = 7;
            this.mobjYLabel.Text = "Y";
            this.mobjYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjYLabel, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjXLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjViewLabel, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjYNumeric, 1, 4);
            this.mobjTLP.Controls.Add(this.mobjViewCB, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjXNumeric, 1, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 8;
            // 
            // ItemPositionPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ItemPositionPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjXNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjYNumeric)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ComboBox mobjViewCB;
        private Gizmox.WebGUI.Forms.Label mobjViewLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjXNumeric;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjYNumeric;
        private Gizmox.WebGUI.Forms.Label mobjXLabel;
        private Gizmox.WebGUI.Forms.Label mobjYLabel;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem2;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem3;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem4;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}