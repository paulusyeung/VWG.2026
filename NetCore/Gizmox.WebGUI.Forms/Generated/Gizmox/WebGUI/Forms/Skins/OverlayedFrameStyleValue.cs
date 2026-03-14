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
	/// Provides a class for editing multiple frame styles
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[TypeConverter(typeof(OverlayedFrameStyleValueConverter))]
	public class OverlayedFrameStyleValue : FrameStyleValue
	{
		/// 
		///
		/// </summary>
		private readonly FrameOverlayStyleValue mobjLeftOverlayStyle;

		/// 
		///
		/// </summary>
		private readonly FrameOverlayStyleValue mobjRightOverlayStyle;

		/// 
		/// Gets the left overlay style.
		/// </summary>
		/// The left overlay style.</value>
		public FrameOverlayStyleValue LeftOverlayStyle => mobjLeftOverlayStyle;

		/// 
		/// Gets the right overlay style.
		/// </summary>
		/// The right overlay style.</value>
		public FrameOverlayStyleValue RightOverlayStyle => mobjRightOverlayStyle;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.OverlayedFrameStyleValue" /> class.
		/// </summary>
		/// <param name="objLeftBottomStyle">The left bottom style.</param>
		/// <param name="objLeftStyle">The left style.</param>
		/// <param name="objLeftTopStyle">obj left top style.</param>
		/// <param name="objTopStyle">The top style.</param>
		/// <param name="objRightTopStyle">The right top style.</param>
		/// <param name="objRightStyle">The right style.</param>
		/// <param name="objRightBottomStyle">The right bottom style.</param>
		/// <param name="objBottomStyle">The bottom style.</param>
		/// <param name="objCenterStyle">The center style.</param>
		/// <param name="objLeftOverlayStyle">The left overlay style.</param>
		/// <param name="objRightOverlayStyle">The right overlay style.</param>
		public OverlayedFrameStyleValue(FramePartStyleValue objLeftBottomStyle, FramePartStyleValue objLeftStyle, FramePartStyleValue objLeftTopStyle, FramePartStyleValue objTopStyle, FramePartStyleValue objRightTopStyle, FramePartStyleValue objRightStyle, FramePartStyleValue objRightBottomStyle, FramePartStyleValue objBottomStyle, StyleValue objCenterStyle, FrameOverlayStyleValue objLeftOverlayStyle, FrameOverlayStyleValue objRightOverlayStyle)
			: base(objLeftBottomStyle, objLeftStyle, objLeftTopStyle, objTopStyle, objRightTopStyle, objRightStyle, objRightBottomStyle, objBottomStyle, objCenterStyle)
		{
			mobjLeftOverlayStyle = objLeftOverlayStyle;
			mobjRightOverlayStyle = objRightOverlayStyle;
		}
	}
}
