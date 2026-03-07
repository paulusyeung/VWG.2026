namespace CompanionKit.Controls.ListView.Features
{
    partial class LabelEditPage
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
            this.listViewItem5 = new Gizmox.WebGUI.Forms.ListViewItem("item5");
            this.mobjViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjEditCheck = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjDetailsRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjListRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLargeIconRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjSmallIconRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTLPMain = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLPView = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLPMain.SuspendLayout();
            this.mobjTLPView.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLPMain.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 80);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Use LabelEdit property to edit item\'s text:";
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
            this.listViewItem4,
            this.listViewItem5});
            this.mobjListView.Location = new System.Drawing.Point(0, 80);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(160, 240);
            this.mobjListView.TabIndex = 1;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            this.columnHeader1.Width = 119;
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
            // listViewItem5
            // 
            this.listViewItem5.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem5.Text = "item5";
            // 
            // mobjViewLabel
            // 
            this.mobjViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjViewLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjViewLabel.Name = "mobjViewLabel";
            this.mobjViewLabel.Size = new System.Drawing.Size(160, 48);
            this.mobjViewLabel.TabIndex = 3;
            this.mobjViewLabel.Text = "View:";
            this.mobjViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjEditCheck
            // 
            this.mobjEditCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTLPMain.SetColumnSpan(this.mobjEditCheck, 2);
            this.mobjEditCheck.Location = new System.Drawing.Point(85, 340);
            this.mobjEditCheck.Name = "mobjEditCheck";
            this.mobjEditCheck.Size = new System.Drawing.Size(150, 40);
            this.mobjEditCheck.TabIndex = 4;
            this.mobjEditCheck.Text = "LabelEdit";
            this.mobjEditCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjEditCheck.CheckedChanged += new System.EventHandler(this.mobjEditCheck_CheckedChanged);
            // 
            // mobjDetailsRB
            // 
            this.mobjDetailsRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjDetailsRB.Checked = true;
            this.mobjDetailsRB.Location = new System.Drawing.Point(20, 57);
            this.mobjDetailsRB.Name = "mobjDetailsRB";
            this.mobjDetailsRB.Size = new System.Drawing.Size(120, 30);
            this.mobjDetailsRB.TabIndex = 5;
            this.mobjDetailsRB.Text = "Details";
            this.mobjDetailsRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjDetailsRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjListRB
            // 
            this.mobjListRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjListRB.Location = new System.Drawing.Point(20, 105);
            this.mobjListRB.Name = "mobjListRB";
            this.mobjListRB.Size = new System.Drawing.Size(120, 30);
            this.mobjListRB.TabIndex = 6;
            this.mobjListRB.Text = "List";
            this.mobjListRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjListRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjLargeIconRB
            // 
            this.mobjLargeIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLargeIconRB.Location = new System.Drawing.Point(20, 153);
            this.mobjLargeIconRB.Name = "mobjLargeIconRB";
            this.mobjLargeIconRB.Size = new System.Drawing.Size(120, 30);
            this.mobjLargeIconRB.TabIndex = 7;
            this.mobjLargeIconRB.Text = "LargeIcon";
            this.mobjLargeIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjLargeIconRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjSmallIconRB
            // 
            this.mobjSmallIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjSmallIconRB.Location = new System.Drawing.Point(20, 201);
            this.mobjSmallIconRB.Name = "mobjSmallIconRB";
            this.mobjSmallIconRB.Size = new System.Drawing.Size(120, 30);
            this.mobjSmallIconRB.TabIndex = 8;
            this.mobjSmallIconRB.Text = "SmallIcon";
            this.mobjSmallIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjSmallIconRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjTLPMain
            // 
            this.mobjTLPMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLPMain.ColumnCount = 2;
            this.mobjTLPMain.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLPMain.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLPMain.Controls.Add(this.mobjTLPView, 1, 1);
            this.mobjTLPMain.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLPMain.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLPMain.Controls.Add(this.mobjEditCheck, 0, 2);
            this.mobjTLPMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLPMain.Location = new System.Drawing.Point(0, 0);
            this.mobjTLPMain.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLPMain.Name = "mobjTLPMain";
            this.mobjTLPMain.RowCount = 3;
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPMain.Size = new System.Drawing.Size(320, 400);
            this.mobjTLPMain.TabIndex = 9;
            // 
            // mobjTLPView
            // 
            this.mobjTLPView.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLPView.ColumnCount = 1;
            this.mobjTLPView.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLPView.Controls.Add(this.mobjViewLabel, 0, 0);
            this.mobjTLPView.Controls.Add(this.mobjDetailsRB, 0, 1);
            this.mobjTLPView.Controls.Add(this.mobjSmallIconRB, 0, 4);
            this.mobjTLPView.Controls.Add(this.mobjListRB, 0, 2);
            this.mobjTLPView.Controls.Add(this.mobjLargeIconRB, 0, 3);
            this.mobjTLPView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLPView.Location = new System.Drawing.Point(160, 80);
            this.mobjTLPView.Name = "mobjTLPView";
            this.mobjTLPView.RowCount = 5;
            this.mobjTLPView.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPView.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPView.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPView.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPView.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLPView.Size = new System.Drawing.Size(160, 240);
            this.mobjTLPView.TabIndex = 10;
            // 
            // LabelEditPage
            // 
            this.Controls.Add(this.mobjTLPMain);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "LabelEditPage";
            this.mobjTLPMain.ResumeLayout(false);
            this.mobjTLPView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.Label mobjViewLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjEditCheck;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem2;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem3;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem4;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem5;
        private Gizmox.WebGUI.Forms.RadioButton mobjDetailsRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjListRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjLargeIconRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjSmallIconRB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLPMain;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLPView;

    }
}