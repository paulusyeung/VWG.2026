namespace CompanionKit.Controls.XamlBox.Programming
{
    partial class ProvideParametersPage
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
            this.demoXamlBox = new Gizmox.WebGUI.Forms.Hosts.XamlBox();
            this.SuspendLayout();
            // 
            // demoXamlBox
            // 
            this.demoXamlBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoXamlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoXamlBox.Location = new System.Drawing.Point(0, 0);
            this.demoXamlBox.Name = "demoXamlBox";
            this.demoXamlBox.Parameters.Add("windowless", false);
            this.demoXamlBox.Size = new System.Drawing.Size(391, 453);
            this.demoXamlBox.TabIndex = 0;
            this.demoXamlBox.Windowless = false;
            // 
            // ProvideParametersPage
            // 
            this.Controls.Add(this.demoXamlBox);
            this.Size = new System.Drawing.Size(391, 453);
            this.Text = "ProvideParametersPage";
            this.Load += new System.EventHandler(this.ProvideParametersPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.XamlBox demoXamlBox;



    }
}