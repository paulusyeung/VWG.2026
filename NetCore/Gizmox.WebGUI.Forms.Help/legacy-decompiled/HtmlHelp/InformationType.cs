using System.IO;

namespace HtmlHelp;

public class InformationType
{
	private string _name = "";

	private string _description = "";

	private InformationTypeMode _typeMode = InformationTypeMode.Inclusive;

	private bool _isInCategory = false;

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

	public bool IsInCategory => _isInCategory;

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

	public InformationTypeMode Mode
	{
		get
		{
			return _typeMode;
		}
		set
		{
			_typeMode = value;
		}
	}

	public InformationType()
		: this("", "")
	{
	}

	public InformationType(string name, string description)
		: this(name, description, InformationTypeMode.Inclusive)
	{
	}

	public InformationType(string name, string description, InformationTypeMode mode)
	{
		_name = name;
		_description = description;
		_typeMode = mode;
	}

	internal void Dump(ref BinaryWriter writer)
	{
		writer.Write((int)_typeMode);
		writer.Write(_name);
		writer.Write(_description);
	}

	internal void ReadDump(ref BinaryReader reader)
	{
		_typeMode = (InformationTypeMode)reader.ReadInt32();
		_name = reader.ReadString();
		_description = reader.ReadString();
	}

	internal void SetCategoryFlag(bool newValue)
	{
		_isInCategory = newValue;
	}
}
