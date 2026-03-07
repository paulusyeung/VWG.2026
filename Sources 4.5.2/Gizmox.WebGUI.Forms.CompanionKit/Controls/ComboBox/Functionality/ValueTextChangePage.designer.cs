namespace CompanionKit.Controls.ComboBox.Functionality
{
    partial class ValueTextChangePage
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
            this.components = new System.ComponentModel.Container();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjSelectLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjComboBoxTextTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBoxTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.DataSource = this.mobjBindingSource;
            this.mobjComboBox.DisplayMember = "Name";
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.Location = new System.Drawing.Point(0, 10);
            this.mobjComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.ValueMember = "Name";
            this.mobjComboBox.SelectedValueChanged += new System.EventHandler(this.mobjComboBox_SelectedValueChanged);
            this.mobjComboBox.TextChanged += new System.EventHandler(this.mobjComboBox_TextChanged);
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataSource = typeof(System.Drawing.Color);
            // 
            // mobjSelectLabel
            // 
            this.mobjSelectLabel.AutoSize = true;
            this.mobjSelectLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectLabel.Location = new System.Drawing.Point(10, 11);
            this.mobjSelectLabel.Name = "label1";
            this.mobjSelectLabel.Size = new System.Drawing.Size(254, 50);
            this.mobjSelectLabel.TabIndex = 1;
            this.mobjSelectLabel.Text = "Select ComboBox";
            this.mobjSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjValueTextBox
            // 
            this.mobjValueTextBox.AllowDrag = false;
            this.mobjValueTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueTextBox.Location = new System.Drawing.Point(267, 84);
            this.mobjValueTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTextBox.Name = "textBox1";
            this.mobjValueTextBox.ReadOnly = true;
            this.mobjValueTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjValueTextBox.TabIndex = 2;
            // 
            // mobjComboBoxTextTextBox
            // 
            this.mobjComboBoxTextTextBox.AllowDrag = false;
            this.mobjComboBoxTextTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBoxTextTextBox.Location = new System.Drawing.Point(0, 10);
            this.mobjComboBoxTextTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjComboBoxTextTextBox.Name = "textBox2";
            this.mobjComboBoxTextTextBox.ReadOnly = true;
            this.mobjComboBoxTextTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjComboBoxTextTextBox.TabIndex = 3;
            // 
            // mobjValueLabel
            // 
            this.mobjValueLabel.AutoSize = true;
            this.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueLabel.Location = new System.Drawing.Point(10, 81);
            this.mobjValueLabel.Name = "label2";
            this.mobjValueLabel.Size = new System.Drawing.Size(254, 30);
            this.mobjValueLabel.TabIndex = 4;
            this.mobjValueLabel.Text = "Selected Value";
            this.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjComboBoxTextLabel
            // 
            this.mobjComboBoxTextLabel.AutoSize = true;
            this.mobjComboBoxTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBoxTextLabel.Location = new System.Drawing.Point(10, 131);
            this.mobjComboBoxTextLabel.Name = "label3";
            this.mobjComboBoxTextLabel.Size = new System.Drawing.Size(254, 50);
            this.mobjComboBoxTextLabel.TabIndex = 5;
            this.mobjComboBoxTextLabel.Text = "Text of ComboBox";
            this.mobjComboBoxTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.AutoSize = true;
            this.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLabel.Location = new System.Drawing.Point(10, 201);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Size = new System.Drawing.Size(254, 30);
            this.mobjTextLabel.TabIndex = 6;
            this.mobjTextLabel.Text = "Text";
            this.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTextTextBox
            // 
            this.mobjTextTextBox.AllowDrag = false;
            this.mobjTextTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextTextBox.Location = new System.Drawing.Point(267, 204);
            this.mobjTextTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextTextBox.Name = "mobjTextTextBox";
            this.mobjTextTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjTextTextBox.TabIndex = 3;
            this.mobjTextTextBox.Text = "ActiveBorder";
            this.mobjTextTextBox.TextChanged += new System.EventHandler(this.mobjTextTextBox_TextChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextLabel, 1, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextTextBox, 2, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBoxTextLabel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueTextBox, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 2, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 2, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 9;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(529, 242);
            this.mobjLayoutPanel.TabIndex = 7;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjComboBoxTextTextBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.DockPadding.Bottom = 10;
            this.mobjPanel.DockPadding.Top = 10;
            this.mobjPanel.Location = new System.Drawing.Point(264, 131);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjPanel.Size = new System.Drawing.Size(254, 50);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjComboBox);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.DockPadding.Bottom = 10;
            this.mobjTopPanel.DockPadding.Top = 10;
            this.mobjTopPanel.Location = new System.Drawing.Point(264, 11);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjTopPanel.Size = new System.Drawing.Size(254, 50);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // ValueTextChangePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(529, 242);
            this.Text = "ValueTextChangePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.BindingSource mobjBindingSource;
        private Gizmox.WebGUI.Forms.Label mobjSelectLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjValueTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjComboBoxTextTextBox;
        private Gizmox.WebGUI.Forms.Label mobjValueLabel;
        private Gizmox.WebGUI.Forms.Label mobjComboBoxTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;



    }
}
