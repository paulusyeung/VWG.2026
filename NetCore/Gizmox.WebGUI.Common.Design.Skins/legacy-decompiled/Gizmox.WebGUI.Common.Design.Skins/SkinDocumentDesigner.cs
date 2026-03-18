using System.ComponentModel;

namespace Gizmox.WebGUI.Common.Design.Skins;

public class SkinDocumentDesigner : DocumentDesinger
{
	public override void Initialize(IComponent objComponent)
	{
		base.Initialize(objComponent);
		SetSelectedComponent(objComponent);
	}
}
