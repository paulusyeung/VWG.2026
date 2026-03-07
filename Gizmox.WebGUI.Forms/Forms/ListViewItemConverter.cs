// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewItemConverter
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
  /// <summary>
  /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to and from various other representations.
  /// </summary>
  [Serializable]
  public class ListViewItemConverter : ExpandableObjectConverter
  {
    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type"></see> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => objDestinationType == typeof (InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);

    /// <summary>
    /// Converts the given value object to the specified type, using the specified context and culture information.
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
      if (objDestinationType == typeof (InstanceDescriptor) && objValue is ListViewItem)
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
      ListViewItem listViewItem = (ListViewItem) objValue;
      string[] strArray = new string[listViewItem.SubItems.Count];
      for (int index = 0; index < strArray.Length; ++index)
        strArray[index] = listViewItem.SubItems[index].Text;
      if (listViewItem.ImageIndex == -1 && listViewItem.SubItems.Count <= 1)
      {
        ConstructorInfo constructor = typeof (ListViewItem).GetConstructor(new Type[1]
        {
          typeof (string)
        });
        if (constructor != (ConstructorInfo) null)
        {
          object[] arguments = new object[1]
          {
            (object) listViewItem.Text
          };
          return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) arguments, false);
        }
      }
      if (listViewItem.SubItems.Count <= 1)
      {
        ConstructorInfo constructor = typeof (ListViewItem).GetConstructor(new Type[2]
        {
          typeof (string),
          typeof (int)
        });
        if (constructor != (ConstructorInfo) null)
        {
          object[] arguments = new object[2]
          {
            (object) listViewItem.Text,
            (object) listViewItem.ImageIndex
          };
          return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) arguments, false);
        }
      }
      ConstructorInfo constructor1 = typeof (ListViewItem).GetConstructor(new Type[2]
      {
        typeof (string[]),
        typeof (int)
      });
      if (!(constructor1 != (ConstructorInfo) null))
        return (object) null;
      object[] arguments1 = new object[2]
      {
        (object) strArray,
        (object) listViewItem.ImageIndex
      };
      return (object) new InstanceDescriptor((MemberInfo) constructor1, (ICollection) arguments1, false);
    }
  }
}
