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
	/// A html control
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(HtmlBox), "HtmlBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Common Controls")]
	[Skin(typeof(HtmlBoxSkin))]
	public class HtmlBox : FrameControl
	{
		/// 
		/// Html gateway handler
		/// </summary>
		[Serializable]
		public class HtmlGateway : GatewayWriter
		{
			private HtmlBox mobjHtmlBox;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HtmlBox.HtmlGateway" /> class.
			/// </summary>
			/// <param name="objHtmlBox">The obj HTML box.</param>
			public HtmlGateway(HtmlBox objHtmlBox)
			{
				mobjHtmlBox = objHtmlBox;
			}

			/// 
			/// Processes the request.
			/// </summary>
			protected override void ProcessRequest()
			{
				if (mobjHtmlBox != null)
				{
					if (mobjHtmlBox.Type == HtmlBoxType.HTML)
					{
						Write(mobjHtmlBox.Html);
						return;
					}
					WriteFile(mobjHtmlBox.Path);
					base.ContentType = mobjHtmlBox.ContentType;
				}
			}
		}

		/// 
		/// Provides a property reference to GatewayReference property.
		/// </summary>
		private static SerializableProperty GatewayReferenceProperty = SerializableProperty.Register("GatewayReference", typeof(GatewayReference), typeof(HtmlBox));

		/// 
		/// Provides a property reference to Expires property.
		/// </summary>
		private static SerializableProperty ExpiresProperty = SerializableProperty.Register("Expires", typeof(int), typeof(HtmlBox));

		/// 
		/// Provides a property reference to ContentType property.
		/// </summary>
		private static SerializableProperty ContentTypeProperty = SerializableProperty.Register("ContentType", typeof(string), typeof(HtmlBox));

		/// 
		/// Provides a property reference to Type property.
		/// </summary>
		private static SerializableProperty TypeProperty = SerializableProperty.Register("Type", typeof(HtmlBoxType), typeof(HtmlBox));

		/// 
		/// Provides a property reference to ResourceHandle property.
		/// </summary>
		private static SerializableProperty ResourceHandleProperty = SerializableProperty.Register("ResourceHandle", typeof(ResourceHandle), typeof(HtmlBox));

		/// 
		/// Provides a property reference to Path property.
		/// </summary>
		private static SerializableProperty PathProperty = SerializableProperty.Register("Path", typeof(string), typeof(HtmlBox));

		/// 
		/// Provides a property reference to Url property.
		/// </summary>
		private static SerializableProperty UrlProperty = SerializableProperty.Register("Url", typeof(string), typeof(HtmlBox));

		/// 
		/// Provides a property reference to Html property.
		/// </summary>
		private static SerializableProperty HtmlProperty = SerializableProperty.Register("Html", typeof(string), typeof(HtmlBox));

		/// 
		/// Provides a property reference to IsWindowless property.
		/// </summary>
		private static SerializableProperty IsWindowlessProperty = SerializableProperty.Register("IsWindowless", typeof(bool), typeof(HtmlBox), new SerializablePropertyMetadata(false));

		/// 
		/// Gets the source.
		/// </summary>
		/// The source.</value>
		protected override string Source
		{
			get
			{
				if (IsWindowless)
				{
					return Html;
				}
				if (Type == HtmlBoxType.RESOURCE)
				{
					ResourceHandle resource = Resource;
					if (resource != null)
					{
						return resource.ToString();
					}
					return string.Empty;
				}
				if (Type == HtmlBoxType.UNC || Type == HtmlBoxType.HTML)
				{
					GatewayReference gatewayReference = GatewayReference;
					if (gatewayReference == null)
					{
						gatewayReference = (GatewayReference = new GatewayReference(this, "Html"));
					}
					return gatewayReference.ToString();
				}
				return Url;
			}
		}

		/// 
		/// Gets or sets the HTML code of the control.
		/// </summary>
		/// </value>
		public virtual string Html
		{
			get
			{
				return (Type == HtmlBoxType.HTML) ? GetValue(HtmlProperty, "No content.</HTML>") : string.Empty;
			}
			set
			{
				string html = Html;
				if (html != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(HtmlProperty);
						return;
					}
					Type = HtmlBoxType.HTML;
					SetValue(HtmlProperty, value);
					RemoveValue(UrlProperty);
					Update();
					FireObservableItemPropertyChanged("Content");
				}
			}
		}

		/// 
		/// Gets or sets the value indicating if html should be rendered without an iframe.
		/// </summary>
		/// 
		/// 	true</c> if this instance is windowless; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool IsWindowless
		{
			get
			{
				return GetValue(IsWindowlessProperty);
			}
			set
			{
				if (value && Type != HtmlBoxType.HTML)
				{
					throw new ArgumentOutOfRangeException("HtmlBox must be in HTML mode to use windowless mode.");
				}
				if (SetValue(IsWindowlessProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Indicates if the framecontrol should render source as inline html of as a url for
		/// a frame.
		/// </summary>
		/// </value>
		protected override bool IsInline => IsWindowless;

		/// 
		/// Gets or sets the URL.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public virtual string Url
		{
			get
			{
				return (Type == HtmlBoxType.URL) ? GetValue(UrlProperty, string.Empty) : string.Empty;
			}
			set
			{
				string text = Url;
				HtmlBoxType type = Type;
				if (type != HtmlBoxType.URL || text != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(UrlProperty);
					}
					else
					{
						Type = HtmlBoxType.URL;
						SetValue(UrlProperty, value);
						text = value;
						RemoveValue(HtmlProperty);
					}
					FireObservableItemPropertyChanged("Content");
					InvokeMethodWithId("FrameControl_SetUrl", text);
				}
			}
		}

		/// 
		/// Gets or sets the path.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public virtual string Path
		{
			get
			{
				return (Type == HtmlBoxType.UNC) ? GetValue(PathProperty, string.Empty) : string.Empty;
			}
			set
			{
				string path = Path;
				if (path != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(UrlProperty);
					}
					else
					{
						Type = HtmlBoxType.UNC;
						SetValue(PathProperty, value);
						SetValue(UrlProperty, value);
						RemoveValue(HtmlProperty);
					}
					FireObservableItemPropertyChanged("Content");
				}
			}
		}

		/// 
		/// Gets or sets the resource.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		public virtual ResourceHandle Resource
		{
			get
			{
				return (Type == HtmlBoxType.RESOURCE) ? GetValue(ResourceHandleProperty, null) : null;
			}
			set
			{
				if (Resource != value)
				{
					if (value == null)
					{
						RemoveValue(ResourceHandleProperty);
					}
					else
					{
						Type = HtmlBoxType.RESOURCE;
						SetValue(ResourceHandleProperty, value);
						RemoveValue(HtmlProperty);
					}
					FireObservableItemPropertyChanged("Content");
				}
			}
		}

		/// 
		/// Gets the html box type.
		/// </summary>
		/// </value>
		public HtmlBoxType Type
		{
			get
			{
				return GetValue(TypeProperty, HtmlBoxType.HTML);
			}
			internal set
			{
				if (Type != value)
				{
					if (value == HtmlBoxType.HTML)
					{
						RemoveValue(TypeProperty);
					}
					else
					{
						SetValue(TypeProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the content type.
		/// </summary>
		/// </value>
		public string ContentType
		{
			get
			{
				return GetValue(ContentTypeProperty, "text/html");
			}
			set
			{
				string contentType = ContentType;
				if (contentType != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(ContentTypeProperty);
					}
					else
					{
						SetValue(ContentTypeProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the expire time in secodns.
		/// </summary>
		/// </value>
		[DefaultValue(-1)]
		public int Expires
		{
			get
			{
				return GetValue(ExpiresProperty, -1);
			}
			set
			{
				if (Expires != value)
				{
					if (value == -1)
					{
						RemoveValue(ExpiresProperty);
					}
					else
					{
						SetValue(ExpiresProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the gateway reference.
		/// </summary>
		/// The gateway reference.</value>
		private GatewayReference GatewayReference
		{
			get
			{
				return GetValue(GatewayReferenceProperty, null);
			}
			set
			{
				if (GatewayReference != value)
				{
					if (value == null)
					{
						RemoveValue(GatewayReferenceProperty);
					}
					else
					{
						SetValue(GatewayReferenceProperty, value);
					}
				}
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.HtmlBox" /> instance.
		/// </summary>
		public HtmlBox()
		{
			base.Size = new Size(200, 200);
		}

		/// 
		/// Prints this instance.
		/// </summary>
		public void Print()
		{
			InvokeMethod("FrameControl_Print", ID.ToString());
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			FireObservableItemPropertyChanged("Content");
		}

		/// 
		/// Resets the resource.
		/// </summary>
		private void ResetResource()
		{
			Resource = null;
		}

		/// 
		/// Resets the HTML.
		/// </summary>
		private void ResetHtml()
		{
			Html = ((Type == HtmlBoxType.HTML) ? "No content.</HTML>" : string.Empty);
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHostContext">The gateway request host context.</param>
		/// <param name="strAction">The gateway request action.</param>
		/// 
		/// By default this method returns a instance of a class which implements the IGatewayHandler and
		/// throws a non implemented HttpException.
		/// </returns>
		/// 
		/// This method is called from the implementation of IGatewayComponent which replaces the
		/// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
		/// RegisteredComponent class which is the base class of most of the Visual WebGui
		/// components.
		/// Referencing a RegisterComponent that overrides this method is done the same way that
		/// a control implementing IGatewayControl, which is by using the GatewayReference class.
		/// </remarks>
		protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
		{
			if (strAction == "Html")
			{
				return new HtmlGateway(this);
			}
			return null;
		}
	}
}
