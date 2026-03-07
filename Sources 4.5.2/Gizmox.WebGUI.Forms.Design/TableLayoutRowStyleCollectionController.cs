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
    #region TableLayoutRowStyleCollectionController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class TableLayoutRowStyleCollectionController : Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        public TableLayoutRowStyleCollectionController(IContext objContext, object objWebObject, IList objWebList, object objWinObject, IList objWinList)
            : base(objContext, objWebObject, objWebList, objWinObject, objWinList)
        {

        }


        #endregion C'Tor/D'Tor

    }

    #endregion TableLayoutRowStyleCollectionController Class

}
