namespace CompanionKit.Controls.Form.Features
{
    partial class MDIFormPage
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
            this.mobjOpenMDIFormBtn = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjOpenMDIFormBtn
            // 
            this.mobjOpenMDIFormBtn.AccessibleDescription = "";
            this.mobjOpenMDIFormBtn.AccessibleName = "";
            this.mobjOpenMDIFormBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenMDIFormBtn.Location = new System.Drawing.Point(121, 60);
            this.mobjOpenMDIFormBtn.Name = "mobjOpenMDIFormBtn";
            this.mobjOpenMDIFormBtn.Size = new System.Drawing.Size(243, 50);
            this.mobjOpenMDIFormBtn.TabIndex = 1;
            this.mobjOpenMDIFormBtn.Text = "Open MDI parent form";
            this.mobjOpenMDIFormBtn.UseVisualStyleBackColor = true;
            this.mobjOpenMDIFormBtn.Click += new System.EventHandler(this.mobjOpenMDIFormBtn_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.AccessibleDescription = "";
            this.mobjLayoutPanel.AccessibleName = "";
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenMDIFormBtn, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(486, 202);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // MDIFormPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(486, 202);
            this.Text = "MDIFormPage";
            this.VisibleChanged += new System.EventHandler(this.MDIFormPage_VisibleChanged);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Button mobjOpenMDIFormBtn;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
