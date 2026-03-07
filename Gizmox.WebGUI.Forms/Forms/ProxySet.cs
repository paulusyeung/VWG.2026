// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxySet
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ProxySet : List<ProxyComponent>, ICustomTypeDescriptor
  {
    private string mstrName = SR.GetString("ProxySet_NewSet");

    /// <summary>Gets or sets the name of the set.</summary>
    /// <value>The name of the set.</value>
    public string Name
    {
      get => this.mstrName;
      set => this.mstrName = value;
    }

    /// <summary>Renders the set.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public void RenderSet(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      for (int index = this.Count - 1; index > -1; --index)
        this[index]?.Render(objContext, objWriter, lngRequestID);
    }

    /// <summary>Pres the render set.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="lngRequestID">The LNG request identifier.</param>
    public void PreRenderSet(IContext objContext, long lngRequestID)
    {
      for (int index = this.Count - 1; index > -1; --index)
        this[index]?.PreRender(objContext, lngRequestID);
    }

    /// <summary>Posts the render set.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="lngRequestID">The LNG request identifier.</param>
    public virtual void PostRenderSet(IContext objContext, long lngRequestID)
    {
      for (int index = this.Count - 1; index > -1; --index)
        this[index]?.PostRender(objContext, lngRequestID);
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

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] arrAttributes)
    {
      List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
      foreach (PropertyDescriptor property in TypeDescriptor.GetProperties((object) this, arrAttributes, true))
      {
        if (property.Name == "Name")
          propertyDescriptorList.Add(property);
      }
      return new PropertyDescriptorCollection(propertyDescriptorList.ToArray());
    }

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => ((ICustomTypeDescriptor) this).GetProperties((Attribute[]) null);

    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor) => (object) this;
  }
}
