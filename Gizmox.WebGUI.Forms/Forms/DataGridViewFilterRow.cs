// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewFilterRow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DataGridViewFilterRow : DataGridViewRow
  {
    /// <summary>
    /// Gets or sets a value indicating whether the row is frozen.
    /// </summary>
    /// <returns>true if the row is frozen; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Frozen
    {
      get => true;
      set => base.Frozen = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether users can resize the row or indicating that the behavior is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value that indicates whether the row can be resized or whether it can be resized only when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property is set to true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    public override DataGridViewTriState Resizable => DataGridViewTriState.False;

    /// <summary>Gets the render attribute validator.</summary>
    internal override int RenderMask => base.RenderMask | 1 | 4 | 2;

    /// <summary>
    /// Gets a value indicating whether this instance is filter row.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is filter row; otherwise, <c>false</c>.
    /// </value>
    public override bool IsFilterRow => true;

    /// <summary>
    /// Gets or sets a value indicating whether the row is visible.
    /// </summary>
    /// <returns>true if the row is visible; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    public override bool Visible
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Renders the band attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      objWriter.WriteAttributeText("FTR", "1");
    }
  }
}
