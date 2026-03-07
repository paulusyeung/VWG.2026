using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections;
using System.Globalization;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.VisualEffects;

namespace Gizmox.WebGUI.Forms.Skins
{
    #region Enums

    /// <summary>
    /// 
    /// </summary>
    public enum VerticalAlignment
    {
        /// <summary>
        /// 
        /// </summary>
        Top,
        /// <summary>
        /// 
        /// </summary>
        Center,
        /// <summary>
        /// 
        /// </summary>
        Bottom
    }

    /// <summary>
    /// 
    /// </summary>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// 
        /// </summary>
        Left,
        /// <summary>
        /// 
        /// </summary>
        Center,
        /// <summary>
        /// 
        /// </summary>
        Right
    }

    #endregion

    #region BorderValue class

    /// <summary>
    /// Provides a way to return a composed skin value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    public class BorderValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private BorderStyle menmStyle = BorderStyle.None;

        /// <summary>
        /// 
        /// </summary>
        private BorderWidth mobjBorderWidth = BorderWidth.Empty;

        /// <summary>
        /// 
        /// </summary>
        private BorderColor mobjBorderColor = BorderColor.Empty;

        /// <summary>
        /// 
        /// </summary>
        private CornerRadius mobjCorner = CornerRadius.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderValue"/> class.
        /// </summary>
        public BorderValue()
        {
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public BorderStyle Style
        {
            get { return menmStyle; }
            set { menmStyle = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public BorderWidth Width
        {
            get { return mobjBorderWidth; }
            set { mobjBorderWidth = value; }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public BorderColor Color
        {
            get { return mobjBorderColor; }
            set { mobjBorderColor = value; }
        }

        /// <summary>
        /// Gets or sets the corner values.
        /// </summary>
        /// <value>The corner values.</value>
        public CornerRadius Corner
        {
            get { return mobjCorner; }
            set { mobjCorner = value; }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            // Get the important value
            string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

            if (menmStyle == BorderStyle.None)
            {
                return string.Format("border:none{0};", strImportantValue);
            }
            else
            {
                StringBuilder objStyle = new StringBuilder();
                string strTop = string.Format("border-top:{0}px {1} {2}{3};", mobjBorderWidth.Top, GetBorderName(menmStyle), GetBorderColor(mobjBorderColor.Top), strImportantValue);
                string strLeft = string.Format("border-left:{0}px {1} {2}{3};", mobjBorderWidth.Left, GetBorderName(menmStyle), GetBorderColor(mobjBorderColor.Left), strImportantValue);
                string strRight = string.Format("border-right:{0}px {1} {2}{3};", mobjBorderWidth.Right, GetBorderName(menmStyle), GetBorderColor(mobjBorderColor.Right), strImportantValue);
                string strBottom = string.Format("border-bottom:{0}px {1} {2}{3};", mobjBorderWidth.Bottom, GetBorderName(menmStyle), GetBorderColor(mobjBorderColor.Bottom), strImportantValue);

                objStyle.Append(string.Format("{0}{1}{2}{3}", strTop, strLeft, strRight, strBottom));

                return objStyle.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the border.
        /// </summary>
        /// <param name="enmStyle">The border style.</param>
        /// <returns></returns>
        internal static string GetBorderName(BorderStyle enmStyle)
        {
            switch (enmStyle)
            {
                case BorderStyle.FixedSingle:
                    return "solid";
                case BorderStyle.Dotted:
                    return "dotted";
                case BorderStyle.Dashed:
                    return "dashed";
                case BorderStyle.Fixed3D:
                    return "solid";
                case BorderStyle.Outset:
                    return "outset";
                case BorderStyle.Inset:
                    return "inset";
            }
            return "fixed";
        }

        /// <summary>
        /// Gets the color of the border.
        /// </summary>
        /// <param name="objColor">The border color.</param>
        /// <returns></returns>
        internal static object GetBorderColor(Color objColor)
        {
            return CommonUtils.GetHtmlColor(objColor);
        }
    }
    #endregion

    #region PaddingValue class

    /// <summary>
    /// hold sthe value that represents padding space between the body of the UI element and its edge.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [TypeConverter(typeof(PaddingValueConverter))]
    [Serializable()]
    public class PaddingValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private Padding mobjValue;

        /// <summary>
        /// The empty padding reference
        /// </summary>
        private static PaddingValue mobjEmpty = new PaddingValue(Padding.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="PaddingValue"/> class.
        /// </summary>
        /// <param name="objValue">The padding value.</param>
        public PaddingValue(Padding objValue)
        {
            mobjValue = objValue;
        }

        /// <summary>
        /// Gets or sets the padding value for the bottom edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the bottom edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Bottom
        {
            get
            {
                return mobjValue.Bottom;
            }
            set
            {
                mobjValue.Bottom = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding value for all the edges.
        /// </summary>
        /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                return mobjValue.All;
            }
            set
            {
                mobjValue.All = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding value for the left edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the left edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Left
        {
            get
            {
                return mobjValue.Left;
            }
            set
            {
                mobjValue.Left = value;
            }
        }
        /// <summary>
        /// Gets or sets the padding value for the right edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the right edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Right
        {
            get
            {
                return mobjValue.Right;
            }
            set
            {
                mobjValue.Right = value;
            }
        }
        /// <summary>
        /// Gets or sets the padding value for the top edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the top edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Top
        {
            get
            {
                return mobjValue.Top;
            }
            set
            {

                mobjValue.Top = value;

            }
        }
        /// <summary>
        /// Gets the combined padding for the right and left edges.
        /// </summary>
        ///	<returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Left"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Right"></see> padding values.</returns>
        [Browsable(false)]
        public int Horizontal
        {
            get
            {
                return mobjValue.Horizontal;
            }
        }
        /// <summary>
        /// Gets the combined padding for the top and bottom edges.
        /// </summary>
        ///	<returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Top"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Bottom"></see> padding values.</returns>
        [Browsable(false)]
        public int Vertical
        {
            get
            {
                return mobjValue.Vertical;
            }
        }
        /// <summary>
        /// Gets the padding information in the form of a <see cref="T:System.Drawing.Size"></see>.
        /// </summary>
        ///	<returns>A <see cref="T:System.Drawing.Size"></see> containing the padding information.</returns>
        [Browsable(false)]
        public Size Size
        {
            get
            {
                return mobjValue.Size;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            // Get the important value
            string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

            if (mobjValue.IsAll)
            {
                return string.Format("{0}:{1}px{2}", this.GetWebStyleName(), mobjValue.All, strImportantValue);
            }
            else
            {
                return string.Format("{0}:{1}px {2}px {3}px {4}px{5}", this.GetWebStyleName(), mobjValue.Top, mobjValue.Right, mobjValue.Bottom, mobjValue.Left, strImportantValue);
            }
        }

        /// <summary>
        /// Gets the name of the web style.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetWebStyleName()
        {
            return "padding";
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return mobjValue.ToString();
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/> to <see cref="Gizmox.WebGUI.Forms.Padding"/>.
        /// </summary>
        /// <param name="objPaddingValue">The padding value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Padding(PaddingValue objPaddingValue)
        {
            if (objPaddingValue == null)
            {
                return Padding.Empty;
            }
            else
            {
                return objPaddingValue.Value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Padding"/> to <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/>.
        /// </summary>
        /// <param name="objPadding">The padding.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PaddingValue(Padding objPadding)
        {
            return new PaddingValue(objPadding);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="objPaddingValue">The padding value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(PaddingValue objPaddingValue)
        {
            if (objPaddingValue.Value.IsAll)
            {
                return objPaddingValue.All.ToString();
            }
            else
            {
                return string.Format("{0},{1},{2},{3}", objPaddingValue.Left, objPaddingValue.Top, objPaddingValue.Right, objPaddingValue.Bottom);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/>.
        /// </summary>
        /// <param name="strPadding">The padding string.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PaddingValue(string strPadding)
        {
            Padding objPadding = Padding.Empty;

            if (!string.IsNullOrEmpty(strPadding))
            {
                string[] arrPadding = strPadding.Split(',');
                if (arrPadding.Length == 4)
                {
                    objPadding = new Padding(int.Parse(arrPadding[0]), int.Parse(arrPadding[1]), int.Parse(arrPadding[2]), int.Parse(arrPadding[3]));
                }
                else if (arrPadding.Length == 1)
                {
                    objPadding = new Padding(int.Parse(arrPadding[0]));
                }
            }

            return new PaddingValue(objPadding);
        }

        /// <summary>
        /// Gets an empty padding value.
        /// </summary>
        /// <value>The empty padding value.</value>
        public static PaddingValue Empty
        {
            get
            {
                return mobjEmpty;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [Browsable(false)]
        public Padding Value
        {
            get { return mobjValue; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MarginValueConverter : TypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MarginValueConverter"></see> class. 
        /// </summary>
        public MarginValueConverter()
        {
        }


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
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objSourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string strValue = (string)objValue;

                if (!string.IsNullOrEmpty(strValue))
                {
                    string[] arrValues = strValue.Split(',');

                    if (arrValues.Length == 1)
                    {
                        return new MarginValue(new Padding(int.Parse(arrValues[0])));
                    }

                    if (arrValues.Length == 4)
                    {
                        return new MarginValue(new Padding(int.Parse(arrValues[0]), int.Parse(arrValues[1]), int.Parse(arrValues[2]), int.Parse(arrValues[3])));
                    }
                }
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
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
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="objDestinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                MarginValue objMarginValue = objValue as MarginValue;
                if (objMarginValue != null)
                {
                    if (objMarginValue.All != -1)
                    {
                        return objMarginValue.All.ToString();
                    }
                    else
                    {
                        return string.Format("{0}, {1}, {2}, {3}", objMarginValue.Left, objMarginValue.Top, objMarginValue.Right, objMarginValue.Bottom);
                    }
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }
        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {


            PaddingValue padding1 = (PaddingValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            Padding objNewPedding;
            int num1 = (int)objPropertyValues["All"];
            if (padding1.All != num1)
            {
                objNewPedding = new Padding(num1);
            }
            else
            {
                objNewPedding = new Padding((int)objPropertyValues["Left"], (int)objPropertyValues["Top"], (int)objPropertyValues["Right"], (int)objPropertyValues["Bottom"]);
            }
            return Activator.CreateInstance(padding1.GetType(), objNewPedding);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }


        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(PaddingValue), arrAttributes);
            string[] arrTextArray = new string[] { "All", "Left", "Top", "Right", "Bottom" };
            return objCollection.Sort(arrTextArray);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }
    }


    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class PaddingValueConverter : TypeConverter
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
        /// </summary>
        public PaddingValueConverter()
        {
        }


        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string strValue = (string)objValue;

                if (!string.IsNullOrEmpty(strValue))
                {
                    string[] arrValues = strValue.Split(',');

                    if (arrValues.Length == 1)
                    {
                        return new PaddingValue(new Padding(int.Parse(arrValues[0])));
                    }

                    if (arrValues.Length == 4)
                    {
                        return new PaddingValue(new Padding(int.Parse(arrValues[0]), int.Parse(arrValues[1]), int.Parse(arrValues[2]), int.Parse(arrValues[3])));
                    }
                }
            }
            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                PaddingValue objPaddingValue = objValue as PaddingValue;
                if (objPaddingValue != null)
                {
                    if (objPaddingValue.All != -1)
                    {
                        return objPaddingValue.All.ToString();
                    }
                    else
                    {
                        return string.Format("{0}, {1}, {2}, {3}", objPaddingValue.Left, objPaddingValue.Top, objPaddingValue.Right, objPaddingValue.Bottom);
                    }
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }
        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {


            PaddingValue padding1 = (PaddingValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            Padding objNewPedding;
            int num1 = (int)objPropertyValues["All"];
            if (padding1.All != num1)
            {
                objNewPedding = new Padding(num1);
            }
            else
            {
                objNewPedding = new Padding((int)objPropertyValues["Left"], (int)objPropertyValues["Top"], (int)objPropertyValues["Right"], (int)objPropertyValues["Bottom"]);
            }
            return Activator.CreateInstance(padding1.GetType(), objNewPedding);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }


        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(PaddingValue), arrAttributes);
            string[] arrTtextArray = new string[] { "All", "Left", "Top", "Right", "Bottom" };
            return objCollection.Sort(arrTtextArray);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

    }

    #endregion

    #region MarginValue class

    /// <summary>
    /// Holds the value for the space between controls
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [TypeConverter(typeof(MarginValueConverter))]
    [Serializable()]
    public class MarginValue : PaddingValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarginValue"/> class.
        /// </summary>
        /// <param name="objValue">The padding value.</param>
        public MarginValue(Padding objValue)
            : base(objValue)
        {

        }

        /// <summary>
        /// Gets the name of the web style.
        /// </summary>
        /// <returns></returns>
        protected override string GetWebStyleName()
        {
            return "margin";
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.MarginValue"/> to <see cref="Gizmox.WebGUI.Forms.Padding"/>.
        /// </summary>
        /// <param name="objMarginValue">The margin value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Padding(MarginValue objMarginValue)
        {
            if (objMarginValue == null)
            {
                return Padding.Empty;
            }
            else
            {
                return objMarginValue.Value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Padding"/> to <see cref="Gizmox.WebGUI.Forms.Skins.MarginValue"/>.
        /// </summary>
        /// <param name="objPadding">The padding.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MarginValue(Padding objPadding)
        {
            return new MarginValue(objPadding);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="objMarginValue">The margin value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(MarginValue objMarginValue)
        {
            if (objMarginValue.Value.IsAll)
            {
                return objMarginValue.All.ToString();
            }
            else
            {
                return string.Format("{0},{1},{2},{3}", objMarginValue.Left, objMarginValue.Top, objMarginValue.Right, objMarginValue.Bottom);
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Gizmox.WebGUI.Forms.Skins.PaddingValue"/>.
        /// </summary>
        /// <param name="strPadding">The padding string.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MarginValue(string strPadding)
        {
            Padding objPadding = Padding.Empty;

            if (!string.IsNullOrEmpty(strPadding))
            {
                string[] arrPadding = strPadding.Split(',');
                if (arrPadding.Length == 4)
                {
                    objPadding = new Padding(int.Parse(arrPadding[0]), int.Parse(arrPadding[1]), int.Parse(arrPadding[2]), int.Parse(arrPadding[3]));
                }
                else if (arrPadding.Length == 1)
                {
                    objPadding = new Padding(int.Parse(arrPadding[0]));
                }
            }

            return new MarginValue(objPadding);
        }

        /// <summary>
        /// The empty padding reference
        /// </summary>
        private static MarginValue mobjEmpty = new MarginValue(Padding.Empty);

        /// <summary>
        /// Gets an empty padding value.
        /// </summary>
        /// <value>The empty padding value.</value>
        public static MarginValue Empty
        {
            get
            {
                return mobjEmpty;
            }
        }
    }

    #endregion

    #region BackgroundValue Class

    /// <summary>
    /// Holds the Background Value of the control
    /// </summary>
    [Serializable()]
    public class BackgroundValue : SkinValue
    {
        /// <summary>
        /// The background color
        /// </summary>
        private Color mobjBackColor = Color.Empty;

        /// <summary>
        /// The background image
        /// </summary>
        private ImageResourceReference mobjBackgroundImage = ImageResourceReference.Empty;

        /// <summary>
        /// The background image repeating definition
        /// </summary>
        private BackgroundImageRepeat menmBackgroundImageRepeat = BackgroundImageRepeat.Repeat;

        /// <summary>
        /// The background image positioning definition
        /// </summary>
        private BackgroundImagePosition menmBackgroundImagePosition = BackgroundImagePosition.MiddleCenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundValue"/> class.
        /// </summary>
        public BackgroundValue()
        {

        }

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get { return mobjBackColor; }
            set { mobjBackColor = value; }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        public ImageResourceReference BackgroundImage
        {
            get { return mobjBackgroundImage; }
            set { mobjBackgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>The background image repeat.</value>
        public BackgroundImageRepeat BackgroundImageRepeat
        {
            get { return menmBackgroundImageRepeat; }
            set { menmBackgroundImageRepeat = value; }
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        public BackgroundImagePosition BackgroundImagePosition
        {
            get { return menmBackgroundImagePosition; }
            set { menmBackgroundImagePosition = value; }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            // Get the important value
            string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);


            StringBuilder objStyle = new StringBuilder();

            // If there is a background color defined
            if (mobjBackColor != Color.Empty)
            {
                string strBackgroundColor = string.Format("background-color:{0}{1};", CommonUtils.GetHtmlColor(mobjBackColor), strImportantValue);

                objStyle.Append(strBackgroundColor);
            }

            // If there is a backgound image
            if (mobjBackgroundImage != ImageResourceReference.Empty)
            {
                //Add backgound image url
                string strBackImage = string.Format("background-image:url({0}){1};", mobjBackgroundImage.GetValue(objContext, objValueDefinition), strImportantValue);

                // Add background position 
                string strBackgroundPosition = string.Format("background-position:{0}{1};", GetCSSValue(menmBackgroundImagePosition), strImportantValue);

                // Add backgroung repeat definition 
                string strBackgroundRepeat = string.Format("background-repeat:{0}{1};", GetCSSValue(menmBackgroundImageRepeat), strImportantValue);

                objStyle.Append(string.Format("{0}{1}{2}", strBackImage, strBackgroundPosition, strBackgroundRepeat));
            }
            return objStyle.ToString();
        }

        /// <summary>
        /// Gets the CSS value.
        /// </summary>
        /// <param name="enmBackgroundImageRepeat">The background image repeat definition.</param>
        /// <returns></returns>
        internal static string GetCSSValue(BackgroundImageRepeat enmBackgroundImageRepeat)
        {
            switch (enmBackgroundImageRepeat)
            {
                case BackgroundImageRepeat.Repeat:
                    return "repeat";
                case BackgroundImageRepeat.RepeatX:
                    return "repeat-x";
                case BackgroundImageRepeat.RepeatY:
                    return "repeat-y";
                case BackgroundImageRepeat.None:
                    return "no-repeat";
            }

            return "repeat";
        }

        /// <summary>
        /// Gets the CSS value.
        /// </summary>
        /// <param name="enmBackgroundImagePosition">The background image position.</param>
        /// <returns></returns>
        internal static string GetCSSValue(BackgroundImagePosition enmBackgroundImagePosition)
        {
            switch (enmBackgroundImagePosition)
            {
                case BackgroundImagePosition.BottomCenter:
                    return "bottom center";
                case BackgroundImagePosition.BottomLeft:
                    return "bottom left";
                case BackgroundImagePosition.BottomRight:
                    return "bottom right";
                case BackgroundImagePosition.MiddleLeft:
                    return "center left";
                case BackgroundImagePosition.MiddleCenter:
                    return "center center";
                case BackgroundImagePosition.MiddleRight:
                    return "center right";
                case BackgroundImagePosition.TopLeft:
                    return "top left";
                case BackgroundImagePosition.TopCenter:
                    return "top center";
                case BackgroundImagePosition.TopRight:
                    return "top right";
            }

            return "center center";
        }
    }

    #endregion

    #region ForegroundValue Class

    /// <summary>
    /// Holds the Foreground Value of the control.
    /// </summary>
    [Serializable()]
    public class ForegroundValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private Color mobjColor = Color.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForegroundValue"/> class.
        /// </summary>
        public ForegroundValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForegroundValue"/> class.
        /// </summary>
        public ForegroundValue(Color objColor)
        {
            this.ForeColor = objColor;
        }
        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return mobjColor; }
            set { mobjColor = value; }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            if (mobjColor != Color.Empty)
            {
                // Get the important value
                string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

                return string.Format("color:{0}{1}", CommonUtils.GetHtmlColor(mobjColor), strImportantValue);
            }

            return string.Empty;
        }
    }

    #endregion

    #region StyleValue Class

    /// <summary>
    /// Provides generic control styling mechanism
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(StyleValueConverter))]
    public class StyleValue : SkinMultiValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
            : base(objPropertyOwner, strPropertyPrefix)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, bool blnIsAmbientValues)
            : base(objPropertyOwner, strPropertyPrefix, null, blnIsAmbientValues)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, StyleValue objDefaults)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
        public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, StyleValue objDefaults, bool blnLocalizeBaseStyleValues)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseStyleValues)
        {
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Fonts"), SRDescription("ControlFontDescr")]
        public Font Font
        {
            get
            {
                return this.GetValue<Font>("Font", this.DefaultFont);
            }
            set
            {
                this.SetValue("Font", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has font.
        /// </summary>
        /// <value><c>true</c> if this instance has font; otherwise, <c>false</c>.</value>
        protected bool HasFont
        {
            get
            {
                return this.HasValue("Font");
            }
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        private void ResetFont()
        {
            Reset("Font");
        }

        /// <summary>
        /// Gets or sets the default font.
        /// </summary>
        /// <value></value>
        protected Font DefaultFont
        {
            get
            {
                // If skin multi value has a default inheritor
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).Font;
                }
                else
                {
                    return ((CommonSkin)this.Skin).Font;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [SRDescription("ControlBackgroundImageDescr")]
        [SRCategory("CatAppearance")]
        public ImageResourceReference BackgroundImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundImage", this.DefaultBackgroundImage);
            }
            set
            {
                this.SetValue("BackgroundImage", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImage
        {
            get
            {
                return this.BackgroundImage != ImageResourceReference.Empty;
            }
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        private void ResetBackgroundImage()
        {
            Reset("BackgroundImage");
        }

        /// <summary>
        /// Gets or sets the default background image.
        /// </summary>
        /// <value></value>
        protected virtual ImageResourceReference DefaultBackgroundImage
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<ImageResourceReference>("BackgroundImage", ImageResourceReference.Empty);
                }
                else
                {
                    ControlSkin objControlSkin = this.Skin as ControlSkin;
                    if (objControlSkin != null)
                    {
                        return objControlSkin.BackgroundImage;
                    }
                }
                return ImageResourceReference.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>The background image repeat.</value>
        [SRDescription("Sets if or how a background image will be repeated.")]
        [SRCategory("CatAppearance")]
        public BackgroundImageRepeat BackgroundImageRepeat
        {
            get
            {
                return this.GetValue<BackgroundImageRepeat>("BackgroundImageRepeat", this.DefaultBackgroundImageRepeat);
            }
            set
            {
                this.SetValue("BackgroundImageRepeat", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image repeat.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image repeat; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImageRepeat
        {
            get
            {
                return this.HasValue("BackgroundImageRepeat");
            }
        }

        /// <summary>
        /// Resets the BackgroundImageRepeat.
        /// </summary>
        private void ResetBackgroundImageRepeat()
        {
            Reset("BackgroundImageRepeat");
        }

        /// <summary>
        /// Gets or sets the default background image repeat.
        /// </summary>
        /// <value></value>
        protected virtual BackgroundImageRepeat DefaultBackgroundImageRepeat
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).BackgroundImageRepeat;
                }
                else
                {
                    return BackgroundImageRepeat.Repeat;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        [SRDescription("Sets the starting position of a background image.")]
        [SRCategory("CatAppearance")]
        public BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return this.GetValue<BackgroundImagePosition>("BackgroundImagePosition", this.DefaultBackgroundImagePosition);
            }
            set
            {
                this.SetValue("BackgroundImagePosition", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image position.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image position; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImagePosition
        {
            get
            {
                return this.HasValue("BackgroundImagePosition");
            }
        }

        /// <summary>
        /// Gets or sets the default background image position.
        /// </summary>
        /// <value></value>
        protected virtual BackgroundImagePosition DefaultBackgroundImagePosition
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).BackgroundImagePosition;
                }
                else
                {
                    return BackgroundImagePosition.MiddleCenter;
                }
            }
        }

        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
        /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Colors"), SRDescription("ControlForeColorDescr")]
        public Color ForeColor
        {
            get
            {
                return this.GetValue<Color>("ForeColor", this.DefaultForeColor);
            }
            set
            {
                this.SetValue("ForeColor", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has fore color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has fore color; otherwise, <c>false</c>.
        /// </value>
        protected bool HasForeColor
        {
            get
            {
                return this.HasValue("ForeColor");
            }
        }

        /// <summary>
        /// Resets the ForeColor.
        /// </summary>
        private void ResetForeColor()
        {
            Reset("ForeColor");
        }

        /// <summary>
        /// Gets or sets the default fore color.
        /// </summary>
        /// <value></value>
        protected virtual Color DefaultForeColor
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).ForeColor;
                }
                else
                {
                    return ((CommonSkin)this.Skin).ForeColor;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("ControlBackColorDescr")]
        public virtual Color BackColor
        {
            get
            {
                return this.GetValue<Color>("BackColor", this.DefaultBackColor);
            }
            set
            {
                this.SetValue("BackColor", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has back color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has back color; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackColor
        {
            get
            {
                return this.HasValue("BackColor");
            }
        }

        /// <summary>
        /// Resets the BackColor.
        /// </summary>
        private void ResetBackColor()
        {
            Reset("BackColor");
        }

        /// <summary>
        /// Gets or sets the default back color.
        /// </summary>
        /// <value></value>
        protected virtual Color DefaultBackColor
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).BackColor;
                }
                else
                {
                    ControlSkin objControlSkin = this.Skin as ControlSkin;
                    if (objControlSkin !=null)
                    {
                        return objControlSkin.BackColor;
                    }
                }
                return Color.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        /// <value>The padding.</value>
        [SRDescription("ControlPaddingDescr"), Category("Layout")]
        public PaddingValue Padding
        {
            get
            {
                return this.GetValue<PaddingValue>("Padding", this.DefaultPadding);
            }
            set
            {

                this.SetValue("Padding", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has padding.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has padding; otherwise, <c>false</c>.
        /// </value>
        protected bool HasPadding
        {
            get
            {
                return this.HasValue("Padding");
            }
        }

        /// <summary>
        /// Resets the Padding.
        /// </summary>
        private void ResetPadding()
        {
            Reset("Padding");
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        [SRDescription("ControlOpacityDescr"), Category("CatAppearance")]
        public OpacityValue Opacity
        {
            get
            {
                return this.GetValue<OpacityValue>("Opacity", this.DefaultOpacity);
            }
            set
            {

                this.SetValue("Opacity", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has opacity.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has opacity; otherwise, <c>false</c>.
        /// </value>
        protected bool HasOpacity
        {
            get
            {
                return this.HasValue("Opacity");
            }
        }

        /// <summary>
        /// Resets the opacity.
        /// </summary>
        private void ResetOpacity()
        {
            Reset("Opacity");
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reset()
        {
            this.ResetBackColor();
            this.ResetBackgroundImage();
            this.ResetBackgroundImageRepeat();
            this.ResetBorderColor();
            this.ResetBorderStyle();
            this.ResetBorderWidth();
            this.ResetFont();
            this.ResetForeColor();
            this.ResetMargin();
            this.ResetPadding();
            this.ResetOpacity();

        }

        /// <summary>
        /// Gets or sets the default padding.
        /// </summary>
        /// <value></value>
        protected virtual PaddingValue DefaultPadding
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<PaddingValue>("Padding", PaddingValue.Empty);
                }
                else
                {
                    return "0";
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance has padding.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has padding; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBorderRadius
        {
            get
            {
                return this.HasValue("BorderRadius");
            }
        }

        /// <summary>
        /// Resets the Padding.
        /// </summary>
        private void ResetBorderRadius()
        {
            Reset("BorderRadius");
        }

        /// <summary>
        /// Gets the default opacity.
        /// </summary>
        /// <value>The default opacity.</value>
        protected virtual OpacityValue DefaultOpacity
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<OpacityValue>("Opacity", "100");
                }
                else
                {
                    return OpacityValue.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <value>The space between controls.</value>
        [Category("Layout"), SRDescription("ControlMarginDescr")]
        public MarginValue Margin
        {
            get
            {
                return this.GetValue<MarginValue>("Margin", this.DefaultMargin);
            }
            set
            {
                this.SetValue("Margin", value);
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance has margin.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has margin; otherwise, <c>false</c>.
        /// </value>
        protected bool HasMargin
        {
            get
            {
                return this.HasValue("Margin");
            }
        }

        /// <summary>
        /// Resets the Margin.
        /// </summary>
        private void ResetMargin()
        {
            Reset("Margin");
        }

        /// <summary>
        /// Gets or sets the default margin.
        /// </summary>
        /// <value></value>
        protected virtual MarginValue DefaultMargin
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<MarginValue>("Margin", MarginValue.Empty);
                }
                else
                {
                    return MarginValue.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value></value>
        [Category("Sizes"), SRDescription("ControlBorderWidthDescr")]
        public BorderWidth BorderWidth
        {
            get
            {
                return this.GetValue<BorderWidth>("BorderWidth", this.DefaultBorderWidth);
            }
            set
            {
                this.SetValue("BorderWidth", value);
            }
        }

        /// <summary>
        /// Resets the BorderColor.
        /// </summary>
        private void ResetBorderWidth()
        {
            Reset("BorderWidth");
        }

        /// <summary>
        /// Gets a value indicating whether this instance has border width.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has border width; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBorderWidth
        {
            get
            {
                return this.HasValue("BorderWidth");
            }
        }

        /// <summary>
        /// Gets or sets the default border width.
        /// </summary>
        /// <value></value>
        protected virtual BorderWidth DefaultBorderWidth
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<BorderWidth>("BorderWidth", BorderWidth.Empty);
                }
                else
                {
                    ControlSkin objControlSkin = this.Skin as ControlSkin;
                    if (objControlSkin != null)
                    {
                        return objControlSkin.BorderWidth;
                    }
                }
                return new BorderWidth(1);
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("ControlBorderColorDescr")]
        public BorderColor BorderColor
        {
            get
            {
                return this.GetValue<BorderColor>("BorderColor", this.DefaultBorderColor);
            }
            set
            {
                this.SetValue("BorderColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the visual effect.
        /// </summary>
        /// <value>
        /// The visual effect.
        /// </value>
        [Category("Styles"), Description("Provide definitions for visual effects.")]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public VisualEffectValue VisualEffect
        {
            get
            {
                return this.GetValue<VisualEffectValue>("VisualEffect", null);
            }
            set
            {
                this.SetValue("VisualEffect", value);
            }
        }

        /// <summary>
        /// Resets the visual effect.
        /// </summary>
        private void ResetVisualEffect()
        {
            Reset("VisualEffect");
        }

        /// <summary>
        /// Resets the BorderColor.
        /// </summary>
        private void ResetBorderColor()
        {
            Reset("BorderColor");
        }

        /// <summary>
        /// Gets a value indicating whether this instance has border color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has border color; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBorderColor
        {
            get
            {
                return this.HasValue("BorderColor");
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has visual effect.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has visual effect; otherwise, <c>false</c>.
        /// </value>
        protected bool HasVisualEffect
        {
            get
            {
                return this.HasValue("VisualEffect");
            }
        }

        /// <summary>
        /// Gets or sets the default border width.
        /// </summary>
        /// <value></value>
        protected virtual BorderColor DefaultBorderColor
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<BorderColor>("BorderColor", new BorderColor(Color.FromArgb(111, 157, 217)));
                }
                else
                {
                    ControlSkin objControlSkin = this.Skin as ControlSkin;
                    if (objControlSkin != null)
                    {
                        return objControlSkin.BorderColor;
                    }
                }
                return BorderColor.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [Category("Styles"), SRDescription("ControlBorderStyleDescr")]
        public BorderStyle BorderStyle
        {
            get
            {
                return this.GetValue<BorderStyle>("BorderStyle", this.DefaultBorderStyle);
            }
            set
            {
                this.SetValue("BorderStyle", value);
            }
        }

        /// <summary>
        /// Resets the BorderColor.
        /// </summary>
        private void ResetBorderStyle()
        {
            Reset("BorderStyle");
        }

        /// <summary>
        /// Gets a value indicating whether this instance has border style.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has border style; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBorderStyle
        {
            get
            {
                return this.HasValue("BorderStyle");
            }
        }

        /// <summary>
        /// Gets or sets the default border style.
        /// </summary>
        /// <value></value>
        protected virtual BorderStyle DefaultBorderStyle
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((StyleValue)this.Defaults).GetValue<BorderStyle>("BorderStyle", BorderStyle.FixedSingle);
                }
                else
                {
                    ControlSkin objControlSkin = this.Skin as ControlSkin;
                    if (objControlSkin != null)
                    {
                        return objControlSkin.BorderStyle;
                    }
                }
                return BorderStyle.None;
            }
        }

        /// <summary>
        /// Gets the border value which can be translated.
        /// </summary>
        /// <value>The border.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderValue Border
        {
            get
            {
                BorderValue objBorderValue = new BorderValue();
                objBorderValue.Color = this.BorderColor;
                objBorderValue.Style = this.BorderStyle;
                objBorderValue.Width = this.BorderWidth;
                return objBorderValue;
            }
        }

        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BackgroundValue Background
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                if (this.HasBackColor)
                {
                    objBackgroundValue.BackColor = this.BackColor;
                }

                if (this.HasBackgroundImage)
                {
                    objBackgroundValue.BackgroundImage = this.BackgroundImage;
                    objBackgroundValue.BackgroundImagePosition = this.BackgroundImagePosition;
                    objBackgroundValue.BackgroundImageRepeat = this.BackgroundImageRepeat;
                }

                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets the foreground.
        /// </summary>
        /// <value>The foreground.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ForegroundValue Foreground
        {
            get
            {
                ForegroundValue objForegroundValue = new ForegroundValue();
                objForegroundValue.ForeColor = this.ForeColor;
                return objForegroundValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackground
        {
            get
            {
                return this.HasBackColor || this.HasBackgroundImage || this.HasBackgroundImagePosition || this.HasBackgroundImageRepeat;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has border.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has border; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBorder
        {
            get
            {
                return this.HasBorderColor || this.HasBorderStyle || this.HasBorderWidth;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            StringBuilder objBuffer = new StringBuilder();
            if (this.HasFont)
            {
            objBuffer.AppendLine(string.Format("{0};", FormatValue(SkinTranslator.GetFont(objContext, this.Font, objValueDefinition))));
            }

            if (this.HasBackground)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Background.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasForeColor)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Foreground.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasBorder)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Border.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasMargin)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Margin.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasPadding)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Padding.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasOpacity)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Opacity.GetValue(objContext, objValueDefinition))));
            }

            if (this.HasVisualEffect)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.VisualEffect.GetValue(objContext, objValueDefinition))));
            }

            return FormatValue(objBuffer.ToString());
        }

        private string FormatValue(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return string.Empty;
            }
            else
            {
                return strValue.TrimEnd(';', '\r', '\n');
            }
        }
    }

    /// <summary>
    /// Provides a type convertor for the control style class
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StyleValueConverter : SkinMultiValueConverter
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
    }

    #endregion

    #region FramePartStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    public class FramePartStyleValue : SkinMultiValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FramePartStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        public FramePartStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
            : base(objPropertyOwner, strPropertyPrefix)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FramePartStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        public FramePartStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, FramePartStyleValue objDefaults)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FramePartStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
        public FramePartStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, FramePartStyleValue objDefaults, bool blnLocalizeBaseStyleValues)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseStyleValues)
        {
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [SRDescription("ControlBackgroundImageDescr")]
        [SRCategory("CatAppearance")]
        public ImageResourceReference BackgroundImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundImage", this.DefaultBackgroundImage);
            }
            set
            {
                this.SetValue("BackgroundImage", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImage
        {
            get
            {
                return this.BackgroundImage != ImageResourceReference.Empty;
            }
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        private void ResetBackgroundImage()
        {
            Reset("BackgroundImage");
        }

        /// <summary>
        /// Gets or sets the default background image.
        /// </summary>
        /// <value></value>
        protected virtual ImageResourceReference DefaultBackgroundImage
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((FramePartStyleValue)this.Defaults).GetValue<ImageResourceReference>("BackgroundImage", ImageResourceReference.Empty);
                }
                else
                {
                    return ImageResourceReference.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            if (this.HasBackgroundImage)
            {
                // Get the important value
                string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

                return string.Format("background-image:url({0}){1};", this.BackgroundImage.GetValue(objContext, objValueDefinition), strImportantValue);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    #endregion

    #region FrameOverlayStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    public class FrameOverlayStyleValue : FramePartStyleValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameOverlayStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        public FrameOverlayStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
            : base(objPropertyOwner, strPropertyPrefix)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameOverlayStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        public FrameOverlayStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, FrameOverlayStyleValue objDefaults)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameOverlayStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
        public FrameOverlayStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, FrameOverlayStyleValue objDefaults, bool blnLocalizeBaseStyleValues)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseStyleValues)
        {
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        [SRDescription("Sets the starting position of a background image.")]
        [SRCategory("CatAppearance")]
        public BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return this.GetValue<BackgroundImagePosition>("BackgroundImagePosition", this.DefaultBackgroundImagePosition);
            }
            set
            {
                this.SetValue("BackgroundImagePosition", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image position.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image position; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImagePosition
        {
            get
            {
                return this.HasValue("BackgroundImagePosition");
            }
        }

        /// <summary>
        /// Gets or sets the default background image position.
        /// </summary>
        /// <value></value>
        protected virtual BackgroundImagePosition DefaultBackgroundImagePosition
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((FrameOverlayStyleValue)this.Defaults).BackgroundImagePosition;
                }
                else
                {
                    return BackgroundImagePosition.TopLeft;
                }
            }
        }

        /// <summary>
        /// Resets the BackgroundImagePosition.
        /// </summary>
        private void ResetBackgroundImagePosition()
        {
            Reset("BackgroundImagePosition");
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            if (this.HasBackgroundImagePosition)
            {
                // Get the important value
                string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

                return string.Format("background-position:{0}{1};{2}", BackgroundValue.GetCSSValue(this.BackgroundImagePosition), strImportantValue, base.GetValue(objContext, objValueDefinition));
            }
            else
            {
                return base.GetValue(objContext, objValueDefinition);
            }
        }
    }

    #endregion

    #region FrameStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(FrameStyleValueConverter))]
    public class FrameStyleValue
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjBottomStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjLeftStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjLeftTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjLeftBottomStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjRightStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjRightTopStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FramePartStyleValue mobjRightBottomStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjCenterStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftBottomStyle">The left bottom style.</param>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objLeftTopStyle">obj left top style.</param>
        /// <param name="objTopStyle">The top style.</param>
        /// <param name="objRightTopStyle">The right top style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objRightBottomStyle">The right bottom style.</param>
        /// <param name="objBottomStyle">The bottom style.</param>
        /// <param name="objCenterStyle">The center style.</param>
        public FrameStyleValue(
            FramePartStyleValue objLeftBottomStyle,
            FramePartStyleValue objLeftStyle,
            FramePartStyleValue objLeftTopStyle,
            FramePartStyleValue objTopStyle,
            FramePartStyleValue objRightTopStyle,
            FramePartStyleValue objRightStyle,
            FramePartStyleValue objRightBottomStyle,
            FramePartStyleValue objBottomStyle,
            StyleValue objCenterStyle)
        {
            mobjLeftBottomStyle = objLeftBottomStyle;
            mobjLeftStyle = objLeftStyle;
            mobjLeftTopStyle = objLeftTopStyle;
            mobjTopStyle = objTopStyle;
            mobjRightTopStyle = objRightTopStyle;
            mobjRightStyle = objRightStyle;
            mobjRightBottomStyle = objRightBottomStyle;
            mobjBottomStyle = objBottomStyle;
            mobjCenterStyle = objCenterStyle;

        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        public StyleValue CenterStyle
        {
            get { return mobjCenterStyle; }
        }

        /// <summary>
        /// Gets the top style.
        /// </summary>
        /// <value>The top style.</value>
        public FramePartStyleValue TopStyle
        {
            get { return mobjTopStyle; }
        }

        /// <summary>
        /// Gets the bottom style.
        /// </summary>
        /// <value>The bottom style.</value>
        public FramePartStyleValue BottomStyle
        {
            get { return mobjBottomStyle; }
        }

        /// <summary>
        /// Gets the left style.
        /// </summary>
        /// <value>The left style.</value>
        public FramePartStyleValue LeftStyle
        {
            get { return mobjLeftStyle; }
        }

        /// <summary>
        /// Gets the left top style.
        /// </summary>
        /// <value>The left top style.</value>
        public FramePartStyleValue LeftTopStyle
        {
            get { return mobjLeftTopStyle; }
        }

        /// <summary>
        /// Gets the left bottom style.
        /// </summary>
        /// <value>The left bottom style.</value>
        public FramePartStyleValue LeftBottomStyle
        {
            get { return mobjLeftBottomStyle; }
        }

        /// <summary>
        /// Gets the right style.
        /// </summary>
        /// <value>The right style.</value>
        public FramePartStyleValue RightStyle
        {
            get { return mobjRightStyle; }
        }

        /// <summary>
        /// Gets the right top style.
        /// </summary>
        /// <value>The right top style.</value>
        public FramePartStyleValue RightTopStyle
        {
            get { return mobjRightTopStyle; }
        }

        /// <summary>
        /// Gets the right bottom style.
        /// </summary>
        /// <value>The right bottom style.</value>
        public FramePartStyleValue RightBottomStyle
        {
            get { return mobjRightBottomStyle; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FrameStyleValueConverter : TypeConverter
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(FrameStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftBottomStyle", "LeftStyle", "LeftTopStyle", "TopStyle", "RightTopStyle", "RightStyle", "RightBottomStyle", "BottomStyle", "CenterStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }
    #endregion

    #region FrameStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(OverlayedFrameStyleValueConverter))]
    public class OverlayedFrameStyleValue : FrameStyleValue
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly FrameOverlayStyleValue mobjLeftOverlayStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly FrameOverlayStyleValue mobjRightOverlayStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverlayedFrameStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftBottomStyle">The left bottom style.</param>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objLeftTopStyle">obj left top style.</param>
        /// <param name="objTopStyle">The top style.</param>
        /// <param name="objRightTopStyle">The right top style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objRightBottomStyle">The right bottom style.</param>
        /// <param name="objBottomStyle">The bottom style.</param>
        /// <param name="objCenterStyle">The center style.</param>
        /// <param name="objLeftOverlayStyle">The left overlay style.</param>
        /// <param name="objRightOverlayStyle">The right overlay style.</param>
        public OverlayedFrameStyleValue(
            FramePartStyleValue objLeftBottomStyle,
            FramePartStyleValue objLeftStyle,
            FramePartStyleValue objLeftTopStyle,
            FramePartStyleValue objTopStyle,
            FramePartStyleValue objRightTopStyle,
            FramePartStyleValue objRightStyle,
            FramePartStyleValue objRightBottomStyle,
            FramePartStyleValue objBottomStyle,
            StyleValue objCenterStyle,
            FrameOverlayStyleValue objLeftOverlayStyle,
            FrameOverlayStyleValue objRightOverlayStyle)
            : base(objLeftBottomStyle, objLeftStyle, objLeftTopStyle, objTopStyle, objRightTopStyle, objRightStyle, objRightBottomStyle, objBottomStyle, objCenterStyle)
        {

            mobjLeftOverlayStyle = objLeftOverlayStyle;
            mobjRightOverlayStyle = objRightOverlayStyle;
        }

        /// <summary>
        /// Gets the left overlay style.
        /// </summary>
        /// <value>The left overlay style.</value>
        public FrameOverlayStyleValue LeftOverlayStyle
        {
            get { return mobjLeftOverlayStyle; }
        }

        /// <summary>
        /// Gets the right overlay style.
        /// </summary>
        /// <value>The right overlay style.</value>
        public FrameOverlayStyleValue RightOverlayStyle
        {
            get { return mobjRightOverlayStyle; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OverlayedFrameStyleValueConverter : TypeConverter
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(OverlayedFrameStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftBottomStyle", "LeftStyle", "LeftOverlayStyle", "LeftTopStyle", "TopStyle", "RightTopStyle", "RightStyle", "RightOverlayStyle", "RightBottomStyle", "BottomStyle", "CenterStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }
    #endregion

    #region SimpleFrameStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(SimpleFrameStyleValueConverter))]
    public class SimpleFrameStyleValue
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjRightStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjLeftStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjCenterStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFrameStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objCenterStyle">The center style.</param>
        public SimpleFrameStyleValue(
            StyleValue objLeftStyle,
            StyleValue objRightStyle,
            StyleValue objCenterStyle)
        {
            mobjLeftStyle = objLeftStyle;
            mobjRightStyle = objRightStyle;
            mobjCenterStyle = objCenterStyle;

        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        public StyleValue CenterStyle
        {
            get { return mobjCenterStyle; }
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
        /// Gets the left style.
        /// </summary>
        /// <value>The left style.</value>
        public StyleValue LeftStyle
        {
            get { return mobjLeftStyle; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SimpleFrameStyleValueConverter : TypeConverter
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(SimpleFrameStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftStyle", "RightStyle", "CenterStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }
    #endregion

    #region HeaderedFrameStyleValue Class

    /// <summary>
    /// Provides a class for editing multiple frame styles
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(HeaderedFrameStyleValueConverter))]
    public class HeaderedFrameStyleValue : FrameStyleValue
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjHeaderLeftStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjHeaderCenterStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjHeaderRightStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftBottomStyle">The left bottom style.</param>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objLeftTopStyle">obj left top style.</param>
        /// <param name="objTopStyle">The top style.</param>
        /// <param name="objRightTopStyle">The right top style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objRightBottomStyle">The right bottom style.</param>
        /// <param name="objBottomStyle">The bottom style.</param>
        /// <param name="objCenterStyle">The center style.</param>
        /// <param name="objHeaderLeftStyle">The header left style.</param>
        /// <param name="objHeaderCenterStyle">The header center style.</param>
        /// <param name="objHeaderRightStyle">The header right style.</param>
        public HeaderedFrameStyleValue(
            FramePartStyleValue objLeftBottomStyle,
            FramePartStyleValue objLeftStyle,
            FramePartStyleValue objLeftTopStyle,
            FramePartStyleValue objTopStyle,
            FramePartStyleValue objRightTopStyle,
            FramePartStyleValue objRightStyle,
            FramePartStyleValue objRightBottomStyle,
            FramePartStyleValue objBottomStyle,
            StyleValue objCenterStyle,
            StyleValue objHeaderLeftStyle,
            StyleValue objHeaderCenterStyle,
            StyleValue objHeaderRightStyle
            )
            : base(objLeftBottomStyle, objLeftStyle, objLeftTopStyle, objTopStyle, objRightTopStyle, objRightStyle, objRightBottomStyle, objBottomStyle, objCenterStyle)
        {
            mobjHeaderRightStyle = objHeaderRightStyle;
            mobjHeaderCenterStyle = objHeaderCenterStyle;
            mobjHeaderLeftStyle = objHeaderLeftStyle;

        }

        /// <summary>
        /// Gets the header left style.
        /// </summary>
        /// <value>The header left style.</value>
        public StyleValue HeaderLeftStyle
        {
            get { return mobjHeaderLeftStyle; }
        }

        /// <summary>
        /// Gets the header center style.
        /// </summary>
        /// <value>The header center style.</value>
        public StyleValue HeaderCenterStyle
        {
            get { return mobjHeaderCenterStyle; }
        }

        /// <summary>
        /// Gets the header right style.
        /// </summary>
        /// <value>The header right style.</value>
        public StyleValue HeaderRightStyle
        {
            get { return mobjHeaderRightStyle; }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HeaderedFrameStyleValueConverter : FrameStyleValueConverter
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(HeaderedFrameStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "HeaderLeftStyle", "HeaderCenterStyle", "HeaderRightStyle", "LeftBottomStyle", "LeftStyle", "LeftTopStyle", "TopStyle", "RightTopStyle", "RightStyle", "RightBottomStyle", "BottomStyle", "CenterStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }
    #endregion

    #region OpacityValue class

    /// <summary>
    /// hold sthe value that represents padding space between the body of the UI element and its edge.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [TypeConverter(typeof(OpacityValueConverter))]
    [Serializable()]
    public class OpacityValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private int mintOpacity;

        private static OpacityValue mobjEmpty = new OpacityValue(100);

        /// <summary>
        /// Initializes a new instance of the <see cref="OpacityValue"/> class.
        /// </summary>
        /// <param name="intOpacity">The int opacity(Value should be between 0 and 100).</param>
        public OpacityValue(int intOpacity)
        {
            mintOpacity = intOpacity;
        }

        /// <summary>
        /// Gets the empty opacity value.
        /// </summary>
        /// <value>The empty opacity value.</value>
        public static OpacityValue Empty
        {
            get
            {
                return mobjEmpty;
            }
        }

        /// <summary>
        /// Gets or sets the padding value for all the edges.
        /// </summary>
        /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
        internal int Opacity
        {
            get
            {
                return mintOpacity;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            // Get the important value
            string strImportantValue = objValueDefinition.GetImportantDeclarationValue(objContext);

            float fltOpacity = 0;

            if (mintOpacity > 0)
            {
                fltOpacity = (mintOpacity / 100F);
            }

            string strOpacityValue = string.Format("opacity:{0}{1}", fltOpacity.ToString(CultureInfo.InvariantCulture), strImportantValue);

            if (objContext.PresentationEngine == Gizmox.WebGUI.Forms.PresentationEngine.InternetExplorer)
            {
                strOpacityValue += string.Format(";filter:alpha(opacity={0}){1}", mintOpacity.ToString(), strImportantValue);
            }

            return strOpacityValue;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}%", mintOpacity.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.OpacityValue"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="objOpacityValue">The padding value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(OpacityValue objOpacityValue)
        {
            return objOpacityValue.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Gizmox.WebGUI.Forms.Skins.OpacityValue"/>.
        /// </summary>
        /// <param name="strFilter">The STR filter.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator OpacityValue(string strFilter)
        {
            // Remove the precent character - if needed.
            if (strFilter.EndsWith("%"))
            {
                strFilter = strFilter.Substring(0, strFilter.Length - 1);
            }

            // Try parse value.
            int intOpacity = -1;
            if (int.TryParse(strFilter, out intOpacity))
            {
                return new OpacityValue(intOpacity);
            }

            // Throw a proper exception.
            throw new Exception("You must supply integer values.");
        }
    }

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class OpacityValueConverter : TypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
        /// </summary>
        public OpacityValueConverter()
        {
        }

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
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string strValue = (string)objValue;

                if (!string.IsNullOrEmpty(strValue))
                {
                    // Remove the precent character - if needed.
                    if (strValue.EndsWith("%"))
                    {
                        strValue = strValue.Substring(0, strValue.Length - 1);
                    }

                    // Try parse value.
                    int intOpacity = -1;
                    if (int.TryParse(strValue, out intOpacity))
                    {
                        return new OpacityValue(intOpacity);
                    }

                    // Throw a proper exception.
                    throw new Exception("You must supply integer values.");
                }
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
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
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="objDestinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                OpacityValue objOpacityValue = objValue as OpacityValue;
                if (objOpacityValue != null)
                {
                    return objOpacityValue.ToString();
                }
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            OpacityValue objOpacityValue = (OpacityValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            int num1 = (int)objPropertyValues["Opacity"];
            return Activator.CreateInstance(objOpacityValue.GetType(), num1);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }


        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(OpacityValue), arrAttributes);
            string[] arrTtextArray = new string[] { "Opacity" };
            return objCollection.Sort(arrTtextArray);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }
    }

    #endregion

    #region VerticalAlignmentValue class

    /// <summary>
    /// hold sthe value that represents padding space between the body of the UI element and its edge.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [TypeConverter(typeof(VerticalAlignmentValueConverter))]
    [Serializable()]
    public class VerticalAlignmentValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private VerticalAlignment menmVerticalAlignment = VerticalAlignment.Center;

        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalAlignmentValue"/> class.
        /// </summary>
        /// <param name="enmVerticalAlignment">The enm vertical alignment.</param>
        public VerticalAlignmentValue(VerticalAlignment enmVerticalAlignment)
        {
            menmVerticalAlignment = enmVerticalAlignment;
        }

        /// <summary>
        /// Gets or sets the padding value for all the edges.
        /// </summary>
        /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
        internal VerticalAlignment VerticalAlignment
        {
            get
            {
                return menmVerticalAlignment;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            return menmVerticalAlignment.ToString().ToLower();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return menmVerticalAlignment.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="objVerticalAlignmentValue">The padding value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(VerticalAlignmentValue objVerticalAlignmentValue)
        {
            return objVerticalAlignmentValue.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue"/>.
        /// </summary>
        /// <param name="strFilter">The STR filter.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator VerticalAlignmentValue(string strFilter)
        {
            if (Enum.IsDefined(typeof(VerticalAlignment), strFilter))
            {
                return new VerticalAlignmentValue((VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), strFilter, true));
            }

            // Throw a proper exception.
            throw new Exception("Illegal vertical alignment value.");
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignment"/> to <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue"/>.
        /// </summary>
        /// <param name="enmVerticalAlignment">The enm vertical alignment.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator VerticalAlignmentValue(VerticalAlignment enmVerticalAlignment)
        {
            return new VerticalAlignmentValue(enmVerticalAlignment);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue"/> to <see cref="Gizmox.WebGUI.Forms.Skins.VerticalAlignment"/>.
        /// </summary>
        /// <param name="objVerticalAlignmentValue">The obj vertical alignment value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator VerticalAlignment(VerticalAlignmentValue objVerticalAlignmentValue)
        {
            return objVerticalAlignmentValue.VerticalAlignment;
        }
    }

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class VerticalAlignmentValueConverter : TypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
        /// </summary>
        public VerticalAlignmentValueConverter()
        {
        }

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
            if (objDestinationType == typeof(string) || objDestinationType == typeof(int) || objDestinationType == typeof(VerticalAlignment))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string) || objSourceType == typeof(int) || objSourceType == typeof(VerticalAlignment))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue)
        {
            if (objValue is string || objValue is int)
            {
                string strValue = objValue.ToString();

                if (!string.IsNullOrEmpty(strValue))
                {
                    if (Enum.IsDefined(typeof(VerticalAlignment), strValue))
                    {
                        return new VerticalAlignmentValue((VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), strValue, true));
                    }

                    // Throw a proper exception.
                    throw new Exception("Illegal vertical alignment value.");
                }
            }
            else if (objValue is VerticalAlignment)
            {
                return new VerticalAlignmentValue((VerticalAlignment)objValue);
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
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
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="objDestinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                VerticalAlignmentValue objVerticalAlignmentValue = objValue as VerticalAlignmentValue;
                if (objVerticalAlignmentValue != null)
                {
                    return objVerticalAlignmentValue.ToString();
                }
            }
            else if (objDestinationType == typeof(VerticalAlignment))
            {
                VerticalAlignmentValue objVerticalAlignmentValue = objValue as VerticalAlignmentValue;
                if (objVerticalAlignmentValue != null)
                {
                    return objVerticalAlignmentValue.VerticalAlignment;
                }
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            VerticalAlignmentValue objVerticalAlignmentValue = (VerticalAlignmentValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            int num1 = (int)objPropertyValues["VerticalAlignment"];
            return Activator.CreateInstance(objVerticalAlignmentValue.GetType(), num1);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(VerticalAlignmentValue), arrAttributes);
            string[] arrTtextArray = new string[] { "VerticalAlignment" };
            return objCollection.Sort(arrTtextArray);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
        /// </returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; false if other values are possible.
        /// </returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
        /// </returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
        {
            // Return the standard values collection
            return new StandardValuesCollection(Enum.GetValues(typeof(VerticalAlignment)));
        }
    }

    #endregion

    #region HorizontalAlignmentValue class

    /// <summary>
    /// hold sthe value that represents padding space between the body of the UI element and its edge.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [TypeConverter(typeof(HorizontalAlignmentValueConverter))]
    [Serializable()]
    public class HorizontalAlignmentValue : SkinValue
    {
        /// <summary>
        /// 
        /// </summary>
        private HorizontalAlignment menmHorizontalAlignment = HorizontalAlignment.Center;

        /// <summary>
        /// Initializes a new instance of the <see cref="HorizontalAlignmentValue"/> class.
        /// </summary>
        /// <param name="enmHorizontalAlignment">The enm horizontal alignment.</param>
        public HorizontalAlignmentValue(HorizontalAlignment enmHorizontalAlignment)
        {
            menmHorizontalAlignment = enmHorizontalAlignment;
        }

        /// <summary>
        /// Gets or sets the padding value for all the edges.
        /// </summary>
        /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
        internal HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return menmHorizontalAlignment;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            return menmHorizontalAlignment.ToString().ToLower();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return menmHorizontalAlignment.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="objHorizontalAlignmentValue">The padding value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(HorizontalAlignmentValue objHorizontalAlignmentValue)
        {
            return objHorizontalAlignmentValue.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue"/>.
        /// </summary>
        /// <param name="strFilter">The STR filter.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator HorizontalAlignmentValue(string strFilter)
        {
            if (Enum.IsDefined(typeof(HorizontalAlignment), strFilter))
            {
                return new HorizontalAlignmentValue((HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), strFilter, true));
            }

            // Throw a proper exception.
            throw new Exception("Illegal horizontal alignment value.");
        }
    }

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class HorizontalAlignmentValueConverter : TypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
        /// </summary>
        public HorizontalAlignmentValueConverter()
        {
        }

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
            if (objDestinationType == typeof(string) || objDestinationType == typeof(int))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string) || objSourceType == typeof(int))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue)
        {
            if (objValue is string || objValue is int)
            {
                string strValue = objValue.ToString();

                if (!string.IsNullOrEmpty(strValue))
                {
                    if (Enum.IsDefined(typeof(HorizontalAlignment), strValue))
                    {
                        return new HorizontalAlignmentValue((HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), strValue, true));
                    }

                    // Throw a proper exception.
                    throw new Exception("Illegal horizontal alignment value.");
                }
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
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
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="objDestinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, System.Globalization.CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                HorizontalAlignmentValue objHorizontalAlignmentValue = objValue as HorizontalAlignmentValue;
                if (objHorizontalAlignmentValue != null)
                {
                    return objHorizontalAlignmentValue.ToString();
                }
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            HorizontalAlignmentValue objHorizontalAlignmentValue = (HorizontalAlignmentValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            int num1 = (int)objPropertyValues["HorizontalAlignment"];
            return Activator.CreateInstance(objHorizontalAlignmentValue.GetType(), num1);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(HorizontalAlignmentValue), arrAttributes);
            string[] arrTtextArray = new string[] { "HorizontalAlignment" };
            return objCollection.Sort(arrTtextArray);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
        /// </returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; false if other values are possible.
        /// </returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
        /// </returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
        {
            // Return the standard values collection
            return new StandardValuesCollection(Enum.GetValues(typeof(HorizontalAlignment)));
        }
    }

    #endregion

    #region BackgroundStyleValue Class

    /// <summary>
    /// Provides generic control styling mechanism
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(BackgroundStyleValueConverter))]
    public class BackgroundStyleValue : SkinMultiValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
            : base(objPropertyOwner, strPropertyPrefix)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, BackgroundStyleValue objDefaults)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundStyleValue"/> class.
        /// </summary>
        /// <param name="objPropertyOwner">The property owner.</param>
        /// <param name="strPropertyPrefix">The property prefix.</param>
        /// <param name="objDefaults">The defaults.</param>
        /// <param name="blnLocalizeBaseBackgroundStyleValues">Treats inherited base style values as locals.</param>
        public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, BackgroundStyleValue objDefaults, bool blnLocalizeBaseBackgroundStyleValues)
            : base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseBackgroundStyleValues)
        {
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [SRDescription("ControlBackgroundImageDescr")]
        [SRCategory("CatAppearance")]
        public ImageResourceReference BackgroundImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundImage", this.DefaultBackgroundImage);
            }
            set
            {
                this.SetValue("BackgroundImage", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImage
        {
            get
            {
                return this.BackgroundImage != ImageResourceReference.Empty;
            }
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        private void ResetBackgroundImage()
        {
            Reset("BackgroundImage");
        }

        /// <summary>
        /// Gets or sets the default background image.
        /// </summary>
        /// <value></value>
        protected virtual ImageResourceReference DefaultBackgroundImage
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((BackgroundStyleValue)this.Defaults).GetValue<ImageResourceReference>("BackgroundImage", ImageResourceReference.Empty);
                }
                else
                {
                    return ImageResourceReference.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>The background image repeat.</value>
        [SRDescription("Sets if or how a background image will be repeated.")]
        [SRCategory("CatAppearance")]
        public BackgroundImageRepeat BackgroundImageRepeat
        {
            get
            {
                return this.GetValue<BackgroundImageRepeat>("BackgroundImageRepeat", this.DefaultBackgroundImageRepeat);
            }
            set
            {
                this.SetValue("BackgroundImageRepeat", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image repeat.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image repeat; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImageRepeat
        {
            get
            {
                return this.HasValue("BackgroundImageRepeat");
            }
        }

        /// <summary>
        /// Resets the BackgroundImageRepeat.
        /// </summary>
        private void ResetBackgroundImageRepeat()
        {
            Reset("BackgroundImageRepeat");
        }

        /// <summary>
        /// Gets or sets the default background image repeat.
        /// </summary>
        /// <value></value>
        protected virtual BackgroundImageRepeat DefaultBackgroundImageRepeat
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((BackgroundStyleValue)this.Defaults).BackgroundImageRepeat;
                }
                else
                {
                    return BackgroundImageRepeat.Repeat;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        [SRDescription("Sets the starting position of a background image.")]
        [SRCategory("CatAppearance")]
        public BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return this.GetValue<BackgroundImagePosition>("BackgroundImagePosition", this.DefaultBackgroundImagePosition);
            }
            set
            {
                this.SetValue("BackgroundImagePosition", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background image position.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background image position; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackgroundImagePosition
        {
            get
            {
                return this.HasValue("BackgroundImagePosition");
            }
        }

        /// <summary>
        /// Gets or sets the default background image position.
        /// </summary>
        /// <value></value>
        protected virtual BackgroundImagePosition DefaultBackgroundImagePosition
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((BackgroundStyleValue)this.Defaults).BackgroundImagePosition;
                }
                else
                {
                    return BackgroundImagePosition.MiddleCenter;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("ControlBackColorDescr")]
        public virtual Color BackColor
        {
            get
            {
                return this.GetValue<Color>("BackColor", this.DefaultBackColor);
            }
            set
            {
                this.SetValue("BackColor", value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has back color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has back color; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackColor
        {
            get
            {
                return this.HasValue("BackColor");
            }
        }

        /// <summary>
        /// Resets the BackColor.
        /// </summary>
        private void ResetBackColor()
        {
            Reset("BackColor");
        }

        /// <summary>
        /// Gets or sets the default back color.
        /// </summary>
        /// <value></value>
        protected virtual Color DefaultBackColor
        {
            get
            {
                if (this.Defaults != null)
                {
                    return ((BackgroundStyleValue)this.Defaults).BackColor;
                }
                else
                {
                    return Color.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BackgroundValue Background
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                if (this.HasBackColor)
                {
                    objBackgroundValue.BackColor = this.BackColor;
                }

                if (this.HasBackgroundImage)
                {
                    objBackgroundValue.BackgroundImage = this.BackgroundImage;
                    objBackgroundValue.BackgroundImagePosition = this.BackgroundImagePosition;
                    objBackgroundValue.BackgroundImageRepeat = this.BackgroundImageRepeat;
                }

                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has background.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has background; otherwise, <c>false</c>.
        /// </value>
        protected bool HasBackground
        {
            get
            {
                return this.HasBackColor || this.HasBackgroundImage || this.HasBackgroundImagePosition || this.HasBackgroundImageRepeat;
            }
        }

        /// <summary>
        /// Gets the translated value.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        /// <returns></returns>
        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            StringBuilder objBuffer = new StringBuilder();


            if (this.HasBackground)
            {
                objBuffer.AppendLine(string.Format("{0};", FormatValue(this.Background.GetValue(objContext))));
            }

            return FormatValue(objBuffer.ToString());
        }

        private string FormatValue(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return string.Empty;
            }
            else
            {
                return strValue.TrimEnd(';', '\r', '\n');
            }
        }
    }

    /// <summary>
    /// Provides a type convertor for the control style class
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BackgroundStyleValueConverter : SkinMultiValueConverter
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
    }

    #endregion

    #region TripleCellFrameStyleValue Class

    /// <summary>
    /// Provides a class for editing Triple Cell Frame style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    [TypeConverter(typeof(TripleCellFrameStyleValueConverter))]
    public class TripleCellFrameStyleValue
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjLeftStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjRightStyle;

        /// <summary>
        /// 
        /// </summary>
        private readonly StyleValue mobjCenterStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameStyleValue"/> class.
        /// </summary>
        /// <param name="objLeftBottomStyle">The left bottom style.</param>
        /// <param name="objLeftStyle">The left style.</param>
        /// <param name="objLeftTopStyle">obj left top style.</param>
        /// <param name="objTopStyle">The top style.</param>
        /// <param name="objRightTopStyle">The right top style.</param>
        /// <param name="objRightStyle">The right style.</param>
        /// <param name="objRightBottomStyle">The right bottom style.</param>
        /// <param name="objBottomStyle">The bottom style.</param>
        /// <param name="objCenterStyle">The center style.</param>
        public TripleCellFrameStyleValue(
            StyleValue objLeftStyle,
            StyleValue objRightStyle,
            StyleValue objCenterStyle)
        {
            mobjLeftStyle = objLeftStyle;
            mobjRightStyle = objRightStyle;
            mobjCenterStyle = objCenterStyle;
        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        public StyleValue CenterStyle
        {
            get { return mobjCenterStyle; }
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
        /// Gets the right style.
        /// </summary>
        /// <value>The right style.</value>
        public StyleValue RightStyle
        {
            get { return mobjRightStyle; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TripleCellFrameStyleValueConverter : TypeConverter
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(TripleCellFrameStyleValue), arrAttributes);
            string[] arrTtextArray = new string[] { "LeftStyle", "RightStyle", "CenterStyle" };
            return objCollection.Sort(arrTtextArray);
        }
    }
    #endregion
}
