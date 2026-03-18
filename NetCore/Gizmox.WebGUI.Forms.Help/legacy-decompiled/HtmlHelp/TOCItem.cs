using System.Collections;
using System.IO;
using System.Text;
using HtmlHelp.ChmDecoding;
using HtmlHelp.Storage;

namespace HtmlHelp;

public sealed class TOCItem
{
	public const int STD_FOLDER_HH2 = 4;

	public const int STD_FOLDER_OPEN_HH2 = 6;

	public const int STD_FILE_HH2 = 16;

	public const int STD_FOLDER_HH1 = 0;

	public const int STD_FOLDER_OPEN_HH1 = 1;

	public const int STD_FILE_HH1 = 10;

	private DataMode _tocMode = DataMode.TextBased;

	private int _offset = 0;

	private int _offsetNext = 0;

	private string _mergeLink = "";

	private string _name = "";

	private string _local = "";

	private ArrayList _infoTypeStrings = new ArrayList();

	private string _chmFile = "";

	private int _imageIndex = -1;

	private int _topicOffset = -1;

	private ArrayList _children = new ArrayList();

	private Hashtable _otherParams = new Hashtable();

	private CHMFile _associatedFile = null;

	private TOCItem _parent = null;

	internal DataMode TocMode
	{
		get
		{
			return _tocMode;
		}
		set
		{
			_tocMode = value;
		}
	}

	internal int TopicOffset
	{
		get
		{
			return _topicOffset;
		}
		set
		{
			_topicOffset = value;
		}
	}

	internal CHMFile AssociatedFile
	{
		get
		{
			return _associatedFile;
		}
		set
		{
			_associatedFile = value;
		}
	}

	internal int Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
		}
	}

	internal int OffsetNext
	{
		get
		{
			return _offsetNext;
		}
		set
		{
			_offsetNext = value;
		}
	}

	internal ArrayList InfoTypeStrings => _infoTypeStrings;

	public TOCItem Parent
	{
		get
		{
			return _parent;
		}
		set
		{
			_parent = value;
		}
	}

	public string MergeLink
	{
		get
		{
			return _mergeLink;
		}
		set
		{
			_mergeLink = value;
		}
	}

	public string Name
	{
		get
		{
			if (_mergeLink.Length > 0)
			{
				return "";
			}
			if (_name.Length <= 0 && _tocMode == DataMode.Binary && _associatedFile != null && _topicOffset >= 0)
			{
				TopicEntry topicEntry = _associatedFile.TopicsFile[_topicOffset];
				if (topicEntry != null)
				{
					return topicEntry.Title;
				}
			}
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public string Local
	{
		get
		{
			if (_mergeLink.Length > 0)
			{
				return "";
			}
			if (_local.Length <= 0 && _tocMode == DataMode.Binary && _associatedFile != null && _topicOffset >= 0)
			{
				TopicEntry topicEntry = _associatedFile.TopicsFile[_topicOffset];
				if (topicEntry != null)
				{
					return topicEntry.Locale;
				}
			}
			return _local;
		}
		set
		{
			_local = value;
		}
	}

	public string ChmFile
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.ChmFilePath;
			}
			return _chmFile;
		}
		set
		{
			_chmFile = value;
		}
	}

	public string Url
	{
		get
		{
			string local = Local;
			if (local.ToLower().IndexOf("http://") >= 0 || local.ToLower().IndexOf("https://") >= 0 || local.ToLower().IndexOf("mailto:") >= 0 || local.ToLower().IndexOf("ftp://") >= 0)
			{
				return local;
			}
			return HtmlHelpSystem.UrlPrefix + ChmFile + "::/" + local;
		}
	}

	public int ImageIndex
	{
		get
		{
			if (_imageIndex == -1)
			{
				int num = 0;
				if (_associatedFile != null && _associatedFile.ImageTypeFolder)
				{
					num = ((!HtmlHelpSystem.UseHH2TreePics) ? 4 : 8);
				}
				if (_children.Count > 0)
				{
					return HtmlHelpSystem.UseHH2TreePics ? (4 + num) : num;
				}
				return HtmlHelpSystem.UseHH2TreePics ? 16 : 10;
			}
			return _imageIndex;
		}
		set
		{
			_imageIndex = value;
		}
	}

	public ArrayList Children
	{
		get
		{
			return _children;
		}
		set
		{
			_children = value;
		}
	}

	public Hashtable Params => _otherParams;

	public Encoding TextEncoding
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.TextEncoding;
			}
			return Encoding.Default;
		}
	}

	public FileObject ContentFile
	{
		get
		{
			if (_associatedFile != null && Local.Length > 0)
			{
				ITStorageWrapper chmWrapper = _associatedFile.ChmWrapper;
				FileObject fileObject = null;
				return chmWrapper.OpenUCOMStream(null, Local);
			}
			return null;
		}
	}

	public string FileContents
	{
		get
		{
			FileObject contentFile = ContentFile;
			if (contentFile != null && contentFile.CanRead)
			{
				byte[] array = new byte[contentFile.Length];
				contentFile.Read(array, 0, (int)contentFile.Length);
				contentFile.Close();
				return TextEncoding.GetString(array);
			}
			return string.Empty;
		}
	}

	public TOCItem(string name, string local, int ImageIndex, string chmFile)
	{
		_tocMode = DataMode.TextBased;
		_name = name;
		_local = local;
		_imageIndex = ImageIndex;
		_chmFile = chmFile;
	}

	public TOCItem(int topicOffset, int ImageIndex, CHMFile associatedFile)
	{
		_tocMode = DataMode.Binary;
		_associatedFile = associatedFile;
		_chmFile = associatedFile.ChmFilePath;
		_topicOffset = topicOffset;
		_imageIndex = ImageIndex;
	}

	public TOCItem()
	{
	}

	internal void Dump(ref BinaryWriter writer, bool writeFilename)
	{
		writer.Write((int)_tocMode);
		writer.Write(_topicOffset);
		writer.Write(_name);
		if (_tocMode == DataMode.TextBased || _topicOffset < 0)
		{
			writer.Write(_local);
		}
		writer.Write(_imageIndex);
		writer.Write(_mergeLink);
		if (writeFilename)
		{
			writer.Write(_chmFile);
		}
		writer.Write(_infoTypeStrings.Count);
		for (int i = 0; i < _infoTypeStrings.Count; i++)
		{
			writer.Write(_infoTypeStrings[i].ToString());
		}
		writer.Write(_children.Count);
		for (int j = 0; j < _children.Count; j++)
		{
			TOCItem tOCItem = (TOCItem)_children[j];
			tOCItem.Dump(ref writer, writeFilename);
		}
	}

	internal void Dump(ref BinaryWriter writer)
	{
		Dump(ref writer, writeFilename: false);
	}

	internal void ReadDump(ref BinaryReader reader, bool readFilename)
	{
		int num = 0;
		_tocMode = (DataMode)reader.ReadInt32();
		_topicOffset = reader.ReadInt32();
		_name = reader.ReadString();
		if (_tocMode == DataMode.TextBased || _topicOffset < 0)
		{
			_local = reader.ReadString();
		}
		_imageIndex = reader.ReadInt32();
		_mergeLink = reader.ReadString();
		if (readFilename)
		{
			_chmFile = reader.ReadString();
		}
		int num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			string value = reader.ReadString();
			_infoTypeStrings.Add(value);
		}
		num2 = reader.ReadInt32();
		if (_associatedFile != null)
		{
			_chmFile = _associatedFile.ChmFilePath;
		}
		for (num = 0; num < num2; num++)
		{
			TOCItem tOCItem = new TOCItem();
			tOCItem.AssociatedFile = _associatedFile;
			tOCItem.ReadDump(ref reader, readFilename);
			if (_associatedFile != null)
			{
				tOCItem.ChmFile = _associatedFile.ChmFilePath;
			}
			else if (!readFilename)
			{
				tOCItem.ChmFile = _chmFile;
			}
			tOCItem.Parent = this;
			_children.Add(tOCItem);
			if (tOCItem.MergeLink.Length > 0)
			{
				_associatedFile.MergLinks.Add(tOCItem);
			}
		}
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		ReadDump(ref reader, readFilename: false);
	}
}
