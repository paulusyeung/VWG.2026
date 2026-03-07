namespace CompanionKit.Controls.DataGridView.Features
{
    partial class VirtualModePage
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
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjDGVBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjDGVUserDS = new CompanionKit.Controls.DataGridView.UserDS();
            this.mobjVirtualDataGridView = new Gizmox.WebGUI.Forms.VirtualDataGridView();
            this.mobjVDGVBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjVDGVUserDS = new CompanionKit.Controls.DataGridView.UserDS();
            this.mobjFillDGVButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDVGLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFillVDGVButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjVDGVLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGVUserDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVirtualDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVDGVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVDGVUserDS)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            this.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mobjDataGridView.DataSource = this.mobjDGVBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 90);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(686, 116);
            this.mobjDataGridView.TabIndex = 0;
            this.mobjDataGridView.UseInternalPaging = false;
            this.mobjDataGridView.VirtualMode = true;
            // 
            // mobjDGVBindingSource
            // 
            this.mobjDGVBindingSource.DataMember = "Users";
            this.mobjDGVBindingSource.DataSource = this.mobjDGVUserDS;
            // 
            // mobjDGVUserDS
            // 
            this.mobjDGVUserDS.DataSetName = "UserDS";
            this.mobjDGVUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjVirtualDataGridView
            // 
            this.mobjVirtualDataGridView.AllowDrag = false;
            this.mobjVirtualDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mobjVirtualDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mobjVirtualDataGridView.CustomStyle = "V";
            this.mobjVirtualDataGridView.DataSource = this.mobjVDGVBindingSource;
            this.mobjVirtualDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjVirtualDataGridView.Location = new System.Drawing.Point(0, 281);
            this.mobjVirtualDataGridView.Name = "mobjVirtualDataGridView";
            this.mobjVirtualDataGridView.Size = new System.Drawing.Size(686, 116);
            this.mobjVirtualDataGridView.TabIndex = 1;
            // 
            // mobjVDGVBindingSource
            // 
            this.mobjVDGVBindingSource.DataMember = "Users";
            this.mobjVDGVBindingSource.DataSource = this.mobjVDGVUserDS;
            // 
            // mobjVDGVUserDS
            // 
            this.mobjVDGVUserDS.DataSetName = "UserDS";
            this.mobjVDGVUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjFillDGVButton
            // 
            this.mobjFillDGVButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFillDGVButton.Location = new System.Drawing.Point(701, 90);
            this.mobjFillDGVButton.Name = "mobjFillDGVButton";
            this.mobjFillDGVButton.Size = new System.Drawing.Size(75, 75);
            this.mobjFillDGVButton.TabIndex = 0;
            this.mobjFillDGVButton.Text = "Fill data";
            this.mobjFillDGVButton.Click += new System.EventHandler(this.mobjFillDGVButton_Click);
            // 
            // mobjDVGLabel
            // 
            this.mobjDVGLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDVGLabel, 4);
            this.mobjDVGLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDVGLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDVGLabel.Name = "mobjDVGLabel";
            this.mobjDVGLabel.Size = new System.Drawing.Size(791, 90);
            this.mobjDVGLabel.TabIndex = 2;
            this.mobjDVGLabel.Text = "DataGridView: \r\nPress \"Fill data\" button to fill DGV with 3000 items \r\n(Caution: " +
    "It may cause page fault )";
            this.mobjDVGLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjFillVDGVButton
            // 
            this.mobjFillVDGVButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFillVDGVButton.Location = new System.Drawing.Point(701, 281);
            this.mobjFillVDGVButton.Name = "mobjFillVDGVButton";
            this.mobjFillVDGVButton.Size = new System.Drawing.Size(75, 75);
            this.mobjFillVDGVButton.TabIndex = 0;
            this.mobjFillVDGVButton.Text = "Fill data";
            this.mobjFillVDGVButton.Click += new System.EventHandler(this.mobjFillVDGVButton_Click);
            // 
            // mobjVDGVLabel
            // 
            this.mobjVDGVLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjVDGVLabel, 4);
            this.mobjVDGVLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjVDGVLabel.Location = new System.Drawing.Point(0, 206);
            this.mobjVDGVLabel.Name = "mobjVDGVLabel";
            this.mobjVDGVLabel.Size = new System.Drawing.Size(791, 75);
            this.mobjVDGVLabel.TabIndex = 2;
            this.mobjVDGVLabel.Text = "VirtualDataGridView: \r\nPress \"Fill data\" button to fill VDGV with 3000 items";
            this.mobjVDGVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 75F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjVDGVLabel, 0, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDVGLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjFillDGVButton, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjFillVDGVButton, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjVirtualDataGridView, 0, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 90F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 75F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(791, 397);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // VirtualModePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.Bottom = 15;
            this.DockPadding.Left = 15;
            this.DockPadding.Top = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15, 15, 0, 15);
            this.Size = new System.Drawing.Size(806, 427);
            this.Text = "VirtualModePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGVUserDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVirtualDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVDGVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjVDGVUserDS)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.BindingSource mobjDGVBindingSource;
        private CompanionKit.Controls.DataGridView.UserDS mobjDGVUserDS;
        private Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private Gizmox.WebGUI.Forms.VirtualDataGridView mobjVirtualDataGridView;
        private Gizmox.WebGUI.Forms.Button mobjFillDGVButton;
        private Gizmox.WebGUI.Forms.Button mobjFillVDGVButton;
        private Gizmox.WebGUI.Forms.BindingSource mobjVDGVBindingSource;
        private CompanionKit.Controls.DataGridView.UserDS mobjVDGVUserDS;
        private Gizmox.WebGUI.Forms.Label mobjDVGLabel;
        private Gizmox.WebGUI.Forms.Label mobjVDGVLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}