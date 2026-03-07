using System;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.Design.TypeConverters
{


    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Originally class defined in System.Design.dll with internal visibility scope, that makes
    /// impossible to instantiate it in Partially Trusted Environment.
    /// </remarks>
    public class DataMemberFieldConverter : TypeConverter
    {
		#region Methods

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }
		
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if ((value != null) && value.Equals(SR.GetString("None")))
            {
                return string.Empty;
            }
            return value;
        }
		
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType != typeof(string)) || ((value != null) && !value.Equals(string.Empty)))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            return SR.GetString("None_lc");
        }
		
		#endregion
    }
}
