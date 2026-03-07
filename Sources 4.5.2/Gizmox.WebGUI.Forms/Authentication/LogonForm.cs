#region Using

using System;
using System.Drawing;
using System.ComponentModel;

using Gizmox.WebGUI.Common.Interfaces;

using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms.Authentication
{
	#region LogonForm Class
	
	/// <summary>
	/// Impementation for LogonForm class.
	/// </summary>
    [ToolboxItem(false), Serializable()]
	public class LogonForm : Form, ILogonForm
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		/// Creates a new <see cref="LogonForm"/> instance.
		/// </summary>
		public LogonForm()
		{
			//==============================================================
			// Set wizard details
			//==============================================================
			Height	= 500;
			Width	= 500;
		}
		
		#endregion
	}
	
	#endregion
}
