// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellStateChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStateChanged"></see> event. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellStateChangedEventArgs : EventArgs
  {
    private DataGridViewCell mobjDataGridViewCell;
    private DataGridViewElementStates menmElementStateChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStateChangedEventArgs"></see> class. </summary>
    /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the cell.</param>
    /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that has a changed state.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewCell is null.</exception>
    public DataGridViewCellStateChangedEventArgs(
      DataGridViewCell objDataGridViewCell,
      DataGridViewElementStates enmElementStateChanged)
    {
      this.mobjDataGridViewCell = objDataGridViewCell != null ? objDataGridViewCell : throw new ArgumentNullException("dataGridViewCell");
      this.menmElementStateChanged = enmElementStateChanged;
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that has a changed state.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> whose state has changed.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCell Cell => this.mobjDataGridViewCell;

    /// <summary>Gets the state that has changed on the cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the cell.</returns>
    public DataGridViewElementStates StateChanged => this.menmElementStateChanged;
  }
}
