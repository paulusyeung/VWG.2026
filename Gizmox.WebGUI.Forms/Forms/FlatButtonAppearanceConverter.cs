// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FlatButtonAppearanceConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public class FlatButtonAppearanceConverter : ExpandableObjectConverter
  {
    /// <summary>
    /// Converts the given value object to the specified type, using the specified context and culture information.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
    /// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
    /// <param name="objDestinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="objDestinationType" /> parameter is null.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The conversion cannot be performed.
    /// </exception>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      return objDestinationType == typeof (string) ? (object) "" : base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>
    /// Gets a collection of properties for the type of object specified by the value parameter.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objValue">An <see cref="T:System.Object" /> that specifies the type of object to get the properties for.</param>
    /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute" /> that will be used as a filter.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for the component, or null if there are no properties.
    /// </returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objValue,
      Attribute[] arrAttributes)
    {
      return TypeDescriptor.GetProperties(objValue);
    }
  }
}
