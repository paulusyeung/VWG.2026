#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using Gizmox.WebGUI.Forms.Serialization;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace HtmlHelp.ChmDecoding;

public sealed class DumpingInfo
{
	private static readonly SerializableBitVector32.Section DumpFlags = SerializableBitVector32.CreateSection(512);

	private const string _dumpHeader = "HtmlHelpSystem dump file 1.0";

	private string _outputDir = "";

	private DumpCompression _compressionLevel = DumpCompression.Maximum;

	private CHMFile _chmFile = null;

	private DeflaterOutputStream _outputStream = null;

	private InflaterInputStream _inputStream = null;

	private BinaryWriter _writer = null;

	private BinaryReader _reader = null;

	private SerializableBitVector32 _flags;

	public bool DumpTextTOC => (_flags[DumpFlags] & 1) != 0;

	public bool DumpBinaryTOC => (_flags[DumpFlags] & 2) != 0;

	public bool DumpTextIndex => (_flags[DumpFlags] & 4) != 0;

	public bool DumpBinaryIndex => (_flags[DumpFlags] & 8) != 0;

	public bool DumpStrings => (_flags[DumpFlags] & 0x10) != 0;

	public bool DumpUrlStr => (_flags[DumpFlags] & 0x20) != 0;

	public bool DumpUrlTbl => (_flags[DumpFlags] & 0x40) != 0;

	public bool DumpTopics => (_flags[DumpFlags] & 0x80) != 0;

	public bool DumpFullText => (_flags[DumpFlags] & 0x100) != 0;

	public string OutputDir => _outputDir;

	public DumpCompression CompressionLevel => _compressionLevel;

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

	private int CompLvl => CompressionLevel switch
	{
		DumpCompression.None => 0, 
		DumpCompression.Minimum => 1, 
		DumpCompression.Medium => -1, 
		DumpCompression.Maximum => 9, 
		_ => 9, 
	};

	internal bool DumpExists
	{
		get
		{
			if (_flags[DumpFlags] == 0)
			{
				return false;
			}
			if (_reader != null || _writer != null)
			{
				return true;
			}
			string text = _chmFile.ChmFilePath;
			FileInfo fileInfo = new FileInfo(_chmFile.ChmFilePath);
			if (_outputDir.Length > 0)
			{
				text = _outputDir;
				if (text[text.Length - 1] != '\\')
				{
					text += "\\";
				}
				text += fileInfo.Name;
			}
			text += ".bin";
			return File.Exists(text);
		}
	}

	internal BinaryWriter Writer
	{
		get
		{
			if (_flags[DumpFlags] == 0)
			{
				throw new InvalidOperationException("Nothing to dump. No flags have been set !");
			}
			if (_reader != null)
			{
				throw new InvalidOperationException("Can't write and read at the same time !");
			}
			if (_chmFile == null)
			{
				throw new InvalidOperationException("Only usable with an associated CHMFile instance !");
			}
			if (_writer == null)
			{
				string text = _chmFile.ChmFilePath;
				FileInfo fileInfo = new FileInfo(_chmFile.ChmFilePath);
				if (_outputDir.Length > 0)
				{
					text = _outputDir;
					if (text[text.Length - 1] != '\\')
					{
						text += "\\";
					}
					text += fileInfo.Name;
				}
				text += ".bin";
				StreamWriter streamWriter = new StreamWriter(text, append: false, _chmFile.TextEncoding);
				BinaryWriter binaryWriter = new BinaryWriter(streamWriter.BaseStream);
				binaryWriter.Write("HtmlHelpSystem dump file 1.0");
				binaryWriter.Write((int)CompressionLevel);
				if (_compressionLevel == DumpCompression.None)
				{
					_writer = new BinaryWriter(streamWriter.BaseStream);
				}
				else
				{
					_outputStream = new DeflaterOutputStream(streamWriter.BaseStream, new Deflater(CompLvl));
					_writer = new BinaryWriter(_outputStream);
				}
			}
			return _writer;
		}
	}

	internal BinaryReader Reader
	{
		get
		{
			if (_writer != null)
			{
				throw new InvalidOperationException("Can't write and read at the same time !");
			}
			if (_chmFile == null)
			{
				throw new InvalidOperationException("Only usable with an associated CHMFile instance !");
			}
			if (_reader == null)
			{
				string text = _chmFile.ChmFilePath;
				FileInfo fileInfo = new FileInfo(_chmFile.ChmFilePath);
				if (_outputDir.Length > 0)
				{
					text = _outputDir;
					if (text[text.Length - 1] != '\\')
					{
						text += "\\";
					}
					text += fileInfo.Name;
				}
				text += ".bin";
				StreamReader streamReader = new StreamReader(text, _chmFile.TextEncoding);
				BinaryReader binaryReader = new BinaryReader(streamReader.BaseStream);
				string text2 = binaryReader.ReadString();
				if (text2 != "HtmlHelpSystem dump file 1.0")
				{
					binaryReader.Close();
					Debug.WriteLine("Unexpected dump-file header !");
					throw new FormatException("DumpingInfo.Reader - Unexpected dump-file header !");
				}
				if (_compressionLevel != (DumpCompression)binaryReader.ReadInt32())
				{
					binaryReader.Close();
					return null;
				}
				if (_compressionLevel == DumpCompression.None)
				{
					_reader = new BinaryReader(streamReader.BaseStream);
				}
				else
				{
					_inputStream = new InflaterInputStream(streamReader.BaseStream, new Inflater());
					_reader = new BinaryReader(_inputStream);
				}
			}
			return _reader;
		}
	}

	public DumpingInfo(DumpingFlags flags, string outputDir, DumpCompression compressionLevel)
	{
		_flags = new SerializableBitVector32(0);
		int num = _flags[DumpFlags];
		_flags[DumpFlags] = num | (int)flags;
		_outputDir = outputDir;
		_compressionLevel = compressionLevel;
	}

	internal bool SaveData()
	{
		if (_writer != null)
		{
			if (_writer != null)
			{
				_writer.Close();
			}
			_outputStream = null;
			_writer = null;
		}
		if (_reader != null)
		{
			if (_reader != null)
			{
				_reader.Close();
			}
			_inputStream = null;
			_reader = null;
		}
		return true;
	}
}
