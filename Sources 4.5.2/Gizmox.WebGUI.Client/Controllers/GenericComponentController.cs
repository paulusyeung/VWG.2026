#region Using

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

using Gizmox.WebGUI.Common.Interfaces;

using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region GenericComponentController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class GenericComponentController : ObjectController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public GenericComponentController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public GenericComponentController(IContext objContext, object objWebObject)
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		: base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public IComponent WebGenericComponent
		{
			get
			{
				return base.SourceObject as IComponent;
			}
		}
		
		/// <summary>
		///
		/// </summary>
        public IComponent WinGenericComponent
		{
			get
			{
				return base.TargetObject as IComponent;
			}
		}
		
		
		#endregion Properties




    }
	
	#endregion GenericComponentController Class
	
}
