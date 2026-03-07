#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Design
{
    #region TextBoxBaseController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>

    public class TextBoxBaseController : Gizmox.WebGUI.Client.Controllers.TextBoxBaseController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <param name="objWinObject"></param>
        public TextBoxBaseController(IContext objContext, object objWebObject, object objWinObject)
            : base(objContext, objWebObject, objWinObject)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        public TextBoxBaseController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }


        #endregion C'Tor/D'Tor

    }

    #endregion TextBoxBaseController Class

}
