namespace CompanionKit.Controls.CheckedListBox.Features
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
            this.mobjCheckedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mobjSelectionModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectionModesComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCheckedListBox
            // 
            this.mobjTLP.SetColumnSpan(this.mobjCheckedListBox, 2);
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
            this.mobjCheckedListBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended;
            this.mobjCheckedListBox.Size = new System.Drawing.Size(320, 276);
            this.mobjCheckedListBox.TabIndex = 0;
            this.mobjCheckedListBox.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.mobjCheckedListBox_ItemCheck);
            // 
            // mobjSelectionModeLabel
            // 
            this.mobjSelectionModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectionModeLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSelectionModeLabel.Name = "mobjSelectionModeLabel";
            this.mobjSelectionModeLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjSelectionModeLabel.Size = new System.Drawing.Size(160, 70);
            this.mobjSelectionModeLabel.TabIndex = 4;
            this.mobjSelectionModeLabel.Text = "Change the selection mode: ";
            this.mobjSelectionModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjSelectionModesComboBox
            // 
            this.mobjSelectionModesComboBox.AllowDrag = false;
            this.mobjSelectionModesComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjSelectionModesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjSelectionModesComboBox.Location = new System.Drawing.Point(160, 24);
            this.mobjSelectionModesComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjSelectionModesComboBox.Name = "mobjSelectionModesComboBox";
            this.mobjSelectionModesComboBox.Size = new System.Drawing.Size(160, 25);
            this.mobjSelectionModesComboBox.TabIndex = 5;
            this.mobjSelectionModesComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjSelectionModesComboBox_SelectedIndexChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjSelectionModeLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjCheckedListBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjSelectionModesComboBox, 1, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 6;
            // 
            // SelectionModesPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "SelectionModesPage";
            this.Load += new System.EventHandler(this.SelectionModesPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckedListBox;
        private Gizmox.WebGUI.Forms.Label mobjSelectionModeLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjSelectionModesComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
