// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyNavigationCommandLast
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [WebCollectionEditorItemTypeName("Navigate Last")]
  [Serializable]
  public class ProxyNavigationCommandLast : ProxyNavigationCommand
  {
    /// <summary>Does the navigation.</summary>
    /// <param name="objINavigationControl">The obj I navigation control.</param>
    /// <returns></returns>
    public override bool DoNavigation(INavigationControl objINavigationControl) => objINavigationControl != null && objINavigationControl.MoveLast();

    /// <summary>Does the navigation.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objList">The obj list.</param>
    /// <param name="objForm">The obj form.</param>
    /// <returns></returns>
    public override bool DoNavigation(IContext objContext, List<IForm> objList, Form objForm)
    {
      if (objList != null && objForm != null)
      {
        List<IForm> formList = objList;
        long id = ((RegisteredComponent) formList[formList.Count - 1]).ID;
        if (id > 0L && ((ISessionRegistry) objContext).GetRegisteredComponent(id) is Form registeredComponent)
        {
          registeredComponent.ActivateForm(true);
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Navigate Last";
  }
}
