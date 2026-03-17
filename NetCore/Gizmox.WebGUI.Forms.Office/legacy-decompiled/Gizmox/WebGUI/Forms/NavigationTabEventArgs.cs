using System;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class NavigationTabEventArgs : EventArgs
{
	public readonly NavigationTab NavigationTab;

	public NavigationTabEventArgs(NavigationTab objNavigationTab)
	{
		NavigationTab = objNavigationTab;
	}
}
