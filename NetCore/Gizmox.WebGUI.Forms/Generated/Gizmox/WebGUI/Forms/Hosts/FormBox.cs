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

namespace Gizmox.WebGUI.Forms.Hosts
{
	/// 
	/// FormBox
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(FormBox), "FormBox_45.png")]
	[Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxData("<{0}:FormBox runat=server></{0}:FormBox>")]
	public class FormBox : WebControl
	{
		/// 
		///
		/// </summary>
		public enum ApplicationUITypes : byte
		{
			/// 
			///
			/// </summary>
			DHTML
		}

		/// 
		///
		/// </summary>
		private string mstrInstance = "";

		private IRouter mobjRouter = null;

		private bool mblnStateless = false;

		/// 
		/// Holds the setting by which this control either opens a form as a DHTML
		/// </summary>
		private ApplicationUITypes menmApplicationUiType = ApplicationUITypes.DHTML;

		/// 
		/// Gets or sets a value indicating whether this Control show open the
		/// internal form as a DHTML Form (wgx).
		/// </summary>
		/// true</c> if [Run as DHTML]; otherwise, false</c>.</value>
		[Category("Behavior")]
		[DefaultValue(ApplicationUITypes.DHTML)]
		public virtual ApplicationUITypes ApplicationUIType
		{
			get
			{
				return menmApplicationUiType;
			}
			set
			{
				menmApplicationUiType = value;
			}
		}

		/// 
		/// The mapped Visual WebGUI form to be displayed
		/// </summary>
		[Category("Data")]
		[DefaultValue("")]
		public string Form
		{
			get
			{
				if (ViewState["Form"] != null)
				{
					return Convert.ToString(ViewState["Form"]);
				}
				return string.Empty;
			}
			set
			{
				ViewState["Form"] = value;
			}
		}

		/// 
		/// The form instance which is used to create instances of the same mapped form
		/// </summary>
		[Category("Data")]
		[DefaultValue("")]
		public string Instance
		{
			get
			{
				return mstrInstance;
			}
			set
			{
				if (mstrInstance != null)
				{
					mstrInstance = value;
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Hosts.FormBox" /> is stateless.
		/// </summary>
		/// true</c> if stateless; otherwise, false</c>.</value>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool Stateless
		{
			get
			{
				return mblnStateless;
			}
			set
			{
				mblnStateless = value;
			}
		}

		/// 
		/// The form arguments which can be used with in the Visual WebGui application
		/// </summary>
		/// 
		/// Provides a mechanism to send parameters and object references to the Visual WebGui application.
		/// </remarks>
		public NameValueCollection Arguments
		{
			get
			{
				if (Router != null)
				{
					return Router.GetArguments(Form, Instance);
				}
				return null;
			}
		}

		/// 
		/// The form results which can be used to expose parameters and references from the Visual WebGui application
		/// </summary>
		/// 
		/// Provides a mechanism to return parameters and object references from the Visual WebGui application.
		/// </remarks>
		public NameValueCollection Results
		{
			get
			{
				if (Router != null)
				{
					return Router.GetResults(Form, Instance);
				}
				return null;
			}
		}

		private IRouter Router
		{
			get
			{
				if (mobjRouter == null)
				{
					mobjRouter = ClientUtils.GetRouter();
				}
				return mobjRouter;
			}
		}

		private string TypeExtension
		{
			get
			{
				string result = string.Empty;
				if (menmApplicationUiType == ApplicationUITypes.DHTML)
				{
					result = Config.GetInstance().DynamicExtension;
				}
				return result;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.FormBox" /> class.
		/// </summary>
		public FormBox()
			: base("IFRAME")
		{
		}

		/// 
		/// Adds HTML attributes and styles that need to be rendered to the specified <see cref="T:System.Web.UI.HtmlTextWriterTag" />. This method is used primarily by control developers.
		/// </summary>
		/// <param name="objWriter">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
		protected override void AddAttributesToRender(HtmlTextWriter objWriter)
		{
			if (!string.IsNullOrEmpty(Form))
			{
				string text = GetArguments();
				if (!text.ToLower().Contains("&vwginstance="))
				{
					text = $"{text}&vwginstance={Instance}";
				}
				if (!text.ToLower().Contains("&vwgstateless="))
				{
					text = string.Format("{0}&vwgstateless={1}", text, mblnStateless ? "1" : "0");
				}
				if (text.StartsWith("&"))
				{
					text = text.Substring(1);
				}
				objWriter.AddAttribute("src", ResolveClientUrl($"~/{Form}{TypeExtension}?{text}"));
			}
			objWriter.AddAttribute("allowtransparency", "yes");
			objWriter.AddAttribute("frameborder", "no");
			base.AddAttributesToRender(objWriter);
		}

		/// 
		/// Gets the arguments.
		/// </summary>
		/// </returns>
		private string GetArguments()
		{
			string text = string.Empty;
			NameValueCollection arguments = Arguments;
			if (arguments != null)
			{
				foreach (string argument in Arguments)
				{
					text = $"{text}&{argument}={Arguments[argument]}";
				}
			}
			return text;
		}
	}
}
