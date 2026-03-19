using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public class Data : IList<DataSeries>, ICollection<DataSeries>, IEnumerable<DataSeries>, IEnumerable, IChartData
{
	/// <summary>
	///
	/// </summary>
	private List<DataSeries> mobjSeries = new List<DataSeries>();

	/// <summary>
	///
	/// </summary>
	private Chart mobjOwner;

	public int Count => mobjSeries.Count;

	public bool IsReadOnly => false;

	DataSeries IList<DataSeries>.this[int index]
	{
		get
		{
			return mobjSeries[index];
		}
		set
		{
			mobjSeries[index] = value;
			mobjOwner.Update();
		}
	}

	public DataSeries this[int index]
	{
		get
		{
			return ((IList<DataSeries>)this)[index];
		}
		set
		{
			((IList<DataSeries>)this)[index] = value;
		}
	}

	internal Data(Chart objOwner)
	{
		mobjOwner = objOwner;
	}

	public void Add(DataSeries item)
	{
		mobjSeries.Add(item);
		item.SetOwner(mobjOwner);
		mobjOwner.Update();
	}

	public void Clear()
	{
		mobjOwner.Update();
		mobjSeries.Clear();
	}

	public bool Contains(DataSeries item)
	{
		return mobjSeries.Contains(item);
	}

	public void CopyTo(DataSeries[] array, int arrayIndex)
	{
		mobjSeries.CopyTo(array, arrayIndex);
	}

	public bool Remove(DataSeries item)
	{
		mobjOwner.Update();
		return mobjSeries.Remove(item);
	}

	public IEnumerator<DataSeries> GetEnumerator()
	{
		return mobjSeries.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return mobjSeries.GetEnumerator();
	}

	int IList<DataSeries>.IndexOf(DataSeries item)
	{
		return mobjSeries.IndexOf(item);
	}

	void IList<DataSeries>.Insert(int index, DataSeries item)
	{
		mobjSeries.Insert(index, item);
		mobjOwner.Update();
	}

	void IList<DataSeries>.RemoveAt(int index)
	{
		mobjSeries.RemoveAt(index);
		mobjOwner.Update();
	}

	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <returns></returns>
	public XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		objWriter.WriteStartElement("vc", "Chart.Series", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		foreach (DataSeries item in mobjSeries)
		{
			objWriter = item.GetChartDataXML(objWriter, ref intLastID);
		}
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
