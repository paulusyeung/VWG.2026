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

namespace Gizmox.WebGUI.Forms.Skins
{
/// 
	/// MainMenu Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(MainMenu), "MainMenu.bmp")]
	public class MainMenuSkin : ControlSkin
	{
		/// 
		/// Gets or sets the height of the menu.
		/// </summary>
		/// The height of the menu.</value>
		[Category("Sizes")]
		[Description("The height of the main menu.")]
		public virtual int Height
		{
			get
			{
				return GetValue("Height", DefaultHeight);
			}
			set
			{
				SetValue("Height", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultHeight => 22;

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Category("Sizes")]
		[Description("Gets or sets the width of the left frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int LeftFrameWidth => GetImageWidth(LeftFrameStyle.BackgroundImage);

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Category("Sizes")]
		[Description("Gets or sets the width of the right frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightFrameWidth => GetImageWidth(RightFrameStyle.BackgroundImage);

		/// 
		/// Gets or sets the width of the seperator.
		/// </summary>
		/// The width of the seperator.</value>
		[Category("Sizes")]
		[Description("The width of the seperator.")]
		public virtual int SeperatorWidth
		{
			get
			{
				return GetValue("SeperatorWidth", DefaultSeperatorWidth);
			}
			set
			{
				SetValue("SeperatorWidth", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultSeperatorWidth => 0;

		/// 
		/// Gets the top menu item hover style.
		/// </summary>
		/// The top menu item hover style.</value>
		[Category("States")]
		[Description("The top menu item hover style.")]
		public virtual SimpleFrameStyleValue FrameStyle => new SimpleFrameStyleValue(LeftFrameStyle, RightFrameStyle, CenterFrameStyle);

		/// 
		/// Gets the right frame style.
		/// </summary>
		/// The right frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightFrameStyle => new StyleValue(this, "RightFrameStyle");

		/// 
		/// Gets the left frame style.
		/// </summary>
		/// The left frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftFrameStyle => new StyleValue(this, "LeftFrameStyle");

		/// 
		/// Gets the center frame style.
		/// </summary>
		/// The center frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterFrameStyle => new StyleValue(this, "CenterFrameStyle");

		/// 
		/// Gets the top menu item normal style.
		/// </summary>
		/// The top menu item normal style.</value>
		[Category("States")]
		[Description("The top menu item normal style.")]
		public virtual SimpleFrameStyleValue MenuItemNormalStyle => new SimpleFrameStyleValue(LeftMenuItemNormalStyle, RightMenuItemNormalStyle, CenterMenuItemNormalStyle);

		/// 
		/// Gets the top menu item pressed style.
		/// </summary>
		/// The top menu item pressed style.</value>
		[Category("States")]
		[Description("The top menu item pressed style.")]
		public virtual SimpleFrameStyleValue MenuItemPressedStyle => new SimpleFrameStyleValue(LeftMenuItemPressedStyle, RightMenuItemPressedStyle, CenterMenuItemPressedStyle);

		/// 
		/// Gets the top menu item hover style.
		/// </summary>
		/// The top menu item hover style.</value>
		[Category("States")]
		[Description("The top menu item hover style.")]
		public virtual SimpleFrameStyleValue MenuItemHoverStyle => new SimpleFrameStyleValue(LeftMenuItemHoverStyle, RightMenuItemHoverStyle, CenterMenuItemHoverStyle);

		/// 
		/// Gets the top menu item disable style.
		/// </summary>
		/// The top menu item disable style.</value>
		[Category("States")]
		[Description("The top menu item disable style.")]
		public virtual SimpleFrameStyleValue MenuItemDisableStyle => new SimpleFrameStyleValue(LeftMenuItemDisableStyle, RightMenuItemDisableStyle, CenterMenuItemDisableStyle);

		/// 
		/// Gets the right menu item normal style.
		/// </summary>
		/// The right menu item normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightMenuItemNormalStyle => new StyleValue(this, "RightMenuItemNormalStyle");

		/// 
		/// Gets the right menu item pressed style.
		/// </summary>
		/// The right menu item pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightMenuItemPressedStyle => new StyleValue(this, "RightMenuItemPressedStyle", RightMenuItemNormalStyle);

		/// 
		/// Gets the right menu item hover style.
		/// </summary>
		/// The right menu item hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightMenuItemHoverStyle => new StyleValue(this, "RightMenuItemHoverStyle", RightMenuItemNormalStyle);

		/// 
		/// Gets the left menu item normal style.
		/// </summary>
		/// The left menu item normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftMenuItemNormalStyle => new StyleValue(this, "LeftMenuItemNormalStyle");

		/// 
		/// Gets the left menu item pressed style.
		/// </summary>
		/// The left menu item pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftMenuItemPressedStyle => new StyleValue(this, "LeftMenuItemPressedStyle", LeftMenuItemNormalStyle);

		/// 
		/// Gets the left menu item hover style.
		/// </summary>
		/// The left menu item hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftMenuItemHoverStyle => new StyleValue(this, "LeftMenuItemHoverStyle", LeftMenuItemNormalStyle);

		/// 
		/// Gets or sets the width of the left menu item.
		/// </summary>
		/// The width of the left menu item.</value>
		[Category("Sizes")]
		[Description("The width of the left menu item.")]
		public virtual int LeftMenuItemWidth
		{
			get
			{
				return GetValue("LeftMenuItemWidth", GetImageWidth(LeftMenuItemNormalStyle.BackgroundImage, 0));
			}
			set
			{
				SetValue("LeftMenuItemWidth", value);
			}
		}

		/// 
		/// Gets or sets the width of the right menu item.
		/// </summary>
		/// The width of the right menu item.</value>
		[Category("Sizes")]
		[Description("The width of the right menu item.")]
		public virtual int RightMenuItemWidth
		{
			get
			{
				return GetValue("RightMenuItemWidth", GetImageWidth(RightMenuItemNormalStyle.BackgroundImage, 0));
			}
			set
			{
				SetValue("RightMenuItemWidth", value);
			}
		}

		/// 
		/// Gets the center menu item normal style.
		/// </summary>
		/// The center menu item normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterMenuItemNormalStyle => new StyleValue(this, "CenterMenuItemNormalStyle");

		/// 
		/// Gets the center menu item pressed style.
		/// </summary>
		/// The center menu item pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterMenuItemPressedStyle => new StyleValue(this, "CenterMenuItemPressedStyle", CenterMenuItemNormalStyle);

		/// 
		/// Gets the center menu item hover style.
		/// </summary>
		/// The center menu item hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterMenuItemHoverStyle => new StyleValue(this, "CenterMenuItemHoverStyle", CenterMenuItemNormalStyle);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftMenuItemDisableStyle => new StyleValue(this, "LeftMenuItemDisableStyle", LeftMenuItemNormalStyle);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterMenuItemDisableStyle => new StyleValue(this, "CenterMenuItemDisableStyle", CenterMenuItemNormalStyle);

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightMenuItemDisableStyle => new StyleValue(this, "RightMenuItemDisableStyle", RightMenuItemNormalStyle);

		/// 
		/// Gets the seperator style.
		/// </summary>
		/// The seperator style.</value>
		public virtual StyleValue SeperatorStyle => new StyleValue(this, "SeperatorStyle");

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetHeight()
		{
			Reset("Height");
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetLeftFrameWidth()
		{
			Reset("LeftFrameWidth");
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetRightFrameWidth()
		{
			Reset("RightFrameWidth");
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetSeperatorWidth()
		{
			Reset("SeperatorWidth");
		}
	}
}
