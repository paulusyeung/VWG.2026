using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.Programming
{
    partial class ItemFormatingValidatingPage
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
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnUserName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnPhone = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjForecolorLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjBackcolorLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjResultLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjForeCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjBackCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjLabel, 2);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 120);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "ListView with handling ItemFormatting event:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnUserName,
            this.columnPhone});
            this.mobjTLP.SetColumnSpan(this.mobjListView, 2);
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(5, 185);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.MultiSelect = false;
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(310, 150);
            this.mobjListView.TabIndex = 1;
            this.mobjListView.TotalItems = 1;
            this.mobjListView.SelectedIndexChanged += new System.EventHandler(this.mobjListView_SelectedIndexChanged);
            this.mobjListView.ItemFormatting += new Gizmox.WebGUI.Forms.ListViewItemFormattingEventHandler(this.mobjListView_ItemFormatting);
            // 
            // columnUserName
            // 
            this.columnUserName.Text = "User Name";
            this.columnUserName.Width = 108;
            // 
            // columnPhone
            // 
            this.columnPhone.Text = "Phone";
            this.columnPhone.Width = 132;
            // 
            // mobjForecolorLbl
            // 
            this.mobjForecolorLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjForecolorLbl.Location = new System.Drawing.Point(0, 60);
            this.mobjForecolorLbl.Name = "mobjForecolorLbl";
            this.mobjForecolorLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjForecolorLbl.Size = new System.Drawing.Size(160, 60);
            this.mobjForecolorLbl.TabIndex = 2;
            this.mobjForecolorLbl.Text = "Foreground color";
            this.mobjForecolorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjBackcolorLbl
            // 
            this.mobjBackcolorLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBackcolorLbl.Location = new System.Drawing.Point(0, 0);
            this.mobjBackcolorLbl.Name = "mobjBackcolorLbl";
            this.mobjBackcolorLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjBackcolorLbl.Size = new System.Drawing.Size(160, 60);
            this.mobjBackcolorLbl.TabIndex = 3;
            this.mobjBackcolorLbl.Text = "Background color";
            this.mobjBackcolorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjResultLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjResultLabel, 2);
            this.mobjResultLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjResultLabel.Location = new System.Drawing.Point(0, 340);
            this.mobjResultLabel.Name = "mobjResultLabel";
            this.mobjResultLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjResultLabel.TabIndex = 4;
            this.mobjResultLabel.Text = "result of formatting";
            this.mobjResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjForeCB
            // 
            this.mobjForeCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjForeCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjForeCB.Location = new System.Drawing.Point(160, 79);
            this.mobjForeCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjForeCB.Name = "mobjForeCB";
            this.mobjForeCB.Size = new System.Drawing.Size(160, 25);
            this.mobjForeCB.TabIndex = 5;
            this.mobjForeCB.SelectedIndexChanged += new System.EventHandler(this.mobjForeCB_SelectedIndexChanged);
            // 
            // mobjBackCB
            // 
            this.mobjBackCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjBackCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjBackCB.Location = new System.Drawing.Point(160, 19);
            this.mobjBackCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjBackCB.Name = "mobjBackCB";
            this.mobjBackCB.Size = new System.Drawing.Size(160, 25);
            this.mobjBackCB.TabIndex = 6;
            this.mobjBackCB.SelectedIndexChanged += new System.EventHandler(this.mobjBackCB_SelectedIndexChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjBackcolorLbl, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjResultLabel, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjForeCB, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjBackCB, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjForecolorLbl, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 7;
            // 
            // ItemFormatingValidatingPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ItemFormatingValidatingPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private ColumnHeader columnUserName;
        private ColumnHeader columnPhone;
        private Gizmox.WebGUI.Forms.Label mobjForecolorLbl;
        private Gizmox.WebGUI.Forms.Label mobjBackcolorLbl;
        private Gizmox.WebGUI.Forms.Label mobjResultLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjForeCB;
        private Gizmox.WebGUI.Forms.ComboBox mobjBackCB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
