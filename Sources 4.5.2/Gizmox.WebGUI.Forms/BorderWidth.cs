using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    #region BorderWidth Class
    
    /// <summary>
    /// Represents border thickness information associated with a user interface (UI) element.
    /// </summary>
    [StructLayout(LayoutKind.Sequential), TypeConverter(typeof(BorderWidthConverter)), Serializable()]
    public struct BorderWidth
    {
        private bool mblnAll;
        private int mintTop;
        private int mintLeft;
        private int mintRight;
        private int mintBottom;

        /// <summary>
        /// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> object with no thickness.
        /// </summary>
        public static readonly BorderWidth Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using the supplied thickness size for all edges.
        /// </summary>
        ///	<param name="intAll">The number of pixels to be used for thickness for all edges.</param>
        public BorderWidth(int intAll)
        {
            int intTemp;
            this.mblnAll = true;
            this.mintBottom = intTemp = intAll;
            this.mintRight = intTemp;
            this.mintLeft = intTemp;
            this.mintTop = intTemp;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using a separate thickness size for each edge.
        /// </summary>
        ///	<param name="intRight">The thickness size, in pixels, for the right edge.</param>
        ///	<param name="intBottom">The thickness size, in pixels, for the bottom edge.</param>
        ///	<param name="intLeft">The thickness size, in pixels, for the left edge.</param>
        ///	<param name="intTop">The thickness size, in pixels, for the top edge.</param>
        public BorderWidth(int intLeft, int intTop, int intRight, int intBottom)
        {
            this.mintTop = intTop;
            this.mintLeft = intLeft;
            this.mintRight = intRight;
            this.mintBottom = intBottom;
            this.mblnAll = (!(this.mintTop != this.mintLeft) && !(this.mintTop != this.mintRight)) && (this.mintTop == this.mintBottom);
        }
        
        /// <summary>
        /// Gets or sets the thickness value for all the edges.
        /// </summary>
        /// <returns>The thickness, in pixels, for all edges if the same; otherwise, -1.</returns>
        [Browsable(false)]
        public int All
        {
            get
            {
                if (!this.mblnAll)
                {
                    return -1;
                }
                return this.mintTop;
            }
            set
            {
                if (!this.mblnAll || (this.mintTop != value))
                {
                    int intTemp;
                    this.mblnAll = true;
                    this.mintBottom = intTemp = value;
                    this.mintRight = intTemp;
                    this.mintLeft = intTemp;
                    this.mintTop = intTemp;
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
        /// Gets or sets the thickness value for the bottom edge.
        /// </summary>
        ///	<returns>The thickness, in pixels, for the bottom edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Bottom
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTop;
                }
                return this.mintBottom;
            }
            set
            {
                if (this.mblnAll || (this.mintBottom != value))
                {
                    this.mblnAll = false;
                    this.mintBottom = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the thickness value for the left edge.
        /// </summary>
        ///	<returns>The thickness, in pixels, for the left edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Left
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTop;
                }
                return this.mintLeft;
            }
            set
            {
                if (this.mblnAll || (this.mintLeft != value))
                {
                    this.mblnAll = false;
                    this.mintLeft = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the thickness value for the right edge.
        /// </summary>
        ///	<returns>The thickness, in pixels, for the right edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Right
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTop;
                }
                return this.mintRight;
            }
            set
            {
                if (this.mblnAll || (this.mintRight != value))
                {
                    this.mblnAll = false;
                    this.mintRight = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the thickness value for the top edge.
        /// </summary>
        ///	<returns>The thickness, in pixels, for the top edge.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int Top
        {
            get
            {
                return this.mintTop;
            }
            set
            {
                if (this.mblnAll || (this.mintTop != value))
                {
                    this.mblnAll = false;
                    this.mintTop = value;
                }
            }
        }

        /// <summary>
        /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
        /// </summary>
        ///	<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent; otherwise, false.</returns>
        ///	<param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.</param>
        public override bool Equals(object other)
        {
            if (other is BorderWidth)
            {
                BorderWidth thickness1 = (BorderWidth)other;
                if (((thickness1.mblnAll == this.mblnAll) && (thickness1.mintTop == this.mintTop)) && ((thickness1.mintLeft == this.mintLeft) && (thickness1.mintBottom == this.mintBottom)))
                {
                    return (thickness1.mintRight == this.mintRight);
                }
            }
            return false;
        }

        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equal; otherwise, false.</returns>
        ///	<param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
        ///	<param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
        public static bool operator ==(BorderWidth objWidth1, BorderWidth objWidth2)
        {
            if (((objWidth1.Left == objWidth2.Left) && (objWidth1.Top == objWidth2.Top)) && (objWidth1.Right == objWidth2.Right))
            {
                return (objWidth1.Bottom == objWidth2.Bottom);
            }
            return false;
        }
        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are not equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are different; otherwise, false.</returns>
        ///	<param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
        ///	<param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
        public static bool operator !=(BorderWidth objWidth1, BorderWidth objWidth2)
        {
            return !(objWidth1 == objWidth2);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Gizmox.WebGUI.Forms.BorderWidth"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="objBorderWidth">The thickness.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator int(BorderWidth objBorderWidth)
        {
            return objBorderWidth.All;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Gizmox.WebGUI.Forms.BorderWidth"/>.
        /// </summary>
        /// <param name="intBorderWidth">The thickness.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator BorderWidth(int intBorderWidth)
        {
            return new BorderWidth(intBorderWidth);
        }

        /// <summary>
        /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer.
        /// </returns>
        public override int GetHashCode()
        {
            return (((this.Left ^ ClientUtils.RotateLeft(this.Top, 8)) ^ ClientUtils.RotateLeft(this.Right, 0x10)) ^ ClientUtils.RotateLeft(this.Bottom, 0x18));
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
        /// </returns>
        public override string ToString()
        {
            string[] arrTextArray = new string[] { "{Left=", this.Left.ToString(), ",Top=", this.Top.ToString(), ",Right=", this.Right.ToString(), ",Bottom=", this.Bottom.ToString(), "}" };
            return string.Concat(arrTextArray);
        }
        
        private void ResetAll()
        {
            this.All = 0;
        }
        
        private void ResetBottom()
        {
            this.Bottom = 0;
        }
        
        private void ResetLeft()
        {
            this.Left = 0;
        }
        
        private void ResetRight()
        {
            this.Right = 0;
        }
        
        private void ResetTop()
        {
            this.Top = 0;
        }

        internal void Scale(float fltX, float fltY)
        {
            this.mintTop = (int)(this.mintTop * fltY);
            this.mintLeft = (int)(this.mintLeft * fltX);
            this.mintRight = (int)(this.mintRight * fltX);
            this.mintBottom = (int)(this.mintBottom * fltY);
        }
        
        internal bool ShouldSerializeAll()
        {
            return this.mblnAll;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using the supplied thickness size for all edges.
        /// </summary>
        static BorderWidth()
        {
            BorderWidth.Empty = new BorderWidth(0);
        }
    }
    
    #endregion

    #region BorderWidthConverter Class
    
    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class BorderWidthConverter : TypeConverter
    {
        /// <summary>
        /// Provides a SkinValue implementation of thickness
        /// </summary>
        [Serializable()]
        internal class BorderWidthSkinValue : Skins.SkinValue
        {
            /// <summary>
            /// 
            /// </summary>
            private BorderWidth mobjValue;

            /// <summary>
            /// Initializes a new instance of the <see cref="BorderWidthSkinValue"/> class.
            /// </summary>
            /// <param name="objValue">The thickness value.</param>
            public BorderWidthSkinValue(BorderWidth objValue)
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
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidthConverter"></see> class. 
        /// </summary>
        public BorderWidthConverter()
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
                return new BorderWidthSkinValue((BorderWidth)objValue);
            }
            if (objDestinationType == typeof(string) && (objValue is BorderWidth))
            {
                BorderWidth thickness2 = (BorderWidth)objValue;
                if (thickness2.ShouldSerializeAll())
                {
                    return thickness2.All.ToString();
                }
                else
                {
                    return string.Format("{0}, {1}, {2}, {3}", thickness2.Left, thickness2.Top, thickness2.Right, thickness2.Bottom);
                }
            }
            
            if (objDestinationType == typeof(InstanceDescriptor) && (objValue is BorderWidth))
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
            Type[]      arrTypeArray;
            object[]    arrObjArray;

            BorderWidth objThickness = (BorderWidth)objValue;
            if (objThickness.ShouldSerializeAll())
            {
                arrTypeArray = new Type[] { typeof(int) };
                arrObjArray = new object[] { objThickness.All };
                return new InstanceDescriptor(typeof(BorderWidth).GetConstructor(arrTypeArray), arrObjArray);
            }
            arrTypeArray = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) };
            arrObjArray = new object[] { objThickness.Left, objThickness.Top, objThickness.Right, objThickness.Bottom };
            
            return new InstanceDescriptor(typeof(BorderWidth).GetConstructor(arrTypeArray), arrObjArray);
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
                    try
                    {
                        string[] arrStrValueParts = strValue.Split(',');
                        if (arrStrValueParts.Length == 1)
                        {
                            return new BorderWidth(int.Parse(arrStrValueParts[0]));
                        }
                        else if (arrStrValueParts.Length == 4)
                        {
                            return new BorderWidth(int.Parse(arrStrValueParts[0]), int.Parse(arrStrValueParts[1]), int.Parse(arrStrValueParts[2]), int.Parse(arrStrValueParts[3]));
                        }
                        else
                        {
                            return BorderWidth.Empty;
                        }
                    }
                    catch
                    {
                        return BorderWidth.Empty;
                    }
                }
            }
            return base.ConvertFrom(objContext, objCulture, objValue);
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
            BorderWidth objThickness = (BorderWidth)objContext.PropertyDescriptor.GetValue(objContext.Instance);

            int intLeft = (int)objPropertyValues["Left"];
            int intTop = (int)objPropertyValues["Top"];
            int intRight = (int)objPropertyValues["Right"];
            int intBottom = (int)objPropertyValues["Bottom"];


            if (intLeft == intRight && intRight == intTop && intTop == intBottom )
            {
                return new BorderWidth(intBottom);
            }
            return new BorderWidth(intLeft, intTop, intRight, intBottom);
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
            PropertyDescriptorCollection objCollection = TypeDescriptor.GetProperties(typeof(BorderWidth), arrAttributes);
            string[] arrTextArray = new string[] {"Left", "Top", "Right", "Bottom" };
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

