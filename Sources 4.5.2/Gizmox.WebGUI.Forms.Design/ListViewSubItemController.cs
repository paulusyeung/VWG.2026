#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.Collections;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region ListViewSubItemController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ListViewSubItemController : Gizmox.WebGUI.Client.Controllers.ListViewSubItemController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ListViewSubItemController(IContext objContext,object objWebTreeNode,object objWinTreeNode): base(objContext,objWebTreeNode,objWinTreeNode)
		{
			
		}

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ListViewSubItemController(IContext objContext, object objWebObject) : base(objContext, objWebObject)
        {
        }

		#endregion C'Tor/D'Tor
		
	}
	
	#endregion ListViewSubItemController Class
	
}
