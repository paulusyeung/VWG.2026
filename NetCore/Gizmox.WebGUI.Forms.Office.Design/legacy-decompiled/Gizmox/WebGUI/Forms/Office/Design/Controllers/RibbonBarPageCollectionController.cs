using System.Collections;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarPageCollectionController : ComponentCollectionController
{
	public RibbonBarPageCollectionController(IContext objContext, object objWebRibbonBar, IList objWebRibbonBarPages, object objWinRibbonBar, IList objWinRibbonBarPages)
		: base(objContext, objWebRibbonBar, objWebRibbonBarPages, objWinRibbonBar, objWinRibbonBarPages)
	{
	}
}
