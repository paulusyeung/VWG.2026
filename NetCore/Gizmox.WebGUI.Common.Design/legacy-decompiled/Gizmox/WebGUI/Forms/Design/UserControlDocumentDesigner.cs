using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design;

[ToolboxItemFilter("Gizmox.WebGUI.Forms.UserControl", ToolboxItemFilterType.Custom)]
[ToolboxItemFilter("Gizmox.WebGUI.Forms.MainMenu", ToolboxItemFilterType.Prevent)]
public class UserControlDocumentDesigner : DocumentDesigner
{
	private UserControl c9c2df588b5e594ffcae7c2d770776810;

	internal override IComponent MappedComponentInternal => c9c2df588b5e594ffcae7c2d770776810;

	protected override object GetView(ViewTechnology technology, IComponent objComponent)
	{
		c9c2df588b5e594ffcae7c2d770776810 = (UserControl)base.ClientDesingerHost.CreateComponent(objComponent);
		Control obj = (Control)((IRootDesigner)base.WinDesingerHost.GetDesigner(c9c2df588b5e594ffcae7c2d770776810)).GetView(ViewTechnology.Default);
		obj.Dock = System.Windows.Forms.DockStyle.Fill;
		return obj;
	}
}
