// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.UICuesEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class UICuesEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UICuesEventArgs"></see> class with the specified <see cref="T:Gizmox.WebGUI.Forms.UICues"></see>.</summary>
    /// <param name="uicues">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values. </param>
    public UICuesEventArgs(UICues uicues)
    {
    }

    /// <summary>Gets the bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values.</summary>
    /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.UICues.Changed"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UICues Changed => UICues.Changed;

    /// <summary>Gets a value indicating whether the state of the focus cues has changed.</summary>
    /// <returns>true if the state of the focus cues has changed; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ChangeFocus => false;

    /// <summary>Gets a value indicating whether the state of the keyboard cues has changed.</summary>
    /// <returns>true if the state of the keyboard cues has changed; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ChangeKeyboard => false;

    /// <summary>Gets a value indicating whether focus rectangles are shown after the change.</summary>
    /// <returns>true if focus rectangles are shown after the change; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowFocus => false;

    /// <summary>Gets a value indicating whether keyboard cues are underlined after the change.</summary>
    /// <returns>true if keyboard cues are underlined after the change; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowKeyboard => false;
  }
}
