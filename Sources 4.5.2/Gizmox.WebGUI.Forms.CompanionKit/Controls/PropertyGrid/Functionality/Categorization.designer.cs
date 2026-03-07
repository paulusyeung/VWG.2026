namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    partial class Categorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categorization));
            this.objPropGrid = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.lblDemoObject = new Gizmox.WebGUI.Forms.Label();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objPropGrid
            // 
            this.objPropGrid.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.objPropGrid.CommandsVisibleIfAvailable = false;
            this.objPropGrid.HelpBackColor = System.Drawing.Color.Transparent;
            this.objPropGrid.HelpForeColor = System.Drawing.Color.Black;
            this.objPropGrid.LineColor = System.Drawing.Color.Empty;
            this.objPropGrid.Location = new System.Drawing.Point(368, 3);
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
            this.lblDemoObject.Location = new System.Drawing.Point(14, 85);
            this.lblDemoObject.Name = "lblDemoObject";
            this.lblDemoObject.Size = new System.Drawing.Size(348, 212);
            this.lblDemoObject.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // Categorization
            // 
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDemoObject);
            this.Controls.Add(this.objPropGrid);
            this.Size = new System.Drawing.Size(653, 328);
            this.Text = "Categorization";
            this.Load += new System.EventHandler(this.Categorization_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid objPropGrid;
        private Gizmox.WebGUI.Forms.Label lblDemoObject;
        private Gizmox.WebGUI.Forms.Label lblDescription;




    }
}