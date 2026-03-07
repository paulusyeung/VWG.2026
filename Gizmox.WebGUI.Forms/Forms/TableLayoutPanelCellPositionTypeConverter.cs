// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutPanelCellPositionTypeConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  public class TableLayoutPanelCellPositionTypeConverter : TypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) || base.CanConvertFrom(objContext, objSourceType);

    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

    public override object ConvertFrom(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue)
    {
      if (!(objValue is string))
        return base.ConvertFrom(objContext, objCulture, objValue);
      string str = ((string) objValue).Trim();
      if (str.Length == 0)
        return (object) null;
      if (objCulture == null)
        objCulture = CultureInfo.CurrentCulture;
      char ch = objCulture.TextInfo.ListSeparator[0];
      string[] strArray = str.Split(ch);
      int[] numArray = new int[strArray.Length];
      TypeConverter converter = TypeDescriptor.GetConverter(typeof (int));
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = (int) converter.ConvertFromString(objContext, objCulture, strArray[index]);
      return numArray.Length == 2 ? (object) new TableLayoutPanelCellPosition(numArray[0], numArray[1]) : throw new ArgumentException(SR.GetString("TextParseFailedFormat", (object) str, (object) "column, row"));
    }

    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      return objDestinationType == typeof (InstanceDescriptor) && objValue is TableLayoutPanelCellPosition ? this.ConvertToInstanceDescriptor(objContext, objValue) : base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
    {
      TableLayoutPanelCellPosition panelCellPosition = (TableLayoutPanelCellPosition) objValue;
      return (object) new InstanceDescriptor((MemberInfo) typeof (TableLayoutPanelCellPosition).GetConstructor(new Type[2]
      {
        typeof (int),
        typeof (int)
      }), (ICollection) new object[2]
      {
        (object) panelCellPosition.Column,
        (object) panelCellPosition.Row
      });
    }

    public object CreateInstance(ITypeDescriptorContext objContext, Hashtable objPropertyValues) => (object) new TableLayoutPanelCellPosition((int) objPropertyValues[(object) "Column"], (int) objPropertyValues[(object) "Row"]);

    public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext) => true;

    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objValue,
      Attribute[] arrAttributes)
    {
      return TypeDescriptor.GetProperties(typeof (TableLayoutPanelCellPosition), arrAttributes).Sort(new string[2]
      {
        "Column",
        "Row"
      });
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;
  }
}
