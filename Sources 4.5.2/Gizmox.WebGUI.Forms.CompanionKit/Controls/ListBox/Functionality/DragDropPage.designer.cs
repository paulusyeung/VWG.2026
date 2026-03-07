namespace CompanionKit.Controls.ListBox.Functionality
{
    partial class DragDropPage
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
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjAllowDrop = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox1
            // 
            this.mobjListBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Component)(this.mobjListBox2))};
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
            this.mobjListBox1.Location = new System.Drawing.Point(0, 80);
            this.mobjListBox1.Margin = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjListBox1.Name = "mobjListBox1";
            this.mobjListBox1.Size = new System.Drawing.Size(150, 212);
            this.mobjListBox1.TabIndex = 0;
            // 
            // mobjListBox2
            // 
            this.mobjListBox2.AllowDrop = true;
            this.mobjListBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox2.Location = new System.Drawing.Point(170, 80);
            this.mobjListBox2.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0);
            this.mobjListBox2.Name = "mobjListBox2";
            this.mobjListBox2.Size = new System.Drawing.Size(150, 212);
            this.mobjListBox2.TabIndex = 1;
            this.mobjListBox2.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.mobjListBox2_DragDrop);
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(160, 80);
            this.mobjLabel1.TabIndex = 2;
            this.mobjLabel1.Text = "ListBox with defined drag target:";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(387, 0);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(160, 80);
            this.mobjLabel2.TabIndex = 3;
            this.mobjLabel2.Text = "ListBox with allowed drop:";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjLabel1, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjListBox2, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjLabel2, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjListBox1, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjAllowDrop, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 23F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 62F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 4;
            // 
            // mobjAllowDrop
            // 
            this.mobjAllowDrop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAllowDrop.Checked = true;
            this.mobjAllowDrop.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjTLP.SetColumnSpan(this.mobjAllowDrop, 2);
            this.mobjAllowDrop.Location = new System.Drawing.Point(85, 298);
            this.mobjAllowDrop.Name = "mobjAllowDrop";
            this.mobjAllowDrop.Size = new System.Drawing.Size(150, 50);
            this.mobjAllowDrop.TabIndex = 0;
            this.mobjAllowDrop.Text = "Alow Drop for ListBox2";
            this.mobjAllowDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjAllowDrop.CheckedChanged += new System.EventHandler(this.mobjAllowDrop_CheckedChanged);
            // 
            // DragDropPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "DragDropPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox1;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox2;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        private Gizmox.WebGUI.Forms.CheckBox mobjAllowDrop;



    }
}
