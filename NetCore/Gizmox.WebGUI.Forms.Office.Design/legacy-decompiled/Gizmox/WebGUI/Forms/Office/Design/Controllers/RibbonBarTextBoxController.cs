using System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarTextBoxController : TextBoxController
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

	public RibbonBarTextBoxController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
	}

	public RibbonBarTextBoxController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}
}
