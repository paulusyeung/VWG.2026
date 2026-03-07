namespace CompanionKit.Controls.Splitter.Features
{
    partial class OrientationPage
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
            this.mobjPanel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSplitter1 = new Gizmox.WebGUI.Forms.Splitter();
            this.mobjPanel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSplitter2 = new Gizmox.WebGUI.Forms.Splitter();
            this.mobjPanel3 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjGroupBoxWithSplitter = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjGroupBoxWithSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPanel1
            // 
            this.mobjPanel1.BackColor = System.Drawing.Color.Red;
            this.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjPanel1.Location = new System.Drawing.Point(172, 17);
            this.mobjPanel1.Name = "mobjPanel1";
            this.mobjPanel1.Size = new System.Drawing.Size(200, 269);
            this.mobjPanel1.TabIndex = 0;
            // 
            // mobjSplitter1
            // 
            this.mobjSplitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjSplitter1.Location = new System.Drawing.Point(169, 17);
            this.mobjSplitter1.Name = "mobjSplitter1";
            this.mobjSplitter1.Size = new System.Drawing.Size(3, 269);
            this.mobjSplitter1.TabIndex = 1;
            this.mobjSplitter1.TabStop = false;
            // 
            // mobjPanel2
            // 
            this.mobjPanel2.BackColor = System.Drawing.Color.Blue;
            this.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPanel2.Location = new System.Drawing.Point(3, 186);
            this.mobjPanel2.Name = "mobjPanel2";
            this.mobjPanel2.Size = new System.Drawing.Size(166, 100);
            this.mobjPanel2.TabIndex = 2;
            // 
            // mobjSplitter2
            // 
            this.mobjSplitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSplitter2.Location = new System.Drawing.Point(3, 183);
            this.mobjSplitter2.Name = "mobjSplitter2";
            this.mobjSplitter2.Size = new System.Drawing.Size(166, 3);
            this.mobjSplitter2.TabIndex = 3;
            this.mobjSplitter2.TabStop = false;
            // 
            // mobjPanel3
            // 
            this.mobjPanel3.BackColor = System.Drawing.Color.Orange;
            this.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel3.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel3.Name = "mobjPanel3";
            this.mobjPanel3.Size = new System.Drawing.Size(166, 166);
            this.mobjPanel3.TabIndex = 4;
            // 
            // mobjGroupBoxWithSplitter
            // 
            this.mobjGroupBoxWithSplitter.Controls.Add(this.mobjPanel3);
            this.mobjGroupBoxWithSplitter.Controls.Add(this.mobjSplitter2);
            this.mobjGroupBoxWithSplitter.Controls.Add(this.mobjPanel2);
            this.mobjGroupBoxWithSplitter.Controls.Add(this.mobjSplitter1);
            this.mobjGroupBoxWithSplitter.Controls.Add(this.mobjPanel1);
            this.mobjGroupBoxWithSplitter.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBoxWithSplitter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBoxWithSplitter.Location = new System.Drawing.Point(25, 25);
            this.mobjGroupBoxWithSplitter.Name = "mobjGroupBoxWithSplitter";
            this.mobjGroupBoxWithSplitter.Size = new System.Drawing.Size(375, 289);
            this.mobjGroupBoxWithSplitter.TabIndex = 0;
            this.mobjGroupBoxWithSplitter.TabStop = false;
            this.mobjGroupBoxWithSplitter.Text = "GroupBox";
            // 
            // OrientationPage
            // 
            this.Controls.Add(this.mobjGroupBoxWithSplitter);
            this.DockPadding.All = 25;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(25);
            this.Size = new System.Drawing.Size(425, 339);
            this.Text = "OrientationPage";
            this.mobjGroupBoxWithSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Panel mobjPanel1;
        private global::Gizmox.WebGUI.Forms.Splitter mobjSplitter1;
        private global::Gizmox.WebGUI.Forms.Panel mobjPanel2;
        private global::Gizmox.WebGUI.Forms.Splitter mobjSplitter2;
        private global::Gizmox.WebGUI.Forms.Panel mobjPanel3;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBoxWithSplitter;



    }
}
