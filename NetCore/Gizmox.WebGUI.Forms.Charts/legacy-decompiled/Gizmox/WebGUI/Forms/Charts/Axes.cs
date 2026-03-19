using System;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public abstract class Axes : IChartData
{
	/// <summary>
	///
	/// </summary>
	private string mstrPrefix;

	/// <summary>
	///
	/// </summary>
	private string mstrSuffix;

	/// <summary>
	///
	/// </summary>
	private string mstrTitle;

	/// <summary>
	/// Gets or sets the prefix.
	/// The prefix will be added to all the AxisLabels. (Prefix + AxisLabels)
	/// </summary>
	/// <value>The prefix.</value>
	public string Prefix
	{
		get
		{
			return mstrPrefix;
		}
		set
		{
			mstrPrefix = value;
		}
	}

	/// <summary>
	/// Gets or sets the suffix.
	/// The suffix that will be added to all the AxisLabels. (AxisLabels + Suffix)
	/// </summary>
	/// <value>The suffix.</value>
	public string Suffix
	{
		get
		{
			return mstrSuffix;
		}
		set
		{
			mstrSuffix = value;
		}
	}

	/// <summary>
	/// Gets or sets the title. The text that will appear in the axis title.
	/// </summary>
	/// <value>The title.</value>
	public string Title
	{
		get
		{
			return mstrTitle;
		}
		set
		{
			mstrTitle = value;
		}
	}

	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The writer.</param>
	/// <returns>The writer for chaining.</returns>
	public abstract XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID);

	/// <summary>
	/// Fires the click.
	/// </summary>
	void IChartData.FireClick()
	{
	}
}
