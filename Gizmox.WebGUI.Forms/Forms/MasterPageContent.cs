// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MasterPageContent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A Panel control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MasterPageContentSkin))]
  [Gizmox.WebGUI.Forms.MetadataTag("MPC")]
  [Serializable]
  internal class MasterPageContent : ContainerControl, INavigationControl
  {
    public MasterPageContent()
    {
      this.CustomStyle = "MasterPageContentSkin";
      this.Name = "FormsContainer";
      this.ClientId = nameof (MasterPageContent);
    }

    /// <summary>Gets the current navigation control.</summary>
    /// <returns></returns>
    private INavigationControl GetCurrentNavigationControl()
    {
      INavigationControl navigationControl1 = (INavigationControl) null;
      if (this.Context.ActiveForm is Form activeForm && activeForm.ProxyComponent is ProxyForm proxyComponent)
      {
        ProxyComponent navigationControl2 = (ProxyComponent) proxyComponent.NavigationControl;
        if (navigationControl2 != null)
          navigationControl1 = navigationControl2.SourceComponent as INavigationControl;
      }
      return navigationControl1;
    }

    /// <summary>Gets the number of views.</summary>
    int INavigationControl.Count
    {
      get
      {
        INavigationControl navigationControl = this.GetCurrentNavigationControl();
        return navigationControl != null ? navigationControl.Count : -1;
      }
    }

    /// <summary>Move to view index.</summary>
    /// <returns></returns>
    void INavigationControl.MoveTo(int intIndex) => this.GetCurrentNavigationControl()?.MoveTo(intIndex);

    /// <summary>Gets the selected view index.</summary>
    int INavigationControl.SelectedIndex
    {
      get
      {
        INavigationControl navigationControl = this.GetCurrentNavigationControl();
        return navigationControl != null ? navigationControl.SelectedIndex : -1;
      }
    }

    /// <summary>Navigate to first view.</summary>
    bool INavigationControl.MoveFirst()
    {
      INavigationControl navigationControl = this.GetCurrentNavigationControl();
      return navigationControl != null && navigationControl.MoveFirst();
    }

    /// <summary>Navigate to last view.</summary>
    bool INavigationControl.MoveLast()
    {
      INavigationControl navigationControl = this.GetCurrentNavigationControl();
      return navigationControl != null && navigationControl.MoveLast();
    }

    /// <summary>Navigate to next view.</summary>
    bool INavigationControl.MoveNext()
    {
      INavigationControl navigationControl = this.GetCurrentNavigationControl();
      return navigationControl != null && navigationControl.MoveNext();
    }

    /// <summary>Navigate to previous view.</summary>
    bool INavigationControl.MovePrevious()
    {
      INavigationControl navigationControl = this.GetCurrentNavigationControl();
      return navigationControl != null && navigationControl.MovePrevious();
    }
  }
}
