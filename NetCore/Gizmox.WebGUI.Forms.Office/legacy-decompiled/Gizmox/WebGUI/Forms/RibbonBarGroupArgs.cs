using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarGroupArgs : EventArgs
{
	private RibbonBarGroup mobjGroup;

	public RibbonBarGroup Group => mobjGroup;

	public RibbonBarGroupArgs(RibbonBarGroup objGroup)
	{
		mobjGroup = objGroup;
	}
}
