// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnCheckedStatus
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  internal class ColumnCheckedStatus
  {
    private bool mblnIsChecked;
    private bool mblnIsChanged;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is visible; otherwise, <c>false</c>.
    /// </value>
    public bool IsChecked
    {
      get => this.mblnIsChecked;
      set => this.mblnIsChecked = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is changed.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is changed; otherwise, <c>false</c>.
    /// </value>
    public bool IsChanged
    {
      get => this.mblnIsChanged;
      set => this.mblnIsChanged = value;
    }
  }
}
