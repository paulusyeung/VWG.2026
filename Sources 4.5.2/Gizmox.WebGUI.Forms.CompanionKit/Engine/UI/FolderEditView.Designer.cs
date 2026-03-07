namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class FolderEditView
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
			this.mobjElementsEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.ElementsEditView();
			this.mobjLblDefaultItem = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmbDefaultItem = new Gizmox.WebGUI.Forms.CompanionKit.UI.NavigationCombo();
			this.mobjChkLobbyLike = new Gizmox.WebGUI.Forms.CheckBox();
			this.lblLobbyElelements = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.mobjResourcesEditView = new Gizmox.WebGUI.Forms.CompanionKit.UI.ResourcesEditView();
			this.mobjGroupResources = new Gizmox.WebGUI.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.mobjGroupResources.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjPanelContent
			// 
			this.mobjPanelContent.Size = new System.Drawing.Size(771, 10);
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
			// mobjElementsEditView
			// 
			this.mobjElementsEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjElementsEditView.Location = new System.Drawing.Point(10, 81);
			this.mobjElementsEditView.Name = "elementsEditView1";
			this.mobjElementsEditView.Size = new System.Drawing.Size(667, 199);
			this.mobjElementsEditView.TabIndex = 3;
			this.mobjElementsEditView.Text = "ElementsEditView";
			// 
			// mobjLblDefaultItem
			// 
			this.mobjLblDefaultItem.AutoSize = true;
			this.mobjLblDefaultItem.Location = new System.Drawing.Point(13, 46);
			this.mobjLblDefaultItem.Name = "mobjLblDefaultItem";
			this.mobjLblDefaultItem.Size = new System.Drawing.Size(69, 13);
			this.mobjLblDefaultItem.TabIndex = 0;
			this.mobjLblDefaultItem.Text = "Default item:";
			// 
			// mobjCmbDefaultItem
			// 
			this.mobjCmbDefaultItem.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjCmbDefaultItem.FoldersOnly = false;
			this.mobjCmbDefaultItem.IncludeRoot = false;
			this.mobjCmbDefaultItem.Location = new System.Drawing.Point(94, 42);
			this.mobjCmbDefaultItem.MaxDropDownItems = 8;
			this.mobjCmbDefaultItem.Name = "mobjCmbDefaultItem";
			this.mobjCmbDefaultItem.Size = new System.Drawing.Size(192, 21);
			this.mobjCmbDefaultItem.TabIndex = 1;
			// 
			// mobjChkLobbyLike
			// 
			this.mobjChkLobbyLike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.mobjChkLobbyLike.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjChkLobbyLike.Location = new System.Drawing.Point(11, 20);
			this.mobjChkLobbyLike.Name = "mobjChkLobbyLike";
			this.mobjChkLobbyLike.Size = new System.Drawing.Size(98, 19);
			this.mobjChkLobbyLike.TabIndex = 2;
			this.mobjChkLobbyLike.Text = "Lobby like:";
			this.mobjChkLobbyLike.CheckedChanged += new System.EventHandler(this.mobjChkLobbyLike_CheckedChanged);
			// 
			// lblLobbyElelements
			// 
			this.lblLobbyElelements.Location = new System.Drawing.Point(13, 66);
			this.lblLobbyElelements.Name = "label1";
			this.lblLobbyElelements.Size = new System.Drawing.Size(133, 16);
			this.lblLobbyElelements.TabIndex = 4;
			this.lblLobbyElelements.Text = "Lobby elements:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.mobjElementsEditView);
			this.groupBox1.Controls.Add(this.mobjChkLobbyLike);
			this.groupBox1.Controls.Add(this.mobjLblDefaultItem);
			this.groupBox1.Controls.Add(this.lblLobbyElelements);
			this.groupBox1.Controls.Add(this.mobjCmbDefaultItem);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(3, 477);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(771, 286);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Lobby elements:";
			// 
			// comboBox1
			// 
			this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.comboBox1.Location = new System.Drawing.Point(98, 36);
			this.comboBox1.MaxDropDownItems = 8;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Default item:";
			// 
			// mobjResourcesEditView
			// 
			this.mobjResourcesEditView.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjResourcesEditView.Location = new System.Drawing.Point(5, 19);
			this.mobjResourcesEditView.Name = "mobjResourcesEditView";
			this.mobjResourcesEditView.Size = new System.Drawing.Size(672, 342);
			this.mobjResourcesEditView.TabIndex = 0;
			this.mobjResourcesEditView.Text = "ResourcesEditView";
			// 
			// mobjGroupResources
			// 
			this.mobjGroupResources.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjGroupResources.Controls.Add(this.mobjResourcesEditView);
			this.mobjGroupResources.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjGroupResources.Location = new System.Drawing.Point(3, 772);
			this.mobjGroupResources.Name = "mobjGroupResources";
			this.mobjGroupResources.Size = new System.Drawing.Size(771, 363);
			this.mobjGroupResources.TabIndex = 0;
			this.mobjGroupResources.TabStop = false;
			this.mobjGroupResources.Text = "Resources";
			// 
			// FolderEditView
			// 
			this.Controls.Add(this.mobjGroupResources);
			this.Controls.Add(this.groupBox1);
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Location = new System.Drawing.Point(0, -339);
			this.Size = new System.Drawing.Size(777, 1196);
			this.Text = "FolderEditView";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.mobjPanelContent, 0);
			this.Controls.SetChildIndex(this.mobjGroupResources, 0);
			this.groupBox1.ResumeLayout(false);
			this.mobjGroupResources.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private ElementsEditView mobjElementsEditView;
		private Label mobjLblDefaultItem;
		private NavigationCombo mobjCmbDefaultItem;
		private CheckBox mobjChkLobbyLike;
		private Label lblLobbyElelements;
		private GroupBox groupBox1;
		private Label label2;
		private ComboBox comboBox1;
		private Label label3;
		private ResourcesEditView mobjResourcesEditView;
		private GroupBox mobjGroupResources;



	}
}
