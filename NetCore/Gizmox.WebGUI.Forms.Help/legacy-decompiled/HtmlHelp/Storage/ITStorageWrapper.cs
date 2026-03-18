#define DEBUG
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HtmlHelp.Storage;

public class ITStorageWrapper : IBaseStorageWrapper
{
	private Interop.UCOMITStorage comITStorage;

	private Interop.ITStorage comITStorageInterfaced;

	public ITStorageWrapper(string workPath, bool enumStorage)
	{
		comITStorage = new Interop.UCOMITStorage();
		comITStorageInterfaced = (Interop.ITStorage)comITStorage;
		storage = comITStorageInterfaced.StgOpenStorage(workPath, IntPtr.Zero, 32, IntPtr.Zero, 0);
		IBaseStorageWrapper.BaseUrl = workPath;
		if (enumStorage)
		{
			base.EnumIStorageObject();
		}
	}

	public override void EnumIStorageObject()
	{
		base.EnumIStorageObject();
	}

	public Interop.IStorage OpenSubStorage(Interop.IStorage parentStorage, string storageName)
	{
		if (parentStorage == null)
		{
			parentStorage = base.storage;
		}
		Interop.IStorage storage = null;
		STATSTG sTATSTG = default(STATSTG);
		sTATSTG.pwcsName = storageName;
		sTATSTG.type = 1;
		try
		{
			Interop.IStorage storage2 = parentStorage.OpenStorage(sTATSTG.pwcsName, IntPtr.Zero, 16, IntPtr.Zero, 0);
			storage = storage2;
		}
		catch (Exception ex)
		{
			storage = null;
			Debug.WriteLine("ITStorageWrapper.OpenSubStorage() - Failed for storage '" + storageName + "'");
			Debug.Indent();
			Debug.WriteLine("Exception: " + ex.Message);
			Debug.Unindent();
		}
		return storage;
	}

	public FileObject OpenUCOMStream(Interop.IStorage parentStorage, string fileName)
	{
		if (parentStorage == null)
		{
			parentStorage = storage;
		}
		FileObject fileObject = null;
		STATSTG sTATSTG = default(STATSTG);
		sTATSTG.pwcsName = fileName;
		sTATSTG.type = 2;
		try
		{
			fileObject = new FileObject();
			UCOMIStream uCOMIStream = parentStorage.OpenStream(sTATSTG.pwcsName, IntPtr.Zero, 16, 0);
			if (uCOMIStream != null)
			{
				fileObject.FileType = sTATSTG.type;
				fileObject.FilePath = "";
				fileObject.FileName = sTATSTG.pwcsName.ToString();
				fileObject.FileStream = uCOMIStream;
			}
			else
			{
				fileObject = null;
			}
		}
		catch (Exception ex)
		{
			fileObject = null;
			Debug.WriteLine("ITStorageWrapper.OpenUCOMStream() - Failed for file '" + fileName + "'");
			Debug.Indent();
			Debug.WriteLine("Exception: " + ex.Message);
			Debug.Unindent();
		}
		return fileObject;
	}
}
