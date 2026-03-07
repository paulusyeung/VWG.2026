// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RichTextBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Gizmox.WebGUI.Forms rich text box control.
  /// </summary>
  [ToolboxBitmap(typeof (RichTextBox), "RichTextBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.RichTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.RichTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [SRDescription("DescriptionRichTextBox")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("RX")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (RichTextBoxSkin))]
  [Serializable]
  public class RichTextBox : TextBoxBase
  {
    private const string RTF_IMAGE = "rtfImage";
    private const string IMAGE_KEY = "imageKey";
    private const string IMAGE_EXTENTION = "imageExtention";
    /// <summary>Provides a property reference to Html property.</summary>
    private static SerializableProperty HtmlProperty = SerializableProperty.Register(nameof (Html), typeof (string), typeof (RichTextBox));
    private Dictionary<string, byte[]> mobjImagesIndexByImageKey = new Dictionary<string, byte[]>();
    /// <summary>The HtmlChanged event registration.</summary>
    private static readonly SerializableEvent HtmlChangedEvent = SerializableEvent.Register("HtmlChanged", typeof (EventHandler), typeof (RichTextBox));
    /// <summary>The HtmlChangeQueued event registration.</summary>
    private static readonly SerializableEvent HtmlChangeQueuedEvent = SerializableEvent.Register("HtmlChangeQueued", typeof (EventHandler), typeof (RichTextBox));

    /// <summary>Gets the hanlder for the HtmlChanged event.</summary>
    private EventHandler HtmlChangedHandler => (EventHandler) this.GetHandler(RichTextBox.HtmlChangedEvent);

    /// <summary>Occurs when [HTML changed].</summary>
    public event EventHandler HtmlChanged
    {
      add => this.AddCriticalHandler(RichTextBox.HtmlChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(RichTextBox.HtmlChangedEvent, (Delegate) value);
    }

    [Obsolete("HtmlChange event is deprecated. Please use HtmlChanged event instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event EventHandler HtmlChange
    {
      add => this.AddCriticalHandler(RichTextBox.HtmlChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(RichTextBox.HtmlChangedEvent, (Delegate) value);
    }

    public event ClientEventHandler ClientHtmlChange
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Gets the hanlder for the HtmlChangeQueued event.</summary>
    private EventHandler HtmlChangeQueuedHandler => (EventHandler) this.GetHandler(RichTextBox.HtmlChangeQueuedEvent);

    /// <summary>Occurs when [HTML change queued].</summary>
    public event EventHandler HtmlChangeQueued
    {
      add => this.AddHandler(RichTextBox.HtmlChangeQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(RichTextBox.HtmlChangeQueuedEvent, (Delegate) value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RichTextBox"></see> class.
    /// </summary>
    public RichTextBox() => this.BorderStyle = BorderStyle.Fixed3D;

    /// <summary>Loads the file.</summary>
    /// <param name="strPath">The STR path.</param>
    public void LoadFile(string strPath) => this.LoadFile(strPath, RichTextBoxStreamType.RichText);

    /// <summary>Loads the file.</summary>
    /// <param name="objData">The obj data.</param>
    /// <param name="objFileType">Type of the obj file.</param>
    public void LoadFile(Stream objData, RichTextBoxStreamType objFileType)
    {
      if (!ClientUtils.IsEnumValid((Enum) objFileType, (int) objFileType, 0, 4))
        throw new InvalidEnumArgumentException(nameof (objFileType), (int) objFileType, typeof (RichTextBoxStreamType));
      if (objFileType != RichTextBoxStreamType.RichText)
        throw new NotImplementedException("Load File supports only type: 'RichTextBoxStreamType.RichText'");
      IFormatConverter provider = CommonUtils.GetProvider<IFormatConverter>(this.GetDefaultFormatConverterString(), true);
      if (provider == null)
        return;
      HtmlConvertionSettings objConvertionSettings = new HtmlConvertionSettings();
      objConvertionSettings.RenderContent = true;
      objConvertionSettings.RenderDocument = true;
      objConvertionSettings.ImagesKeyPattern = "{0}";
      string oldValue1 = Guid.NewGuid().ToString("N");
      string oldValue2 = Guid.NewGuid().ToString("N");
      objConvertionSettings.ImagesUrlPattern = new GatewayResourceHandle((IRegisteredComponent) this, "rtfImage", new NameValueCollection()
      {
        {
          "imageKey",
          oldValue1
        },
        {
          "imageExtention",
          oldValue2
        }
      }).ToString();
      HtmlConvertionSettings convertionSettings = objConvertionSettings;
      convertionSettings.ImagesUrlPattern = convertionSettings.ImagesUrlPattern.Replace(oldValue1, objConvertionSettings.ImagesKeyPattern).Replace(oldValue2, "{1}");
      using (Stream stream = provider.Convert(FormatConvertionType.Rtf, FormatConvertionType.Html, objData, (ConvertionSettings) objConvertionSettings, this.mobjImagesIndexByImageKey))
        this.Html = new StreamReader(stream).ReadToEnd();
    }

    /// <summary>Gets the default Format converter's type string</summary>
    /// <returns></returns>
    private string GetDefaultFormatConverterString()
    {
      string empty = string.Empty;
      return "Gizmox.WebGUI.Converters.Itenso.FormatConverter, Gizmox.WebGUI.Converters, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=null";
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
    /// <param name="objHostContext">The gateway request HOST context.</param>
    /// <param name="strAction">The gateway request action.</param>
    /// <returns>
    /// By default this method returns a instance of a class which implements the IGatewayHandler and
    /// throws a non implemented HttpException.
    /// </returns>
    protected override IGatewayHandler ProcessGatewayRequest(
      HostContext objHostContext,
      string strAction)
    {
      if (!(strAction == "rtfImage"))
        return base.ProcessGatewayRequest(objHostContext, strAction);
      string key = objHostContext.Request.QueryString["imageKey"];
      if (!string.IsNullOrEmpty(key) && this.mobjImagesIndexByImageKey.ContainsKey(key))
      {
        string strFileName = objHostContext.Request.QueryString["imageExtention"];
        if (!string.IsNullOrEmpty(strFileName))
        {
          byte[] buffer = this.mobjImagesIndexByImageKey[key];
          objHostContext.Response.ContentType = CommonUtils.GetMimeType(strFileName);
          objHostContext.Response.OutputStream.Write(buffer, 0, buffer.Length);
          objHostContext.Response.OutputStream.Flush();
        }
      }
      return (IGatewayHandler) null;
    }

    /// <summary>Loads the file.</summary>
    /// <param name="strPath">The STR path.</param>
    /// <param name="objFileType">Type of the obj file.</param>
    public void LoadFile(string strPath, RichTextBoxStreamType objFileType)
    {
      if (!ClientUtils.IsEnumValid((Enum) objFileType, (int) objFileType, 0, 4))
        throw new InvalidEnumArgumentException(nameof (objFileType), (int) objFileType, typeof (RichTextBoxStreamType));
      Stream objData = (Stream) new FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.Read);
      try
      {
        this.LoadFile(objData, objFileType);
      }
      finally
      {
        objData.Close();
      }
    }

    /// <summary>Sets the content of the clipboard.</summary>
    /// <param name="strValue">The STR value.</param>
    protected override void SetClipboardContent(string strValue) => this.Html = strValue;

    /// <summary>Gets the content of the clipboard.</summary>
    /// <returns></returns>
    protected override string GetClipboardContent() => this.Html;

    /// <summary>Renders the value.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">Force render</param>
    protected override void RenderValue(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      string html = this.Html;
      if (!blnForceRender && string.IsNullOrEmpty(html))
        return;
      objWriter.WriteAttributeString("SR", html);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strArg"></param>
    protected string DoImageInsert(string strArg) => this.Html;

    /// <summary>Prints the current RichTextBox content</summary>
    public void Print() => this.InvokeMethodWithId("RichTextBox_Execute", (object) nameof (Print));

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "ValueChange")
      {
        string str = objEvent["TX"];
        this.Html = str == null ? "" : str;
        if (this.HtmlChangedHandler != null)
          this.HtmlChangedHandler((object) this, EventArgs.Empty);
        if (this.HtmlChangeQueuedHandler == null)
          return;
        this.HtmlChangeQueuedHandler((object) this, EventArgs.Empty);
      }
      else
        base.FireEvent(objEvent);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.RichTextBox.Font"></see> property value changes. </summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This event is obsolete")]
    public new event EventHandler FontChanged;

    /// <summary>
    /// Gets or sets a value indicating whether text box is multi line.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if multi line otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [Browsable(false)]
    public override bool Multiline => true;

    /// <summary>Gets or sets the HTML string.</summary>
    /// <value>The HTML string.</value>
    [DefaultValue("")]
    [Bindable(true)]
    public string Html
    {
      get => this.GetValue<string>(RichTextBox.HtmlProperty, string.Empty);
      set
      {
        if (!(this.Html != value))
          return;
        if (value == null || value == string.Empty)
          this.RemoveValue<string>(RichTextBox.HtmlProperty);
        else
          this.SetValue<string>(RichTextBox.HtmlProperty, value);
        if (this.HtmlChangedHandler != null)
          this.HtmlChangedHandler((object) this, EventArgs.Empty);
        if (this.HtmlChangeQueuedHandler != null)
          this.HtmlChangeQueuedHandler((object) this, EventArgs.Empty);
        this.Update();
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
    [SRCategory("CatAppearance")]
    [SRDescription("ControlFontDescr")]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
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
      get => throw new NotImplementedException();
      set => this.InvokeMethodWithId("RichTextBox_Execute", (object) "FontName", (object) "", (object) value.FontFamily.Name);
    }

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is not supported for this control.")]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue("")]
    public override string Text
    {
      get => this.GetTextFromHtml(this.Html);
      set => this.Html = this.GetHtmlFromText(value);
    }

    /// <summary>Gets the text from HTML.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <returns></returns>
    private string GetTextFromHtml(string strValue)
    {
      if (string.IsNullOrEmpty(strValue))
        return string.Empty;
      string input = HttpUtility.HtmlDecode(strValue);
      string[] strArray1 = new string[15]
      {
        "&bs;",
        "<br />",
        "<br>",
        "<hr>",
        "<hr />",
        "</p>",
        "</td><td>",
        "</tr>",
        "</td>",
        "<([^<])*>",
        " ",
        "<",
        ">",
        "&",
        "&#160;"
      };
      string[] strArray2 = new string[15]
      {
        "\b",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\t",
        "\n",
        " ",
        "",
        " ",
        "<",
        ">",
        "&",
        " "
      };
      for (int index = 0; index < strArray1.Length; ++index)
        input = new Regex(strArray1[index], RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(input, strArray2[index]);
      return input;
    }

    /// <summary>Gets the HTML from text.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <returns></returns>
    private string GetHtmlFromText(string strValue) => !string.IsNullOrEmpty(strValue) ? HttpUtility.HtmlEncode(strValue).Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace("\b", "&bs;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;") : string.Empty;
  }
}
