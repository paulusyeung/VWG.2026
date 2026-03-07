using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.DataGridView.Appearance
{
    partial class AlternatingStylePage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjDataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn10 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn11 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjPropertyGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.mobjCustomersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            this.mobjDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mobjDataGridView.AutoGenerateColumns = false;
            this.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjDataGridViewTextBoxColumn1,
            this.mobjDataGridViewTextBoxColumn2,
            this.mobjDataGridViewTextBoxColumn3,
            this.mobjDataGridViewTextBoxColumn4,
            this.mobjDataGridViewTextBoxColumn5,
            this.mobjDataGridViewTextBoxColumn6,
            this.mobjDataGridViewTextBoxColumn7,
            this.mobjDataGridViewTextBoxColumn8,
            this.mobjDataGridViewTextBoxColumn9,
            this.mobjDataGridViewTextBoxColumn10,
            this.mobjDataGridViewTextBoxColumn11});
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(513, 317);
            this.mobjDataGridView.TabIndex = 1;
            // 
            // mobjDataGridViewTextBoxColumn1
            // 
            this.mobjDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID";
            this.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn1.HeaderText = "CustomerID";
            this.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1";
            this.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn1.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn2
            // 
            this.mobjDataGridViewTextBoxColumn2.DataPropertyName = "CompanyName";
            this.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn2.HeaderText = "CompanyName";
            this.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2";
            this.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn2.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn3
            // 
            this.mobjDataGridViewTextBoxColumn3.DataPropertyName = "ContactName";
            this.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn3.HeaderText = "ContactName";
            this.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3";
            this.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn3.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn4
            // 
            this.mobjDataGridViewTextBoxColumn4.DataPropertyName = "ContactTitle";
            this.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn4.HeaderText = "ContactTitle";
            this.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4";
            this.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn4.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn5
            // 
            this.mobjDataGridViewTextBoxColumn5.DataPropertyName = "Address";
            this.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn5.HeaderText = "Address";
            this.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5";
            this.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn5.Visible = false;
            this.mobjDataGridViewTextBoxColumn5.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn6
            // 
            this.mobjDataGridViewTextBoxColumn6.DataPropertyName = "City";
            this.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn6.HeaderText = "City";
            this.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6";
            this.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn6.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn7
            // 
            this.mobjDataGridViewTextBoxColumn7.DataPropertyName = "Region";
            this.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            this.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn7.HeaderText = "Region";
            this.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7";
            this.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn7.Visible = false;
            this.mobjDataGridViewTextBoxColumn7.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn8
            // 
            this.mobjDataGridViewTextBoxColumn8.DataPropertyName = "PostalCode";
            this.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle9;
            this.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn8.HeaderText = "PostalCode";
            this.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8";
            this.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn8.Visible = false;
            this.mobjDataGridViewTextBoxColumn8.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn9
            // 
            this.mobjDataGridViewTextBoxColumn9.DataPropertyName = "Country";
            this.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle10;
            this.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn9.HeaderText = "Country";
            this.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9";
            this.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn9.Visible = false;
            this.mobjDataGridViewTextBoxColumn9.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn10
            // 
            this.mobjDataGridViewTextBoxColumn10.DataPropertyName = "Phone";
            this.mobjDataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle11;
            this.mobjDataGridViewTextBoxColumn10.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn10.HeaderText = "Phone";
            this.mobjDataGridViewTextBoxColumn10.Name = "mobjDataGridViewTextBoxColumn10";
            this.mobjDataGridViewTextBoxColumn10.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn10.Visible = false;
            this.mobjDataGridViewTextBoxColumn10.Width = 5;
            // 
            // mobjDataGridViewTextBoxColumn11
            // 
            this.mobjDataGridViewTextBoxColumn11.DataPropertyName = "Fax";
            this.mobjDataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle12;
            this.mobjDataGridViewTextBoxColumn11.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn11.HeaderText = "Fax";
            this.mobjDataGridViewTextBoxColumn11.Name = "mobjDataGridViewTextBoxColumn11";
            this.mobjDataGridViewTextBoxColumn11.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn11.Visible = false;
            this.mobjDataGridViewTextBoxColumn11.Width = 5;
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataMember = "Customers";
            this.mobjBindingSource.DataSource = this.mobjNorthwindDataSet;
            // 
            // mobjNorthwindDataSet
            // 
            this.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet";
            this.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjPropertyGrid
            // 
            this.mobjPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.mobjPropertyGrid.CommandsVisibleIfAvailable = false;
            this.mobjPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPropertyGrid.HelpBackColor = System.Drawing.Color.Transparent;
            this.mobjPropertyGrid.HelpForeColor = System.Drawing.Color.Black;
            this.mobjPropertyGrid.HelpVisible = false;
            this.mobjPropertyGrid.LineColor = System.Drawing.Color.Empty;
            this.mobjPropertyGrid.Location = new System.Drawing.Point(513, 50);
            this.mobjPropertyGrid.Name = "mobjPropertyGrid";
            this.mobjPropertyGrid.Size = new System.Drawing.Size(240, 317);
            this.mobjPropertyGrid.TabIndex = 2;
            this.mobjPropertyGrid.ViewBackColor = System.Drawing.Color.White;
            this.mobjPropertyGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // mobjCustomersTableAdapter
            // 
            this.mobjCustomersTableAdapter.ClearBeforeFill = true;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDescriptionLabel, 2);
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(753, 50);
            this.mobjDescriptionLabel.TabIndex = 3;
            this.mobjDescriptionLabel.Text = "DataGridView demonstrates how to change the alternating row style";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 2;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 240F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjPropertyGrid, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 2;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(753, 367);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // AlternatingStylePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(753, 367);
            this.Text = "AlternatingStylePage";
            this.Load += new System.EventHandler(this.AlternatingStylePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private Gizmox.WebGUI.Forms.PropertyGrid mobjPropertyGrid;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn11;
        private BindingSource mobjBindingSource;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter mobjCustomersTableAdapter;
        private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;


    }
}
