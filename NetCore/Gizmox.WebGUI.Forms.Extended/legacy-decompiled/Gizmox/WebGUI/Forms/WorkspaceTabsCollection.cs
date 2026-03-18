using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Tab pages collection class
/// </summary>
[Serializable]
public class WorkspaceTabsCollection : TabPageCollection
{
	/// <summary>
	/// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabPage" /> with the specified int index.
	/// </summary>
	/// <value></value>
	public new WorkspaceTab this[int intIndex] => (WorkspaceTab)base[intIndex];

	/// <summary>
	/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection" /> instance.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public WorkspaceTabsCollection(TabControl objTabControl)
		: base(objTabControl)
	{
	}

	/// <summary>
	/// Adds the specified tab page.
	/// </summary>
	/// <param name="objTabPage">tab page.</param>
	/// <returns></returns>
	public override int Add(TabPage objTabPage)
	{
		if (objTabPage is WorkspaceTab)
		{
			return base.Add(objTabPage);
		}
		return -1;
	}

	/// <summary>
	/// Removes the specified tab page.
	/// </summary>
	/// <param name="objTabPage">tab page.</param>
	public override void Remove(TabPage objTabPage)
	{
		base.Remove(objTabPage);
	}
}
