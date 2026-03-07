#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace $rootnamespace$
{
    /// <summary>
    /// A ToolTip control
    /// </summary>
    [Skin(typeof($safeitemname$Skin))]
    [Serializable()]
    [ProvideProperty("ToolTipTemplateName", typeof(Control))]
    public class $safeitemname$ : ToolTip
    {
        #region Template Name Property Extension

        /// <summary>
        /// Gets the name of the tool tip template.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns></returns>
        [DefaultValue("")]
        public string GetToolTipTemplateName(Control objControl)
        {
            return GetExtendedToolTipTemplateName(objControl);
        }

        /// <summary>
        /// Sets the name of the tool tip template.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="strValue">The STR value.</param>
        public void SetToolTipTemplateName(Control objControl, string strValue)
        {
            SetExtendedToolTipTemplateName(objControl, strValue);
        }

        /// <summary>
        /// Determines whether to serialize the tooltip template name.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns></returns>
        private bool ShouldSerializeToolTipTemplateName(Control objControl)
        {
            return !string.IsNullOrEmpty(GetExtendedToolTipTemplateName(objControl));
        }

        /// <summary>
        /// Resets the tooltip template name.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        private void ResetToolTipTemplateName(Control objControl)
        {
            SetExtendedToolTipTemplateName(objControl, string.Empty);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the tool tip key.
        /// </summary>
        protected override string ToolTipKey
        {
            get
            {
                return "$safeitemname$Skin";
            }
        }

        #endregion Properties
    }
}
