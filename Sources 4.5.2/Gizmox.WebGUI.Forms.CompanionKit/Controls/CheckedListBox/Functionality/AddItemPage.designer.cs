namespace CompanionKit.Controls.CheckedListBox.Functionality
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjAddedItemText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjAddedItemPlace = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjAddedItemPlace)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 45);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Extended CheckedListBox:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            "F item"});
            this.mobjCheckedListBox.Location = new System.Drawing.Point(0, 45);
            this.mobjCheckedListBox.Name = "mobjCheckedListBox";
            this.mobjCheckedListBox.Size = new System.Drawing.Size(320, 116);
            this.mobjCheckedListBox.TabIndex = 1;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 165);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel1.Size = new System.Drawing.Size(160, 45);
            this.mobjLabel1.TabIndex = 2;
            this.mobjLabel1.Text = "Added item text";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjAddedItemText
            // 
            this.mobjAddedItemText.AllowDrag = false;
            this.mobjAddedItemText.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjAddedItemText.Location = new System.Drawing.Point(170, 175);
            this.mobjAddedItemText.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3);
            this.mobjAddedItemText.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjAddedItemText.Name = "mobjAddedItemText";
            this.mobjAddedItemText.Size = new System.Drawing.Size(140, 25);
            this.mobjAddedItemText.TabIndex = 3;
            this.mobjAddedItemText.Text = "Added item";
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 210);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel2.Size = new System.Drawing.Size(160, 45);
            this.mobjLabel2.TabIndex = 4;
            this.mobjLabel2.Text = "Added item place";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjAddedItemPlace
            // 
            this.mobjAddedItemPlace.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjAddedItemPlace.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjAddedItemPlace.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjAddedItemPlace.Location = new System.Drawing.Point(170, 222);
            this.mobjAddedItemPlace.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjAddedItemPlace.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjAddedItemPlace.Name = "mobjAddedItemPlace";
            this.mobjAddedItemPlace.Size = new System.Drawing.Size(140, 21);
            this.mobjAddedItemPlace.TabIndex = 5;
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(170, 265);
            this.mobjAddButton.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjAddButton.MaximumSize = new System.Drawing.Size(200, 50);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(140, 25);
            this.mobjAddButton.TabIndex = 6;
            this.mobjAddButton.Text = "Add item ";
            this.mobjAddButton.UseVisualStyleBackColor = true;
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjAddButton, 1, 4);
            this.mobjTLP.Controls.Add(this.mobjCheckedListBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjAddedItemPlace, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjLabel1, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjAddedItemText, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjLabel2, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 300);
            this.mobjTLP.TabIndex = 7;
            // 
            // AddItemPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 300);
            this.Text = "AddItemPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjAddedItemPlace)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckedListBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.TextBox mobjAddedItemText;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjAddedItemPlace;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
