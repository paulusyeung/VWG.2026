// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Formatter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class Formatter : SerializableObject
  {
    private static Type mobjBooleanType;
    private static Type mobjCheckStateType;
    private static object mobjDefaultDataSourceNullValue;
    private static object mobjParseMethodNotFound;
    private static Type mobjStringType = typeof (string);

    static Formatter()
    {
      Formatter.mobjBooleanType = typeof (bool);
      Formatter.mobjCheckStateType = typeof (CheckState);
      Formatter.mobjParseMethodNotFound = new object();
      Formatter.mobjDefaultDataSourceNullValue = (object) DBNull.Value;
    }

    private static object ChangeType(object objValue, Type objType, IFormatProvider objFormatInfo)
    {
      try
      {
        if (objFormatInfo == null)
          objFormatInfo = (IFormatProvider) CultureInfo.CurrentCulture;
        return Convert.ChangeType(objValue, objType, objFormatInfo);
      }
      catch (InvalidCastException ex)
      {
        throw new FormatException(ex.Message, (Exception) ex);
      }
    }

    private static bool EqualsFormattedNullValue(
      object objValue,
      object objFormattedNullValue,
      IFormatProvider objFormatInfo)
    {
      return objFormattedNullValue is string && objValue is string ? string.Compare((string) objValue, (string) objFormattedNullValue, true, Formatter.GetFormatterCulture(objFormatInfo)) == 0 : object.Equals(objValue, objFormattedNullValue);
    }

    public static object FormatObject(
      object objValue,
      Type objTargetType,
      TypeConverter objSourceConverter,
      TypeConverter objTargetConverter,
      string strFormatString,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue,
      object objDataSourceNullValue)
    {
      if (Formatter.IsNullData(objValue, objDataSourceNullValue))
        objValue = (object) DBNull.Value;
      Type type = objTargetType;
      objTargetType = Formatter.NullableUnwrap(objTargetType);
      objSourceConverter = Formatter.NullableUnwrap(objSourceConverter);
      objTargetConverter = Formatter.NullableUnwrap(objTargetConverter);
      bool flag = objTargetType != type;
      object obj = Formatter.FormatObjectInternal(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue);
      if (type.IsValueType && obj == null && !flag)
        throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
      return obj;
    }

    private static object FormatObjectInternal(
      object objValue,
      Type objTargetType,
      TypeConverter objSourceConverter,
      TypeConverter objTargetConverter,
      string strFormatString,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue)
    {
      if (objValue == DBNull.Value || objValue == null)
      {
        if (objFormattedNullValue != null)
          return objFormattedNullValue;
        if (objTargetType == Formatter.mobjStringType)
          return (object) string.Empty;
        return objTargetType == Formatter.mobjCheckStateType ? (object) CheckState.Indeterminate : (object) null;
      }
      if (objTargetType == Formatter.mobjStringType && objValue is IFormattable)
      {
        if (!CommonUtils.IsNullOrEmpty(strFormatString))
          return (object) (objValue as IFormattable).ToString(strFormatString, objFormatInfo);
      }
      Type type = objValue.GetType();
      TypeConverter converter1 = TypeDescriptor.GetConverter(type);
      if (objSourceConverter != null && objSourceConverter != converter1 && objSourceConverter.CanConvertTo(objTargetType))
        return objSourceConverter.ConvertTo((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
      TypeConverter converter2 = TypeDescriptor.GetConverter(objTargetType);
      if (objTargetConverter != null && objTargetConverter != converter2 && objTargetConverter.CanConvertFrom(type))
        return objTargetConverter.ConvertFrom((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
      if (objTargetType == Formatter.mobjCheckStateType)
      {
        if (type == Formatter.mobjBooleanType)
          return (object) (CheckState) ((bool) objValue ? 1 : 0);
        if (objSourceConverter == null)
          objSourceConverter = converter1;
        if (objSourceConverter != null && objSourceConverter.CanConvertTo(Formatter.mobjBooleanType))
          return (object) (CheckState) ((bool) objSourceConverter.ConvertTo((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue, Formatter.mobjBooleanType) ? 1 : 0);
      }
      if (objTargetType.IsAssignableFrom(type))
        return objValue;
      if (objSourceConverter == null)
        objSourceConverter = converter1;
      if (objTargetConverter == null)
        objTargetConverter = converter2;
      if (objSourceConverter != null && objSourceConverter.CanConvertTo(objTargetType))
        return objSourceConverter.ConvertTo((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
      if (objTargetConverter != null && objTargetConverter.CanConvertFrom(type))
        return objTargetConverter.ConvertFrom((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
      if (!(objValue is IConvertible))
        throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
      return Formatter.ChangeType(objValue, objTargetType, objFormatInfo);
    }

    private static string GetCantConvertMessage(object objValue, Type objTargetType) => string.Format((IFormatProvider) CultureInfo.CurrentCulture, SR.GetString(objValue == null ? "Formatter_CantConvertNull" : "Formatter_CantConvert"), objValue, (object) objTargetType.Name);

    public static object GetDefaultDataSourceNullValue(Type objType) => objType != (Type) null && !objType.IsValueType ? (object) null : Formatter.mobjDefaultDataSourceNullValue;

    private static CultureInfo GetFormatterCulture(IFormatProvider objFormatInfo) => objFormatInfo is CultureInfo ? objFormatInfo as CultureInfo : CultureInfo.CurrentCulture;

    public static object InvokeStringParseMethod(
      object objValue,
      Type objTargetType,
      IFormatProvider objFormatInfo)
    {
      try
      {
        MethodInfo method1 = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, (Binder) null, new Type[3]
        {
          Formatter.mobjStringType,
          typeof (NumberStyles),
          typeof (IFormatProvider)
        }, (ParameterModifier[]) null);
        if (method1 != (MethodInfo) null)
          return method1.Invoke((object) null, new object[3]
          {
            (object) (string) objValue,
            (object) NumberStyles.Any,
            (object) objFormatInfo
          });
        MethodInfo method2 = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, (Binder) null, new Type[2]
        {
          Formatter.mobjStringType,
          typeof (IFormatProvider)
        }, (ParameterModifier[]) null);
        if (method2 != (MethodInfo) null)
          return method2.Invoke((object) null, new object[2]
          {
            (object) (string) objValue,
            (object) objFormatInfo
          });
        MethodInfo method3 = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, (Binder) null, new Type[1]
        {
          Formatter.mobjStringType
        }, (ParameterModifier[]) null);
        if (!(method3 != (MethodInfo) null))
          return Formatter.mobjParseMethodNotFound;
        return method3.Invoke((object) null, new object[1]
        {
          (object) (string) objValue
        });
      }
      catch (TargetInvocationException ex)
      {
        throw new FormatException(ex.InnerException.Message, ex.InnerException);
      }
    }

    public static bool IsNullData(object objValue, object objDataSourceNullValue) => objValue == null || objValue == DBNull.Value || object.Equals(objValue, Formatter.NullData(objValue.GetType(), objDataSourceNullValue));

    private static TypeConverter NullableUnwrap(TypeConverter objTypeConverter)
    {
      if (objTypeConverter != null)
      {
        Type c = typeof (NullableConverter);
        if (c != (Type) null)
        {
          Type type = objTypeConverter.GetType();
          if (type.IsSubclassOf(c) || type == c)
            objTypeConverter = (TypeConverter) c.GetProperty("UnderlyingTypeConverter", BindingFlags.Instance | BindingFlags.Public).GetValue((object) objTypeConverter, (object[]) null);
        }
      }
      return objTypeConverter;
    }

    private static Type NullableUnwrap(Type objType)
    {
      if (objType == Formatter.mobjStringType)
        return Formatter.mobjStringType;
      Type underlyingType = Nullable.GetUnderlyingType(objType);
      return !(underlyingType != (Type) null) ? objType : underlyingType;
    }

    public static object NullData(Type objType, object objDataSourceNullValue) => !objType.IsGenericType || objType.GetGenericTypeDefinition() != typeof (Nullable<>) || objDataSourceNullValue != null && objDataSourceNullValue != DBNull.Value ? objDataSourceNullValue : (object) null;

    public static object ParseObject(
      object objValue,
      Type objTargetType,
      Type objSourceType,
      TypeConverter objTargetConverter,
      TypeConverter objSourceConverter,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue,
      object objDataSourceNullValue)
    {
      Type objType = objTargetType;
      objSourceType = Formatter.NullableUnwrap(objSourceType);
      objTargetType = Formatter.NullableUnwrap(objTargetType);
      objSourceConverter = Formatter.NullableUnwrap(objSourceConverter);
      objTargetConverter = Formatter.NullableUnwrap(objTargetConverter);
      object objectInternal = Formatter.ParseObjectInternal(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue);
      return objectInternal == DBNull.Value ? Formatter.NullData(objType, objDataSourceNullValue) : objectInternal;
    }

    private static object ParseObjectInternal(
      object objValue,
      Type objTargetType,
      Type objSourceType,
      TypeConverter objTargetConverter,
      TypeConverter objSourceConverter,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue)
    {
      if (Formatter.EqualsFormattedNullValue(objValue, objFormattedNullValue, objFormatInfo) || objValue == DBNull.Value)
        return (object) DBNull.Value;
      TypeConverter converter1 = TypeDescriptor.GetConverter(objTargetType);
      if (objTargetConverter == null || converter1 == objTargetConverter || !objTargetConverter.CanConvertFrom(objSourceType))
      {
        TypeConverter converter2 = TypeDescriptor.GetConverter(objSourceType);
        if (objSourceConverter != null && converter2 != objSourceConverter && objSourceConverter.CanConvertTo(objTargetType))
          return objSourceConverter.ConvertTo((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
        if (objValue is string)
        {
          object method = Formatter.InvokeStringParseMethod(objValue, objTargetType, objFormatInfo);
          if (method != Formatter.mobjParseMethodNotFound)
            return method;
        }
        else if (objValue is CheckState checkState)
        {
          if (checkState == CheckState.Indeterminate)
            return (object) DBNull.Value;
          if (objTargetType == Formatter.mobjBooleanType)
            return (object) (checkState == CheckState.Checked);
          if (objTargetConverter == null)
            objTargetConverter = converter1;
          if (objTargetConverter != null && objTargetConverter.CanConvertFrom(Formatter.mobjBooleanType))
            return objTargetConverter.ConvertFrom((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), (object) (checkState == CheckState.Checked));
        }
        else if (objValue != null && objTargetType.IsAssignableFrom(objValue.GetType()))
          return objValue;
        if (objTargetConverter == null)
          objTargetConverter = converter1;
        if (objSourceConverter == null)
          objSourceConverter = converter2;
        if (objTargetConverter == null || !objTargetConverter.CanConvertFrom(objSourceType))
        {
          if (objSourceConverter != null && objSourceConverter.CanConvertTo(objTargetType))
            return objSourceConverter.ConvertTo((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
          if (!(objValue is IConvertible))
            throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
          return Formatter.ChangeType(objValue, objTargetType, objFormatInfo);
        }
      }
      return objTargetConverter.ConvertFrom((ITypeDescriptorContext) null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
    }
  }
}
