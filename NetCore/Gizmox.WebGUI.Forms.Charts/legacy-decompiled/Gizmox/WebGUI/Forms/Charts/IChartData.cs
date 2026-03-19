using System.Xml;

namespace Gizmox.WebGUI.Forms.Charts;

public interface IChartData
{
	XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID);

	void FireClick();
}
