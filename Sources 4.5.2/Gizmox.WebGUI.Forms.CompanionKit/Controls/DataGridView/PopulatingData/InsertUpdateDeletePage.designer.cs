using Gizmox.WebGUI.Forms;
using CompanionKit.Controls.DataGridView;


namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    partial class InsertUpdateDeletePage
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
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjUserIDColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserNameColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserEmailColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserPhoneColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserCityColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserAddressColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserCountryColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserStateColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserZipCodeColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.mobjAddRowMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjModifyRowMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjRemoveRowMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjUserDS = new CompanionKit.Controls.DataGridView.UserDS();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjUserDS)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            this.mobjDataGridView.AutoGenerateColumns = false;
            this.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjUserIDColumn,
            this.mobjUserNameColumn,
            this.mobjUserEmailColumn,
            this.mobjUserPhoneColumn,
            this.mobjUserCityColumn,
            this.mobjUserAddressColumn,
            this.mobjUserCountryColumn,
            this.mobjUserStateColumn,
            this.mobjUserZipCodeColumn});
            this.mobjDataGridView.ContextMenu = this.mobjContextMenu;
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mobjDataGridView.Size = new System.Drawing.Size(611, 218);
            this.mobjDataGridView.TabIndex = 1;
            this.mobjDataGridView.UseInternalPaging = false;
            this.mobjDataGridView.RowsAdded += new Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventHandler(this.mobjDataGridView_RowsAdded);
            // 
            // mobjUserIDColumn
            // 
            this.mobjUserIDColumn.DataPropertyName = "UserId";
            this.mobjUserIDColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mobjUserIDColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserIDColumn.HeaderText = "User ID";
            this.mobjUserIDColumn.Name = "mobjUserIDColumn";
            this.mobjUserIDColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserIDColumn.Width = 5;
            // 
            // mobjUserNameColumn
            // 
            this.mobjUserNameColumn.DataPropertyName = "UserName";
            this.mobjUserNameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjUserNameColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserNameColumn.HeaderText = "User Name";
            this.mobjUserNameColumn.Name = "mobjUserNameColumn";
            this.mobjUserNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserNameColumn.Width = 5;
            // 
            // mobjUserEmailColumn
            // 
            this.mobjUserEmailColumn.DataPropertyName = "UserEmail";
            this.mobjUserEmailColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjUserEmailColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserEmailColumn.HeaderText = "User Email";
            this.mobjUserEmailColumn.Name = "mobjUserEmailColumn";
            this.mobjUserEmailColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserEmailColumn.Width = 5;
            // 
            // mobjUserPhoneColumn
            // 
            this.mobjUserPhoneColumn.DataPropertyName = "UserPhone";
            this.mobjUserPhoneColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjUserPhoneColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserPhoneColumn.HeaderText = "User Phone";
            this.mobjUserPhoneColumn.Name = "mobjUserPhoneColumn";
            this.mobjUserPhoneColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserPhoneColumn.Width = 5;
            // 
            // mobjUserCityColumn
            // 
            this.mobjUserCityColumn.DataPropertyName = "UserCity";
            this.mobjUserCityColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjUserCityColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserCityColumn.HeaderText = "User City";
            this.mobjUserCityColumn.Name = "mobjUserCityColumn";
            this.mobjUserCityColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserCityColumn.Width = 5;
            // 
            // mobjUserAddressColumn
            // 
            this.mobjUserAddressColumn.DataPropertyName = "UserAddress";
            this.mobjUserAddressColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjUserAddressColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserAddressColumn.HeaderText = "User Address";
            this.mobjUserAddressColumn.Name = "mobjUserAddressColumn";
            this.mobjUserAddressColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserAddressColumn.Width = 5;
            // 
            // mobjUserCountryColumn
            // 
            this.mobjUserCountryColumn.DataPropertyName = "UserCountry";
            this.mobjUserCountryColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.mobjUserCountryColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserCountryColumn.HeaderText = "User Country";
            this.mobjUserCountryColumn.Name = "mobjUserCountryColumn";
            this.mobjUserCountryColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserCountryColumn.Width = 5;
            // 
            // mobjUserStateColumn
            // 
            this.mobjUserStateColumn.DataPropertyName = "UserState";
            this.mobjUserStateColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.mobjUserStateColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserStateColumn.HeaderText = "User State";
            this.mobjUserStateColumn.Name = "mobjUserStateColumn";
            this.mobjUserStateColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserStateColumn.Width = 5;
            // 
            // mobjUserZipCodeColumn
            // 
            this.mobjUserZipCodeColumn.DataPropertyName = "UserZipCode";
            this.mobjUserZipCodeColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.mobjUserZipCodeColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserZipCodeColumn.HeaderText = "User ZipCode";
            this.mobjUserZipCodeColumn.Name = "mobjUserZipCodeColumn";
            this.mobjUserZipCodeColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserZipCodeColumn.Width = 5;
            // 
            // mobjContextMenu
            // 
            this.mobjContextMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjAddRowMenuItem,
            this.mobjModifyRowMenuItem,
            this.mobjRemoveRowMenuItem});
            this.mobjContextMenu.Popup += new System.EventHandler(this.mobjContextMenu_Popup);
            // 
            // mobjAddRowMenuItem
            // 
            this.mobjAddRowMenuItem.Index = 0;
            this.mobjAddRowMenuItem.Text = "Add Row...";
            this.mobjAddRowMenuItem.Click += new System.EventHandler(this.mobjAddRowMenuItem_Click);
            // 
            // mobjModifyRowMenuItem
            // 
            this.mobjModifyRowMenuItem.Index = 1;
            this.mobjModifyRowMenuItem.Text = "Modify Row...";
            this.mobjModifyRowMenuItem.Click += new System.EventHandler(this.mobjModifyRowMenuItem_Click);
            // 
            // mobjRemoveRowMenuItem
            // 
            this.mobjRemoveRowMenuItem.Index = 2;
            this.mobjRemoveRowMenuItem.Text = "Remove Row...";
            this.mobjRemoveRowMenuItem.Click += new System.EventHandler(this.mobjRemoveRowMenuItem_Click);
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataMember = "Users";
            this.mobjBindingSource.DataSource = this.mobjUserDS;
            // 
            // mobjUserDS
            // 
            this.mobjUserDS.DataSetName = "UserDS";
            this.mobjUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(611, 50);
            this.mobjDescriptionLabel.TabIndex = 2;
            this.mobjDescriptionLabel.Text = "DataGridView allows inserting, updating and removing rows with context menu";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 2;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(611, 268);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // InsertUpdateDeletePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(611, 268);
            this.Text = "InsertUpdateDeletePage";
            this.Load += new System.EventHandler(this.InsertUpdateDeletePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjUserDS)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private DataGridViewTextBoxColumn mobjUserIDColumn;
        private DataGridViewTextBoxColumn mobjUserNameColumn;
        private DataGridViewTextBoxColumn mobjUserEmailColumn;
        private DataGridViewTextBoxColumn mobjUserPhoneColumn;
        private DataGridViewTextBoxColumn mobjUserCityColumn;
        private DataGridViewTextBoxColumn mobjUserAddressColumn;
        private DataGridViewTextBoxColumn mobjUserCountryColumn;
        private DataGridViewTextBoxColumn mobjUserStateColumn;
        private DataGridViewTextBoxColumn mobjUserZipCodeColumn;
        private BindingSource mobjBindingSource;
        private CompanionKit.Controls.DataGridView.UserDS mobjUserDS;
        private Gizmox.WebGUI.Forms.ContextMenu mobjContextMenu;
        private MenuItem mobjAddRowMenuItem;
        private MenuItem mobjModifyRowMenuItem;
        private MenuItem mobjRemoveRowMenuItem;
        private Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
