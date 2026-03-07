// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnChooserColumnsVisibilityChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBeginEdit"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see> events.
  /// </summary>
  [Serializable]
  public class ColumnChooserColumnsVisibilityChangedEventArgs : EventArgs
  {
    private List<DataGridViewColumn> mobjChangedColumnsVisibility;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserColumnsVisibilityChangedEventArgs" /> class.
    /// </summary>
    /// <param name="objChangedColumnsVisibility">The obj changed columns visibility.</param>
    public ColumnChooserColumnsVisibilityChangedEventArgs(
      List<DataGridViewColumn> objChangedColumnsVisibility)
    {
      this.mobjChangedColumnsVisibility = objChangedColumnsVisibility;
    }

    /// <summary>Gets the changed columns visibility.</summary>
    public List<DataGridViewColumn> ChangedColumnsVisibility => this.mobjChangedColumnsVisibility;
  }
}
