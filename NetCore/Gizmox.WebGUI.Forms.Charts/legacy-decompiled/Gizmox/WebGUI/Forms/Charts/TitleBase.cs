using System;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public abstract class TitleBase
{
	private AlignmentX enmAlignmentX = AlignmentX.Center;

	private AlignmentY enmAlignmentY;

	private string mstrText;

	private double mblnFontSize = 8.0;

	/// <summary>
	/// Gets or sets the text associated with this control.
	/// </summary>
	/// <value></value>
	public string Text
	{
		get
		{
			return mstrText;
		}
		set
		{
			mstrText = value;
		}
	}

	/// <summary>
	/// Gets or sets the alignment X.
	/// </summary>
	/// <value>The alignment X.</value>
	public AlignmentX AlignmentX
	{
		get
		{
			return enmAlignmentX;
		}
		set
		{
			enmAlignmentX = value;
		}
	}

	/// <summary>
	/// Gets or sets the alignment Y.
	/// </summary>
	/// <value>The alignment Y.</value>
	public AlignmentY AlignmentY
	{
		get
		{
			return enmAlignmentY;
		}
		set
		{
			enmAlignmentY = value;
		}
	}

	/// <summary>
	/// Gets or sets the size of the font.
	/// </summary>
	/// <value>The size of the font.</value>
	public double FontSize
	{
		get
		{
			return mblnFontSize;
		}
		set
		{
			mblnFontSize = value;
		}
	}

	public TitleBase()
	{
	}

	public TitleBase(string strText)
	{
		mstrText = strText;
	}
}
