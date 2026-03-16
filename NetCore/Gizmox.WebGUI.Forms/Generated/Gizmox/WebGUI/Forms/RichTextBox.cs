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
	/// Represents a Gizmox.WebGUI.Forms rich text box control.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(RichTextBox), "RichTextBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[SRDescription("DescriptionRichTextBox")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("RX")]
	[Skin(typeof(RichTextBoxSkin))]
	public class RichTextBox : TextBoxBase
	{
		private const string RTF_IMAGE = "rtfImage";

		private const string IMAGE_KEY = "imageKey";

		private const string IMAGE_EXTENTION = "imageExtention";

		/// 
		/// Provides a property reference to Html property.
		/// </summary>
		private static SerializableProperty HtmlProperty = SerializableProperty.Register("Html", typeof(string), typeof(RichTextBox));

		private Dictionary<string, byte[]> mobjImagesIndexByImageKey = new Dictionary<string, byte[]>();

		/// 
		/// The HtmlChanged event registration.
		/// </summary>
		private static readonly SerializableEvent HtmlChangedEvent;

		/// 
		/// The HtmlChangeQueued event registration.
		/// </summary>
		private static readonly SerializableEvent HtmlChangeQueuedEvent;

		/// 
		/// Gets the hanlder for the HtmlChanged event.
		/// </summary>
		private EventHandler HtmlChangedHandler => (EventHandler)GetHandler(HtmlChangedEvent);

		/// 
		/// Gets the hanlder for the HtmlChangeQueued event.
		/// </summary>
		private EventHandler HtmlChangeQueuedHandler => (EventHandler)GetHandler(HtmlChangeQueuedEvent);

		/// 
		/// Gets or sets a value indicating whether text box is multi line.
		/// </summary>
		/// 
		/// 	true</c> if multi line otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		public override bool Multiline => true;

		/// 
		/// Gets or sets the HTML string.
		/// </summary>
		/// The HTML string.</value>
		[DefaultValue("")]
		[Bindable(true)]
		public string Html
		{
			get
			{
				return GetValue(HtmlProperty, string.Empty);
			}
			set
			{
				if (Html != value)
				{
					if (value == null || value == string.Empty)
					{
						RemoveValue(HtmlProperty);
					}
					else
					{
						SetValue(HtmlProperty, value);
					}
					if (HtmlChangedHandler != null)
					{
						HtmlChangedHandler(this, EventArgs.Empty);
					}
					if (HtmlChangeQueuedHandler != null)
					{
						HtmlChangeQueuedHandler(this, EventArgs.Empty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this control.")]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlFontDescr")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		/// Gets or sets the font of the current text selection or insertion point.</summary>
		/// A <see cref="T:System.Drawing.Font"></see> that represents the font to apply to the current text selection or to text entered after the insertion point.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this control.")]
		[SRDescription("RichTextBoxSelFont")]
		public Font SelectionFont
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				InvokeMethodWithId("RichTextBox_Execute", "FontName", "", value.FontFamily.Name);
			}
		}

		/// 
		/// Gets or sets the fore color.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this control.")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue("")]
		public override string Text
		{
			get
			{
				return GetTextFromHtml(Html);
			}
			set
			{
				Html = GetHtmlFromText(value);
			}
		}

		/// 
		/// Occurs when [HTML changed].
		/// </summary>
		public event EventHandler HtmlChanged
		{
			add
			{
				AddCriticalHandler(HtmlChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(HtmlChangedEvent, value);
			}
		}

		[Obsolete("HtmlChange event is deprecated. Please use HtmlChanged event instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event EventHandler HtmlChange
		{
			add
			{
				AddCriticalHandler(HtmlChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(HtmlChangedEvent, value);
			}
		}

		public event ClientEventHandler ClientHtmlChange
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Occurs when [HTML change queued].
		/// </summary>
		public event EventHandler HtmlChangeQueued
		{
			add
			{
				AddHandler(HtmlChangeQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(HtmlChangeQueuedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.RichTextBox.Font"></see> property value changes. </summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		public new event EventHandler FontChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RichTextBox"></see> class.
		/// </summary>
		public RichTextBox()
		{
			BorderStyle = BorderStyle.Fixed3D;
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="strPath">The STR path.</param>
		public void LoadFile(string strPath)
		{
			LoadFile(strPath, RichTextBoxStreamType.RichText);
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="objData">The obj data.</param>
		/// <param name="objFileType">Type of the obj file.</param>
		public void LoadFile(Stream objData, RichTextBoxStreamType objFileType)
		{
			if (!ClientUtils.IsEnumValid(objFileType, (int)objFileType, 0, 4))
			{
				throw new InvalidEnumArgumentException("objFileType", (int)objFileType, typeof(RichTextBoxStreamType));
			}
			if (objFileType == RichTextBoxStreamType.RichText)
			{
				IFormatConverter provider = CommonUtils.GetProvider<IFormatConverter>(GetDefaultFormatConverterString(), blnIsCache: true);
				if (provider != null)
				{
					HtmlConvertionSettings htmlConvertionSettings = new HtmlConvertionSettings();
					htmlConvertionSettings.RenderContent = true;
					htmlConvertionSettings.RenderDocument = true;
					htmlConvertionSettings.ImagesKeyPattern = "{0}";
					string text = Guid.NewGuid().ToString("N");
					string text2 = Guid.NewGuid().ToString("N");
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection.Add("imageKey", text);
					nameValueCollection.Add("imageExtention", text2);
					htmlConvertionSettings.ImagesUrlPattern = new GatewayResourceHandle(this, "rtfImage", nameValueCollection).ToString();
					htmlConvertionSettings.ImagesUrlPattern = htmlConvertionSettings.ImagesUrlPattern.Replace(text, htmlConvertionSettings.ImagesKeyPattern).Replace(text2, "{1}");
					using Stream stream = provider.Convert(FormatConvertionType.Rtf, FormatConvertionType.Html, objData, htmlConvertionSettings, mobjImagesIndexByImageKey);
					StreamReader streamReader = new StreamReader(stream);
					Html = streamReader.ReadToEnd();
					return;
				}
				return;
			}
			throw new NotImplementedException("Load File supports only type: 'RichTextBoxStreamType.RichText'");
		}

		/// 
		/// Gets the default Format converter's type string
		/// </summary>
		/// </returns>
		private string GetDefaultFormatConverterString()
		{
			string empty = string.Empty;
			return "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=null";
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHostContext">The gateway request HOST context.</param>
		/// <param name="strAction">The gateway request action.</param>
		/// 
		/// By default this method returns a instance of a class which implements the IGatewayHandler and
		/// throws a non implemented HttpException.
		/// </returns>
		protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
		{
			if (strAction == "rtfImage")
			{
				string text = objHostContext.Request.QueryString["imageKey"];
				if (!string.IsNullOrEmpty(text) && mobjImagesIndexByImageKey.ContainsKey(text))
				{
					string text2 = objHostContext.Request.QueryString["imageExtention"];
					if (!string.IsNullOrEmpty(text2))
					{
						byte[] array = mobjImagesIndexByImageKey[text];
						objHostContext.Response.ContentType = CommonUtils.GetMimeType(text2);
						objHostContext.Response.OutputStream.Write(array, 0, array.Length);
						objHostContext.Response.OutputStream.Flush();
					}
				}
				return null;
			}
			return base.ProcessGatewayRequest(objHostContext, strAction);
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="strPath">The STR path.</param>
		/// <param name="objFileType">Type of the obj file.</param>
		public void LoadFile(string strPath, RichTextBoxStreamType objFileType)
		{
			if (!ClientUtils.IsEnumValid(objFileType, (int)objFileType, 0, 4))
			{
				throw new InvalidEnumArgumentException("objFileType", (int)objFileType, typeof(RichTextBoxStreamType));
			}
			Stream stream = new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				LoadFile(stream, objFileType);
			}
			finally
			{
				stream.Close();
			}
		}

		/// 
		/// Sets the content of the clipboard.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		protected override void SetClipboardContent(string strValue)
		{
			Html = strValue;
		}

		/// 
		/// Gets the content of the clipboard.
		/// </summary>
		/// </returns>
		protected override string GetClipboardContent()
		{
			return Html;
		}

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">Force render</param>
		protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			string html = Html;
			if (blnForceRender || !string.IsNullOrEmpty(html))
			{
				objWriter.WriteAttributeString("SR", html);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="strArg"></param>
		protected string DoImageInsert(string strArg)
		{
			return Html;
		}

		/// 
		/// Prints the current RichTextBox content
		/// </summary>
		public void Print()
		{
			InvokeMethodWithId("RichTextBox_Execute", "Print");
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "ValueChange")
			{
				string text = objEvent["TX"];
				Html = ((text == null) ? "" : text);
				if (HtmlChangedHandler != null)
				{
					HtmlChangedHandler(this, EventArgs.Empty);
				}
				if (HtmlChangeQueuedHandler != null)
				{
					HtmlChangeQueuedHandler(this, EventArgs.Empty);
				}
			}
			else
			{
				base.FireEvent(objEvent);
			}
		}

		/// 
		/// Gets the text from HTML.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// </returns>
		private string GetTextFromHtml(string strValue)
		{
			if (!string.IsNullOrEmpty(strValue))
			{
				string text = global::System.Net.WebUtility.HtmlDecode(strValue);
				string[] array = new string[15]
				{
					"&bs;", "<br />", "", "", "<hr />", "</p>", "</td>", "</tr>", "</td>", "<([^<])*>",
					" ", "<", ">", "&", "&#160;"
				};
				string[] array2 = new string[15]
				{
					"\b", "\n", "\n", "\n", "\n", "\n", "\t", "\n", " ", "",
					" ", "<", ">", "&", " "
				};
				for (int i = 0; i < array.Length; i++)
				{
					Regex regex = new Regex(array[i], RegexOptions.IgnoreCase | RegexOptions.Compiled);
					text = regex.Replace(text, array2[i]);
				}
				return text;
			}
			return string.Empty;
		}

		/// 
		/// Gets the HTML from text.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// </returns>
		private string GetHtmlFromText(string strValue)
		{
			if (!string.IsNullOrEmpty(strValue))
			{
				string text = global::System.Net.WebUtility.HtmlEncode(strValue);
				text = text.Replace("\r\n", "<br/>");
				text = text.Replace("\r", "<br/>");
				text = text.Replace("\n", "<br/>");
				text = text.Replace("\b", "&bs;");
				return text.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
			}
			return string.Empty;
		}

		static RichTextBox()
		{
			HtmlChangedEvent = SerializableEvent.Register("HtmlChanged", typeof(EventHandler), typeof(RichTextBox));
			HtmlChangeQueuedEvent = SerializableEvent.Register("HtmlChangeQueued", typeof(EventHandler), typeof(RichTextBox));
		}
	}
}
