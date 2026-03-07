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
	internal class HtmlCollector : TextFileCollector
	{
		internal override bool IsCompileEnabled => true;

		protected override string ContentType => "text/html";

		public HtmlCollector(GlobalScope objGlobalScope, string strCollectorName)
			: base(objGlobalScope, strCollectorName)
		{
		}

		internal override void WriteContent(StreamWriter objStreamWriter, BB objController)
		{
			PresentationDrawingEngine currentPresentationDrawingEngine = ConfigHelper.CurrentPresentationDrawingEngine;
			SkinCollectorResource skinCollectorResource = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, SkinCollectorResource> current = enumerator.Current;
					if (!(current.Value.Resource is TextFileResource textFileResource))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (textFileResource.PresentationDrawingEngine == PresentationDrawingEngine.Agnostic)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (textFileResource.PresentationDrawingEngine != currentPresentationDrawingEngine)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if ((textFileResource.PresentationEngine & objController.PresentationEngine) == objController.PresentationEngine)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (textFileResource.PresentationEngine != PresentationEngine.Agnostic)
					{
						continue;
					}
					if (!ValidateBrowserCapabilities(objController.CSS3BrowserCapabilities, objController.HTML5BrowserCapabilities, objController.MISCBrowserCapabilities, textFileResource.BrowserCapabilities.RequiredBrowserCSS3Capabilities, textFileResource.BrowserCapabilities.RequiredBrowserHTML5Capabilities, textFileResource.BrowserCapabilities.RequiredBrowserMISCCapabilities, blnRequiredCapabilities: true))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (ValidateBrowserCapabilities(objController.CSS3BrowserCapabilities, objController.HTML5BrowserCapabilities, objController.MISCBrowserCapabilities, textFileResource.BrowserCapabilities.ForbiddenBrowserCSS3Capabilities, textFileResource.BrowserCapabilities.ForbiddenBrowserHTML5Capabilities, textFileResource.BrowserCapabilities.ForbiddenBrowserMISCCapabilities, blnRequiredCapabilities: false))
					{
						if (ValidateUserAgentRegEx(textFileResource.UserAgentRegEx))
						{
							skinCollectorResource = current.Value;
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
			}
			if (skinCollectorResource == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			WriteResourceContent(skinCollectorResource.Scope, (TextFileResource)skinCollectorResource.Resource, objStreamWriter, objController);
			objStreamWriter.Flush();
		}
	}
}
