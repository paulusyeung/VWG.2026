using System;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Summary description for SurfacePanel
/// </summary>
[Serializable]
[ToolboxItem(false)]
[Skin(typeof(SurfacePanelSkin))]
public class SurfacePanel : Panel, IRequiresRegistration
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SurfacePanel" /> class.
	/// </summary>
	public SurfacePanel()
	{
		base.PanelType = PanelType.Custom;
		CustomStyle = "Surface";
	}
}
