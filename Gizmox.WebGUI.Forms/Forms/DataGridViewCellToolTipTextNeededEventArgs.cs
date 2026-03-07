// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextNeeded"></see> event. </summary>
  [Serializable]
  public class DataGridViewCellToolTipTextNeededEventArgs : DataGridViewCellEventArgs
  {
    private string mstrToolTipText;

    internal DataGridViewCellToolTipTextNeededEventArgs(
      int intColumnIndex,
      int intRowIndex,
      string strToolTipText)
      : base(intColumnIndex, intRowIndex)
    {
      this.mstrToolTipText = strToolTipText;
    }

    /// <summary>Gets or sets the ToolTip text.</summary>
    /// <returns>The current ToolTip text.</returns>
    public string ToolTipText
    {
      get => this.mstrToolTipText;
      set => this.mstrToolTipText = value;
    }
  }
}
