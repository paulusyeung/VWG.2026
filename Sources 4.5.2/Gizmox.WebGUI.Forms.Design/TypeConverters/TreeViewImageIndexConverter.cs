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
    public class TreeViewImageIndexConverter : ImageIndexConverter
    {
        #region Public Methods

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = value as string;
            if (str != null)
            {
                if (string.Compare(str, SR.GetString("toStringDefault"), true, culture) == 0)
                {
                    return -1;
                }
                if (string.Compare(str, SR.GetString("toStringNone"), true, culture) == 0)
                {
                    return -2;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

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
            if ((destinationType == typeof(string)) && (value is int))
            {
                switch (((int)value))
                {
                    case -1:
                        return SR.GetString("toStringDefault");

                    case -2:
                        return SR.GetString("toStringNone");
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
        /// </returns>
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if ((context != null) && (context.Instance != null))
            {
                object instance = context.Instance;
                PropertyDescriptor imageListProperty = ImageListUtils.GetImageListProperty(context.PropertyDescriptor, ref instance);
                while ((instance != null) && (imageListProperty == null))
                {
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
                    foreach (PropertyDescriptor descriptor2 in properties)
                    {
                        if (typeof(ImageList).IsAssignableFrom(descriptor2.PropertyType))
                        {
                            imageListProperty = descriptor2;
                            break;
                        }
                    }
                    if (imageListProperty == null)
                    {
                        PropertyDescriptor descriptor3 = properties[base.ParentImageListProperty];
                        if (descriptor3 != null)
                        {
                            instance = descriptor3.GetValue(instance);
                            continue;
                        }
                        instance = null;
                    }
                }
                if (imageListProperty != null)
                {
                    ImageList list = (ImageList)imageListProperty.GetValue(instance);
                    if (list != null)
                    {
                        int num = list.Images.Count + 2;
                        object[] values = new object[num];
                        values[num - 2] = -1;
                        values[num - 1] = -2;
                        for (int i = 0; i < (num - 2); i++)
                        {
                            values[i] = i;
                        }
                        return new TypeConverter.StandardValuesCollection(values);
                    }
                }
            }
            return new TypeConverter.StandardValuesCollection(new object[] { -1, -2 });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [include none as standard value].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [include none as standard value]; otherwise, <c>false</c>.
        /// </value>
        protected override bool IncludeNoneAsStandardValue
        {
            get
            {
                return false;
            }
        }

        #endregion    }
    }
}
