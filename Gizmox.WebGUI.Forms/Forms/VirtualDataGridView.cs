// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.VirtualDataGridView
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (VirtualDataGridViewSkin))]
  [ToolboxBitmap(typeof (VirtualDataGridView), "VirtualDataGridView_45.png")]
  [Serializable]
  public class VirtualDataGridView : DataGridView
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.VirtualDataGridView" /> class.
    /// </summary>
    public VirtualDataGridView() => this.UseInternalPaging = false;

    /// <summary>
    /// Gets a value indicating whether this instance is virtual.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is virtual; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    protected override bool IsVirtualDataGridView => true;

    /// <summary>Uses internal paging algorithem</summary>
    [DefaultValue(false)]
    public override bool UseInternalPaging
    {
      get => base.UseInternalPaging;
      set => base.UseInternalPaging = value;
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
    protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
    {
      base.OnDataBindingComplete(e);
      if (e.ListChangedType != ListChangedType.Reset)
        return;
      this.SetScrollTop(0);
      this.SetScrollLeft(0);
    }

    /// <summary>Performs scroll into view.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    public override void ScrollIntoView(DataGridViewCell objDataGridViewCell) => throw new NotImplementedException();
  }
}
