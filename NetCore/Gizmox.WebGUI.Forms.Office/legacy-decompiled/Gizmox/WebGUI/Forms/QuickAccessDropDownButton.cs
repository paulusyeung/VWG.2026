using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(QuickAccessDropDownButtonSkin))]
[ToolboxItem(false)]
internal class QuickAccessDropDownButton : Button
{
	public QuickAccessDropDownButton()
	{
		CustomStyle = "QuickAccessDropDownButtonSkin";
	}
}
