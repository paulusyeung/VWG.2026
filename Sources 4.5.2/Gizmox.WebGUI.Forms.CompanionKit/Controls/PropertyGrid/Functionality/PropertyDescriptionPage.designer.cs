namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    partial class PropertyDescriptionPage
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
            this.objPropGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.lblDemoObject = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objPropGrid
            // 
            this.objPropGrid.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.objPropGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.objPropGrid.CommandsVisibleIfAvailable = false;
            this.objPropGrid.HelpBackColor = System.Drawing.Color.Transparent;
            this.objPropGrid.HelpForeColor = System.Drawing.Color.Black;
            this.objPropGrid.LineColor = System.Drawing.Color.Empty;
            this.objPropGrid.Location = new System.Drawing.Point(3, 4);
            this.objPropGrid.Name = "objPropGrid";
            this.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
            this.objPropGrid.Size = new System.Drawing.Size(282, 320);
            this.objPropGrid.TabIndex = 0;
            this.objPropGrid.ViewBackColor = System.Drawing.Color.White;
            this.objPropGrid.ViewForeColor = System.Drawing.Color.Black;
            this.objPropGrid.PropertyValueChanged += new Gizmox.WebGUI.Forms.PropertyValueChangedEventHandler(this.objPropGrid_PropertyValueChanged);
            // 
            // lblDemoObject
            // 
            this.lblDemoObject.Location = new System.Drawing.Point(295, 107);
            this.lblDemoObject.Name = "lblDemoObject";
            this.lblDemoObject.Size = new System.Drawing.Size(348, 212);
            this.lblDemoObject.TabIndex = 1;
            // 
            // PropertyDescriptionPage
            // 
            this.Controls.Add(this.lblDemoObject);
            this.Controls.Add(this.objPropGrid);
            this.Size = new System.Drawing.Size(653, 328);
            this.Text = "PropertyDescriptionPage";
            this.Load += new System.EventHandler(this.PropertyDescriptionPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid objPropGrid;
        private Gizmox.WebGUI.Forms.Label lblDemoObject;

    }
}