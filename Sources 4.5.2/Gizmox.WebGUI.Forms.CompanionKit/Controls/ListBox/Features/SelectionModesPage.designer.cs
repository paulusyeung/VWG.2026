namespace CompanionKit.Controls.ListBox.Features
{
    partial class SelectionModesPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjModeCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
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
            this.mobjListBox.Location = new System.Drawing.Point(0, 52);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 186);
            this.mobjListBox.TabIndex = 0;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "ListBox demonstrates selection modes:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjModeLabel
            // 
            this.mobjModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjModeLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjModeLabel.Name = "mobjModeLabel";
            this.mobjModeLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjModeLabel.Size = new System.Drawing.Size(160, 106);
            this.mobjModeLabel.TabIndex = 4;
            this.mobjModeLabel.Text = "Selection Mode";
            this.mobjModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjModeCB
            // 
            this.mobjModeCB.AllowDrag = false;
            this.mobjModeCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjModeCB.FormattingEnabled = true;
            this.mobjModeCB.Location = new System.Drawing.Point(160, 42);
            this.mobjModeCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjModeCB.Name = "mobjModeCB";
            this.mobjModeCB.Size = new System.Drawing.Size(160, 25);
            this.mobjModeCB.TabIndex = 5;
            this.mobjModeCB.SelectedIndexChanged += new System.EventHandler(this.mobjModeCB_SelectedIndexChanged);
            // 
            // mobjTLP1
            // 
            this.mobjTLP1.ColumnCount = 1;
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP1.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP1.Controls.Add(this.mobjListBox, 0, 1);
            this.mobjTLP1.Controls.Add(this.mobjTLP2, 0, 2);
            this.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP1.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP1.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP1.Name = "mobjTLP1";
            this.mobjTLP1.RowCount = 3;
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP1.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP1.TabIndex = 6;
            // 
            // mobjTLP2
            // 
            this.mobjTLP2.ColumnCount = 2;
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.Controls.Add(this.mobjModeLabel, 0, 0);
            this.mobjTLP2.Controls.Add(this.mobjModeCB, 1, 0);
            this.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP2.Location = new System.Drawing.Point(0, 244);
            this.mobjTLP2.Name = "mobjTLP2";
            this.mobjTLP2.RowCount = 1;
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.Size = new System.Drawing.Size(320, 106);
            this.mobjTLP2.TabIndex = 0;
            // 
            // SelectionModesPage
            // 
            this.Controls.Add(this.mobjTLP1);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "SelectionModesPage";
            this.mobjTLP1.ResumeLayout(false);
            this.mobjTLP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Label mobjModeLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjModeCB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP2;



    }
}
