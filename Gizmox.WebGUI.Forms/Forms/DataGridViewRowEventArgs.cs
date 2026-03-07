// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for row-related <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewRowEventArgs : EventArgs
  {
    private DataGridViewRow mobjDataGridViewRow;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> class. </summary>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that the event occurred for.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
    public DataGridViewRowEventArgs(DataGridViewRow objDataGridViewRow) => this.mobjDataGridViewRow = objDataGridViewRow != null ? objDataGridViewRow : throw new ArgumentNullException("dataGridViewRow");

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> associated with the event.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> associated with the event.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewRow Row => this.mobjDataGridViewRow;
  }
}
