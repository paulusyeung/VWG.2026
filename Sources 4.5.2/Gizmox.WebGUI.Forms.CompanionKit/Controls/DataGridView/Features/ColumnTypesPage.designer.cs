namespace CompanionKit.Controls.DataGridView.Features
{
    partial class ColumnTypesPage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjUserIdColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjUserNameColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjEmailColumn = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.mobjPhoneColumn = new Gizmox.WebGUI.Forms.DataGridViewButtonColumn();
            this.mobjIsLoggedInColumn = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.mobjBirthYearColumn = new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
            this.mobjPhotoColumn = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjUserIdColumn,
            this.mobjUserNameColumn,
            this.mobjEmailColumn,
            this.mobjPhoneColumn,
            this.mobjIsLoggedInColumn,
            this.mobjBirthYearColumn,
            this.mobjPhotoColumn});
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.RowTemplate.Height = 40;
            this.mobjDataGridView.RowTemplate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridView.Size = new System.Drawing.Size(782, 249);
            this.mobjDataGridView.TabIndex = 0;
            // 
            // mobjUserIdColumn
            // 
            this.mobjUserIdColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.mobjUserIdColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserIdColumn.HeaderText = "User ID";
            this.mobjUserIdColumn.Name = "mobjUserIdColumn";
            this.mobjUserIdColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserIdColumn.Width = 50;
            // 
            // mobjUserNameColumn
            // 
            this.mobjUserNameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjUserNameColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjUserNameColumn.HeaderText = "User Name";
            this.mobjUserNameColumn.Name = "mobjUserNameColumn";
            this.mobjUserNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjUserNameColumn.Width = 60;
            // 
            // mobjEmailColumn
            // 
            this.mobjEmailColumn.ActiveLinkColor = System.Drawing.Color.Empty;
            this.mobjEmailColumn.ClientMode = false;
            this.mobjEmailColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjEmailColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjEmailColumn.HeaderText = "E-mail";
            this.mobjEmailColumn.LinkColor = System.Drawing.Color.Empty;
            this.mobjEmailColumn.Name = "mobjEmailColumn";
            this.mobjEmailColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjEmailColumn.TrackVisitedState = false;
            this.mobjEmailColumn.Url = "";
            this.mobjEmailColumn.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // mobjPhoneColumn
            // 
            this.mobjPhoneColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjPhoneColumn.HeaderText = "Phone";
            this.mobjPhoneColumn.Name = "mobjPhoneColumn";
            this.mobjPhoneColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjPhoneColumn.Width = 150;
            // 
            // mobjIsLoggedInColumn
            // 
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = false;
            this.mobjIsLoggedInColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjIsLoggedInColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjIsLoggedInColumn.HeaderText = "Is Logged In";
            this.mobjIsLoggedInColumn.Name = "mobjIsLoggedInColumn";
            this.mobjIsLoggedInColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjIsLoggedInColumn.Width = 70;
            // 
            // mobjBirthYearColumn
            // 
            this.mobjBirthYearColumn.AutoComplete = false;
            this.mobjBirthYearColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjBirthYearColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjBirthYearColumn.DisplayStyleForCurrentCellOnly = true;
            this.mobjBirthYearColumn.HeaderText = "Birth Year";
            this.mobjBirthYearColumn.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.mobjBirthYearColumn.Name = "mobjBirthYearColumn";
            this.mobjBirthYearColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjBirthYearColumn.Width = 70;
            // 
            // mobjPhotoColumn
            // 
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = null;
            this.mobjPhotoColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjPhotoColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjPhotoColumn.Description = null;
            this.mobjPhotoColumn.HeaderText = "Photo";
            this.mobjPhotoColumn.Name = "mobjPhotoColumn";
            this.mobjPhotoColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjPhotoColumn.Width = 50;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(782, 50);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "DataGridView with columns of deferent types";
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(782, 299);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // ColumnTypesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(782, 299);
            this.Text = "ColumnTypesPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn mobjUserIdColumn;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn mobjUserNameColumn;
        private Gizmox.WebGUI.Forms.DataGridViewLinkColumn mobjEmailColumn;
        private Gizmox.WebGUI.Forms.DataGridViewButtonColumn mobjPhoneColumn;
        private Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn mobjIsLoggedInColumn;
        private Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn mobjBirthYearColumn;
        private Gizmox.WebGUI.Forms.DataGridViewImageColumn mobjPhotoColumn;
        private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
    }
}
