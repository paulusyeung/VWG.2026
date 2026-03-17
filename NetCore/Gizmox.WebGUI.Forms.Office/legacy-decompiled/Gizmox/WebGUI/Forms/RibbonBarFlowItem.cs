using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarFlowItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarFlowItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
public class RibbonBarFlowItem : RibbonBarItemContainer
{
	[Editor("Gizmox.WebGUI.Forms.Office.Design.RibonBarFlowItemCollectionEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	public override RibbonBarItemCollection Items => base.Items;

	[DefaultValue(100)]
	public int Width
	{
		get
		{
			return base.Control.Width;
		}
		set
		{
			base.Control.Width = value;
		}
	}

	protected override Control CreateControl()
	{
		return new RibbonBar.RibbonBarFlowLayoutPanel
		{
			Padding = new Padding(2, 8, 2, 1)
		};
	}

	internal override void AppendControl(Control objControl)
	{
		base.AppendControl(objControl);
		objControl.Height = 23;
		objControl.Margin = new Padding(0, 0, 0, 7);
	}

	protected override Type[] GetValidItemTypes()
	{
		return new List<Type>
		{
			typeof(RibbonBarButtonItem),
			typeof(RibbonBarDropDownButtonItem),
			typeof(RibbonBarCheckBoxItem),
			typeof(RibbonBarTextBoxItem),
			typeof(RibbonBarComboBoxItem),
			typeof(RibbonBarToolBarItem)
		}.ToArray();
	}

	protected override void Dispose(bool blnDisposing)
	{
		base.Dispose(blnDisposing);
		if (!blnDisposing)
		{
			return;
		}
		foreach (RibbonBarItem item in Items)
		{
			item.Dispose();
		}
	}
}
