namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    partial class ObjectInspection
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
            this.objInitial = new Gizmox.WebGUI.Forms.Label();
            this.objGroupSelection = new Gizmox.WebGUI.Forms.GroupBox();
            this.objMultiple = new Gizmox.WebGUI.Forms.Button();
            this.objButton03 = new Gizmox.WebGUI.Forms.Button();
            this.objButton02 = new Gizmox.WebGUI.Forms.Button();
            this.objButton01 = new Gizmox.WebGUI.Forms.Button();
            this.objVWGLinkLabel = new Gizmox.WebGUI.Forms.LinkLabel();
            this.objAnotherLabel = new Gizmox.WebGUI.Forms.Label();
            this.objGroupSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // objPropGrid
            // 
            this.objPropGrid.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.objPropGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty;
            this.objPropGrid.CommandsVisibleIfAvailable = false;
            this.objPropGrid.HelpBackColor = System.Drawing.Color.Gainsboro;
            this.objPropGrid.HelpForeColor = System.Drawing.Color.Black;
            this.objPropGrid.LineColor = System.Drawing.Color.Empty;
            this.objPropGrid.Location = new System.Drawing.Point(368, 3);
            this.objPropGrid.Name = "objPropGrid";
            this.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
            this.objPropGrid.SelectedObject = this.objInitial;
            this.objPropGrid.Size = new System.Drawing.Size(282, 322);
            this.objPropGrid.TabIndex = 0;
            this.objPropGrid.ViewBackColor = System.Drawing.Color.White;
            this.objPropGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // objInitial
            // 
            this.objInitial.AutoSize = true;
            this.objInitial.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.objInitial.Location = new System.Drawing.Point(118, 35);
            this.objInitial.Name = "objInitial";
            this.objInitial.Size = new System.Drawing.Size(136, 15);
            this.objInitial.TabIndex = 1;
            this.objInitial.Text = "The label selected on initialization";
            // 
            // objGroupSelection
            // 
            this.objGroupSelection.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.objGroupSelection.Controls.Add(this.objMultiple);
            this.objGroupSelection.Controls.Add(this.objButton03);
            this.objGroupSelection.Controls.Add(this.objButton02);
            this.objGroupSelection.Controls.Add(this.objButton01);
            this.objGroupSelection.Controls.Add(this.objVWGLinkLabel);
            this.objGroupSelection.Controls.Add(this.objAnotherLabel);
            this.objGroupSelection.Controls.Add(this.objInitial);
            this.objGroupSelection.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objGroupSelection.Location = new System.Drawing.Point(3, 3);
            this.objGroupSelection.Name = "objGroupSelection";
            this.objGroupSelection.Size = new System.Drawing.Size(359, 322);
            this.objGroupSelection.TabIndex = 2;
            this.objGroupSelection.TabStop = false;
            this.objGroupSelection.Text = "Click to inspect and change with PropertyGrid";
            // 
            // objMultiple
            // 
            this.objMultiple.Location = new System.Drawing.Point(18, 146);
            this.objMultiple.Name = "objMultiple";
            this.objMultiple.Size = new System.Drawing.Size(335, 40);
            this.objMultiple.TabIndex = 5;
            this.objMultiple.Text = "Click to select simple and initial label to inspect and edit simultaneously";
            this.objMultiple.UseVisualStyleBackColor = true;
            this.objMultiple.Click += new System.EventHandler(this.objMultiple_Click);
            // 
            // objButton03
            // 
            this.objButton03.Location = new System.Drawing.Point(18, 94);
            this.objButton03.Name = "button1";
            this.objButton03.Size = new System.Drawing.Size(55, 27);
            this.objButton03.TabIndex = 4;
            this.objButton03.Text = "select";
            this.objButton03.UseVisualStyleBackColor = true;
            this.objButton03.Click += new System.EventHandler(this.objButton03_Click);
            // 
            // objButton02
            // 
            this.objButton02.Location = new System.Drawing.Point(18, 61);
            this.objButton02.Name = "button1";
            this.objButton02.Size = new System.Drawing.Size(55, 27);
            this.objButton02.TabIndex = 4;
            this.objButton02.Text = "select";
            this.objButton02.UseVisualStyleBackColor = true;
            this.objButton02.Click += new System.EventHandler(this.objButton02_Click);
            // 
            // objButton01
            // 
            this.objButton01.Location = new System.Drawing.Point(18, 28);
            this.objButton01.Name = "objButton01";
            this.objButton01.Size = new System.Drawing.Size(55, 27);
            this.objButton01.TabIndex = 4;
            this.objButton01.Text = "select";
            this.objButton01.UseVisualStyleBackColor = true;
            this.objButton01.Click += new System.EventHandler(this.objButton01_Click);
            // 
            // objVWGLinkLabel
            // 
            this.objVWGLinkLabel.AutoSize = true;
            this.objVWGLinkLabel.ClientMode = false;
            this.objVWGLinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.objVWGLinkLabel.Location = new System.Drawing.Point(115, 101);
            this.objVWGLinkLabel.Name = "objVWGLinkLabel";
            this.objVWGLinkLabel.Size = new System.Drawing.Size(53, 13);
            this.objVWGLinkLabel.TabIndex = 3;
            this.objVWGLinkLabel.TabStop = true;
            this.objVWGLinkLabel.Text = "Link label";
            this.objVWGLinkLabel.Url = "http://www.visualwebgui.com";
            // 
            // objAnotherLabel
            // 
            this.objAnotherLabel.AutoSize = true;
            this.objAnotherLabel.Location = new System.Drawing.Point(115, 68);
            this.objAnotherLabel.Name = "objAnotherLabel";
            this.objAnotherLabel.Size = new System.Drawing.Size(35, 13);
            this.objAnotherLabel.TabIndex = 2;
            this.objAnotherLabel.Text = "A simple label";
            // 
            // ObjectInspection
            // 
            this.Controls.Add(this.objGroupSelection);
            this.Controls.Add(this.objPropGrid);
            this.Size = new System.Drawing.Size(653, 328);
            this.Text = "ObjectInspection";
            this.objGroupSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PropertyGrid objPropGrid;
        private Gizmox.WebGUI.Forms.Label objInitial;
        private Gizmox.WebGUI.Forms.GroupBox objGroupSelection;
        private Gizmox.WebGUI.Forms.LinkLabel objVWGLinkLabel;
        private Gizmox.WebGUI.Forms.Label objAnotherLabel;
        private Gizmox.WebGUI.Forms.Button objButton03;
        private Gizmox.WebGUI.Forms.Button objButton02;
        private Gizmox.WebGUI.Forms.Button objButton01;
        private Gizmox.WebGUI.Forms.Button objMultiple;



    }
}