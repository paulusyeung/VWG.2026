using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{
    #region DomainUpDownController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
    public class DomainUpDownController : Gizmox.WebGUI.Client.Controllers.UpDownBaseController
    {
        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <param name="objWinObject"></param>
        public DomainUpDownController(IContext objContext, object objWebObject, object objWinObject)
            : base(objContext, objWebObject, objWinObject)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        public DomainUpDownController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }


        #endregion C'Tor/D'Tor





    }

    #endregion DomainUpDownController Class
}
