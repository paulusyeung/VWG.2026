using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class ListControlWinFormsCompatibility : ControlWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if ListControl selected index changed raising should be forced on click like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if ComboBox selected index changed raising should be forced on click like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates ForceSelectedIndexChangedOnClick
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.ForceSelectedIndexChangedOnClick);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.ForceSelectedIndexChangedOnClick, value);
            }
        }


        /// <summary>
        /// Gets a value indicating whether [is force selected index changed on click].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is force selected index changed on click]; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsForceSelectedIndexChangedOnClick
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.ForceSelectedIndexChangedOnClick);
            }
        }
    }
}
