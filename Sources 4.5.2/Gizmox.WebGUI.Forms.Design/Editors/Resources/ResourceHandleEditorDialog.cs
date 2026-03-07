#region Using

using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using WinForms = System.Windows.Forms;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Forms.Design.Editors.Resources.Objects;
using Gizmox.WebGUI.Forms;


#endregion

namespace Gizmox.WebGUI.Common.Design
{
    /// <summary>
    /// This class implements the ResourceHandleEditor UI
    /// </summary>
    
    internal class ResourceHandleEditorDialog : System.Windows.Forms.Form
    {

        #region Class Members

        private System.Windows.Forms.Label mobjLabelFileName;
        private System.Windows.Forms.Label mobjLabelFilesOfType;
        internal System.Windows.Forms.Button mobjButtonOK;
        private System.Windows.Forms.Button mobjButtonCancel;

        private Hashtable mobjFileIcons = new Hashtable();

        private ResourceHandle mobjResourceHandle = null;
        private System.Windows.Forms.Panel mobjPanelRightBottom;
        private System.Windows.Forms.ComboBox mobjComboFileType;
        private System.Windows.Forms.ComboBox mobjComboFileName;
        private System.Windows.Forms.Panel mobjPanelSpace;
        internal System.Windows.Forms.TreeView mobjTreeView;
        internal System.Windows.Forms.ListView mobjListView;


        #endregion
        private System.Windows.Forms.ImageList mobjItemImages;
        private System.Windows.Forms.ImageList mobjFolderImages;
        private IContainer components;
        private System.Windows.Forms.ColumnHeader columnHeader1;

        private IClientDesignServices mobjContext;

        /// <summary>
        /// 
        /// </summary>
        private static string mstrLastSelectedImage = string.Empty;

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ResourceHandleEditorDialog"/> instance.
        /// </summary>
        internal ResourceHandleEditorDialog()
        {

            InitializeComponent();


        }

        /// <summary>
        /// Creates a new <see cref="ResourceHandleEditorDialog"/> instance.
        /// </summary>
        /// <param name="objResourceHandle">Resource handle.</param>
        /// <param name="blnFixed">Fixed type.</param>
        internal ResourceHandleEditorDialog(ResourceHandle objResourceHandle, IClientDesignServices objContext)
        {
            InitializeComponent();

            // Set local resource handle
            mobjResourceHandle = objResourceHandle;

            mobjContext = objContext;



        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceHandleEditorDialog));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Directories");
            this.mobjListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.mobjItemImages = new System.Windows.Forms.ImageList(this.components);
            this.mobjPanelRightBottom = new System.Windows.Forms.Panel();
            this.mobjButtonCancel = new System.Windows.Forms.Button();
            this.mobjComboFileType = new System.Windows.Forms.ComboBox();
            this.mobjButtonOK = new System.Windows.Forms.Button();
            this.mobjComboFileName = new System.Windows.Forms.ComboBox();
            this.mobjLabelFilesOfType = new System.Windows.Forms.Label();
            this.mobjLabelFileName = new System.Windows.Forms.Label();
            this.mobjTreeView = new System.Windows.Forms.TreeView();
            this.mobjFolderImages = new System.Windows.Forms.ImageList(this.components);
            this.mobjPanelSpace = new System.Windows.Forms.Panel();
            this.mobjPanelRightBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListView
            // 
            this.mobjListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.mobjListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(169, 10);
            this.mobjListView.MultiSelect = false;
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(313, 232);
            this.mobjListView.SmallImageList = this.mobjItemImages;
            this.mobjListView.TabIndex = 1;
            this.mobjListView.UseCompatibleStateImageBehavior = false;
            this.mobjListView.View = System.Windows.Forms.View.List;
            this.mobjListView.SelectedIndexChanged += new System.EventHandler(this.mobjListView_SelectedIndexChanged);
            this.mobjListView.DoubleClick += new System.EventHandler(this.mobjListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // mobjItemImages
            // 
            this.mobjItemImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mobjItemImages.ImageStream")));
            this.mobjItemImages.TransparentColor = System.Drawing.Color.Transparent;
            this.mobjItemImages.Images.SetKeyName(0, "Class.gif");
            // 
            // mobjPanelRightBottom
            // 
            this.mobjPanelRightBottom.Controls.Add(this.mobjButtonCancel);
            this.mobjPanelRightBottom.Controls.Add(this.mobjComboFileType);
            this.mobjPanelRightBottom.Controls.Add(this.mobjButtonOK);
            this.mobjPanelRightBottom.Controls.Add(this.mobjComboFileName);
            this.mobjPanelRightBottom.Controls.Add(this.mobjLabelFilesOfType);
            this.mobjPanelRightBottom.Controls.Add(this.mobjLabelFileName);
            this.mobjPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mobjPanelRightBottom.Location = new System.Drawing.Point(10, 242);
            this.mobjPanelRightBottom.Name = "mobjPanelRightBottom";
            this.mobjPanelRightBottom.Size = new System.Drawing.Size(472, 64);
            this.mobjPanelRightBottom.TabIndex = 2;
            // 
            // mobjButtonCancel
            // 
            this.mobjButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mobjButtonCancel.Location = new System.Drawing.Point(384, 40);
            this.mobjButtonCancel.Name = "mobjButtonCancel";
            this.mobjButtonCancel.Size = new System.Drawing.Size(88, 23);
            this.mobjButtonCancel.TabIndex = 3;
            this.mobjButtonCancel.Text = "Cancel";
            this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
            // 
            // mobjComboFileType
            // 
            this.mobjComboFileType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjComboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboFileType.Items.AddRange(new object[] {
            "*.gif",
            "*.jpg",
            "*.png",
            "*.*"});
            this.mobjComboFileType.Location = new System.Drawing.Point(112, 41);
            this.mobjComboFileType.Name = "mobjComboFileType";
            this.mobjComboFileType.Size = new System.Drawing.Size(261, 21);
            this.mobjComboFileType.TabIndex = 1;
            this.mobjComboFileType.SelectedIndexChanged += new System.EventHandler(this.mobjComboFileType_SelectedIndexChanged);
            // 
            // mobjButtonOK
            // 
            this.mobjButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonOK.Location = new System.Drawing.Point(384, 12);
            this.mobjButtonOK.Name = "mobjButtonOK";
            this.mobjButtonOK.Size = new System.Drawing.Size(88, 23);
            this.mobjButtonOK.TabIndex = 2;
            this.mobjButtonOK.Text = "OK";
            this.mobjButtonOK.Click += new System.EventHandler(this.mobjButtonOK_Click);
            // 
            // mobjComboFileName
            // 
            this.mobjComboFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjComboFileName.Location = new System.Drawing.Point(112, 13);
            this.mobjComboFileName.Name = "mobjComboFileName";
            this.mobjComboFileName.Size = new System.Drawing.Size(261, 21);
            this.mobjComboFileName.TabIndex = 0;
            this.mobjComboFileName.TextChanged += new System.EventHandler(this.mobjComboFileName_TextChanged);
            // 
            // mobjLabelFilesOfType
            // 
            this.mobjLabelFilesOfType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mobjLabelFilesOfType.Location = new System.Drawing.Point(8, 36);
            this.mobjLabelFilesOfType.Name = "mobjLabelFilesOfType";
            this.mobjLabelFilesOfType.Size = new System.Drawing.Size(100, 23);
            this.mobjLabelFilesOfType.TabIndex = 1;
            this.mobjLabelFilesOfType.Text = "Files of type:";
            this.mobjLabelFilesOfType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLabelFileName
            // 
            this.mobjLabelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mobjLabelFileName.Location = new System.Drawing.Point(8, 12);
            this.mobjLabelFileName.Name = "mobjLabelFileName";
            this.mobjLabelFileName.Size = new System.Drawing.Size(100, 23);
            this.mobjLabelFileName.TabIndex = 0;
            this.mobjLabelFileName.Text = "File name:";
            this.mobjLabelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.mobjTreeView.ImageIndex = 0;
            this.mobjTreeView.ImageList = this.mobjFolderImages;
            this.mobjTreeView.Location = new System.Drawing.Point(10, 10);
            this.mobjTreeView.Name = "mobjTreeView";
            treeNode1.Name = "mobjDirectoriesNode";
            treeNode1.Text = "Directories";
            this.mobjTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.mobjTreeView.SelectedImageIndex = 0;
            this.mobjTreeView.ShowRootLines = false;
            this.mobjTreeView.Size = new System.Drawing.Size(153, 232);
            this.mobjTreeView.TabIndex = 0;
            this.mobjTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mobjTreeView_AfterSelect);
            // 
            // mobjFolderImages
            // 
            this.mobjFolderImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mobjFolderImages.ImageStream")));
            this.mobjFolderImages.TransparentColor = System.Drawing.Color.Transparent;
            this.mobjFolderImages.Images.SetKeyName(0, "Folder.gif");
            // 
            // mobjPanelSpace
            // 
            this.mobjPanelSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.mobjPanelSpace.Location = new System.Drawing.Point(163, 10);
            this.mobjPanelSpace.Name = "mobjPanelSpace";
            this.mobjPanelSpace.Size = new System.Drawing.Size(6, 232);
            this.mobjPanelSpace.TabIndex = 6;
            // 
            // ResourceHandleEditorDialog
            // 
            this.AcceptButton = this.mobjButtonOK;            
            this.CancelButton = this.mobjButtonCancel;
            this.ClientSize = new System.Drawing.Size(492, 316);
            this.Controls.Add(this.mobjListView);
            this.Controls.Add(this.mobjPanelSpace);
            this.Controls.Add(this.mobjTreeView);
            this.Controls.Add(this.mobjPanelRightBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "ResourceHandleEditorDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Resource";
            this.Load += new System.EventHandler(this.ResourceHandleEditorDialog_Load);
            this.mobjPanelRightBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Events

        private void mobjButtonOK_Click(object sender, System.EventArgs e)
        {

            string strResource = mobjComboFileName.Text;
            ResourceHandleConverter objResourceHandleConverter = new ResourceHandleConverter();
            ResourceHandle objHandle = objResourceHandleConverter.ConvertFromString(strResource) as ResourceHandle;
            if (objHandle != null)
            {
                mobjResourceHandle = objHandle;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        private void mobjButtonCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets or sets the handle.
        /// </summary>
        /// <value></value>
        new internal ResourceHandle Handle
        {
            get
            {
                return mobjResourceHandle;
            }
            set
            {
                mobjResourceHandle = value;
            }
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <value></value>
        internal string File
        {
            get
            {
                return mobjResourceHandle.File;
            }
        }

        #endregion

        private void ResourceHandleEditorDialog_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.TreeNode objDirectories = this.mobjTreeView.Nodes[0];
            ResourceDirectoryRootNode objNode;

            DirectoryInfo objIconsDir = GetDirectory("Icons");
            if (objIconsDir != null)
            {
                objNode = new ResourceDirectoryRootNode(objIconsDir, "Icons");
                objNode.Name = "Icons";
                objDirectories.Nodes.Add(objNode);
                objNode.ImageIndex = 0;
                BuildFolderList(objNode);
            }

            DirectoryInfo objImagesDir = GetDirectory("Images");
            if (objImagesDir != null)
            {
                objNode = new ResourceDirectoryRootNode(objImagesDir, "Images");
                objNode.Name = "Images";
                objDirectories.Nodes.Add(objNode);
                objNode.ImageIndex = 0;
                BuildFolderList(objNode);
            }
            mobjComboFileType.SelectedItem = "*.*";

            objDirectories.Expand();

            //If another icon has already been selected by the Editor()
            if (!string.IsNullOrEmpty(mstrLastSelectedImage))
            {
                //Open the previous location
                OpenLastNode(); 
            }
            
        }


        private DirectoryInfo GetDirectory(string strName)
        {
            string strDir = mobjContext.GetNamedDirecotry(strName);
            if (Directory.Exists(strDir))
            {
                return new DirectoryInfo(strDir);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDirectoryNode"></param>
        private void BuildFolderList(ResourceDirectoryNode objDirectoryNode)
        {
            mobjTreeView.BeginUpdate();
            GetFolders(objDirectoryNode);
            mobjTreeView.EndUpdate();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDirectoryNode"></param>
        private void GetFolders(ResourceDirectoryNode objDirectoryNode)
        {

            // foreach of the root nodes in objDirectories
            foreach (DirectoryInfo objDirInfo in objDirectoryNode.SubDirectories)
            {
                ResourceDirectoryNode objSubDirNode = new ResourceDirectoryNode(objDirInfo, objDirInfo.Name);
                objSubDirNode.Name = objDirInfo.Name;
                objDirectoryNode.Nodes.Add(objSubDirNode);
                objSubDirNode.ImageIndex = 0;
                GetFolders(objSubDirNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mobjTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            ResourceDirectoryNode objResourceDirectoryNode = null;

            if (e.Node is ResourceDirectoryNode)
            {
                if (e.Node != null)                
                {
                    objResourceDirectoryNode = e.Node as ResourceDirectoryNode;
                }
            }

            DrawListView(objResourceDirectoryNode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objNode"></param>
        private void DrawListView(ResourceDirectoryNode objNode)
        {
            mobjListView.Items.Clear();

            if (objNode != null)
            {
	            ResourceDirectoryNode objResourceDirectoryNode = objNode as ResourceDirectoryNode;
	            if (objResourceDirectoryNode == null)
	            {
    	            return;
	            }

    	        FileInfo[] arrFileInfo = objResourceDirectoryNode.GetItems((string)mobjComboFileType.SelectedItem);
	            
	            if (arrFileInfo != null && arrFileInfo.Length != 0)
	            {
	                mobjButtonOK.Enabled = false;
	                mobjListView.BeginUpdate();

    	            ResourceDirectoryNode objTempResourceDirectoryNode = null;

	                foreach (FileInfo objFileInfo in arrFileInfo)
    	            {
        	            if (mobjTreeView.SelectedNode != null)
	                    {
	                        objTempResourceDirectoryNode = mobjTreeView.SelectedNode as ResourceDirectoryNode;
	                        if (objTempResourceDirectoryNode != null)
	                        {
	                            ResourceDirectoryItem objListItem = new ResourceDirectoryItem(objTempResourceDirectoryNode, objFileInfo.Name);
    	                        objListItem.ImageIndex = GetFileIcon(objFileInfo);
	                            mobjListView.Items.Add(objListItem);
	                        }
    	                }
	                }
    	            mobjListView.EndUpdate();
        	    }
			}
        }

        private int GetFileIcon(FileInfo objFileInfo)
        {
            int intFileIndex = 0;
            if (mobjFileIcons.Contains(objFileInfo.Extension))
            {
                intFileIndex = (int)mobjFileIcons[objFileInfo.Extension];
            }
            else
            {
                Icon objFileIcon = ResourceHandleIconReader.GetFileIcon(objFileInfo.FullName, ResourceHandleIconReader.EnumIconSize.Small, false);
                mobjItemImages.Images.Add(objFileIcon);
                intFileIndex = mobjItemImages.Images.Count - 1;
                mobjFileIcons.Add(objFileInfo.Extension, intFileIndex);
            }
            return intFileIndex;
        }

        private void mobjComboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjTreeView != null && mobjTreeView.SelectedNode != null)
            {
                ResourceDirectoryNode objResourceDirectoryNode = mobjTreeView.SelectedNode as ResourceDirectoryNode;
                if (objResourceDirectoryNode != null)
                {
                    DrawListView(objResourceDirectoryNode);
                }
            }
        }

        private void mobjComboFileName_TextChanged(object sender, EventArgs e)
        {
            // verify that text is in valid ResourceHandle format
            string strResource = ((WinForms.ComboBox)sender).Text;
            ResourceHandleConverter objResourceHandleConverter = new ResourceHandleConverter();

            ResourceHandle objResourceHandle = objResourceHandleConverter.ConvertFromString(strResource) as ResourceHandle;

            if (objResourceHandle != null)
            {
                mobjButtonOK.Enabled = true;
            }
            else
            {
                mobjButtonOK.Enabled = false;
            }
        }

        private void mobjListView_DoubleClick(object sender, EventArgs e)
        {
            if (mobjListView.SelectedItems.Count > 0)
            {
                ResourceDirectoryItem objItem = mobjListView.SelectedItems[0] as ResourceDirectoryItem;
                if (objItem != null)
                {
                    mobjResourceHandle = objItem.Handle;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjListView.SelectedIndices.Count > 0)
            {
                this.mobjButtonOK.Enabled = true;

                //Save the last selected image
                mstrLastSelectedImage = ((ResourceDirectoryItem)(mobjListView.SelectedItems[0])).Handle;
                mobjComboFileName.Text = mstrLastSelectedImage;

            }
        }

        /// <summary>
        /// Opens the last selected node.
        /// </summary>
        private void OpenLastNode()
        {
            WinForms.TreeNode objNode = null;
            string[] arrDirectories = new string[] { };

            //Get the list of directories the tree nodes 
            arrDirectories = mstrLastSelectedImage.Split('.');

            objNode = mobjTreeView.TopNode;
            for (int i = 0; i < arrDirectories.GetUpperBound(0)-1; i++)
            {
                if (objNode != null)
                {
                    //Expand each node
                    objNode.Expand();

                    //Set the current node
                    objNode = objNode.Nodes[arrDirectories.GetValue(i).ToString()];
                }
            }

            if (objNode != null)
            {
                //Expand the last node
                objNode.Expand();

                //Select it
                mobjTreeView.SelectedNode = objNode;

                //Fill the items in the list view
                DrawListView((ResourceDirectoryNode)objNode);
            }
        }
        
	}
}
