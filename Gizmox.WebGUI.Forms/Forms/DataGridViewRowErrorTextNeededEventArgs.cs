// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowErrorTextNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  [Serializable]
  public class DataGridViewRowErrorTextNeededEventArgs : EventArgs
  {
    private string mstrErrorText;
    private int mintRowIndex;

    internal DataGridViewRowErrorTextNeededEventArgs(int intRowIndex, string strErrorText)
    {
      this.mintRowIndex = intRowIndex;
      this.mstrErrorText = strErrorText;
    }

    /// <summary>Gets or sets the error text for the row.</summary>
    /// <returns>A string that represents the error text for the row.</returns>
    public string ErrorText
    {
      get => this.mstrErrorText;
      set => this.mstrErrorText = value;
    }

    /// <summary>Gets the row that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event.</summary>
    /// <returns>The zero based row index for the row.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
