using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Close Active Form")]
    public class ProxyCloseActiveFormCommand : ProxyAction
    {
        #region Members

        private Type mobjFormType = null;

        #endregion Members

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyCloseActiveFormCommand"/> class.
        /// </summary>
        public ProxyCloseActiveFormCommand()
        {
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Executes action
        /// </summary>
        public override void Execute()
        {
            IContext objContext = Global.Context;
            if (objContext != null)
            {
                Form objActiveForm = objContext.ActiveForm as Form;
                if (objActiveForm != null && objActiveForm.CloseBox && objActiveForm.FormBorderStyle != FormBorderStyle.None)
                {
                    objContext.ActiveForm.Close();
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Close Active Form";
        }

        #endregion Methods
    }
}
