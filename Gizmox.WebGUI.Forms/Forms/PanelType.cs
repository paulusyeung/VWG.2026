// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PanelType
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The panel display tyle</summary>
  [Obsolete("Use HeaderedPanel in the office extension instead")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public enum PanelType
  {
    /// <summary>Normal</summary>
    Normal,
    /// <summary>Titled</summary>
    Titled,
    /// <summary>Border</summary>
    Border,
    /// <summary>Page</summary>
    Page,
    /// <summary>Custom</summary>
    Custom,
    /// <summary>Navigation</summary>
    Navigation,
  }
}
