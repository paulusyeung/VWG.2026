// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListBindingConverter
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
  /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects to and from various other representations.
  /// </summary>
  [Serializable]
  public class ListBindingConverter : TypeConverter
  {
    private static string[] marrCtorParamProps;
    private static Type[] marrCtorTypes;

    /// <filterpriority>1</filterpriority>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

    /// <filterpriority>1</filterpriority>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException("destinationType");
      return objDestinationType == typeof (InstanceDescriptor) && objValue is Binding ? (object) this.GetInstanceDescriptorFromValues((Binding) objValue) : base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <filterpriority>1</filterpriority>
    public override object CreateInstance(
      ITypeDescriptorContext objContext,
      IDictionary objPropertyValues)
    {
      try
      {
        return (object) new Binding((string) objPropertyValues[(object) "PropertyName"], objPropertyValues[(object) "DataSource"], (string) objPropertyValues[(object) "DataMember"]);
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

    /// <filterpriority>1</filterpriority>
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext) => true;

    private InstanceDescriptor GetInstanceDescriptorFromValues(Binding objBinding)
    {
      objBinding.FormattingEnabled = true;
      bool isComplete = true;
      int index1;
      for (index1 = ListBindingConverter.ConstructorParameterProperties.Length - 1; index1 >= 0 && ListBindingConverter.ConstructorParameterProperties[index1] != null; --index1)
      {
        PropertyDescriptor property = TypeDescriptor.GetProperties((object) objBinding)[ListBindingConverter.ConstructorParameterProperties[index1]];
        if (property != null && property.ShouldSerializeValue((object) objBinding))
          break;
      }
      Type[] typeArray = new Type[index1 + 1];
      Array.Copy((Array) ListBindingConverter.ConstructorParamaterTypes, 0, (Array) typeArray, 0, typeArray.Length);
      ConstructorInfo constructor = typeof (Binding).GetConstructor(typeArray);
      if (constructor == (ConstructorInfo) null)
      {
        isComplete = false;
        constructor = typeof (Binding).GetConstructor(new Type[3]
        {
          typeof (string),
          typeof (object),
          typeof (string)
        });
      }
      object[] arguments = new object[typeArray.Length];
      for (int index2 = 0; index2 < arguments.Length; ++index2)
      {
        object obj;
        switch (index2)
        {
          case 0:
            obj = (object) objBinding.PropertyName;
            break;
          case 1:
            obj = objBinding.BindToObject.DataSource;
            break;
          case 2:
            obj = (object) objBinding.BindToObject.BindingMemberInfo.BindingMember;
            break;
          default:
            obj = TypeDescriptor.GetProperties((object) objBinding)[ListBindingConverter.ConstructorParameterProperties[index2]].GetValue((object) objBinding);
            break;
        }
        arguments[index2] = obj;
      }
      return new InstanceDescriptor((MemberInfo) constructor, (ICollection) arguments, isComplete);
    }

    private static Type[] ConstructorParamaterTypes
    {
      get
      {
        if (ListBindingConverter.marrCtorTypes == null)
          ListBindingConverter.marrCtorTypes = new Type[8]
          {
            typeof (string),
            typeof (object),
            typeof (string),
            typeof (bool),
            typeof (DataSourceUpdateMode),
            typeof (object),
            typeof (string),
            typeof (IFormatProvider)
          };
        return ListBindingConverter.marrCtorTypes;
      }
    }

    private static string[] ConstructorParameterProperties
    {
      get
      {
        if (ListBindingConverter.marrCtorParamProps == null)
          ListBindingConverter.marrCtorParamProps = new string[8]
          {
            null,
            null,
            null,
            "FormattingEnabled",
            "DataSourceUpdateMode",
            "NullValue",
            "FormatString",
            "FormatInfo"
          };
        return ListBindingConverter.marrCtorParamProps;
      }
    }
  }
}
