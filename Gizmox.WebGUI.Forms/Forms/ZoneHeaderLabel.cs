// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneHeaderLabel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A Label control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ZoneHeaderLabelSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class ZoneHeaderLabel : Label
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ZoneHeaderLabel" /> class.
    /// </summary>
    public ZoneHeaderLabel()
    {
      this.TextAlign = ContentAlignment.MiddleLeft;
      this.CustomStyle = "ZoneHeaderLabelSkin";
    }
  }
}
