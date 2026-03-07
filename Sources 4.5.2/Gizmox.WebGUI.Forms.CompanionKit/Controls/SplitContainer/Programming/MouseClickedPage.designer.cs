namespace CompanionKit.Controls.SplitContainer.Programming
{
    partial class MouseClickedPage
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
            this.mobjSplitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.mobjGroupBoxWithSplitContainer = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjGroupBoxWithSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjSplitContainer
            // 
            this.mobjSplitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mobjSplitContainer.Name = "mobjSplitContainer1";
            // 
            // mobjSplitContainer.Panel1
            // 
            this.mobjSplitContainer.Panel1.BackColor = System.Drawing.Color.Yellow;
            this.mobjSplitContainer.Panel1.Click += new System.EventHandler(this.mobjSplitContainer_Panel1_Click);
            // 
            // mobjSplitContainer.Panel2
            // 
            this.mobjSplitContainer.Panel2.BackColor = System.Drawing.Color.Red;
            this.mobjSplitContainer.Panel2.Click += new System.EventHandler(this.mobjSplitContainer_Panel2_Click);
            this.mobjSplitContainer.Size = new System.Drawing.Size(439, 229);
            this.mobjSplitContainer.SplitterDistance = 146;
            this.mobjSplitContainer.TabIndex = 0;
            this.mobjSplitContainer.Click += new System.EventHandler(this.mobjSplitContainer_Click);
            // 
            // mobjGroupBoxWithSplitContainer
            // 
            this.mobjGroupBoxWithSplitContainer.Controls.Add(this.mobjSplitContainer);
            this.mobjGroupBoxWithSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBoxWithSplitContainer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBoxWithSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.mobjGroupBoxWithSplitContainer.Name = "mobjGroupBoxWithSplitContainer";
            this.mobjGroupBoxWithSplitContainer.Size = new System.Drawing.Size(445, 249);
            this.mobjGroupBoxWithSplitContainer.TabIndex = 0;
            this.mobjGroupBoxWithSplitContainer.TabStop = false;
            this.mobjGroupBoxWithSplitContainer.Text = "SplitContainers with Click event ";
            // 
            // MouseClickedPage
            // 
            this.Controls.Add(this.mobjGroupBoxWithSplitContainer);
            this.DockPadding.All = 10;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(465, 269);
            this.Text = "MouseClickedPage";
            this.mobjGroupBoxWithSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.SplitContainer mobjSplitContainer;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBoxWithSplitContainer;



    }
}
