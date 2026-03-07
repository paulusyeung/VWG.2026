// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripLayoutStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the possible alignments with which the items of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> can be displayed.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ToolStripLayoutStyle
  {
    /// <summary>Specifies that items are laid out automatically.</summary>
    StackWithOverflow,
    /// <summary>Specifies that items are laid out horizontally and overflow as necessary.</summary>
    HorizontalStackWithOverflow,
    /// <summary>Specifies that items are laid out vertically, are centered within the control, and overflow as necessary.</summary>
    VerticalStackWithOverflow,
    /// <summary>Specifies that items flow horizontally or vertically as necessary.</summary>
    /// <filterpriority>1</filterpriority>
    Flow,
    /// <summary>Specifies that items are laid out flush left.</summary>
    /// <filterpriority>1</filterpriority>
    Table,
  }
}
