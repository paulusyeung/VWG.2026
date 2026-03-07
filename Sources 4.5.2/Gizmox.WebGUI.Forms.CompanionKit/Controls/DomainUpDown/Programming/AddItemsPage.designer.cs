namespace CompanionKit.Controls.DomainUpDown.Programming
{
    partial class AddItemsPage
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
            this.mobjDomainUpDown = new Gizmox.WebGUI.Forms.DomainUpDown();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDomainUpDownLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameAddedItemLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameAddedItemTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDomainUpDown
            // 
            this.mobjDomainUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDomainUpDown.Items.Add("Item1");
            this.mobjDomainUpDown.Items.Add("Item2");
            this.mobjDomainUpDown.Items.Add("Item3");
            this.mobjDomainUpDown.Items.Add("Item4");
            this.mobjDomainUpDown.Items.Add("Item5");
            this.mobjDomainUpDown.Items.Add("Item6");
            this.mobjDomainUpDown.Location = new System.Drawing.Point(111, 62);
            this.mobjDomainUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0);
            this.mobjDomainUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDomainUpDown.Name = "mobjDomainUpDown";
            this.mobjDomainUpDown.Size = new System.Drawing.Size(194, 21);
            this.mobjDomainUpDown.Sorted = true;
            this.mobjDomainUpDown.TabIndex = 0;
            this.mobjDomainUpDown.Text = "demoDomainUpDown";
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(111, 305);
            this.mobjAddButton.Margin = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjAddButton.MaximumSize = new System.Drawing.Size(200, 60);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(194, 60);
            this.mobjAddButton.TabIndex = 1;
            this.mobjAddButton.Text = "Add item to DomainUpDown";
            this.mobjAddButton.UseVisualStyleBackColor = true;
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjDomainUpDownLabel
            // 
            this.mobjDomainUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDomainUpDownLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDomainUpDownLabel.Name = "mobjDomainUpDownLabel";
            this.mobjDomainUpDownLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjDomainUpDownLabel.Size = new System.Drawing.Size(96, 145);
            this.mobjDomainUpDownLabel.TabIndex = 2;
            this.mobjDomainUpDownLabel.Text = "Domain Up Down";
            this.mobjDomainUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjNameAddedItemLabel
            // 
            this.mobjNameAddedItemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNameAddedItemLabel.Location = new System.Drawing.Point(0, 145);
            this.mobjNameAddedItemLabel.Name = "mobjNameAddedItemLabel";
            this.mobjNameAddedItemLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjNameAddedItemLabel.Size = new System.Drawing.Size(96, 145);
            this.mobjNameAddedItemLabel.TabIndex = 3;
            this.mobjNameAddedItemLabel.Text = "New item text";
            this.mobjNameAddedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjNameAddedItemTextBox
            // 
            this.mobjNameAddedItemTextBox.AllowDrag = false;
            this.mobjNameAddedItemTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjNameAddedItemTextBox.Location = new System.Drawing.Point(111, 205);
            this.mobjNameAddedItemTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(15, 3, 15, 3);
            this.mobjNameAddedItemTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjNameAddedItemTextBox.Name = "mobjNameAddedItemTextBox";
            this.mobjNameAddedItemTextBox.Size = new System.Drawing.Size(194, 25);
            this.mobjNameAddedItemTextBox.TabIndex = 4;
            this.mobjNameAddedItemTextBox.Text = "Added item";
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjTLP.Controls.Add(this.mobjDomainUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjAddButton, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjNameAddedItemTextBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjDomainUpDown, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjNameAddedItemLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 36.36364F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 36.36364F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.27273F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 5;
            // 
            // AddItemsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "AddItemsPage";
            this.Load += new System.EventHandler(this.AddItemsPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DomainUpDown mobjDomainUpDown;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Label mobjDomainUpDownLabel;
        private Gizmox.WebGUI.Forms.Label mobjNameAddedItemLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjNameAddedItemTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}