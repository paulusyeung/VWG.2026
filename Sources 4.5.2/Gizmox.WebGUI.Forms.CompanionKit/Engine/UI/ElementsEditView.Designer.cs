namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ElementsEditView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementsEditView));
			this.mobjElementsList = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjButtonNew = new Gizmox.WebGUI.Forms.Button();
			this.monjButtonEdit = new Gizmox.WebGUI.Forms.Button();
			this.monjButtonDelete = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdLobbySettings = new Gizmox.WebGUI.Forms.Button();
			this.mobjGenerate = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdUp = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdDown = new Gizmox.WebGUI.Forms.Button();
			this.mobjMenuGenerate = new Gizmox.WebGUI.Forms.ContextMenu();
			this.mobjMenuFolderOnly = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuRecursively = new Gizmox.WebGUI.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mobjElementsList
			// 
			this.mobjElementsList.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjElementsList.AutoGenerateColumns = false;
			this.mobjElementsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.mobjElementsList.DataMember = null;
			this.mobjElementsList.ItemsPerPage = 20;
			this.mobjElementsList.Location = new System.Drawing.Point(3, 3);
			this.mobjElementsList.Name = "mobjElementsList";
			this.mobjElementsList.ShowItemToolTips = false;
			this.mobjElementsList.Size = new System.Drawing.Size(545, 176);
			this.mobjElementsList.TabIndex = 0;
			this.mobjElementsList.TotalItems = 1;
			this.mobjElementsList.DoubleClick += new System.EventHandler(this.OnButtonEditClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Image = null;
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 306;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Image = null;
			this.columnHeader2.Text = "Image";
			this.columnHeader2.Width = 105;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Image = null;
			this.columnHeader3.Text = "Link";
			this.columnHeader3.Width = 75;
			// 
			// mobjButtonNew
			// 
			this.mobjButtonNew.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjButtonNew.Location = new System.Drawing.Point(579, 3);
			this.mobjButtonNew.Name = "mobjButtonNew";
			this.mobjButtonNew.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonNew.TabIndex = 1;
			this.mobjButtonNew.Text = "Add";
			this.mobjButtonNew.UseVisualStyleBackColor = true;
			this.mobjButtonNew.Click += new System.EventHandler(this.OnButtonNewClick);
			// 
			// monjButtonEdit
			// 
			this.monjButtonEdit.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.monjButtonEdit.Location = new System.Drawing.Point(579, 59);
			this.monjButtonEdit.Name = "monjButtonEdit";
			this.monjButtonEdit.Size = new System.Drawing.Size(75, 23);
			this.monjButtonEdit.TabIndex = 3;
			this.monjButtonEdit.Text = "Edit";
			this.monjButtonEdit.UseVisualStyleBackColor = true;
			this.monjButtonEdit.Click += new System.EventHandler(this.OnButtonEditClick);
			// 
			// monjButtonDelete
			// 
			this.monjButtonDelete.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.monjButtonDelete.Location = new System.Drawing.Point(579, 31);
			this.monjButtonDelete.Name = "monjButtonDelete";
			this.monjButtonDelete.Size = new System.Drawing.Size(75, 23);
			this.monjButtonDelete.TabIndex = 2;
			this.monjButtonDelete.Text = "Remove";
			this.monjButtonDelete.UseVisualStyleBackColor = true;
			this.monjButtonDelete.Click += new System.EventHandler(this.OnButtonDeleteClick);
			// 
			// mobjCmdLobbySettings
			// 
			this.mobjCmdLobbySettings.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdLobbySettings.Location = new System.Drawing.Point(579, 87);
			this.mobjCmdLobbySettings.Name = "mobjCmdLobbySettings";
			this.mobjCmdLobbySettings.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdLobbySettings.TabIndex = 4;
			this.mobjCmdLobbySettings.Text = "Sections";
			this.mobjCmdLobbySettings.UseVisualStyleBackColor = true;
			this.mobjCmdLobbySettings.Click += new System.EventHandler(this.mobjCmdLobbySections_Click);
			// 
			// mobjGenerate
			// 
			this.mobjGenerate.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjGenerate.DropDownMenu = this.mobjMenuGenerate;
			this.mobjGenerate.Location = new System.Drawing.Point(579, 155);
			this.mobjGenerate.Name = "mobjGenerate";
			this.mobjGenerate.Size = new System.Drawing.Size(75, 23);
			this.mobjGenerate.TabIndex = 5;
			this.mobjGenerate.Text = "Generate";
			this.mobjGenerate.UseVisualStyleBackColor = true;
			// 
			// mobjCmdUp
			// 
			this.mobjCmdUp.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdUp.Location = new System.Drawing.Point(564, 120);
			this.mobjCmdUp.Name = "mobjCmdUp";
			this.mobjCmdUp.Size = new System.Drawing.Size(51, 23);
			this.mobjCmdUp.TabIndex = 6;
			this.mobjCmdUp.Text = "Up";
			this.mobjCmdUp.UseVisualStyleBackColor = true;
			this.mobjCmdUp.Click += new System.EventHandler(this.OnButtonUpDown);
			// 
			// mobjCmdDown
			// 
			this.mobjCmdDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdDown.Location = new System.Drawing.Point(618, 120);
			this.mobjCmdDown.Name = "mobjCmdDown";
			this.mobjCmdDown.Size = new System.Drawing.Size(51, 23);
			this.mobjCmdDown.TabIndex = 6;
			this.mobjCmdDown.Text = "Down";
			this.mobjCmdDown.UseVisualStyleBackColor = true;
			this.mobjCmdDown.Click += new System.EventHandler(this.OnButtonUpDown);
			// 
			// mobjMenuGenerate
			// 
			this.mobjMenuGenerate.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuFolderOnly,
            this.mobjMenuRecursively});
			// 
			// mobjMenuFolderOnly
			// 
			this.mobjMenuFolderOnly.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjMenuFolderOnly.Icon"));
			this.mobjMenuFolderOnly.Index = 0;
			this.mobjMenuFolderOnly.Text = "This Folder Only";
			this.mobjMenuFolderOnly.Click += new System.EventHandler(this.OnGenerate_Click);
			// 
			// mobjMenuRecursively
			// 
			this.mobjMenuRecursively.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjMenuRecursively.Icon"));
			this.mobjMenuRecursively.Index = 1;
			this.mobjMenuRecursively.Text = "In depth recursively";
			this.mobjMenuRecursively.Click += new System.EventHandler(this.OnGenerate_Click);
			// 
			// ElementsEditView
			// 
			this.Controls.Add(this.mobjCmdDown);
			this.Controls.Add(this.mobjCmdUp);
			this.Controls.Add(this.mobjGenerate);
			this.Controls.Add(this.mobjCmdLobbySettings);
			this.Controls.Add(this.monjButtonDelete);
			this.Controls.Add(this.monjButtonEdit);
			this.Controls.Add(this.mobjButtonNew);
			this.Controls.Add(this.mobjElementsList);
			this.Size = new System.Drawing.Size(681, 192);
			this.Text = "ElementsEditView";
			this.ResumeLayout(false);

        }

        #endregion

        private ListView mobjElementsList;
        private Button mobjButtonNew;
        private Button monjButtonEdit;
        private Button monjButtonDelete;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private Button mobjCmdLobbySettings;
		private Button mobjGenerate;
		private Button mobjCmdUp;
		private Button mobjCmdDown;
		private ContextMenu mobjMenuGenerate;
		private MenuItem mobjMenuFolderOnly;
		private MenuItem mobjMenuRecursively;


    }
}
