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
	public class ToolStripMenuItemSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
	{
		/// 
		/// Gets the tool strip menu item style.
		/// </summary>
		/// The tool strip menu item style.</value>
		[Category("States")]
		[SRDescription("The tool strip menu item style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemStyle => new StyleValue(this, "MenuItemStyle");

		/// 
		/// Gets the menu item hover style.
		/// </summary>
		/// The menu item hover style.</value>
		[Category("States")]
		[SRDescription("The tool strip menu item over style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemHoverStyle => new StyleValue(this, "MenuItemHoverStyle");

		/// 
		/// Gets the menu item down style.
		/// </summary>
		/// The menu item down style.</value>
		[Category("States")]
		[SRDescription("The tool strip menu item down style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemDownStyle => new StyleValue(this, "MenuItemDownStyle");

		/// 
		/// Gets the disabled menu item style.
		/// </summary>
		/// The disabled menu item style.</value>
		[Category("States")]
		[SRDescription("The tool strip menu item disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue DisabledMenuItemTextStyle => new StyleValue(this, "DisabledMenuItemTextStyle");

		/// 
		/// Gets the arrow image width LTR.
		/// </summary>
		/// The arrow image width LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int MenuItemArrowImageWidthLTR => GetImageWidth(MenuItemArrowLTR.BackgroundImage, 7);

		/// 
		/// Gets the arrow image width RTL.
		/// </summary>
		/// The arrow image width RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int MenuItemArrowImageWidthRTL => GetImageWidth(MenuItemArrowRTL.BackgroundImage, 7);

		/// 
		/// Gets the width of the arrow image.
		/// </summary>
		/// The width of the arrow image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SkinValue MenuItemArrowImageWidth => new BidirectionalSkinValue<object>(this, MenuItemArrowImageWidthLTR, MenuItemArrowImageWidthRTL);

		/// 
		/// Gets the menu item image style.
		/// </summary>
		/// The menu item image style.</value>
		[Category("States")]
		[SRDescription("The menu item image style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinValue<object> MenuItemImageStyle => new BidirectionalSkinValue<object>(this, MenuItemImageStyleLTR, MenuItemImageStyleRTL);

		/// 
		/// Gets the menu item image style LTR.
		/// </summary>
		/// The menu item image style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemImageStyleLTR => new StyleValue(this, "MenuItemImageStyleLTR");

		/// 
		/// Gets the menu item image style RTL.
		/// </summary>
		/// The menu item image style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemImageStyleRTL => new StyleValue(this, "MenuItemImageStyleRTL");

		/// 
		/// Gets the width of the tool strip menu item image.
		/// </summary>
		/// The width of the tool strip menu item image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SkinValue MenuItemImageWidth => new BidirectionalSkinValue<object>(this, MenuItemImageWidthLTR, MenuItemImageWidthRTL);

		/// 
		/// Gets the tool strip menu item image width LTR.
		/// </summary>
		/// The tool strip menu item image width LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int MenuItemImageWidthLTR => GetImageWidth(MenuItemImageStyleLTR.BackgroundImage, 32);

		/// 
		/// Gets the tool strip menu item image width RTL.
		/// </summary>
		/// The tool strip menu item image width RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int MenuItemImageWidthRTL => GetImageWidth(MenuItemImageStyleRTL.BackgroundImage, 32);

		/// 
		/// Gets the menu item arrow.
		/// </summary>
		/// The menu item arrow.</value>
		[Category("States")]
		[SRDescription("The menu item arrow style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinValue<object> MenuItemArrow => new BidirectionalSkinValue<object>(this, MenuItemArrowLTR, MenuItemArrowRTL);

		/// 
		/// Gets the menu item arrow LTR.
		/// </summary>
		/// The menu item arrow LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemArrowLTR => new StyleValue(this, "MenuItemArrowLTR");

		/// 
		/// Gets the menu item arrow RTL.
		/// </summary>
		/// The menu item arrow RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemArrowRTL => new StyleValue(this, "MenuItemArrowRTL");

		/// 
		/// Gets the menu item arrow disabled.
		/// </summary>
		/// The menu item arrow disabled.</value>
		[Category("States")]
		[SRDescription("The menu item arrow disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinValue<object> MenuItemArrowDisabled => new BidirectionalSkinValue<object>(this, MenuItemArrowDisabledLTR, MenuItemArrowDisabledRTL);

		/// 
		/// Gets the menu item arrow disabled LTR.
		/// </summary>
		/// The menu item arrow disabled LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemArrowDisabledLTR => new StyleValue(this, "MenuItemArrowDisabledLTR");

		/// 
		/// Gets the menu item arrow disabled RTL.
		/// </summary>
		/// The menu item arrow disabled RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue MenuItemArrowDisabledRTL => new StyleValue(this, "MenuItemArrowDisabledRTL");

		/// 
		/// Gets the menu item checked.
		/// </summary>
		/// The menu item checked.</value>
		[Category("States")]
		[SRDescription("The menu item checked style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemChecked => new StyleValue(this, "MenuItemChecked");

		/// 
		/// Gets the menu item checked disabled.
		/// </summary>
		/// The menu item checked disabled.</value>
		[Category("States")]
		[SRDescription("The menu item checked disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemCheckedDisabled => new StyleValue(this, "MenuItemCheckedDisabled");

		/// 
		/// Gets the menu item indeterminate.
		/// </summary>
		/// The menu item indeterminate.</value>
		[Category("States")]
		[SRDescription("The menu item indeterminate style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemIndeterminate => new StyleValue(this, "MenuItemIndeterminate");

		/// 
		/// Gets the menu item indeterminate disabled.
		/// </summary>
		/// The menu item indeterminate disabled.</value>
		[Category("States")]
		[SRDescription("The menu item indeterminate disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue MenuItemIndeterminateDisabled => new StyleValue(this, "MenuItemIndeterminateDisabled");

		/// 
		/// Gets or sets the size of the text image gap.
		/// </summary>
		/// The size of the text image gap.</value>
		[Category("Sizes")]
		[SRDescription("The size of the gap between text and image elements.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int TextImageGapSize
		{
			get
			{
				return GetValue("TextImageGapSize", DefaultTextImageGapSize);
			}
			set
			{
				SetValue("TextImageGapSize", value);
			}
		}

		/// 
		/// Gets or sets the number of pixels to add to the calculated max image width to allow spacing around images
		/// </summary>
		/// The extra width in pixels added for image area in addition to calculated image width.</value>
		[Category("Sizes")]
		[SRDescription("The extra width in pixels added for image area in addition to calculated image width.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(4)]
		public int MenuItemImageExtraWidth
		{
			get
			{
				return GetValue("MenuItemImageExtraWidth", 4);
			}
			set
			{
				SetValue("MenuItemImageExtraWidth", value);
			}
		}

		/// 
		/// Gets or sets the size of the text image gap.
		/// </summary>
		/// The size of the text image gap.</value>
		[Category("Sizes")]
		[SRDescription("The padding between the arrow and the end of the menu item.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int ArrowEdgeGapSize
		{
			get
			{
				return GetValue("ArrowEdgeGapSize", 3);
			}
			set
			{
				SetValue("ArrowEdgeGapSize", value);
			}
		}

		/// 
		/// Gets the size of the default text image gap.
		/// </summary>
		/// The size of the default text image gap.</value>
		private int DefaultTextImageGapSize => 8;

		/// 
		/// Gets or sets the size of the text shortcut gap.
		/// </summary>
		/// 
		/// The size of the text shortcut gap.
		/// </value>
		[Category("Sizes")]
		[SRDescription("The size of the gap between text and its shortcut.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int TextShortcutGapSize
		{
			get
			{
				return GetValue("TextShortcutGapSize", 8);
			}
			set
			{
				SetValue("TextShortcutGapSize", value);
			}
		}

		/// 
		/// Gets or sets the end size of the spacing.
		/// </summary>
		/// 
		/// The end size of the spacing.
		/// </value>
		[Category("Sizes")]
		[SRDescription("The size of the gap between text and menu item arrow.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int TextArrowGapSize
		{
			get
			{
				return GetValue("TextArrowGapSize", 10);
			}
			set
			{
				SetValue("TextArrowGapSize", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the size of the text shortcut gap.
		/// </summary>
		internal void ResetTextShortcutGapSize()
		{
			Reset("TextShortcutGapSize");
		}

		/// 
		/// Resets the size of the text arrow gap.
		/// </summary>
		internal void ResetTextArrowGapSize()
		{
			Reset("TextArrowGapSize");
		}
	}
}
