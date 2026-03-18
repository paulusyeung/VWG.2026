#define DEBUG
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HtmlHelp.Storage;

public class IBaseStorageWrapper
{
	protected Interop.IStorage storage;

	private static string baseUrl;

	public FileObjectCollection foCollection;

	public Interop.IStorage Storage => storage;

	public static string BaseUrl
	{
		get
		{
			return baseUrl;
		}
		set
		{
			baseUrl = HtmlHelpSystem.UrlPrefix + value + "::/";
		}
	}

	public IBaseStorageWrapper()
	{
		foCollection = new FileObjectCollection();
	}

	public virtual void EnumIStorageObject()
	{
		EnumIStorageObject(storage, "");
	}

	protected void EnumIStorageObject(Interop.IStorage enumStorage, string BasePath)
	{
		enumStorage.EnumElements(0, IntPtr.Zero, 0, out var ppenum);
		ppenum.Reset();
		STATSTG rgVar;
		int pceltFetched;
		while (ppenum.Next(1, out rgVar, out pceltFetched) == 0 && pceltFetched != 0)
		{
			FileObject fileObject = new FileObject();
			fileObject.FileType = rgVar.type;
			switch (rgVar.type)
			{
			case 1:
			{
				Interop.IStorage storage = enumStorage.OpenStorage(rgVar.pwcsName, IntPtr.Zero, 16, IntPtr.Zero, 0);
				if (storage != null)
				{
					string basePath = BasePath + rgVar.pwcsName.ToString();
					fileObject.FileStorage = storage;
					fileObject.FilePath = BasePath;
					fileObject.FileName = rgVar.pwcsName.ToString();
					foCollection.Add(fileObject);
					EnumIStorageObject(storage, basePath);
				}
				break;
			}
			case 2:
			{
				UCOMIStream fileStream = enumStorage.OpenStream(rgVar.pwcsName, IntPtr.Zero, 16, 0);
				fileObject.FilePath = BasePath;
				fileObject.FileName = rgVar.pwcsName.ToString();
				fileObject.FileStream = fileStream;
				foCollection.Add(fileObject);
				break;
			}
			case 4:
				Debug.WriteLine("Ignoring IProperty type ...");
				break;
			case 3:
				Debug.WriteLine("Ignoring ILockBytes type ...");
				break;
			default:
				Debug.WriteLine("Unknown object type ...");
				break;
			}
		}
	}
}
