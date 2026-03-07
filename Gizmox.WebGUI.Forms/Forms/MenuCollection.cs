// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MenuCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class MenuCollection : Component, IEnumerable
  {
    private ArrayList mobjMenus;

    internal MenuCollection(Component objParent)
    {
      this.mobjMenus = new ArrayList();
      this.InternalParent = objParent;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objMenu"></param>
    /// <returns></returns>
    public int Add(Menu objMenu)
    {
      objMenu.InternalParent = this.InternalParent;
      this.Update();
      return this.mobjMenus.Add((object) objMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objMenu"></param>
    public void Remove(Menu objMenu)
    {
      if (objMenu.InternalParent == this.InternalParent)
      {
        this.UnRegisterComponent((IRegisteredComponent) objMenu);
        objMenu.InternalParent = (Component) null;
      }
      this.mobjMenus.Remove((object) objMenu);
      this.Update();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator() => this.mobjMenus.GetEnumerator();
  }
}
