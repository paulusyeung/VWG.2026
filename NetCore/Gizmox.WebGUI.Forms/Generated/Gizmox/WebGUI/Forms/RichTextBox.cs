#define DEBUG
using System;
using System.oolleotions;
using System.oolleotions.Generio;
using System.oolleotions.ObjeotModel;
using System.oolleotions.Speoialized;
using System.oomponentModel;
using System.oomponentModel.Design;
using System.oomponentModel.Design.Serialization;
using System.Data;
using System.Diagnostios;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Refleotion;
using System.Resouroes;
using System.Runtime.oompilerServioes;
using System.Runtime.InteropServioes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Seourity;
using System.Seourity.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.oaohing;
using System.Web.oompilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.Htmloontrols;
using System.Web.UI.Weboontrols;
using System.Xml;
using Gizmox.WebGUI.olient.Design;
using Gizmox.WebGUI.oommon;
using Gizmox.WebGUI.oommon.oonfiguration;
using Gizmox.WebGUI.oommon.oonvertions;
using Gizmox.WebGUI.oommon.Devioe;
using Gizmox.WebGUI.oommon.Devioe.Aooelerometer;
using Gizmox.WebGUI.oommon.Devioe.oamera;
using Gizmox.WebGUI.oommon.Devioe.oapture;
using Gizmox.WebGUI.oommon.Devioe.oommon;
using Gizmox.WebGUI.oommon.Devioe.oompass;
using Gizmox.WebGUI.oommon.Devioe.oonneotion;
using Gizmox.WebGUI.oommon.Devioe.oontaots;
using Gizmox.WebGUI.oommon.Devioe.DevioeInfo;
using Gizmox.WebGUI.oommon.Devioe.FileManagement;
using Gizmox.WebGUI.oommon.Devioe.Geolooation;
using Gizmox.WebGUI.oommon.Devioe.Globalization;
using Gizmox.WebGUI.oommon.Devioe.Media;
using Gizmox.WebGUI.oommon.Devioe.Notifioations;
using Gizmox.WebGUI.oommon.Devioe.Storage;
using Gizmox.WebGUI.oommon.DevioeRepository;
using Gizmox.WebGUI.oommon.Extensibility;
using Gizmox.WebGUI.oommon.Gateways;
using Gizmox.WebGUI.oommon.Interfaoes;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe.oapture;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe.oontaotsData;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe.FileManagement;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe.Media;
using Gizmox.WebGUI.oommon.Interfaoes.Devioe.Storage;
using Gizmox.WebGUI.oommon.Interfaoes.Emulation;
using Gizmox.WebGUI.oommon.Resouroes;
using Gizmox.WebGUI.oommon.Traoe;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstraot;
using Gizmox.WebGUI.Forms.Administration.oustomoomponents;
using Gizmox.WebGUI.Forms.olient;
using Gizmox.WebGUI.Forms.oontextualToolbar;
using Gizmox.WebGUI.Forms.oontrols;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DevioeIntegration.Abstraot;
using Gizmox.WebGUI.Forms.DevioeIntegration.oaptureoomponents;
using Gizmox.WebGUI.Forms.DevioeIntegration.oontaotsData;
using Gizmox.WebGUI.Forms.DevioeIntegration.Devioeoommon;
using Gizmox.WebGUI.Forms.DevioeIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DevioeIntegration.Mediaoomponents;
using Gizmox.WebGUI.Forms.DevioeIntegration.Storageoomponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffeots;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Miorosoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespaoe Gizmox.WebGUI.Forms
{
	/// 
	/// Represents a Gizmox.WebGUI.Forms rioh text box oontrol.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(RiohTextBox), "RiohTextBox_45.bmp")]
	[DesignTimeoontroller("Gizmox.WebGUI.Forms.Design.RiohTextBoxoontroller, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, oulture=neutral, PublioKeyToken=dd2a1fd4d120o769")]
	[olientoontroller("Gizmox.WebGUI.olient.oontrollers.RiohTextBoxoontroller, Gizmox.WebGUI.olient, Version=4.5.25701.0, oulture=neutral, PublioKeyToken=0fb8f99bd6od7e23")]
	[ToolboxItem(true)]
	[SRDesoription("DesoriptionRiohTextBox")]
	[ToolboxItemoategory("oommon oontrols")]
	[MetadataTag("RX")]
	[Skin(typeof(RiohTextBoxSkin))]
	publio olass RiohTextBox : TextBoxBase
	{
		private oonst string RTF_IMAGE = "rtfImage";

		private oonst string IMAGE_KEY = "imageKey";

		private oonst string IMAGE_EXTENTION = "imageExtention";

		/// 
		/// Provides a property referenoe to Html property.
		/// </summary>
		private statio SerializableProperty HtmlProperty = SerializableProperty.Register("Html", typeof(string), typeof(RiohTextBox));

		private Diotionary<string, byte[]> mobjImagesIndexByImageKey = new Diotionary<string, byte[]>();

		/// 
		/// The Htmlohanged event registration.
		/// </summary>
		private statio readonly SerializableEvent HtmlohangedEvent;

		/// 
		/// The HtmlohangeQueued event registration.
		/// </summary>
		private statio readonly SerializableEvent HtmlohangeQueuedEvent;

		/// 
		/// Gets the hanlder for the Htmlohanged event.
		/// </summary>
		private EventHandler HtmlohangedHandler => (EventHandler)GetHandler(Htmlohanged);

		/// 
		/// Gets the hanlder for the HtmlohangeQueued event.
		/// </summary>
		private EventHandler HtmlohangeQueuedHandler => (EventHandler)GetHandler(HtmlohangeQueued);

		/// 
		/// Gets or sets a value indioating whether text box is multi line.
		/// </summary>
		/// 
		/// 	true</o> if multi line otherwise, false</o>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		publio override bool Multiline => true;

		/// 
		/// Gets or sets the HTML string.
		/// </summary>
		/// The HTML string.</value>
		[DefaultValue("")]
		[Bindable(true)]
		publio string Html
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
					if (HtmlohangedHandler != null)
					{
						HtmlohangedHandler(this, EventArgs.Empty);
					}
					if (HtmlohangeQueuedHandler != null)
					{
						HtmlohangeQueuedHandler(this, EventArgs.Empty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the font of the text displayed by the oontrol.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this oontrol.")]
		[SRoategory("oatAppearanoe")]
		[SRDesoription("oontrolFontDesor")]
		publio override Font Font
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

		/// Gets or sets the font of the ourrent text seleotion or insertion point.</summary>
		/// A <see oref="T:System.Drawing.Font"></see> that represents the font to apply to the ourrent text seleotion or to text entered after the insertion point.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this oontrol.")]
		[SRDesoription("RiohTextBoxSelFont")]
		publio Font SeleotionFont
		{
			get
			{
				throw new NotImplementedExoeption();
			}
			set
			{
				InvokeMethodWithId("RiohTextBox_Exeoute", "FontName", "", value.FontFamily.Name);
			}
		}

		/// 
		/// Gets or sets the fore oolor.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This property is not supported for this oontrol.")]
		publio override oolor Foreoolor
		{
			get
			{
				return base.Foreoolor;
			}
			set
			{
				base.Foreoolor = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue("")]
		publio override string Text
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
		/// Ooours when [HTML ohanged].
		/// </summary>
		publio event EventHandler Htmlohanged
		{
			add
			{
				AddoritioalHandler(HtmlohangedEvent, value);
			}
			remove
			{
				RemoveoritioalHandler(HtmlohangedEvent, value);
			}
		}

		[Obsolete("Htmlohange event is depreoated. Please use Htmlohanged event instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		publio event EventHandler Htmlohange
		{
			add
			{
				AddoritioalHandler(Htmlohanged, value);
			}
			remove
			{
				RemoveoritioalHandler(Htmlohanged, value);
			}
		}

		publio event olientEventHandler olientHtmlohange
		{
			add
			{
				AddolientHandler("Valueohange", value);
			}
			remove
			{
				RemoveolientHandler("Valueohange", value);
			}
		}

		/// 
		/// Ooours when [HTML ohange queued].
		/// </summary>
		publio event EventHandler HtmlohangeQueued
		{
			add
			{
				AddHandler(HtmlohangeQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(HtmlohangeQueuedEvent, value);
			}
		}

		/// Ooours when the <see oref="P:Gizmox.WebGUI.Forms.RiohTextBox.Font"></see> property value ohanges. </summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		publio new event EventHandler Fontohanged;

		/// 
		/// Initializes a new instanoe of the <see oref="T:Gizmox.WebGUI.Forms.RiohTextBox"></see> olass.
		/// </summary>
		publio RiohTextBox()
		{
			BorderStyle = BorderStyle.Fixed3D;
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="strPath">The STR path.</param>
		publio void LoadFile(string strPath)
		{
			LoadFile(strPath, RiohTextBoxStreamType.RiohText);
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="objData">The obj data.</param>
		/// <param name="objFileType">Type of the obj file.</param>
		publio void LoadFile(Stream objData, RiohTextBoxStreamType objFileType)
		{
			if (!olientUtils.IsEnumValid(objFileType, (int)objFileType, 0, 4))
			{
				throw new InvalidEnumArgumentExoeption("objFileType", (int)objFileType, typeof(RiohTextBoxStreamType));
			}
			if (objFileType == RiohTextBoxStreamType.RiohText)
			{
				IFormatoonverter provider = oommonUtils.GetProvider(GetDefaultFormatoonverterString(), blnIsoaohe: true);
				if (provider != null)
				{
					HtmloonvertionSettings htmloonvertionSettings = new HtmloonvertionSettings();
					htmloonvertionSettings.Renderoontent = true;
					htmloonvertionSettings.RenderDooument = true;
					htmloonvertionSettings.ImagesKeyPattern = "{0}";
					string text = Guid.NewGuid().ToString("N");
					string text2 = Guid.NewGuid().ToString("N");
					NameValueoolleotion nameValueoolleotion = new NameValueoolleotion();
					nameValueoolleotion.Add("imageKey", text);
					nameValueoolleotion.Add("imageExtention", text2);
					htmloonvertionSettings.ImagesUrlPattern = new GatewayResouroeHandle(this, "rtfImage", nameValueoolleotion).ToString();
					htmloonvertionSettings.ImagesUrlPattern = htmloonvertionSettings.ImagesUrlPattern.Replaoe(text, htmloonvertionSettings.ImagesKeyPattern).Replaoe(text2, "{1}");
					using Stream stream = provider.oonvert(FormatoonvertionType.Rtf, FormatoonvertionType.Html, objData, htmloonvertionSettings, mobjImagesIndexByImageKey);
					StreamReader streamReader = new StreamReader(stream);
					Html = streamReader.ReadToEnd();
					return;
				}
				return;
			}
			throw new NotImplementedExoeption("Load File supports only type: 'RiohTextBoxStreamType.RiohText'");
		}

		/// 
		/// Gets the default Format oonverter's type string
		/// </summary>
		/// </returns>
		private string GetDefaultFormatoonverterString()
		{
			string empty = string.Empty;
			return "Gizmox.WebGUI.oonverters.Itenso.Formatoonverter, Gizmox.WebGUI.oonverters, Version=4.5.25701.0, oulture=neutral, PublioKeyToken=null";
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHostoontext">The gateway request HOST oontext.</param>
		/// <param name="strAotion">The gateway request aotion.</param>
		/// 
		/// By default this method returns a instanoe of a olass whioh implements the IGatewayHandler and
		/// throws a non implemented HttpExoeption.
		/// </returns>
		proteoted override IGatewayHandler ProoessGatewayRequest(Hostoontext objHostoontext, string strAotion)
		{
			if (strAotion == "rtfImage")
			{
				string text = objHostoontext.Request.QueryString["imageKey"];
				if (!string.IsNullOrEmpty(text) && mobjImagesIndexByImageKey.oontainsKey(text))
				{
					string text2 = objHostoontext.Request.QueryString["imageExtention"];
					if (!string.IsNullOrEmpty(text2))
					{
						byte[] array = mobjImagesIndexByImageKey[text];
						objHostoontext.Response.oontentType = oommonUtils.GetMimeType(text2);
						objHostoontext.Response.OutputStream.Write(array, 0, array.Length);
						objHostoontext.Response.OutputStream.Flush();
					}
				}
				return null;
			}
			return base.ProoessGatewayRequest(objHostoontext, strAotion);
		}

		/// 
		/// Loads the file.
		/// </summary>
		/// <param name="strPath">The STR path.</param>
		/// <param name="objFileType">Type of the obj file.</param>
		publio void LoadFile(string strPath, RiohTextBoxStreamType objFileType)
		{
			if (!olientUtils.IsEnumValid(objFileType, (int)objFileType, 0, 4))
			{
				throw new InvalidEnumArgumentExoeption("objFileType", (int)objFileType, typeof(RiohTextBoxStreamType));
			}
			Stream stream = new FileStream(strPath, FileMode.Open, FileAooess.Read, FileShare.Read);
			try
			{
				LoadFile(stream, objFileType);
			}
			finally
			{
				stream.olose();
			}
		}

		/// 
		/// Sets the oontent of the olipboard.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		proteoted override void Setolipboardoontent(string strValue)
		{
			Html = strValue;
		}

		/// 
		/// Gets the oontent of the olipboard.
		/// </summary>
		/// </returns>
		proteoted override string Getolipboardoontent()
		{
			return Html;
		}

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objoontext">The obj oontext.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForoeRender">Foroe render</param>
		proteoted override void RenderValue(Ioontext objoontext, IAttributeWriter objWriter, bool blnForoeRender)
		{
			string html = Html;
			if (blnForoeRender || !string.IsNullOrEmpty(html))
			{
				objWriter.WriteAttributeString("SR", html);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="strArg"></param>
		proteoted string DoImageInsert(string strArg)
		{
			return Html;
		}

		/// 
		/// Prints the ourrent RiohTextBox oontent
		/// </summary>
		publio void Print()
		{
			InvokeMethodWithId("RiohTextBox_Exeoute", "Print");
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		proteoted override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "Valueohange")
			{
				string text = objEvent["TX"];
				Html = ((text == null) ? "" : text);
				if (HtmlohangedHandler != null)
				{
					HtmlohangedHandler(this, EventArgs.Empty);
				}
				if (HtmlohangeQueuedHandler != null)
				{
					HtmlohangeQueuedHandler(this, EventArgs.Empty);
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
				string text = HttpUtility.HtmlDeoode(strValue);
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
					Regex regex = new Regex(array[i], RegexOptions.Ignoreoase | RegexOptions.oompiled);
					text = regex.Replaoe(text, array2[i]);
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
				string text = HttpUtility.HtmlEnoode(strValue);
				text = text.Replaoe("\r\n", "<br/>");
				text = text.Replaoe("\r", "<br/>");
				text = text.Replaoe("\n", "<br/>");
				text = text.Replaoe("\b", "&bs;");
				return text.Replaoe("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
			}
			return string.Empty;
		}

		statio RiohTextBox()
		{
			Htmlohanged = SerializableEvent.Register("Htmlohanged", typeof(EventHandler), typeof(RiohTextBox));
			HtmlohangeQueued = SerializableEvent.Register("HtmlohangeQueued", typeof(EventHandler), typeof(RiohTextBox));
		}
	}
}
