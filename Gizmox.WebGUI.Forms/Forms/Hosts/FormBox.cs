// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.FormBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>FormBox</summary>
  [ToolboxBitmap(typeof (FormBox), "FormBox_45.png")]
  [Designer("Gizmox.WebGUI.Forms.Design.FormBoxDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ToolboxItem("System.Web.UI.Design.WebControlToolboxItem, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [ToolboxData("<{0}:FormBox runat=server></{0}:FormBox>")]
  [Serializable]
  public class FormBox : WebControl
  {
    /// <summary>
    /// 
    /// </summary>
    private string mstrInstance = "";
    private IRouter mobjRouter;
    private bool mblnStateless;
    /// <summary>
    /// Holds the setting by which this control either opens a form as a DHTML
    /// </summary>
    private FormBox.ApplicationUITypes menmApplicationUiType;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.FormBox" /> class.
    /// </summary>
    public FormBox()
      : base("IFRAME")
    {
    }

    /// <summary>
    /// Adds HTML attributes and styles that need to be rendered to the specified <see cref="T:System.Web.UI.HtmlTextWriterTag" />. This method is used primarily by control developers.
    /// </summary>
    /// <param name="objWriter">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
    protected override void AddAttributesToRender(HtmlTextWriter objWriter)
    {
      if (!string.IsNullOrEmpty(this.Form))
      {
        string str = this.GetArguments();
        if (!str.ToLower().Contains("&vwginstance="))
          str = string.Format("{0}&vwginstance={1}", (object) str, (object) this.Instance);
        if (!str.ToLower().Contains("&vwgstateless="))
          str = string.Format("{0}&vwgstateless={1}", (object) str, this.mblnStateless ? (object) "1" : (object) "0");
        if (str.StartsWith("&"))
          str = str.Substring(1);
        objWriter.AddAttribute("src", this.ResolveClientUrl(string.Format("~/{0}{1}?{2}", (object) this.Form, (object) this.TypeExtension, (object) str)));
      }
      objWriter.AddAttribute("allowtransparency", "yes");
      objWriter.AddAttribute("frameborder", "no");
      base.AddAttributesToRender(objWriter);
    }

    /// <summary>Gets the arguments.</summary>
    /// <returns></returns>
    private string GetArguments()
    {
      string arguments = string.Empty;
      if (this.Arguments != null)
      {
        foreach (string name in (NameObjectCollectionBase) this.Arguments)
          arguments = string.Format("{0}&{1}={2}", (object) arguments, (object) name, (object) this.Arguments[name]);
      }
      return arguments;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this Control show open the
    /// internal form as a DHTML Form (wgx).
    /// </summary>
    /// <value><c>true</c> if [Run as DHTML]; otherwise, <c>false</c>.</value>
    [Category("Behavior")]
    [DefaultValue(FormBox.ApplicationUITypes.DHTML)]
    public virtual FormBox.ApplicationUITypes ApplicationUIType
    {
      get => this.menmApplicationUiType;
      set => this.menmApplicationUiType = value;
    }

    /// <summary>The mapped Visual WebGUI form to be displayed</summary>
    [Category("Data")]
    [DefaultValue("")]
    public string Form
    {
      get => this.ViewState[nameof (Form)] != null ? Convert.ToString(this.ViewState[nameof (Form)]) : string.Empty;
      set => this.ViewState[nameof (Form)] = (object) value;
    }

    /// <summary>
    /// The form instance which is used to create instances of the same mapped form
    /// </summary>
    [Category("Data")]
    [DefaultValue("")]
    public string Instance
    {
      get => this.mstrInstance;
      set
      {
        if (this.mstrInstance == null)
          return;
        this.mstrInstance = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Hosts.FormBox" /> is stateless.
    /// </summary>
    /// <value><c>true</c> if stateless; otherwise, <c>false</c>.</value>
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool Stateless
    {
      get => this.mblnStateless;
      set => this.mblnStateless = value;
    }

    /// <summary>
    /// The form arguments which can be used with in the Visual WebGui application
    /// </summary>
    /// <remarks>
    /// Provides a mechanism to send parameters and object references to the Visual WebGui application.
    /// </remarks>
    public NameValueCollection Arguments => this.Router != null ? this.Router.GetArguments(this.Form, this.Instance) : (NameValueCollection) null;

    /// <summary>
    /// The form results which can be used to expose parameters and references from the Visual WebGui application
    /// </summary>
    /// <remarks>
    /// Provides a mechanism to return parameters and object references from the Visual WebGui application.
    /// </remarks>
    public NameValueCollection Results => this.Router != null ? this.Router.GetResults(this.Form, this.Instance) : (NameValueCollection) null;

    private IRouter Router
    {
      get
      {
        if (this.mobjRouter == null)
          this.mobjRouter = Gizmox.WebGUI.Forms.ClientUtils.GetRouter();
        return this.mobjRouter;
      }
    }

    private string TypeExtension
    {
      get
      {
        string typeExtension = string.Empty;
        if (this.menmApplicationUiType == FormBox.ApplicationUITypes.DHTML)
          typeExtension = Config.GetInstance().DynamicExtension;
        return typeExtension;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ApplicationUITypes : byte
    {
      /// <summary>
      /// 
      /// </summary>
      DHTML,
    }
  }
}
