#define DEBUG
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HtmlHelp.ChmDecoding;

internal sealed class FullTextEngine : IDisposable
{
	private sealed class FTHeader
	{
		private int _numberOfIndexFiles = 0;

		private int _rootOffset = 0;

		private int _pageCount = 0;

		private int _depth = 0;

		private byte _scaleDocIdx = 0;

		private byte _scaleCodeCnt = 0;

		private byte _scaleLocCodes = 0;

		private byte _rootDocIdx = 0;

		private byte _rootCodeCnt = 0;

		private byte _rootLocCodes = 0;

		private int _nodeSize = 0;

		private int _lengthOfLongestWord = 0;

		private int _totalNumberOfWords = 0;

		private int _numberOfUniqueWords = 0;

		private int _codePage = 1252;

		private int _lcid = 1033;

		private Encoding _textEncoder = Encoding.Default;

		public int IndexedFileCount => _numberOfIndexFiles;

		public int RootOffset => _rootOffset;

		public int PageCount => _pageCount;

		public int Depth => _depth;

		public byte ScaleDocumentIndex => _scaleDocIdx;

		public byte RootDocumentIndex => _rootDocIdx;

		public byte ScaleCodeCount => _scaleCodeCnt;

		public byte RootCodeCount => _rootCodeCnt;

		public byte ScaleLocationCodes => _scaleLocCodes;

		public byte RootLocationCodes => _rootLocCodes;

		public int NodeSize => _nodeSize;

		private int LengthOfLongestWord => _lengthOfLongestWord;

		public int TotalWordCount => _totalNumberOfWords;

		public int UniqueWordCount => _numberOfUniqueWords;

		public int CodePage => _codePage;

		public int LCID => _lcid;

		public Encoding TextEncoder => _textEncoder;

		public FTHeader(byte[] binaryData)
		{
			DecodeHeader(binaryData);
		}

		internal FTHeader()
		{
		}

		private void DecodeHeader(byte[] binaryData)
		{
			MemoryStream input = new MemoryStream(binaryData);
			BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.ReadBytes(4);
			_numberOfIndexFiles = binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			_pageCount = binaryReader.ReadInt32();
			_rootOffset = binaryReader.ReadInt32();
			_depth = binaryReader.ReadInt16();
			binaryReader.ReadInt32();
			_scaleDocIdx = binaryReader.ReadByte();
			_rootDocIdx = binaryReader.ReadByte();
			_scaleCodeCnt = binaryReader.ReadByte();
			_rootCodeCnt = binaryReader.ReadByte();
			_scaleLocCodes = binaryReader.ReadByte();
			_rootLocCodes = binaryReader.ReadByte();
			if (_scaleDocIdx != 2 || _scaleCodeCnt != 2 || _scaleLocCodes != 2)
			{
				Debug.WriteLine("Unsupported scale for s/r encoding !");
				throw new InvalidOperationException("Unsupported scale for s/r encoding !");
			}
			binaryReader.ReadBytes(10);
			_nodeSize = binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			_lengthOfLongestWord = binaryReader.ReadInt32();
			_totalNumberOfWords = binaryReader.ReadInt32();
			_numberOfUniqueWords = binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
			binaryReader.ReadBytes(24);
			_codePage = binaryReader.ReadInt32();
			_lcid = binaryReader.ReadInt32();
			CultureInfo cultureInfo = new CultureInfo(_lcid);
			_textEncoder = Encoding.GetEncoding(cultureInfo.TextInfo.ANSICodePage);
		}

		internal void Dump(ref BinaryWriter writer)
		{
			writer.Write(_numberOfIndexFiles);
			writer.Write(_rootOffset);
			writer.Write(_pageCount);
			writer.Write(_depth);
			writer.Write(_scaleDocIdx);
			writer.Write(_rootDocIdx);
			writer.Write(_scaleCodeCnt);
			writer.Write(_rootCodeCnt);
			writer.Write(_scaleLocCodes);
			writer.Write(_rootLocCodes);
			writer.Write(_nodeSize);
			writer.Write(_lengthOfLongestWord);
			writer.Write(_totalNumberOfWords);
			writer.Write(_numberOfUniqueWords);
		}

		internal void ReadDump(ref BinaryReader reader)
		{
			_numberOfIndexFiles = reader.ReadInt32();
			_rootOffset = reader.ReadInt32();
			_pageCount = reader.ReadInt32();
			_depth = reader.ReadInt32();
			_scaleDocIdx = reader.ReadByte();
			_rootDocIdx = reader.ReadByte();
			_scaleCodeCnt = reader.ReadByte();
			_rootCodeCnt = reader.ReadByte();
			_scaleLocCodes = reader.ReadByte();
			_rootLocCodes = reader.ReadByte();
			_nodeSize = reader.ReadInt32();
			_lengthOfLongestWord = reader.ReadInt32();
			_totalNumberOfWords = reader.ReadInt32();
			_numberOfUniqueWords = reader.ReadInt32();
		}
	}

	private sealed class HitHelper : IComparable
	{
		private int _documentIndex = 0;

		private string _title = "";

		private string _locale = "";

		private string _location = "";

		private string _url = "";

		private double _rating = 0.0;

		private Hashtable _partialRating = new Hashtable();

		internal Hashtable PartialRating => _partialRating;

		public int DocumentIndex => _documentIndex;

		public string Title => _title;

		public string Locale => _locale;

		public string Location => _location;

		public string URL => _url;

		public double Rating => _rating;

		public HitHelper(int documentIndex, string title, string locale, string location, string url, double rating)
		{
			_documentIndex = documentIndex;
			_title = title;
			_locale = locale;
			_location = location;
			_url = url;
			_rating = rating;
		}

		public void UpdateRating(string word)
		{
			if (_partialRating[word] == null)
			{
				_partialRating[word] = 100.0;
			}
			else
			{
				_partialRating[word] = (double)_partialRating[word] * 1.01;
			}
			_rating = 0.0;
			foreach (double value in _partialRating.Values)
			{
				_rating += value;
			}
		}

		public int CompareTo(object obj)
		{
			if (obj is HitHelper)
			{
				HitHelper hitHelper = (HitHelper)obj;
				return Rating.CompareTo(hitHelper.Rating);
			}
			return -1;
		}
	}

	private string RE_Quotes = "\\\"(?<innerText>.*?)\\\"";

	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private FTHeader _header = null;

	private CHMFile _associatedFile = null;

	public bool CanSearch => _associatedFile.SystemFile.FullTextSearch && _header != null;

	public FullTextEngine(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		if (_associatedFile.SystemFile.FullTextSearch)
		{
			_header = new FTHeader(_binaryFileData);
		}
	}

	internal FullTextEngine()
	{
	}

	internal void Dump(ref BinaryWriter writer)
	{
		_header.Dump(ref writer);
		writer.Write(_binaryFileData.Length);
		writer.Write(_binaryFileData);
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		_header = new FTHeader();
		_header.ReadDump(ref reader);
		int count = reader.ReadInt32();
		_binaryFileData = reader.ReadBytes(count);
	}

	internal void SetCHMFile(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
	}

	public DataTable Search(string search, bool partialMatches, bool titleOnly)
	{
		return Search(search, -1, partialMatches, titleOnly);
	}

	public DataTable Search(string search, int MaxHits, bool partialMatches, bool titleOnly)
	{
		if (CanSearch)
		{
			string text = search;
			bool flag = search.IndexOf("\"") > -1;
			if (flag)
			{
				text = search.Replace("\"", "");
			}
			bool flag2 = true;
			ArrayList arrayList = new ArrayList();
			DataTable createHitsTable = GetCreateHitsTable();
			string[] array = text.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				flag2 &= SearchSingleWord(array[i], MaxHits, partialMatches, titleOnly, arrayList);
				if (arrayList.Count >= MaxHits)
				{
					break;
				}
			}
			if (flag2 && flag)
			{
				FinalizeQuoted(search, arrayList);
			}
			if (flag2)
			{
				arrayList.Sort();
				int num = MaxHits;
				if (MaxHits < 0)
				{
					num = arrayList.Count;
				}
				if (num > arrayList.Count)
				{
					num = arrayList.Count;
				}
				for (int num2 = num; num2 > 0; num2--)
				{
					HitHelper hitHelper = (HitHelper)arrayList[num2 - 1];
					DataRow dataRow = createHitsTable.NewRow();
					dataRow["Rating"] = hitHelper.Rating;
					dataRow["Title"] = hitHelper.Title;
					dataRow["Locale"] = hitHelper.Locale;
					dataRow["Location"] = hitHelper.Location;
					dataRow["URL"] = hitHelper.URL;
					createHitsTable.Rows.Add(dataRow);
				}
			}
			return flag2 ? createHitsTable : null;
		}
		return null;
	}

	private void FinalizeQuoted(string search, ArrayList hitsHelper)
	{
		Regex regex = new Regex(RE_Quotes, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		int num = regex.GroupNumberFromName("innerText");
		int startat = 0;
		while (regex.IsMatch(search, startat))
		{
			Match match = regex.Match(search, startat);
			string value = match.Groups["innerText"].Value;
			string[] wordsInPhrase = value.Split(' ');
			int count = hitsHelper.Count;
			for (int i = 0; i < hitsHelper.Count; i++)
			{
				if (!CheckHit((HitHelper)hitsHelper[i], wordsInPhrase))
				{
					hitsHelper.RemoveAt(i--);
				}
			}
			startat = match.Index + match.Length;
		}
	}

	private bool CheckHit(HitHelper hit, string[] wordsInPhrase)
	{
		for (int i = 0; i < wordsInPhrase.Length; i++)
		{
			if (hit.PartialRating[wordsInPhrase[i]] == null || (double)hit.PartialRating[wordsInPhrase[i]] == 0.0)
			{
				return false;
			}
		}
		return true;
	}

	private bool SearchSingleWord(string word, int MaxHits, bool partialMatches, bool titleOnly, ArrayList hitsHelper)
	{
		string strB = word.ToLower();
		MemoryStream input = new MemoryStream(_binaryFileData);
		BinaryReader binReader = new BinaryReader(input);
		binReader.BaseStream.Seek(_header.RootOffset, SeekOrigin.Begin);
		if (_header.Depth > 2)
		{
			Debug.WriteLine("FullTextSearcher.SearchSingleWord() - Failed with message: Unsupported index depth !");
			Debug.WriteLine("File: " + _associatedFile.ChmFilePath);
			Debug.WriteLine(" ");
			return false;
		}
		if (_header.Depth > 1)
		{
			int num = binReader.ReadInt16();
			for (int i = 0; i < _header.PageCount; i++)
			{
				int num2 = binReader.ReadByte();
				int num3 = binReader.ReadByte();
				string text = BinaryReaderHelp.ExtractString(ref binReader, num2 - 1, 0, noOffset: true, _header.TextEncoder);
				int num4 = binReader.ReadInt32();
				binReader.ReadInt16();
				if (text.CompareTo(strB) >= 0)
				{
					long position = binReader.BaseStream.Position;
					binReader.BaseStream.Seek(num4, SeekOrigin.Begin);
					ReadLeafNode(ref binReader, word, MaxHits, partialMatches, titleOnly, hitsHelper);
					binReader.BaseStream.Seek(position, SeekOrigin.Begin);
				}
			}
		}
		return true;
	}

	private void ReadLeafNode(ref BinaryReader binReader, string word, int MaxHits, bool partialMatches, bool titleOnly, ArrayList hitsHelper)
	{
		int num = binReader.ReadInt32();
		binReader.ReadInt16();
		int num2 = binReader.ReadInt16();
		string text = "";
		bool flag = false;
		string text2 = word.ToLower();
		while (binReader.BaseStream.Position < binReader.BaseStream.Length)
		{
			int num3 = binReader.ReadByte();
			if (num3 == 0)
			{
				break;
			}
			int num4 = binReader.ReadByte();
			string text3 = BinaryReaderHelp.ExtractString(ref binReader, num3 - 1, 0, noOffset: true, _header.TextEncoder);
			int num5 = binReader.ReadByte();
			long num6 = BinaryReaderHelp.ReadENCINT(ref binReader);
			int num7 = binReader.ReadInt32();
			binReader.ReadInt16();
			long num8 = BinaryReaderHelp.ReadENCINT(ref binReader);
			text = ((num4 <= 0) ? text3 : CombineStrings(text, text3, num4));
			flag = false;
			flag = ((!partialMatches) ? (text == text2) : (text.IndexOf(text2) >= 0));
			if (flag && ((titleOnly && num5 == 1) || !titleOnly))
			{
				long position = binReader.BaseStream.Position;
				binReader.BaseStream.Seek(num7, SeekOrigin.Begin);
				byte[] wclBytes = binReader.ReadBytes((int)num8);
				DecodeWCL(wclBytes, MaxHits, word, hitsHelper);
				binReader.BaseStream.Seek(position, SeekOrigin.Begin);
			}
		}
	}

	private void DecodeWCL(byte[] wclBytes, int MaxHits, string word, ArrayList hitsHelper)
	{
		byte[] array = new byte[wclBytes.Length * 8];
		int num = 0;
		for (int i = 0; i < wclBytes.Length; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				array[num] = (((byte)(wclBytes[i] & (byte)(1 << 7 - j)) > 0) ? ((byte)1) : ((byte)0));
				num++;
			}
		}
		num = 0;
		int num2 = 0;
		while (num < array.Length)
		{
			num2 += BinaryReaderHelp.ReadSRItem(array, _header.ScaleDocumentIndex, _header.RootDocumentIndex, ref num);
			int num3 = BinaryReaderHelp.ReadSRItem(array, _header.ScaleCodeCount, _header.RootCodeCount, ref num);
			int num4 = 0;
			for (int k = 0; k < num3; k++)
			{
				num4 += BinaryReaderHelp.ReadSRItem(array, _header.ScaleLocationCodes, _header.RootLocationCodes, ref num);
			}
			for (; num % 8 != 0; num++)
			{
			}
			HitHelper hitHelper = DocumentHit(num2, hitsHelper);
			if (hitHelper == null)
			{
				if (hitsHelper.Count > MaxHits)
				{
					break;
				}
				hitHelper = new HitHelper(num2, ((TopicEntry)_associatedFile.TopicsFile.TopicTable[num2]).Title, ((TopicEntry)_associatedFile.TopicsFile.TopicTable[num2]).Locale, _associatedFile.CompileFile, ((TopicEntry)_associatedFile.TopicsFile.TopicTable[num2]).URL, 0.0);
				for (int l = 0; l < num3; l++)
				{
					hitHelper.UpdateRating(word);
				}
				hitsHelper.Add(hitHelper);
			}
			else
			{
				for (int m = 0; m < num3; m++)
				{
					hitHelper.UpdateRating(word);
				}
			}
		}
	}

	private string CombineStrings(string word, string partial, int partialPosition)
	{
		string text = word;
		int num = 0;
		for (num = 0; num < partial.Length; num++)
		{
			if (num + partialPosition > text.Length - 1)
			{
				text += partial[num];
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace(text[partialPosition + num], partial[num], partialPosition + num, 1);
			text = stringBuilder.ToString();
		}
		if (num + partialPosition <= text.Length - 1)
		{
			text = text.Substring(0, partialPosition + partial.Length);
		}
		return text;
	}

	private HitHelper DocumentHit(int index, ArrayList hitsHelper)
	{
		foreach (HitHelper item in hitsHelper)
		{
			if (item.DocumentIndex == index)
			{
				return item;
			}
		}
		return null;
	}

	private DataTable GetCreateHitsTable()
	{
		DataTable dataTable = new DataTable("FT_Search_Hits");
		DataColumn dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.Double");
		dataColumn.ColumnName = "Rating";
		dataColumn.ReadOnly = false;
		dataColumn.Unique = false;
		dataTable.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Title";
		dataColumn.ReadOnly = false;
		dataColumn.Unique = false;
		dataTable.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Locale";
		dataColumn.ReadOnly = false;
		dataColumn.Unique = false;
		dataTable.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "Location";
		dataColumn.ReadOnly = false;
		dataColumn.Unique = false;
		dataTable.Columns.Add(dataColumn);
		dataColumn = new DataColumn();
		dataColumn.DataType = Type.GetType("System.String");
		dataColumn.ColumnName = "URL";
		dataColumn.ReadOnly = false;
		dataColumn.Unique = false;
		dataTable.Columns.Add(dataColumn);
		return dataTable;
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
