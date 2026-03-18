#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;

namespace HtmlHelp;

public class Index
{
	private ArrayList _kLinks = new ArrayList();

	private ArrayList _aLinks = new ArrayList();

	public ArrayList KLinks
	{
		get
		{
			if (_kLinks == null)
			{
				_kLinks = new ArrayList();
			}
			return _kLinks;
		}
	}

	public ArrayList ALinks
	{
		get
		{
			if (_aLinks == null)
			{
				_aLinks = new ArrayList();
			}
			return _aLinks;
		}
	}

	public Index()
	{
	}

	public Index(ArrayList kLinks, ArrayList aLinks)
	{
		_kLinks = kLinks;
		_aLinks = aLinks;
	}

	public void Clear()
	{
		if (_aLinks != null)
		{
			_aLinks.Clear();
		}
		if (_kLinks != null)
		{
			_kLinks.Clear();
		}
	}

	public int Count(IndexType typeOfIndex)
	{
		ArrayList arrayList = null;
		switch (typeOfIndex)
		{
		case IndexType.AssiciativeLinks:
			arrayList = _aLinks;
			break;
		case IndexType.KeywordLinks:
			arrayList = _kLinks;
			break;
		}
		return arrayList?.Count ?? 0;
	}

	public void MergeIndex(ArrayList arrIndex, IndexType typeOfIndex)
	{
		ArrayList arrayList = null;
		switch (typeOfIndex)
		{
		case IndexType.AssiciativeLinks:
			arrayList = _aLinks;
			break;
		case IndexType.KeywordLinks:
			arrayList = _kLinks;
			break;
		}
		Debug.WriteLine("Index.MergeIndex() ");
		Debug.Indent();
		DateTime now = DateTime.Now;
		foreach (IndexItem item in arrIndex)
		{
			int insertIndex = 0;
			IndexItem indexItem2 = BinSearch(0, arrayList.Count - 1, arrayList, item.KeyWordPath, searchKeyword: false, caseInsensitive: false, ref insertIndex);
			if (indexItem2 != null)
			{
				foreach (IndexTopic topic in item.Topics)
				{
					indexItem2.Topics.Add(topic);
				}
			}
			else if (insertIndex > arrayList.Count)
			{
				arrayList.Add(item);
			}
			else
			{
				arrayList.Insert(insertIndex, item);
			}
		}
		DateTime now2 = DateTime.Now;
		Debug.WriteLine("--- Merge completed in " + (now2 - now).ToString());
		Debug.Unindent();
	}

	private IndexItem BinSearch(int nStart, int nEnd, ArrayList arrIndex, string keywordPath, bool searchKeyword, bool caseInsensitive, ref int insertIndex)
	{
		if (arrIndex.Count <= 0)
		{
			insertIndex = 0;
			return null;
		}
		if (caseInsensitive)
		{
			keywordPath = keywordPath.ToLower();
		}
		if (nEnd - nStart > 1)
		{
			int num = nStart + (nEnd - nStart) / 2;
			IndexItem indexItem = arrIndex[num] as IndexItem;
			string text = indexItem.KeyWordPath;
			if (searchKeyword)
			{
				text = indexItem.KeyWord;
			}
			if (caseInsensitive)
			{
				text = text.ToLower();
			}
			if (text == keywordPath)
			{
				insertIndex = -1;
				return indexItem;
			}
			if (keywordPath.CompareTo(text) < 0)
			{
				return BinSearch(nStart, num - 1, arrIndex, keywordPath, searchKeyword, caseInsensitive, ref insertIndex);
			}
			if (keywordPath.CompareTo(text) > 0)
			{
				return BinSearch(num + 1, nEnd, arrIndex, keywordPath, searchKeyword, caseInsensitive, ref insertIndex);
			}
		}
		else if (nEnd - nStart == 1)
		{
			IndexItem indexItem2 = arrIndex[nStart] as IndexItem;
			IndexItem indexItem3 = arrIndex[nEnd] as IndexItem;
			string text2 = indexItem2.KeyWordPath;
			if (searchKeyword)
			{
				text2 = indexItem2.KeyWord;
			}
			if (caseInsensitive)
			{
				text2 = text2.ToLower();
			}
			string text3 = indexItem3.KeyWordPath;
			if (searchKeyword)
			{
				text3 = indexItem3.KeyWord;
			}
			if (caseInsensitive)
			{
				text3 = text3.ToLower();
			}
			if (text2 == keywordPath)
			{
				insertIndex = -1;
				return indexItem2;
			}
			if (text3 == keywordPath)
			{
				insertIndex = -1;
				return indexItem3;
			}
			if (text2.CompareTo(keywordPath) > 0)
			{
				insertIndex = nStart;
				return null;
			}
			if (text3.CompareTo(keywordPath) > 0)
			{
				insertIndex = nEnd;
				return null;
			}
			insertIndex = nEnd + 1;
		}
		IndexItem indexItem4 = arrIndex[nEnd] as IndexItem;
		string text4 = indexItem4.KeyWordPath;
		if (searchKeyword)
		{
			text4 = indexItem4.KeyWord;
		}
		if (caseInsensitive)
		{
			text4 = text4.ToLower();
		}
		if (text4.CompareTo(keywordPath) > 0)
		{
			insertIndex = nStart;
			return null;
		}
		if (text4.CompareTo(keywordPath) < 0)
		{
			insertIndex = nEnd + 1;
			return null;
		}
		insertIndex = -1;
		return arrIndex[nEnd] as IndexItem;
	}

	private IndexItem ContainsIndex(ArrayList arrIndex, string keywordPath)
	{
		foreach (IndexItem item in arrIndex)
		{
			if (item.KeyWordPath == keywordPath)
			{
				return item;
			}
		}
		return null;
	}

	public IndexItem SearchIndex(string search, IndexType typeOfIndex)
	{
		ArrayList arrayList = null;
		switch (typeOfIndex)
		{
		case IndexType.AssiciativeLinks:
			arrayList = _aLinks;
			break;
		case IndexType.KeywordLinks:
			arrayList = _kLinks;
			break;
		}
		int insertIndex = 0;
		return BinSearch(0, arrayList.Count, arrayList, search, searchKeyword: true, caseInsensitive: true, ref insertIndex);
	}
}
