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

namespace Gizmox.WebGUI.Forms.Design
{
/// 
	///
	/// </summary>
	[Serializable]
	internal class ServerOpenFileDialog : CommonDialog
	{
		/// 
		///
		/// </summary>
		[Serializable]
		private class ServerOpenFileDialogForm : CommonDialogForm
		{
			/// 
			///
			/// </summary>
			[Serializable]
			private class FilterComboItem
			{
				private string mstrDisplayName;

				private string mstrFilter;

				/// 
				/// Gets the filter.
				/// </summary>
				/// 
				/// The filter.
				/// </value>
				public string Filter => mstrFilter;

				public FilterComboItem(string strDisplayName, string strFilter)
				{
					mstrDisplayName = strDisplayName;
					mstrFilter = strFilter;
				}

				/// 
				/// Returns a <see cref="T:System.String" /> that represents this instance.
				/// </summary>
				/// 
				/// A <see cref="T:System.String" /> that represents this instance.
				/// </returns>
				public override string ToString()
				{
					return mstrDisplayName;
				}
			}

			private string mstrIconsFolder = string.Empty;

			private string mstrImagesFolder = string.Empty;

			private IContainer components = null;

			private Panel mobjPanelControls;

			private ComboBox mobjFilterComboBox;

			private TextBox mobjFileNameTextBox;

			private Label mobjFileNameLabel;

			private Panel mobjFoldersPanel;

			private TreeView mobjFoldersTreeView;

			private Splitter mobjSplitter;

			private Panel mobjFilesPanel;

			private ListView mobjFilesListView;

			private Button mobjOpenButton;

			private Button mobjCancelButton;

			private ColumnHeader mobjNameColumnHeader;

			private ColumnHeader mobjDateColumnHeader;

			private ColumnHeader mobjTypeColumnHeader;

			private ColumnHeader mobjSizeColumnHeader;

			private ContextMenuStrip mobjListViewContextMenuStrip;

			private ToolStripMenuItem mobjViewToolStripMenuItem;

			private ToolStripMenuItem objDetailsToolStripMenuItem;

			private ToolStripMenuItem mobjLargeIconToolStripMenuItem;

			private ToolStripMenuItem mobjListToolStripMenuItem;

			private ToolStripMenuItem mobjSmallIconToolStripMenuItem;

			/// 
			/// Gets the server open file dialog owner.
			/// </summary>
			/// 
			/// The server open file dialog owner.
			/// </value>
			private ServerOpenFileDialog ServerOpenFileDialogOwner => (ServerOpenFileDialog)base.CommonDialogOwner;

			/// 
			/// Gets the filter.
			/// </summary>
			/// 
			/// The filter.
			/// </value>
			private string Filter => ServerOpenFileDialogOwner.Filter;

			/// 
			/// Gets or sets the name of the file.
			/// </summary>
			/// 
			/// The name of the file.
			/// </value>
			private string FileName
			{
				get
				{
					return ServerOpenFileDialogOwner.FileName;
				}
				set
				{
					ServerOpenFileDialogOwner.FileName = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.ServerOpenFileDialog.ServerOpenFileDialogForm" /> class.
			/// </summary>
			/// <param name="objCommonDialog"></param>
			public ServerOpenFileDialogForm(CommonDialog objCommonDialog)
				: base(objCommonDialog)
			{
				InitializeComponent();
				ResetAll();
			}

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				components = new Container();
				mobjPanelControls = new Panel();
				mobjOpenButton = new Button();
				mobjCancelButton = new Button();
				mobjFilterComboBox = new ComboBox();
				mobjFileNameTextBox = new TextBox();
				mobjFileNameLabel = new Label();
				mobjFoldersPanel = new Panel();
				mobjFoldersTreeView = new TreeView();
				mobjSplitter = new Splitter();
				mobjFilesPanel = new Panel();
				mobjFilesListView = new ListView();
				mobjNameColumnHeader = new ColumnHeader();
				mobjDateColumnHeader = new ColumnHeader();
				mobjTypeColumnHeader = new ColumnHeader();
				mobjSizeColumnHeader = new ColumnHeader();
				mobjListViewContextMenuStrip = new ContextMenuStrip(components);
				mobjViewToolStripMenuItem = new ToolStripMenuItem();
				objDetailsToolStripMenuItem = new ToolStripMenuItem();
				mobjLargeIconToolStripMenuItem = new ToolStripMenuItem();
				mobjListToolStripMenuItem = new ToolStripMenuItem();
				mobjSmallIconToolStripMenuItem = new ToolStripMenuItem();
				mobjPanelControls.SuspendLayout();
				mobjFoldersPanel.SuspendLayout();
				mobjFilesPanel.SuspendLayout();
				SuspendLayout();
				mobjPanelControls.Controls.Add(mobjOpenButton);
				mobjPanelControls.Controls.Add(mobjCancelButton);
				mobjPanelControls.Controls.Add(mobjFilterComboBox);
				mobjPanelControls.Controls.Add(mobjFileNameTextBox);
				mobjPanelControls.Controls.Add(mobjFileNameLabel);
				mobjPanelControls.Dock = DockStyle.Bottom;
				mobjPanelControls.Location = new Point(0, 324);
				mobjPanelControls.Name = "mobjPanelControls";
				mobjPanelControls.Size = new Size(600, 70);
				mobjPanelControls.TabIndex = 0;
				mobjOpenButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mobjOpenButton.Location = new Point(400, 37);
				mobjOpenButton.Name = "mobjOpenButton";
				mobjOpenButton.Size = new Size(86, 23);
				mobjOpenButton.TabIndex = 4;
				mobjOpenButton.Text = "Open";
				mobjOpenButton.Enabled = false;
				mobjOpenButton.Click += mobjOpenButton_Click;
				mobjCancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mobjCancelButton.Location = new Point(502, 37);
				mobjCancelButton.Name = "mobjCancelButton";
				mobjCancelButton.Size = new Size(86, 23);
				mobjCancelButton.TabIndex = 3;
				mobjCancelButton.Text = "Cancel";
				mobjCancelButton.Click += mobjCancelButton_Click;
				mobjFilterComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mobjFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				mobjFilterComboBox.FormattingEnabled = true;
				mobjFilterComboBox.Location = new Point(400, 9);
				mobjFilterComboBox.Name = "mobjFilterComboBox";
				mobjFilterComboBox.Size = new Size(188, 21);
				mobjFilterComboBox.TabIndex = 2;
				mobjFilterComboBox.SelectedIndexChanged += mobjFilterComboBox_SelectedIndexChanged;
				mobjFileNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				mobjFileNameTextBox.Location = new Point(142, 9);
				mobjFileNameTextBox.Name = "mobjFileNameTextBox";
				mobjFileNameTextBox.ReadOnly = true;
				mobjFileNameTextBox.Size = new Size(243, 20);
				mobjFileNameTextBox.TabIndex = 1;
				mobjFileNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
				mobjFileNameLabel.Location = new Point(9, 9);
				mobjFileNameLabel.Name = "mobjFileNameLabel";
				mobjFileNameLabel.Size = new Size(130, 60);
				mobjFileNameLabel.TabIndex = 0;
				mobjFileNameLabel.Text = "File name:";
				mobjFileNameLabel.TextAlign = ContentAlignment.TopRight;
				mobjFoldersPanel.Controls.Add(mobjFoldersTreeView);
				mobjFoldersPanel.Dock = DockStyle.Left;
				mobjFoldersPanel.Location = new Point(0, 0);
				mobjFoldersPanel.Name = "mobjFoldersPanel";
				mobjFoldersPanel.Size = new Size(200, 330);
				mobjFoldersPanel.TabIndex = 1;
				mobjFoldersTreeView.Dock = DockStyle.Fill;
				mobjFoldersTreeView.Location = new Point(0, 0);
				mobjFoldersTreeView.Name = "mobjFoldersTreeView";
				mobjFoldersTreeView.Size = new Size(200, 330);
				mobjFoldersTreeView.TabIndex = 0;
				mobjSplitter.Location = new Point(200, 0);
				mobjSplitter.Name = "mobjSplitter";
				mobjSplitter.Size = new Size(3, 330);
				mobjSplitter.TabIndex = 2;
				mobjSplitter.TabStop = false;
				mobjFilesPanel.Controls.Add(mobjFilesListView);
				mobjFilesPanel.Dock = DockStyle.Fill;
				mobjFilesPanel.Location = new Point(203, 0);
				mobjFilesPanel.Name = "mobjFilesPanel";
				mobjFilesPanel.Size = new Size(397, 330);
				mobjFilesPanel.TabIndex = 3;
				mobjFilesListView.Columns.AddRange(new ColumnHeader[4] { mobjNameColumnHeader, mobjDateColumnHeader, mobjTypeColumnHeader, mobjSizeColumnHeader });
				mobjFilesListView.ContextMenuStrip = mobjListViewContextMenuStrip;
				mobjFilesListView.DataMember = null;
				mobjFilesListView.Dock = DockStyle.Fill;
				mobjFilesListView.Location = new Point(0, 0);
				mobjFilesListView.MultiSelect = false;
				mobjFilesListView.Name = "mobjFilesListView";
				mobjFilesListView.Size = new Size(397, 330);
				mobjFilesListView.TabIndex = 0;
				mobjFilesListView.SelectedIndexChanged += mobjFilesListView_SelectedIndexChanged;
				mobjNameColumnHeader.Text = "Name";
				mobjNameColumnHeader.Width = 150;
				mobjDateColumnHeader.Text = "Date";
				mobjDateColumnHeader.Width = 150;
				mobjTypeColumnHeader.Text = "Type";
				mobjTypeColumnHeader.Width = 150;
				mobjSizeColumnHeader.Text = "Size";
				mobjSizeColumnHeader.Width = 150;
				mobjListViewContextMenuStrip.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				mobjListViewContextMenuStrip.BorderColor = new BorderColor(Color.FromArgb(101, 147, 207));
				mobjListViewContextMenuStrip.BorderStyle = BorderStyle.None;
				mobjListViewContextMenuStrip.BorderWidth = new BorderWidth(1);
				mobjListViewContextMenuStrip.Items.AddRange(new ToolStripItem[1] { mobjViewToolStripMenuItem });
				mobjListViewContextMenuStrip.Name = "mobjListViewContextMenuStrip";
				mobjListViewContextMenuStrip.Size = new Size(100, 25);
				mobjViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4] { objDetailsToolStripMenuItem, mobjLargeIconToolStripMenuItem, mobjListToolStripMenuItem, mobjSmallIconToolStripMenuItem });
				mobjViewToolStripMenuItem.Name = "mobjViewToolStripMenuItem";
				mobjViewToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
				mobjViewToolStripMenuItem.Size = new Size(96, 20);
				mobjViewToolStripMenuItem.Text = "View";
				objDetailsToolStripMenuItem.Name = "objDetailsToolStripMenuItem";
				objDetailsToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
				objDetailsToolStripMenuItem.Size = new Size(106, 20);
				objDetailsToolStripMenuItem.Tag = "Details";
				objDetailsToolStripMenuItem.Text = "Details";
				objDetailsToolStripMenuItem.Click += ChangeView;
				mobjLargeIconToolStripMenuItem.Name = "mobjLargeIconToolStripMenuItem";
				mobjLargeIconToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
				mobjLargeIconToolStripMenuItem.Size = new Size(130, 20);
				mobjLargeIconToolStripMenuItem.Tag = "LargeIcon";
				mobjLargeIconToolStripMenuItem.Text = "Large Icons";
				mobjLargeIconToolStripMenuItem.Click += ChangeView;
				mobjListToolStripMenuItem.Name = "mobjListToolStripMenuItem";
				mobjListToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
				mobjListToolStripMenuItem.Size = new Size(130, 20);
				mobjListToolStripMenuItem.Tag = "List";
				mobjListToolStripMenuItem.Text = "List";
				mobjListToolStripMenuItem.Click += ChangeView;
				mobjSmallIconToolStripMenuItem.Name = "mobjSmallIconToolStripMenuItem";
				mobjSmallIconToolStripMenuItem.Padding = new Padding(0, 0, 0, 0);
				mobjSmallIconToolStripMenuItem.Size = new Size(130, 20);
				mobjSmallIconToolStripMenuItem.Tag = "SmallIcon";
				mobjSmallIconToolStripMenuItem.Text = "Small Icons";
				mobjSmallIconToolStripMenuItem.Click += ChangeView;
				base.AcceptButton = mobjOpenButton;
				base.CancelButton = mobjCancelButton;
				base.Controls.Add(mobjFilesPanel);
				base.Controls.Add(mobjSplitter);
				base.Controls.Add(mobjFoldersPanel);
				base.Controls.Add(mobjPanelControls);
				base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				base.Size = new Size(600, 400);
				Text = "Open";
				mobjPanelControls.ResumeLayout(blnPerformLayout: false);
				mobjFoldersPanel.ResumeLayout(blnPerformLayout: false);
				mobjFilesPanel.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Resets all.
			/// </summary>
			private void ResetAll()
			{
				FillFilterCombo();
				UpdateSelectedFile(string.Empty);
				mobjFilesListView.Items.Clear();
				mobjFoldersTreeView.Nodes.Clear();
				mstrIconsFolder = Context.Config.GetDirectory("Icons").ToLower(CultureInfo.InvariantCulture);
				AddRootFolder(mstrIconsFolder);
				mstrImagesFolder = Context.Config.GetDirectory("Images").ToLower(CultureInfo.InvariantCulture);
				AddRootFolder(mstrImagesFolder);
			}

			/// 
			/// Fills the filter combo.
			/// </summary>
			private void FillFilterCombo()
			{
				mobjFilterComboBox.Items.Clear();
				string filter = Filter;
				if (!string.IsNullOrEmpty(filter))
				{
					string[] array = filter.Split('|');
					for (int i = 0; i < array.Length; i += 2)
					{
						mobjFilterComboBox.Items.Add(new FilterComboItem(array[i], array[i + 1]));
					}
					if (mobjFilterComboBox.Items.Count > 0)
					{
						mobjFilterComboBox.SelectedIndex = 0;
					}
				}
			}

			/// 
			/// Adds the root folder.
			/// </summary>
			/// <param name="strFolder">The STR folder.</param>
			private void AddRootFolder(string strFolder)
			{
				if (Directory.Exists(strFolder))
				{
					DirectoryInfo objDir = new DirectoryInfo(strFolder);
					CreateFolderNode(objDir, mobjFoldersTreeView.Nodes);
				}
			}

			/// 
			/// Creates the folder node.
			/// </summary>
			/// <param name="objDir">The obj dir.</param>
			/// <param name="objParent">The obj parent.</param>
			/// </returns>
			private TreeNode CreateFolderNode(DirectoryInfo objDir, TreeNodeCollection objParent)
			{
				TreeNode treeNode = new TreeNode(objDir.Name);
				treeNode.Text = objDir.Name;
				treeNode.Tag = objDir.FullName;
				treeNode.HasNodes = objDir.GetDirectories().Length != 0;
				treeNode.BeforeExpand += objFolder_BeforeExpand;
				treeNode.AfterSelect += objTreeNode_AfterSelect;
				objParent.Add(treeNode);
				return treeNode;
			}

			/// 
			/// Handles the AfterSelect event of the objTreeNode control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
			private void objTreeNode_AfterSelect(object sender, TreeViewEventArgs e)
			{
				UpdateFileList();
			}

			/// 
			/// Updates the file list.
			/// </summary>
			private void UpdateFileList()
			{
				string strFilter = string.Empty;
				mobjFilesListView.Items.Clear();
				UpdateSelectedFile(string.Empty);
				TreeNode selectedNode = mobjFoldersTreeView.SelectedNode;
				if (selectedNode == null)
				{
					return;
				}
				if (mobjFilterComboBox.SelectedItem is FilterComboItem filterComboItem)
				{
					strFilter = filterComboItem.Filter;
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(selectedNode.Tag.ToString());
				if (directoryInfo == null)
				{
					return;
				}
				FileInfo[] files = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					if (ShouldAddFile(fileInfo.Name, strFilter))
					{
						ListViewItem listViewItem = new ListViewItem(fileInfo.Name);
						string strFileName;
						ResourceHandle largeImage = (listViewItem.SmallImage = CreateResourceHandle(fileInfo, out strFileName));
						listViewItem.LargeImage = largeImage;
						listViewItem.SubItems.Add(fileInfo.Length.ToString());
						listViewItem.SubItems.Add(fileInfo.Extension);
						listViewItem.SubItems.Add(fileInfo.LastWriteTime.ToString());
						listViewItem.Tag = fileInfo;
						mobjFilesListView.Items.Add(listViewItem);
					}
				}
			}

			/// 
			/// Shoulds the add file.
			/// </summary>
			/// <param name="strFileName">Name of the STR file.</param>
			/// <param name="strFilter">The STR filter.</param>
			/// </returns>
			private bool ShouldAddFile(string strFileName, string strFilter)
			{
				string[] array = strFilter.Split(';');
				foreach (string text in array)
				{
					strFilter = text.TrimStart('*').ToLower(CultureInfo.InvariantCulture);
					if (strFileName.ToLower(CultureInfo.InvariantCulture).EndsWith(strFilter))
					{
						return true;
					}
				}
				return false;
			}

			/// 
			/// Creates the resource handle.
			/// </summary>
			/// <param name="objFile">The obj file.</param>
			/// <param name="strFileName">Name of the STR file.</param>
			/// </returns>
			private ResourceHandle CreateResourceHandle(FileInfo objFile, out string strFileName)
			{
				strFileName = string.Empty;
				if (objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(mstrIconsFolder))
				{
					strFileName = objFile.FullName.Remove(0, mstrIconsFolder.Length + 1).Replace("\\", ".");
					return new IconResourceHandle(strFileName);
				}
				if (objFile.FullName.ToLower(CultureInfo.InvariantCulture).StartsWith(mstrImagesFolder))
				{
					strFileName = objFile.FullName.Remove(0, mstrImagesFolder.Length + 1).Replace("\\", ".");
					return new ImageResourceHandle(strFileName);
				}
				return null;
			}

			/// 
			/// Handles the BeforeExpand event of the objFolder control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
			private void objFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
			{
				TreeNode node = e.Node;
				node.Loaded = true;
				DirectoryInfo directoryInfo = new DirectoryInfo(node.Tag.ToString());
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				foreach (DirectoryInfo objDir in directories)
				{
					CreateFolderNode(objDir, node.Nodes);
				}
			}

			/// 
			/// Changes the view.
			/// </summary>
			/// <param name="sender">The sender.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void ChangeView(object sender, EventArgs e)
			{
				if (sender is ToolStripItem toolStripItem)
				{
					string value = toolStripItem.Tag as string;
					if (!string.IsNullOrEmpty(value))
					{
						mobjFilesListView.View = (View)Enum.Parse(typeof(View), value);
					}
				}
			}

			/// 
			/// Handles the SelectedIndexChanged event of the mobjFilesListView control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjFilesListView_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (mobjFilesListView.SelectedItem != null)
				{
					string strFileName = string.Empty;
					if (mobjFilesListView.SelectedItem.Tag is FileInfo fileInfo)
					{
						strFileName = fileInfo.Name;
					}
					UpdateSelectedFile(strFileName);
				}
			}

			/// 
			/// Updates the selected file.
			/// </summary>
			/// <param name="strFileName">Name of the STR file.</param>
			private void UpdateSelectedFile(string strFileName)
			{
				mobjFileNameTextBox.Text = strFileName;
				if (string.IsNullOrEmpty(strFileName))
				{
					mobjOpenButton.Enabled = false;
				}
				else
				{
					mobjOpenButton.Enabled = true;
				}
			}

			/// 
			/// Handles the Click event of the mobjOpenButton control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjOpenButton_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.OK;
				if (mobjFilesListView.SelectedItem.Tag is FileInfo fileInfo)
				{
					FileName = fileInfo.FullName;
				}
				Close();
			}

			/// 
			/// Handles the Click event of the mobjCancelButton control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjCancelButton_Click(object sender, EventArgs e)
			{
				Close();
			}

			/// 
			/// Handles the SelectedIndexChanged event of the mobjFilterComboBox control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				UpdateFileList();
			}
		}

		private const string DEFAULT_FILTER = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";

		private string mstrFileName = string.Empty;

		private string mstrFilter = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";

		/// 
		/// Gets or sets the filter.
		/// </summary>
		/// 
		/// The filter.
		/// </value>
		/// <exception cref="T:System.ArgumentException"></exception>
		public string Filter
		{
			get
			{
				return mstrFilter;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					string[] array = value.Split('|');
					if (array == null || array.Length % 2 != 0)
					{
						throw new ArgumentException(SR.GetString("FileDialogInvalidFilter"));
					}
				}
				mstrFilter = value;
			}
		}

		/// 
		/// Gets or sets the name of the file.
		/// </summary>
		/// 
		/// The name of the file.
		/// </value>
		public string FileName
		{
			get
			{
				return mstrFileName;
			}
			internal set
			{
				mstrFileName = value;
			}
		}

		public event EventHandler FileOk;

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new ServerOpenFileDialogForm(this);
		}

		/// 
		/// When overridden in a derived class, resets the properties of a common dialog box to their default values.
		/// </summary>
		public override void Reset()
		{
			mstrFilter = "Image Files (JPEG,GIF,BMP,PNG,ICON)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.ico|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|ICON Files(*.ico)|*.ico|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files(*.png)|*.png";
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data.</param>
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			if (base.DialogResult == DialogResult.OK)
			{
				OnFileOk(new EventArgs());
			}
		}

		/// 
		/// Raises the <see cref="E:FileOk" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnFileOk(EventArgs e)
		{
			this.FileOk?.Invoke(this, e);
		}
	}
}
