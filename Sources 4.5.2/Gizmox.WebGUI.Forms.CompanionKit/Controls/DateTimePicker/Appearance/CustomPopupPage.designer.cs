namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    partial class CustomPopupPage
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
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLabelPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 320F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjLabelPanel, 1, 0);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(391, 386);
            this.mobjLayoutPanel.TabIndex = 0;
            // 
            // mobjLabelPanel
            // 
            this.mobjLabelPanel.Controls.Add(this.mobjLabel);
            this.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabelPanel.DockPadding.Bottom = 10;
            this.mobjLabelPanel.DockPadding.Right = 10;
            this.mobjLabelPanel.DockPadding.Top = 10;
            this.mobjLabelPanel.Location = new System.Drawing.Point(35, 0);
            this.mobjLabelPanel.Name = "mobjLabelPanel";
            this.mobjLabelPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 10, 10);
            this.mobjLabelPanel.Size = new System.Drawing.Size(320, 117);
            this.mobjLabelPanel.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 10);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(310, 97);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "DateTimePicker with custom popup";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CustomPopupPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(391, 386);
            this.Text = "CustomPopupPage";
            this.Load += new System.EventHandler(this.CustomPopupPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjLabelPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}