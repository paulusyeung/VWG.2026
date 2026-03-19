using System.Collections;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarItemCollectionController : ComponentCollectionController
{
	public RibbonBarItemCollectionController(IContext objContext, object objWebRibbonBarGroup, IList objWebRibbonBarGroupItems, object objWinRibbonBarGroup, IList objWinRibbonBarGroupItems)
		: base(objContext, objWebRibbonBarGroup, objWebRibbonBarGroupItems, objWinRibbonBarGroup, objWinRibbonBarGroupItems)
	{
	}
}
