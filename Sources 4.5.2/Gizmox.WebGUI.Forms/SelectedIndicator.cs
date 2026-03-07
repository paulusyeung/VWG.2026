using System;
using System.Drawing;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    #region SelectedIndicatorStyleValue Class

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(SelectedIndicatorStyleValueConverter))]
    public class SelectedIndicatorStyleValue
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjBottomStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjLeftStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjLeftTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjLeftBottomStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjRightStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjRightTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjRightBottomStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedIndicatorStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftBottomStyle">The left bottom style.</param>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objLeftTopStyle">obj left top style.</param>
        /// <param name="objTopStyle">The top style.</param>
        /// <param name="objRightTopStyle">The right top style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objRightBottomStyle">The right bottom style.</param>
        /// <param name="objBottomStyle">The bottom style.</param>        
        public SelectedIndicatorStyleValue(
            StyleValue objLeftBottomStyle,
            StyleValue objLeftStyle,
            StyleValue objLeftTopStyle,
            StyleValue objTopStyle,
            StyleValue objRightTopStyle,
            StyleValue objRightStyle,
            StyleValue objRightBottomStyle,
            StyleValue objBottomStyle)
        {
            mobjLeftBottomStyle = objLeftBottomStyle;
            mobjLeftStyle = objLeftStyle;
            mobjLeftTopStyle = objLeftTopStyle;
            mobjTopStyle = objTopStyle;
            mobjRightTopStyle = objRightTopStyle;
            mobjRightStyle = objRightStyle;
            mobjRightBottomStyle = objRightBottomStyle;
            mobjBottomStyle = objBottomStyle;
        }

        /// <summary>
        /// Gets the top style.
        /// </summary>
        /// <value>The top style.</value>
        public StyleValue TopStyle
        {
            get { return mobjTopStyle; }
        }

        /// <summary>
        /// Gets the bottom style.
        /// </summary>
        /// <value>The bottom style.</value>
        public StyleValue BottomStyle
        {
            get { return mobjBottomStyle; }
        }

        /// <summary>
        /// Gets the left style.
        /// </summary>
        /// <value>The left style.</value>
        public StyleValue LeftStyle
        {
            get { return mobjLeftStyle; }
        }

        /// <summary>
        /// Gets the left top style.
        /// </summary>
        /// <value>The left top style.</value>
        public StyleValue LeftTopStyle
        {
            get { return mobjLeftTopStyle; }
        }

        /// <summary>
        /// Gets the left bottom style.
        /// </summary>
        /// <value>The left bottom style.</value>
        public StyleValue LeftBottomStyle
        {
            get { return mobjLeftBottomStyle; }
        }

        /// <summary>
        /// Gets the right style.
        /// </summary>
        /// <value>The right style.</value>
        public StyleValue RightStyle
        {
            get { return mobjRightStyle; }
        }

        /// <summary>
        /// Gets the right top style.
        /// </summary>
        /// <value>The right top style.</value>
        public StyleValue RightTopStyle
        {
            get { return mobjRightTopStyle; }
        }

        /// <summary>
        /// Gets the right bottom style.
        /// </summary>
        /// <value>The right bottom style.</value>
        public StyleValue RightBottomStyle
        {
            get { return mobjRightBottomStyle; }
        }
    }

    #endregion SelectedIndicatorStyleValue Class

    #region SelectedIndicatorStyleValueConverter Class

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectedIndicatorStyleValueConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="objDestinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return "";
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(SelectedIndicatorStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftBottomStyle", "LeftStyle", "LeftTopStyle", "TopStyle", "RightTopStyle", "RightStyle", "RightBottomStyle", "BottomStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }

    #endregion SelectedIndicatorStyleValueConverter Class

    #region SelectedIndicatorSizeValue Class

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(SelectedIndicatorSizeValueConverter))]
    public class SelectedIndicatorSizeValue
    {
        CommonSkin mobjCommonSkin;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedIndicatorSizeValue" /> class.
        /// </summary>
        /// <param name="objCommonSkin">The obj common skin.</param>
        /// <exception cref="System.ArgumentNullException">objCommonSkin</exception>
        public SelectedIndicatorSizeValue(CommonSkin objCommonSkin)
        {
            if (objCommonSkin == null)
            {
                throw new ArgumentNullException("objCommonSkin");
            }

            mobjCommonSkin = objCommonSkin;
        }

        /// <summary>
        /// Gets the top Size.
        /// </summary>
        /// <value>The top Size.</value>
        public Size TopSize
        {
            get
            {
                return mobjCommonSkin.TopSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.TopSelectedIndicatorSize = value;
            }
        }

        /// <summary>
        /// Resets the size of the top.
        /// </summary>
        private void ResetTopSize()
        {
            mobjCommonSkin.ResetTopSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the bottom Size.
        /// </summary>
        /// <value>The bottom Size.</value>
        public Size BottomSize
        {
            get
            {
                return mobjCommonSkin.BottomSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.BottomSelectedIndicatorSize = value;
            }
        }


        /// <summary>
        /// Resets the size of the bottom.
        /// </summary>
        private void ResetBottomSize()
        {
            mobjCommonSkin.ResetBottomSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the left Size.
        /// </summary>
        /// <value>The left Size.</value>
        public Size LeftSize
        {
            get
            {
                return mobjCommonSkin.LeftSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.LeftSelectedIndicatorSize = value;
            }
        }


        /// <summary>
        /// Resets the size of the left.
        /// </summary>
        private void ResetLeftSize()
        {
            mobjCommonSkin.ResetLeftSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the left top Size.
        /// </summary>
        /// <value>The left top Size.</value>
        public Size LeftTopSize
        {
            get
            {
                return mobjCommonSkin.LeftTopSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.LeftTopSelectedIndicatorSize = value;
            }
        }

        /// <summary>
        /// Resets the size of the left top.
        /// </summary>
        private void ResetLeftTopSize()
        {
            mobjCommonSkin.ResetLeftTopSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the left bottom Size.
        /// </summary>
        /// <value>The left bottom Size.</value>
        public Size LeftBottomSize
        {
            get
            {
                return mobjCommonSkin.LeftBottomSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.LeftBottomSelectedIndicatorSize = value;
            }
        }


        /// <summary>
        /// Resets the size of the left bottom.
        /// </summary>
        private void ResetLeftBottomSize()
        {
            mobjCommonSkin.ResetLeftBottomSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the right Size.
        /// </summary>
        /// <value>The right Size.</value>
        public Size RightSize
        {
            get
            {
                return mobjCommonSkin.RightSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.RightSelectedIndicatorSize = value;
            }
        }

        /// <summary>
        /// Resets the size of the right.
        /// </summary>
        private void ResetRightSize()
        {
            mobjCommonSkin.ResetRightSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the right top Size.
        /// </summary>
        /// <value>The right top Size.</value>
        public Size RightTopSize
        {
            get
            {
                return mobjCommonSkin.RightTopSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.RightTopSelectedIndicatorSize = value;
            }
        }

        /// <summary>
        /// Resets the size of the right top.
        /// </summary>
        private void ResetRightTopSize()
        {
            mobjCommonSkin.ResetRightTopSelectedIndicatorSize();
        }

        /// <summary>
        /// Gets the right bottom Size.
        /// </summary>
        /// <value>The right bottom Size.</value>
        public Size RightBottomSize
        {
            get
            {
                return mobjCommonSkin.RightBottomSelectedIndicatorSize;
            }
            set
            {
                mobjCommonSkin.RightBottomSelectedIndicatorSize = value;
            }
        }

        /// <summary>
        /// Resets the size of the right bottom.
        /// </summary>
        private void ResetRightBottomSize()
        {
            mobjCommonSkin.ResetRightBottomSelectedIndicatorSize();
        }
    }

    #endregion SelectedIndicatorSizeValue Class

    #region SelectedIndicatorSizeValueConverter Class

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectedIndicatorSizeValueConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="objDestinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return "";
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(SelectedIndicatorSizeValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftBottomSize", "LeftSize", "LeftTopSize", "TopSize", "RightTopSize", "RightSize", "RightBottomSize", "BottomSize" };
            return objCollection.Sort(arrTtextArray);
        }
    }

    #endregion SelectedIndicatorSizeValueConverter Class
}
