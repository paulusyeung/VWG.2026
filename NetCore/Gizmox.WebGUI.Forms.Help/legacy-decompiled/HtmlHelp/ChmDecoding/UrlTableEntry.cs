using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class UrlTableEntry
{
	private int _entryOffset = 0;

	private uint _uniqueID = 0u;

	private int _topicsIndex = 0;

	private int _urlStrOffset = 0;

	private CHMFile _associatedFile = null;

	internal uint UniqueID => _uniqueID;

	internal int EntryOffset => _entryOffset;

	internal int TopicIndex => _topicsIndex;

	internal int UrlstrOffset => _urlStrOffset;

	public string URL
	{
		get
		{
			if (_associatedFile == null)
			{
				return string.Empty;
			}
			if (_associatedFile.UrlstrFile == null)
			{
				return string.Empty;
			}
			string uRLatOffset = _associatedFile.UrlstrFile.GetURLatOffset(_urlStrOffset);
			if (uRLatOffset == null)
			{
				return string.Empty;
			}
			return uRLatOffset;
		}
	}

	internal TopicEntry Topic
	{
		get
		{
			if (_associatedFile == null)
			{
				return null;
			}
			if (_associatedFile.TopicsFile == null)
			{
				return null;
			}
			return _associatedFile.TopicsFile[_topicsIndex * 16];
		}
	}

	public UrlTableEntry(uint uniqueID, int entryOffset, int topicIndex, int urlstrOffset)
		: this(uniqueID, entryOffset, topicIndex, urlstrOffset, null)
	{
	}

	internal UrlTableEntry(uint uniqueID, int entryOffset, int topicIndex, int urlstrOffset, CHMFile associatedFile)
	{
		_uniqueID = uniqueID;
		_entryOffset = entryOffset;
		_topicsIndex = topicIndex;
		_urlStrOffset = urlstrOffset;
		_associatedFile = associatedFile;
	}

	internal UrlTableEntry()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_urlStrOffset);
		writer.Write(_entryOffset);
		writer.Write(_topicsIndex);
		writer.Write(_urlStrOffset);
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		_urlStrOffset = reader.ReadInt32();
		_entryOffset = reader.ReadInt32();
		_topicsIndex = reader.ReadInt32();
		_urlStrOffset = reader.ReadInt32();
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
	}
}
