namespace CompanionKit.Controls.GroupBox.Programming
{
    partial class MouseClickedPage
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
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjButtonClickedLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjButtonClickedLabel);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(102, 21);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(478, 98);
            this.mobjGroupBox.TabIndex = 0;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "GroupBox";
            this.mobjGroupBox.Click += new System.EventHandler(this.mobjGroupBox_Click);
            // 
            // mobjButtonClickedLabel
            // 
            this.mobjButtonClickedLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonClickedLabel.AutoSize = true;
            this.mobjButtonClickedLabel.Location = new System.Drawing.Point(206, 47);
            this.mobjButtonClickedLabel.Name = "mobjButtonClickedLabel";
            this.mobjButtonClickedLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjButtonClickedLabel.TabIndex = 0;
            this.mobjButtonClickedLabel.Text = "Right clicked";
            // 
            // mobjLabel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjLabel, 3);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 119);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(683, 60);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Click inside the boundaries of group box";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjLabel.Click += new System.EventHandler(this.mobjGroupBox_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel, 0, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(683, 200);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // MouseClickedPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(683, 200);
            this.Text = "MouseClickedPage";
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Label mobjButtonClickedLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
