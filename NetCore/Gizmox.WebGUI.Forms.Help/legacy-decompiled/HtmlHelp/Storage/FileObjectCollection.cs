using System.Collections;

namespace HtmlHelp.Storage;

public class FileObjectCollection : CollectionBase
{
	public void Add(FileObject fo)
	{
		base.List.Add(fo);
	}

	public void Remove(int index)
	{
		if (index < base.Count - 1 && index > 0)
		{
			base.List.RemoveAt(index);
		}
	}

	public FileObject Item(int index)
	{
		return (FileObject)base.List[index];
	}
}
