using System.Collections;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarGroupCollectionController : ComponentCollectionController
{
	public RibbonBarGroupCollectionController(IContext objContext, object objWebRibbonBarPage, IList objWebRibbonBarPageGroups, object objWinRibbonBarPage, IList objWinRibbonBarPageGroups)
		: base(objContext, objWebRibbonBarPage, objWebRibbonBarPageGroups, objWinRibbonBarPage, objWinRibbonBarPageGroups)
	{
	}
}
