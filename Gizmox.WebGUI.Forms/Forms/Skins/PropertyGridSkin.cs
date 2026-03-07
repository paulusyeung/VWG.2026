// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.PropertyGridSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>PropertyGrid Skin</summary>
  [ToolboxBitmap(typeof (PropertyGrid), "PropertyGrid.bmp")]
  [SkinDependency(typeof (AnchorPanelSkin))]
  [SkinDependency(typeof (DockButtonSkin))]
  [Serializable]
  public class PropertyGridSkin : ControlSkin
  {
    /// <summary>Gets the row height</summary>
    /// <value>The row height.</value>
    [Category("Sizes")]
    [Description("The row height.")]
    public virtual int RowHeight
    {
      get => this.GetValue<int>(nameof (RowHeight), this.DefaultRowHeight);
      set => this.SetValue(nameof (RowHeight), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetRowHeight() => this.Reset("RowHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultRowHeight => 18;

    /// <summary>Gets or sets the width of the grid lines.</summary>
    /// <value></value>
    [Category("Sizes")]
    [Description("The width of the grid lines.")]
    public virtual BorderWidth GridLinesWidth
    {
      get => this.GetValue<BorderWidth>(nameof (GridLinesWidth), this.DefaultGridLinesWidth);
      set => this.SetValue(nameof (GridLinesWidth), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetGridLinesWidth() => this.Reset("GridLinesWidth");

    /// <summary>Gets default value</summary>
    protected virtual BorderWidth DefaultGridLinesWidth => new BorderWidth(1);

    /// <summary>Gets the width of the plus button.</summary>
    /// <value>The width of the plus button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int PlusButtonWidth => this.GetMaxImageWidth(this.DefaultPlusButtonWidth, "PGLightPlus0.gif", "PGLightPlus1.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetPlusButtonWidth() => this.Reset("PlusButtonWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultPlusButtonWidth => 9;

    /// <summary>Gets the height of the plus button.</summary>
    /// <value>The height of the plus button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int PlusButtonHeight => this.GetMaxImageHeight(this.DefaultPlusButtonHeight, "PGLightPlus0.gif", "PGLightPlus1.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetPlusButtonHeight() => this.Reset("PlusButtonHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultPlusButtonHeight => 9;

    /// <summary>Gets the height of the category plus button.</summary>
    /// <value>The height of the category plus button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CategoryPlusButtonHeight => this.GetMaxImageHeight(this.DefaultCategoryPlusButtonHeight, "PGLightPlus0.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetCategoryPlusButtonHeight() => this.Reset("CategoryPlusButtonHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultCategoryPlusButtonHeight => 9;

    /// <summary>Gets the width of the category plus button.</summary>
    /// <value>The width of the category plus button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CategoryPlusButtonWidth => this.GetMaxImageWidth(this.DefaultCategoryPlusButtonWidth, "PGLightPlus0.gif");

    /// <summary>Resets the height value</summary>
    internal void ResetCategoryPlusButtonWidth() => this.Reset("CategoryPlusButtonWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultCategoryPlusButtonWidth => 9;

    /// <summary>Gets the category style.</summary>
    /// <value>The category style.</value>
    [Category("Style")]
    [Description("The category style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CategoryStyle => (StyleValue) new PropertyGridSkin.GridStyleValue(this, nameof (CategoryStyle));

    /// <summary>Gets the splitter style.</summary>
    /// <value>The splitter style.</value>
    [Category("Style")]
    [Description("The splitter style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SplitterStyle => (StyleValue) new PropertyGridSkin.GridStyleValue(this, nameof (SplitterStyle));

    /// <summary>Gets the property value normal style.</summary>
    /// <value>The property value normal style.</value>
    [Category("States")]
    [Description("The property value normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ValueNormalStyle => (StyleValue) new PropertyGridSkin.GridStyleValue(this, nameof (ValueNormalStyle));

    /// <summary>Gets the property value active style.</summary>
    /// <value>The property value active style.</value>
    [Category("States")]
    [Description("The property value active style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ValueActiveStyle => (StyleValue) new PropertyGridSkin.GridStyleValue(this, nameof (ValueActiveStyle));

    /// <summary>Gets the property label normal style.</summary>
    /// <value>The property label normal style.</value>
    [Category("States")]
    [Description("The property label normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue LabelNormalStyle => (StyleValue) new PropertyGridSkin.GridStyleValue(this, nameof (LabelNormalStyle));

    /// <summary>Gets the property label active style.</summary>
    /// <value>The property label active style.</value>
    [Category("States")]
    [Description("The property label active style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue LabelActiveStyle => new StyleValue((CommonSkin) this, nameof (LabelActiveStyle));

    /// <summary>Gets the outline style.</summary>
    /// <value>The outline style.</value>
    [Category("Style")]
    [Description("The outline style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue OutlineStyle => new StyleValue((CommonSkin) this, nameof (OutlineStyle));

    /// <summary>Gets or sets the grid lines color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Description("The color of the grid lines.")]
    public virtual Color GridLinesColor
    {
      get => this.GetValue<Color>(nameof (GridLinesColor), this.DefaultGridLinesColor);
      set => this.SetValue(nameof (GridLinesColor), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetGridLinesColor() => this.Reset("GridLinesColor");

    /// <summary>Gets default value</summary>
    protected virtual Color DefaultGridLinesColor => Color.FromArgb(211, 219, 233);

    /// <summary>Gets or sets the grid lines style.</summary>
    /// <value></value>
    [Category("Styles")]
    [Description("The color of the grid lines style.")]
    public virtual BorderStyle GridLinesStyle
    {
      get => this.GetValue<BorderStyle>(nameof (GridLinesStyle), BorderStyle.FixedSingle);
      set => this.SetValue(nameof (GridLinesStyle), (object) value);
    }

    /// <summary>Gets the help panel style.</summary>
    /// <value>The help panel style.</value>
    [Category("Styles")]
    [Description("The help panel style, you can define the BorderStyle, BorderColor and Padding of the help panel.")]
    public virtual StyleValue HelpPanelStyle => new StyleValue((CommonSkin) this, nameof (HelpPanelStyle));

    /// <summary>Gets the grid lines style which can be translated.</summary>
    /// <value>The grid lines style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BorderValue GridLines => new BorderValue()
    {
      Color = (BorderColor) this.GridLinesColor,
      Style = this.GridLinesStyle,
      Width = this.GridLinesWidth
    };

    private void InitializeComponent()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class GridStyleValue : StyleValue
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.PropertyGridSkin.GridStyleValue" /> class.
      /// </summary>
      /// <param name="objPropertyOwner">The property owner.</param>
      /// <param name="strPropertyPrefix">The property prefix.</param>
      public GridStyleValue(PropertyGridSkin objPropertyOwner, string strPropertyPrefix)
        : base((CommonSkin) objPropertyOwner, strPropertyPrefix)
      {
      }

      /// <summary>Gets or sets the default border width.</summary>
      /// <value></value>
      protected override BorderColor DefaultBorderColor => this.PropertyGridSkin != null ? (BorderColor) this.PropertyGridSkin.GridLinesColor : base.DefaultBorderColor;

      /// <summary>Gets or sets the default border style.</summary>
      /// <value></value>
      protected override BorderStyle DefaultBorderStyle => this.PropertyGridSkin != null ? this.PropertyGridSkin.GridLinesStyle : base.DefaultBorderStyle;

      /// <summary>Gets or sets the default border width.</summary>
      /// <value></value>
      protected override BorderWidth DefaultBorderWidth => this.PropertyGridSkin != null ? this.PropertyGridSkin.GridLinesWidth : base.DefaultBorderWidth;

      /// <summary>Gets the property grid skin.</summary>
      /// <value>The property grid skin.</value>
      private PropertyGridSkin PropertyGridSkin => this.Skin as PropertyGridSkin;
    }
  }
}
