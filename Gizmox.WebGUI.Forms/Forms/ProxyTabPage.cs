// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyTabPage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public class ProxyTabPage : ProxyControl
  {
    /// <summary>The mobj name</summary>
    private string mobjName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPage" /> class.
    /// </summary>
    /// <param name="objComponent">The object component.</param>
    /// <param name="objParentProxy">The object parent proxy.</param>
    public ProxyTabPage(
      Component objComponent,
      ProxyComponent objParentProxy,
      bool blnStateComponent)
      : base(objComponent, objParentProxy, blnStateComponent)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPage" /> class.
    /// </summary>
    public ProxyTabPage()
    {
    }

    /// <summary>Gets or sets the name of the component.</summary>
    public new string Name
    {
      get
      {
        string name = this.mobjName;
        if (string.IsNullOrEmpty(this.mobjName))
          name = "TabPage";
        return name;
      }
      set => this.mobjName = value;
    }

    public override ProxyComponent Parent
    {
      get => base.Parent;
      set
      {
        switch (value)
        {
          case null:
          case ProxyTabControl _:
            base.Parent = value;
            break;
          default:
            throw new ArgumentException(string.Format("Cannot add component of type 'TabPage' to container of type '{0}'", (object) value.GetType().Name));
        }
      }
    }

    /// <summary>Returns wether proxy component is visible.</summary>
    protected override bool GetVisible()
    {
      if (this.Parent is ProxyTabControl parent)
      {
        int num = parent.TabPages.IndexOf((object) this);
        if ((parent.SourceComponent as TabControl).SelectedIndex != num)
          return false;
      }
      return base.GetVisible();
    }

    /// <summary>Gets the proxy component property owner.</summary>
    /// <param name="objPropertyDescriptor"></param>
    /// <returns></returns>
    protected override object GetProxyComponentPropertyOwner(
      PropertyDescriptor objPropertyDescriptor)
    {
      return objPropertyDescriptor != null && objPropertyDescriptor.Name == "Name" ? (object) this : base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
    }

    /// <summary>Gets the proxy component properties.</summary>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    protected override PropertyDescriptorCollection GetProxyComponentProperties(
      Attribute[] arrAttributes)
    {
      PropertyDescriptorCollection componentProperties = base.GetProxyComponentProperties(arrAttributes);
      componentProperties.Add(TypeDescriptor.GetProperties((object) this, arrAttributes, true)["Name"]);
      return componentProperties;
    }
  }
}
