using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design;

public class FormDocumentDesigner : DocumentDesigner
{
	private Form c30c0087f777630712d41fdacd62ab546;

	internal override IComponent MappedComponentInternal => c30c0087f777630712d41fdacd62ab546;

	protected override object GetView(ViewTechnology technology, IComponent objComponent)
	{
		c30c0087f777630712d41fdacd62ab546 = (Form)base.ClientDesingerHost.CreateComponent(objComponent);
		c30c0087f777630712d41fdacd62ab546.TopLevel = false;
		Control obj = (Control)((IRootDesigner)base.WinDesingerHost.GetDesigner(c30c0087f777630712d41fdacd62ab546)).GetView(ViewTechnology.Default);
		obj.Dock = System.Windows.Forms.DockStyle.Fill;
		return obj;
	}
}
