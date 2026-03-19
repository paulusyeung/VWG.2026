using System;
using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

[Serializable]
public class AxisY : Axes, IChartData
{
	/// <summary>
	/// Gets the chart data XML.
	/// </summary>
	/// <param name="objWriter">The writer.</param>
	/// <returns>The writer for chaining.</returns>
	public override XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		objWriter.WriteStartElement("vc", "Chart.AxesY", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		objWriter.WriteStartElement("vc", "Axis", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		intLastID++;
		objWriter.WriteAttributeString("Name", intLastID.ToString());
		if (base.Title != null)
		{
			objWriter.WriteAttributeString("Title", base.Title);
		}
		if (base.Prefix != null)
		{
			objWriter.WriteAttributeString("Prefix", base.Prefix);
		}
		if (base.Suffix != null)
		{
			objWriter.WriteAttributeString("Suffix", base.Suffix);
		}
		objWriter.WriteEndElement();
		objWriter.WriteEndElement();
		return objWriter;
	}
}
