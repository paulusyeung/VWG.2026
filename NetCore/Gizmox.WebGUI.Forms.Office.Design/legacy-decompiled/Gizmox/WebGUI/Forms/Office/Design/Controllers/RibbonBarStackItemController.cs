using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarStackItemController : ComponentController
{
	private RibbonBarItemCollectionController mobjItemsController;

	public RibbonBarStackItem WebRibbonBarStackItem => base.SourceObject as RibbonBarStackItem;

	public RibbonBarStackItemController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
		mobjItemsController = new RibbonBarItemCollectionController(base.Context, objWebObject, WebRibbonBarStackItem.Items, objWinObject, null);
	}

	public RibbonBarStackItemController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
		mobjItemsController = new RibbonBarItemCollectionController(base.Context, objWebObject, WebRibbonBarStackItem.Items, base.WinComponent, null);
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
