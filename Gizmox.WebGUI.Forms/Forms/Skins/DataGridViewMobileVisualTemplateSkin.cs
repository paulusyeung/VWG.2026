// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.DataGridViewMobileVisualTemplateSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DataGridViewMobileVisualTemplateSkin : DataGridViewSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>
    /// Gets or sets the data grid view visual template add new row image.
    /// </summary>
    /// <value>The data grid view visual template add new row image.</value>
    public ImageResourceReference DataGridViewVisualTemplateAddNewRowImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateAddNewRowImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateAddNewRowImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template properties image.
    /// </summary>
    /// <value>The data grid view visual template properties image.</value>
    public ImageResourceReference DataGridViewVisualTemplatePropertiesImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplatePropertiesImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplatePropertiesImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template sort image.
    /// </summary>
    /// <value>The data grid view visual template sort image.</value>
    public ImageResourceReference DataGridViewVisualTemplateSortImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateSortImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateSortImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template filter image.
    /// </summary>
    /// <value>The data grid view visual template filter image.</value>
    public ImageResourceReference DataGridViewVisualTemplateFilterImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateFilterImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateFilterImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template view configuration image.
    /// </summary>
    /// <value>
    /// The data grid view visual template view configuration image.
    /// </value>
    public ImageResourceReference DataGridViewVisualTemplateViewConfigurationImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateViewConfigurationImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateViewConfigurationImage), (object) value);
    }

    /// <summary>Gets the size of the caption.</summary>
    /// <value>The size of the caption.</value>
    public Size CaptionSize => this.GetValue<Size>(nameof (CaptionSize), new Size(0, this.DefaultCaptionHeight));

    /// <summary>Resets the size of the caption.</summary>
    public void ResetCaptionSize() => this.Reset("CaptionSize");

    /// <summary>Gets the default height of the caption.</summary>
    /// <value>The default height of the caption.</value>
    public int DefaultCaptionHeight => 32;

    /// <summary>
    /// Gets the height of the TreeView visual template back button.
    /// </summary>
    /// <value>The height of the TreeView visual template back button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CaptionHeight => this.CaptionSize.Height;

    /// <summary>Gets the size of the bottom menu.</summary>
    /// <value>The size of the bottom menu.</value>
    public Size BottomMenuSize => this.GetValue<Size>(nameof (BottomMenuSize), new Size(0, this.DefaultBottomMenuHeight));

    /// <summary>Resets the size of the bottom menu.</summary>
    public void ResetBottomMenuSize() => this.Reset("BottomMenuSize");

    /// <summary>Gets the default height of the bottom menu.</summary>
    /// <value>The default height of the bottom menu.</value>
    public int DefaultBottomMenuHeight => 32;

    /// <summary>Gets the height of the bottom menu.</summary>
    /// <value>The height of the bottom menu.</value>
    public int BottomMenuHeight => this.BottomMenuSize.Height;

    /// <summary>Gets the bottom menu style.</summary>
    /// <value>The bottom menu style.</value>
    [Category("Styles")]
    [Description("The bottom menu style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue BottomMenuStyle => new StyleValue((CommonSkin) this, nameof (BottomMenuStyle));

    /// <summary>Gets the bottom menu button style.</summary>
    /// <value>The bottom menu button style.</value>
    [Category("Styles")]
    [Description("The bottom menu button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue BottomMenuButtonStyle => new StyleValue((CommonSkin) this, nameof (BottomMenuButtonStyle));

    /// <summary>Gets the size of the bottom menut button.</summary>
    /// <value>The size of the bottom menut button.</value>
    public virtual Size BottomMenutButtonSize => this.GetValue<Size>(nameof (BottomMenutButtonSize), new Size(this.DefaultBottomMenuButtonWidthHeight, this.DefaultBottomMenuButtonWidthHeight));

    /// <summary>Gets the width of the bottom menu button.</summary>
    /// <value>The width of the bottom menu button.</value>
    public int BottomMenuButtonWidth => this.BottomMenutButtonSize.Width;

    /// <summary>Gets the height of the bottom menu button.</summary>
    /// <value>The height of the bottom menu button.</value>
    public int BottomMenuButtonHeight => this.BottomMenutButtonSize.Width;

    /// <summary>
    /// Gets the default height of the buttom menu bottom width.
    /// </summary>
    /// <value>The default height of the buttom menu bottom width.</value>
    private int DefaultBottomMenuButtonWidthHeight => 26;

    /// <summary>Gets the caption menu button style.</summary>
    /// <value>The caption menu button style.</value>
    [Category("Styles")]
    [Description("The caption menu button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CaptionMenuButtonStyle => new StyleValue((CommonSkin) this, nameof (CaptionMenuButtonStyle));

    /// <summary>Gets the size of the caption menut button.</summary>
    /// <value>The size of the caption menut button.</value>
    public virtual Size CaptionMenutButtonSize => this.GetValue<Size>(nameof (CaptionMenutButtonSize), new Size(this.DefaultCaptionMenuButtonWidthHeight, this.DefaultCaptionMenuButtonWidthHeight));

    /// <summary>Gets the width of the caption menu button.</summary>
    /// <value>The width of the caption menu button.</value>
    public int CaptionMenuButtonWidth => this.CaptionMenutButtonSize.Width;

    /// <summary>Gets the height of the caption menu button.</summary>
    /// <value>The height of the caption menu button.</value>
    public int CaptionMenuButtonHeight => this.BottomMenutButtonSize.Width;

    /// <summary>
    /// Gets the default height of the buttom menu bottom width.
    /// </summary>
    /// <value>The default height of the buttom menu bottom width.</value>
    private int DefaultCaptionMenuButtonWidthHeight => 28;

    /// <summary>Gets the sort column row style.</summary>
    /// <value>The sort column row style.</value>
    [Category("Styles")]
    [Description("The bottom menu button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SortColumnRowStyle => new StyleValue((CommonSkin) this, nameof (SortColumnRowStyle));

    /// <summary>Gets the sort column text style.</summary>
    /// <value>The sort column text style.</value>
    [Category("Styles")]
    [Description("The sorting text style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SortColumnTextStyle => new StyleValue((CommonSkin) this, nameof (SortColumnTextStyle));

    /// <summary>
    /// Gets or sets the data grid view visual template sort column check image.
    /// </summary>
    /// <value>
    /// The data grid view visual template sort column check image.
    /// </value>
    public ImageResourceReference DataGridViewVisualTemplateSortColumnCheckImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateSortColumnCheckImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateSortColumnCheckImage), (object) value);
    }

    /// <summary>
    /// Gets the width of the data grid view visual template sort column check width.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template sort column check width.
    /// </value>
    public int DataGridViewVisualTemplateSortColumnCheckWidth => this.GetImageWidth(this.DataGridViewVisualTemplateSortColumnCheckImage, this.CaptionMenutButtonSize.Width);

    /// <summary>
    /// Gets or sets the data grid view visual template filter column next image RTL.
    /// </summary>
    /// <value>
    /// The data grid view visual template filter column next image RTL.
    /// </value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference DataGridViewVisualTemplateFilterColumnNextImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateFilterColumnNextImageRTL), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateFilterColumnNextImageRTL), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template filter column next image LTR.
    /// </summary>
    /// <value>
    /// The data grid view visual template filter column next image LTR.
    /// </value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference DataGridViewVisualTemplateFilterColumnNextImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateFilterColumnNextImageLTR), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateFilterColumnNextImageLTR), (object) value);
    }

    /// <summary>
    /// Gets the data grid view visual template filter column next image.
    /// </summary>
    /// <value>
    /// The data grid view visual template filter column next image.
    /// </value>
    public BidirectionalSkinProperty<ImageResourceReference> DataGridViewVisualTemplateFilterColumnNextImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "DataGridViewVisualTemplateFilterColumnNextImageLTR", "DataGridViewVisualTemplateFilterColumnNextImageRTL");

    /// <summary>
    /// Gets the width of the data grid view visual template filter column next.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template filter column next.
    /// </value>
    public int DataGridViewVisualTemplateFilterColumnNextWidth => this.GetImageWidth(this.DataGridViewVisualTemplateFilterColumnNextImageLTR, this.CaptionMenutButtonSize.Width);

    /// <summary>Gets the filter column row style.</summary>
    /// <value>The filter column row style.</value>
    [Category("Styles")]
    [Description("The filter page row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FilterColumnRowStyle => new StyleValue((CommonSkin) this, nameof (FilterColumnRowStyle));

    /// <summary>Gets the filter column text style.</summary>
    /// <value>The filter column text style.</value>
    [Category("Styles")]
    [Description("The filtering text style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FilterColumnTextStyle => new StyleValue((CommonSkin) this, nameof (FilterColumnTextStyle));

    /// <summary>Gets the filter column data style.</summary>
    /// <value>The filter column data style.</value>
    [Category("Styles")]
    [Description("The filtering data style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FilterColumnDataStyle => new StyleValue((CommonSkin) this, nameof (FilterColumnDataStyle));

    /// <summary>Gets the view column row style.</summary>
    /// <value>The view column row style.</value>
    [Category("Styles")]
    [Description("The view page row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue DisplayOrderColumnRowStyle => new StyleValue((CommonSkin) this, nameof (DisplayOrderColumnRowStyle));

    /// <summary>Gets the view sub title style.</summary>
    /// <value>The view sub title style.</value>
    [Category("Styles")]
    [Description("The view sub title style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ViewSubTitleStyle => new StyleValue((CommonSkin) this, nameof (ViewSubTitleStyle));

    /// <summary>Gets the view column row style.</summary>
    /// <value>The view column row style.</value>
    [Category("Styles")]
    [Description("The view page column row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ViewColumnRowStyle => new StyleValue((CommonSkin) this, nameof (ViewColumnRowStyle));

    /// <summary>Gets the view categoty title column row style.</summary>
    /// <value>The view categoty title column row style.</value>
    [Category("Styles")]
    [Description("The view categoty title column row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ViewCategoryTitleColumnRowStyle => new StyleValue((CommonSkin) this, nameof (ViewCategoryTitleColumnRowStyle));

    /// <summary>Gets the add group column row style.</summary>
    /// <value>The add group column row style.</value>
    [Category("Styles")]
    [Description("The add group column row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue AddGroupColumnRowStyle => new StyleValue((CommonSkin) this, nameof (AddGroupColumnRowStyle));

    /// <summary>Gets the group column row style.</summary>
    /// <value>The group column row style.</value>
    [Category("Styles")]
    [Description("The group column row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue GroupColumnRowStyle => new StyleValue((CommonSkin) this, nameof (GroupColumnRowStyle));

    /// <summary>Gets the view column text style.</summary>
    /// <value>The view column text style.</value>
    [Category("Styles")]
    [Description("The view text style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ViewColumnTextStyle => new StyleValue((CommonSkin) this, nameof (ViewColumnTextStyle));

    /// <summary>Gets the view column data style.</summary>
    /// <value>The view column data style.</value>
    [Category("Styles")]
    [Description("The view data style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ViewColumnDataStyle => new StyleValue((CommonSkin) this, nameof (ViewColumnDataStyle));

    /// <summary>
    /// Gets or sets the data grid view visual template list disabled image.
    /// </summary>
    /// <value>The data grid view visual template list disabled image.</value>
    public ImageResourceReference DataGridViewVisualTemplateListDisabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateListDisabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateListDisabledImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template list enabled image.
    /// </summary>
    /// <value>The data grid view visual template list enabled image.</value>
    public ImageResourceReference DataGridViewVisualTemplateListEnabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateListEnabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateListEnabledImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template table disabled image.
    /// </summary>
    /// <value>The data grid view visual template table disabled image.</value>
    public ImageResourceReference DataGridViewVisualTemplateTableDisabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateTableDisabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateTableDisabledImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template table enabled image.
    /// </summary>
    /// <value>The data grid view visual template table enabled image.</value>
    public ImageResourceReference DataGridViewVisualTemplateTableEnabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateTableEnabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateTableEnabledImage), (object) value);
    }

    /// <summary>
    /// Gets the width of the data grid view visual template list enabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template list enabled.
    /// </value>
    public int DataGridViewVisualTemplateListEnabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateListEnabledImage, 45);

    /// <summary>
    /// Gets the width of the data grid view visual template list disabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template list disabled.
    /// </value>
    public int DataGridViewVisualTemplateListDisabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateListDisabledImage, 45);

    /// <summary>
    /// Gets the width of the data grid view visual template table enabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template table enabled.
    /// </value>
    public int DataGridViewVisualTemplateTableEnabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateTableEnabledImage, 45);

    /// <summary>
    /// Gets the width of the data grid view visual template table disabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template table disabled.
    /// </value>
    public int DataGridViewVisualTemplateTableDisabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateTableDisabledImage, 45);

    /// <summary>
    /// Gets or sets the data grid view visual template view by groups disabled image.
    /// </summary>
    /// <value>
    /// The data grid view visual template view by groups disabled image.
    /// </value>
    public ImageResourceReference DataGridViewVisualTemplateViewByGroupsDisabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateViewByGroupsDisabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateViewByGroupsDisabledImage), (object) value);
    }

    /// <summary>
    /// Gets or sets the data grid view visual template view by groups enabled image.
    /// </summary>
    /// <value>
    /// The data grid view visual template view by groups enabled image.
    /// </value>
    public ImageResourceReference DataGridViewVisualTemplateViewByGroupsEnabledImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateViewByGroupsEnabledImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateViewByGroupsEnabledImage), (object) value);
    }

    /// <summary>
    /// Gets the width of the data grid view visual template view by groups disabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template view by groups disabled.
    /// </value>
    public int DataGridViewVisualTemplateViewByGroupsDisabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateViewByGroupsDisabledImage, 45);

    /// <summary>
    /// Gets the width of the data grid view visual template view by groups enabled.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template view by groups enabled.
    /// </value>
    public int DataGridViewVisualTemplateViewByGroupsEnabledWidth => this.GetImageWidth(this.DataGridViewVisualTemplateViewByGroupsEnabledImage, 45);

    /// <summary>
    /// Gets or sets the data grid view visual template add group image.
    /// </summary>
    /// <value>The data grid view visual template add group image.</value>
    public ImageResourceReference DataGridViewVisualTemplateAddGroupImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DataGridViewVisualTemplateAddGroupImage), (ImageResourceReference) null);
      set => this.SetValue(nameof (DataGridViewVisualTemplateAddGroupImage), (object) value);
    }

    /// <summary>
    /// Gets the width of the data grid view visual template add group.
    /// </summary>
    /// <value>
    /// The width of the data grid view visual template add group.
    /// </value>
    public int DataGridViewVisualTemplateAddGroupWidth => this.GetImageWidth(this.DataGridViewVisualTemplateAddGroupImage, 45);
  }
}
