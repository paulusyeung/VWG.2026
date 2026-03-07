// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataSourceUpdateMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies when a data source is updated when changes occur in the bound control.</summary>
  public enum DataSourceUpdateMode : byte
  {
    /// <summary>
    /// Data source is updated when the control property is validated,
    /// </summary>
    OnValidation,
    /// <summary>
    /// Data source is updated whenever the value of the control property changes.
    /// </summary>
    OnPropertyChanged,
    /// <summary>
    /// Data source is never updated and values entered into the control are not parsed, validated or re-formatted.
    /// </summary>
    Never,
  }
}
