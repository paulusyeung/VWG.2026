// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripOverflowButton
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Hosts a <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> that displays items that overflow the <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.None)]
  [Serializable]
  public class ToolStripOverflowButton : ToolStripDropDownButton
  {
    internal ToolStripOverflowButton(ToolStrip objParentToolStrip)
    {
    }

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> has items that overflow the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> has overflow items; otherwise, false. </returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool HasDropDownItems => false;

    /// <summary>Retrieves the size of a rectangular area into which a control can fit.</summary>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    /// <param name="objConstrainingSize">The custom-sized area for a control. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Size GetPreferredSize(Size objConstrainingSize) => Size.Empty;
  }
}
