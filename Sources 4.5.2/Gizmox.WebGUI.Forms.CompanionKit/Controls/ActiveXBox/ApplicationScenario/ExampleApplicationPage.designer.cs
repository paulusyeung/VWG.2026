namespace CompanionKit.Controls.ActiveXBox.ApplicationScenario
{
    partial class ExampleApplicationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleApplicationPage));
            this.demoActiveXBox = new Gizmox.WebGUI.Forms.Hosts.ActiveXBox();
            this.SuspendLayout();
            // 
            // demoActiveXBox
            // 
            this.demoActiveXBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoActiveXBox.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("demoActiveXBox.BackgroundImage"));
            this.demoActiveXBox.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.demoActiveXBox.ClassId = "CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6";
            this.demoActiveXBox.CodeBase = "";
            this.demoActiveXBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoActiveXBox.Location = new System.Drawing.Point(0, 0);
            this.demoActiveXBox.Name = "demoActiveXBox";
            this.demoActiveXBox.Size = new System.Drawing.Size(391, 306);
            this.demoActiveXBox.StandBy = "";
            this.demoActiveXBox.TabIndex = 0;
            this.demoActiveXBox.Type = "";
            // 
            // ExampleApplicationPage
            // 
            this.Controls.Add(this.demoActiveXBox);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ExampleApplicationPage";
            this.Load += new System.EventHandler(this.ExampleApplicationPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.ActiveXBox demoActiveXBox;



    }
}
