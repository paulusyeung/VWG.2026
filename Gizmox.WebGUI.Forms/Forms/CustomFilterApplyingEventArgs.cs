// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents CustomFilterApplied event arguments.</summary>
  [Serializable]
  public class CustomFilterApplyingEventArgs : EventArgs
  {
    private DataGridViewColumn mobjFilteredColumn;

    /// <summary>Gets the owning column.</summary>
    public DataGridViewColumn FilteredColumn => this.mobjFilteredColumn;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs" /> class.
    /// </summary>
    /// <param name="objOwningColumn">The obj owning column.</param>
    public CustomFilterApplyingEventArgs(DataGridViewColumn objOwningColumn) => this.mobjFilteredColumn = objOwningColumn;
  }
}
