using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.Features
{
    partial class ViewsPage
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
            this.userNameColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.phoneColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjDetailsRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjListRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLargeIconRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjSmallIconRB = new Gizmox.WebGUI.Forms.RadioButton();
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
            this.mobjInfoLabel.TabIndex = 2;
            this.mobjInfoLabel.Text = "ListView with selected view type:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.userNameColumn,
            this.phoneColumn});
            this.mobjTLP.SetColumnSpan(this.mobjListView, 2);
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(5, 65);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(310, 170);
            this.mobjListView.TabIndex = 3;
            this.mobjListView.TotalItems = 1;
            // 
            // userNameColumn
            // 
            this.userNameColumn.Text = "User Name";
            this.userNameColumn.Width = 120;
            // 
            // phoneColumn
            // 
            this.phoneColumn.Text = "Phone";
            this.phoneColumn.Width = 120;
            // 
            // mobjDetailsRB
            // 
            this.mobjDetailsRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjDetailsRB.Checked = true;
            this.mobjDetailsRB.Location = new System.Drawing.Point(15, 260);
            this.mobjDetailsRB.Name = "mobjDetailsRB";
            this.mobjDetailsRB.Size = new System.Drawing.Size(130, 40);
            this.mobjDetailsRB.TabIndex = 4;
            this.mobjDetailsRB.Text = "Details";
            this.mobjDetailsRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjDetailsRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjListRB
            // 
            this.mobjListRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjListRB.Location = new System.Drawing.Point(15, 340);
            this.mobjListRB.Name = "mobjListRB";
            this.mobjListRB.Size = new System.Drawing.Size(130, 40);
            this.mobjListRB.TabIndex = 5;
            this.mobjListRB.Text = "List";
            this.mobjListRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjListRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjLargeIconRB
            // 
            this.mobjLargeIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLargeIconRB.Location = new System.Drawing.Point(175, 260);
            this.mobjLargeIconRB.Name = "mobjLargeIconRB";
            this.mobjLargeIconRB.Size = new System.Drawing.Size(130, 40);
            this.mobjLargeIconRB.TabIndex = 6;
            this.mobjLargeIconRB.Text = "LargeIcon";
            this.mobjLargeIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjLargeIconRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjSmallIconRB
            // 
            this.mobjSmallIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjSmallIconRB.Location = new System.Drawing.Point(175, 340);
            this.mobjSmallIconRB.Name = "mobjSmallIconRB";
            this.mobjSmallIconRB.Size = new System.Drawing.Size(130, 40);
            this.mobjSmallIconRB.TabIndex = 7;
            this.mobjSmallIconRB.Text = "SmallIcon";
            this.mobjSmallIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjSmallIconRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjListRB, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjSmallIconRB, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjLargeIconRB, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjDetailsRB, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 8;
            // 
            // ViewsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ViewsPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private ColumnHeader userNameColumn;
        private ColumnHeader phoneColumn;
        private Gizmox.WebGUI.Forms.RadioButton mobjDetailsRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjListRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjLargeIconRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjSmallIconRB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
