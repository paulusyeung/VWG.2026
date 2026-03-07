#region Using

using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Request Class
	
	/// <summary>
	/// Represents a client request f
	/// </summary>
	
	internal class  Request : IRequest
	{
		#region Class Members
		
		private Context					mobjContext			= null;
		
		
		#endregion Class Members
		
		#region C'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objHttpContext"></param>
		/// <param name="objContext"></param>
		internal Request(IContext objContext)
		{
			// set local reference
			mobjContext = (Context)objContext;
			
		}
		
		
		#endregion C'Tor
		
		#region Properties
		
		
		#endregion Properties
		
	}
	
	#endregion Request Class
	
}
