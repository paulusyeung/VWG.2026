using System;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public class Title : TitleBase, IChartData
{
	public Title()
	{
	}

	public Title(string strText)
		: base(strText)
	{
	}

	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <returns></returns>
	public XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		if (base.Text != null)
		{
			objWriter.WriteStartElement("vc", "Chart.Titles", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
			objWriter.WriteStartElement("vc", "Title", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
			intLastID++;
			objWriter.WriteAttributeString("Name", intLastID.ToString());
			objWriter.WriteAttributeString("Text", base.Text);
			objWriter.WriteEndElement();
			objWriter.WriteEndElement();
		}
		return objWriter;
	}

	/// <summary>
	/// Fires the click.
	/// </summary>
	void IChartData.FireClick()
	{
	}
}
