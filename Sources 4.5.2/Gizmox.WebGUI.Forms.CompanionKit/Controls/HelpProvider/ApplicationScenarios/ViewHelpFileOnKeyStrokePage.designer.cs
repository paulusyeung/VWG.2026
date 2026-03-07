namespace CompanionKit.Controls.HelpProvider.ApplicationScenarios
{
    partial class ViewHelpFileOnKeyStrokePage
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
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjHelpProvider = new Gizmox.WebGUI.Forms.HelpProvider();
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjTextBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDomainUpDown = new Gizmox.WebGUI.Forms.DomainUpDown();
            this.mobjDUDLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjNUDLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLinkLabel = new Gizmox.WebGUI.Forms.LinkLabel();
            this.mobjLinkLabelLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRadioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButtonLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjOptionPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjOptionPanel.SuspendLayout();
            this.mobjContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"});
            this.mobjComboBox.Location = new System.Drawing.Point(319, 88);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(309, 21);
            this.mobjComboBox.TabIndex = 1;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBox.Location = new System.Drawing.Point(322, 53);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(303, 30);
            this.mobjTextBox.TabIndex = 0;
            // 
            // mobjHelpProvider
            // 
            this.mobjHelpProvider.HelpNamespace = null;
            // 
            // mobjListBox
            // 
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"});
            this.mobjListBox.Location = new System.Drawing.Point(5, 5);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(299, 69);
            this.mobjListBox.TabIndex = 8;
            // 
            // mobjTextBoxLabel
            // 
            this.mobjTextBoxLabel.AutoSize = true;
            this.mobjTextBoxLabel.Location = new System.Drawing.Point(10, 50);
            this.mobjTextBoxLabel.Name = "mobjTextBoxLabel";
            this.mobjTextBoxLabel.Size = new System.Drawing.Size(47, 13);
            this.mobjTextBoxLabel.TabIndex = 9;
            this.mobjTextBoxLabel.Text = "TextBox";
            // 
            // mobjListBoxLabel
            // 
            this.mobjListBoxLabel.AutoSize = true;
            this.mobjListBoxLabel.Location = new System.Drawing.Point(10, 316);
            this.mobjListBoxLabel.Name = "mobjListBoxLabel";
            this.mobjListBoxLabel.Size = new System.Drawing.Size(41, 13);
            this.mobjListBoxLabel.TabIndex = 16;
            this.mobjListBoxLabel.Text = "ListBox";
            // 
            // mobjComboBoxLabel
            // 
            this.mobjComboBoxLabel.AutoSize = true;
            this.mobjComboBoxLabel.Location = new System.Drawing.Point(10, 88);
            this.mobjComboBoxLabel.Name = "mobjComboBoxLabel";
            this.mobjComboBoxLabel.Size = new System.Drawing.Size(58, 13);
            this.mobjComboBoxLabel.TabIndex = 10;
            this.mobjComboBoxLabel.Text = "ComboBox";
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(618, 50);
            this.mobjInfoLabel.TabIndex = 17;
            this.mobjInfoLabel.Text = "Set focus on a control and press F1 key to view the relevant help file";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjDomainUpDown
            // 
            this.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDomainUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDomainUpDown.Items.Add("Item 1");
            this.mobjDomainUpDown.Items.Add("Item 2");
            this.mobjDomainUpDown.Items.Add("Item 3");
            this.mobjDomainUpDown.Items.Add("Item 4");
            this.mobjDomainUpDown.Items.Add("Item 5");
            this.mobjDomainUpDown.Location = new System.Drawing.Point(319, 126);
            this.mobjDomainUpDown.Name = "mobjDomainUpDown";
            this.mobjDomainUpDown.Size = new System.Drawing.Size(309, 21);
            this.mobjDomainUpDown.TabIndex = 2;
            // 
            // mobjDUDLabel
            // 
            this.mobjDUDLabel.AutoSize = true;
            this.mobjDUDLabel.Location = new System.Drawing.Point(10, 126);
            this.mobjDUDLabel.Name = "mobjDUDLabel";
            this.mobjDUDLabel.Size = new System.Drawing.Size(82, 13);
            this.mobjDUDLabel.TabIndex = 11;
            this.mobjDUDLabel.Text = "DomainUpDown";
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjNumericUpDown.Location = new System.Drawing.Point(319, 164);
            this.mobjNumericUpDown.Name = "mobjNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(309, 21);
            this.mobjNumericUpDown.TabIndex = 3;
            // 
            // mobjNUDLabel
            // 
            this.mobjNUDLabel.AutoSize = true;
            this.mobjNUDLabel.Location = new System.Drawing.Point(10, 164);
            this.mobjNUDLabel.Name = "mobjNUDLabel";
            this.mobjNUDLabel.Size = new System.Drawing.Size(85, 13);
            this.mobjNUDLabel.TabIndex = 12;
            this.mobjNUDLabel.Text = "NumericUpDown";
            // 
            // mobjLinkLabel
            // 
            this.mobjLinkLabel.AutoSize = true;
            this.mobjLinkLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.mobjLinkLabel.Location = new System.Drawing.Point(319, 202);
            this.mobjLinkLabel.Name = "mobjLinkLabel";
            this.mobjLinkLabel.Size = new System.Drawing.Size(309, 13);
            this.mobjLinkLabel.TabIndex = 4;
            this.mobjLinkLabel.TabStop = true;
            this.mobjLinkLabel.Text = "LinkLabel";
            // 
            // mobjLinkLabelLabel
            // 
            this.mobjLinkLabelLabel.AutoSize = true;
            this.mobjLinkLabelLabel.Location = new System.Drawing.Point(10, 202);
            this.mobjLinkLabelLabel.Name = "mobjLinkLabelLabel";
            this.mobjLinkLabelLabel.Size = new System.Drawing.Size(50, 13);
            this.mobjLinkLabelLabel.TabIndex = 13;
            this.mobjLinkLabelLabel.Text = "LinkLabel";
            // 
            // mobjRadioButton1
            // 
            this.mobjRadioButton1.AutoSize = true;
            this.mobjRadioButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjRadioButton1.Location = new System.Drawing.Point(0, 0);
            this.mobjRadioButton1.Name = "mobjRadioButton1";
            this.mobjRadioButton1.Size = new System.Drawing.Size(55, 38);
            this.mobjRadioButton1.TabIndex = 5;
            this.mobjRadioButton1.Text = "Case1";
            this.mobjRadioButton1.UseVisualStyleBackColor = true;
            // 
            // mobjRadioButton2
            // 
            this.mobjRadioButton2.AutoSize = true;
            this.mobjRadioButton2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjRadioButton2.Location = new System.Drawing.Point(55, 0);
            this.mobjRadioButton2.Name = "mobjRadioButton2";
            this.mobjRadioButton2.Size = new System.Drawing.Size(55, 38);
            this.mobjRadioButton2.TabIndex = 6;
            this.mobjRadioButton2.Text = "Case2";
            this.mobjRadioButton2.UseVisualStyleBackColor = true;
            // 
            // mobjRadioButtonLabel
            // 
            this.mobjRadioButtonLabel.AutoSize = true;
            this.mobjRadioButtonLabel.Location = new System.Drawing.Point(10, 240);
            this.mobjRadioButtonLabel.Name = "mobjRadioButtonLabel";
            this.mobjRadioButtonLabel.Size = new System.Drawing.Size(66, 13);
            this.mobjRadioButtonLabel.TabIndex = 14;
            this.mobjRadioButtonLabel.Text = "RadioButton";
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCheckBox.Location = new System.Drawing.Point(319, 278);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(309, 17);
            this.mobjCheckBox.TabIndex = 7;
            this.mobjCheckBox.Text = "Value";
            this.mobjCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjCheckBoxLabel
            // 
            this.mobjCheckBoxLabel.AutoSize = true;
            this.mobjCheckBoxLabel.Location = new System.Drawing.Point(10, 278);
            this.mobjCheckBoxLabel.Name = "mobjCheckBoxLabel";
            this.mobjCheckBoxLabel.Size = new System.Drawing.Size(54, 13);
            this.mobjCheckBoxLabel.TabIndex = 15;
            this.mobjCheckBoxLabel.Text = "CheckBox";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBox, 2, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBoxLabel, 1, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBoxLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjRadioButtonLabel, 1, 6);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBoxLabel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 2, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDUDLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjLinkLabel, 2, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjLinkLabelLabel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDomainUpDown, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjNUDLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjNumericUpDown, 2, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjOptionPanel, 2, 6);
            this.mobjLayoutPanel.Controls.Add(this.mobjListBoxLabel, 1, 8);
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerPanel, 2, 8);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 9;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(638, 400);
            this.mobjLayoutPanel.TabIndex = 18;
            // 
            // mobjTopPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjTopPanel, 2);
            this.mobjTopPanel.Controls.Add(this.mobjInfoLabel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(10, 0);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(618, 50);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjOptionPanel
            // 
            this.mobjOptionPanel.Controls.Add(this.mobjRadioButton2);
            this.mobjOptionPanel.Controls.Add(this.mobjRadioButton1);
            this.mobjOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOptionPanel.Location = new System.Drawing.Point(319, 240);
            this.mobjOptionPanel.Name = "mobjOptionPanel";
            this.mobjOptionPanel.Size = new System.Drawing.Size(309, 38);
            this.mobjOptionPanel.TabIndex = 0;
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.Controls.Add(this.mobjListBox);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.DockPadding.All = 5;
            this.mobjContainerPanel.Location = new System.Drawing.Point(319, 316);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjContainerPanel.Size = new System.Drawing.Size(309, 84);
            this.mobjContainerPanel.TabIndex = 0;
            // 
            // ViewHelpFileOnKeyStrokePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(638, 400);
            this.Text = "ViewHelpFileOnKeyStrokePage";
            this.Load += new System.EventHandler(this.ViewHelpFileOnKeyStrokePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjOptionPanel.ResumeLayout(false);
            this.mobjContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.HelpProvider mobjHelpProvider;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjTextBoxLabel;
        private Gizmox.WebGUI.Forms.Label mobjListBoxLabel;
        private Gizmox.WebGUI.Forms.Label mobjComboBoxLabel;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.DomainUpDown mobjDomainUpDown;
        private Gizmox.WebGUI.Forms.Label mobjDUDLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjNUDLabel;
        private Gizmox.WebGUI.Forms.LinkLabel mobjLinkLabel;
        private Gizmox.WebGUI.Forms.Label mobjLinkLabelLabel;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton2;
        private Gizmox.WebGUI.Forms.Label mobjRadioButtonLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjCheckBoxLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjOptionPanel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;



    }
}