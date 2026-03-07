using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    internal class HiddenZonePopupForm : Form
    {

        #region Fields (1)

        private Zone mobjContainedZone;

        #endregion Fields
        
        #region Properties (1)

        /// <summary>
        /// Gets or sets the contained zone.
        /// </summary>
        /// <value>
        /// The contained zone.
        /// </value>
        internal Zone ContainedZone
        {
            get
            {
                return this.mobjContainedZone;
            }
            set
            {
                this.mobjContainedZone = value;
            }
        }

        #endregion Properties

    }
}
