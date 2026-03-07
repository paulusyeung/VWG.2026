// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextImageRelation
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the position of the text and image relative to each other on a control.</summary>
  /// <filterpriority>2</filterpriority>
  public enum TextImageRelation
  {
    /// <summary>Specifies that the image and text share the same space on a control.</summary>
    /// <filterpriority>1</filterpriority>
    Overlay = 0,
    /// <summary>Specifies that the image is displayed vertically above the text of a control.</summary>
    /// <filterpriority>1</filterpriority>
    ImageAboveText = 1,
    /// <summary>Specifies that the text is displayed vertically above the image of a control.</summary>
    /// <filterpriority>1</filterpriority>
    TextAboveImage = 2,
    /// <summary>Specifies that the image is displayed horizontally before the text of a control.</summary>
    /// <filterpriority>1</filterpriority>
    ImageBeforeText = 4,
    /// <summary>Specifies that the text is displayed horizontally before the image of a control.</summary>
    /// <filterpriority>1</filterpriority>
    TextBeforeImage = 8,
  }
}
