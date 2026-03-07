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
    public class TreeViewWinFormsCompatibility : ControlWinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if TreeNode click events should be raised on tree node expansion indicator click like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if TreeNode click events should be raised on tree node expansion indicator click like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates TreeNodeClickEventsOnToggle
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.TreeNodeClickEventsOnToggle);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.TreeNodeClickEventsOnToggle, value);
            }
        }

        /// <summary>
        /// Gets a value indicating if TreeNode click events should be raised on tree node expansion indicator click like in WinForms.
        /// </summary>
        /// <value>
        /// <c>true</c> if TreeNode click events should be raised on tree node expansion indicator click like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsTreeNodeClickEventsOnToggle
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.TreeNodeClickEventsOnToggle);
            }
        }
    }
}
