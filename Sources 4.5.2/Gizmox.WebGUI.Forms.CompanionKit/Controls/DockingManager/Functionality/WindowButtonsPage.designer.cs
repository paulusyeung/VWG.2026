namespace CompanionKit.Controls.DockingManager.Functionality
{
    partial class WindowButtonsPage
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
            this.mobjCloseCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjDropDownCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMaximizeCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMinimizeCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjPinCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjCustomersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjDockingPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
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
            this.mobjDockingManager.Location = new System.Drawing.Point(0, 0);
            this.mobjDockingManager.Name = "objDockingManager";
            this.mobjDockingManager.PinAnimationSpeed = 500;
            this.mobjDockingManager.Size = new System.Drawing.Size(413, 299);
            this.mobjDockingManager.TabIndex = 0;
            // 
            // mobjCloseCheckBox
            // 
            this.mobjCloseCheckBox.AutoSize = true;
            this.mobjCloseCheckBox.Checked = true;
            this.mobjCloseCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjCloseCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCloseCheckBox.Location = new System.Drawing.Point(0, 309);
            this.mobjCloseCheckBox.Name = "objCloseCheckBox";
            this.mobjCloseCheckBox.Size = new System.Drawing.Size(413, 30);
            this.mobjCloseCheckBox.TabIndex = 6;
            this.mobjCloseCheckBox.Text = "ShowCloseButton";
            this.mobjCloseCheckBox.CheckedChanged += new System.EventHandler(this.mobjCloseCheckBox_CheckedChanged);
            // 
            // mobjDropDownCheckBox
            // 
            this.mobjDropDownCheckBox.AutoSize = true;
            this.mobjDropDownCheckBox.Checked = true;
            this.mobjDropDownCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjDropDownCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDropDownCheckBox.Location = new System.Drawing.Point(0, 339);
            this.mobjDropDownCheckBox.Name = "objDropDownCheckBox";
            this.mobjDropDownCheckBox.Size = new System.Drawing.Size(413, 30);
            this.mobjDropDownCheckBox.TabIndex = 7;
            this.mobjDropDownCheckBox.Text = "ShowDropDownButton";
            this.mobjDropDownCheckBox.CheckedChanged += new System.EventHandler(this.mobjDropDownCheckBox_CheckedChanged);
            // 
            // mobjMaximizeCheckBox
            // 
            this.mobjMaximizeCheckBox.AutoSize = true;
            this.mobjMaximizeCheckBox.Checked = true;
            this.mobjMaximizeCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjMaximizeCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaximizeCheckBox.Location = new System.Drawing.Point(0, 369);
            this.mobjMaximizeCheckBox.Name = "objMaximizeCheckBox";
            this.mobjMaximizeCheckBox.Size = new System.Drawing.Size(413, 30);
            this.mobjMaximizeCheckBox.TabIndex = 8;
            this.mobjMaximizeCheckBox.Text = "ShowMaximizeButton";
            this.mobjMaximizeCheckBox.CheckedChanged += new System.EventHandler(this.mobjMaximizeCheckBox_CheckedChanged);
            // 
            // mobjMinimizeCheckBox
            // 
            this.mobjMinimizeCheckBox.AutoSize = true;
            this.mobjMinimizeCheckBox.Checked = true;
            this.mobjMinimizeCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjMinimizeCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMinimizeCheckBox.Location = new System.Drawing.Point(0, 399);
            this.mobjMinimizeCheckBox.Name = "objMinimizeCheckBox";
            this.mobjMinimizeCheckBox.Size = new System.Drawing.Size(413, 30);
            this.mobjMinimizeCheckBox.TabIndex = 9;
            this.mobjMinimizeCheckBox.Text = "ShowMinimizeButton";
            this.mobjMinimizeCheckBox.CheckedChanged += new System.EventHandler(this.mobjMinimizeCheckBox_CheckedChanged);
            // 
            // mobjPinCheckBox
            // 
            this.mobjPinCheckBox.AutoSize = true;
            this.mobjPinCheckBox.Checked = true;
            this.mobjPinCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjPinCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPinCheckBox.Location = new System.Drawing.Point(0, 429);
            this.mobjPinCheckBox.Name = "objPinCheckBox";
            this.mobjPinCheckBox.Size = new System.Drawing.Size(413, 30);
            this.mobjPinCheckBox.TabIndex = 10;
            this.mobjPinCheckBox.Text = "ShowPinButton";
            this.mobjPinCheckBox.CheckedChanged += new System.EventHandler(this.mobjPinCheckBox_CheckedChanged);
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
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPinCheckBox, 0, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjCloseCheckBox, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinimizeCheckBox, 0, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDropDownCheckBox, 0, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaximizeCheckBox, 0, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjDockingPanel, 0, 0);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(413, 459);
            this.mobjLayoutPanel.TabIndex = 12;
            // 
            // mobjDockingPanel
            // 
            this.mobjDockingPanel.Controls.Add(this.mobjDockingManager);
            this.mobjDockingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDockingPanel.DockPadding.Bottom = 10;
            this.mobjDockingPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjDockingPanel.Name = "mobjDockingPanel";
            this.mobjDockingPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 10);
            this.mobjDockingPanel.Size = new System.Drawing.Size(413, 309);
            this.mobjDockingPanel.TabIndex = 13;
            // 
            // WindowButtonsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.All = 15;
            this.Location = new System.Drawing.Point(0, -77);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(443, 489);
            this.Text = "WindowButtonsPage";
            this.Load += new System.EventHandler(this.WindowButtonsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjDockingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DockingManager mobjDockingManager;
        private Gizmox.WebGUI.Forms.CheckBox mobjCloseCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjDropDownCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjMaximizeCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjMinimizeCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjPinCheckBox;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private global::Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter mobjCustomersTableAdapter;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjDockingPanel;
    }
}