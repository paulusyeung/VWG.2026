using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms.Office.Design.Editors;

public class RibbonBarPageContextualTabGroupEditor : ContextualTabGroupEditor
{
	protected override TabPage TabPage
	{
		get
		{
			if (mobjContext.Instance is RibbonBarPage ribbonBarPage)
			{
				return ribbonBarPage.TabPage;
			}
			return null;
		}
	}
}
