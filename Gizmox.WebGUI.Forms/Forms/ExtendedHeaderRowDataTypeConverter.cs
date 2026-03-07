// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ExtendedHeaderRowDataTypeConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// This class represents the ExtendedHeaderRow Converter.
  /// Used to avoid the default behaviour of the designer adding columns into the form's resx file.
  /// </summary>
  [Serializable]
  public class ExtendedHeaderRowDataTypeConverter : TypeConverter
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

    /// <summary>Converts to.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objCulture">The obj culture.</param>
    /// <param name="objValue">The obj value.</param>
    /// <param name="objDestinationType">Type of the obj destination.</param>
    /// <returns></returns>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      if (!(objDestinationType == typeof (InstanceDescriptor)) || !(objValue is ExtendedHeaderRowData))
        return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
      ExtendedHeaderRowData extendedHeaderRowData = objValue as ExtendedHeaderRowData;
      List<object> arguments = (List<object>) null;
      ConstructorInfo constructor;
      if (extendedHeaderRowData.HeightSizeMode == HeightMode.Custom)
      {
        arguments = new List<object>();
        arguments.Add((object) extendedHeaderRowData.HeightSizeMode);
        arguments.Add((object) extendedHeaderRowData.Height);
        constructor = typeof (ExtendedHeaderRowData).GetConstructor(new Type[2]
        {
          typeof (HeightMode),
          typeof (int)
        });
      }
      else
        constructor = typeof (ExtendedHeaderRowData).GetConstructor(new Type[0]);
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) arguments);
    }
  }
}
