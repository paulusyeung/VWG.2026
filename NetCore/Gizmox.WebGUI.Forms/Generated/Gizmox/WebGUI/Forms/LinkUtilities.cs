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
	[Serializable]
	internal class LinkUtilities
	{
		private static Color ieactiveLinkColor = Color.Empty;

		private const string IEAnchorColor = "Anchor Color";

		private const string IEAnchorColorHover = "Anchor Color Hover";

		private const string IEAnchorColorVisited = "Anchor Color Visited";

		private static Color ielinkColor = Color.Empty;

		public const string IEMainRegPath = "Software\\Microsoft\\Internet Explorer\\Main";

		private const string IESettingsRegPath = "Software\\Microsoft\\Internet Explorer\\Settings";

		private static Color ievisitedLinkColor = Color.Empty;

		public static Color IEActiveLinkColor
		{
			get
			{
				if (ieactiveLinkColor.IsEmpty)
				{
					ieactiveLinkColor = GetIEColor("Anchor Color Hover");
				}
				return ieactiveLinkColor;
			}
		}

		public static Color IELinkColor
		{
			get
			{
				if (ielinkColor.IsEmpty)
				{
					ielinkColor = GetIEColor("Anchor Color");
				}
				return ielinkColor;
			}
		}

		public static Color IEVisitedLinkColor
		{
			get
			{
				if (ievisitedLinkColor.IsEmpty)
				{
					ievisitedLinkColor = GetIEColor("Anchor Color Visited");
				}
				return ievisitedLinkColor;
			}
		}

		public static void EnsureLinkFonts(Font baseFont, LinkBehavior link, ref Font linkFont, ref Font hoverLinkFont)
		{
			if (linkFont == null || hoverLinkFont == null)
			{
				bool flag = true;
				bool flag2 = true;
				if (link == LinkBehavior.SystemDefault)
				{
					link = GetIELinkBehavior();
				}
				switch (link)
				{
				case LinkBehavior.AlwaysUnderline:
					flag = true;
					flag2 = true;
					break;
				case LinkBehavior.HoverUnderline:
					flag = false;
					flag2 = true;
					break;
				case LinkBehavior.NeverUnderline:
					flag = false;
					flag2 = false;
					break;
				}
				if (flag2 == flag)
				{
					FontStyle style = baseFont.Style;
					style = ((!flag2) ? (style & ~FontStyle.Underline) : (style | FontStyle.Underline));
					hoverLinkFont = new Font(baseFont, style);
					linkFont = hoverLinkFont;
				}
				else
				{
					FontStyle style2 = baseFont.Style;
					style2 = ((!flag2) ? (style2 & ~FontStyle.Underline) : (style2 | FontStyle.Underline));
					hoverLinkFont = new Font(baseFont, style2);
					FontStyle style3 = baseFont.Style;
					style3 = ((!flag) ? (style3 & ~FontStyle.Underline) : (style3 | FontStyle.Underline));
					linkFont = new Font(baseFont, style3);
				}
			}
		}

		private static Color GetIEColor(string strName)
		{
			return Color.Red;
		}

		public static LinkBehavior GetIELinkBehavior()
		{
			return LinkBehavior.AlwaysUnderline;
		}
	}
}
