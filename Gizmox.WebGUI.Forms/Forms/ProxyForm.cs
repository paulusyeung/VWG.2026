// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyForm
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyForm : ProxyControl, IProxyForm
  {
    private string mstrMasterPageId;
    private IEmulatorForm mobjEmulatorForm;
    private ProxyControl mobjNavigationControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyForm" /> class.
    /// </summary>
    public ProxyForm()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyForm" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyForm(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
      : base(objComponent, objParent, blnStateComponent)
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

    /// <summary>Gets or sets the application master page.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string MasterPageId
    {
      get => this.mstrMasterPageId;
      set => this.mstrMasterPageId = value;
    }

    /// <summary>Gets or sets the application master page.</summary>
    [Category("Emulation")]
    [Description("The default master page name for the form.")]
    [DefaultValue("")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [WebEditor("Gizmox.WebGUI.Forms.Design.MasterPageSelectEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    public string MasterPage
    {
      get
      {
        IProxyMasterPage masterPageById = this.EmulatorForm.GetMasterPageById(this.MasterPageId);
        return masterPageById == null ? this.EmulatorForm.MasterPageInheritName : this.EmulatorForm.GetMasterPageDisplayName(masterPageById);
      }
      set => this.MasterPageId = value;
    }

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      if (this.ParentForm == null)
        return;
      this.ParentForm.Update();
    }

    /// <summary>Redraw only</summary>
    /// <param name="blnRedrawOnly"></param>
    public override void Update(bool blnRedrawOnly)
    {
      base.Update(blnRedrawOnly);
      if (this.ParentForm == null)
        return;
      this.ParentForm.Update(blnRedrawOnly);
    }

    public override void Update(bool blnRedrawOnly, bool blnUseClientUpdateHandler)
    {
      base.Update(blnRedrawOnly, blnUseClientUpdateHandler);
      if (this.ParentForm == null)
        return;
      this.ParentForm.Update(blnRedrawOnly, blnUseClientUpdateHandler);
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
    private bool IsProxyProperty(PropertyDescriptor objPropertyDescriptor)
    {
      if (objPropertyDescriptor != null)
      {
        switch (objPropertyDescriptor.Name)
        {
          case "FullScreenMode":
            if (this.EmulatorForm != null)
              return this.SourceComponent == this.EmulatorForm.MainForm;
            break;
          case "MasterPage":
            return true;
          case "NavigationControl":
            return true;
        }
      }
      return false;
    }

    /// <summary>Gets the proxy component property owner.</summary>
    /// <param name="objPropertyDescriptor"></param>
    /// <returns></returns>
    protected override object GetProxyComponentPropertyOwner(
      PropertyDescriptor objPropertyDescriptor)
    {
      return this.IsProxyProperty(objPropertyDescriptor) ? (object) this : base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
    }

    /// <summary>Validates the source component.</summary>
    internal override void ValidateSourceComponent()
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        if (component is ProxyControl proxyControl)
          proxyControl.ValidateSourceComponent();
      }
    }

    /// <summary>Gets or sets the navigation control.</summary>
    /// <value>The navigation control.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    [TypeConverter(typeof (EmptyExpandableObjectConverter))]
    public ProxyControl NavigationControl
    {
      get => this.mobjNavigationControl;
      set => this.mobjNavigationControl = value;
    }

    /// <summary>Gets or sets the parent form.</summary>
    /// <value>The parent form.</value>
    IForm IProxyForm.ParentForm
    {
      get => (IForm) this.ParentForm;
      set => this.ParentForm = value as Form;
    }
  }
}
