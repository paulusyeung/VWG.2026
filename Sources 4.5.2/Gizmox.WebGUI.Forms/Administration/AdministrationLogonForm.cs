using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.Administration.Abstract;

namespace Gizmox.WebGUI.Forms
{
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal class AdministrationLogonForm : AdministrationFormBase, ILogonForm
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationLogonForm"/> class.
        /// </summary>
        public AdministrationLogonForm()
        {
            
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns></returns>
        public override ContentChangeNotifierUserControl GetContent()
        {
            Type objConfiguredLogonControlType = null;
            string strConfiguredLogonControlType = HostRuntime.Config.Administration.LogonControlName;
            
            if (!string.IsNullOrEmpty(strConfiguredLogonControlType))
            {
                try
                {
                    objConfiguredLogonControlType = Type.GetType(strConfiguredLogonControlType);
                }
                catch (Exception)
                {
                    return new DefaultAdministrationLogonControl();
                }

                if (objConfiguredLogonControlType != null)
                {
                    AdministrationLogonControlBase objInstance = Activator.CreateInstance(objConfiguredLogonControlType) as AdministrationLogonControlBase;
                    if (objInstance != null)
                    {
                        return objInstance;
                    }
                }
            }

            return new DefaultAdministrationLogonControl();
        }
    }
}
