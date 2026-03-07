using CompanionKit.Controls.DataGridView;
using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.DataGridView.Features
{
    partial class NewLinePage
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
            this.mobjUserIdDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserNameDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserEmailDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserPhoneDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserCityDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserAddressDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserCountryDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserStateDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserZipCodeDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
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
            this.mobjDataGridView.AllowUserToAddRows = false;
            this.mobjDataGridView.AutoGenerateColumns = false;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjUserIdDataGridViewTextBoxColumn,
            this.mobjUserNameDataGridViewTextBoxColumn,
            this.mobjUserEmailDataGridViewTextBoxColumn,
            this.mobjUserPhoneDataGridViewTextBoxColumn,
            this.mobjUserCityDataGridViewTextBoxColumn,
            this.mobjUserAddressDataGridViewTextBoxColumn,
            this.mobjUserCountryDataGridViewTextBoxColumn,
            this.mobjUserStateDataGridViewTextBoxColumn,
            this.mobjUserZipCodeDataGridViewTextBoxColumn});
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(594, 230);
            this.mobjDataGridView.TabIndex = 0;
            // 
            // mobjUserIdDataGridViewTextBoxColumn
            // 
            this.mobjUserIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.mobjUserIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mobjUserIdDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.mobjUserIdDataGridViewTextBoxColumn.Name = "mobjUserIdDataGridViewTextBoxColumn";
            this.mobjUserIdDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserNameDataGridViewTextBoxColumn
            // 
            this.mobjUserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.mobjUserNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjUserNameDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.mobjUserNameDataGridViewTextBoxColumn.Name = "mobjUserNameDataGridViewTextBoxColumn";
            this.mobjUserNameDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserEmailDataGridViewTextBoxColumn
            // 
            this.mobjUserEmailDataGridViewTextBoxColumn.DataPropertyName = "UserEmail";
            this.mobjUserEmailDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjUserEmailDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserEmailDataGridViewTextBoxColumn.HeaderText = "UserEmail";
            this.mobjUserEmailDataGridViewTextBoxColumn.Name = "mobjUserEmailDataGridViewTextBoxColumn";
            this.mobjUserEmailDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserPhoneDataGridViewTextBoxColumn
            // 
            this.mobjUserPhoneDataGridViewTextBoxColumn.DataPropertyName = "UserPhone";
            this.mobjUserPhoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjUserPhoneDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserPhoneDataGridViewTextBoxColumn.HeaderText = "UserPhone";
            this.mobjUserPhoneDataGridViewTextBoxColumn.Name = "mobjUserPhoneDataGridViewTextBoxColumn";
            this.mobjUserPhoneDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserCityDataGridViewTextBoxColumn
            // 
            this.mobjUserCityDataGridViewTextBoxColumn.DataPropertyName = "UserCity";
            this.mobjUserCityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjUserCityDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserCityDataGridViewTextBoxColumn.HeaderText = "UserCity";
            this.mobjUserCityDataGridViewTextBoxColumn.Name = "mobjUserCityDataGridViewTextBoxColumn";
            this.mobjUserCityDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserAddressDataGridViewTextBoxColumn
            // 
            this.mobjUserAddressDataGridViewTextBoxColumn.DataPropertyName = "UserAddress";
            this.mobjUserAddressDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjUserAddressDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserAddressDataGridViewTextBoxColumn.HeaderText = "UserAddress";
            this.mobjUserAddressDataGridViewTextBoxColumn.Name = "mobjUserAddressDataGridViewTextBoxColumn";
            this.mobjUserAddressDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserAddressDataGridViewTextBoxColumn.Width = 130;
            // 
            // mobjUserCountryDataGridViewTextBoxColumn
            // 
            this.mobjUserCountryDataGridViewTextBoxColumn.DataPropertyName = "UserCountry";
            this.mobjUserCountryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.mobjUserCountryDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserCountryDataGridViewTextBoxColumn.HeaderText = "UserCountry";
            this.mobjUserCountryDataGridViewTextBoxColumn.Name = "mobjUserCountryDataGridViewTextBoxColumn";
            this.mobjUserCountryDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserStateDataGridViewTextBoxColumn
            // 
            this.mobjUserStateDataGridViewTextBoxColumn.DataPropertyName = "UserState";
            this.mobjUserStateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.mobjUserStateDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserStateDataGridViewTextBoxColumn.HeaderText = "UserState";
            this.mobjUserStateDataGridViewTextBoxColumn.Name = "mobjUserStateDataGridViewTextBoxColumn";
            this.mobjUserStateDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserZipCodeDataGridViewTextBoxColumn
            // 
            this.mobjUserZipCodeDataGridViewTextBoxColumn.DataPropertyName = "UserZipCode";
            this.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserZipCodeDataGridViewTextBoxColumn.HeaderText = "UserZipCode";
            this.mobjUserZipCodeDataGridViewTextBoxColumn.Name = "mobjUserZipCodeDataGridViewTextBoxColumn";
            this.mobjUserZipCodeDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
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
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(594, 50);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "DataGridView demonstrates how to add rows";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 2;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(594, 280);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // NewLinePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(594, 280);
            this.Text = "NewLinePage";
            this.Load += new System.EventHandler(this.NewLinePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjUserDS)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private DataGridViewTextBoxColumn mobjUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserEmailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserPhoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserCityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserAddressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserCountryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserStateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mobjUserZipCodeDataGridViewTextBoxColumn;
        private BindingSource mobjBindingSource;
        private CompanionKit.Controls.DataGridView.UserDS mobjUserDS;
        private Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
    }
}
