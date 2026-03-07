#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections.Generic;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region EventCollection Class
	
	/// <summary>
	///
	/// </summary>
	
	internal class EventCollection : Queue<IEvent>, IEventCollection
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		internal EventCollection()
		{
		}
		
		
		#endregion C'Tor / D'Tor
		
		
		
		}
		
	#endregion EventCollection Class
	
}
