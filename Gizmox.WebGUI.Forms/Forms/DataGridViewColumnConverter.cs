// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnConverter
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
  public class DataGridViewColumnConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      DataGridViewColumn objColumn = objValue as DataGridViewColumn;
      if (objDestinationType == typeof (InstanceDescriptor) && objColumn != null)
      {
        object instanceDescriptor = this.ConvertToInstanceDescriptor(objContext, objColumn);
        if (instanceDescriptor != null)
          return instanceDescriptor;
      }
      return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(
      ITypeDescriptorContext objContext,
      DataGridViewColumn objColumn)
    {
      if (objColumn.CellType != (Type) null)
      {
        ConstructorInfo constructor = objColumn.GetType().GetConstructor(new Type[1]
        {
          typeof (Type)
        });
        if (constructor != (ConstructorInfo) null)
          return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[1]
          {
            (object) objColumn.CellType
          }, false);
      }
      ConstructorInfo constructor1 = objColumn.GetType().GetConstructor(new Type[0]);
      return constructor1 != (ConstructorInfo) null ? (object) new InstanceDescriptor((MemberInfo) constructor1, (ICollection) new object[0], false) : (object) null;
    }
  }
}
