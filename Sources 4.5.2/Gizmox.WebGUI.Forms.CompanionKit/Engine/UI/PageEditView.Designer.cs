namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class PageEditView
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
			this.mobjGroupResources = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjResourcesEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.ResourcesEditView();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjInspectorEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.InspectorEditView();
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.objCmdHelp = new Gizmox.WebGUI.Forms.Button();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTxtHeight = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjPanelContent.SuspendLayout();
			this.mobjGroupResources.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjPanelContent
			// 
			this.mobjPanelContent.Controls.Add(this.groupBox2);
			this.mobjPanelContent.Controls.Add(this.groupBox1);
			this.mobjPanelContent.Controls.Add(this.mobjGroupResources);
			this.mobjPanelContent.Size = new System.Drawing.Size(683, 584);
			// 
			// mobjComboParent
			// 
			this.mobjComboParent.Enabled = false;
			// 
			// mobjTextName
			// 
			this.mobjTextName.Enabled = false;
			// 
			// mobjButtonDelete
			// 
			this.mobjButtonDelete.Enabled = true;
			// 
			// mobjGroupResources
			// 
			this.mobjGroupResources.Controls.Add(this.mobjResourcesEditView);
			this.mobjGroupResources.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjGroupResources.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjGroupResources.Location = new System.Drawing.Point(0, 0);
			this.mobjGroupResources.Name = "mobjGroupResources";
			this.mobjGroupResources.Size = new System.Drawing.Size(683, 301);
			this.mobjGroupResources.TabIndex = 0;
			this.mobjGroupResources.TabStop = false;
			this.mobjGroupResources.Text = "Resources";
			// 
			// mobjResourcesEditView
			// 
			this.mobjResourcesEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjResourcesEditView.Location = new System.Drawing.Point(5, 19);
			this.mobjResourcesEditView.Name = "mobjResourcesEditView";
			this.mobjResourcesEditView.Size = new System.Drawing.Size(672, 278);
			this.mobjResourcesEditView.TabIndex = 0;
			this.mobjResourcesEditView.Text = "ResourcesEditView";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.mobjInspectorEditView);
			this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(0, 301);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(683, 192);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Inspector";
			// 
			// mobjInspectorEditView
			// 
			this.mobjInspectorEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjInspectorEditView.Location = new System.Drawing.Point(6, 18);
			this.mobjInspectorEditView.Name = "inspectorEditView1";
			this.mobjInspectorEditView.Size = new System.Drawing.Size(668, 164);
			this.mobjInspectorEditView.TabIndex = 0;
			this.mobjInspectorEditView.Text = "InspectorEditView";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.objCmdHelp);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.mobjTxtHeight);
			this.groupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(0, 493);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(683, 75);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Snippet user control";
			// 
			// objCmdHelp
			// 
			this.objCmdHelp.Location = new System.Drawing.Point(587, 29);
			this.objCmdHelp.Name = "objCmdHelp";
			this.objCmdHelp.Size = new System.Drawing.Size(75, 23);
			this.objCmdHelp.TabIndex = 2;
			this.objCmdHelp.Tag = "User control height";
			this.objCmdHelp.Text = "Help";
			this.objCmdHelp.UseVisualStyleBackColor = true;
			this.objCmdHelp.Click += new System.EventHandler(this.objCmdHelp_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Height, px";
			// 
			// mobjTxtHeight
			// 
			this.mobjTxtHeight.Location = new System.Drawing.Point(90, 31);
			this.mobjTxtHeight.Name = "mobjTxtHeight";
			this.mobjTxtHeight.Size = new System.Drawing.Size(124, 20);
			this.mobjTxtHeight.TabIndex = 1;
			// 
			// PageEditView
			// 
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Size = new System.Drawing.Size(689, 1104);
			this.Text = "PageEditView";
			this.Controls.SetChildIndex(this.mobjPanelContent, 0);
			this.mobjPanelContent.ResumeLayout(false);
			this.mobjGroupResources.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private GroupBox mobjGroupResources;
        private ResourcesEditView mobjResourcesEditView;
        private GroupBox groupBox1;
        private InspectorEditView mobjInspectorEditView;
		private GroupBox groupBox2;
		private Label label1;
		private TextBox mobjTxtHeight;
		private Button objCmdHelp;




    }
}
