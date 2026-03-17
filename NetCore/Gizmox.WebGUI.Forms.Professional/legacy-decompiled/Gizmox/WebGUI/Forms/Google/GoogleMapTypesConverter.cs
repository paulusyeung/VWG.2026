using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>Converts a <see cref="T:System.Drawing.GoogleMapLocation"></see> object from one data type to another. Access this class through the <see cref="T:System.ComponentModel.TypeDescriptor"></see> object.</summary>
/// <filterpriority>1</filterpriority>
public class GoogleMapTypesConverter : TypeConverter
{
	/// <summary>Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
	/// <returns>true if this object can perform the conversion; otherwise, false.</returns>
	/// <param name="context">A formatter context. This object can be used to get additional information about the environment this converter is being called from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
	/// <param name="sourceType">The type you want to convert from. </param>
	/// <filterpriority>1</filterpriority>
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	/// <summary>Gets a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
	/// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
	/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> object that provides a format context. </param>
	/// <param name="destinationType">A <see cref="T:System.Type"></see> object that represents the type you want to convert to. </param>
	/// <filterpriority>1</filterpriority>
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(InstanceDescriptor)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	/// <summary>
	/// Converts from string representation
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objCulture">The culture.</param>
	/// <param name="objValue">The value.</param>
	/// <returns></returns>
	public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
	{
		if (!(objValue is string text))
		{
			return base.ConvertFrom(objContext, objCulture, objValue);
		}
		string text2 = text.Trim();
		if (text2.Length == 0)
		{
			return GoogleMapMapTypes.DefaultMapTypes();
		}
		if (objCulture == null)
		{
			objCulture = CultureInfo.CurrentCulture;
		}
		char c = objCulture.TextInfo.ListSeparator[0];
		string[] array = text2.Split(c);
		GoogleMapMapTypes googleMapMapTypes = GoogleMapMapTypes.DefaultMapTypes();
		foreach (string text3 in array)
		{
			if (text3 != null && text3.Trim().Length > 0)
			{
				if (text3.ToLower() == GoogleMapType.Hybrid.ToString().ToLower())
				{
					googleMapMapTypes.Hybrid = true;
				}
				else if (text3.ToLower() == GoogleMapType.RoadMap.ToString().ToLower())
				{
					googleMapMapTypes.RoadMap = true;
				}
				else if (text3.ToLower() == GoogleMapType.Satellite.ToString().ToLower())
				{
					googleMapMapTypes.Satellite = true;
				}
				else if (text3.ToLower() == GoogleMapType.Terrain.ToString().ToLower())
				{
					googleMapMapTypes.Terrain = true;
				}
				else if (text3.ToLower() == GoogleMapType.OpenStreatMap.ToString().ToLower())
				{
					googleMapMapTypes.OpenStreatMap = true;
				}
			}
		}
		return googleMapMapTypes;
	}

	/// <summary>Convert to string as well as design-time code generation</summary>
	/// <returns>The converted object.</returns>
	/// <param name="culture">An object that contains culture specific information, such as the language, calendar, and cultural conventions associated with a specific culture. It is based on the RFC 1766 standard. </param>
	/// <param name="context">A formatter context. This object can be used to get additional information about the environment this converter is being called from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
	/// <param name="destinationType">The type to convert the object to. </param>
	/// <param name="value">The object to convert. </param>
	/// <exception cref="T:System.NotSupportedException">The conversion cannot be completed.</exception>
	/// <filterpriority>1</filterpriority>
	public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object value, Type destinationType)
	{
		if (destinationType == null)
		{
			throw new ArgumentNullException("destinationType");
		}
		if (value is GoogleMapMapTypes)
		{
			if (destinationType == typeof(string))
			{
				GoogleMapMapTypes googleMapMapTypes = (GoogleMapMapTypes)value;
				if (objCulture == null)
				{
					objCulture = CultureInfo.CurrentCulture;
				}
				string text = objCulture.TextInfo.ListSeparator + " ";
				if (googleMapMapTypes.isBlank())
				{
					googleMapMapTypes.RoadMap = true;
				}
				string empty = string.Empty;
				empty += (googleMapMapTypes.RoadMap ? ((string.IsNullOrEmpty(empty) ? "" : text) + GoogleMapType.RoadMap) : "");
				empty += (googleMapMapTypes.Hybrid ? ((string.IsNullOrEmpty(empty) ? "" : text) + GoogleMapType.Hybrid) : "");
				empty += (googleMapMapTypes.Satellite ? ((string.IsNullOrEmpty(empty) ? "" : text) + GoogleMapType.Satellite) : "");
				empty += (googleMapMapTypes.Terrain ? ((string.IsNullOrEmpty(empty) ? "" : text) + GoogleMapType.Terrain) : "");
				return empty + (googleMapMapTypes.OpenStreatMap ? ((string.IsNullOrEmpty(empty) ? "" : text) + GoogleMapType.OpenStreatMap) : "");
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				GoogleMapMapTypes googleMapMapTypes2 = value as GoogleMapMapTypes;
				ConstructorInfo constructor = typeof(GoogleMapMapTypes).GetConstructor(new Type[5]
				{
					typeof(bool),
					typeof(bool),
					typeof(bool),
					typeof(bool),
					typeof(bool)
				});
				if (constructor != null)
				{
					if (googleMapMapTypes2 == null)
					{
						googleMapMapTypes2 = GoogleMapMapTypes.DefaultMapTypes();
					}
					return new InstanceDescriptor(constructor, new object[5] { googleMapMapTypes2.RoadMap, googleMapMapTypes2.Hybrid, googleMapMapTypes2.Satellite, googleMapMapTypes2.Terrain, googleMapMapTypes2.OpenStreatMap });
				}
			}
		}
		return base.ConvertTo(objContext, objCulture, value, destinationType);
	}

	/// <summary>Creates an instance of this type given a set of property values for the object.</summary>
	/// <returns>The newly created object, or null if the object could not be created. The default implementation returns null.</returns>
	/// <param name="propertyValues">A dictionary of new property values. The dictionary contains a series of name-value pairs, one for each property returned from <see cref="M:System.Drawing.GoogleMapLocationConverter.GetProperties(System.ComponentModel.ITypeDescriptorContext,System.Object,System.Attribute[])"></see>. </param>
	/// <param name="context">A type descriptor through which additional context can be provided. </param>
	/// <filterpriority>1</filterpriority>
	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		if (propertyValues == null)
		{
			throw new ArgumentNullException("propertyValues");
		}
		object obj = propertyValues["RoadMap"];
		object obj2 = propertyValues["Hybrid"];
		object obj3 = propertyValues["Satellite"];
		object obj4 = propertyValues["Terrain"];
		object obj5 = propertyValues["OpenStreatMap"];
		if (obj == null || obj2 == null || obj3 == null || obj4 == null || obj5 == null || !(obj is bool) || !(obj2 is bool) || !(obj3 is bool) || !(obj4 is bool) || !(obj5 is bool))
		{
			throw new ArgumentException("Invalid property value.");
		}
		return new GoogleMapMapTypes((bool)obj, (bool)obj2, (bool)obj3, (bool)obj4, (bool)obj5);
	}

	/// <summary>Determines if changing a value on this object should require a call to <see cref="M:GoogleMapTypesConverter.CreateInstance(System.ComponentModel.ITypeDescriptorContext,System.Collections.IDictionary)"></see> to create a new value.</summary>
	/// <returns>true if the <see cref="M:System.Drawing.GoogleMapLocationConverter.CreateInstance(System.ComponentModel.ITypeDescriptorContext,System.Collections.IDictionary)"></see> method should be called when a change is made to one or more properties of this object; otherwise, false.</returns>
	/// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor"></see> through which additional context can be provided. </param>
	/// <filterpriority>1</filterpriority>
	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	/// <summary>Retrieves the set of properties for this type. By default, a type does not return any properties. </summary>
	/// <returns>The set of properties that are exposed for this data type. If no properties are exposed, this method might return null. The default implementation always returns null.</returns>
	/// <param name="context">A type descriptor through which additional context can be provided. </param>
	/// <param name="attributes">An array of <see cref="T:System.Attribute"></see> objects that describe the properties. </param>
	/// <param name="value">The value of the object to get the properties for. </param>
	/// <filterpriority>1</filterpriority>
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		return TypeDescriptor.GetProperties(typeof(GoogleMapMapTypes), attributes).Sort(new string[5] { "RoadMap", "Hybrid", "Satellite", "Terrain", "OpenStreatMap" });
	}

	/// <summary>Determines if this object supports properties. By default, this is false.</summary>
	/// <returns>true if <see cref="M:System.Drawing.GoogleMapLocationConverter.GetProperties(System.ComponentModel.ITypeDescriptorContext,System.Object,System.Attribute[])"></see> should be called to find the properties of this object; otherwise, false.</returns>
	/// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor"></see> through which additional context can be provided. </param>
	/// <filterpriority>1</filterpriority>
	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return true;
	}
}
