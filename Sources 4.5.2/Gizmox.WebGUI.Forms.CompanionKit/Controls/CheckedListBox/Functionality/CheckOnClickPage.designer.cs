namespace CompanionKit.Controls.CheckedListBox.Functionality
{
    partial class CheckOnClickPage
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
            this.mobjCheckOnClick = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCheckOnClick
            // 
            this.mobjCheckOnClick.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckOnClick.Location = new System.Drawing.Point(136, 11);
            this.mobjCheckOnClick.Name = "mobjCheckOnClick";
            this.mobjCheckOnClick.Size = new System.Drawing.Size(250, 70);
            this.mobjCheckOnClick.TabIndex = 0;
            this.mobjCheckOnClick.Text = "Turn on CheckOnClick property for CheckedListBox";
            this.mobjCheckOnClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckOnClick.UseVisualStyleBackColor = true;
            this.mobjCheckOnClick.CheckedChanged += new System.EventHandler(this.mobjCheckOnClick_CheckedChanged);
            // 
            // mobjCheckedListBox
            // 
            this.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckedListBox.Items.AddRange(new object[] {
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
            this.mobjCheckedListBox.Location = new System.Drawing.Point(0, 70);
            this.mobjCheckedListBox.Name = "mobjCheckedListBox";
            this.mobjCheckedListBox.Size = new System.Drawing.Size(320, 276);
            this.mobjCheckedListBox.TabIndex = 2;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjCheckOnClick, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjCheckedListBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 3;
            // 
            // CheckOnClickPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "CheckOnClickPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjCheckOnClick;
        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckedListBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
