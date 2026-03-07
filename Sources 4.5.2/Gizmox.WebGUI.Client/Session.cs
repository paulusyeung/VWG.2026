#region Using

using System;
using System.Web;
using System.Xml;
using System.Threading;
using System.Collections;
using System.Globalization;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Session Class
	
	/// <summary>
	/// Summary description for Session.
	/// </summary>
	
	internal class  Session : ISession
	{
		#region Class Members
		
		/// <summary>
		/// Context related objects
		/// </summary>
		private Hashtable mobjObjects = null;
		

		/// <summary>
		/// Logged on flag
		/// </summary>
		private bool			mblnIsLoggedOn					= false;
		
		/// <summary>
		/// Right to left interface
		/// </summary>
		private bool			mblnRightToLeft					= false;
		
		/// <summary>
		///
		/// </summary>
		private Context mobjContext = null;
		
		private int mintTraceLimit = -1;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		/// Creates a new <see cref="Session"/> instance.
		/// </summary>
		internal Session(IContext objContext)
		{
			
			
			// Create session objects
			mobjObjects				= new Hashtable();
			
			
			
			if(CommonSwitches.TraceEnabled)
			{
				mintTraceLimit = CommonSwitches.TraceThreshold;
			}
			
			mobjContext = (Context)objContext;
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		

		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		/// Gets the current session ID.
		/// </summary>
		/// <value></value>
		public string SessionID
		{
			get
			{
				return "1";
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether this instance is logged on.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is logged on; otherwise, <c>false</c>.
		/// </value>
		public bool IsLoggedOn
		{
			get
			{
				return mblnIsLoggedOn;
			}
			set
			{
				mblnIsLoggedOn = value;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public CultureInfo CurrentUICulture
		{
			get
			{
				return System.Threading.Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the <see cref="Object"/> with the specified property.
		/// </summary>
		/// <value></value>
		public object this[string strProperty]
		{
			get
			{
				return mobjObjects[strProperty];
			}
			set
			{
				mobjObjects[strProperty]=value;
			}
		}
		
		

		#endregion Properties
		
	}
	
	#endregion Session Class	
}
