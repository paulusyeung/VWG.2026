// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SecurityUtils
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class SecurityUtils
  {
    internal static object SecureConstructorInvoke(
      Type objType,
      Type[] arrArgTypes,
      object[] arrArgs,
      bool blnAllowNonPublic)
    {
      return SecurityUtils.SecureConstructorInvoke(objType, arrArgTypes, arrArgs, blnAllowNonPublic, BindingFlags.Default);
    }

    internal static object SecureConstructorInvoke(
      Type objType,
      Type[] arrArgTypes,
      object[] arrArgs,
      bool blnAllowNonPublic,
      BindingFlags enmExtraFlags)
    {
      if (objType == (Type) null)
        throw new ArgumentNullException("type");
      BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | enmExtraFlags;
      if (objType.Assembly == typeof (SecurityUtils).Assembly)
      {
        if (!objType.IsPublic && !objType.IsNestedPublic)
          new ReflectionPermission(PermissionState.Unrestricted).Demand();
        else if (blnAllowNonPublic && !SecurityUtils.HasReflectionPermission)
          blnAllowNonPublic = false;
      }
      if (blnAllowNonPublic)
        bindingAttr |= BindingFlags.NonPublic;
      ConstructorInfo constructor = objType.GetConstructor(bindingAttr, (Binder) null, arrArgTypes, (ParameterModifier[]) null);
      return constructor != (ConstructorInfo) null ? constructor.Invoke(arrArgs) : (object) null;
    }

    internal static object SecureCreateInstance(Type objType) => SecurityUtils.SecureCreateInstance(objType, (object[]) null);

    internal static object SecureCreateInstance(Type objType, object[] arrArgs)
    {
      if (objType == (Type) null)
        throw new ArgumentNullException("type");
      if (objType.Assembly == typeof (SecurityUtils).Assembly && !objType.IsPublic && !objType.IsNestedPublic)
        new ReflectionPermission(PermissionState.Unrestricted).Demand();
      return Activator.CreateInstance(objType, arrArgs);
    }

    internal static object SecureCreateInstance(
      Type objType,
      object[] arrArgs,
      bool blnAllowNonPublic)
    {
      if (objType == (Type) null)
        throw new ArgumentNullException("type");
      BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;
      if (objType.Assembly == typeof (SecurityUtils).Assembly)
      {
        if (!objType.IsPublic && !objType.IsNestedPublic)
          new ReflectionPermission(PermissionState.Unrestricted).Demand();
        else if (blnAllowNonPublic && !SecurityUtils.HasReflectionPermission)
          blnAllowNonPublic = false;
      }
      if (blnAllowNonPublic)
        bindingAttr |= BindingFlags.NonPublic;
      return Activator.CreateInstance(objType, bindingAttr, (Binder) null, arrArgs, (CultureInfo) null);
    }

    private static bool HasReflectionPermission
    {
      get
      {
        try
        {
          new ReflectionPermission(PermissionState.Unrestricted).Demand();
          return true;
        }
        catch (SecurityException ex)
        {
        }
        return false;
      }
    }
  }
}
