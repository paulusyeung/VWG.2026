namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class LobbyEditView
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
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjElementsEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.ElementsEditView();
			this.mobjResourcesEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.ResourcesEditView();
			this.mobjGroupResources = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjPanelContent.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.mobjGroupResources.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjPanelContent
			// 
			this.mobjPanelContent.Controls.Add(this.mobjGroupResources);
			this.mobjPanelContent.Controls.Add(this.groupBox2);
			this.mobjPanelContent.Size = new System.Drawing.Size(838, 526);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.mobjElementsEditView);
			this.groupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(838, 274);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Elements";
			// 
			// mobjElementsEditView
			// 
			this.mobjElementsEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjElementsEditView.Location = new System.Drawing.Point(5, 20);
			this.mobjElementsEditView.Name = "mobjElementsEditView";
			this.mobjElementsEditView.Size = new System.Drawing.Size(672, 245);
			this.mobjElementsEditView.TabIndex = 0;
			this.mobjElementsEditView.Text = "ElementsEditView";
			// 
			// mobjResourcesEditView
			// 
			this.mobjResourcesEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjResourcesEditView.Location = new System.Drawing.Point(5, 19);
			this.mobjResourcesEditView.Name = "mobjResourcesEditView";
			this.mobjResourcesEditView.Size = new System.Drawing.Size(672, 229);
			this.mobjResourcesEditView.TabIndex = 0;
			this.mobjResourcesEditView.Text = "ResourcesEditView";
			// 
			// mobjGroupResources
			// 
			this.mobjGroupResources.Controls.Add(this.mobjResourcesEditView);
			this.mobjGroupResources.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjGroupResources.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjGroupResources.Location = new System.Drawing.Point(0, 274);
			this.mobjGroupResources.Name = "mobjGroupResources";
			this.mobjGroupResources.Size = new System.Drawing.Size(838, 250);
			this.mobjGroupResources.TabIndex = 0;
			this.mobjGroupResources.TabStop = false;
			this.mobjGroupResources.Text = "Resources";
			// 
			// LobbyEditView
			// 
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Size = new System.Drawing.Size(844, 1074);
			this.Text = "LobbyEditView";
			this.Controls.SetChildIndex(this.mobjPanelContent, 0);
			this.mobjPanelContent.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.mobjGroupResources.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private GroupBox groupBox2;
        private ElementsEditView mobjElementsEditView;
		private GroupBox mobjGroupResources;
		private ResourcesEditView mobjResourcesEditView;


    }
}