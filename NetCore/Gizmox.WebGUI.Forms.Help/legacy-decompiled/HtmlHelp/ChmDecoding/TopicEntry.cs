using System.IO;
using System.Text;
using HtmlHelp.Storage;

namespace HtmlHelp.ChmDecoding;

public sealed class TopicEntry
{
	private int _entryOffset = 0;

	private int _tocidxOffset = 0;

	private int _titleOffset = 0;

	private int _urltableOffset = 0;

	private int _visibilityMode = 0;

	private int _unknownMode = 0;

	private CHMFile _associatedFile = null;

	internal CHMFile ChmFile => _associatedFile;

	internal int EntryOffset => _entryOffset;

	internal int TOCIdxOffset => _tocidxOffset;

	internal int TitleOffset => _titleOffset;

	internal int UrlTableOffset => _urltableOffset;

	public string Title
	{
		get
		{
			if (_associatedFile == null)
			{
				return string.Empty;
			}
			if (_associatedFile.StringsFile == null)
			{
				return string.Empty;
			}
			string text = _associatedFile.StringsFile[_titleOffset];
			if (text == null)
			{
				return string.Empty;
			}
			return text;
		}
	}

	public string Locale
	{
		get
		{
			if (_associatedFile == null)
			{
				return string.Empty;
			}
			if (_associatedFile.UrltblFile == null)
			{
				return string.Empty;
			}
			UrlTableEntry urlTableEntry = _associatedFile.UrltblFile[_urltableOffset];
			if (urlTableEntry == null)
			{
				return string.Empty;
			}
			if (urlTableEntry.URL == "")
			{
				return string.Empty;
			}
			return urlTableEntry.URL;
		}
	}

	public string URL
	{
		get
		{
			if (Locale.Length <= 0)
			{
				return "about:blank";
			}
			if (Locale.ToLower().IndexOf("http://") >= 0 || Locale.ToLower().IndexOf("https://") >= 0 || Locale.ToLower().IndexOf("mailto:") >= 0 || Locale.ToLower().IndexOf("ftp://") >= 0)
			{
				return Locale;
			}
			return HtmlHelpSystem.UrlPrefix + _associatedFile.ChmFilePath + "::/" + Locale;
		}
	}

	public int VisibilityMode => _visibilityMode;

	public int UknownMode => _unknownMode;

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
			if (_associatedFile != null && Locale.Length > 0)
			{
				ITStorageWrapper chmWrapper = _associatedFile.ChmWrapper;
				FileObject fileObject = null;
				return chmWrapper.OpenUCOMStream(null, Locale);
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

	public TopicEntry(int entryOffset, int tocidxOffset, int titleOffset, int urltableOffset, int visibilityMode, int unknownMode)
		: this(entryOffset, tocidxOffset, titleOffset, urltableOffset, visibilityMode, unknownMode, null)
	{
	}

	internal TopicEntry(int entryOffset, int tocidxOffset, int titleOffset, int urltableOffset, int visibilityMode, int unknownMode, CHMFile associatedFile)
	{
		_entryOffset = entryOffset;
		_tocidxOffset = tocidxOffset;
		_titleOffset = titleOffset;
		_urltableOffset = urltableOffset;
		_visibilityMode = visibilityMode;
		_unknownMode = unknownMode;
		_associatedFile = associatedFile;
	}

	internal TopicEntry()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_entryOffset);
		writer.Write(_tocidxOffset);
		writer.Write(_titleOffset);
		writer.Write(_urltableOffset);
		writer.Write(_visibilityMode);
		writer.Write(_unknownMode);
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		_entryOffset = reader.ReadInt32();
		_tocidxOffset = reader.ReadInt32();
		_titleOffset = reader.ReadInt32();
		_urltableOffset = reader.ReadInt32();
		_visibilityMode = reader.ReadInt32();
		_unknownMode = reader.ReadInt32();
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
	}
}
