#region Using

using System;
using System.Collections;
using System.Collections.Specialized;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client
{
	#region Application Class
	
	/// <summary>
	/// Summary description for Application.
	/// </summary>
	
	public class Application : NameObjectCollectionBase, IApplication
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		/// Creates a new <see cref="Application"/> instance.
		/// </summary>
		internal Application(IContext objContext)
		{
			mobjContext = (Context)objContext;
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Class Members
		
		private Context mobjContext = null;
		
		
		#endregion Class Members
		
		#region IApplication Members
		
		/// <summary>
		///
		/// </summary>
		object IApplication.this[string strName]
		{
			get
			{
				return base.BaseGet(strName);
			}
			set
			{
				base.BaseSet(strName,value);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		object IApplication.this[int intIndex]
		{
			get
			{
				return base.BaseGet(intIndex);
			}
		}
		
		
		#endregion IApplication Members
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objApplicationType"></param>
		public static void Run(Type objApplicationType)
		{
			Run(objApplicationType,null);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objApplicationType"></param>
		/// <param name="objLoginType"></param>
		public static void Run(Type objApplicationType,Type objLoginType)
		{
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			Context objContext = new Context();
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.DoEvents();
			if(objLoginType!=null)
			{
				System.Windows.Forms.Application.Run(new Gizmox.WebGUI.Client.Forms.ApplicationForm(objLoginType,objContext));
				if(!objContext.Session.IsLoggedOn)
				{
					return;
				}
			}
			
			System.Windows.Forms.Application.Run(new Gizmox.WebGUI.Client.Forms.ApplicationForm(objApplicationType,objContext));
			
		}

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

        }
		
		
		#endregion Methods
		
	}
	
	#endregion Application Class
	
}
