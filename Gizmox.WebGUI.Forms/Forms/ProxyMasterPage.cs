// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyMasterPage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyMasterPage : ProxyControl, IProxyMasterPage
  {
    private string mstrName;
    private string mstrMasterPageId;
    private IEmulatorForm mobjEmulatorForm;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMasterPage" /> class.
    /// </summary>
    public ProxyMasterPage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMasterPage" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    public ProxyMasterPage(Component objComponent)
      : base(objComponent, (ProxyComponent) null, false)
    {
    }

    internal IEmulatorForm EmulatorForm
    {
      get
      {
        if (this.mobjEmulatorForm == null)
        {
          if (!(this.Context is IContextParams context))
            return (IEmulatorForm) null;
          this.mobjEmulatorForm = context.EmulatorForm;
        }
        return this.mobjEmulatorForm;
      }
    }

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.SourceComponent.Update();
    }

    /// <summary>Gets or sets the id of the master page.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public string MasterPageId
    {
      get
      {
        if (this.mstrMasterPageId == null)
          this.mstrMasterPageId = Guid.NewGuid().ToString();
        return this.mstrMasterPageId;
      }
      set => this.mstrMasterPageId = value;
    }

    /// <summary>Gets or sets the name of the master page.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [RefreshProperties(RefreshProperties.Repaint)]
    public override string Name
    {
      get => this.mstrName;
      set => this.mstrName = value;
    }

    /// <summary>Gets the proxy component properties.</summary>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    protected override PropertyDescriptorCollection GetProxyComponentProperties(
      Attribute[] arrAttributes)
    {
      PropertyDescriptorCollection componentProperties = base.GetProxyComponentProperties(arrAttributes);
      foreach (PropertyDescriptor property in TypeDescriptor.GetProperties((object) this, arrAttributes, true))
      {
        if (this.IsProxyProperty(property))
          componentProperties.Add(property);
      }
      return componentProperties;
    }

    /// <summary>
    /// Determines whether [is proxy property] [the specified obj property descriptor].
    /// </summary>
    /// <param name="objPropertyDescriptor">The obj property descriptor.</param>
    /// <returns>
    ///   <c>true</c> if [is proxy property] [the specified obj property descriptor]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsProxyProperty(PropertyDescriptor objPropertyDescriptor) => objPropertyDescriptor != null && objPropertyDescriptor.Name == "Name";

    /// <summary>Gets the proxy component property owner.</summary>
    /// <param name="objPropertyDescriptor"></param>
    /// <returns></returns>
    protected override object GetProxyComponentPropertyOwner(
      PropertyDescriptor objPropertyDescriptor)
    {
      return this.IsProxyProperty(objPropertyDescriptor) ? (object) this : base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
    }

    void IProxyMasterPage.Render(IContext objContext, IResponseWriter objWriter, long lngRequestID) => this.Render(objContext, objWriter, lngRequestID);

    void IProxyMasterPage.PreRender(IContext objContext, long lngRequestID) => this.PreRender(objContext, lngRequestID);

    void IProxyMasterPage.PostRender(IContext objContext, long lngRequestID) => this.PostRender(objContext, lngRequestID);
  }
}
