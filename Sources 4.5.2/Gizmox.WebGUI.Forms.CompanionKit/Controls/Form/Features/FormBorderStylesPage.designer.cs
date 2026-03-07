namespace CompanionKit.Controls.Form.Features
{
    partial class FormBorderStylesPage
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
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(231, 35);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Border style";
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjComboBox.Location = new System.Drawing.Point(0, 35);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(231, 21);
            this.mobjComboBox.TabIndex = 2;
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(115, 99);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(231, 70);
            this.mobjButton.TabIndex = 3;
            this.mobjButton.Text = "Open form with selected border style";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(462, 214);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjAdditionalLayoutPanel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(115, 29);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(231, 70);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.ColumnCount = 1;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjComboBox, 0, 1);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 2;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(231, 70);
            this.mobjAdditionalLayoutPanel.TabIndex = 3;
            // 
            // FormBorderStylesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(462, 214);
            this.Text = "FormBorderStylesPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjLabel;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private global::Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;



    }
}
