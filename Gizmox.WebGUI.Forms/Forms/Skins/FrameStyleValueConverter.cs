// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.FrameStyleValueConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class FrameStyleValueConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (string) || base.CanConvertTo(objContext, objDestinationType);

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
    /// Returns whether this object supports properties, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
    /// </returns>
    public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;

    /// <summary>
    /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objValue">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
    /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
    /// </returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objValue,
      Attribute[] arrAttributes)
    {
      return TypeDescriptor.GetProperties(typeof (FrameStyleValue), arrAttributes).Sort(new string[9]
      {
        "LeftBottomStyle",
        "LeftStyle",
        "LeftTopStyle",
        "TopStyle",
        "RightTopStyle",
        "RightStyle",
        "RightBottomStyle",
        "BottomStyle",
        "CenterStyle"
      });
    }
  }
}
