using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// This class represents the ExtendedHeaderRow Converter.
    /// Used to avoid the default behaviour of the designer adding columns into the form's resx file.
    /// </summary>
    [Serializable()]
    public class ExtendedHeaderRowDataTypeConverter : TypeConverter
    {
        /// <summary>
        /// Determines whether this instance [can convert to] the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="objDestinationType">Type of the obj destination.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }

            return base.CanConvertTo(context, objDestinationType);
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objCulture">The obj culture.</param>
        /// <param name="objValue">The obj value.</param>
        /// <param name="objDestinationType">Type of the obj destination.</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }

            //If need to support Convert to InstanceDescriptor
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is ExtendedHeaderRowData))
            {
                //Create origin ExtendedHeaderRowData instance
                ExtendedHeaderRowData objExtendedHeaderRowData = objValue as ExtendedHeaderRowData;

                List<object> objArguments = null;
                ConstructorInfo objConstructorInfo = null;

                //Define instance argument, based on HeightMode property value and call proper c'tor
                if (objExtendedHeaderRowData.HeightSizeMode == HeightMode.Custom)
                {
                    objArguments = new List<object>();
                    objArguments.Add(objExtendedHeaderRowData.HeightSizeMode);
                    objArguments.Add(objExtendedHeaderRowData.Height);
                    objConstructorInfo = typeof(ExtendedHeaderRowData).GetConstructor(new Type[] { typeof(HeightMode), typeof(int) });
                }
                else
                {
                    objConstructorInfo = typeof(ExtendedHeaderRowData).GetConstructor(new Type[] { });
                }

                //Return converted InstanceDescriptor onject
                return new InstanceDescriptor(objConstructorInfo, objArguments);
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }
    }
}
