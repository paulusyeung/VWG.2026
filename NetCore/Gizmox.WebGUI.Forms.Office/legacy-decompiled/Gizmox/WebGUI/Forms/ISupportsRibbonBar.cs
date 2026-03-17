namespace Gizmox.WebGUI.Forms;

public interface ISupportsRibbonBar
{
	RibbonBarGroup CreateGroup(string strGroupName);

	void ApplyGroup(RibbonBarGroup objGroup, string strGroupName);
}
