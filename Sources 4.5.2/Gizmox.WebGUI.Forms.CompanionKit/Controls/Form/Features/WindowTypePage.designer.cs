namespace CompanionKit.Controls.Form.Features
{
    partial class WindowTypePage
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
            this.mobjOpenModelessFormButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjOpenPopupFormButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjOpenModalFormButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjOpenModelessFormButton
            // 
            this.mobjOpenModelessFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenModelessFormButton.Location = new System.Drawing.Point(57, 11);
            this.mobjOpenModelessFormButton.Name = "button1";
            this.mobjOpenModelessFormButton.Size = new System.Drawing.Size(268, 60);
            this.mobjOpenModelessFormButton.TabIndex = 1;
            this.mobjOpenModelessFormButton.Text = "Open modeless form";
            this.mobjOpenModelessFormButton.UseVisualStyleBackColor = true;
            this.mobjOpenModelessFormButton.Click += new System.EventHandler(this.mobjOpenModelessFormButton_Click);
            // 
            // mobjOpenPopupFormButton
            // 
            this.mobjOpenPopupFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenPopupFormButton.Location = new System.Drawing.Point(57, 151);
            this.mobjOpenPopupFormButton.Name = "button2";
            this.mobjOpenPopupFormButton.Size = new System.Drawing.Size(268, 60);
            this.mobjOpenPopupFormButton.TabIndex = 2;
            this.mobjOpenPopupFormButton.Text = "Open popup form";
            this.mobjOpenPopupFormButton.UseVisualStyleBackColor = true;
            this.mobjOpenPopupFormButton.Click += new System.EventHandler(this.mobjOpenPopupFormButton_Click);
            // 
            // mobjOpenModalFormButton
            // 
            this.mobjOpenModalFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenModalFormButton.Location = new System.Drawing.Point(57, 81);
            this.mobjOpenModalFormButton.Name = "button3";
            this.mobjOpenModalFormButton.Size = new System.Drawing.Size(268, 60);
            this.mobjOpenModalFormButton.TabIndex = 3;
            this.mobjOpenModalFormButton.Text = "Open modal form";
            this.mobjOpenModalFormButton.UseVisualStyleBackColor = true;
            this.mobjOpenModalFormButton.Click += new System.EventHandler(this.mobjOpenModalFormButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenModalFormButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenModelessFormButton, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenPopupFormButton, 1, 5);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(384, 222);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // WindowTypePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(384, 222);
            this.Text = "WindowTypePage";
            this.VisibleChanged += new System.EventHandler(this.WindowTypePage_VisibleChanged);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Button mobjOpenModelessFormButton;
        private global::Gizmox.WebGUI.Forms.Button mobjOpenPopupFormButton;
        private global::Gizmox.WebGUI.Forms.Button mobjOpenModalFormButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
