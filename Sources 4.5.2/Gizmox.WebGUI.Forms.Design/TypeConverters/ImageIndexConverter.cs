using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    public class ImageIndexConverter : Int32Converter
    {
		#region Fields 

		private string parentImageListProperty = "Parent";

		#endregion 

		#region Properties 

        /// <summary>
        /// Gets a value indicating whether [include none as standard value].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [include none as standard value]; otherwise, <c>false</c>.
        /// </value>
		protected virtual bool IncludeNoneAsStandardValue
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the parent image list property.
        /// </summary>
        /// <value>The parent image list property.</value>
		internal string ParentImageListProperty
        {
            get
            {
                return this.parentImageListProperty;
            }
            set
            {
                this.parentImageListProperty = value;
            }
        }
		
		#endregion 

		#region Methods 

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strA = value as string;
            if ((strA != null) && (string.Compare(strA, SR.GetString("toStringNone"), true, culture) == 0))
            {
                return -1;
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
            if (((destinationType == typeof(string)) && (value is int)) && (((int)value) == -1))
            {
                return SR.GetString("toStringNone");
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
                        PropertyDescriptor descriptor3 = properties[this.ParentImageListProperty];
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
                        object[] objArray;
                        int count = list.Images.Count;
                        if (this.IncludeNoneAsStandardValue)
                        {
                            objArray = new object[count + 1];
                            objArray[count] = -1;
                        }
                        else
                        {
                            objArray = new object[count];
                        }
                        for (int i = 0; i < count; i++)
                        {
                            objArray[i] = i;
                        }
                        return new TypeConverter.StandardValuesCollection(objArray);
                    }
                }
            }
            if (this.IncludeNoneAsStandardValue)
            {
                return new TypeConverter.StandardValuesCollection(new object[] { -1 });
            }
            return new TypeConverter.StandardValuesCollection(new object[0]);
        }

        /// <summary>
        /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; false if other values are possible.
        /// </returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
        /// </returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
		
		#endregion 
    }
}
