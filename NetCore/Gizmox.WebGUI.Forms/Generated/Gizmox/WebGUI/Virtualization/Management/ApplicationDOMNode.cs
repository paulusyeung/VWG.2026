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
	[Serializable]
	internal class ApplicationDOMNode : ServerExplorerNode
	{
		private static ResourceHandle mobjNulImageResourceHandle = new AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.null-set-icon.gif");

		private bool mobjIsSelectable;

		/// 
		/// Gets the display text.
		/// </summary>
		/// <param name="objValue">The object value.</param>
		/// </returns>
		protected string GetDisplayText(object objValue)
		{
			if (objValue == null)
			{
				return string.Empty;
			}
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objValue)["Text"];
			string text;
			if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
			{
				text = (string)propertyDescriptor.GetValue(objValue);
				if (text != null && text.Length > 0)
				{
					return text;
				}
			}
			PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(objValue)["Name"];
			if (propertyDescriptor2 != null && propertyDescriptor2.PropertyType == typeof(string))
			{
				text = (string)propertyDescriptor2.GetValue(objValue);
				if (text != null && text.Length > 0)
				{
					return text;
				}
			}
			text = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
			if (text != null && text.Length != 0)
			{
				return text;
			}
			return objValue.GetType().Name;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ApplicationDOMNode" /> class.
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		/// <param name="blnIsSelectable">if set to true</c> [BLN is selectable].</param>
		internal ApplicationDOMNode(IRegisteredComponent objComponent, bool blnIsSelectable)
		{
			base.Tag = objComponent;
			if (objComponent is ProxyComponent { SourceComponent: { } sourceComponent })
			{
				objComponent = sourceComponent;
			}
			mobjIsSelectable = blnIsSelectable;
			base.Label = $"{objComponent.GetType().Name}({GetDisplayText(objComponent)})";
			if (!mobjIsSelectable)
			{
				base.ForeColor = Color.FromArgb(140, 140, 140);
				base.StateImage = mobjNulImageResourceHandle;
			}
			System.Drawing.Image toolboxImageFromControlType = CommonUtils.GetToolboxImageFromControlType(objComponent.GetType());
			if (toolboxImageFromControlType != null)
			{
				base.Image = new GatewayResourceHandle(this, "componentImage");
			}
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHttpContext">The gateway request HTTP context (which is unavailable in non ASP.NET hosting modes).</param>
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
		protected override IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
		{
			if (base.Tag != null)
			{
				objHttpContext.Response.ContentType = "image/jpeg";
				CommonUtils.GetToolboxImageFromControlType(base.Tag.GetType())?.Save(objHttpContext.Response.OutputStream, ImageFormat.Bmp);
			}
			return null;
		}

		/// 
		/// Loads the nodes.
		/// </summary>
		protected override void LoadNodes()
		{
			if (base.Tag is Gizmox.WebGUI.Forms.TreeView)
			{
				foreach (Gizmox.WebGUI.Forms.TreeNode node in ((Gizmox.WebGUI.Forms.TreeView)base.Tag).Nodes)
				{
					base.Nodes.Add(new ApplicationDOMNode(node, base.Explorer.IsSupportSelect(node)));
				}
			}
			else if (base.Tag is Gizmox.WebGUI.Forms.TreeNode)
			{
				foreach (Gizmox.WebGUI.Forms.TreeNode node2 in ((Gizmox.WebGUI.Forms.TreeNode)base.Tag).Nodes)
				{
					base.Nodes.Add(new ApplicationDOMNode(node2, base.Explorer.IsSupportSelect(node2)));
				}
			}
			if (base.Tag is ToolBar)
			{
				foreach (ToolBarButton item in (IEnumerable)((ToolBar)base.Tag).Buttons)
				{
					base.Nodes.Add(new ApplicationDOMNode(item, base.Explorer.IsSupportSelect(item)));
				}
				return;
			}
			if (base.Tag is ListView)
			{
				foreach (ListViewItem item2 in ((ListView)base.Tag).Items)
				{
					base.Nodes.Add(new ApplicationDOMNode(item2, base.Explorer.IsSupportSelect(item2)));
				}
				return;
			}
			if (base.Tag is Gizmox.WebGUI.Forms.MenuItem)
			{
				if (!(base.Tag is Gizmox.WebGUI.Forms.MenuItem menuItem))
				{
					return;
				}
				{
					foreach (Gizmox.WebGUI.Forms.MenuItem menuItem2 in menuItem.MenuItems)
					{
						base.Nodes.Add(new ApplicationDOMNode(menuItem2, base.Explorer.IsSupportSelect(menuItem2)));
					}
					return;
				}
			}
			if (base.Tag is MainMenu)
			{
				if (!(base.Tag is MainMenu mainMenu))
				{
					return;
				}
				{
					foreach (Gizmox.WebGUI.Forms.MenuItem menuItem3 in mainMenu.MenuItems)
					{
						base.Nodes.Add(new ApplicationDOMNode(menuItem3, base.Explorer.IsSupportSelect(menuItem3)));
					}
					return;
				}
			}
			if (base.Tag is ToolStrip)
			{
				if (!(base.Tag is ToolStrip toolStrip))
				{
					return;
				}
				{
					foreach (ToolStripItem item3 in toolStrip.Items)
					{
						base.Nodes.Add(new ApplicationDOMNode(item3, base.Explorer.IsSupportSelect(item3)));
					}
					return;
				}
			}
			if (base.Tag is ToolStripDropDownItem)
			{
				if (!(base.Tag is ToolStripDropDownItem toolStripDropDownItem))
				{
					return;
				}
				{
					foreach (ToolStripItem dropDownItem in toolStripDropDownItem.DropDownItems)
					{
						base.Nodes.Add(new ApplicationDOMNode(dropDownItem, base.Explorer.IsSupportSelect(dropDownItem)));
					}
					return;
				}
			}
			if (base.Tag is Form)
			{
				if (base.Tag is Form { OwnedForms: var ownedForms } form)
				{
					foreach (Form objComponent9 in ownedForms)
					{
						base.Nodes.Add(new ApplicationDOMNode(objComponent9, base.Explorer.IsSupportSelect(objComponent9)));
					}
					MainMenu menu = form.Menu;
					if (menu != null)
					{
						base.Nodes.Add(new ApplicationDOMNode(menu, base.Explorer.IsSupportSelect(menu)));
					}
					MenuStrip mainMenuStrip = form.MainMenuStrip;
					if (mainMenuStrip != null)
					{
						base.Nodes.Add(new ApplicationDOMNode(mainMenuStrip, base.Explorer.IsSupportSelect(mainMenuStrip)));
					}
				}
				LoadControl();
			}
			else
			{
				if (base.Tag is ProxyComponent)
				{
					if (!(base.Tag is ProxyComponent proxyComponent))
					{
						return;
					}
					{
						foreach (ProxyComponent component in proxyComponent.Components)
						{
							base.Nodes.Add(new ApplicationDOMNode(component, base.Explorer.IsSupportSelect(component)));
						}
						return;
					}
				}
				if (base.Tag is Gizmox.WebGUI.Forms.Control)
				{
					LoadControl();
				}
			}
		}

		/// 
		/// Loads the control.
		/// </summary>
		private void LoadControl()
		{
			if (!(base.Tag is Gizmox.WebGUI.Forms.Control control))
			{
				return;
			}
			foreach (Gizmox.WebGUI.Forms.Control control2 in control.Controls)
			{
				base.Nodes.Add(new ApplicationDOMNode(control2, base.Explorer.IsSupportSelect(control2)));
			}
		}

		/// 
		/// Loads the columns.
		/// </summary>
		/// <param name="objColumns">The object columns.</param>
		protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
		{
			objColumns.Add("Name", 200, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
			objColumns.Add("Value", 300, Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
		}

		/// 
		/// Loads the items.
		/// </summary>
		/// <param name="objItems">The object items.</param>
		protected override void LoadItems(ListView.ListViewItemCollection objItems)
		{
			object tag = base.Tag;
			if (tag == null)
			{
				return;
			}
			Type type = tag.GetType();
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				object obj = null;
				try
				{
					obj = type.InvokeMember(propertyInfo.Name, BindingFlags.GetProperty, null, tag, new object[0]);
				}
				catch
				{
				}
				if (obj != null)
				{
					objItems.Add(propertyInfo.Name).SubItems.Add(obj.ToString());
				}
				else
				{
					objItems.Add(propertyInfo.Name).SubItems.Add("null");
				}
			}
			if (base.List != null && base.List.Columns.Count > 0)
			{
				base.List.SortBy(base.List.Columns[0]);
			}
		}
	}
}
