// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TabControlSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>TabControl Skin</summary>
  [ToolboxBitmap(typeof (TabControl), "TabControl.bmp")]
  [SkinDependency(typeof (TabPageSkin))]
  [Serializable]
  public class TabControlSkin : ControlSkin
  {
    /// <summary>Gets the right scroll button normal style.</summary>
    /// <value>The right scroll button normal style.</value>
    [Category("States")]
    [Description("The right scroll button normal style.")]
    public virtual StyleValue RightScrollButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (RightScrollButtonNormalStyle));

    /// <summary>Gets the right scroll button hover style.</summary>
    /// <value>The right scroll button hover style.</value>
    [Category("States")]
    [Description("The right scroll button hover style.")]
    public virtual StyleValue RightScrollButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (RightScrollButtonHoverStyle), this.RightScrollButtonNormalStyle);

    /// <summary>Gets the right scroll button pressed style.</summary>
    /// <value>The right scroll button pressed style.</value>
    [Category("States")]
    [Description("The right scroll button pressed style.")]
    public virtual StyleValue RightScrollButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (RightScrollButtonPressedStyle), this.RightScrollButtonNormalStyle);

    /// <summary>Gets or sets the size of the right scroll button.</summary>
    /// <value>The size of the right scroll button.</value>
    [Category("Sizes")]
    [Description("The size of the right scroll button.")]
    public virtual Size RightScrollButtonSize
    {
      get => this.GetValue<Size>(nameof (RightScrollButtonSize), this.GetImageSize(this.RightScrollButtonNormalStyle.BackgroundImage, this.DefaultRightScrollButtonSize));
      set => this.SetValue(nameof (RightScrollButtonSize), (object) value);
    }

    /// <summary>Gets the default size of the right scroll button.</summary>
    /// <value>The default size of the right scroll button.</value>
    protected virtual Size DefaultRightScrollButtonSize => new Size(16, 16);

    /// <summary>Resets the size of the right scroll button.</summary>
    private void ResetRightScrollButtonSize() => this.Reset("RightScrollButtonSize");

    /// <summary>Gets the width of the right scroll button.</summary>
    /// <value>The width of the right scroll button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightScrollButtonWidth => this.RightScrollButtonSize.Width;

    /// <summary>Gets the height of the right scroll button.</summary>
    /// <value>The height of the right scroll button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightScrollButtonHeight => this.RightScrollButtonSize.Height;

    /// <summary>Gets the left scroll button normal style.</summary>
    /// <value>The left scroll button normal style.</value>
    [Category("States")]
    [Description("The left scroll button normal style.")]
    public virtual StyleValue LeftScrollButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (LeftScrollButtonNormalStyle));

    /// <summary>Gets the left scroll button hover style.</summary>
    /// <value>The left scroll button hover style.</value>
    [Category("States")]
    [Description("The left scroll button hover style.")]
    public virtual StyleValue LeftScrollButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (LeftScrollButtonHoverStyle), this.LeftScrollButtonNormalStyle);

    /// <summary>Gets the left scroll button pressed style.</summary>
    /// <value>The left scroll button pressed style.</value>
    [Category("States")]
    [Description("The left scroll button pressed style.")]
    public virtual StyleValue LeftScrollButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (LeftScrollButtonPressedStyle), this.LeftScrollButtonNormalStyle);

    /// <summary>Gets or sets the size of the left scroll button.</summary>
    /// <value>The size of the left scroll button.</value>
    [Category("Sizes")]
    [Description("The size of the left scroll button.")]
    public virtual Size LeftScrollButtonSize
    {
      get => this.GetValue<Size>(nameof (LeftScrollButtonSize), this.GetImageSize(this.LeftScrollButtonNormalStyle.BackgroundImage, this.DefaultLeftScrollButtonSize));
      set => this.SetValue(nameof (LeftScrollButtonSize), (object) value);
    }

    /// <summary>Resets the size of the left scroll button.</summary>
    private void ResetLeftScrollButtonSize() => this.Reset("LeftScrollButtonSize");

    /// <summary>Gets the default size of the left scroll button.</summary>
    /// <value>The default size of the left scroll button.</value>
    protected virtual Size DefaultLeftScrollButtonSize => new Size(16, 16);

    /// <summary>Gets the width of the left scroll button.</summary>
    /// <value>The width of the left scroll button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftScrollButtonWidth => this.LeftScrollButtonSize.Width;

    /// <summary>Gets the height of the left scroll button.</summary>
    /// <value>The height of the left scroll button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftScrollButtonHeight => this.LeftScrollButtonSize.Height;

    /// <summary>
    /// Gets the bidirectional right scroll button normal style.
    /// </summary>
    /// <value>The bidirectional right scroll button normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightScrollButtonNormalStyle, this.LeftScrollButtonNormalStyle);

    /// <summary>
    /// Gets the bidirectional left scroll button normal style.
    /// </summary>
    /// <value>The bidirectional left scroll button normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftScrollButtonNormalStyle, this.RightScrollButtonNormalStyle);

    /// <summary>
    /// Gets the bidirectional left scroll button hover style.
    /// </summary>
    /// <value>The bidirectional left scroll button hover style.</value>
    public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftScrollButtonHoverStyle, this.RightScrollButtonHoverStyle);

    /// <summary>
    /// Gets the bidirectional left scroll button pressed style.
    /// </summary>
    /// <value>The bidirectional left scroll button pressed style.</value>
    public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonPressedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftScrollButtonPressedStyle, this.RightScrollButtonPressedStyle);

    /// <summary>
    /// Gets the bidirectional right scroll button hover style.
    /// </summary>
    /// <value>The bi directional right scroll button hover style.</value>
    public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightScrollButtonHoverStyle, this.LeftScrollButtonHoverStyle);

    /// <summary>
    /// Gets the bidirectional right scroll button pressed style.
    /// </summary>
    /// <value>The bidirectional right scroll button pressed style.</value>
    public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonPressedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightScrollButtonPressedStyle, this.LeftScrollButtonPressedStyle);

    /// <summary>Gets the SpreadTabHeaderTextColumn style.</summary>
    [Category("Styles")]
    [Description("The SpreadTabHeaderTextColumn style.")]
    public virtual StyleValue SpreadTabHeaderTextColumnStyle => new StyleValue((CommonSkin) this, nameof (SpreadTabHeaderTextColumnStyle));

    /// <summary>Resets the SpreadTabHeaderTextColumn.</summary>
    internal void ResetSpreadTabHeaderTextColumnStyle() => this.Reset("SpreadTabHeaderTextColumnStyle");

    /// <summary>Gets or sets the initial start point of the tabs.</summary>
    /// <value>The initial start point of the tabs.</value>
    [Category("Sizes")]
    [Description("The initial start point of the tabs.")]
    public virtual int HeadersOffset
    {
      get => this.GetValue<int>(nameof (HeadersOffset), this.DefaultHeadersOffset);
      set => this.SetValue(nameof (HeadersOffset), (object) value);
    }

    /// <summary>Gets the tab top normal style.</summary>
    /// <value>The tab top normal style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopNormalStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabTopNormalLTRStyle, this.TabTopNormalRTLStyle);

    /// <summary>Gets the tab top normal style.</summary>
    /// <value>The tab top normal style.</value>
    public BidirectionalSkinValue<StyleValue> TabTopNormalSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabTopNormalLTRSpreadStyle, this.CenterTabTopNormalRTLSpreadStyle);

    /// <summary>Gets the tab top normal LTR spread style.</summary>
    [Category("States")]
    [Description("The top tab normal spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopNormalLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopNormalLTRSpreadStyle), this.CenterBottomTabNormalLTRStyle);

    /// <summary>Gets the tab top normal RTL spread style.</summary>
    [Category("States")]
    [Description("The top tab normal spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopNormalRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopNormalRTLSpreadStyle));

    /// <summary>Gets the top tab normal style.</summary>
    /// <value>The top tab normal style.</value>
    [Category("States")]
    [Description("The top tab normal LTR style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopNormalLTRStyle => new TripleCellFrameStyleValue(this.LeftTopTabNormalLTRStyle, this.RightTopTabNormalLTRStyle, this.CenterTopTabNormalLTRStyle);

    /// <summary>Gets the tab top normal RTL style.</summary>
    /// <value>The tab top normal RTL style.</value>
    [Category("States")]
    [Description("The top tab normal RTL style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopNormalRTLStyle => new TripleCellFrameStyleValue(this.LeftTopTabNormalRTLStyle, this.RightTopTabNormalRTLStyle, this.CenterTopTabNormalRTLStyle);

    /// <summary>Gets the tab top selected style.</summary>
    /// <value>The tab top selected style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopSelectedStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabTopSelectedLTRStyle, this.TabTopSelectedRTLStyle);

    /// <summary>Gets the tab top Selected style.</summary>
    /// <value>The tab top Selected style.</value>
    public BidirectionalSkinValue<StyleValue> TabTopSelectedSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabTopSelectedLTRSpreadStyle, this.CenterTabTopSelectedRTLSpreadStyle);

    /// <summary>Gets the tab top selected LTR spread style.</summary>
    [Category("States")]
    [Description("The top tab selected spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopSelectedLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopSelectedLTRSpreadStyle), this.TabPageHeaderSelectedStyle);

    /// <summary>Gets the tab top selected LTR spread style.</summary>
    [Category("States")]
    [Description("The top tab selected  spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopSelectedRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopSelectedRTLSpreadStyle), this.TabPageHeaderSelectedStyle);

    /// <summary>Gets the top tab selected style.</summary>
    /// <value>The top tab selected style.</value>
    [Category("States")]
    [Description("The top tab selected style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopSelectedLTRStyle => new TripleCellFrameStyleValue(this.LeftTopTabSelectedLTRStyle, this.RightTopTabSelectedLTRStyle, this.CenterTopTabSelectedLTRStyle);

    /// <summary>Gets the tab top selected RTL style.</summary>
    /// <value>The tab top selected RTL style.</value>
    [Category("States")]
    [Description("The top tab selected style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopSelectedRTLStyle => new TripleCellFrameStyleValue(this.LeftTopTabSelectedRTLStyle, this.RightTopTabSelectedRTLStyle, this.CenterTopTabSelectedRTLStyle);

    /// <summary>Gets the tab top hover style.</summary>
    /// <value>The tab top hover style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopHoverStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabTopHoverLTRStyle, this.TabTopHoverRTLStyle);

    /// <summary>Gets the tab top Hover style.</summary>
    /// <value>The tab top Hover style.</value>
    public BidirectionalSkinValue<StyleValue> TabTopHoverSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabTopHoverLTRSpreadStyle, this.CenterTabTopHoverRTLSpreadStyle);

    /// <summary>Gets the tab top hover LTR spread style.</summary>
    [Category("States")]
    [Description("The top tab hover spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopHoverLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopHoverLTRSpreadStyle));

    /// <summary>Gets the tab top hover RTL spread style.</summary>
    [Category("States")]
    [Description("The top tab hover spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabTopHoverRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabTopHoverRTLSpreadStyle));

    /// <summary>Gets the top tab hover style.</summary>
    /// <value>The top tab hover style.</value>
    [Category("States")]
    [Description("The top tab hover style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopHoverLTRStyle => new TripleCellFrameStyleValue(this.LeftTopTabHoverLTRStyle, this.RightTopTabHoverLTRStyle, this.CenterTopTabHoverLTRStyle);

    /// <summary>Gets the top tab hover style.</summary>
    /// <value>The top tab hover style.</value>
    [Category("States")]
    [Description("The top tab hover style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabTopHoverRTLStyle => new TripleCellFrameStyleValue(this.LeftTopTabHoverRTLStyle, this.RightTopTabHoverRTLStyle, this.CenterTopTabHoverRTLStyle);

    /// <summary>Gets the right tab normal style.</summary>
    /// <value>The right tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabNormalLTRStyle));

    /// <summary>Gets the right top tab normal RTL style.</summary>
    /// <value>The right top tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabNormalRTLStyle));

    /// <summary>Gets the right top tab normal style.</summary>
    /// <value>The right top tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightTopTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightTopTabNormalLTRStyle, this.RightTopTabNormalRTLStyle);

    /// <summary>Gets the right tab selected style.</summary>
    /// <value>The right tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabSelectedLTRStyle), this.RightTopTabNormalLTRStyle);

    /// <summary>Gets the right top tab selected RTL style.</summary>
    /// <value>The right top tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabSelectedRTLStyle), this.RightTopTabNormalRTLStyle);

    /// <summary>Gets the right top tab selected style.</summary>
    /// <value>The right top tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightTopTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightTopTabSelectedLTRStyle, this.RightTopTabSelectedRTLStyle);

    /// <summary>Gets the right tab hover style.</summary>
    /// <value>The right tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabHoverLTRStyle), this.RightTopTabNormalLTRStyle);

    /// <summary>Gets the right top tab hover RTL style.</summary>
    /// <value>The right top tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightTopTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (RightTopTabHoverRTLStyle), this.RightTopTabNormalRTLStyle);

    /// <summary>Gets the right top tab hover style.</summary>
    /// <value>The right top tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightTopTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightTopTabHoverLTRStyle, this.RightTopTabHoverRTLStyle);

    /// <summary>Gets the left tab normal style.</summary>
    /// <value>The left tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabNormalLTRStyle));

    /// <summary>Gets the left top tab normal RTL style.</summary>
    /// <value>The left top tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabNormalRTLStyle));

    /// <summary>Gets the left top tab normal style.</summary>
    /// <value>The left top tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftTopTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftTopTabNormalLTRStyle, this.LeftTopTabNormalRTLStyle);

    /// <summary>Gets the left tab selected style.</summary>
    /// <value>The left tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabSelectedLTRStyle), this.LeftTopTabNormalLTRStyle);

    /// <summary>Gets the left top tab selected RTL style.</summary>
    /// <value>The left top tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabSelectedRTLStyle), this.LeftTopTabNormalRTLStyle);

    /// <summary>Gets the left top tab selected style.</summary>
    /// <value>The left top tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftTopTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftTopTabSelectedLTRStyle, this.LeftTopTabSelectedLTRStyle);

    /// <summary>Gets the left tab hover style.</summary>
    /// <value>The left tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabHoverLTRStyle), this.LeftTopTabNormalLTRStyle);

    /// <summary>Gets the left top tab hover RTL style.</summary>
    /// <value>The left top tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftTopTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftTopTabHoverRTLStyle), this.LeftTopTabNormalRTLStyle);

    /// <summary>Gets the left top tab hover style.</summary>
    /// <value>The left top tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftTopTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftTopTabHoverLTRStyle, this.LeftTopTabHoverRTLStyle);

    /// <summary>Gets or sets the width of the left tab top in LTR.</summary>
    /// <value>The width of the left tab top in LTR.</value>
    [Category("Sizes")]
    [Description("The width of the left tab top in LTR.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftTopTabWidthLTR
    {
      get => this.GetValue<int>(nameof (LeftTopTabWidthLTR), this.GetImageWidth(this.LeftTopTabNormalLTRStyle.BackgroundImage, this.DefaultLeftTopTabWidthLTR));
      set => this.SetValue(nameof (LeftTopTabWidthLTR), (object) value);
    }

    /// <summary>Resets the width of the left tab top in LTR.</summary>
    internal void ResetLeftTopTabWidthLTR() => this.Reset("LeftTopTabWidthLTR");

    /// <summary>Gets the default width of the left tab top in LTR.</summary>
    /// <value>The default width of the left tab top in LTR.</value>
    protected virtual int DefaultLeftTopTabWidthLTR => 0;

    /// <summary>Gets or sets the width of the left tab top in RTL.</summary>
    /// <value>The width of the left tab top in RTL.</value>
    [Category("Sizes")]
    [Description("The width of the left tab top in RTL.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftTopTabWidthRTL
    {
      get => this.GetValue<int>(nameof (LeftTopTabWidthRTL), this.GetImageWidth(this.LeftTopTabNormalRTLStyle.BackgroundImage, this.DefaultLeftTopTabWidthRTL));
      set => this.SetValue(nameof (LeftTopTabWidthRTL), (object) value);
    }

    /// <summary>Resets the width of the left tab top in RTL.</summary>
    internal void ResetLeftTopTabWidthRTL() => this.Reset("LeftTopTabWidthRTL");

    /// <summary>Gets the default width of the left tab top in RTL.</summary>
    /// <value>The default width of the left tab top in RTL.</value>
    protected virtual int DefaultLeftTopTabWidthRTL => 0;

    /// <summary>Gets the width of the left top tab.</summary>
    /// <value>The width of the left top tab.</value>
    public BidirectionalSkinProperty<int> LeftTopTabWidth => new BidirectionalSkinProperty<int>((Skin) this, "LeftTopTabWidthLTR", "LeftTopTabWidthRTL");

    /// <summary>Gets or sets the width of the right tab top in LTR.</summary>
    /// <value>The width of the right tab top in LTR.</value>
    [Category("Sizes")]
    [Description("The width of the right tab top in LTR.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightTopTabWidthLTR
    {
      get => this.GetValue<int>(nameof (RightTopTabWidthLTR), this.GetImageWidth(this.RightTopTabNormalLTRStyle.BackgroundImage, this.DefaultRightTopTabWidthLTR));
      set => this.SetValue(nameof (RightTopTabWidthLTR), (object) value);
    }

    /// <summary>Gets the default width of the right tab top in LTR.</summary>
    /// <value>The default width of the right tab top in LTR.</value>
    protected virtual int DefaultRightTopTabWidthLTR => 0;

    /// <summary>Resets the width of the right tab top in LTR.</summary>
    internal void ResetRightTopTabWidthLTR() => this.Reset("RightTopTabWidthLTR");

    /// <summary>Gets the width of the right top tab.</summary>
    /// <value>The width of the right top tab.</value>
    public BidirectionalSkinProperty<int> RightTopTabWidth => new BidirectionalSkinProperty<int>((Skin) this, "RightTopTabWidthLTR", "RightTopTabWidthRTL");

    /// <summary>Gets or sets the width of the right tab top in RTL.</summary>
    /// <value>The width of the right tab top in RTL.</value>
    [Category("Sizes")]
    [Description("The width of the right tab top in RTL.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightTopTabWidthRTL
    {
      get => this.GetValue<int>(nameof (RightTopTabWidthRTL), this.GetImageWidth(this.RightTopTabNormalRTLStyle.BackgroundImage, this.DefaultRightTopTabWidthRTL));
      set => this.SetValue(nameof (RightTopTabWidthRTL), (object) value);
    }

    /// <summary>Gets the default width of the right tab top in RTL.</summary>
    /// <value>The default width of the right tab top in RTL.</value>
    protected virtual int DefaultRightTopTabWidthRTL => 0;

    /// <summary>Resets the width of the right tab top in RTL.</summary>
    internal void ResetRightTopTabWidthRTL() => this.Reset("RightTopTabWidthRTL");

    /// <summary>Gets the center tab normal style.</summary>
    /// <value>The center tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabNormalLTRStyle));

    /// <summary>Gets the center top tab normal RTL style.</summary>
    /// <value>The center top tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabNormalRTLStyle));

    /// <summary>Gets the center top tab normal style.</summary>
    /// <value>The center top tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterTopTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTopTabNormalLTRStyle, this.CenterTopTabNormalRTLStyle);

    /// <summary>Gets the center tab selected style.</summary>
    /// <value>The center tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabSelectedLTRStyle), this.CenterTopTabNormalLTRStyle);

    /// <summary>Gets the center top tab selected RTL style.</summary>
    /// <value>The center top tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabSelectedRTLStyle), this.CenterTopTabNormalRTLStyle);

    /// <summary>Gets the center top tab selected style.</summary>
    /// <value>The center top tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterTopTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTopTabSelectedLTRStyle, this.CenterTopTabSelectedRTLStyle);

    /// <summary>Gets the center tab hover style.</summary>
    /// <value>The center tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabHoverLTRStyle), this.CenterTopTabNormalLTRStyle);

    /// <summary>Gets the center top tab hover RTL style.</summary>
    /// <value>The center top tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTopTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterTopTabHoverRTLStyle), this.CenterTopTabNormalRTLStyle);

    /// <summary>Gets the center top tab hover style.</summary>
    /// <value>The center top tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterTopTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTopTabHoverLTRStyle, this.CenterTopTabHoverRTLStyle);

    /// <summary>Gets the tabs container style.</summary>
    /// <value>The tabs container style.</value>
    [Category("Styles")]
    [Description("The top tab container style.")]
    public virtual StyleValue TabsTopContainerStyle => new StyleValue((CommonSkin) this, nameof (TabsTopContainerStyle));

    /// <summary>Gets the tab Bottom normal style.</summary>
    /// <value>The tab Bottom normal style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomNormalStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabBottomNormalLTRStyle, this.TabBottomNormalRTLStyle);

    /// <summary>Gets the Bottom tab normal style.</summary>
    /// <value>The Bottom tab normal style.</value>
    [Category("States")]
    [Description("The Bottom tab normal LTR style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomNormalLTRStyle => new TripleCellFrameStyleValue(this.LeftBottomTabNormalLTRStyle, this.RightBottomTabNormalLTRStyle, this.CenterBottomTabNormalLTRStyle);

    /// <summary>Gets the tab Bottom normal style.</summary>
    /// <value>The tab Bottom normal style.</value>
    public BidirectionalSkinValue<StyleValue> TabBottomNormalSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabBottomNormalLTRSpreadStyle, this.CenterTabBottomNormalRTLSpreadStyle);

    /// <summary>Gets the tab Bottom normal LTR spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab normal spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomNormalLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomNormalLTRSpreadStyle), this.CenterBottomTabNormalLTRStyle);

    /// <summary>Gets the tab Bottom normal RTL spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab normal spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomNormalRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomNormalRTLSpreadStyle));

    /// <summary>Gets the tab Bottom normal RTL style.</summary>
    /// <value>The tab Bottom normal RTL style.</value>
    [Category("States")]
    [Description("The Bottom tab normal RTL style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomNormalRTLStyle => new TripleCellFrameStyleValue(this.LeftBottomTabNormalRTLStyle, this.RightBottomTabNormalRTLStyle, this.CenterBottomTabNormalRTLStyle);

    /// <summary>Gets the tab Bottom selected style.</summary>
    /// <value>The tab Bottom selected style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomSelectedStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabBottomSelectedLTRStyle, this.TabBottomSelectedRTLStyle);

    /// <summary>Gets the tab Bottom Selected style.</summary>
    /// <value>The tab Bottom Selected style.</value>
    public BidirectionalSkinValue<StyleValue> TabBottomSelectedSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabBottomSelectedLTRSpreadStyle, this.CenterTabBottomSelectedRTLSpreadStyle);

    /// <summary>Gets the tab Bottom selected LTR spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab selected spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomSelectedLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomSelectedLTRSpreadStyle), this.TabPageHeaderSelectedStyle);

    /// <summary>Gets the tab Bottom selected LTR spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab selected  spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomSelectedRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomSelectedRTLSpreadStyle), this.TabPageHeaderSelectedStyle);

    /// <summary>Gets the Bottom tab selected style.</summary>
    /// <value>The Bottom tab selected style.</value>
    [Category("States")]
    [Description("The Bottom tab selected style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomSelectedLTRStyle => new TripleCellFrameStyleValue(this.LeftBottomTabSelectedLTRStyle, this.RightBottomTabSelectedLTRStyle, this.CenterBottomTabSelectedLTRStyle);

    /// <summary>Gets the tab Bottom selected RTL style.</summary>
    /// <value>The tab Bottom selected RTL style.</value>
    [Category("States")]
    [Description("The Bottom tab selected style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomSelectedRTLStyle => new TripleCellFrameStyleValue(this.LeftBottomTabSelectedRTLStyle, this.RightBottomTabSelectedRTLStyle, this.CenterBottomTabSelectedRTLStyle);

    /// <summary>Gets the tab Bottom hover style.</summary>
    /// <value>The tab Bottom hover style.</value>
    public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomHoverStyle => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.TabBottomHoverLTRStyle, this.TabBottomHoverRTLStyle);

    /// <summary>Gets the tab Bottom Hover style.</summary>
    /// <value>The tab Bottom Hover style.</value>
    public BidirectionalSkinValue<StyleValue> TabBottomHoverSpreadStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterTabBottomHoverLTRSpreadStyle, this.CenterTabBottomHoverRTLSpreadStyle);

    /// <summary>Gets the tab Bottom hover LTR spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab hover spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomHoverLTRSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomHoverLTRSpreadStyle));

    /// <summary>Gets the tab Bottom hover RTL spread style.</summary>
    [Category("States")]
    [Description("The Bottom tab hover spread appearance style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterTabBottomHoverRTLSpreadStyle => new StyleValue((CommonSkin) this, nameof (CenterTabBottomHoverRTLSpreadStyle));

    /// <summary>Gets the Bottom tab hover style.</summary>
    /// <value>The Bottom tab hover style.</value>
    [Category("States")]
    [Description("The Bottom tab hover style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomHoverLTRStyle => new TripleCellFrameStyleValue(this.LeftBottomTabHoverLTRStyle, this.RightBottomTabHoverLTRStyle, this.CenterBottomTabHoverLTRStyle);

    /// <summary>Gets the Bottom tab hover style.</summary>
    /// <value>The Bottom tab hover style.</value>
    [Category("States")]
    [Description("The Bottom tab hover style.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TripleCellFrameStyleValue TabBottomHoverRTLStyle => new TripleCellFrameStyleValue(this.LeftBottomTabHoverRTLStyle, this.RightBottomTabHoverRTLStyle, this.CenterBottomTabHoverRTLStyle);

    /// <summary>Gets the right tab normal style.</summary>
    /// <value>The right tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabNormalLTRStyle));

    /// <summary>Gets the right Bottom tab normal RTL style.</summary>
    /// <value>The right Bottom tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabNormalRTLStyle));

    /// <summary>Gets the right Bottom tab normal style.</summary>
    /// <value>The right Bottom tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightBottomTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightBottomTabNormalLTRStyle, this.RightBottomTabNormalRTLStyle);

    /// <summary>Gets the right tab selected style.</summary>
    /// <value>The right tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabSelectedLTRStyle), this.RightBottomTabNormalLTRStyle);

    /// <summary>Gets the right Bottom tab selected RTL style.</summary>
    /// <value>The right Bottom tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabSelectedRTLStyle), this.RightBottomTabNormalRTLStyle);

    /// <summary>Gets the right Bottom tab selected style.</summary>
    /// <value>The right Bottom tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightBottomTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightBottomTabSelectedLTRStyle, this.RightBottomTabSelectedRTLStyle);

    /// <summary>Gets the right tab hover style.</summary>
    /// <value>The right tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabHoverLTRStyle), this.RightBottomTabNormalLTRStyle);

    /// <summary>Gets the right Bottom tab hover RTL style.</summary>
    /// <value>The right Bottom tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightBottomTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (RightBottomTabHoverRTLStyle), this.RightBottomTabNormalRTLStyle);

    /// <summary>Gets the right Bottom tab hover style.</summary>
    /// <value>The right Bottom tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> RightBottomTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.RightBottomTabHoverLTRStyle, this.RightBottomTabHoverRTLStyle);

    /// <summary>Gets the left tab normal style.</summary>
    /// <value>The left tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabNormalLTRStyle));

    /// <summary>Gets the left Bottom tab normal RTL style.</summary>
    /// <value>The left Bottom tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabNormalRTLStyle));

    /// <summary>Gets the left Bottom tab normal style.</summary>
    /// <value>The left Bottom tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftBottomTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftBottomTabNormalLTRStyle, this.LeftBottomTabNormalRTLStyle);

    /// <summary>Gets the left tab selected style.</summary>
    /// <value>The left tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabSelectedLTRStyle), this.LeftBottomTabNormalLTRStyle);

    /// <summary>Gets the left Bottom tab selected RTL style.</summary>
    /// <value>The left Bottom tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabSelectedRTLStyle), this.LeftBottomTabNormalRTLStyle);

    /// <summary>Gets the left Bottom tab selected style.</summary>
    /// <value>The left Bottom tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftBottomTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftBottomTabSelectedLTRStyle, this.LeftBottomTabSelectedRTLStyle);

    /// <summary>Gets the left tab hover style.</summary>
    /// <value>The left tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabHoverLTRStyle), this.LeftBottomTabNormalLTRStyle);

    /// <summary>Gets the left Bottom tab hover RTL style.</summary>
    /// <value>The left Bottom tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftBottomTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (LeftBottomTabHoverRTLStyle), this.LeftBottomTabNormalRTLStyle);

    /// <summary>Gets the left Bottom tab hover style.</summary>
    /// <value>The left Bottom tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> LeftBottomTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftBottomTabHoverLTRStyle, this.LeftBottomTabHoverRTLStyle);

    /// <summary>Gets or sets the width of the left tab Bottom in LTR.</summary>
    /// <value>The width of the left tab Bottom in LTR.</value>
    [Category("Sizes")]
    [Description("The width of the left tab Bottom in LTR.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftBottomTabWidthLTR
    {
      get => this.GetValue<int>(nameof (LeftBottomTabWidthLTR), this.GetImageWidth(this.LeftBottomTabNormalLTRStyle.BackgroundImage, this.DefaultLeftBottomTabWidthLTR));
      set => this.SetValue(nameof (LeftBottomTabWidthLTR), (object) value);
    }

    /// <summary>Resets the width of the left tab Bottom in LTR.</summary>
    internal void ResetLeftBottomTabWidthLTR() => this.Reset("LeftBottomTabWidthLTR");

    /// <summary>Gets the default width of the left tab Bottom in LTR.</summary>
    /// <value>The default width of the left tab Bottom in LTR.</value>
    protected virtual int DefaultLeftBottomTabWidthLTR => 0;

    /// <summary>Gets or sets the width of the left tab Bottom in RTL.</summary>
    /// <value>The width of the left tab Bottom in RTL.</value>
    [Category("Sizes")]
    [Description("The width of the left tab Bottom in RTL.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int LeftBottomTabWidthRTL
    {
      get => this.GetValue<int>(nameof (LeftBottomTabWidthRTL), this.GetImageWidth(this.LeftBottomTabNormalRTLStyle.BackgroundImage, this.DefaultLeftBottomTabWidthRTL));
      set => this.SetValue(nameof (LeftBottomTabWidthRTL), (object) value);
    }

    /// <summary>Resets the width of the left tab Bottom in RTL.</summary>
    internal void ResetLeftBottomTabWidthRTL() => this.Reset("LeftBottomTabWidthRTL");

    /// <summary>Gets the default width of the left tab Bottom in RTL.</summary>
    /// <value>The default width of the left tab Bottom in RTL.</value>
    protected virtual int DefaultLeftBottomTabWidthRTL => 0;

    /// <summary>Gets the width of the left Bottom tab.</summary>
    /// <value>The width of the left Bottom tab.</value>
    public BidirectionalSkinProperty<int> LeftBottomTabWidth => new BidirectionalSkinProperty<int>((Skin) this, "LeftBottomTabWidthLTR", "LeftBottomTabWidthRTL");

    /// <summary>
    /// Gets or sets the width of the right tab Bottom in LTR.
    /// </summary>
    /// <value>The width of the right tab Bottom in LTR.</value>
    [Category("Sizes")]
    [Description("The width of the right tab Bottom in LTR.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightBottomTabWidthLTR
    {
      get => this.GetValue<int>(nameof (RightBottomTabWidthLTR), this.GetImageWidth(this.RightBottomTabNormalLTRStyle.BackgroundImage, this.DefaultRightBottomTabWidthLTR));
      set => this.SetValue(nameof (RightBottomTabWidthLTR), (object) value);
    }

    /// <summary>
    /// Gets the default width of the right tab Bottom in LTR.
    /// </summary>
    /// <value>The default width of the right tab Bottom in LTR.</value>
    protected virtual int DefaultRightBottomTabWidthLTR => 0;

    /// <summary>Resets the width of the right tab Bottom in LTR.</summary>
    internal void ResetRightBottomTabWidthLTR() => this.Reset("RightBottomTabWidthLTR");

    /// <summary>Gets the width of the right Bottom tab.</summary>
    /// <value>The width of the right Bottom tab.</value>
    public BidirectionalSkinProperty<int> RightBottomTabWidth => new BidirectionalSkinProperty<int>((Skin) this, "RightBottomTabWidthLTR", "RightBottomTabWidthRTL");

    /// <summary>
    /// Gets or sets the width of the right tab Bottom in RTL.
    /// </summary>
    /// <value>The width of the right tab Bottom in RTL.</value>
    [Category("Sizes")]
    [Description("The width of the right tab Bottom in RTL.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int RightBottomTabWidthRTL
    {
      get => this.GetValue<int>(nameof (RightBottomTabWidthRTL), this.GetImageWidth(this.RightBottomTabNormalRTLStyle.BackgroundImage, this.DefaultRightBottomTabWidthRTL));
      set => this.SetValue(nameof (RightBottomTabWidthRTL), (object) value);
    }

    /// <summary>
    /// Gets the default width of the right tab Bottom in RTL.
    /// </summary>
    /// <value>The default width of the right tab Bottom in RTL.</value>
    protected virtual int DefaultRightBottomTabWidthRTL => 0;

    /// <summary>Resets the width of the right tab Bottom in RTL.</summary>
    internal void ResetRightBottomTabWidthRTL() => this.Reset("RightBottomTabWidthRTL");

    /// <summary>Gets the center tab normal style.</summary>
    /// <value>The center tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabNormalLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabNormalLTRStyle));

    /// <summary>Gets the center Bottom tab normal RTL style.</summary>
    /// <value>The center Bottom tab normal RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabNormalRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabNormalRTLStyle));

    /// <summary>Gets the center Bottom tab normal style.</summary>
    /// <value>The center Bottom tab normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterBottomTabNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterBottomTabNormalLTRStyle, this.CenterBottomTabNormalRTLStyle);

    /// <summary>Gets the center tab selected style.</summary>
    /// <value>The center tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabSelectedLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabSelectedLTRStyle), this.CenterBottomTabNormalLTRStyle);

    /// <summary>Gets the center Bottom tab selected RTL style.</summary>
    /// <value>The center Bottom tab selected RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabSelectedRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabSelectedRTLStyle), this.CenterBottomTabNormalRTLStyle);

    /// <summary>Gets the center Bottom tab selected style.</summary>
    /// <value>The center Bottom tab selected style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterBottomTabSelectedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterBottomTabSelectedLTRStyle, this.CenterBottomTabSelectedRTLStyle);

    /// <summary>Gets the center tab hover style.</summary>
    /// <value>The center tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabHoverLTRStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabHoverLTRStyle), this.CenterBottomTabNormalLTRStyle);

    /// <summary>Gets the center Bottom tab hover RTL style.</summary>
    /// <value>The center Bottom tab hover RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterBottomTabHoverRTLStyle => new StyleValue((CommonSkin) this, nameof (CenterBottomTabHoverRTLStyle), this.CenterBottomTabNormalRTLStyle);

    /// <summary>Gets the center Bottom tab hover style.</summary>
    /// <value>The center Bottom tab hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<StyleValue> CenterBottomTabHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.CenterBottomTabHoverLTRStyle, this.CenterBottomTabHoverRTLStyle);

    /// <summary>Gets the tabs container style.</summary>
    /// <value>The tabs container style.</value>
    [Category("Styles")]
    [Description("The Bottom tab container style.")]
    public virtual StyleValue TabsBottomContainerStyle => new StyleValue((CommonSkin) this, nameof (TabsBottomContainerStyle));

    /// <summary>Gets the frame frame style.</summary>
    /// <value>The frame frame style.</value>
    [Category("Styles")]
    [Description("The frame style.")]
    public virtual FrameStyleValue FrameStyle => new FrameStyleValue(this.LeftBottomFrameStyle, this.LeftFrameStyle, this.LeftTopFrameStyle, this.TopFrameStyle, this.RightTopFrameStyle, this.RightFrameStyle, this.RightBottomFrameStyle, this.BottomFrameStyle, this.CenterFrameStyle);

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Category("Sizes")]
    [Description("The height of the top frame.")]
    public virtual int TopFrameHeight
    {
      get => this.GetValue<int>(nameof (TopFrameHeight), this.DefaultTopFrameHeight);
      set => this.SetValue(nameof (TopFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the top frame.</summary>
    internal void ResetTopFrameHeight() => this.Reset("TopFrameHeight");

    /// <summary>Gets the default height of the top frame.</summary>
    /// <value>The default height of the top frame.</value>
    protected virtual int DefaultTopFrameHeight => 1;

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom frame.")]
    public virtual int BottomFrameHeight
    {
      get => this.GetValue<int>(nameof (BottomFrameHeight), this.DefaultBottomFrameHeight);
      set => this.SetValue(nameof (BottomFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the bottom frame.</summary>
    internal void ResetBottomFrameHeight() => this.Reset("BottomFrameHeight");

    /// <summary>Gets the default height of the bottom frame.</summary>
    /// <value>The default height of the bottom frame.</value>
    protected virtual int DefaultBottomFrameHeight => 1;

    /// <summary>Gets or sets the height of the tab.</summary>
    /// <value>The height of the tab.</value>
    [Category("Sizes")]
    [Description("The height of the tab.")]
    public virtual int TabHeight
    {
      get => this.GetValue<int>(nameof (TabHeight), this.DefaultTabHeight);
      set => this.SetValue(nameof (TabHeight), (object) value);
    }

    /// <summary>
    /// Gets or sets the height of the tab in Spread appearance.
    /// </summary>
    /// <value>The height of the tab.</value>
    [Category("Sizes")]
    [Description("The height of the tab in Spread appearance.")]
    public virtual int TabSpreadHeight
    {
      get => this.GetValue<int>(nameof (TabSpreadHeight), this.DefaultTabHeight);
      set => this.SetValue(nameof (TabSpreadHeight), (object) value);
    }

    /// <summary>Resets the height of the tab.</summary>
    internal void ResetTabHeight() => this.Reset("TabHeight");

    /// <summary>Gets the default height of the tab.</summary>
    /// <value>The default height of the tab.</value>
    protected virtual int DefaultTabHeight => 21;

    /// <summary>
    /// Gets or sets the default initial start point of the tabs.
    /// </summary>
    /// <value>The default initial start point of the tabs.</value>
    protected virtual int DefaultHeadersOffset => 0;

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("The width of the right frame.")]
    public virtual int RightFrameWidth
    {
      get => this.GetValue<int>(nameof (RightFrameWidth), this.DefaultRightFrameWidth);
      set => this.SetValue(nameof (RightFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the right frame.</summary>
    internal void ResetRightFrameWidth() => this.Reset("RightFrameWidth");

    /// <summary>Gets the default width of the right frame.</summary>
    /// <value>The default width of the right frame.</value>
    protected virtual int DefaultRightFrameWidth => 1;

    /// <summary>Gets or sets the height of the seperator frame.</summary>
    /// <value>The height of the seperator frame.</value>
    [Category("Sizes")]
    [Description("The height of the seperator frame.")]
    public virtual int SeperatorFrameHeight
    {
      get => this.GetValue<int>(nameof (SeperatorFrameHeight), this.DefaultSeperatorFrameHeight);
      set => this.SetValue(nameof (SeperatorFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the seperator frame.</summary>
    private void ResetSeperatorFrameHeight() => this.Reset("SeperatorFrameHeight");

    /// <summary>Gets the default height of the seperator frame.</summary>
    /// <value>The default height of the seperator frame.</value>
    protected virtual int DefaultSeperatorFrameHeight => 0;

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("The width of the left frame.")]
    public virtual int LeftFrameWidth
    {
      get => this.GetValue<int>(nameof (LeftFrameWidth), this.DefaultLeftFrameWidth);
      set => this.SetValue(nameof (LeftFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the left frame.</summary>
    private void ResetLeftFrameWidth() => this.Reset("LeftFrameWidth");

    /// <summary>Gets the default width of the left frame.</summary>
    /// <value>The default width of the left frame.</value>
    protected virtual int DefaultLeftFrameWidth => 1;

    /// <summary>Gets the frame left top style.</summary>
    /// <value>The frame left top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopFrameStyle => new FramePartStyleValue((CommonSkin) this, "LeftTopStyle");

    /// <summary>Gets the frame top style.</summary>
    /// <value>The frame top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopFrameStyle));

    /// <summary>Gets the frame right top style.</summary>
    /// <value>The frame right top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopFrameStyle));

    /// <summary>Gets the frame left style.</summary>
    /// <value>The frame left style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftFrameStyle));

    /// <summary>Gets the frame right style.</summary>
    /// <value>The frame right style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightFrameStyle));

    /// <summary>Gets the frame left bottom style.</summary>
    /// <value>The frame left bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomFrameStyle));

    /// <summary>Gets the center style.</summary>
    /// <value>The center style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterFrameStyle => new StyleValue((CommonSkin) this, nameof (CenterFrameStyle));

    /// <summary>Gets the frame bottom style.</summary>
    /// <value>The frame bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomFrameStyle));

    /// <summary>Gets the frame right bottom style.</summary>
    /// <value>The frame right bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomFrameStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomFrameStyle));

    /// <summary>Gets the seperator frame style.</summary>
    /// <value>The seperator frame style.</value>
    [Category("Styles")]
    [Description("The seperator style.")]
    public virtual SimpleFrameStyleValue SeperatorFrameStyle => new SimpleFrameStyleValue(this.LeftSeperatorFrameStyle, this.RightSeperatorFrameStyle, this.CenterSeperatorFrameStyle);

    /// <summary>Gets the center seperator frame style.</summary>
    /// <value>The center seperator frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterSeperatorFrameStyle => new StyleValue((CommonSkin) this, nameof (CenterSeperatorFrameStyle));

    /// <summary>Gets the right seperator frame style.</summary>
    /// <value>The right seperator frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightSeperatorFrameStyle => new StyleValue((CommonSkin) this, nameof (RightSeperatorFrameStyle));

    /// <summary>Gets the left seperator frame style.</summary>
    /// <value>The left seperator frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftSeperatorFrameStyle => new StyleValue((CommonSkin) this, nameof (LeftSeperatorFrameStyle));

    /// <summary>Gets the header lable normal padding.</summary>
    /// <value>The header lable normal padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinValue<PaddingValue> HeaderLableNormalPadding => new BidirectionalSkinValue<PaddingValue>((Skin) this, this.CenterTopTabNormalLTRStyle.Padding, this.CenterTopTabNormalLTRStyle.Padding);

    /// <summary>Gets the Close button normal style.</summary>
    /// <value>The Close button normal style.</value>
    [Category("States")]
    [Description("The Close button normal style.")]
    public virtual StyleValue CloseButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (CloseButtonNormalStyle));

    /// <summary>Gets the Close button hover style.</summary>
    /// <value>The Close button hover style.</value>
    [Category("States")]
    [Description("The Close button hover style.")]
    public virtual StyleValue CloseButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (CloseButtonHoverStyle), this.CloseButtonNormalStyle);

    /// <summary>Gets the Close button pressed style.</summary>
    /// <value>The Close button pressed style.</value>
    [Category("States")]
    [Description("The Close button pressed style.")]
    public virtual StyleValue CloseButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (CloseButtonPressedStyle), this.CloseButtonNormalStyle);

    /// <summary>Gets or sets the size of the Close button.</summary>
    /// <value>The size of the Close button.</value>
    [Category("Sizes")]
    [Description("The size of the Close button.")]
    public virtual Size CloseButtonSize
    {
      get => this.GetValue<Size>(nameof (CloseButtonSize), this.GetImageSize(this.CloseButtonNormalStyle.BackgroundImage, this.DefaultCloseButtonSize));
      set => this.SetValue(nameof (CloseButtonSize), (object) value);
    }

    /// <summary>Gets the default size of the Close button.</summary>
    /// <value>The default size of the Close button.</value>
    protected virtual Size DefaultCloseButtonSize => new Size(16, 16);

    /// <summary>Resets the size of the Close button.</summary>
    private void ResetCloseButtonSize() => this.Reset("CloseButtonSize");

    /// <summary>Gets the width of the Close button.</summary>
    /// <value>The width of the Close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CloseButtonWidth => this.CloseButtonSize.Width + this.CloseButtonNormalStyle.Padding.Horizontal;

    /// <summary>Gets the height of the Close button.</summary>
    /// <value>The height of the Close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CloseButtonHeight => this.CloseButtonSize.Height;

    /// <summary>Gets the expand button normal style.</summary>
    /// <value>The expand button normal style.</value>
    [Category("States")]
    [Description("The expand button normal style.")]
    public virtual StyleValue ExpandButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (ExpandButtonNormalStyle));

    /// <summary>Gets the Expand button hover style.</summary>
    /// <value>The Expand button hover style.</value>
    [Category("States")]
    [Description("The Expand button hover style.")]
    public virtual StyleValue ExpandButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (ExpandButtonHoverStyle), this.ExpandButtonNormalStyle);

    /// <summary>Gets the expand button pressed style.</summary>
    /// <value>The expand button pressed style.</value>
    [Category("States")]
    [Description("The Expand button pressed style.")]
    public virtual StyleValue ExpandButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (ExpandButtonPressedStyle), this.ExpandButtonNormalStyle);

    /// <summary>Gets or sets the size of the expand button.</summary>
    /// <value>The size of the Expand button.</value>
    [Category("Sizes")]
    [Description("The size of the expand button.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Size ExpandButtonSize => this.GetImageSize(this.ExpandButtonNormalStyle.BackgroundImage, this.DefaultExpandButtonSize);

    /// <summary>Gets the default size of the expand button.</summary>
    /// <value>The default size of the expand button.</value>
    protected virtual Size DefaultExpandButtonSize => new Size(16, 16);

    /// <summary>Gets the width of the Expand button.</summary>
    /// <value>The width of the Expand button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ExpandButtonWidth => this.ExpandButtonSize.Width + this.ExpandButtonNormalStyle.Padding.Horizontal;

    /// <summary>Gets the height of the Expand button.</summary>
    /// <value>The height of the Expand button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ExpandButtonHeight => this.ExpandButtonSize.Height;

    /// <summary>Gets the collapse button normal style.</summary>
    /// <value>The collapse button normal style.</value>
    [Category("States")]
    [Description("The collapse button normal style.")]
    public virtual StyleValue CollapseButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (CollapseButtonNormalStyle));

    /// <summary>Gets the Collapse button hover style.</summary>
    /// <value>The Collapse button hover style.</value>
    [Category("States")]
    [Description("The Collapse button hover style.")]
    public virtual StyleValue CollapseButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (CollapseButtonHoverStyle), this.CollapseButtonNormalStyle);

    /// <summary>Gets the collapse button pressed style.</summary>
    /// <value>The collapse button pressed style.</value>
    [Category("States")]
    [Description("The Collapse button pressed style.")]
    public virtual StyleValue CollapseButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (CollapseButtonPressedStyle), this.CollapseButtonNormalStyle);

    /// <summary>Gets or sets the size of the collapse button.</summary>
    /// <value>The size of the Collapse button.</value>
    [Category("Sizes")]
    [Description("The size of the collapse button.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Size CollapseButtonSize => this.GetImageSize(this.CollapseButtonNormalStyle.BackgroundImage, this.DefaultCollapseButtonSize);

    /// <summary>Gets the default size of the collapse button.</summary>
    /// <value>The default size of the collapse button.</value>
    protected virtual Size DefaultCollapseButtonSize => new Size(16, 16);

    /// <summary>Gets the width of the Collapse button.</summary>
    /// <value>The width of the Collapse button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CollapseButtonWidth => this.CollapseButtonSize.Width + this.CollapseButtonNormalStyle.Padding.Horizontal;

    /// <summary>Gets the height of the Collapse button.</summary>
    /// <value>The height of the Collapse button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CollapseButtonHeight => this.CollapseButtonSize.Height;

    /// <summary>Hide font property</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    /// <summary>Hide fore color property</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets or sets the size of the tab image.</summary>
    /// <value>The size of the tab image.</value>
    [Category("Sizes")]
    [Description("The width and height of the tab page image.")]
    public virtual Size TabImageSize
    {
      get => new Size(this.TabImageWidth, this.TabImageHeight);
      set
      {
        this.TabImageWidth = value.Width;
        this.TabImageHeight = value.Height;
      }
    }

    /// <summary>Resets the size of the tab image.</summary>
    private void ResetTabImageSize()
    {
      this.Reset("TabImageHeight");
      this.Reset("TabImageWidth");
    }

    /// <summary>Gets or sets the height of the tab image.</summary>
    /// <value>The height of the tab image.</value>
    [Category("Sizes")]
    [Description("The height of the tab page image.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TabImageHeight
    {
      get => this.GetValue<int>(nameof (TabImageHeight), this.DefaultTabImageHeight);
      set => this.SetValue(nameof (TabImageHeight), (object) value);
    }

    /// <summary>Gets the default height of the tab image.</summary>
    /// <value>The default height of the tab image.</value>
    protected virtual int DefaultTabImageHeight => 16;

    /// <summary>Gets or sets the width of the tab image.</summary>
    /// <value>The width of the tab image.</value>
    [Category("Sizes")]
    [Description("The width of the tab page image.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int TabImageWidth
    {
      get => this.GetValue<int>(nameof (TabImageWidth), this.DefaultTabImageWidth);
      set => this.SetValue(nameof (TabImageWidth), (object) value);
    }

    /// <summary>Gets the default width of the tab image.</summary>
    /// <value>The default width of the tab image.</value>
    protected virtual int DefaultTabImageWidth => 16;

    /// <summary>Gets the contextual tab group normal style.</summary>
    public virtual StyleValue ContextualTabGroupNormalStyle => new StyleValue((CommonSkin) this, nameof (ContextualTabGroupNormalStyle));

    /// <summary>Gets or sets the height of the contextual tab group.</summary>
    /// <value>The height of the tab.</value>
    [Category("Sizes")]
    [Description("The height of the contextual tab group.")]
    public virtual int ContextualTabGroupHeight
    {
      get => this.GetValue<int>(nameof (ContextualTabGroupHeight), this.DefaultContextualTabGroupHeight);
      set => this.SetValue(nameof (ContextualTabGroupHeight), (object) value);
    }

    /// <summary>Resets the height of the contextual tab group.</summary>
    internal void ResetContextualTabGroupHeight() => this.Reset("ContextualTabGroupHeight");

    /// <summary>Gets the default height of the tab.</summary>
    /// <value>The default height of the tab.</value>
    protected virtual int DefaultContextualTabGroupHeight => 21;

    /// <summary>Gets the tab show content image.</summary>
    [Category("Images")]
    [Description("The default image shown on the each tab in 'MORE' display.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> TabShowContentImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "TabShowContentImageLTR", "TabShowContentImageRTL");

    [Category("Images")]
    [Description("The default image size shown on the each tab in 'MORE' display.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<Size> TabShowContentImageSize => new BidirectionalSkinProperty<Size>((Skin) this, "TabShowContentImageLTRSize", "TabShowContentImageRTLSize");

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinProperty<int> TabShowContentImageHeight => new BidirectionalSkinProperty<int>((Skin) this, "TabShowContentImageLTRHeight", "TabShowContentImageRTLHeight");

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BidirectionalSkinProperty<int> TabShowContentImageWidth => new BidirectionalSkinProperty<int>((Skin) this, "TabShowContentImageLTRWidth", "TabShowContentImageRTLWidth");

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TabShowContentImageLTRHeight => this.TabShowContentImageLTRSize.Height;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TabShowContentImageLTRWidth => this.TabShowContentImageLTRSize.Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TabShowContentImageRTLHeight => this.TabShowContentImageRTLSize.Height;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TabShowContentImageRTLWidth => this.TabShowContentImageRTLSize.Width;

    /// <summary>Gets or sets the tab show content image LTR.</summary>
    /// <value>The tab show content image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference TabShowContentImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (TabShowContentImageLTR), new ImageResourceReference(typeof (TabControlSkin), "TabShowContentLTR.png"));
      set => this.SetValue(nameof (TabShowContentImageLTR), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size TabShowContentImageLTRSize
    {
      get => this.GetValue<Size>(nameof (TabShowContentImageLTRSize), this.GetImageSize(this.TabShowContentImageLTR, Size.Empty));
      set => this.SetValue(nameof (TabShowContentImageLTRSize), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size TabShowContentImageRTLSize
    {
      get => this.GetValue<Size>(nameof (TabShowContentImageRTLSize), this.GetImageSize(this.TabShowContentImageRTL, Size.Empty));
      set => this.SetValue(nameof (TabShowContentImageRTLSize), (object) value);
    }

    /// <summary>Resets the tab show content image LTR.</summary>
    private void ResetTabShowContentImageLTR() => this.Reset("TabShowContentImageLTR");

    /// <summary>Gets or sets the tab show content image RTL.</summary>
    /// <value>The tab show content image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference TabShowContentImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (TabShowContentImageRTL), new ImageResourceReference(typeof (TabControlSkin), "TabShowContentRTL.png"));
      set => this.SetValue("DropDownOverImageRTL", (object) value);
    }

    /// <summary>Resets the tab show content image RTL.</summary>
    private void ResetTabShowContentImageRTL() => this.Reset("TabShowContentImageRTL");

    /// <summary>Gets the More Tab image.</summary>
    /// <value>The image.</value>
    [Category("Images")]
    [Description("The default image shown on tab 'MORE'.")]
    public virtual ImageResourceReference TabMoreImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (TabMoreImage), new ImageResourceReference(typeof (TabControlSkin), "TabMoreImage.png"));
      set => this.SetValue(nameof (TabMoreImage), (object) value);
    }

    /// <summary>Gets the tab page headers container spread style.</summary>
    [Category("Appearance")]
    [Description("Tab Page Headers Container style in Spread appearance.")]
    public virtual StyleValue TabPageHeadersContainerSpreadStyle => new StyleValue((CommonSkin) this, nameof (TabPageHeadersContainerSpreadStyle));

    /// <summary>
    /// Gets the tab page headers container spread top padding.
    /// </summary>
    [Browsable(false)]
    public virtual int TabPageHeadersContainerSpreadStylePaddingTop => this.TabPageHeadersContainerSpreadStyle.Padding.Top;

    /// <summary>
    /// Gets the tab page headers container spread bottom padding.
    /// </summary>
    [Browsable(false)]
    public virtual int TabPageHeadersContainerSpreadStylePaddingBottom => this.TabPageHeadersContainerSpreadStyle.Padding.Bottom;

    /// <summary>Gets the tab page header gradient selected style.</summary>
    [Category("Appearance")]
    [Description("Tab Page Header Selected style.")]
    public virtual StyleValue TabPageHeaderSelectedStyle => new StyleValue((CommonSkin) this, nameof (TabPageHeaderSelectedStyle));

    /// <summary>Gets the tab page more tab page style.</summary>
    [Category("Appearance")]
    [Description("The style of the tab pages in tab more content.")]
    public virtual StyleValue TabPageMoreTabPagesStyle => new StyleValue((CommonSkin) this, nameof (TabPageMoreTabPagesStyle), this.CenterTabTopNormalLTRSpreadStyle);

    /// <summary>Gets the tab page more tab page hover style.</summary>
    [Category("Appearance")]
    [Description("The style of the tab pages in tab more content on hover.")]
    public virtual StyleValue TabPageMoreTabHoverPagesStyle => new StyleValue((CommonSkin) this, nameof (TabPageMoreTabHoverPagesStyle), this.CenterTabTopHoverLTRSpreadStyle);

    /// <summary>Gets the tab top pressed more style.</summary>
    [Category("Appearance")]
    [Description("The top tab pressed more appearance style.")]
    public virtual StyleValue TabPageMoreTabPressedPagesStyle => new StyleValue((CommonSkin) this, "TabPageMoreTabSelectedPagesStyle", this.CenterTabTopSelectedLTRSpreadStyle);

    /// <summary>
    /// Gets or sets the height of the tab page more tab page.
    /// </summary>
    /// <value>The height of the tab page more tab page.</value>
    [Category("Sizes")]
    [Description("The height of the tab pages in tab more content.")]
    public virtual int TabPageMoreTabPageHeight
    {
      get => this.GetValue<int>(nameof (TabPageMoreTabPageHeight), this.DefaultTabPageMoreTabPageHeight);
      set => this.SetValue(nameof (TabPageMoreTabPageHeight), (object) value);
    }

    /// <summary>Resets the height of the tab page more tab page.</summary>
    internal void ResetTabPageMoreTabPageHeight() => this.Reset("TabPageMoreTabPageHeight");

    /// <summary>
    /// Gets the default height of the tab page more tab page.
    /// </summary>
    /// <value>The default height of the tab page more tab page.</value>
    private int DefaultTabPageMoreTabPageHeight => 44;

    private void InitializeComponent()
    {
    }
  }
}
