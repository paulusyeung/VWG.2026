// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneDropDownButton
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A button control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ZoneDropDownButtonSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class ZoneDropDownButton : Button
  {
    public ZoneDropDownButton() => this.CustomStyle = "ZoneDropDownButtonSkin";

    /// <summary>
    /// Gets a value indicating whether [supports key navigation].
    /// </summary>
    /// <value>
    /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
    /// </value>
    protected override bool SupportsKeyNavigation => true;
  }
}
