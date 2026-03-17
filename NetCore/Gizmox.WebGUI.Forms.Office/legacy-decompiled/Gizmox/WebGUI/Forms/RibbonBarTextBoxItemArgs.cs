using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarTextBoxItemArgs : EventArgs
{
	private RibbonBarTextBoxItem mobjTextBox;

	public RibbonBarTextBoxItem TextBox => mobjTextBox;

	public RibbonBarTextBoxItemArgs(RibbonBarTextBoxItem objTextBox)
	{
		mobjTextBox = objTextBox;
	}
}
