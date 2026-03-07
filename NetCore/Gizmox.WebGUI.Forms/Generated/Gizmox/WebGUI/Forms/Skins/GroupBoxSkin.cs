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
	/// GroupBox Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(GroupBox), "GroupBox.bmp")]
	public class GroupBoxSkin : ControlSkin
	{
		/// 
		/// Gets the normal groupbox style.
		/// </summary>
		/// The normal groupbox style.</value>
		[Category("States")]
		[Description("The normal groupbox style.")]
		public HeaderedFrameStyleValue NormalStyle => new HeaderedFrameStyleValue(LeftBottomNormalStyle, LeftNormalStyle, LeftTopNormalStyle, TopNormalStyle, RightTopNormalStyle, RightNormalStyle, RightBottomNormalStyle, BottomNormalStyle, CenterNormalStyle, HeaderLeftNormalStyle, HeaderCenterNormalStyle, HeaderRightNormalStyle);

		/// 
		/// Gets the header center normal style.
		/// </summary>
		/// The header center normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue HeaderCenterNormalStyle => new StyleValue(this, "HeaderCenterNormalStyle");

		/// 
		/// Gets or sets the width of the header left cell.
		/// </summary>
		/// The width of the header left cell.</value>
		[Category("Sizes")]
		[Description("The width of the header left cell.")]
		public virtual int HeaderLeftWidth
		{
			get
			{
				return GetValue("HeaderLeftWidth", GetImageWidth(NormalStyle.HeaderLeftStyle.BackgroundImage, DefaultHeaderLeftWidth));
			}
			set
			{
				SetValue("HeaderLeftWidth", value);
			}
		}

		/// 
		/// Gets the default width of the header left.
		/// </summary>
		/// The default width of the header left.</value>
		protected virtual int DefaultHeaderLeftWidth => 1;

		/// 
		/// Gets the header left normal style.
		/// </summary>
		/// The header left normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue HeaderLeftNormalStyle => new StyleValue(this, "HeaderLeftNormalStyle");

		/// 
		/// Gets or sets the width of the header right cell.
		/// </summary>
		/// The width of the header right cell.</value>
		[Category("Sizes")]
		[Description("The width of the header right cell.")]
		public virtual int HeaderRightWidth
		{
			get
			{
				return GetValue("HeaderRightWidth", GetImageWidth(NormalStyle.HeaderRightStyle.BackgroundImage, DefaultHeaderRightWidth));
			}
			set
			{
				SetValue("HeaderRightWidth", value);
			}
		}

		/// 
		/// Gets the default width of the header right.
		/// </summary>
		/// The default width of the header right.</value>
		protected virtual int DefaultHeaderRightWidth => 1;

		/// 
		/// Gets the header right normal style.
		/// </summary>
		/// The header right normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue HeaderRightNormalStyle => new StyleValue(this, "HeaderRightNormalStyle");

		/// 
		/// Gets the center normal style.
		/// </summary>
		/// The center normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterNormalStyle => new StyleValue(this, "CenterNormalStyle");

		/// 
		/// Gets the left normal style.
		/// </summary>
		/// The left normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftNormalStyle => new FramePartStyleValue(this, "LeftNormalStyle");

		/// 
		/// Gets the top normal style.
		/// </summary>
		/// The top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopNormalStyle => new FramePartStyleValue(this, "TopNormalStyle");

		/// 
		/// Gets the bottom normal style.
		/// </summary>
		/// The bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomNormalStyle => new FramePartStyleValue(this, "BottomNormalStyle");

		/// 
		/// Gets the right normal style.
		/// </summary>
		/// The right normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightNormalStyle => new FramePartStyleValue(this, "RightNormalStyle");

		/// 
		/// Gets the right top normal style.
		/// </summary>
		/// The right top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopNormalStyle => new FramePartStyleValue(this, "RightTopNormalStyle");

		/// 
		/// Gets the left top normal style.
		/// </summary>
		/// The left top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopNormalStyle => new FramePartStyleValue(this, "LeftTopNormalStyle");

		/// 
		/// Gets the left bottom normal style.
		/// </summary>
		/// The left bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomNormalStyle => new FramePartStyleValue(this, "LeftBottomNormalStyle");

		/// 
		/// Gets the right bottom normal style.
		/// </summary>
		/// The right bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomNormalStyle => new FramePartStyleValue(this, "RightBottomNormalStyle");

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Category("Sizes")]
		[Description("The width of the left frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int LeftFrameWidth => GetFrameEdgeSize(NormalStyle, FrameEdge.Left);

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Category("Sizes")]
		[Description("The width of the right frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightFrameWidth => GetFrameEdgeSize(NormalStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the top frame.
		/// </summary>
		/// The height of the top frame.</value>
		[Category("Sizes")]
		[Description("The height of the top frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int TopFrameHeight => GetFrameEdgeSize(NormalStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the height of the bottom frame.
		/// </summary>
		/// The height of the bottom frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int BottomFrameHeight => GetFrameEdgeSize(NormalStyle, FrameEdge.Bottom);

		/// 
		/// Resets the width of the header left cell.
		/// </summary>
		internal void ResetHeaderLeftWidth()
		{
			Reset("HeaderLeftWidth");
		}

		/// 
		/// Resets the width of the header right cell.
		/// </summary>
		internal void ResetHeaderRightWidth()
		{
			Reset("HeaderRightWidth");
		}

		/// 
		/// Resets the width of the left frame.
		/// </summary>
		internal void ResetLeftFrameWidth()
		{
			Reset("LeftFrameWidth");
		}

		/// 
		/// Resets the width of the right frame.
		/// </summary>
		internal void ResetRightFrameWidth()
		{
			Reset("RightFrameWidth");
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

		private void InitializeComponent()
		{
		}
	}
}
