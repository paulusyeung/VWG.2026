// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.FormSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Form Skin</summary>
  [ToolboxBitmap(typeof (Form))]
  [Serializable]
  public class FormSkin : ContainerControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the dialog window modal style.</summary>
    /// <value>The dialog window modal style.</value>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("WindowModalMaskOpacityDescr")]
    public new virtual StyleValue WindowModalMaskStyle => new StyleValue((CommonSkin) this, nameof (WindowModalMaskStyle));

    /// <summary>Gets or sets the back color opacity.</summary>
    /// <value>The back color opacity.</value>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("WindowModalMaskOpacityDescr")]
    public new OpacityValue WindowModalMaskOpacity
    {
      get => this.GetValue<OpacityValue>(nameof (WindowModalMaskOpacity), new OpacityValue(this.DefaultWindowModalMaskOpacity));
      set
      {
        if (value.Opacity < 0 || value.Opacity > 100)
          throw new Exception("You must supply values between 1 and 100.");
        this.SetValue(nameof (WindowModalMaskOpacity), (object) value);
      }
    }

    /// <summary>Resets the height value</summary>
    internal void ResetWindowModalMaskOpacity() => this.Reset("WindowModalMaskOpacity");

    /// <summary>Gets the size of the default minimized MDI form.</summary>
    /// <value>The size of the default minimized MDI form.</value>
    protected virtual Size DefaultMinimizedMdiFormSize => new Size(200, 60);

    /// <summary>Gets default value</summary>
    protected virtual int DefaultWindowModalMaskOpacity => 50;

    /// <summary>
    /// Gets or sets the width of the left dialog window frame.
    /// </summary>
    /// <value>The width of the left dialog window frame.</value>
    [Category("Sizes")]
    [Description("The width of the left dialog window frame.")]
    public virtual int LeftDialogWindowFrameWidth
    {
      get => this.GetValue<int>(nameof (LeftDialogWindowFrameWidth), this.GetImageWidth(this.ActiveDialogWindowStyle.LeftStyle.BackgroundImage, this.DefaultLeftDialogWindowFrameWidth));
      set => this.SetValue(nameof (LeftDialogWindowFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the left dialog window frame.</summary>
    internal void ResetLeftDialogWindowFrameWidth() => this.Reset("LeftDialogWindowFrameWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultLeftDialogWindowFrameWidth => 4;

    /// <summary>
    /// Gets or sets the width of the right dialog window frame.
    /// </summary>
    /// <value>The width of the right dialog window frame.</value>
    [Category("Sizes")]
    [Description("The width of the right dialog window frame.")]
    public virtual int RightDialogWindowFrameWidth
    {
      get => this.GetValue<int>(nameof (RightDialogWindowFrameWidth), this.GetImageWidth(this.ActiveDialogWindowStyle.RightStyle.BackgroundImage, this.DefaultRightDialogWindowFrameWidth));
      set => this.SetValue(nameof (RightDialogWindowFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the right dialog window frame.</summary>
    internal void ResetRightDialogWindowFrameWidth() => this.Reset("RightDialogWindowFrameWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultRightDialogWindowFrameWidth => 4;

    /// <summary>
    /// Gets or sets the height of the top dialog window frame.
    /// </summary>
    /// <value>The height of the top dialog window frame.</value>
    [Category("Sizes")]
    [Description("The height of the top dialog window frame.")]
    public virtual int TopDialogWindowFrameHeight
    {
      get => this.GetValue<int>(nameof (TopDialogWindowFrameHeight), this.GetImageHeight(this.ActiveDialogWindowStyle.TopStyle.BackgroundImage, this.DefaultTopDialogWindowFrameHeight));
      set => this.SetValue(nameof (TopDialogWindowFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the top dialog window frame.</summary>
    internal void ResetTopDialogWindowFrameHeight() => this.Reset("TopDialogWindowFrameHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultTopDialogWindowFrameHeight => 4;

    /// <summary>
    /// Gets or sets the height of the bottom dialog window frame.
    /// </summary>
    /// <value>The height of the bottom dialog window frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom dialog window frame.")]
    public virtual int BottomDialogWindowFrameHeight
    {
      get => this.GetValue<int>(nameof (BottomDialogWindowFrameHeight), this.GetImageHeight(this.ActiveDialogWindowStyle.BottomStyle.BackgroundImage, this.DefaultBottomDialogWindowFrameHeight));
      set => this.SetValue(nameof (BottomDialogWindowFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the bottom dialog window frame.</summary>
    internal void ResetBottomDialogWindowFrameHeight() => this.Reset("BottomDialogWindowFrameHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultBottomDialogWindowFrameHeight => 4;

    /// <summary>Gets the normal active dialog style.</summary>
    /// <value>The normal active dialog style.</value>
    [Category("States")]
    [Description("The normal active dialog style.")]
    public virtual OverlayedFrameStyleValue ActiveDialogWindowStyle => new OverlayedFrameStyleValue(this.LeftBottomActiveDialogWindowStyle, this.LeftActiveDialogWindowStyle, this.LeftTopActiveDialogWindowStyle, this.TopActiveDialogWindowStyle, this.RightTopActiveDialogWindowStyle, this.RightActiveDialogWindowStyle, this.RightBottomActiveDialogWindowStyle, this.BottomActiveDialogWindowStyle, this.CenterActiveDialogWindowStyle, this.LeftOverlayActiveDialogWindowStyle, this.RightOverlayActiveDialogWindowStyle);

    /// <summary>Gets the dialog window captions style.</summary>
    /// <value>The dialog window captions style.</value>
    [Category("States")]
    [Description("The dialog window captions style.")]
    public virtual StyleValue DialogWindowCaptionStyle => new StyleValue((CommonSkin) this, nameof (DialogWindowCaptionStyle));

    /// <summary>Gets the dialog window buttons style.</summary>
    /// <value>The dialog window buttons style.</value>
    [Category("States")]
    [Description("The dialog window buttons style.")]
    public virtual StyleValue DialogWindowButtonsStyle => new StyleValue((CommonSkin) this, nameof (DialogWindowButtonsStyle));

    /// <summary>Gets the dialog window close button normal style.</summary>
    /// <value>The dialog window close button normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window close button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowCloseButtonNormalStyleLTR, this.DialogWindowCloseButtonNormalStyleRTL);

    /// <summary>Gets the dialog window close button normal style LTR.</summary>
    /// <value>The dialog window close button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonNormalStyleLTR));

    /// <summary>Gets the dialog window close button normal style RTL.</summary>
    /// <value>The dialog window close button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonNormalStyleRTL));

    /// <summary>Gets the dialog window close button hover style.</summary>
    /// <value>The dialog window close button hover style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window hover close button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowCloseButtonHoverStyleLTR, this.DialogWindowCloseButtonHoverStyleRTL);

    /// <summary>Gets the dialog window close button hover style LTR.</summary>
    /// <value>The dialog window close button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonHoverStyleLTR), this.DialogWindowCloseButtonNormalStyleLTR);

    /// <summary>Gets the dialog window close button hover style RTL.</summary>
    /// <value>The dialog window close button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonHoverStyleRTL), this.DialogWindowCloseButtonNormalStyleRTL);

    /// <summary>Gets the dialog window close button disabled style.</summary>
    /// <value>The dialog window close button disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window disabled close button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowCloseButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowCloseButtonDisabledStyleLTR, this.DialogWindowCloseButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the dialog window close button disabled style RTL.
    /// </summary>
    /// <value>The dialog window close button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonDisabledStyleRTL), this.DialogWindowCloseButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window close button disabled style LTR.
    /// </summary>
    /// <value>The dialog window close button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowCloseButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowCloseButtonDisabledStyleLTR), this.DialogWindowCloseButtonNormalStyleLTR);

    /// <summary>
    /// Gets or sets the size of the dialog window close button.
    /// </summary>
    /// <value>The size of the dialog window close button.</value>
    [Category("Sizes")]
    [Description("The size of the dialog window close button.")]
    public virtual Size DialogWindowCloseButtonSize
    {
      get => this.GetValue<Size>(nameof (DialogWindowCloseButtonSize), this.GetImageSize(this.DialogWindowCloseButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (DialogWindowCloseButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetHeight() => this.Reset("DialogWindowCloseButtonSize");

    /// <summary>Gets the width of the dialog window close button.</summary>
    /// <value>The width of the dialog window close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DialogWindowCloseButtonWidth => this.DialogWindowCloseButtonSize.Width;

    /// <summary>Gets the height of the dialog window close button.</summary>
    /// <value>The height of the dialog window close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DialogWindowButtonCloseHeight => this.DialogWindowCloseButtonSize.Height;

    /// <summary>Gets the dialog window minimize button normal style.</summary>
    /// <value>The dialog window minimize button normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window minimize button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMinimizeButtonNormalStyleLTR, this.DialogWindowMinimizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window minimize button normal style LTR.
    /// </summary>
    /// <value>The dialog window minimize button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonNormalStyleLTR));

    /// <summary>
    /// Gets the dialog window minimize button normal style RTL.
    /// </summary>
    /// <value>The dialog window minimize button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonNormalStyleRTL));

    /// <summary>Gets the dialog window minimize button hover style.</summary>
    /// <value>The dialog window minimize button hover style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window hover minimize button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMinimizeButtonHoverStyleLTR, this.DialogWindowMinimizeButtonHoverStyleRTL);

    /// <summary>
    /// Gets the dialog window minimize button hover style LTR.
    /// </summary>
    /// <value>The dialog window minimize button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonHoverStyleLTR), this.DialogWindowMinimizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window minimize button hover style RTL.
    /// </summary>
    /// <value>The dialog window minimize button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonHoverStyleRTL), this.DialogWindowMinimizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window minimize button disabled style.
    /// </summary>
    /// <value>The dialog window minimize button disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The dialog window disabled minimize button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMinimizeButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMinimizeButtonDisabledStyleLTR, this.DialogWindowMinimizeButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the dialog window minimize button disabled style LTR.
    /// </summary>
    /// <value>The dialog window minimize button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonDisabledStyleLTR), this.DialogWindowMinimizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window minimize button disabled style RTL.
    /// </summary>
    /// <value>The dialog window minimize button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMinimizeButtonDisabledStyleRTL), this.DialogWindowMinimizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets or sets the size of the dialog window minimize button.
    /// </summary>
    /// <value>The size of the dialog window minimize button.</value>
    [Category("Sizes")]
    [Description("The size of the dialog window minimize button.")]
    public virtual Size DialogWindowMinimizeButtonSize
    {
      get => this.GetValue<Size>(nameof (DialogWindowMinimizeButtonSize), this.GetImageSize(this.DialogWindowMinimizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (DialogWindowMinimizeButtonSize), (object) value);
    }

    /// <summary>
    /// Gets or sets the size of the dialog window restore button.
    /// </summary>
    /// <value>The size of the dialog window restore button.</value>
    [Category("Sizes")]
    [Description("The size of the dialog window restore button.")]
    public virtual Size DialogWindowRestoreButtonSize
    {
      get => this.GetValue<Size>(nameof (DialogWindowRestoreButtonSize), this.GetImageSize(this.DialogWindowRestoreButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (DialogWindowRestoreButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetDialogWindowMinimizeButtonSize() => this.Reset("DialogWindowMinimizeButtonSize");

    /// <summary>Gets the width of the dialog window restore button.</summary>
    /// <value>The width of the dialog window restore button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowRestoreButtonWidth => this.DialogWindowRestoreButtonSize.Width;

    /// <summary>Gets the height of the dialog window restore button.</summary>
    /// <value>The height of the dialog window restore button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DialogWindowRestoreButtonHeight => this.DialogWindowRestoreButtonSize.Height;

    /// <summary>Gets the width of the dialog window minimize button.</summary>
    /// <value>The width of the dialog window minimize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowMinimizeButtonWidth => this.DialogWindowMinimizeButtonSize.Width;

    /// <summary>Gets the height of the dialog window minimize button.</summary>
    /// <value>The height of the dialog window minimize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DialogWindowMinimizeButtonHeight => this.DialogWindowMinimizeButtonSize.Height;

    /// <summary>Gets the height of the dialog window close button.</summary>
    /// <value>The height of the dialog window close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowCloseButtonHeight => this.DialogWindowCloseButtonSize.Height;

    /// <summary>Gets the dialog window restore button normal style.</summary>
    /// <value>The dialog window restore button normal style.</value>
    [Category("States")]
    [Description("The dialog window restore button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowRestoreButtonNormalStyleLTR, this.DialogWindowRestoreButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window restore button normal style LTR.
    /// </summary>
    /// <value>The dialog window restore button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonNormalStyleLTR));

    /// <summary>
    /// Gets the dialog window restore button normal style RTL.
    /// </summary>
    /// <value>The dialog window restore button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonNormalStyleRTL));

    /// <summary>Gets the dialog window restore button hover style.</summary>
    /// <value>The dialog window restore button hover style.</value>
    [Category("States")]
    [Description("The dialog window hover restore button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowRestoreButtonHoverStyleLTR, this.DialogWindowRestoreButtonHoverStyleRTL);

    /// <summary>
    /// Gets the dialog window restore button hover style LTR.
    /// </summary>
    /// <value>The dialog window restore button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonHoverStyleLTR), this.DialogWindowMaximizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window restore button hover style RTL.
    /// </summary>
    /// <value>The dialog window restore button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonHoverStyleRTL), this.DialogWindowMaximizeButtonNormalStyleRTL);

    /// <summary>Gets the dialog window restore button disabled style.</summary>
    /// <value>The dialog window restore button disabled style.</value>
    [Category("States")]
    [Description("The dialog window disabled restore button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowRestoreButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowRestoreButtonDisabledStyleLTR, this.DialogWindowRestoreButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the dialog window restore button disabled style LTR.
    /// </summary>
    /// <value>The dialog window restore button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonDisabledStyleLTR), this.DialogWindowMaximizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window restore button disabled style RTL.
    /// </summary>
    /// <value>The dialog window restore button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowRestoreButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowRestoreButtonDisabledStyleRTL), this.DialogWindowMaximizeButtonNormalStyleRTL);

    /// <summary>Gets the dialog window maximize button normal style.</summary>
    /// <value>The dialog window maximize button normal style.</value>
    [Category("States")]
    [Description("The dialog window maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMaximizeButtonNormalStyleLTR, this.DialogWindowMaximizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window maximize button normal style LTR.
    /// </summary>
    /// <value>The dialog window maximize button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonNormalStyleLTR));

    /// <summary>
    /// Gets the dialog window maximize button normal style RTL.
    /// </summary>
    /// <value>The dialog window maximize button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonNormalStyleRTL));

    /// <summary>Gets the dialog window maximize button hover style.</summary>
    /// <value>The dialog window maximize button hover style.</value>
    [Category("States")]
    [Description("The dialog window hover maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMaximizeButtonHoverStyleLTR, this.DialogWindowMaximizeButtonHoverStyleRTL);

    /// <summary>
    /// Gets the dialog window maximize button hover style LTR.
    /// </summary>
    /// <value>The dialog window maximize button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonHoverStyleLTR), this.DialogWindowMaximizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window maximize button hover style RTL.
    /// </summary>
    /// <value>The dialog window maximize button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonHoverStyleRTL), this.DialogWindowMaximizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the dialog window maximize button disabled style.
    /// </summary>
    /// <value>The dialog window maximize button disabled style.</value>
    [Category("States")]
    [Description("The dialog window disabled maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> DialogWindowMaximizeButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DialogWindowMaximizeButtonDisabledStyleLTR, this.DialogWindowMaximizeButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the dialog window maximize button disabled style LTR.
    /// </summary>
    /// <value>The dialog window maximize button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonDisabledStyleLTR), this.DialogWindowMaximizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the dialog window maximize button disabled style RTL.
    /// </summary>
    /// <value>The dialog window maximize button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (DialogWindowMaximizeButtonDisabledStyleRTL), this.DialogWindowMaximizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets or sets the size of the dialog window maximize button.
    /// </summary>
    /// <value>The size of the dialog window maximize button.</value>
    [Category("Sizes")]
    [Description("The size of the dialog window maximize button.")]
    public virtual Size DialogWindowMaximizeButtonSize
    {
      get => this.GetValue<Size>(nameof (DialogWindowMaximizeButtonSize), this.GetImageSize(this.DialogWindowMaximizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (DialogWindowMaximizeButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetDialogWindowMaximizeButtonSize() => this.Reset("DialogWindowMaximizeButtonSize");

    /// <summary>Gets the width of the dialog window maximize button.</summary>
    /// <value>The width of the dialog window maximize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int DialogWindowMaximizeButtonWidth => this.DialogWindowMaximizeButtonSize.Width;

    /// <summary>Gets the height of the dialog window maximize button.</summary>
    /// <value>The height of the dialog window maximize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DialogWindowMaximizeButtonHeight => this.DialogWindowMaximizeButtonSize.Height;

    /// <summary>Gets the center normal active dialog style.</summary>
    /// <value>The center normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterActiveDialogWindowStyle => new StyleValue((CommonSkin) this, nameof (CenterActiveDialogWindowStyle));

    /// <summary>Gets the left normal active dialog style.</summary>
    /// <value>The left normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftActiveDialogWindowStyle));

    /// <summary>Gets the top normal active dialog style.</summary>
    /// <value>The top normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopActiveDialogWindowStyle));

    /// <summary>Gets the bottom normal active dialog style.</summary>
    /// <value>The bottom normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomActiveDialogWindowStyle));

    /// <summary>Gets the right normal active dialog style.</summary>
    /// <value>The right normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightActiveDialogWindowStyle));

    /// <summary>Gets the right top normal active dialog style.</summary>
    /// <value>The right top normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopActiveDialogWindowStyle));

    /// <summary>Gets the left top normal active dialog style.</summary>
    /// <value>The left top normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopActiveDialogWindowStyle));

    /// <summary>Gets the left overlay active dialog window style.</summary>
    /// <value>The left overlay active dialog window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FrameOverlayStyleValue LeftOverlayActiveDialogWindowStyle => new FrameOverlayStyleValue((CommonSkin) this, nameof (LeftOverlayActiveDialogWindowStyle));

    /// <summary>Gets the right overlay active dialog window style.</summary>
    /// <value>The right overlay active dialog window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FrameOverlayStyleValue RightOverlayActiveDialogWindowStyle => new FrameOverlayStyleValue((CommonSkin) this, nameof (RightOverlayActiveDialogWindowStyle));

    /// <summary>Gets the left bottom normal active dialog style.</summary>
    /// <value>The left bottom normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomActiveDialogWindowStyle));

    /// <summary>Gets the right bottom normal active dialog style.</summary>
    /// <value>The right bottom normal active dialog style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomActiveDialogWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomActiveDialogWindowStyle));

    /// <summary>Gets or sets the width of the left tool window frame.</summary>
    /// <value>The width of the left tool window frame.</value>
    [Category("Sizes")]
    [Description("The width of the left tool window frame.")]
    public virtual int LeftToolWindowFrameWidth
    {
      get => this.GetValue<int>(nameof (LeftToolWindowFrameWidth), this.GetImageWidth(this.ActiveToolWindowStyle.LeftStyle.BackgroundImage, this.DefaultLeftToolWindowFrameWidth));
      set => this.SetValue(nameof (LeftToolWindowFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the left tool window frame.</summary>
    internal void ResetLeftToolWindowFrameWidth() => this.Reset("LeftToolWindowFrameWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultLeftToolWindowFrameWidth => 4;

    /// <summary>
    /// Gets or sets the width of the right tool window frame.
    /// </summary>
    /// <value>The width of the right tool window frame.</value>
    [Category("Sizes")]
    [Description("The width of the right tool window frame.")]
    public virtual int RightToolWindowFrameWidth
    {
      get => this.GetValue<int>(nameof (RightToolWindowFrameWidth), this.GetImageWidth(this.ActiveToolWindowStyle.RightStyle.BackgroundImage, this.DefaultRightToolWindowFrameWidth));
      set => this.SetValue(nameof (RightToolWindowFrameWidth), (object) value);
    }

    /// <summary>Resets the width of the right tool window frame.</summary>
    internal void ResetRightToolWindowFrameWidth() => this.Reset("RightToolWindowFrameWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultRightToolWindowFrameWidth => 4;

    /// <summary>Gets or sets the height of the top tool window frame.</summary>
    /// <value>The height of the top tool window frame.</value>
    [Category("Sizes")]
    [Description("The height of the top tool window frame.")]
    public virtual int TopToolWindowFrameHeight
    {
      get => this.GetValue<int>(nameof (TopToolWindowFrameHeight), this.GetImageHeight(this.ActiveToolWindowStyle.TopStyle.BackgroundImage, this.DefaultTopToolWindowFrameHeight));
      set => this.SetValue(nameof (TopToolWindowFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the top tool window frame.</summary>
    internal void ResetTopToolWindowFrameHeight() => this.Reset("TopToolWindowFrameHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultTopToolWindowFrameHeight => 4;

    /// <summary>
    /// Gets or sets the height of the bottom tool window frame.
    /// </summary>
    /// <value>The height of the bottom tool window frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom tool window frame.")]
    public virtual int BottomToolWindowFrameHeight
    {
      get => this.GetValue<int>(nameof (BottomToolWindowFrameHeight), this.GetImageHeight(this.ActiveToolWindowStyle.BottomStyle.BackgroundImage, this.DefaultBottomToolWindowFrameHeight));
      set => this.SetValue(nameof (BottomToolWindowFrameHeight), (object) value);
    }

    /// <summary>Resets the height of the bottom tool window frame.</summary>
    internal void ResetBottomToolWindowFrameHeight() => this.Reset("BottomToolWindowFrameHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultBottomToolWindowFrameHeight => 4;

    /// <summary>Gets the normal active tool style.</summary>
    /// <value>The normal active tool style.</value>
    [Category("States")]
    [Description("The normal active tool style.")]
    public virtual FrameStyleValue ActiveToolWindowStyle => new FrameStyleValue(this.LeftBottomActiveToolWindowStyle, this.LeftActiveToolWindowStyle, this.LeftTopActiveToolWindowStyle, this.TopActiveToolWindowStyle, this.RightTopActiveToolWindowStyle, this.RightActiveToolWindowStyle, this.RightBottomActiveToolWindowStyle, this.BottomActiveToolWindowStyle, this.CenterActiveToolWindowStyle);

    /// <summary>Gets the tool window captions style.</summary>
    /// <value>The tool window captions style.</value>
    [Category("States")]
    [Description("The tool window captions style.")]
    public virtual StyleValue ToolWindowCaptionStyle => new StyleValue((CommonSkin) this, nameof (ToolWindowCaptionStyle));

    /// <summary>Gets the tool window buttons style.</summary>
    /// <value>The tool window buttons style.</value>
    [Category("States")]
    [Description("The tool window buttons style.")]
    public virtual StyleValue ToolWindowButtonsStyle => new StyleValue((CommonSkin) this, nameof (ToolWindowButtonsStyle));

    /// <summary>Gets the tool window close button normal style.</summary>
    /// <value>The tool window close button normal style.</value>
    [Category("States")]
    [Description("The tool window close button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowCloseButtonNormalStyleLTR, this.ToolWindowCloseButtonNormalStyleRTL);

    /// <summary>Gets the tool window close button normal style LTR.</summary>
    /// <value>The tool window close button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonNormalStyleLTR));

    /// <summary>Gets the tool window close button normal style RTL.</summary>
    /// <value>The tool window close button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonNormalStyleRTL));

    /// <summary>Gets the tool window close button hover style.</summary>
    /// <value>The tool window close button hover style.</value>
    [Category("States")]
    [Description("The tool window hover close button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowCloseButtonHoverStyleLTR, this.ToolWindowCloseButtonHoverStyleRTL);

    /// <summary>Gets the tool window close button hover style LTR.</summary>
    /// <value>The tool window close button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonHoverStyleLTR), this.ToolWindowCloseButtonNormalStyleLTR);

    /// <summary>Gets the tool window close button hover style RTL.</summary>
    /// <value>The tool window close button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonHoverStyleRTL), this.ToolWindowCloseButtonNormalStyleRTL);

    /// <summary>Gets the tool window close button disabled style.</summary>
    /// <value>The tool window close button disabled style.</value>
    [Category("States")]
    [Description("The tool window disabled close button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowCloseButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowCloseButtonDisabledStyleLTR, this.ToolWindowCloseButtonDisabledStyleRTL);

    /// <summary>Gets the tool window close button disabled style LTR.</summary>
    /// <value>The tool window close button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonDisabledStyleLTR), this.ToolWindowCloseButtonNormalStyleLTR);

    /// <summary>Gets the tool window close button disabled style RTL.</summary>
    /// <value>The tool window close button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowCloseButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowCloseButtonDisabledStyleRTL), this.ToolWindowCloseButtonNormalStyleRTL);

    /// <summary>
    /// Gets or sets the size of the tool window close button.
    /// </summary>
    /// <value>The size of the tool window close button.</value>
    [Category("Sizes")]
    [Description("The size of the tool window close button.")]
    public virtual Size ToolWindowCloseButtonSize
    {
      get => this.GetValue<Size>(nameof (ToolWindowCloseButtonSize), this.GetImageSize(this.ToolWindowCloseButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (ToolWindowCloseButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetToolWindowCloseButtonSize() => this.Reset("ToolWindowCloseButtonSize");

    /// <summary>Gets the width of the tool window close button.</summary>
    /// <value>The width of the tool window close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowCloseButtonWidth => this.ToolWindowCloseButtonSize.Width;

    /// <summary>Gets the height of the tool window close button.</summary>
    /// <value>The height of the tool window close button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowCloseButtonHeight => this.ToolWindowCloseButtonSize.Height;

    /// <summary>Gets the tool window minimize button normal style.</summary>
    /// <value>The tool window minimize button normal style.</value>
    [Category("States")]
    [Description("The tool window minimize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMinimizeButtonNormalStyleLTR, this.ToolWindowMinimizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the tool window minimize button normal style LTR.
    /// </summary>
    /// <value>The tool window minimize button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonNormalStyleLTR));

    /// <summary>
    /// Gets the tool window minimize button normal style RTL.
    /// </summary>
    /// <value>The tool window minimize button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonNormalStyleRTL));

    /// <summary>Gets the tool window minimize button hover style.</summary>
    /// <value>The tool window minimize button hover style.</value>
    [Category("States")]
    [Description("The tool window hover minimize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMinimizeButtonHoverStyleLTR, this.ToolWindowMinimizeButtonHoverStyleRTL);

    /// <summary>Gets the tool window minimize button hover style LTR.</summary>
    /// <value>The tool window minimize button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonHoverStyleLTR), this.ToolWindowMinimizeButtonNormalStyleLTR);

    /// <summary>Gets the tool window minimize button hover style RTL.</summary>
    /// <value>The tool window minimize button hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonHoverStyleRTL), this.ToolWindowMinimizeButtonNormalStyleRTL);

    /// <summary>Gets the tool window minimize button disabled style.</summary>
    /// <value>The tool window minimize button disabled style.</value>
    [Category("States")]
    [Description("The tool window disabled minimize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMinimizeButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMinimizeButtonDisabledStyleLTR, this.ToolWindowMinimizeButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the tool window minimize button disabled style LTR.
    /// </summary>
    /// <value>The tool window minimize button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonDisabledStyleLTR), this.ToolWindowMinimizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the tool window minimize button disabled style RTL.
    /// </summary>
    /// <value>The tool window minimize button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMinimizeButtonDisabledStyleRTL), this.ToolWindowMinimizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets or sets the size of the tool window minimize button.
    /// </summary>
    /// <value>The size of the tool window minimize button.</value>
    [Category("Sizes")]
    [Description("The size of the tool window minimize button.")]
    public virtual Size ToolWindowMinimizeButtonSize
    {
      get => this.GetValue<Size>(nameof (ToolWindowMinimizeButtonSize), this.GetImageSize(this.ToolWindowMinimizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (ToolWindowMinimizeButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetToolWindowMinimizeButtonSize() => this.Reset("ToolWindowMinimizeButtonSize");

    /// <summary>Gets the width of the tool window minimize button.</summary>
    /// <value>The width of the tool window minimize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowMinimizeButtonWidth => this.ToolWindowMinimizeButtonSize.Width;

    /// <summary>Gets the height of the tool window minimize button.</summary>
    /// <value>The height of the tool window minimize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowMinimizeButtonHeight => this.ToolWindowMinimizeButtonSize.Height;

    /// <summary>Gets the tool window maximize button normal style.</summary>
    /// <value>The tool window maximize button normal style.</value>
    [Category("States")]
    [Description("The tool window maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMaximizeButtonNormalStyleLTR, this.ToolWindowMaximizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets the tool window maximize button normal style LTR.
    /// </summary>
    /// <value>The tool window maximize button normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMaximizeButtonNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonNormalStyleLTR));

    /// <summary>
    /// Gets the tool window maximize button normal style RTL.
    /// </summary>
    /// <value>The tool window maximize button normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMaximizeButtonNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonNormalStyleRTL));

    /// <summary>Gets the tool window maximize button hover style.</summary>
    /// <value>The tool window maximize button hover style.</value>
    [Category("States")]
    [Description("The tool window hover maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMaximizeButtonHoverStyleLTR, this.ToolWindowMaximizeButtonHoverStyleRTL);

    /// <summary>Gets the tool window maximize button hover style LTR.</summary>
    /// <value>The tool window maximize button hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMaximizeButtonHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonHoverStyleLTR), this.ToolWindowMaximizeButtonNormalStyleLTR);

    /// <summary>Gets the tool window maximize button hover style RTL.</summary>
    /// <value>The tool window maximize button hover style RTL.</value>
    public virtual StyleValue ToolWindowMaximizeButtonHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonHoverStyleRTL), this.ToolWindowMaximizeButtonNormalStyleRTL);

    /// <summary>Gets the tool window maximize button disabled style.</summary>
    /// <value>The tool window maximize button disabled style.</value>
    [Category("States")]
    [Description("The tool window disabled maximize button style.")]
    public virtual BidirectionalSkinValue<StyleValue> ToolWindowMaximizeButtonDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ToolWindowMaximizeButtonDisabledStyleLTR, this.ToolWindowMaximizeButtonDisabledStyleRTL);

    /// <summary>
    /// Gets the tool window maximize button disabled style LTR.
    /// </summary>
    /// <value>The tool window maximize button disabled style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonDisabledStyleLTR), this.ToolWindowMaximizeButtonNormalStyleLTR);

    /// <summary>
    /// Gets the tool window maximize button disabled style RTL.
    /// </summary>
    /// <value>The tool window maximize button disabled style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (ToolWindowMaximizeButtonDisabledStyleRTL), this.ToolWindowMaximizeButtonNormalStyleRTL);

    /// <summary>
    /// Gets or sets the size of the tool window maximize button.
    /// </summary>
    /// <value>The size of the tool window maximize button.</value>
    [Category("Sizes")]
    [Description("The size of the tool window maximize button.")]
    public virtual Size ToolWindowMaximizeButtonSize
    {
      get => this.GetValue<Size>(nameof (ToolWindowMaximizeButtonSize), this.GetImageSize(this.ToolWindowMaximizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
      set => this.SetValue(nameof (ToolWindowMaximizeButtonSize), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetToolWindowMaximizeButtonSize() => this.Reset("ToolWindowMaximizeButtonSize");

    /// <summary>Gets the width of the tool window maximize button.</summary>
    /// <value>The width of the tool window maximize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowMaximizeButtonWidth => this.ToolWindowMaximizeButtonSize.Width;

    /// <summary>Gets the height of the tool window maximize button.</summary>
    /// <value>The height of the tool window maximize button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ToolWindowMaximizeButtonHeight => this.ToolWindowMaximizeButtonSize.Height;

    /// <summary>Gets the center normal active tool style.</summary>
    /// <value>The center normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterActiveToolWindowStyle => new StyleValue((CommonSkin) this, nameof (CenterActiveToolWindowStyle));

    /// <summary>Gets the left normal active tool style.</summary>
    /// <value>The left normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftActiveToolWindowStyle));

    /// <summary>Gets the top normal active tool style.</summary>
    /// <value>The top normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopActiveToolWindowStyle));

    /// <summary>Gets the bottom normal active tool style.</summary>
    /// <value>The bottom normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomActiveToolWindowStyle));

    /// <summary>Gets the right normal active tool style.</summary>
    /// <value>The right normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightActiveToolWindowStyle));

    /// <summary>Gets the right top normal active tool style.</summary>
    /// <value>The right top normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopActiveToolWindowStyle));

    /// <summary>Gets the left top normal active tool style.</summary>
    /// <value>The left top normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopActiveToolWindowStyle));

    /// <summary>Gets the left bottom normal active tool style.</summary>
    /// <value>The left bottom normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomActiveToolWindowStyle));

    /// <summary>Gets the right bottom normal active tool style.</summary>
    /// <value>The right bottom normal active tool style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomActiveToolWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomActiveToolWindowStyle));

    /// <summary>Gets or sets the width of the popup window offset.</summary>
    /// <value>The width of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset width for the popup window.")]
    public virtual int PopupWindowOffsetWidth
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetWidth), this.DefaultPopupWindowOffsetWidth);
      set => this.SetValue(nameof (PopupWindowOffsetWidth), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetPopupWindowOffsetWidth() => this.Reset("PopupWindowOffsetWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultPopupWindowOffsetWidth => this.RightPopupWindowFrameWidth + this.LeftPopupWindowFrameWidth;

    /// <summary>Gets or sets the height of the popup window offset.</summary>
    /// <value>The height of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset height for the popup window.")]
    public virtual int PopupWindowOffsetHeight
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetHeight), this.DefaultPopupWindowOffsetHeight);
      set => this.SetValue(nameof (PopupWindowOffsetHeight), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetPopupWindowOffsetHeight() => this.Reset("PopupWindowOffsetHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultPopupWindowOffsetHeight => this.TopPopupWindowFrameHeight + this.BottomPopupWindowFrameHeight;

    /// <summary>
    /// Gets or sets the width of the left popup window frame.
    /// </summary>
    /// <value>The width of the left popup window frame.</value>
    [Category("Sizes")]
    [Description("The width of the left popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int LeftPopupWindowFrameWidth => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Resets the width of the left popup window frame.</summary>
    internal void ResetLeftPopupWindowFrameWidth() => this.Reset("LeftPopupWindowFrameWidth");

    /// <summary>
    /// Gets or sets the width of the right popup window frame.
    /// </summary>
    /// <value>The width of the right popup window frame.</value>
    [Category("Sizes")]
    [Description("The width of the right popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightPopupWindowFrameWidth => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Resets the width of the right popup window frame.</summary>
    internal void ResetRightPopupWindowFrameWidth() => this.Reset("RightPopupWindowFrameWidth");

    /// <summary>
    /// Gets or sets the height of the top popup window frame.
    /// </summary>
    /// <value>The height of the top popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the top popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int TopPopupWindowFrameHeight => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Resets the height of the top popup window frame.</summary>
    internal void ResetTopPopupWindowFrameHeight() => this.Reset("TopPopupWindowFrameHeight");

    /// <summary>
    /// Gets or sets the height of the bottom popup window frame.
    /// </summary>
    /// <value>The height of the bottom popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int BottomPopupWindowFrameHeight => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Resets the height of the bottom popup window frame.</summary>
    internal void ResetBottomPopupWindowFrameHeight() => this.Reset("BottomPopupWindowFrameHeight");

    /// <summary>Gets the opup window style.</summary>
    /// <value>The opup window style.</value>
    [Category("States")]
    [Description("The popup window style.")]
    public virtual FrameStyleValue PopupWindowStyle => new FrameStyleValue(this.LeftBottomPopupWindowStyle, this.LeftPopupWindowStyle, this.LeftTopPopupWindowStyle, this.TopPopupWindowStyle, this.RightTopPopupWindowStyle, this.RightPopupWindowStyle, this.RightBottomPopupWindowStyle, this.BottomPopupWindowStyle, this.CenterPopupWindowStyle);

    /// <summary>Gets the center popup window style.</summary>
    /// <value>The center popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterPopupWindowStyle => new StyleValue((CommonSkin) this, nameof (CenterPopupWindowStyle), this.PopupSkin.CenterStyle, true);

    /// <summary>Gets the left popup window style.</summary>
    /// <value>The left popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftPopupWindowStyle), this.PopupSkin.LeftStyle, true);

    /// <summary>Gets the top popup window style.</summary>
    /// <value>The top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopPopupWindowStyle), this.PopupSkin.TopStyle, true);

    /// <summary>Gets the bottom popup window style.</summary>
    /// <value>The bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomPopupWindowStyle), this.PopupSkin.BottomStyle, true);

    /// <summary>Gets the right popup window style.</summary>
    /// <value>The right popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightPopupWindowStyle), this.PopupSkin.RightStyle, true);

    /// <summary>Gets the right top popup window style.</summary>
    /// <value>The right top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopPopupWindowStyle), this.PopupSkin.RightTopStyle, true);

    /// <summary>Gets the left top popup window style.</summary>
    /// <value>The left top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopPopupWindowStyle), this.PopupSkin.LeftTopStyle, true);

    /// <summary>Gets the left bottom popup window style.</summary>
    /// <value>The left bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomPopupWindowStyle), this.PopupSkin.LeftBottomStyle, true);

    /// <summary>Gets the right bottom popup window style.</summary>
    /// <value>The right bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomPopupWindowStyle), this.PopupSkin.RightBottomStyle, true);

    /// <summary>Gets the popups skin.</summary>
    /// <value>The popups skin.</value>
    private PopupsSkin PopupSkin => SkinFactory.GetSkin(this.Owner, typeof (PopupsSkin), true) as PopupsSkin;

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    /// <remarks>Provides the default background color for design time.</remarks>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Color BackColor
    {
      get => this.DialogBackColor;
      set
      {
      }
    }

    /// <summary>Gets the width of the minimized MDI form.</summary>
    /// <value>The width of the minimized MDI form.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int MinimizedMdiFormWidth => this.MinimizedMdiFormSize.Width;

    /// <summary>Gets the height of the minimized MDI form.</summary>
    /// <value>The height of the minimized MDI form.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int MinimizedMdiFormHeight => this.MinimizedMdiFormSize.Height;

    /// <summary>Resets the height value</summary>
    internal new void ResetBackColor() => this.Reset("BackColor");

    /// <summary>Gets or sets the size of the minimized MDI form.</summary>
    /// <value>The size of the minimized MDI form.</value>
    [Category("Sizes")]
    [Description("Gets or sets the size of a minimized MDI form.")]
    public Size MinimizedMdiFormSize
    {
      get => this.GetValue<Size>(nameof (MinimizedMdiFormSize), this.DefaultMinimizedMdiFormSize);
      set => this.SetValue(nameof (MinimizedMdiFormSize), (object) value);
    }

    /// <summary>Gets or sets the dialog background color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Description("Gets or sets the dialog background color.")]
    public virtual Color DialogBackColor
    {
      get => this.GetValue<Color>(nameof (DialogBackColor), Color.FromArgb(240, 240, 240));
      set => this.SetValue(nameof (DialogBackColor), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetDialogBackColor() => this.Reset("DialogBackColor");

    /// <summary>Gets the dialog background.</summary>
    /// <value>The dialog background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue DialogBackground => new BackgroundValue()
    {
      BackColor = this.DialogBackColor
    };

    /// <summary>Gets or sets the window background color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Description("Gets or sets the window background color.")]
    public virtual Color WindowBackColor
    {
      get => this.GetValue<Color>(nameof (WindowBackColor), Color.Empty);
      set => this.SetValue(nameof (WindowBackColor), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetWindowBackColor() => this.Reset("WindowBackColor");

    /// <summary>Gets the window background.</summary>
    /// <value>The window background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue WindowBackground => new BackgroundValue()
    {
      BackColor = this.WindowBackColor
    };

    /// <summary>Gets or sets the popup background color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Description("Gets or sets the popup background color.")]
    public virtual Color PopupBackColor
    {
      get => this.GetValue<Color>(nameof (PopupBackColor), Color.FromArgb(240, 240, 240));
      set => this.SetValue(nameof (PopupBackColor), (object) value);
    }

    /// <summary>Resets the height value</summary>
    internal void ResetPopupBackColor() => this.Reset("PopupBackColor");

    /// <summary>Gets the popup background.</summary>
    /// <value>The popup background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue PopupBackground => new BackgroundValue()
    {
      BackColor = this.PopupBackColor
    };

    /// <summary>Gets the boxes bar footer style.</summary>
    /// <value>The boxes bar footer style.</value>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("States")]
    [Description("Gets or sets the style of the boxes bar footer.")]
    public virtual StyleValue BoxesBarFooterStyle => new StyleValue((CommonSkin) this, nameof (BoxesBarFooterStyle));

    /// <summary>Gets or sets the height of the boxes bar footer.</summary>
    /// <value>The height of the boxes bar footer.</value>
    [Category("Sizes")]
    [Description("Gets or sets the height of the boxes bar footer.")]
    public virtual int BoxesBarFooterHeight
    {
      get => this.GetValue<int>(nameof (BoxesBarFooterHeight), 4);
      set => this.SetValue(nameof (BoxesBarFooterHeight), (object) value);
    }
  }
}
