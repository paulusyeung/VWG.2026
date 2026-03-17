using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarStackItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarStackItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
public class RibbonBarStackItem : RibbonBarItemContainer
{
	[Editor("Gizmox.WebGUI.Forms.Office.Design.RibonBarStackItemCollectionEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	public override RibbonBarItemCollection Items => base.Items;

	protected override Control CreateControl()
	{
		return new RibbonBar.RibbonBarPanel
		{
			Width = 108,
			Padding = new Padding(0, 0, 2, 0)
		};
	}

	internal override void RemoveControl(Control objControl)
	{
		base.RemoveControl(objControl);
		UpdateRibbonBarGroup();
	}

	internal override void ClearControls()
	{
		base.ClearControls();
		UpdateRibbonBarGroup();
	}

	internal override void AppendControl(Control objControl)
	{
		base.AppendControl(objControl);
		objControl.Dock = DockStyle.Top;
		objControl.Height = 22;
		if (objControl is Button button)
		{
			button.TextImageRelation = TextImageRelation.ImageBeforeText;
			button.CustomStyle = "RibbonBarMedium";
		}
		UpdateRibbonBarGroup();
	}

	private void UpdateRibbonBarGroup()
	{
		if (base.Owner is RibbonBarGroup ribbonBarGroup)
		{
			ribbonBarGroup.CalculateWidth();
		}
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
