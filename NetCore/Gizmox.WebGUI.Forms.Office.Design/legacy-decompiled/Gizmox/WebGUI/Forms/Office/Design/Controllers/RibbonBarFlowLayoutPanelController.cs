using System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarFlowLayoutPanelController : FlowLayoutPanelController
{
	public override object SelectableObject
	{
		get
		{
			System.Windows.Forms.Control winAncestorByWebType = GetWinAncestorByWebType(typeof(RibbonBar));
			if (winAncestorByWebType != null)
			{
				return winAncestorByWebType;
			}
			return base.TargetObject;
		}
	}

	public RibbonBarFlowLayoutPanelController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
	}

	public RibbonBarFlowLayoutPanelController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}
}
