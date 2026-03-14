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

namespace Gizmox.WebGUI.Virtualization.Management
{
/// 
	/// Summary description for ServerExplorer.
	/// </summary>
	[Serializable]
	public class ServerExplorer : Form
	{
		private static readonly SerializableEvent ComponentDoubleClickEvent;

		private bool mblnIsDoubleClickRegistered;

		private IRegisteredComponent mobjSelectedComponent;

		private IEnumerable mobjAllowedSelectedTypes;

		private IEnumerable mobjAllowedProxySourceSelectedTypes;

		private Gizmox.WebGUI.Forms.Panel mobjButtonsPanel;

		private Gizmox.WebGUI.Forms.Panel mobjSeperatorPanel;

		private Gizmox.WebGUI.Forms.Button mobjOkButton;

		private Gizmox.WebGUI.Forms.Button mobjCancelButton;

		private ServerExplorerTree mobjServerExplorerTree;

		private Splitter mobjSplitterTrace;

		private ListView mobjListTrace;

		private Gizmox.WebGUI.Forms.TreeNode mobjRootTraceNode;

		/// 
		/// Required designer variable.
		/// </summary>
		[NonSerialized]
		private Container components = null;

		/// 
		/// Gets or sets the allowed selected types.
		/// </summary>
		/// 
		/// The allowed selected types.
		/// </value>
		public IEnumerable AllowedSelectedTypes
		{
			get
			{
				return mobjAllowedSelectedTypes ?? new Type[1] { typeof(IRegisteredComponent) };
			}
			set
			{
				mobjAllowedSelectedTypes = value;
			}
		}

		/// 
		/// Gets or sets the allowed selected types.
		/// </summary>
		/// 
		/// The allowed selected types.
		/// </value>
		public IEnumerable AllowedProxySourceSelectedTypes
		{
			get
			{
				return mobjAllowedProxySourceSelectedTypes ?? new Type[1] { typeof(IRegisteredComponent) };
			}
			set
			{
				mobjAllowedProxySourceSelectedTypes = value;
			}
		}

		/// 
		/// Gets the selected component.
		/// </summary>
		/// 
		/// The selected component.
		/// </value>
		public IRegisteredComponent SelectedComponent
		{
			get
			{
				return mobjSelectedComponent;
			}
			internal set
			{
				bool flag = IsSupportSelect(value);
				if (value == null || flag)
				{
					mobjSelectedComponent = value;
					if (flag)
					{
						mobjOkButton.Enabled = true;
					}
				}
				else
				{
					mobjOkButton.Enabled = false;
				}
			}
		}

		/// 
		/// Gets the component double handler.
		/// </summary>
		/// 
		/// The component double handler.
		/// </value>
		private EventHandler ComponentDoubleHandler => GetHandler(ComponentDoubleClick) as EventHandler;

		/// 
		/// Occurs when [node mouse double click].
		/// </summary>
		public event EventHandler ComponentDoubleClick
		{
			add
			{
				AddHandler(ComponentDoubleClickEvent, value);
				if (!mblnIsDoubleClickRegistered)
				{
					mblnIsDoubleClickRegistered = true;
					mobjServerExplorerTree.NodeMouseDoubleClick += OnTreeNodeMouseClick;
				}
			}
			remove
			{
				RemoveHandler(ComponentDoubleClickEvent, value);
				if (ComponentDoubleHandler.GetInvocationList().Length == 0)
				{
					mblnIsDoubleClickRegistered = false;
					mobjServerExplorerTree.NodeMouseDoubleClick -= OnTreeNodeMouseClick;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ServerExplorer" /> class.
		/// </summary>
		public ServerExplorer()
			: this(blnShowPhysicalEnviroment: true, blnShowRuntimeEnvironment: true, blnShowTraceList: true, blnShowOkCancel: false)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ServerExplorer" /> class.
		/// </summary>
		/// <param name="blnShowPhysicalEnviroment">if set to true</c> [BLN show physical enviroment].</param>
		/// <param name="blnShowRuntimeEnvironment">if set to true</c> [BLN show runtime environment].</param>
		/// <param name="blnShowTraceList">if set to true</c> [BLN show trace list].</param>
		/// <param name="blnShowOkCancel">if set to true</c> [BLN show ok cancel].</param>
		public ServerExplorer(bool blnShowPhysicalEnviroment, bool blnShowRuntimeEnvironment, bool blnShowTraceList, bool blnShowOkCancel)
		{
			InitializeComponent();
			if (blnShowTraceList)
			{
				InitialzeTraceList();
				mobjServerExplorerTree.List = mobjListTrace;
			}
			else
			{
				mobjServerExplorerTree.Dock = DockStyle.Fill;
			}
			if (blnShowPhysicalEnviroment)
			{
				InitialzePhysicalEnviroment();
			}
			if (blnShowRuntimeEnvironment)
			{
				InitialzeRuntimeEnvironment();
			}
			if (blnShowOkCancel)
			{
				InitializeOkCancel();
			}
		}

		/// 
		/// Initializes the ok cancel.
		/// </summary>
		private void InitializeOkCancel()
		{
			mobjButtonsPanel = new Gizmox.WebGUI.Forms.Panel();
			mobjOkButton = new Gizmox.WebGUI.Forms.Button();
			mobjSeperatorPanel = new Gizmox.WebGUI.Forms.Panel();
			mobjCancelButton = new Gizmox.WebGUI.Forms.Button();
			mobjButtonsPanel.Height = 40;
			mobjButtonsPanel.Dock = DockStyle.Bottom;
			mobjButtonsPanel.DockPadding.Top = 10;
			mobjButtonsPanel.DockPadding.Bottom = 10;
			mobjButtonsPanel.DockPadding.Right = 10;
			mobjButtonsPanel.Controls.Add(mobjOkButton);
			mobjButtonsPanel.Controls.Add(mobjSeperatorPanel);
			mobjButtonsPanel.Controls.Add(mobjCancelButton);
			mobjOkButton.Text = WGLabels.Ok;
			mobjOkButton.Dock = DockStyle.Right;
			mobjOkButton.Enabled = false;
			mobjOkButton.DialogResult = DialogResult.OK;
			mobjSeperatorPanel.Width = 20;
			mobjSeperatorPanel.Dock = DockStyle.Right;
			mobjCancelButton.Text = WGLabels.Cancel;
			mobjCancelButton.Dock = DockStyle.Right;
			base.CancelButton = mobjCancelButton;
			base.AcceptButton = mobjOkButton;
			base.Controls.Add(mobjButtonsPanel);
		}

		/// 
		/// Called when [tree node mouse click].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
		private void OnTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			OnComponentDoubleClick(e.Node);
		}

		/// 
		/// Called when [component double click].
		/// </summary>
		/// <param name="treeNode">The tree node.</param>
		private void OnComponentDoubleClick(Gizmox.WebGUI.Forms.TreeNode treeNode)
		{
			if (treeNode is ApplicationDOMNode)
			{
				IRegisteredComponent objComponent = treeNode.Tag as IRegisteredComponent;
				if (IsSupportSelect(objComponent))
				{
					ComponentDoubleHandler?.Invoke(this, new ComponentDoubleClickEventArgs(treeNode.Tag as IRegisteredComponent));
				}
			}
		}

		/// 
		/// Initialzes the runtime environment.
		/// </summary>
		private void InitialzeRuntimeEnvironment()
		{
			Gizmox.WebGUI.Forms.TreeNode treeNode = new Gizmox.WebGUI.Forms.TreeNode("RuntimeEnviroment", "Runtime Enviroment", "Folders");
			mobjServerExplorerTree.Nodes.Add(treeNode);
			mobjServerExplorerTree.AfterSelect += mobjServerExplorerTree_AfterSelect;
			mobjRootTraceNode = new Gizmox.WebGUI.Forms.TreeNode("UserInterface", "User Interface", "Folder");
			mobjRootTraceNode.IsExpanded = false;
			treeNode.Nodes.Add(mobjRootTraceNode);
		}

		/// 
		/// Handles the AfterSelect event of the mobjServerExplorerTree control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
		private void mobjServerExplorerTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == mobjRootTraceNode && mobjListTrace != null)
			{
				mobjListTrace.Columns.Clear();
				mobjListTrace.Items.Clear();
				mobjListTrace.Update();
			}
			if (e.Node is ApplicationDOMNode)
			{
				SelectedComponent = (e.Node as ApplicationDOMNode).Tag as IRegisteredComponent;
			}
			else
			{
				SelectedComponent = null;
			}
		}

		/// 
		/// Sets the root component.
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		public void SetRootComponent(IRegisteredComponent objComponent)
		{
			if (mobjRootTraceNode != null)
			{
				mobjRootTraceNode.Nodes.Clear();
				mobjRootTraceNode.Nodes.Add(new ApplicationDOMNode(objComponent, IsSupportSelect(objComponent)));
			}
		}

		/// 
		/// Initialzes the physical enviroment.
		/// </summary>
		private void InitialzePhysicalEnviroment()
		{
			Gizmox.WebGUI.Forms.TreeNode treeNode = new Gizmox.WebGUI.Forms.TreeNode("PhysicalEnviroment", "Physical Enviroment", "Folders");
			mobjServerExplorerTree.Nodes.Add(treeNode);
			Gizmox.WebGUI.Forms.TreeNode objTreeViewNode = new Gizmox.WebGUI.Forms.TreeNode("PhysicalRegistry", "Registry", "Registry");
			treeNode.Nodes.Add(objTreeViewNode);
			Gizmox.WebGUI.Forms.TreeNode treeNode2 = new Gizmox.WebGUI.Forms.TreeNode("PhysicalStorage", "Storage", "Storage");
			treeNode2.Nodes.Add(new PhysicalStorageNode(Context.HostContext.Server.MapPath("/")));
			treeNode2.IsExpanded = false;
			treeNode.Nodes.Add(treeNode2);
		}

		/// 
		/// Initialzes the trace list.
		/// </summary>
		private void InitialzeTraceList()
		{
			mobjListTrace = new ListView();
			mobjSplitterTrace = new Splitter();
			mobjSplitterTrace.Location = new Point(168, 5);
			mobjSplitterTrace.Name = "mobjSplitterTrace";
			mobjSplitterTrace.Size = new Size(3, 420);
			mobjSplitterTrace.TabIndex = 1;
			mobjSplitterTrace.TabStop = false;
			mobjListTrace.Dock = DockStyle.Fill;
			mobjListTrace.Location = new Point(171, 5);
			mobjListTrace.Name = "mobjListTrace";
			mobjListTrace.Size = new Size(576, 420);
			mobjListTrace.TabIndex = 2;
			mobjListTrace.View = Gizmox.WebGUI.Forms.View.Details;
			mobjListTrace.DoubleClick += mobjListTrace_DoubleClick;
			base.Controls.Insert(0, mobjSplitterTrace);
			base.Controls.Insert(0, mobjListTrace);
		}

		/// 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjServerExplorerTree = new ServerExplorerTree();
			SuspendLayout();
			mobjServerExplorerTree.Dock = DockStyle.Left;
			mobjServerExplorerTree.ImageIndex = -1;
			mobjServerExplorerTree.Location = new Point(5, 5);
			mobjServerExplorerTree.Name = "mobjTreeTrace";
			mobjServerExplorerTree.SelectedImageIndex = -1;
			mobjServerExplorerTree.Size = new Size(163, 420);
			mobjServerExplorerTree.TabIndex = 0;
			base.ClientSize = new Size(752, 430);
			base.Controls.Add(mobjServerExplorerTree);
			base.DockPadding.All = 5;
			base.Name = "ServerExplorer";
			Text = "Server Explorer";
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Handles the DoubleClick event of the mobjListTrace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjListTrace_DoubleClick(object sender, EventArgs e)
		{
			if (mobjListTrace.SelectedItem != null && mobjServerExplorerTree.SelectedNode is ServerExplorerNode serverExplorerNode)
			{
				serverExplorerNode.OnItemDoubleClick(mobjListTrace.SelectedItem);
			}
		}

		/// 
		/// Determines whether [is support select] [the specified object component].
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		/// </returns>
		internal bool IsSupportSelect(IRegisteredComponent objComponent)
		{
			bool flag = false;
			if (objComponent != null)
			{
				Type type = objComponent.GetType();
				foreach (Type allowedSelectedType in AllowedSelectedTypes)
				{
					flag |= allowedSelectedType.IsAssignableFrom(type);
					if (flag)
					{
						break;
					}
				}
				if (flag && objComponent is ProxyComponent proxyComponent)
				{
					bool flag2 = false;
					Gizmox.WebGUI.Forms.Component sourceComponent = proxyComponent.SourceComponent;
					if (sourceComponent != null)
					{
						Type type2 = sourceComponent.GetType();
						foreach (Type allowedProxySourceSelectedType in AllowedProxySourceSelectedTypes)
						{
							flag2 |= allowedProxySourceSelectedType.IsAssignableFrom(type2);
							if (flag2)
							{
								break;
							}
						}
					}
					flag = flag && flag2;
				}
			}
			return flag;
		}

		static ServerExplorer()
		{
			ComponentDoubleClickEvent = SerializableEvent.Register("ComponentDoubleClickEvent", typeof(EventHandler), typeof(ServerExplorer));
		}
	}
}
