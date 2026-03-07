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
	/// ToolBar Skin
	/// </summary>
	[ToolboxBitmap(typeof(ToolBar), "ToolBar.bmp")]
	[SkinDependency(typeof(ToolBarButtonSkin))]
	[SkinDependency(typeof(FlatToolBarSkin))]
	[SkinDependency(typeof(FlatToolBarButtonSkin))]
	public class ToolBarSkin : ControlSkin
	{
		/// 
		/// Gets the height of the defalut.
		/// </summary>
		/// The height of the defalut.</value>
		internal static int DefalutHeight => 25;

		/// 
		/// Gets or sets the height of the toolbar.
		/// </summary>
		/// The height of the toolbar.</value>
		[Category("Sizes")]
		[Description("The height of the main menu.")]
		public int Height
		{
			get
			{
				return GetValue("Height", DefalutHeight);
			}
			set
			{
				SetValue("Height", value);
			}
		}

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
		/// Resets the height of the menu.
		/// </summary>
		private void ResetHeight()
		{
			Reset("Height");
		}

		private void InitializeComponent()
		{
		}
	}
}
