using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMStrings : IDisposable
{
	private const int STRING_BLOCK_SIZE = 4096;

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private Hashtable _stringDictionary = new Hashtable();

	private CHMFile _associatedFile = null;

	public string this[int offset]
	{
		get
		{
			if (offset == -1)
			{
				return string.Empty;
			}
			string text = (string)_stringDictionary[offset.ToString()];
			if (text == null)
			{
				return string.Empty;
			}
			return text;
		}
	}

	public string this[string offset]
	{
		get
		{
			if (offset == "-1")
			{
				return string.Empty;
			}
			string text = (string)_stringDictionary[offset];
			if (text == null)
			{
				return string.Empty;
			}
			return text;
		}
	}

	public CHMStrings(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
	}

	internal CHMStrings()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_stringDictionary.Count);
		if (_stringDictionary.Count != 0)
		{
			IDictionaryEnumerator enumerator = _stringDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				writer.Write(int.Parse(dictionaryEntry.Key.ToString()));
				writer.Write(dictionaryEntry.Value.ToString());
			}
		}
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			int num2 = reader.ReadInt32();
			string value = reader.ReadString();
			_stringDictionary[num2.ToString()] = value;
		}
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
	}

	private bool DecodeData()
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(_binaryFileData);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		int num = 0;
		int nSubsetOffset = 0;
		while (memoryStream.Position < memoryStream.Length && flag)
		{
			num = (int)memoryStream.Position;
			byte[] stringBlock = binaryReader.ReadBytes(4096);
			flag &= DecodeBlock(stringBlock, ref num, ref nSubsetOffset);
		}
		return flag;
	}

	private bool DecodeBlock(byte[] stringBlock, ref int nStringOffset, ref int nSubsetOffset)
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(stringBlock);
		BinaryReader binReader = new BinaryReader(memoryStream);
		while (memoryStream.Position < memoryStream.Length && flag)
		{
			bool bFoundTerminator = false;
			int num = nStringOffset + (int)memoryStream.Position;
			string text = BinaryReaderHelp.ExtractString(ref binReader, ref bFoundTerminator, 0, noOffset: true, _associatedFile.TextEncoding);
			if (nSubsetOffset != 0)
			{
				_stringDictionary[nSubsetOffset.ToString()] = text.ToString();
			}
			else
			{
				_stringDictionary[num.ToString()] = text.ToString();
			}
			if (bFoundTerminator)
			{
				nSubsetOffset = 0;
			}
			else
			{
				nSubsetOffset = num;
			}
		}
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
			_stringDictionary = null;
		}
		disposed = true;
	}
}
