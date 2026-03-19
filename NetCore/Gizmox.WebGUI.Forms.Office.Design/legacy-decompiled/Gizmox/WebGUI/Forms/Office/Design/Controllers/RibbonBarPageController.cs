using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarPageController : ComponentController
{
	private RibbonBarGroupCollectionController mobjGroupsController;

	public RibbonBarPage WebRibbonBarPage => base.SourceObject as RibbonBarPage;

	public RibbonBarPageController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
		mobjGroupsController = new RibbonBarGroupCollectionController(base.Context, objWebObject, WebRibbonBarPage.Groups, objWinObject, null);
	}

	public RibbonBarPageController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
		mobjGroupsController = new RibbonBarGroupCollectionController(base.Context, objWebObject, WebRibbonBarPage.Groups, base.WinComponent, null);
	}

	public override void Clear()
	{
		base.Clear();
		if (mobjGroupsController != null)
		{
			mobjGroupsController.Clear();
		}
	}

	public override void Terminate()
	{
		base.Terminate();
		if (mobjGroupsController != null)
		{
			mobjGroupsController.Terminate();
		}
	}
}
