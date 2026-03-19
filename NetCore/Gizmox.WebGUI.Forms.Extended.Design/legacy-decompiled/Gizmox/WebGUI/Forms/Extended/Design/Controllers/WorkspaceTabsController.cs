using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers;

public class WorkspaceTabsController : Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController
{
	public WorkspaceTabsController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
	}

	public WorkspaceTabsController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}

	protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
	{
		base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
	}
}
