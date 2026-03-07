namespace CompanionKit.Controls.ListBox.Functionality
{
    partial class Transfer
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
            this.mobjListBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjListBox2 = new Gizmox.WebGUI.Forms.ListBox();
            this.btnToRight = new Gizmox.WebGUI.Forms.Button();
            this.btnAllToRight = new Gizmox.WebGUI.Forms.Button();
            this.btnToLeft = new Gizmox.WebGUI.Forms.Button();
            this.btnAllToLeft = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP1.SuspendLayout();
            this.mobjTLP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox1
            // 
            this.mobjListBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox1.Items.AddRange(new object[] {
            "A item",
            "B item",
            "C item",
            "D item",
            "E item",
            "F item",
            "G item",
            "I item",
            "J item",
            "K item",
            "L item",
            "M item",
            "N item",
            "O item",
            "P item",
            "Q item",
            "R item",
            "S item",
            "T item",
            "U item",
            "V item",
            "W item",
            "X item",
            "Y item",
            "Z item"});
            this.mobjListBox1.Location = new System.Drawing.Point(0, 52);
            this.mobjListBox1.Name = "mobjListBox1";
            this.mobjListBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended;
            this.mobjListBox1.Size = new System.Drawing.Size(160, 290);
            this.mobjListBox1.Sorted = true;
            this.mobjListBox1.TabIndex = 0;
            this.mobjListBox1.SelectedIndexChanged += new System.EventHandler(this.mobjListBox1_SelectedIndexChanged);
            // 
            // mobjListBox2
            // 
            this.mobjListBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox2.Location = new System.Drawing.Point(240, 52);
            this.mobjListBox2.Name = "mobjListBox2";
            this.mobjListBox2.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended;
            this.mobjListBox2.Size = new System.Drawing.Size(160, 290);
            this.mobjListBox2.Sorted = true;
            this.mobjListBox2.TabIndex = 1;
            this.mobjListBox2.SelectedIndexChanged += new System.EventHandler(this.mobjListBox2_SelectedIndexChanged);
            // 
            // btnToRight
            // 
            this.btnToRight.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnToRight.Location = new System.Drawing.Point(0, 22);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(80, 30);
            this.btnToRight.TabIndex = 2;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnAllToRight.Location = new System.Drawing.Point(0, 96);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(80, 30);
            this.btnAllToRight.TabIndex = 3;
            this.btnAllToRight.Text = ">>";
            this.btnAllToRight.UseVisualStyleBackColor = true;
            this.btnAllToRight.Click += new System.EventHandler(this.btnAllToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnToLeft.Location = new System.Drawing.Point(0, 170);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(80, 30);
            this.btnToLeft.TabIndex = 4;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnAllToLeft.Location = new System.Drawing.Point(0, 245);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(80, 30);
            this.btnAllToLeft.TabIndex = 5;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.btnAllToLeft_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP1.SetColumnSpan(this.mobjInfoLabel, 3);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(400, 52);
            this.mobjInfoLabel.TabIndex = 6;
            this.mobjInfoLabel.Text = "Transfer an item from a ListBox to another one:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP1
            // 
            this.mobjTLP1.ColumnCount = 3;
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP1.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP1.Controls.Add(this.mobjListBox1, 0, 1);
            this.mobjTLP1.Controls.Add(this.mobjListBox2, 2, 1);
            this.mobjTLP1.Controls.Add(this.mobjTLP2, 1, 1);
            this.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP1.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP1.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP1.Name = "mobjTLP1";
            this.mobjTLP1.RowCount = 2;
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85F));
            this.mobjTLP1.Size = new System.Drawing.Size(400, 350);
            this.mobjTLP1.TabIndex = 7;
            // 
            // mobjTLP2
            // 
            this.mobjTLP2.ColumnCount = 1;
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP2.Controls.Add(this.btnToRight, 0, 0);
            this.mobjTLP2.Controls.Add(this.btnAllToLeft, 0, 3);
            this.mobjTLP2.Controls.Add(this.btnAllToRight, 0, 1);
            this.mobjTLP2.Controls.Add(this.btnToLeft, 0, 2);
            this.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP2.Location = new System.Drawing.Point(160, 52);
            this.mobjTLP2.Name = "mobjTLP2";
            this.mobjTLP2.RowCount = 4;
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP2.Size = new System.Drawing.Size(80, 298);
            this.mobjTLP2.TabIndex = 0;
            // 
            // Transfer
            // 
            this.Controls.Add(this.mobjTLP1);
            this.Size = new System.Drawing.Size(400, 350);
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.Transfer_Load);
            this.mobjTLP1.ResumeLayout(false);
            this.mobjTLP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox1;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox2;
        private Gizmox.WebGUI.Forms.Button btnToRight;
        private Gizmox.WebGUI.Forms.Button btnAllToRight;
        private Gizmox.WebGUI.Forms.Button btnToLeft;
        private Gizmox.WebGUI.Forms.Button btnAllToLeft;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP2;



    }
}
