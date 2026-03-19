using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarFlowItemController : ComponentController
{
	private RibbonBarItemCollectionController mobjItemsController;

	public RibbonBarFlowItem WebRibbonBarFlowItem => base.SourceObject as RibbonBarFlowItem;

	public RibbonBarFlowItemController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
		mobjItemsController = new RibbonBarItemCollectionController(base.Context, objWebObject, WebRibbonBarFlowItem.Items, objWinObject, null);
	}

	public RibbonBarFlowItemController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
		mobjItemsController = new RibbonBarItemCollectionController(base.Context, objWebObject, WebRibbonBarFlowItem.Items, base.WinComponent, null);
	}

	public override void Clear()
	{
		base.Clear();
		if (mobjItemsController != null)
		{
			mobjItemsController.Clear();
		}
	}

	public override void Terminate()
	{
		base.Terminate();
		if (mobjItemsController != null)
		{
			mobjItemsController.Terminate();
		}
	}
}
