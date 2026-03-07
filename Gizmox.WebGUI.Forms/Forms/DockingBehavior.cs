// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockingBehavior
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies how a control should be docked by default when added through a designer.</summary>
  /// <filterpriority>2</filterpriority>
  public enum DockingBehavior
  {
    /// <summary>Do not prompt the user for the desired docking behavior.</summary>
    /// <filterpriority>1</filterpriority>
    Never,
    /// <summary>Prompt the user for the desired docking behavior.</summary>
    /// <filterpriority>1</filterpriority>
    Ask,
    /// <summary>Set the control's <see cref="P:Gizmox.WebGUI.Forms.Control.Dock"></see> property to <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Fill"></see>  when it is dropped into a container with no other child controls.</summary>
    /// <filterpriority>1</filterpriority>
    AutoDock,
  }
}
