namespace CompanionKit.Controls.ComboBox.Features
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
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.Location = new System.Drawing.Point(91, 138);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(91, 88);
            this.mobjLabel.Name = "label1";
            this.mobjLabel.Size = new System.Drawing.Size(200, 50);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Items are sorted";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjCheckBox, 2);
            this.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckBox.Location = new System.Drawing.Point(91, 18);
            this.mobjCheckBox.Name = "checkBox1";
            this.mobjCheckBox.Size = new System.Drawing.Size(292, 50);
            this.mobjCheckBox.TabIndex = 2;
            this.mobjCheckBox.Text = "Turn on Sorted property";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(383, 186);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // SortedPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(383, 186);
            this.Text = "SortedPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;




    }
}
