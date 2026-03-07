#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms.Phonegap.Integration
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(PhonegapIntegratorSkin))]
    [Serializable()]
    public class PhonegapIntegrator : RegisteredComponent, ISkinable
    {
        public PhonegapIntegrator()
        {
        }

        /// <summary>
        /// Gets the current application context.
        /// </summary>
        public override Common.Interfaces.IContext Context
        {
            get { return VWGContext.Current; }
        }

        public string Theme
        {
            get
            {
                // Only if in design-time and not apply selected theme
                if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
                {
                    return "Default";
                }
                else
                {
                    if (this.Context != null)
                    {
                        return this.Context.CurrentTheme;
                    }

                    return ConfigHelper.SelectedTheme;
                }
            }
        }
    }

}
