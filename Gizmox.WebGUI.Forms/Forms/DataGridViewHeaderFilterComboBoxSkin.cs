// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewHeaderFilterComboBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>DataGridViewHeaderFilterComboBox Skin</summary>
  [SkinContainer(typeof (DataGridViewSkin))]
  [Serializable]
  public class DataGridViewHeaderFilterComboBoxSkin : ComboBoxSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the filter normal image.</summary>
    [Category("Images")]
    [Description("The Filter image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> FilterNormalImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "FilterNormalImageLTR", "FilterNormalImageRTL");

    /// <summary>Gets or sets the filter normal image LTR.</summary>
    /// <value>The filter normal image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterNormalImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterNormalImageLTR), new ImageResourceReference(typeof (DataGridViewHeaderFilterComboBoxSkin), "Filter.png"));
      set => this.SetValue(nameof (FilterNormalImageLTR), (object) value);
    }

    /// <summary>Gets or sets the filter normal image RTL.</summary>
    /// <value>The filter normal image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterNormalImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterNormalImageRTL), this.FilterNormalImageLTR);
      set => this.SetValue(nameof (FilterNormalImageRTL), (object) value);
    }

    /// <summary>Resets the filter normal image.</summary>
    private void ResetFilterNormalImage() => this.Reset("FilterNormalImage");

    /// <summary>Gets the filter hover image.</summary>
    [Category("Images")]
    [Description("The filter image while mouse hover.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> FilterHoverImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "FilterHoverImageLTR", "FilterHoverImageRTL");

    /// <summary>Gets or sets the filter hover image LTR.</summary>
    /// <value>The filter hover image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterHoverImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterHoverImageLTR), new ImageResourceReference(typeof (DataGridViewHeaderFilterComboBoxSkin), "FilterHover.png"));
      set => this.SetValue(nameof (FilterHoverImageLTR), (object) value);
    }

    /// <summary>Gets or sets the filter hover image RTL.</summary>
    /// <value>The filter hover image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterHoverImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterHoverImageRTL), this.FilterHoverImageLTR);
      set => this.SetValue(nameof (FilterHoverImageRTL), (object) value);
    }

    /// <summary>Resets the filter hover image.</summary>
    private void ResetFilterHoverImage() => this.Reset("FilterHoverImage");

    /// <summary>Gets the filter normal image.</summary>
    [Category("Images")]
    [Description("THe Filter image while mouse down.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> FilterDownImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "FilterDownImageLTR", "FilterDownImageRTL");

    /// <summary>Gets or sets the filter down image LTR.</summary>
    /// <value>The filter down image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterDownImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterDownImageLTR), new ImageResourceReference(typeof (DataGridViewHeaderFilterComboBoxSkin), "FilterDown.png"));
      set => this.SetValue(nameof (FilterDownImageLTR), (object) value);
    }

    /// <summary>Gets or sets the filter down image RTL.</summary>
    /// <value>The filter down image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference FilterDownImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterDownImageRTL), this.FilterDownImageLTR);
      set => this.SetValue(nameof (FilterDownImageRTL), (object) value);
    }

    /// <summary>Resets the filter normal image.</summary>
    private void ResetFilterDownImage() => this.Reset("FilterDownImage");

    /// <summary>Gets the width of the filter normal image.</summary>
    /// <value>The width of the filter normal image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual SkinValue FilterNormalImageWidth => (SkinValue) new BidirectionalSkinValue<int>((Skin) this, this.FilterNormalImageWidthLTR, this.FilterNormalImageWidthRTL);

    /// <summary>Gets the filter normal image width RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int FilterNormalImageWidthRTL => this.GetImageWidth(this.FilterNormalImageRTL);

    /// <summary>Gets the filter normal image width LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int FilterNormalImageWidthLTR => this.GetImageWidth(this.FilterNormalImageLTR);

    /// <summary>Gets the drop down width spaceer.</summary>
    [Category("Sizes")]
    [SRDescription("This value will be added to the longest item width.")]
    public virtual int DropDownWidthSpacer
    {
      get => this.GetValue<int>(nameof (DropDownWidthSpacer), 25);
      set => this.SetValue(nameof (DropDownWidthSpacer), (object) value);
    }

    /// <summary>Resets the drop down width spacer.</summary>
    internal void ResetDropDownWidthSpacer() => this.Reset("DropDownWidthSpacer");
  }
}
