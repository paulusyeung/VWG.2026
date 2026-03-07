namespace CompanionKit.Controls.ListBox.Functionality
{
    partial class AddItemPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.mobjTLP1.SuspendLayout();
            this.mobjTLP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "A item",
            "B item",
            "C item",
            "D item",
            "E item",
            "F item"});
            this.mobjListBox.Location = new System.Drawing.Point(0, 35);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 173);
            this.mobjListBox.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 35);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Extended ListBox:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextBox.Location = new System.Drawing.Point(163, 10);
            this.mobjTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjTextBox.TabIndex = 2;
            this.mobjTextBox.Text = "Added item";
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel1.Size = new System.Drawing.Size(160, 46);
            this.mobjLabel1.TabIndex = 3;
            this.mobjLabel1.Text = "Added item text";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNumericUpDown.Location = new System.Drawing.Point(160, 58);
            this.mobjNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjNumericUpDown.Name = "mobjNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(160, 21);
            this.mobjNumericUpDown.TabIndex = 4;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 46);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel2.Size = new System.Drawing.Size(160, 46);
            this.mobjLabel2.TabIndex = 5;
            this.mobjLabel2.Text = "Added item place";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(160, 92);
            this.mobjButton.MaximumSize = new System.Drawing.Size(200, 50);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(160, 48);
            this.mobjButton.TabIndex = 6;
            this.mobjButton.Text = "Add item into ListBox";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjTLP1
            // 
            this.mobjTLP1.ColumnCount = 1;
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP1.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP1.Controls.Add(this.mobjListBox, 0, 1);
            this.mobjTLP1.Controls.Add(this.mobjTLP2, 0, 2);
            this.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP1.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP1.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP1.Name = "mobjTLP1";
            this.mobjTLP1.RowCount = 3;
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjTLP1.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP1.TabIndex = 7;
            // 
            // mobjTLP2
            // 
            this.mobjTLP2.ColumnCount = 2;
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.Controls.Add(this.mobjLabel1, 0, 0);
            this.mobjTLP2.Controls.Add(this.mobjButton, 1, 2);
            this.mobjTLP2.Controls.Add(this.mobjLabel2, 0, 1);
            this.mobjTLP2.Controls.Add(this.mobjNumericUpDown, 1, 1);
            this.mobjTLP2.Controls.Add(this.mobjTextBox, 1, 0);
            this.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP2.Location = new System.Drawing.Point(0, 210);
            this.mobjTLP2.Name = "mobjTLP2";
            this.mobjTLP2.RowCount = 3;
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.Size = new System.Drawing.Size(320, 140);
            this.mobjTLP2.TabIndex = 0;
            // 
            // AddItemPage
            // 
            this.Controls.Add(this.mobjTLP1);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "AddItemPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.mobjTLP1.ResumeLayout(false);
            this.mobjTLP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP2;



    }
}
