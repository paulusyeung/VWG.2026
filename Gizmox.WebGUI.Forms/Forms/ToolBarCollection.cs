// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolBarCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>ToolBar collection.</summary>
  [Serializable]
  public class ToolBarCollection : CollectionBase
  {
    private Control mobjParent;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objParent"></param>
    public ToolBarCollection(Control objParent) => this.mobjParent = objParent;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToolBar"></param>
    public int Add(ToolBar objToolBar)
    {
      objToolBar.InternalParent = (Component) this.mobjParent;
      return this.List.Add((object) objToolBar);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToolBar"></param>
    public void Remove(ToolBar objToolBar)
    {
      if (objToolBar.InternalParent == this.mobjParent)
        objToolBar.InternalParent = (Component) null;
      this.List.Remove((object) objToolBar);
    }

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBar" /> with the specified int index.
    /// </summary>
    /// <value></value>
    public ToolBar this[int intIndex]
    {
      get => (ToolBar) this.List[intIndex];
      set => this.List[intIndex] = (object) value;
    }
  }
}
