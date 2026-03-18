using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMTocidx : IDisposable
{
	private const int BLOCK_SIZE = 4096;

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private int _offset2028 = 0;

	private int _offset16structs = 0;

	private int _numberOf16structs = 0;

	private int _offsetOftopics = 0;

	private ArrayList _toc = new ArrayList();

	private Hashtable _offsetTable = new Hashtable();

	private CHMFile _associatedFile = null;

	internal ArrayList TOC => _toc;

	public CHMTocidx(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		_binaryFileData = null;
	}

	private bool DecodeData()
	{
		_toc = new ArrayList();
		_offsetTable = new Hashtable();
		bool result = true;
		MemoryStream input = new MemoryStream(_binaryFileData);
		BinaryReader binReader = new BinaryReader(input);
		int num = 0;
		_offset2028 = binReader.ReadInt32();
		_offset16structs = binReader.ReadInt32();
		_numberOf16structs = binReader.ReadInt32();
		_offsetOftopics = binReader.ReadInt32();
		binReader.BaseStream.Seek(_offset2028, SeekOrigin.Begin);
		if (RecursivelyBuildTree(ref binReader, _offset2028, _toc, null))
		{
			binReader.BaseStream.Seek(_offset16structs, SeekOrigin.Begin);
			num = (int)binReader.BaseStream.Position;
			for (int i = 0; i < _numberOf16structs; i++)
			{
				int num2 = binReader.ReadInt32();
				int num3 = binReader.ReadInt32();
				int num4 = binReader.ReadInt32();
				int num5 = binReader.ReadInt32();
				num = (int)binReader.BaseStream.Position;
				int num6 = -1;
				if (num4 >= binReader.BaseStream.Length - 4 || num4 < _offsetOftopics)
				{
					continue;
				}
				binReader.BaseStream.Seek(num4, SeekOrigin.Begin);
				num6 = binReader.ReadInt32();
				binReader.BaseStream.Seek(num, SeekOrigin.Begin);
				TOCItem tOCItem = (TOCItem)_offsetTable[num2.ToString()];
				if (tOCItem != null && num6 < _associatedFile.TopicsFile.TopicTable.Count && num6 >= 0)
				{
					TopicEntry topicEntry = (TopicEntry)_associatedFile.TopicsFile.TopicTable[num6];
					if (topicEntry != null && tOCItem.TopicOffset < 0)
					{
						tOCItem.TopicOffset = topicEntry.EntryOffset;
					}
				}
			}
		}
		return result;
	}

	private bool RecursivelyBuildTree(ref BinaryReader binReader, int NodeOffset, ArrayList level, TOCItem parentItem)
	{
		bool flag = true;
		int num = 0;
		int num2 = (int)binReader.BaseStream.Position;
		binReader.BaseStream.Seek(NodeOffset, SeekOrigin.Begin);
		do
		{
			int num3 = (int)binReader.BaseStream.Position;
			int num4 = binReader.ReadInt16();
			int num5 = binReader.ReadInt16();
			int num6 = binReader.ReadInt32();
			int num7 = 0;
			if (_associatedFile != null && _associatedFile.ImageTypeFolder)
			{
				num7 = ((!HtmlHelpSystem.UseHH2TreePics) ? 4 : 8);
			}
			int num8 = (HtmlHelpSystem.UseHH2TreePics ? (4 + num7) : num7);
			int num9 = (HtmlHelpSystem.UseHH2TreePics ? 16 : 10);
			int imageIndex = (((num6 & 4) != 0) ? num8 : num9);
			int num10 = binReader.ReadInt32();
			int num11 = binReader.ReadInt32();
			num = binReader.ReadInt32();
			int num12 = 0;
			int num13 = 0;
			if ((num6 & 4) != 0)
			{
				num12 = binReader.ReadInt32();
				num13 = binReader.ReadInt32();
			}
			TOCItem tOCItem = new TOCItem();
			tOCItem.ImageIndex = imageIndex;
			tOCItem.Offset = num3;
			tOCItem.OffsetNext = num;
			tOCItem.AssociatedFile = _associatedFile;
			tOCItem.TocMode = DataMode.Binary;
			tOCItem.Parent = parentItem;
			if ((num6 & 8) == 0)
			{
				tOCItem.Name = _associatedFile.StringsFile[num10];
			}
			else if (num10 < _associatedFile.TopicsFile.TopicTable.Count && num10 >= 0)
			{
				TopicEntry topicEntry = (TopicEntry)_associatedFile.TopicsFile.TopicTable[num10];
				if (topicEntry != null)
				{
					tOCItem.TopicOffset = topicEntry.EntryOffset;
				}
			}
			_offsetTable[num3.ToString()] = tOCItem;
			if (num12 > 0)
			{
				flag &= RecursivelyBuildTree(ref binReader, num12, tOCItem.Children, tOCItem);
			}
			level.Add(tOCItem);
			if (num3 != num)
			{
				binReader.BaseStream.Seek(num, SeekOrigin.Begin);
			}
		}
		while (num != 0);
		binReader.BaseStream.Seek(num2, SeekOrigin.Begin);
		return flag;
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
			_toc = null;
			_offsetTable = null;
		}
		disposed = true;
	}
}
