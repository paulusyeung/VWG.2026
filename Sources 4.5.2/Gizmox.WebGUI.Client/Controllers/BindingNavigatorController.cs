#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    
    public class BindingNavigatorController : ToolBarController
    {
        #region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public BindingNavigatorController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
        public BindingNavigatorController(IContext objContext, object objWebControl)
            : base(objContext, objWebControl)
		{
		}
		
		
		#endregion C'Tor/D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.BindingNavigator WebBindingNavigator
        {
            get
            {
                return base.SourceObject as WebForms.BindingNavigator;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.BindingNavigator WinBindingNavigator
        {
            get
            {
                return base.TargetObject as WinForms.BindingNavigator;
            }
        }


        #endregion Properties
    }
}
