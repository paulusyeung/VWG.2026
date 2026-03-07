#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Design;


#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region PlaceHolderController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
    
	public class PlaceHolderController : Gizmox.WebGUI.Client.Controllers.PlaceHolderController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public PlaceHolderController(IContext objContext, object objWebObject, object objWinObject): base(objContext, objWebObject, objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public PlaceHolderController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor





    }
	
	#endregion PlaceHolderController Class
	
}
