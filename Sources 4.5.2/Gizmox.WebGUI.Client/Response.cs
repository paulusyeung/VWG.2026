#region Using

using System;
using System.IO;
using System.Xml;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Response Class
	
	/// <summary>
	/// Summary description for WGResponses.
	/// </summary>
	
	internal class  Response : IResponse
	{
		#region Class Members
		
		/// <summary>
		/// Private members
		/// </summary>
		private Context						mobjContext					= null;
		
		
		#endregion Class Members
		
		#region C'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		internal Response(IContext objContext)
		{
			mobjContext	= (Context)objContext;
		}
		
		
		#endregion C'Tor
		
		#region Properties
		
		/// <summary>
		/// Gets the application context.
		/// </summary>
		/// <value></value>
		private Context Context
		{
			get
			{
				return mobjContext;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion Response Class
	
}
