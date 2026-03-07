namespace CompanionKit.Controls.ActiveXBox.Programming
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
            this.demoActiveXBox = new Gizmox.WebGUI.Forms.Hosts.ActiveXBox();
            this.SuspendLayout();
            // 
            // demoActiveXBox
            // 
            this.demoActiveXBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoActiveXBox.ClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000";
            this.demoActiveXBox.CodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0" +
                ",0";
            this.demoActiveXBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoActiveXBox.Location = new System.Drawing.Point(0, 0);
            this.demoActiveXBox.Name = "demoActiveXBox";
            this.demoActiveXBox.Parameters.Add("Src", "../../../../../../../Resources/Flash/FC_2_3_Area2D.swf");
            this.demoActiveXBox.Parameters.Add("FlashVars", "&dataURL=../../../../../../../Resources/Flash/FC_2_3_DATA.xml");
            this.demoActiveXBox.Parameters.Add("quality", "high");
            this.demoActiveXBox.Size = new System.Drawing.Size(391, 306);
            this.demoActiveXBox.StandBy = "";
            this.demoActiveXBox.TabIndex = 0;
            this.demoActiveXBox.Type = "";
            // 
            // ProvideParametersPage
            // 
            this.Controls.Add(this.demoActiveXBox);
            this.Size = new System.Drawing.Size(391, 450);
            this.Text = "ProvideParametersPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.ActiveXBox demoActiveXBox;



    }
}
