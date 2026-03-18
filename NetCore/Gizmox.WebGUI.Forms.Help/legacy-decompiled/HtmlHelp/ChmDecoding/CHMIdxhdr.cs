using System;
using System.Collections;
using System.IO;

namespace HtmlHelp.ChmDecoding;

internal sealed class CHMIdxhdr : IDisposable
{
	private bool disposed = false;

	private byte[] _binaryFileData = null;

	private int _numberOfTopicNodes = 0;

	private int _imageListOffset = 0;

	private bool _imageTypeFolder = false;

	private int _background = 0;

	private int _foreground = 0;

	private int _fontOffset = 0;

	private int _frameNameOffset = 0;

	private int _windowNameOffset = 0;

	private int _numberOfMergedFiles = 0;

	private ArrayList _mergedFileOffsets = new ArrayList();

	private CHMFile _associatedFile = null;

	public int NumberOfTopicNodes => _numberOfTopicNodes;

	public int ImageListOffset => _imageListOffset;

	public bool ImageTypeFolder => _imageTypeFolder;

	public int Background => _background;

	public int Foreground => _foreground;

	public int WindowNameOffset => _fontOffset;

	public int FrameNameOffset => _frameNameOffset;

	public int FontOffset => _windowNameOffset;

	public ArrayList MergedFileOffsets => _mergedFileOffsets;

	public CHMIdxhdr(byte[] binaryFileData, CHMFile associatedFile)
	{
		_binaryFileData = binaryFileData;
		_associatedFile = associatedFile;
		DecodeData();
	}

	private bool DecodeData()
	{
		bool result = true;
		MemoryStream input = new MemoryStream(_binaryFileData);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = 0;
		binaryReader.ReadBytes(4);
		num = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		_numberOfTopicNodes = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		_imageListOffset = binaryReader.ReadInt32();
		if (_imageListOffset == 0)
		{
			_imageListOffset = -1;
		}
		num = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		_imageTypeFolder = num == 1;
		_background = binaryReader.ReadInt32();
		_foreground = binaryReader.ReadInt32();
		_fontOffset = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		_frameNameOffset = binaryReader.ReadInt32();
		if (_frameNameOffset == 0)
		{
			_frameNameOffset = -1;
		}
		_windowNameOffset = binaryReader.ReadInt32();
		if (_windowNameOffset == 0)
		{
			_windowNameOffset = -1;
		}
		num = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		_numberOfMergedFiles = binaryReader.ReadInt32();
		num = binaryReader.ReadInt32();
		for (int i = 0; i < _numberOfMergedFiles; i++)
		{
			num = binaryReader.ReadInt32();
			if (num > 0)
			{
				_mergedFileOffsets.Add(num);
			}
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
			_mergedFileOffsets = null;
		}
		disposed = true;
	}
}
