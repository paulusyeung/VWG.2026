using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    partial class BindingDataCollectionPage
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
            this.mobjUserIDColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjFirstNameColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjLastNameColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjFullNameColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjFavoriteColorColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserPhotoColumn = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjUserIDColumn
            // 
            this.mobjUserIDColumn.DataPropertyName = "ID";
            this.mobjUserIDColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mobjUserIDColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserIDColumn.HeaderText = "ID";
            this.mobjUserIDColumn.Name = "mobjUserIDColumn";
            this.mobjUserIDColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjFirstNameColumn
            // 
            this.mobjFirstNameColumn.DataPropertyName = "FirstName";
            this.mobjFirstNameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjFirstNameColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjFirstNameColumn.HeaderText = "First Name";
            this.mobjFirstNameColumn.Name = "mobjFirstNameColumn";
            this.mobjFirstNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjLastNameColumn
            // 
            this.mobjLastNameColumn.DataPropertyName = "LastName";
            this.mobjLastNameColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjLastNameColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjLastNameColumn.HeaderText = "Last Name";
            this.mobjLastNameColumn.Name = "mobjLastNameColumn";
            this.mobjLastNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjFullNameColumn
            // 
            this.mobjFullNameColumn.DataPropertyName = "FullName";
            this.mobjFullNameColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjFullNameColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjFullNameColumn.HeaderText = "Full Name";
            this.mobjFullNameColumn.Name = "mobjFullNameColumn";
            this.mobjFullNameColumn.ReadOnly = true;
            this.mobjFullNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjFavoriteColorColumn
            // 
            this.mobjFavoriteColorColumn.DataPropertyName = "FavoriteColor";
            this.mobjFavoriteColorColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjFavoriteColorColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjFavoriteColorColumn.HeaderText = "Favorite Color";
            this.mobjFavoriteColorColumn.Name = "mobjFavoriteColorColumn";
            this.mobjFavoriteColorColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjUserPhotoColumn
            // 
            this.mobjUserPhotoColumn.DataPropertyName = "Foto";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = null;
            this.mobjUserPhotoColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjUserPhotoColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserPhotoColumn.Description = null;
            this.mobjUserPhotoColumn.HeaderText = "Photo";
            this.mobjUserPhotoColumn.Name = "mobjUserPhotoColumn";
            this.mobjUserPhotoColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataSource = typeof(Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer);
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(655, 50);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "DataGridView with a collection DataSource";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            this.mobjDataGridView.AutoGenerateColumns = false;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjUserIDColumn,
            this.mobjFirstNameColumn,
            this.mobjLastNameColumn,
            this.mobjFullNameColumn,
            this.mobjFavoriteColorColumn,
            this.mobjUserPhotoColumn});
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "dataGridView1";
            this.mobjDataGridView.RowTemplate.Height = 40;
            this.mobjDataGridView.Size = new System.Drawing.Size(655, 243);
            this.mobjDataGridView.TabIndex = 0;
            this.mobjDataGridView.CellEndEdit += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.mobjDataGridView_CellEndEdit);
            this.mobjDataGridView.CellValidating += new Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventHandler(this.mobjDataGridView_CellValidating);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 0);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 2;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(655, 293);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // BindingDataCollectionPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(655, 293);
            this.Text = "BindingDataCollectionPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private DataGridViewTextBoxColumn mobjUserIDColumn;
        private DataGridViewTextBoxColumn mobjFirstNameColumn;
        private DataGridViewTextBoxColumn mobjLastNameColumn;
        private DataGridViewTextBoxColumn mobjFullNameColumn;
        private DataGridViewTextBoxColumn mobjFavoriteColorColumn;
        private DataGridViewImageColumn mobjUserPhotoColumn;
        private BindingSource mobjBindingSource;
        private Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
