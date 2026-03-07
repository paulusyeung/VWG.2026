namespace CompanionKit.Controls.StatusBar.Layouts
{
    partial class Docking
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
            this.mobjDockComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTestStatusBar = new Gizmox.WebGUI.Forms.StatusBar();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjDockComboBox
            // 
            this.mobjDockComboBox.AllowDrag = false;
            this.mobjDockComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjDockComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjDockComboBox.Location = new System.Drawing.Point(182, 86);
            this.mobjDockComboBox.Name = "mobjDockComboBox";
            this.mobjDockComboBox.Size = new System.Drawing.Size(155, 30);
            this.mobjDockComboBox.TabIndex = 1;
            this.mobjDockComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjDockComboBox_SelectedIndexChanged);
            // 
            // mobjTestStatusBar
            // 
            this.mobjTestStatusBar.Location = new System.Drawing.Point(0, 284);
            this.mobjTestStatusBar.Name = "mobjTestStatusBar";
            this.mobjTestStatusBar.Size = new System.Drawing.Size(511, 22);
            this.mobjTestStatusBar.TabIndex = 3;
            this.mobjTestStatusBar.Text = "This is test StatusBar";
            // 
            // mobjLabel
            // 
            this.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(179, 55);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 4;
            this.mobjLabel.Text = "Dock Style";
            // 
            // Docking
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjTestStatusBar);
            this.Controls.Add(this.mobjDockComboBox);
            this.Size = new System.Drawing.Size(511, 200);
            this.Text = "Docking";
            this.Load += new System.EventHandler(this.Docking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjDockComboBox;
        private Gizmox.WebGUI.Forms.StatusBar mobjTestStatusBar;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}
