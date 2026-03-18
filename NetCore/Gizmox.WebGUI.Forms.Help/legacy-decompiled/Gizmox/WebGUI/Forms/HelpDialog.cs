using System.IO;

namespace Gizmox.WebGUI.Forms;

public class HelpDialog : HelpFormBase
{
	private string mstrCHMLocation = null;

	private HelpNavigator menmCommand = HelpNavigator.TableOfContents;

	private object mobjParam = null;

	protected override HelpNavigator InitializationCommand => menmCommand;

	protected override object InitializationParam => mobjParam;

	protected override string CHMLocation => mstrCHMLocation;

	public HelpDialog(string strCHMLocation, HelpNavigator enmCommand, object objParam)
	{
		mstrCHMLocation = strCHMLocation;
		menmCommand = enmCommand;
		mobjParam = objParam;
	}

	public static void ShowHelp(Control objParent, string strCHMLocation, HelpNavigator enmCommand, object objParam)
	{
		if (File.Exists(strCHMLocation))
		{
			HelpFormBase helpFormBase = new HelpDialog(strCHMLocation, enmCommand, objParam);
			helpFormBase.ShowDialog();
		}
	}
}
