// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyAction
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class ProxyAction : ICustomTypeDescriptor
  {
    private ProxyComponent mobjActionOwner;

    /// <summary>Gets or sets the action owner.</summary>
    /// <value>The action owner.</value>
    public ProxyComponent ActionOwner
    {
      get => this.mobjActionOwner;
      set => this.mobjActionOwner = value;
    }

    /// <summary>Executes action.</summary>
    public abstract void Execute();

    /// <summary>Gets the filtered custom properties.</summary>
    /// <param name="objPropertyDescriptorCollection">The object property descriptor collection.</param>
    /// <returns></returns>
    protected virtual PropertyDescriptorCollection GetFilteredCustomProperties(
      PropertyDescriptorCollection objPropertyDescriptorCollection)
    {
      return objPropertyDescriptorCollection;
    }

    /// <summary>Gets the custom properties.</summary>
    /// <param name="attributes">The attributes.</param>
    /// <returns></returns>
    private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
    {
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties((object) this, attributes, true);
      List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
      foreach (PropertyDescriptor propertyDescriptor in properties)
      {
        bool flag = true;
        if (propertyDescriptor.Attributes[typeof (BrowsableAttribute)] is BrowsableAttribute attribute)
          flag = attribute.Browsable;
        if (flag && propertyDescriptor.Name == "ActionOwner")
          flag = false;
        if (flag)
          propertyDescriptorList.Add(propertyDescriptor);
      }
      return this.GetFilteredCustomProperties(new PropertyDescriptorCollection(propertyDescriptorList.ToArray()));
    }

    AttributeCollection ICustomTypeDescriptor.GetAttributes() => TypeDescriptor.GetAttributes((object) this, true);

    string ICustomTypeDescriptor.GetClassName() => TypeDescriptor.GetClassName((object) this, true);

    string ICustomTypeDescriptor.GetComponentName() => TypeDescriptor.GetComponentName((object) this, true);

    TypeConverter ICustomTypeDescriptor.GetConverter() => TypeDescriptor.GetConverter((object) this, true);

    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => TypeDescriptor.GetDefaultEvent((object) this, true);

    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => TypeDescriptor.GetDefaultProperty((object) this, true);

    object ICustomTypeDescriptor.GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor((object) this, editorBaseType, true);

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents((object) this, attributes, true);

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => TypeDescriptor.GetEvents((object) this, true);

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) => this.GetCustomProperties(attributes);

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => this.GetCustomProperties((Attribute[]) null);

    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) => (object) this;
  }
}
