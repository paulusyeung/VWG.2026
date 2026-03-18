using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace HtmlHelp.Storage;

public class FileObject : Stream
{
	private string fileName;

	private string filePath;

	private string fileUrl;

	private int fileType;

	private Interop.IStorage fileStorage;

	private UCOMIStream fileStream;

	public override long Length
	{
		get
		{
			if (fileStream == null)
			{
				throw new ObjectDisposedException("fileStream", "storage stream no longer available");
			}
			fileStream.Stat(out var pstatstg, 1);
			return pstatstg.cbSize;
		}
	}

	public override bool CanRead
	{
		get
		{
			if (fileStream != null)
			{
				return true;
			}
			return false;
		}
	}

	public override bool CanWrite => true;

	public override bool CanSeek => true;

	public override long Position
	{
		get
		{
			return Seek(0L, SeekOrigin.Current);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public string FileName
	{
		get
		{
			return fileName;
		}
		set
		{
			fileName = value;
		}
	}

	public string FilePath
	{
		get
		{
			return filePath;
		}
		set
		{
			filePath = value;
		}
	}

	public string FileUrl
	{
		get
		{
			return IBaseStorageWrapper.BaseUrl + FilePath.Replace("\\", "/") + "/" + FileName;
		}
		set
		{
			fileUrl = value;
		}
	}

	public int FileType
	{
		get
		{
			return fileType;
		}
		set
		{
			fileType = value;
		}
	}

	public Interop.IStorage FileStorage
	{
		get
		{
			return fileStorage;
		}
		set
		{
			fileStorage = value;
		}
	}

	public UCOMIStream FileStream
	{
		get
		{
			return fileStream;
		}
		set
		{
			fileStream = value;
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		int num = 0;
		object obj = num;
		GCHandle gCHandle = default(GCHandle);
		try
		{
			gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
			IntPtr pcbRead = gCHandle.AddrOfPinnedObject();
			if (offset != 0)
			{
				byte[] array = new byte[count - 1];
				fileStream.Read(array, count, pcbRead);
				num = (int)obj;
				Array.Copy(array, 0, buffer, offset, num);
			}
			else
			{
				fileStream.Read(buffer, count, pcbRead);
				num = (int)obj;
			}
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("theStream");
		}
		if (offset != 0)
		{
			int num = buffer.Length - offset;
			byte[] array = new byte[num];
			Array.Copy(buffer, offset, array, 0, num);
			fileStream.Write(array, num, IntPtr.Zero);
		}
		else
		{
			fileStream.Write(buffer, count, IntPtr.Zero);
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		long num = 0L;
		object obj = num;
		GCHandle gCHandle = default(GCHandle);
		try
		{
			gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
			IntPtr plibNewPosition = gCHandle.AddrOfPinnedObject();
			fileStream.Seek(offset, (int)origin, plibNewPosition);
			num = (long)obj;
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		return num;
	}

	public override void Flush()
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		fileStream.Commit(0);
	}

	public override void Close()
	{
		if (fileStream != null)
		{
			fileStream.Commit(0);
			Marshal.ReleaseComObject(fileStream);
			fileStream = null;
			GC.SuppressFinalize(this);
		}
	}

	public override void SetLength(long Value)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		fileStream.SetSize(Value);
	}

	public void Save(string FileName)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		byte[] buffer = new byte[Length];
		Seek(0L, SeekOrigin.Begin);
		Stream stream = File.OpenWrite(FileName);
		int count;
		while ((count = Read(buffer, 0, 1024)) > 0)
		{
			stream.Write(buffer, 0, count);
		}
		stream.Close();
	}

	public string ReadFromFile()
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		Stream stream = new MemoryStream();
		byte[] buffer = new byte[Length];
		Seek(0L, SeekOrigin.Begin);
		int count;
		while ((count = Read(buffer, 0, 1024)) > 0)
		{
			stream.Write(buffer, 0, count);
		}
		stream.Seek(0L, SeekOrigin.Begin);
		return new StreamReader(stream, Encoding.Default).ReadToEnd().ToString();
	}

	public string ReadFromFile(Encoding encoder)
	{
		if (fileStream == null)
		{
			throw new ObjectDisposedException("fileStream", "storage stream no longer available");
		}
		Stream stream = new MemoryStream();
		byte[] buffer = new byte[Length];
		Seek(0L, SeekOrigin.Begin);
		int count;
		while ((count = Read(buffer, 0, 1024)) > 0)
		{
			stream.Write(buffer, 0, count);
		}
		stream.Seek(0L, SeekOrigin.Begin);
		return new StreamReader(stream, encoder).ReadToEnd();
	}
}
