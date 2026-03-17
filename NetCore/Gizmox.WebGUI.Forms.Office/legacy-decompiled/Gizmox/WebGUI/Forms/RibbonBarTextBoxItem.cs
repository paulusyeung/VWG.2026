using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarTextBoxItem : RibbonBarItem
{
	protected override Control CreateControl()
	{
		RibbonBar.RibbonBarTextBox ribbonBarTextBox = new RibbonBar.RibbonBarTextBox();
		ribbonBarTextBox.TextChanged += OnTextChanged;
		return ribbonBarTextBox;
	}

	private void OnTextChanged(object sender, EventArgs e)
	{
		if (RibbonBar != null)
		{
			RibbonBar.OnTextChanged(this);
		}
	}
}
