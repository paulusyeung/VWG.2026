using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarButtonItemArgs : EventArgs
{
	private RibbonBarButtonItem mobjButton;

	public RibbonBarButtonItem Button => mobjButton;

	public RibbonBarButtonItemArgs(RibbonBarButtonItem objButton)
	{
		mobjButton = objButton;
	}
}
