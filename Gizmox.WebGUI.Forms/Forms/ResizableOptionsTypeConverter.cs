// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ResizableOptionsTypeConverter
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
  /// <summary>Type converter for the draggable option object.</summary>
  [Serializable]
  public class ResizableOptionsTypeConverter : TypeConverter
  {
    /// <summary>
    /// Converts the specified objValue object to an enumeration object.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="destinationType">Type of the destination.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can convert from] the specified context; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (string) || destinationType == typeof (bool) || base.CanConvertFrom(context, destinationType);

    /// <summary>
    /// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (InstanceDescriptor) || destinationType == typeof (string) || base.CanConvertTo(context, destinationType);

    /// <summary>converts from string to the object.</summary>
    /// <param name="objContext"></param>
    /// <param name="culture"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      switch (value)
      {
        case string _:
          ResizableOptions resizableOptions = new ResizableOptions();
          resizableOptions.ConvertFromString((string) value);
          return (object) resizableOptions;
        case bool blnIsResizable:
          return (object) new ResizableOptions(blnIsResizable);
        default:
          return base.ConvertFrom(context, culture, value);
      }
    }

    /// <summary>
    /// Converts the given objValue object to the specified destination type.
    /// </summary>
    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType == (Type) null)
        throw new ArgumentNullException("objDestinationType");
      if (destinationType == typeof (InstanceDescriptor))
      {
        object instanceDescriptor = this.ConvertToInstanceDescriptor(context, value);
        if (instanceDescriptor != null)
          return instanceDescriptor;
      }
      else if (destinationType == typeof (string))
        return (object) this.ConvertToString(context, value);
      return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>gives the InstanceDescriptor of the object</summary>
    /// <param name="objContext"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
    {
      if (!(value is ResizableOptions resizableOptions))
        return (object) null;
      object[] arguments;
      Type[] types;
      if (resizableOptions.IsDefault())
      {
        arguments = new object[1]
        {
          (object) resizableOptions.IsResizable
        };
        types = new Type[1]
        {
          resizableOptions.IsResizable.GetType()
        };
      }
      else
      {
        arguments = new object[10]
        {
          (object) resizableOptions.IsResizable,
          (object) resizableOptions.AlsoResize,
          (object) resizableOptions.Animate,
          (object) resizableOptions.AnimateDuration,
          (object) resizableOptions.AspectRatio,
          (object) resizableOptions.AutoHide,
          (object) resizableOptions.ContainmentMode,
          (object) resizableOptions.Ghost,
          (object) resizableOptions.Xgrid,
          (object) resizableOptions.Ygrid
        };
        types = new Type[10]
        {
          resizableOptions.IsResizable.GetType(),
          resizableOptions.AlsoResize.GetType(),
          resizableOptions.Animate.GetType(),
          resizableOptions.AnimateDuration.GetType(),
          resizableOptions.AspectRatio.GetType(),
          resizableOptions.AutoHide.GetType(),
          resizableOptions.ContainmentMode.GetType(),
          resizableOptions.Ghost.GetType(),
          resizableOptions.Xgrid.GetType(),
          resizableOptions.Ygrid.GetType()
        };
      }
      return (object) new InstanceDescriptor((MemberInfo) typeof (ResizableOptions).GetConstructor(types), (ICollection) arguments);
    }

    /// <summary>converts the object to string.</summary>
    /// <param name="objContext"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private new string ConvertToString(ITypeDescriptorContext objContext, object value) => value is ResizableOptions resizableOptions ? resizableOptions.ToString() : "";

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
      return TypeDescriptor.GetProperties(value, attributes);
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
