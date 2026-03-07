namespace Gizmox.WebGUI.Forms.Design.Editors.Resources.Objects
{
    partial class DataGridViewGroupingColumnsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjMainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mobjSourceListBox = new System.Windows.Forms.ListBox();
            this.mobjTargetListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mobjRightBtton = new System.Windows.Forms.Button();
            this.mobjLeftButton = new System.Windows.Forms.Button();
            this.mobjDownButton = new System.Windows.Forms.Button();
            this.mobjUpButton = new System.Windows.Forms.Button();
            this.mobjMainTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMainTableLayoutPanel
            // 
            this.mobjMainTableLayoutPanel.ColumnCount = 3;
            this.mobjMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mobjMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mobjMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mobjMainTableLayoutPanel.Controls.Add(this.mobjSourceListBox, 0, 0);
            this.mobjMainTableLayoutPanel.Controls.Add(this.mobjTargetListBox, 2, 0);
            this.mobjMainTableLayoutPanel.Controls.Add(this.panel1, 1, 0);
            this.mobjMainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobjMainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjMainTableLayoutPanel.Name = "mobjMainTableLayoutPanel";
            this.mobjMainTableLayoutPanel.RowCount = 1;
            this.mobjMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mobjMainTableLayoutPanel.Size = new System.Drawing.Size(361, 257);
            this.mobjMainTableLayoutPanel.TabIndex = 0;
            // 
            // mobjSourceListBox
            // 
            this.mobjSourceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobjSourceListBox.FormattingEnabled = true;
            this.mobjSourceListBox.Location = new System.Drawing.Point(3, 3);
            this.mobjSourceListBox.Name = "mobjSourceListBox";
            this.mobjSourceListBox.Size = new System.Drawing.Size(149, 251);
            this.mobjSourceListBox.TabIndex = 1;
            this.mobjSourceListBox.SelectedIndexChanged += new System.EventHandler(this.OnSourceListBoxSelectedIndexChanged);
            // 
            // mobjTargetLlistBox
            // 
            this.mobjTargetListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobjTargetListBox.FormattingEnabled = true;
            this.mobjTargetListBox.Location = new System.Drawing.Point(208, 3);
            this.mobjTargetListBox.Name = "mobjTargetLlistBox";
            this.mobjTargetListBox.Size = new System.Drawing.Size(150, 251);
            this.mobjTargetListBox.TabIndex = 0;
            this.mobjTargetListBox.SelectedIndexChanged += new System.EventHandler(this.OnTargetListBoxSelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjRightBtton);
            this.panel1.Controls.Add(this.mobjLeftButton);
            this.panel1.Controls.Add(this.mobjDownButton);
            this.panel1.Controls.Add(this.mobjUpButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(158, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 251);
            this.panel1.TabIndex = 2;
            // 
            // mobjRightBtton
            // 
            this.mobjRightBtton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mobjRightBtton.Location = new System.Drawing.Point(0, 175);
            this.mobjRightBtton.Name = "mobjRightBtton";
            this.mobjRightBtton.Size = new System.Drawing.Size(44, 23);
            this.mobjRightBtton.TabIndex = 6;
            this.mobjRightBtton.Text = ">>";
            this.mobjRightBtton.UseVisualStyleBackColor = true;
            this.mobjRightBtton.Click += new System.EventHandler(this.OnRightButtonClick);
            // 
            // mobjLeftButton
            // 
            this.mobjLeftButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mobjLeftButton.Location = new System.Drawing.Point(0, 146);
            this.mobjLeftButton.Name = "mobjLeftButton";
            this.mobjLeftButton.Size = new System.Drawing.Size(44, 23);
            this.mobjLeftButton.TabIndex = 5;
            this.mobjLeftButton.Text = "<<";
            this.mobjLeftButton.UseVisualStyleBackColor = true;
            this.mobjLeftButton.Click += new System.EventHandler(this.OnLeftButtonClick);
            // 
            // mobjDownButton
            // 
            this.mobjDownButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mobjDownButton.Location = new System.Drawing.Point(0, 81);
            this.mobjDownButton.Name = "mobjDownButton";
            this.mobjDownButton.Size = new System.Drawing.Size(44, 23);
            this.mobjDownButton.TabIndex = 4;
            this.mobjDownButton.Text = "&Down";
            this.mobjDownButton.UseVisualStyleBackColor = true;
            this.mobjDownButton.Click += new System.EventHandler(this.OnDownButtonClick);
            // 
            // mobjUpButton
            // 
            this.mobjUpButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mobjUpButton.Location = new System.Drawing.Point(0, 52);
            this.mobjUpButton.Name = "mobjUpButton";
            this.mobjUpButton.Size = new System.Drawing.Size(44, 23);
            this.mobjUpButton.TabIndex = 3;
            this.mobjUpButton.Text = "&Up";
            this.mobjUpButton.UseVisualStyleBackColor = true;
            this.mobjUpButton.Click += new System.EventHandler(this.OnUpButtonClick);
            // 
            // DataGridViewGroupingColumnsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mobjMainTableLayoutPanel);
            this.Name = "DataGridViewGroupingColumnsControl";
            this.Size = new System.Drawing.Size(361, 257);
            this.mobjMainTableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mobjMainTableLayoutPanel;
        private System.Windows.Forms.ListBox mobjSourceListBox;
        private System.Windows.Forms.ListBox mobjTargetListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button mobjRightBtton;
        private System.Windows.Forms.Button mobjLeftButton;
        private System.Windows.Forms.Button mobjDownButton;
        private System.Windows.Forms.Button mobjUpButton;

    }
}
