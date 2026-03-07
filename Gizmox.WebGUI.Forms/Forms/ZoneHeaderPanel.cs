// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneHeaderPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A Panel control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ZoneHeaderPanelSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class ZoneHeaderPanel : Panel
  {
    private Zone mobjOwningZone;

    public ZoneHeaderPanel(Zone objOwningZone)
    {
      this.mobjOwningZone = objOwningZone;
      this.CustomStyle = "ZoneHeaderPanelSkin";
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
    /// </summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
    public override ContextMenuStrip ContextMenuStrip
    {
      get => !this.DesignMode ? this.mobjOwningZone.Manager.GetDockedContextMenuStrip(this.mobjOwningZone) : base.ContextMenuStrip;
      set => base.ContextMenuStrip = value;
    }
  }
}
