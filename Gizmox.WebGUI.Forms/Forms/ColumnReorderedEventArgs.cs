// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnReorderedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Column Reordered Event Args</summary>
  public class ColumnReorderedEventArgs : CancelEventArgs
  {
    private ColumnHeader mobjHeader;
    private int mintNewDisplayIndex;
    private int mintOldDisplayIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnReorderedEventArgs" /> class.
    /// </summary>
    /// <param name="intOldDisplayIndex">Old Display index of the column.</param>
    /// <param name="intNewDisplayIndex">New Display index of the column.</param>
    /// <param name="objHeader">The column header.</param>
    public ColumnReorderedEventArgs(
      int intOldDisplayIndex,
      int intNewDisplayIndex,
      ColumnHeader objHeader)
    {
      this.mintOldDisplayIndex = intOldDisplayIndex;
      this.mintNewDisplayIndex = intNewDisplayIndex;
      this.mobjHeader = objHeader;
    }

    /// <summary>Gets the header.</summary>
    /// <value>The header.</value>
    public ColumnHeader Header => this.mobjHeader;

    /// <summary>Gets the new index of the display.</summary>
    /// <value>The new index of the display.</value>
    public int NewDisplayIndex => this.mintNewDisplayIndex;

    /// <summary>Gets the old index of the display.</summary>
    /// <value>The old index of the display.</value>
    public int OldDisplayIndex => this.mintOldDisplayIndex;
  }
}
