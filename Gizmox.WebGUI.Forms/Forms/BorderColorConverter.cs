// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BorderColorConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> values to and from various other representations.
  /// </summary>
  [Serializable]
  public class BorderColorConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || objDestinationType == typeof (SkinValue) || objDestinationType == typeof (string) || base.CanConvertTo(objContext, objDestinationType);

    /// <summary>
    /// Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"></see>. If null is passed, the current culture is assumed.</param>
    /// <param name="objValue">The <see cref="T:System.Object"></see> to convert.</param>
    /// <param name="objDestinationType">The <see cref="T:System.Type"></see> to convert the value parameter to.</param>
    /// <returns>
    /// An <see cref="T:System.Object"></see> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
    /// <exception cref="T:System.ArgumentNullException">The objDestinationType parameter is null. </exception>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      if (objDestinationType == typeof (SkinValue))
        return (object) new BorderColorConverter.BorderColorSkinValue((BorderColor) objValue);
      if (objDestinationType == typeof (string) && objValue is BorderColor borderColor)
      {
        if (borderColor.ShouldSerializeAll())
          return this.GetColorString(borderColor.All, objCulture);
        return (object) string.Format("{0} {1} {2} {3}", this.GetColorString(borderColor.Left, objCulture), this.GetColorString(borderColor.Top, objCulture), this.GetColorString(borderColor.Right, objCulture), this.GetColorString(borderColor.Bottom, objCulture));
      }
      return objDestinationType == typeof (InstanceDescriptor) && objValue is BorderColor ? this.ConvertToInstanceDescriptor(objContext, objValue) : base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
    {
      BorderColor borderColor = (BorderColor) objValue;
      if (borderColor.ShouldSerializeAll())
      {
        Type[] types = new Type[1]{ typeof (Color) };
        object[] arguments = new object[1]
        {
          (object) borderColor.All
        };
        return (object) new InstanceDescriptor((MemberInfo) typeof (BorderColor).GetConstructor(types), (ICollection) arguments);
      }
      Type[] types1 = new Type[4]
      {
        typeof (Color),
        typeof (Color),
        typeof (Color),
        typeof (Color)
      };
      object[] arguments1 = new object[4]
      {
        (object) borderColor.Left,
        (object) borderColor.Top,
        (object) borderColor.Right,
        (object) borderColor.Bottom
      };
      return (object) new InstanceDescriptor((MemberInfo) typeof (BorderColor).GetConstructor(types1), (ICollection) arguments1);
    }

    private object GetColorString(Color objColor, CultureInfo objCulture) => (object) TypeDescriptor.GetConverter(typeof (Color)).ConvertToString((ITypeDescriptorContext) null, objCulture, (object) objColor);

    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) || base.CanConvertFrom(objContext, objSourceType);

    public override object ConvertFrom(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue)
    {
      if (!(objValue is string))
        return base.ConvertFrom(objContext, objCulture, objValue);
      string str = (string) objValue;
      if (string.IsNullOrEmpty(str))
        return (object) BorderColor.Empty;
      string newValue = ",";
      if (objCulture != null)
        newValue = objCulture.TextInfo.ListSeparator;
      string[] strArray = str.Replace(newValue + " ", newValue).Split(' ');
      if (strArray.Length == 1)
        return (object) new BorderColor(this.ConvertColor(strArray[0], objCulture));
      if (strArray.Length == 2)
        return (object) new BorderColor(this.ConvertColor(strArray[0], objCulture), this.ConvertColor(strArray[1], objCulture), this.ConvertColor(strArray[1], objCulture), this.ConvertColor(strArray[1], objCulture));
      if (strArray.Length == 3)
        return (object) new BorderColor(this.ConvertColor(strArray[0], objCulture), this.ConvertColor(strArray[1], objCulture), this.ConvertColor(strArray[2], objCulture), this.ConvertColor(strArray[2], objCulture));
      return strArray.Length == 4 ? (object) new BorderColor(this.ConvertColor(strArray[0], objCulture), this.ConvertColor(strArray[1], objCulture), this.ConvertColor(strArray[2], objCulture), this.ConvertColor(strArray[3], objCulture)) : (object) BorderColor.Empty;
    }

    /// <summary>Converts the color.</summary>
    /// <param name="strColor">Color in string format.</param>
    /// <param name="objCulture">The culture.</param>
    /// <returns></returns>
    private Color ConvertColor(string strColor, CultureInfo objCulture) => (Color) TypeDescriptor.GetConverter(typeof (Color)).ConvertFromString((ITypeDescriptorContext) null, objCulture, strColor);

    /// <summary>
    /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
    /// <returns>
    /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
    /// </returns>
    public override object CreateInstance(
      ITypeDescriptorContext objContext,
      IDictionary objPropertyValues)
    {
      BorderColor borderColor = (BorderColor) objContext.PropertyDescriptor.GetValue(objContext.Instance);
      Color objPropertyValue1 = (Color) objPropertyValues[(object) "Left"];
      Color objPropertyValue2 = (Color) objPropertyValues[(object) "Top"];
      Color objPropertyValue3 = (Color) objPropertyValues[(object) "Right"];
      Color objPropertyValue4 = (Color) objPropertyValues[(object) "Bottom"];
      return objPropertyValue1 == objPropertyValue3 && objPropertyValue3 == objPropertyValue2 && objPropertyValue2 == objPropertyValue4 ? (object) new BorderColor(objPropertyValue1) : (object) new BorderColor(objPropertyValue1, objPropertyValue2, objPropertyValue3, objPropertyValue4);
    }

    /// <summary>
    /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <returns>
    /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
    /// </returns>
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext) => true;

    /// <summary>
    /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
    /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
    /// </returns>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objValue,
      Attribute[] arrAttributes)
    {
      return TypeDescriptor.GetProperties(typeof (BorderColor), arrAttributes).Sort(new string[5]
      {
        "All",
        "Left",
        "Top",
        "Right",
        "Bottom"
      });
    }

    /// <summary>
    /// Returns whether this object supports properties, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <returns>
    /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
    /// </returns>
    public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;

    /// <summary>Provides a SkinValue implementation of color</summary>
    [Serializable]
    internal class BorderColorSkinValue : SkinValue
    {
      /// <summary>
      /// 
      /// </summary>
      private BorderColor mobjValue;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColorConverter.BorderColorSkinValue" /> class.
      /// </summary>
      /// <param name="objValue">The color value.</param>
      public BorderColorSkinValue(BorderColor objValue) => this.mobjValue = objValue;

      /// <summary>Gets the value.</summary>
      /// <param name="objContext">The current context.</param>
      /// <returns></returns>
      public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
      {
        if (this.mobjValue.IsAll)
          return string.Format("{0}", (object) this.mobjValue.All);
        return string.Format("{0} {1} {2} {3}", (object) this.mobjValue.Top, (object) this.mobjValue.Right, (object) this.mobjValue.Bottom, (object) this.mobjValue.Left);
      }
    }
  }
}
