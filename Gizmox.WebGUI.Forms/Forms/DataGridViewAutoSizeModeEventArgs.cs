// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> events.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewAutoSizeModeEventArgs : EventArgs
  {
    private bool mblnPreviousModeAutoSized;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> class.</summary>
    /// <param name="blnPreviousModeAutoSized">true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</param>
    public DataGridViewAutoSizeModeEventArgs(bool blnPreviousModeAutoSized) => this.mblnPreviousModeAutoSized = blnPreviousModeAutoSized;

    /// <summary>Gets a value specifying whether the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was previously set to automatically resize.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool PreviousModeAutoSized => this.mblnPreviousModeAutoSized;
  }
}
