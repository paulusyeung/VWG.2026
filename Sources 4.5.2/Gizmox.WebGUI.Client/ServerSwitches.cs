#region Using

using System;
using System.Diagnostics;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region ClientSwitches Class
	
	/// <summary>
	/// Summary description for ClientSwitches.
	/// </summary>
	
	internal class ClientSwitches
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		static ClientSwitches()
		{
			mblnShowEventsSwitch = new BooleanSwitch("VWG_ShowEventsSwitch","Show client side event alerts.");
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		private static BooleanSwitch mblnDisableObscuringSwitch;
		
		private static BooleanSwitch mblnShowEventsSwitch;
		
		private static BooleanSwitch mblnShowClientErrorsSwitch;
		
		private static BooleanSwitch mblnDisableCachingSwitch;
		
		
		#endregion Class Members
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public static BooleanSwitch ShowEvents
		{
			get
			{
				return mblnShowEventsSwitch;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ClientSwitches Class
	
}
