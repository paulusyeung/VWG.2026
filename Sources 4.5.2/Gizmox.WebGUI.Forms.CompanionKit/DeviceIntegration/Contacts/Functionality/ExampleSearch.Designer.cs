using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Contacts.Functionality
{
    partial class ExampleSearch
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
            this.searchTextBox = new Gizmox.WebGUI.Forms.SearchTextBox();
            this.contactsListView = new CompanionKit.DeviceIntegration.Contacts.Functionality.ContactsListView();
            this.clmName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.clmPhone = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.clmAddress = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.clmEmail = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.clmBirthday = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox1
            // 
            this.searchTextBox.AllowDrag = false;
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.CustomStyle = "STB";
            this.searchTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox1";
            this.searchTextBox.Size = new System.Drawing.Size(372, 44);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Search += new System.EventHandler(this.searchTextBox_Search);
            this.searchTextBox.Clear += new System.EventHandler(this.searchTextBox_Clear);
            // 
            // contactsListView1
            // 
            this.contactsListView.AutoGenerateColumns = true;
            this.contactsListView.BackColor = System.Drawing.Color.White;
            this.contactsListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.clmName,
            this.clmPhone,
            this.clmAddress,
            this.clmEmail,
            this.clmBirthday});
            this.contactsListView.CustomStyle = "ContactsListViewSkin";
            this.contactsListView.DataMember = null;
            this.contactsListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.contactsListView.ItemsPerPage = 20;
            this.contactsListView.Location = new System.Drawing.Point(0, 50);
            this.contactsListView.Name = "contactsListView1";
            this.contactsListView.ShowItemToolTips = false;
            this.contactsListView.Size = new System.Drawing.Size(378, 581);
            this.contactsListView.TabIndex = 0;
            // 
            // clmName
            // 
            this.clmName.Text = "";
            this.clmName.Width = 150;
            // 
            // clmPhone
            // 
            this.clmPhone.Text = "";
            this.clmPhone.Width = 150;
            // 
            // clmAddress
            // 
            this.clmAddress.Text = "";
            this.clmAddress.Width = 150;
            // 
            // clmEmail
            // 
            this.clmEmail.Text = "";
            this.clmEmail.Width = 150;
            // 
            // clmBirthday
            // 
            this.clmBirthday.Text = "";
            this.clmBirthday.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.searchTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contactsListView, 0, 1);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 631);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ExampleSearch
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Size = new System.Drawing.Size(378, 631);
            this.Text = "ExampleCreate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private ContactsListView contactsListView;
        private ColumnHeader clmName;
        private ColumnHeader clmPhone;
        private ColumnHeader clmAddress;
        private ColumnHeader clmEmail;
        private ColumnHeader clmBirthday;
        private SearchTextBox searchTextBox;
        private TableLayoutPanel tableLayoutPanel1;



    }
}