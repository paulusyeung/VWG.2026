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
	/// ToolStrip Skin
	/// </summary>
	[Serializable]
	[SkinDependency(typeof(ToolStripButtonSkin))]
	[SkinDependency(typeof(ToolStripDropDownButtonSkin))]
	[SkinDependency(typeof(ToolStripLabelSkin))]
	[SkinDependency(typeof(ToolStripSeparatorSkin))]
	[SkinDependency(typeof(ToolStripSplitButtonSkin))]
	[SkinDependency(typeof(ToolStripControlHostSkin))]
	[SkinDependency(typeof(ToolStripMenuItemSkin))]
	[SkinDependency(typeof(ToolStripDropDownSkin))]
	[SkinDependency(typeof(ToolStripDropDownContentPanelSkin))]
	public class ToolStripSkin : ControlSkin
	{
		internal const int IMAGE_SCALING_SIZE = 16;

		/// 
		/// Gets the frame frame style.
		/// </summary>
		/// The frame frame style.</value>
		public FrameStyleValue FrameStyle => new FrameStyleValue(LeftBottomStyle, LeftStyle, LeftTopStyle, TopStyle, RightTopStyle, RightStyle, RightBottomStyle, BottomStyle, CenterStyle);

		/// 
		/// Gets or sets the height of the top frame.
		/// </summary>
		/// The height of the top frame.</value>
		[Category("Sizes")]
		[Description("The height of the top frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int TopFrameHeight => GetFrameEdgeSize(FrameStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Category("Sizes")]
		[Description("The width of the right frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int RightFrameWidth => GetFrameEdgeSize(FrameStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the bottom frame.
		/// </summary>
		/// The height of the bottom frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int BottomFrameHeight => GetFrameEdgeSize(FrameStyle, FrameEdge.Bottom);

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Category("Sizes")]
		[Description("The width of the left frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int LeftFrameWidth => GetFrameEdgeSize(FrameStyle, FrameEdge.Left);

		/// 
		/// Gets the frame left top style.
		/// </summary>
		/// The frame left top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue LeftTopStyle => new FramePartStyleValue(this, "LeftTopStyle");

		/// 
		/// Gets the frame top style.
		/// </summary>
		/// The frame top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue TopStyle => new FramePartStyleValue(this, "TopStyle");

		/// 
		/// Gets the frame right top style.
		/// </summary>
		/// The frame right top style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue RightTopStyle => new FramePartStyleValue(this, "RightTopStyle");

		/// 
		/// Gets the frame left style.
		/// </summary>
		/// The frame left style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue LeftStyle => new FramePartStyleValue(this, "LeftStyle");

		/// 
		/// Gets the frame right style.
		/// </summary>
		/// The frame right style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue RightStyle => new FramePartStyleValue(this, "RightStyle");

		/// 
		/// Gets the frame left bottom style.
		/// </summary>
		/// The frame left bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue LeftBottomStyle => new FramePartStyleValue(this, "LeftBottomStyle");

		/// 
		/// Gets the center style.
		/// </summary>
		/// The center style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue CenterStyle => new StyleValue(this, "CenterStyle");

		/// 
		/// Gets the frame bottom style.
		/// </summary>
		/// The frame bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue BottomStyle => new FramePartStyleValue(this, "BottomStyle");

		/// 
		/// Gets the frame right bottom style.
		/// </summary>
		/// The frame right bottom style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FramePartStyleValue RightBottomStyle => new FramePartStyleValue(this, "RightBottomStyle");

		/// 
		/// Gets the horizontal drop down button style.
		/// </summary>
		/// The horizontal drop down button style.</value>
		public StyleValue HorizontalDropDownButtonStyle => new StyleValue(this, "HorizontalDropDownButtonStyle");

		/// 
		/// Gets the vertical drop down button style.
		/// </summary>
		/// The vertical drop down button style.</value>
		public StyleValue VerticalDropDownButtonStyle => new StyleValue(this, "VerticalDropDownButtonStyle");

		/// 
		/// Gets the width of the horizontal drop down button.
		/// </summary>
		/// The width of the horizontal drop down button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalDropDownButtonWidth => GetImageWidth(HorizontalDropDownButtonStyle.BackgroundImage);

		/// 
		/// Gets the height of the vertical drop down button.
		/// </summary>
		/// The height of the vertical drop down button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalDropDownButtonHeight => GetImageHeight(VerticalDropDownButtonStyle.BackgroundImage);

		/// 
		/// Gets the vertical grip style.
		/// </summary>
		/// The vertical grip style.</value>
		public StyleValue VerticalGripStyle => new StyleValue(this, "VerticalGripStyle");

		/// 
		/// Gets the horizontal grip style.
		/// </summary>
		/// The horizontal grip style.</value>
		public StyleValue HorizontalGripStyle => new StyleValue(this, "HorizontalGripStyle");

		/// 
		/// Gets the width of the drop down button.
		/// </summary>
		/// The width of the drop down button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalGripWidth => GetImageWidth(HorizontalGripStyle.BackgroundImage);

		/// 
		/// Gets the height of the vertical grip.
		/// </summary>
		/// The height of the vertical grip.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalGripHeight => GetImageHeight(VerticalGripStyle.BackgroundImage);

		/// 
		/// Gets or sets the width of the popup window offset.
		/// </summary>
		/// The width of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset width for the popup window.")]
		public virtual int PopupWindowOffsetWidth
		{
			get
			{
				return GetValue("PopupWindowOffsetWidth", DefaultPopupWindowOffsetWidth);
			}
			set
			{
				SetValue("PopupWindowOffsetWidth", value);
			}
		}

		/// 
		/// Gets the default width of the popup window offset.
		/// </summary>
		/// The default width of the popup window offset.</value>
		protected virtual int DefaultPopupWindowOffsetWidth => RightPopupWindowFrameWidth + LeftPopupWindowFrameWidth;

		/// 
		/// Gets or sets the height of the popup window offset.
		/// </summary>
		/// The height of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset height for the popup window.")]
		public virtual int PopupWindowOffsetHeight
		{
			get
			{
				return GetValue("PopupWindowOffsetHeight", DefaultPopupWindowOffsetHeight);
			}
			set
			{
				SetValue("PopupWindowOffsetHeight", value);
			}
		}

		/// 
		/// Gets the default height of the popup window offset.
		/// </summary>
		/// The default height of the popup window offset.</value>
		protected virtual int DefaultPopupWindowOffsetHeight
		{
			get
			{
				int num = CenterPopupWindowStyle.BorderWidth.Top + CenterPopupWindowStyle.BorderWidth.Bottom + CenterPopupWindowStyle.Padding.Vertical;
				if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
				{
					return num;
				}
				return num + TopPopupWindowFrameHeight + BottomPopupWindowFrameHeight;
			}
		}

		/// 
		/// Gets or sets the width of the left popup window frame.
		/// </summary>
		/// The width of the left popup window frame.</value>
		[Category("Sizes")]
		[Description("The width of the left popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int LeftPopupWindowFrameWidth => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Left);

		/// 
		/// Gets or sets the width of the right popup window frame.
		/// </summary>
		/// The width of the right popup window frame.</value>
		[Category("Sizes")]
		[Description("The width of the right popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightPopupWindowFrameWidth => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the top popup window frame.
		/// </summary>
		/// The height of the top popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the top popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int TopPopupWindowFrameHeight => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the height of the bottom popup window frame.
		/// </summary>
		/// The height of the bottom popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int BottomPopupWindowFrameHeight => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Bottom);

		/// 
		/// Gets the opup window style.
		/// </summary>
		/// The opup window style.</value>
		[Category("States")]
		[Description("The popup window style.")]
		public FrameStyleValue PopupWindowStyle => new FrameStyleValue(LeftBottomPopupWindowStyle, LeftPopupWindowStyle, LeftTopPopupWindowStyle, TopPopupWindowStyle, RightTopPopupWindowStyle, RightPopupWindowStyle, RightBottomPopupWindowStyle, BottomPopupWindowStyle, CenterPopupWindowStyle);

		/// 
		/// Gets the center popup window style.
		/// </summary>
		/// The center popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterPopupWindowStyle => new StyleValue(this, "CenterPopupWindowStyle", PopupSkin.CenterStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left popup window style.
		/// </summary>
		/// The left popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftPopupWindowStyle => new FramePartStyleValue(this, "LeftPopupWindowStyle", PopupSkin.LeftStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the top popup window style.
		/// </summary>
		/// The top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopPopupWindowStyle => new FramePartStyleValue(this, "TopPopupWindowStyle", PopupSkin.TopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the bottom popup window style.
		/// </summary>
		/// The bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomPopupWindowStyle => new FramePartStyleValue(this, "BottomPopupWindowStyle", PopupSkin.BottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right popup window style.
		/// </summary>
		/// The right popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightPopupWindowStyle => new FramePartStyleValue(this, "RightPopupWindowStyle", PopupSkin.RightStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right top popup window style.
		/// </summary>
		/// The right top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopPopupWindowStyle => new FramePartStyleValue(this, "RightTopPopupWindowStyle", PopupSkin.RightTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left top popup window style.
		/// </summary>
		/// The left top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopPopupWindowStyle => new FramePartStyleValue(this, "LeftTopPopupWindowStyle", PopupSkin.LeftTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left bottom popup window style.
		/// </summary>
		/// The left bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomPopupWindowStyle => new FramePartStyleValue(this, "LeftBottomPopupWindowStyle", PopupSkin.LeftBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right bottom popup window style.
		/// </summary>
		/// The right bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomPopupWindowStyle => new FramePartStyleValue(this, "RightBottomPopupWindowStyle", PopupSkin.RightBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the popups skin.
		/// </summary>
		/// The popups skin.</value>
		private PopupsSkin PopupSkin => SkinFactory.GetSkin(base.Owner, typeof(PopupsSkin), blnEnableSkinableFallback: true) as PopupsSkin;

		/// 
		/// Gets or sets the size of the image scaling.
		/// </summary>
		/// 
		/// The size of the image scaling.
		/// </value>
		public Size ImageScalingSize
		{
			get
			{
				return GetValue("ImageScalingSize", new Size(16, 16));
			}
			set
			{
				SetValue("ImageScalingSize", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the width of the popup window offset.
		/// </summary>
		private void ResetPopupWindowOffsetWidth()
		{
			Reset("PopupWindowOffsetWidth");
		}

		/// 
		/// Resets the height of the popup window offset.
		/// </summary>
		private void ResetPopupWindowOffsetHeight()
		{
			Reset("PopupWindowOffsetHeight");
		}

		/// 
		/// Resets the width of the left popup window frame.
		/// </summary>
		internal void ResetLeftPopupWindowFrameWidth()
		{
			Reset("LeftPopupWindowFrameWidth");
		}

		/// 
		/// Resets the width of the right popup window frame.
		/// </summary>
		internal void ResetRightPopupWindowFrameWidth()
		{
			Reset("RightPopupWindowFrameWidth");
		}

		/// 
		/// Resets the height of the top popup window frame.
		/// </summary>
		internal void ResetTopPopupWindowFrameHeight()
		{
			Reset("TopPopupWindowFrameHeight");
		}

		/// 
		/// Resets the height of the bottom popup window frame.
		/// </summary>
		internal void ResetBottomPopupWindowFrameHeight()
		{
			Reset("BottomPopupWindowFrameHeight");
		}
	}
}
