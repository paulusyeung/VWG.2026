// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GroupHeaderFormattingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  public class GroupHeaderFormattingEventArgs
  {
    private string mstrDataPropertyName;
    private string mstrValue;
    private int mintValueCount;
    private bool mblnFormattingApplied;
    private Label mobjHeaderLabel;
    private DataGridViewRow mobjOwningRow;

    /// <summary>Gets the header label.</summary>
    public Label HeaderLabel => this.mobjHeaderLabel;

    /// <summary>Gets the owning row.</summary>
    public DataGridViewRow OwningRow => this.mobjOwningRow;

    /// <summary>
    /// Gets or sets a value indicating whether [formatting applied].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [formatting applied]; otherwise, <c>false</c>.
    /// </value>
    public bool FormattingApplied
    {
      get => this.mblnFormattingApplied;
      set
      {
        if (this.mblnFormattingApplied == value)
          return;
        this.mblnFormattingApplied = value;
      }
    }

    /// <summary>Gets the value.</summary>
    /// <value>The value.</value>
    public string Value => this.mstrValue;

    /// <summary>Gets the name of the data property.</summary>
    /// <value>The name of the data property.</value>
    public string DataPropertyName => this.mstrDataPropertyName;

    /// <summary>Gets or sets the value count.</summary>
    /// <value>The value count.</value>
    public int ValueCount => this.mintValueCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GroupHeaderFormattingEventArgs" /> class.
    /// </summary>
    /// <param name="objHeaderLabel">The obj header label.</param>
    /// <param name="strDataPropertyName">Name of the STR data property.</param>
    /// <param name="intValueCount">The int value count.</param>
    /// <param name="strValue">The STR value.</param>
    /// <param name="objOwningRow">The obj owning row.</param>
    internal GroupHeaderFormattingEventArgs(
      Label objHeaderLabel,
      string strDataPropertyName,
      int intValueCount,
      string strValue,
      DataGridViewRow objOwningRow)
    {
      this.mintValueCount = intValueCount;
      this.mstrDataPropertyName = strDataPropertyName;
      this.mstrValue = strValue;
      this.mblnFormattingApplied = false;
      this.mobjHeaderLabel = objHeaderLabel;
      this.mobjOwningRow = objOwningRow;
    }
  }
}
