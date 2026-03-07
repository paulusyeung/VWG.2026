using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Security.Permissions;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using System.IO;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Prompts the user to select a folder. 
    /// This class can be inherited to provide default data source.
    /// </summary>
    /// <remarks>By default this dialog works on server side folders.</remarks>
    [DefaultEvent("HelpRequest"), SRDescription("DescriptionFolderBrowserDialog"), DefaultProperty("SelectedPath")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(FolderBrowserDialog), "FolderBrowserDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(FolderBrowserDialog), "FolderBrowserDialog.bmp")]
#endif
    [ToolboxItem(true), Skins.Skin(typeof(Skins.FolderBrowserDialogSkin)), Serializable()]
    public class FolderBrowserDialog : CommonDialog
    {

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        protected class FolderBrowserDialogForm : CommonDialogForm
        {

            #region Class Members

            private Button mobjButtonCancel;
            private Button mobjButtonCreate;
            private Button mobjButtonOK;
            private Label mobjLabelDescription;
            private TreeView mobjTreeFolders;

            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer objComponents = null;

            #endregion

            #region C'Tors \ D'Tors

            /// <summary>
            /// Initializes a new instance of the <see cref="FolderBrowserDialogForm"/> class.
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public FolderBrowserDialogForm(CommonDialog objCommonDialog)
                : base(objCommonDialog)
            {
                InitializeComponent();
            }

            #endregion

            /// <summary>
            /// Gets the folder browser dialog owner.
            /// </summary>
            /// <value>The folder browser dialog owner.</value>
            public FolderBrowserDialog FolderBrowserDialogOwner
            {
                get
                {
                    return (FolderBrowserDialog)this.CommonDialogOwner;
                }
            }

            #region Methods

            #region Private Methods

            void FolderBrowserDialogForm_Load(object sender, EventArgs e)
            {
                this.mobjLabelDescription.Text = this.FolderBrowserDialogOwner.Description;
                this.mobjButtonCreate.Visible = this.FolderBrowserDialogOwner.ShowNewFolderButton;
                this.Text = this.FolderBrowserDialogOwner.Title;

                // Create root folder
                this.mobjTreeFolders.Nodes.Add(CreateFolderNode(this.FolderBrowserDialogOwner.GetRootFolder()));
                this.mobjTreeFolders.Nodes[0].Expand();
            }

            private TreeNode CreateFolderNode(object objFolder)
            {
                bool blnHasNodes = this.FolderBrowserDialogOwner.HasSubFolders(objFolder);

                TreeNode objTreeNode = new TreeNode();
                objTreeNode.Text = this.FolderBrowserDialogOwner.GetFolderLabel(objFolder);
                objTreeNode.Image = this.FolderBrowserDialogOwner.GetFolderIcon(objFolder);
                objTreeNode.Loaded = !blnHasNodes;
                objTreeNode.HasNodes = blnHasNodes;
                objTreeNode.IsExpanded = !blnHasNodes;
                objTreeNode.BeforeExpand += new TreeViewCancelEventHandler(objTreeNode_BeforeExpand);
                objTreeNode.Tag = objFolder;

                return objTreeNode;
            }

            private void CreateFolderNodes(TreeNode objTreeNode)
            {
                ICollection objFolders = this.FolderBrowserDialogOwner.GetSubFolders(objTreeNode.Tag);

                foreach (object objFolder in objFolders)
                {
                    objTreeNode.Nodes.Add(CreateFolderNode(objFolder));
                }
            }

            void objTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
            {
                if (!objArgs.Node.Loaded)
                {
                    CreateFolderNodes(objArgs.Node);
                    objArgs.Node.Loaded = true;
                }
            }

            void mobjTreeFolders_DoubleClick(object sender, EventArgs e)
            {
                this.DoOK();
            }

            void mobjTreeFolders_AfterSelect(object sender, TreeViewEventArgs e)
            {

            }

            private void mobjButtonCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private void mobjButtonCreate_Click(object sender, EventArgs e)
            {

            }

            private void mobjButtonOK_Click(object sender, EventArgs e)
            {
                this.DoOK();
            }

            private void DoOK()
            {
                if (this.mobjTreeFolders.SelectedNode != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.FolderBrowserDialogOwner.SelectedPath = this.FolderBrowserDialogOwner.GetFolderPath(this.mobjTreeFolders.SelectedNode.Tag);
                    this.Close();
                }
            }

            #endregion

            #endregion

            #region WebGUI Designer generated code

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="blnDisposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool blnDisposing)
            {
                if (blnDisposing && (objComponents != null))
                {
                    objComponents.Dispose();
                }
                base.Dispose(blnDisposing);
            }

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjTreeFolders = new TreeView();
                this.mobjButtonCancel = new Button();
                this.mobjButtonOK = new Button();
                this.mobjButtonCreate = new Button();
                this.mobjLabelDescription = new Label();
                this.SuspendLayout();
                // 
                // mobjTreeFolders
                // 
                this.mobjTreeFolders.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                            | AnchorStyles.Left)
                            | AnchorStyles.Right)));
                this.mobjTreeFolders.Location = new System.Drawing.Point(12, 61);
                this.mobjTreeFolders.Name = "mobjTreeFolders";
                this.mobjTreeFolders.Size = new System.Drawing.Size(306, 230);
                this.mobjTreeFolders.TabIndex = 0;
                this.mobjTreeFolders.AfterSelect += new TreeViewEventHandler(mobjTreeFolders_AfterSelect);
                this.mobjTreeFolders.DoubleClick += new EventHandler(mobjTreeFolders_DoubleClick);
                // 
                // mobjButtonCancel
                // 
                this.mobjButtonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                this.mobjButtonCancel.Location = new System.Drawing.Point(243, 302);
                this.mobjButtonCancel.Name = "mobjButtonCancel";
                this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
                this.mobjButtonCancel.TabIndex = 1;
                this.mobjButtonCancel.Text = WGLabels.Cancel;
                this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
                // 
                // mobjButtonOK
                // 
                this.mobjButtonOK.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                this.mobjButtonOK.Location = new System.Drawing.Point(163, 302);
                this.mobjButtonOK.Name = "mobjButtonOK";
                this.mobjButtonOK.Size = new System.Drawing.Size(75, 23);
                this.mobjButtonOK.TabIndex = 2;
                this.mobjButtonOK.Text = WGLabels.Ok;
                this.mobjButtonOK.Click += new System.EventHandler(this.mobjButtonOK_Click);
                // 
                // mobjButtonCreate
                // 
                this.mobjButtonCreate.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
                this.mobjButtonCreate.Location = new System.Drawing.Point(12, 302);
                this.mobjButtonCreate.Name = "mobjButtonCreate";
                this.mobjButtonCreate.Size = new System.Drawing.Size(109, 23);
                this.mobjButtonCreate.TabIndex = 3;
                this.mobjButtonCreate.Text = WGLabels.MakeNewFolder;
                this.mobjButtonCreate.Click += new System.EventHandler(this.mobjButtonCreate_Click);
                // 
                // mobjLabelDescription
                // 
                this.mobjLabelDescription.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                            | AnchorStyles.Right)));
                this.mobjLabelDescription.Location = new System.Drawing.Point(13, 13);
                this.mobjLabelDescription.Name = "mobjLabelDescription";
                this.mobjLabelDescription.Size = new System.Drawing.Size(305, 45);
                this.mobjLabelDescription.TabIndex = 4;
                this.mobjLabelDescription.Text = "Description";
                // 
                // Form2
                // 
                this.ClientSize = new System.Drawing.Size(332, 337);
                this.Controls.Add(this.mobjLabelDescription);
                this.Controls.Add(this.mobjButtonCreate);
                this.Controls.Add(this.mobjButtonOK);
                this.Controls.Add(this.mobjButtonCancel);
                this.Controls.Add(this.mobjTreeFolders);
                this.Load += new EventHandler(FolderBrowserDialogForm_Load);
                this.Name = "Form2";
                this.Text = "FolderBrowserDialog";
                this.ResumeLayout(false);

            }

            #endregion
        }

        #region Class Members

        /// <summary>
        /// 
        /// </summary>
        private bool mblnSelectedPathNeedsCheck;

        /// <summary>
        /// 
        /// </summary>
        private Environment.SpecialFolder menmRootFolder;

        /// <summary>
        /// 
        /// </summary>
        private bool msblShowNewFolderButton;

        /// <summary>
        /// 
        /// </summary>
        private string mstrDescriptionText;

        /// <summary>
        /// 
        /// </summary>
        private string mstrSelectedPath;

        /// <summary>
        /// 
        /// </summary>
        private string mstrTitle;

        /// <summary>Occurs when the user clicks the Help button on the dialog box.</summary>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        new public event EventHandler HelpRequest;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FolderBrowserDialog"></see> class.
        /// </summary>
        public FolderBrowserDialog()
        {
            this.Reset();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the file dialog box title.</summary>
        /// <returns>The file dialog box title. The default value is an empty string ("").</returns>
        [DefaultValue(""), Localizable(true), SRDescription("FDtitleDescr"), SRCategory("CatAppearance")]
        public string Title
        {
            get
            {
                if (this.mstrTitle != null)
                {
                    return this.mstrTitle;
                }
                return string.Empty;
            }
            set
            {
                this.mstrTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog box.
        /// </summary>
        /// <returns>
        /// The description to display. The default is an empty string ("").
        /// </returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(""), SRCategory("CatFolderBrowsing"), Browsable(true), Localizable(true), SRDescription("FolderBrowserDialogDescription")]
        public string Description
        {
            get
            {
                return this.mstrDescriptionText;
            }
            set
            {
                this.mstrDescriptionText = (value == null) ? string.Empty : value;
            }
        }

        /// <summary>
        /// Gets or sets the root folder where the browsing starts from.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Environment.SpecialFolder"></see> values. The default is Desktop.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
        /// The value assigned is not one of the <see cref="T:System.Environment.SpecialFolder"></see> values.
        /// </exception>
        [SRDescription("FolderBrowserDialogRootFolder"), Browsable(true), DefaultValue(0), Localizable(false), SRCategory("CatFolderBrowsing")]
        public Environment.SpecialFolder RootFolder
        {
            get
            {
                return this.menmRootFolder;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Environment.SpecialFolder), value))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(Environment.SpecialFolder));
                }
                this.menmRootFolder = value;
            }
        }

        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        /// <returns>
        /// The path of the folder first selected in the dialog box or the last folder selected by the user. 
        /// The default is an empty string ("").
        /// </returns>
        [DefaultValue(""), Browsable(true), SRCategory("CatFolderBrowsing"), SRDescription("FolderBrowserDialogSelectedPath"), Localizable(true)]
        public string SelectedPath
        {
            get
            {
                return this.mstrSelectedPath;
            }
            set
            {
                this.mstrSelectedPath = (value == null) ? string.Empty : value;

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the New Folder button 
        /// appears in the folder browser dialog box.
        /// </summary>
        /// <returns>
        /// true if the New Folder button is shown in the dialog box; 
        /// otherwise, false. The default is true.
        /// </returns>
        [DefaultValue(true), SRDescription("FolderBrowserDialogShowNewFolderButton"), Localizable(false), SRCategory("CatFolderBrowsing"), Browsable(true)]
        public bool ShowNewFolderButton
        {
            get
            {
                return this.msblShowNewFolderButton;
            }
            set
            {
                this.msblShowNewFolderButton = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Resets properties to their default values.
        /// </summary>
        public override void Reset()
        {
            this.menmRootFolder = Environment.SpecialFolder.Desktop;
            this.mstrDescriptionText = string.Empty;
            this.mstrSelectedPath = string.Empty;
            this.mblnSelectedPathNeedsCheck = false;
            this.msblShowNewFolderButton = true;
        }

        /// <summary>
        /// Create the folder browser dialog form
        /// </summary>
        /// <returns></returns>
        protected override CommonDialogForm CreateForm()
        {
            return new FolderBrowserDialogForm(this);
        }

        #endregion

        #region Data provider methods

        /// <summary>
        /// Gets the root folder.
        /// </summary>
        /// <returns></returns>
        protected virtual object GetRootFolder()
        {
            return new DirectoryInfo(Environment.GetFolderPath(this.menmRootFolder));
        }

        /// <summary>
        /// Gets the folder icon.
        /// </summary>
        /// <param name="objFolder">The folder object.</param>
        /// <returns></returns>
        protected virtual ResourceHandle GetFolderIcon(object objFolder)
        {
            return new SkinResourceHandle(this.Skin, "Folder.gif");
        }

        /// <summary>
        /// Gets the folder label.
        /// </summary>
        /// <param name="objFolder">The folder object.</param>
        /// <returns></returns>
        protected virtual string GetFolderLabel(object objFolder)
        {
            DirectoryInfo objDirectory = objFolder as DirectoryInfo;
            if (objDirectory != null)
            {
                return objDirectory.Name;
            }
            else
            {
                return "Uknown";
            }
        }

        /// <summary>
        /// Gets the sub folders of the current folder.
        /// </summary>
        /// <param name="objFolder">The current folder.</param>
        /// <returns></returns>
        protected virtual ICollection GetSubFolders(object objFolder)
        {
            DirectoryInfo objDirectory = objFolder as DirectoryInfo;
            if (objDirectory != null)
            {
                return objDirectory.GetDirectories();
            }
            else
            {
                return new object[] { };
            }
        }

        /// <summary>
        /// Determines whether the specified folder has sub folders.
        /// </summary>
        /// <param name="objFolder">The obj folder.</param>
        /// <returns>
        /// 	<c>true</c> if specified folder has sub folders; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool HasSubFolders(object objFolder)
        {
            return GetSubFolders(objFolder).Count > 0;
        }

        /// <summary>
        /// Gets the folder path.
        /// </summary>
        /// <param name="objFolder">The folder to get its path.</param>
        /// <returns></returns>
        protected virtual string GetFolderPath(object objFolder)
        {
            DirectoryInfo objDirectory = objFolder as DirectoryInfo;
            if (objDirectory != null)
            {
                return objDirectory.FullName;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #endregion

    }
}
