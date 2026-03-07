// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ValidationConstraints
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines constants that inform <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren(System.Windows.Forms.ValidationConstraints)"></see> about how it should validate a container's child controls. </summary>
  [Flags]
  public enum ValidationConstraints
  {
    /// <summary>Validates child controls whose <see cref="P:System.Windows.Forms.Control.Enabled"></see> property is set to true.</summary>
    Enabled = 2,
    /// <summary>Validates child controls that are directly hosted within the container. Does not validate any of the children of these children. For example, if you have a <see cref="T:System.Windows.Forms.Form"></see> that contains a custom <see cref="T:System.Windows.Forms.UserControl"></see>, and the <see cref="T:System.Windows.Forms.UserControl"></see> contains a <see cref="T:System.Windows.Forms.Button"></see>, using <see cref="F:System.Windows.Forms.ValidationConstraints.ImmediateChildren"></see> will cause the <see cref="E:System.Windows.Forms.Control.Validating"></see> event of the <see cref="T:System.Windows.Forms.UserControl"></see> to occur, but not the <see cref="E:System.Windows.Forms.Control.Validating"></see> event of the <see cref="T:System.Windows.Forms.Button"></see>. </summary>
    ImmediateChildren = 16, // 0x00000010
    /// <summary>Validates all child controls, and all children of these child controls, regardless of their property settings. </summary>
    None = 0,
    /// <summary>Validates child controls that can be selected.</summary>
    Selectable = 1,
    /// <summary>Validates child controls that have a <see cref="P:System.Windows.Forms.Control.TabStop"></see> value set, which means that the user can navigate to the control using the TAB key. </summary>
    TabStop = 8,
    /// <summary>Validates child controls whose <see cref="P:System.Windows.Forms.Control.Visible"></see> property is set to true.</summary>
    Visible = 4,
  }
}
