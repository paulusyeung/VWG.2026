namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    partial class FilteringPage
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
            this.mobjDGV = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjBS = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.northwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjFilterHeadersRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjFilterRowRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjMaxFilterLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaxFilterNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.customersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            this.mobjGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxFilterNUD)).BeginInit();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDGV
            // 
            this.mobjDGV.AccessibleDescription = "";
            this.mobjDGV.AccessibleName = "";
            this.mobjDGV.AllowDrag = false;
            this.mobjDGV.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mobjDGV.DataSource = this.mobjBS;
            this.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDGV.Location = new System.Drawing.Point(0, 120);
            this.mobjDGV.MaxFilterOptions = 10;
            this.mobjDGV.Name = "mobjDGV";
            this.mobjDGV.ShowFilterRow = true;
            this.mobjDGV.Size = new System.Drawing.Size(809, 228);
            this.mobjDGV.TabIndex = 0;
            this.mobjDGV.CustomHeaderFilterClicked += new Gizmox.WebGUI.Forms.CustomFilterApplyingEventHandler(this.mobjDGV_CustomHeaderFilterClicked);
            // 
            // mobjBS
            // 
            this.mobjBS.DataMember = "Customers";
            this.mobjBS.DataSource = this.northwindDataSet;
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName = "NorthwindDataSet";
            this.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.AccessibleDescription = "";
            this.mobjGroupBox.AccessibleName = "";
            this.mobjGroupBox.Controls.Add(this.mobjFilterHeadersRB);
            this.mobjGroupBox.Controls.Add(this.mobjFilterRowRB);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(201, 120);
            this.mobjGroupBox.TabIndex = 2;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Filtering";
            // 
            // mobjFilterHeadersRB
            // 
            this.mobjFilterHeadersRB.AccessibleDescription = "";
            this.mobjFilterHeadersRB.AccessibleName = "";
            this.mobjFilterHeadersRB.Location = new System.Drawing.Point(18, 64);
            this.mobjFilterHeadersRB.Name = "mobjFilterHeadersRB";
            this.mobjFilterHeadersRB.Size = new System.Drawing.Size(145, 23);
            this.mobjFilterHeadersRB.TabIndex = 1;
            this.mobjFilterHeadersRB.Text = "In Headers";
            this.mobjFilterHeadersRB.CheckedChanged += new System.EventHandler(this.mobjFilterHeadersRB_CheckedChanged);
            // 
            // mobjFilterRowRB
            // 
            this.mobjFilterRowRB.AccessibleDescription = "";
            this.mobjFilterRowRB.AccessibleName = "";
            this.mobjFilterRowRB.Checked = true;
            this.mobjFilterRowRB.Location = new System.Drawing.Point(18, 30);
            this.mobjFilterRowRB.Name = "mobjFilterRowRB";
            this.mobjFilterRowRB.Size = new System.Drawing.Size(145, 23);
            this.mobjFilterRowRB.TabIndex = 0;
            this.mobjFilterRowRB.Text = "Filter Row";
            // 
            // mobjMaxFilterLbl
            // 
            this.mobjMaxFilterLbl.AccessibleDescription = "";
            this.mobjMaxFilterLbl.AccessibleName = "";
            this.mobjMaxFilterLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaxFilterLbl.Location = new System.Drawing.Point(201, 0);
            this.mobjMaxFilterLbl.Name = "mobjMaxFilterLbl";
            this.mobjMaxFilterLbl.Padding = new Gizmox.WebGUI.Forms.Padding(25, 0, 0, 0);
            this.mobjMaxFilterLbl.Size = new System.Drawing.Size(608, 64);
            this.mobjMaxFilterLbl.TabIndex = 3;
            this.mobjMaxFilterLbl.Text = "Max Filter Options";
            this.mobjMaxFilterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjMaxFilterNUD
            // 
            this.mobjMaxFilterNUD.AccessibleDescription = "";
            this.mobjMaxFilterNUD.AccessibleName = "";
            this.mobjMaxFilterNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMaxFilterNUD.CurrentValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mobjMaxFilterNUD.Location = new System.Drawing.Point(204, 67);
            this.mobjMaxFilterNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjMaxFilterNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjMaxFilterNUD.Name = "mobjMaxFilterNUD";
            this.mobjMaxFilterNUD.Size = new System.Drawing.Size(132, 21);
            this.mobjMaxFilterNUD.TabIndex = 4;
            this.mobjMaxFilterNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mobjMaxFilterNUD.ValueChanged += new System.EventHandler(this.mobjMaxFilterNUD_ValueChanged);
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 348);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Padding = new Gizmox.WebGUI.Forms.Padding(20, 20, 0, 0);
            this.mobjInfoLabel.Size = new System.Drawing.Size(809, 95);
            this.mobjInfoLabel.TabIndex = 5;
            this.mobjInfoLabel.Text = "Use FilterRow to filter values by column in DataGridView.";
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.Controls.Add(this.mobjMaxFilterLbl);
            this.mobjPanel.Controls.Add(this.mobjGroupBox);
            this.mobjPanel.Controls.Add(this.mobjMaxFilterNUD);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(809, 120);
            this.mobjPanel.TabIndex = 6;
            // 
            // FilteringPage
            // 
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjDGV);
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(809, 480);
            this.Text = "FilteringPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            this.mobjGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxFilterNUD)).EndInit();
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView mobjDGV;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjFilterHeadersRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjFilterRowRB;
        private Gizmox.WebGUI.Forms.Label mobjMaxFilterLbl;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMaxFilterNUD;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;

        private Gizmox.WebGUI.Forms.BindingSource mobjBS;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet northwindDataSet;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;

        private Gizmox.WebGUI.Forms.Panel mobjPanel;

    }
}