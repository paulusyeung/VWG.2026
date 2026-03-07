namespace CompanionKit.Controls.DomainUpDown.Programming
{
    partial class RemoveItemsPage
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
            this.mobjDomainUpDownLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDomainUpDown = new Gizmox.WebGUI.Forms.DomainUpDown();
            this.mobjRemoveItemByPositionNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjRemoveItemComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjRemoveItemByNameRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRemoveItemByPositionRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRemoveItemButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjRemoveItemByPositionNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDomainUpDownLabel
            // 
            this.mobjDomainUpDownLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.mobjDomainUpDownLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDomainUpDownLabel.Name = "mobjDomainUpDownLabel";
            this.mobjDomainUpDownLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjDomainUpDownLabel.Size = new System.Drawing.Size(106, 75);
            this.mobjDomainUpDownLabel.TabIndex = 0;
            this.mobjDomainUpDownLabel.Text = "Domain Up Down";
            this.mobjDomainUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjDomainUpDown
            // 
            this.mobjDomainUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDomainUpDown.Location = new System.Drawing.Point(121, 27);
            this.mobjDomainUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0);
            this.mobjDomainUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDomainUpDown.Name = "mobjDomainUpDown";
            this.mobjDomainUpDown.Size = new System.Drawing.Size(184, 21);
            this.mobjDomainUpDown.TabIndex = 3;
            // 
            // mobjRemoveItemByPositionNumericUpDown
            // 
            this.mobjRemoveItemByPositionNumericUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjRemoveItemByPositionNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjRemoveItemByPositionNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjRemoveItemByPositionNumericUpDown.Enabled = false;
            this.mobjRemoveItemByPositionNumericUpDown.Location = new System.Drawing.Point(121, 177);
            this.mobjRemoveItemByPositionNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0);
            this.mobjRemoveItemByPositionNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjRemoveItemByPositionNumericUpDown.Name = "mobjRemoveItemByPositionNumericUpDown";
            this.mobjRemoveItemByPositionNumericUpDown.Size = new System.Drawing.Size(184, 21);
            this.mobjRemoveItemByPositionNumericUpDown.TabIndex = 6;
            // 
            // mobjRemoveItemComboBox
            // 
            this.mobjRemoveItemComboBox.AllowDrag = false;
            this.mobjRemoveItemComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjRemoveItemComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjRemoveItemComboBox.Location = new System.Drawing.Point(121, 102);
            this.mobjRemoveItemComboBox.Margin = new Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0);
            this.mobjRemoveItemComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjRemoveItemComboBox.Name = "mobjRemoveItemComboBox";
            this.mobjRemoveItemComboBox.Size = new System.Drawing.Size(184, 25);
            this.mobjRemoveItemComboBox.TabIndex = 7;
            // 
            // mobjRemoveItemByNameRadioButton
            // 
            this.mobjRemoveItemByNameRadioButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.mobjRemoveItemByNameRadioButton.Checked = true;
            this.mobjRemoveItemByNameRadioButton.Location = new System.Drawing.Point(0, 75);
            this.mobjRemoveItemByNameRadioButton.Name = "mobjRemoveItemByNameRadioButton";
            this.mobjRemoveItemByNameRadioButton.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjRemoveItemByNameRadioButton.Size = new System.Drawing.Size(106, 75);
            this.mobjRemoveItemByNameRadioButton.TabIndex = 8;
            this.mobjRemoveItemByNameRadioButton.Text = "Remove item by name";
            this.mobjRemoveItemByNameRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRemoveItemByNameRadioButton.UseVisualStyleBackColor = true;
            this.mobjRemoveItemByNameRadioButton.CheckedChanged += new System.EventHandler(this.mobjRemoveItemByNameRadioButton_CheckedChanged);
            // 
            // mobjRemoveItemByPositionRadioButton
            // 
            this.mobjRemoveItemByPositionRadioButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.mobjRemoveItemByPositionRadioButton.Location = new System.Drawing.Point(0, 150);
            this.mobjRemoveItemByPositionRadioButton.Name = "mobjRemoveItemByPositionRadioButton";
            this.mobjRemoveItemByPositionRadioButton.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjRemoveItemByPositionRadioButton.Size = new System.Drawing.Size(106, 75);
            this.mobjRemoveItemByPositionRadioButton.TabIndex = 9;
            this.mobjRemoveItemByPositionRadioButton.Text = "Remove item by position";
            this.mobjRemoveItemByPositionRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRemoveItemByPositionRadioButton.UseVisualStyleBackColor = true;
            this.mobjRemoveItemByPositionRadioButton.CheckedChanged += new System.EventHandler(this.mobjRemoveItemByPositionRadioButton_CheckedChanged);
            // 
            // mobjRemoveItemButton
            // 
            this.mobjRemoveItemButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRemoveItemButton.Location = new System.Drawing.Point(121, 240);
            this.mobjRemoveItemButton.Margin = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjRemoveItemButton.MaximumSize = new System.Drawing.Size(200, 60);
            this.mobjRemoveItemButton.Name = "mobjRemoveItemButton";
            this.mobjRemoveItemButton.Size = new System.Drawing.Size(184, 45);
            this.mobjRemoveItemButton.TabIndex = 10;
            this.mobjRemoveItemButton.Text = "Remove item";
            this.mobjRemoveItemButton.UseVisualStyleBackColor = true;
            this.mobjRemoveItemButton.Click += new System.EventHandler(this.mobjRemoveItemButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 66.66666F));
            this.mobjTLP.Controls.Add(this.mobjDomainUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjRemoveItemButton, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjDomainUpDown, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjRemoveItemByPositionNumericUpDown, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjRemoveItemByPositionRadioButton, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjRemoveItemByNameRadioButton, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjRemoveItemComboBox, 1, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 300);
            this.mobjTLP.TabIndex = 11;
            // 
            // RemoveItemsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 300);
            this.Text = "RemoveItemsPage";
            this.Load += new System.EventHandler(this.RemoveItemsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjRemoveItemByPositionNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDomainUpDownLabel;
        private Gizmox.WebGUI.Forms.DomainUpDown mobjDomainUpDown;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjRemoveItemByPositionNumericUpDown;
        private Gizmox.WebGUI.Forms.ComboBox mobjRemoveItemComboBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjRemoveItemByNameRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjRemoveItemByPositionRadioButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveItemButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}