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

namespace Gizmox.WebGUI.Forms.Layout
{
[Serializable]
	internal class PropertyNames
	{
		public static readonly string Alignment = "Alignment";

		public static readonly string Anchor = "Anchor";

		public static readonly string Appearance = "Appearance";

		public static readonly string AutoEllipsis = "AutoEllipsis";

		public static readonly string AutoScroll = "AutoScroll";

		public static readonly string AutoSize = "AutoSize";

		public static readonly string BorderStyle = "BorderStyle";

		public static readonly string Bounds = "Bounds";

		public static readonly string CellBorderStyle = "CellBorderStyle";

		public static readonly string CheckAlign = "CheckAlign";

		public static readonly string ChildIndex = "ChildIndex";

		public static readonly string ColumnHeadersHeight = "ColumnHeadersHeight";

		public static readonly string ColumnHeadersVisible = "ColumnHeadersVisible";

		public static readonly string Columns = "Columns";

		public static readonly string ColumnSpan = "ColumnSpan";

		public static readonly string ColumnStyles = "ColumnStyles";

		public static readonly string Controls = "Controls";

		public static readonly string DisplayRectangle = "DisplayRectangle";

		public static readonly string DisplayStyle = "DisplayStyle";

		public static readonly string Dock = "Dock";

		public static readonly string DrawMode = "DrawMode";

		public static readonly string DropDownButtonWidth = "DropDownButtonWidth";

		public static readonly string FlatAppearanceBorderSize = "FlatAppearance.BorderSize";

		public static readonly string FlatStyle = "FlatStyle";

		public static readonly string FlowBreak = "FlowBreak";

		public static readonly string FlowDirection = "FlowDirection";

		public static readonly string Font = "Font";

		public static readonly string GripStyle = "GripStyle";

		public static readonly string GrowStyle = "GrowStyle";

		public static readonly string Image = "Image";

		public static readonly string ImageAlign = "ImageAlign";

		public static readonly string ImageIndex = "ImageIndex";

		public static readonly string ImageKey = "ImageKey";

		public static readonly string ImageScaling = "ImageScaling";

		public static readonly string ImageScalingSize = "ImageScalingSize";

		public static readonly string Items = "Items";

		public static readonly string LayoutSettings = "LayoutSettings";

		public static readonly string LayoutStyle = "LayoutStyle";

		public static readonly string LinkArea = "LinkArea";

		public static readonly string Links = "Links";

		public static readonly string Location = "Location";

		public static readonly string Margin = "Margin";

		public static readonly string MaximumSize = "MaximumSize";

		public static readonly string MinimumSize = "MinimumSize";

		public static readonly string Multiline = "Multiline";

		public static readonly string Orientation = "Orientation";

		public static readonly string Padding = "Padding";

		public static readonly string Parent = "Parent";

		public static readonly string PreferredSize = "PreferredSize";

		public static readonly string Renderer = "Renderer";

		public static readonly string RightToLeft = "RightToLeft";

		public static readonly string RightToLeftLayout = "RightToLeftLayout";

		public static readonly string RowHeadersVisible = "RowHeadersVisible";

		public static readonly string RowHeadersWidth = "RowHeadersWidth";

		public static readonly string Rows = "Rows";

		public static readonly string RowSpan = "RowSpan";

		public static readonly string RowStyles = "RowStyles";

		public static readonly string ScrollBars = "ScrollBars";

		public static readonly string ShowCheckMargin = "ShowCheckMargin";

		public static readonly string ShowDropDownArrow = "ShowDropDownArrow";

		public static readonly string ShowImageMargin = "ShowCheckMargin";

		public static readonly string Size = "Size";

		public static readonly string Spring = "Spring";

		public static readonly string Style = "Style";

		public static readonly string TableIndex = "TableIndex";

		public static readonly string Text = "Text";

		public static readonly string TextAlign = "TextAlign";

		public static readonly string TextImageRelation = "TextImageRelation";

		public static readonly string UseCompatibleTextRendering = "UseCompatibleTextRendering";

		public static readonly string Visible = "Visible";

		public static readonly string WordWrap = "WordWrap";

		public static readonly string WrapContents = "WrapContents";
	}
}
