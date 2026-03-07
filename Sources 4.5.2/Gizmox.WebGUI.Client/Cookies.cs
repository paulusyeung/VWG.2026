#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Cookies Class
	
	/// <summary>
	/// Summary description for Cookies.
	/// </summary>
	
	internal class Cookies : ICookies
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		internal Cookies()
		{
			
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public string this[string strKey]
		{
			get
			{
				string strValue = System.Windows.Forms.Application.CommonAppDataRegistry.GetValue(string.Format("COOKIE_{0}",strKey)) as string;
				if(strValue==null)
				{
					strValue="";
				}
				return strValue;
			}
			set
			{
                System.Windows.Forms.Application.CommonAppDataRegistry.SetValue(string.Format("COOKIE_{0}", strKey), value);
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion Cookies Class
}
