// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewSystemFilterOption
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents DataGridView filter ComboBox system option entry as "(All)", "(Blanks)", etc.
  /// </summary>
  [Serializable]
  public class DataGridViewSystemFilterOption
  {
    private SystemFilterOptions menmOption;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSystemFilterOption" /> class.
    /// </summary>
    /// <param name="enmOption">The enm option.</param>
    public DataGridViewSystemFilterOption(SystemFilterOptions enmOption) => this.menmOption = enmOption;

    /// <summary>Gets the option.</summary>
    public SystemFilterOptions Option => this.menmOption;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => SR.GetString(string.Format("DataGridViewFilterComboBoxOption_" + (object) this.menmOption));
  }
}
