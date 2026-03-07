// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PaddingConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
  /// </summary>
  [Serializable]
  public class PaddingConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || objDestinationType == typeof (string) || base.CanConvertTo(objContext, objDestinationType);

    /// <summary>
    /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objSourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) || base.CanConvertFrom(objContext, objSourceType);

    /// <summary>
    /// Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
    /// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
    public override object ConvertFrom(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue)
    {
      if (objValue is string)
      {
        string str = (string) objValue;
        if (!string.IsNullOrEmpty(str))
        {
          string[] strArray = str.Split(',');
          if (strArray.Length == 1)
            return (object) new Padding(int.Parse(strArray[0]));
          if (strArray.Length == 4)
            return (object) new Padding(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
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
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException("destinationType");
      if ((0 | (!(objDestinationType == typeof (InstanceDescriptor)) ? 0 : (objValue is Padding ? 1 : 0)) | (!(objDestinationType == typeof (string)) ? 0 : (objValue is Padding ? 1 : 0))) != 0)
      {
        Padding objPadding = (Padding) objValue;
        if (objDestinationType == typeof (string))
        {
          if (objPadding.IsAll)
            return (object) objPadding.All.ToString();
          return (object) string.Format("{0}, {1}, {2}, {3}", (object) objPadding.Left, (object) objPadding.Top, (object) objPadding.Right, (object) objPadding.Bottom);
        }
        if (objDestinationType == typeof (InstanceDescriptor))
          return this.ConvertToInstanceDescriptor(objContext, objPadding);
      }
      return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(
      ITypeDescriptorContext objContext,
      Padding objPadding)
    {
      if (objPadding.ShouldSerializeAll())
      {
        Type[] types = new Type[1]{ typeof (int) };
        object[] arguments = new object[1]
        {
          (object) objPadding.All
        };
        return (object) new InstanceDescriptor((MemberInfo) typeof (Padding).GetConstructor(types), (ICollection) arguments);
      }
      Type[] types1 = new Type[4]
      {
        typeof (int),
        typeof (int),
        typeof (int),
        typeof (int)
      };
      object[] arguments1 = new object[4]
      {
        (object) objPadding.Left,
        (object) objPadding.Top,
        (object) objPadding.Right,
        (object) objPadding.Bottom
      };
      return (object) new InstanceDescriptor((MemberInfo) typeof (Padding).GetConstructor(types1), (ICollection) arguments1);
    }

    /// <summary>
    /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
    /// <returns>
    /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
    /// </returns>
    public override object CreateInstance(
      ITypeDescriptorContext objContext,
      IDictionary objPropertyValues)
    {
      Padding padding = (Padding) objContext.PropertyDescriptor.GetValue(objContext.Instance);
      int objPropertyValue = (int) objPropertyValues[(object) "All"];
      return padding.All != objPropertyValue ? (object) new Padding(objPropertyValue) : (object) new Padding((int) objPropertyValues[(object) "Left"], (int) objPropertyValues[(object) "Top"], (int) objPropertyValues[(object) "Right"], (int) objPropertyValues[(object) "Bottom"]);
    }

    /// <summary>
    /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <returns>
    /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
    /// </returns>
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext) => true;

    /// <summary>
    /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
    /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
    /// </returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objValue,
      Attribute[] arrAttributes)
    {
      return TypeDescriptor.GetProperties(typeof (Padding), arrAttributes).Sort(new string[5]
      {
        "All",
        "Left",
        "Top",
        "Right",
        "Bottom"
      });
    }

    /// <summary>
    /// Returns whether this object supports properties, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
    /// </returns>
    public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;
  }
}
