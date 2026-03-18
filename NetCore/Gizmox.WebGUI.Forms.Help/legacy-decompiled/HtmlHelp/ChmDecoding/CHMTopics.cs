using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

public sealed class CHMTopics : IDisposable
{
	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private CHMFile _associatedFile = null;

	private ArrayList _topicTable = new ArrayList();

	public ArrayList TopicTable => _topicTable;

	public TopicEntry this[int offset]
	{
		get
		{
			foreach (TopicEntry item in _topicTable)
			{
				if (item.EntryOffset == offset)
				{
					return item;
				}
			}
			return null;
		}
	}

	public CHMTopics(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		_binaryFileData = null;
	}

	internal CHMTopics()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_topicTable.Count);
		foreach (TopicEntry item in _topicTable)
		{
			item.Dump(ref writer);
		}
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		int num = 0;
		int num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			TopicEntry topicEntry = new TopicEntry();
			topicEntry.SetCHMFile(_associatedFile);
			topicEntry.ReadDump(ref reader);
			_topicTable.Add(topicEntry);
		}
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
		foreach (TopicEntry item in _topicTable)
		{
			item.SetCHMFile(associatedFile);
		}
	}

	private bool DecodeData()
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(_binaryFileData);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		int num = 0;
		while (memoryStream.Position < memoryStream.Length && flag)
		{
			int entryOffset = num;
			int tocidxOffset = binaryReader.ReadInt32();
			int titleOffset = binaryReader.ReadInt32();
			int urltableOffset = binaryReader.ReadInt32();
			int visibilityMode = binaryReader.ReadInt16();
			int unknownMode = binaryReader.ReadInt16();
			TopicEntry value = new TopicEntry(entryOffset, tocidxOffset, titleOffset, urltableOffset, visibilityMode, unknownMode, _associatedFile);
			_topicTable.Add(value);
			num = (int)memoryStream.Position;
		}
		return flag;
	}

	public TopicEntry GetByLocale(string locale)
	{
		foreach (TopicEntry item in TopicTable)
		{
			if (item.Locale.ToLower() == locale.ToLower())
			{
				return item;
			}
		}
		return null;
	}

	public ArrayList GetByExtension(string fileExtension)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TopicEntry item in TopicTable)
		{
			if (item.Locale.ToLower().EndsWith(fileExtension.ToLower()))
			{
				arrayList.Add(item);
			}
		}
		if (arrayList.Count > 0)
		{
			return arrayList;
		}
		return null;
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
			_topicTable = null;
		}
		disposed = true;
	}
}
