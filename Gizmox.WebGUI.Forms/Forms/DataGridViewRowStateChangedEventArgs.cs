// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowStateChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowStateChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewRowStateChangedEventArgs : EventArgs
  {
    private DataGridViewRow mobjDataGridViewRow;
    private DataGridViewElementStates menmElementStateChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowStateChangedEventArgs"></see> class. </summary>
    /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the row.</param>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</param>
    public DataGridViewRowStateChangedEventArgs(
      DataGridViewRow objDataGridViewRow,
      DataGridViewElementStates enmElementStateChanged)
    {
      this.mobjDataGridViewRow = objDataGridViewRow;
      this.menmElementStateChanged = enmElementStateChanged;
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewRow Row => this.mobjDataGridViewRow;

    /// <summary>Gets the state that has changed on the row.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the row.</returns>
    public DataGridViewElementStates StateChanged => this.menmElementStateChanged;
  }
}
