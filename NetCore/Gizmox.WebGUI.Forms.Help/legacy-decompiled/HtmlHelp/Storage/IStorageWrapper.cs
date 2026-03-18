using System;
using System.Runtime.InteropServices;

namespace HtmlHelp.Storage;

public class IStorageWrapper : IBaseStorageWrapper
{
	public IStorageWrapper(string workPath, bool enumStorage)
	{
		Interop.StgOpenStorage(workPath, null, 16, IntPtr.Zero, 0, out storage);
		IBaseStorageWrapper.BaseUrl = workPath;
		STATSTG pStatStg = default(STATSTG);
		storage.Stat(out pStatStg, 1);
		if (enumStorage)
		{
			base.EnumIStorageObject();
		}
	}

	public override void EnumIStorageObject()
	{
		base.EnumIStorageObject();
	}
}
