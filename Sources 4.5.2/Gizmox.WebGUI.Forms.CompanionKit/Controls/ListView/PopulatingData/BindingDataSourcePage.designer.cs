using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.PopulatingData
{
    partial class BindingDataSourcePage
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
            this.components = new System.ComponentModel.Container();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.northwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.customersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.columnCustomerID = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnCompanyName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnContactName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnContactTitle = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnAddress = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnCity = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnRegion = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnPostalCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnCountry = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnPhone = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnFax = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "ListView with a database DataSource:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnCustomerID,
            this.columnCompanyName,
            this.columnContactName,
            this.columnContactTitle,
            this.columnAddress,
            this.columnCity,
            this.columnRegion,
            this.columnPostalCode,
            this.columnCountry,
            this.columnPhone,
            this.columnFax});
            this.mobjListView.DataMember = null;
            this.mobjListView.DataSource = this.bindingSource1;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(5, 65);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(310, 330);
            this.mobjListView.TabIndex = 1;
            this.mobjListView.TotalItems = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Customers";
            this.bindingSource1.DataSource = this.northwindDataSet;
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName = "NorthwindDataSet";
            this.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
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
            // columnCustomerID
            // 
            this.columnCustomerID.Tag = "CustomerID";
            this.columnCustomerID.Text = "CustomerID";
            this.columnCustomerID.Width = 100;
            // 
            // columnCompanyName
            // 
            this.columnCompanyName.Tag = "CompanyName";
            this.columnCompanyName.Text = "CompanyName";
            this.columnCompanyName.Width = 100;
            // 
            // columnContactName
            // 
            this.columnContactName.Tag = "ContactName";
            this.columnContactName.Text = "ContactName";
            this.columnContactName.Width = 100;
            // 
            // columnContactTitle
            // 
            this.columnContactTitle.Tag = "ContactTitle";
            this.columnContactTitle.Text = "ContactTitle";
            this.columnContactTitle.Width = 100;
            // 
            // columnAddress
            // 
            this.columnAddress.Tag = "Address";
            this.columnAddress.Text = "Address";
            this.columnAddress.Width = 100;
            // 
            // columnCity
            // 
            this.columnCity.Tag = "City";
            this.columnCity.Text = "City";
            this.columnCity.Width = 100;
            // 
            // columnRegion
            // 
            this.columnRegion.Tag = "Region";
            this.columnRegion.Text = "Region";
            this.columnRegion.Width = 100;
            // 
            // columnPostalCode
            // 
            this.columnPostalCode.Tag = "PostalCode";
            this.columnPostalCode.Text = "PostalCode";
            this.columnPostalCode.Width = 100;
            // 
            // columnCountry
            // 
            this.columnCountry.Tag = "Country";
            this.columnCountry.Text = "Country";
            this.columnCountry.Width = 100;
            // 
            // columnPhone
            // 
            this.columnPhone.Tag = "Phone";
            this.columnPhone.Text = "Phone";
            this.columnPhone.Width = 100;
            // 
            // columnFax
            // 
            this.columnFax.Tag = "Fax";
            this.columnFax.Text = "Fax";
            this.columnFax.Width = 100;
            // 
            // BindingDataSourcePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "BindingDataSourcePage";
            this.Load += new System.EventHandler(this.BindingDataSourcePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet northwindDataSet;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private ColumnHeader columnCustomerID;
        private ColumnHeader columnCompanyName;
        private ColumnHeader columnContactName;
        private ColumnHeader columnContactTitle;
        private ColumnHeader columnAddress;
        private ColumnHeader columnCity;
        private ColumnHeader columnRegion;
        private ColumnHeader columnPostalCode;
        private ColumnHeader columnCountry;
        private ColumnHeader columnPhone;
        private ColumnHeader columnFax;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
