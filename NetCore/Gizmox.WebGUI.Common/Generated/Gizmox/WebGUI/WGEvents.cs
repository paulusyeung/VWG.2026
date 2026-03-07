#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
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
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI
{
	[Serializable]
	public class WGEvents
	{
		public const string Click = "CL";

		public const string DoubleClick = "DCL";

		public const string KeyDown = "KD";

		public const string ValueChange = "VC";

		public const string GotFocus = "GF";

		public const string LostFocus = "LF";

		public const string CheckedChange = "CC";

		public const string SizeChange = "SC";

		public const string EnterKeyDown = "EKD";

		public const string LocationChange = "LC";

		public const string Expand = "EXP";

		public const string Collapse = "COL";

		public const string SelectionChange = "SLC";

		public const string DragDrop = "DD";

		public const string AfterLabelEdit = "ALE";

		public const string ChangeColumnWidth = "CCW";

		public const string RightClick = "RC";

		public const string Closing = "CLI";

		public const string Closed = "CLO";

		public const string Activated = "AC";

		public const string Deactivate = "DAT";

		public const string Enter = "EN";

		public const string Leave = "LE";

		public const string PositionChanged = "PC";

		public const string BeginEdit = "BE";

		public const string OrientationChanged = "OC";

		public const string Swipe = "SWP";

		public const string StartDrag = "SD";

		public const string EndEdit = "EE";

		public const string ColumnDividerDoubleClick = "CDD";

		public const string TransitionVisualEffectEnd = "TVE";

		public const string Notification = "NF";

		public const string DeviceNotImplementedError = "DNIE";

		public const string DropDown = "CBDD";

		public const string DropDownClosed = "CBDDC";

		public const string Save = "SAV";

		public const string GoogleClick = "GC";

		public const string GoogleDoubleClick = "GDC";

		public const string GoogleLocationChanged = "GLC";

		public const string GoogleAddressGEOSearched = "GGEO";

		public const string GoogleZoomChanged = "GZC";

		public const string GoogleRightClick = "GRC";

		public const string GoogleMapTypeChanged = "GMT";

		public const string GoogleBoundsChanged = "GBC";

		public const string GoogleHeadingChanged = "GHC";

		public const string GoogleOverlayInfoOpened = "GOI";

		public const string GoogleOverlayInfoClosed = "GOV";

		public const string GoogleInfoWindowClosed = "GIW";

		public const string GoogleGroundClick = "GGC";

		public const string GoogleGroundDoubleClick = "GGD";

		public const string GoogleCircleClick = "GCC";

		public const string GoogleCircleDoubleClick = "GCD";

		public const string GoogleCircleRightClick = "GCR";

		public const string GoogleOverlayClick = "GOC";

		public const string GoogleOverlayDoubleClick = "GOD";

		public const string GoogleOverlayRightClick = "GOR";

		public const string GoogleOverlayLocationChanged = "GOL";

		public const string GoogleKmlClick = "GKC";

		public const string GoogleWeatherClick = "GWC";

		public const string GooglePolylineClick = "GPC";

		public const string GooglePolylineDoubleClick = "GPD";

		public const string GooglePolylineRightClick = "GPR";

		public const string GooglePolygonClick = "GLL";

		public const string GooglePolygonDoubleClick = "GLD";

		public const string GooglePolygonRightClick = "GLG";

		public const string GoogleRectangleClick = "GRE";

		public const string GoogleRectangleDoubleClick = "GRD";

		public const string GoogleRectangleRightClick = "GRR";

		public const string DeviceAccelerometer = "DAC";

		public const string DeviceCompass = "DCO";

		public const string DeviceGeolocation = "DGE";

		public const string DevicePause = "DPA";

		public const string DeviceResume = "DRE";

		public const string DeviceOnline = "DON";

		public const string DeviceOffline = "DOF";

		public const string DeviceBackButton = "DBB";

		public const string DeviceBatteryCritical = "DBC";

		public const string DeviceBatteryLow = "DBL";

		public const string DeviceBatteryStatus = "DBS";

		public const string DeviceMenuButton = "DMB";

		public const string DeviceSearchButton = "DSB";

		public const string DeviceStartCallButton = "DSC";

		public const string DeviceEndCallButton = "DEC";

		public const string DeviceVolumeDownButton = "DVD";

		public const string DeviceVolumeUpButton = "DVU";

		public const string DeviceMediaPosition = "DMP";

		public const string UploadControlBatchStartingHandler = "ULBSH";

		public const string UploadControlBatchCompletedHandler = "ULBCH";

		public const string UploadControlErrorHandler = "ULEH";

		public const string UploadControlFileCompletedHandler = "ULFCH";
	}
}
