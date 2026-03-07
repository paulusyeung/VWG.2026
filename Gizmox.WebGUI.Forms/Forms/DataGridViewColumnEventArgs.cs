// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for column-related events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewColumnEventArgs : EventArgs
  {
    private DataGridViewColumn mobjDataGridViewColumn;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> class. </summary>
    /// <param name="objDataGridViewColumn">The column that the event occurs for.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
    public DataGridViewColumnEventArgs(DataGridViewColumn objDataGridViewColumn) => this.mobjDataGridViewColumn = objDataGridViewColumn != null ? objDataGridViewColumn : throw new ArgumentNullException("dataGridViewColumn");

    /// <summary>Gets the column that the event occurs for.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> that the event occurs for.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewColumn Column => this.mobjDataGridViewColumn;
  }
}
