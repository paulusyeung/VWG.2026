using System;
using System.Text;
using System.Security.Permissions;
using System.Reflection;
using System.Security;

namespace Gizmox.WebGUI.Forms
{

    [Serializable()]
    internal class SecurityUtils
    {
        internal static object SecureConstructorInvoke(Type objType, Type[] arrArgTypes, object[] arrArgs, bool blnAllowNonPublic)
        {
            return SecureConstructorInvoke(objType, arrArgTypes, arrArgs, blnAllowNonPublic, BindingFlags.Default);
        }

        internal static object SecureConstructorInvoke(Type objType, Type[] arrArgTypes, object[] arrArgs, bool blnAllowNonPublic, BindingFlags enmExtraFlags)
        {
            if (objType == null)
            {
                throw new ArgumentNullException("type");
            }
            BindingFlags enmBindingAttr = (BindingFlags.Public | BindingFlags.Instance) | enmExtraFlags;
            if (objType.Assembly == typeof(SecurityUtils).Assembly)
            {
                if (!objType.IsPublic && !objType.IsNestedPublic)
                {
                    new ReflectionPermission(PermissionState.Unrestricted).Demand();
                }
                else if (blnAllowNonPublic && !HasReflectionPermission)
                {
                    blnAllowNonPublic = false;
                }
            }
            if (blnAllowNonPublic)
            {
                enmBindingAttr |= BindingFlags.NonPublic;
            }
            ConstructorInfo objInfo = objType.GetConstructor(enmBindingAttr, null, arrArgTypes, null);
            if (objInfo != null)
            {
                return objInfo.Invoke(arrArgs);
            }
            return null;
        }

        internal static object SecureCreateInstance(Type objType)
        {
            return SecureCreateInstance(objType, null);
        }

        internal static object SecureCreateInstance(Type objType, object[] arrArgs)
        {
            if (objType == null)
            {
                throw new ArgumentNullException("type");
            }
            if (((objType.Assembly == typeof(SecurityUtils).Assembly) && !objType.IsPublic) && !objType.IsNestedPublic)
            {
                new ReflectionPermission(PermissionState.Unrestricted).Demand();
            }
            return Activator.CreateInstance(objType, arrArgs);
        }

        internal static object SecureCreateInstance(Type objType, object[] arrArgs, bool blnAllowNonPublic)
        {
            if (objType == null)
            {
                throw new ArgumentNullException("type");
            }
            BindingFlags enmBindingAttr = BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance;
            if (objType.Assembly == typeof(SecurityUtils).Assembly)
            {
                if (!objType.IsPublic && !objType.IsNestedPublic)
                {
                    new ReflectionPermission(PermissionState.Unrestricted).Demand();
                }
                else if (blnAllowNonPublic && !HasReflectionPermission)
                {
                    blnAllowNonPublic = false;
                }
            }
            if (blnAllowNonPublic)
            {
                enmBindingAttr |= BindingFlags.NonPublic;
            }
            return Activator.CreateInstance(objType, enmBindingAttr, null, arrArgs, null);
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
                catch (SecurityException)
                {
                }
                return false;
            }
        }
    }
}
