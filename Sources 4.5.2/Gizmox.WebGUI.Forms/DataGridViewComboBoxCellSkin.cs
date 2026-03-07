using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// DataGridView ComboBox Cell Skin
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox), "ComboBox.bmp")]
    [Serializable()]
    public class DataGridViewComboBoxCellSkin : Gizmox.WebGUI.Forms.Skins.ComboBoxSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the cell normal style.
        /// </summary>
        /// <value>The cell normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CellNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellNormalStyle", true);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the color of the normal fore.
        /// </summary>
        /// <value>The color of the normal fore.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color NormalForeColor
        {
            get
            {
                return this.CellNormalStyle.ForeColor;
            }
        }

    }
}
