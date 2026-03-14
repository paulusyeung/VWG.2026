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
	/// Specifies the style and behavior of a control.</summary>
	/// </summary>
	[Flags]
	public enum ControlStyles
	{
		/// If true, the control ignores the window message WM_ERASEBKGND to reduce flicker. This style should only be applied if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true.</summary>
		AllPaintingInWmPaint = 0x2000,
		/// If true, the control keeps a copy of the text rather than getting it from the <see cref="P:System.Windows.Forms.Control.Handle"></see> each time it is needed. This style defaults to false. This behavior improves performance, but makes it difficult to keep the text synchronized.</summary>
		CacheText = 0x4000,
		/// If true, the control is a container-like control.</summary>
		ContainerControl = 1,
		/// If true, drawing is performed in a buffer, and after it completes, the result is output to the screen. Double-buffering prevents flicker caused by the redrawing of the control. If you set <see cref="F:System.Windows.Forms.ControlStyles.DoubleBuffer"></see> to true, you should alsoset <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> and <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		DoubleBuffer = 0x10000,
		/// If true, the <see cref="M:System.Windows.Forms.Control.OnNotifyMessage(System.Windows.Forms.Message)"></see> method is called for every message sent to the control's <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)"></see>. This style defaults to false. <see cref="F:System.Windows.Forms.ControlStyles.EnableNotifyMessage"></see> does not work in partial trust.</summary>
		EnableNotifyMessage = 0x8000,
		/// If true, the control has a fixed height when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Height"></see> remains unchanged.</summary>
		/// 1</filterpriority>
		FixedHeight = 0x40,
		/// If true, the control has a fixed width when auto-scaled. For example, if a layout operation attempts to rescale the control to accommodate a new <see cref="T:System.Drawing.Font"></see>, the control's <see cref="P:System.Windows.Forms.Control.Width"></see> remains unchanged.</summary>
		FixedWidth = 0x20,
		/// If true, the control is drawn opaque and the background is not painted.</summary>
		Opaque = 4,
		/// If true, the control is first drawn to a buffer rather than directly to the screen, which can reduce flicker. If you set this property to true, you should also set the <see cref="F:System.Windows.Forms.ControlStyles.AllPaintingInWmPaint"></see> to true.</summary>
		/// 1</filterpriority>
		OptimizedDoubleBuffer = 0x20000,
		/// If true, the control is redrawn when it is resized.</summary>
		ResizeRedraw = 0x10,
		/// If true, the control can receive focus.</summary>
		Selectable = 0x200,
		/// If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.Click"></see> behavior.</summary>
		StandardClick = 0x100,
		/// If true, the control implements the standard <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> behavior. This style is ignored if the <see cref="F:System.Windows.Forms.ControlStyles.StandardClick"></see> bit is not set to true.</summary>
		StandardDoubleClick = 0x1000,
		/// If true, the control accepts a <see cref="P:System.Windows.Forms.Control.BackColor"></see> with an alpha component of less than 255 to simulate transparency. Transparency will be simulated only if the <see cref="F:System.Windows.Forms.ControlStyles.UserPaint"></see> bit is set to true and the parent control is derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
		SupportsTransparentBackColor = 0x800,
		/// If true, the control does its own mouse processing, and mouse events are not handled by the operating system.</summary>
		UserMouse = 0x400,
		/// If true, the control paints itself rather than the operating system doing so. If false, the <see cref="E:System.Windows.Forms.Control.Paint"></see> event is not raised. This style only applies to classes derived from <see cref="T:System.Windows.Forms.Control"></see>.</summary>
		UserPaint = 2,
		/// Specifies that the value of the control's Text property, if set, determines the control's default Active Accessibility name and shortcut key.</summary>
		UseTextForAccessibility = 0x40000
	}
}
