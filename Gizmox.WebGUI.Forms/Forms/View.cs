// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.View
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The list display mode</summary>
  public enum View
  {
    /// <summary>Details</summary>
    Details,
    /// <summary>LargeIcon</summary>
    LargeIcon,
    /// <summary>List</summary>
    List,
    /// <summary>SmallIcon</summary>
    SmallIcon,
    /// <summary>
    /// <summary>Each item appears as a full-sized icon with the item label and subitem information to the right of it. The subitem information that appears is specified by the application. This view is available only on Windows XP and the Windows Server 2003 family. On earlier operating systems, this value is ignored and the <see cref="T:System.Windows.Forms.ListView"></see> control displays in the <see cref="F:System.Windows.Forms.View.LargeIcon"></see> view.</summary>
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)] Tile,
  }
}
