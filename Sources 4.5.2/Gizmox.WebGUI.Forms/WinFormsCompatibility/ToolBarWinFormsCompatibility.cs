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
    public class ToolBarWinFormsCompatibility : ControlWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if content placeholders should be preserved for auto-sized ToolBar items like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if content placeholders should be preserved for auto-sized ToolBar items like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates ToolBarItemAutoSizePreservedPlaceholders
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.ToolBarItemAutoSizePreservedPlaceholders);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.ToolBarItemAutoSizePreservedPlaceholders, value);
            }
        }

        /// <summary>
        /// Gets a value indicating if content placeholders should be preserved for auto-sized ToolBar items like in WinForms.
        /// </summary>
        /// <value>
        /// <c>true</c> if content placeholders should be preserved for auto-sized ToolBar items like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsToolBarItemAutoSizePreservedPlaceholders
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.ToolBarItemAutoSizePreservedPlaceholders);
            }
        }
    }
}
