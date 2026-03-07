using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    #region BorderColor Class

    /// <summary>
    /// Represents color information associated with a user interface (UI) element.
    /// </summary>
    [StructLayout(LayoutKind.Sequential), TypeConverter(typeof(BorderColorConverter)), Serializable()]
    [WebEditor(typeof(BorderColorEditor), typeof(WebUITypeEditor))]
#if WG_NET46
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
    public struct BorderColor
    {
        private bool mblnAll;
        private Color mobjTop;
        private Color mobjLeft;
        private Color mobjRight;
        private Color mobjBottom;

        /// <summary>
        /// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> object with no color.
        /// </summary>
        public static readonly BorderColor Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderColor"/> struct.
        /// </summary>
        /// <param name="objAll">All.</param>
        public BorderColor(Color objAll)
        {
            Color objTemp;
            this.mblnAll = true;
            this.mobjBottom = objTemp = objAll;
            this.mobjRight = objTemp;
            this.mobjLeft = objTemp;
            this.mobjTop = objTemp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderColor"/> struct.
        /// </summary>
        /// <param name="objLeft">The left.</param>
        /// <param name="objTop">The top.</param>
        /// <param name="objRight">The right.</param>
        /// <param name="objBottom">The bottom.</param>
        public BorderColor(Color objLeft, Color objTop, Color objRight, Color objBottom)
        {
            this.mobjTop = objTop;
            this.mobjLeft = objLeft;
            this.mobjRight = objRight;
            this.mobjBottom = objBottom;
            this.mblnAll = (!(this.mobjTop != this.mobjLeft) && !(this.mobjTop != this.mobjRight)) && (this.mobjTop == this.mobjBottom);
        }

        /// <summary>
        /// Gets or sets all.
        /// </summary>
        /// <value>All.</value>
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(false)]
        public Color All
        {
            get
            {
                if (!this.mblnAll)
                {
                    return Color.Empty;
                }
                return this.mobjTop;
            }
            set
            {
                if (!this.mblnAll || (this.mobjTop != value))
                {
                    Color objTemp;
                    this.mblnAll = true;
                    this.mobjBottom = objTemp = value;
                    this.mobjRight = objTemp;
                    this.mobjLeft = objTemp;
                    this.mobjTop = objTemp;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is all.
        /// </summary>
        /// <value><c>true</c> if this instance is all; otherwise, <c>false</c>.</value>
        internal bool IsAll
        {
            get
            {
                return mblnAll;
            }
        }

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        [RefreshProperties(RefreshProperties.All)]
        public Color Bottom
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mobjTop;
                }
                return this.mobjBottom;
            }
            set
            {
                if (this.mblnAll || (this.mobjBottom != value))
                {
                    this.mblnAll = false;
                    this.mobjBottom = value;
                }
            }
        }


        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        [RefreshProperties(RefreshProperties.All)]
        public Color Left
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mobjTop;
                }
                return this.mobjLeft;
            }
            set
            {
                if (this.mblnAll || (this.mobjLeft != value))
                {
                    this.mblnAll = false;
                    this.mobjLeft = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>The right.</value>
        [RefreshProperties(RefreshProperties.All)]
        public Color Right
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mobjTop;
                }
                return this.mobjRight;
            }
            set
            {
                if (this.mblnAll || (this.mobjRight != value))
                {
                    this.mblnAll = false;
                    this.mobjRight = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        [RefreshProperties(RefreshProperties.All)]
        public Color Top
        {
            get
            {
                return this.mobjTop;
            }
            set
            {
                if (this.mblnAll || (this.mobjTop != value))
                {
                    this.mblnAll = false;
                    this.mobjTop = value;
                }
            }
        }

        /// <summary>
        /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
        /// </summary>
        ///	<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent; otherwise, false.</returns>
        ///	<param name="objOther">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.</param>
        public override bool Equals(object objOther)
        {
            if (objOther is BorderColor)
            {
                BorderColor objBorderColor = (BorderColor)objOther;
                if (((objBorderColor.mblnAll == this.mblnAll) && (objBorderColor.mobjTop == this.mobjTop)) && ((objBorderColor.mobjLeft == this.mobjLeft) && (objBorderColor.mobjBottom == this.mobjBottom)))
                {
                    return (objBorderColor.mobjRight == this.mobjRight);
                }
            }
            return false;
        }


        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equal; otherwise, false.</returns>
        ///	<param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
        ///	<param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
        public static bool operator ==(BorderColor objColor1, BorderColor objColor2)
        {
            if (((objColor1.Left == objColor2.Left) && (objColor1.Top == objColor2.Top)) && (objColor1.Right == objColor2.Right))
            {
                return (objColor1.Bottom == objColor2.Bottom);
            }
            return false;
        }

        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are not equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are different; otherwise, false.</returns>
        ///	<param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
        ///	<param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
        public static bool operator !=(BorderColor objColor1, BorderColor objColor2)
        {
            return !(objColor1 == objColor2);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.BorderColor"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="objBorderColor">The color.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color(BorderColor objBorderColor)
        {
            return objBorderColor.All;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Gizmox.WebGUI.Forms.BorderColor"/>.
        /// </summary>
        /// <param name="objBorderColor">The color.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator BorderColor(Color objBorderColor)
        {
            return new BorderColor(objBorderColor);
        }

        /// <summary>
        /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.Top.GetHashCode() + this.Right.GetHashCode() + this.Bottom.GetHashCode() + this.Left.GetHashCode());
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
        /// </returns>
        public override string ToString()
        {
            string[] arrTextArray = new string[] { "{Left=", this.Left.ToString(), ",Top=", this.Top.ToString(), ",Right=", this.Right.ToString(), ",Bottom=", this.Bottom.ToString(), "}" };
            return string.Concat(arrTextArray);
        }

        private void ResetAll()
        {
            this.All = Color.Empty;
        }
        
        private void ResetBottom()
        {
            this.Bottom = Color.Empty;
        }
        
        private void ResetLeft()
        {
            this.Left = Color.Empty;
        }
        
        private void ResetRight()
        {
            this.Right = Color.Empty;
        }
        
        private void ResetTop()
        {
            this.Top = Color.Empty;
        }

        internal bool ShouldSerializeAll()
        {
            return this.mblnAll;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> class using the supplied color size for all edges.
        /// </summary>
        static BorderColor()
        {
            BorderColor.Empty = new BorderColor(Color.Empty);
        }
    }

    #endregion

    #region BorderColorConverter Class

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class BorderColorConverter : TypeConverter
    {
        /// <summary>
        /// Provides a SkinValue implementation of color
        /// </summary>
        [Serializable()]
        internal class BorderColorSkinValue : Skins.SkinValue
        {
            /// <summary>
            /// 
            /// </summary>
            private BorderColor mobjValue;

            /// <summary>
            /// Initializes a new instance of the <see cref="BorderColorSkinValue"/> class.
            /// </summary>
            /// <param name="objValue">The color value.</param>
            public BorderColorSkinValue(BorderColor objValue)
            {
                mobjValue = objValue;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <param name="objContext">The current context.</param>
            /// <returns></returns>
            public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
            {
                if (mobjValue.IsAll)
                {
                    return string.Format("{0}", mobjValue.All);
                }
                else
                {
                    return string.Format("{0} {1} {2} {3}", mobjValue.Top, mobjValue.Right, mobjValue.Bottom, mobjValue.Left);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColorConverter"></see> class. 
        /// </summary>
        public BorderColorConverter()
        {
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            else if (objDestinationType == typeof(Skins.SkinValue))
            {
                return true;
            }
            else if (objDestinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"></see>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"></see> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"></see> to convert the value parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        /// <exception cref="T:System.ArgumentNullException">The objDestinationType parameter is null. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            if (objDestinationType == typeof(Skins.SkinValue))
            {
                return new BorderColorSkinValue((BorderColor)objValue);
            }
            if (objDestinationType == typeof(string) && (objValue is BorderColor))
            {
                BorderColor objBorderColor = (BorderColor)objValue;
                if (objBorderColor.ShouldSerializeAll())
                {
                    return GetColorString(objBorderColor.All, objCulture);
                }
                else
                {
                    return string.Format("{0} {1} {2} {3}",
                        GetColorString(objBorderColor.Left, objCulture), GetColorString(objBorderColor.Top, objCulture),
                        GetColorString(objBorderColor.Right, objCulture), GetColorString(objBorderColor.Bottom, objCulture));
                }
            }

            if (objDestinationType == typeof(InstanceDescriptor) && (objValue is BorderColor))
            {
                //convert to InstanceDescriptor
                return ConvertToInstanceDescriptor(objContext, objValue);
            }

            // if unable to convert to known type ask base class to deal with conversion
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }
        
        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
        {
            Type[] arrTypeArray;
            object[] arrObjArray;

            BorderColor objBorderColor = (BorderColor)objValue;
            if (objBorderColor.ShouldSerializeAll())
            {
                arrTypeArray = new Type[] { typeof(Color) };
                arrObjArray = new object[] { objBorderColor.All };

                return new InstanceDescriptor(typeof(BorderColor).GetConstructor(arrTypeArray), arrObjArray);
            }

            arrTypeArray = new Type[] { typeof(Color), typeof(Color), typeof(Color), typeof(Color) };
            arrObjArray = new object[] { objBorderColor.Left, objBorderColor.Top,  
                                        objBorderColor.Right, objBorderColor.Bottom };

            return new InstanceDescriptor(typeof(BorderColor).GetConstructor(arrTypeArray), arrObjArray);
        }

        private object GetColorString(Color objColor, CultureInfo objCulture)
        {
			return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(null, objCulture, objColor);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if (objSourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(objContext, objSourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string strValue = (string)objValue;

                if (!string.IsNullOrEmpty(strValue))
                {
                    string strListSeperator = ",";
                    if (objCulture != null)
                    {
                        strListSeperator = objCulture.TextInfo.ListSeparator;
                    }
                    strValue = strValue.Replace(strListSeperator + " ", strListSeperator);

                    string[] arrStrValueParts = strValue.Split(' ');
                    if (arrStrValueParts.Length == 1)
                    {
                        return new BorderColor(this.ConvertColor(arrStrValueParts[0], objCulture));
                    }
                    else if (arrStrValueParts.Length == 2)
                    {
                        return new BorderColor(this.ConvertColor(arrStrValueParts[0], objCulture), this.ConvertColor(arrStrValueParts[1], objCulture), this.ConvertColor(arrStrValueParts[1], objCulture), this.ConvertColor(arrStrValueParts[1], objCulture));
                    }
                    else if (arrStrValueParts.Length == 3)
                    {
                        return new BorderColor(this.ConvertColor(arrStrValueParts[0], objCulture), this.ConvertColor(arrStrValueParts[1], objCulture), this.ConvertColor(arrStrValueParts[2], objCulture), this.ConvertColor(arrStrValueParts[2], objCulture));
                    }
                    else if (arrStrValueParts.Length == 4)
                    {
                        return new BorderColor(this.ConvertColor(arrStrValueParts[0], objCulture), this.ConvertColor(arrStrValueParts[1], objCulture), this.ConvertColor(arrStrValueParts[2], objCulture), this.ConvertColor(arrStrValueParts[3], objCulture));
                    }
                    else
                    {
                        return BorderColor.Empty;
                    }
                }
                else
                {
                    return BorderColor.Empty;
                }
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        /// <summary>
        /// Converts the color.
        /// </summary>
        /// <param name="strColor">Color in string format.</param>
        /// <param name="objCulture">The culture.</param>
        /// <returns></returns>
        private Color ConvertColor(string strColor, CultureInfo objCulture)
        {
            return (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(null, objCulture, strColor);
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
            BorderColor objBorderColor = (BorderColor)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            Color objLeft = (Color)objPropertyValues["Left"];
            Color objTop = (Color)objPropertyValues["Top"];
            Color objRight = (Color)objPropertyValues["Right"];
            Color objBottom = (Color)objPropertyValues["Bottom"];

            if (objLeft == objRight && objRight == objTop && objTop == objBottom)
            {
                return new BorderColor(objLeft);
            }
            return new BorderColor(objLeft, objTop, objRight, objBottom);
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(BorderColor), arrAttributes);
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
    #endregion
}

