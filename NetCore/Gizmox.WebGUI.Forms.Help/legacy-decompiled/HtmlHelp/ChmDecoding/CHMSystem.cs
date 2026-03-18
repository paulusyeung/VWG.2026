#define DEBUG
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using HtmlHelp.Storage;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMSystem : IDisposable
{
	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private int _fileVersion = 0;

	private string _contentsFile = "";

	private string _indexFile = "";

	private string _defaultTopic = "";

	private string _title = "";

	private bool _dbcs = false;

	private bool _fullTextSearch = false;

	private bool _hasKLinks = false;

	private bool _hasALinks = false;

	private string _defaultWindow = "";

	private string _compileFile = "";

	private uint _binaryIndexURLTableID = 0u;

	private string _compilerVersion = "";

	private uint _binaryTOCURLTableID = 0u;

	private CHMFile _associatedFile = null;

	private string _defaultFont = "";

	private CultureInfo _culture;

	public int FileVersion => _fileVersion;

	public string ContentsFile
	{
		get
		{
			if (BinaryTOC)
			{
				if (_associatedFile != null && _associatedFile.UrltblFile != null)
				{
					UrlTableEntry byUniqueID = _associatedFile.UrltblFile.GetByUniqueID(BinaryTOCURLTableID);
					if (byUniqueID != null)
					{
						return byUniqueID.URL;
					}
				}
			}
			else if (_contentsFile.Length <= 0)
			{
				string text = "Table of Contents.hhc";
				if (_associatedFile != null && _associatedFile.TopicsFile != null)
				{
					TopicEntry byLocale = _associatedFile.TopicsFile.GetByLocale(text);
					if (byLocale == null)
					{
						text = "toc.hhc";
						byLocale = _associatedFile.TopicsFile.GetByLocale(text);
						if (byLocale == null)
						{
							text = CompileFile + ".hhc";
							byLocale = _associatedFile.TopicsFile.GetByLocale(text);
							if (byLocale == null)
							{
								ArrayList byExtension = _associatedFile.TopicsFile.GetByExtension("hhc");
								if (byExtension == null)
								{
									byExtension = _associatedFile.EnumFilesByExtension("hhc");
									if (byExtension == null)
									{
										Debug.WriteLine("CHMSystem.ContentsFile - Failed, contents file not found !");
									}
									else if (byExtension.Count > 1)
									{
										text = (_contentsFile = GetMasterHHC(byExtension, TopicItemArrayList: false));
									}
									else
									{
										_contentsFile = (string)byExtension[0];
										text = _contentsFile;
									}
								}
								else if (byExtension.Count > 1)
								{
									text = (_contentsFile = GetMasterHHC(byExtension, TopicItemArrayList: true));
								}
								else
								{
									_contentsFile = ((TopicEntry)byExtension[0]).Locale;
									text = _contentsFile;
								}
							}
							else
							{
								_contentsFile = text;
							}
						}
						else
						{
							_contentsFile = text;
						}
					}
					else
					{
						_contentsFile = text;
					}
				}
				return text;
			}
			return _contentsFile;
		}
	}

	public string IndexFile
	{
		get
		{
			if (BinaryIndex)
			{
				if (_associatedFile != null && _associatedFile.UrltblFile != null)
				{
					UrlTableEntry byUniqueID = _associatedFile.UrltblFile.GetByUniqueID(BinaryIndexURLTableID);
					if (byUniqueID != null)
					{
						return byUniqueID.URL;
					}
				}
			}
			else if (_indexFile.Length <= 0)
			{
				string text = "Index.hhk";
				if (_associatedFile != null && _associatedFile.TopicsFile != null)
				{
					TopicEntry byLocale = _associatedFile.TopicsFile.GetByLocale(text);
					if (byLocale == null)
					{
						text = CompileFile + ".hhk";
						byLocale = _associatedFile.TopicsFile.GetByLocale(text);
						if (byLocale == null)
						{
							ArrayList byExtension = _associatedFile.TopicsFile.GetByExtension("hhk");
							if (byExtension == null)
							{
								Debug.WriteLine("CHMSystem.IndexFile - Failed, index file not found !");
							}
							else
							{
								_indexFile = ((TopicEntry)byExtension[0]).Locale;
								text = _indexFile;
							}
						}
						else
						{
							_indexFile = text;
						}
					}
					else
					{
						_indexFile = text;
					}
				}
				return text;
			}
			return _indexFile;
		}
	}

	public string DefaultTopic => _defaultTopic;

	public string Title => _title;

	public bool DBCS => _dbcs;

	public bool FullTextSearch => _fullTextSearch;

	public bool HasALinks => _hasALinks;

	public bool HasKLinks => _hasKLinks;

	public string DefaultWindow => _defaultWindow;

	public string CompileFile => _compileFile;

	public uint BinaryIndexURLTableID => _binaryIndexURLTableID;

	public bool BinaryIndex => _binaryIndexURLTableID != 0;

	public string CompilerVersion => _compilerVersion;

	public uint BinaryTOCURLTableID => _binaryTOCURLTableID;

	public bool BinaryTOC => _binaryTOCURLTableID != 0;

	public string FontFace
	{
		get
		{
			if (_defaultFont.Length > 0)
			{
				string[] array = _defaultFont.Split(',');
				if (array.Length != 0)
				{
					return array[0].Trim();
				}
			}
			return "";
		}
	}

	public double FontSize
	{
		get
		{
			if (_defaultFont.Length > 0)
			{
				string[] array = _defaultFont.Split(',');
				if (array.Length > 1)
				{
					return double.Parse(array[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture);
				}
			}
			return 0.0;
		}
	}

	public int CharacterSet
	{
		get
		{
			if (_defaultFont.Length > 0)
			{
				string[] array = _defaultFont.Split(',');
				if (array.Length > 2)
				{
					return int.Parse(array[2].Trim());
				}
			}
			return 0;
		}
	}

	public int CodePage
	{
		get
		{
			if (_culture != null)
			{
				return _culture.TextInfo.ANSICodePage;
			}
			int result = 1252;
			switch (CharacterSet)
			{
			case 0:
				result = 1252;
				break;
			case 204:
				result = 1251;
				break;
			case 238:
				result = 1250;
				break;
			case 161:
				result = 1253;
				break;
			case 162:
				result = 1254;
				break;
			case 186:
				result = 1257;
				break;
			case 177:
				result = 1255;
				break;
			case 178:
				result = 1256;
				break;
			case 128:
				result = 932;
				break;
			case 129:
				result = 949;
				break;
			case 134:
				result = 936;
				break;
			case 136:
				result = 950;
				break;
			}
			return result;
		}
	}

	public CultureInfo Culture => _culture;

	public CHMSystem(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		if (_culture == null)
		{
			_associatedFile.TextEncoding = Encoding.GetEncoding(CodePage);
		}
	}

	private bool DecodeData()
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(_binaryFileData);
		BinaryReader binReader = new BinaryReader(memoryStream);
		_fileVersion = binReader.ReadInt32();
		while (memoryStream.Position < memoryStream.Length && flag)
		{
			flag &= DecodeEntry(ref binReader);
		}
		return flag;
	}

	private bool DecodeEntry(ref BinaryReader binReader)
	{
		bool result = true;
		int num = binReader.ReadInt16();
		int num2 = binReader.ReadInt16();
		switch (num)
		{
		case 0:
			_contentsFile = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 1:
			_indexFile = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 2:
			_defaultTopic = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 3:
			_title = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 4:
		{
			int num12 = 0;
			num12 = binReader.ReadInt32();
			_culture = new CultureInfo(num12);
			if (_culture != null)
			{
				_associatedFile.TextEncoding = Encoding.GetEncoding(_culture.TextInfo.ANSICodePage);
			}
			num12 = binReader.ReadInt32();
			_dbcs = num12 == 1;
			num12 = binReader.ReadInt32();
			_fullTextSearch = num12 == 1;
			num12 = binReader.ReadInt32();
			_hasKLinks = num12 != 0;
			num12 = binReader.ReadInt32();
			_hasALinks = num12 != 0;
			byte[] array10 = new byte[num2 - 20];
			array10 = binReader.ReadBytes(num2 - 20);
			break;
		}
		case 5:
			_defaultWindow = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 6:
			_compileFile = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 7:
		{
			if (_fileVersion > 2)
			{
				_binaryIndexURLTableID = (uint)binReader.ReadInt32();
				break;
			}
			byte[] array9 = binReader.ReadBytes(num2);
			int num11 = array9.Length;
			break;
		}
		case 8:
		{
			byte[] array8 = binReader.ReadBytes(num2);
			int num10 = array8.Length;
			break;
		}
		case 9:
			_compilerVersion = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		case 10:
		{
			byte[] array7 = binReader.ReadBytes(num2);
			int num9 = array7.Length;
			break;
		}
		case 11:
		{
			if (_fileVersion > 2)
			{
				_binaryTOCURLTableID = (uint)binReader.ReadInt32();
				break;
			}
			byte[] array6 = binReader.ReadBytes(num2);
			int num8 = array6.Length;
			break;
		}
		case 12:
		{
			byte[] array5 = binReader.ReadBytes(num2);
			int num7 = array5.Length;
			break;
		}
		case 13:
		{
			byte[] array4 = binReader.ReadBytes(num2);
			int num6 = array4.Length;
			break;
		}
		case 14:
		{
			byte[] array3 = binReader.ReadBytes(num2);
			int num5 = array3.Length;
			break;
		}
		case 15:
		{
			byte[] array2 = binReader.ReadBytes(num2);
			int num4 = array2.Length;
			break;
		}
		case 16:
			_defaultFont = BinaryReaderHelp.ExtractString(ref binReader, num2, 0, noOffset: true, _associatedFile.TextEncoding);
			break;
		default:
		{
			byte[] array = new byte[num2];
			array = binReader.ReadBytes(num2);
			int num3 = array.Length;
			break;
		}
		}
		return result;
	}

	private string GetMasterHHC(ArrayList hhcTopics, bool TopicItemArrayList)
	{
		string result = "";
		if (hhcTopics != null && hhcTopics.Count > 0)
		{
			if (TopicItemArrayList)
			{
				if (hhcTopics.Count == 1)
				{
					result = ((TopicEntry)hhcTopics[0]).Locale;
				}
				else
				{
					foreach (TopicEntry hhcTopic in hhcTopics)
					{
						ITStorageWrapper iTStorageWrapper = null;
						FileObject fileObject = null;
						iTStorageWrapper = ((_associatedFile.CurrentStorageWrapper != null) ? _associatedFile.CurrentStorageWrapper : new ITStorageWrapper(_associatedFile.ChmFilePath, enumStorage: false));
						fileObject = iTStorageWrapper.OpenUCOMStream(null, hhcTopic.Locale);
						if (fileObject != null)
						{
							string hhcFile = fileObject.ReadFromFile(_associatedFile.TextEncoding);
							fileObject.Close();
							if (HHCParser.HasGlobalObjectTag(hhcFile, _associatedFile))
							{
								result = hhcTopic.Locale;
								break;
							}
						}
					}
				}
			}
			else if (hhcTopics.Count == 1)
			{
				result = (string)hhcTopics[0];
			}
			else
			{
				foreach (string hhcTopic2 in hhcTopics)
				{
					ITStorageWrapper iTStorageWrapper2 = null;
					FileObject fileObject2 = null;
					iTStorageWrapper2 = ((_associatedFile.CurrentStorageWrapper != null) ? _associatedFile.CurrentStorageWrapper : new ITStorageWrapper(_associatedFile.ChmFilePath, enumStorage: false));
					fileObject2 = iTStorageWrapper2.OpenUCOMStream(null, hhcTopic2);
					if (fileObject2 != null)
					{
						string hhcFile2 = fileObject2.ReadFromFile(_associatedFile.TextEncoding);
						fileObject2.Close();
						if (HHCParser.HasGlobalObjectTag(hhcFile2, _associatedFile))
						{
							result = hhcTopic2;
							break;
						}
					}
				}
			}
		}
		return result;
	}

	internal void SetDefaultTopic(string local)
	{
		_defaultTopic = local;
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
			_binaryFileData = null;
		}
		disposed = true;
	}
}
