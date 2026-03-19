using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarController : UserControlController
{
	private RibbonBarPageCollectionController mobjPagesController;

	public RibbonBar WebRibbonBar => base.SourceObject as RibbonBar;

	public RibbonBarController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
		mobjPagesController = new RibbonBarPageCollectionController(base.Context, objWebObject, WebRibbonBar.Pages, objWinObject, null);
	}

	public RibbonBarController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
		mobjPagesController = new RibbonBarPageCollectionController(base.Context, objWebObject, WebRibbonBar.Pages, base.WinComponent, null);
	}

	public override void Clear()
	{
		base.Clear();
		if (mobjPagesController != null)
		{
			mobjPagesController.Clear();
		}
	}

	public override void Terminate()
	{
		base.Terminate();
		if (mobjPagesController != null)
		{
			mobjPagesController.Terminate();
		}
	}
}
