// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.VisualTemplatesTypeConverter
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
  /// <summary>Type converter for the draggable option object.</summary>
  [Serializable]
  public class VisualTemplatesTypeConverter : TypeConverter
  {
    /// <summary>
    /// Converts the specified objValue object to an enumeration object.
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof (string) || base.CanConvertFrom(context, destinationType);

    /// <summary>
    /// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
    /// </summary>
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
      if (value is string)
      {
        string str = (string) value;
        if (!string.IsNullOrEmpty(str))
        {
          string[] strArray = str.Split('|');
          List<string> objVisualTemplateValues = new List<string>();
          for (int index = 1; index < strArray.Length; ++index)
            objVisualTemplateValues.Add(strArray[index]);
          return (object) this.GetVisualTemplateObjectFromString(strArray[0], objVisualTemplateValues);
        }
      }
      return base.ConvertFrom(context, culture, value);
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
      if (destinationType == typeof (InstanceDescriptor))
        return this.ConvertToInstanceDescriptor(context, value);
      return destinationType == typeof (string) ? (object) this.ConvertToString(context, value) : base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>converts the object to string.</summary>
    /// <param name="objContext"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private new string ConvertToString(ITypeDescriptorContext objContext, object value) => value is VisualTemplate visualTemplate ? visualTemplate.ConvertToString() : "";

    /// <summary>gives the InstanceDescriptor of the object</summary>
    /// <param name="objContext"></param>
    /// <param name="objValue"></param>
    /// <returns></returns>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
    {
      VisualTemplate visualTemplate = value as VisualTemplate;
      object[] consturctorArguments = visualTemplate.GetConsturctorArguments();
      Type[] constructorTypes = visualTemplate.GetConstructorTypes();
      return (object) new InstanceDescriptor((MemberInfo) visualTemplate.GetType().GetConstructor(constructorTypes), (ICollection) consturctorArguments);
    }

    /// <summary>Gets the visual effect object from string.</summary>
    /// <param name="strVisualEffectType">Name of the STR visual effect.</param>
    /// <param name="strVisualEffectValue">The STR visual effect objValue.</param>
    /// <returns></returns>
    protected virtual VisualTemplate GetVisualTemplateObjectFromString(
      string strVisualTypeType,
      List<string> objVisualTemplateValues)
    {
      objectFromString = (VisualTemplate) null;
      string typeName = strVisualTypeType;
      string[] strArray = strVisualTypeType.Split(',');
      if (strArray.Length > 1)
        typeName = string.Format("{0}, {1}", (object) strArray[0], (object) CommonUtils.GetFullAssemblyName(strArray[1].Trim()));
      Type type = Type.GetType(typeName);
      if (type != (Type) null && Activator.CreateInstance(type) is VisualTemplate objectFromString)
        objectFromString.ConvertFromString(objVisualTemplateValues);
      return objectFromString;
    }
  }
}
