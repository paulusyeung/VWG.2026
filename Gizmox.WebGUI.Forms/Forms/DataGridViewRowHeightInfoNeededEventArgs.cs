// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  [Serializable]
  public class DataGridViewRowHeightInfoNeededEventArgs : EventArgs
  {
    private int mintHeight;
    private int mintMinimumHeight;
    private int mintRowIndex;

    internal DataGridViewRowHeightInfoNeededEventArgs()
    {
      this.mintRowIndex = -1;
      this.mintHeight = -1;
      this.mintMinimumHeight = -1;
    }

    internal void SetProperties(int intRowIndex, int intHeight, int intMinimumHeight)
    {
      this.mintRowIndex = intRowIndex;
      this.mintHeight = intHeight;
      this.mintMinimumHeight = intMinimumHeight;
    }

    /// <summary>Gets or sets the height of the row the event occurred for.</summary>
    /// <returns>The row height. </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is greater than 65,536. </exception>
    public int Height
    {
      get => this.mintHeight;
      set
      {
        if (value < this.mintMinimumHeight)
          value = this.mintMinimumHeight;
        this.mintHeight = value <= 65536 ? value : throw new ArgumentOutOfRangeException();
      }
    }

    /// <summary>Gets or sets the minimum height of the row the event occurred for. </summary>
    /// <returns>The minimum row height.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 2.</exception>
    public int MinimumHeight
    {
      get => this.mintMinimumHeight;
      set
      {
        if (value < 2)
          throw new ArgumentOutOfRangeException();
        if (this.mintHeight < value)
          this.mintHeight = value;
        this.mintMinimumHeight = value;
      }
    }

    /// <summary>Gets the index of the row associated with this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoNeededEventArgs"></see>.</summary>
    /// <returns>The zero-based index of the row the event occurred for.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
