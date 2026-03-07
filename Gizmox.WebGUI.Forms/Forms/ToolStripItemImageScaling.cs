// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemImageScaling
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies whether the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> while retaining the original image proportions.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ToolStripItemImageScaling
  {
    /// <summary>Specifies that the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    None,
    /// <summary>Specifies that the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    SizeToFit,
  }
}
