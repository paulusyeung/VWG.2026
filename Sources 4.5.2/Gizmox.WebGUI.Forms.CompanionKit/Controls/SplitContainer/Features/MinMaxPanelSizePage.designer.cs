namespace CompanionKit.Controls.SplitContainer.Features
{
    partial class MinMaxPanelSizePage
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
            this.mobjSplitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.mobjSplitContainer2 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.mobjGroupBoxWithSplitContainer = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjGroupBoxWithSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjSplitContainer1
            // 
            this.mobjSplitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjSplitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.mobjSplitContainer1.Name = "splitContainer1";
            // 
            // mobjSplitContainer1.Panel1
            // 
            this.mobjSplitContainer1.Panel1.BackColor = System.Drawing.Color.Red;
            this.mobjSplitContainer1.Panel1MinSize = 100;
            // 
            // mobjSplitContainer1.Panel2
            // 
            this.mobjSplitContainer1.Panel2.Controls.Add(this.mobjSplitContainer2);
            this.mobjSplitContainer1.Panel2MinSize = 100;
            this.mobjSplitContainer1.Size = new System.Drawing.Size(398, 256);
            this.mobjSplitContainer1.SplitterDistance = 134;
            this.mobjSplitContainer1.TabIndex = 0;
            // 
            // mobjSplitContainer2
            // 
            this.mobjSplitContainer2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjSplitContainer2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.mobjSplitContainer2.Name = "splitContainer2";
            this.mobjSplitContainer2.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // mobjSplitContainer2.Panel1
            // 
            this.mobjSplitContainer2.Panel1.BackColor = System.Drawing.Color.Green;
            this.mobjSplitContainer2.Panel1MinSize = 50;
            // 
            // mobjSplitContainer2.Panel2
            // 
            this.mobjSplitContainer2.Panel2.BackColor = System.Drawing.Color.Yellow;
            this.mobjSplitContainer2.Panel2MinSize = 100;
            this.mobjSplitContainer2.Size = new System.Drawing.Size(260, 256);
            this.mobjSplitContainer2.SplitterDistance = 122;
            this.mobjSplitContainer2.TabIndex = 0;
            // 
            // mobjGroupBoxWithSplitContainer
            // 
            this.mobjGroupBoxWithSplitContainer.Controls.Add(this.mobjSplitContainer1);
            this.mobjGroupBoxWithSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBoxWithSplitContainer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBoxWithSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.mobjGroupBoxWithSplitContainer.Name = "mobjGroupBoxWithSplitContainer";
            this.mobjGroupBoxWithSplitContainer.Size = new System.Drawing.Size(404, 276);
            this.mobjGroupBoxWithSplitContainer.TabIndex = 0;
            this.mobjGroupBoxWithSplitContainer.TabStop = false;
            this.mobjGroupBoxWithSplitContainer.Text = "SplitContainer with min/max panels";
            // 
            // MinMaxPanelSizePage
            // 
            this.Controls.Add(this.mobjGroupBoxWithSplitContainer);
            this.DockPadding.All = 10;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(424, 296);
            this.Text = "MinMaxPanelSizePage";
            this.mobjGroupBoxWithSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.SplitContainer mobjSplitContainer1;
        private global::Gizmox.WebGUI.Forms.SplitContainer mobjSplitContainer2;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBoxWithSplitContainer;



    }
}
