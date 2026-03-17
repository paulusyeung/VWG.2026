using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(StartMenuToolStripSkin))]
[ToolboxItem(false)]
public class StartMenuToolStrip : ToolStrip
{
	public StartMenuToolStrip()
	{
		CustomStyle = "StartMenuToolStripSkin";
	}
}
