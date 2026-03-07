// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewTopLeftHeaderCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the cell in the top left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that sits above the row headers and to the left of the column headers.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewTopLeftHeaderCell : DataGridViewColumnHeaderCell
  {
    private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_horizontalTextMarginLeft = 1;
    private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_horizontalTextMarginRight = 2;
    private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_verticalTextMargin = 1;

    /// <filterpriority>1</filterpriority>
    public override string ToString() => nameof (DataGridViewTopLeftHeaderCell);

    /// <summary>Fires the column header mouse click.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected override void FireColumnHeaderMouseClick(IEvent objEvent)
    {
    }

    /// <summary>
    /// </summary>
    /// <value></value>
    protected override string MemberID => "GHC0";
  }
}
