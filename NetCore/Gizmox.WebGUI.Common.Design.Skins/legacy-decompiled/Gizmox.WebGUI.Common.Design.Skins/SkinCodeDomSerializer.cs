using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Gizmox.WebGUI.Common.Design.Skins;

public class SkinCodeDomSerializer : CodeDomSerializer
{
	public override object Serialize(IDesignerSerializationManager manager, object value)
	{
		if (value is IComponent component)
		{
			if (component is ICollection { Count: >0 } collection)
			{
				string componentTypeName = GetComponentTypeName(value);
				if (!string.IsNullOrEmpty(componentTypeName))
				{
					foreach (object item in collection)
					{
						if (item == null)
						{
							continue;
						}
						Type type = item.GetType();
						PropertyInfo property = type.GetProperty("Key");
						PropertyInfo property2 = type.GetProperty("Value");
						if (!(property != null) || !(property2 != null))
						{
							continue;
						}
						string text = (string)property.GetValue(item, new object[0]);
						object value2 = property2.GetValue(item, new object[0]);
						if (!ShouldSerializeValue(value2) || string.IsNullOrEmpty(text) || DocumentUtils.IsInherited(component, value2))
						{
							continue;
						}
						SerializeResourceInvariant(manager, GetResourceName(componentTypeName, text), GetSkinResourceTypeName(value2));
						Type type2 = value2.GetType();
						foreach (PropertyDescriptor property3 in TypeDescriptor.GetProperties(type2))
						{
							if (property3.SerializationVisibility != DesignerSerializationVisibility.Hidden)
							{
								object propertyValue = GetPropertyValue(value, property3, value2);
								if (ShouldSerializeValue(property3, propertyValue, value2, type2))
								{
									SerializeResourceInvariant(manager, GetResourcePropertyName(componentTypeName, text, property3.Name), GetResourcePropertyValue(propertyValue));
								}
							}
						}
					}
				}
			}
			else
			{
				SerializeResourceInvariant(manager, "Empty", null);
			}
		}
		return null;
	}

	private bool ShouldSerializeValue(PropertyDescriptor objProperty, object objPropertyValue, object objObject, Type objObjectType)
	{
		bool result = true;
		if (objProperty != null && objObject != null && objObjectType != null)
		{
			MethodInfo method = objObjectType.GetMethod($"ShouldSerialize{objProperty.Name}", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod);
			if (method != null)
			{
				result = Convert.ToBoolean(method.Invoke(objObject, new object[0]));
			}
			else if (objProperty.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute defaultValueAttribute)
			{
				object obj = null;
				if (objProperty.PropertyType != null && objProperty.PropertyType.IsEnum && objPropertyValue != null && Enum.IsDefined(objProperty.PropertyType, objPropertyValue))
				{
					obj = Enum.Parse(objProperty.PropertyType, objPropertyValue.ToString());
				}
				result = !object.Equals(defaultValueAttribute.Value, objPropertyValue) && (obj == null || !object.Equals(defaultValueAttribute.Value, obj));
			}
		}
		return result;
	}

	private bool ShouldSerializeValue(object objValue)
	{
		bool result = false;
		if (objValue != null)
		{
			result = true;
			Type type = objValue.GetType();
			if (type != null && type.Name == "ValueResource`1")
			{
				object propertyValue = DocumentUtils.GetPropertyValue(objValue, "Value");
				result = propertyValue != null && Convert.ToString(propertyValue) != string.Empty;
			}
		}
		return result;
	}

	private object GetResourcePropertyValue(object objPropertyValue)
	{
		if (!(objPropertyValue is ResXFileRef) && objPropertyValue != null && !(objPropertyValue is string))
		{
			TypeConverter converter = TypeDescriptor.GetConverter(objPropertyValue);
			if (converter != null && converter.CanConvertTo(typeof(string)))
			{
				objPropertyValue = converter.ConvertToInvariantString(objPropertyValue);
			}
		}
		return objPropertyValue;
	}

	private static string GetSkinResourceTypeName(object objValueValue)
	{
		Type type = objValueValue.GetType();
		if (type.IsGenericType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("ValueResource");
			Type[] genericArguments = type.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				stringBuilder.Append(":");
				stringBuilder.AppendFormat("{0}, {1}", genericArguments[i].FullName, genericArguments[i].Assembly.GetName().Name);
			}
			return stringBuilder.ToString();
		}
		return objValueValue.GetType().Name;
	}

	protected virtual string GetResourceName(string strComponentName, string strKeyValue)
	{
		return $"Skin:{strComponentName}:{strKeyValue}";
	}

	protected virtual string GetResourcePropertyName(string strComponentName, string strKeyValue, string strPropertyName)
	{
		return $"Skin:{strComponentName}:{strKeyValue}:{strPropertyName}";
	}

	private object GetPropertyValue(object objResourceOwner, PropertyDescriptor objProperty, object objResourceInstance)
	{
		if (objResourceInstance != null)
		{
			if (objProperty.Name == "Content")
			{
				Type type = (Type)GetPropertyValue(objResourceInstance, "CompilerContentType", null);
				if (type != null && !DocumentUtils.IsInherited(objResourceOwner, objResourceInstance))
				{
					string text = GetPropertyValue(objResourceInstance, "FileName", null) as string;
					if (!string.IsNullOrEmpty(text))
					{
						string typeName = string.Join(",", type.AssemblyQualifiedName.Split(','), 0, 2);
						ResXFileRef resXFileRef = new ResXFileRef(text, typeName);
						if (resXFileRef != null)
						{
							return resXFileRef;
						}
					}
				}
			}
			if (objProperty.Name.StartsWith("Presentation") || objProperty.Name == "CompilerActions")
			{
				TypeConverter converter = objProperty.Converter;
				if (converter != null && converter.CanConvertTo(typeof(int)))
				{
					return converter.ConvertTo(objProperty.GetValue(objResourceInstance), typeof(int));
				}
			}
			return objProperty.GetValue(objResourceInstance);
		}
		return null;
	}

	private object GetPropertyValue(object objInstance, string strProperty, object objDefault)
	{
		if (objInstance != null)
		{
			PropertyInfo property = objInstance.GetType().GetProperty(strProperty);
			if (property != null)
			{
				return property.GetValue(objInstance, new object[0]);
			}
		}
		return null;
	}

	private string GetComponentTypeName(object objValue)
	{
		if (objValue is IComponent { Site: not null } component)
		{
			IDesignerHost designerHost = (IDesignerHost)component.Site.GetService(typeof(IDesignerHost));
			if (designerHost != null)
			{
				if (designerHost.RootComponent == objValue)
				{
					return designerHost.RootComponentClassName;
				}
				return objValue.GetType().FullName;
			}
		}
		return null;
	}

	public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
	{
		return null;
	}
}
