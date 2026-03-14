#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Prompts the user to select a folder. 
	/// This class can be inherited to provide default data source.
	/// </summary>
	/// By default this dialog works on server side folders.</remarks>
	[Serializable]
	[DefaultEvent("HelpRequest")]
	[SRDescription("DescriptionFolderBrowserDialog")]
	[DefaultProperty("SelectedPath")]
	[ToolboxBitmap(typeof(FolderBrowserDialog), "FolderBrowserDialog_45.bmp")]
	[ToolboxItem(true)]
	[Skin(typeof(FolderBrowserDialogSkin))]
	public class FolderBrowserDialog : CommonDialog
	{
		/// 
		///
		/// </summary>
		[Serializable]
		protected class FolderBrowserDialogForm : CommonDialogForm
		{
			private Button mobjButtonCancel;

			private Button mobjButtonCreate;

			private Button mobjButtonOK;

			private Label mobjLabelDescription;

			private TreeView mobjTreeFolders;

			/// 
			/// Required designer variable.
			/// </summary>
			private IContainer objComponents = null;

			/// 
			/// Gets the folder browser dialog owner.
			/// </summary>
			/// The folder browser dialog owner.</value>
			public FolderBrowserDialog FolderBrowserDialogOwner => (FolderBrowserDialog)base.CommonDialogOwner;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FolderBrowserDialog.FolderBrowserDialogForm" /> class.
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public FolderBrowserDialogForm(CommonDialog objCommonDialog)
				: base(objCommonDialog)
			{
				InitializeComponent();
			}

			private void FolderBrowserDialogForm_Load(object sender, EventArgs e)
			{
				mobjLabelDescription.Text = FolderBrowserDialogOwner.Description;
				mobjButtonCreate.Visible = FolderBrowserDialogOwner.ShowNewFolderButton;
				Text = FolderBrowserDialogOwner.Title;
				mobjTreeFolders.Nodes.Add(CreateFolderNode(FolderBrowserDialogOwner.GetRootFolder()));
				mobjTreeFolders.Nodes[0].Expand();
			}

			private TreeNode CreateFolderNode(object objFolder)
			{
				bool flag = FolderBrowserDialogOwner.HasSubFolders(objFolder);
				TreeNode treeNode = new TreeNode();
				treeNode.Text = FolderBrowserDialogOwner.GetFolderLabel(objFolder);
				treeNode.Image = FolderBrowserDialogOwner.GetFolderIcon(objFolder);
				treeNode.Loaded = !flag;
				treeNode.HasNodes = flag;
				treeNode.IsExpanded = !flag;
				treeNode.BeforeExpand += objTreeNode_BeforeExpand;
				treeNode.Tag = objFolder;
				return treeNode;
			}

			private void CreateFolderNodes(TreeNode objTreeNode)
			{
				ICollection subFolders = FolderBrowserDialogOwner.GetSubFolders(objTreeNode.Tag);
				foreach (object item in subFolders)
				{
					objTreeNode.Nodes.Add(CreateFolderNode(item));
				}
			}

			private void objTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
			{
				if (!objArgs.Node.Loaded)
				{
					CreateFolderNodes(objArgs.Node);
					objArgs.Node.Loaded = true;
				}
			}

			private void mobjTreeFolders_DoubleClick(object sender, EventArgs e)
			{
				DoOK();
			}

			private void mobjTreeFolders_AfterSelect(object sender, TreeViewEventArgs e)
			{
			}

			private void mobjButtonCancel_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}

			private void mobjButtonCreate_Click(object sender, EventArgs e)
			{
			}

			private void mobjButtonOK_Click(object sender, EventArgs e)
			{
				DoOK();
			}

			private void DoOK()
			{
				if (mobjTreeFolders.SelectedNode != null)
				{
					base.DialogResult = DialogResult.OK;
					FolderBrowserDialogOwner.SelectedPath = FolderBrowserDialogOwner.GetFolderPath(mobjTreeFolders.SelectedNode.Tag);
					Close();
				}
			}

			/// 
			/// Clean up any resources being used.
			/// </summary>
			/// <param name="blnDisposing">true if managed resources should be disposed; otherwise, false.</param>
			protected override void Dispose(bool blnDisposing)
			{
				if (blnDisposing && objComponents != null)
				{
					objComponents.Dispose();
				}
				base.Dispose(blnDisposing);
			}

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				mobjTreeFolders = new TreeView();
				mobjButtonCancel = new Button();
				mobjButtonOK = new Button();
				mobjButtonCreate = new Button();
				mobjLabelDescription = new Label();
				SuspendLayout();
				mobjTreeFolders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				mobjTreeFolders.Location = new Point(12, 61);
				mobjTreeFolders.Name = "mobjTreeFolders";
				mobjTreeFolders.Size = new Size(306, 230);
				mobjTreeFolders.TabIndex = 0;
				mobjTreeFolders.AfterSelect += mobjTreeFolders_AfterSelect;
				mobjTreeFolders.DoubleClick += mobjTreeFolders_DoubleClick;
				mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mobjButtonCancel.Location = new Point(243, 302);
				mobjButtonCancel.Name = "mobjButtonCancel";
				mobjButtonCancel.Size = new Size(75, 23);
				mobjButtonCancel.TabIndex = 1;
				mobjButtonCancel.Text = WGLabels.Cancel;
				mobjButtonCancel.Click += mobjButtonCancel_Click;
				mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mobjButtonOK.Location = new Point(163, 302);
				mobjButtonOK.Name = "mobjButtonOK";
				mobjButtonOK.Size = new Size(75, 23);
				mobjButtonOK.TabIndex = 2;
				mobjButtonOK.Text = WGLabels.Ok;
				mobjButtonOK.Click += mobjButtonOK_Click;
				mobjButtonCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
				mobjButtonCreate.Location = new Point(12, 302);
				mobjButtonCreate.Name = "mobjButtonCreate";
				mobjButtonCreate.Size = new Size(109, 23);
				mobjButtonCreate.TabIndex = 3;
				mobjButtonCreate.Text = WGLabels.MakeNewFolder;
				mobjButtonCreate.Click += mobjButtonCreate_Click;
				mobjLabelDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				mobjLabelDescription.Location = new Point(13, 13);
				mobjLabelDescription.Name = "mobjLabelDescription";
				mobjLabelDescription.Size = new Size(305, 45);
				mobjLabelDescription.TabIndex = 4;
				mobjLabelDescription.Text = "Description";
				base.ClientSize = new Size(332, 337);
				base.Controls.Add(mobjLabelDescription);
				base.Controls.Add(mobjButtonCreate);
				base.Controls.Add(mobjButtonOK);
				base.Controls.Add(mobjButtonCancel);
				base.Controls.Add(mobjTreeFolders);
				base.Load += FolderBrowserDialogForm_Load;
				base.Name = "Form2";
				Text = "FolderBrowserDialog";
				ResumeLayout(blnPerformLayout: false);
			}
		}

		/// 
		///
		/// </summary>
		private bool mblnSelectedPathNeedsCheck;

		/// 
		///
		/// </summary>
		private Environment.SpecialFolder menmRootFolder;

		/// 
		///
		/// </summary>
		private bool msblShowNewFolderButton;

		/// 
		///
		/// </summary>
		private string mstrDescriptionText;

		/// 
		///
		/// </summary>
		private string mstrSelectedPath;

		/// 
		///
		/// </summary>
		private string mstrTitle;

		/// Gets or sets the file dialog box title.</summary>
		/// The file dialog box title. The default value is an empty string ("").</returns>
		[DefaultValue("")]
		[Localizable(true)]
		[SRDescription("FDtitleDescr")]
		[SRCategory("CatAppearance")]
		public string Title
		{
			get
			{
				if (mstrTitle != null)
				{
					return mstrTitle;
				}
				return string.Empty;
			}
			set
			{
				mstrTitle = value;
			}
		}

		/// 
		/// Gets or sets the descriptive text displayed above the tree view control in the dialog box.
		/// </summary>
		/// 
		/// The description to display. The default is an empty string ("").
		/// </returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		[SRCategory("CatFolderBrowsing")]
		[Browsable(true)]
		[Localizable(true)]
		[SRDescription("FolderBrowserDialogDescription")]
		public string Description
		{
			get
			{
				return mstrDescriptionText;
			}
			set
			{
				mstrDescriptionText = ((value == null) ? string.Empty : value);
			}
		}

		/// 
		/// Gets or sets the root folder where the browsing starts from.
		/// </summary>
		/// 
		/// One of the <see cref="T:System.Environment.SpecialFolder"></see> values. The default is Desktop.
		/// </returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
		/// The value assigned is not one of the <see cref="T:System.Environment.SpecialFolder"></see> values.
		/// </exception>
		[SRDescription("FolderBrowserDialogRootFolder")]
		[Browsable(true)]
		[DefaultValue(0)]
		[Localizable(false)]
		[SRCategory("CatFolderBrowsing")]
		public Environment.SpecialFolder RootFolder
		{
			get
			{
				return menmRootFolder;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Environment.SpecialFolder), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(Environment.SpecialFolder));
				}
				menmRootFolder = value;
			}
		}

		/// 
		/// Gets or sets the path selected by the user.
		/// </summary>
		/// 
		/// The path of the folder first selected in the dialog box or the last folder selected by the user. 
		/// The default is an empty string ("").
		/// </returns>
		[DefaultValue("")]
		[Browsable(true)]
		[SRCategory("CatFolderBrowsing")]
		[SRDescription("FolderBrowserDialogSelectedPath")]
		[Localizable(true)]
		public string SelectedPath
		{
			get
			{
				return mstrSelectedPath;
			}
			set
			{
				mstrSelectedPath = ((value == null) ? string.Empty : value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether the New Folder button 
		/// appears in the folder browser dialog box.
		/// </summary>
		/// 
		/// true if the New Folder button is shown in the dialog box; 
		/// otherwise, false. The default is true.
		/// </returns>
		[DefaultValue(true)]
		[SRDescription("FolderBrowserDialogShowNewFolderButton")]
		[Localizable(false)]
		[SRCategory("CatFolderBrowsing")]
		[Browsable(true)]
		public bool ShowNewFolderButton
		{
			get
			{
				return msblShowNewFolderButton;
			}
			set
			{
				msblShowNewFolderButton = value;
			}
		}

		/// Occurs when the user clicks the Help button on the dialog box.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler HelpRequest;

		/// 
		/// Initializes a new instance of the <see cref="T:FolderBrowserDialog"></see> class.
		/// </summary>
		public FolderBrowserDialog()
		{
			Reset();
		}

		/// 
		/// Resets properties to their default values.
		/// </summary>
		public override void Reset()
		{
			menmRootFolder = Environment.SpecialFolder.Desktop;
			mstrDescriptionText = string.Empty;
			mstrSelectedPath = string.Empty;
			mblnSelectedPathNeedsCheck = false;
			msblShowNewFolderButton = true;
		}

		/// 
		/// Create the folder browser dialog form
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new FolderBrowserDialogForm(this);
		}

		/// 
		/// Gets the root folder.
		/// </summary>
		/// </returns>
		protected virtual object GetRootFolder()
		{
			return new DirectoryInfo(Environment.GetFolderPath(menmRootFolder));
		}

		/// 
		/// Gets the folder icon.
		/// </summary>
		/// <param name="objFolder">The folder object.</param>
		/// </returns>
		protected virtual ResourceHandle GetFolderIcon(object objFolder)
		{
			return new SkinResourceHandle(base.Skin, "Folder.gif");
		}

		/// 
		/// Gets the folder label.
		/// </summary>
		/// <param name="objFolder">The folder object.</param>
		/// </returns>
		protected virtual string GetFolderLabel(object objFolder)
		{
			if (!(objFolder is DirectoryInfo { Name: var name }))
			{
				return "Uknown";
			}
			return name;
		}

		/// 
		/// Gets the sub folders of the current folder.
		/// </summary>
		/// <param name="objFolder">The current folder.</param>
		/// </returns>
		protected virtual ICollection GetSubFolders(object objFolder)
		{
			if (objFolder is DirectoryInfo directoryInfo)
			{
				return directoryInfo.GetDirectories();
			}
			return new object[0];
		}

		/// 
		/// Determines whether the specified folder has sub folders.
		/// </summary>
		/// <param name="objFolder">The obj folder.</param>
		/// 
		/// 	true</c> if specified folder has sub folders; otherwise, false</c>.
		/// </returns>
		protected virtual bool HasSubFolders(object objFolder)
		{
			return GetSubFolders(objFolder).Count > 0;
		}

		/// 
		/// Gets the folder path.
		/// </summary>
		/// <param name="objFolder">The folder to get its path.</param>
		/// </returns>
		protected virtual string GetFolderPath(object objFolder)
		{
			if (!(objFolder is DirectoryInfo { FullName: var fullName }))
			{
				return string.Empty;
			}
			return fullName;
		}
	}
}
