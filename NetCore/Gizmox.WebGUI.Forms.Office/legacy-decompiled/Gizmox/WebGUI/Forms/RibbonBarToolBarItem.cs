using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarToolBarItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarToolBarItemController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
public class RibbonBarToolBarItem : RibbonBarItemContainer
{
	[Editor("Gizmox.WebGUI.Forms.Office.Design.RibonBarToolBarItemCollectionEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	public override RibbonBarItemCollection Items => base.Items;

	protected override Control CreateControl()
	{
		return new RibbonBar.RibbonBarPanel
		{
			Padding = new Padding(0),
			Margin = new Padding(0)
		};
	}

	internal override void AppendControl(Control objControl)
	{
		base.AppendControl(objControl);
		objControl.Dock = DockStyle.Left;
		int num = 0;
		foreach (Control control in base.Control.Controls)
		{
			num += control.Width;
		}
		num += 5;
		base.Control.Width = num;
	}

	protected override Type[] GetValidItemTypes()
	{
		return new List<Type> { typeof(RibbonBarToolBarButtonItem) }.ToArray();
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
