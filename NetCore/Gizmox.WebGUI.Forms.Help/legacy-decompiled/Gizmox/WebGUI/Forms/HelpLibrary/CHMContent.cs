using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.HelpLibrary;

internal class CHMContent : IStaticGateway
{
	private string[] marrBaseFolder;

	private string mstrBaseFolder = "";

	private CHMExplorerController mobjCHMExplorerController = null;

	private string mstrRedirectionTemplate = null;

	private string mstrResourceTemplate = null;

	private CHMExplorerController CHMController
	{
		get
		{
			if (mobjCHMExplorerController == null)
			{
				mobjCHMExplorerController = CHMExplorerController.Get(CHMReference);
			}
			return mobjCHMExplorerController;
		}
	}

	private string CHMReference => HostContext.Current.Request.QueryString["chm"];

	private string Local => HostContext.Current.Request.QueryString["src"];

	private string RedirectionTemplate
	{
		get
		{
			if (mstrRedirectionTemplate == null)
			{
				mstrRedirectionTemplate = string.Format(CHMExplorerController.RedirectionTemplateRoot + "?chm={0}", CHMReference) + "&src={0}";
			}
			return mstrRedirectionTemplate;
		}
	}

	private string ResourceTemplate
	{
		get
		{
			if (mstrResourceTemplate == null)
			{
				mstrResourceTemplate = string.Format(CHMExplorerController.ResourceTemplateRoot + "?chm={0}", CHMReference) + "&src={0}";
			}
			return mstrResourceTemplate;
		}
	}

	static CHMContent()
	{
	}

	public IStaticGatewayHandler GetGatewayHandler(IContext objContext)
	{
		objContext.HostContext.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
		objContext.HostContext.Response.ExpiresAbsolute = DateTime.Now.AddMonths(6);
		try
		{
			if (Local.LastIndexOf("/") > -1)
			{
				mstrBaseFolder = Local.Substring(0, Local.LastIndexOf("/")).Replace("\\", "/");
				marrBaseFolder = mstrBaseFolder.Split('/');
			}
			else
			{
				mstrBaseFolder = "";
				marrBaseFolder = new string[0];
			}
			Render(objContext.HostContext.Response);
		}
		catch (Exception ex)
		{
			objContext.HostContext.Response.Write("Error:" + ex.Message);
		}
		return null;
	}

	protected void Render(HostResponse objResponse)
	{
		string strHtmlContent = null;
		if (CHMController != null)
		{
			strHtmlContent = CHMController.ReadFromFile(Local);
		}
		if (!string.IsNullOrEmpty(strHtmlContent))
		{
			CommonUtils.GetProvider<IHelpRevisor>(null, blnIsCache: true, blnCanBeNull: true)?.OnHelpRender(CHMController.FilePath, ref strHtmlContent);
			try
			{
				Regex regex = new Regex("(?<tag></?[?A-Za-z!][a-zA-Z0-9:]*[^<>]*[\\s]?>)|(?<text>[^<>]*)");
				Regex regex2 = new Regex("((?<=href[\\s]*=[\\s]*)[^\\n\"'\\s]*(?=[\\s>]))|((?<=href[\\s]*=[\\s]*[\"'])[^\\n\"']*(?=[\"']))", RegexOptions.IgnoreCase);
				Regex regex3 = new Regex("((?<=src[\\s]*=[\\s]*)[^\\n\"'\\s]*(?=[\\s>]))|((?<=src[\\s]*=[\\s]*[\"'])[^\\n\"']*(?=[\"']))", RegexOptions.IgnoreCase);
				Match match = regex.Match(strHtmlContent);
				while (match.Success)
				{
					string text = match.Value;
					string input = text.ToLower();
					Regex regex4 = new Regex("<a[\\s]");
					Regex regex5 = new Regex("<img[\\s]");
					Regex regex6 = new Regex("<script[\\s]");
					Regex regex7 = new Regex("<link[\\s]");
					if (regex4.Match(input).Success)
					{
						text = regex2.Replace(text, ReplaceLink);
					}
					else if (regex5.Match(input).Success)
					{
						text = regex3.Replace(text, ReplaceResource);
					}
					else if (regex6.Match(input).Success)
					{
						text = regex3.Replace(text, ReplaceResource);
					}
					else if (regex7.Match(input).Success)
					{
						text = regex2.Replace(text, ReplaceResource);
					}
					objResponse.Write(text);
					match = match.NextMatch();
				}
				return;
			}
			catch (ArgumentException ex)
			{
				objResponse.Write(ex.Message);
				return;
			}
		}
		objResponse.Write("<html></html>");
	}

	private string ReplaceLink(Match objMatch)
	{
		string value = objMatch.Value;
		if (value.StartsWith("http:") || value.StartsWith("ftp:"))
		{
			return value;
		}
		string text = GetPath(objMatch.Value);
		if (!IsTheTextEncoded(text))
		{
			text = HttpUtility.UrlEncode(text);
		}
		return string.Format(RedirectionTemplate, text.Replace("%2f", "/"));
	}

	private string ReplaceResource(Match objMatch)
	{
		string value = objMatch.Value;
		if (value.StartsWith("http:") || value.StartsWith("ftp:"))
		{
			return value;
		}
		string text = GetPath(objMatch.Value);
		if (!IsTheTextEncoded(text))
		{
			text = HttpUtility.UrlEncode(text);
		}
		return string.Format(ResourceTemplate, text.Replace("%2f", "/"));
	}

	private bool IsTheTextEncoded(string strText)
	{
		string text = HttpUtility.UrlDecode(strText);
		return text != strText;
	}

	private string GetPath(string strPath)
	{
		return GetPath(strPath, 0);
	}

	private string GetPath(string strPath, int intBack)
	{
		if (strPath.StartsWith("../"))
		{
			return GetPath(strPath.Substring(3), intBack + 1);
		}
		if (intBack > 0)
		{
			if (marrBaseFolder.Length - intBack > 0)
			{
				return Path.Combine(string.Join("/", marrBaseFolder, 0, marrBaseFolder.Length - intBack), strPath).Replace("\\", "/");
			}
			return strPath.Replace("\\", "/");
		}
		return Path.Combine(mstrBaseFolder, strPath).Replace("\\", "/");
	}
}
