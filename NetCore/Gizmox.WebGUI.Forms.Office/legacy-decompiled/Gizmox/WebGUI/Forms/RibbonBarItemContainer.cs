using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public abstract class RibbonBarItemContainer : RibbonBarItem
{
	private RibbonBarItemCollection mobItems;

	private Type[] mobjValidTypes;

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual RibbonBarItemCollection Items
	{
		get
		{
			if (mobItems == null)
			{
				mobItems = new RibbonBarItemCollection(this);
			}
			return mobItems;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Type[] ValidItemTypes => GetValidItemTypes();

	internal virtual void AppendControl(Control objControl)
	{
		base.Control.Controls.Add(objControl);
		objControl.BringToFront();
	}

	internal virtual void RemoveControl(Control objControl)
	{
		base.Control.Controls.Remove(objControl);
	}

	internal virtual void ClearControls()
	{
		base.Control.Controls.Clear();
	}

	protected abstract Type[] GetValidItemTypes();
}
