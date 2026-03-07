// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.ImmutablePropertyDescriptorGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class ImmutablePropertyDescriptorGridEntry : PropertyDescriptorGridEntry
  {
    internal ImmutablePropertyDescriptorGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGridEntry,
      PropertyDescriptor objPropertyDescriptor,
      bool blnHide)
      : base(objOwnerGrid, objParentGridEntry, objPropertyDescriptor, blnHide)
    {
    }

    internal override bool NotifyValueGivenParent(object objObject, int intType) => this.ParentGridEntry.NotifyValue(intType);

    private GridEntry InstanceParentGridEntry
    {
      get
      {
        GridEntry parentGridEntry = this.ParentGridEntry;
        if (parentGridEntry is CategoryGridEntry)
          parentGridEntry = parentGridEntry.ParentGridEntry;
        return parentGridEntry;
      }
    }

    protected override bool IsPropertyReadOnly => this.ShouldRenderReadOnly;

    public override object PropertyValue
    {
      get => base.PropertyValue;
      set
      {
        object valueOwner = this.GetValueOwner();
        GridEntry instanceParentGridEntry = this.InstanceParentGridEntry;
        TypeConverter typeConverter = instanceParentGridEntry.TypeConverter;
        PropertyDescriptorCollection properties = typeConverter.GetProperties((ITypeDescriptorContext) instanceParentGridEntry, valueOwner);
        IDictionary propertyValues = (IDictionary) new Hashtable(properties.Count);
        for (int index = 0; index < properties.Count; ++index)
        {
          if (this.mobjPropertyInfo.Name != null && this.mobjPropertyInfo.Name.Equals(properties[index].Name))
            propertyValues[(object) properties[index].Name] = value;
          else
            propertyValues[(object) properties[index].Name] = properties[index].GetValue(valueOwner);
        }
        object instance;
        try
        {
          instance = typeConverter.CreateInstance((ITypeDescriptorContext) instanceParentGridEntry, propertyValues);
        }
        catch (Exception ex)
        {
          if (CommonUtils.IsNullOrEmpty(ex.Message))
            throw new TargetInvocationException(Gizmox.WebGUI.Forms.SR.GetString("ExceptionCreatingObject", (object) this.InstanceParentGridEntry.PropertyType.FullName, (object) ex.ToString()), ex);
          throw;
        }
        if (instance == null)
          return;
        instanceParentGridEntry.PropertyValue = instance;
        instanceParentGridEntry.Update(AttributeType.Redraw);
      }
    }

    public override bool ShouldRenderReadOnly => this.InstanceParentGridEntry.ShouldRenderReadOnly;
  }
}
