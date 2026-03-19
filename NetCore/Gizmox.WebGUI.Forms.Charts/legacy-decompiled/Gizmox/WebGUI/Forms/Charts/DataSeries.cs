using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public class DataSeries : ICollection<DataPoint>, IEnumerable<DataPoint>, IEnumerable, IChartData
{
	private List<DataPoint> mobjPoints;

	private Chart mobjOwner;

	private DisplayTypes enmRenderTypes = DisplayTypes.Column;

	private bool mblnLabelEnabled;

	private string mstrName;

	private string mstrLegend;

	private string mstrLegendText;

	private bool mblnShowInLegend = true;

	private double mdblMarkerScale;

	private string mstrToolTipText;

	private double mdblOpacity;

	public DataPoint this[int index]
	{
		get
		{
			return mobjPoints[index];
		}
		set
		{
			mobjPoints[index] = value;
		}
	}

	public int Count => mobjPoints.Count;

	public bool IsReadOnly => false;

	/// <summary>
	/// Gets or sets the render as property(Data chart type).
	///
	/// </summary>
	/// <value>The render as.</value>
	public DisplayTypes RenderAs
	{
		get
		{
			return enmRenderTypes;
		}
		set
		{
			enmRenderTypes = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether the label is enabled.
	/// </summary>
	/// <value><c>true</c> if [label enabled]; otherwise, <c>false</c>.</value>
	public bool LabelEnabled
	{
		get
		{
			return mblnLabelEnabled;
		}
		set
		{
			mblnLabelEnabled = value;
		}
	}

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name
	{
		get
		{
			return mstrName;
		}
		set
		{
			mstrName = value;
		}
	}

	/// <summary>
	/// Gets or sets the legend.
	/// </summary>
	/// <value>
	/// The legend.
	/// </value>
	public string Legend
	{
		get
		{
			return mstrLegend;
		}
		set
		{
			mstrLegend = value;
		}
	}

	/// <summary>
	/// Gets or sets the legend text.
	/// </summary>
	/// <value>
	/// The legend text.
	/// </value>
	public string LegendText
	{
		get
		{
			return mstrLegendText;
		}
		set
		{
			mstrLegendText = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether [show in legend].
	/// </summary>
	/// <value>
	///   <c>true</c> if [show in legend]; otherwise, <c>false</c>.
	/// </value>
	public bool ShowInLegend
	{
		get
		{
			return mblnShowInLegend;
		}
		set
		{
			mblnShowInLegend = value;
		}
	}

	/// <summary>
	/// Gets or sets the marker scale.
	/// Should be between 0-1.0
	/// </summary>
	/// <value>The marker scale.</value>
	public double MarkerScale
	{
		get
		{
			return mdblMarkerScale;
		}
		set
		{
			mdblMarkerScale = value;
		}
	}

	/// <summary>
	/// Gets or sets the tool tip text.
	/// </summary>
	/// <value>The tool tip text.</value>
	public string ToolTipText
	{
		get
		{
			if (!string.IsNullOrEmpty(mstrToolTipText))
			{
				return mstrToolTipText;
			}
			return null;
		}
		set
		{
			mstrToolTipText = value;
		}
	}

	/// <summary>
	/// Gets or sets the opacity.
	/// Should be between 0-1.0
	/// </summary>
	/// <value>The opacity.</value>
	public double Opacity
	{
		get
		{
			return mdblOpacity;
		}
		set
		{
			mdblOpacity = value;
		}
	}

	public void Add(DataPoint item)
	{
		mobjPoints.Add(item);
		item.SetOwner(this);
		if (mobjOwner != null)
		{
			mobjOwner.Update();
		}
	}

	public void Add(string strAxisLabel, double dblYValue)
	{
		Add(strAxisLabel, dblYValue, 0.0, 0.0);
	}

	public void Add(string strAxisLabel, double dblYValue, double dblXValue)
	{
		Add(strAxisLabel, dblYValue, dblXValue, 0.0);
	}

	public void Add(string strAxisLabel, double dblYValue, double dblXValue, double dblZValue)
	{
		Add(new DataPoint(strAxisLabel, dblYValue, dblXValue, dblZValue));
	}

	public void Add(string strAxisLabel, double dblYValue, double dblXValue, double dblZValue, bool blnShowYifZero, bool blnShowXifZero, bool blnShowZifZero)
	{
		Add(new DataPoint(strAxisLabel, dblYValue, dblXValue, dblZValue, blnShowYifZero, blnShowXifZero, blnShowZifZero));
	}

	internal void SetOwner(Chart objOwner)
	{
		mobjOwner = objOwner;
	}

	public void Clear()
	{
		mobjPoints.Clear();
	}

	public bool Contains(DataPoint item)
	{
		return mobjPoints.Contains(item);
	}

	public void CopyTo(DataPoint[] array, int arrayIndex)
	{
		mobjPoints.CopyTo(array, arrayIndex);
	}

	public bool Remove(DataPoint item)
	{
		return mobjPoints.Remove(item);
	}

	public IEnumerator<DataPoint> GetEnumerator()
	{
		return mobjPoints.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return mobjPoints.GetEnumerator();
	}

	public DataSeries()
	{
		mobjPoints = new List<DataPoint>();
	}

	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The writer object.</param>
	/// <param name="intLastID">The last ID.</param>
	/// <returns></returns>
	public XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		objWriter.WriteStartElement("vc", "DataSeries", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		if (!string.IsNullOrEmpty(Name))
		{
			objWriter.WriteAttributeString("Name", Name);
		}
		else
		{
			intLastID++;
			objWriter.WriteAttributeString("Name", intLastID.ToString());
		}
		if (!string.IsNullOrEmpty(Legend))
		{
			objWriter.WriteAttributeString("Legend", Legend);
		}
		if (!string.IsNullOrEmpty(LegendText))
		{
			objWriter.WriteAttributeString("LegendText", LegendText);
		}
		if (!ShowInLegend)
		{
			objWriter.WriteAttributeString("ShowInLegend", "False");
		}
		objWriter.WriteAttributeString("RenderAs", RenderAs.ToString());
		if (LabelEnabled)
		{
			objWriter.WriteAttributeString("LabelEnabled", LabelEnabled.ToString());
		}
		if (MarkerScale != 0.0)
		{
			objWriter.WriteAttributeString("MarkerScale", MarkerScale.ToString(CultureInfo.InvariantCulture));
		}
		if (ToolTipText != null)
		{
			objWriter.WriteAttributeString("ToolTipText", ToolTipText);
		}
		if (Opacity != 0.0)
		{
			objWriter.WriteAttributeString("Opacity", Opacity.ToString(CultureInfo.InvariantCulture));
		}
		objWriter.WriteStartElement("vc", "DataSeries.DataPoints", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		foreach (DataPoint mobjPoint in mobjPoints)
		{
			objWriter = mobjPoint.GetChartDataXML(objWriter, ref intLastID);
		}
		objWriter.WriteEndElement();
		objWriter.WriteEndElement();
		return objWriter;
	}

	/// <summary>
	/// Fires the click.
	/// </summary>
	void IChartData.FireClick()
	{
	}
}
