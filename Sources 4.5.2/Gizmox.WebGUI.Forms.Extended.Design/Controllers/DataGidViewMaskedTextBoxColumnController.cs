#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;

#endregion Using

namespace Gizmox.WebGUI.Forms.Extended.Design.Controllers
{
    #region DataGidViewMaskedTextBoxColumnController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
    
	public class DataGidViewMaskedTextBoxColumnController : DataGidViewTextBoxColumnController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebColumn"></param>
        /// <param name="objWinColumn"></param>
        public DataGidViewMaskedTextBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
            : base(objContext, objWebColumn, objWinColumn)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public DataGidViewMaskedTextBoxColumnController(IContext objContext, object objWebObject)
            : base(objContext, objWebObject)
        {
        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Generic create webforms control
        /// </summary>
        /// <param name="objTargetObject"></param>
        /// <returns></returns>
        protected override object CreateSourceObject(object objTargetObject)
        {
            return new Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxColumn();
        }        

        #endregion Methods
    }

    #endregion DataGidViewMaskedTextBoxColumnController Class
}
