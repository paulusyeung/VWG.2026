#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using HtmlHelp.Storage;

namespace HtmlHelp.ChmDecoding;

[Serializable]
public sealed class CHMFile : IDisposable
{
	private HtmlHelpSystem _systemInstance = null;

	private bool _onlySystem = false;

	private bool disposed = false;

	private ArrayList _toc = new ArrayList();

	private ArrayList _mergeLinks = new ArrayList();

	private ArrayList _informationTypes = new ArrayList();

	private ArrayList _categories = new ArrayList();

	private ArrayList _indexKLinks = new ArrayList();

	private ArrayList _indexALinks = new ArrayList();

	private string _chmFileName = "";

	private string _chiFileName = "";

	private string _chwFileName = "";

	private string _chqFileName = "";

	private CHMSystem _systemFile = null;

	private CHMIdxhdr _idxhdrFile = null;

	private CHMStrings _stringsFile = null;

	private CHMUrlstr _urlstrFile = null;

	private CHMUrltable _urltblFile = null;

	private CHMTopics _topicsFile = null;

	private CHMTocidx _tocidxFile = null;

	private CHMBtree _kLinks = null;

	private CHMBtree _aLinks = null;

	private FullTextEngine _ftSearcher = null;

	private Encoding _textEncoding = Encoding.GetEncoding(1252);

	private ChmFileInfo _chmFileInfo = null;

	private bool _mustWriteDump = true;

	private bool _dumpRead = false;

	private int _dumpReadTrys = 0;

	private DumpingInfo _dmpInfo = null;

	private ITStorageWrapper _currentWrapper = null;

	internal ITStorageWrapper ChmWrapper
	{
		get
		{
			if (_currentWrapper != null)
			{
				return _currentWrapper;
			}
			ITStorageWrapper iTStorageWrapper = null;
			return new ITStorageWrapper(_chmFileName, enumStorage: false);
		}
	}

	public bool HasInformationTypes => _informationTypes.Count > 0;

	public bool HasCategories => _categories.Count > 0;

	public ArrayList InformationTypes => _informationTypes;

	public ArrayList Categories => _categories;

	internal ITStorageWrapper CurrentStorageWrapper => _currentWrapper;

	internal HtmlHelpSystem SystemInstance
	{
		get
		{
			return _systemInstance;
		}
		set
		{
			_systemInstance = value;
		}
	}

	internal ArrayList MergLinks => _mergeLinks;

	internal CHMSystem SystemFile => _systemFile;

	internal CHMIdxhdr IdxHdrFile => _idxhdrFile;

	internal CHMStrings StringsFile => _stringsFile;

	internal CHMUrlstr UrlstrFile => _urlstrFile;

	internal CHMUrltable UrltblFile => _urltblFile;

	public CHMTopics TopicsFile => _topicsFile;

	internal CHMTocidx TocidxFile => _tocidxFile;

	internal CHMBtree ALinksFile => _aLinks;

	internal CHMBtree KLinksFile => _kLinks;

	public Encoding TextEncoding
	{
		get
		{
			return _textEncoding;
		}
		set
		{
			_textEncoding = value;
		}
	}

	internal int FileVersion
	{
		get
		{
			if (_systemFile == null)
			{
				return 0;
			}
			return _systemFile.FileVersion;
		}
	}

	internal string ContentsFile
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.ContentsFile;
		}
	}

	internal string IndexFile
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.IndexFile;
		}
	}

	internal string DefaultTopic
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.DefaultTopic;
		}
	}

	internal string HelpWindowTitle
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.Title;
		}
	}

	internal bool DBCS
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.DBCS;
		}
	}

	internal bool FullTextSearch
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.FullTextSearch;
		}
	}

	internal bool HasALinks
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.HasALinks;
		}
	}

	internal bool HasKLinks
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.HasKLinks;
		}
	}

	internal string DefaultWindow
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.DefaultWindow;
		}
	}

	internal string CompileFile
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.CompileFile;
		}
	}

	internal bool BinaryIndex
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.BinaryIndex;
		}
	}

	internal string CompilerVersion
	{
		get
		{
			if (_systemFile == null)
			{
				return string.Empty;
			}
			return _systemFile.CompilerVersion;
		}
	}

	internal bool BinaryTOC
	{
		get
		{
			if (_systemFile == null)
			{
				return false;
			}
			return _systemFile.BinaryTOC;
		}
	}

	internal string FontFace
	{
		get
		{
			if (_systemFile == null)
			{
				return "";
			}
			return _systemFile.FontFace;
		}
	}

	internal double FontSize
	{
		get
		{
			if (_systemFile == null)
			{
				return 0.0;
			}
			return _systemFile.FontSize;
		}
	}

	internal int CharacterSet
	{
		get
		{
			if (_systemFile == null)
			{
				return 1;
			}
			return _systemFile.CharacterSet;
		}
	}

	internal int CodePage
	{
		get
		{
			if (_systemFile == null)
			{
				return CultureInfo.CurrentCulture.TextInfo.ANSICodePage;
			}
			return _systemFile.CodePage;
		}
	}

	internal CultureInfo Culture
	{
		get
		{
			if (_systemFile == null)
			{
				return CultureInfo.CurrentCulture;
			}
			return _systemFile.Culture;
		}
	}

	internal int NumberOfTopicNodes
	{
		get
		{
			if (_idxhdrFile == null)
			{
				return 0;
			}
			return _idxhdrFile.NumberOfTopicNodes;
		}
	}

	internal string ImageList
	{
		get
		{
			if (_stringsFile == null || _idxhdrFile == null)
			{
				return "";
			}
			return _stringsFile[_idxhdrFile.ImageListOffset];
		}
	}

	internal bool ImageTypeFolder
	{
		get
		{
			if (_idxhdrFile == null)
			{
				return false;
			}
			return _idxhdrFile.ImageTypeFolder;
		}
	}

	internal int Background
	{
		get
		{
			if (_idxhdrFile == null)
			{
				return 0;
			}
			return _idxhdrFile.Background;
		}
	}

	internal int Foreground
	{
		get
		{
			if (_idxhdrFile == null)
			{
				return 0;
			}
			return _idxhdrFile.Foreground;
		}
	}

	internal string FontName
	{
		get
		{
			if (_stringsFile == null || _idxhdrFile == null)
			{
				return "";
			}
			return _stringsFile[_idxhdrFile.FontOffset];
		}
	}

	internal string FrameName
	{
		get
		{
			if (_stringsFile == null || _idxhdrFile == null)
			{
				return "";
			}
			return _stringsFile[_idxhdrFile.FrameNameOffset];
		}
	}

	internal string WindowName
	{
		get
		{
			if (_stringsFile == null || _idxhdrFile == null)
			{
				return "";
			}
			return _stringsFile[_idxhdrFile.WindowNameOffset];
		}
	}

	internal string[] MergedFiles
	{
		get
		{
			if (_stringsFile == null || _idxhdrFile == null)
			{
				return new string[0];
			}
			string[] array = new string[_idxhdrFile.MergedFileOffsets.Count];
			for (int i = 0; i < _idxhdrFile.MergedFileOffsets.Count; i++)
			{
				array[i] = _stringsFile[(int)_idxhdrFile.MergedFileOffsets[i]];
			}
			return array;
		}
	}

	public ChmFileInfo FileInfo => _chmFileInfo;

	public ArrayList TOC => _toc;

	public ArrayList IndexKLinks => _indexKLinks;

	public ArrayList IndexALinks => _indexALinks;

	internal FullTextEngine FullTextSearchEngine => _ftSearcher;

	public string ChmFilePath => _chmFileName;

	public string ChiFilePath => _chiFileName;

	public string ChwFilePath => _chwFileName;

	public string ChqFilePath => _chqFileName;

	public CHMFile(HtmlHelpSystem systemInstance, string chmFile)
		: this(systemInstance, chmFile, onlySystemData: false, null)
	{
	}

	public CHMFile(HtmlHelpSystem systemInstance, string chmFile, DumpingInfo dmpInfo)
		: this(systemInstance, chmFile, onlySystemData: false, dmpInfo)
	{
	}

	internal CHMFile(HtmlHelpSystem systemInstance, string chmFile, bool onlySystemData)
		: this(systemInstance, chmFile, onlySystemData, null)
	{
	}

	internal CHMFile(HtmlHelpSystem systemInstance, string chmFile, bool onlySystemData, DumpingInfo dmpInfo)
	{
		_systemInstance = systemInstance;
		_dumpReadTrys = 0;
		_dmpInfo = dmpInfo;
		if (dmpInfo != null)
		{
			dmpInfo.ChmFile = this;
		}
		if (!chmFile.ToLower().EndsWith(".chm"))
		{
			throw new ArgumentException("HtmlHelp file must have the extension .chm !", "chmFile");
		}
		_chmFileName = chmFile;
		_chiFileName = "";
		if (File.Exists(chmFile))
		{
			_onlySystem = onlySystemData;
			Debug.WriteLine("--- Reading HtmlHelp file: " + chmFile);
			Debug.Indent();
			DateTime now = DateTime.Now;
			string text = _chmFileName.Substring(0, _chmFileName.Length - 3) + "chi";
			string text2 = _chmFileName.Substring(0, _chmFileName.Length - 3) + "chq";
			string text3 = _chmFileName.Substring(0, _chmFileName.Length - 3) + "chw";
			if (File.Exists(text))
			{
				_chiFileName = text;
				ReadFile(_chiFileName, HtmlHelpFileType.CHI);
			}
			if (File.Exists(text3) && !_onlySystem)
			{
				_chwFileName = text3;
				ReadFile(_chwFileName, HtmlHelpFileType.CHW);
			}
			if (File.Exists(text2) && !_onlySystem)
			{
				_chqFileName = text2;
				ReadFile(_chqFileName, HtmlHelpFileType.CHQ);
			}
			ReadFile(chmFile, HtmlHelpFileType.CHM);
			DateTime now2 = DateTime.Now;
			Debug.WriteLine("--- HtmlHelp file read in " + (now2 - now).ToString());
			Debug.Unindent();
			if (_mustWriteDump)
			{
				Debug.WriteLine("--- Writing data dump ");
				Debug.Indent();
				DateTime now3 = DateTime.Now;
				_mustWriteDump = !SaveDump(dmpInfo);
				DateTime now4 = DateTime.Now;
				Debug.WriteLine("--- Dump written in " + (now4 - now3).ToString());
				Debug.Unindent();
			}
			if (_systemFile.DefaultTopic.Length > 0)
			{
				ITStorageWrapper iTStorageWrapper = null;
				FileObject fileObject = null;
				fileObject = (_currentWrapper = new ITStorageWrapper(chmFile, enumStorage: false)).OpenUCOMStream(null, _systemFile.DefaultTopic);
				if (fileObject != null)
				{
					fileObject.Close();
				}
				else if (_toc.Count > 0)
				{
					_systemFile.SetDefaultTopic(((TOCItem)_toc[0]).Local);
				}
				_currentWrapper = null;
			}
			else if (_toc.Count > 0)
			{
				_systemFile.SetDefaultTopic(((TOCItem)_toc[0]).Local);
			}
			_chmFileInfo = new ChmFileInfo(this);
			return;
		}
		throw new ArgumentException("File '" + chmFile + "' not found !", "chmFile");
	}

	private void ReadFile(string fname, HtmlHelpFileType type)
	{
		ITStorageWrapper iTStorageWrapper = null;
		FileObject fileObject = null;
		iTStorageWrapper = (_currentWrapper = new ITStorageWrapper(fname, enumStorage: false));
		Debug.WriteLine("CHMFile.ctor() - Reading system files from " + type.ToString() + ": ");
		Debug.Indent();
		if (type != HtmlHelpFileType.CHQ && type != HtmlHelpFileType.CHW)
		{
			fileObject = iTStorageWrapper.OpenUCOMStream(null, "#SYSTEM");
			if (fileObject != null)
			{
				Debug.WriteLine("Read #SYSTEM file: ");
				Debug.Indent();
				DateTime now = DateTime.Now;
				byte[] array = new byte[fileObject.Length];
				fileObject.Read(array, 0, (int)fileObject.Length);
				fileObject.Close();
				_systemFile = new CHMSystem(array, this);
				DateTime now2 = DateTime.Now;
				Debug.WriteLine("time elapsed - " + (now2 - now).ToString());
				Debug.Unindent();
			}
			fileObject = iTStorageWrapper.OpenUCOMStream(null, "#IDXHDR");
			if (fileObject != null)
			{
				Debug.WriteLine("Read #IDXHDR file: ");
				Debug.Indent();
				DateTime now3 = DateTime.Now;
				byte[] array2 = new byte[fileObject.Length];
				fileObject.Read(array2, 0, (int)fileObject.Length);
				fileObject.Close();
				_idxhdrFile = new CHMIdxhdr(array2, this);
				DateTime now4 = DateTime.Now;
				Debug.WriteLine("time elapsed - " + (now4 - now3).ToString());
				Debug.Unindent();
			}
			if (!_dumpRead && CheckDump(_dmpInfo) && _dumpReadTrys == 0)
			{
				_dumpReadTrys++;
				Debug.WriteLine("--- Reading data dump ");
				Debug.Indent();
				DateTime now5 = DateTime.Now;
				_dumpRead = LoadDump(_dmpInfo);
				DateTime now6 = DateTime.Now;
				Debug.WriteLine("--- Dump read in " + (now6 - now5).ToString());
				Debug.Unindent();
			}
			if (!_dumpRead || !_dmpInfo.DumpStrings)
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, "#STRINGS");
				if (fileObject != null)
				{
					Debug.WriteLine("Read #STRINGS file: ");
					Debug.Indent();
					DateTime now7 = DateTime.Now;
					byte[] array3 = new byte[fileObject.Length];
					fileObject.Read(array3, 0, (int)fileObject.Length);
					fileObject.Close();
					_stringsFile = new CHMStrings(array3, this);
					DateTime now8 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now8 - now7).ToString());
					Debug.Unindent();
				}
			}
			if (!_dumpRead || !_dmpInfo.DumpUrlStr)
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, "#URLSTR");
				if (fileObject != null)
				{
					Debug.WriteLine("Read #URLSTR file: ");
					Debug.Indent();
					DateTime now9 = DateTime.Now;
					byte[] array4 = new byte[fileObject.Length];
					fileObject.Read(array4, 0, (int)fileObject.Length);
					fileObject.Close();
					_urlstrFile = new CHMUrlstr(array4, this);
					DateTime now10 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now10 - now9).ToString());
					Debug.Unindent();
				}
			}
			if (!_dumpRead || !_dmpInfo.DumpUrlTbl)
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, "#URLTBL");
				if (fileObject != null)
				{
					Debug.WriteLine("Read #URLTBL file: ");
					Debug.Indent();
					DateTime now11 = DateTime.Now;
					byte[] array5 = new byte[fileObject.Length];
					fileObject.Read(array5, 0, (int)fileObject.Length);
					fileObject.Close();
					_urltblFile = new CHMUrltable(array5, this);
					DateTime now12 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now12 - now11).ToString());
					Debug.Unindent();
				}
			}
			if (!_dumpRead || !_dmpInfo.DumpTopics)
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, "#TOPICS");
				if (fileObject != null)
				{
					Debug.WriteLine("Read #TOPICS file: ");
					Debug.Indent();
					DateTime now13 = DateTime.Now;
					byte[] array6 = new byte[fileObject.Length];
					fileObject.Read(array6, 0, (int)fileObject.Length);
					fileObject.Close();
					_topicsFile = new CHMTopics(array6, this);
					DateTime now14 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now14 - now13).ToString());
					Debug.Unindent();
				}
			}
			if (!_onlySystem && (!_dumpRead || !_dmpInfo.DumpBinaryTOC))
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, "#TOCIDX");
				if (fileObject != null && _systemFile.BinaryTOC)
				{
					Debug.WriteLine("Read #TOCIDX file: ");
					Debug.Indent();
					DateTime now15 = DateTime.Now;
					byte[] array7 = new byte[fileObject.Length];
					fileObject.Read(array7, 0, (int)fileObject.Length);
					fileObject.Close();
					_tocidxFile = new CHMTocidx(array7, this);
					_toc = _tocidxFile.TOC;
					DateTime now16 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now16 - now15).ToString());
					Debug.Unindent();
				}
			}
			if (_systemFile != null && !_onlySystem && !_systemFile.BinaryTOC && (!_dumpRead || !_dmpInfo.DumpTextTOC))
			{
				fileObject = iTStorageWrapper.OpenUCOMStream(null, _systemFile.ContentsFile);
				if (fileObject != null)
				{
					Debug.WriteLine("Parsing HHC-toc: ");
					Debug.Indent();
					DateTime now17 = DateTime.Now;
					string hhcFile = fileObject.ReadFromFile(TextEncoding);
					fileObject.Close();
					_toc = HHCParser.ParseHHC(hhcFile, this);
					if (HHCParser.HasMergeLinks)
					{
						_mergeLinks = HHCParser.MergeItems;
					}
					DateTime now18 = DateTime.Now;
					Debug.WriteLine("time elapsed - " + (now18 - now17).ToString());
					Debug.Unindent();
				}
			}
		}
		if (type != HtmlHelpFileType.CHQ && _systemFile != null && !_onlySystem)
		{
			if (!_systemFile.BinaryIndex)
			{
				if (!_dumpRead || !_dmpInfo.DumpTextIndex)
				{
					fileObject = iTStorageWrapper.OpenUCOMStream(null, _systemFile.IndexFile);
					if (fileObject != null)
					{
						Debug.WriteLine("Parsing HHK-index: ");
						Debug.Indent();
						DateTime now19 = DateTime.Now;
						string hhkFile = fileObject.ReadFromFile(TextEncoding);
						fileObject.Close();
						_indexKLinks = HHKParser.ParseHHK(hhkFile, this);
						_indexKLinks.Sort();
						DateTime now20 = DateTime.Now;
						Debug.WriteLine("time elapsed - " + (now20 - now19).ToString());
						Debug.Unindent();
					}
				}
			}
			else if (!_dumpRead || !_dmpInfo.DumpBinaryIndex)
			{
				Interop.IStorage storage = iTStorageWrapper.OpenSubStorage(null, "$WWKeywordLinks");
				if (storage != null)
				{
					fileObject = iTStorageWrapper.OpenUCOMStream(storage, "BTree");
					if (fileObject != null)
					{
						Debug.WriteLine("Extracting index (klinks) from BTree: ");
						Debug.Indent();
						DateTime now21 = DateTime.Now;
						byte[] array8 = new byte[fileObject.Length];
						fileObject.Read(array8, 0, (int)fileObject.Length);
						fileObject.Close();
						_kLinks = new CHMBtree(array8, this);
						_indexKLinks = _kLinks.IndexList;
						_indexKLinks.Sort();
						DateTime now22 = DateTime.Now;
						Debug.WriteLine("time elapsed - " + (now22 - now21).ToString());
						Debug.Unindent();
					}
				}
				storage = iTStorageWrapper.OpenSubStorage(null, "$WWAssociativeLinks");
				if (storage != null)
				{
					fileObject = iTStorageWrapper.OpenUCOMStream(storage, "BTree");
					if (fileObject != null)
					{
						Debug.WriteLine("Extracting index (alinks) from BTree: ");
						Debug.Indent();
						DateTime now23 = DateTime.Now;
						byte[] array9 = new byte[fileObject.Length];
						fileObject.Read(array9, 0, (int)fileObject.Length);
						fileObject.Close();
						_aLinks = new CHMBtree(array9, this);
						_indexALinks = _aLinks.IndexList;
						_indexALinks.Sort();
						DateTime now24 = DateTime.Now;
						Debug.WriteLine("time elapsed - " + (now24 - now23).ToString());
						Debug.Unindent();
					}
				}
			}
		}
		if (type != HtmlHelpFileType.CHI && type != HtmlHelpFileType.CHW && _systemFile != null && !_onlySystem && _systemFile.FullTextSearch && (!_dumpRead || !_dmpInfo.DumpFullText))
		{
			fileObject = iTStorageWrapper.OpenUCOMStream(null, "$FIftiMain");
			if (fileObject != null)
			{
				Debug.WriteLine("Enabling fulltext-search: ");
				Debug.Indent();
				DateTime now25 = DateTime.Now;
				byte[] array10 = new byte[fileObject.Length];
				fileObject.Read(array10, 0, (int)fileObject.Length);
				fileObject.Close();
				_ftSearcher = new FullTextEngine(array10, this);
				DateTime now26 = DateTime.Now;
				Debug.WriteLine("time elapsed - " + (now26 - now25).ToString());
				Debug.Unindent();
			}
		}
		Debug.Unindent();
		_currentWrapper = null;
	}

	internal ArrayList EnumFilesByExtension(string extension)
	{
		ArrayList arrayList = new ArrayList();
		ITStorageWrapper iTStorageWrapper = null;
		iTStorageWrapper = ((_currentWrapper != null) ? _currentWrapper : new ITStorageWrapper(_chmFileName, enumStorage: false));
		iTStorageWrapper.EnumIStorageObject();
		foreach (FileObject item in iTStorageWrapper.foCollection)
		{
			if (item.CanRead && item.FileName.ToLower().EndsWith(extension))
			{
				arrayList.Add(item.FileName);
			}
		}
		if (arrayList.Count > 0)
		{
			return arrayList;
		}
		return null;
	}

	internal FileObject GetFile(string strLocal)
	{
		ITStorageWrapper iTStorageWrapper = null;
		iTStorageWrapper = ((_currentWrapper != null) ? _currentWrapper : new ITStorageWrapper(_chmFileName, enumStorage: false));
		return iTStorageWrapper.OpenUCOMStream(null, strLocal);
	}

	internal TOCItem GetTOCItemByLocal(string local)
	{
		return GetTOCItemByLocal(TOC, local);
	}

	private TOCItem GetTOCItemByLocal(ArrayList arrTOC, string local)
	{
		TOCItem tOCItem = null;
		foreach (TOCItem item in arrTOC)
		{
			string text = item.Local.ToLower();
			string text2 = local.ToLower();
			while (text[0] == '/')
			{
				text = text.Substring(1);
			}
			while (text2[0] == '/')
			{
				text2 = text2.Substring(1);
			}
			if (text == text2)
			{
				return item;
			}
			if (item.Children.Count > 0)
			{
				tOCItem = GetTOCItemByLocal(item.Children, local);
				if (tOCItem != null)
				{
					return tOCItem;
				}
			}
		}
		return tOCItem;
	}

	internal bool RemoveTOCItem(TOCItem rem)
	{
		if (rem == null)
		{
			return false;
		}
		return RemoveTOCItem(TOC, rem);
	}

	private bool RemoveTOCItem(ArrayList arrTOC, TOCItem rem)
	{
		for (int i = 0; i < arrTOC.Count; i++)
		{
			TOCItem tOCItem = arrTOC[i] as TOCItem;
			if (tOCItem == rem)
			{
				arrTOC.RemoveAt(i);
				return true;
			}
			if (tOCItem.Children.Count > 0 && RemoveTOCItem(tOCItem.Children, rem))
			{
				return true;
			}
		}
		return false;
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

	public ArrayList ParseHHC(string hhcFile)
	{
		ArrayList result = new ArrayList();
		ITStorageWrapper iTStorageWrapper = null;
		FileObject fileObject = null;
		iTStorageWrapper = new ITStorageWrapper(_chmFileName, enumStorage: false);
		fileObject = iTStorageWrapper.OpenUCOMStream(null, hhcFile);
		if (fileObject != null)
		{
			Debug.WriteLine("Parsing HHC-toc: ");
			Debug.Indent();
			DateTime now = DateTime.Now;
			string hhcFile2 = fileObject.ReadFromFile(TextEncoding);
			fileObject.Close();
			result = HHCParser.ParseHHC(hhcFile2, this);
			if (HHCParser.HasMergeLinks)
			{
				foreach (TOCItem mergeItem in HHCParser.MergeItems)
				{
					_mergeLinks.Add(mergeItem);
				}
			}
			DateTime now2 = DateTime.Now;
			Debug.WriteLine("time elapsed - " + (now2 - now).ToString());
			Debug.Unindent();
		}
		return result;
	}

	private bool CheckDump(DumpingInfo dmpInfo)
	{
		if (_dumpReadTrys <= 0)
		{
			_mustWriteDump = false;
		}
		if (_onlySystem)
		{
			return false;
		}
		if (dmpInfo != null)
		{
			if (_dumpReadTrys > 0)
			{
				return _mustWriteDump;
			}
			_mustWriteDump = !dmpInfo.DumpExists;
			return !_mustWriteDump;
		}
		return false;
	}

	private bool SaveDump(DumpingInfo dmpInfo)
	{
		if (dmpInfo == null)
		{
			return false;
		}
		bool result = false;
		BinaryWriter writer = dmpInfo.Writer;
		int num = 0;
		try
		{
			Debug.WriteLine("writing dump-file header");
			FileInfo fileInfo = new FileInfo(_chmFileName);
			string value = fileInfo.LastWriteTime.ToString("dd.MM.yyyy HH:mm:ss.ffffff");
			writer.Write("HtmlHelpSystem dump file 1.0");
			writer.Write(value);
			writer.Write(_textEncoding.CodePage);
			if (dmpInfo.DumpStrings)
			{
				writer.Write(value: true);
				if (_stringsFile == null)
				{
					writer.Write(value: false);
				}
				else
				{
					Debug.WriteLine("writing #STRINGS");
					writer.Write(value: true);
					_stringsFile.Dump(ref writer);
				}
			}
			else
			{
				writer.Write(value: false);
			}
			if (dmpInfo.DumpUrlStr)
			{
				writer.Write(value: true);
				if (_urlstrFile == null)
				{
					writer.Write(value: false);
				}
				else
				{
					Debug.WriteLine("writing #URLSTR");
					writer.Write(value: true);
					_urlstrFile.Dump(ref writer);
				}
			}
			else
			{
				writer.Write(value: false);
			}
			if (dmpInfo.DumpUrlTbl)
			{
				writer.Write(value: true);
				if (_urltblFile == null)
				{
					writer.Write(value: false);
				}
				else
				{
					Debug.WriteLine("writing #URLTBL");
					writer.Write(value: true);
					_urltblFile.Dump(ref writer);
				}
			}
			else
			{
				writer.Write(value: false);
			}
			if (dmpInfo.DumpTopics)
			{
				writer.Write(value: true);
				if (_topicsFile == null)
				{
					writer.Write(value: false);
				}
				else
				{
					Debug.WriteLine("writing #TOPICS");
					writer.Write(value: true);
					_topicsFile.Dump(ref writer);
				}
			}
			else
			{
				writer.Write(value: false);
			}
			if (dmpInfo.DumpFullText)
			{
				writer.Write(value: true);
				if (_ftSearcher == null)
				{
					writer.Write(value: false);
				}
				else
				{
					Debug.WriteLine("writing $FIftiMain");
					writer.Write(value: true);
					_ftSearcher.Dump(ref writer);
				}
			}
			else
			{
				writer.Write(value: false);
			}
			bool flag = false;
			if (_systemFile.BinaryTOC && dmpInfo.DumpBinaryTOC)
			{
				Debug.WriteLine("writing binary TOC");
				flag = true;
			}
			if (!_systemFile.BinaryTOC && dmpInfo.DumpTextTOC)
			{
				Debug.WriteLine("writing text-based TOC");
				flag = true;
			}
			writer.Write(flag);
			if (flag)
			{
				writer.Write(_toc.Count);
				for (num = 0; num < _toc.Count; num++)
				{
					TOCItem tOCItem = (TOCItem)_toc[num];
					tOCItem.Dump(ref writer);
				}
			}
			bool flag2 = false;
			if (_systemFile.BinaryIndex && dmpInfo.DumpBinaryIndex)
			{
				Debug.WriteLine("writing binary index");
				flag2 = true;
			}
			if (!_systemFile.BinaryIndex && dmpInfo.DumpTextIndex)
			{
				Debug.WriteLine("writing text-based index");
				flag2 = true;
			}
			writer.Write(flag2);
			if (flag2)
			{
				writer.Write(_indexALinks.Count);
				for (num = 0; num < _indexALinks.Count; num++)
				{
					IndexItem indexItem = (IndexItem)_indexALinks[num];
					indexItem.Dump(ref writer);
				}
				writer.Write(_indexKLinks.Count);
				for (num = 0; num < _indexKLinks.Count; num++)
				{
					IndexItem indexItem2 = (IndexItem)_indexKLinks[num];
					indexItem2.Dump(ref writer);
				}
			}
			writer.Write(_informationTypes.Count);
			Debug.WriteLine("writing " + _informationTypes.Count + " information types");
			for (num = 0; num < _informationTypes.Count; num++)
			{
				InformationType informationType = _informationTypes[num] as InformationType;
				informationType.Dump(ref writer);
			}
			writer.Write(_categories.Count);
			Debug.WriteLine("writing " + _categories.Count + " categories");
			for (num = 0; num < _categories.Count; num++)
			{
				Category category = _categories[num] as Category;
				category.Dump(ref writer);
			}
			result = true;
		}
		finally
		{
			dmpInfo.SaveData();
		}
		return result;
	}

	private bool LoadDump(DumpingInfo dmpInfo)
	{
		if (dmpInfo == null)
		{
			return false;
		}
		bool result = false;
		try
		{
			BinaryReader reader = dmpInfo.Reader;
			if (reader == null)
			{
				Debug.WriteLine("No reader returned !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			int num = 0;
			Debug.WriteLine("reading dump-file header");
			FileInfo fileInfo = new FileInfo(_chmFileName);
			string text = fileInfo.LastWriteTime.ToString("dd.MM.yyyy HH:mm:ss.ffffff");
			string text2 = reader.ReadString();
			if (text2 != "HtmlHelpSystem dump file 1.0")
			{
				Debug.WriteLine("Unsupported dump-file format !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			string text3 = reader.ReadString();
			reader.ReadInt32();
			if (text3 != text)
			{
				Debug.WriteLine("Dump is out of date (CHM file changed during last dump creation) !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			if (reader.ReadBoolean())
			{
				flag2 = reader.ReadBoolean();
				if (!dmpInfo.DumpStrings)
				{
					Debug.WriteLine("Dumped #STRINGS found but not expected !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (flag2)
				{
					Debug.WriteLine("reading #STRINGS");
					_stringsFile = new CHMStrings();
					_stringsFile.SetCHMFile(this);
					_stringsFile.ReadDump(ref reader);
				}
			}
			else if (dmpInfo.DumpStrings)
			{
				Debug.WriteLine("Dumped #STRINGS expected but not found !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			if (reader.ReadBoolean())
			{
				flag2 = reader.ReadBoolean();
				if (!dmpInfo.DumpUrlStr)
				{
					Debug.WriteLine("Dumped #URLSTR found but not expected !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (flag2)
				{
					Debug.WriteLine("reading #URLSTR");
					_urlstrFile = new CHMUrlstr();
					_urlstrFile.SetCHMFile(this);
					_urlstrFile.ReadDump(ref reader);
				}
			}
			else if (dmpInfo.DumpUrlStr)
			{
				Debug.WriteLine("Dumped #URLSTR expected but not found !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			if (reader.ReadBoolean())
			{
				flag2 = reader.ReadBoolean();
				if (!dmpInfo.DumpUrlTbl)
				{
					Debug.WriteLine("Dumped #URLTBL found but not expected !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (flag2)
				{
					Debug.WriteLine("reading #URLTBL");
					_urltblFile = new CHMUrltable();
					_urltblFile.SetCHMFile(this);
					_urltblFile.ReadDump(ref reader);
				}
			}
			else if (dmpInfo.DumpUrlTbl)
			{
				Debug.WriteLine("Dumped #URLTBL expected but not found !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			if (reader.ReadBoolean())
			{
				flag2 = reader.ReadBoolean();
				if (!dmpInfo.DumpTopics)
				{
					Debug.WriteLine("Dumped #TOPICS found but not expected !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (flag2)
				{
					Debug.WriteLine("reading #TOPICS");
					_topicsFile = new CHMTopics();
					_topicsFile.SetCHMFile(this);
					_topicsFile.ReadDump(ref reader);
				}
			}
			else if (dmpInfo.DumpTopics)
			{
				Debug.WriteLine("Dumped #TOPICS expected but not found !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			if (reader.ReadBoolean())
			{
				flag2 = reader.ReadBoolean();
				if (!dmpInfo.DumpFullText)
				{
					Debug.WriteLine("Dumped $FIftiMain found but not expected !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (flag2)
				{
					Debug.WriteLine("reading $FIftiMain");
					_ftSearcher = new FullTextEngine();
					_ftSearcher.SetCHMFile(this);
					_ftSearcher.ReadDump(ref reader);
				}
			}
			else if (dmpInfo.DumpFullText)
			{
				Debug.WriteLine("Dumped $FIftiMain expected but not found !");
				dmpInfo.SaveData();
				_mustWriteDump = true;
				return false;
			}
			_toc.Clear();
			if (reader.ReadBoolean())
			{
				if (_systemFile.BinaryTOC && !dmpInfo.DumpBinaryTOC)
				{
					Debug.WriteLine("Binary TOC expected but not found !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (!_systemFile.BinaryTOC && !dmpInfo.DumpTextTOC)
				{
					Debug.WriteLine("Text-based TOC expected but not found !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (_systemFile.BinaryTOC)
				{
					Debug.WriteLine("reading binary TOC");
				}
				else
				{
					Debug.WriteLine("reading text-based TOC");
				}
				int num2 = reader.ReadInt32();
				for (num = 0; num < num2; num++)
				{
					TOCItem tOCItem = new TOCItem();
					tOCItem.AssociatedFile = this;
					tOCItem.ChmFile = _chmFileName;
					tOCItem.ReadDump(ref reader);
					if (tOCItem.MergeLink.Length > 0)
					{
						_mergeLinks.Add(tOCItem);
					}
					_toc.Add(tOCItem);
				}
			}
			else
			{
				if (_systemFile.BinaryTOC && dmpInfo.DumpBinaryTOC)
				{
					Debug.WriteLine("Binary TOC expected but no TOC dump !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (!_systemFile.BinaryTOC && dmpInfo.DumpTextTOC)
				{
					Debug.WriteLine("Text-based TOC expected but no TOC dump !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
			}
			_indexALinks.Clear();
			_indexKLinks.Clear();
			if (reader.ReadBoolean())
			{
				if (_systemFile.BinaryIndex && !dmpInfo.DumpBinaryIndex)
				{
					Debug.WriteLine("Binary index expected but not found !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (!_systemFile.BinaryIndex && !dmpInfo.DumpTextIndex)
				{
					Debug.WriteLine("Binary index expected but not found !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (_systemFile.BinaryIndex)
				{
					Debug.WriteLine("reading binary index");
				}
				else
				{
					Debug.WriteLine("reading text-based index");
				}
				int num3 = reader.ReadInt32();
				for (num = 0; num < num3; num++)
				{
					IndexItem indexItem = new IndexItem();
					indexItem.ChmFile = this;
					indexItem.ReadDump(ref reader);
					_indexALinks.Add(indexItem);
				}
				int num4 = reader.ReadInt32();
				for (num = 0; num < num4; num++)
				{
					IndexItem indexItem2 = new IndexItem();
					indexItem2.ChmFile = this;
					indexItem2.ReadDump(ref reader);
					_indexKLinks.Add(indexItem2);
				}
			}
			else
			{
				if (_systemFile.BinaryIndex && dmpInfo.DumpBinaryIndex)
				{
					Debug.WriteLine("Binary index expected but no index in dump !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
				if (!_systemFile.BinaryIndex && dmpInfo.DumpTextIndex)
				{
					Debug.WriteLine("Text-based index expected but no index dump !");
					dmpInfo.SaveData();
					_mustWriteDump = true;
					return false;
				}
			}
			int num5 = reader.ReadInt32();
			Debug.WriteLine("Reading " + num5 + " information types from dump !");
			for (num = 0; num < num5; num++)
			{
				InformationType informationType = new InformationType();
				informationType.ReadDump(ref reader);
				if (SystemInstance.GetInformationType(informationType.Name) != null)
				{
					InformationType informationType2 = SystemInstance.GetInformationType(informationType.Name);
					_informationTypes.Add(informationType2);
				}
				else
				{
					_informationTypes.Add(informationType);
				}
			}
			int num6 = reader.ReadInt32();
			Debug.WriteLine("Reading " + num5 + " categories from dump !");
			for (num = 0; num < num6; num++)
			{
				Category category = new Category();
				category.ReadDump(ref reader, this);
				if (SystemInstance.GetCategory(category.Name) != null)
				{
					Category category2 = SystemInstance.GetCategory(category.Name);
					category2.MergeInfoTypes(category);
					_categories.Add(category2);
				}
				else
				{
					_categories.Add(category);
				}
			}
			_dumpRead = true;
			result = true;
		}
		catch (Exception ex)
		{
			Debug.WriteLine("###ERROR :" + ex.Message);
			_mustWriteDump = true;
		}
		finally
		{
			dmpInfo.SaveData();
		}
		return result;
	}

	internal string FormURL(string local)
	{
		if (local.ToLower().IndexOf("http://") >= 0 || local.ToLower().IndexOf("https://") >= 0 || local.ToLower().IndexOf("mailto:") >= 0 || local.ToLower().IndexOf("ftp://") >= 0)
		{
			return local;
		}
		return HtmlHelpSystem.UrlPrefix + _chmFileName + "::/" + local;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (!disposed && disposing)
		{
			_toc.Clear();
			_indexKLinks.Clear();
			_indexALinks.Clear();
			if (_systemFile != null)
			{
				_systemFile.Dispose();
			}
			if (_idxhdrFile != null)
			{
				_idxhdrFile.Dispose();
			}
			if (_stringsFile != null)
			{
				_stringsFile.Dispose();
			}
			if (_urlstrFile != null)
			{
				_urlstrFile.Dispose();
			}
			if (_urltblFile != null)
			{
				_urltblFile.Dispose();
			}
			if (_topicsFile != null)
			{
				_topicsFile.Dispose();
			}
			if (_tocidxFile != null)
			{
				_tocidxFile.Dispose();
			}
			if (_kLinks != null)
			{
				_kLinks.Dispose();
			}
			if (_aLinks != null)
			{
				_aLinks.Dispose();
			}
			if (_ftSearcher != null)
			{
				_ftSearcher.Dispose();
			}
			if (_chmFileInfo != null)
			{
				_chmFileInfo = null;
			}
		}
		disposed = true;
	}
}
