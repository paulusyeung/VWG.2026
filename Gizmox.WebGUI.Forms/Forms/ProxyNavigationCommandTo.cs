// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyNavigationCommandTo
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

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
  [WebCollectionEditorItemTypeName("Navigate To")]
  [Serializable]
  public class ProxyNavigationCommandTo : ProxyNavigationCommand
  {
    private int mintIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyNavigationCommandLast" /> class.
    /// </summary>
    public ProxyNavigationCommandTo() => base.NavigationCommandTarget = NavigationCommandTarget.NavigationControl;

    /// <summary>Does the navigation.</summary>
    /// <param name="objINavigationControl">The obj I navigation control.</param>
    /// <returns></returns>
    public override bool DoNavigation(INavigationControl objINavigationControl)
    {
      if (objINavigationControl == null)
        return false;
      objINavigationControl.MoveTo(this.Index);
      return true;
    }

    /// <summary>Does the navigation.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objList">The obj list.</param>
    /// <param name="objForm">The obj form.</param>
    /// <returns></returns>
    public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm) => false;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Format("Navigate To Index {0}", (object) this.mintIndex);

    /// <summary>Gets or sets the navigation command target.</summary>
    /// <value>The navigation command target.</value>
    [Browsable(false)]
    public override NavigationCommandTarget NavigationCommandTarget
    {
      get => base.NavigationCommandTarget;
      set
      {
      }
    }

    /// <summary>Gets or sets the index.</summary>
    /// <value>The index.</value>
    public int Index
    {
      get => this.mintIndex;
      set => this.mintIndex = value;
    }
  }
}
