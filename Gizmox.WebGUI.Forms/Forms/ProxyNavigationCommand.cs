// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyNavigationCommand
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class ProxyNavigationCommand : ProxyAction
  {
    protected NavigationCommandTarget menmNavigationCommandTarget;
    protected ProxyControl mobjTargetNavigationControl;

    /// <summary>Does the navigation.</summary>
    /// <param name="objINavigationControl">The obj I navigation control.</param>
    /// <returns></returns>
    public abstract bool DoNavigation(INavigationControl objINavigationControl);

    /// <summary>Does the navigation.</summary>
    /// <param name="objList">The obj list.</param>
    /// <returns></returns>
    public abstract bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm);

    /// <summary>Executes action.</summary>
    public override void Execute()
    {
      bool flag = false;
      IContext context = Global.Context;
      if (context == null)
        return;
      if (this.menmNavigationCommandTarget == NavigationCommandTarget.FullNavigation || this.menmNavigationCommandTarget == NavigationCommandTarget.NavigationControl)
      {
        ProxyControl navigationControl = this.TargetNavigationControl;
        if (navigationControl != null && navigationControl.SourceComponent is INavigationControl sourceComponent)
          flag = this.DoNavigation(sourceComponent);
      }
      if (this.menmNavigationCommandTarget != NavigationCommandTarget.Form && (flag || this.menmNavigationCommandTarget != NavigationCommandTarget.FullNavigation) || !context.FullScreenMode)
        return;
      List<IForm> objList = new List<IForm>((IEnumerable<IForm>) ((IFormResolver) context).AccessibleForms);
      if (!(context.ActiveForm is Form activeForm))
        return;
      this.DoNavigation(context, objList, activeForm);
    }

    /// <summary>Gets the filtered custom properties.</summary>
    /// <param name="objPropertyDescriptorCollection">The object property descriptor collection.</param>
    /// <returns></returns>
    protected override PropertyDescriptorCollection GetFilteredCustomProperties(
      PropertyDescriptorCollection objPropertyDescriptorCollection)
    {
      List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
      foreach (PropertyDescriptor propertyDescriptor in objPropertyDescriptorCollection)
      {
        bool flag = true;
        if (propertyDescriptor.Name == "TargetNavigationControl")
          flag = this.NavigationCommandTarget != NavigationCommandTarget.Form;
        if (flag)
          propertyDescriptorList.Add(propertyDescriptor);
      }
      return new PropertyDescriptorCollection(propertyDescriptorList.ToArray());
    }

    /// <summary>Shoulds the serialize target navigation control.</summary>
    /// <returns></returns>
    private bool ShouldSerializeTargetNavigationControl() => this.TargetNavigationControl != null && this.NavigationCommandTarget != NavigationCommandTarget.Form;

    /// <summary>Gets or sets the navigation command target.</summary>
    /// <value>The navigation command target.</value>
    [Description("Form - will execute the Navigation Command on the available forms list.\r\nNavigationControl - will execute the Navigation Command on the selected Navigation Control.\r\nFullNavigation – will try to execute the Navigation Command on the selected Navigation Control (if navigation is available) otherwise the Navigation Command is executed on the forms list.")]
    [RefreshProperties(RefreshProperties.All)]
    public virtual NavigationCommandTarget NavigationCommandTarget
    {
      get => this.menmNavigationCommandTarget;
      set => this.menmNavigationCommandTarget = value;
    }

    /// <summary>Gets or sets the target navigation control.</summary>
    /// <value>The target navigation control.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.TargetNavigationControlEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    [TypeConverter(typeof (EmptyExpandableObjectConverter))]
    public ProxyControl TargetNavigationControl
    {
      get => this.mobjTargetNavigationControl;
      set => this.mobjTargetNavigationControl = value;
    }
  }
}
