using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMUrlstr : IDisposable
{
	private const int BLOCK_SIZE = 4096;

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private Hashtable _urlDictionary = new Hashtable();

	private Hashtable _framenameDictionary = new Hashtable();

	private CHMFile _associatedFile = null;

	public CHMUrlstr(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
		_binaryFileData = null;
	}

	internal CHMUrlstr()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_urlDictionary.Count);
		if (_urlDictionary.Count != 0)
		{
			IDictionaryEnumerator enumerator = _urlDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				writer.Write(int.Parse(dictionaryEntry.Key.ToString()));
				writer.Write(dictionaryEntry.Value.ToString());
			}
		}
		writer.Write(_framenameDictionary.Count);
		if (_framenameDictionary.Count != 0)
		{
			IDictionaryEnumerator enumerator2 = _framenameDictionary.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)enumerator2.Current;
				writer.Write(int.Parse(dictionaryEntry2.Key.ToString()));
				writer.Write(dictionaryEntry2.Value.ToString());
			}
		}
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		int num = 0;
		int num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			int num3 = reader.ReadInt32();
			string value = reader.ReadString();
			_urlDictionary[num3.ToString()] = value;
		}
		num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			int num4 = reader.ReadInt32();
			string value2 = reader.ReadString();
			_framenameDictionary[num4.ToString()] = value2;
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
		bool flag = true;
		int num = nOffset;
		MemoryStream memoryStream = new MemoryStream(dataBlock);
		BinaryReader binReader = new BinaryReader(memoryStream);
		if (nOffset == 0)
		{
			binReader.ReadByte();
		}
		while (memoryStream.Position < memoryStream.Length - 8 && flag)
		{
			int num2 = num + (int)memoryStream.Position;
			int num3 = binReader.ReadInt32();
			int num4 = binReader.ReadInt32();
			bool bFoundTerminator = false;
			string text = BinaryReaderHelp.ExtractString(ref binReader, ref bFoundTerminator, 0, noOffset: true, _associatedFile.TextEncoding);
			if (text == "")
			{
				memoryStream.Seek(memoryStream.Length - 1, SeekOrigin.Begin);
				continue;
			}
			_urlDictionary[num2.ToString()] = text.ToString();
			_framenameDictionary[num2.ToString()] = text.ToString();
		}
		return flag;
	}

	public string GetURLatOffset(int offset)
	{
		if (offset == -1)
		{
			return string.Empty;
		}
		string text = (string)_urlDictionary[offset.ToString()];
		if (text == null)
		{
			return string.Empty;
		}
		return text;
	}

	public string GetFrameNameatOffset(int offset)
	{
		if (offset == -1)
		{
			return string.Empty;
		}
		string text = (string)_framenameDictionary[offset.ToString()];
		if (text == null)
		{
			return string.Empty;
		}
		return text;
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
			_urlDictionary = null;
			_framenameDictionary = null;
		}
		disposed = true;
	}
}
