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
	public class WGTags
	{
		public const string WatermarkTextBox = "WMT";

		public const string ControlTypeComponent = "CTC";

		public const string ToolBox = "TBX";

		public const string DockManager = "DM";

		public const string DeviceIntegrator = "DI";

		public const string DockingZone = "DZ";

		public const string DockingZoneHeader = "DZH";

		public const string Token = "TK";

		public const string Literal = "LT";

		public const string UserControl = "UC";

		public const string Object = "OBJ";

		public const string Events = "ES";

		public const string Event = "E";

		public const string Error = "Er";

		public const string PropertyGrid = "PG";

		public const string PropertyGridView = "PV";

		public const string PropertyGridEntry = "PE";

		public const string Refresh = "RE";

		public const string Response = "R";

		public const string Form = "F";

		public const string MasterPage = "MP";

		public const string MasterPageContent = "MPC";

		public const string TreeView = "TV";

		public const string TreeNode = "TN";

		public const string TrackBar = "TRB";

		public const string NumericUpDown = "NUD";

		public const string DomainUpDown = "DUD";

		public const string Header = "HDR";

		public const string Content = "CNT";

		public const string Button = "B";

		public const string WebSocket = "WEBS";

		public const string Panel = "P";

		public const string PictureBox = "PBX";

		public const string ListView = "LV";

		public const string ListViewPanel = "LVP";

		public const string Group = "G";

		public const string Row = "R";

		public const string Rows = "RS";

		public const string Column = "C";

		public const string Menu = "M";

		public const string Item = "I";

		public const string TextBox = "T";

		public const string ListBox = "LX";

		public const string Label = "L";

		public const string TabControl = "TC";

		public const string TabPage = "TP";

		public const string Splitter = "S";

		public const string ToolBarControl = "T1";

		public const string ToolBarButton = "T2";

		public const string TableLayoutPanel = "TLP";

		public const string MainMenu = "MM";

		public const string MenuItem = "I";

		public const string Option = "O";

		public const string Options = "OS";

		public const string MonthCalendar = "MC";

		public const string RadioButton = "RB";

		public const string ComboBox = "CB";

		public const string GroupBox = "GB";

		public const string CheckBox = "CH";

		public const string DateTimePicker = "DP";

		public const string LinkLabel = "LL";

		public const string Line = "LI";

		public const string CheckedListBox = "CX";

		public const string ColorListBox = "CL";

		public const string ColorComboBox = "CCB";

		public const string StatusBar = "SB";

		public const string StatusPanel = "SP";

		public const string ContextMenu = "CM";

		public const string ProgressBar = "PB";

		public const string Applet = "A";

		public const string ASPXBox = "ASPX";

		public const string Param = "P";

		public const string ScrollablePanel = "SP";

		public const string HtmlBox = "H";

		public const string FrameControl = "FC";

		public const string XamlBox = "XB";

		public const string ClientEvents = "OES";

		public const string ClientEvent = "OE";

		public const string RichTextBox = "RX";

		public const string MethodInvokes = "MIs";

		public const string MethodInvoke = "MI";

		public const string UpdateParams = "PRM";

		public const string FlowLayoutPanel = "FL";

		public const string DataGridView = "DG";

		public const string DataGridViewColumn = "DC";

		public const string DataGridViewRow = "DR";

		public const string DataGridViewCell = "DL";

		public const string DataGridViewOptions = "DO";

		public const string ScheduleBox = "SCB";

		public const string ShortcutsContainer = "SCC";

		public const string MdiClient = "MDIC";

		public const string DragElement = "DE";

		public const string DraggedOverElement = "DOE";

		public const string TableLayoutRow = "TLR";

		public const string TableLayoutCol = "TLC";

		public const string TableLayoutCell = "TLL";

		public const string Chart = "CT";

		public const string Packages = "PCKS";

		public const string Package = "PCK";

		public const string Themes = "THMS";

		public const string Theme = "THM";

		public const string Assembly = "ASM";

		public const string Manifest = "MFT";

		public const string Tags = "TS";

		public const string Tag = "TG";

		public const string FormControlBox = "FCB";

		public const string DataGridViewBlock = "DGVB";

		public const string ToolStripItem = "TSI";

		public const string ToolStrip = "TSP";

		public const string StatusStrip = "SSP";

		public const string ToolStripContainer = "TSC";

		public const string ToolStripPanel = "TSPN";

		public const string MenuStrip = "MSP";

		public const string RibbonBar = "RBB";

		public const string Table = "TBL";

		public const string ClientStorage = "OLS";

		public const string ClientContext = "OCT";

		public const string Accelerometer = "ACC";

		public const string Compass = "CMP";

		public const string Camera = "CAM";

		public const string Contacts = "CON";

		public const string Geolocation = "GPS";

		public const string Notifications = "NTF";

		public const string FileManager = "FMR";

		public const string ConnectionType = "CTY";

		public const string DeviceInfo = "DIN";

		public const string DeviceMedia = "DMA";

		public const string DeviceGlobalization = "GLZ";

		public const string Capture = "CAP";

		public const string Splashscreen = "SPL";

		public const string Storage = "SQL";

		public const string ExtendedColumnHeaderRows = "XCR";

		public const string ExtendedColumnHeaderCollection = "XC";

		public const string ContextualToolbar = "CTB";

		public const string ContextualToolbarButton = "CTBB";
	}
}
