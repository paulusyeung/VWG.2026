using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Common.Resources;

/// <summary>
/// Static gateway that will serve any file or resource accessible by the server, provided the
/// IGeneralResourceHandleAccessGranter provider grants access to the resource. By default, access
/// is granted to non-local resources (Urls) and all files under the virtual folder's Resources folder.
///
/// Custom access granter can be set through Provider in web.config, default being equal to:
///
///  <WebGUI>
///    <Providers>
///      <Provider key="IGeneralResourceHandleAccessGranter" value="Gizmox.WebGUI.Common.Resources.GeneralResourceHandleDefaultGranter, Gizmox.WebGUI.Forms.Extended" />
///    </Providers>
///  </WebGUI>
///
/// Names of file resources are always interpreted relative to application's virtual folder,
/// which means a resource named 'test.jpg' will mean a test.jpg file directly on the application's
/// virtual folder.
///
/// Default caching is set at application startup according to the VWG_DisableCachingSwitch of web.config, 
/// and if enabled, resources are by default cached for 1 year. 
/// </summary>
[Serializable]
public class GeneralResourceHandle : StaticGatewayResourceHandle, IStaticGateway
{
	internal const string FULL_NAME = "FN";

	internal const string CONTENT_TYPE = "CT";

	/// <summary>
	/// Full name of file/resource - used for internal processing
	/// </summary>
	protected string mstrFileName = string.Empty;

	/// <summary>
	/// ContentType of file/resource - used for internal processing
	/// </summary>
	protected string mstrContentType = string.Empty;

	/// <summary>
	/// Gets a value indicating whether this resource is a local server resource.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is a local server resource; otherwise, <c>false</c>.
	/// </value>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool IsServerResource => true;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralResourceHandle" /> class.
	///
	/// Required by StaticGatewayResourceHandle derived classes - Best practice: No code should be in here.
	///
	/// This constructor is required by the router when serving requests for resources served by this static
	/// gateway and should not contain any code.
	/// </summary>
	public GeneralResourceHandle()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralResourceHandle" /> class.
	/// </summary>
	/// <param name="strFullName">Full name of the string.</param>
	public GeneralResourceHandle(string strFullName)
		: this(strFullName, CommonUtils.GetMimeType(strFullName))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralResourceHandle" /> class.
	/// </summary>
	/// <param name="strFullName">Full name of the string.</param>
	/// <param name="strContentType">Type of the string content.</param>
	public GeneralResourceHandle(string strFullName, string strContentType)
		: this(strFullName, strContentType, typeof(GeneralResourceHandle).FullName, typeof(GeneralResourceHandle))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Common.Resources.GeneralResourceHandle" /> class.
	/// </summary>
	/// <param name="strFullName">The filename to reference</param>
	/// <param name="strContentType">The content type to use when serving the gateway request.</param>
	/// <param name="strTypeName">The full name of the static gateway class type</param>
	/// <param name="objType">The static gateway class type</param>
	protected internal GeneralResourceHandle(string strFullName, string strContentType, string strTypeName, Type objType)
		: base(strTypeName, objType)
	{
		mstrFileName = strFullName;
		mstrContentType = strContentType;
	}

	/// <summary>
	/// Gets the gateway handler.
	/// </summary>
	/// <param name="objContext">Request context.</param>
	/// <returns></returns>
	IStaticGatewayHandler IStaticGateway.GetGatewayHandler(IContext objContext)
	{
		NameValueCollection queryString = objContext.HostContext.Request.QueryString;
		mstrFileName = HttpUtility.UrlDecode(queryString["FN"]);
		mstrContentType = HttpUtility.UrlDecode(queryString["CT"]);
		Write(objContext, mstrContentType);
		return null;
	}

	/// <summary>
	/// Writes the resource and it's headers to the response stream.
	/// Calls WriteCacheHeaders, WriteContentType, WriteContent in this order
	/// </summary>
	/// <param name="objContext">The response.</param>
	/// <param name="strContentType">Type of the string content.</param>
	protected virtual void Write(IContext objContext, string strContentType)
	{
		WriteCacheHeaders(objContext);
		WriteContentType(objContext, strContentType);
		WriteContent(objContext);
	}

	/// <summary>
	/// Writes the caching headers.
	/// </summary>
	/// <param name="objContext">The response.</param>
	protected virtual void WriteCacheHeaders(IContext objContext)
	{
		if (ConfigHelper.IsCacheEnabled)
		{
			objContext.HostContext.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
			objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.Public);
			objContext.HostContext.Response.Cache.SetValidUntilExpires(validUntilExpires: true);
		}
		else
		{
			objContext.HostContext.Response.Cache.SetExpires(DateTime.Now);
			objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			objContext.HostContext.Response.Cache.SetValidUntilExpires(validUntilExpires: false);
		}
	}

	/// <summary>
	/// Writes the content type header.
	/// </summary>
	/// <param name="objContext">The response.</param>
	/// <param name="strContentType">The data reader.</param>
	protected virtual void WriteContentType(IContext objContext, string strContentType)
	{
		objContext.HostContext.Response.ContentType = strContentType;
	}

	/// <summary>
	/// Writes the binary content of the file/resource.
	/// </summary>
	/// <param name="objContext">The response.</param>
	/// <param name="strFullName">The data reader.</param>
	protected virtual void WriteContent(IContext objContext)
	{
		CopyStream(ToStream(), objContext.HostContext.Response.OutputStream);
	}

	/// <summary>
	/// Gets the resource stream
	/// </summary>
	/// <returns></returns>
	public override Stream ToStream()
	{
		string text = mstrFileName;
		bool? flag = null;
		Stream stream = null;
		if (System.IO.File.Exists(mstrFileName))
		{
			flag = true;
		}
		text = Path.Combine(Application.StartupPath, text.Replace("/", "\\"));
		if (!flag.HasValue && System.IO.File.Exists(text))
		{
			flag = true;
		}
		if ((!flag.HasValue && mstrFileName.StartsWith(Uri.UriSchemeHttp)) || mstrFileName.StartsWith(Uri.UriSchemeHttps))
		{
			text = mstrFileName;
			flag = false;
		}
		IGeneralResourceHandleAccessGranter provider = CommonUtils.GetProvider<IGeneralResourceHandleAccessGranter>("Gizmox.WebGUI.Common.Resources.GeneralResourceHandleDefaultGranter, Gizmox.WebGUI.Forms.Extended", blnIsCache: true, blnCanBeNull: false);
		if (flag.HasValue && provider.IsGranted(text, flag.Value))
		{
			if (flag.Value)
			{
				using Stream stream2 = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
				if (stream2 == null)
				{
					stream = null;
				}
				else
				{
					stream = new MemoryStream();
					CopyStream(stream2, stream);
					stream.Seek(0L, SeekOrigin.Begin);
				}
			}
			else
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.Method = "GET";
				WebResponse response = httpWebRequest.GetResponse();
				if (response != null)
				{
					stream = response.GetResponseStream();
				}
			}
		}
		return stream;
	}

	/// <summary>
	/// Gets the specific resource handle  - used for ToString().
	///
	/// The returned value will be the Url used for this particular resource/file.
	/// </summary>
	/// <returns></returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override string GetSpecificResourceHandle()
	{
		return string.Format("{0}?{1}={2}&{3}={4}", base.GetSpecificResourceHandle(), "FN", HttpUtility.UrlEncode(mstrFileName), "CT", HttpUtility.UrlEncode(mstrContentType));
	}

	/// <summary>
	/// Copy one stream to another. 
	/// </summary>
	/// <param name="objFromStream"></param>
	/// <param name="objToStream"></param>
	private static void CopyStream(Stream objFromStream, Stream objToStream)
	{
		if (objFromStream != null && objToStream != null)
		{
			byte[] array = new byte[32768];
			int count;
			while ((count = objFromStream.Read(array, 0, array.Length)) > 0)
			{
				objToStream.Write(array, 0, count);
			}
		}
	}
}
