namespace CompanionKit.Controls.ComboBox.Features
{
    partial class AutocompletePage
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
            this.mobjComboBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjAutoCompleteComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjOptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBoxLabel
            // 
            this.mobjComboBoxLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjComboBoxLabel, 3);
            this.mobjComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBoxLabel.Location = new System.Drawing.Point(0, 21);
            this.mobjComboBoxLabel.Name = "label1";
            this.mobjComboBoxLabel.Size = new System.Drawing.Size(339, 50);
            this.mobjComboBoxLabel.TabIndex = 0;
            this.mobjComboBoxLabel.Text = "AutoCompleted ComboBox";
            this.mobjComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems;
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
            this.mobjComboBox.Location = new System.Drawing.Point(69, 71);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 1;
            // 
            // mobjAutoCompleteComboBox
            // 
            this.mobjAutoCompleteComboBox.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems;
            this.mobjAutoCompleteComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjAutoCompleteComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAutoCompleteComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjAutoCompleteComboBox.Items.AddRange(new object[] {
            "None",
            "Suggest",
            "Append",
            "SuggestAppend"});
            this.mobjAutoCompleteComboBox.Location = new System.Drawing.Point(69, 171);
            this.mobjAutoCompleteComboBox.Name = "mobjAutoCompleteComboBox";
            this.mobjAutoCompleteComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjAutoCompleteComboBox.TabIndex = 1;
            this.mobjAutoCompleteComboBox.Text = "None";
            this.mobjAutoCompleteComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjAutoCompleteComboBox_SelectedIndexChanged);
            // 
            // mobjOptionLabel
            // 
            this.mobjOptionLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjOptionLabel, 3);
            this.mobjOptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOptionLabel.Location = new System.Drawing.Point(0, 121);
            this.mobjOptionLabel.Name = "label2";
            this.mobjOptionLabel.Size = new System.Drawing.Size(339, 50);
            this.mobjOptionLabel.TabIndex = 0;
            this.mobjOptionLabel.Text = "AutoComplete Options";
            this.mobjOptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjAutoCompleteComboBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBoxLabel, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOptionLabel, 0, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(339, 223);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // AutocompletePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(339, 223);
            this.Text = "AutocompletePage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjComboBoxLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjAutoCompleteComboBox;
        private Gizmox.WebGUI.Forms.Label mobjOptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
    }
}
