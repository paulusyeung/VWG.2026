using System;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarGroupCollection : Collection<RibbonBarGroup>
{
	private RibbonBarPage mobjRibonBarPage;

	internal RibbonBar RibbonBar => mobjRibonBarPage.RibbonBar;

	public RibbonBarGroupCollection(RibbonBarPage objRibonBarPage)
	{
		mobjRibonBarPage = objRibonBarPage;
	}

	protected override void SetItem(int index, RibbonBarGroup item)
	{
		base.SetItem(index, item);
	}

	protected override void InsertItem(int index, RibbonBarGroup item)
	{
		base.InsertItem(index, item);
		item.SetOwner(this);
		mobjRibonBarPage.TabPage.Controls.Add(item.GroupBox);
		item.GroupBox.BringToFront();
	}

	protected override void RemoveItem(int index)
	{
		RibbonBarGroup ribbonBarGroup = base[index];
		ribbonBarGroup.SetOwner(null);
		base.RemoveItem(index);
		mobjRibonBarPage.TabPage.Controls.Remove(ribbonBarGroup.GroupBox);
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		mobjRibonBarPage.TabPage.Controls.Clear();
	}

	public void Add(ISupportsRibbonBar objGenerator, string strGroupName)
	{
		RibbonBarGroup ribbonBarGroup = objGenerator.CreateGroup(strGroupName);
		if (ribbonBarGroup != null)
		{
			Add(ribbonBarGroup);
		}
	}
}
