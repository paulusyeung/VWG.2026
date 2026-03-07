// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewAlignment
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies how items align in the <see cref="T:Gizmox.WebGui.Forms.ListView"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ListViewAlignment
  {
    /// <summary>When the user moves an item, it remains where it is dropped.</summary>
    /// <filterpriority>1</filterpriority>
    Default = 0,
    /// <summary>Items are aligned to the left of the <see cref="T:System.Windows.Forms.ListView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    Left = 1,
    /// <summary>Items are aligned to the top of the <see cref="T:System.Windows.Forms.ListView"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    Top = 2,
    /// <summary>Items are aligned to an invisible grid in the control. When the user moves an item, it moves to the closest juncture in the grid.</summary>
    /// <filterpriority>1</filterpriority>
    SnapToGrid = 5,
  }
}
