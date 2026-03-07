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
	public class ToolStripDropDownSkin : ToolStripSkin
	{
		/// 
		/// Gets or sets the width of the popup window offset.
		/// </summary>
		/// The width of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset width for the popup window.")]
		public virtual int DropDownOffsetWidth
		{
			get
			{
				return GetValue("DropDownOffsetWidth", DefaultDropDownOffsetWidth);
			}
			set
			{
				SetValue("DropDownOffsetWidth", value);
			}
		}

		/// 
		/// Gets the default width of the popup window offset.
		/// </summary>
		/// The default width of the popup window offset.</value>
		protected virtual int DefaultDropDownOffsetWidth
		{
			get
			{
				int num = DropDownStyle.CenterStyle.BorderWidth.Left + DropDownStyle.CenterStyle.BorderWidth.Right + DropDownStyle.CenterStyle.Padding.Horizontal;
				if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
				{
					return num;
				}
				return num + RightDropDownFrameWidth + LeftDropDownFrameWidth;
			}
		}

		/// 
		/// Gets or sets the height of the popup window offset.
		/// </summary>
		/// The height of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset height for the popup window.")]
		public virtual int DropDownOffsetHeight
		{
			get
			{
				return GetValue("DropDownOffsetHeight", DefaultDropDownOffsetHeight);
			}
			set
			{
				SetValue("DropDownOffsetHeight", value);
			}
		}

		/// 
		/// Gets the default height of the popup window offset.
		/// </summary>
		/// The default height of the popup window offset.</value>
		protected virtual int DefaultDropDownOffsetHeight
		{
			get
			{
				int num = DropDownStyle.CenterStyle.BorderWidth.Top + DropDownStyle.CenterStyle.BorderWidth.Bottom + DropDownStyle.CenterStyle.Padding.Vertical;
				if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
				{
					return num;
				}
				return num + TopDropDownFrameHeight + BottomDropDownFrameHeight;
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
		public virtual int LeftDropDownFrameWidth => GetFrameEdgeSize(DropDownStyle, FrameEdge.Left);

		/// 
		/// Gets or sets the width of the right popup window frame.
		/// </summary>
		/// The width of the right popup window frame.</value>
		[Category("Sizes")]
		[Description("The width of the right popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightDropDownFrameWidth => GetFrameEdgeSize(DropDownStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the top popup window frame.
		/// </summary>
		/// The height of the top popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the top popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int TopDropDownFrameHeight => GetFrameEdgeSize(DropDownStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the height of the bottom popup window frame.
		/// </summary>
		/// The height of the bottom popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int BottomDropDownFrameHeight => GetFrameEdgeSize(DropDownStyle, FrameEdge.Bottom);

		/// 
		/// Gets the opup window style.
		/// </summary>
		/// The opup window style.</value>
		[Category("States")]
		[Description("The popup window style.")]
		public FrameStyleValue DropDownStyle => new FrameStyleValue(LeftBottomDropDownStyle, LeftDropDownStyle, LeftTopDropDownStyle, TopDropDownStyle, RightTopDropDownStyle, RightDropDownStyle, RightBottomDropDownStyle, BottomDropDownStyle, CenterDropDownStyle);

		/// 
		/// Gets the center popup window style.
		/// </summary>
		/// The center popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterDropDownStyle => new StyleValue(this, "CenterDropDownStyle", PopupSkin.CenterStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left popup window style.
		/// </summary>
		/// The left popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftDropDownStyle => new FramePartStyleValue(this, "LeftDropDownStyle", PopupSkin.LeftStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the top popup window style.
		/// </summary>
		/// The top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopDropDownStyle => new FramePartStyleValue(this, "TopDropDownStyle", PopupSkin.TopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the bottom popup window style.
		/// </summary>
		/// The bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomDropDownStyle => new FramePartStyleValue(this, "BottomDropDownStyle", PopupSkin.BottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right popup window style.
		/// </summary>
		/// The right popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightDropDownStyle => new FramePartStyleValue(this, "RightDropDownStyle", PopupSkin.RightStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right top popup window style.
		/// </summary>
		/// The right top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopDropDownStyle => new FramePartStyleValue(this, "RightTopDropDownStyle", PopupSkin.RightTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left top popup window style.
		/// </summary>
		/// The left top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopDropDownStyle => new FramePartStyleValue(this, "LeftTopDropDownStyle", PopupSkin.LeftTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left bottom popup window style.
		/// </summary>
		/// The left bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomDropDownStyle => new FramePartStyleValue(this, "LeftBottomDropDownStyle", PopupSkin.LeftBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right bottom popup window style.
		/// </summary>
		/// The right bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomDropDownStyle => new FramePartStyleValue(this, "RightBottomDropDownStyle", PopupSkin.RightBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the popups skin.
		/// </summary>
		/// The popups skin.</value>
		private PopupsSkin PopupSkin => SkinFactory.GetSkin(base.Owner, typeof(PopupsSkin), blnEnableSkinableFallback: true) as PopupsSkin;

		/// 
		/// Resets the width of the popup window offset.
		/// </summary>
		private void ResetDropDownOffsetWidth()
		{
			Reset("DropDownOffsetWidth");
		}

		/// 
		/// Resets the height of the popup window offset.
		/// </summary>
		private void ResetDropDownOffsetHeight()
		{
			Reset("DropDownOffsetHeight");
		}

		/// 
		/// Resets the width of the left popup window frame.
		/// </summary>
		internal void ResetLeftDropDownFrameWidth()
		{
			Reset("LeftDropDownFrameWidth");
		}

		/// 
		/// Resets the width of the right popup window frame.
		/// </summary>
		internal void ResetRightDropDownFrameWidth()
		{
			Reset("RightDropDownFrameWidth");
		}

		/// 
		/// Resets the height of the top popup window frame.
		/// </summary>
		internal void ResetTopDropDownFrameHeight()
		{
			Reset("TopDropDownFrameHeight");
		}

		/// 
		/// Resets the height of the bottom popup window frame.
		/// </summary>
		internal void ResetBottomDropDownFrameHeight()
		{
			Reset("BottomDropDownFrameHeight");
		}

		private void InitializeComponent()
		{
		}
	}
}
