// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CursorConverter
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
  /// <summary>Provides a type converter to convert <see cref="T:System.Windows.Forms.Cursor"></see> objects to and from various other representations.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class CursorConverter : TypeConverter
  {
    [NonSerialized]
    private TypeConverter.StandardValuesCollection mobjValues;

    /// <summary>Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
    /// <returns>true if this object can perform the conversion.</returns>
    /// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
    /// <param name="objSourceType">The type you wish to convert from. </param>
    /// <filterpriority>1</filterpriority>
    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => !(objSourceType != typeof (string)) || !(objSourceType != typeof (byte[])) || base.CanConvertFrom(objContext, objSourceType);

    /// <summary>Gets a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
    /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context. </param>
    /// <param name="objDestinationType">A <see cref="T:System.Type"></see> that represents the type you wish to convert to. </param>
    /// <filterpriority>1</filterpriority>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => !(objDestinationType != typeof (InstanceDescriptor)) || !(objDestinationType != typeof (byte[])) || base.CanConvertTo(objContext, objDestinationType);

    /// <filterpriority>1</filterpriority>
    public override object ConvertFrom(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue)
    {
      if (objValue is string)
      {
        string strB = ((string) objValue).Trim();
        foreach (PropertyInfo property in this.GetProperties())
        {
          if (ClientUtils.IsEquals(property.Name, strB, StringComparison.OrdinalIgnoreCase))
          {
            object[] index = (object[]) null;
            return property.GetValue((object) null, index);
          }
        }
      }
      return base.ConvertFrom(objContext, objCulture, objValue);
    }

    /// <filterpriority>1</filterpriority>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException("destinationType");
      if (objDestinationType == typeof (string) && objValue != null)
      {
        PropertyInfo[] properties = this.GetProperties();
        int index1 = -1;
        for (int index2 = 0; index2 < properties.Length; ++index2)
        {
          PropertyInfo propertyInfo = properties[index2];
          object[] index3 = (object[]) null;
          Cursor cursor = (Cursor) propertyInfo.GetValue((object) null, index3);
          if (cursor == (Cursor) objValue)
          {
            if ((object) cursor == objValue)
              return (object) propertyInfo.Name;
            index1 = index2;
          }
        }
        if (index1 == -1)
          throw new FormatException(SR.GetString("CursorCannotCovertToString"));
        return (object) properties[index1].Name;
      }
      if (objDestinationType == typeof (InstanceDescriptor) && (object) (objValue as Cursor) != null)
        return this.ConvertToInstanceDescriptor(objContext, objValue);
      return objDestinationType != typeof (byte[]) ? base.ConvertTo(objContext, objCulture, objValue, objDestinationType) : (object) new byte[0];
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
    {
      foreach (PropertyInfo property in this.GetProperties())
      {
        if (property.GetValue((object) null, (object[]) null) == objValue)
          return (object) new InstanceDescriptor((MemberInfo) property, (ICollection) null);
      }
      return (object) new byte[0];
    }

    private PropertyInfo[] GetProperties() => typeof (Cursors).GetProperties(BindingFlags.Static | BindingFlags.Public);

    /// <summary>Retrieves a collection containing a set of standard values for the data type this validator is designed for. This will return null if the data type does not support a standard set of values.</summary>
    /// <returns>A collection containing a standard set of valid values, or null. The default implementation always returns null.</returns>
    /// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
    /// <filterpriority>1</filterpriority>
    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext objContext)
    {
      if (this.mobjValues == null)
      {
        ArrayList arrayList = new ArrayList();
        foreach (PropertyInfo property in this.GetProperties())
        {
          object[] index = (object[]) null;
          arrayList.Add(property.GetValue((object) null, index));
        }
        this.mobjValues = new TypeConverter.StandardValuesCollection((ICollection) arrayList.ToArray());
      }
      return this.mobjValues;
    }

    /// <summary>Determines if this object supports a standard set of values that can be picked from a list.</summary>
    /// <returns>Returns true if GetStandardValues should be called to find a common set of values the object supports.</returns>
    /// <param name="objContext">A type descriptor through which additional context may be provided. </param>
    /// <filterpriority>1</filterpriority>
    public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext) => true;
  }
}
