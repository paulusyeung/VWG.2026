namespace CompanionKit.Controls.DockingManager.Functionality
{
    partial class AddingWindowsPage
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
            this.mobjDockingManager = new Gizmox.WebGUI.Forms.DockingManager();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjWindowsTypeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjShowButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCloseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjPositionComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjPositionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjCustomersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDockingManager
            // 
            this.mobjDockingManager.AllowTabbedDocuments = false;
            this.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDockingManager.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjCommonLayoutPanel.SetColumnSpan(this.mobjDockingManager, 3);
            this.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDockingManager.Location = new System.Drawing.Point(0, 0);
            this.mobjDockingManager.Name = "objDockingManager";
            this.mobjDockingManager.PinAnimationSpeed = 500;
            this.mobjDockingManager.Size = new System.Drawing.Size(472, 239);
            this.mobjDockingManager.TabIndex = 0;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "AutoHidden",
            "Docked",
            "Float",
            "Tabbed"});
            this.mobjComboBox.Location = new System.Drawing.Point(0, 284);
            this.mobjComboBox.Name = "objComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(226, 21);
            this.mobjComboBox.TabIndex = 1;
            this.mobjComboBox.Text = "Float";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjWindowsTypeLabel
            // 
            this.mobjWindowsTypeLabel.AutoSize = true;
            this.mobjWindowsTypeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWindowsTypeLabel.Location = new System.Drawing.Point(0, 249);
            this.mobjWindowsTypeLabel.Name = "objWindowsTypeLabel";
            this.mobjWindowsTypeLabel.Size = new System.Drawing.Size(226, 25);
            this.mobjWindowsTypeLabel.TabIndex = 2;
            this.mobjWindowsTypeLabel.Text = "Windows Type";
            // 
            // mobjAddButton
            // 
            this.mobjCommonLayoutPanel.SetColumnSpan(this.mobjAddButton, 3);
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(0, 324);
            this.mobjAddButton.Name = "objAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(472, 50);
            this.mobjAddButton.TabIndex = 3;
            this.mobjAddButton.Text = "Add";
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjShowButton
            // 
            this.mobjShowButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowButton.Location = new System.Drawing.Point(0, 384);
            this.mobjShowButton.Name = "objShowButton";
            this.mobjShowButton.Size = new System.Drawing.Size(226, 50);
            this.mobjShowButton.TabIndex = 4;
            this.mobjShowButton.Text = "Show All";
            this.mobjShowButton.Click += new System.EventHandler(this.mobjShowButton_Click);
            // 
            // mobjCloseButton
            // 
            this.mobjCloseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCloseButton.Location = new System.Drawing.Point(246, 384);
            this.mobjCloseButton.Name = "objCloseButton";
            this.mobjCloseButton.Size = new System.Drawing.Size(226, 50);
            this.mobjCloseButton.TabIndex = 5;
            this.mobjCloseButton.Text = "Close All";
            this.mobjCloseButton.Click += new System.EventHandler(this.mobjCloseButton_Click);
            // 
            // mobjPositionComboBox
            // 
            this.mobjPositionComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPositionComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjPositionComboBox.FormattingEnabled = true;
            this.mobjPositionComboBox.Items.AddRange(new object[] {
            "Top",
            "Bottom",
            "Left",
            "Right"});
            this.mobjPositionComboBox.Location = new System.Drawing.Point(246, 284);
            this.mobjPositionComboBox.Name = "objPositionComboBox";
            this.mobjPositionComboBox.Size = new System.Drawing.Size(226, 21);
            this.mobjPositionComboBox.TabIndex = 6;
            this.mobjPositionComboBox.Text = "Top";
            this.mobjPositionComboBox.Visible = false;
            // 
            // mobjPositionLabel
            // 
            this.mobjPositionLabel.AutoSize = true;
            this.mobjPositionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPositionLabel.Location = new System.Drawing.Point(246, 249);
            this.mobjPositionLabel.Name = "objPoitionLabel";
            this.mobjPositionLabel.Size = new System.Drawing.Size(226, 25);
            this.mobjPositionLabel.TabIndex = 7;
            this.mobjPositionLabel.Text = "Position";
            this.mobjPositionLabel.Visible = false;
            // 
            // mobjNorthwindDataSet
            // 
            this.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet";
            this.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjCustomersTableAdapter
            // 
            this.mobjCustomersTableAdapter.ClearBeforeFill = true;
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjShowButton, 0, 8);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjAddButton, 0, 6);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjComboBox, 0, 4);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjCloseButton, 2, 8);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjPositionComboBox, 2, 4);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjPositionLabel, 2, 2);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjWindowsTypeLabel, 0, 2);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjDockingManager, 0, 0);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 10;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 25F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(472, 444);
            this.mobjCommonLayoutPanel.TabIndex = 9;
            // 
            // AddingWindowsPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.DockPadding.All = 15;
            this.Location = new System.Drawing.Point(0, -120);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(502, 474);
            this.Text = "AddingWindowsPage";
            this.Load += new System.EventHandler(this.AddingWindowsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DockingManager mobjDockingManager;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjWindowsTypeLabel;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Button mobjShowButton;
        private Gizmox.WebGUI.Forms.Button mobjCloseButton;
        private Gizmox.WebGUI.Forms.ComboBox mobjPositionComboBox;
        private Gizmox.WebGUI.Forms.Label mobjPositionLabel;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private global::Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter mobjCustomersTableAdapter;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
    }
}