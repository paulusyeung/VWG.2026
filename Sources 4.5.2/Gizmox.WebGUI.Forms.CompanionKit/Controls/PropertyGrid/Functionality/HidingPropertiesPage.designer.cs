namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    partial class HidingPropertiesPage
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
            this.objPropertiesComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.objPropertiesLabel = new Gizmox.WebGUI.Forms.Label();
            this.showPropertyCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // objPropGrid
            // 
            this.objPropGrid.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.objPropGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
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
            this.lblDemoObject.Location = new System.Drawing.Point(14, 90);
            this.lblDemoObject.Name = "lblDemoObject";
            this.lblDemoObject.Size = new System.Drawing.Size(348, 207);
            this.lblDemoObject.TabIndex = 1;
            // 
            // objPropertiesComboBox
            // 
            this.objPropertiesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.objPropertiesComboBox.Location = new System.Drawing.Point(34, 22);
            this.objPropertiesComboBox.MaxDropDownItems = 8;
            this.objPropertiesComboBox.Name = "objPropertiesComboBox";
            this.objPropertiesComboBox.Size = new System.Drawing.Size(153, 21);
            this.objPropertiesComboBox.TabIndex = 2;
            this.objPropertiesComboBox.SelectedIndexChanged += new System.EventHandler(this.objPropertiesComboBox_SelectedIndexChanged);
            // 
            // objPropertiesLabel
            // 
            this.objPropertiesLabel.AutoSize = true;
            this.objPropertiesLabel.Location = new System.Drawing.Point(34, 4);
            this.objPropertiesLabel.Name = "objPropertiesLabel";
            this.objPropertiesLabel.Size = new System.Drawing.Size(35, 13);
            this.objPropertiesLabel.TabIndex = 3;
            this.objPropertiesLabel.Text = "Selected object properties";
            // 
            // showPropertyCheckBox
            // 
            this.showPropertyCheckBox.AutoSize = true;
            this.showPropertyCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.showPropertyCheckBox.Location = new System.Drawing.Point(193, 24);
            this.showPropertyCheckBox.Name = "showPropertyCheckBox";
            this.showPropertyCheckBox.Size = new System.Drawing.Size(140, 17);
            this.showPropertyCheckBox.TabIndex = 4;
            this.showPropertyCheckBox.Text = "Show selected property";
            this.showPropertyCheckBox.UseVisualStyleBackColor = true;
            this.showPropertyCheckBox.Click += new System.EventHandler(this.showPropertyCheckBox_Click);
            // 
            // HidingPropertiesPage
            // 
            this.Controls.Add(this.showPropertyCheckBox);
            this.Controls.Add(this.objPropertiesLabel);
            this.Controls.Add(this.objPropertiesComboBox);
            this.Controls.Add(this.lblDemoObject);
            this.Controls.Add(this.objPropGrid);
            this.Size = new System.Drawing.Size(653, 328);
            this.Text = "HidingPropertiesPage";
            this.Load += new System.EventHandler(this.HidingPropertiesPage_Load);
            this.VisibleChanged += new System.EventHandler(this.HidingPropertiesPage_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid objPropGrid;
        private Gizmox.WebGUI.Forms.Label lblDemoObject;
        private Gizmox.WebGUI.Forms.ComboBox objPropertiesComboBox;
        private Gizmox.WebGUI.Forms.Label objPropertiesLabel;
        private Gizmox.WebGUI.Forms.CheckBox showPropertyCheckBox;


    }
}