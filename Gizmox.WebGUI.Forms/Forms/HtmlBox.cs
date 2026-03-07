// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HtmlBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A html control</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (HtmlBox), "HtmlBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.HtmlBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.HtmlBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (HtmlBoxSkin))]
  [Serializable]
  public class HtmlBox : FrameControl
  {
    /// <summary>
    /// Provides a property reference to GatewayReference property.
    /// </summary>
    private static SerializableProperty GatewayReferenceProperty = SerializableProperty.Register(nameof (GatewayReference), typeof (GatewayReference), typeof (HtmlBox));
    /// <summary>Provides a property reference to Expires property.</summary>
    private static SerializableProperty ExpiresProperty = SerializableProperty.Register(nameof (Expires), typeof (int), typeof (HtmlBox));
    /// <summary>
    /// Provides a property reference to ContentType property.
    /// </summary>
    private static SerializableProperty ContentTypeProperty = SerializableProperty.Register(nameof (ContentType), typeof (string), typeof (HtmlBox));
    /// <summary>Provides a property reference to Type property.</summary>
    private static SerializableProperty TypeProperty = SerializableProperty.Register(nameof (Type), typeof (HtmlBoxType), typeof (HtmlBox));
    /// <summary>
    /// Provides a property reference to ResourceHandle property.
    /// </summary>
    private static SerializableProperty ResourceHandleProperty = SerializableProperty.Register("ResourceHandle", typeof (ResourceHandle), typeof (HtmlBox));
    /// <summary>Provides a property reference to Path property.</summary>
    private static SerializableProperty PathProperty = SerializableProperty.Register(nameof (Path), typeof (string), typeof (HtmlBox));
    /// <summary>Provides a property reference to Url property.</summary>
    private static SerializableProperty UrlProperty = SerializableProperty.Register(nameof (Url), typeof (string), typeof (HtmlBox));
    /// <summary>Provides a property reference to Html property.</summary>
    private static SerializableProperty HtmlProperty = SerializableProperty.Register(nameof (Html), typeof (string), typeof (HtmlBox));
    /// <summary>
    /// Provides a property reference to IsWindowless property.
    /// </summary>
    private static SerializableProperty IsWindowlessProperty = SerializableProperty.Register(nameof (IsWindowless), typeof (bool), typeof (HtmlBox), new SerializablePropertyMetadata((object) false));

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.HtmlBox" /> instance.
    /// </summary>
    public HtmlBox() => this.Size = new Size(200, 200);

    /// <summary>Gets the source.</summary>
    /// <value>The source.</value>
    protected override string Source
    {
      get
      {
        if (this.IsWindowless)
          return this.Html;
        if (this.Type == HtmlBoxType.RESOURCE)
        {
          ResourceHandle resource = this.Resource;
          return resource != null ? resource.ToString() : string.Empty;
        }
        if (this.Type != HtmlBoxType.UNC && this.Type != HtmlBoxType.HTML)
          return this.Url;
        GatewayReference gatewayReference = this.GatewayReference;
        if (gatewayReference == null)
        {
          gatewayReference = new GatewayReference((IRegisteredComponent) this, "Html");
          this.GatewayReference = gatewayReference;
        }
        return gatewayReference.ToString();
      }
    }

    /// <summary>Prints this instance.</summary>
    public void Print() => this.InvokeMethod("FrameControl_Print", (object) this.ID.ToString());

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.FireObservableItemPropertyChanged("Content");
    }

    /// <summary>Resets the resource.</summary>
    private void ResetResource() => this.Resource = (ResourceHandle) null;

    /// <summary>Gets or sets the HTML code of the control.</summary>
    /// <value></value>
    public virtual string Html
    {
      get => this.Type != HtmlBoxType.HTML ? string.Empty : this.GetValue<string>(HtmlBox.HtmlProperty, "<HTML>No content.</HTML>");
      set
      {
        if (!(this.Html != value))
          return;
        if (string.IsNullOrEmpty(value))
        {
          this.RemoveValue<string>(HtmlBox.HtmlProperty);
        }
        else
        {
          this.Type = HtmlBoxType.HTML;
          this.SetValue<string>(HtmlBox.HtmlProperty, value);
          this.RemoveValue<string>(HtmlBox.UrlProperty);
          this.Update();
          this.FireObservableItemPropertyChanged("Content");
        }
      }
    }

    /// <summary>Resets the HTML.</summary>
    private void ResetHtml() => this.Html = this.Type == HtmlBoxType.HTML ? "<HTML>No content.</HTML>" : string.Empty;

    /// <summary>
    /// Gets or sets the value indicating if html should be rendered without an iframe.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is windowless; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool IsWindowless
    {
      get => this.GetValue<bool>(HtmlBox.IsWindowlessProperty);
      set
      {
        if (value && this.Type != HtmlBoxType.HTML)
          throw new ArgumentOutOfRangeException("HtmlBox must be in HTML mode to use windowless mode.");
        if (!this.SetValue<bool>(HtmlBox.IsWindowlessProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Indicates if the framecontrol should render source as inline html of as a url for
    /// a frame.
    /// </summary>
    /// <value></value>
    protected override bool IsInline => this.IsWindowless;

    /// <summary>Gets or sets the URL.</summary>
    /// <value></value>
    [DefaultValue("")]
    public virtual string Url
    {
      get => this.Type != HtmlBoxType.URL ? string.Empty : this.GetValue<string>(HtmlBox.UrlProperty, string.Empty);
      set
      {
        string str = this.Url;
        if (this.Type == HtmlBoxType.URL && !(str != value))
          return;
        if (string.IsNullOrEmpty(value))
        {
          this.RemoveValue<string>(HtmlBox.UrlProperty);
        }
        else
        {
          this.Type = HtmlBoxType.URL;
          this.SetValue<string>(HtmlBox.UrlProperty, value);
          str = value;
          this.RemoveValue<string>(HtmlBox.HtmlProperty);
        }
        this.FireObservableItemPropertyChanged("Content");
        this.InvokeMethodWithId("FrameControl_SetUrl", (object) str);
      }
    }

    /// <summary>Gets or sets the path.</summary>
    /// <value></value>
    [DefaultValue("")]
    public virtual string Path
    {
      get => this.Type != HtmlBoxType.UNC ? string.Empty : this.GetValue<string>(HtmlBox.PathProperty, string.Empty);
      set
      {
        if (!(this.Path != value))
          return;
        if (string.IsNullOrEmpty(value))
        {
          this.RemoveValue<string>(HtmlBox.UrlProperty);
        }
        else
        {
          this.Type = HtmlBoxType.UNC;
          this.SetValue<string>(HtmlBox.PathProperty, value);
          this.SetValue<string>(HtmlBox.UrlProperty, value);
          this.RemoveValue<string>(HtmlBox.HtmlProperty);
        }
        this.FireObservableItemPropertyChanged("Content");
      }
    }

    /// <summary>Gets or sets the resource.</summary>
    /// <value></value>
    [DefaultValue(null)]
    public virtual ResourceHandle Resource
    {
      get => this.Type != HtmlBoxType.RESOURCE ? (ResourceHandle) null : this.GetValue<ResourceHandle>(HtmlBox.ResourceHandleProperty, (ResourceHandle) null);
      set
      {
        if (this.Resource == value)
          return;
        if (value == null)
        {
          this.RemoveValue<string>(HtmlBox.ResourceHandleProperty);
        }
        else
        {
          this.Type = HtmlBoxType.RESOURCE;
          this.SetValue<ResourceHandle>(HtmlBox.ResourceHandleProperty, value);
          this.RemoveValue<string>(HtmlBox.HtmlProperty);
        }
        this.FireObservableItemPropertyChanged("Content");
      }
    }

    /// <summary>Gets the html box type.</summary>
    /// <value></value>
    public HtmlBoxType Type
    {
      get => this.GetValue<HtmlBoxType>(HtmlBox.TypeProperty, HtmlBoxType.HTML);
      internal set
      {
        if (this.Type == value)
          return;
        if (value == HtmlBoxType.HTML)
          this.RemoveValue<HtmlBoxType>(HtmlBox.TypeProperty);
        else
          this.SetValue<HtmlBoxType>(HtmlBox.TypeProperty, value);
      }
    }

    /// <summary>Gets or sets the content type.</summary>
    /// <value></value>
    public string ContentType
    {
      get => this.GetValue<string>(HtmlBox.ContentTypeProperty, "text/html");
      set
      {
        if (!(this.ContentType != value))
          return;
        if (string.IsNullOrEmpty(value))
          this.RemoveValue<string>(HtmlBox.ContentTypeProperty);
        else
          this.SetValue<string>(HtmlBox.ContentTypeProperty, value);
      }
    }

    /// <summary>Gets or sets the expire time in secodns.</summary>
    /// <value></value>
    [DefaultValue(-1)]
    public int Expires
    {
      get => this.GetValue<int>(HtmlBox.ExpiresProperty, -1);
      set
      {
        if (this.Expires == value)
          return;
        if (value == -1)
          this.RemoveValue<string>(HtmlBox.ExpiresProperty);
        else
          this.SetValue<int>(HtmlBox.ExpiresProperty, value);
      }
    }

    /// <summary>Gets or sets the gateway reference.</summary>
    /// <value>The gateway reference.</value>
    private GatewayReference GatewayReference
    {
      get => this.GetValue<GatewayReference>(HtmlBox.GatewayReferenceProperty, (GatewayReference) null);
      set
      {
        if (this.GatewayReference == value)
          return;
        if (value == null)
          this.RemoveValue<GatewayReference>(HtmlBox.GatewayReferenceProperty);
        else
          this.SetValue<GatewayReference>(HtmlBox.GatewayReferenceProperty, value);
      }
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
    /// <param name="objHostContext">The gateway request host context.</param>
    /// <param name="strAction">The gateway request action.</param>
    /// <returns>
    /// By default this method returns a instance of a class which implements the IGatewayHandler and
    /// throws a non implemented HttpException.
    /// </returns>
    /// <remarks>
    /// This method is called from the implementation of IGatewayComponent which replaces the
    /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
    /// RegisteredComponent class which is the base class of most of the Visual WebGui
    /// components.
    /// Referencing a RegisterComponent that overrides this method is done the same way that
    /// a control implementing IGatewayControl, which is by using the GatewayReference class.
    /// </remarks>
    protected override IGatewayHandler ProcessGatewayRequest(
      HostContext objHostContext,
      string strAction)
    {
      return strAction == "Html" ? (IGatewayHandler) new HtmlBox.HtmlGateway(this) : (IGatewayHandler) null;
    }

    /// <summary>Html gateway handler</summary>
    [Serializable]
    public class HtmlGateway : GatewayWriter
    {
      private HtmlBox mobjHtmlBox;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HtmlBox.HtmlGateway" /> class.
      /// </summary>
      /// <param name="objHtmlBox">The obj HTML box.</param>
      public HtmlGateway(HtmlBox objHtmlBox) => this.mobjHtmlBox = objHtmlBox;

      /// <summary>Processes the request.</summary>
      protected override void ProcessRequest()
      {
        if (this.mobjHtmlBox == null)
          return;
        if (this.mobjHtmlBox.Type == HtmlBoxType.HTML)
        {
          this.Write(this.mobjHtmlBox.Html);
        }
        else
        {
          this.WriteFile(this.mobjHtmlBox.Path);
          this.ContentType = this.mobjHtmlBox.ContentType;
        }
      }
    }
  }
}
