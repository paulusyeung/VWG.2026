// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsAdded"></see> event. </summary>
  [Serializable]
  public class DataGridViewRowsAddedEventArgs : EventArgs
  {
    private int mintRowCount;
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventArgs"></see> class. </summary>
    /// <param name="intRowCount">The number of rows that have been added.</param>
    /// <param name="intRowIndex">The index of the first added row.</param>
    public DataGridViewRowsAddedEventArgs(int intRowIndex, int intRowCount)
    {
      this.mintRowIndex = intRowIndex;
      this.mintRowCount = intRowCount;
    }

    /// <summary>Gets the number of rows that have been added.</summary>
    /// <returns>The number of rows that have been added.</returns>
    public int RowCount => this.mintRowCount;

    /// <summary>Gets the index of the first added row.</summary>
    /// <returns>The index of the first added row.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
