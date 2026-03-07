namespace CompanionKit.Controls.ComboBox.Functionality
{
    partial class ForceSelectedIndexChangedOnClickPage
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
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextBox.Location = new System.Drawing.Point(82, 159);
            this.mobjTextBox.Multiline = true;
            this.mobjTextBox.Name = "objTextBox";
            this.mobjTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.mobjTextBox.Size = new System.Drawing.Size(362, 117);
            this.mobjTextBox.TabIndex = 2;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4",
            "Item5",
            "Item6"});
            this.mobjComboBox.Location = new System.Drawing.Point(79, 106);
            this.mobjComboBox.Name = "objComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(368, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.Text = "Item1";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjCheckBox, 2);
            this.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckBox.Location = new System.Drawing.Point(79, 26);
            this.mobjCheckBox.Name = "objCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(448, 80);
            this.mobjCheckBox.TabIndex = 1;
            this.mobjCheckBox.Text = "Force to fire SelectedIndexChanged on click";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBox, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(527, 306);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // ForceSelectedIndexChangedOnClickPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(527, 306);
            this.Text = "ForceSelectedIndexChangedOnClickPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}