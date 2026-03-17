using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarButtonItemMenuClickArgs : EventArgs
{
	private RibbonBarButtonItem mobjButton;

	private MenuItem mobjMenuItem;

	public RibbonBarButtonItem Button => mobjButton;

	public MenuItem MenuItem => mobjMenuItem;

	public RibbonBarButtonItemMenuClickArgs(RibbonBarButtonItem objButton, MenuItem objMenuItem)
	{
		mobjButton = objButton;
		mobjMenuItem = objMenuItem;
	}
}
