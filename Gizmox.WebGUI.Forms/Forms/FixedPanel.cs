// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FixedPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  public enum FixedPanel
  {
    /// <summary>
    /// Specifies that neither SplitContainer.Panel1, SplitContainer.Panel2 is fixed. A Control.Resize event affects both panels.
    /// </summary>
    None,
    /// <summary>
    /// Specifies that SplitContainer.Panel1 is fixed. A Control.Resize event affects only SplitContainer.Panel2.
    /// </summary>
    Panel1,
    /// <summary>
    /// Specifies that SplitContainer.Panel2 is fixed. A Control.Resize event affects only SplitContainer.Panel1.
    /// </summary>
    Panel2,
  }
}
