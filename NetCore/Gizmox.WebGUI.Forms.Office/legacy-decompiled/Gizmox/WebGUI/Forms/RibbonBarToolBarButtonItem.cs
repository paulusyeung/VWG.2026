using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarToolBarButtonItem : RibbonBarButtonItem
{
	[Browsable(false)]
	public override string Text
	{
		get
		{
			return "";
		}
		set
		{
		}
	}

	protected override Control CreateControl()
	{
		RibbonBar.RibbonBarButton obj = (RibbonBar.RibbonBarButton)base.CreateControl();
		obj.Width = 23;
		return obj;
	}

	protected override Button CreateButton()
	{
		return new RibbonBar.RibbonBarButton("RibbonBarSmall");
	}
}
