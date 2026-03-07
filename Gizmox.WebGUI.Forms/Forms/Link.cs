// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Link
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// The Link class provides services for opening links in a new window
  /// </summary>
  [Serializable]
  public class Link : ILink
  {
    /// <summary>The current link url</summary>
    private string mstrUrl = string.Empty;

    /// <summary>Create a new link object</summary>
    /// <param name="strUrl"></param>
    internal Link(string strUrl) => this.mstrUrl = strUrl;

    /// <summary>Opens a new url</summary>
    /// <param name="strUrl">The url to open</param>
    public static void Open(string strUrl) => Global.Context.OpenLink((ILink) new Link(strUrl));

    /// <summary>Opens a new url with window parameters</summary>
    /// <param name="strUrl">The url to open</param>
    /// <param name="objLinkParameters">The link window paramters</param>
    public static void Open(string strUrl, LinkParameters objLinkParameters) => Global.Context.OpenLink((ILink) new Link(strUrl), (ILinkParameters) objLinkParameters);

    /// <summary>
    /// Download a resource handle with content disposition to force browser save as.
    /// </summary>
    /// <param name="objResourceHandle">The resource handle to download its content.</param>
    /// <remarks>
    /// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
    /// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
    /// </remarks>
    public static void Download(ResourceHandle objResourceHandle)
    {
      string fileName = Path.GetFileName(objResourceHandle.File);
      Link.Download(objResourceHandle, fileName);
    }

    /// <summary>
    /// Download a resource handle with content disposition to force browser save as.
    /// </summary>
    /// <param name="objResourceHandle">The resource handle to download its content.</param>
    /// <param name="strFileName">The file name to give the downloaded file.</param>
    /// <remarks>
    /// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
    /// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
    /// </remarks>
    public static void Download(ResourceHandle objResourceHandle, string strFileName)
    {
      LinkParameters objLinkParameters = new LinkParameters();
      if (objResourceHandle.IsServerResource)
      {
        objLinkParameters.QueryString["content-disposition"] = strFileName;
        objLinkParameters.Target = "_self";
      }
      else
        objLinkParameters.Target = "_blank";
      Link.Open(objResourceHandle.ToString(), objLinkParameters);
    }

    /// <summary>Opens a gateway link</summary>
    /// <param name="objGatewayReference">The gateway reference</param>
    public static void Open(GatewayReference objGatewayReference) => Link.Open(objGatewayReference.ToString());

    /// <summary>Opens a gateway link with parameters</summary>
    /// <param name="objGatewayReference">The gateway reference</param>
    /// <param name="objLinkParameters">The link window paramters</param>
    public static void Open(GatewayReference objGatewayReference, LinkParameters objLinkParameters) => Link.Open(objGatewayReference.ToString(), objLinkParameters);

    /// <summary>Opens a form reference link</summary>
    /// <param name="objFormReference">The form reference</param>
    public static void Open(FormReference objFormReference) => Link.Open(objFormReference, new LinkParameters());

    /// <summary>Opens a form reference link with parameters</summary>
    /// <param name="objFormReference">The form reference</param>
    /// <param name="objLinkParameters">The link window paramters</param>
    public static void Open(FormReference objFormReference, LinkParameters objLinkParameters)
    {
      if (objLinkParameters == null)
        objLinkParameters = new LinkParameters();
      Global.Context.OpenLink((ILink) objFormReference, (ILinkParameters) objLinkParameters);
    }

    /// <summary>Gets the link url</summary>
    public string Url => this.mstrUrl;
  }
}
