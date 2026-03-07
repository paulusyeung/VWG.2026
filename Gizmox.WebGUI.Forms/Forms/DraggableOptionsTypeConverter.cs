// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DraggableOptionsTypeConverter
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
  public class DraggableOptionsTypeConverter : TypeConverter
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
          string[] strArray = ((string) value).Split('|');
          if (strArray.Length != 9)
            return (object) new DraggableOptions(false);
          DraggableOptions draggableOptions = new DraggableOptions(strArray[0] == "1");
          draggableOptions.SnapTo = (SnapTo) int.Parse(strArray[1]);
          draggableOptions.SnapMode = (SnapMode) int.Parse(strArray[2]);
          draggableOptions.Xgrid = int.Parse(strArray[3]);
          draggableOptions.Ygrid = int.Parse(strArray[4]);
          draggableOptions.SnapTolerance = int.Parse(strArray[5]);
          draggableOptions.RevertMode = (RevertMode) int.Parse(strArray[6]);
          draggableOptions.RevertDuration = int.Parse(strArray[7]);
          draggableOptions.AllowNegativeAxes = bool.Parse(strArray[8]);
          return (object) draggableOptions;
        case bool blnIsDraggable:
          return (object) new DraggableOptions(blnIsDraggable);
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
      if (!(value is DraggableOptions draggableOptions))
        return (object) null;
      object[] arguments;
      Type[] types;
      if (draggableOptions.IsDefault())
      {
        arguments = new object[1]
        {
          (object) draggableOptions.IsDraggable
        };
        types = new Type[1]
        {
          draggableOptions.IsDraggable.GetType()
        };
      }
      else
      {
        arguments = new object[9]
        {
          (object) draggableOptions.IsDraggable,
          (object) draggableOptions.SnapTo,
          (object) draggableOptions.SnapMode,
          (object) draggableOptions.SnapTolerance,
          (object) draggableOptions.RevertMode,
          (object) draggableOptions.RevertDuration,
          (object) draggableOptions.Xgrid,
          (object) draggableOptions.Ygrid,
          (object) draggableOptions.AllowNegativeAxes
        };
        types = new Type[9]
        {
          draggableOptions.IsDraggable.GetType(),
          draggableOptions.SnapTo.GetType(),
          draggableOptions.SnapMode.GetType(),
          draggableOptions.SnapTolerance.GetType(),
          draggableOptions.RevertMode.GetType(),
          draggableOptions.RevertDuration.GetType(),
          draggableOptions.Xgrid.GetType(),
          draggableOptions.Ygrid.GetType(),
          draggableOptions.AllowNegativeAxes.GetType()
        };
      }
      return (object) new InstanceDescriptor((MemberInfo) typeof (DraggableOptions).GetConstructor(types), (ICollection) arguments);
    }

    /// <summary>converts the object to string.</summary>
    /// <param name="objContext"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private new string ConvertToString(ITypeDescriptorContext objContext, object value) => value is DraggableOptions draggableOptions ? draggableOptions.ToString() : "";

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
      return TypeDescriptor.GetProperties(value);
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
