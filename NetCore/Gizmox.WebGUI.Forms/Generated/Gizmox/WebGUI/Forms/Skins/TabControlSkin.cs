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
	/// TabControl Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(TabControl), "TabControl.bmp")]
	[SkinDependency(typeof(TabPageSkin))]
	public class TabControlSkin : ControlSkin
	{
		/// 
		/// Gets the right scroll button normal style.
		/// </summary>
		/// The right scroll button normal style.</value>
		[Category("States")]
		[Description("The right scroll button normal style.")]
		public virtual StyleValue RightScrollButtonNormalStyle => new StyleValue(this, "RightScrollButtonNormalStyle");

		/// 
		/// Gets the right scroll button hover style.
		/// </summary>
		/// The right scroll button hover style.</value>
		[Category("States")]
		[Description("The right scroll button hover style.")]
		public virtual StyleValue RightScrollButtonHoverStyle => new StyleValue(this, "RightScrollButtonHoverStyle", RightScrollButtonNormalStyle);

		/// 
		/// Gets the right scroll button pressed style.
		/// </summary>
		/// The right scroll button pressed style.</value>
		[Category("States")]
		[Description("The right scroll button pressed style.")]
		public virtual StyleValue RightScrollButtonPressedStyle => new StyleValue(this, "RightScrollButtonPressedStyle", RightScrollButtonNormalStyle);

		/// 
		/// Gets or sets the size of the right scroll button.
		/// </summary>
		/// The size of the right scroll button.</value>
		[Category("Sizes")]
		[Description("The size of the right scroll button.")]
		public virtual Size RightScrollButtonSize
		{
			get
			{
				return GetValue("RightScrollButtonSize", GetImageSize(RightScrollButtonNormalStyle.BackgroundImage, DefaultRightScrollButtonSize));
			}
			set
			{
				SetValue("RightScrollButtonSize", value);
			}
		}

		/// 
		/// Gets the default size of the right scroll button.
		/// </summary>
		/// The default size of the right scroll button.</value>
		protected virtual Size DefaultRightScrollButtonSize => new Size(16, 16);

		/// 
		/// Gets the width of the right scroll button.
		/// </summary>
		/// The width of the right scroll button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightScrollButtonWidth => RightScrollButtonSize.Width;

		/// 
		/// Gets the height of the right scroll button.
		/// </summary>
		/// The height of the right scroll button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightScrollButtonHeight => RightScrollButtonSize.Height;

		/// 
		/// Gets the left scroll button normal style.
		/// </summary>
		/// The left scroll button normal style.</value>
		[Category("States")]
		[Description("The left scroll button normal style.")]
		public virtual StyleValue LeftScrollButtonNormalStyle => new StyleValue(this, "LeftScrollButtonNormalStyle");

		/// 
		/// Gets the left scroll button hover style.
		/// </summary>
		/// The left scroll button hover style.</value>
		[Category("States")]
		[Description("The left scroll button hover style.")]
		public virtual StyleValue LeftScrollButtonHoverStyle => new StyleValue(this, "LeftScrollButtonHoverStyle", LeftScrollButtonNormalStyle);

		/// 
		/// Gets the left scroll button pressed style.
		/// </summary>
		/// The left scroll button pressed style.</value>
		[Category("States")]
		[Description("The left scroll button pressed style.")]
		public virtual StyleValue LeftScrollButtonPressedStyle => new StyleValue(this, "LeftScrollButtonPressedStyle", LeftScrollButtonNormalStyle);

		/// 
		/// Gets or sets the size of the left scroll button.
		/// </summary>
		/// The size of the left scroll button.</value>
		[Category("Sizes")]
		[Description("The size of the left scroll button.")]
		public virtual Size LeftScrollButtonSize
		{
			get
			{
				return GetValue("LeftScrollButtonSize", GetImageSize(LeftScrollButtonNormalStyle.BackgroundImage, DefaultLeftScrollButtonSize));
			}
			set
			{
				SetValue("LeftScrollButtonSize", value);
			}
		}

		/// 
		/// Gets the default size of the left scroll button.
		/// </summary>
		/// The default size of the left scroll button.</value>
		protected virtual Size DefaultLeftScrollButtonSize => new Size(16, 16);

		/// 
		/// Gets the width of the left scroll button.
		/// </summary>
		/// The width of the left scroll button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftScrollButtonWidth => LeftScrollButtonSize.Width;

		/// 
		/// Gets the height of the left scroll button.
		/// </summary>
		/// The height of the left scroll button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftScrollButtonHeight => LeftScrollButtonSize.Height;

		/// 
		/// Gets the bidirectional right scroll button normal style.
		/// </summary>
		/// The bidirectional right scroll button normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> BidirectionalRightScrollButtonNormalStyle => new BidirectionalSkinValue<object>(this, RightScrollButtonNormalStyle, LeftScrollButtonNormalStyle);

		/// 
		/// Gets the bidirectional left scroll button normal style.
		/// </summary>
		/// The bidirectional left scroll button normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> BidirectionalLeftScrollButtonNormalStyle => new BidirectionalSkinValue<object>(this, LeftScrollButtonNormalStyle, RightScrollButtonNormalStyle);

		/// 
		/// Gets the bidirectional left scroll button hover style.
		/// </summary>
		/// The bidirectional left scroll button hover style.</value>
		public BidirectionalSkinValue<object> BidirectionalLeftScrollButtonHoverStyle => new BidirectionalSkinValue<object>(this, LeftScrollButtonHoverStyle, RightScrollButtonHoverStyle);

		/// 
		/// Gets the bidirectional left scroll button pressed style.
		/// </summary>
		/// The bidirectional left scroll button pressed style.</value>
		public BidirectionalSkinValue<object> BidirectionalLeftScrollButtonPressedStyle => new BidirectionalSkinValue<object>(this, LeftScrollButtonPressedStyle, RightScrollButtonPressedStyle);

		/// 
		/// Gets the bidirectional right scroll button hover style.
		/// </summary>
		/// The bi directional right scroll button hover style.</value>
		public BidirectionalSkinValue<object> BidirectionalRightScrollButtonHoverStyle => new BidirectionalSkinValue<object>(this, RightScrollButtonHoverStyle, LeftScrollButtonHoverStyle);

		/// 
		/// Gets the bidirectional right scroll button pressed style.
		/// </summary>
		/// The bidirectional right scroll button pressed style.</value>
		public BidirectionalSkinValue<object> BidirectionalRightScrollButtonPressedStyle => new BidirectionalSkinValue<object>(this, RightScrollButtonPressedStyle, LeftScrollButtonPressedStyle);

		/// 
		/// Gets the SpreadTabHeaderTextColumn style.
		/// </summary>
		[Category("Styles")]
		[Description("The SpreadTabHeaderTextColumn style.")]
		public virtual StyleValue SpreadTabHeaderTextColumnStyle => new StyleValue(this, "SpreadTabHeaderTextColumnStyle");

		/// 
		/// Gets or sets the initial start point of the tabs.
		/// </summary>
		/// The initial start point of the tabs.</value>
		[Category("Sizes")]
		[Description("The initial start point of the tabs.")]
		public virtual int HeadersOffset
		{
			get
			{
				return GetValue("HeadersOffset", DefaultHeadersOffset);
			}
			set
			{
				SetValue("HeadersOffset", value);
			}
		}

		/// 
		/// Gets the tab top normal style.
		/// </summary>
		/// The tab top normal style.</value>
		public BidirectionalSkinValue<object> TabTopNormalStyle => new BidirectionalSkinValue<object>(this, TabTopNormalLTRStyle, TabTopNormalRTLStyle);

		/// 
		/// Gets the tab top normal style.
		/// </summary>
		/// The tab top normal style.</value>
		public BidirectionalSkinValue<object> TabTopNormalSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabTopNormalLTRSpreadStyle, CenterTabTopNormalRTLSpreadStyle);

		/// 
		/// Gets the tab top normal LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab normal spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopNormalLTRSpreadStyle => new StyleValue(this, "CenterTabTopNormalLTRSpreadStyle", CenterBottomTabNormalLTRStyle);

		/// 
		/// Gets the tab top normal RTL spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab normal spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopNormalRTLSpreadStyle => new StyleValue(this, "CenterTabTopNormalRTLSpreadStyle");

		/// 
		/// Gets the top tab normal style.
		/// </summary>
		/// The top tab normal style.</value>
		[Category("States")]
		[Description("The top tab normal LTR style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopNormalLTRStyle => new TripleCellFrameStyleValue(LeftTopTabNormalLTRStyle, RightTopTabNormalLTRStyle, CenterTopTabNormalLTRStyle);

		/// 
		/// Gets the tab top normal RTL style.
		/// </summary>
		/// The tab top normal RTL style.</value>
		[Category("States")]
		[Description("The top tab normal RTL style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopNormalRTLStyle => new TripleCellFrameStyleValue(LeftTopTabNormalRTLStyle, RightTopTabNormalRTLStyle, CenterTopTabNormalRTLStyle);

		/// 
		/// Gets the tab top selected style.
		/// </summary>
		/// The tab top selected style.</value>
		public BidirectionalSkinValue<object> TabTopSelectedStyle => new BidirectionalSkinValue<object>(this, TabTopSelectedLTRStyle, TabTopSelectedRTLStyle);

		/// 
		/// Gets the tab top Selected style.
		/// </summary>
		/// The tab top Selected style.</value>
		public BidirectionalSkinValue<object> TabTopSelectedSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabTopSelectedLTRSpreadStyle, CenterTabTopSelectedRTLSpreadStyle);

		/// 
		/// Gets the tab top selected LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab selected spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopSelectedLTRSpreadStyle => new StyleValue(this, "CenterTabTopSelectedLTRSpreadStyle", TabPageHeaderSelectedStyle);

		/// 
		/// Gets the tab top selected LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab selected  spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopSelectedRTLSpreadStyle => new StyleValue(this, "CenterTabTopSelectedRTLSpreadStyle", TabPageHeaderSelectedStyle);

		/// 
		/// Gets the top tab selected style.
		/// </summary>
		/// The top tab selected style.</value>
		[Category("States")]
		[Description("The top tab selected style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopSelectedLTRStyle => new TripleCellFrameStyleValue(LeftTopTabSelectedLTRStyle, RightTopTabSelectedLTRStyle, CenterTopTabSelectedLTRStyle);

		/// 
		/// Gets the tab top selected RTL style.
		/// </summary>
		/// The tab top selected RTL style.</value>
		[Category("States")]
		[Description("The top tab selected style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopSelectedRTLStyle => new TripleCellFrameStyleValue(LeftTopTabSelectedRTLStyle, RightTopTabSelectedRTLStyle, CenterTopTabSelectedRTLStyle);

		/// 
		/// Gets the tab top hover style.
		/// </summary>
		/// The tab top hover style.</value>
		public BidirectionalSkinValue<object> TabTopHoverStyle => new BidirectionalSkinValue<object>(this, TabTopHoverLTRStyle, TabTopHoverRTLStyle);

		/// 
		/// Gets the tab top Hover style.
		/// </summary>
		/// The tab top Hover style.</value>
		public BidirectionalSkinValue<object> TabTopHoverSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabTopHoverLTRSpreadStyle, CenterTabTopHoverRTLSpreadStyle);

		/// 
		/// Gets the tab top hover LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab hover spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopHoverLTRSpreadStyle => new StyleValue(this, "CenterTabTopHoverLTRSpreadStyle");

		/// 
		/// Gets the tab top hover RTL spread style.
		/// </summary>
		[Category("States")]
		[Description("The top tab hover spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabTopHoverRTLSpreadStyle => new StyleValue(this, "CenterTabTopHoverRTLSpreadStyle");

		/// 
		/// Gets the top tab hover style.
		/// </summary>
		/// The top tab hover style.</value>
		[Category("States")]
		[Description("The top tab hover style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopHoverLTRStyle => new TripleCellFrameStyleValue(LeftTopTabHoverLTRStyle, RightTopTabHoverLTRStyle, CenterTopTabHoverLTRStyle);

		/// 
		/// Gets the top tab hover style.
		/// </summary>
		/// The top tab hover style.</value>
		[Category("States")]
		[Description("The top tab hover style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabTopHoverRTLStyle => new TripleCellFrameStyleValue(LeftTopTabHoverRTLStyle, RightTopTabHoverRTLStyle, CenterTopTabHoverRTLStyle);

		/// 
		/// Gets the right tab normal style.
		/// </summary>
		/// The right tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabNormalLTRStyle => new StyleValue(this, "RightTopTabNormalLTRStyle");

		/// 
		/// Gets the right top tab normal RTL style.
		/// </summary>
		/// The right top tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabNormalRTLStyle => new StyleValue(this, "RightTopTabNormalRTLStyle");

		/// 
		/// Gets the right top tab normal style.
		/// </summary>
		/// The right top tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightTopTabNormalStyle => new BidirectionalSkinValue<object>(this, RightTopTabNormalLTRStyle, RightTopTabNormalRTLStyle);

		/// 
		/// Gets the right tab selected style.
		/// </summary>
		/// The right tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabSelectedLTRStyle => new StyleValue(this, "RightTopTabSelectedLTRStyle", RightTopTabNormalLTRStyle);

		/// 
		/// Gets the right top tab selected RTL style.
		/// </summary>
		/// The right top tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabSelectedRTLStyle => new StyleValue(this, "RightTopTabSelectedRTLStyle", RightTopTabNormalRTLStyle);

		/// 
		/// Gets the right top tab selected style.
		/// </summary>
		/// The right top tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightTopTabSelectedStyle => new BidirectionalSkinValue<object>(this, RightTopTabSelectedLTRStyle, RightTopTabSelectedRTLStyle);

		/// 
		/// Gets the right tab hover style.
		/// </summary>
		/// The right tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabHoverLTRStyle => new StyleValue(this, "RightTopTabHoverLTRStyle", RightTopTabNormalLTRStyle);

		/// 
		/// Gets the right top tab hover RTL style.
		/// </summary>
		/// The right top tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightTopTabHoverRTLStyle => new StyleValue(this, "RightTopTabHoverRTLStyle", RightTopTabNormalRTLStyle);

		/// 
		/// Gets the right top tab hover style.
		/// </summary>
		/// The right top tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightTopTabHoverStyle => new BidirectionalSkinValue<object>(this, RightTopTabHoverLTRStyle, RightTopTabHoverRTLStyle);

		/// 
		/// Gets the left tab normal style.
		/// </summary>
		/// The left tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabNormalLTRStyle => new StyleValue(this, "LeftTopTabNormalLTRStyle");

		/// 
		/// Gets the left top tab normal RTL style.
		/// </summary>
		/// The left top tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabNormalRTLStyle => new StyleValue(this, "LeftTopTabNormalRTLStyle");

		/// 
		/// Gets the left top tab normal style.
		/// </summary>
		/// The left top tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftTopTabNormalStyle => new BidirectionalSkinValue<object>(this, LeftTopTabNormalLTRStyle, LeftTopTabNormalRTLStyle);

		/// 
		/// Gets the left tab selected style.
		/// </summary>
		/// The left tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabSelectedLTRStyle => new StyleValue(this, "LeftTopTabSelectedLTRStyle", LeftTopTabNormalLTRStyle);

		/// 
		/// Gets the left top tab selected RTL style.
		/// </summary>
		/// The left top tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabSelectedRTLStyle => new StyleValue(this, "LeftTopTabSelectedRTLStyle", LeftTopTabNormalRTLStyle);

		/// 
		/// Gets the left top tab selected style.
		/// </summary>
		/// The left top tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftTopTabSelectedStyle => new BidirectionalSkinValue<object>(this, LeftTopTabSelectedLTRStyle, LeftTopTabSelectedLTRStyle);

		/// 
		/// Gets the left tab hover style.
		/// </summary>
		/// The left tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabHoverLTRStyle => new StyleValue(this, "LeftTopTabHoverLTRStyle", LeftTopTabNormalLTRStyle);

		/// 
		/// Gets the left top tab hover RTL style.
		/// </summary>
		/// The left top tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftTopTabHoverRTLStyle => new StyleValue(this, "LeftTopTabHoverRTLStyle", LeftTopTabNormalRTLStyle);

		/// 
		/// Gets the left top tab hover style.
		/// </summary>
		/// The left top tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftTopTabHoverStyle => new BidirectionalSkinValue<object>(this, LeftTopTabHoverLTRStyle, LeftTopTabHoverRTLStyle);

		/// 
		/// Gets or sets the width of the left tab top in LTR.
		/// </summary>
		/// The width of the left tab top in LTR.</value>
		[Category("Sizes")]
		[Description("The width of the left tab top in LTR.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftTopTabWidthLTR
		{
			get
			{
				return GetValue("LeftTopTabWidthLTR", GetImageWidth(LeftTopTabNormalLTRStyle.BackgroundImage, DefaultLeftTopTabWidthLTR));
			}
			set
			{
				SetValue("LeftTopTabWidthLTR", value);
			}
		}

		/// 
		/// Gets the default width of the left tab top in LTR.
		/// </summary>
		/// The default width of the left tab top in LTR.</value>
		protected virtual int DefaultLeftTopTabWidthLTR => 0;

		/// 
		/// Gets or sets the width of the left tab top in RTL.
		/// </summary>
		/// The width of the left tab top in RTL.</value>
		[Category("Sizes")]
		[Description("The width of the left tab top in RTL.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftTopTabWidthRTL
		{
			get
			{
				return GetValue("LeftTopTabWidthRTL", GetImageWidth(LeftTopTabNormalRTLStyle.BackgroundImage, DefaultLeftTopTabWidthRTL));
			}
			set
			{
				SetValue("LeftTopTabWidthRTL", value);
			}
		}

		/// 
		/// Gets the default width of the left tab top in RTL.
		/// </summary>
		/// The default width of the left tab top in RTL.</value>
		protected virtual int DefaultLeftTopTabWidthRTL => 0;

		/// 
		/// Gets the width of the left top tab.
		/// </summary>
		/// The width of the left top tab.</value>       
		public BidirectionalSkinProperty<object> LeftTopTabWidth => new BidirectionalSkinProperty<object>(this, "LeftTopTabWidthLTR", "LeftTopTabWidthRTL");

		/// 
		/// Gets or sets the width of the right tab top in LTR.
		/// </summary>
		/// The width of the right tab top in LTR.</value>
		[Category("Sizes")]
		[Description("The width of the right tab top in LTR.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightTopTabWidthLTR
		{
			get
			{
				return GetValue("RightTopTabWidthLTR", GetImageWidth(RightTopTabNormalLTRStyle.BackgroundImage, DefaultRightTopTabWidthLTR));
			}
			set
			{
				SetValue("RightTopTabWidthLTR", value);
			}
		}

		/// 
		/// Gets the default width of the right tab top in LTR.
		/// </summary>
		/// The default width of the right tab top in LTR.</value>
		protected virtual int DefaultRightTopTabWidthLTR => 0;

		/// 
		/// Gets the width of the right top tab.
		/// </summary>
		/// The width of the right top tab.</value>
		public BidirectionalSkinProperty<object> RightTopTabWidth => new BidirectionalSkinProperty<object>(this, "RightTopTabWidthLTR", "RightTopTabWidthRTL");

		/// 
		/// Gets or sets the width of the right tab top in RTL.
		/// </summary>
		/// The width of the right tab top in RTL.</value>
		[Category("Sizes")]
		[Description("The width of the right tab top in RTL.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightTopTabWidthRTL
		{
			get
			{
				return GetValue("RightTopTabWidthRTL", GetImageWidth(RightTopTabNormalRTLStyle.BackgroundImage, DefaultRightTopTabWidthRTL));
			}
			set
			{
				SetValue("RightTopTabWidthRTL", value);
			}
		}

		/// 
		/// Gets the default width of the right tab top in RTL.
		/// </summary>
		/// The default width of the right tab top in RTL.</value>
		protected virtual int DefaultRightTopTabWidthRTL => 0;

		/// 
		/// Gets the center tab normal style.
		/// </summary>
		/// The center tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabNormalLTRStyle => new StyleValue(this, "CenterTopTabNormalLTRStyle");

		/// 
		/// Gets the center top tab normal RTL style.
		/// </summary>
		/// The center top tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabNormalRTLStyle => new StyleValue(this, "CenterTopTabNormalRTLStyle");

		/// 
		/// Gets the center top tab normal style.
		/// </summary>
		/// The center top tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterTopTabNormalStyle => new BidirectionalSkinValue<object>(this, CenterTopTabNormalLTRStyle, CenterTopTabNormalRTLStyle);

		/// 
		/// Gets the center tab selected style.
		/// </summary>
		/// The center tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabSelectedLTRStyle => new StyleValue(this, "CenterTopTabSelectedLTRStyle", CenterTopTabNormalLTRStyle);

		/// 
		/// Gets the center top tab selected RTL style.
		/// </summary>
		/// The center top tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabSelectedRTLStyle => new StyleValue(this, "CenterTopTabSelectedRTLStyle", CenterTopTabNormalRTLStyle);

		/// 
		/// Gets the center top tab selected style.
		/// </summary>
		/// The center top tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterTopTabSelectedStyle => new BidirectionalSkinValue<object>(this, CenterTopTabSelectedLTRStyle, CenterTopTabSelectedRTLStyle);

		/// 
		/// Gets the center tab hover style.
		/// </summary>
		/// The center tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabHoverLTRStyle => new StyleValue(this, "CenterTopTabHoverLTRStyle", CenterTopTabNormalLTRStyle);

		/// 
		/// Gets the center top tab hover RTL style.
		/// </summary>
		/// The center top tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTopTabHoverRTLStyle => new StyleValue(this, "CenterTopTabHoverRTLStyle", CenterTopTabNormalRTLStyle);

		/// 
		/// Gets the center top tab hover style.
		/// </summary>
		/// The center top tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterTopTabHoverStyle => new BidirectionalSkinValue<object>(this, CenterTopTabHoverLTRStyle, CenterTopTabHoverRTLStyle);

		/// 
		/// Gets the tabs container style.
		/// </summary>
		/// The tabs container style.</value>
		[Category("Styles")]
		[Description("The top tab container style.")]
		public virtual StyleValue TabsTopContainerStyle => new StyleValue(this, "TabsTopContainerStyle");

		/// 
		/// Gets the tab Bottom normal style.
		/// </summary>
		/// The tab Bottom normal style.</value>
		public BidirectionalSkinValue<object> TabBottomNormalStyle => new BidirectionalSkinValue<object>(this, TabBottomNormalLTRStyle, TabBottomNormalRTLStyle);

		/// 
		/// Gets the Bottom tab normal style.
		/// </summary>
		/// The Bottom tab normal style.</value>
		[Category("States")]
		[Description("The Bottom tab normal LTR style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomNormalLTRStyle => new TripleCellFrameStyleValue(LeftBottomTabNormalLTRStyle, RightBottomTabNormalLTRStyle, CenterBottomTabNormalLTRStyle);

		/// 
		/// Gets the tab Bottom normal style.
		/// </summary>
		/// The tab Bottom normal style.</value>
		public BidirectionalSkinValue<object> TabBottomNormalSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabBottomNormalLTRSpreadStyle, CenterTabBottomNormalRTLSpreadStyle);

		/// 
		/// Gets the tab Bottom normal LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab normal spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomNormalLTRSpreadStyle => new StyleValue(this, "CenterTabBottomNormalLTRSpreadStyle", CenterBottomTabNormalLTRStyle);

		/// 
		/// Gets the tab Bottom normal RTL spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab normal spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomNormalRTLSpreadStyle => new StyleValue(this, "CenterTabBottomNormalRTLSpreadStyle");

		/// 
		/// Gets the tab Bottom normal RTL style.
		/// </summary>
		/// The tab Bottom normal RTL style.</value>
		[Category("States")]
		[Description("The Bottom tab normal RTL style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomNormalRTLStyle => new TripleCellFrameStyleValue(LeftBottomTabNormalRTLStyle, RightBottomTabNormalRTLStyle, CenterBottomTabNormalRTLStyle);

		/// 
		/// Gets the tab Bottom selected style.
		/// </summary>
		/// The tab Bottom selected style.</value>
		public BidirectionalSkinValue<object> TabBottomSelectedStyle => new BidirectionalSkinValue<object>(this, TabBottomSelectedLTRStyle, TabBottomSelectedRTLStyle);

		/// 
		/// Gets the tab Bottom Selected style.
		/// </summary>
		/// The tab Bottom Selected style.</value>
		public BidirectionalSkinValue<object> TabBottomSelectedSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabBottomSelectedLTRSpreadStyle, CenterTabBottomSelectedRTLSpreadStyle);

		/// 
		/// Gets the tab Bottom selected LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab selected spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomSelectedLTRSpreadStyle => new StyleValue(this, "CenterTabBottomSelectedLTRSpreadStyle", TabPageHeaderSelectedStyle);

		/// 
		/// Gets the tab Bottom selected LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab selected  spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomSelectedRTLSpreadStyle => new StyleValue(this, "CenterTabBottomSelectedRTLSpreadStyle", TabPageHeaderSelectedStyle);

		/// 
		/// Gets the Bottom tab selected style.
		/// </summary>
		/// The Bottom tab selected style.</value>
		[Category("States")]
		[Description("The Bottom tab selected style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomSelectedLTRStyle => new TripleCellFrameStyleValue(LeftBottomTabSelectedLTRStyle, RightBottomTabSelectedLTRStyle, CenterBottomTabSelectedLTRStyle);

		/// 
		/// Gets the tab Bottom selected RTL style.
		/// </summary>
		/// The tab Bottom selected RTL style.</value>
		[Category("States")]
		[Description("The Bottom tab selected style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomSelectedRTLStyle => new TripleCellFrameStyleValue(LeftBottomTabSelectedRTLStyle, RightBottomTabSelectedRTLStyle, CenterBottomTabSelectedRTLStyle);

		/// 
		/// Gets the tab Bottom hover style.
		/// </summary>
		/// The tab Bottom hover style.</value>
		public BidirectionalSkinValue<object> TabBottomHoverStyle => new BidirectionalSkinValue<object>(this, TabBottomHoverLTRStyle, TabBottomHoverRTLStyle);

		/// 
		/// Gets the tab Bottom Hover style.
		/// </summary>
		/// The tab Bottom Hover style.</value>
		public BidirectionalSkinValue<object> TabBottomHoverSpreadStyle => new BidirectionalSkinValue<object>(this, CenterTabBottomHoverLTRSpreadStyle, CenterTabBottomHoverRTLSpreadStyle);

		/// 
		/// Gets the tab Bottom hover LTR spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab hover spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomHoverLTRSpreadStyle => new StyleValue(this, "CenterTabBottomHoverLTRSpreadStyle");

		/// 
		/// Gets the tab Bottom hover RTL spread style.
		/// </summary>
		[Category("States")]
		[Description("The Bottom tab hover spread appearance style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterTabBottomHoverRTLSpreadStyle => new StyleValue(this, "CenterTabBottomHoverRTLSpreadStyle");

		/// 
		/// Gets the Bottom tab hover style.
		/// </summary>
		/// The Bottom tab hover style.</value>
		[Category("States")]
		[Description("The Bottom tab hover style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomHoverLTRStyle => new TripleCellFrameStyleValue(LeftBottomTabHoverLTRStyle, RightBottomTabHoverLTRStyle, CenterBottomTabHoverLTRStyle);

		/// 
		/// Gets the Bottom tab hover style.
		/// </summary>
		/// The Bottom tab hover style.</value>
		[Category("States")]
		[Description("The Bottom tab hover style.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TripleCellFrameStyleValue TabBottomHoverRTLStyle => new TripleCellFrameStyleValue(LeftBottomTabHoverRTLStyle, RightBottomTabHoverRTLStyle, CenterBottomTabHoverRTLStyle);

		/// 
		/// Gets the right tab normal style.
		/// </summary>
		/// The right tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabNormalLTRStyle => new StyleValue(this, "RightBottomTabNormalLTRStyle");

		/// 
		/// Gets the right Bottom tab normal RTL style.
		/// </summary>
		/// The right Bottom tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabNormalRTLStyle => new StyleValue(this, "RightBottomTabNormalRTLStyle");

		/// 
		/// Gets the right Bottom tab normal style.
		/// </summary>
		/// The right Bottom tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightBottomTabNormalStyle => new BidirectionalSkinValue<object>(this, RightBottomTabNormalLTRStyle, RightBottomTabNormalRTLStyle);

		/// 
		/// Gets the right tab selected style.
		/// </summary>
		/// The right tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabSelectedLTRStyle => new StyleValue(this, "RightBottomTabSelectedLTRStyle", RightBottomTabNormalLTRStyle);

		/// 
		/// Gets the right Bottom tab selected RTL style.
		/// </summary>
		/// The right Bottom tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabSelectedRTLStyle => new StyleValue(this, "RightBottomTabSelectedRTLStyle", RightBottomTabNormalRTLStyle);

		/// 
		/// Gets the right Bottom tab selected style.
		/// </summary>
		/// The right Bottom tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightBottomTabSelectedStyle => new BidirectionalSkinValue<object>(this, RightBottomTabSelectedLTRStyle, RightBottomTabSelectedRTLStyle);

		/// 
		/// Gets the right tab hover style.
		/// </summary>
		/// The right tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabHoverLTRStyle => new StyleValue(this, "RightBottomTabHoverLTRStyle", RightBottomTabNormalLTRStyle);

		/// 
		/// Gets the right Bottom tab hover RTL style.
		/// </summary>
		/// The right Bottom tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightBottomTabHoverRTLStyle => new StyleValue(this, "RightBottomTabHoverRTLStyle", RightBottomTabNormalRTLStyle);

		/// 
		/// Gets the right Bottom tab hover style.
		/// </summary>
		/// The right Bottom tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> RightBottomTabHoverStyle => new BidirectionalSkinValue<object>(this, RightBottomTabHoverLTRStyle, RightBottomTabHoverRTLStyle);

		/// 
		/// Gets the left tab normal style.
		/// </summary>
		/// The left tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabNormalLTRStyle => new StyleValue(this, "LeftBottomTabNormalLTRStyle");

		/// 
		/// Gets the left Bottom tab normal RTL style.
		/// </summary>
		/// The left Bottom tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabNormalRTLStyle => new StyleValue(this, "LeftBottomTabNormalRTLStyle");

		/// 
		/// Gets the left Bottom tab normal style.
		/// </summary>
		/// The left Bottom tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftBottomTabNormalStyle => new BidirectionalSkinValue<object>(this, LeftBottomTabNormalLTRStyle, LeftBottomTabNormalRTLStyle);

		/// 
		/// Gets the left tab selected style.
		/// </summary>
		/// The left tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabSelectedLTRStyle => new StyleValue(this, "LeftBottomTabSelectedLTRStyle", LeftBottomTabNormalLTRStyle);

		/// 
		/// Gets the left Bottom tab selected RTL style.
		/// </summary>
		/// The left Bottom tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabSelectedRTLStyle => new StyleValue(this, "LeftBottomTabSelectedRTLStyle", LeftBottomTabNormalRTLStyle);

		/// 
		/// Gets the left Bottom tab selected style.
		/// </summary>
		/// The left Bottom tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftBottomTabSelectedStyle => new BidirectionalSkinValue<object>(this, LeftBottomTabSelectedLTRStyle, LeftBottomTabSelectedRTLStyle);

		/// 
		/// Gets the left tab hover style.
		/// </summary>
		/// The left tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabHoverLTRStyle => new StyleValue(this, "LeftBottomTabHoverLTRStyle", LeftBottomTabNormalLTRStyle);

		/// 
		/// Gets the left Bottom tab hover RTL style.
		/// </summary>
		/// The left Bottom tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftBottomTabHoverRTLStyle => new StyleValue(this, "LeftBottomTabHoverRTLStyle", LeftBottomTabNormalRTLStyle);

		/// 
		/// Gets the left Bottom tab hover style.
		/// </summary>
		/// The left Bottom tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> LeftBottomTabHoverStyle => new BidirectionalSkinValue<object>(this, LeftBottomTabHoverLTRStyle, LeftBottomTabHoverRTLStyle);

		/// 
		/// Gets or sets the width of the left tab Bottom in LTR.
		/// </summary>
		/// The width of the left tab Bottom in LTR.</value>
		[Category("Sizes")]
		[Description("The width of the left tab Bottom in LTR.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftBottomTabWidthLTR
		{
			get
			{
				return GetValue("LeftBottomTabWidthLTR", GetImageWidth(LeftBottomTabNormalLTRStyle.BackgroundImage, DefaultLeftBottomTabWidthLTR));
			}
			set
			{
				SetValue("LeftBottomTabWidthLTR", value);
			}
		}

		/// 
		/// Gets the default width of the left tab Bottom in LTR.
		/// </summary>
		/// The default width of the left tab Bottom in LTR.</value>
		protected virtual int DefaultLeftBottomTabWidthLTR => 0;

		/// 
		/// Gets or sets the width of the left tab Bottom in RTL.
		/// </summary>
		/// The width of the left tab Bottom in RTL.</value>
		[Category("Sizes")]
		[Description("The width of the left tab Bottom in RTL.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftBottomTabWidthRTL
		{
			get
			{
				return GetValue("LeftBottomTabWidthRTL", GetImageWidth(LeftBottomTabNormalRTLStyle.BackgroundImage, DefaultLeftBottomTabWidthRTL));
			}
			set
			{
				SetValue("LeftBottomTabWidthRTL", value);
			}
		}

		/// 
		/// Gets the default width of the left tab Bottom in RTL.
		/// </summary>
		/// The default width of the left tab Bottom in RTL.</value>
		protected virtual int DefaultLeftBottomTabWidthRTL => 0;

		/// 
		/// Gets the width of the left Bottom tab.
		/// </summary>
		/// The width of the left Bottom tab.</value>       
		public BidirectionalSkinProperty<object> LeftBottomTabWidth => new BidirectionalSkinProperty<object>(this, "LeftBottomTabWidthLTR", "LeftBottomTabWidthRTL");

		/// 
		/// Gets or sets the width of the right tab Bottom in LTR.
		/// </summary>
		/// The width of the right tab Bottom in LTR.</value>
		[Category("Sizes")]
		[Description("The width of the right tab Bottom in LTR.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightBottomTabWidthLTR
		{
			get
			{
				return GetValue("RightBottomTabWidthLTR", GetImageWidth(RightBottomTabNormalLTRStyle.BackgroundImage, DefaultRightBottomTabWidthLTR));
			}
			set
			{
				SetValue("RightBottomTabWidthLTR", value);
			}
		}

		/// 
		/// Gets the default width of the right tab Bottom in LTR.
		/// </summary>
		/// The default width of the right tab Bottom in LTR.</value>
		protected virtual int DefaultRightBottomTabWidthLTR => 0;

		/// 
		/// Gets the width of the right Bottom tab.
		/// </summary>
		/// The width of the right Bottom tab.</value>
		public BidirectionalSkinProperty<object> RightBottomTabWidth => new BidirectionalSkinProperty<object>(this, "RightBottomTabWidthLTR", "RightBottomTabWidthRTL");

		/// 
		/// Gets or sets the width of the right tab Bottom in RTL.
		/// </summary>
		/// The width of the right tab Bottom in RTL.</value>
		[Category("Sizes")]
		[Description("The width of the right tab Bottom in RTL.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightBottomTabWidthRTL
		{
			get
			{
				return GetValue("RightBottomTabWidthRTL", GetImageWidth(RightBottomTabNormalRTLStyle.BackgroundImage, DefaultRightBottomTabWidthRTL));
			}
			set
			{
				SetValue("RightBottomTabWidthRTL", value);
			}
		}

		/// 
		/// Gets the default width of the right tab Bottom in RTL.
		/// </summary>
		/// The default width of the right tab Bottom in RTL.</value>
		protected virtual int DefaultRightBottomTabWidthRTL => 0;

		/// 
		/// Gets the center tab normal style.
		/// </summary>
		/// The center tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabNormalLTRStyle => new StyleValue(this, "CenterBottomTabNormalLTRStyle");

		/// 
		/// Gets the center Bottom tab normal RTL style.
		/// </summary>
		/// The center Bottom tab normal RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabNormalRTLStyle => new StyleValue(this, "CenterBottomTabNormalRTLStyle");

		/// 
		/// Gets the center Bottom tab normal style.
		/// </summary>
		/// The center Bottom tab normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterBottomTabNormalStyle => new BidirectionalSkinValue<object>(this, CenterBottomTabNormalLTRStyle, CenterBottomTabNormalRTLStyle);

		/// 
		/// Gets the center tab selected style.
		/// </summary>
		/// The center tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabSelectedLTRStyle => new StyleValue(this, "CenterBottomTabSelectedLTRStyle", CenterBottomTabNormalLTRStyle);

		/// 
		/// Gets the center Bottom tab selected RTL style.
		/// </summary>
		/// The center Bottom tab selected RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabSelectedRTLStyle => new StyleValue(this, "CenterBottomTabSelectedRTLStyle", CenterBottomTabNormalRTLStyle);

		/// 
		/// Gets the center Bottom tab selected style.
		/// </summary>
		/// The center Bottom tab selected style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterBottomTabSelectedStyle => new BidirectionalSkinValue<object>(this, CenterBottomTabSelectedLTRStyle, CenterBottomTabSelectedRTLStyle);

		/// 
		/// Gets the center tab hover style.
		/// </summary>
		/// The center tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabHoverLTRStyle => new StyleValue(this, "CenterBottomTabHoverLTRStyle", CenterBottomTabNormalLTRStyle);

		/// 
		/// Gets the center Bottom tab hover RTL style.
		/// </summary>
		/// The center Bottom tab hover RTL style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterBottomTabHoverRTLStyle => new StyleValue(this, "CenterBottomTabHoverRTLStyle", CenterBottomTabNormalRTLStyle);

		/// 
		/// Gets the center Bottom tab hover style.
		/// </summary>
		/// The center Bottom tab hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> CenterBottomTabHoverStyle => new BidirectionalSkinValue<object>(this, CenterBottomTabHoverLTRStyle, CenterBottomTabHoverRTLStyle);

		/// 
		/// Gets the tabs container style.
		/// </summary>
		/// The tabs container style.</value>
		[Category("Styles")]
		[Description("The Bottom tab container style.")]
		public virtual StyleValue TabsBottomContainerStyle => new StyleValue(this, "TabsBottomContainerStyle");

		/// 
		/// Gets the frame frame style.
		/// </summary>
		/// The frame frame style.</value>
		[Category("Styles")]
		[Description("The frame style.")]
		public virtual FrameStyleValue FrameStyle => new FrameStyleValue(LeftBottomFrameStyle, LeftFrameStyle, LeftTopFrameStyle, TopFrameStyle, RightTopFrameStyle, RightFrameStyle, RightBottomFrameStyle, BottomFrameStyle, CenterFrameStyle);

		/// 
		/// Gets or sets the height of the top frame.
		/// </summary>
		/// The height of the top frame.</value>
		[Category("Sizes")]
		[Description("The height of the top frame.")]
		public virtual int TopFrameHeight
		{
			get
			{
				return GetValue("TopFrameHeight", DefaultTopFrameHeight);
			}
			set
			{
				SetValue("TopFrameHeight", value);
			}
		}

		/// 
		/// Gets the default height of the top frame.
		/// </summary>
		/// The default height of the top frame.</value>
		protected virtual int DefaultTopFrameHeight => 1;

		/// 
		/// Gets or sets the height of the bottom frame.
		/// </summary>
		/// The height of the bottom frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom frame.")]
		public virtual int BottomFrameHeight
		{
			get
			{
				return GetValue("BottomFrameHeight", DefaultBottomFrameHeight);
			}
			set
			{
				SetValue("BottomFrameHeight", value);
			}
		}

		/// 
		/// Gets the default height of the bottom frame.
		/// </summary>
		/// The default height of the bottom frame.</value>
		protected virtual int DefaultBottomFrameHeight => 1;

		/// 
		/// Gets or sets the height of the tab.
		/// </summary>
		/// The height of the tab.</value>
		[Category("Sizes")]
		[Description("The height of the tab.")]
		public virtual int TabHeight
		{
			get
			{
				return GetValue("TabHeight", DefaultTabHeight);
			}
			set
			{
				SetValue("TabHeight", value);
			}
		}

		/// 
		/// Gets or sets the height of the tab in Spread appearance.
		/// </summary>
		/// The height of the tab.</value>
		[Category("Sizes")]
		[Description("The height of the tab in Spread appearance.")]
		public virtual int TabSpreadHeight
		{
			get
			{
				return GetValue("TabSpreadHeight", DefaultTabHeight);
			}
			set
			{
				SetValue("TabSpreadHeight", value);
			}
		}

		/// 
		/// Gets the default height of the tab.
		/// </summary>
		/// The default height of the tab.</value>
		protected virtual int DefaultTabHeight => 21;

		/// 
		/// Gets or sets the default initial start point of the tabs.
		/// </summary>
		/// The default initial start point of the tabs.</value>
		protected virtual int DefaultHeadersOffset => 0;

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Category("Sizes")]
		[Description("The width of the right frame.")]
		public virtual int RightFrameWidth
		{
			get
			{
				return GetValue("RightFrameWidth", DefaultRightFrameWidth);
			}
			set
			{
				SetValue("RightFrameWidth", value);
			}
		}

		/// 
		/// Gets the default width of the right frame.
		/// </summary>
		/// The default width of the right frame.</value>
		protected virtual int DefaultRightFrameWidth => 1;

		/// 
		/// Gets or sets the height of the seperator frame.
		/// </summary>
		/// The height of the seperator frame.</value>
		[Category("Sizes")]
		[Description("The height of the seperator frame.")]
		public virtual int SeperatorFrameHeight
		{
			get
			{
				return GetValue("SeperatorFrameHeight", DefaultSeperatorFrameHeight);
			}
			set
			{
				SetValue("SeperatorFrameHeight", value);
			}
		}

		/// 
		/// Gets the default height of the seperator frame.
		/// </summary>
		/// The default height of the seperator frame.</value>
		protected virtual int DefaultSeperatorFrameHeight => 0;

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Category("Sizes")]
		[Description("The width of the left frame.")]
		public virtual int LeftFrameWidth
		{
			get
			{
				return GetValue("LeftFrameWidth", DefaultLeftFrameWidth);
			}
			set
			{
				SetValue("LeftFrameWidth", value);
			}
		}

		/// 
		/// Gets the default width of the left frame.
		/// </summary>
		/// The default width of the left frame.</value>
		protected virtual int DefaultLeftFrameWidth => 1;

		/// 
		/// Gets the frame left top style.
		/// </summary>
		/// The frame left top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopFrameStyle => new FramePartStyleValue(this, "LeftTopStyle");

		/// 
		/// Gets the frame top style.
		/// </summary>
		/// The frame top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopFrameStyle => new FramePartStyleValue(this, "TopFrameStyle");

		/// 
		/// Gets the frame right top style.
		/// </summary>
		/// The frame right top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopFrameStyle => new FramePartStyleValue(this, "RightTopFrameStyle");

		/// 
		/// Gets the frame left style.
		/// </summary>
		/// The frame left style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftFrameStyle => new FramePartStyleValue(this, "LeftFrameStyle");

		/// 
		/// Gets the frame right style.
		/// </summary>
		/// The frame right style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightFrameStyle => new FramePartStyleValue(this, "RightFrameStyle");

		/// 
		/// Gets the frame left bottom style.
		/// </summary>
		/// The frame left bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomFrameStyle => new FramePartStyleValue(this, "LeftBottomFrameStyle");

		/// 
		/// Gets the center style.
		/// </summary>
		/// The center style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterFrameStyle => new StyleValue(this, "CenterFrameStyle");

		/// 
		/// Gets the frame bottom style.
		/// </summary>
		/// The frame bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomFrameStyle => new FramePartStyleValue(this, "BottomFrameStyle");

		/// 
		/// Gets the frame right bottom style.
		/// </summary>
		/// The frame right bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomFrameStyle => new FramePartStyleValue(this, "RightBottomFrameStyle");

		/// 
		/// Gets the seperator frame style.
		/// </summary>
		/// The seperator frame style.</value>
		[Category("Styles")]
		[Description("The seperator style.")]
		public virtual SimpleFrameStyleValue SeperatorFrameStyle => new SimpleFrameStyleValue(LeftSeperatorFrameStyle, RightSeperatorFrameStyle, CenterSeperatorFrameStyle);

		/// 
		/// Gets the center seperator frame style.
		/// </summary>
		/// The center seperator frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterSeperatorFrameStyle => new StyleValue(this, "CenterSeperatorFrameStyle");

		/// 
		/// Gets the right seperator frame style.
		/// </summary>
		/// The right seperator frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue RightSeperatorFrameStyle => new StyleValue(this, "RightSeperatorFrameStyle");

		/// 
		/// Gets the left seperator frame style.
		/// </summary>
		/// The left seperator frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue LeftSeperatorFrameStyle => new StyleValue(this, "LeftSeperatorFrameStyle");

		/// 
		/// Gets the header lable normal padding.
		/// </summary>
		/// The header lable normal padding.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinValue<object> HeaderLableNormalPadding => new BidirectionalSkinValue<object>(this, CenterTopTabNormalLTRStyle.Padding, CenterTopTabNormalLTRStyle.Padding);

		/// 
		/// Gets the Close button normal style.
		/// </summary>
		/// The Close button normal style.</value>
		[Category("States")]
		[Description("The Close button normal style.")]
		public virtual StyleValue CloseButtonNormalStyle => new StyleValue(this, "CloseButtonNormalStyle");

		/// 
		/// Gets the Close button hover style.
		/// </summary>
		/// The Close button hover style.</value>
		[Category("States")]
		[Description("The Close button hover style.")]
		public virtual StyleValue CloseButtonHoverStyle => new StyleValue(this, "CloseButtonHoverStyle", CloseButtonNormalStyle);

		/// 
		/// Gets the Close button pressed style.
		/// </summary>
		/// The Close button pressed style.</value>
		[Category("States")]
		[Description("The Close button pressed style.")]
		public virtual StyleValue CloseButtonPressedStyle => new StyleValue(this, "CloseButtonPressedStyle", CloseButtonNormalStyle);

		/// 
		/// Gets or sets the size of the Close button.
		/// </summary>
		/// The size of the Close button.</value>
		[Category("Sizes")]
		[Description("The size of the Close button.")]
		public virtual Size CloseButtonSize
		{
			get
			{
				return GetValue("CloseButtonSize", GetImageSize(CloseButtonNormalStyle.BackgroundImage, DefaultCloseButtonSize));
			}
			set
			{
				SetValue("CloseButtonSize", value);
			}
		}

		/// 
		/// Gets the default size of the Close button.
		/// </summary>
		/// The default size of the Close button.</value>
		protected virtual Size DefaultCloseButtonSize => new Size(16, 16);

		/// 
		/// Gets the width of the Close button.
		/// </summary>
		/// The width of the Close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CloseButtonWidth => CloseButtonSize.Width + CloseButtonNormalStyle.Padding.Horizontal;

		/// 
		/// Gets the height of the Close button.
		/// </summary>
		/// The height of the Close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CloseButtonHeight => CloseButtonSize.Height;

		/// 
		/// Gets the expand button normal style.
		/// </summary>
		/// The expand button normal style.</value>
		[Category("States")]
		[Description("The expand button normal style.")]
		public virtual StyleValue ExpandButtonNormalStyle => new StyleValue(this, "ExpandButtonNormalStyle");

		/// 
		/// Gets the Expand button hover style.
		/// </summary>
		/// The Expand button hover style.</value>
		[Category("States")]
		[Description("The Expand button hover style.")]
		public virtual StyleValue ExpandButtonHoverStyle => new StyleValue(this, "ExpandButtonHoverStyle", ExpandButtonNormalStyle);

		/// 
		/// Gets the expand button pressed style.
		/// </summary>
		/// The expand button pressed style.</value>
		[Category("States")]
		[Description("The Expand button pressed style.")]
		public virtual StyleValue ExpandButtonPressedStyle => new StyleValue(this, "ExpandButtonPressedStyle", ExpandButtonNormalStyle);

		/// 
		/// Gets or sets the size of the expand button.
		/// </summary>
		/// The size of the Expand button.</value>
		[Category("Sizes")]
		[Description("The size of the expand button.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Size ExpandButtonSize => GetImageSize(ExpandButtonNormalStyle.BackgroundImage, DefaultExpandButtonSize);

		/// 
		/// Gets the default size of the expand button.
		/// </summary>
		/// The default size of the expand button.</value>
		protected virtual Size DefaultExpandButtonSize => new Size(16, 16);

		/// 
		/// Gets the width of the Expand button.
		/// </summary>
		/// The width of the Expand button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ExpandButtonWidth => ExpandButtonSize.Width + ExpandButtonNormalStyle.Padding.Horizontal;

		/// 
		/// Gets the height of the Expand button.
		/// </summary>
		/// The height of the Expand button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ExpandButtonHeight => ExpandButtonSize.Height;

		/// 
		/// Gets the collapse button normal style.
		/// </summary>
		/// The collapse button normal style.</value>
		[Category("States")]
		[Description("The collapse button normal style.")]
		public virtual StyleValue CollapseButtonNormalStyle => new StyleValue(this, "CollapseButtonNormalStyle");

		/// 
		/// Gets the Collapse button hover style.
		/// </summary>
		/// The Collapse button hover style.</value>
		[Category("States")]
		[Description("The Collapse button hover style.")]
		public virtual StyleValue CollapseButtonHoverStyle => new StyleValue(this, "CollapseButtonHoverStyle", CollapseButtonNormalStyle);

		/// 
		/// Gets the collapse button pressed style.
		/// </summary>
		/// The collapse button pressed style.</value>
		[Category("States")]
		[Description("The Collapse button pressed style.")]
		public virtual StyleValue CollapseButtonPressedStyle => new StyleValue(this, "CollapseButtonPressedStyle", CollapseButtonNormalStyle);

		/// 
		/// Gets or sets the size of the collapse button.
		/// </summary>
		/// The size of the Collapse button.</value>
		[Category("Sizes")]
		[Description("The size of the collapse button.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Size CollapseButtonSize => GetImageSize(CollapseButtonNormalStyle.BackgroundImage, DefaultCollapseButtonSize);

		/// 
		/// Gets the default size of the collapse button.
		/// </summary>
		/// The default size of the collapse button.</value>
		protected virtual Size DefaultCollapseButtonSize => new Size(16, 16);

		/// 
		/// Gets the width of the Collapse button.
		/// </summary>
		/// The width of the Collapse button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CollapseButtonWidth => CollapseButtonSize.Width + CollapseButtonNormalStyle.Padding.Horizontal;

		/// 
		/// Gets the height of the Collapse button.
		/// </summary>
		/// The height of the Collapse button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CollapseButtonHeight => CollapseButtonSize.Height;

		/// 
		/// Hide font property
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		/// 
		/// Hide fore color property
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		/// 
		/// Gets or sets the size of the tab image.
		/// </summary>
		/// The size of the tab image.</value>
		[Category("Sizes")]
		[Description("The width and height of the tab page image.")]
		public virtual Size TabImageSize
		{
			get
			{
				return new Size(TabImageWidth, TabImageHeight);
			}
			set
			{
				TabImageWidth = value.Width;
				TabImageHeight = value.Height;
			}
		}

		/// 
		/// Gets or sets the height of the tab image.
		/// </summary>
		/// The height of the tab image.</value>
		[Category("Sizes")]
		[Description("The height of the tab page image.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TabImageHeight
		{
			get
			{
				return GetValue("TabImageHeight", DefaultTabImageHeight);
			}
			set
			{
				SetValue("TabImageHeight", value);
			}
		}

		/// 
		/// Gets the default height of the tab image.
		/// </summary>
		/// The default height of the tab image.</value>
		protected virtual int DefaultTabImageHeight => 16;

		/// 
		/// Gets or sets the width of the tab image.
		/// </summary>
		/// The width of the tab image.</value>
		[Category("Sizes")]
		[Description("The width of the tab page image.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TabImageWidth
		{
			get
			{
				return GetValue("TabImageWidth", DefaultTabImageWidth);
			}
			set
			{
				SetValue("TabImageWidth", value);
			}
		}

		/// 
		/// Gets the default width of the tab image.
		/// </summary>
		/// The default width of the tab image.</value>
		protected virtual int DefaultTabImageWidth => 16;

		/// 
		/// Gets the contextual tab group normal style.
		/// </summary>
		public virtual StyleValue ContextualTabGroupNormalStyle => new StyleValue(this, "ContextualTabGroupNormalStyle");

		/// 
		/// Gets or sets the height of the contextual tab group.
		/// </summary>
		/// The height of the tab.</value>
		[Category("Sizes")]
		[Description("The height of the contextual tab group.")]
		public virtual int ContextualTabGroupHeight
		{
			get
			{
				return GetValue("ContextualTabGroupHeight", DefaultContextualTabGroupHeight);
			}
			set
			{
				SetValue("ContextualTabGroupHeight", value);
			}
		}

		/// 
		/// Gets the default height of the tab.
		/// </summary>
		/// The default height of the tab.</value>
		protected virtual int DefaultContextualTabGroupHeight => 21;

		/// 
		/// Gets the tab show content image.
		/// </summary>
		[Category("Images")]
		[Description("The default image shown on the each tab in 'MORE' display.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> TabShowContentImage => new BidirectionalSkinProperty<object>(this, "TabShowContentImageLTR", "TabShowContentImageRTL");

		[Category("Images")]
		[Description("The default image size shown on the each tab in 'MORE' display.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> TabShowContentImageSize => new BidirectionalSkinProperty<object>(this, "TabShowContentImageLTRSize", "TabShowContentImageRTLSize");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinProperty<object> TabShowContentImageHeight => new BidirectionalSkinProperty<object>(this, "TabShowContentImageLTRHeight", "TabShowContentImageRTLHeight");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BidirectionalSkinProperty<object> TabShowContentImageWidth => new BidirectionalSkinProperty<object>(this, "TabShowContentImageLTRWidth", "TabShowContentImageRTLWidth");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TabShowContentImageLTRHeight => TabShowContentImageLTRSize.Height;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TabShowContentImageLTRWidth => TabShowContentImageLTRSize.Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TabShowContentImageRTLHeight => TabShowContentImageRTLSize.Height;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TabShowContentImageRTLWidth => TabShowContentImageRTLSize.Width;

		/// 
		/// Gets or sets the tab show content image LTR.
		/// </summary>
		/// 
		/// The tab show content image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference TabShowContentImageLTR
		{
			get
			{
				return GetValue("TabShowContentImageLTR", new ImageResourceReference(typeof(TabControlSkin), "TabShowContentLTR.png"));
			}
			set
			{
				SetValue("TabShowContentImageLTR", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size TabShowContentImageLTRSize
		{
			get
			{
				return GetValue("TabShowContentImageLTRSize", GetImageSize(TabShowContentImageLTR, Size.Empty));
			}
			set
			{
				SetValue("TabShowContentImageLTRSize", value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size TabShowContentImageRTLSize
		{
			get
			{
				return GetValue("TabShowContentImageRTLSize", GetImageSize(TabShowContentImageRTL, Size.Empty));
			}
			set
			{
				SetValue("TabShowContentImageRTLSize", value);
			}
		}

		/// 
		/// Gets or sets the tab show content image RTL.
		/// </summary>
		/// 
		/// The tab show content image RTL.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference TabShowContentImageRTL
		{
			get
			{
				return GetValue("TabShowContentImageRTL", new ImageResourceReference(typeof(TabControlSkin), "TabShowContentRTL.png"));
			}
			set
			{
				SetValue("DropDownOverImageRTL", value);
			}
		}

		/// 
		/// Gets the More Tab image.
		/// </summary>
		/// The image.</value>
		[Category("Images")]
		[Description("The default image shown on tab 'MORE'.")]
		public virtual ImageResourceReference TabMoreImage
		{
			get
			{
				return GetValue("TabMoreImage", new ImageResourceReference(typeof(TabControlSkin), "TabMoreImage.png"));
			}
			set
			{
				SetValue("TabMoreImage", value);
			}
		}

		/// 
		/// Gets the tab page headers container spread style.
		/// </summary>
		[Category("Appearance")]
		[Description("Tab Page Headers Container style in Spread appearance.")]
		public virtual StyleValue TabPageHeadersContainerSpreadStyle => new StyleValue(this, "TabPageHeadersContainerSpreadStyle");

		/// 
		/// Gets the tab page headers container spread top padding.
		/// </summary>
		[Browsable(false)]
		public virtual int TabPageHeadersContainerSpreadStylePaddingTop => TabPageHeadersContainerSpreadStyle.Padding.Top;

		/// 
		/// Gets the tab page headers container spread bottom padding.
		/// </summary>
		[Browsable(false)]
		public virtual int TabPageHeadersContainerSpreadStylePaddingBottom => TabPageHeadersContainerSpreadStyle.Padding.Bottom;

		/// 
		/// Gets the tab page header gradient selected style.
		/// </summary>
		[Category("Appearance")]
		[Description("Tab Page Header Selected style.")]
		public virtual StyleValue TabPageHeaderSelectedStyle => new StyleValue(this, "TabPageHeaderSelectedStyle");

		/// 
		/// Gets the tab page more tab page style.
		/// </summary>
		[Category("Appearance")]
		[Description("The style of the tab pages in tab more content.")]
		public virtual StyleValue TabPageMoreTabPagesStyle => new StyleValue(this, "TabPageMoreTabPagesStyle", CenterTabTopNormalLTRSpreadStyle);

		/// 
		/// Gets the tab page more tab page hover style.
		/// </summary>
		[Category("Appearance")]
		[Description("The style of the tab pages in tab more content on hover.")]
		public virtual StyleValue TabPageMoreTabHoverPagesStyle => new StyleValue(this, "TabPageMoreTabHoverPagesStyle", CenterTabTopHoverLTRSpreadStyle);

		/// 
		/// Gets the tab top pressed more style.
		/// </summary>
		[Category("Appearance")]
		[Description("The top tab pressed more appearance style.")]
		public virtual StyleValue TabPageMoreTabPressedPagesStyle => new StyleValue(this, "TabPageMoreTabSelectedPagesStyle", CenterTabTopSelectedLTRSpreadStyle);

		/// 
		/// Gets or sets the height of the tab page more tab page.
		/// </summary>
		/// 
		/// The height of the tab page more tab page.
		/// </value>
		[Category("Sizes")]
		[Description("The height of the tab pages in tab more content.")]
		public virtual int TabPageMoreTabPageHeight
		{
			get
			{
				return GetValue("TabPageMoreTabPageHeight", DefaultTabPageMoreTabPageHeight);
			}
			set
			{
				SetValue("TabPageMoreTabPageHeight", value);
			}
		}

		/// 
		/// Gets the default height of the tab page more tab page.
		/// </summary>
		/// 
		/// The default height of the tab page more tab page.
		/// </value>
		private int DefaultTabPageMoreTabPageHeight => 44;

		/// 
		/// Resets the size of the right scroll button.
		/// </summary>
		private void ResetRightScrollButtonSize()
		{
			Reset("RightScrollButtonSize");
		}

		/// 
		/// Resets the size of the left scroll button.
		/// </summary>
		private void ResetLeftScrollButtonSize()
		{
			Reset("LeftScrollButtonSize");
		}

		/// 
		/// Resets the SpreadTabHeaderTextColumn.
		/// </summary>
		internal void ResetSpreadTabHeaderTextColumnStyle()
		{
			Reset("SpreadTabHeaderTextColumnStyle");
		}

		/// 
		/// Resets the width of the left tab top in LTR.
		/// </summary>
		internal void ResetLeftTopTabWidthLTR()
		{
			Reset("LeftTopTabWidthLTR");
		}

		/// 
		/// Resets the width of the left tab top in RTL.
		/// </summary>
		internal void ResetLeftTopTabWidthRTL()
		{
			Reset("LeftTopTabWidthRTL");
		}

		/// 
		/// Resets the width of the right tab top in LTR.
		/// </summary>
		internal void ResetRightTopTabWidthLTR()
		{
			Reset("RightTopTabWidthLTR");
		}

		/// 
		/// Resets the width of the right tab top in RTL.
		/// </summary>
		internal void ResetRightTopTabWidthRTL()
		{
			Reset("RightTopTabWidthRTL");
		}

		/// 
		/// Resets the width of the left tab Bottom in LTR.
		/// </summary>
		internal void ResetLeftBottomTabWidthLTR()
		{
			Reset("LeftBottomTabWidthLTR");
		}

		/// 
		/// Resets the width of the left tab Bottom in RTL.
		/// </summary>
		internal void ResetLeftBottomTabWidthRTL()
		{
			Reset("LeftBottomTabWidthRTL");
		}

		/// 
		/// Resets the width of the right tab Bottom in LTR.
		/// </summary>
		internal void ResetRightBottomTabWidthLTR()
		{
			Reset("RightBottomTabWidthLTR");
		}

		/// 
		/// Resets the width of the right tab Bottom in RTL.
		/// </summary>
		internal void ResetRightBottomTabWidthRTL()
		{
			Reset("RightBottomTabWidthRTL");
		}

		/// 
		/// Resets the height of the top frame.
		/// </summary>
		internal void ResetTopFrameHeight()
		{
			Reset("TopFrameHeight");
		}

		/// 
		/// Resets the height of the bottom frame.
		/// </summary>
		internal void ResetBottomFrameHeight()
		{
			Reset("BottomFrameHeight");
		}

		/// 
		/// Resets the height of the tab.
		/// </summary>
		internal void ResetTabHeight()
		{
			Reset("TabHeight");
		}

		/// 
		/// Resets the width of the right frame.
		/// </summary>
		internal void ResetRightFrameWidth()
		{
			Reset("RightFrameWidth");
		}

		/// 
		/// Resets the height of the seperator frame.
		/// </summary>
		private void ResetSeperatorFrameHeight()
		{
			Reset("SeperatorFrameHeight");
		}

		/// 
		/// Resets the width of the left frame.
		/// </summary>
		private void ResetLeftFrameWidth()
		{
			Reset("LeftFrameWidth");
		}

		/// 
		/// Resets the size of the Close button.
		/// </summary>
		private void ResetCloseButtonSize()
		{
			Reset("CloseButtonSize");
		}

		/// 
		/// Resets the size of the tab image.
		/// </summary>
		private void ResetTabImageSize()
		{
			Reset("TabImageHeight");
			Reset("TabImageWidth");
		}

		/// 
		/// Resets the height of the contextual tab group.
		/// </summary>
		internal void ResetContextualTabGroupHeight()
		{
			Reset("ContextualTabGroupHeight");
		}

		/// 
		/// Resets the tab show content image LTR.
		/// </summary>
		private void ResetTabShowContentImageLTR()
		{
			Reset("TabShowContentImageLTR");
		}

		/// 
		/// Resets the tab show content image RTL.
		/// </summary>
		private void ResetTabShowContentImageRTL()
		{
			Reset("TabShowContentImageRTL");
		}

		/// 
		/// Resets the height of the tab page more tab page.
		/// </summary>
		internal void ResetTabPageMoreTabPageHeight()
		{
			Reset("TabPageMoreTabPageHeight");
		}

		private void InitializeComponent()
		{
		}
	}
}
