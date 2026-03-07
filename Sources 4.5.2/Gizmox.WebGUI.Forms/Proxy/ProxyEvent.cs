using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{
    #region ProxyEvent Class

    /// <summary>
    /// ProxyEvent class
    /// </summary>
    [Serializable()]
    [WebCollectionEditorItemTypeNameAttribute("Event")]
    public class ProxyEvent : ProxyAction
    {

        private string mstrTargetComponentUniqueID;


        #region C'Tor


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyEvent"/> class.
        /// </summary>
        public ProxyEvent()
        {
        }

        #endregion C'Tor


        #region Properties

        /// <summary>
        /// Gets or sets the target component unique ID.
        /// </summary>
        /// <value>
        /// The target component unique ID.
        /// </value>
        #if WG_NET46
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET452
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET451
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
        #elif WG_NET45
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET40
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET35
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET2
        [WebEditor("Gizmox.WebGUI.Forms.Design.TargetComponentUniqueIDEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#endif
        public string TargetComponentUniqueID
        {
            get
            {
                return mstrTargetComponentUniqueID;
            }
            set
            {
                mstrTargetComponentUniqueID = value;
            }
        }


        #endregion Properties

        #region Methods

        /// <summary>
        /// Executes action.
        /// </summary>
        public override void Execute()
        {
            IContext objContext = Global.Context;
            if (objContext != null)
            {
                string strTargetUniqueID = this.TargetComponentUniqueID;
                if (!string.IsNullOrEmpty(strTargetUniqueID))
                {
                    ProxyComponent objProxyComponent = this.ActionOwner as ProxyComponent;
                    if (objProxyComponent != null)
                    {
                        Form objForm = objContext.ActiveForm as Form;

                        if (objForm != null)
                        {
                            Component objTargetComponent = objProxyComponent.GetComponentByUniqueId(objForm, strTargetUniqueID);

                            if (objTargetComponent != null)
                            {
                                Type objComponentType = objTargetComponent.GetType();
                                object[] objCustomAttributes = objComponentType.GetCustomAttributes(typeof(DefaultEventAttribute), true);
                                if (objCustomAttributes != null && objCustomAttributes.Length > 0)
                                {
                                    DefaultEventAttribute objDefaultEventAttribute = objCustomAttributes[0] as DefaultEventAttribute;
                                    if (objDefaultEventAttribute != null)
                                    {
                                        MethodInfo objMethodInfo = objComponentType.GetMethod(string.Format("On{0}", objDefaultEventAttribute.Name), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                                        if (objMethodInfo != null)
                                        {
                                            ArrayList objArrayList = new ArrayList();
                                            ParameterInfo[] objParameterInfos = objMethodInfo.GetParameters();
                                            if (objParameterInfos != null)
                                            {
                                                foreach (ParameterInfo objParameterInfo in objParameterInfos)
                                                {
                                                    Type objParameterType = objParameterInfo.ParameterType;
                                                    object objParameterValue = CommonUtils.GetTypeDefaultValue(objParameterType);
                                                    objArrayList.Add(objParameterValue);
                                                }
                                            }
                                            objMethodInfo.Invoke(objTargetComponent, objArrayList.ToArray());
                                        }
                                    }
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
            return "Event";
        }

        #endregion Methods
    }

    #endregion ProxyEvent Class
}