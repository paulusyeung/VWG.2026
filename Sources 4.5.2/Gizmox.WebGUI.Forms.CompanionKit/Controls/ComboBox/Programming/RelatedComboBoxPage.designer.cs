namespace CompanionKit.Controls.ComboBox.Programming
{
    partial class RelatedComboBoxPage
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
            this.mobjCustomerComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjFirstBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjIDComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjSecondBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjPriceComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjThirdBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.customersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.ordersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            this.order_DetailsTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter();
            this.mobjCustomersLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjIdLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPriceLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDataPriceLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDataIdLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDataCustomersLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCustomersTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjIDTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPricesTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjFifthPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFourthPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjThirdPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFirstPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjFirstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjSecondBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjThirdBindingSource)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjFifthPanel.SuspendLayout();
            this.mobjFourthPanel.SuspendLayout();
            this.mobjThirdPanel.SuspendLayout();
            this.mobjSecondPanel.SuspendLayout();
            this.mobjFirstPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCustomerComboBox
            // 
            this.mobjCustomerComboBox.AllowDrag = false;
            this.mobjCustomerComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjCustomerComboBox.DataSource = this.mobjFirstBindingSource;
            this.mobjCustomerComboBox.DisplayMember = "ContactName";
            this.mobjCustomerComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomerComboBox.Location = new System.Drawing.Point(331, 29);
            this.mobjCustomerComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjCustomerComboBox.Name = "mobjCustomerComboBox";
            this.mobjCustomerComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjCustomerComboBox.TabIndex = 0;
            this.mobjCustomerComboBox.ValueMember = "CustomerID";
            this.mobjCustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjCustomerComboBox_SelectedIndexChanged);
            // 
            // mobjFirstBindingSource
            // 
            this.mobjFirstBindingSource.DataMember = "Customers";
            this.mobjFirstBindingSource.DataSource = this.mobjNorthwindDataSet;
            // 
            // mobjNorthwindDataSet
            // 
            this.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet";
            this.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjIDComboBox
            // 
            this.mobjIDComboBox.AllowDrag = false;
            this.mobjIDComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjIDComboBox.DataSource = this.mobjSecondBindingSource;
            this.mobjIDComboBox.DisplayMember = "OrderID";
            this.mobjIDComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjIDComboBox.Location = new System.Drawing.Point(0, 10);
            this.mobjIDComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjIDComboBox.Name = "mobjIDComboBox";
            this.mobjIDComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjIDComboBox.TabIndex = 1;
            this.mobjIDComboBox.ValueMember = "OrderID";
            this.mobjIDComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjIDComboBox_SelectedIndexChanged);
            // 
            // mobjSecondBindingSource
            // 
            this.mobjSecondBindingSource.DataMember = "Orders";
            this.mobjSecondBindingSource.DataSource = this.mobjNorthwindDataSet;
            // 
            // mobjPriceComboBox
            // 
            this.mobjPriceComboBox.AllowDrag = false;
            this.mobjPriceComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjPriceComboBox.DataSource = this.mobjThirdBindingSource;
            this.mobjPriceComboBox.DisplayMember = "UnitPrice";
            this.mobjPriceComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPriceComboBox.Location = new System.Drawing.Point(0, 10);
            this.mobjPriceComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjPriceComboBox.Name = "mobjPriceComboBox";
            this.mobjPriceComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjPriceComboBox.TabIndex = 2;
            this.mobjPriceComboBox.ValueMember = "OrderID";
            // 
            // mobjThirdBindingSource
            // 
            this.mobjThirdBindingSource.DataMember = "Order Details";
            this.mobjThirdBindingSource.DataSource = this.mobjNorthwindDataSet;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // order_DetailsTableAdapter
            // 
            this.order_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // mobjCustomersLabel
            // 
            this.mobjCustomersLabel.AutoSize = true;
            this.mobjCustomersLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomersLabel.Location = new System.Drawing.Point(10, 29);
            this.mobjCustomersLabel.Name = "mobjCustomersLabel";
            this.mobjCustomersLabel.Size = new System.Drawing.Size(321, 30);
            this.mobjCustomersLabel.TabIndex = 3;
            this.mobjCustomersLabel.Text = "Customers";
            this.mobjCustomersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjIdLabel
            // 
            this.mobjIdLabel.AutoSize = true;
            this.mobjIdLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjIdLabel.Location = new System.Drawing.Point(10, 69);
            this.mobjIdLabel.Name = "mobjIdLabel";
            this.mobjIdLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjIdLabel.TabIndex = 4;
            this.mobjIdLabel.Text = "Customer order IDs";
            this.mobjIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjPriceLabel
            // 
            this.mobjPriceLabel.AutoSize = true;
            this.mobjPriceLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPriceLabel.Location = new System.Drawing.Point(10, 129);
            this.mobjPriceLabel.Name = "mobjPriceLabel";
            this.mobjPriceLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjPriceLabel.TabIndex = 5;
            this.mobjPriceLabel.Text = "Customer order prices";
            this.mobjPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDataPriceLabel
            // 
            this.mobjDataPriceLabel.AutoSize = true;
            this.mobjDataPriceLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataPriceLabel.Location = new System.Drawing.Point(10, 309);
            this.mobjDataPriceLabel.Name = "mobjDataPriceLabel";
            this.mobjDataPriceLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjDataPriceLabel.TabIndex = 5;
            this.mobjDataPriceLabel.Text = "Data of \'Order prices\'";
            this.mobjDataPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDataIdLabel
            // 
            this.mobjDataIdLabel.AutoSize = true;
            this.mobjDataIdLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataIdLabel.Location = new System.Drawing.Point(10, 249);
            this.mobjDataIdLabel.Name = "mobjDataIdLabel";
            this.mobjDataIdLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjDataIdLabel.TabIndex = 4;
            this.mobjDataIdLabel.Text = "Data of \'Order IDs\'";
            this.mobjDataIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDataCustomersLabel
            // 
            this.mobjDataCustomersLabel.AutoSize = true;
            this.mobjDataCustomersLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataCustomersLabel.Location = new System.Drawing.Point(10, 189);
            this.mobjDataCustomersLabel.Name = "mobjDataCustomersLabel";
            this.mobjDataCustomersLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjDataCustomersLabel.TabIndex = 3;
            this.mobjDataCustomersLabel.Text = "Data of \'Customers\'";
            this.mobjDataCustomersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCustomersTextBox
            // 
            this.mobjCustomersTextBox.AllowDrag = false;
            this.mobjCustomersTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomersTextBox.Location = new System.Drawing.Point(0, 10);
            this.mobjCustomersTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjCustomersTextBox.Name = "mobjCustomersTextBox";
            this.mobjCustomersTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjCustomersTextBox.TabIndex = 6;
            this.mobjCustomersTextBox.Text = "Maria Anders";
            this.mobjCustomersTextBox.TextChanged += new System.EventHandler(this.mobjCustomersTextBox_TextChanged);
            // 
            // mobjIDTextBox
            // 
            this.mobjIDTextBox.AllowDrag = false;
            this.mobjIDTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjIDTextBox.Location = new System.Drawing.Point(0, 10);
            this.mobjIDTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjIDTextBox.Name = "mobjIDTextBox";
            this.mobjIDTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjIDTextBox.TabIndex = 7;
            this.mobjIDTextBox.Text = "10643";
            this.mobjIDTextBox.TextChanged += new System.EventHandler(this.mobjIDTextBox_TextChanged);
            // 
            // mobjPricesTextBox
            // 
            this.mobjPricesTextBox.AllowDrag = false;
            this.mobjPricesTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPricesTextBox.Location = new System.Drawing.Point(0, 10);
            this.mobjPricesTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjPricesTextBox.Name = "mobjPricesTextBox";
            this.mobjPricesTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjPricesTextBox.TabIndex = 8;
            this.mobjPricesTextBox.Text = "45.6";
            this.mobjPricesTextBox.TextChanged += new System.EventHandler(this.mobjPricesTextBox_TextChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjCustomersLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjCustomerComboBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataPriceLabel, 1, 11);
            this.mobjLayoutPanel.Controls.Add(this.mobjIdLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataIdLabel, 1, 9);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataCustomersLabel, 1, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjPriceLabel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjFifthPanel, 2, 11);
            this.mobjLayoutPanel.Controls.Add(this.mobjFourthPanel, 2, 9);
            this.mobjLayoutPanel.Controls.Add(this.mobjThirdPanel, 2, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjSecondPanel, 2, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjFirstPanel, 2, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 13;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(663, 388);
            this.mobjLayoutPanel.TabIndex = 9;
            // 
            // mobjFifthPanel
            // 
            this.mobjFifthPanel.Controls.Add(this.mobjPricesTextBox);
            this.mobjFifthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFifthPanel.DockPadding.Bottom = 10;
            this.mobjFifthPanel.DockPadding.Top = 10;
            this.mobjFifthPanel.Location = new System.Drawing.Point(331, 309);
            this.mobjFifthPanel.Name = "mobjFifthPanel";
            this.mobjFifthPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjFifthPanel.Size = new System.Drawing.Size(321, 50);
            this.mobjFifthPanel.TabIndex = 0;
            // 
            // mobjFourthPanel
            // 
            this.mobjFourthPanel.Controls.Add(this.mobjIDTextBox);
            this.mobjFourthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFourthPanel.DockPadding.Bottom = 10;
            this.mobjFourthPanel.DockPadding.Top = 10;
            this.mobjFourthPanel.Location = new System.Drawing.Point(331, 249);
            this.mobjFourthPanel.Name = "mobjFourthPanel";
            this.mobjFourthPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjFourthPanel.Size = new System.Drawing.Size(321, 50);
            this.mobjFourthPanel.TabIndex = 0;
            // 
            // mobjThirdPanel
            // 
            this.mobjThirdPanel.Controls.Add(this.mobjCustomersTextBox);
            this.mobjThirdPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjThirdPanel.DockPadding.Bottom = 10;
            this.mobjThirdPanel.DockPadding.Top = 10;
            this.mobjThirdPanel.Location = new System.Drawing.Point(331, 189);
            this.mobjThirdPanel.Name = "mobjThirdPanel";
            this.mobjThirdPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjThirdPanel.Size = new System.Drawing.Size(321, 50);
            this.mobjThirdPanel.TabIndex = 0;
            // 
            // mobjSecondPanel
            // 
            this.mobjSecondPanel.Controls.Add(this.mobjPriceComboBox);
            this.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSecondPanel.DockPadding.Bottom = 10;
            this.mobjSecondPanel.DockPadding.Top = 10;
            this.mobjSecondPanel.Location = new System.Drawing.Point(331, 129);
            this.mobjSecondPanel.Name = "mobjSecondPanel";
            this.mobjSecondPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjSecondPanel.Size = new System.Drawing.Size(321, 50);
            this.mobjSecondPanel.TabIndex = 0;
            // 
            // mobjFirstPanel
            // 
            this.mobjFirstPanel.Controls.Add(this.mobjIDComboBox);
            this.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFirstPanel.DockPadding.Bottom = 10;
            this.mobjFirstPanel.DockPadding.Top = 10;
            this.mobjFirstPanel.Location = new System.Drawing.Point(331, 69);
            this.mobjFirstPanel.Name = "mobjFirstPanel";
            this.mobjFirstPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjFirstPanel.Size = new System.Drawing.Size(321, 50);
            this.mobjFirstPanel.TabIndex = 0;
            // 
            // RelatedComboBoxPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(663, 388);
            this.Text = "RelatedComboBoxPage";
            this.Load += new System.EventHandler(this.RelatedComboBoxPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjFirstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjSecondBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjThirdBindingSource)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjFifthPanel.ResumeLayout(false);
            this.mobjFourthPanel.ResumeLayout(false);
            this.mobjThirdPanel.ResumeLayout(false);
            this.mobjSecondPanel.ResumeLayout(false);
            this.mobjFirstPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjCustomerComboBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjIDComboBox;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private Gizmox.WebGUI.Forms.ComboBox mobjPriceComboBox;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private Gizmox.WebGUI.Forms.BindingSource mobjFirstBindingSource;
        private Gizmox.WebGUI.Forms.BindingSource mobjSecondBindingSource;
        private Gizmox.WebGUI.Forms.BindingSource mobjThirdBindingSource;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter order_DetailsTableAdapter;
        private Gizmox.WebGUI.Forms.Label mobjCustomersLabel;
        private Gizmox.WebGUI.Forms.Label mobjIdLabel;
        private Gizmox.WebGUI.Forms.Label mobjPriceLabel;
        private Gizmox.WebGUI.Forms.Label mobjDataPriceLabel;
        private Gizmox.WebGUI.Forms.Label mobjDataIdLabel;
        private Gizmox.WebGUI.Forms.Label mobjDataCustomersLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjCustomersTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjIDTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjPricesTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFifthPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFourthPanel;
        private Gizmox.WebGUI.Forms.Panel mobjThirdPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstPanel;



    }
}
