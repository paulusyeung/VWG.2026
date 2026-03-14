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
internal class VirtualStorageNode : ServerExplorerNode
	{
		private string mstrSelectedFile = "";

		internal VirtualStorageNode(string strDirectory)
			: this(strDirectory, "")
		{
		}

		internal VirtualStorageNode(string strDirectory, string strLabel)
		{
			base.Tag = strDirectory;
			if (strLabel != "")
			{
				base.Label = strLabel;
			}
			else
			{
				string[] array = strDirectory.Split('\\');
				if (array.Length != 0)
				{
					base.Label = array[array.Length - 1];
				}
				else
				{
					base.Label = "N/A";
				}
			}
			if (strDirectory != "")
			{
				base.Image = new IconResourceHandle("Folder.gif");
			}
			else
			{
				base.Image = new IconResourceHandle("Storage.gif");
			}
		}

		/// 
		/// Loads the columns.
		/// </summary>
		/// <param name="objColumns">The columns.</param>
		protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
		{
			objColumns.Add("Name", 150, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
			objColumns.Add("Size", 100, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
			objColumns.Add("Type", 100, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
			objColumns.Add("Date Modified", 100, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
			objColumns.Add("Date Created", 100, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
		}

		/// 
		/// Loads the items.
		/// </summary>
		/// <param name="objItems">The items.</param>
		protected override void LoadItems(ListView.ListViewItemCollection objItems)
		{
			string text = (string)base.Tag;
			if (text != "" && Gizmox.WebGUI.Virtualization.IO.VirtualDirectory.Exists(text))
			{
				VirtualDirectoryInfo virtualDirectoryInfo = new VirtualDirectoryInfo(text);
				VirtualFileInfo[] files = virtualDirectoryInfo.GetFiles();
				foreach (VirtualFileInfo virtualFileInfo in files)
				{
					ListViewItem listViewItem = objItems.Add(virtualFileInfo.Name);
					listViewItem.Tag = virtualFileInfo.FullName;
					listViewItem.SmallImage = new IconResourceHandle("File.gif");
					listViewItem.SubItems.Add(GetFileLength(virtualFileInfo.Length));
					listViewItem.SubItems.Add(virtualFileInfo.Extension);
					listViewItem.SubItems.Add(virtualFileInfo.LastWriteTime.ToShortDateString());
					listViewItem.SubItems.Add(virtualFileInfo.CreationTime.ToShortDateString());
				}
			}
		}

		protected internal override void OnItemDoubleClick(ListViewItem listViewItem)
		{
			mstrSelectedFile = (string)listViewItem.Tag;
			MessageBox.Show(mstrSelectedFile);
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHostContext">The gateway request HOST context.</param>
		/// <param name="strAction">The gateway request action.</param>
		/// 
		/// By default this method returns a instance of a class which implements the IGatewayHandler and
		/// throws a non implemented HttpException.
		/// </returns>
		/// 
		/// This method is called from the implementation of IGatewayComponent which replaces the
		/// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
		/// RegisteredComponent class which is the base class of most of the Visual WebGui
		/// components.
		/// Referencing a RegisterComponent that overrides this method is done the same way that
		/// a control implementing IGatewayControl, which is by using the GatewayReference class.
		/// </remarks>
		protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
		{
			return null;
		}

		/// 
		/// Gets the length of the file.
		/// </summary>
		/// <param name="lngFileLength">Length of the file.</param>
		/// </returns>
		private string GetFileLength(long lngFileLength)
		{
			if (lngFileLength < 1024 && lngFileLength > 0)
			{
				return "1Kb";
			}
			if (lngFileLength > 1024)
			{
				return (int)(lngFileLength / 1024) + "Kb";
			}
			return "0Kb";
		}

		/// 
		/// Loads the nodes.
		/// </summary>
		protected override void LoadNodes()
		{
			string text = (string)base.Tag;
			if (text == "")
			{
				VirtualDriveInfo[] drives = VirtualDriveInfo.GetDrives();
				foreach (VirtualDriveInfo virtualDriveInfo in drives)
				{
					base.Nodes.Add(new VirtualStorageNode(virtualDriveInfo.Name));
				}
			}
			else if (Gizmox.WebGUI.Virtualization.IO.VirtualDirectory.Exists(text))
			{
				VirtualDirectoryInfo virtualDirectoryInfo = new VirtualDirectoryInfo(text);
				VirtualDirectoryInfo[] directories = virtualDirectoryInfo.GetDirectories();
				foreach (VirtualDirectoryInfo virtualDirectoryInfo2 in directories)
				{
					base.Nodes.Add(new VirtualStorageNode(virtualDirectoryInfo2.FullName));
				}
			}
		}
	}
}
