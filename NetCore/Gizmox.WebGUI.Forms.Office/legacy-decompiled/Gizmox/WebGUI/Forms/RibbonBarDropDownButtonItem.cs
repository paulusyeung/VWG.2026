using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarDropDownButtonItem : RibbonBarButtonItem
{
	private Button Button => base.Control as Button;

	[Browsable(true)]
	[DefaultValue(null)]
	public virtual ContextMenu DropDownMenu
	{
		get
		{
			return Button.DropDownMenu as ContextMenu;
		}
		set
		{
			Button.DropDownMenu = value;
		}
	}
}
