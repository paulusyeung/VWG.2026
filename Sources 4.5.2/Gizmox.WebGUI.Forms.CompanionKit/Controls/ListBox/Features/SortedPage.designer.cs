namespace CompanionKit.Controls.ListBox.Features
{
    partial class SortedPage
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
            this.mobjIsSorted = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjIsSorted
            // 
            this.mobjIsSorted.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjIsSorted.Location = new System.Drawing.Point(35, 10);
            this.mobjIsSorted.Name = "mobjIsSorted";
            this.mobjIsSorted.Size = new System.Drawing.Size(250, 50);
            this.mobjIsSorted.TabIndex = 0;
            this.mobjIsSorted.Text = "Turn on Sorted property for ListBox";
            this.mobjIsSorted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjIsSorted.UseVisualStyleBackColor = true;
            this.mobjIsSorted.CheckedChanged += new System.EventHandler(this.mobjIsSorted_CheckedChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 70);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 70);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "The items are not sorted";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListBox
            // 
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Location = new System.Drawing.Point(0, 140);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 199);
            this.mobjListBox.TabIndex = 2;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjIsSorted, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjListBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 3;
            // 
            // SortedPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "SortedPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjIsSorted;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
