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
    public class TextBoxWinFormsCompatibility : TextBoxBaseWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if gray background should be applied on read-only TextBox like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if gray background should be applied on read-only TextBox like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates GrayedReadOnlyTextBox
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.GrayedReadOnlyTextBox);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.GrayedReadOnlyTextBox, value);
            }
        }

        /// <summary>
        /// Gets a value indicating if gray background should be applied on read-only TextBox like in WinForms.
        /// </summary>
        /// <value>
        /// <c>true</c> if gray background should be applied on read-only TextBox like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsGrayedReadOnlyTextBox
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.GrayedReadOnlyTextBox);
            }
        }
    }
}
