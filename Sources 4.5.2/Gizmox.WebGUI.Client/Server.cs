#region Using

using System;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Server Class
	
	/// <summary>
	/// Summary description for Server.
	/// </summary>
	
	internal class Server : IServer
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		internal Server()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		/// Returns the physical file path that corresponds to the specified virtual path on the Web server.
		/// </summary>
		/// <param name="strPath">The virtual path on the Web server.</param>
		/// <returns>The physical file path that corresponds to path.</returns>
		public string MapPath(string strPath)
		{
			return strPath;
		}
		
		
		#endregion Methods
		
	}
	
	#endregion Server Class
	
}
