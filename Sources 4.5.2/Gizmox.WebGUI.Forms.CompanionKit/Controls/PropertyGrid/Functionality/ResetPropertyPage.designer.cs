namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    partial class ResetPropertyPage
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
            this.mobjPropertyGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButtonTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanelTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTableLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.mobjTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPropertyGrid
            // 
            this.mobjPropertyGrid.AccessibleDescription = "";
            this.mobjPropertyGrid.AccessibleName = "";
            this.mobjPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.mobjPropertyGrid.CommandsVisibleIfAvailable = false;
            this.mobjPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPropertyGrid.HelpForeColor = System.Drawing.Color.Black;
            this.mobjPropertyGrid.LineColor = System.Drawing.Color.Empty;
            this.mobjPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.mobjPropertyGrid.MaximumSize = new System.Drawing.Size(600, 400);
            this.mobjPropertyGrid.Name = "objPropertyGrid";
            this.mobjPropertyGrid.Size = new System.Drawing.Size(321, 227);
            this.mobjPropertyGrid.TabIndex = 0;
            this.mobjPropertyGrid.ViewBackColor = System.Drawing.Color.White;
            this.mobjPropertyGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AccessibleDescription = "";
            this.mobjComboBox.AccessibleName = "";
            this.mobjComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Button",
            "Panel"});
            this.mobjComboBox.Location = new System.Drawing.Point(36, 38);
            this.mobjComboBox.Name = "objComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(143, 21);
            this.mobjComboBox.TabIndex = 1;
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(33, 16);
            this.mobjLabel.Name = "objLabel";
            this.mobjLabel.Size = new System.Drawing.Size(83, 13);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Choose control:";
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.Location = new System.Drawing.Point(39, 93);
            this.mobjButton.Name = "objButton";
            this.mobjButton.Size = new System.Drawing.Size(100, 100);
            this.mobjButton.TabIndex = 3;
            this.mobjButton.Text = "Button";
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed;
            this.mobjPanel.Location = new System.Drawing.Point(179, 93);
            this.mobjPanel.Name = "objPanel";
            this.mobjPanel.Size = new System.Drawing.Size(100, 100);
            this.mobjPanel.TabIndex = 4;
            // 
            // mobjButtonTextLabel
            // 
            this.mobjButtonTextLabel.AccessibleDescription = "";
            this.mobjButtonTextLabel.AccessibleName = "";
            this.mobjButtonTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonTextLabel.AutoSize = true;
            this.mobjButtonTextLabel.Location = new System.Drawing.Point(51, 71);
            this.mobjButtonTextLabel.Name = "objButtonTextLabel";
            this.mobjButtonTextLabel.Size = new System.Drawing.Size(43, 13);
            this.mobjButtonTextLabel.TabIndex = 6;
            this.mobjButtonTextLabel.Text = "Button:";
            // 
            // mobjPanelTextLabel
            // 
            this.mobjPanelTextLabel.AccessibleDescription = "";
            this.mobjPanelTextLabel.AccessibleName = "";
            this.mobjPanelTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjPanelTextLabel.AutoSize = true;
            this.mobjPanelTextLabel.Location = new System.Drawing.Point(191, 71);
            this.mobjPanelTextLabel.Name = "objPanelTextLabel";
            this.mobjPanelTextLabel.Size = new System.Drawing.Size(37, 13);
            this.mobjPanelTextLabel.TabIndex = 7;
            this.mobjPanelTextLabel.Text = "Panel:";
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.Controls.Add(this.mobjLabel);
            this.mobjTopPanel.Controls.Add(this.mobjComboBox);
            this.mobjTopPanel.Controls.Add(this.mobjPanelTextLabel);
            this.mobjTopPanel.Controls.Add(this.mobjButtonTextLabel);
            this.mobjTopPanel.Controls.Add(this.mobjPanel);
            this.mobjTopPanel.Controls.Add(this.mobjButton);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(107, 0);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(321, 227);
            this.mobjTopPanel.TabIndex = 9;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjPropertyGrid);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(107, 227);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(321, 227);
            this.mobjBottomPanel.TabIndex = 10;
            // 
            // mobjTableLayoutPanel
            // 
            this.mobjTableLayoutPanel.AccessibleDescription = "";
            this.mobjTableLayoutPanel.AccessibleName = "";
            this.mobjTableLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTableLayoutPanel.ColumnCount = 3;
            this.mobjTableLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTableLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTableLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTableLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 1);
            this.mobjTableLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 0);
            this.mobjTableLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTableLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjTableLayoutPanel.Name = "mobjTableLayoutPanel";
            this.mobjTableLayoutPanel.RowCount = 3;
            this.mobjTableLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTableLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTableLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjTableLayoutPanel.Size = new System.Drawing.Size(535, 475);
            this.mobjTableLayoutPanel.TabIndex = 11;
            // 
            // ResetPropertyPage
            // 
            this.Controls.Add(this.mobjTableLayoutPanel);
            this.DockPadding.All = 15;
            this.Location = new System.Drawing.Point(0, -150);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(565, 505);
            this.Text = "ResetPropertyPage";
            this.Load += new System.EventHandler(this.ResetPropertyPage_Load);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.mobjTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid mobjPropertyGrid;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Label mobjButtonTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjPanelTextLabel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTableLayoutPanel;



    }
}