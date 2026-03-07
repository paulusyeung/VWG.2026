using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.ListView.Features
{
    partial class CustomListViewPage
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
            this.columnUserID = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnUserName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnPhoto = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnVisitDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnPhone = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnCheckBox = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnUserID,
            this.columnUserName,
            this.columnPhoto,
            this.columnVisitDate,
            this.columnPhone,
            this.columnCheckBox});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.mobjListView.Location = new System.Drawing.Point(5, 65);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(310, 330);
            this.mobjListView.TabIndex = 0;
            this.mobjListView.TotalItems = 1;
            // 
            // columnUserID
            // 
            this.columnUserID.Text = "User ID";
            this.columnUserID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnUserID.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Number;
            this.columnUserID.Width = 69;
            // 
            // columnUserName
            // 
            this.columnUserName.Text = "User Name";
            this.columnUserName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnUserName.Width = 91;
            // 
            // columnPhoto
            // 
            this.columnPhoto.Text = "Photo";
            this.columnPhoto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnPhoto.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.columnPhoto.Width = 50;
            // 
            // columnVisitDate
            // 
            this.columnVisitDate.Text = "Visit Date";
            this.columnVisitDate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnVisitDate.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Date;
            this.columnVisitDate.Width = 90;
            // 
            // columnPhone
            // 
            this.columnPhone.Text = "Phone";
            this.columnPhone.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnPhone.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.columnPhone.Width = 164;
            // 
            // columnCheckBox
            // 
            this.columnCheckBox.Text = "VIP";
            this.columnCheckBox.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnCheckBox.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.columnCheckBox.Width = 50;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "ListView with a custom control in the item:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 2;
            // 
            // CustomListViewPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "CustomListViewPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private ColumnHeader columnUserID;
        private ColumnHeader columnUserName;
        private ColumnHeader columnPhone;
        private ColumnHeader columnCheckBox;
        private ColumnHeader columnPhoto;
		private ColumnHeader columnVisitDate;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}