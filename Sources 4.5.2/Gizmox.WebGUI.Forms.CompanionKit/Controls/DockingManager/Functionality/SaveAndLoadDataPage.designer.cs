namespace CompanionKit.Controls.DockingManager.Functionality
{
    partial class SaveAndLoadDataPage
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
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSaveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLoadButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjCustomersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjBottomLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLoadPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAddPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSavePanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjDockingPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            this.mobjBottomLayoutPanel.SuspendLayout();
            this.mobjLoadPanel.SuspendLayout();
            this.mobjAddPanel.SuspendLayout();
            this.mobjSavePanel.SuspendLayout();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjDockingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDockingManager
            // 
            this.mobjDockingManager.AllowTabbedDocuments = false;
            this.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDockingManager.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDockingManager.Location = new System.Drawing.Point(15, 15);
            this.mobjDockingManager.Name = "mobjDockingManager";
            this.mobjDockingManager.PinAnimationSpeed = 500;
            this.mobjDockingManager.Size = new System.Drawing.Size(494, 229);
            this.mobjDockingManager.TabIndex = 0;
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(15, 15);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(179, 71);
            this.mobjAddButton.TabIndex = 1;
            this.mobjAddButton.Text = "Add Window";
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjSaveButton
            // 
            this.mobjSaveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSaveButton.Location = new System.Drawing.Point(15, 15);
            this.mobjSaveButton.Name = "mobjSaveButton";
            this.mobjSaveButton.Size = new System.Drawing.Size(127, 71);
            this.mobjSaveButton.TabIndex = 2;
            this.mobjSaveButton.Text = "Save";
            this.mobjSaveButton.Click += new System.EventHandler(this.mobjSaveButton_Click);
            // 
            // mobjLoadButton
            // 
            this.mobjLoadButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLoadButton.Location = new System.Drawing.Point(15, 15);
            this.mobjLoadButton.Name = "mobjLoadButton";
            this.mobjLoadButton.Size = new System.Drawing.Size(128, 71);
            this.mobjLoadButton.TabIndex = 3;
            this.mobjLoadButton.Text = "Load";
            this.mobjLoadButton.Click += new System.EventHandler(this.mobjLoadButton_Click);
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
            // mobInfoLabel
            // 
            this.mobInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobInfoLabel.Location = new System.Drawing.Point(10, 10);
            this.mobInfoLabel.Name = "mobInfoLabel";
            this.mobInfoLabel.Size = new System.Drawing.Size(524, 50);
            this.mobInfoLabel.TabIndex = 4;
            this.mobInfoLabel.Text = "Note: SaveData saves only DockingWindow\'s layout";
            this.mobInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjBottomLayoutPanel
            // 
            this.mobjBottomLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjBottomLayoutPanel.ColumnCount = 3;
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjLoadPanel, 2, 0);
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjAddPanel, 1, 0);
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjSavePanel, 0, 0);
            this.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomLayoutPanel.Location = new System.Drawing.Point(10, 319);
            this.mobjBottomLayoutPanel.Name = "mobjBottomLayoutPanel";
            this.mobjBottomLayoutPanel.RowCount = 1;
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjBottomLayoutPanel.Size = new System.Drawing.Size(524, 101);
            this.mobjBottomLayoutPanel.TabIndex = 5;
            // 
            // mobjLoadPanel
            // 
            this.mobjLoadPanel.Controls.Add(this.mobjLoadButton);
            this.mobjLoadPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLoadPanel.DockPadding.All = 15;
            this.mobjLoadPanel.Location = new System.Drawing.Point(366, 0);
            this.mobjLoadPanel.Name = "mobjLoadPanel";
            this.mobjLoadPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjLoadPanel.Size = new System.Drawing.Size(158, 101);
            this.mobjLoadPanel.TabIndex = 7;
            // 
            // mobjAddPanel
            // 
            this.mobjAddPanel.Controls.Add(this.mobjAddButton);
            this.mobjAddPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddPanel.DockPadding.All = 15;
            this.mobjAddPanel.Location = new System.Drawing.Point(157, 0);
            this.mobjAddPanel.Name = "mobjAddPanel";
            this.mobjAddPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjAddPanel.Size = new System.Drawing.Size(209, 101);
            this.mobjAddPanel.TabIndex = 7;
            // 
            // mobjSavePanel
            // 
            this.mobjSavePanel.Controls.Add(this.mobjSaveButton);
            this.mobjSavePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSavePanel.DockPadding.All = 15;
            this.mobjSavePanel.Location = new System.Drawing.Point(0, 0);
            this.mobjSavePanel.Name = "mobjSavePanel";
            this.mobjSavePanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjSavePanel.Size = new System.Drawing.Size(157, 101);
            this.mobjSavePanel.TabIndex = 7;
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjCommonLayoutPanel.ColumnCount = 1;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjDockingPanel, 0, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobInfoLabel, 0, 0);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjBottomLayoutPanel, 0, 2);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(20, 20);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjCommonLayoutPanel.RowCount = 3;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 72.22222F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.77778F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(544, 430);
            this.mobjCommonLayoutPanel.TabIndex = 6;
            // 
            // mobjDockingPanel
            // 
            this.mobjDockingPanel.Controls.Add(this.mobjDockingManager);
            this.mobjDockingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDockingPanel.DockPadding.All = 15;
            this.mobjDockingPanel.Location = new System.Drawing.Point(10, 60);
            this.mobjDockingPanel.Name = "mobjDockingPanel";
            this.mobjDockingPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjDockingPanel.Size = new System.Drawing.Size(524, 259);
            this.mobjDockingPanel.TabIndex = 7;
            // 
            // SaveAndLoadDataPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.DockPadding.All = 20;
            this.Location = new System.Drawing.Point(0, -15);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.Size = new System.Drawing.Size(584, 470);
            this.Text = "SaveAndLoadDataPage";
            this.Load += new System.EventHandler(this.SaveAndLoadDataPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            this.mobjBottomLayoutPanel.ResumeLayout(false);
            this.mobjLoadPanel.ResumeLayout(false);
            this.mobjAddPanel.ResumeLayout(false);
            this.mobjSavePanel.ResumeLayout(false);
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjDockingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DockingManager mobjDockingManager;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Button mobjSaveButton;
        private Gizmox.WebGUI.Forms.Button mobjLoadButton;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private global::Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter mobjCustomersTableAdapter;
        private Gizmox.WebGUI.Forms.Label mobInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjBottomLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSavePanel;
        private Gizmox.WebGUI.Forms.Panel mobjLoadPanel;
        private Gizmox.WebGUI.Forms.Panel mobjAddPanel;
        private Gizmox.WebGUI.Forms.Panel mobjDockingPanel;



    }
}