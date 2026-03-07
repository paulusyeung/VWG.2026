#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region TreeNodeController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TreeNodeController : Gizmox.WebGUI.Client.Controllers.TreeNodeController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public TreeNodeController(IContext objContext, object objWebObject, object objWinObject): base(objContext, objWebObject, objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public TreeNodeController(IContext objContext, object objWebObject): base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        /// <summary>
        /// </summary>
        protected override void InitializedContained()
        {
            if (!this.WebTreeNode.IsExpanded && this.WebTreeNode.HasNodes)
            {
                this.WinTreeNode.HasNodes = true;
            }
            else
            {
                base.InitializedContained();
            }
        }
	}
	
	#endregion TreeNodeController Class
	
}
