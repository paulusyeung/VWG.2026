// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ShowExpansionIndicator
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public enum ShowExpansionIndicator
  {
    /// <summary>Always display</summary>
    Always = 1,
    /// <summary>Never display</summary>
    Never = 2,
    /// <summary>Check before display</summary>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] CheckOnDisplay = 3,
    /// <summary>Check before expand (default)</summary>
    CheckOnExpand = 4,
    /// <summary>Show empty</summary>
    Empty = 5,
  }
}
