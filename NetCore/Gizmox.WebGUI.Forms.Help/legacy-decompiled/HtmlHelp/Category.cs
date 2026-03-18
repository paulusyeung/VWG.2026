using System.Collections;
using System.IO;
using HtmlHelp.ChmDecoding;

namespace HtmlHelp;

public class Category
{
	private string _name = "";

	private string _description = "";

	private ArrayList _infoTypes = null;

	private int _referenceCount = 1;

	internal int ReferenceCount
	{
		get
		{
			return _referenceCount;
		}
		set
		{
			_referenceCount = value;
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			_name = value;
		}
	}

	public ArrayList InformationTypes => _infoTypes;

	public Category()
		: this("", "")
	{
	}

	public Category(string name, string description)
		: this(name, description, new ArrayList())
	{
	}

	public Category(string name, string description, ArrayList linkedInformationTypes)
	{
		_name = name;
		_description = description;
		_infoTypes = linkedInformationTypes;
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write(_name);
		writer.Write(_description);
		writer.Write(_infoTypes.Count);
		for (int i = 0; i < _infoTypes.Count; i++)
		{
			InformationType informationType = _infoTypes[i] as InformationType;
			writer.Write(informationType.Name);
		}
	}

	internal void ReadDump(ref BinaryReader reader, CHMFile chmFile)
	{
		_name = reader.ReadString();
		_description = reader.ReadString();
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			string name = reader.ReadString();
			InformationType informationType = chmFile.GetInformationType(name);
			if (informationType != null)
			{
				informationType.SetCategoryFlag(newValue: true);
				_infoTypes.Add(informationType);
			}
		}
	}

	internal void MergeInfoTypes(Category cat)
	{
		if (cat == null || cat.InformationTypes.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < cat.InformationTypes.Count; i++)
		{
			InformationType informationType = cat.InformationTypes[i] as InformationType;
			if (!ContainsInformationType(informationType.Name))
			{
				informationType.SetCategoryFlag(newValue: true);
				_infoTypes.Add(informationType);
			}
		}
	}

	public void AddInformationType(InformationType type)
	{
		_infoTypes.Add(type);
	}

	public void RemoveInformationType(InformationType type)
	{
		_infoTypes.Remove(type);
	}

	public bool ContainsInformationType(InformationType type)
	{
		return _infoTypes.Contains(type);
	}

	public bool ContainsInformationType(string name)
	{
		for (int i = 0; i < _infoTypes.Count; i++)
		{
			InformationType informationType = _infoTypes[i] as InformationType;
			if (informationType.Name == name)
			{
				return true;
			}
		}
		return false;
	}
}
