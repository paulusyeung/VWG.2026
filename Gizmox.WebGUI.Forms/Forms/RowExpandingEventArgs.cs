// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RowExpandingEventArgs
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
  public class RowExpandingEventArgs : EventArgs
  {
    private bool mblnCancel;
    private DataGridViewRow mobjExpandingRow;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RowExpandingEventArgs" /> class.
    /// </summary>
    /// <param name="objExpandingRow">The obj expanding row.</param>
    public RowExpandingEventArgs(DataGridViewRow objExpandingRow) => this.mobjExpandingRow = objExpandingRow;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.RowExpandingEventArgs" /> is cancel.
    /// </summary>
    /// <value>
    ///   <c>true</c> if cancel; otherwise, <c>false</c>.
    /// </value>
    public bool Cancel
    {
      get => this.mblnCancel;
      set => this.mblnCancel = value;
    }

    /// <summary>Gets the expanding row.</summary>
    public DataGridViewRow ExpandingRow => this.mobjExpandingRow;
  }
}
