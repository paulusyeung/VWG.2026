namespace CompanionKit.Controls.AppletBox.Programming
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
            this.demoAppletBox = new Gizmox.WebGUI.Forms.Hosts.AppletBox();
            this.SuspendLayout();
            // 
            // demoAppletBox
            // 
            this.demoAppletBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoAppletBox.Archive = "MoleculeViewer.jar";
            this.demoAppletBox.Code = "XYZApp.class";
            this.demoAppletBox.CodeBase = "Controls/AppletBox/Programming";
            this.demoAppletBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoAppletBox.Location = new System.Drawing.Point(0, 0);
            this.demoAppletBox.Name = "demoAppletBox";
            this.demoAppletBox.Parameters.Add("model", "Controls/AppletBox/Programming/HyaluronicAcid.xyz");
            this.demoAppletBox.Size = new System.Drawing.Size(391, 306);
            this.demoAppletBox.TabIndex = 0;
            // 
            // ProvideParametersPage
            // 
            this.Controls.Add(this.demoAppletBox);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ProvideParametersPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.AppletBox demoAppletBox;



    }
}