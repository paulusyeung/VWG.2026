using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.Performance
{
    partial class PagingPage
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
            this.listViewWithPaging = new Gizmox.WebGUI.Forms.ListView();
            this.columnUserNameWithPaging = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnEmailWithPaging = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.listViewWithoutPaging = new Gizmox.WebGUI.Forms.ListView();
            this.columnUserNameWithoutPaging = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnEmailWithoutPaging = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjPerPageLabel = new Gizmox.WebGUI.Forms.Label();
            this.itemsPerPagesNumUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.itemsPerPagesNumUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewWithPaging
            // 
            this.listViewWithPaging.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnUserNameWithPaging,
            this.columnEmailWithPaging});
            this.mobjTLP.SetColumnSpan(this.listViewWithPaging, 2);
            this.listViewWithPaging.DataMember = null;
            this.listViewWithPaging.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listViewWithPaging.Location = new System.Drawing.Point(0, 120);
            this.listViewWithPaging.Name = "listView1";
            this.listViewWithPaging.Size = new System.Drawing.Size(320, 110);
            this.listViewWithPaging.TabIndex = 0;
            this.listViewWithPaging.UseInternalPaging = true;
            // 
            // columnUserNameWithPaging
            // 
            this.columnUserNameWithPaging.Text = "User Name";
            this.columnUserNameWithPaging.Width = 94;
            // 
            // columnEmailWithPaging
            // 
            this.columnEmailWithPaging.Text = "E-mail";
            this.columnEmailWithPaging.Width = 137;
            // 
            // mobjLabel1
            // 
            this.mobjTLP.SetColumnSpan(this.mobjLabel1, 2);
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 60);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel1.TabIndex = 1;
            this.mobjLabel1.Text = "ListView with paging items:";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewWithoutPaging
            // 
            this.listViewWithoutPaging.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnUserNameWithoutPaging,
            this.columnEmailWithoutPaging});
            this.mobjTLP.SetColumnSpan(this.listViewWithoutPaging, 2);
            this.listViewWithoutPaging.DataMember = null;
            this.listViewWithoutPaging.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listViewWithoutPaging.Location = new System.Drawing.Point(0, 290);
            this.listViewWithoutPaging.Name = "listViewWithoutPaging";
            this.listViewWithoutPaging.Size = new System.Drawing.Size(320, 110);
            this.listViewWithoutPaging.TabIndex = 3;
            this.listViewWithoutPaging.TotalItems = 1;
            // 
            // columnUserNameWithoutPaging
            // 
            this.columnUserNameWithoutPaging.Text = "User Name";
            this.columnUserNameWithoutPaging.Width = 95;
            // 
            // columnEmailWithoutPaging
            // 
            this.columnEmailWithoutPaging.Text = "Email";
            this.columnEmailWithoutPaging.Width = 135;
            // 
            // mobjLabel2
            // 
            this.mobjTLP.SetColumnSpan(this.mobjLabel2, 2);
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 230);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel2.TabIndex = 4;
            this.mobjLabel2.Text = "ListView without paging items:";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjPerPageLabel
            // 
            this.mobjPerPageLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPerPageLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjPerPageLabel.Name = "mobjPerPageLabel";
            this.mobjPerPageLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjPerPageLabel.Size = new System.Drawing.Size(160, 60);
            this.mobjPerPageLabel.TabIndex = 5;
            this.mobjPerPageLabel.Text = "ItemsPerPage";
            this.mobjPerPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemsPerPagesNumUpDown
            // 
            this.itemsPerPagesNumUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.itemsPerPagesNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.itemsPerPagesNumUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemsPerPagesNumUpDown.Location = new System.Drawing.Point(160, 19);
            this.itemsPerPagesNumUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.itemsPerPagesNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemsPerPagesNumUpDown.Name = "numericUpDown1";
            this.itemsPerPagesNumUpDown.Size = new System.Drawing.Size(160, 21);
            this.itemsPerPagesNumUpDown.TabIndex = 6;
            this.itemsPerPagesNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemsPerPagesNumUpDown.ValueChanged += new System.EventHandler(this.itemsPerPagesNumUpDown_ValueChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjPerPageLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.listViewWithoutPaging, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjLabel2, 0, 3);
            this.mobjTLP.Controls.Add(this.itemsPerPagesNumUpDown, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjLabel1, 0, 1);
            this.mobjTLP.Controls.Add(this.listViewWithPaging, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.5F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.5F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 7;
            // 
            // PagingPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "PagingPage";
            ((System.ComponentModel.ISupportInitialize)(this.itemsPerPagesNumUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView listViewWithPaging;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnUserNameWithPaging;
        private Gizmox.WebGUI.Forms.ColumnHeader columnEmailWithPaging;
        private Gizmox.WebGUI.Forms.ListView listViewWithoutPaging;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.ColumnHeader columnUserNameWithoutPaging;
        private Gizmox.WebGUI.Forms.ColumnHeader columnEmailWithoutPaging;
        private Gizmox.WebGUI.Forms.Label mobjPerPageLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown itemsPerPagesNumUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
