using System;
using System.Collections;
using System.IO;
using System.Web;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMBtree : IDisposable
{
	private const int BLOCK_SIZE = 2048;

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private int _flags = 0;

	private byte[] _dataFormat = new byte[16];

	private int _indexOfLastListingBlock = 0;

	private int _indexOfRootBlock = 0;

	private int _numberOfBlocks = 0;

	private int _treeDepth = 0;

	private int _numberOfKeywords = 0;

	private int _codePage = 0;

	private bool _isCHI_CHM = true;

	private CHMFile _associatedFile = null;

	private bool _readListingBlocks = true;

	private ArrayList _indexList = new ArrayList();

	internal ArrayList IndexList => _indexList;

	public CHMBtree(byte[] binaryFileData, CHMFile associatedFile)
	{
		if (associatedFile == null)
		{
			throw new ArgumentException("CHMBtree.ctor() - Associated CHMFile must not be null !", "associatedFile");
		}
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		_binaryFileData = null;
	}

	private bool DecodeData()
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(_binaryFileData);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		int num = 0;
		int num2 = 0;
		binaryReader.ReadChars(2);
		_flags = binaryReader.ReadInt16();
		binaryReader.ReadInt16();
		_dataFormat = binaryReader.ReadBytes(16);
		binaryReader.ReadInt32();
		_indexOfLastListingBlock = binaryReader.ReadInt32();
		_indexOfRootBlock = binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		_numberOfBlocks = binaryReader.ReadInt32();
		_treeDepth = binaryReader.ReadInt16();
		_numberOfKeywords = binaryReader.ReadInt32();
		_codePage = binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		num2 = binaryReader.ReadInt32();
		_isCHI_CHM = num2 == 1;
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		while (memoryStream.Position < memoryStream.Length && flag)
		{
			num = (int)memoryStream.Position;
			byte[] dataBlock = binaryReader.ReadBytes(2048);
			flag &= DecodeBlock(dataBlock, ref num, _treeDepth - 1);
		}
		return flag;
	}

	private bool DecodeBlock(byte[] dataBlock, ref int nOffset, int indexBlocks)
	{
		bool result = true;
		int num = nOffset;
		MemoryStream input = new MemoryStream(dataBlock);
		BinaryReader binReader = new BinaryReader(input);
		int count = binReader.ReadInt16();
		int num2 = binReader.ReadInt16();
		bool flag = false;
		int num3 = -1;
		int num4 = -1;
		int num5 = 0;
		if (_readListingBlocks)
		{
			num3 = binReader.ReadInt32();
			num4 = binReader.ReadInt32();
		}
		else
		{
			num5 = binReader.ReadInt32();
		}
		for (int i = 0; i < num2; i++)
		{
			if (_readListingBlocks)
			{
				flag = num4 == -1;
				string keyWord = BinaryReaderHelp.ExtractUTF16String(ref binReader, 0, noOffset: true, _associatedFile.TextEncoding);
				bool flag2 = binReader.ReadInt16() != 0;
				int indent = binReader.ReadInt16();
				int charIndex = binReader.ReadInt32();
				binReader.ReadInt32();
				int num6 = binReader.ReadInt32();
				int[] array = new int[num6];
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					if (flag2)
					{
						array2[j] = HttpUtility.HtmlDecode(BinaryReaderHelp.ExtractUTF16String(ref binReader, 0, noOffset: true, _associatedFile.TextEncoding));
					}
					else
					{
						array[j] = binReader.ReadInt32();
					}
				}
				binReader.ReadInt32();
				int entryIndex = binReader.ReadInt32();
				IndexItem value = new IndexItem(_associatedFile, keyWord, flag2, indent, charIndex, entryIndex, array2, array);
				_indexList.Add(value);
				continue;
			}
			string keyWord2 = BinaryReaderHelp.ExtractUTF16String(ref binReader, 0, noOffset: true, _associatedFile.TextEncoding);
			bool flag3 = binReader.ReadInt16() != 0;
			int indent2 = binReader.ReadInt16();
			int charIndex2 = binReader.ReadInt32();
			binReader.ReadInt32();
			int num7 = binReader.ReadInt32();
			int[] array3 = new int[num7];
			string[] array4 = new string[num7];
			for (int k = 0; k < num7; k++)
			{
				if (flag3)
				{
					array4[k] = BinaryReaderHelp.ExtractUTF16String(ref binReader, 0, noOffset: true, _associatedFile.TextEncoding);
				}
				else
				{
					array3[k] = binReader.ReadInt32();
				}
			}
			int num8 = binReader.ReadInt32();
			int entryIndex2 = -1;
			IndexItem value2 = new IndexItem(_associatedFile, keyWord2, flag3, indent2, charIndex2, entryIndex2, array4, array3);
			_indexList.Add(value2);
		}
		binReader.ReadBytes(count);
		if (flag)
		{
			_readListingBlocks = false;
		}
		return result;
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
