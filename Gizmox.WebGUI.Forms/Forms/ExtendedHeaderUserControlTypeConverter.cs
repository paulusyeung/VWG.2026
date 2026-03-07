// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ExtendedHeaderUserControlTypeConverter
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
  /// ExtendedHeaderUserControl Convertor.
  /// Used to manage Designer feature for the object. e.g. Display filtered properties on PropertyGrid by User Control cell type
  /// </summary>
  public class ExtendedHeaderUserControlTypeConverter : TypeConverter
  {
    /// <summary>
    /// Determines whether this instance [can convert to] the specified context.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="objDestinationType">Type of the obj destination.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(context, objDestinationType);

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
      if (destinationType == typeof (InstanceDescriptor) && value is ExtendedHeaderUserControl)
      {
        ConstructorInfo constructor = value.GetType().GetConstructor(new Type[0]);
        if (constructor != (ConstructorInfo) null)
          return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[0]);
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>
    /// Returns whether this object supports properties, using the specified context.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
    /// </returns>
    public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;

    /// <summary>Gets the properties.</summary>
    /// <param name="context">The context.</param>
    /// <param name="objValue">The obj value.</param>
    /// <param name="attributes">The attributes.</param>
    /// <returns></returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext context,
      object objValue,
      Attribute[] attributes)
    {
      if (objValue is ExtendedHeaderUserControl)
      {
        PropertyDescriptorCollection properties1 = TypeDescriptor.GetProperties(objValue.GetType(), attributes);
        PropertyDescriptor propertyDescriptor1 = properties1["ExtendedHeaderCellType"];
        if (propertyDescriptor1 != null)
        {
          ExtendedHeaderCellType extendedHeaderCellType = (ExtendedHeaderCellType) propertyDescriptor1.GetValue(objValue);
          PropertyDescriptorCollection properties2 = new PropertyDescriptorCollection((PropertyDescriptor[]) null);
          foreach (PropertyDescriptor propertyDescriptor2 in properties1)
          {
            if (propertyDescriptor2.Name == "ColSpan" || propertyDescriptor2.Name == "ColIndex")
            {
              switch (extendedHeaderCellType)
              {
                case ExtendedHeaderCellType.Headers:
                  properties2.Add(propertyDescriptor2);
                  continue;
                default:
                  continue;
              }
            }
            else
              properties2.Add(propertyDescriptor2);
          }
          return properties2;
        }
      }
      return (PropertyDescriptorCollection) null;
    }
  }
}
