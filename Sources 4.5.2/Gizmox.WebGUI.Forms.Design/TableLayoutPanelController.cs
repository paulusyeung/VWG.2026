#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
	#region TableLayoutPanelController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TableLayoutPanelController : Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public TableLayoutPanelController(IContext objContext, object objWebObject, object objWinObject): base(objContext, objWebObject, objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public TableLayoutPanelController(IContext objContext, object objWebObject): base(objContext, objWebObject)
		{
		}

        /// <summary>
        /// Sets the source table layout panel column styles.
        /// </summary>
        protected override void SetSourceTableLayoutPanelColumnStyles()
        {
            base.SetSourceTableLayoutPanelColumnStyles();

            try
            {
                this.SuspendNotifications();
                this.DesignServices.FireWebComponentChanged(this.SourceObject, "ColumnStyles", this.TargetTableLayoutPanel.ColumnStyles, this.TargetTableLayoutPanel.ColumnStyles);
            }
            finally
            {
                this.ResumeNotifications();
            }
        }

        /// <summary>
        /// Sets the source table layout panel row styles.
        /// </summary>
        protected override void SetSourceTableLayoutPanelRowStyles()
        {
            base.SetSourceTableLayoutPanelRowStyles();

            try
            {
                this.SuspendNotifications();

                this.DesignServices.FireWebComponentChanged(this.SourceObject, "RowStyles", this.TargetTableLayoutPanel.RowStyles, this.TargetTableLayoutPanel.RowStyles);

            }
            finally
            {
                this.ResumeNotifications();
            }
        }
		
		
		#endregion C'Tor/D'Tor
		
	}
	
	#endregion TableLayoutPanelController Class
	
}
