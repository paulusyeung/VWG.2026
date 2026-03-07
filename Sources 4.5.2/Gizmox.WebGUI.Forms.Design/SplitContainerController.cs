#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
    #region SplitContainerController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class SplitContainerController : Gizmox.WebGUI.Client.Controllers.SplitContainerController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="SplitContainerController"></param>
        /// <param name="objWinObject"></param>
        public SplitContainerController(IContext objContext, object SplitContainerController, object objWinObject)
            : base(objContext, SplitContainerController, objWinObject)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="SplitContainerController"></param>
        public SplitContainerController(IContext objContext, object SplitContainerController)
            : base(objContext, SplitContainerController)
        {
        }

        #endregion C'Tor/D'Tor

    }

    #endregion SplitContainerController Class

}
