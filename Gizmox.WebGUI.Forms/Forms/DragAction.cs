// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DragAction
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies how and if a drag-and-drop operation should continue.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  public enum DragAction
  {
    /// <summary>The operation will continue.</summary>
    /// <filterpriority>1</filterpriority>
    Continue,
    /// <summary>The operation will stop with a drop.</summary>
    /// <filterpriority>1</filterpriority>
    Drop,
    /// <summary>The operation is canceled with no drop message.</summary>
    /// <filterpriority>1</filterpriority>
    Cancel,
  }
}
