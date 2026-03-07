#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region ListViewController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ListViewController : Gizmox.WebGUI.Client.Controllers.ListViewController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public ListViewController(IContext objContext, object objWebObject, object objWinObject): base(objContext, objWebObject, objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public ListViewController(IContext objContext, object objWebObject): base(objContext, objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        protected override void SetWebListViewColumnHeaderWidth(ColumnHeader objWebColumnHeader, System.Windows.Forms.ColumnHeader objWinColumnHeader)
        {
            if (!this.DesignSuspended)
            {
                try
                {
                    this.SuspendNotifications();
                    this.DesignServices.FireWebComponentChanging(objWinColumnHeader, "Width");
                    object objOldValue = objWebColumnHeader.Width;
                    object objNewValue = objWinColumnHeader.Width;
                    base.SetWebListViewColumnHeaderWidth(objWebColumnHeader, objWinColumnHeader);
                    this.DesignServices.FireWebComponentChanged(objWinColumnHeader, "Width", objOldValue, objNewValue);
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }            
        }
	}
	
	#endregion ListViewController Class
	
}
