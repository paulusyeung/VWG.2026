// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewFilterComboBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A DataGridViewFilterComboBox control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewFilterComboBoxSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewFilterComboBox : DataGridViewFilterComboBoxBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterComboBox" /> class.
    /// </summary>
    /// <param name="objDataGridView">The obj data grid view.</param>
    /// <param name="objColumn">The obj column.</param>
    /// <param name="objFilterCell">The obj filter cell.</param>
    public DataGridViewFilterComboBox(
      DataGridView objDataGridView,
      DataGridViewColumn objColumn,
      DataGridViewCell objFilterCell)
      : base(objDataGridView, objColumn, objFilterCell)
    {
      this.CustomStyle = nameof (DataGridViewFilterComboBox);
    }
  }
}
