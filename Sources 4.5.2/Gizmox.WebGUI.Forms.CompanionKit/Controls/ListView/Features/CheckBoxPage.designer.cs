using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.Features
{
    partial class CheckBoxPage
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
            this.columnHeader2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.listViewItem1 = new Gizmox.WebGUI.Forms.ListViewItem(new string[] {
            "item1",
            "subitem1"}, -1);
            this.listViewItem2 = new Gizmox.WebGUI.Forms.ListViewItem(new string[] {
            "item2",
            "subitem2"}, -1);
            this.listViewItem3 = new Gizmox.WebGUI.Forms.ListViewItem(new string[] {
            "item3",
            "subitem3"}, -1);
            this.listViewItem4 = new Gizmox.WebGUI.Forms.ListViewItem(new string[] {
            "item4",
            "subitem4"}, -1);
            this.listViewItem5 = new Gizmox.WebGUI.Forms.ListViewItem(new string[] {
            "item5",
            "subitem5"}, -1);
            this.mobjGridCheck = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjBoxesCheck = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
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
            this.mobjInfoLabel.Text = "Show or hide grid lines and check boxes in ListView:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.mobjTLP.SetColumnSpan(this.mobjListView, 2);
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Items.AddRange(new Gizmox.WebGUI.Forms.ListViewItem[] {
            this.listViewItem1,
            this.listViewItem2,
            this.listViewItem3,
            this.listViewItem4,
            this.listViewItem5});
            this.mobjListView.Location = new System.Drawing.Point(5, 145);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(310, 250);
            this.mobjListView.TabIndex = 1;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column1";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Column2";
            this.columnHeader2.Width = 117;
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
            // mobjGridCheck
            // 
            this.mobjGridCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjGridCheck.Location = new System.Drawing.Point(30, 80);
            this.mobjGridCheck.Name = "mobjGridCheck";
            this.mobjGridCheck.Size = new System.Drawing.Size(130, 40);
            this.mobjGridCheck.TabIndex = 2;
            this.mobjGridCheck.Text = "GridLines";
            this.mobjGridCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjGridCheck.CheckedChanged += new System.EventHandler(this.mobjGridCheck_CheckedChanged);
            // 
            // mobjBoxesCheck
            // 
            this.mobjBoxesCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjBoxesCheck.Location = new System.Drawing.Point(180, 80);
            this.mobjBoxesCheck.Name = "mobjBoxesCheck";
            this.mobjBoxesCheck.Size = new System.Drawing.Size(130, 40);
            this.mobjBoxesCheck.TabIndex = 3;
            this.mobjBoxesCheck.Text = "CheckBoxes";
            this.mobjBoxesCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjBoxesCheck.CheckedChanged += new System.EventHandler(this.mobjBoxesCheck_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjBoxesCheck, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjGridCheck, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 4;
            // 
            // CheckBoxPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "CheckBoxPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem1;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem2;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem3;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem4;
        private Gizmox.WebGUI.Forms.ListViewItem listViewItem5;
        private Gizmox.WebGUI.Forms.CheckBox mobjGridCheck;
        private Gizmox.WebGUI.Forms.CheckBox mobjBoxesCheck;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
