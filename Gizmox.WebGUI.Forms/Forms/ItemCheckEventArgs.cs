// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ItemCheckEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ItemCheckEventArgs : EventArgs
  {
    private CheckState menmCurrentValue;
    private int mintIndex;
    private CheckState menmNewValue;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ItemCheckEventArgs" /> instance.
    /// </summary>
    /// <param name="intIndex">Int index.</param>
    /// <param name="enmNewCheckValue">Enm new check value.</param>
    /// <param name="enmCurrentValue">Enm current value.</param>
    public ItemCheckEventArgs(
      int intIndex,
      CheckState enmNewCheckValue,
      CheckState enmCurrentValue)
    {
      this.menmCurrentValue = enmCurrentValue;
      this.mintIndex = intIndex;
      this.menmNewValue = enmNewCheckValue;
    }

    /// <summary>Gets the current value.</summary>
    /// <value></value>
    public CheckState CurrentValue => this.menmCurrentValue;

    /// <summary>Gets the index.</summary>
    /// <value></value>
    public int Index => this.mintIndex;

    /// <summary>Gets or sets the new value.</summary>
    /// <value></value>
    public CheckState NewValue
    {
      get => this.menmNewValue;
      set => this.menmNewValue = value;
    }
  }
}
