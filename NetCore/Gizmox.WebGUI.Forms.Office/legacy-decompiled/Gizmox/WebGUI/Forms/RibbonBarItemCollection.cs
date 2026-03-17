using System;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class RibbonBarItemCollection : Collection<RibbonBarItem>
{
	private RibbonBarItemContainer mobjRibonBarItemContainer;

	protected internal RibbonBarItemCollection(RibbonBarItemContainer objRibonBarItemContainer)
	{
		mobjRibonBarItemContainer = objRibonBarItemContainer;
	}

	protected override void ClearItems()
	{
		base.ClearItems();
		mobjRibonBarItemContainer.ClearControls();
	}

	protected override void InsertItem(int index, RibbonBarItem item)
	{
		if (IsValidItem(item))
		{
			base.InsertItem(index, item);
			item.SetOwner(mobjRibonBarItemContainer);
			mobjRibonBarItemContainer.AppendControl(item.Control);
		}
	}

	protected override void RemoveItem(int index)
	{
		RibbonBarItem ribbonBarItem = base[index];
		ribbonBarItem.SetOwner(null);
		base.RemoveItem(index);
		mobjRibonBarItemContainer.RemoveControl(ribbonBarItem.Control);
	}

	private bool IsValidItem(RibbonBarItem objItem)
	{
		Type type = objItem.GetType();
		Type[] validItemTypes = mobjRibonBarItemContainer.ValidItemTypes;
		for (int i = 0; i < validItemTypes.Length; i++)
		{
			if (validItemTypes[i].IsAssignableFrom(type))
			{
				return true;
			}
		}
		return false;
	}
}
