// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SelectionRangeConverter
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
  /// 
  /// </summary>
  public class SelectionRangeConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => sourceType == typeof (string) || sourceType == typeof (DateTime) || base.CanConvertFrom(context, sourceType);

    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (InstanceDescriptor) || destinationType == typeof (DateTime) || base.CanConvertTo(context, destinationType);

    /// <summary>
    /// Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
    /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      switch (value)
      {
        case string _:
          string str = ((string) value).Trim();
          if (str.Length == 0)
          {
            DateTime now = DateTime.Now;
            DateTime date1 = now.Date;
            now = DateTime.Now;
            DateTime date2 = now.Date;
            return (object) new SelectionRange(date1, date2);
          }
          if (culture == null)
            culture = CultureInfo.CurrentCulture;
          char ch = culture.TextInfo.ListSeparator[0];
          string[] strArray = str.Split(ch);
          if (strArray.Length != 2)
            throw new ArgumentException(SR.GetString("TextParseFailedFormat", (object) str, (object) ("Start" + ch.ToString() + " End")));
          TypeConverter converter = TypeDescriptor.GetConverter(typeof (DateTime));
          return (object) new SelectionRange((DateTime) converter.ConvertFromString(context, culture, strArray[0]), (DateTime) converter.ConvertFromString(context, culture, strArray[1]));
        case DateTime dateTime:
          return (object) new SelectionRange(dateTime, dateTime);
        default:
          return base.ConvertFrom(context, culture, value);
      }
    }

    /// <summary>
    /// Converts the given value object to the specified type, using the specified context and culture information.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
    /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
    /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType" /> parameter is null. </exception>
    /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType == (Type) null)
        throw new ArgumentNullException(nameof (destinationType));
      if (value is SelectionRange selectionRange)
      {
        if (destinationType == typeof (string))
        {
          if (culture == null)
            culture = CultureInfo.CurrentCulture;
          string separator = culture.TextInfo.ListSeparator + " ";
          PropertyDescriptorCollection properties = this.GetProperties(value);
          string[] strArray = new string[properties.Count];
          for (int index = 0; index < properties.Count; ++index)
          {
            object component = properties[index].GetValue(value);
            strArray[index] = TypeDescriptor.GetConverter(component).ConvertToString(context, culture, component);
          }
          return (object) string.Join(separator, strArray);
        }
        if (destinationType == typeof (DateTime))
          return (object) selectionRange.Start;
        if (destinationType == typeof (InstanceDescriptor))
        {
          ConstructorInfo constructor = typeof (SelectionRange).GetConstructor(new Type[2]
          {
            typeof (DateTime),
            typeof (DateTime)
          });
          if (constructor != (ConstructorInfo) null)
            return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[2]
            {
              (object) selectionRange.Start,
              (object) selectionRange.End
            });
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>
    /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter" /> is associated with, using the specified context, given a set of property values for the object.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary" /> of new property values.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> representing the given <see cref="T:System.Collections.IDictionary" />, or null if the object cannot be created. This method always returns null.
    /// </returns>
    public override object CreateInstance(
      ITypeDescriptorContext context,
      IDictionary propertyValues)
    {
      try
      {
        return (object) new SelectionRange((DateTime) propertyValues[(object) "Start"], (DateTime) propertyValues[(object) "End"]);
      }
      catch (InvalidCastException ex)
      {
        throw new ArgumentException(SR.GetString("PropertyValueInvalidEntry"), (Exception) ex);
      }
      catch (NullReferenceException ex)
      {
        throw new ArgumentException(SR.GetString("PropertyValueInvalidEntry"), (Exception) ex);
      }
    }

    /// <summary>
    /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.
    /// </returns>
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => true;

    /// <summary>
    /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
    /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
    /// </returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext context,
      object value,
      Attribute[] attributes)
    {
      return TypeDescriptor.GetProperties(typeof (SelectionRange), attributes).Sort(new string[2]
      {
        "Start",
        "End"
      });
    }

    /// <summary>
    /// Returns whether this object supports properties, using the specified context.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
    /// </returns>
    public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
  }
}
