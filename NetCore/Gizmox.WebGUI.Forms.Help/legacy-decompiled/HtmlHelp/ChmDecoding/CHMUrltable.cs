using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMUrltable : IDisposable
{
	private const int BLOCK_SIZE = 4096;

	private const int RECORDS_PER_BLOCK = 341;

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private ArrayList _urlTable = new ArrayList();

	private CHMFile _associatedFile = null;

	public ArrayList UrlTable => _urlTable;

	public UrlTableEntry this[int offset]
	{
		get
		{
			foreach (UrlTableEntry item in _urlTable)
			{
				if (item.EntryOffset == offset)
				{
					return item;
				}
			}
			return null;
		}
	}

	public CHMUrltable(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		_binaryFileData = null;
	}

	internal CHMUrltable()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_urlTable.Count);
		foreach (UrlTableEntry item in _urlTable)
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
			UrlTableEntry urlTableEntry = new UrlTableEntry();
			urlTableEntry.SetCHMFile(_associatedFile);
			urlTableEntry.ReadDump(ref reader);
			_urlTable.Add(urlTableEntry);
		}
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
		foreach (UrlTableEntry item in _urlTable)
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
			num = (int)memoryStream.Position;
			byte[] dataBlock = binaryReader.ReadBytes(4096);
			flag &= DecodeBlock(dataBlock, ref num);
		}
		return flag;
	}

	private bool DecodeBlock(byte[] dataBlock, ref int nOffset)
	{
		bool result = true;
		int num = nOffset;
		MemoryStream memoryStream = new MemoryStream(dataBlock);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		for (int i = 0; i < 341; i++)
		{
			int entryOffset = num + (int)memoryStream.Position;
			uint uniqueID = (uint)binaryReader.ReadInt32();
			int topicIndex = binaryReader.ReadInt32();
			int urlstrOffset = binaryReader.ReadInt32();
			UrlTableEntry value = new UrlTableEntry(uniqueID, entryOffset, topicIndex, urlstrOffset, _associatedFile);
			_urlTable.Add(value);
			if (memoryStream.Position >= memoryStream.Length)
			{
				break;
			}
		}
		if (dataBlock.Length == 4096)
		{
			binaryReader.ReadInt32();
		}
		return result;
	}

	public UrlTableEntry GetByUniqueID(uint uniqueID)
	{
		foreach (UrlTableEntry item in UrlTable)
		{
			if (item.UniqueID == uniqueID)
			{
				return item;
			}
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
			_urlTable = null;
		}
		disposed = true;
	}
}
