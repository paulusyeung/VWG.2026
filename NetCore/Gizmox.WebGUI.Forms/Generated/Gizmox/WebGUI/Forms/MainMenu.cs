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
	/// Summary description for MainMenu.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(MainMenu), "MainMenu_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms.MainMenu")]
	[ToolboxItemCategory("Menus & Toolbars")]
	[MetadataTag("MM")]
	[Skin(typeof(MainMenuSkin))]
	[ProxyComponent(typeof(ProxyMainMenu))]
	public class MainMenu : Control, IRegisteredComponentContainer, IMainMenu
	{
		/// 
		/// The Items property registration.
		/// </summary>
		private static readonly SerializableProperty ItemsProperty = SerializableProperty.Register("Items", typeof(MenuItemCollection), typeof(MainMenu));

		/// 
		/// The main menu menu items
		/// </summary>
		private MenuItemCollection ItemsInternal
		{
			get
			{
				return GetValue(ItemsProperty, null);
			}
			set
			{
				SetValue(ItemsProperty, value);
			}
		}

		/// 
		///
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ListBindable(false)]
		[Browsable(false)]
		public MenuItemCollection MenuItems
		{
			get
			{
				if (ItemsInternal == null)
				{
					ItemsInternal = new MenuItemCollection(this);
				}
				return ItemsInternal;
			}
		}

		/// 
		/// Gets the parent of this component.
		/// </summary>
		/// </value>
		public override Component InternalParent
		{
			get
			{
				return base.InternalParent;
			}
			set
			{
				if (base.InternalParent != value)
				{
					if (value == null)
					{
						MenuItems.RemovingFromDOM();
					}
					base.InternalParent = value;
					if (value != null)
					{
						MenuItems.AttachedToDOM();
					}
				}
			}
		}

		ICollection IRegisteredComponentContainer.ContainedComponents => ItemsInternal;

		ICollection IMainMenu.MenuItems => MenuItems;

		IComponent IMainMenu.Parent => base.Parent;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MainMenu" /> instance.
		/// </summary>
		/// <param name="objControl">parent control.</param>
		internal MainMenu(Control objControl)
		{
			InternalParent = objControl;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MainMenu" /> class.
		/// </summary>
		public MainMenu()
			: this(null)
		{
		}

		/// 
		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
		/// </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing && Form != null)
			{
				Form.Menu = null;
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Renders the height.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		internal override void RenderHeight(IContext objContext, IAttributeWriter objWriter)
		{
			if (base.Skin is MainMenuSkin mainMenuSkin)
			{
				objWriter.WriteAttributeString("H", mainMenuSkin.Height.ToString());
			}
			else
			{
				base.RenderHeight(objContext, objWriter);
			}
		}

		/// 
		/// MainMenu render impementation
		/// </summary>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			string strValue = GetMenuItemCriticalEventsData().ToClientString();
			foreach (MenuItem menuItem in MenuItems)
			{
				if (menuItem.Visible)
				{
					menuItem.Enter += MenuItem_Enter;
					RegisterComponent(menuItem);
					objWriter.WriteStartElement("I");
					objWriter.WriteAttributeString("Id", menuItem.GetProxyPropertyValue("ID", menuItem.ID).ToString());
					if (!menuItem.Enabled)
					{
						objWriter.WriteAttributeString("En", "0");
					}
					objWriter.WriteAttributeString("E", strValue);
					if (menuItem != null && menuItem.MenuItems.Count > 0)
					{
						objWriter.WriteAttributeString("HN", "1");
					}
					objWriter.WriteAttributeText("TX", menuItem.Text, (TextFilter)5);
					menuItem.RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);
					objWriter.WriteEndElement();
				}
			}
		}

		/// 
		/// Gets the critical events of specific menu item instance.
		/// </summary>
		private CriticalEventsData GetMenuItemCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = new CriticalEventsData();
			criticalEventsData.Set("CL");
			if (HasHandler(Control.DoubleClickEvent))
			{
				criticalEventsData.Set("DCL");
			}
			return criticalEventsData;
		}

		/// 
		/// Handles the Enter event of the MenuItem control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void MenuItem_Enter(object objSender, EventArgs e)
		{
			if (objSender is MenuItem objMenuItem)
			{
				ShowSubMenu(objMenuItem);
			}
		}

		/// 
		/// Shows the submenu form.
		/// </summary>
		/// <param name="objMenuItem">The obj menu item.</param>
		private void ShowSubMenu(MenuItem objMenuItem)
		{
			if (objMenuItem != null && objMenuItem.MenuItems.Count > 0)
			{
				objMenuItem.Show(objMenuItem, Point.Empty, DialogAlignment.Below);
			}
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is MenuItem)
			{
				MenuItems.Add((MenuItem)objValue);
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			if (ItemsInternal != null)
			{
				RegisterBatch(ItemsInternal);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			if (ItemsInternal != null)
			{
				UnRegisterBatch(ItemsInternal);
			}
		}

		/// 
		/// Fires the click event.
		/// </summary>
		/// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		internal void FireClick(MouseEventArgs objMouseEventArgs)
		{
			OnClick(objMouseEventArgs);
		}

		/// 
		/// Fires the double click event.
		/// </summary>
		/// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		internal void FireDoubleClick(MouseEventArgs objMouseEventArgs)
		{
			OnDoubleClick(objMouseEventArgs);
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return MenuItems;
		}
	}
}
