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
    public class TextBoxBaseWinFormsCompatibility : ControlWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if TextBox keyboard events should be raised in real-time like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if TextBox keyboard events should be raised in real-time like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates TextBoxRealTimeKeyboardEvents
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.TextBoxRealTimeKeyboardEvents);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.TextBoxRealTimeKeyboardEvents, value);
            }
        }

        /// <summary>
        /// Gets a value indicating if TextBox keyboard events should be raised in real-time like in WinForms.
        /// </summary>
        /// <value>
        /// <c>true</c> if TextBox keyboard events should be raised in real-time like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsTextBoxRealTimeKeyboardEvents
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.TextBoxRealTimeKeyboardEvents);
            }
        }
    }
}
