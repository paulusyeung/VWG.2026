using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents padding or margin information associated with a user interface (UI) element.
    /// </summary>

    [StructLayout(LayoutKind.Sequential), TypeConverter(typeof(PaddingConverter)), Serializable()]
    public struct Padding
    {
        private bool mblnAll;
        private int mintTop;
        private int mintLeft;
        private int mintRight;
        private int mintBottom;

        /// <summary>
        /// Provides a <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> object with no padding.
        /// </summary>
        public static readonly Padding Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> class using the supplied padding size for all edges.
        /// </summary>
        ///	<param name="intAll">The number of pixels to be used for padding for all edges.</param>
        public Padding(int intAll)
        {
            int intTemp;
            this.mblnAll = true;
            this.mintBottom = intTemp = intAll;
            this.mintRight = intTemp;
            this.mintLeft = intTemp;
            this.mintTop = intTemp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> class using a separate padding size for each edge.
        /// </summary>
        ///	<param name="intRight">The padding size, in pixels, for the right edge.</param>
        ///	<param name="intBottom">The padding size, in pixels, for the bottom edge.</param>
        ///	<param name="intLeft">The padding size, in pixels, for the left edge.</param>
        ///	<param name="intTop">The padding size, in pixels, for the top edge.</param>
        public Padding(int intLeft, int intTop, int intRight, int intBottom)
        {
            this.mintTop = intTop;
            this.mintLeft = intLeft;
            this.mintRight = intRight;
            this.mintBottom = intBottom;
            this.mblnAll = (!(this.mintTop != this.mintLeft) && !(this.mintTop != this.mintRight)) && (this.mintTop == this.mintBottom);
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
        /// Gets or sets the padding value for the bottom edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the bottom edge.</returns>
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
        /// Gets or sets the padding value for the left edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the left edge.</returns>
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
        /// Gets or sets the padding value for the right edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the right edge.</returns>
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
        /// Gets or sets the padding value for the top edge.
        /// </summary>
        ///	<returns>The padding, in pixels, for the top edge.</returns>
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
        /// Gets the combined padding for the right and left edges.
        /// </summary>
        ///	<returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Left"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Right"></see> padding values.</returns>
        [Browsable(false)]
        public int Horizontal
        {
            get
            {
                return (this.Left + this.Right);
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
                return (this.Top + this.Bottom);
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
                return new System.Drawing.Size(this.Horizontal, this.Vertical);
            }
        }

        /// <summary>
        /// Computes the sum of the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that contains the sum of the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
        ///	<param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
        ///	<param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
        public static Padding Add(Padding objPadding1, Padding objPadding2)
        {
            return (objPadding1 + objPadding2);
        }

        /// <summary>
        /// Subtracts one specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value from another.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that contains the result of the subtraction of one specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value from another.</returns>
        ///	<param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
        ///	<param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
        public static Padding Subtract(Padding objPadding1, Padding objPadding2)
        {
            return (objPadding1 - objPadding2);
        }

        /// <summary>
        /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </summary>
        ///	<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equivalent; otherwise, false.</returns>
        ///	<param name="objOther">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
        public override bool Equals(object objOther)
        {
            if (objOther is Padding)
            {
                Padding objPadding = (Padding)objOther;
                if (((objPadding.mblnAll == this.mblnAll) && (objPadding.mintTop == this.mintTop)) && ((objPadding.mintLeft == this.mintLeft) && (objPadding.mintBottom == this.mintBottom)))
                {
                    return (objPadding.mintRight == this.mintRight);
                }
            }
            return false;
        }

        /// <summary>
        /// Performs vector addition on the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects, resulting in a new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </summary>
        ///	<returns>A new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that results from adding p1 and p2.</returns>
        ///	<param name="objPadding2">The second <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to add.</param>
        ///	<param name="objPadding1">The first <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to add.</param>
        public static Padding operator +(Padding objPadding1, Padding objPadding2)
        {
            return new Padding(objPadding1.Left + objPadding2.Left, objPadding1.Top + objPadding2.Top, objPadding1.Right + objPadding2.Right, objPadding1.Bottom + objPadding2.Bottom);
        }

        /// <summary>
        /// Performs vector subtraction on the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects, resulting in a new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </summary>
        ///	<returns>The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> result of subtracting p2 from p1.</returns>
        ///	<param name="objPadding2">The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to subtract from (the subtrahend).</param>
        ///	<param name="objPadding1">The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to subtract from (the minuend).</param>
        public static Padding operator -(Padding objPadding1, Padding objPadding2)
        {
            return new Padding(objPadding1.Left - objPadding2.Left, objPadding1.Top - objPadding2.Top, objPadding1.Right - objPadding2.Right, objPadding1.Bottom - objPadding2.Bottom);
        }

        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equal; otherwise, false.</returns>
        ///	<param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
        ///	<param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
        public static bool operator ==(Padding objPadding1, Padding objPadding2)
        {
            if (((objPadding1.Left == objPadding2.Left) && (objPadding1.Top == objPadding2.Top)) && (objPadding1.Right == objPadding2.Right))
            {
                return (objPadding1.Bottom == objPadding2.Bottom);
            }
            return false;
        }

        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are not equivalent.
        /// </summary>
        ///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are different; otherwise, false.</returns>
        ///	<param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
        ///	<param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
        public static bool operator !=(Padding objPadding1, Padding objPadding2)
        {
            return !(objPadding1 == objPadding2);
        }

        /// <summary>
        /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer.
        /// </returns>
        public override int GetHashCode()
        {
            return (((this.Left ^ ClientUtils.RotateLeft(this.Top, 8)) ^ ClientUtils.RotateLeft(this.Right, 0x10)) ^ ClientUtils.RotateLeft(this.Bottom, 0x18));
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
        /// </returns>
        public override string ToString()
        {
            string[] arrText = new string[] { "{Left=", this.Left.ToString(), ",Top=", this.Top.ToString(), ",Right=", this.Right.ToString(), ",Bottom=", this.Bottom.ToString(), "}" };
            return string.Concat(arrText);
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
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> class using the supplied padding size for all edges.
        /// </summary>
        static Padding()
        {
            Padding.Empty = new Padding(0);
        }
    }

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class PaddingConverter : TypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
        /// </summary>
        public PaddingConverter()
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
        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {

            // If value is string
            if (objValue is string)
            {
                // Get value as string
                string strValue = (string)objValue;

                // If is valid string value
                if (!string.IsNullOrEmpty(strValue))
                {
                    // Get value as string array
                    string[] arrValues = strValue.Split(',');

                    // If is an 'all' string
                    if (arrValues.Length == 1)
                    {
                        return new Padding(int.Parse(arrValues[0]));
                    }

                    // If is a full padding definition
                    if (arrValues.Length == 4)
                    {
                        return new Padding(int.Parse(arrValues[0]), int.Parse(arrValues[1]), int.Parse(arrValues[2]), int.Parse(arrValues[3]));
                    }
                }
            }

            return base.ConvertFrom(objContext, objCulture, objValue);
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
        /// <exception cref="T:System.ArgumentNullException">The destinationType parameter is null. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {

            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            bool blnIsHandled = false;
            blnIsHandled |= ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is Padding));
            blnIsHandled |= ((objDestinationType == typeof(string)) && (objValue is Padding));

            // If convertion is handled
            if (blnIsHandled)
            {
                Padding objPadding = (Padding)objValue;

                // If is convert to string
                if (objDestinationType == typeof(string))
                {
                    if (objPadding.IsAll)
                    {
                        return objPadding.All.ToString();
                    }
                    else
                    {
                        return string.Format("{0}, {1}, {2}, {3}", objPadding.Left, objPadding.Top, objPadding.Right, objPadding.Bottom);
                    }
                }
                // If is convert to instance descriptor
                else if (objDestinationType == typeof(InstanceDescriptor))
                {
                    //convert to InstanceDescriptor
                    return ConvertToInstanceDescriptor(objContext, objPadding);
                }
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, Padding objPadding)
        {
            Type[] typeArray1;
            object[] objArray1;

            if (objPadding.ShouldSerializeAll())
            {
                typeArray1 = new Type[] { typeof(int) };
                objArray1 = new object[] { objPadding.All };
                return new InstanceDescriptor(typeof(Padding).GetConstructor(typeArray1), objArray1);
            }

            typeArray1 = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) };
            objArray1 = new object[] { objPadding.Left, objPadding.Top, objPadding.Right, objPadding.Bottom };

            return new InstanceDescriptor(typeof(Padding).GetConstructor(typeArray1), objArray1);
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
            Padding objPadding = (Padding)objContext.PropertyDescriptor.GetValue(objContext.Instance);
            int num1 = (int)objPropertyValues["All"];
            if (objPadding.All != num1)
            {
                return new Padding(num1);
            }
            return new Padding((int)objPropertyValues["Left"], (int)objPropertyValues["Top"], (int)objPropertyValues["Right"], (int)objPropertyValues["Bottom"]);
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
            PropertyDescriptorCollection objCollection1 = TypeDescriptor.GetProperties(typeof(Padding), arrAttributes);
            string[] arrText = new string[] { "All", "Left", "Top", "Right", "Bottom" };
            return objCollection1.Sort(arrText);
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
}