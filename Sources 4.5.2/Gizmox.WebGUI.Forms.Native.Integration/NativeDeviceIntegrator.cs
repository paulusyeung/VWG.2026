using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Native.Integration
{
    [Skin(typeof(NativeDeviceIntegratorSkin))]
    [Serializable()]
    public class NativeDeviceIntegrator : RegisteredComponent, ISkinable
    {
        public NativeDeviceIntegrator()
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
