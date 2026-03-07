namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class InspectorView
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
            this.components = new System.ComponentModel.Container();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // Errors
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            this.mobjErrorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.mobjErrorProvider.DataMember = "";
            this.mobjErrorProvider.DataSource = "";
            this.mobjErrorProvider.Icon = null;
            // 
            // InspectorView
            // 
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "InspectorView";
            this.ResumeLayout(false);

        }

        #endregion

        private ErrorProvider mobjErrorProvider;


    }
}