// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Appearance
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Appearance enumaration.</summary>
  public enum Appearance
  {
    /// <summary>
    /// 
    /// </summary>
    Normal,
    /// <summary>
    /// 
    /// </summary>
    Button,
    /// <summary>
    /// 
    /// </summary>
    [Obsolete("This appearance is deprecated, please use the CheckBoxSwitchVisualTemplate instead"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)] Switch,
  }
}
