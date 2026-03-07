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
    public class ControlWinFormsCompatibility : WinFormsCompatibility
    {
        /// <summary>
        /// Gets or sets a value indicating if control resizing should raise Resize events for contained controls like in WinForms.
        /// </summary>
        /// <value>
        /// <c>True</c> if control resizing should raise Resize events for contained controls like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
        /// </value>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        public WinFormsCompatibilityStates RecursiveResizeEvent
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.RecursiveResizeEvent);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.RecursiveResizeEvent, value);
            }
        }

        /// <summary>
        /// Gets a value indicating if control resizing should raise Resize events for contained controls like in WinForms.
        /// </summary>
        /// <value>
        /// <c>true</c> if control resizing should raise Resize events for contained controls like in WinForms; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsRecursiveResizeEvent
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.RecursiveResizeEvent);
            }
        }

        /// <summary>
        /// Should forbid margin styles on items in Dock container or use Winforms style with no margin
        /// </summary>
        [DefaultValue(WinFormsCompatibilityStates.Default)]
        [SRDescription("Don't Include margins when docking controls within a container")]
        public WinFormsCompatibilityStates ForbidDockMargin
        {
            get
            {
                return GetFeature(WinFormsCompatibilityPredefinedOptions.ForbidDockMargin);
            }
            set
            {
                SetFeature(WinFormsCompatibilityPredefinedOptions.ForbidDockMargin, value);
            }
        }

        /// <summary>
        /// Should forbid margin styles on items in Dock container or use Winforms style with no margin
        /// </summary>
        [Browsable(false)]
        public bool IsForbidDockMargin
        {
            get
            {
                return GetFeatureBoolValue(WinFormsCompatibilityPredefinedOptions.ForbidDockMargin);
            }
        }
    }
}
