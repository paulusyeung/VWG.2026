namespace CompanionKit.Controls.TabControl.Appearance
{
    partial class ExpandCollapsePage
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
            this.mobjTabControl = new Gizmox.WebGUI.Forms.TabControl();
            this.mobjTabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjTabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjTabPage3 = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjTabControl)).BeginInit();
            this.mobjTabControl.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTabControl
            // 
            this.mobjTabControl.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjTabControl.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTabControl.Controls.Add(this.mobjTabPage1);
            this.mobjTabControl.Controls.Add(this.mobjTabPage2);
            this.mobjTabControl.Controls.Add(this.mobjTabPage3);
            this.mobjTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTabControl.Location = new System.Drawing.Point(85, 19);
            this.mobjTabControl.Name = "mobjTabControl";
            this.mobjTabControl.SelectedIndex = 0;
            this.mobjTabControl.ShowExpandButton = true;
            this.mobjTabControl.Size = new System.Drawing.Size(429, 151);
            this.mobjTabControl.TabIndex = 0;
            this.mobjTabControl.Collapse += new System.EventHandler(this.mobjTabControl_Collapse);
            this.mobjTabControl.Expand += new System.EventHandler(this.mobjTabControl_Expand);
            // 
            // mobjTabPage1
            // 
            this.mobjTabPage1.BackColor = System.Drawing.Color.MediumPurple;
            this.mobjTabPage1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjTabPage1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTabPage1.Location = new System.Drawing.Point(4, 22);
            this.mobjTabPage1.Name = "mobjTabPage1";
            this.mobjTabPage1.Size = new System.Drawing.Size(421, 125);
            this.mobjTabPage1.TabIndex = 0;
            this.mobjTabPage1.Text = "tabPage1";
            // 
            // mobjTabPage2
            // 
            this.mobjTabPage2.BackColor = System.Drawing.Color.MediumPurple;
            this.mobjTabPage2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjTabPage2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTabPage2.Location = new System.Drawing.Point(4, 22);
            this.mobjTabPage2.Name = "mobjTabPage2";
            this.mobjTabPage2.Size = new System.Drawing.Size(246, 125);
            this.mobjTabPage2.TabIndex = 1;
            this.mobjTabPage2.Text = "tabPage2";
            // 
            // mobjTabPage3
            // 
            this.mobjTabPage3.BackColor = System.Drawing.Color.MediumPurple;
            this.mobjTabPage3.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjTabPage3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTabPage3.Location = new System.Drawing.Point(0, 0);
            this.mobjTabPage3.Name = "mobjTabPage3";
            this.mobjTabPage3.Size = new System.Drawing.Size(421, 125);
            this.mobjTabPage3.TabIndex = 2;
            this.mobjTabPage3.Text = "tabPage3";
            // 
            // mobjStateLabel
            // 
            this.mobjStateLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjStateLabel, 3);
            this.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStateLabel.Location = new System.Drawing.Point(0, 194);
            this.mobjStateLabel.Name = "mobjStateLabel";
            this.mobjStateLabel.Size = new System.Drawing.Size(601, 30);
            this.mobjStateLabel.TabIndex = 2;
            this.mobjStateLabel.Text = "Now TabControl is:Expanded";
            this.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 14.28571F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 71.42857F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 14.28571F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTabControl, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjStateLabel, 0, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(601, 244);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // ExpandCollapsePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(601, 244);
            this.Text = "ExpandCollapse";
            ((System.ComponentModel.ISupportInitialize)(this.mobjTabControl)).EndInit();
            this.mobjTabControl.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl mobjTabControl;
        private Gizmox.WebGUI.Forms.TabPage mobjTabPage1;
        private Gizmox.WebGUI.Forms.TabPage mobjTabPage2;
        private Gizmox.WebGUI.Forms.Label mobjStateLabel;
        private Gizmox.WebGUI.Forms.TabPage mobjTabPage3;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}