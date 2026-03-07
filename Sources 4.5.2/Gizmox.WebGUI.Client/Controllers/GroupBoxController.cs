#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region GroupBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class GroupBoxController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public GroupBoxController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public GroupBoxController(IContext objContext, object objWebObject)
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
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.GroupBox();
		}
		
		
		#endregion Methods
		
	}
	
	#endregion GroupBoxController Class
	
}
