// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.KeyPressEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class KeyPressEventArgs : EventArgs
  {
    private bool mblnHandled;
    private char mchrKeyChar;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> class.</summary>
    /// <param name="chrKey">The ASCII character corresponding to the key the user pressed. </param>
    public KeyPressEventArgs(char chrKey) => this.mchrKeyChar = chrKey;

    /// <summary>Gets or sets a value indicating whether the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event was handled.</summary>
    /// <returns>true if the event is handled; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented by design.")]
    public bool Handled
    {
      get => this.mblnHandled;
      set => this.mblnHandled = value;
    }

    /// <summary>Gets or sets the character corresponding to the key pressed.</summary>
    /// <returns>The ASCII character that is composed. For example, if the user presses SHIFT + K, this property returns an uppercase K.</returns>
    /// <filterpriority>1</filterpriority>
    public char KeyChar
    {
      get => this.mchrKeyChar;
      set => this.mchrKeyChar = value;
    }
  }
}
