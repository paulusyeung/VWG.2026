// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowConverter
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
  public class DataGridViewRowConverter : ExpandableObjectConverter
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
      DataGridViewRow objRow = objValue as DataGridViewRow;
      if (objDestinationType == typeof (InstanceDescriptor) && objRow != null)
      {
        InstanceDescriptor instanceDescriptor = this.ConvertToInstanceDescriptor(objRow);
        if (instanceDescriptor != null)
          return (object) instanceDescriptor;
      }
      return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private InstanceDescriptor ConvertToInstanceDescriptor(DataGridViewRow objRow)
    {
      ConstructorInfo constructor = objRow.GetType().GetConstructor(new Type[0]);
      return constructor != (ConstructorInfo) null ? new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[0], false) : (InstanceDescriptor) null;
    }
  }
}
