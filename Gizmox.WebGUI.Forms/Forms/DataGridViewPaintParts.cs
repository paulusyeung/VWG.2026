// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewPaintParts
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines values for specifying the parts of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that are to be painted.</summary>
  [Flags]
  [Serializable]
  public enum DataGridViewPaintParts
  {
    /// <summary>All parts of the cell should be painted.</summary>
    All = 127, // 0x0000007F
    /// <summary>The background of the cell should be painted.</summary>
    Background = 1,
    /// <summary>The border of the cell should be painted.</summary>
    Border = 2,
    /// <summary>The background of the cell content should be painted.</summary>
    ContentBackground = 4,
    /// <summary>The foreground of the cell content should be painted.</summary>
    ContentForeground = 8,
    /// <summary>The cell error icon should be painted.</summary>
    ErrorIcon = 16, // 0x00000010
    /// <summary>The focus rectangle should be painted around the cell.</summary>
    Focus = 32, // 0x00000020
    /// <summary>Nothing should be painted.</summary>
    None = 0,
    /// <summary>The background of the cell should be painted when the cell is selected.</summary>
    SelectionBackground = 64, // 0x00000040
  }
}
