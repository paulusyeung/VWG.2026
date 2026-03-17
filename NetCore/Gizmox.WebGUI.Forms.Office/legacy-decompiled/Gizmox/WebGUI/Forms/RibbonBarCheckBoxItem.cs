using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarCheckBoxItem : RibbonBarItem
{
	protected override Control CreateControl()
	{
		RibbonBar.RibbonBarCheckBox ribbonBarCheckBox = new RibbonBar.RibbonBarCheckBox();
		ribbonBarCheckBox.CheckedChanged += OnCheckedChanged;
		return ribbonBarCheckBox;
	}

	private void OnCheckedChanged(object sender, EventArgs e)
	{
		if (RibbonBar != null)
		{
			RibbonBar.OnCheckedChanged(this);
		}
	}
}
