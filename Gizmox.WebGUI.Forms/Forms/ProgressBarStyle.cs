// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProgressBarStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the style that a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> uses to indicate the progress of an operation.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ProgressBarStyle
  {
    /// <summary>Indicates progress by increasing the number of segmented blocks in a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Blocks,
    /// <summary>Indicates progress by increasing the size of a smooth, continuous bar in a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Continuous,
    /// <summary>Indicates progress by continuously scrolling a block across a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> in a marquee fashion.</summary>
    Marquee,
  }
}
