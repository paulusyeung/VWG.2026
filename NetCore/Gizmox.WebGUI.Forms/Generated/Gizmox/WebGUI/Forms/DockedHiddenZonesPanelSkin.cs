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
	/// DockedHiddenZonesPanel Skin
	/// </summary>
	[Serializable]
	[SkinContainer(typeof(DockingManagerSkin))]
	public class DockedHiddenZonesPanelSkin : PanelSkin
	{
		private HiddenZoneItemProperties mobjHiddenZoneItemProperties;

		/// 
		/// Gets the font When the button is focused.
		/// </summary>
		/// The font focused.</value>
		[Browsable(false)]
		public Font FontData => HiddenZoneItemStyle.Font;

		/// 
		/// Gets the hidden zone item properties object.
		/// </summary>
		public HiddenZoneItemProperties HiddenZoneItem
		{
			get
			{
				if (mobjHiddenZoneItemProperties == null)
				{
					mobjHiddenZoneItemProperties = new HiddenZoneItemProperties(this);
				}
				return mobjHiddenZoneItemProperties;
			}
		}

		/// 
		/// Gets the drop down arrow image style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneItemHoverStyle => new StyleValue(this, "HiddenZoneItemHoverStyle");

		/// 
		/// Gets the drop down arrow image style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZonePopUpStyle => new StyleValue(this, "HiddenZonePopUpStyle");

		/// 
		/// Gets the hidden zone scroller bottom hover style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerBottomHoverStyle => new StyleValue(this, "HiddenZoneScrollerBottomHoverStyle");

		/// 
		/// Gets the hidden zone scroller bottom pressed style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerBottomPressedStyle => new StyleValue(this, "HiddenZoneScrollerBottomPressedStyle");

		/// 
		/// Gets the hidden zone scroller bottom style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerBottomStyle => new StyleValue(this, "HiddenZoneScrollerBottomStyle");

		/// 
		/// Gets the hidden zone scroller left hover style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerLeftHoverStyle => new StyleValue(this, "HiddenZoneScrollerLeftHoverStyle");

		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerLeftPressedStyle => new StyleValue(this, "HiddenZoneScrollerLeftPressedStyle");

		/// 
		/// Gets the hidden zone scroller left style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerLeftStyle => new StyleValue(this, "HiddenZoneScrollerLeftStyle");

		/// 
		/// Gets the hidden zone scroller right hover style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerRightHoverStyle => new StyleValue(this, "HiddenZoneScrollerRightHoverStyle");

		/// 
		/// Gets the hidden zone scroller right pressed style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerRightPressedStyle => new StyleValue(this, "HiddenZoneScrollerRightPressedStyle");

		/// 
		/// Gets the hidden zone scroller right style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerRightStyle => new StyleValue(this, "HiddenZoneScrollerRightStyle");

		/// 
		/// Gets the hidden zone scroller top hover style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerTopHoverStyle => new StyleValue(this, "HiddenZoneScrollerTopHoverStyle");

		/// 
		/// Gets the hidden zone scroller top pressed style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerTopPressedStyle => new StyleValue(this, "HiddenZoneScrollerTopPressedStyle");

		/// 
		/// Gets the hidden zone scroller top style.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue HiddenZoneScrollerTopStyle => new StyleValue(this, "HiddenZoneScrollerTopStyle");

		/// 
		/// Gets the height of the left right center content.
		/// </summary>
		/// 
		/// The height of the left right center content.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int LeftRightContentWidth => PanelThickness - LeftRightPanelsPadding.Left - LeftRightPanelsPadding.Right;

		/// 
		/// Gets or sets the left right panels padding.
		/// </summary>
		/// 
		/// The left right panels padding.
		/// </value>
		[SRDescription("ControlPaddingDescr")]
		[Category("Layout")]
		public PaddingValue LeftRightPanelsPadding
		{
			get
			{
				return GetValue("LeftRightPanelsPadding", new PaddingValue(new Padding(0, 0, 0, 0)));
			}
			set
			{
				SetValue("LeftRightPanelsPadding", value);
			}
		}

		/// 
		/// Gets or sets the panel item thickness.
		/// </summary>
		/// 
		/// The panel item thickness.
		/// </value>
		public int PanelItemThickness
		{
			get
			{
				return GetValue("PanelItemThickness", 100);
			}
			set
			{
				SetValue("PanelItemThickness", value);
			}
		}

		/// 
		/// Gets or sets the panel thickness.
		/// </summary>
		/// 
		/// The panel thickness.
		/// </value>
		public int PanelThickness
		{
			get
			{
				return GetValue("PanelThickness", 22);
			}
			set
			{
				SetValue("PanelThickness", value);
			}
		}

		/// 
		/// Gets or sets the scroller thickness.
		/// </summary>
		/// 
		/// The scroller thickness.
		/// </value>
		public int ScrollerThickness
		{
			get
			{
				return GetValue("ScrollerThickness", 22);
			}
			set
			{
				SetValue("ScrollerThickness", value);
			}
		}

		/// 
		/// Gets the height of the top bottom center content.
		/// </summary>
		/// 
		/// The height of the top bottom center content.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int TopBottomContentHeight => PanelThickness - TopBottomPanelsPadding.Top - TopBottomPanelsPadding.Bottom - HiddenZoneItemStyle.BorderWidth.Top - HiddenZoneItemStyle.BorderWidth.Bottom;

		/// 
		/// Gets or sets the top bottom panels padding.
		/// </summary>
		/// 
		/// The top bottom panels padding.
		/// </value>
		[SRDescription("ControlPaddingDescr")]
		[Category("Layout")]
		public PaddingValue TopBottomPanelsPadding
		{
			get
			{
				return GetValue("TopBottomPanelsPadding", new PaddingValue(new Padding(0, 0, 0, 0)));
			}
			set
			{
				SetValue("TopBottomPanelsPadding", value);
			}
		}

		/// 
		/// Gets the width of the top bottom hidden zone item image.
		/// </summary>
		/// 
		/// The width of the top bottom hidden zone item image.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HiddenZoneItemImageWidth => HiddenZoneItemImageSize.Width;

		/// 
		/// Gets the height of the top bottom hidden zone item image.
		/// </summary>
		/// 
		/// The height of the top bottom hidden zone item image.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HiddenZoneItemImageHeight => HiddenZoneItemImageSize.Height;

		/// 
		/// Gets or sets the size of the top bottom hidden zone item image.
		/// </summary>
		/// 
		/// The size of the top bottom hidden zone item image.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size HiddenZoneItemImageSize
		{
			get
			{
				return GetValue("HiddenZoneItemImageSize", new Size(TopBottomContentHeight, TopBottomContentHeight));
			}
			set
			{
				SetValue("HiddenZoneItemImageSize", value);
			}
		}

		/// 
		/// Gets or sets the hidden zone item expantion delay.
		/// </summary>
		/// 
		/// The hidden zone item expantion delay.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HiddenZoneItemExpantionDelay
		{
			get
			{
				return GetValue("HiddenZoneItemExpantionDelay", 500);
			}
			set
			{
				SetValue("HiddenZoneItemExpantionDelay", value);
			}
		}

		/// 
		/// Gets or sets the width of the hidden zone item expantion.
		/// </summary>
		/// 
		/// The width of the hidden zone item expantion.
		/// </value>
		public int HiddenZoneItemExpantionWidth
		{
			get
			{
				return GetValue("HiddenZoneItemExpantionWidth", 300);
			}
			set
			{
				SetValue("HiddenZoneItemExpantionWidth", value);
			}
		}

		/// 
		/// Gets or sets the duration of the hidden zone item expantion animation.
		/// </summary>
		/// 
		/// The duration of the hidden zone item expantion animation.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HiddenZoneItemExpantionAnimationDuration
		{
			get
			{
				return GetValue("HiddenZoneItemExpantionAnimationDuration", 500);
			}
			set
			{
				SetValue("HiddenZoneItemExpantionAnimationDuration", value);
			}
		}

		/// 
		/// Gets the drop down arrow image style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue HiddenZoneItemStyle => new StyleValue(this, "HiddenZoneItemStyle");

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HiddenZoneItemStyleVerticalPadding => HiddenZoneItemStyle.Padding.Vertical + HiddenZoneItemStyle.Border.Width.Top + HiddenZoneItemStyle.Border.Width.Bottom;

		internal int HiddenZoneItemStyleHorizontalPadding => HiddenZoneItemStyle.Padding.Horizontal;

		/// 
		/// Gets the hidden zone item container vertical style.
		/// </summary>
		/// 
		/// The hidden zone item container vertical style.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue HiddenZoneItemContainerVerticalStyle => new StyleValue(this, "HiddenZoneItemContainerVerticalStyle");

		/// 
		/// Gets the hidden zone item container horizontal style.
		/// </summary>
		/// 
		/// The hidden zone item container horizontal style.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue HiddenZoneItemContainerHorizontalStyle => new StyleValue(this, "HiddenZoneItemContainerHorizontalStyle");

		private void InitializeComponent()
		{
		}
	}
}
