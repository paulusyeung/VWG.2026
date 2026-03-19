using System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Office.Design.Controllers;

public class RibbonBarComboBoxController : ComboBoxController
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

	public RibbonBarComboBoxController(IContext objContext, object objWebObject, object objWinObject)
		: base(objContext, objWebObject, objWinObject)
	{
	}

	public RibbonBarComboBoxController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}
}
