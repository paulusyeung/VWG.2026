// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewGroupConverter
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
  /// <summary>Provides a convertion for the listviewgroup class</summary>
  /// <remarks>This converter causes the group the appear as a list selector of groups in the designer.</remarks>
  public class ListViewGroupConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objSourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) && objContext != null && objContext.Instance is ListViewItem || base.CanConvertFrom(objContext, objSourceType);

    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || objDestinationType == typeof (string) && objContext != null && objContext.Instance is ListViewItem || base.CanConvertTo(objContext, objDestinationType);

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
        string str = ((string) objValue).Trim();
        if (objContext != null && objContext.Instance != null && objContext.Instance is ListViewItem instance && instance.ListView != null)
        {
          foreach (ListViewGroup group in instance.ListView.Groups)
          {
            if (group.Header == str)
              return (object) group;
          }
        }
      }
      return objValue != null && !objValue.Equals((object) SR.GetString("toStringNone")) ? base.ConvertFrom(objContext, objCulture, objValue) : (object) null;
    }

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
    /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType" /> parameter is null. </exception>
    /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException("destinationType");
      if (objDestinationType == typeof (InstanceDescriptor) && objValue is ListViewGroup)
      {
        object instanceDescriptor = this.ConvertToInstanceDescriptor(objContext, objValue);
        if (instanceDescriptor != null)
          return instanceDescriptor;
      }
      return objDestinationType == typeof (string) && objValue == null ? (object) SR.GetString("toStringNone") : base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
    {
      ListViewGroup listViewGroup = (ListViewGroup) objValue;
      ConstructorInfo constructor = typeof (ListViewGroup).GetConstructor(new Type[2]
      {
        typeof (string),
        typeof (HorizontalAlignment)
      });
      if (!(constructor != (ConstructorInfo) null))
        return (object) null;
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[2]
      {
        (object) listViewGroup.Header,
        (object) listViewGroup.HeaderAlignment
      }, false);
    }

    /// <summary>
    /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
    /// </returns>
    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext objContext)
    {
      if (objContext == null || objContext.Instance == null || !(objContext.Instance is ListViewItem instance) || instance.ListView == null)
        return (TypeConverter.StandardValuesCollection) null;
      ArrayList values = new ArrayList();
      foreach (ListViewGroup group in instance.ListView.Groups)
        values.Add((object) group);
      values.Add((object) null);
      return new TypeConverter.StandardValuesCollection((ICollection) values);
    }

    /// <summary>
    /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exclusive list of possible values, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exhaustive list of possible values; false if other values are possible.
    /// </returns>
    public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext) => true;

    /// <summary>
    /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> should be called to find a common set of values the object supports; otherwise, false.
    /// </returns>
    public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext) => true;
  }
}
