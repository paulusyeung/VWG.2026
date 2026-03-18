#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;
using HtmlHelp.ChmDecoding;

namespace HtmlHelp;

public class TableOfContents
{
	private ArrayList _toc = new ArrayList();

	public ArrayList TOC => _toc;

	public TableOfContents()
	{
	}

	public TableOfContents(ArrayList toc)
	{
		_toc = toc;
	}

	public void Clear()
	{
		if (_toc != null)
		{
			_toc.Clear();
		}
	}

	public int Count()
	{
		if (_toc != null)
		{
			return _toc.Count;
		}
		return 0;
	}

	internal void MergeToC(ArrayList arrToC)
	{
		if (_toc == null)
		{
			_toc = new ArrayList();
		}
		Debug.WriteLine("TableOfContents.MergeToC() ");
		Debug.Indent();
		Debug.WriteLine("Start: " + DateTime.Now.ToString("HH:mm:ss.ffffff"));
		MergeToC(_toc, arrToC, null);
		Debug.WriteLine("End: " + DateTime.Now.ToString("HH:mm:ss.ffffff"));
		Debug.Unindent();
	}

	internal void MergeToC(ArrayList arrToC, ArrayList openFiles)
	{
		if (_toc == null)
		{
			_toc = new ArrayList();
		}
		Debug.WriteLine("TableOfContents.MergeToC() ");
		Debug.Indent();
		Debug.WriteLine("Start: " + DateTime.Now.ToString("HH:mm:ss.ffffff"));
		MergeToC(_toc, arrToC, openFiles);
		Debug.WriteLine("End: " + DateTime.Now.ToString("HH:mm:ss.ffffff"));
		Debug.Unindent();
	}

	private void MergeToC(ArrayList globalLevel, ArrayList localLevel, ArrayList openFiles)
	{
		foreach (TOCItem item in localLevel)
		{
			if (IsMergedItem(item.Name, item.Local, openFiles))
			{
				continue;
			}
			TOCItem tOCItem2 = ContainsToC(globalLevel, item.Name);
			if (tOCItem2 == null)
			{
				globalLevel.Add(item);
				continue;
			}
			if (tOCItem2.Local.Length <= 0 && item.Local.Length > 0)
			{
				tOCItem2.Local = item.Local;
				tOCItem2.ChmFile = item.ChmFile;
			}
			MergeToC(tOCItem2.Children, item.Children);
		}
	}

	private bool IsMergedItem(string name, string local, ArrayList openFiles)
	{
		if (openFiles == null)
		{
			return false;
		}
		foreach (CHMFile openFile in openFiles)
		{
			foreach (TOCItem mergLink in openFile.MergLinks)
			{
				if (mergLink.Name == name && mergLink.Local == local)
				{
					return true;
				}
			}
		}
		return false;
	}

	private TOCItem ContainsToC(ArrayList arrToC, string Topic)
	{
		foreach (TOCItem item in arrToC)
		{
			if (item.Name == Topic)
			{
				return item;
			}
		}
		return null;
	}

	public TOCItem SearchTopic(string topic)
	{
		return SearchTopic(topic, _toc);
	}

	private TOCItem SearchTopic(string topic, ArrayList searchIn)
	{
		foreach (TOCItem item in searchIn)
		{
			if (item.Name.ToLower() == topic.ToLower())
			{
				return item;
			}
			if (item.Children.Count > 0)
			{
				TOCItem tOCItem2 = SearchTopic(topic, item.Children);
				if (tOCItem2 != null)
				{
					return tOCItem2;
				}
			}
		}
		return null;
	}
}
