using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace HtmlHelp.ChmDecoding;

internal sealed class HHKParser
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

	public static ArrayList ParseHHK(string hhkFile, CHMFile chmFile)
	{
		ArrayList arrayList = new ArrayList();
		ulRE = new Regex(RE_ULBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		NestedRE = new Regex(RE_NestedBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		ObjectRE = new Regex(RE_ObjectBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		ParamRE = new Regex(RE_ParamBoundaries, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		AttributesRE = new Regex("( |\\t)*(?<attributeName>[\\-a-zA-Z0-9]*)( |\\t)*=( |\\t)*(?<attributeTD>[\\\"\\'])?(?<attributeValue>.*?(?(attributeTD)\\k<attributeTD>|([\\s>]|.$)))", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		int num = ulRE.GroupNumberFromName("innerText");
		if (ulRE.IsMatch(hhkFile, 0))
		{
			Match match = ulRE.Match(hhkFile, 0);
			if (ObjectRE.IsMatch(hhkFile, 0))
			{
				Match match2 = ObjectRE.Match(hhkFile, 0);
				int groupnum = ObjectRE.GroupNumberFromName("innerText");
				string value = match2.Groups[groupnum].Value;
				ParseGlobalSettings(value, chmFile);
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

	private static void ParseTree(string text, IndexItem parent, ArrayList arrNodes, CHMFile chmFile)
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
				IndexItem parent2 = (IndexItem)arrNodes[arrNodes.Count - 1];
				ParseTree(text4, parent2, arrNodes, chmFile);
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

	private static void ParseItems(string itemstext, IndexItem parentItem, ArrayList arrNodes, CHMFile chmFile)
	{
		int groupnum = ObjectRE.GroupNumberFromName("innerText");
		int groupnum2 = ParamRE.GroupNumberFromName("innerText");
		int groupnum3 = AttributesRE.GroupNumberFromName("attributeName");
		int groupnum4 = AttributesRE.GroupNumberFromName("attributeValue");
		int groupnum5 = AttributesRE.GroupNumberFromName("attributeTD");
		int num = 0;
		int num2 = 0;
		string text = "";
		while (ObjectRE.IsMatch(itemstext, num))
		{
			Match match = ObjectRE.Match(itemstext, num);
			string value = match.Groups[groupnum].Value;
			IndexItem indexItem = new IndexItem();
			int startat = 0;
			int num3 = 0;
			string title = "";
			string local = "";
			bool flag = false;
			while (ParamRE.IsMatch(value, startat))
			{
				Match match2 = ParamRE.Match(value, startat);
				string value2 = match2.Groups[groupnum2].Value;
				string text2 = "";
				string text3 = "";
				int startat2 = 0;
				while (AttributesRE.IsMatch(value2, startat2))
				{
					Match match3 = AttributesRE.Match(value2, startat2);
					string value3 = match3.Groups[groupnum3].Value;
					string text4 = match3.Groups[groupnum4].Value;
					string value4 = match3.Groups[groupnum5].Value;
					if (value4.Length > 0 && text4.Length > 0)
					{
						int num4 = text4.LastIndexOf(value4);
						if (num4 >= 0)
						{
							text4 = text4.Substring(0, num4);
						}
					}
					if (value3.ToLower() == "name")
					{
						text2 = HttpUtility.HtmlDecode(text4);
						num3++;
					}
					if (value3.ToLower() == "value")
					{
						text3 = HttpUtility.HtmlDecode(text4);
						while (text3.Length > 0 && text3[text3.Length - 1] == '/')
						{
							text3 = text3.Substring(0, text3.Length - 1);
						}
					}
					startat2 = match3.Index + match3.Length;
				}
				if (num3 == 1)
				{
					text = "";
					if (parentItem != null)
					{
						text = parentItem.KeyWordPath + ",";
					}
					string text5 = text;
					text += text3;
					IndexItem indexItem2 = FindByKeyword(arrNodes, text);
					if (indexItem2 != null)
					{
						indexItem = indexItem2;
					}
					else
					{
						if (text.Split(',').Length > 1)
						{
							indexItem.CharIndex = text.Length - text3.Length;
						}
						else
						{
							text = text3;
							text5 = text;
							indexItem.CharIndex = 0;
						}
						indexItem.KeyWordPath = text;
						indexItem.Indent = text.Split(',').Length - 1;
						indexItem.IsSeeAlso = false;
						text = text5;
					}
				}
				else
				{
					if (num3 > 2 && text2.ToLower() == "name")
					{
						flag = true;
						IndexTopic value5 = new IndexTopic(title, local, chmFile.CompileFile, chmFile.ChmFilePath);
						indexItem.Topics.Add(value5);
						title = "";
						local = "";
					}
					switch (text2.ToLower())
					{
					case "name":
						title = text3;
						break;
					case "local":
						local = text3.Replace("../", "").Replace("./", "");
						break;
					case "type":
						indexItem.InfoTypeStrings.Add(text3);
						break;
					case "see also":
						indexItem.AddSeeAlso(text3);
						indexItem.IsSeeAlso = true;
						flag = true;
						break;
					}
				}
				startat = match2.Index + match2.Length;
			}
			if (!flag)
			{
				flag = false;
				IndexTopic value6 = new IndexTopic(title, local, chmFile.CompileFile, chmFile.ChmFilePath);
				indexItem.Topics.Add(value6);
				title = "";
				local = "";
			}
			indexItem.ChmFile = chmFile;
			arrNodes.Add(indexItem);
			num2 = num;
			num = match.Index + match.Length;
		}
	}

	private static IndexItem FindByKeyword(ArrayList indexList, string Keyword)
	{
		foreach (IndexItem index in indexList)
		{
			if (index.KeyWordPath == Keyword)
			{
				return index;
			}
		}
		return null;
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
