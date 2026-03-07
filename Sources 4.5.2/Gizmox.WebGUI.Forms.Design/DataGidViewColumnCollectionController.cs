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
    #region DataGidViewColumnCollectionController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class DataGidViewColumnCollectionController : Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public DataGidViewColumnCollectionController(IContext objContext, object objWebDataGridView, IList objWebColumns, object objWinDataGridView, IList objWinColumns)
            : base(objContext, objWebDataGridView, objWebColumns, objWinDataGridView, objWinColumns)
        {
        }


        #endregion C'Tor/D'Tor

    }

    #endregion DataGidViewColumnCollectionController Class

}
