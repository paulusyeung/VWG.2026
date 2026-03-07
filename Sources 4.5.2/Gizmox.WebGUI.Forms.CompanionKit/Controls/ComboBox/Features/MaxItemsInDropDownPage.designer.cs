namespace CompanionKit.Controls.ComboBox.Features
{
    partial class MaxItemsInDropDownPage
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
            this.mobjCurrentMaxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjMaxComboBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCurrentMaxLabel
            // 
            this.mobjCurrentMaxLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjCurrentMaxLabel, 3);
            this.mobjCurrentMaxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCurrentMaxLabel.Location = new System.Drawing.Point(0, 22);
            this.mobjCurrentMaxLabel.Name = "label1";
            this.mobjCurrentMaxLabel.Size = new System.Drawing.Size(379, 50);
            this.mobjCurrentMaxLabel.TabIndex = 0;
            this.mobjCurrentMaxLabel.Text = "Current MaxDropDownItems";
            this.mobjCurrentMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextBox.Location = new System.Drawing.Point(92, 75);
            this.mobjTextBox.Name = "textBox1";
            this.mobjTextBox.Size = new System.Drawing.Size(194, 34);
            this.mobjTextBox.TabIndex = 1;
            this.mobjTextBox.TextChanged += new System.EventHandler(this.mobjTextBox_TextChanged);
            // 
            // mobjMaxComboBoxLabel
            // 
            this.mobjMaxComboBoxLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjMaxComboBoxLabel, 3);
            this.mobjMaxComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaxComboBoxLabel.Location = new System.Drawing.Point(0, 132);
            this.mobjMaxComboBoxLabel.Name = "label2";
            this.mobjMaxComboBoxLabel.Size = new System.Drawing.Size(379, 50);
            this.mobjMaxComboBoxLabel.TabIndex = 2;
            this.mobjMaxComboBoxLabel.Text = "ComboBox";
            this.mobjMaxComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.Items.AddRange(new object[] {
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
            this.mobjComboBox.Location = new System.Drawing.Point(89, 182);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjCurrentMaxLabel, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxComboBoxLabel, 0, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(379, 234);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // MaxItemsInDropDownPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(379, 234);
            this.Text = "MaxItemsInDropDownPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjCurrentMaxLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Label mobjMaxComboBoxLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
