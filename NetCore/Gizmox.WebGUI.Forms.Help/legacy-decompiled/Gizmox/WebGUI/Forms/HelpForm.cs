using System;
using System.IO;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms;

public class HelpForm : HelpFormBase
{
	private string mstrCHMLocation = null;

	private HelpNavigator menmCommand = HelpNavigator.TableOfContents;

	private object mobjParam = null;

	private bool mblnInitialized = false;

	protected override HelpNavigator InitializationCommand
	{
		get
		{
			InitializeParams();
			return menmCommand;
		}
	}

	protected override object InitializationParam
	{
		get
		{
			InitializeParams();
			return mobjParam;
		}
	}

	protected override string CHMLocation
	{
		get
		{
			if (mstrCHMLocation == null)
			{
				Config instance = Config.GetInstance();
				mstrCHMLocation = Path.Combine(instance.GetDirectory("Data"), "Help.chm");
			}
			return mstrCHMLocation;
		}
	}

	private void InitializeParams()
	{
		if (mblnInitialized)
		{
			return;
		}
		if (Context.Arguments != null && Context.Arguments["command"] != null)
		{
			try
			{
				menmCommand = (HelpNavigator)Enum.Parse(typeof(HelpNavigator), Context.Arguments["command"]);
			}
			catch (Exception)
			{
				menmCommand = HelpNavigator.TableOfContents;
			}
		}
		if (Context.Arguments != null && Context.Arguments["param"] != null)
		{
			try
			{
				mobjParam = Context.Arguments["param"];
			}
			catch (Exception)
			{
				mobjParam = null;
			}
		}
		mblnInitialized = true;
	}
}
