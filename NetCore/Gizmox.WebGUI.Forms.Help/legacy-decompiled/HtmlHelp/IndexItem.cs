using System;
using System.Collections;
using System.IO;
using System.Text;
using HtmlHelp.ChmDecoding;

namespace HtmlHelp;

public sealed class IndexItem : IComparable
{
	private string _keyWord = "";

	private ArrayList _infoTypeStrings = new ArrayList();

	private bool _isSeeAlso = false;

	private int _indent = 0;

	private int _charIndex = 0;

	private int _entryIndex = 0;

	private string[] _seeAlso = new string[0];

	private int[] _nTopics = new int[0];

	private ArrayList _Topics = null;

	private CHMFile _chmFile = null;

	private string _chmFileName = "";

	internal CHMFile ChmFile
	{
		get
		{
			return _chmFile;
		}
		set
		{
			_chmFile = value;
		}
	}

	internal ArrayList InfoTypeStrings => _infoTypeStrings;

	public string KeyWordPath
	{
		get
		{
			return _keyWord;
		}
		set
		{
			_keyWord = value;
		}
	}

	public string KeyWord => _keyWord.Substring(_charIndex, _keyWord.Length - _charIndex);

	public string IndentKeyWord
	{
		get
		{
			string keyWord = KeyWord;
			StringBuilder stringBuilder = new StringBuilder("", Indent * 3 + keyWord.Length);
			for (int i = 0; i < Indent; i++)
			{
				stringBuilder.Append("   ");
			}
			stringBuilder.Append(keyWord);
			return stringBuilder.ToString();
		}
	}

	public bool IsSeeAlso
	{
		get
		{
			return _isSeeAlso;
		}
		set
		{
			_isSeeAlso = value;
		}
	}

	public int Indent
	{
		get
		{
			return _indent;
		}
		set
		{
			_indent = value;
		}
	}

	public int CharIndex
	{
		get
		{
			return _charIndex;
		}
		set
		{
			_charIndex = value;
		}
	}

	public string[] SeeAlso => _seeAlso;

	public ArrayList Topics
	{
		get
		{
			if (_Topics == null)
			{
				if (IsSeeAlso)
				{
					_Topics = new ArrayList();
				}
				else if (_chmFile != null && _chmFile.TopicsFile != null)
				{
					_Topics = new ArrayList();
					for (int i = 0; i < _nTopics.Length; i++)
					{
						IndexTopic indexTopic = IndexTopic.FromTopicEntry((TopicEntry)_chmFile.TopicsFile.TopicTable[_nTopics[i]]);
						indexTopic.AssociatedFile = _chmFile;
						_Topics.Add(indexTopic);
					}
				}
				else
				{
					_Topics = new ArrayList();
				}
			}
			return _Topics;
		}
	}

	internal IndexItem(CHMFile chmFile, string keyWord, bool isSeeAlso, int indent, int charIndex, int entryIndex, string[] seeAlsoValues, int[] topicOffsets)
	{
		_chmFile = chmFile;
		_chmFileName = _chmFile.ChmFilePath;
		_keyWord = keyWord;
		_isSeeAlso = isSeeAlso;
		_indent = indent;
		_charIndex = charIndex;
		_entryIndex = entryIndex;
		_seeAlso = seeAlsoValues;
		_nTopics = topicOffsets;
	}

	public IndexItem()
	{
	}

	internal void Dump(ref BinaryWriter writer, bool writeFileName)
	{
		int num = 0;
		writer.Write(_keyWord);
		writer.Write(_isSeeAlso);
		writer.Write(_indent);
		if (writeFileName)
		{
			writer.Write(_chmFileName);
		}
		writer.Write(_infoTypeStrings.Count);
		for (num = 0; num < _infoTypeStrings.Count; num++)
		{
			writer.Write(_infoTypeStrings[num].ToString());
		}
		writer.Write(_seeAlso.Length);
		for (num = 0; num < _seeAlso.Length; num++)
		{
			if (_seeAlso[num] == null)
			{
				writer.Write("");
			}
			else
			{
				writer.Write(_seeAlso[num]);
			}
		}
		writer.Write(Topics.Count);
		for (num = 0; num < Topics.Count; num++)
		{
			IndexTopic indexTopic = (IndexTopic)Topics[num];
			indexTopic.Dump(ref writer);
		}
	}

	internal void Dump(ref BinaryWriter writer)
	{
		Dump(ref writer, writeFileName: false);
	}

	internal bool ReadDump(ref BinaryReader reader, ArrayList filesList)
	{
		int num = 0;
		_keyWord = reader.ReadString();
		_isSeeAlso = reader.ReadBoolean();
		_indent = reader.ReadInt32();
		_chmFileName = reader.ReadString();
		foreach (CHMFile files in filesList)
		{
			if (files.ChmFilePath == _chmFileName)
			{
				_chmFile = files;
				break;
			}
		}
		if (_chmFile == null)
		{
			return false;
		}
		int num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			string value = reader.ReadString();
			_infoTypeStrings.Add(value);
		}
		num2 = reader.ReadInt32();
		_seeAlso = new string[num2];
		for (num = 0; num < num2; num++)
		{
			_seeAlso[num] = reader.ReadString();
		}
		num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			IndexTopic indexTopic = new IndexTopic("", "", "", "");
			indexTopic.SetChmInfo(_chmFile.CompileFile, _chmFile.ChmFilePath);
			indexTopic.AssociatedFile = _chmFile;
			indexTopic.ReadDump(ref reader);
			Topics.Add(indexTopic);
		}
		return true;
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		int num = 0;
		_keyWord = reader.ReadString();
		_isSeeAlso = reader.ReadBoolean();
		_indent = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			string value = reader.ReadString();
			_infoTypeStrings.Add(value);
		}
		num2 = reader.ReadInt32();
		_seeAlso = new string[num2];
		for (num = 0; num < num2; num++)
		{
			_seeAlso[num] = reader.ReadString();
		}
		num2 = reader.ReadInt32();
		for (num = 0; num < num2; num++)
		{
			IndexTopic indexTopic = new IndexTopic("", "", "", "");
			indexTopic.AssociatedFile = _chmFile;
			indexTopic.SetChmInfo(_chmFile.CompileFile, _chmFile.ChmFilePath);
			indexTopic.ReadDump(ref reader);
			Topics.Add(indexTopic);
		}
	}

	public int CompareTo(object obj)
	{
		if (obj.GetType() == GetType())
		{
			IndexItem indexItem = (IndexItem)obj;
			return KeyWordPath.CompareTo(indexItem.KeyWordPath);
		}
		return 0;
	}

	internal void AddSeeAlso(string seeAlsoString)
	{
		string[] array = new string[_seeAlso.Length + 1];
		for (int i = 0; i < _seeAlso.Length; i++)
		{
			array[i] = _seeAlso[i];
		}
		array[_seeAlso.Length] = seeAlsoString;
		_seeAlso = array;
		_isSeeAlso = true;
	}
}
