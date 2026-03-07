using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewImageKeyConverter : ImageKeyConverter
    {

        #region Public Methods

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if ((destinationType == typeof(string)) && (value == null))
            {
                return SR.GetString("toStringDefault");
            }
            string str = value as string;
            if ((str != null) && (str.Length == 0))
            {
                return SR.GetString("toStringDefault");
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        #endregion    }

    }
}
