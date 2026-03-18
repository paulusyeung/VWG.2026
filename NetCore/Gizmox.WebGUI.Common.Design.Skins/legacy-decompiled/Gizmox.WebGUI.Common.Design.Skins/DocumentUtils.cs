using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Gizmox.WebGUI.Common.Design.Skins;

internal static class DocumentUtils
{
	public static object InvokeMethod(object objInstance, string strMethod, BindingFlags enmBindingFlags, params object[] objParams)
	{
		if (objInstance != null)
		{
			MethodInfo method = objInstance.GetType().GetMethod(strMethod, enmBindingFlags);
			if (method != null)
			{
				return method.Invoke(objInstance, objParams);
			}
		}
		return null;
	}

	public static object InvokeMethod(object objInstance, string strMethod, params object[] objParams)
	{
		return InvokeMethod(objInstance, strMethod, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, objParams);
	}

	public static string GetResourceName(object objSkin, object objResource)
	{
		if (objSkin != null)
		{
			MethodInfo method = objSkin.GetType().GetMethod("GetResourceName", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod);
			if (method != null)
			{
				object obj = method.Invoke(objSkin, new object[1] { objResource });
				if (obj != null)
				{
					return (string)obj;
				}
			}
		}
		return "";
	}

	public static Type GetSkinDesignType(object objSkin)
	{
		Type result = null;
		if (objSkin != null)
		{
			Type type = objSkin.GetType();
			if (type != null)
			{
				result = type.InvokeMember("DesignedType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty, null, objSkin, null) as Type;
			}
		}
		return result;
	}

	public static void SetResourceName(object objSkin, object objResource, string strName)
	{
		if (objSkin != null)
		{
			MethodInfo method = objSkin.GetType().GetMethod("SetResourceName", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod);
			if (method != null)
			{
				method.Invoke(objSkin, new object[2] { objResource, strName });
			}
		}
	}

	public static bool IsInherited(object objSkin, object objResource)
	{
		if (objSkin != null)
		{
			MethodInfo method = objSkin.GetType().GetMethod("IsInherited");
			if (method != null)
			{
				object obj = method.Invoke(objSkin, new object[1] { objResource });
				if (obj != null)
				{
					return (bool)obj;
				}
			}
		}
		return false;
	}

	public static bool IsVisible(object objResource)
	{
		PropertyInfo property = objResource.GetType().GetProperty("Visible");
		if (property != null)
		{
			object value = property.GetValue(objResource, new object[0]);
			if (value != null)
			{
				return !(value.ToString().ToLower() == "false");
			}
			return true;
		}
		return true;
	}

	public static object GetPropertyValue(object objInstance, string strProperty, BindingFlags enmBindingFlags)
	{
		if (objInstance != null)
		{
			PropertyInfo property = objInstance.GetType().GetProperty(strProperty, enmBindingFlags);
			if (property != null)
			{
				try
				{
					return property.GetValue(objInstance, new object[0]);
				}
				catch (TargetInvocationException ex)
				{
					if (ex.InnerException != null)
					{
						ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
					}
					throw;
				}
			}
		}
		return null;
	}

	public static object GetPropertyValue(object objInstance, string strProperty)
	{
		return GetPropertyValue(objInstance, strProperty, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	public static Type GetPropertyValue(object objInstance, string strProperty, Type objDefault)
	{
		object propertyValue = GetPropertyValue(objInstance, strProperty);
		if (propertyValue != null && propertyValue is Type)
		{
			return (Type)propertyValue;
		}
		return objDefault;
	}

	public static Type GetPropertyType(object objInstance, string strProperty)
	{
		Type result = null;
		if (objInstance != null && !string.IsNullOrEmpty(strProperty))
		{
			Type type = objInstance.GetType();
			if (objInstance != null)
			{
				PropertyInfo property = type.GetProperty(strProperty);
				if (property != null)
				{
					result = property.PropertyType;
				}
			}
		}
		return result;
	}

	public static bool GetPropertyValue(object objInstance, string strProperty, bool blnDefault)
	{
		object propertyValue = GetPropertyValue(objInstance, strProperty);
		if (propertyValue != null && propertyValue is bool)
		{
			return (bool)propertyValue;
		}
		return blnDefault;
	}

	public static string GetPropertyValue(object objInstance, string strProperty, string strDefault)
	{
		object propertyValue = GetPropertyValue(objInstance, strProperty);
		if (propertyValue != null)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(propertyValue.GetType());
			if (converter != null && converter.CanConvertTo(typeof(string)))
			{
				return converter.ConvertToInvariantString(propertyValue);
			}
		}
		return strDefault;
	}

	public static object GetFieldValue(object objInstance, Type objInstanceType, string strFieldName, BindingFlags enmBindingFlags)
	{
		object result = null;
		if (objInstance != null && objInstanceType != null)
		{
			FieldInfo field = objInstanceType.GetField(strFieldName, enmBindingFlags);
			if (field != null)
			{
				try
				{
					result = field.GetValue(objInstance);
				}
				catch (TargetInvocationException ex)
				{
					if (ex.InnerException != null)
					{
						ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
					}
					throw;
				}
			}
		}
		return result;
	}

	public static void SetFieldValue(object objInstance, Type objInstanceType, string strFieldName, BindingFlags enmBindingFlags, object objValue)
	{
		if (objInstance == null || !(objInstanceType != null))
		{
			return;
		}
		FieldInfo field = objInstanceType.GetField(strFieldName, enmBindingFlags);
		if (!(field != null))
		{
			return;
		}
		try
		{
			field.SetValue(objInstance, objValue);
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException != null)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
			throw;
		}
	}

	public static void SetPropertyValue(object objInstance, string strProperty, object objValue)
	{
		if (objInstance != null)
		{
			PropertyInfo property = objInstance.GetType().GetProperty(strProperty);
			if (property != null)
			{
				property.SetValue(objInstance, objValue, new object[0]);
			}
		}
	}

	public static string GetComponentName(IComponent objComponent, ComponentCollection objComponentCollection)
	{
		string name = objComponent.GetType().Name;
		string text = name;
		if (IsNameUsed(text, objComponentCollection))
		{
			int num = 1;
			text = $"{name}{num}";
			while (IsNameUsed(text, objComponentCollection))
			{
				num++;
				text = $"{name}{num}";
			}
		}
		return text;
	}

	private static bool IsNameUsed(string strSkinCurrentName, ComponentCollection objComponentCollection)
	{
		foreach (IComponent item in objComponentCollection)
		{
			if (item.Site != null && item.Site.Name == strSkinCurrentName)
			{
				return true;
			}
		}
		return false;
	}
}
