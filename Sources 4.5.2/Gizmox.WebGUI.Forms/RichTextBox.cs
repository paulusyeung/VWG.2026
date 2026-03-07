#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using Gizmox.WebGUI.Common.Convertions;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Specialized;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    public enum RichTextBoxStreamType
    {
        /// <summary>
        /// 
        /// </summary>
        RichText,
        [Obsolete("Not implemented. Added for migration compatibility")]
        PlainText,
        [Obsolete("Not implemented. Added for migration compatibility")]
        RichNoOleObjs,
        [Obsolete("Not implemented. Added for migration compatibility")]
        TextTextOleObjs,
        [Obsolete("Not implemented. Added for migration compatibility")]
        UnicodePlainText
    }

    #region RichTextBox Class

    /// <summary>
    /// Represents a Gizmox.WebGUI.Forms rich text box control.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(RichTextBox), "RichTextBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(RichTextBox), "RichTextBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [SRDescription("DescriptionRichTextBox")]
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.RichTextBox)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.RichTextBoxSkin))]
    public class RichTextBox : TextBoxBase
    {
        #region Consts

        private const string RTF_IMAGE = "rtfImage";
        private const string IMAGE_KEY = "imageKey";
        private const string IMAGE_EXTENTION = "imageExtention";

        #endregion

        /// <summary>
        /// Provides a property reference to Html property.
        /// </summary>
        private static SerializableProperty HtmlProperty = SerializableProperty.Register("Html", typeof(string), typeof(RichTextBox));


        #region Class Members

        private Dictionary<string, byte[]> mobjImagesIndexByImageKey = new Dictionary<string, byte[]>();

        /// <summary>
        /// Gets the hanlder for the HtmlChanged event.
        /// </summary>
        private EventHandler HtmlChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(RichTextBox.HtmlChangedEvent);
            }
        }

        /// <summary>
        /// The HtmlChanged event registration.
        /// </summary>
        private static readonly SerializableEvent HtmlChangedEvent = SerializableEvent.Register("HtmlChanged", typeof(EventHandler), typeof(RichTextBox));

        /// <summary>
        /// Occurs when [HTML changed].
        /// </summary>
        public event EventHandler HtmlChanged
        {
            add
            {
                this.AddCriticalHandler(RichTextBox.HtmlChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(RichTextBox.HtmlChangedEvent, value);
            }
        }

        [Obsolete("HtmlChange event is deprecated. Please use HtmlChanged event instead.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler HtmlChange
        {
            add
            {
                this.AddCriticalHandler(RichTextBox.HtmlChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(RichTextBox.HtmlChangedEvent, value);
            }
        }

        public event ClientEventHandler ClientHtmlChange
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the HtmlChangeQueued event.
        /// </summary>
        private EventHandler HtmlChangeQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(RichTextBox.HtmlChangeQueuedEvent);
            }
        }

        /// <summary>
        /// The HtmlChangeQueued event registration.
        /// </summary>
        private static readonly SerializableEvent HtmlChangeQueuedEvent = SerializableEvent.Register("HtmlChangeQueued", typeof(EventHandler), typeof(RichTextBox));

        /// <summary>
        /// Occurs when [HTML change queued].
        /// </summary>
        public event EventHandler HtmlChangeQueued
        {
            add
            {
                this.AddHandler(RichTextBox.HtmlChangeQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(RichTextBox.HtmlChangeQueuedEvent, value);
            }
        }

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RichTextBox"></see> class.
        /// </summary>
        public RichTextBox()
        {
            this.BorderStyle = BorderStyle.Fixed3D;


        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <param name="strPath">The STR path.</param>
        public void LoadFile(string strPath)
        {
            this.LoadFile(strPath, RichTextBoxStreamType.RichText);
        }

        /// <summary>
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
            switch (objFileType)
            {
                case RichTextBoxStreamType.RichText:
                    // Create a converter to handle the RTF file
                    IFormatConverter objConverter = CommonUtils.GetProvider<IFormatConverter>(this.GetDefaultFormatConverterString(), true);

                    if (objConverter != null)
                    {
                        // Configure the settings for the converter
                        HtmlConvertionSettings objConvertionSettings = new HtmlConvertionSettings();
                        objConvertionSettings.RenderContent = true;
                        objConvertionSettings.RenderDocument = true;
                        objConvertionSettings.ImagesKeyPattern = "{0}";

                        // To trick the URL encode we replace the values with guids
                        string strImageKeyGuid = Guid.NewGuid().ToString("N");
                        string strImageExtentionKeyGuid = Guid.NewGuid().ToString("N");

                        // Create the parameters
                        NameValueCollection objNameValueCollection = new NameValueCollection();
                        objNameValueCollection.Add(IMAGE_KEY, strImageKeyGuid);
                        objNameValueCollection.Add(IMAGE_EXTENTION, strImageExtentionKeyGuid);

                        // Assign the patterns
                        objConvertionSettings.ImagesUrlPattern = (new GatewayResourceHandle(this, RTF_IMAGE, objNameValueCollection)).ToString();
                        objConvertionSettings.ImagesUrlPattern = objConvertionSettings.ImagesUrlPattern.Replace(strImageKeyGuid, objConvertionSettings.ImagesKeyPattern).Replace(strImageExtentionKeyGuid, "{1}");

                        // Convert the rtf into a stream holding an HTML string
                        using (Stream objOutputStream = objConverter.Convert(FormatConvertionType.Rtf, FormatConvertionType.Html, objData, objConvertionSettings, mobjImagesIndexByImageKey))
                        {
                            // Read the HTML
                            StreamReader objReader = new StreamReader(objOutputStream);

                            this.Html = objReader.ReadToEnd();
                        }
                    }

                    break;
                default:
                    throw new NotImplementedException("Load File supports only type: 'RichTextBoxStreamType.RichText'");
            }
        }

        /// <summary>
        /// Gets the default Format converter's type string
        /// </summary>
        /// <returns></returns>
        private string GetDefaultFormatConverterString()
        {
            // Assign the fullty qualified name according to the correct .Net framework
            string strQualifiedNameForFormatConverter = string.Empty;
#if WG_NET46
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET452
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET451
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET45
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET40
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET35
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=null";
#elif WG_NET2
            strQualifiedNameForFormatConverter = "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=null";
#endif
            // Get the format converter type string
            return strQualifiedNameForFormatConverter;
        }

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHostContext">The gateway request HOST context.</param>
        /// <param name="strAction">The gateway request action.</param>
        /// <returns>
        /// By default this method returns a instance of a class which implements the IGatewayHandler and
        /// throws a non implemented HttpException.
        /// </returns>
        protected override IGatewayHandler ProcessGatewayRequest(WebGUI.Hosting.HostContext objHostContext, string strAction)
        {
            switch (strAction)
            {
                // handle The RTF images request
                case RTF_IMAGE:
                    // Get the image's key
                    string strImageKey = objHostContext.Request.QueryString[IMAGE_KEY];

                    // Mae sure that the key exists
                    if (!string.IsNullOrEmpty(strImageKey) && mobjImagesIndexByImageKey.ContainsKey(strImageKey))
                    {
                        // Get the extention
                        string strImageExtention = objHostContext.Request.QueryString[IMAGE_EXTENTION];
                        if (!string.IsNullOrEmpty(strImageExtention))
                        {
                            // Get the relevant image's byte array
                            byte[] arrImageByteArray = this.mobjImagesIndexByImageKey[strImageKey];

                            // Set the correct mime type according to the file extention
                            objHostContext.Response.ContentType = CommonUtils.GetMimeType(strImageExtention);

                            // Write array to output stream
                            objHostContext.Response.OutputStream.Write(arrImageByteArray, 0, arrImageByteArray.Length);
                            objHostContext.Response.OutputStream.Flush();
                        }
                    }

                    return null;
                default:
                    return base.ProcessGatewayRequest(objHostContext, strAction);
            }
        }

        /// <summary>
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
            Stream objData = new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                this.LoadFile(objData, objFileType);
            }
            finally
            {
                objData.Close();
            }
        }


        /// <summary>
        /// Sets the content of the clipboard.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        protected override void SetClipboardContent(string strValue)
        {
            this.Html = strValue;
        }

        /// <summary>
        /// Gets the content of the clipboard.
        /// </summary>
        /// <returns></returns>
        protected override string GetClipboardContent()
        {
            return this.Html;
        }

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">Force render</param>
        protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            string strHtml = this.Html;
            if (blnForceRender || !string.IsNullOrEmpty(strHtml))
            {
                objWriter.WriteAttributeString(WGAttributes.Source, strHtml);
            }
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="strArg"></param>
        protected string DoImageInsert(string strArg)
        {
            return this.Html;
        }

        /// <summary>
        /// Prints the current RichTextBox content
        /// </summary>
        public void Print()
        {
            this.InvokeMethodWithId("RichTextBox_Execute", "Print");
        }



        #endregion Methods

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // Select event type
            switch (objEvent.Type)
            {
                case "ValueChange":

                    // Set the current text value
                    string strValue = objEvent[WGAttributes.Text];

                    this.Html = strValue == null ? "" : strValue;

                    if (HtmlChangedHandler != null)
                    {
                        HtmlChangedHandler(this, EventArgs.Empty);
                    }

                    if (HtmlChangeQueuedHandler != null)
                    {
                        HtmlChangeQueuedHandler(this, EventArgs.Empty);
                    }

                    break;
                default:
                    base.FireEvent(objEvent);
                    break;
            }

        }

        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.RichTextBox.Font"></see> property value changes. </summary>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This event is obsolete")]
        new public event EventHandler FontChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether text box is multi line.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if multi line otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true), Browsable(false)]
        public override bool Multiline
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the HTML string.
        /// </summary>
        /// <value>The HTML string.</value>
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Bindable(true)]
        public string Html
        {
            get
            {
                return this.GetValue<string>(RichTextBox.HtmlProperty, String.Empty);
            }
            set
            {
                // If value has changed
                if (this.Html != value)
                {
                    // If value is default value
                    if (value == null || value == String.Empty)
                    {
                        // Remove from PropertyStore
                        this.RemoveValue<string>(RichTextBox.HtmlProperty);
                    }
                    else
                    {
                        // Set the new value
                        this.SetValue<string>(RichTextBox.HtmlProperty, value);
                    }

                    if (HtmlChangedHandler != null)
                    {
                        HtmlChangedHandler(this, EventArgs.Empty);
                    }

                    if (HtmlChangeQueuedHandler != null)
                    {
                        HtmlChangeQueuedHandler(this, EventArgs.Empty);
                    }

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is not supported for this control.")]
        [SRCategory("CatAppearance"), SRDescription("ControlFontDescr")]
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

        /// <summary>Gets or sets the font of the current text selection or insertion point.</summary>
        /// <returns>A <see cref="T:System.Drawing.Font"></see> that represents the font to apply to the current text selection or to text entered after the insertion point.</returns>
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
                this.InvokeMethodWithId("RichTextBox_Execute", "FontName", "", value.FontFamily.Name);
            }
        }

        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
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

        #endregion Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.DefaultValue("")]

        public override string Text
        {
            get
            {
                return this.GetTextFromHtml(this.Html);
            }
            set
            {
                this.Html = GetHtmlFromText(value);
            }
        }

        /// <summary>
        /// Gets the text from HTML.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <returns></returns>
        private string GetTextFromHtml(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                // Its better to use StringBuilder, but it does not support Regular Expression Replacing, so ended up with string class
                string strDecodedValue = HttpUtility.HtmlDecode(strValue);
                Regex objRegex;
                string[] arrHtmlTags = { "&bs;", "<br />", "<br>", "<hr>", "<hr />", "</p>", "</td><td>", "</tr>", "</td>", "<([^<])*>", " ", "<", ">", "&", "&#160;" };
                string[] arrStrings = { "\b", "\n", "\n", "\n", "\n", "\n", "\t", "\n", " ", "", " ", "<", ">", "&", " " };
                for (int i = 0; i < arrHtmlTags.Length; i++)
                {
                    objRegex = new Regex(arrHtmlTags[i], RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    strDecodedValue = objRegex.Replace(strDecodedValue, arrStrings[i]);
                }


                return strDecodedValue;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the HTML from text.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <returns></returns>
        private string GetHtmlFromText(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                string strEncodedValue = HttpUtility.HtmlEncode(strValue);

                strEncodedValue = strEncodedValue.Replace("\r\n", "<br/>");
                strEncodedValue = strEncodedValue.Replace("\r", "<br/>");
                strEncodedValue = strEncodedValue.Replace("\n", "<br/>");
                strEncodedValue = strEncodedValue.Replace("\b", "&bs;");
                strEncodedValue = strEncodedValue.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

                return strEncodedValue;
            }
            return string.Empty;
        }
    }

    #endregion RichTextBox Class





}
