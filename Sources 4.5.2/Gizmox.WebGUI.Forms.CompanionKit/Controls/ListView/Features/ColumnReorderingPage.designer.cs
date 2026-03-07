using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.Features
{
    partial class ColumnReorderingPage
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
            this.allowedReorderingColumnListView = new Gizmox.WebGUI.Forms.ListView();
            this.userIDColumnWithReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.userFirstNameColumnWithReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.userSecondNameColumnWithReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.unallowedReorderingColumnListView = new Gizmox.WebGUI.Forms.ListView();
            this.userIDColumnWithoutReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.userFirstNameColumnWithoutReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.userSecondNameColumnWithoutReordering = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // allowedReorderingColumnListView
            // 
            this.allowedReorderingColumnListView.AllowColumnReorder = true;
            this.allowedReorderingColumnListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.userIDColumnWithReordering,
            this.userFirstNameColumnWithReordering,
            this.userSecondNameColumnWithReordering});
            this.allowedReorderingColumnListView.DataMember = null;
            this.allowedReorderingColumnListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.allowedReorderingColumnListView.Location = new System.Drawing.Point(5, 65);
            this.allowedReorderingColumnListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.allowedReorderingColumnListView.Name = "listView1";
            this.allowedReorderingColumnListView.Size = new System.Drawing.Size(310, 130);
            this.allowedReorderingColumnListView.TabIndex = 0;
            this.allowedReorderingColumnListView.TotalItems = 1;
            // 
            // userIDColumnWithReordering
            // 
            this.userIDColumnWithReordering.Text = "User ID";
            this.userIDColumnWithReordering.Width = 50;
            // 
            // userFirstNameColumnWithReordering
            // 
            this.userFirstNameColumnWithReordering.Text = "User First Name";
            this.userFirstNameColumnWithReordering.Width = 120;
            // 
            // userSecondNameColumnWithReordering
            // 
            this.userSecondNameColumnWithReordering.Text = "User Second Name";
            this.userSecondNameColumnWithReordering.Width = 120;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel1.TabIndex = 1;
            this.mobjLabel1.Text = "ListView with allowed reordering of columns:";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unallowedReorderingColumnListView
            // 
            this.unallowedReorderingColumnListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.userIDColumnWithoutReordering,
            this.userFirstNameColumnWithoutReordering,
            this.userSecondNameColumnWithoutReordering});
            this.unallowedReorderingColumnListView.DataMember = null;
            this.unallowedReorderingColumnListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.unallowedReorderingColumnListView.Location = new System.Drawing.Point(5, 265);
            this.unallowedReorderingColumnListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.unallowedReorderingColumnListView.Name = "unallowedReorderingColumnListView";
            this.unallowedReorderingColumnListView.Size = new System.Drawing.Size(310, 130);
            this.unallowedReorderingColumnListView.TabIndex = 3;
            this.unallowedReorderingColumnListView.TotalItems = 1;
            // 
            // userIDColumnWithoutReordering
            // 
            this.userIDColumnWithoutReordering.Text = "User ID";
            this.userIDColumnWithoutReordering.Width = 50;
            // 
            // userFirstNameColumnWithoutReordering
            // 
            this.userFirstNameColumnWithoutReordering.Text = "User First Name";
            this.userFirstNameColumnWithoutReordering.Width = 120;
            // 
            // userSecondNameColumnWithoutReordering
            // 
            this.userSecondNameColumnWithoutReordering.Text = "User Second Name";
            this.userSecondNameColumnWithoutReordering.Width = 120;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 200);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel2.TabIndex = 4;
            this.mobjLabel2.Text = "ListView with unallowed reordering of columns:";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjLabel2, 0, 2);
            this.mobjTLP.Controls.Add(this.unallowedReorderingColumnListView, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjLabel1, 0, 0);
            this.mobjTLP.Controls.Add(this.allowedReorderingColumnListView, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 5;
            // 
            // ColumnReorderingPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ColumnReorderingPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView allowedReorderingColumnListView;
        private ColumnHeader userIDColumnWithReordering;
        private ColumnHeader userFirstNameColumnWithReordering;
        private ColumnHeader userSecondNameColumnWithReordering;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.ListView unallowedReorderingColumnListView;
        private Label mobjLabel2;
        private ColumnHeader userIDColumnWithoutReordering;
        private ColumnHeader userFirstNameColumnWithoutReordering;
        private ColumnHeader userSecondNameColumnWithoutReordering;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
