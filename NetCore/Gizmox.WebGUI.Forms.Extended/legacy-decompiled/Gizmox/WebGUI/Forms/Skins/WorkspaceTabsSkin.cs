using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins;

/// <summary>
/// WorkspaceTabs Skin
/// </summary>
[Serializable]
[ToolboxBitmap(typeof(TabControl))]
[SkinDependency(typeof(WorkspaceTabSkin))]
public class WorkspaceTabsSkin : TabControlSkin
{
	/// <summary>
	/// Gets the tabs container style.
	/// </summary>
	/// <value>The tabs container style.</value>
	[Category("States")]
	[Description("The tabs top container style.")]
	public override StyleValue TabsTopContainerStyle => base.TabsTopContainerStyle;

	private void InitializeComponent()
	{
	}
}
