using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(RibbonBarStartButtonSkin))]
[ToolboxItem(false)]
internal class RibbonBarStartButton : Button
{
	protected override bool SupportsKeyNavigation => true;

	public RibbonBarStartButton()
	{
		CustomStyle = "RibbonBarStartButtonSkin";
	}
}
