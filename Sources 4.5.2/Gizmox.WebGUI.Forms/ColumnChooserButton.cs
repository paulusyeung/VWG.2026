#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A button control
    /// </summary>
    [ToolboxItem(false)]
    [Skin(typeof(ColumnChooserButtonSkin))]
    [Serializable()]
    public class ColumnChooserButton : Button
    {
        public ColumnChooserButton()
        {
            this.CustomStyle = "ColumnChooserButtonSkin";
        }

        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportsKeyNavigation
        {
            get
            {
                return true;
            }
        }
    }

}
