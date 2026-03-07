// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.PaddingValueConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
  /// </summary>
  [Serializable]
  public class PaddingValueConverter : TypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (string) || base.CanConvertTo(objContext, objDestinationType);

    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) || base.CanConvertFrom(objContext, objSourceType);

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
            return (object) new PaddingValue(new Padding(int.Parse(strArray[0])));
          if (strArray.Length == 4)
            return (object) new PaddingValue(new Padding(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3])));
        }
      }
      return base.ConvertFrom(objContext, objCulture, objValue);
    }

    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (!(objDestinationType == typeof (string)) || !(objValue is PaddingValue paddingValue))
        return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
      if (paddingValue.All != -1)
        return (object) paddingValue.All.ToString();
      return (object) string.Format("{0}, {1}, {2}, {3}", (object) paddingValue.Left, (object) paddingValue.Top, (object) paddingValue.Right, (object) paddingValue.Bottom);
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
      PaddingValue paddingValue = (PaddingValue) objContext.PropertyDescriptor.GetValue(objContext.Instance);
      int objPropertyValue = (int) objPropertyValues[(object) "All"];
      Padding padding = paddingValue.All == objPropertyValue ? new Padding((int) objPropertyValues[(object) "Left"], (int) objPropertyValues[(object) "Top"], (int) objPropertyValues[(object) "Right"], (int) objPropertyValues[(object) "Bottom"]) : new Padding(objPropertyValue);
      return Activator.CreateInstance(paddingValue.GetType(), (object) padding);
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
      return TypeDescriptor.GetProperties(typeof (PaddingValue), arrAttributes).Sort(new string[5]
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
