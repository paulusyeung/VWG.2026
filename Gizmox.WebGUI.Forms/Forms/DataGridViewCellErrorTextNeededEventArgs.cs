// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  [Serializable]
  public class DataGridViewCellErrorTextNeededEventArgs : DataGridViewCellEventArgs
  {
    private string mstrErrorText;

    internal DataGridViewCellErrorTextNeededEventArgs(
      int intColumnIndex,
      int intRowIndex,
      string strErrorText)
      : base(intColumnIndex, intRowIndex)
    {
      this.mstrErrorText = strErrorText;
    }

    /// <summary>Gets or sets the message that is displayed when the cell is selected.</summary>
    /// <returns>The error message.</returns>
    public string ErrorText
    {
      get => this.mstrErrorText;
      set => this.mstrErrorText = value;
    }
  }
}
