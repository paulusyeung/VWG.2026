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
	[Serializable]
	[SkinContainer(typeof(ToolBarSkin))]
	[ToolboxBitmap(typeof(Button), "Button.bmp")]
	public class ToolBarButtonSkin : ButtonSkin
	{
		/// 
		/// Gets the pushed style.
		/// </summary>
		/// The pushed style.</value>
		[Category("States")]
		[Description("The pushed button style.")]
		public virtual FrameStyleValue PushedStyle => new FrameStyleValue(LeftBottomPushedStyle, LeftPushedStyle, LeftTopPushedStyle, TopPushedStyle, RightTopPushedStyle, RightPushedStyle, RightBottomPushedStyle, BottomPushedStyle, CenterPushedStyle);

		/// 
		/// Gets the drop down button style.
		/// </summary>
		/// The drop down button style.</value>
		[Category("States")]
		[Description("The drop down button sytle.")]
		public virtual StyleValue DropDownButtonStyle => new StyleValue(this, "DropDownButtonStyle");

		/// 
		/// Gets the seperator style.
		/// </summary>
		/// The seperator style.</value>
		public StyleValue SeperatorStyle => new StyleValue(this, "SeperatorStyle");

		/// 
		/// Gets or sets the width of the seperator.
		/// </summary>
		/// The width of the seperator.</value>
		[Category("Sizes")]
		[Description("The width of the seperator.")]
		public int SeperatorWidth
		{
			get
			{
				return GetValue("SeperatorWidth", 3);
			}
			set
			{
				SetValue("SeperatorWidth", value);
			}
		}

		/// 
		/// Gets the center pushed style.
		/// </summary>
		/// The center pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterPushedStyle => new StyleValue(this, "CenterPushedStyle", CenterPressedStyle);

		/// 
		/// Gets the left pushed style.
		/// </summary>
		/// The left pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftPushedStyle => new FramePartStyleValue(this, "LeftPushedStyle", LeftPressedStyle);

		/// 
		/// Gets the top pushed style.
		/// </summary>
		/// The top pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopPushedStyle => new FramePartStyleValue(this, "TopPushedStyle", TopPressedStyle);

		/// 
		/// Gets the bottom pushed style.
		/// </summary>
		/// The bottom pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomPushedStyle => new FramePartStyleValue(this, "BottomPushedStyle", BottomPressedStyle);

		/// 
		/// Gets the right pushed style.
		/// </summary>
		/// The right pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightPushedStyle => new FramePartStyleValue(this, "RightPushedStyle", RightPressedStyle);

		/// 
		/// Gets the right top pushed style.
		/// </summary>
		/// The right top pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopPushedStyle => new FramePartStyleValue(this, "RightTopPushedStyle", RightTopPressedStyle);

		/// 
		/// Gets the left top pushed style.
		/// </summary>
		/// The left top pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopPushedStyle => new FramePartStyleValue(this, "LeftTopPushedStyle", LeftTopPressedStyle);

		/// 
		/// Gets the left bottom pushed style.
		/// </summary>
		/// The left bottom pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomPushedStyle => new FramePartStyleValue(this, "LeftBottomPushedStyle", LeftBottomPressedStyle);

		/// 
		/// Gets the right bottom pushed style.
		/// </summary>
		/// The right bottom pushed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomPushedStyle => new FramePartStyleValue(this, "RightBottomPushedStyle", RightBottomPressedStyle);

		/// 
		/// Gets the size of the drop down image.
		/// </summary>
		/// The size of the drop down image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size DropDownImageSize => GetImageSize(DropDownButtonStyle.BackgroundImage, Size.Empty);

		/// 
		/// Gets the width of the drop down image.
		/// </summary>
		/// The width of the drop down image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int DropDownImageWidth => DropDownImageSize.Width;

		private void InitializeComponent()
		{
		}
	}
}
