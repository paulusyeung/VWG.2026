using System.IO;
using System.Text;
using HtmlHelp.ChmDecoding;
using HtmlHelp.Storage;

namespace HtmlHelp;

public sealed class IndexTopic
{
	private DataMode _topicMode = DataMode.TextBased;

	private string _title = "";

	private string _local = "";

	private string _compileFile = "";

	private string _chmPath = "";

	private int _topicOffset = -1;

	private CHMFile _associatedFile = null;

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

	public string Title
	{
		get
		{
			if (_topicMode == DataMode.Binary && _associatedFile != null && _topicOffset >= 0)
			{
				TopicEntry topicEntry = _associatedFile.TopicsFile[_topicOffset];
				if (topicEntry != null)
				{
					return topicEntry.Title;
				}
			}
			return _title;
		}
	}

	public string Local
	{
		get
		{
			if (_topicMode == DataMode.Binary && _associatedFile != null && _topicOffset >= 0)
			{
				TopicEntry topicEntry = _associatedFile.TopicsFile[_topicOffset];
				if (topicEntry != null)
				{
					return topicEntry.Locale;
				}
			}
			return _local;
		}
	}

	public string CompileFile
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.CompileFile;
			}
			return _compileFile;
		}
	}

	public string ChmFilePath
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.ChmFilePath;
			}
			return _chmPath;
		}
	}

	public string URL
	{
		get
		{
			string local = Local;
			if (local.Length <= 0)
			{
				return "";
			}
			if (local.ToLower().IndexOf("http://") >= 0 || local.ToLower().IndexOf("https://") >= 0 || local.ToLower().IndexOf("mailto:") >= 0 || local.ToLower().IndexOf("ftp://") >= 0)
			{
				return local;
			}
			return HtmlHelpSystem.UrlPrefix + ChmFilePath + "::/" + local;
		}
	}

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

	internal static IndexTopic FromTopicEntry(TopicEntry entry)
	{
		return new IndexTopic(entry.EntryOffset, entry.ChmFile);
	}

	internal IndexTopic(int topicOffset, CHMFile associatedFile)
	{
		_topicMode = DataMode.Binary;
		_topicOffset = topicOffset;
		_associatedFile = associatedFile;
	}

	public IndexTopic(string Title, string local, string compilefile, string chmpath)
	{
		_topicMode = DataMode.TextBased;
		_title = Title;
		_local = local;
		_compileFile = compilefile;
		_chmPath = chmpath;
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write((int)_topicMode);
		if (_topicMode == DataMode.TextBased)
		{
			writer.Write(_title);
			writer.Write(_local);
		}
		else
		{
			writer.Write(_topicOffset);
		}
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		_topicMode = (DataMode)reader.ReadInt32();
		if (_topicMode == DataMode.TextBased)
		{
			_title = reader.ReadString();
			_local = reader.ReadString();
		}
		else
		{
			_topicOffset = reader.ReadInt32();
		}
	}

	internal void SetChmInfo(string compilefile, string chmpath)
	{
		_compileFile = compilefile;
		_chmPath = chmpath;
	}
}
