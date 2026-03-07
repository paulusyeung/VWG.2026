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
    [WebCollectionEditorItemTypeNameAttribute("Activate Form")]
    public class ProxyActivateFormCommand : ProxyAction
    {
        #region Members

        private Type mobjFormType = null;
        
        #endregion Members


        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyActivateFormCommand"/> class.
        /// </summary>
        public ProxyActivateFormCommand()
        {
        }

        #endregion C'Tor


        #region Properties

        /// <summary>
        /// Gets or sets the type of the form.
        /// </summary>
        /// <value>
        /// The type of the form.
        /// </value>
        #if WG_NET46
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET452
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET451
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET45
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET40
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET35
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET2
                [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActivateFormCommandEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#endif
        public Type FormType
        {
            get
            {
                return mobjFormType;
            }
            set
            {
                mobjFormType = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Executes action
        /// </summary>
        public override void Execute()
        {
            IContext objContext = Global.Context;
            if (objContext != null)
            {
                if (objContext.ActiveForm.GetType() != this.FormType)
                {
                    List<IForm> objList = new List<IForm>(((IFormResolver)objContext).AccessibleForms);
                    if (objList != null)
                    {
                        foreach (IForm objIForm in objList)
                        {
                            Form objForm = objIForm as Form;
                            if (objForm != null)
                            {
                                if (objForm.GetType() == this.FormType)
                                {
                                    objForm.ActivateForm(true);
                                    break;
                                }
                            }
                        }
                    }
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
            return "Activate Form";
        }

        #endregion Methods
    }
}
