using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Represents a single tab page in a <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTabs"></see>.
/// </summary>
[Serializable]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[DesignTimeVisible(false)]
[ToolboxItem(false)]
[DefaultProperty("Text")]
[Skin(typeof(WorkspaceTabSkin))]
public class WorkspaceTab : TabPage
{
	/// <summary>
	/// Gets or sets the appearance.
	/// </summary>
	/// <value>
	/// The appearance.
	/// </value>
	protected override TabAppearance Appearance
	{
		get
		{
			return TabAppearance.Workspace;
		}
		set
		{
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTab"></see> class.
	/// </summary>
	public WorkspaceTab()
	{
		CustomStyle = "Workspace";
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTab"></see> class and specifies the text for the tab.
	/// </summary>
	/// <param name="strText">The text for the tab. </param>
	public WorkspaceTab(string strText)
		: base(strText)
	{
		CustomStyle = "Workspace";
	}
}
