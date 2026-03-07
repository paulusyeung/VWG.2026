// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellStyleContentChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleContentChanged"></see> event. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellStyleContentChangedEventArgs : EventArgs
  {
    private bool mblnChangeAffectsPreferredSize;
    private DataGridViewCellStyle mobjDataGridViewCellStyle;

    internal DataGridViewCellStyleContentChangedEventArgs(
      DataGridViewCellStyle objDataGridViewCellStyle,
      bool blnChangeAffectsPreferredSize)
    {
      this.mobjDataGridViewCellStyle = objDataGridViewCellStyle;
      this.mblnChangeAffectsPreferredSize = blnChangeAffectsPreferredSize;
    }

    /// <summary>Gets the changed <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <returns>The changed <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCellStyle CellStyle => this.mobjDataGridViewCellStyle;

    /// <summary>Gets the scope that is affected by the changed cell style.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyleScopes"></see> that indicates which <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> entity owns the cell style that changed.</returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCellStyleScopes CellStyleScope => this.mobjDataGridViewCellStyle.Scope;

    internal bool ChangeAffectsPreferredSize => this.mblnChangeAffectsPreferredSize;
  }
}
