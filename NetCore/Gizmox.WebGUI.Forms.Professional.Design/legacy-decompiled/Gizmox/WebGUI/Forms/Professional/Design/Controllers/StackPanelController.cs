using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Professional.Design.Controllers;

public class StackPanelController : Gizmox.WebGUI.Client.Controllers.StackPanelController
{
	public StackPanelController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
	}

	public StackPanelController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}
}
