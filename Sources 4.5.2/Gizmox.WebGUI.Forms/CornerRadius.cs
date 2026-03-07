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
    /// <summary>
    /// Represents corner information associated with a user interface (UI) element.
    /// </summary>
    [StructLayout(LayoutKind.Sequential), TypeConverter(typeof(CornerRadiusConverter))]
    [EditorBrowsable(EditorBrowsableState.Never), Serializable()]
    public struct CornerRadius
    {
        private bool mblnAll;
        private int mintTopLeft;
        private int mintBottomLeft;
        private int mintTopRight;
        private int mintBottomRight;

        /// <summary>
        /// Provides a <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> object with no corner.
        /// </summary>
        public static readonly CornerRadius Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using the supplied corner size for all edges.
        /// </summary>
        ///	<param name="intAll">The number of pixels to be used for corner for all edges.</param>
        public CornerRadius(int intAll)
        {
            this.mblnAll = true;
            this.mintBottomRight = intAll;
            this.mintTopRight = intAll;
            this.mintBottomLeft = intAll;
            this.mintTopLeft = intAll;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using a separate corner size for each edge.
        /// </summary>
        ///	<param name="topLeft">The corner size, in pixels, for the top left edge.</param>
        ///	<param name="topRight">The corner size, in pixels, for the top right edge.</param>
        ///	<param name="intBottomRight">The corner size, in pixels, for the bottom right edge.</param>
        ///	<param name="intBottomLeft">The corner size, in pixels, for the bottom left edge.</param>
        public CornerRadius(int topLeft, int topRight, int intBottomRight, int intBottomLeft)
        {
            this.mintTopLeft = topLeft;
            this.mintBottomLeft = intBottomLeft;
            this.mintTopRight = topRight;
            this.mintBottomRight = intBottomRight;
            this.mblnAll = (!(this.mintTopLeft != this.mintBottomLeft) && !(this.mintTopLeft != this.mintTopRight)) && (this.mintTopLeft == this.mintBottomRight);
        }
        /// <summary>
        /// Gets or sets the corner value for all the edges.
        /// </summary>
        /// <returns>The corner, in pixels, for all edges if the same; otherwise, -1.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                if (!this.mblnAll)
                {
                    return -1;
                }
                return this.mintTopLeft;
            }
            set
            {
                if (!this.mblnAll || (this.mintTopLeft != value))
                {
                    int intTemp;
                    this.mblnAll = true;
                    this.mintBottomRight = intTemp = value;
                    this.mintTopRight = intTemp;
                    this.mintBottomLeft = intTemp;
                    this.mintTopLeft = intTemp;
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
        /// Gets or sets the corner value for the bottom right corner.
        /// </summary>
        ///	<returns>The corner, in pixels, for the bottom right corner.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int BottomRight
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTopLeft;
                }
                return this.mintBottomRight;
            }
            set
            {
                if (this.mblnAll || (this.mintBottomRight != value))
                {
                    this.mblnAll = false;
                    this.mintBottomRight = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the corner value for the bottom left corner.
        /// </summary>
		///	<returns>The corner, in pixels, for the bottom left corner.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int BottomLeft
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTopLeft;
                }
                return this.mintBottomLeft;
            }
            set
            {
                if (this.mblnAll || (this.mintBottomLeft != value))
                {
                    this.mblnAll = false;
                    this.mintBottomLeft = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the corner value for the top right corner.
        /// </summary>
		///	<returns>The corner, in pixels, for the top right corner.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int TopRight
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintTopLeft;
                }
                return this.mintTopRight;
            }
            set
            {
                if (this.mblnAll || (this.mintTopRight != value))
                {
                    this.mblnAll = false;
                    this.mintTopRight = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the corner value for the top left corner.
        /// </summary>
        ///	<returns>The corner, in pixels, for the top left corner.</returns>
        [RefreshProperties(RefreshProperties.All)]
        public int TopLeft
        {
            get
            {
                return this.mintTopLeft;
            }
            set
            {
                if (this.mblnAll || (this.mintTopLeft != value))
                {
                    this.mblnAll = false;
                    this.mintTopLeft = value;
                }
            }
        }



        /// <summary>
        /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
        /// </summary>
		///	<returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent; otherwise, false.</returns>
		///	<param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.</param>
        public override bool Equals(object other)
        {
            if (other is CornerRadius)
            {
                CornerRadius corner1 = (CornerRadius) other;
                if (((corner1.mblnAll == this.mblnAll) && (corner1.mintTopLeft == this.mintTopLeft)) && ((corner1.mintBottomLeft == this.mintBottomLeft) && (corner1.mintBottomRight == this.mintBottomRight)))
                {
                    return (corner1.mintTopRight == this.mintTopRight);
                }
            }
            return false;
        }

        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent.
        /// </summary>
		///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equal; otherwise, false.</returns>
        ///	<param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
        ///	<param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
        public static bool operator ==(CornerRadius objRadius1, CornerRadius objRadius2)
        {
            if (((objRadius1.BottomLeft == objRadius2.BottomLeft) && (objRadius1.TopLeft == objRadius2.TopLeft)) && (objRadius1.TopRight == objRadius2.TopRight))
            {
                return (objRadius1.BottomRight == objRadius2.BottomRight);
            }
            return false;
        }
        /// <summary>
        /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are not equivalent.
        /// </summary>
		///	<returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are different; otherwise, false.</returns>
        ///	<param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
        ///	<param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
        public static bool operator !=(CornerRadius objRadius1, CornerRadius objRadius2)
        {
            return !(objRadius1 == objRadius2);
        }
        /// <summary>
        /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer.
        /// </returns>
        public override int GetHashCode()
        {
            return (((this.BottomLeft ^ ClientUtils.RotateLeft(this.TopLeft, 8)) ^ ClientUtils.RotateLeft(this.TopRight, 0x10)) ^ ClientUtils.RotateLeft(this.BottomRight, 0x18));
        }
        /// <summary>
        /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
        /// </returns>
        public override string ToString()
        {
            string[] arrText = new string[] { "{TopLeft=", this.TopLeft.ToString(), ",TopRight=", this.TopRight.ToString(), ",BottomRight=", this.BottomRight.ToString(), ",BottomLeft=", this.BottomLeft.ToString(), "}" };
            return string.Concat(arrText);
        }
        private void ResetAll()
        {
            this.All = 0;
        }
        private void ResetBottomRight()
        {
            this.BottomRight = 0;
        }
        private void ResetBottomLeft()
        {
            this.BottomLeft = 0;
        }
        private void ResetTopRight()
        {
            this.TopRight = 0;
        }
        private void ResetTopLeft()
        {
            this.TopLeft = 0;
        }
        internal void Scale(float fltX, float fltY)
        {
            this.mintTopLeft = (int) (this.mintTopLeft * fltY);
            this.mintBottomLeft = (int) (this.mintBottomLeft * fltX);
            this.mintTopRight = (int) (this.mintTopRight * fltX);
            this.mintBottomRight = (int) (this.mintBottomRight * fltY);
        }
        internal bool ShouldSerializeAll()
        {
            return this.mblnAll;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using the supplied corner size for all edges.
        /// </summary>
        static CornerRadius()
        {
            CornerRadius.Empty = new CornerRadius(0);
        }
    }



    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> values to and from various other representations.
    /// </summary>
    [Serializable()]
    public class CornerRadiusConverter : TypeConverter
    {
        /// <summary>
        /// Provides a SkinValue implementation of corner
        /// </summary>
        [Serializable()]
        internal class CornerRadiusSkinValue : Skins.SkinValue
        {
            /// <summary>
            /// 
            /// </summary>
            private CornerRadius mobjValue;

            /// <summary>
            /// Initializes a new instance of the <see cref="CornerRadiusSkinValue"/> class.
            /// </summary>
            /// <param name="objValue">The corner value.</param>
            public CornerRadiusSkinValue(CornerRadius objValue)
            {
                mobjValue = objValue;
            }

            public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
            {
                if (mobjValue.IsAll)
                {
                    return string.Format("{0}", mobjValue.All);
                }
                else
                {
                    return string.Format("{0} {1} {2} {3}", mobjValue.TopLeft, mobjValue.TopRight, mobjValue.BottomRight, mobjValue.BottomLeft);
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CornerConverter"></see> class. 
        /// </summary>
        public CornerRadiusConverter()
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
        /// <exception cref="T:System.ArgumentNullException">The destinationType parameter is null. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (objDestinationType == typeof(Skins.SkinValue))
            {
                return new CornerRadiusSkinValue((CornerRadius)objValue);
            }
            if (objDestinationType == typeof(InstanceDescriptor) && (objValue is CornerRadius))
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
            Type[] arrTypes;
            object[] arrObjects1;

            CornerRadius corner1 = (CornerRadius)objValue;
            if (corner1.ShouldSerializeAll())
            {
                arrTypes = new Type[] { typeof(int) };
                arrObjects1 = new object[] { corner1.All };
                return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(arrTypes), arrObjects1);
            }
            arrTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) };
            arrObjects1 = new object[] { corner1.TopLeft, corner1.TopRight, corner1.BottomRight, corner1.BottomLeft };
            return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(arrTypes), arrObjects1);
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
            CornerRadius corner1 = (CornerRadius) objContext.PropertyDescriptor.GetValue(objContext.Instance);
            int num1 = (int) objPropertyValues["All"];
            if (corner1.All != num1)
            {
                return new CornerRadius(num1);
            }
            return new CornerRadius((int) objPropertyValues["TopLeft"], (int) objPropertyValues["TopRight"], (int) objPropertyValues["BottomRight"], (int) objPropertyValues["BottomLeft"]);
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
            PropertyDescriptorCollection objCollection1 = TypeDescriptor.GetProperties(typeof(CornerRadius), arrAttributes);
            string[] arrText = new string[] { "All", "TopLeft", "TopRight", "BottomRight", "BottomLeft" };
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

