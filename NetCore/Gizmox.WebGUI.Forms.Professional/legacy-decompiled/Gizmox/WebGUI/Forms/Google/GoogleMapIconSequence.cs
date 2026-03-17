using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Describes how icons are to be rendered on a line.
/// </summary>
[Serializable]
[TypeConverter(typeof(GoogleMapIconSequenceConverter))]
public class GoogleMapIconSequence
{
	private GoogleMapSymbol mobjIcon = new GoogleMapSymbol();

	private string mstrOffset = string.Empty;

	private string mstrRepeat = string.Empty;

	/// <summary>
	/// The icon to render on the line.
	/// </summary>
	public GoogleMapSymbol Icon
	{
		get
		{
			return mobjIcon;
		}
		set
		{
			mobjIcon = value;
		}
	}

	/// <summary>
	/// The distance from the start of the line at which an icon is to be rendered. This distance may be expressed as a percentage of line's length (e.g. '50%') or in pixels (e.g. '50px'). Defaults to '100%'.
	/// </summary>
	public string Offset
	{
		get
		{
			return mstrOffset;
		}
		set
		{
			if (mstrOffset != value)
			{
				mstrOffset = ValidateValue(value);
			}
		}
	}

	/// <summary>
	/// The distance between consecutive icons on the line. This distance may be expressed as a percentage of the line's length (e.g. '50%') or in pixels (e.g. '50px'). To disable repeating of the icon, specify '0'. Defaults to '0'.
	/// </summary>
	public string Repeat
	{
		get
		{
			return mstrRepeat;
		}
		set
		{
			if (mstrRepeat != value)
			{
				mstrRepeat = ValidateValue(value);
			}
		}
	}

	public GoogleMapIconSequence()
	{
	}

	/// <summary>
	/// Initializes Object from parameters
	/// </summary>
	/// <param name="objIcon">The icon to render on the line.</param>
	/// <param name="strOffset">The distance from the start of the line at which an icon is to be rendered. This distance may be expressed as a percentage of line's length (e.g. '50%') or in pixels (e.g. '50px'). Defaults to '100%'.</param>
	/// <param name="strRepeat">The distance between consecutive icons on the line. This distance may be expressed as a percentage of the line's length (e.g. '50%') or in pixels (e.g. '50px'). To disable repeating of the icon, specify '0'. Defaults to '0'.</param>
	public GoogleMapIconSequence(GoogleMapSymbol objIcon, string strOffset, string strRepeat)
	{
		mobjIcon = objIcon;
		Offset = strOffset;
		Repeat = strRepeat;
	}

	/// <summary>
	/// Validate Offset or Repeat values according to GoogleMap's documentation:
	/// Offset:
	///   The distance from the start of the line at which an icon is to be rendered. This distance may be expressed as a percentage of line's length (e.g. '50%') or in pixels (e.g. '50px'). Defaults to '100%'.
	/// Repeat:
	///   The distance between consecutive icons on the line. This distance may be expressed as a percentage of the line's length (e.g. '50%') or in pixels (e.g. '50px'). To disable repeating of the icon, specify '0'. Defaults to '0'.
	/// </summary>
	/// <param name="strValidatingValue"></param>
	/// <returns></returns>
	private static string ValidateValue(string strValidatingValue)
	{
		string text = "%";
		string text2 = strValidatingValue.Trim();
		if (text2.EndsWith("%"))
		{
			text = "%";
			text2 = text2.Substring(0, text2.Length - 1);
		}
		else if (text2.ToLower().EndsWith("px"))
		{
			text = "px";
			text2 = text2.Substring(0, text2.Length - 2);
		}
		int num = 0;
		if (!string.IsNullOrEmpty(text2))
		{
			num = int.Parse(text2);
		}
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException("Value needs to be positive number, expressing percentages (%) or pixels (px)");
		}
		return num + text;
	}
}
