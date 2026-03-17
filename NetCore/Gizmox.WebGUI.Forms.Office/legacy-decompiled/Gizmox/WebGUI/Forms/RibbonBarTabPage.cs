using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(RibbonBarTabPageSkin))]
[ToolboxItem(false)]
public class RibbonBarTabPage : TabPage
{
	public RibbonBarTabPage()
	{
		CustomStyle = "RibbonBarTabPage";
	}

	public RibbonBarTabPage(string strText)
		: base(strText)
	{
		CustomStyle = "RibbonBarTabPage";
	}
}
