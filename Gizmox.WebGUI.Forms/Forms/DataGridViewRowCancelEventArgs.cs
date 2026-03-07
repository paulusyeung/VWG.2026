// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowCancelEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletingRow"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewRowCancelEventArgs : CancelEventArgs
  {
    private DataGridViewRow mobjDataGridViewRow;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCancelEventArgs"></see> class. </summary>
    /// <param name="objDataGridViewRow">The row the user is deleting.</param>
    public DataGridViewRowCancelEventArgs(DataGridViewRow objDataGridViewRow) => this.mobjDataGridViewRow = objDataGridViewRow;

    /// <summary>Gets the row that the user is deleting.</summary>
    /// <returns>The row that the user deleted.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewRow Row => this.mobjDataGridViewRow;
  }
}
