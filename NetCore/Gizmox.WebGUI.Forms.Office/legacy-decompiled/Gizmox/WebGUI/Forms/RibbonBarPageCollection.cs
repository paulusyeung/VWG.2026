using System;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarPageCollection : Collection<RibbonBarPage>
{
	private RibbonBar mobjRibbonBar;

	internal TabControl TabControl => mobjRibbonBar.TabControl;

	internal RibbonBar RibbonBar => mobjRibbonBar;

	protected internal RibbonBarPageCollection(RibbonBar objRibbonBar)
	{
		mobjRibbonBar = objRibbonBar;
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		TabControl.TabPages.Clear();
	}

	protected override void InsertItem(int index, RibbonBarPage item)
	{
		base.InsertItem(index, item);
		item.SetOwner(this);
		TabControl.TabPages.Add(item.TabPage);
		item.TabPage.SendToBack();
	}

	protected override void RemoveItem(int index)
	{
		RibbonBarPage ribbonBarPage = base[index];
		ribbonBarPage.SetOwner(null);
		base.RemoveItem(index);
		TabControl.TabPages.Remove(ribbonBarPage.TabPage);
	}
}
