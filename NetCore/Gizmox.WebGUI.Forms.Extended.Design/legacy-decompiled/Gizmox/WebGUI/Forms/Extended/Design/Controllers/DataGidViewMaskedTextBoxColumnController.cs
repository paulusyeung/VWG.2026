using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers;

public class DataGidViewMaskedTextBoxColumnController : DataGidViewTextBoxColumnController
{
	public DataGidViewMaskedTextBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
		: base(objContext, objWebColumn, objWinColumn)
	{
	}

	public DataGidViewMaskedTextBoxColumnController(IContext objContext, object objWebObject)
		: base(objContext, objWebObject)
	{
	}

	protected override object CreateSourceObject(object objTargetObject)
	{
		return new DataGridViewMaskedTextBoxColumn();
	}
}
