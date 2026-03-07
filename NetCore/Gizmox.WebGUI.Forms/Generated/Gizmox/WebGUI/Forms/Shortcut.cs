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
	/// Specifies shortcut keys that can be used.
	/// </summary>
	public enum Shortcut
	{
		/// 
		/// The shortcut keys Alt+0
		/// </summary>        
		Alt0 = 262192,
		/// 
		/// The shortcut keys Alt+1
		/// </summary>
		Alt1 = 262193,
		/// 
		/// The shortcut keys Alt+2
		/// </summary>
		Alt2 = 262194,
		/// 
		/// The shortcut keys Alt+3
		/// </summary>
		Alt3 = 262195,
		/// 
		/// The shortcut keys Alt+4
		/// </summary>
		Alt4 = 262196,
		/// 
		/// The shortcut keys Alt+5
		/// </summary>
		Alt5 = 262197,
		/// 
		/// The shortcut keys Alt+6
		/// </summary>
		Alt6 = 262198,
		/// 
		/// The shortcut keys Alt+7
		/// </summary>
		Alt7 = 262199,
		/// 
		/// The shortcut keys Alt+8
		/// </summary>
		Alt8 = 262200,
		/// 
		/// The shortcut keys Alt+9
		/// </summary>
		Alt9 = 262201,
		/// 
		/// The shortcut keys Alt+Bksp
		/// </summary>
		AltBksp = 262152,
		/// 
		/// The shortcut keys Alt+F1
		/// </summary>
		AltF1 = 262256,
		/// 
		/// The shortcut keys Alt+F10
		/// </summary>
		AltF10 = 262265,
		/// 
		/// The shortcut keys Alt+F11
		/// </summary>
		AltF11 = 262266,
		/// 
		/// The shortcut keys Alt+F12
		/// </summary>
		AltF12 = 262267,
		/// 
		/// The shortcut keys Alt+F2
		/// </summary>
		AltF2 = 262257,
		/// 
		/// The shortcut keys Alt+F3
		/// </summary>
		AltF3 = 262258,
		/// 
		/// The shortcut keys Alt+F4
		/// </summary>
		AltF4 = 262259,
		/// 
		/// The shortcut keys Alt+F5
		/// </summary>
		AltF5 = 262260,
		/// 
		/// The shortcut keys Alt+F6
		/// </summary>
		AltF6 = 262261,
		/// 
		/// The shortcut keys Alt+F7
		/// </summary>
		AltF7 = 262262,
		/// 
		/// The shortcut keys Alt+F8
		/// </summary>
		AltF8 = 262263,
		/// 
		/// The shortcut keys Alt+F9
		/// </summary>
		AltF9 = 262264,
		/// 
		/// The shortcut keys Ctrl+0
		/// </summary>
		Ctrl0 = 131120,
		/// 
		/// The shortcut keys Ctrl+1
		/// </summary>
		Ctrl1 = 131121,
		/// 
		/// The shortcut keys Ctrl+2
		/// </summary>
		Ctrl2 = 131122,
		/// 
		/// The shortcut keys Ctrl+3
		/// </summary>
		Ctrl3 = 131123,
		/// 
		/// The shortcut keys Ctrl+4
		/// </summary>
		Ctrl4 = 131124,
		/// 
		/// The shortcut keys Ctrl+5
		/// </summary>
		Ctrl5 = 131125,
		/// 
		/// The shortcut keys Ctrl+6
		/// </summary>
		Ctrl6 = 131126,
		/// 
		/// The shortcut keys Ctrl+7
		/// </summary>
		Ctrl7 = 131127,
		/// 
		/// The shortcut keys Ctrl+8
		/// </summary>
		Ctrl8 = 131128,
		/// 
		/// The shortcut keys Ctrl+9
		/// </summary>
		Ctrl9 = 131129,
		/// 
		/// The shortcut keys Ctrl+A
		/// </summary>
		CtrlA = 131137,
		/// 
		/// The shortcut keys Ctrl+B
		/// </summary>
		CtrlB = 131138,
		/// 
		/// The shortcut keys Ctrl+C
		/// </summary>
		CtrlC = 131139,
		/// 
		/// The shortcut keys Ctrl+D
		/// </summary>
		CtrlD = 131140,
		/// 
		/// The shortcut keys Ctrl+Del
		/// </summary>
		CtrlDel = 131118,
		/// 
		/// The shortcut keys Ctrl+E
		/// </summary>
		CtrlE = 131141,
		/// 
		/// The shortcut keys Ctrl+F
		/// </summary>
		CtrlF = 131142,
		/// 
		/// The shortcut keys Ctrl+F1
		/// </summary>
		CtrlF1 = 131184,
		/// 
		/// The shortcut keys Ctrl+F10
		/// </summary>
		CtrlF10 = 131193,
		/// 
		/// The shortcut keys Ctrl+F11
		/// </summary>
		CtrlF11 = 131194,
		/// 
		/// The shortcut keys Ctrl+F12
		/// </summary>
		CtrlF12 = 131195,
		/// 
		/// The shortcut keys Ctrl+F2
		/// </summary>
		CtrlF2 = 131185,
		/// 
		/// The shortcut keys Ctrl+F3
		/// </summary>
		CtrlF3 = 131186,
		/// 
		/// The shortcut keys Ctrl+F4
		/// </summary>
		CtrlF4 = 131187,
		/// 
		/// The shortcut keys Ctrl+F5
		/// </summary>
		CtrlF5 = 131188,
		/// 
		/// The shortcut keys Ctrl+F6
		/// </summary>
		CtrlF6 = 131189,
		/// 
		/// The shortcut keys Ctrl+F7
		/// </summary>
		CtrlF7 = 131190,
		/// 
		/// The shortcut keys Ctrl+F8
		/// </summary>
		CtrlF8 = 131191,
		/// 
		/// The shortcut keys Ctrl+F9
		/// </summary>
		CtrlF9 = 131192,
		/// 
		/// The shortcut keys Ctrl+G
		/// </summary>
		CtrlG = 131143,
		/// 
		/// The shortcut keys Ctrl+H
		/// </summary>
		CtrlH = 131144,
		/// 
		/// The shortcut keys Ctrl+I
		/// </summary>
		CtrlI = 131145,
		/// 
		/// The shortcut keys Ctrl+Ins
		/// </summary>
		CtrlIns = 131117,
		/// 
		/// The shortcut keys Ctrl+J
		/// </summary>
		CtrlJ = 131146,
		/// 
		/// The shortcut keys Ctrl+K
		/// </summary>
		CtrlK = 131147,
		/// 
		/// The shortcut keys Ctrl+L
		/// </summary>
		CtrlL = 131148,
		/// 
		/// The shortcut keys Ctrl+M
		/// </summary>
		CtrlM = 131149,
		/// 
		/// The shortcut keys Ctrl+N
		/// </summary>
		CtrlN = 131150,
		/// 
		/// The shortcut keys Ctrl+O
		/// </summary>
		CtrlO = 131151,
		/// 
		/// The shortcut keys Ctrl+P
		/// </summary>
		CtrlP = 131152,
		/// 
		/// The shortcut keys Ctrl+Q
		/// </summary>
		CtrlQ = 131153,
		/// 
		/// The shortcut keys Ctrl+R
		/// </summary>
		CtrlR = 131154,
		/// 
		/// The shortcut keys Ctrl+S
		/// </summary>
		CtrlS = 131155,
		/// 
		/// The shortcut keys CtrlShift+0
		/// </summary>
		CtrlShift0 = 196656,
		/// 
		/// The shortcut keys CtrlShift+1
		/// </summary>
		CtrlShift1 = 196657,
		/// 
		/// The shortcut keys CtrlShift+2
		/// </summary>
		CtrlShift2 = 196658,
		/// 
		/// The shortcut keys CtrlShift+3
		/// </summary>
		CtrlShift3 = 196659,
		/// 
		/// The shortcut keys CtrlShift+4
		/// </summary>
		CtrlShift4 = 196660,
		/// 
		/// The shortcut keys CtrlShift+5
		/// </summary>
		CtrlShift5 = 196661,
		/// 
		/// The shortcut keys CtrlShift+6
		/// </summary>
		CtrlShift6 = 196662,
		/// 
		/// The shortcut keys CtrlShift+7
		/// </summary>
		CtrlShift7 = 196663,
		/// 
		/// The shortcut keys CtrlShift+8
		/// </summary>
		CtrlShift8 = 196664,
		/// 
		/// The shortcut keys CtrlShift+9
		/// </summary>
		CtrlShift9 = 196665,
		/// 
		/// The shortcut keys CtrlShift+A
		/// </summary>
		CtrlShiftA = 196673,
		/// 
		/// The shortcut keys CtrlShift+B
		/// </summary>
		CtrlShiftB = 196674,
		/// 
		/// The shortcut keys CtrlShift+C
		/// </summary>
		CtrlShiftC = 196675,
		/// 
		/// The shortcut keys CtrlShift+D
		/// </summary>
		CtrlShiftD = 196676,
		/// 
		/// The shortcut keys CtrlShift+E
		/// </summary>
		CtrlShiftE = 196677,
		/// 
		/// The shortcut keys CtrlShift+F
		/// </summary>
		CtrlShiftF = 196678,
		/// 
		/// The shortcut keys CtrlShift+F1
		/// </summary>
		CtrlShiftF1 = 196720,
		/// 
		/// The shortcut keys CtrlShift+F10
		/// </summary>
		CtrlShiftF10 = 196729,
		/// 
		/// The shortcut keys CtrlShift+F11
		/// </summary>
		CtrlShiftF11 = 196730,
		/// 
		/// The shortcut keys CtrlShift+F12
		/// </summary>
		CtrlShiftF12 = 196731,
		/// 
		/// The shortcut keys CtrlShift+F2
		/// </summary>
		CtrlShiftF2 = 196721,
		/// 
		/// The shortcut keys CtrlShift+F3
		/// </summary>
		CtrlShiftF3 = 196722,
		/// 
		/// The shortcut keys CtrlShift+F4
		/// </summary>
		CtrlShiftF4 = 196723,
		/// 
		/// The shortcut keys CtrlShift+F5
		/// </summary>
		CtrlShiftF5 = 196724,
		/// 
		/// The shortcut keys CtrlShift+F6
		/// </summary>
		CtrlShiftF6 = 196725,
		/// 
		/// The shortcut keys CtrlShift+F7
		/// </summary>
		CtrlShiftF7 = 196726,
		/// 
		/// The shortcut keys CtrlShift+F8
		/// </summary>
		CtrlShiftF8 = 196727,
		/// 
		/// The shortcut keys CtrlShift+F9
		/// </summary>
		CtrlShiftF9 = 196728,
		/// 
		/// The shortcut keys CtrlShift+G
		/// </summary>
		CtrlShiftG = 196679,
		/// 
		/// The shortcut keys CtrlShift+H
		/// </summary>
		CtrlShiftH = 196680,
		/// 
		/// The shortcut keys CtrlShift+I
		/// </summary>
		CtrlShiftI = 196681,
		/// 
		/// The shortcut keys CtrlShift+J
		/// </summary>
		CtrlShiftJ = 196682,
		/// 
		/// The shortcut keys CtrlShift+K
		/// </summary>
		CtrlShiftK = 196683,
		/// 
		/// The shortcut keys CtrlShift+L
		/// </summary>
		CtrlShiftL = 196684,
		/// 
		/// The shortcut keys CtrlShift+M
		/// </summary>
		CtrlShiftM = 196685,
		/// 
		/// The shortcut keys CtrlShift+N
		/// </summary>
		CtrlShiftN = 196686,
		/// 
		/// The shortcut keys CtrlShift+O
		/// </summary>
		CtrlShiftO = 196687,
		/// 
		/// The shortcut keys CtrlShift+P
		/// </summary>
		CtrlShiftP = 196688,
		/// 
		/// The shortcut keys CtrlShift+Q
		/// </summary>
		CtrlShiftQ = 196689,
		/// 
		/// The shortcut keys CtrlShift+R
		/// </summary>
		CtrlShiftR = 196690,
		/// 
		/// The shortcut keys CtrlShift+S
		/// </summary>
		CtrlShiftS = 196691,
		/// 
		/// The shortcut keys CtrlShift+T
		/// </summary>
		CtrlShiftT = 196692,
		/// 
		/// The shortcut keys CtrlShift+U
		/// </summary>
		CtrlShiftU = 196693,
		/// 
		/// The shortcut keys CtrlShift+V
		/// </summary>
		CtrlShiftV = 196694,
		/// 
		/// The shortcut keys CtrlShift+W
		/// </summary>
		CtrlShiftW = 196695,
		/// 
		/// The shortcut keys CtrlShift+X
		/// </summary>
		CtrlShiftX = 196696,
		/// 
		/// The shortcut keys CtrlShift+Y
		/// </summary>
		CtrlShiftY = 196697,
		/// 
		/// The shortcut keys CtrlShift+Z
		/// </summary>
		CtrlShiftZ = 196698,
		/// 
		/// The shortcut keys Ctrl+T
		/// </summary>
		CtrlT = 131156,
		/// 
		/// The shortcut keys Ctrl+U
		/// </summary>
		CtrlU = 131157,
		/// 
		/// The shortcut keys Ctrl+V
		/// </summary>
		CtrlV = 131158,
		/// 
		/// The shortcut keys Ctrl+W
		/// </summary>
		CtrlW = 131159,
		/// 
		/// The shortcut keys Ctrl+X
		/// </summary>
		CtrlX = 131160,
		/// 
		/// The shortcut keys Ctrl+Y
		/// </summary>
		CtrlY = 131161,
		/// 
		/// The shortcut keys Ctrl+Z
		/// </summary>
		CtrlZ = 131162,
		/// 
		/// The shortcut keys Del
		/// </summary>
		Del = 46,
		/// 
		/// The shortcut keys F1
		/// </summary>
		F1 = 112,
		/// 
		/// The shortcut keys 10
		/// </summary>
		F10 = 121,
		/// 
		/// The shortcut keys F11
		/// </summary>
		F11 = 122,
		/// 
		/// The shortcut keys F1
		/// </summary>
		F12 = 123,
		/// 
		/// The shortcut keys F2
		/// </summary>
		F2 = 113,
		/// 
		/// The shortcut keys F3
		/// </summary>
		F3 = 114,
		/// 
		/// The shortcut keys F4
		/// </summary>
		F4 = 115,
		/// 
		/// The shortcut keys F5
		/// </summary>
		F5 = 116,
		/// 
		/// The shortcut keys F6
		/// </summary>
		F6 = 117,
		/// 
		/// The shortcut keys F7
		/// </summary>
		F7 = 118,
		/// 
		/// The shortcut keys F8
		/// </summary>
		F8 = 119,
		/// 
		/// The shortcut keys F9
		/// </summary>
		F9 = 120,
		/// 
		/// The shortcut keys Ins
		/// </summary>
		Ins = 45,
		/// 
		/// The shortcut keys None
		/// </summary>
		None = 0,
		/// 
		/// The shortcut keys Shift+Del
		/// </summary>
		ShiftDel = 65582,
		/// 
		/// The shortcut keys Shift+F1
		/// </summary>
		ShiftF1 = 65648,
		/// 
		/// The shortcut keys Shift+F10
		/// </summary>
		ShiftF10 = 65657,
		/// 
		/// The shortcut keys Shift+F11
		/// </summary>
		ShiftF11 = 65658,
		/// 
		/// The shortcut keys Shift+F12
		/// </summary>
		ShiftF12 = 65659,
		/// 
		/// The shortcut keys Shift+F2
		/// </summary>
		ShiftF2 = 65649,
		/// 
		/// The shortcut keys Shift+F3
		/// </summary>
		ShiftF3 = 65650,
		/// 
		/// The shortcut keys Shift+F4
		/// </summary>
		ShiftF4 = 65651,
		/// 
		/// The shortcut keys Shift+F5
		/// </summary>
		ShiftF5 = 65652,
		/// 
		/// The shortcut keys Shift+F6
		/// </summary>
		ShiftF6 = 65653,
		/// 
		/// The shortcut keys Shift+F7
		/// </summary>
		ShiftF7 = 65654,
		/// 
		/// The shortcut keys Shift+F8
		/// </summary>
		ShiftF8 = 65655,
		/// 
		/// The shortcut keys Shift+F9
		/// </summary>
		ShiftF9 = 65656,
		/// 
		/// The shortcut keys Shift+Ins
		/// </summary>
		ShiftIns = 65581
	}
}
