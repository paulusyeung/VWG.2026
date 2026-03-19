using System;
using System.ComponentModel.Design;

namespace Gizmox.WebGUI.Forms.Office.Design;

public abstract class RibonBarItemCollectionEditor : CollectionEditor
{
	public RibonBarItemCollectionEditor(Type objType)
		: base(objType)
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		if (base.Context.Instance is RibbonBarItemContainer ribbonBarItemContainer)
		{
			return ribbonBarItemContainer.ValidItemTypes;
		}
		return new Type[0];
	}
}
