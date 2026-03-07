namespace CompanionKit.Controls.Form.Features
{
    partial class FormStatePage
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
            this.mobjMaximizeBtnCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMinimizeBtnCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjOpenFormWindowState = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjFirstPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.mobjFirstPanel.SuspendLayout();
            this.mobjSecondPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaximizeBtnCheckBox
            // 
            this.mobjMaximizeBtnCheckBox.AutoSize = true;
            this.mobjMaximizeBtnCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaximizeBtnCheckBox.Location = new System.Drawing.Point(0, 0);
            this.mobjMaximizeBtnCheckBox.Name = "maximizeBtnCheckBox";
            this.mobjMaximizeBtnCheckBox.Size = new System.Drawing.Size(348, 17);
            this.mobjMaximizeBtnCheckBox.TabIndex = 1;
            this.mobjMaximizeBtnCheckBox.Text = "Maximize button";
            this.mobjMaximizeBtnCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjMinimizeBtnCheckBox
            // 
            this.mobjMinimizeBtnCheckBox.AutoSize = true;
            this.mobjMinimizeBtnCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMinimizeBtnCheckBox.Location = new System.Drawing.Point(0, 0);
            this.mobjMinimizeBtnCheckBox.Name = "minimizeBtnCheckBox";
            this.mobjMinimizeBtnCheckBox.Size = new System.Drawing.Size(348, 17);
            this.mobjMinimizeBtnCheckBox.TabIndex = 2;
            this.mobjMinimizeBtnCheckBox.Text = "Minimize button";
            this.mobjMinimizeBtnCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 66);
            this.mobjLabel.Name = "label2";
            this.mobjLabel.Size = new System.Drawing.Size(121, 13);
            this.mobjLabel.TabIndex = 3;
            this.mobjLabel.Text = "Form state";
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjComboBox.Location = new System.Drawing.Point(121, 66);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(227, 30);
            this.mobjComboBox.TabIndex = 4;
            // 
            // mobjOpenFormWindowState
            // 
            this.mobjOpenFormWindowState.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFormWindowState.Location = new System.Drawing.Point(116, 148);
            this.mobjOpenFormWindowState.Name = "openFormWindowState";
            this.mobjOpenFormWindowState.Size = new System.Drawing.Size(348, 60);
            this.mobjOpenFormWindowState.TabIndex = 5;
            this.mobjOpenFormWindowState.Text = "Open form with selected window state";
            this.mobjOpenFormWindowState.UseVisualStyleBackColor = true;
            this.mobjOpenFormWindowState.Click += new System.EventHandler(this.mobjOpenFormWindowState_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFormWindowState, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(581, 257);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjAdditionalLayoutPanel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(116, 48);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(348, 100);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.ColumnCount = 2;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjFirstPanel, 0, 0);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjComboBox, 1, 2);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjSecondPanel, 0, 1);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjLabel, 0, 2);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 3;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(348, 100);
            this.mobjAdditionalLayoutPanel.TabIndex = 5;
            // 
            // mobjFirstPanel
            // 
            this.mobjAdditionalLayoutPanel.SetColumnSpan(this.mobjFirstPanel, 2);
            this.mobjFirstPanel.Controls.Add(this.mobjMaximizeBtnCheckBox);
            this.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFirstPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjFirstPanel.Name = "mobjFirstPanel";
            this.mobjFirstPanel.Size = new System.Drawing.Size(348, 33);
            this.mobjFirstPanel.TabIndex = 0;
            // 
            // mobjSecondPanel
            // 
            this.mobjAdditionalLayoutPanel.SetColumnSpan(this.mobjSecondPanel, 2);
            this.mobjSecondPanel.Controls.Add(this.mobjMinimizeBtnCheckBox);
            this.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSecondPanel.Location = new System.Drawing.Point(0, 33);
            this.mobjSecondPanel.Name = "mobjSecondPanel";
            this.mobjSecondPanel.Size = new System.Drawing.Size(348, 33);
            this.mobjSecondPanel.TabIndex = 0;
            // 
            // FormStatePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(581, 257);
            this.Text = "FormStatePage";
            this.Load += new System.EventHandler(this.FormStatePage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.mobjFirstPanel.ResumeLayout(false);
            this.mobjSecondPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.CheckBox mobjMaximizeBtnCheckBox;
        private global::Gizmox.WebGUI.Forms.CheckBox mobjMinimizeBtnCheckBox;
        private global::Gizmox.WebGUI.Forms.Label mobjLabel;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private global::Gizmox.WebGUI.Forms.Button mobjOpenFormWindowState;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondPanel;



    }
}
