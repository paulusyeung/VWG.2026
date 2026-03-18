using System;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public class ProcessCompletedArgs : EventArgs
{
	private bool mblnChangesApplied;

	public bool ChangesApplied
	{
		get
		{
			return mblnChangesApplied;
		}
		set
		{
			mblnChangesApplied = value;
		}
	}

	public ProcessCompletedArgs(bool blnChangesApplied)
	{
		mblnChangesApplied = blnChangesApplied;
	}
}
