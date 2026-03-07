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
	/// Menu Item Skin
	/// </summary>    
	[Serializable]
	[ToolboxBitmap(typeof(Menu), "MainMenu.bmp")]
	public class MenuItemSkin : ControlSkin
	{
		/// 
		/// Gets the menu item Background LTR.
		/// </summary>
		/// The menu item Background LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundStyleValue BackgroundLTR => new BackgroundStyleValue(this, "BackgroundLTR");

		/// 
		/// Gets the menu item Background RTL.
		/// </summary>
		/// The menu item Background RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundStyleValue BackgroundRTL => new BackgroundStyleValue(this, "BackgroundRTL", BackgroundLTR);

		/// 
		/// Gets the menu item background.
		/// </summary>
		/// The background.</value>
		[Category("States")]
		[Description("The menu item Background.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> MenuItemBackground => new BidirectionalSkinValue<object>(this, BackgroundLTR, BackgroundRTL);

		/// 
		/// Gets the menu item seperator row.
		/// </summary>
		/// The menu item seperator row.</value>
		[Category("States")]
		[Description("The menu item seperator row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue MenuItemSeperator => new StyleValue(this, "MenuItemSeperator");

		/// 
		/// Gets the seperator icon column.
		/// </summary>
		/// The seperator icon column.</value>
		[Category("States")]
		[Description("The seperator icon column style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SeperatorIconColumn => new StyleValue(this, "SeperatorIconColumn");

		/// 
		/// Gets the menu item normal.
		/// </summary>
		/// The menu item normal.</value>
		[Category("States")]
		[Description("The item  normal  style.")]
		public BidirectionalSkinValue<object> MenuItemNormal => new BidirectionalSkinValue<object>(this, MenuItemNormalLTR, MenuItemNormalRTL);

		/// 
		/// Gets the item row normal LTR style.
		/// </summary>
		/// The item row normal LTR style.</value>
		[Category("States")]
		[Description("The item  normal LTR style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemNormalLTR => new TripleCellFrameStyleValue(MenuItemNormalLeftLTR, MenuItemNormalRightLTR, MenuItemNormalCenterLTR);

		/// 
		/// Gets the item row normal RTL style.
		/// </summary>
		/// The item row normal RTL style.</value>
		[Category("States")]
		[Description("The item  normal RTL style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemNormalRTL => new TripleCellFrameStyleValue(MenuItemNormalLeftRTL, MenuItemNormalRightRTL, MenuItemNormalCenterRTL);

		/// 
		/// Gets the item row normal left LTR style.
		/// </summary>
		/// The item row normal left LTR style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalLeftLTR => new StyleValue(this, "MenuItemNormalLeftLTR");

		/// 
		/// Gets the item row normal left RTL style.
		/// </summary>
		/// The item row normal left RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalLeftRTL => new StyleValue(this, "MenuItemNormalLeftRTL");

		/// 
		/// Gets the menu item normal left.
		/// </summary>
		/// The menu item normal left.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemNormalLeft => new BidirectionalSkinValue<object>(this, MenuItemNormalLeftLTR, MenuItemNormalLeftRTL);

		/// 
		/// Gets the item row normal right LTR style.
		/// </summary>
		/// The item row normal right LTR style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalRightLTR => new StyleValue(this, "MenuItemNormalRightLTR");

		/// 
		/// Gets the item row normal right RTL style.
		/// </summary>
		/// The item row normal right RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalRightRTL => new StyleValue(this, "MenuItemNormalRightRTL");

		/// 
		/// Gets the menu item normal right.
		/// </summary>
		/// The menu item normal right.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemNormalRight => new BidirectionalSkinValue<object>(this, MenuItemNormalRightLTR, MenuItemNormalRightRTL);

		/// 
		/// Gets the item row normal center LTR style.
		/// </summary>
		/// The item row normal center LTR style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalCenterLTR => new StyleValue(this, "MenuItemNormalCenterLTR");

		/// 
		/// Gets the item row normal center RTL style.
		/// </summary>
		/// The item row normal center RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemNormalCenterRTL => new StyleValue(this, "MenuItemNormalCenterRTL");

		/// 
		/// Gets the menu item normal center.
		/// </summary>
		/// The menu item normal center.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemNormalCenter => new BidirectionalSkinValue<object>(this, MenuItemNormalCenterLTR, MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item hover.
		/// </summary>
		/// The menu item hover.</value>
		[Category("States")]
		[Description("The item  hover  style.")]
		public BidirectionalSkinValue<object> MenuItemHover => new BidirectionalSkinValue<object>(this, MenuItemHoverLTR, MenuItemHoverRTL);

		/// 
		/// Gets the item row hover LTR style.
		/// </summary>
		/// The item row hover LTR style.</value>
		[Category("States")]
		[Description("The item  Hover LTR style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemHoverLTR => new TripleCellFrameStyleValue(MenuItemHoverLeftLTR, MenuItemHoverRightLTR, MenuItemHoverCenterLTR);

		/// 
		/// Gets the item row hover RTL style.
		/// </summary>
		/// The item row hover RTL style.</value>
		[Category("States")]
		[Description("The item  Hover RTL style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemHoverRTL => new TripleCellFrameStyleValue(MenuItemHoverLeftRTL, MenuItemHoverRightRTL, MenuItemHoverCenterRTL);

		/// 
		/// Gets the menu item row hover left LTR style.
		/// </summary>
		/// The menu item row hover left LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverLeftLTR => new StyleValue(this, "MenuItemHoverLeftLTR", MenuItemNormalLeftLTR);

		/// 
		/// Gets the menu item row hover left RTL style.
		/// </summary>
		/// The menu item row hover left RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverLeftRTL => new StyleValue(this, "MenuItemHoverLeftRTL", MenuItemNormalLeftRTL);

		/// 
		/// Gets the menu item hover left.
		/// </summary>
		/// The menu item hover left.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemHoverLeft => new BidirectionalSkinValue<object>(this, MenuItemHoverLeftLTR, MenuItemHoverLeftRTL);

		/// 
		/// Gets the menu item row hover right LTR style.
		/// </summary>
		/// The menu item row hover right LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverRightLTR => new StyleValue(this, "MenuItemHoverRightLTR", MenuItemNormalRightLTR);

		/// 
		/// Gets the menu item row hover right RTL style.
		/// </summary>
		/// The menu item row hover right RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverRightRTL => new StyleValue(this, "MenuItemHoverRightRTL", MenuItemNormalRightRTL);

		/// 
		/// Gets the menu item hover right.
		/// </summary>
		/// The menu item hover right.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemHoverRight => new BidirectionalSkinValue<object>(this, MenuItemHoverRightLTR, MenuItemHoverRightRTL);

		/// 
		/// Gets the menu item row hover center LTR style.
		/// </summary>
		/// The menu item row hover center LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverCenterLTR => new StyleValue(this, "MenuItemHoverCenterLTR", MenuItemNormalCenterLTR);

		/// 
		/// Gets the menu item row hover center RTL style.
		/// </summary>
		/// The menu item row hover center RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemHoverCenterRTL => new StyleValue(this, "MenuItemHoverCenterRTL", MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item hover center.
		/// </summary>
		/// The menu item hover center.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemHoverCenter => new BidirectionalSkinValue<object>(this, MenuItemHoverCenterLTR, MenuItemHoverCenterRTL);

		/// 
		/// Gets the menu item down.
		/// </summary>
		/// The menu item down.</value>
		[Category("States")]
		[Description("The item  down  style.")]
		public BidirectionalSkinValue<object> MenuItemDown => new BidirectionalSkinValue<object>(this, MenuItemDownLTR, MenuItemDownRTL);

		/// 
		/// Gets the item row down LTR style.
		/// </summary>
		/// The item row down LTR style.</value>
		[Category("States")]
		[Description("The item down LTR style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemDownLTR => new TripleCellFrameStyleValue(MenuItemDownLeftLTR, MenuItemDownRightLTR, MenuItemDownCenterLTR);

		/// 
		/// Gets the item row down RTL style.
		/// </summary>
		/// The item row down RTL style.</value>
		[Category("States")]
		[Description("The item  down RTL style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemDownRTL => new TripleCellFrameStyleValue(MenuItemDownLeftRTL, MenuItemDownRightRTL, MenuItemDownCenterRTL);

		/// 
		/// Gets the menu item row down left LTR style.
		/// </summary>
		/// The menu item row down left LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownLeftLTR => new StyleValue(this, "MenuItemDownLeftLTR", MenuItemNormalLeftLTR);

		/// 
		/// Gets the menu item row down left RTL style.
		/// </summary>
		/// The menu item row down left RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownLeftRTL => new StyleValue(this, "MenuItemDownLeftRTL", MenuItemNormalLeftRTL);

		/// 
		/// Gets the menu item down left.
		/// </summary>
		/// The menu item down Left.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDownLeft => new BidirectionalSkinValue<object>(this, MenuItemDownLeftLTR, MenuItemDownLeftRTL);

		/// 
		/// Gets the menu item row down right LTR style.
		/// </summary>
		/// The menu item row down right LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownRightLTR => new StyleValue(this, "MenuItemDownRightLTR", MenuItemNormalRightLTR);

		/// 
		/// Gets the menu item row down right style RTL.
		/// </summary>
		/// The menu item row down right RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownRightRTL => new StyleValue(this, "MenuItemDownRightRTL", MenuItemNormalRightRTL);

		/// 
		/// Gets the menu item down right.
		/// </summary>
		/// The menu item down right.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDownRight => new BidirectionalSkinValue<object>(this, MenuItemDownRightLTR, MenuItemDownRightRTL);

		/// 
		/// Gets the menu item row down center style LTR.
		/// </summary>
		/// The menu item row down center LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownCenterLTR => new StyleValue(this, "MenuItemDownCenterLTR", MenuItemNormalCenterLTR);

		/// 
		/// Gets the menu item row down center style RTL.
		/// </summary>
		/// The menu item row down center RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDownCenterRTL => new StyleValue(this, "MenuItemDownCenterRTL", MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item down center.
		/// </summary>
		/// The menu item down center.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDownCenter => new BidirectionalSkinValue<object>(this, MenuItemDownCenterLTR, MenuItemDownCenterRTL);

		/// 
		/// Gets the menu item disable.
		/// </summary>
		/// The menu item disable.</value>
		[Category("States")]
		[Description("The item disable style.")]
		public BidirectionalSkinValue<object> MenuItemDisable => new BidirectionalSkinValue<object>(this, MenuItemDisableLTR, MenuItemDisableRTL);

		/// 
		/// Gets the item row disable LTR style.
		/// </summary>
		/// The item row disable LTR style.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemDisableLTR => new TripleCellFrameStyleValue(MenuItemDisableLeftLTR, MenuItemDisableRightLTR, MenuItemDisableCenterLTR);

		/// 
		/// Gets the item row disable RTL style.
		/// </summary>
		/// The item row disable RTL style.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public virtual TripleCellFrameStyleValue MenuItemDisableRTL => new TripleCellFrameStyleValue(MenuItemDisableLeftRTL, MenuItemDisableRightRTL, MenuItemDisableCenterRTL);

		/// 
		/// Gets the menu item Disable LTR.
		/// </summary>
		/// The menu item Disable LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableLeftLTR => new StyleValue(this, "MenuItemDisableLeftLTR", MenuItemNormalLeftLTR);

		/// 
		/// Gets the menu item Disable RTL.
		/// </summary>
		/// The menu item Disable RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableLeftRTL => new StyleValue(this, "MenuItemDisableLeftRTL", MenuItemNormalLeftRTL);

		/// 
		/// Gets the menu item down left.
		/// </summary>
		/// The menu item down left.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDisableLeft => new BidirectionalSkinValue<object>(this, MenuItemDisableLeftLTR, MenuItemDisableLeftRTL);

		/// 
		/// Gets the menu item Disable LTR.
		/// </summary>
		/// The menu item Disable LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableRightLTR => new StyleValue(this, "MenuItemDisableRightLTR", MenuItemNormalRightLTR);

		/// 
		/// Gets the menu item Disable RTL.
		/// </summary>
		/// The menu item Disable RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableRightRTL => new StyleValue(this, "MenuItemDisableRightRTL", MenuItemNormalRightRTL);

		/// 
		/// Gets the menu item disable right.
		/// </summary>
		/// The menu item disable right.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDisableRight => new BidirectionalSkinValue<object>(this, MenuItemDisableRightLTR, MenuItemDisableRightRTL);

		/// 
		/// Gets the menu item Disable LTR.
		/// </summary>
		/// The menu item Disable LTr.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableCenterLTR => new StyleValue(this, "MenuItemDisableCenterLTR", MenuItemNormalCenterLTR);

		/// 
		/// Gets the menu item Disable RTL.
		/// </summary>
		/// The menu item Disable RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemDisableCenterRTL => new StyleValue(this, "MenuItemDisableCenterRTL", MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item disable center.
		/// </summary>
		/// The menu item disable center.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue MenuItemDisableCenter => new BidirectionalSkinValue<object>(this, MenuItemDisableCenterLTR, MenuItemDisableCenterRTL);

		/// 
		/// Gets the menu item label normal style .
		/// </summary>
		/// The menu item label normal style.</value>
		[Category("States")]
		[SRDescription("Menu item label normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> MenuItemLabelNormalStyle => new BidirectionalSkinValue<object>(this, MenuItemLabelNormalStyleLTR, MenuItemLabelNormalStyleRTL);

		/// 
		/// Gets the menu item label normal style LTR.
		/// </summary>
		/// The menu item label normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelNormalStyleLTR => new StyleValue(this, "MenuItemLabelNormalStyleLTR", MenuItemNormalCenterLTR);

		/// 
		/// Gets the menu item label normal style RTL.
		/// </summary>
		/// The menu item label normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelNormalStyleRTL => new StyleValue(this, "MenuItemLabelNormalStyleRTL", MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item label hover style .
		/// </summary>
		/// The menu item label hover style.</value>
		[Category("States")]
		[SRDescription("Menu item label hover style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> MenuItemLabelHoverStyle => new BidirectionalSkinValue<object>(this, MenuItemLabelHoverStyleLTR, MenuItemLabelHoverStyleRTL);

		/// 
		/// Gets the menu item label hover style LTR.
		/// </summary>
		/// The menu item label hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelHoverStyleLTR => new StyleValue(this, "MenuItemLabelHoverStyleLTR", MenuItemLabelNormalStyleLTR);

		/// 
		/// Gets the menu item label hover style RTL.
		/// </summary>
		/// The menu item label hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelHoverStyleRTL => new StyleValue(this, "MenuItemLabelHoverStyleRTL", MenuItemLabelNormalStyleRTL);

		/// 
		/// Gets the menu item label down style .
		/// </summary>
		/// The menu item label down style.</value>
		[Category("States")]
		[SRDescription("Menu item label down style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> MenuItemLabelDownStyle => new BidirectionalSkinValue<object>(this, MenuItemLabelDownStyleLTR, MenuItemLabelDownStyleRTL);

		/// 
		/// Gets the menu item label down style LTR.
		/// </summary>
		/// The menu item label down style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelDownStyleLTR => new StyleValue(this, "MenuItemLabelDownStyleLTR", MenuItemLabelNormalStyleLTR);

		/// 
		/// Gets the menu item label down style RTL.
		/// </summary>
		/// The menu item label down style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelDownStyleRTL => new StyleValue(this, "MenuItemLabelDownStyleRTL", MenuItemLabelNormalStyleRTL);

		/// 
		/// Gets the menu item label Disable style .
		/// </summary>
		/// The menu item label Disable style.</value>
		[Category("States")]
		[SRDescription("Menu item label disable style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> MenuItemLabelDisableStyle => new BidirectionalSkinValue<object>(this, MenuItemLabelDisableStyleLTR, MenuItemLabelDisableStyleRTL);

		/// 
		/// Gets the menu item label disable style LTR.
		/// </summary>
		/// The menu item label disable style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelDisableStyleLTR => new StyleValue(this, "MenuItemLabelDisableStyleLTR", MenuItemLabelNormalStyleLTR);

		/// 
		/// Gets the menu item label disable style RTL.
		/// </summary>
		/// The menu item label disable style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemLabelDisableStyleRTL => new StyleValue(this, "MenuItemLabelDisableStyleRTL", MenuItemLabelNormalStyleRTL);

		/// 
		/// Gets the menu item Icon LTR Padding.
		/// </summary>
		/// The menu item Icon LTR Padding.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual PaddingValue MenuItemIconPaddingLTR
		{
			get
			{
				return GetValue("MenuItemIconPaddingLTR", new PaddingValue(new Padding(2, 3, 0, 0)));
			}
			set
			{
				SetValue("MenuItemIconPaddingLTR", value);
			}
		}

		/// 
		/// Gets the menu item Icon RTL Padding.
		/// </summary>
		/// The menu item Icon RTL Padding.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual PaddingValue MenuItemIconPaddingRTL
		{
			get
			{
				return GetValue("MenuItemIconPaddingRTL", new PaddingValue(new Padding(0, 3, 2, 0)));
			}
			set
			{
				SetValue("MenuItemIconPaddingRTL", value);
			}
		}

		/// 
		/// Gets the menu item Icon Padding.
		/// </summary>
		/// The menu item Icon Padding.</value>
		[Category("Padding")]
		[Description("The menu item Icon Padding.")]
		public BidirectionalSkinValue<object> MenuItemIconPadding => new BidirectionalSkinValue<object>(this, MenuItemIconPaddingLTR, MenuItemIconPaddingRTL);

		/// 
		/// Gets the menu item arrow LTR Padding.
		/// </summary>
		/// The menu item arrow LTR Padding.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual PaddingValue MenuItemArrowPaddingLTR
		{
			get
			{
				return GetValue("MenuItemArrowPaddingLTR", new PaddingValue(new Padding(0, 7, 2, 0)));
			}
			set
			{
				SetValue("MenuItemArrowPaddingLTR", value);
			}
		}

		/// 
		/// Gets the menu item arrow RTL Padding.
		/// </summary>
		/// The menu item arrow RTL Padding.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual PaddingValue MenuItemArrowPaddingRTL
		{
			get
			{
				return GetValue("MenuItemArrowPaddingRTL", new PaddingValue(new Padding(0, 7, 2, 0)));
			}
			set
			{
				SetValue("MenuItemArrowPaddingRTL", value);
			}
		}

		/// 
		/// Gets the menu item arrow Bidirectional style.
		/// </summary>
		/// The menu item arrow Bidirectional style.</value>
		[Category("Padding")]
		[Description("The menu item arrow Padding.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinValue<object> MenuItemArrowPadding => new BidirectionalSkinValue<object>(this, MenuItemArrowPaddingLTR, MenuItemArrowPaddingRTL);

		/// 
		/// Gets the menu item Shortcut normal style .
		/// </summary>
		/// The menu item Shortcut normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BidirectionalSkinValue<object> MenuItemShortcutNormalStyle => new BidirectionalSkinValue<object>(this, MenuItemShortcutNormalStyleLTR, MenuItemShortcutNormalStyleRTL);

		/// 
		/// Gets the menu item shortcut normal style LTR.
		/// </summary>
		/// The menu item shortcut normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutNormalStyleLTR => new StyleValue(this, "MenuItemShortcutNormalStyleLTR", MenuItemNormalCenterLTR);

		/// 
		/// Gets the menu item shortcut normal style RTL.
		/// </summary>
		/// The menu item shortcut normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutNormalStyleRTL => new StyleValue(this, "MenuItemShortcutNormalStyleRTL", MenuItemNormalCenterRTL);

		/// 
		/// Gets the menu item Shortcut hover style .
		/// </summary>
		/// The menu item Shortcut hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual SkinValue MenuItemShortcutHoverStyle => new BidirectionalSkinValue<object>(this, MenuItemShortcutHoverStyleLTR, MenuItemShortcutHoverStyleRTL);

		/// 
		/// Gets the menu item shortcut hover style LTR.
		/// </summary>
		/// The menu item shortcut hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutHoverStyleLTR => new StyleValue(this, "MenuItemShortcutHoverStyleLTR", MenuItemShortcutNormalStyleLTR);

		/// 
		/// Gets the menu item shortcut hover style RTL.
		/// </summary>
		/// The menu item shortcut hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutHoverStyleRTL => new StyleValue(this, "MenuItemShortcutHoverStyleRTL", MenuItemShortcutNormalStyleRTL);

		/// 
		/// Gets the menu item Shortcut down style .
		/// </summary>
		/// The menu item Shortcut down style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual SkinValue MenuItemShortcutDownStyle => new BidirectionalSkinValue<object>(this, MenuItemShortcutDownStyleLTR, MenuItemShortcutDownStyleRTL);

		/// 
		/// Gets the menu item shortcut down style LTR.
		/// </summary>
		/// The menu item shortcut down style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutDownStyleLTR => new StyleValue(this, "MenuItemShortcutDownStyleLTR", MenuItemShortcutNormalStyleLTR);

		/// 
		/// Gets the menu item shortcut down style RTL.
		/// </summary>
		/// The menu item shortcut down style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutDownStyleRTL => new StyleValue(this, "MenuItemShortcutDownStyleRTL", MenuItemShortcutNormalStyleRTL);

		/// 
		/// Gets the menu item Shortcut Disable style .
		/// </summary>
		/// The menu item Shortcut Disable style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual SkinValue MenuItemShortcutDisableStyle => new BidirectionalSkinValue<object>(this, MenuItemShortcutDisableStyleLTR, MenuItemShortcutDisableStyleRTL);

		/// 
		/// Gets the menu item shortcut disable style LTR.
		/// </summary>
		/// The menu item shortcut disable style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutDisableStyleLTR => new StyleValue(this, "MenuItemShortcutDisableStyleLTR", MenuItemShortcutNormalStyleLTR);

		/// 
		/// Gets the menu item shortcut disable style RTL.
		/// </summary>
		/// The menu item shortcut disable style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue MenuItemShortcutDisableStyleRTL => new StyleValue(this, "MenuItemShortcutDisableStyleRTL", MenuItemShortcutNormalStyleRTL);

		/// 
		/// Gets or sets the height of the item.
		/// </summary>
		/// The height of the item.</value>
		[Category("Sizes")]
		[Description("The height of a item.")]
		public int Height
		{
			get
			{
				return GetValue("Height", DefaultItemHeight);
			}
			set
			{
				SetValue("Height", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultItemHeight => 22;

		/// 
		/// Gets or sets the height of the seperator.
		/// </summary>
		/// The height of the seperator.</value>
		[Category("Sizes")]
		[Description("The height of the seperator.")]
		public int SeperatorHeight
		{
			get
			{
				return GetValue("SeperatorRowHeight", DefaultSeperatorRowHeight);
			}
			set
			{
				SetValue("SeperatorRowHeight", value);
			}
		}

		/// 
		/// Gets default Seperator row height
		/// </summary>
		protected virtual int DefaultSeperatorRowHeight => 6;

		/// 
		/// Gets the arrow image width LTR.
		/// </summary>
		/// The arrow image width LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int ArrowImageWidthLTR => GetImageWidth(ArrowImageLTR, 7);

		/// 
		/// Gets the arrow image width RTL.
		/// </summary>
		/// The arrow image width RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal int ArrowImageWidthRTL => GetImageWidth(ArrowImageRTL, 7);

		/// 
		/// Gets the width of the arrow image.
		/// </summary>
		/// The width of the arrow image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SkinValue ArrowImageWidth => new BidirectionalSkinValue<object>(this, ArrowImageWidthLTR, ArrowImageWidthRTL);

		/// 
		/// Gets the width of the menu item icons column.
		/// </summary>
		/// The width of the menu item icons column.</value>
		[Category("Sizes")]
		[Description("The width of the menu item icons column.")]
		public int MenuItemIconsColumnWidth
		{
			get
			{
				return GetValue("MenuItemIconsColumnWidth", DefaultMenuItemIconsColumnWidth);
			}
			set
			{
				SetValue("MenuItemIconsColumnWidth", value);
			}
		}

		/// 
		/// Gets the default width of the menu item icons column.
		/// </summary>
		/// The default width of the menu item icons column.</value>
		protected virtual int DefaultMenuItemIconsColumnWidth => 32;

		/// 
		/// Gets the menu item highlight left width LTR.
		/// </summary>
		/// The menu item highlight left width LTR.</value>
		[Category("Sizes")]
		[Description("The width of the LTR menu item Highlight Left column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int MenuItemHighlightLeftWidthLTR => GetImageWidth(MenuItemHoverLTR.LeftStyle.BackgroundImage);

		/// 
		/// Gets the menu item highlight left width RTL.
		/// </summary>
		/// The menu item highlight left width RTL.</value>
		[Category("Sizes")]
		[Description("The width of the RTL menu item Highlight Left column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int MenuItemHighlightLeftWidthRTL => GetImageWidth(MenuItemHoverRTL.LeftStyle.BackgroundImage);

		/// 
		/// Gets the width of the menu item Highlight Left column Width
		/// </summary>
		/// The width of the menu item Highlight Left column Width.</value>
		[Category("Sizes")]
		[Description("The width of the menu item Highlight Left column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public BidirectionalSkinProperty<object> MenuItemHighlightLeftWidth => new BidirectionalSkinProperty<object>(this, "MenuItemHighlightLeftWidthLTR", "MenuItemHighlightLeftWidthRTL");

		/// 
		/// Gets the menu item highlight right width LTR.
		/// </summary>
		/// The menu item highlight right width LTR.</value>
		[Category("Sizes")]
		[Description("The width of the LTR menu item Highlight Right column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int MenuItemHighlightRightWidthLTR => GetImageWidth(MenuItemHoverLTR.RightStyle.BackgroundImage);

		/// 
		/// Gets the menu item highlight right width RTL.
		/// </summary>
		/// The menu item highlight right width RTL.</value>
		[Category("Sizes")]
		[Description("The width of the RTL menu item Highlight Right column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int MenuItemHighlightRightWidthRTL => GetImageWidth(MenuItemHoverRTL.RightStyle.BackgroundImage);

		/// 
		/// Gets the width of the menu item Highlight Right column Width
		/// </summary>
		/// The width of the menu item Highlight Right column Width.</value>
		[Category("Sizes")]
		[Description("The width of the menu item Highlight Right column Width")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public BidirectionalSkinProperty<object> MenuItemHighlightRightWidth => new BidirectionalSkinProperty<object>(this, "MenuItemHighlightRightWidthLTR", "MenuItemHighlightRightWidthRTL");

		/// 
		/// Gets or sets menu item the checked image.
		/// </summary>
		/// The checked image.</value>
		[Description("Menu item checked image")]
		[Category("Images")]
		public ImageResourceReference CheckedImage
		{
			get
			{
				return GetValue("CheckedImage", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "Checked.gif"));
			}
			set
			{
				SetValue("CheckedImage", value);
			}
		}

		/// 
		/// Gets or sets menu item the checked Disable image.
		/// </summary>
		/// The checked Disable image.</value>
		[Description("Menu item checked Disable image")]
		[Category("Images")]
		public ImageResourceReference CheckedImageDisable
		{
			get
			{
				return GetValue("CheckedImageDisable", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "CheckedDisabled.gif"));
			}
			set
			{
				SetValue("CheckedImageDisable", value);
			}
		}

		/// 
		/// Gets or sets the radio checked image.
		/// </summary>
		/// The radio checked image.</value>
		[Description("Menu item radio checked image")]
		[Category("Images")]
		public ImageResourceReference RadioCheckedImage
		{
			get
			{
				return GetValue("RadioCheckedImage", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "RadioChecked.gif"));
			}
			set
			{
				SetValue("RadioCheckedImage", value);
			}
		}

		/// 
		/// Gets or sets the radio checked Disable image.
		/// </summary>
		/// The radio checked Disable image.</value>
		[Description("Menu item radio checked Disable image")]
		[Category("Images")]
		public ImageResourceReference RadioCheckedImageDisable
		{
			get
			{
				return GetValue("RadioCheckedImageDisable", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "RadioCheckedDisabled.gif"));
			}
			set
			{
				SetValue("RadioCheckedImageDisable", value);
			}
		}

		/// 
		/// Gets or sets the arrow image LTR.
		/// </summary>
		/// The arrow image LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference ArrowImageLTR
		{
			get
			{
				return GetValue("ArrowImageLTR", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowLTR.gif"));
			}
			set
			{
				SetValue("ArrowImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the arrow image RTL.
		/// </summary>
		/// The arrow image RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference ArrowImageRTL
		{
			get
			{
				return GetValue("ArrowImageRTL", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowRTL.gif"));
			}
			set
			{
				SetValue("ArrowImageRTL", value);
			}
		}

		/// 
		/// Gets or sets the arrow image Bidirectional.
		/// </summary>
		/// The arrow image Bidirectional.</value>
		[Category("Images")]
		[Description("The menu item arrow image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> ArrowImage => new BidirectionalSkinProperty<object>(this, "ArrowImageLTR", "ArrowImageRTL");

		/// 
		/// Gets or sets the arrow Disable image LTR.
		/// </summary>
		/// The arrow image Disable LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImageResourceReference ArrowImageLTRDisabled
		{
			get
			{
				return GetValue("ArrowImageLTRDisabled", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowLTRDisabled.gif"));
			}
			set
			{
				SetValue("ArrowImageLTRDisabled", value);
			}
		}

		/// 
		/// Gets or sets the arrow Disable image RTL.
		/// </summary>
		/// The arrow Disable image RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImageResourceReference ArrowImageRTLDisabled
		{
			get
			{
				return GetValue("ArrowImageRTLDisabled", (ImageResourceReference)(string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowRTLDisabled.gif"));
			}
			set
			{
				SetValue("ArrowImageRTLDisabled", value);
			}
		}

		/// 
		/// Gets or sets the arrow Disable image Bidirectional.
		/// </summary>
		/// The arrow Disable image Bidirectional.</value>
		[Category("Images")]
		[Description("The menu item disable arrow image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> ArrowImageDisabled => new BidirectionalSkinProperty<object>(this, "ArrowImageLTRDisabled", "ArrowImageRTLDisabled");

		/// 
		/// Gets the background.
		/// </summary>
		/// The background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BackgroundValue Background
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = BackColor;
				backgroundValue.BackgroundImage = BackgroundImage;
				backgroundValue.BackgroundImagePosition = BackgroundImagePosition;
				backgroundValue.BackgroundImageRepeat = BackgroundImageRepeat;
				return backgroundValue;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ImageResourceReference BackgroundImage
		{
			get
			{
				return GetValue("BackgroundImage", (ImageResourceReference)"");
			}
			set
			{
				SetValue("BackgroundImage", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BackgroundImageRepeat BackgroundImageRepeat
		{
			get
			{
				return GetValue("BackgroundImageRepeat", BackgroundImageRepeat.Repeat);
			}
			set
			{
				SetValue("BackgroundImageRepeat", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BackgroundImagePosition BackgroundImagePosition
		{
			get
			{
				return GetValue("BackgroundImagePosition", BackgroundImagePosition.MiddleCenter);
			}
			set
			{
				SetValue("BackgroundImagePosition", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BorderWidth BorderWidth
		{
			get
			{
				return base.BorderWidth;
			}
			set
			{
				base.BorderWidth = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BorderColor BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override BorderStyle BorderStyle
		{
			get
			{
				return GetValue("BorderStyle", BorderStyle.FixedSingle);
			}
			set
			{
				SetValue("BorderStyle", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override MarginValue Margin
		{
			get
			{
				return base.Margin;
			}
			set
			{
				base.Margin = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override PaddingValue Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetItemHeight()
		{
			Reset("Height");
		}

		/// 
		/// Resets the seperator row height
		/// </summary>
		internal void ResetSeperatorRowHeight()
		{
			Reset("SeperatorRowHeight");
		}

		/// 
		/// Resets the width of the menu item icons column.
		/// </summary>
		internal void ResetMenuItemIconsColumnWidth()
		{
			Reset("MenuItemIconsColumnWidth");
		}

		/// 
		/// Resets the height of the menu.
		/// </summary>
		internal void ResetCheckedImage()
		{
			Reset("CheckedImage");
		}
	}
}
