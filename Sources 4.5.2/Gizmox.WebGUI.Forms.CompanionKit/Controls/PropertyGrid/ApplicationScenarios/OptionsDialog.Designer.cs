namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios
{
    partial class OptionsDialog
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.optionsPropertyGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // optionsPropertyGrid
            // 
            this.optionsPropertyGrid.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.optionsPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.optionsPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.optionsPropertyGrid.CommandsVisibleIfAvailable = false;
            this.optionsPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.optionsPropertyGrid.HelpBackColor = System.Drawing.Color.Transparent;
            this.optionsPropertyGrid.HelpForeColor = System.Drawing.Color.Black;
            this.optionsPropertyGrid.LineColor = System.Drawing.Color.Empty;
            this.optionsPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.optionsPropertyGrid.Name = "optionsPropertyGrid";
            this.optionsPropertyGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
            this.optionsPropertyGrid.Size = new System.Drawing.Size(419, 466);
            this.optionsPropertyGrid.TabIndex = 0;
            this.optionsPropertyGrid.ViewBackColor = System.Drawing.Color.White;
            this.optionsPropertyGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // OptionsDialog
            // 
            this.Controls.Add(this.optionsPropertyGrid);
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "OptionsDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid optionsPropertyGrid;


    }
}