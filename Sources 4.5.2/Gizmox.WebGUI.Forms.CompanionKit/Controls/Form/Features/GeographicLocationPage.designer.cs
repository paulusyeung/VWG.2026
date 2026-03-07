namespace CompanionKit.Controls.Form.Features
{
    partial class GeographicLocationPage
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(88, 52);
            this.mobjButton.Name = "button1";
            this.mobjButton.Size = new System.Drawing.Size(177, 50);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Open GeographicLocationForm";
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.AccessibleDescription = "";
            this.mobjLayoutPanel.AccessibleName = "";
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(30, 30);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(355, 155);
            this.mobjLayoutPanel.TabIndex = 1;
            // 
            // GeographicLocationPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.All = 30;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.Size = new System.Drawing.Size(415, 215);
            this.Text = "GeographicLocationPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;




    }
}