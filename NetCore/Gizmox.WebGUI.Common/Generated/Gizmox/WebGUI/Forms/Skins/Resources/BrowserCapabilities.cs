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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	[TypeConverter(typeof(BrowserCapabilitiesConverter))]
	public class BrowserCapabilities
	{
		private CSS3BrowserCapabilities menmForbiddenBrowserCSS3Capabilities;

		private HTML5BrowserCapabilities menmForbiddenBrowserHTML5Capabilities;

		private MISCBrowserCapabilities menmForbiddenBrowserMISCCapabilities;

		private CSS3BrowserCapabilities menmRequiredBrowserCSS3Capabilities;

		private HTML5BrowserCapabilities menmRequiredBrowserHTML5Capabilities;

		private MISCBrowserCapabilities menmRequiredBrowserMISCCapabilities;

		public static BrowserCapabilities Empty = new BrowserCapabilities(CSS3BrowserCapabilities.None, HTML5BrowserCapabilities.None, MISCBrowserCapabilities.None, CSS3BrowserCapabilities.None, HTML5BrowserCapabilities.None, MISCBrowserCapabilities.None);

		public CSS3BrowserCapabilities ForbiddenBrowserCSS3Capabilities
		{
			get
			{
				return menmForbiddenBrowserCSS3Capabilities;
			}
			set
			{
				menmForbiddenBrowserCSS3Capabilities = value;
			}
		}

		public HTML5BrowserCapabilities ForbiddenBrowserHTML5Capabilities
		{
			get
			{
				return menmForbiddenBrowserHTML5Capabilities;
			}
			set
			{
				menmForbiddenBrowserHTML5Capabilities = value;
			}
		}

		public MISCBrowserCapabilities ForbiddenBrowserMISCCapabilities
		{
			get
			{
				return menmForbiddenBrowserMISCCapabilities;
			}
			set
			{
				menmForbiddenBrowserMISCCapabilities = value;
			}
		}

		public CSS3BrowserCapabilities RequiredBrowserCSS3Capabilities
		{
			get
			{
				return menmRequiredBrowserCSS3Capabilities;
			}
			set
			{
				menmRequiredBrowserCSS3Capabilities = value;
			}
		}

		public HTML5BrowserCapabilities RequiredBrowserHTML5Capabilities
		{
			get
			{
				return menmRequiredBrowserHTML5Capabilities;
			}
			set
			{
				menmRequiredBrowserHTML5Capabilities = value;
			}
		}

		public MISCBrowserCapabilities RequiredBrowserMISCCapabilities
		{
			get
			{
				return menmRequiredBrowserMISCCapabilities;
			}
			set
			{
				menmRequiredBrowserMISCCapabilities = value;
			}
		}

		public BrowserCapabilities(int intRequiredBrowserCSS3Capabilities, int intRequiredBrowserHTML5Capabilities, int intRequiredBrowserMISCCapabilities, int intForbiddenBrowserCSS3Capabilities, int intForbiddenBrowserHTML5Capabilities, int intForbiddenBrowserMISCCapabilities)
			: this((CSS3BrowserCapabilities)intRequiredBrowserCSS3Capabilities, (HTML5BrowserCapabilities)intRequiredBrowserHTML5Capabilities, (MISCBrowserCapabilities)intRequiredBrowserMISCCapabilities, (CSS3BrowserCapabilities)intForbiddenBrowserCSS3Capabilities, (HTML5BrowserCapabilities)intForbiddenBrowserHTML5Capabilities, (MISCBrowserCapabilities)intForbiddenBrowserMISCCapabilities)
		{
		}

		public BrowserCapabilities(CSS3BrowserCapabilities enmRequiredBrowserCSS3Capabilities, HTML5BrowserCapabilities enmRequiredBrowserHTML5Capabilities, MISCBrowserCapabilities enmRequiredBrowserMISCCapabilities, CSS3BrowserCapabilities enmForbiddenBrowserCSS3Capabilities, HTML5BrowserCapabilities enmForbiddenBrowserHTML5Capabilities, MISCBrowserCapabilities enmForbiddenBrowserMISCCapabilities)
		{
			menmRequiredBrowserCSS3Capabilities = enmRequiredBrowserCSS3Capabilities;
			menmRequiredBrowserHTML5Capabilities = enmRequiredBrowserHTML5Capabilities;
			menmRequiredBrowserMISCCapabilities = enmRequiredBrowserMISCCapabilities;
			menmForbiddenBrowserCSS3Capabilities = enmForbiddenBrowserCSS3Capabilities;
			menmForbiddenBrowserHTML5Capabilities = enmForbiddenBrowserHTML5Capabilities;
			menmForbiddenBrowserMISCCapabilities = enmForbiddenBrowserMISCCapabilities;
		}

		public BrowserCapabilities()
		{
		}

		public override bool Equals(object objObject)
		{
			if (!(objObject is BrowserCapabilities browserCapabilities))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (ForbiddenBrowserCSS3Capabilities != browserCapabilities.ForbiddenBrowserCSS3Capabilities)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (ForbiddenBrowserHTML5Capabilities != browserCapabilities.ForbiddenBrowserHTML5Capabilities)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (ForbiddenBrowserMISCCapabilities == browserCapabilities.ForbiddenBrowserMISCCapabilities)
			{
				if (RequiredBrowserCSS3Capabilities != browserCapabilities.RequiredBrowserCSS3Capabilities)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (RequiredBrowserHTML5Capabilities == browserCapabilities.RequiredBrowserHTML5Capabilities)
				{
					return RequiredBrowserMISCCapabilities == browserCapabilities.RequiredBrowserMISCCapabilities;
				}
			}
			return false;
		}
	}
}
