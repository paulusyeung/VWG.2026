namespace CompanionKit.Controls.DockingManager.Functionality
{
    partial class PinWindowsPage
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
            this.mobjPinButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjUnpinButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjNorthwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjCustomersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).BeginInit();
            this.mobjTopPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDockingManager
            // 
            this.mobjDockingManager.AllowTabbedDocuments = false;
            this.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDockingManager.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDockingManager.Location = new System.Drawing.Point(20, 20);
            this.mobjDockingManager.Name = "objDockingManager";
            this.mobjDockingManager.PinAnimationSpeed = 500;
            this.mobjDockingManager.Size = new System.Drawing.Size(261, 207);
            this.mobjDockingManager.TabIndex = 0;
            // 
            // mobjPinButton
            // 
            this.mobjPinButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPinButton.Location = new System.Drawing.Point(0, 267);
            this.mobjPinButton.Name = "objPinButton";
            this.mobjPinButton.Size = new System.Drawing.Size(140, 50);
            this.mobjPinButton.TabIndex = 2;
            this.mobjPinButton.Text = "Pin All";
            this.mobjPinButton.Click += new System.EventHandler(this.mobjPinButton_Click);
            // 
            // mobjUnpinButton
            // 
            this.mobjUnpinButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjUnpinButton.Location = new System.Drawing.Point(160, 267);
            this.mobjUnpinButton.Name = "objUnpinButton";
            this.mobjUnpinButton.Size = new System.Drawing.Size(141, 50);
            this.mobjUnpinButton.TabIndex = 3;
            this.mobjUnpinButton.Text = "Unpin All";
            this.mobjUnpinButton.Click += new System.EventHandler(this.mobjUnpinButton_Click);
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
            // mobjTopPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjTopPanel, 3);
            this.mobjTopPanel.Controls.Add(this.mobjDockingManager);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.DockPadding.All = 20;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mobjTopPanel.Size = new System.Drawing.Size(301, 247);
            this.mobjTopPanel.TabIndex = 6;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjUnpinButton, 2, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjPinButton, 0, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(30, 30);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(301, 317);
            this.mobjLayoutPanel.TabIndex = 7;
            // 
            // PinWindowsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.All = 30;
            this.Location = new System.Drawing.Point(0, -23);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.Size = new System.Drawing.Size(361, 377);
            this.Text = "PinWindowsPage";
            this.Load += new System.EventHandler(this.PinWindowsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNorthwindDataSet)).EndInit();
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DockingManager mobjDockingManager;
        private Gizmox.WebGUI.Forms.Button mobjPinButton;
        private Gizmox.WebGUI.Forms.Button mobjUnpinButton;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet mobjNorthwindDataSet;
        private global::Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter mobjCustomersTableAdapter;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;

    }
}