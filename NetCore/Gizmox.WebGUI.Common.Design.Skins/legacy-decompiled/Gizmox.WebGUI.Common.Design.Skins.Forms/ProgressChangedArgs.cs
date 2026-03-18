using System;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public class ProgressChangedArgs : EventArgs
{
	private int mintValue = -1;

	private int mintMinimum = -1;

	private int mintMaximum = -1;

	public int Value
	{
		get
		{
			return mintValue;
		}
		set
		{
			mintValue = value;
		}
	}

	public int Minimum
	{
		get
		{
			return mintMinimum;
		}
		set
		{
			mintMinimum = value;
		}
	}

	public int Maximum
	{
		get
		{
			return mintMaximum;
		}
		set
		{
			mintMaximum = value;
		}
	}

	public ProgressChangedArgs(int intValue, int intMinimum, int intMaximum)
	{
		mintValue = intValue;
		mintMinimum = intMinimum;
		mintMaximum = intMaximum;
	}
}
