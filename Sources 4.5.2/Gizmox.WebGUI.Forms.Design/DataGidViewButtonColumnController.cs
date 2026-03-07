#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
    #region DataGidViewButtonColumnController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class DataGidViewButtonColumnController : Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebColumn"></param>
        /// <param name="objWinColumn"></param>
        public DataGidViewButtonColumnController(IContext objContext, object objWebColumn, object objWinColumn)
            : base(objContext, objWebColumn, objWinColumn)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DataGidViewButtonColumnController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }


        #endregion C'Tor/D'Tor

    }

    #endregion DataGidViewButtonColumnController Class

}
