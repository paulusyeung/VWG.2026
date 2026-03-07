// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.XamlBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>A html control</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (XamlBox), "XamlBox_45.png")]
  [ToolboxItemCategory("Host Controls")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (XamlBoxSkin))]
  [Serializable]
  public class XamlBox : ObjectBox
  {
    private string mstrXaml = string.Empty;
    private string mstrUrl;
    private XamlBoxType menmType;
    private XamlBox.XamlGateway mobjGateway;
    private ResourceHandle mobjResourceHandle;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.HtmlBox" /> instance.
    /// </summary>
    public XamlBox()
    {
      this.Size = new Size(200, 200);
      this.ObjectType = "application/x-silverlight-2";
      this.ObjectData = "data:application/x-silverlight-2,";
    }

    /// <summary>Resets the resource.</summary>
    private void ResetResource() => this.Resource = (ResourceHandle) null;

    /// <summary>Updates this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.FireObservableItemPropertyChanged("Content");
    }

    /// <summary>Gets or sets the Xaml code of the control.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string Xaml
    {
      get => this.Type != XamlBoxType.XAML ? "" : this.mstrXaml;
      set
      {
        this.menmType = XamlBoxType.XAML;
        this.mstrXaml = value;
        this.mstrUrl = "";
        this.FireObservableItemPropertyChanged("Content");
      }
    }

    /// <summary>
    /// Gets or sets a flag indicating if the Xaml control should be windowless.
    /// </summary>
    [DefaultValue(true)]
    public bool Windowless
    {
      get => this.Parameters.Contains("windowless") && bool.Parse(this.Parameters["windowless"].ToString());
      set => this.Parameters["windowless"] = (object) value;
    }

    /// <summary>Gets or sets the URL to the Xaml code.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string Url
    {
      get => this.Parameters.Contains("source") ? this.Parameters["source"].ToString() : string.Empty;
      set
      {
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
          this.Parameters["source"] = (object) new UrlResourceHandle(value.Contains("~/") ? value : "~/" + value).ToString();
        else
          this.Parameters["source"] = (object) value;
      }
    }

    /// <summary>Gets or sets the path to the Xaml code.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string Path
    {
      get => this.Type != XamlBoxType.UNC ? "" : this.mstrUrl;
      set
      {
        this.menmType = XamlBoxType.UNC;
        this.mstrUrl = value;
        this.mstrXaml = "";
        this.FireObservableItemPropertyChanged("Content");
      }
    }

    /// <summary>Gets or sets a resource that contains Xaml.</summary>
    /// <value></value>
    [DefaultValue(null)]
    public ResourceHandle Resource
    {
      get => this.Type != XamlBoxType.RESOURCE ? (ResourceHandle) null : this.mobjResourceHandle;
      set
      {
        this.menmType = XamlBoxType.RESOURCE;
        this.mobjResourceHandle = value;
        this.mstrXaml = "";
        this.FireObservableItemPropertyChanged("Content");
      }
    }

    /// <summary>Gets the html box type.</summary>
    /// <value></value>
    public XamlBoxType Type => this.menmType;

    /// <summary>Gets the gateway handler.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="strAction">The STR action.</param>
    /// <returns></returns>
    public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction) => strAction == "Xaml" ? (IGatewayHandler) new XamlBox.XamlGateway(this) : (IGatewayHandler) null;

    /// <summary>Xaml gateway handler</summary>
    [Serializable]
    public class XamlGateway : GatewayWriter
    {
      private XamlBox mobjXamlBox;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.XamlBox.XamlGateway" /> class.
      /// </summary>
      /// <param name="objXamlBox">The obj xaml box.</param>
      public XamlGateway(XamlBox objXamlBox) => this.mobjXamlBox = objXamlBox;

      /// <summary>Processes the request.</summary>
      protected override void ProcessRequest()
      {
        if (this.mobjXamlBox == null)
          return;
        if (this.mobjXamlBox.Type == XamlBoxType.XAML)
        {
          if (this.mobjXamlBox.Xaml != string.Empty)
            this.Write(this.mobjXamlBox.Xaml);
          else
            this.Write("<Canvas xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Height=\"500\" Width=\"500\"></Canvas>");
        }
        else
          this.WriteFile(this.mobjXamlBox.Path);
        this.ContentType = "text/xml";
      }
    }
  }
}
