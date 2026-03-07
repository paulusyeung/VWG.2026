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
	/// Represents a selectable option displayed on a <see cref="T:System.Windows.Forms.MenuStrip"></see> or <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. Although <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> replaces and adds functionality to the <see cref="T:System.Windows.Forms.MenuItem"></see> control of previous versions, <see cref="T:System.Windows.Forms.MenuItem"></see> is retained for both backward compatibility and future use if you choose.</summary>
	[Serializable]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)6)]
	[Skin(typeof(ToolStripMenuItemSkin))]
	public class ToolStripMenuItem : ToolStripDropDownItem
	{
		private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register("mblnCheckOnClick", typeof(bool), typeof(ToolStripMenuItem));

		private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register("menmCheckState", typeof(CheckState), typeof(ToolStripMenuItem));

		private static readonly SerializableProperty mobjMdiFormProperty = SerializableProperty.Register("mobjMdiForm", typeof(Form), typeof(ToolStripMenuItem));

		private static readonly SerializableProperty mstrShortcutKeyDisplayStringProperty = SerializableProperty.Register("mstrShortcutKeyDisplayString", typeof(string), typeof(ToolStripMenuItem));

		private static readonly SerializableProperty menmShortcutKeysProperty = SerializableProperty.Register("menmShortcutKeys", typeof(Keys), typeof(ToolStripMenuItem));

		private static readonly SerializableProperty mblnShowShortcutKeysProperty = SerializableProperty.Register("mblnShowShortcutKeys", typeof(bool), typeof(ToolStripMenuItem));

		private static readonly SerializableEvent CheckedChangedEvent;

		private static readonly SerializableEvent CheckStateChangedEvent;

		[NonSerialized]
		private TypeConverter mobjTypeConverter = null;

		/// 
		/// Gets the CheckedChanged handler.
		/// </summary>
		/// The CheckedChanged handler.</value>
		private EventHandler CheckedChangedHandler => (EventHandler)GetHandler(CheckedChanged);

		/// 
		/// Gets the CheckStateChanged handler.
		/// </summary>
		/// The CheckStateChanged handler.</value>
		private EventHandler CheckStateChangedHandler => (EventHandler)GetHandler(CheckStateChanged);

		private bool mblnCheckOnClick
		{
			get
			{
				return GetValue(mblnCheckOnClickProperty);
			}
			set
			{
				SetValue(mblnCheckOnClickProperty, value);
			}
		}

		private CheckState menmCheckState
		{
			get
			{
				return GetValue(menmCheckStateProperty, CheckState.Unchecked);
			}
			set
			{
				SetValue(menmCheckStateProperty, value);
			}
		}

		private Form mobjMdiForm
		{
			get
			{
				return GetValue(mobjMdiFormProperty, null);
			}
			set
			{
				SetValue(mobjMdiFormProperty, value);
			}
		}

		private string mstrShortcutKeyDisplayString
		{
			get
			{
				return GetValue(mstrShortcutKeyDisplayStringProperty);
			}
			set
			{
				SetValue(mstrShortcutKeyDisplayStringProperty, value);
			}
		}

		private Keys menmShortcutKeys
		{
			get
			{
				return GetValue(menmShortcutKeysProperty, Keys.None);
			}
			set
			{
				SetValue(menmShortcutKeysProperty, value);
			}
		}

		private bool mblnShowShortcutKeys
		{
			get
			{
				return GetValue(mblnShowShortcutKeysProperty);
			}
			set
			{
				SetValue(mblnShowShortcutKeysProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance is top level.
		/// </summary>
		/// 
		/// 	true</c> if this instance is top level; otherwise, false</c>.
		/// </value>
		internal bool IsTopLevel => !(base.ParentInternal is ToolStripDropDown);

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 7;

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked or is in an indeterminate state; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DefaultValue(false)]
		[Bindable(true)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("CheckBoxCheckedDescr")]
		[SRCategory("CatAppearance")]
		public bool Checked
		{
			get
			{
				return CheckState != CheckState.Unchecked;
			}
			set
			{
				if (value != Checked)
				{
					CheckState = (value ? CheckState.Checked : CheckState.Unchecked);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked and unchecked when clicked.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked when clicked; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("ToolStripButtonCheckOnClickDescr")]
		public bool CheckOnClick
		{
			get
			{
				return mblnCheckOnClick;
			}
			set
			{
				if (mblnCheckOnClick != value)
				{
					mblnCheckOnClick = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is in the checked, unchecked, or indeterminate state.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property is not set to one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception> 
		/// 1</filterpriority>
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("CheckBoxCheckStateDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(CheckState.Unchecked)]
		[Bindable(true)]
		public CheckState CheckState
		{
			get
			{
				return menmCheckState;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
				}
				if (value != CheckState)
				{
					menmCheckState = value;
					OnCheckedChanged(EventArgs.Empty);
					OnCheckStateChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns>
		///
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatLayout")]
		[DefaultValue(ToolStripItemOverflow.Never)]
		[SRDescription("ToolStripItemOverflowDescr")]
		public new ToolStripItemOverflow Overflow
		{
			get
			{
				return ToolStripItemOverflow.Never;
			}
			set
			{
			}
		}

		/// Gets the internal spacing within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value representing the spacing.</returns>
		protected override Padding DefaultPadding
		{
			get
			{
				if (base.IsOnDropDown)
				{
					return new Padding(0, 1, 0, 1);
				}
				return new Padding(4, 0, 4, 0);
			}
		}

		/// Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
		/// The <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, measured in pixels. The default is 100 pixels horizontally.</returns>
		protected override Size DefaultSize => new Size(32, 19);

		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a multiple document interface (MDI) window list.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a MDI window list; otherwise, false.</returns>
		[Browsable(false)]
		public bool IsMdiWindowListEntry => MdiForm != null;

		/// 
		/// Gets the MDI form.
		/// </summary>
		/// The MDI form.</value>
		internal Form MdiForm => mobjMdiForm;

		/// Gets or sets the shortcut key text.</summary> 
		/// A <see cref="T:System.String"></see> representing the shortcut key.</returns>
		[SRDescription("ToolStripMenuItemShortcutKeyDisplayStringDescr")]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[DefaultValue(null)]
		public string ShortcutKeyDisplayString
		{
			get
			{
				return mstrShortcutKeyDisplayString;
			}
			set
			{
				if (mstrShortcutKeyDisplayString != value)
				{
					mstrShortcutKeyDisplayString = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the shortcut keys associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Keys.None"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property was not set to one of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values.</exception>
		[Localizable(true)]
		[DefaultValue(Keys.None)]
		[SRDescription("MenuItemShortCutDescr")]
		public Keys ShortcutKeys
		{
			get
			{
				return menmShortcutKeys;
			}
			set
			{
				if (value != Keys.None && !IsValidShortcut(value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(Keys));
				}
				Keys shortcutKeys = ShortcutKeys;
				if (shortcutKeys == value)
				{
					return;
				}
				menmShortcutKeys = value;
				if (!base.DesignMode)
				{
					if (value == Keys.None)
					{
						UnregisterShortcut(blnForce: true);
					}
					else
					{
						RegisterShortcut();
					}
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets the forecolor from skin.
		/// </summary>
		/// 
		/// The color of the skin fore.
		/// </value>
		protected override Color SkinForeColor
		{
			get
			{
				Color result = Color.Empty;
				if (SkinFactory.GetSkin(this) is ToolStripMenuItemSkin toolStripMenuItemSkin)
				{
					result = toolStripMenuItemSkin.MenuItemStyle.ForeColor;
				}
				return result;
			}
		}

		/// Gets or sets a value indicating whether the shortcut keys that are associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> are displayed next to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary> 
		/// true if the shortcut keys are shown; otherwise, false. The default is true.</returns>
		[Localizable(true)]
		[SRDescription("MenuItemShowShortCutDescr")]
		[DefaultValue(true)]
		public bool ShowShortcutKeys
		{
			get
			{
				return mblnShowShortcutKeys;
			}
			set
			{
				if (value != mblnShowShortcutKeys)
				{
					mblnShowShortcutKeys = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.Checked"></see> property changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler CheckedChanged
		{
			add
			{
				AddCriticalHandler(CheckedChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CheckedChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler CheckStateChanged
		{
			add
			{
				AddCriticalHandler(CheckStateChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CheckStateChangedEvent, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class.</summary>
		public ToolStripMenuItem()
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text.</summary> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text)
			: base(text, (ResourceHandle)null, (EventHandler)null)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
		public ToolStripMenuItem(ResourceHandle image)
			: base((string)null, image, (EventHandler)null)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image.</summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text, ResourceHandle image)
			: base(text, image, (EventHandler)null)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary> 
		/// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, onClick)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class with the specified name that displays the specified text and image that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary> 
		/// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
		/// <param name="name">The name of the menu item.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, onClick, null)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that contains the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection.</summary> 
		/// <param name="dropDownItems">The menu items to display when the control is clicked.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
			: base(text, image, dropDownItems)
		{
			mblnShowShortcutKeys = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image, does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked, and displays the specified shortcut keys.</summary> 
		/// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param> 
		/// <param name="shortcutKeys">One of the values of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> that represents the shortcut key for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param> 
		/// <param name="text">The text to display on the menu item.</param>
		public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick, Keys shortcutKeys)
			: base(text, image, onClick)
		{
			mblnShowShortcutKeys = true;
			ShortcutKeys = shortcutKeys;
		}

		/// 
		/// Gets the preferred size with image.
		/// </summary>
		/// <param name="objSizeWithoutImage">The obj size without image.</param>
		/// </returns>
		protected internal override Size GetPreferredSizeByImage(Size objSizeWithoutImage)
		{
			return base.GetPreferredSizeByImage(objSizeWithoutImage);
		}

		/// 
		/// Gets the preferred size by text.
		/// </summary>
		/// </returns>
		protected internal override Size GetPreferredeSizeByText()
		{
			if ((DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || DisplayStyle == ToolStripItemDisplayStyle.Text) && !string.IsNullOrEmpty(Text))
			{
				return GetTextSize(Text);
			}
			return GetTextSize(" ");
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fit.
		/// </summary>
		/// <param name="objConstrainingSize">The custom-sized area for a control.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
		/// </returns>
		/// 
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   </PermissionSet>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			Size preferredeSizeByText = GetPreferredeSizeByText();
			preferredeSizeByText = GetPreferredSizeByImage(preferredeSizeByText);
			if (SkinFactory.GetSkin(this) is ToolStripMenuItemSkin toolStripMenuItemSkin)
			{
				string shortcutKeyDisplayString = GetShortcutKeyDisplayString();
				bool flag = ShowShortcutKeys && !string.IsNullOrEmpty(shortcutKeyDisplayString);
				BorderWidth borderWidth = ((toolStripMenuItemSkin.MenuItemStyle.Border.Style != BorderStyle.None) ? toolStripMenuItemSkin.MenuItemStyle.Border.Width : BorderWidth.Empty);
				BorderWidth borderWidth2 = ((toolStripMenuItemSkin.BorderStyle != BorderStyle.None) ? toolStripMenuItemSkin.BorderWidth : BorderWidth.Empty);
				preferredeSizeByText.Width += toolStripMenuItemSkin.Padding.Horizontal + borderWidth2.Left + borderWidth2.Right + borderWidth.Left + borderWidth.Right;
				preferredeSizeByText.Height += toolStripMenuItemSkin.Padding.Vertical + borderWidth2.Top + borderWidth2.Bottom + borderWidth.Top + borderWidth.Bottom;
				if (!IsTopLevel && flag)
				{
					preferredeSizeByText.Width += toolStripMenuItemSkin.TextShortcutGapSize;
					preferredeSizeByText.Width += toolStripMenuItemSkin.ArrowEdgeGapSize;
					preferredeSizeByText.Width += GetTextSize(GetShortcutKeyDisplayString()).Width;
				}
			}
			return preferredeSizeByText;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "Shortcut":
				OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				break;
			case "CheckedChange":
			{
				bool result = false;
				if (bool.TryParse(objEvent["C"], out result))
				{
					Checked = result;
				}
				break;
			}
			case "Enter":
				OnEnter();
				break;
			}
		}

		/// 
		/// Renders the tool strip item's drop down attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		protected override void RenderToolStripDropDownItemDropDownAttribute(IAttributeWriter objAttributeWriter)
		{
		}

		/// 
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
			RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, blnForceRender: false);
			RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, blnForceRender: false);
			RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, blnForceRender: false);
			RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, blnForce: false);
		}

		/// 
		/// Renders the toolstrip menu item short cut attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForce">if set to true</c> [BLN force].</param>
		private void RenderToolstripMenuItemShortCutAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForce)
		{
			string shortcutKeyDisplayString = GetShortcutKeyDisplayString();
			if (!string.IsNullOrEmpty(shortcutKeyDisplayString))
			{
				objAttributeWriter.WriteAttributeString("SC", shortcutKeyDisplayString);
				objAttributeWriter.WriteAttributeString("SCW", GetTextSize(shortcutKeyDisplayString).Width.ToString());
			}
			else if (blnForce)
			{
				objAttributeWriter.WriteAttributeString("SC", string.Empty);
				objAttributeWriter.WriteAttributeString("SCW", "");
			}
		}

		/// 
		/// Renders the tool strip item checked on click attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderToolStripItemCheckedOnClickAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (mblnCheckOnClick || blnForceRender)
			{
				objAttributeWriter.WriteAttributeText("COC", mblnCheckOnClick ? "1" : "0");
			}
		}

		/// 
		/// Renders the tool strip item has nodes attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected virtual void RenderToolStripItemHasNodesAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool flag = base.DropDownItems.Count > 0;
			if (flag || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("HN", flag ? "1" : "0");
			}
		}

		/// 
		/// Renders the tool strip item updated attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
		{
			base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, blnForceRender: true);
				RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, blnForce: false);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Extended))
			{
				RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the tool strip item checked attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected virtual void RenderToolStripItemCheckedAttribute(IContext objContext, IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			CheckState checkState = CheckState;
			if (checkState != CheckState.Unchecked || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("C", Convert.ToInt32(checkState).ToString());
			}
		}

		/// 
		/// Handles the Enter event of the MenuItemControl control.
		/// </summary>
		private void OnEnter()
		{
			base.DropDown?.Show();
		}

		/// Retrieves a value indicating whether a defined shortcut key is valid.</summary>
		/// true if the shortcut key is valid; otherwise, false. </returns>
		/// <param name="shortcut">The shortcut key to test for validity.</param>
		private bool IsValidShortcut(Keys shortcut)
		{
			Keys keys = shortcut & Keys.KeyCode;
			Keys keys2 = shortcut & Keys.Modifiers;
			if (shortcut == Keys.None)
			{
				return false;
			}
			Keys keys3 = keys;
			if (keys3 == Keys.Insert || keys3 == Keys.Delete)
			{
				return true;
			}
			if (keys < Keys.F1 || keys > Keys.F24)
			{
				if (keys == Keys.None || keys2 == Keys.None)
				{
					return false;
				}
				switch (keys)
				{
				case Keys.ShiftKey:
				case Keys.ControlKey:
				case Keys.Menu:
					return false;
				}
				if (keys2 == Keys.Shift)
				{
					return false;
				}
			}
			return true;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckedChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			CheckedChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckStateChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnCheckStateChanged(EventArgs e)
		{
			CheckStateChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Gets the shortcut string.
		/// </summary>
		/// </returns>
		private string GetShortcutString(Keys enmShortcutKeys)
		{
			if (mobjTypeConverter == null)
			{
				mobjTypeConverter = TypeDescriptor.GetConverter(typeof(Keys));
			}
			return mobjTypeConverter.ConvertToString(enmShortcutKeys);
		}

		/// 
		/// Attacheds to DOM.
		/// </summary>
		internal void AttachedToDOM()
		{
			RegisterShortcut();
			foreach (ToolStripItem dropDownItem in base.DropDownItems)
			{
				if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
				{
					toolStripMenuItem.AttachedToDOM();
				}
			}
		}

		/// 
		/// Removings from DOM.
		/// </summary>
		internal void RemovingFromDOM()
		{
			UnregisterShortcut(blnForce: false);
			foreach (ToolStripItem dropDownItem in base.DropDownItems)
			{
				if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
				{
					toolStripMenuItem.RemovingFromDOM();
				}
			}
		}

		/// 
		/// Unregisters the shortcut.
		/// </summary>
		/// <param name="blnForce">if set to true</c> [BLN force].</param>
		private void UnregisterShortcut(bool blnForce)
		{
			Keys keys = menmShortcutKeys;
			if (keys != Keys.None || blnForce)
			{
				GetForm(base.Owner)?.Shortcuts.Remove(this);
			}
		}

		/// 
		/// Registers the shortcut.
		/// </summary>
		private void RegisterShortcut()
		{
			Keys keys = menmShortcutKeys;
			if (keys != Keys.None)
			{
				GetForm(base.Owner)?.Shortcuts.Add(KeyToShortcut(keys), this);
			}
		}

		/// 
		/// Keys to shortcut.
		/// </summary>
		/// <param name="enmKeys">The enm keys.</param>
		/// </returns>
		private string KeyToShortcut(Keys enmKeys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if ((enmKeys & Keys.Control) == Keys.Control)
			{
				stringBuilder.Append("Ctrl");
			}
			if ((enmKeys & Keys.Shift) == Keys.Shift)
			{
				stringBuilder.Append("Shift");
			}
			if ((enmKeys & Keys.Alt) == Keys.Alt)
			{
				stringBuilder.Append("Alt");
			}
			stringBuilder.Append(GetShortcutString(enmKeys & Keys.KeyCode));
			return stringBuilder.ToString();
		}

		/// 
		/// Gets the form.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// </returns>
		private Form GetForm(Component objComponent)
		{
			if (objComponent is ToolStripDropDown)
			{
				return GetForm(((ToolStripDropDown)objComponent).OwnerItem);
			}
			if (objComponent is ToolStrip)
			{
				return objComponent.Form;
			}
			if (objComponent is ToolStripItem)
			{
				return GetForm(((ToolStripItem)objComponent).Owner);
			}
			return null;
		}

		/// 
		/// Gets the shortcut key display string.
		/// </summary>
		/// </returns>
		private string GetShortcutKeyDisplayString()
		{
			string text = string.Empty;
			if (ShowShortcutKeys)
			{
				text = ShortcutKeyDisplayString;
				if (string.IsNullOrEmpty(text))
				{
					Keys shortcutKeys = ShortcutKeys;
					if (shortcutKeys != Keys.None)
					{
						text = GetShortcutString(shortcutKeys);
					}
				}
			}
			return text;
		}

		static ToolStripMenuItem()
		{
			CheckedChanged = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(ToolStripMenuItem));
			CheckStateChanged = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(ToolStripMenuItem));
		}
	}
}
