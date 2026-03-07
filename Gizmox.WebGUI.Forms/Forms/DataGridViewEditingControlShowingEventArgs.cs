// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewEditingControlShowingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditingControlShowing"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewEditingControlShowingEventArgs : EventArgs
  {
    private DataGridViewCellStyle mobjCellStyle;
    private Control mobjControl;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditingControlShowingEventArgs"></see> class.</summary>
    /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> representing the style of the cell being edited.</param>
    /// <param name="objControl">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in which the user will edit the selected cell's contents.</param>
    public DataGridViewEditingControlShowingEventArgs(
      Control objControl,
      DataGridViewCellStyle objCellStyle)
    {
      this.mobjControl = objControl;
      this.mobjCellStyle = objCellStyle;
    }

    /// <summary>Gets or sets the cell style of the edited cell.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> representing the style of the cell being edited.</returns>
    /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
    public DataGridViewCellStyle CellStyle
    {
      get => this.mobjCellStyle;
      set => this.mobjCellStyle = value != null ? value : throw new ArgumentNullException(nameof (value));
    }

    /// <summary>The control shown to the user for editing the selected cell's value.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that displays an area for the user to enter or change the selected cell's value.</returns>
    /// <filterpriority>1</filterpriority>
    public Control Control => this.mobjControl;
  }
}
