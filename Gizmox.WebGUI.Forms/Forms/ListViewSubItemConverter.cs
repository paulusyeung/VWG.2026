// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewSubItemConverter
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
  /// <summary>Summary description for ListViewSubItemConverter.</summary>
  [Serializable]
  public class ListViewSubItemConverter : ExpandableObjectConverter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objDestinationType"></param>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objCulture"></param>
    /// <param name="objValue"></param>
    /// <param name="objDestinationType"></param>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      if (objDestinationType == typeof (InstanceDescriptor) && objValue is ListViewItem.ListViewSubItem)
      {
        object instanceDescriptor = this.ConvertToInstanceDescriptor(objContext, objValue);
        if (instanceDescriptor != null)
          return instanceDescriptor;
      }
      return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
    }

    /// <summary>Convert to InstanceDescriptor</summary>
    /// <remarks>
    /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
    /// </remarks>
    private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
    {
      ListViewItem.ListViewSubItem listViewSubItem = (ListViewItem.ListViewSubItem) objValue;
      ConstructorInfo constructor = typeof (ListViewItem.ListViewSubItem).GetConstructor(new Type[2]
      {
        typeof (ListViewItem),
        typeof (string)
      });
      if (!(constructor != (ConstructorInfo) null))
        return (object) null;
      object[] arguments = new object[2]
      {
        null,
        (object) listViewSubItem.Text
      };
      return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) arguments, true);
    }
  }
}
