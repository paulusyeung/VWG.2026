// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GridEntryRecreateChildrenEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class GridEntryRecreateChildrenEventArgs : EventArgs
  {
    public readonly int NewChildCount;
    public readonly int OldChildCount;

    public GridEntryRecreateChildrenEventArgs(int oldCount, int intNewCount)
    {
      this.OldChildCount = oldCount;
      this.NewChildCount = intNewCount;
    }
  }
}
