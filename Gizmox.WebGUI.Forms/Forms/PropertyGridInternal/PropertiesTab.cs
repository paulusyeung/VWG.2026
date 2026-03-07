// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.PropertiesTab
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  /// <summary>
  /// Represents the Properties tab on a PropertyGrid control.
  /// </summary>
  [Serializable]
  public class PropertiesTab : PropertyTab
  {
    /// <summary>Gets the default Property Descriptor.</summary>
    /// <param name="objObject">The obj object.</param>
    /// <returns></returns>
    public override PropertyDescriptor GetDefaultProperty(object objObject)
    {
      PropertyDescriptor defaultProperty = base.GetDefaultProperty(objObject);
      if (defaultProperty == null)
      {
        PropertyDescriptorCollection properties = this.GetProperties(objObject);
        if (properties == null)
          return defaultProperty;
        for (int index = 0; index < properties.Count; ++index)
        {
          if ("Name".Equals(properties[index].Name))
            return properties[index];
        }
      }
      return defaultProperty;
    }

    /// <summary>Returns a collection of property descriors</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    public override PropertyDescriptorCollection GetProperties(
      object objComponent,
      Attribute[] arrAttributes)
    {
      return this.GetProperties((ITypeDescriptorContext) null, objComponent, arrAttributes);
    }

    /// <summary>Returns a collection of property descriors</summary>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objComponent,
      Attribute[] arrAttributes)
    {
      if (arrAttributes == null)
        arrAttributes = new Attribute[1]
        {
          (Attribute) BrowsableAttribute.Yes
        };
      if (CommonUtils.IsEnvironmentSecurityPermitted)
      {
        Attribute[] attributeArray1 = new Attribute[arrAttributes.Length + 1];
        arrAttributes.CopyTo((Array) attributeArray1, 0);
        Attribute[] attributeArray2 = attributeArray1;
        attributeArray2[attributeArray2.Length - 1] = (Attribute) LimitedTrustBrowsableAttribute.Yes;
        arrAttributes = attributeArray1;
      }
      if (objContext != null)
      {
        TypeConverter typeConverter = objContext.PropertyDescriptor == null ? TypeDescriptor.GetConverter(objComponent) : objContext.PropertyDescriptor.Converter;
        if (typeConverter != null && typeConverter.GetPropertiesSupported(objContext))
          return typeConverter.GetProperties(objContext, objComponent, arrAttributes);
      }
      return TypeDescriptor.GetProperties(objComponent, arrAttributes);
    }

    /// <summary>
    /// Gets the Help keyword that is to be associated with this tab.
    /// </summary>
    /// <value></value>
    /// <returns>The string vs.properties.</returns>
    public override string HelpKeyword => "vs.properties";

    /// <summary>Gets the name of the Properties tab.</summary>
    /// <returns>The string Properties.</returns>
    public override string TabName => Gizmox.WebGUI.Forms.SR.GetString("PBRSToolTipProperties");
  }
}
