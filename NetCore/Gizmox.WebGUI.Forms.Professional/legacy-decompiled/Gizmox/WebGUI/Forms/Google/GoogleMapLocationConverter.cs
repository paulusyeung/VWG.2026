using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>Converts a <see cref="T:System.Drawing.GoogleMapLocation"></see> object from one data type to another. Access this class through the <see cref="T:System.ComponentModel.TypeDescriptor"></see> object.</summary>
/// <filterpriority>1</filterpriority>
public class GoogleMapLocationConverter : TypeConverter
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
	/// Converts from.
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
			return null;
		}
		if (objCulture == null)
		{
			objCulture = CultureInfo.CurrentCulture;
		}
		char c = objCulture.TextInfo.ListSeparator[0];
		string[] array = text2.Split(c);
		double[] array2 = new double[array.Length];
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = (double)converter.ConvertFromString(objContext, objCulture, array[i]);
		}
		if (array2.Length == 2)
		{
			return new GoogleMapLocation(array2[0], array2[1]);
		}
		if (array2.Length == 3)
		{
			return new GoogleMapWeightedLocation(array2[0], array2[1], array2[2]);
		}
		throw new ArgumentException("Invalid string format.");
	}

	/// <summary>Converts the specified object to the specified type.</summary>
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
		if (value is GoogleMapWeightedLocation)
		{
			if (destinationType == typeof(string))
			{
				GoogleMapWeightedLocation googleMapWeightedLocation = (GoogleMapWeightedLocation)value;
				if (objCulture == null)
				{
					objCulture = CultureInfo.CurrentCulture;
				}
				string separator = objCulture.TextInfo.ListSeparator + " ";
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
				string[] array = new string[3];
				int num = 0;
				array[num++] = converter.ConvertToString(objContext, objCulture, googleMapWeightedLocation.Latitude);
				array[num++] = converter.ConvertToString(objContext, objCulture, googleMapWeightedLocation.Longitude);
				array[num++] = converter.ConvertToString(objContext, objCulture, googleMapWeightedLocation.Weight);
				return string.Join(separator, array);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				GoogleMapWeightedLocation googleMapWeightedLocation2 = (GoogleMapWeightedLocation)value;
				ConstructorInfo constructor = typeof(GoogleMapWeightedLocation).GetConstructor(new Type[3]
				{
					typeof(double),
					typeof(double),
					typeof(double)
				});
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, new object[3] { googleMapWeightedLocation2.Latitude, googleMapWeightedLocation2.Longitude, googleMapWeightedLocation2.Weight });
				}
			}
		}
		else if (value is GoogleMapLocation)
		{
			if (destinationType == typeof(string))
			{
				GoogleMapLocation googleMapLocation = (GoogleMapLocation)value;
				if (objCulture == null)
				{
					objCulture = CultureInfo.CurrentCulture;
				}
				string separator2 = objCulture.TextInfo.ListSeparator + " ";
				TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(double));
				string[] array2 = new string[2];
				int num2 = 0;
				array2[num2++] = converter2.ConvertToString(objContext, objCulture, googleMapLocation.Latitude);
				array2[num2++] = converter2.ConvertToString(objContext, objCulture, googleMapLocation.Longitude);
				return string.Join(separator2, array2);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				GoogleMapLocation googleMapLocation2 = (GoogleMapLocation)value;
				ConstructorInfo constructor2 = typeof(GoogleMapLocation).GetConstructor(new Type[2]
				{
					typeof(double),
					typeof(double)
				});
				if (constructor2 != null)
				{
					if (googleMapLocation2 == null)
					{
						googleMapLocation2 = GoogleMapLocation.Empty;
					}
					return new InstanceDescriptor(constructor2, new object[2] { googleMapLocation2.Latitude, googleMapLocation2.Longitude });
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
		if (context.PropertyDescriptor.PropertyType == typeof(GoogleMapWeightedLocation))
		{
			object obj = propertyValues["Latitude"];
			object obj2 = propertyValues["Longitude"];
			object obj3 = propertyValues["Weight"];
			if (obj == null || obj2 == null || obj3 == null || !(obj is double) || !(obj2 is double) || !(obj3 is double))
			{
				throw new ArgumentException("Invalid property value.");
			}
			return new GoogleMapWeightedLocation((double)obj, (double)obj2, (double)obj3);
		}
		object obj4 = propertyValues["Latitude"];
		object obj5 = propertyValues["Longitude"];
		if (obj4 == null || obj5 == null || !(obj4 is double) || !(obj5 is double))
		{
			throw new ArgumentException("Invalid property value.");
		}
		return new GoogleMapLocation((double)obj4, (double)obj5);
	}

	/// <summary>Determines if changing a value on this object should require a call to <see cref="M:System.Drawing.GoogleMapLocationConverter.CreateInstance(System.ComponentModel.ITypeDescriptorContext,System.Collections.IDictionary)"></see> to create a new value.</summary>
	/// <returns>true if the <see cref="M:System.Drawing.GoogleMapLocationConverter.CreateInstance(System.ComponentModel.ITypeDescriptorContext,System.Collections.IDictionary)"></see> method should be called when a change is made to one or more properties of this object; otherwise, false.</returns>
	/// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor"></see> through which additional context can be provided. </param>
	/// <filterpriority>1</filterpriority>
	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return false;
	}

	/// <summary>
	/// We want collapsible property editing
	///
	/// When acting as collection within a collection, it is important not to support GetProperties, as it will
	/// result in a list of properties for the wrong object type. In that case, only support properties for the
	/// types you want to support properties for, in this case the two Location types.
	/// </summary>
	/// <param name="context"></param>
	/// <returns></returns>
	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		if (context != null && context.PropertyDescriptor != null && context.PropertyDescriptor.PropertyType != null)
		{
			if (context.PropertyDescriptor.PropertyType == typeof(GoogleMapLocation) || context.PropertyDescriptor.PropertyType == typeof(GoogleMapWeightedLocation))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// Properties to support on collapsible editing
	/// </summary>
	/// <param name="context"></param>
	/// <param name="value"></param>
	/// <param name="attributes"></param>
	/// <returns></returns>
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		return TypeDescriptor.GetProperties(value.GetType(), attributes);
	}
}
