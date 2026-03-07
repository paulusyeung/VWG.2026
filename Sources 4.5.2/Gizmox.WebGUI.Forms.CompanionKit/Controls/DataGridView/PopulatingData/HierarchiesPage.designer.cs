//using Gizmox.WebGUI.Forms.CompanionKit.Controls.DataGridView.PopulatingData;
namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    partial class HierarchiesPage
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
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDGV = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjOrdersSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjDS = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.hierarchicInfo1 = new Gizmox.WebGUI.Forms.HierarchicInfo();
            this.mobjOrderDetailsSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjOrderIDFilter = new Gizmox.WebGUI.Forms.FilterRelation();
            this.hierarchicInfo2 = new Gizmox.WebGUI.Forms.HierarchicInfo();
            this.mobjProductsSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjProductIDFilter = new Gizmox.WebGUI.Forms.FilterRelation();
            this.ordersAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            this.orderDetailsAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter();
            this.productsAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.ProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjOrdersSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjOrderDetailsSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjProductsSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(451, 66);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Use ColumnChooser to show or hide columns in HierarchicalDataGridView:";
            // 
            // mobjDGV
            // 
            this.mobjDGV.AccessibleDescription = "Orders";
            this.mobjDGV.AccessibleName = "Orders";
            this.mobjDGV.AllowDrag = false;
            this.mobjDGV.AutoGenerateColumns = false;
            this.mobjDGV.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDGV.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.mobjDGV.DataSource = this.mobjOrdersSource;
            this.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDGV.ExpansionIndicator = Gizmox.WebGUI.Forms.ShowExpansionIndicator.Always;
            this.mobjDGV.HierarchicInfos.Add(this.hierarchicInfo1);
            this.mobjDGV.HierarchicInfos.Add(this.hierarchicInfo2);
            this.mobjDGV.Location = new System.Drawing.Point(0, 66);
            this.mobjDGV.Name = "mobjDGV";
            this.mobjDGV.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.mobjDGV.ShowColumnChooser = true;
            this.mobjDGV.Size = new System.Drawing.Size(451, 272);
            this.mobjDGV.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn1.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CustomerID";
            this.dataGridViewTextBoxColumn2.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EmployeeID";
            this.dataGridViewTextBoxColumn3.HeaderText = "EmployeeID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RequiredDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "RequiredDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ShippedDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "ShippedDate";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ShipVia";
            this.dataGridViewTextBoxColumn7.HeaderText = "ShipVia";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Freight";
            this.dataGridViewTextBoxColumn8.HeaderText = "Freight";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ShipName";
            this.dataGridViewTextBoxColumn9.HeaderText = "ShipName";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ShipAddress";
            this.dataGridViewTextBoxColumn10.HeaderText = "ShipAddress";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ShipCity";
            this.dataGridViewTextBoxColumn11.HeaderText = "ShipCity";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ShipRegion";
            this.dataGridViewTextBoxColumn12.HeaderText = "ShipRegion";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ShipPostalCode";
            this.dataGridViewTextBoxColumn13.HeaderText = "ShipPostalCode";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ShipCountry";
            this.dataGridViewTextBoxColumn14.HeaderText = "ShipCountry";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // mobjOrdersSource
            // 
            this.mobjOrdersSource.DataMember = "Orders";
            this.mobjOrdersSource.DataSource = this.mobjDS;
            // 
            // mobjDS
            // 
            this.mobjDS.DataSetName = "NorthwindDataSet";
            this.mobjDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hierarchicInfo1
            // 
            this.hierarchicInfo1.BindedSource = this.mobjOrderDetailsSource;
            this.hierarchicInfo1.FilteringDataMembers.Add(this.mobjOrderIDFilter);
            this.hierarchicInfo1.HierarchyName = "Order Details";
            // 
            // mobjOrderDetailsSource
            // 
            this.mobjOrderDetailsSource.DataMember = "Order Details";
            this.mobjOrderDetailsSource.DataSource = this.mobjDS;
            // 
            // mobjOrderIDFilter
            // 
            this.mobjOrderIDFilter.SourceColumnDataName = "OrderID";
            this.mobjOrderIDFilter.TargetColumnDataName = "OrderID";
            // 
            // hierarchicInfo2
            // 
            this.hierarchicInfo2.BindedSource = this.mobjProductsSource;
            this.hierarchicInfo2.FilteringDataMembers.Add(this.mobjProductIDFilter);
            this.hierarchicInfo2.HierarchyName = "Product Info";
            // 
            // mobjProductsSource
            // 
            this.mobjProductsSource.DataMember = "Products";
            this.mobjProductsSource.DataSource = this.mobjDS;
            // 
            // mobjProductIDFilter
            // 
            this.mobjProductIDFilter.SourceColumnDataName = "ProductID";
            this.mobjProductIDFilter.TargetColumnDataName = "ProductID";
            // 
            // ordersAdapter
            // 
            this.ordersAdapter.ClearBeforeFill = true;
            // 
            // orderDetailsAdapter
            // 
            this.orderDetailsAdapter.ClearBeforeFill = true;
            // 
            // productsAdapter
            // 
            this.productsAdapter.ClearBeforeFill = true;
            // 
            // HierarchiesPage
            // 
            this.Controls.Add(this.mobjDGV);
            this.Controls.Add(this.mobjInfoLabel);
            this.Size = new System.Drawing.Size(451, 390);
            this.Text = "HierarchiesPage";
            this.Load += new System.EventHandler(this.HierarchiesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjOrdersSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjOrderDetailsSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjProductsSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView mobjDGV;
        private Gizmox.WebGUI.Forms.BindingSource mobjOrdersSource;
        private Gizmox.WebGUI.Forms.HierarchicInfo hierarchicInfo1;
        private Gizmox.WebGUI.Forms.BindingSource mobjOrderDetailsSource;
        private Gizmox.WebGUI.Forms.FilterRelation mobjOrderIDFilter;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private Gizmox.WebGUI.Forms.BindingSource mobjProductsSource;
        private Gizmox.WebGUI.Forms.HierarchicInfo hierarchicInfo2;
        private Gizmox.WebGUI.Forms.FilterRelation mobjProductIDFilter;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjDS;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;

        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersAdapter;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter orderDetailsAdapter;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.ProductsTableAdapter productsAdapter;

    }
} 