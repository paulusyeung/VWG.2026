using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Specialized;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageKeyConverter : StringConverter
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
        /// Determines whether this instance [can convert from] the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can convert from] the specified context; otherwise, <c>false</c>.
        /// </returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return (string)value;
            }
            if (value == null)
            {
                return "";
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
            if (((destinationType == typeof(string)) && (value != null)) && ((value is string) && (((string)value).Length == 0)))
            {
                return SR.GetString("toStringNone");
            }
            if ((destinationType == typeof(string)) && (value == null))
            {
                return SR.GetString("toStringNone");
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Gets the standard values.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
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
                            objArray[count] = "";
                        }
                        else
                        {
                            objArray = new object[count];
                        }
                        StringCollection keys = list.Images.Keys;
                        for (int i = 0; i < keys.Count; i++)
                        {
                            if ((keys[i] != null) && (keys[i].Length != 0))
                            {
                                objArray[i] = keys[i];
                            }
                        }
                        return new TypeConverter.StandardValuesCollection(objArray);
                    }
                }
            }
            if (this.IncludeNoneAsStandardValue)
            {
                return new TypeConverter.StandardValuesCollection(new object[] { "" });
            }
            return new TypeConverter.StandardValuesCollection(new object[0]);
        }

        /// <summary>
        /// Gets the standard values exclusive.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Gets the standard values supported.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
		
		#endregion 
    }
}
