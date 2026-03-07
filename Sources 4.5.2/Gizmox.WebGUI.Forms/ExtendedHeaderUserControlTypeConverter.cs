using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// ExtendedHeaderUserControl Convertor.
    /// Used to manage Designer feature for the object. e.g. Display filtered properties on PropertyGrid by User Control cell type
    /// </summary>
    public class ExtendedHeaderUserControlTypeConverter : TypeConverter
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
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) && value is ExtendedHeaderUserControl)
            {
                ConstructorInfo constructor = value.GetType().GetConstructor(new Type[] { });
                if (constructor != null)
                {
                    return new InstanceDescriptor(constructor, new object[] { });
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="objValue">The obj value.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object objValue, Attribute[] attributes)
        {
            if (objValue is ExtendedHeaderUserControl)
            {
                PropertyDescriptorCollection objPropertyDescriptorCollection = TypeDescriptor.GetProperties(objValue.GetType(), attributes);

                PropertyDescriptor objTransformTypeDescriptor = objPropertyDescriptorCollection["ExtendedHeaderCellType"];

                if (objTransformTypeDescriptor != null)
                {
                    ExtendedHeaderCellType objTransformType = (ExtendedHeaderCellType)objTransformTypeDescriptor.GetValue(objValue);

                    // Create an empty Properties collection;
                    PropertyDescriptorCollection objRelevantProperties = new PropertyDescriptorCollection(null);

                    //Add ColSpan and ColIndex properties only to common header user control type. For Corner/Expand etc types avoid adding those two
                    foreach (PropertyDescriptor objPropertyDescriptor in objPropertyDescriptorCollection)
                    {
                        if (objPropertyDescriptor.Name == "ColSpan" || objPropertyDescriptor.Name == "ColIndex")
                        {
                            switch (objTransformType)
                            {
                                case ExtendedHeaderCellType.Headers:
                                    objRelevantProperties.Add(objPropertyDescriptor);
                                    break;
                                case ExtendedHeaderCellType.Corner:
                                case ExtendedHeaderCellType.Expand:
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            objRelevantProperties.Add(objPropertyDescriptor);
                        }
                    }

                    return objRelevantProperties;
                }
            }

            return null;
        }
    }

}
