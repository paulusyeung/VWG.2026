using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class ListViewWinFormsCompatibility : ControlWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if grid lines should be rendered into ListView on empty rows.
        /// </summary>
        /// <value>
        /// <c>True</c> if grid lines should be rendered like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates ListViewShowGridLinesOnEmptyRows
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.ListViewShowGridLinesOnEmptyRows);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.ListViewShowGridLinesOnEmptyRows, value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating if grid lines should be rendered into ListView on empty rows.
        /// </summary>
        /// <value>
        /// <c>true</c>if grid lines should be rendered like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool ShowGridLinesOnEmptyRows
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.ListViewShowGridLinesOnEmptyRows);
            }
        }
    }
}
