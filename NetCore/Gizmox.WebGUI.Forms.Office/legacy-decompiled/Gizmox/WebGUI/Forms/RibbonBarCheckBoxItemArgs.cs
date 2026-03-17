using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarCheckBoxItemArgs : EventArgs
{
	private RibbonBarCheckBoxItem mobjCheckBox;

	public RibbonBarCheckBoxItem CheckBox => mobjCheckBox;

	public RibbonBarCheckBoxItemArgs(RibbonBarCheckBoxItem objCheckBox)
	{
		mobjCheckBox = objCheckBox;
	}
}
