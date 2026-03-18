using System;
using System.Collections;
using System.Data;
using System.Globalization;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Hosting;
using HtmlHelp;

namespace Gizmox.WebGUI.Forms.HelpLibrary;

internal class CHMExplorerController
{
	private HtmlHelpSystem mobjHtmlHelpSystem = null;

	private Hashtable mobjCHMItemsHash = null;

	private CHMExplorerNode mobjCHMRootNode = null;

	private CHMExplorerNode mobjCHMDefaultNode = null;

	private string mstrCHMDefaultLocal = null;

	private string mstrCHMFilePath = null;

	private static StaticGatewayResourceHandle mobjStaticGatewayContentHandle;

	private static string mstrRedirectionTemplateRoot;

	private static StaticGatewayResourceHandle mobjStaticGatewayResourceHandle;

	private static string mstrResourceTemplateRoot;

	private string mstrWindowName = null;

	private static Hashtable mobjControllers;

	private static Hashtable mobjControllerHashes;

	private static int mintControllerId;

	private static string mstrLock;

	private bool HasKLinks => mobjHtmlHelpSystem.HasKLinks;

	private bool HasALinks => mobjHtmlHelpSystem.HasALinks;

	public CHMExplorerNode Root => mobjCHMRootNode;

	public string FilePath => mstrCHMFilePath;

	public CHMExplorerNode DefaultNode
	{
		get
		{
			if (mobjCHMDefaultNode == null && mobjHtmlHelpSystem != null)
			{
				string defaultTopic = mobjHtmlHelpSystem.DefaultTopic;
				if (defaultTopic != null && defaultTopic.IndexOf("::/") > -1)
				{
					defaultTopic = defaultTopic.Substring(defaultTopic.IndexOf("::/") + 3).ToLower();
					mobjCHMDefaultNode = GetNode(defaultTopic);
				}
			}
			return mobjCHMDefaultNode;
		}
	}

	public string DefaultLocal
	{
		get
		{
			if (mstrCHMDefaultLocal == null && mobjHtmlHelpSystem != null)
			{
				string defaultTopic = mobjHtmlHelpSystem.DefaultTopic;
				if (defaultTopic != null && defaultTopic.IndexOf("::/") > -1)
				{
					mstrCHMDefaultLocal = defaultTopic.Substring(defaultTopic.IndexOf("::/") + 3).ToLower();
				}
			}
			return mstrCHMDefaultLocal;
		}
	}

	public string Title
	{
		get
		{
			if (mstrWindowName == null && mobjHtmlHelpSystem.FileList.Length != 0)
			{
				mstrWindowName = mobjHtmlHelpSystem.FileList[0].HelpWindowTitle;
			}
			return mstrWindowName;
		}
	}

	public static string RedirectionTemplateRoot => mstrRedirectionTemplateRoot;

	public static string ResourceTemplateRoot => mstrResourceTemplateRoot;

	static CHMExplorerController()
	{
		mobjStaticGatewayContentHandle = null;
		mstrRedirectionTemplateRoot = null;
		mobjStaticGatewayResourceHandle = null;
		mstrResourceTemplateRoot = null;
		mobjControllers = new Hashtable();
		mobjControllerHashes = new Hashtable();
		mintControllerId = 1;
		mstrLock = "lock";
		mobjStaticGatewayContentHandle = new StaticGatewayResourceHandle("Gizmox.CHMContent", typeof(CHMContent));
		mstrRedirectionTemplateRoot = mobjStaticGatewayContentHandle.ToString();
		mobjStaticGatewayResourceHandle = new StaticGatewayResourceHandle("Gizmox.CHMResource", typeof(CHMResource));
		mstrResourceTemplateRoot = mobjStaticGatewayResourceHandle.ToString();
	}

	public CHMExplorerController()
	{
		mobjCHMItemsHash = new Hashtable();
	}

	public void Load(string strPath)
	{
		mobjHtmlHelpSystem = new HtmlHelpSystem(strPath);
		mstrCHMFilePath = strPath;
		mobjCHMRootNode = new CHMExplorerNode(this, null);
		mobjCHMRootNode.Load(mobjHtmlHelpSystem.TableOfContents.TOC);
	}

	public void Register(CHMExplorerNode objCHMExplorerNode)
	{
		mobjCHMItemsHash[objCHMExplorerNode.Local] = objCHMExplorerNode;
	}

	public CHMExplorerNode GetNode(string strNodeId)
	{
		return mobjCHMItemsHash[strNodeId] as CHMExplorerNode;
	}

	private string GetSafeName(string strName)
	{
		return strName.Replace(" ", "_");
	}

	public DataTable PerformSearch(string strWords, int intMaxResults, bool blnPartialMatches, bool blnTitleOnly)
	{
		return mobjHtmlHelpSystem.PerformSearch(strWords, intMaxResults, blnPartialMatches, blnTitleOnly);
	}

	public IndexItem PerformSingleIndexSearch(string search)
	{
		if (HasKLinks || HasALinks)
		{
			IndexType typeOfIndex = ((!HasKLinks) ? IndexType.AssiciativeLinks : IndexType.KeywordLinks);
			return mobjHtmlHelpSystem.Index.SearchIndex(search, typeOfIndex);
		}
		return null;
	}

	public ArrayList PerformIndexSearch(string strWildcard, int intMaxResults)
	{
		ArrayList arrayList = null;
		if (HasKLinks)
		{
			arrayList = mobjHtmlHelpSystem.Index.KLinks;
		}
		else if (HasALinks)
		{
			arrayList = mobjHtmlHelpSystem.Index.ALinks;
		}
		ArrayList arrayList2 = new ArrayList();
		if (arrayList != null)
		{
			int num = 0;
			string value = strWildcard.ToLower(CultureInfo.InvariantCulture);
			foreach (IndexItem item in arrayList)
			{
				string text = item.KeyWord.ToLower(CultureInfo.InvariantCulture);
				if (text.StartsWith(value))
				{
					arrayList2.Add(item);
					num++;
				}
				if (intMaxResults <= num)
				{
					break;
				}
			}
		}
		return arrayList2;
	}

	public void WriteResource(HostResponse objResponse, string strLocal)
	{
		mobjHtmlHelpSystem.WriteFile(objResponse, strLocal);
	}

	public string ReadFromFile(string strLocal)
	{
		if (mobjHtmlHelpSystem != null)
		{
			return mobjHtmlHelpSystem.ReadFromFile(strLocal);
		}
		return null;
	}

	public static string ExtractLocal(string strUrl)
	{
		string text = strUrl;
		if (strUrl.IndexOf("::/") > -1)
		{
			text = text.Substring(text.IndexOf("::/") + 3).ToLower();
		}
		return text;
	}

	public static string Create(string strPath, string strStaticHash)
	{
		strPath = strPath.ToLower();
		string text = (string)mobjControllerHashes[strPath];
		if (text == null)
		{
			lock (mstrLock)
			{
				text = (string)mobjControllerHashes[strPath];
				if (text == null)
				{
					try
					{
						CHMExplorerController cHMExplorerController = new CHMExplorerController();
						cHMExplorerController.Load(strPath);
						if (CommonUtils.IsNullOrEmpty(strStaticHash))
						{
							text = (string)(mobjControllerHashes[strPath] = mintControllerId.ToString());
							mobjControllers[text] = cHMExplorerController;
							mintControllerId++;
						}
						else
						{
							mobjControllerHashes[strPath] = strStaticHash;
							mobjControllers[strStaticHash] = cHMExplorerController;
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
		return text;
	}

	public static CHMExplorerController Get(string strHash)
	{
		return mobjControllers[strHash] as CHMExplorerController;
	}
}
