// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsModeChanged"></see> event. </summary>
  [Serializable]
  public class DataGridViewAutoSizeColumnsModeEventArgs : EventArgs
  {
    private DataGridViewAutoSizeColumnMode[] marrPreviousModes;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs"></see> class. </summary>
    /// <param name="arrPreviousModes">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values representing the previous <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property values of each column. </param>
    public DataGridViewAutoSizeColumnsModeEventArgs(
      DataGridViewAutoSizeColumnMode[] arrPreviousModes)
    {
      this.marrPreviousModes = arrPreviousModes;
    }

    /// <summary>Gets an array of the previous values of the column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> properties.</summary>
    /// <returns>An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values representing the previous values of the column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> properties.</returns>
    public DataGridViewAutoSizeColumnMode[] PreviousModes => this.marrPreviousModes;
  }
}
