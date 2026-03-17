using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides a convertion for the GoogleMapLayer class
/// Remember: For Collection editor to show properties on individual class types, the base class
///             needs at least one property. For this purpose, the Tag property was added.
/// </summary>
public class GoogleMapLayerConverter : TypeConverter
{
	/// <summary>
	/// Returns whether this converter can convert the object to the specified type, using the specified context.
	/// </summary>
	/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
	/// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
	/// <returns>
	/// true if this converter can perform the conversion; otherwise, false.
	/// </returns>
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	/// <summary>
	/// Converts the given value object to the specified type, using the specified context and culture information.
	/// </summary>
	/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
	/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
	/// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
	/// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
	/// <returns>
	/// An <see cref="T:System.Object" /> that represents the converted value.
	/// </returns>
	/// <exception cref="T:System.ArgumentNullException">
	/// The <paramref name="destinationType" /> parameter is null.
	/// </exception>
	/// <exception cref="T:System.NotSupportedException">
	/// The conversion cannot be performed.
	/// </exception>
	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor) && value is GoogleMapLayer)
		{
			ConstructorInfo constructor = ((GoogleMapLayer)value).GetType().GetConstructor(new Type[0]);
			if (constructor != null)
			{
				return new InstanceDescriptor(constructor, null, isComplete: false);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
