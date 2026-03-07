using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class BorderColorEditor : ColorEditor
    {
        /// <summary>
        /// Supplies a editor level mechanism to convert property values before editing
        /// </summary>
        /// <param name="value">The property value.</param>
        /// <returns></returns>
        protected override object GetEditorValueFromPropertyValue(object objValue)
        {
            if (objValue != null)
            {
                return ((BorderColor)objValue).All;
            }
            return Color.Empty;
        }

        /// <summary>
        /// Supplies a editor level mechanism to convert editor returned values before assigning to property
        /// </summary>
        /// <param name="value">The editor returned value.</param>
        /// <returns></returns>
        protected override object GetPropertyValueFromEditorValue(object objValue)
        {
            if (objValue != null)
            {
                return new BorderColor((Color)objValue);
            }
            return BorderColor.Empty;
        }
    }
}
