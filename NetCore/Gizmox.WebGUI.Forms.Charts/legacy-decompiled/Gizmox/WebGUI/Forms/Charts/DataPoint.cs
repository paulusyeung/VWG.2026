using System;
using System.Globalization;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

/// <summary>
///
/// </summary>
[Serializable]
public class DataPoint : IChartData
{
	private string mstrAxisLabel;

	private double mdblXValue;

	private double mdblYValue;

	private double mdblZValue;

	private bool mblnShowXifZero;

	private bool mblnShowYifZero;

	private bool mblnShowZifZero;

	private int mintIndex;

	/// <summary>
	///
	/// </summary>
	private DataSeries mobjOwner;

	/// <summary>
	/// Gets or sets the axis label.
	/// </summary>
	/// <value>The axis label.</value>
	public string AxisLabel
	{
		get
		{
			return mstrAxisLabel;
		}
		set
		{
			mstrAxisLabel = value;
		}
	}

	/// <summary>
	/// Gets or sets the index.
	/// </summary>
	/// <value>The index.</value>
	internal int Index
	{
		get
		{
			return mintIndex;
		}
		set
		{
			mintIndex = value;
		}
	}

	/// <summary>
	/// Gets or sets the X value.
	/// </summary>
	/// <value>The X value.</value>
	public double XValue
	{
		get
		{
			if (!double.IsNaN(mdblXValue))
			{
				return mdblXValue;
			}
			return Index + 1;
		}
		set
		{
			mdblXValue = value;
		}
	}

	/// <summary>
	/// Gets or sets the Z value.
	/// </summary>
	/// <value>The Z value.</value>
	public double ZValue
	{
		get
		{
			return mdblZValue;
		}
		set
		{
			mdblZValue = value;
		}
	}

	/// <summary>
	/// Gets or sets the Y value.
	/// </summary>
	/// <value>The Y value.</value>
	public double YValue
	{
		get
		{
			switch (mobjOwner.RenderAs)
			{
			case DisplayTypes.StackedBar100:
			case DisplayTypes.Stackedcolumn100:
			case DisplayTypes.StackedArea100:
				if (!double.IsNaN(mdblYValue))
				{
					return mdblYValue;
				}
				return 0.0;
			case DisplayTypes.Doughnut:
			case DisplayTypes.Pie:
				if (!double.IsNaN(mdblYValue))
				{
					return Math.Abs(mdblYValue);
				}
				return 0.0;
			default:
				return mdblYValue;
			}
		}
		set
		{
			mdblYValue = value;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this instance is click critical.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is click critical; otherwise, <c>false</c>.
	/// </value>
	internal bool IsClickCritical => this.Click != null;

	/// <summary>
	/// Data Point click event
	/// </summary>
	public event EventHandler Click;

	public DataPoint()
	{
	}

	public DataPoint(string strAxisLabel, double dblYValue)
		: this(strAxisLabel, dblYValue, 0.0, 0.0)
	{
	}

	public DataPoint(string strAxisLabel, double dblYValue, double dblXValue)
		: this(strAxisLabel, dblYValue, dblXValue, 0.0)
	{
	}

	public DataPoint(string strAxisLabel, double dblYValue, double dblXValue, double dblZValue)
		: this(strAxisLabel, dblYValue, dblXValue, dblZValue, blnShowYifZero: false, blnShowXifZero: false, blnShowZifZero: false)
	{
	}

	public DataPoint(string strAxisLabel, double dblYValue, double dblXValue, double dblZValue, bool blnShowYifZero, bool blnShowXifZero, bool blnShowZifZero)
	{
		mstrAxisLabel = strAxisLabel;
		mdblYValue = dblYValue;
		mdblXValue = dblXValue;
		mdblZValue = dblZValue;
		mblnShowYifZero = blnShowYifZero;
		mblnShowXifZero = blnShowXifZero;
		mblnShowZifZero = blnShowZifZero;
	}

	/// <summary>
	/// Sets the owner.
	/// </summary>
	/// <param name="objOwner">The owner.</param>
	internal void SetOwner(DataSeries objOwner)
	{
		mobjOwner = objOwner;
	}

	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <returns></returns>
	public XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		objWriter.WriteStartElement("vc", "DataPoint", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		intLastID++;
		objWriter.WriteAttributeString("Name", intLastID.ToString());
		if (AxisLabel != null)
		{
			objWriter.WriteAttributeString("AxisXLabel", AxisLabel);
		}
		if (mblnShowXifZero || XValue != 0.0)
		{
			objWriter.WriteAttributeString("XValue", XValue.ToString(CultureInfo.InvariantCulture));
		}
		if (mblnShowYifZero || YValue != 0.0)
		{
			objWriter.WriteAttributeString("YValue", YValue.ToString(CultureInfo.InvariantCulture));
		}
		if (mblnShowZifZero || ZValue != 0.0)
		{
			objWriter.WriteAttributeString("ZValue", ZValue.ToString(CultureInfo.InvariantCulture));
		}
		objWriter.WriteEndElement();
		return objWriter;
	}

	/// <summary>
	/// Fires the click.
	/// </summary>
	void IChartData.FireClick()
	{
		if (this.Click != null)
		{
			this.Click(this, EventArgs.Empty);
		}
	}
}
