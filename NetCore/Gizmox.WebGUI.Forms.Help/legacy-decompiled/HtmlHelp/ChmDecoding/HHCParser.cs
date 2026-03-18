using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace HtmlHelp.ChmDecoding;

internal sealed class HHCParser
{
	private static string RE_ULOpening = "\\<ul\\>";

	private static string RE_ULClosing = "\\</ul\\>";

	private static string RE_ULBoundaries = "\\<ul\\>(?<innerText>.*)\\</ul\\>";

	private static string RE_NestedBoundaries = "\\( (?> [^()]+ | \\( (?<DEPTH>) | \\) (?<-DEPTH>) )* (?(DEPTH)(?!)) \\)";

	private static string RE_ObjectBoundaries = "\\<object(?<innerText>.*?)\\</object\\>";

	private static string RE_ParamBoundaries = "\\<param(?<innerText>.*?)\\>";

	private const string RE_QuoteAttributes = "( |\\t)*(?<attributeName>[\\-a-zA-Z0-9]*)( |\\t)*=( |\\t)*(?<attributeTD>[\\\"\\'])?(?<attributeValue>.*?(?(attributeTD)\\k<attributeTD>|([\\s>]|.$)))";

	private static Regex ulRE;

	private static Regex NestedRE;

	private static Regex ObjectRE;

	private static Regex ParamRE;

	private static Regex AttributesRE;

	private static ArrayList _mergeItems = null;

	private static TOCItem _lastTopicItem = null;

	public static bool HasMergeLinks
	{
		get
		{
			if (_mergeItems == null)
			{
				return false;
			}
			return _mergeItems.Count > 0;
		}
	}

	public static ArrayList MergeItems => _mergeItems;

	public static ArrayList ParseHHC(string hhcFile, CHMFile chmFile)
	{
		_lastTopicItem = null;
		_mergeItems = null;
		ArrayList arrayList = new ArrayList();
		ulRE = new Regex(RE_ULBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		NestedRE = new Regex(RE_NestedBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		ObjectRE = new Regex(RE_ObjectBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		ParamRE = new Regex(RE_ParamBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		AttributesRE = new Regex("( |\\t)*(?<attributeName>[\\-a-zA-Z0-9]*)( |\\t)*=( |\\t)*(?<attributeTD>[\\\"\\'])?(?<attributeValue>.*?(?(attributeTD)\\k<attributeTD>|([\\s>]|.$)))", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		int num = ulRE.GroupNumberFromName("innerText");
		if (ulRE.IsMatch(hhcFile, 0))
		{
			Match match = ulRE.Match(hhcFile, 0);
			int num2 = 0;
			num2 = hhcFile.ToLower().IndexOf("<ul>");
			if (num2 == -1)
			{
				num2 = hhcFile.ToLower().IndexOf("<il>");
			}
			if (ObjectRE.IsMatch(hhcFile, 0))
			{
				Match match2 = ObjectRE.Match(hhcFile, 0);
				int groupnum = ObjectRE.GroupNumberFromName("innerText");
				string value = match2.Groups[groupnum].Value;
				if (match2.Groups[groupnum].Index <= num2)
				{
					ParseGlobalSettings(value, chmFile);
				}
			}
			string value2 = match.Groups["innerText"].Value;
			value2 = value2.Replace("(", "&#040;");
			value2 = value2.Replace(")", "&#041;");
			value2 = Regex.Replace(value2, RE_ULOpening, "(", RegexOptions.IgnoreCase);
			value2 = Regex.Replace(value2, RE_ULClosing, ")", RegexOptions.IgnoreCase);
			ParseTree(value2, null, arrayList, chmFile);
		}
		return arrayList;
	}

	public static bool HasGlobalObjectTag(string hhcFile, CHMFile chmFile)
	{
		bool result = false;
		ulRE = new Regex(RE_ULBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		ObjectRE = new Regex(RE_ObjectBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		int num = ulRE.GroupNumberFromName("innerText");
		if (ulRE.IsMatch(hhcFile, 0))
		{
			Match match = ulRE.Match(hhcFile, 0);
			int num2 = 0;
			num2 = hhcFile.ToLower().IndexOf("<ul>");
			if (num2 == -1)
			{
				num2 = hhcFile.ToLower().IndexOf("<il>");
			}
			if (ObjectRE.IsMatch(hhcFile, 0))
			{
				Match match2 = ObjectRE.Match(hhcFile, 0);
				int groupnum = ObjectRE.GroupNumberFromName("innerText");
				string value = match2.Groups[groupnum].Value;
				if (match2.Groups[groupnum].Index <= num2)
				{
					result = true;
				}
			}
		}
		return result;
	}

	private static void ParseTree(string text, TOCItem parent, ArrayList arrNodes, CHMFile chmFile)
	{
		string text2 = "";
		string text3 = "";
		string text4 = "";
		int num = 0;
		while (NestedRE.IsMatch(text, num))
		{
			Match match = NestedRE.Match(text, num);
			text4 = match.Value.Substring(1, match.Length - 2);
			text2 = text.Substring(num, match.Index - num);
			ParseItems(text2, parent, arrNodes, chmFile);
			if (arrNodes.Count > 0 && text4.Length > 0)
			{
				TOCItem tOCItem = (TOCItem)arrNodes[arrNodes.Count - 1];
				ParseTree(text4, tOCItem, tOCItem.Children, chmFile);
			}
			num = match.Index + match.Length;
		}
		if (num == 0)
		{
			text3 = text.Substring(num, text.Length - num);
			ParseItems(text3, parent, arrNodes, chmFile);
		}
		else if (num < text.Length - 1)
		{
			text3 = text.Substring(num, text.Length - num);
			ParseTree(text3, parent, arrNodes, chmFile);
		}
	}

	private static void ParseItems(string itemstext, TOCItem parent, ArrayList arrNodes, CHMFile chmFile)
	{
		int groupnum = ObjectRE.GroupNumberFromName("innerText");
		int groupnum2 = ParamRE.GroupNumberFromName("innerText");
		int groupnum3 = AttributesRE.GroupNumberFromName("attributeName");
		int groupnum4 = AttributesRE.GroupNumberFromName("attributeValue");
		int groupnum5 = AttributesRE.GroupNumberFromName("attributeTD");
		int startat = 0;
		while (ObjectRE.IsMatch(itemstext, startat))
		{
			Match match = ObjectRE.Match(itemstext, startat);
			string value = match.Groups[groupnum].Value;
			TOCItem tOCItem = new TOCItem();
			tOCItem.TocMode = DataMode.TextBased;
			tOCItem.AssociatedFile = chmFile;
			tOCItem.Parent = parent;
			int startat2 = 0;
			while (ParamRE.IsMatch(value, startat2))
			{
				Match match2 = ParamRE.Match(value, startat2);
				string value2 = match2.Groups[groupnum2].Value;
				string text = "";
				string text2 = "";
				int startat3 = 0;
				while (AttributesRE.IsMatch(value2, startat3))
				{
					Match match3 = AttributesRE.Match(value2, startat3);
					string value3 = match3.Groups[groupnum3].Value;
					string text3 = match3.Groups[groupnum4].Value;
					string value4 = match3.Groups[groupnum5].Value;
					if (value4.Length > 0 && text3.Length > 0)
					{
						int num = text3.LastIndexOf(value4);
						if (num >= 0)
						{
							text3 = text3.Substring(0, num);
						}
					}
					if (value3.ToLower() == "name")
					{
						text = HttpUtility.HtmlDecode(text3);
					}
					if (value3.ToLower() == "value")
					{
						text2 = HttpUtility.HtmlDecode(text3);
						while (text2.Length > 0 && text2[text2.Length - 1] == '/')
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
					}
					startat3 = match3.Index + match3.Length;
				}
				tOCItem.Params[text] = text2;
				switch (text.ToLower())
				{
				case "name":
					tOCItem.Name = text2;
					break;
				case "local":
					tOCItem.Local = text2.Replace("../", "").Replace("./", "");
					break;
				case "imagenumber":
				{
					tOCItem.ImageIndex = int.Parse(text2);
					tOCItem.ImageIndex--;
					int num2 = 0;
					if (chmFile != null && chmFile.ImageTypeFolder)
					{
						num2 = ((!HtmlHelpSystem.UseHH2TreePics) ? 4 : 8);
					}
					if (tOCItem.ImageIndex % 2 != 0 && tOCItem.ImageIndex == 1)
					{
						tOCItem.ImageIndex = 0;
					}
					if (HtmlHelpSystem.UseHH2TreePics && tOCItem.ImageIndex == 0)
					{
						tOCItem.ImageIndex = 4 + num2;
					}
					break;
				}
				case "merge":
					tOCItem.MergeLink = text2;
					if (_mergeItems == null)
					{
						_mergeItems = new ArrayList();
					}
					_mergeItems.Add(tOCItem);
					break;
				case "type":
					tOCItem.InfoTypeStrings.Add(text2);
					break;
				}
				startat2 = match2.Index + match2.Length;
			}
			tOCItem.ChmFile = chmFile.ChmFilePath;
			if (tOCItem.MergeLink.Length > 0)
			{
				if (_lastTopicItem != null)
				{
					tOCItem.Parent = _lastTopicItem;
					_lastTopicItem.Children.Add(tOCItem);
				}
				else
				{
					arrNodes.Add(tOCItem);
				}
			}
			else
			{
				_lastTopicItem = tOCItem;
				arrNodes.Add(tOCItem);
			}
			startat = match.Index + match.Length;
		}
	}

	private static void ParseGlobalSettings(string sText, CHMFile chmFile)
	{
		int groupnum = ParamRE.GroupNumberFromName("innerText");
		int groupnum2 = AttributesRE.GroupNumberFromName("attributeName");
		int groupnum3 = AttributesRE.GroupNumberFromName("attributeValue");
		int groupnum4 = AttributesRE.GroupNumberFromName("attributeTD");
		int startat = 0;
		int num = 0;
		string text = "";
		string text2 = "";
		string name = "";
		while (ParamRE.IsMatch(sText, startat))
		{
			Match match = ParamRE.Match(sText, startat);
			string value = match.Groups[groupnum].Value;
			string text3 = "";
			string text4 = "";
			int startat2 = 0;
			while (AttributesRE.IsMatch(value, startat2))
			{
				Match match2 = AttributesRE.Match(value, startat2);
				string value2 = match2.Groups[groupnum2].Value;
				string text5 = match2.Groups[groupnum3].Value;
				string value3 = match2.Groups[groupnum4].Value;
				if (value3.Length > 0 && text5.Length > 0)
				{
					int num2 = text5.LastIndexOf(value3);
					if (num2 >= 0)
					{
						text5 = text5.Substring(0, num2);
					}
				}
				if (value2.ToLower() == "name")
				{
					text3 = HttpUtility.HtmlDecode(text5);
				}
				if (value2.ToLower() == "value")
				{
					text4 = HttpUtility.HtmlDecode(text5);
					while (text4.Length > 0 && text4[text4.Length - 1] == '/')
					{
						text4 = text4.Substring(0, text4.Length - 1);
					}
				}
				startat2 = match2.Index + match2.Length;
			}
			switch (text3.ToLower())
			{
			case "savetype":
				num = 1;
				text = text4;
				break;
			case "savetypedesc":
			{
				InformationTypeMode mode = InformationTypeMode.Inclusive;
				text2 = text4;
				if (num == 1)
				{
					mode = InformationTypeMode.Inclusive;
				}
				if (num == 2)
				{
					mode = InformationTypeMode.Exclusive;
				}
				if (num == 3)
				{
					mode = InformationTypeMode.Hidden;
				}
				if (chmFile.GetInformationType(text) == null)
				{
					if (chmFile.SystemInstance.GetInformationType(text) == null)
					{
						InformationType value4 = new InformationType(text, text2, mode);
						chmFile.InformationTypes.Add(value4);
					}
					else
					{
						InformationType informationType2 = chmFile.SystemInstance.GetInformationType(text);
						chmFile.InformationTypes.Add(informationType2);
					}
				}
				num = 0;
				break;
			}
			case "saveexclusive":
				num = 2;
				text = text4;
				break;
			case "savehidden":
				num = 3;
				text = text4;
				break;
			case "category":
				num = 4;
				text = text4;
				name = text;
				break;
			case "categorydesc":
				text2 = text4;
				if (chmFile.GetCategory(text) == null)
				{
					if (chmFile.SystemInstance.GetCategory(text) == null)
					{
						Category value5 = new Category(text, text2);
						chmFile.Categories.Add(value5);
					}
					else
					{
						Category category2 = chmFile.SystemInstance.GetCategory(text);
						chmFile.Categories.Add(category2);
					}
				}
				num = 0;
				break;
			case "type":
				num = 5;
				text = text4;
				break;
			case "typedesc":
			{
				text2 = text4;
				Category category = chmFile.GetCategory(name);
				if (category != null)
				{
					InformationType informationType = chmFile.GetInformationType(text);
					if (informationType != null && !category.ContainsInformationType(informationType))
					{
						informationType.SetCategoryFlag(newValue: true);
						category.AddInformationType(informationType);
					}
				}
				num = 0;
				break;
			}
			case "typeexclusive":
				num = 6;
				text = text4;
				break;
			case "typehidden":
				num = 7;
				text = text4;
				break;
			default:
				num = 0;
				text = "";
				text2 = "";
				break;
			}
			startat = match.Index + match.Length;
		}
	}
}
