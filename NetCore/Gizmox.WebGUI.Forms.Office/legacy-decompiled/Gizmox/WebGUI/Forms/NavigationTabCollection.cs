using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class NavigationTabCollection : TabPageCollection
{
	public new NavigationTab this[int intIndex] => (NavigationTab)base[intIndex];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public NavigationTabCollection(TabControl objTabControl)
		: base(objTabControl)
	{
	}

	public override int Add(TabPage objTabPage)
	{
		if (objTabPage is NavigationTab)
		{
			return base.Add(objTabPage);
		}
		return -1;
	}

	public override void Remove(TabPage objTabPage)
	{
		base.Remove(objTabPage);
	}
}
