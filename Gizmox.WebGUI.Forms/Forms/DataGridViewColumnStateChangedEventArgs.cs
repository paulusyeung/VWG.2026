// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnStateChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnStateChanged"></see> event. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewColumnStateChangedEventArgs : EventArgs
  {
    private DataGridViewColumn mobjDataGridViewColumn;
    private DataGridViewElementStates menmElementStateChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnStateChangedEventArgs"></see> class. </summary>
    /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> whose state has changed.</param>
    public DataGridViewColumnStateChangedEventArgs(
      DataGridViewColumn objDataGridViewColumn,
      DataGridViewElementStates enmElementStateChanged)
    {
      this.mobjDataGridViewColumn = objDataGridViewColumn;
      this.menmElementStateChanged = enmElementStateChanged;
    }

    /// <summary>Gets the column whose state changed.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> whose state changed.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewColumn Column => this.mobjDataGridViewColumn;

    /// <summary>Gets the new column state.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</returns>
    public DataGridViewElementStates StateChanged => this.menmElementStateChanged;
  }
}
