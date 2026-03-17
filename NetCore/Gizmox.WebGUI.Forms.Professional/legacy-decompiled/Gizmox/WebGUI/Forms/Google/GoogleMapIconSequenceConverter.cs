using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Google;

public class GoogleMapIconSequenceConverter : TypeConverter
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
	/// For Code generation, override ConvertTo
	/// </summary>
	/// <param name="context"></param>
	/// <param name="culture"></param>
	/// <param name="value"></param>
	/// <param name="destinationType"></param>
	/// <returns></returns>
	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor))
		{
			GoogleMapIconSequence googleMapIconSequence = (GoogleMapIconSequence)value;
			ConstructorInfo constructor = typeof(GoogleMapIconSequence).GetConstructor(new Type[3]
			{
				typeof(GoogleMapSymbol),
				typeof(string),
				typeof(string)
			});
			if (constructor != null)
			{
				return new InstanceDescriptor(constructor, new object[3] { googleMapIconSequence.Icon, googleMapIconSequence.Offset, googleMapIconSequence.Repeat });
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	/// <summary>
	/// Class has properties, we want collapsible property editing
	/// </summary>
	/// <param name="context"></param>
	/// <returns></returns>
	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return true;
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
