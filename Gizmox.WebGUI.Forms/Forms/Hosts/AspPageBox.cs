// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspPageBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Summary description for AspPageBox</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (AspPageBox), "AspPageBox_45.png")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Host Controls")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (AspPageBoxSkin))]
  [Serializable]
  public class AspPageBox : FrameControl
  {
    /// <summary>
    /// 
    /// </summary>
    private static SerializableProperty PathProperty = SerializableProperty.Register(nameof (Path), typeof (string), typeof (AspPageBox));

    /// <summary>Gets the source.</summary>
    /// <value>The source.</value>
    protected override string Source
    {
      get
      {
        if (!this.IsValidPath(this.Path))
          return string.Empty;
        string baseUrl = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);
        string virtualPath = new GatewayReference((IRegisteredComponent) this, "ASPXhost", this.SourceArguments).ToString();
        if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
          virtualPath = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(virtualPath);
        string str = virtualPath;
        return baseUrl + str;
      }
    }

    /// <summary>Gets the source arguments.</summary>
    /// <value>The source arguments.</value>
    private NameValueCollection SourceArguments
    {
      get
      {
        string pathQueryString = this.PathQueryString;
        if (string.IsNullOrEmpty(pathQueryString))
          return (NameValueCollection) null;
        NameValueCollection sourceArguments = new NameValueCollection();
        string str1 = pathQueryString;
        char[] chArray1 = new char[1]{ '&' };
        foreach (string str2 in str1.Split(chArray1))
        {
          char[] chArray2 = new char[1]{ '=' };
          string[] strArray = str2.Split(chArray2);
          if (strArray.Length == 2)
            sourceArguments[HttpUtility.UrlDecode(strArray[0])] = HttpUtility.UrlDecode(strArray[1]);
        }
        return sourceArguments;
      }
    }

    /// <summary>Gets the path query string.</summary>
    /// <value>The path query string.</value>
    private string PathQueryString
    {
      get
      {
        string path = this.Path;
        if (!string.IsNullOrEmpty(path))
        {
          string[] strArray = path.Split('?');
          if (strArray.Length > 1)
            return strArray[1];
        }
        return string.Empty;
      }
    }

    /// <summary>Gets the path page.</summary>
    /// <value>The path page.</value>
    private string PagePath
    {
      get
      {
        string path = this.Path;
        if (string.IsNullOrEmpty(path))
          return string.Empty;
        string pagePath = path.Replace("\\", "/");
        if (!pagePath.StartsWith("~/"))
          pagePath = string.Format("~/{0}", (object) pagePath);
        if (pagePath.Contains("?"))
          pagePath = pagePath.Split('?')[0];
        return pagePath;
      }
    }

    /// <summary>Returns a flag indicating if path is valid</summary>
    /// <param name="strPath"></param>
    /// <returns></returns>
    private bool IsValidPath(string strPath) => !string.IsNullOrEmpty(strPath) && strPath.Trim() != string.Empty;

    /// <summary>The path of the asp page to be displayed</summary>
    [DefaultValue("")]
    public string Path
    {
      get => this.GetValue<string>(AspPageBox.PathProperty);
      set
      {
        if (!(this.Path != value))
          return;
        if (string.IsNullOrEmpty(value))
          this.RemoveValue<string>(AspPageBox.PathProperty);
        else
          this.SetValue<string>(AspPageBox.PathProperty, value);
      }
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
    /// <param name="objHttpContext">The gateway request HTTP context.</param>
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
      HttpContext objHttpContext,
      string strAction)
    {
      if (objHttpContext == null)
        throw new HttpException("ASP.NET runtime is unavailable.");
      string pagePath = this.PagePath;
      try
      {
        IHttpHandler compiledPageInstance = PageParser.GetCompiledPageInstance(pagePath, objHttpContext.Server.MapPath(pagePath), objHttpContext);
        if (compiledPageInstance != null)
        {
          if (compiledPageInstance is AspPageBase aspPageBase)
            aspPageBase.SetHost(this);
          compiledPageInstance.ProcessRequest(objHttpContext);
          return (IGatewayHandler) null;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return (IGatewayHandler) null;
    }
  }
}
