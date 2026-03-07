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
	/// Summary description for Menu Item.
	/// </summary>
	[Serializable]
	[DefaultProperty("Text")]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	[DefaultEvent("Click")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class MenuItem : Menu
	{
		/// 
		/// The TextInteranl property registration.
		/// </summary>
		private static readonly SerializableProperty TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(MenuItem));

		/// 
		/// The IconInteranl property registration.
		/// </summary>
		private static readonly SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(MenuItem));

		/// 
		/// The RadioCheckInteranl property registration.
		/// </summary>
		private static readonly SerializableProperty RadioCheckProperty = SerializableProperty.Register("RadioCheck", typeof(bool), typeof(MenuItem));

		/// 
		/// The ShortcutInternal property registration.
		/// </summary>
		private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register("Shortcut", typeof(Shortcut), typeof(MenuItem));

		/// 
		/// The Click event registration.
		/// </summary>
		private static readonly SerializableEvent ClickEvent;

		/// 
		/// The Enter event registration.
		/// </summary>
		private static readonly SerializableEvent EnterEvent;

		/// 
		/// The ShowShortcut property registration.
		/// </summary>
		private static readonly SerializableProperty ShowShortcutProperty;

		/// 
		/// The Name property registration.
		/// </summary>
		private static readonly SerializableProperty NameProperty;

		private string TextInteranl
		{
			get
			{
				return GetValue(TextProperty, string.Empty);
			}
			set
			{
				SetValue(TextProperty, value);
			}
		}

		private ResourceHandle IconInteranl
		{
			get
			{
				return GetValue(IconProperty, null);
			}
			set
			{
				SetValue(IconProperty, value);
			}
		}

		private bool RadioCheckInteranl
		{
			get
			{
				return GetValue(RadioCheckProperty, objDefault: false);
			}
			set
			{
				SetValue(RadioCheckProperty, value);
			}
		}

		private Shortcut ShortcutInternal
		{
			get
			{
				return GetValue(ShortcutProperty, Shortcut.None);
			}
			set
			{
				SetValue(ShortcutProperty, value);
			}
		}

		/// 
		///
		/// </summary>
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
					if (value == null && base.InternalParent != null)
					{
						UnregisterShortcut(blnForce: false);
					}
					base.InternalParent = value;
					if (value != null)
					{
						RegisterShortcut();
					}
				}
			}
		}

		/// 
		/// Gets or sets the shortcut.
		/// </summary>
		/// </value>
		[DefaultValue(Shortcut.None)]
		public Shortcut Shortcut
		{
			get
			{
				return ShortcutInternal;
			}
			set
			{
				if (ShortcutInternal == value)
				{
					return;
				}
				ShortcutInternal = value;
				if (!base.DesignMode)
				{
					if (value == Shortcut.None)
					{
						UnregisterShortcut(blnForce: true);
					}
					else
					{
						RegisterShortcut();
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to show shortcut.
		/// </summary>
		/// true</c> if [show shortcut]; otherwise, false</c>.</value>
		[Localizable(true)]
		[SRDescription("MenuItemShowShortCutDescr")]
		[DefaultValue(true)]
		public bool ShowShortcut
		{
			get
			{
				return GetValue(ShowShortcutProperty, objDefault: true);
			}
			set
			{
				if (value != ShowShortcut)
				{
					if (!value)
					{
						SetValue(ShowShortcutProperty, value);
					}
					else
					{
						RemoveValue(ShowShortcutProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets the menu item Text.
		/// </summary>
		[DefaultValue("")]
		[Localizable(true)]
		[SRDescription("MenuItemTextDescr")]
		public string Text
		{
			get
			{
				return TextInteranl;
			}
			set
			{
				if (TextInteranl != value)
				{
					TextInteranl = value;
					if (InternalParent != null && InternalParent is MainMenu)
					{
						InternalParent.Update();
					}
				}
			}
		}

		/// 
		///  Gets or sets a value indicating whether a check mark 
		///  appears next to the text of the menu item.  
		/// </summary>
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return GetState(ComponentState.Checked);
			}
			set
			{
				SetState(ComponentState.Checked, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether the MenuItem , if checked, 
		/// displays a radio-button instead of a check mark.  
		/// </summary>
		[DefaultValue(false)]
		public bool RadioCheck
		{
			get
			{
				return RadioCheckInteranl;
			}
			set
			{
				RadioCheckInteranl = value;
			}
		}

		/// 
		/// Gets or sets the menu icon.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		public ResourceHandle Icon
		{
			get
			{
				return IconInteranl;
			}
			set
			{
				IconInteranl = value;
			}
		}

		/// 
		/// Indicated if the menu item is visible.
		/// </summary>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool Visible
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Visible, value) && InternalParent != null && InternalParent is MainMenu)
				{
					InternalParent.Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> is enabled.
		/// </summary>
		/// 
		/// 	true</c> if enabled; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return GetState(ComponentState.Enabled);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Enabled, value) && InternalParent != null && InternalParent is MainMenu)
				{
					InternalParent.Update();
				}
			}
		}

		/// 
		/// Gets the parent menu of this menu item.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public Menu Parent => InternalParent as Menu;

		/// 
		/// Gets the parent menu items.
		/// </summary>
		/// The parent menu items.</value>
		private MenuItemCollection ParentMenuItems
		{
			get
			{
				MenuItemCollection result = null;
				if (InternalParent != null)
				{
					if (InternalParent is MainMenu)
					{
						result = ((MainMenu)InternalParent).MenuItems;
					}
					else if (InternalParent is Menu)
					{
						result = ((Menu)InternalParent).MenuItems;
					}
				}
				return result;
			}
		}

		/// 
		///  Gets or sets a value indicating the position of the menu item in its parent menu.</para>
		/// </summary>
		[Browsable(false)]
		public int Index
		{
			get
			{
				if (ParentMenuItems != null)
				{
					return ((IList)ParentMenuItems).IndexOf((object)this);
				}
				return -1;
			}
			set
			{
				int index = Index;
				if (index >= 0)
				{
					if (value < 0 || value >= ParentMenuItems.Count)
					{
						throw new ArgumentException(SR.GetString("InvalidArgument", "value", value.ToString()));
					}
					if (value != index)
					{
						ParentMenuItems.RemoveAt(index);
						ParentMenuItems.Add(value, this);
					}
				}
			}
		}

		/// 
		/// Gets the name.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Name
		{
			get
			{
				return GetValue(NameProperty, string.Empty);
			}
			set
			{
				SetValue(NameProperty, value);
			}
		}

		/// 
		/// Gets the hanlder for the Click event.
		/// </summary>
		internal EventHandler ClickHandler => (EventHandler)GetHandler(Click);

		/// 
		/// Gets the enter handler.
		/// </summary>
		/// The enter handler.</value>
		private EventHandler EnterHandler => (EventHandler)GetHandler(Enter);

		/// 
		/// Invokes when a menu item was clicked
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		public override event MenuEventHandler MenuClick
		{
			add
			{
				base.MenuClick += value;
			}
			remove
			{
				base.MenuClick -= value;
			}
		}

		/// 
		/// Occurs when a drag-and-drop operation is completed.</summary>
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		public override event DragEventHandler DragDrop
		{
			add
			{
				base.DragDrop += value;
			}
			remove
			{
				base.DragDrop -= value;
			}
		}

		/// 
		///
		/// </summary>
		public event EventHandler Click
		{
			add
			{
				AddHandler(ClickEvent, value);
			}
			remove
			{
				RemoveHandler(ClickEvent, value);
			}
		}

		/// 
		/// Occurs when [enter].
		/// </summary>
		public event EventHandler Enter
		{
			add
			{
				AddHandler(EnterEvent, value);
			}
			remove
			{
				RemoveHandler(EnterEvent, value);
			}
		}

		/// Initializes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> with a blank caption.</summary>
		public MenuItem()
		{
			TextInteranl = "";
			InitializeState();
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption for the menu item.</summary>
		/// <param name="strText">The caption for the menu item. </param>
		public MenuItem(string strText)
		{
			TextInteranl = strText;
			InitializeState();
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> class.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="strIcon">The icon.</param>
		public MenuItem(string strText, string strIcon)
		{
			TextInteranl = strText;
			if (strIcon != "")
			{
				IconInteranl = new IconResourceHandle(strIcon + ".gif");
			}
			InitializeState();
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> class.
		/// </summary>
		/// <param name="strText">The menu item Text</param>
		/// <param name="strIcon">The menu item icon</param>
		/// <param name="objTag">The obj tag.</param>
		public MenuItem(string strText, string strIcon, object objTag)
			: this(strText, strIcon)
		{
			base.Tag = objTag;
		}

		/// Initializes a new instance of the class with a specified caption and event handler for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event of the menu item.</summary>
		/// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
		/// <param name="strText">The caption for the menu item. </param>
		public MenuItem(string strText, EventHandler onClick)
			: this(MenuMerge.Add, 0, Shortcut.None, strText, onClick, null, null, null)
		{
		}

		/// Initializes a new instance of the class with a specified caption and an array of submenu items defined for the menu item.</summary>
		/// The items param is not impemented.
		/// <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
		/// <param name="strText">The caption for the menu item. </param>
		[Obsolete("The items param is not impemented use public MenuItem(string strText)")]
		public MenuItem(string strText, MenuItem[] arrItems)
			: this(MenuMerge.Add, 0, Shortcut.None, strText, null, null, null, arrItems)
		{
		}

		/// Initializes a new instance of the class with a specified caption, event handler, and associated shortcut key for the menu item.</summary>
		/// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
		/// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
		/// <param name="strText">The caption for the menu item. </param>
		public MenuItem(string strText, EventHandler onClick, Shortcut enmShortcut)
			: this(MenuMerge.Add, 0, enmShortcut, strText, onClick, null, null, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption; defined event-handlers for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see>, <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> and <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> events; a shortcut key; a merge type; and order specified for the menu item.</summary>
		/// The mergeType, mergeOrder, onSelect, onPopup and items params are not impemented.
		/// <param name="onSelect">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> event for this menu item[not impemented]. </param>
		/// <param name="intMergeOrder">The relative position that this menu item will take in a merged menu[not impemented]. </param>
		/// <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
		/// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
		/// <param name="enmMergeType">One of the <see cref="T:Gizmox.WebGUI.Forms.MenuMerge"></see> values[not impemented]. </param>
		/// <param name="onPopup">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> event for this menu item[not impemented]. </param>
		/// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
		/// <param name="strText">The caption for the menu item. </param>
		[Obsolete("TThe mergeType, mergeOrder, onSelect, onPopup and items params are not impemented use public MenuItem(string text, EventHandler onClick, Shortcut shortcut)")]
		public MenuItem(MenuMerge enmMergeType, int intMergeOrder, Shortcut enmShortcut, string strText, EventHandler onClick, EventHandler onPopup, EventHandler onSelect, MenuItem[] arrItems)
		{
			TextInteranl = strText;
			Click += onClick;
			ShortcutInternal = enmShortcut;
			InitializeState();
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			if (!Visible || !Enabled)
			{
				return;
			}
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "DoubleClick":
				if (Enabled && InternalParent != null && InternalParent is MainMenu)
				{
					((MainMenu)InternalParent).FireDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				}
				break;
			case "Shortcut":
			case "Click":
			{
				if (!Enabled)
				{
					break;
				}
				bool flag = true;
				if (objEvent.Type == "Click")
				{
					flag = MouseButtons.Left == GetEventButtonsValue(objEvent, MouseButtons.Left);
					if (InternalParent != null && InternalParent is MainMenu)
					{
						((MainMenu)InternalParent).FireClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
					}
				}
				if (flag)
				{
					if (base.MenuItems.Count == 0)
					{
						OnClick(new EventArgs());
					}
					else
					{
						Show(this, Point.Empty, DialogAlignment.Below);
					}
					Component ancestorByType = GetAncestorByType(typeof(Control));
					if (ancestorByType != null && base.MenuItems.Count == 0)
					{
						ancestorByType.FireMenuClick(this);
					}
				}
				break;
			}
			case "Enter":
				if (Enabled && EnterHandler != null)
				{
					EnterHandler(this, new EventArgs());
				}
				break;
			}
		}

		/// 
		/// Raises the <see cref="E:Click" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnClick(EventArgs objEventArgs)
		{
			if (ClickHandler != null)
			{
				ClickHandler(this, objEventArgs);
			}
		}

		internal void AttachedToDOM()
		{
			RegisterShortcut();
			base.MenuItems.AttachedToDOM();
		}

		internal void RemovingFromDOM()
		{
			UnregisterShortcut(blnForce: false);
			base.MenuItems.RemovingFromDOM();
		}

		private void UnregisterShortcut(bool blnForce)
		{
			if (ShortcutInternal != Shortcut.None || blnForce)
			{
				Form?.Shortcuts.Remove(this);
			}
		}

		private void RegisterShortcut()
		{
			if (ShortcutInternal != Shortcut.None)
			{
				Form?.Shortcuts.Add(ShortcutInternal.ToString(), this);
			}
		}

		/// 
		/// Fires the click.
		/// </summary>
		internal void FireClick()
		{
			if (ClickHandler != null)
			{
				ClickHandler(this, new EventArgs());
			}
			if (Parent != null)
			{
				Parent.FireClick(this);
			}
		}

		/// 
		/// Initializes the state.
		/// </summary>
		private void InitializeState()
		{
			SetState(ComponentState.Visible | ComponentState.Enabled, blnValue: true);
		}

		/// 
		/// Disposes the specified component.
		/// </summary>
		/// <param name="blnDisposing"></param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing && Parent != null)
			{
				Parent.MenuItems.Remove(this);
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return base.MenuItems;
		}

		static MenuItem()
		{
			Click = SerializableEvent.Register("Click", typeof(EventHandler), typeof(MenuItem));
			Enter = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(MenuItem));
			ShowShortcutProperty = SerializableProperty.Register("ShowShortcut", typeof(bool), typeof(MenuItem));
			NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(MenuItem));
		}
	}
}
