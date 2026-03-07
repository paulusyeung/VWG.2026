using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// CheckBox Skin
    /// </summary>
    [Serializable(), Gizmox.WebGUI.Forms.Skins.SkinContainer(typeof(DockingManagerSkin))]
    public class ZonePinCheckBoxSkin : Gizmox.WebGUI.Forms.Skins.CheckBoxSkin
    {
		#region Properties (1) 

        /// <summary>
        /// Gets the width of the expand button image.
        /// </summary>
        /// <value>
        /// The width of the expand button image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Size TotalSize
        {
            get
            {
                Size objTotalSize = GetImageSize(this.NormalStyle.CenterStyle.BackgroundImage, Size.Empty);
                objTotalSize.Width += this.NormalStyle.CenterStyle.BorderWidth.Left + this.NormalStyle.CenterStyle.BorderWidth.Right;
                objTotalSize.Height += this.NormalStyle.CenterStyle.BorderWidth.Top + this.NormalStyle.CenterStyle.BorderWidth.Bottom;

                objTotalSize.Width += this.NormalStyle.CenterStyle.Padding.Horizontal;
                objTotalSize.Height += this.NormalStyle.CenterStyle.Padding.Vertical;

                return objTotalSize;
            }
        }

		#endregion Properties 

		#region Methods (1) 

		// Private Methods (1) 

        private void InitializeComponent()
        {

        }

		#endregion Methods 
    }
}
