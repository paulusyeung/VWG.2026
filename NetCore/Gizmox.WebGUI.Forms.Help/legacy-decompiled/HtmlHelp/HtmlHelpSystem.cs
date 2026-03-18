using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using Gizmox.WebGUI.Hosting;
using HtmlHelp.ChmDecoding;
using HtmlHelp.Storage;

namespace HtmlHelp;

public sealed class HtmlHelpSystem
{
	private static HtmlHelpSystem _current = null;

	private ArrayList _chmFiles = new ArrayList();

	private TableOfContents _toc = new TableOfContents();

	private Index _index = new Index();

	private static string _urlPrefix = "ms-its:";

	private static bool _useHH2TreePics = false;

	private ArrayList _informationTypes = new ArrayList();

	private ArrayList _categories = new ArrayList();

	public static string UrlPrefix
	{
		get
		{
			return _urlPrefix;
		}
		set
		{
			_urlPrefix = value;
		}
	}

	public static bool UseHH2TreePics
	{
		get
		{
			return _useHH2TreePics;
		}
		set
		{
			_useHH2TreePics = value;
		}
	}

	public static HtmlHelpSystem Current => _current;

	public CHMFile[] FileList
	{
		get
		{
			CHMFile[] array = new CHMFile[_chmFiles.Count];
			for (int i = 0; i < _chmFiles.Count; i++)
			{
				array[i] = (CHMFile)_chmFiles[i];
			}
			return array;
		}
	}

	public bool HasInformationTypes => _informationTypes.Count > 0;

	public bool HasCategories => _categories.Count > 0;

	public ArrayList InformationTypes => _informationTypes;

	public ArrayList Categories => _categories;

	public string DefaultTopic
	{
		get
		{
			if (_chmFiles.Count > 0)
			{
				foreach (CHMFile chmFile in _chmFiles)
				{
					if (chmFile.DefaultTopic.Length > 0)
					{
						return chmFile.FormURL(chmFile.DefaultTopic);
					}
				}
			}
			return "about:blank";
		}
	}

	public TableOfContents TableOfContents
	{
		get
		{
			if (_chmFiles.Count > 0 && _toc.Count() <= 0)
			{
				foreach (CHMFile chmFile in _chmFiles)
				{
					_toc.MergeToC(chmFile.TOC);
				}
			}
			return _toc;
		}
	}

	public Index Index
	{
		get
		{
			if (_chmFiles.Count > 0 && _index.Count(IndexType.KeywordLinks) + _index.Count(IndexType.AssiciativeLinks) <= 0)
			{
				foreach (CHMFile chmFile in _chmFiles)
				{
					_index.MergeIndex(chmFile.IndexKLinks, IndexType.KeywordLinks);
					_index.MergeIndex(chmFile.IndexALinks, IndexType.AssiciativeLinks);
				}
			}
			return _index;
		}
	}

	public bool HasTableOfContents => TableOfContents.Count() > 0;

	public bool HasIndex => HasALinks || HasKLinks;

	public bool HasKLinks => _index.Count(IndexType.KeywordLinks) > 0;

	public bool HasALinks => _index.Count(IndexType.AssiciativeLinks) > 0;

	public bool FullTextSearch
	{
		get
		{
			bool flag = false;
			foreach (CHMFile chmFile in _chmFiles)
			{
				flag |= chmFile.FullTextSearch;
			}
			return flag;
		}
	}

	public HtmlHelpSystem()
		: this("")
	{
	}

	public HtmlHelpSystem(string chmFile)
	{
		_current = this;
		OpenFile(chmFile);
	}

	public void OpenFile(string chmFile)
	{
		OpenFile(chmFile, null);
	}

	public void OpenFile(string chmFile, DumpingInfo dmpInfo)
	{
		if (!File.Exists(chmFile))
		{
			return;
		}
		_chmFiles.Clear();
		_toc.Clear();
		_index.Clear();
		_informationTypes.Clear();
		_categories.Clear();
		CHMFile cHMFile = new CHMFile(this, chmFile, dmpInfo);
		_toc = new TableOfContents(cHMFile.TOC);
		_index = new Index(cHMFile.IndexKLinks, cHMFile.IndexALinks);
		_chmFiles.Add(cHMFile);
		MergeFileInfoTypesCategories(cHMFile);
		if (cHMFile.MergedFiles.Length == 0)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(chmFile);
		string directoryName = fileInfo.DirectoryName;
		for (int i = 0; i < cHMFile.MergedFiles.Length; i++)
		{
			string text = cHMFile.MergedFiles[i];
			if (text.Length > 0)
			{
				if (text[1] != ':')
				{
					text = Path.Combine(directoryName, text);
				}
				MergeFile(text, dmpInfo, mergedFileList: true);
			}
		}
		if (cHMFile.MergLinks.Count > 0)
		{
			RecalculateMergeLinks(cHMFile);
		}
		RemoveMergeLinks();
	}

	public void MergeFile(string chmFile)
	{
		MergeFile(chmFile, null);
	}

	public void MergeFile(string chmFile, DumpingInfo dmpInfo)
	{
		MergeFile(chmFile, dmpInfo, mergedFileList: false);
	}

	internal void MergeFile(string chmFile, DumpingInfo dmpInfo, bool mergedFileList)
	{
		if (!File.Exists(chmFile))
		{
			return;
		}
		if (_chmFiles.Count == 1)
		{
			ArrayList tOC = _toc.TOC;
			ArrayList aLinks = _index.ALinks;
			ArrayList kLinks = _index.KLinks;
			_toc = new TableOfContents();
			_index = new Index();
			_toc.MergeToC(tOC);
			_index.MergeIndex(aLinks, IndexType.AssiciativeLinks);
			_index.MergeIndex(kLinks, IndexType.KeywordLinks);
		}
		CHMFile cHMFile = new CHMFile(this, chmFile, dmpInfo);
		if (mergedFileList)
		{
			RecalculateMergeLinks(cHMFile);
			_toc.MergeToC(cHMFile.TOC, _chmFiles);
			_index.MergeIndex(cHMFile.IndexALinks, IndexType.AssiciativeLinks);
			_index.MergeIndex(cHMFile.IndexKLinks, IndexType.KeywordLinks);
			_chmFiles.Add(cHMFile);
			MergeFileInfoTypesCategories(cHMFile);
			return;
		}
		_toc.MergeToC(cHMFile.TOC, _chmFiles);
		_index.MergeIndex(cHMFile.IndexALinks, IndexType.AssiciativeLinks);
		_index.MergeIndex(cHMFile.IndexKLinks, IndexType.KeywordLinks);
		_chmFiles.Add(cHMFile);
		MergeFileInfoTypesCategories(cHMFile);
		if (cHMFile.MergedFiles.Length == 0)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(chmFile);
		string directoryName = fileInfo.DirectoryName;
		for (int i = 0; i < cHMFile.MergedFiles.Length; i++)
		{
			string text = cHMFile.MergedFiles[i];
			if (text.Length > 0)
			{
				if (text[1] != ':')
				{
					text = Path.Combine(directoryName, text);
				}
				MergeFile(text, dmpInfo, mergedFileList: true);
			}
		}
		RemoveMergeLinks();
	}

	internal void RecalculateMergeLinks(CHMFile currentFile)
	{
		foreach (CHMFile chmFile in _chmFiles)
		{
			if (chmFile.MergLinks.Count <= 0)
			{
				continue;
			}
			for (int i = 0; i < chmFile.MergLinks.Count; i++)
			{
				TOCItem tOCItem = chmFile.MergLinks[i] as TOCItem;
				string mergeLink = tOCItem.MergeLink;
				string[] array = mergeLink.Split(':');
				string text = "";
				string text2 = "";
				if (array.Length > 3)
				{
					text = array[0] + ":" + array[1];
					text2 = array[3];
				}
				else if (array.Length == 3)
				{
					FileInfo fileInfo = new FileInfo(currentFile.ChmFilePath);
					string directoryName = fileInfo.DirectoryName;
					string text3 = array[0];
					if (text3.Length > 0 && text3[1] != ':')
					{
						text3 = Path.Combine(directoryName, text3);
					}
					text = text3;
					text2 = array[2];
				}
				ArrayList arrayList = null;
				if (text.Length <= 0 || text2.Length <= 0 || !(text.ToLower() == currentFile.ChmFilePath.ToLower()))
				{
					continue;
				}
				if (text2.ToLower().IndexOf(".hhc") >= 0)
				{
					string text4 = text2;
					while (text4[0] == '.' || text4[0] == '/')
					{
						text4 = text4.Substring(1);
					}
					if (currentFile.ContentsFile.ToLower() != text4)
					{
						arrayList = currentFile.ParseHHC(text2);
						if (arrayList.Count <= 0)
						{
						}
					}
					else
					{
						arrayList = currentFile.TOC;
					}
					int num = 0;
					foreach (TOCItem item in arrayList)
					{
						if (num == 0)
						{
							tOCItem.AssociatedFile = currentFile;
							tOCItem.Children = item.Children;
							tOCItem.ChmFile = currentFile.ChmFilePath;
							tOCItem.ImageIndex = item.ImageIndex;
							tOCItem.Local = item.Local;
							tOCItem.MergeLink = item.MergeLink;
							tOCItem.Name = item.Name;
							tOCItem.TocMode = item.TocMode;
							tOCItem.TopicOffset = item.TopicOffset;
							MarkChildrenAdded(item.Children, chmFile.MergLinks);
						}
						else
						{
							ArrayList arrayList2 = null;
							arrayList2 = ((tOCItem.Parent == null) ? chmFile.TOC : tOCItem.Parent.Children);
							int num2 = arrayList2.IndexOf(tOCItem);
							if (num2 + num > arrayList2.Count)
							{
								arrayList2.Add(item);
							}
							else
							{
								arrayList2.Insert(num2 + num, item);
							}
							chmFile.MergLinks.Add(item);
							MarkChildrenAdded(item.Children, chmFile.MergLinks);
						}
						num++;
					}
				}
				else
				{
					TOCItem tOCItemByLocal = currentFile.GetTOCItemByLocal(text2);
					if (tOCItemByLocal != null)
					{
						tOCItem.AssociatedFile = currentFile;
						tOCItem.Children = tOCItemByLocal.Children;
						tOCItem.ChmFile = currentFile.ChmFilePath;
						tOCItem.ImageIndex = tOCItemByLocal.ImageIndex;
						tOCItem.Local = tOCItemByLocal.Local;
						tOCItem.MergeLink = tOCItemByLocal.MergeLink;
						tOCItem.Name = tOCItemByLocal.Name;
						tOCItem.TocMode = tOCItemByLocal.TocMode;
						tOCItem.TopicOffset = tOCItemByLocal.TopicOffset;
						chmFile.MergLinks.Add(tOCItemByLocal);
						MarkChildrenAdded(tOCItemByLocal.Children, chmFile.MergLinks);
					}
				}
			}
		}
	}

	internal void MarkChildrenAdded(ArrayList tocs, ArrayList merged)
	{
		foreach (TOCItem toc in tocs)
		{
			if (!merged.Contains(toc))
			{
				merged.Add(toc);
				MarkChildrenAdded(toc.Children, merged);
			}
		}
	}

	internal void RemoveMergeLinks()
	{
		foreach (CHMFile chmFile in _chmFiles)
		{
			if (chmFile.MergLinks.Count <= 0)
			{
				continue;
			}
			while (chmFile.MergLinks.Count > 0)
			{
				TOCItem tOCItem = chmFile.MergLinks[0] as TOCItem;
				if (tOCItem.MergeLink.Length > 0)
				{
					chmFile.RemoveTOCItem(tOCItem);
				}
				chmFile.MergLinks.RemoveAt(0);
			}
		}
	}

	private void MergeFileInfoTypesCategories(CHMFile chmFile)
	{
		if (chmFile.HasInformationTypes)
		{
			for (int i = 0; i < chmFile.InformationTypes.Count; i++)
			{
				InformationType informationType = chmFile.InformationTypes[i] as InformationType;
				InformationType informationType2 = GetInformationType(informationType.Name);
				if (informationType2 == null)
				{
					_informationTypes.Add(informationType);
				}
				else
				{
					informationType.ReferenceCount++;
				}
			}
		}
		if (!chmFile.HasCategories)
		{
			return;
		}
		for (int j = 0; j < chmFile.Categories.Count; j++)
		{
			Category category = chmFile.Categories[j] as Category;
			Category category2 = GetCategory(category.Name);
			if (category2 == null)
			{
				_categories.Add(category);
			}
			else
			{
				category.ReferenceCount++;
			}
		}
	}

	private void RemoveFileInfoTypesCategories(CHMFile chmFile)
	{
		if (chmFile.HasInformationTypes)
		{
			for (int i = 0; i < chmFile.InformationTypes.Count; i++)
			{
				InformationType informationType = chmFile.InformationTypes[i] as InformationType;
				InformationType informationType2 = GetInformationType(informationType.Name);
				if (informationType2 != null)
				{
					informationType2.ReferenceCount--;
					if (informationType2.ReferenceCount <= 0)
					{
						_informationTypes.Remove(informationType2);
					}
				}
			}
		}
		if (!chmFile.HasCategories)
		{
			return;
		}
		for (int j = 0; j < chmFile.Categories.Count; j++)
		{
			Category category = chmFile.Categories[j] as Category;
			Category category2 = GetCategory(category.Name);
			if (category2 != null)
			{
				category2.ReferenceCount--;
				if (category2.ReferenceCount <= 0)
				{
					_categories.Remove(category2);
				}
			}
		}
	}

	public void RemoveFile(string chmFile)
	{
		int num = -1;
		CHMFile chmFile2 = null;
		foreach (CHMFile chmFile3 in _chmFiles)
		{
			num++;
			if (chmFile3.ChmFilePath.ToLower() == chmFile.ToLower())
			{
				chmFile2 = chmFile3;
				break;
			}
		}
		if (num >= 0)
		{
			_toc.Clear();
			_index.Clear();
			RemoveFileInfoTypesCategories(chmFile2);
			_chmFiles.RemoveAt(num);
		}
	}

	public void CloseAllFiles()
	{
		int num;
		for (num = 0; num < _chmFiles.Count; num++)
		{
			CHMFile cHMFile = _chmFiles[num] as CHMFile;
			_chmFiles.RemoveAt(num);
			cHMFile.Dispose();
			num--;
		}
		_chmFiles.Clear();
		_toc.Clear();
		_index.Clear();
		_informationTypes.Clear();
		_categories.Clear();
	}

	public void WriteFile(HostResponse objResponse, string strLocal)
	{
		FileObject fileObject = null;
		foreach (CHMFile chmFile in _chmFiles)
		{
			fileObject = chmFile.GetFile(strLocal);
			if (fileObject != null)
			{
				break;
			}
		}
		if (fileObject != null)
		{
			string text = strLocal.ToLower();
			if (text.EndsWith(".gif"))
			{
				objResponse.ContentType = "image/gif";
			}
			else if (text.EndsWith(".css"))
			{
				objResponse.ContentType = "text/css";
			}
			else if (text.EndsWith(".js"))
			{
				objResponse.ContentType = "text/javascript";
			}
			else if (text.EndsWith(".css"))
			{
				objResponse.ContentType = "text/css";
			}
			else if (text.EndsWith(".htm") || text.EndsWith(".html"))
			{
				objResponse.ContentType = "text/html";
			}
			objResponse.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
			objResponse.Cache.SetExpires(DateTime.Now.AddMonths(6));
			BinaryReader binaryReader = new BinaryReader(fileObject);
			objResponse.BinaryWrite(binaryReader.ReadBytes((int)fileObject.Length));
			binaryReader.Close();
		}
	}

	public string ReadFromFile(string strLocal)
	{
		FileObject fileObject = null;
		foreach (CHMFile chmFile in _chmFiles)
		{
			fileObject = chmFile.GetFile(strLocal);
			if (fileObject != null)
			{
				break;
			}
		}
		string result = "";
		if (fileObject != null)
		{
			result = fileObject.ReadFromFile();
			fileObject.Close();
		}
		return result;
	}

	public InformationType GetInformationType(string name)
	{
		if (HasInformationTypes)
		{
			for (int i = 0; i < _informationTypes.Count; i++)
			{
				InformationType informationType = _informationTypes[i] as InformationType;
				if (informationType.Name == name)
				{
					return informationType;
				}
			}
		}
		return null;
	}

	public Category GetCategory(string name)
	{
		if (HasCategories)
		{
			for (int i = 0; i < _categories.Count; i++)
			{
				Category category = _categories[i] as Category;
				if (category.Name == name)
				{
					return category;
				}
			}
		}
		return null;
	}

	public DataTable PerformSearch(string words, bool partialMatches, bool titleOnly)
	{
		return PerformSearch(words, -1, partialMatches, titleOnly);
	}

	public DataTable PerformSearch(string words, int MaxResults, bool partialMatches, bool titleOnly)
	{
		if (!FullTextSearch)
		{
			return null;
		}
		DataTable dataTable = null;
		int num = 0;
		foreach (CHMFile chmFile in _chmFiles)
		{
			if (num == 0)
			{
				if (chmFile.FullTextSearchEngine.CanSearch && (dataTable = chmFile.FullTextSearchEngine.Search(words, MaxResults, partialMatches, titleOnly)) != null)
				{
					dataTable.DefaultView.Sort = "Rating DESC";
				}
			}
			else if (chmFile.FullTextSearchEngine.CanSearch)
			{
				DataTable dataTable2 = null;
				if ((dataTable2 = chmFile.FullTextSearchEngine.Search(words, MaxResults, partialMatches, titleOnly)) != null)
				{
					foreach (DataRow row in dataTable2.Rows)
					{
						dataTable.ImportRow(row);
					}
					dataTable.DefaultView.Sort = "Rating DESC";
					if (MaxResults >= 0 && dataTable.DefaultView.Count > MaxResults)
					{
						for (int i = MaxResults - 1; i < dataTable.DefaultView.Count - 1; i++)
						{
							if (dataTable.DefaultView[i].Row.RowState != DataRowState.Deleted)
							{
								dataTable.DefaultView[i].Row.Delete();
								dataTable.DefaultView[i].Row.AcceptChanges();
								i--;
							}
						}
						dataTable.AcceptChanges();
						dataTable.DefaultView.Sort = "Rating DESC";
					}
				}
			}
			num++;
		}
		return dataTable;
	}
}
