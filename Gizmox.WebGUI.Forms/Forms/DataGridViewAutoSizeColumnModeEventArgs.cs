// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnModeChanged"></see> event. </summary>
  [Serializable]
  public class DataGridViewAutoSizeColumnModeEventArgs : EventArgs
  {
    private DataGridViewColumn mobjDataGridViewColumn;
    private DataGridViewAutoSizeColumnMode menmPreviousMode;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs"></see> class. </summary>
    /// <param name="enmPreviousMode">The previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value of the column's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property. </param>
    /// <param name="objDataGridViewColumn">The column with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</param>
    public DataGridViewAutoSizeColumnModeEventArgs(
      DataGridViewColumn objDataGridViewColumn,
      DataGridViewAutoSizeColumnMode enmPreviousMode)
    {
      this.mobjDataGridViewColumn = objDataGridViewColumn;
      this.menmPreviousMode = enmPreviousMode;
    }

    /// <summary>Gets the column with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</returns>
    public DataGridViewColumn Column => this.mobjDataGridViewColumn;

    /// <summary>Gets the previous value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of the column.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value representing the previous value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs.Column"></see>.</returns>
    public DataGridViewAutoSizeColumnMode PreviousMode => this.menmPreviousMode;
  }
}
