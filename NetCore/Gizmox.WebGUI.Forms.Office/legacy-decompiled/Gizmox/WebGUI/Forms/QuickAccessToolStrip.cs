using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(QuickAccessToolStripSkin))]
[ToolboxItem(false)]
public class QuickAccessToolStrip : ToolStrip
{
	public QuickAccessToolStrip()
	{
		CustomStyle = "QuickAccessToolStripSkin";
		base.GripStyle = ToolStripGripStyle.Hidden;
		base.CanOverflow = false;
	}
}
