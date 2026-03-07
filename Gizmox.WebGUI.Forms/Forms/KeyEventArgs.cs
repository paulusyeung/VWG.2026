// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.KeyEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class KeyEventArgs : EventArgs
  {
    private Keys menmKeydata;
    private bool mblnHandled;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> class.
    /// </summary>
    /// <param name="enmKeyData">The enm key data.</param>
    public KeyEventArgs(Keys enmKeyData) => this.menmKeydata = enmKeyData;

    /// <summary>Gets or sets a value indicating whether the event was handled.</summary>
    /// <returns>true to bypass the control's default handling; otherwise, false to also pass the event along to the default control handler.</returns>
    [Obsolete("Not implemented by design.")]
    public bool Handled
    {
      get => this.mblnHandled;
      set => this.mblnHandled = value;
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is alt.
    /// </summary>
    /// <value><c>true</c> if alt; otherwise, <c>false</c>.</value>
    public virtual bool Alt => (this.menmKeydata & Keys.Alt) == Keys.Alt;

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is control.
    /// </summary>
    /// <value><c>true</c> if control; otherwise, <c>false</c>.</value>
    public bool Control => (this.menmKeydata & Keys.Control) == Keys.Control;

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is shift.
    /// </summary>
    /// <value><c>true</c> if shift; otherwise, <c>false</c>.</value>
    public virtual bool Shift => (this.menmKeydata & Keys.Shift) == Keys.Shift;

    /// <summary>Gets the key value.</summary>
    /// <value>The key value.</value>
    public int KeyValue => (int) (this.menmKeydata & Keys.KeyCode);

    /// <summary>Gets the key data.</summary>
    /// <value>The key data.</value>
    public Keys KeyData => this.menmKeydata;

    /// <summary>Gets the key code.</summary>
    /// <value>The key code.</value>
    public Keys KeyCode
    {
      get
      {
        Keys keys = this.menmKeydata & Keys.KeyCode;
        return !Enum.IsDefined(typeof (Keys), (object) (int) keys) ? Keys.None : keys;
      }
    }

    /// <summary>
    /// Gets the modifier flags for a <see cref="E:Gizmox.WebGui.Forms.Control.KeyDown"></see> or <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event. The flags indicate which combination of CTRL, SHIFT, and ALT keys was pressed.
    /// </summary>
    /// <value>The modifiers.</value>
    /// <returns>A <see cref="T:System.Windows.Forms.Keys"></see> value representing one or more modifier flags.</returns>
    public Keys Modifiers => this.menmKeydata & Keys.Modifiers;
  }
}
