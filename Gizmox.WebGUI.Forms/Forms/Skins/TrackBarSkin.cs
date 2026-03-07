// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TrackBarSkin
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
  [ToolboxBitmap(typeof (TrackBar), "TrackBar.bmp")]
  [Serializable]
  public class TrackBarSkin : ControlSkin
  {
    /// <summary>Gets the horizontal tail both style.</summary>
    /// <value>The horizontal tail both style.</value>
    public StyleValue HorizontalTailBothStyle => new StyleValue((CommonSkin) this, nameof (HorizontalTailBothStyle));

    /// <summary>Gets the horizontal tail top style.</summary>
    /// <value>The horizontal tail top style.</value>
    public StyleValue HorizontalTailTopStyle => new StyleValue((CommonSkin) this, nameof (HorizontalTailTopStyle));

    /// <summary>Gets the horizontal tail bottom style.</summary>
    /// <value>The horizontal tail bottom style.</value>
    public StyleValue HorizontalTailBottomStyle => new StyleValue((CommonSkin) this, nameof (HorizontalTailBottomStyle));

    /// <summary>Gets the horizontal tail none style.</summary>
    /// <value>The horizontal tail none style.</value>
    public StyleValue HorizontalTailNoneStyle => new StyleValue((CommonSkin) this, nameof (HorizontalTailNoneStyle));

    /// <summary>Gets the vertical tail both style.</summary>
    /// <value>The vertical tail both style.</value>
    public StyleValue VerticalTailBothStyle => new StyleValue((CommonSkin) this, nameof (VerticalTailBothStyle));

    /// <summary>Gets the vertical tail top style.</summary>
    /// <value>The vertical tail top style.</value>
    public StyleValue VerticalTailTopStyle => new StyleValue((CommonSkin) this, nameof (VerticalTailTopStyle));

    /// <summary>Gets the vertical tail bottom style.</summary>
    /// <value>The vertical tail bottom style.</value>
    public StyleValue VerticalTailBottomStyle => new StyleValue((CommonSkin) this, nameof (VerticalTailBottomStyle));

    /// <summary>Gets the vertical tail none style.</summary>
    /// <value>The vertical tail none style.</value>
    public StyleValue VerticalTailNoneStyle => new StyleValue((CommonSkin) this, nameof (VerticalTailNoneStyle));

    /// <summary>Gets or sets the slider top image.</summary>
    /// <value>The slider top image.</value>
    [Description("Slider top image")]
    [Category("Images")]
    public ImageResourceReference SliderTop
    {
      get => this.GetValue<ImageResourceReference>("SliderTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarDU.gif"));
      set => this.SetValue("SliderTopImage", (object) value);
    }

    /// <summary>Resets the slider top image.</summary>
    private void ResetSliderTop() => this.Reset("SliderTopImage");

    /// <summary>Gets or sets the slider bottom image.</summary>
    /// <value>The slider bottom image.</value>
    [Description("Slider bottom image")]
    [Category("Images")]
    public ImageResourceReference SliderBottom
    {
      get => this.GetValue<ImageResourceReference>("SliderBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarUD.gif"));
      set => this.SetValue("SliderBottomImage", (object) value);
    }

    /// <summary>Resets the slider bottom image.</summary>
    private void ResetSliderBottom() => this.Reset("SliderBottomImage");

    /// <summary>Gets or sets the slider horizontal both image.</summary>
    /// <value>The slider horizontal both image.</value>
    [Description("Slider horizontal both image")]
    [Category("Images")]
    public ImageResourceReference SliderHorizontalBoth
    {
      get => this.GetValue<ImageResourceReference>("SliderHorizontalBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarVERT.gif"));
      set => this.SetValue("SliderHorizontalBothImage", (object) value);
    }

    /// <summary>Resets the slider horizontal both image.</summary>
    private void ResetSliderHorizontalBoth() => this.Reset("SliderHorizontalBothImage");

    /// <summary>Gets or sets the slider left image.</summary>
    /// <value>The slider left image.</value>
    [Description("Slider left image")]
    [Category("Images")]
    public ImageResourceReference SliderLeft
    {
      get => this.GetValue<ImageResourceReference>("SliderLeftImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarRL.gif"));
      set => this.SetValue("SliderLeftImage", (object) value);
    }

    /// <summary>Resets the slider left image.</summary>
    private void ResetSliderLeft() => this.Reset("SliderLeftImage");

    /// <summary>Gets or sets the slider right image.</summary>
    /// <value>The slider right image.</value>
    [Description("Slider right image")]
    [Category("Images")]
    public ImageResourceReference SliderRight
    {
      get => this.GetValue<ImageResourceReference>("SliderRightImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarLR.gif"));
      set => this.SetValue("SliderRightImage", (object) value);
    }

    /// <summary>Resets the slider right image.</summary>
    private void ResetSliderRight() => this.Reset("SliderRightImage");

    /// <summary>Gets or sets the slider vertical both image.</summary>
    /// <value>The slider vertical both image.</value>
    [Description("Slider vertical both image")]
    [Category("Images")]
    public ImageResourceReference SliderVerticalBoth
    {
      get => this.GetValue<ImageResourceReference>("SliderVerticalBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarHORZ.gif"));
      set => this.SetValue("SliderVerticalBothImage", (object) value);
    }

    /// <summary>Resets the slider vertical both image.</summary>
    private void ResetSliderVerticalBoth() => this.Reset("SliderVerticalBothImage");

    /// <summary>Gets or sets the horizontal start tick top image.</summary>
    /// <value>The horizontal start tick top image.</value>
    [Description("Horizontal start tick top image")]
    [Category("Images")]
    public ImageResourceReference HorizontalStartTickTop
    {
      get => this.GetValue<ImageResourceReference>("HorizontalStartTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarDUTickL.gif"));
      set => this.SetValue("HorizontalStartTickTopImage", (object) value);
    }

    /// <summary>Resets the horizontal start tick top image.</summary>
    private void ResetHorizontalStartTickTop() => this.Reset("HorizontalStartTickTopImage");

    /// <summary>Gets or sets the horizontal start tick bottom image.</summary>
    /// <value>The horizontal start tick bottom image.</value>
    [Description("Horizontal start tick bottom image")]
    [Category("Images")]
    public ImageResourceReference HorizontalStartTickBottom
    {
      get => this.GetValue<ImageResourceReference>("HorizontalStartTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarUDTickL.gif"));
      set => this.SetValue("HorizontalStartTickBottomImage", (object) value);
    }

    /// <summary>Resets the horizontal start tick bottom image.</summary>
    private void ResetHorizontalStartTickBottom() => this.Reset("HorizontalStartTickBottomImage");

    /// <summary>Gets or sets the horizontal start tick both image.</summary>
    /// <value>The horizontal start tick both image.</value>
    [Description("Horizontal start tick both image")]
    [Category("Images")]
    public ImageResourceReference HorizontalStartTickBoth
    {
      get => this.GetValue<ImageResourceReference>("HorizontalStartTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarVERTTickL.gif"));
      set => this.SetValue("HorizontalStartTickBothImage", (object) value);
    }

    /// <summary>Resets the horizontal start tick both image.</summary>
    private void ResetHorizontalStartTickBoth() => this.Reset("HorizontalStartTickBothImage");

    /// <summary>Gets or sets the horizontal start tick none image.</summary>
    /// <value>The horizontal start tick none image.</value>
    [Description("Horizontal start tick none image")]
    [Category("Images")]
    public ImageResourceReference HorizontalStartTickNone
    {
      get => this.GetValue<ImageResourceReference>("HorizontalStartTickNoneImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarNOTickL.gif"));
      set => this.SetValue("HorizontalStartTickNoneImage", (object) value);
    }

    /// <summary>Resets the horizontal start tick None image.</summary>
    private void ResetHorizontalStartTickNone() => this.Reset("HorizontalStartTickNoneImage");

    /// <summary>Gets or sets the horizontal end tick top image.</summary>
    /// <value>The horizontal end tick top image.</value>
    [Description("Horizontal end tick top image")]
    [Category("Images")]
    public ImageResourceReference HorizontalEndTickTop
    {
      get => this.GetValue<ImageResourceReference>("HorizontalEndTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarDUTickR.gif"));
      set => this.SetValue("HorizontalEndTickTopImage", (object) value);
    }

    /// <summary>Resets the horizontal end tick top image.</summary>
    private void ResetHorizontalEndTickTop() => this.Reset("HorizontalEndTickTopImage");

    /// <summary>Gets or sets the horizontal end tick bottom image.</summary>
    /// <value>The horizontal end tick bottom image.</value>
    [Description("Horizontal end tick bottom image")]
    [Category("Images")]
    public ImageResourceReference HorizontalEndTickBottom
    {
      get => this.GetValue<ImageResourceReference>("HorizontalEndTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarUDTickR.gif"));
      set => this.SetValue("HorizontalEndTickBottomImage", (object) value);
    }

    /// <summary>Resets the horizontal end tick bottom image.</summary>
    private void ResetHorizontalEndTickBottom() => this.Reset("HorizontalEndTickBottomImage");

    /// <summary>Gets or sets the horizontal end tick both image.</summary>
    /// <value>The horizontal end tick both image.</value>
    [Description("Horizontal end tick both image")]
    [Category("Images")]
    public ImageResourceReference HorizontalEndTickBoth
    {
      get => this.GetValue<ImageResourceReference>("HorizontalEndTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarVERTTickR.gif"));
      set => this.SetValue("HorizontalEndTickBothImage", (object) value);
    }

    /// <summary>Resets the horizontal end tick both image.</summary>
    private void ResetHorizontalEndTickBoth() => this.Reset("HorizontalEndTickBothImage");

    /// <summary>Gets or sets the horizontal end tick none image.</summary>
    /// <value>The horizontal end tick none image.</value>
    [Description("Horizontal end tick none image")]
    [Category("Images")]
    public ImageResourceReference HorizontalEndTickNone
    {
      get => this.GetValue<ImageResourceReference>("HorizontalEndTickNoneImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarNOTickR.gif"));
      set => this.SetValue("HorizontalEndTickNoneImage", (object) value);
    }

    /// <summary>Resets the horizontal end tick none image.</summary>
    private void ResetHorizontalEndTickNone() => this.Reset("HorizontalEndTickNoneImage");

    /// <summary>Gets or sets the horizontal middle tick top image.</summary>
    /// <value>The horizontal middle tick top image.</value>
    [Description("Horizontal middle tick top image")]
    [Category("Images")]
    public ImageResourceReference HorizontalMiddleTickTop
    {
      get => this.GetValue<ImageResourceReference>("HorizontalMiddleTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarDUTickM.gif"));
      set => this.SetValue("HorizontalMiddleTickTopImage", (object) value);
    }

    /// <summary>Resets the horizontal middle tick top image.</summary>
    private void ResetHorizontalMiddleTickTop() => this.Reset("HorizontalMiddleTickTopImage");

    /// <summary>Gets or sets the horizontal middle tick bottom image.</summary>
    /// <value>The horizontal middle tick bottom image.</value>
    [Description("Horizontal middle tick bottom image")]
    [Category("Images")]
    public ImageResourceReference HorizontalMiddleTickBottom
    {
      get => this.GetValue<ImageResourceReference>("HorizontalMiddleTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarUDTickM.gif"));
      set => this.SetValue("HorizontalMiddleTickBottomImage", (object) value);
    }

    /// <summary>Resets the horizontal middle tick bottom image.</summary>
    private void ResetHorizontalMiddleTickBottom() => this.Reset("HorizontalMiddleTickBottomImage");

    /// <summary>Gets or sets the horizontal middle tick both image.</summary>
    /// <value>The horizontal middle tick both image.</value>
    [Description("Horizontal middle tick both image")]
    [Category("Images")]
    public ImageResourceReference HorizontalMiddleTickBoth
    {
      get => this.GetValue<ImageResourceReference>("HorizontalMiddleTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarVERTTickM.gif"));
      set => this.SetValue("HorizontalMiddleTickBothImage", (object) value);
    }

    /// <summary>Resets the horizontal middle tick both image.</summary>
    private void ResetHorizontalMiddleTickBoth() => this.Reset("HorizontalMiddleTickBothImage");

    /// <summary>Gets or sets the horizontal space tick top image.</summary>
    /// <value>The horizontal space tick top image.</value>
    [Description("Horizontal space tick top image")]
    [Category("Images")]
    public ImageResourceReference HorizontalSpaceTickTop
    {
      get => this.GetValue<ImageResourceReference>("HorizontalSpaceTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarDUSpace.gif"));
      set => this.SetValue("HorizontalSpaceTickTopImage", (object) value);
    }

    /// <summary>Resets the horizontal space tick top image.</summary>
    private void ResetHorizontalSpaceTickTop() => this.Reset("HorizontalSpaceTickTopImage");

    /// <summary>Gets or sets the horizontal space tick bottom image.</summary>
    /// <value>The horizontal space tick bottom image.</value>
    [Description("Horizontal space tick bottom image")]
    [Category("Images")]
    public ImageResourceReference HorizontalSpaceTickBottom
    {
      get => this.GetValue<ImageResourceReference>("HorizontalSpaceTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarUDSpace.gif"));
      set => this.SetValue("HorizontalSpaceTickBottomImage", (object) value);
    }

    /// <summary>Resets the horizontal space tick bottom image.</summary>
    private void ResetHorizontalSpaceTickBottom() => this.Reset("HorizontalSpaceTickBottomImage");

    /// <summary>Gets or sets the horizontal space tick both image.</summary>
    /// <value>The horizontal space tick both image.</value>
    [Description("Horizontal space tick both image")]
    [Category("Images")]
    public ImageResourceReference HorizontalSpaceTickBoth
    {
      get => this.GetValue<ImageResourceReference>("HorizontalSpaceTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarVERTSpace.gif"));
      set => this.SetValue("HorizontalSpaceTickBothImage", (object) value);
    }

    /// <summary>Resets the horizontal space tick both image.</summary>
    private void ResetHorizontalSpaceTickBoth() => this.Reset("HorizontalSpaceTickBothImage");

    /// <summary>Gets or sets the vertical start tick top image.</summary>
    /// <value>The vertical start tick top image.</value>
    [Description("Vertical start tick top image")]
    [Category("Images")]
    public ImageResourceReference VerticalStartTickTop
    {
      get => this.GetValue<ImageResourceReference>("VerticalStartTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarRLTickU.gif"));
      set => this.SetValue("VerticalStartTickTopImage", (object) value);
    }

    /// <summary>Resets the vertical start tick top image.</summary>
    private void ResetVerticalStartTickTop() => this.Reset("VerticalStartTickTopImage");

    /// <summary>Gets or sets the vertical start tick bottom image.</summary>
    /// <value>The vertical start tick bottom image.</value>
    [Description("Vertical start tick bottom image")]
    [Category("Images")]
    public ImageResourceReference VerticalStartTickBottom
    {
      get => this.GetValue<ImageResourceReference>("VerticalStartTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarLRTickU.gif"));
      set => this.SetValue("VerticalStartTickBottomImage", (object) value);
    }

    /// <summary>Resets the vertical start tick bottom image.</summary>
    private void ResetVerticalStartTickBottom() => this.Reset("VerticalStartTickBottomImage");

    /// <summary>Gets or sets the vertical start tick both image.</summary>
    /// <value>The vertical start tick both image.</value>
    [Description("Vertical start tick both image")]
    [Category("Images")]
    public ImageResourceReference VerticalStartTickBoth
    {
      get => this.GetValue<ImageResourceReference>("VerticalStartTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarHORZTickU.gif"));
      set => this.SetValue("VerticalStartTickBothImage", (object) value);
    }

    /// <summary>Resets the vertical start tick both image.</summary>
    private void ResetVerticalStartTickBoth() => this.Reset("VerticalStartTickBothImage");

    /// <summary>Gets or sets the vertical start tick none image.</summary>
    /// <value>The vertical start tick none image.</value>
    [Description("Vertical start tick none image")]
    [Category("Images")]
    public ImageResourceReference VerticalStartTickNone
    {
      get => this.GetValue<ImageResourceReference>("VerticalStartTickNoneImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarNOTickU.gif"));
      set => this.SetValue("VerticalStartTickNoneImage", (object) value);
    }

    /// <summary>Resets the vertical start tick none image.</summary>
    private void ResetVerticalStartTickNone() => this.Reset("VerticalStartTickNoneImage");

    /// <summary>Gets or sets the vertical end tick top image.</summary>
    /// <value>The vertical end tick top image.</value>
    [Description("Vertical end tick top image")]
    [Category("Images")]
    public ImageResourceReference VerticalEndTickTop
    {
      get => this.GetValue<ImageResourceReference>("VerticalEndTickTopImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarRLTickD.gif"));
      set => this.SetValue("VerticalEndTickTopImage", (object) value);
    }

    /// <summary>Resets the vertical end tick top image.</summary>
    private void ResetVerticalEndTickTop() => this.Reset("VerticalEndTickTopImage");

    /// <summary>Gets or sets the vertical end tick bottom image.</summary>
    /// <value>The vertical end tick bottom image.</value>
    [Description("Vertical end tick bottom image")]
    [Category("Images")]
    public ImageResourceReference VerticalEndTickBottom
    {
      get => this.GetValue<ImageResourceReference>("VerticalEndTickBottomImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarLRTickD.gif"));
      set => this.SetValue("VerticalEndTickBottomImage", (object) value);
    }

    /// <summary>Resets the vertical end tick bottom image.</summary>
    private void ResetVerticalEndTickBottom() => this.Reset("VerticalEndTickBottomImage");

    /// <summary>Gets or sets the vertical end tick both image.</summary>
    /// <value>The vertical end tick both image.</value>
    [Description("Vertical end tick both image")]
    [Category("Images")]
    public ImageResourceReference VerticalEndTickBoth
    {
      get => this.GetValue<ImageResourceReference>("VerticalEndTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarHORZTickD.gif"));
      set => this.SetValue("VerticalEndTickBothImage", (object) value);
    }

    /// <summary>Resets the vertical end tick both image.</summary>
    private void ResetVerticalEndTickBoth() => this.Reset("VerticalEndTickBothImage");

    /// <summary>Gets or sets the vertical end tick none image.</summary>
    /// <value>The vertical end tick none image.</value>
    [Description("Vertical end tick none image")]
    [Category("Images")]
    public ImageResourceReference VerticalEndTickNone
    {
      get => this.GetValue<ImageResourceReference>("VerticalEndTickNoneImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarNOTickD.gif"));
      set => this.SetValue("VerticalEndTickNoneImage", (object) value);
    }

    /// <summary>Resets the vertical end tick none image.</summary>
    private void ResetVerticalEndTickNone() => this.Reset("VerticalEndTickNoneImage");

    /// <summary>Gets or sets the vertical middle tick right image.</summary>
    /// <value>The vertical middle tick right image.</value>
    [Description("Vertical middle tick right image")]
    [Category("Images")]
    public ImageResourceReference VerticalMiddleTickRight
    {
      get => this.GetValue<ImageResourceReference>("VerticalMiddleTickRightImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarLRTickM.gif"));
      set => this.SetValue("VerticalMiddleTickRightImage", (object) value);
    }

    /// <summary>Resets the vertical middle tick right image.</summary>
    private void ResetVerticalMiddleTickRight() => this.Reset("VerticalMiddleTickRightImage");

    /// <summary>Gets or sets the vertical middle tick left image.</summary>
    /// <value>The vertical middle tick left image.</value>
    [Description("Vertical middle tick left image")]
    [Category("Images")]
    public ImageResourceReference VerticalMiddleTickLeft
    {
      get => this.GetValue<ImageResourceReference>("VerticalMiddleTickLeftImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarRLTickM.gif"));
      set => this.SetValue("VerticalMiddleTickLeftImage", (object) value);
    }

    /// <summary>Resets the vertical middle tick left image.</summary>
    private void ResetVerticalMiddleTickLeft() => this.Reset("VerticalMiddleTickLeftImage");

    /// <summary>Gets or sets the vertical middle tick both image.</summary>
    /// <value>The vertical middle tick both image.</value>
    [Description("Vertical middle tick both image")]
    [Category("Images")]
    public ImageResourceReference VerticalMiddleTickBoth
    {
      get => this.GetValue<ImageResourceReference>("VerticalMiddleTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarHORZTickM.gif"));
      set => this.SetValue("VerticalMiddleTickBothImage", (object) value);
    }

    /// <summary>Resets the vertical middle tick both image.</summary>
    private void ResetVerticalMiddleTickBoth() => this.Reset("VerticalMiddleTickBothImage");

    /// <summary>Gets or sets the vertical space tick left image.</summary>
    /// <value>The vertical space tick left image.</value>
    [Description("Vertical space tick left image")]
    [Category("Images")]
    public ImageResourceReference VerticalSpaceTickLeft
    {
      get => this.GetValue<ImageResourceReference>("VerticalSpaceTickLeftImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarRLSpace.gif"));
      set => this.SetValue("VerticalSpaceTickLeftImage", (object) value);
    }

    /// <summary>Resets the vertical space tick left image.</summary>
    private void ResetVerticalSpaceTickLeft() => this.Reset("VerticalSpaceTickLeftImage");

    /// <summary>Gets or sets the vertical space tick right image.</summary>
    /// <value>The vertical space tick right image.</value>
    [Description("Vertical space tick right image")]
    [Category("Images")]
    public ImageResourceReference VerticalSpaceTickRight
    {
      get => this.GetValue<ImageResourceReference>("VerticalSpaceTickRightImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarLRSpace.gif"));
      set => this.SetValue("VerticalSpaceTickRightImage", (object) value);
    }

    /// <summary>Resets the vertical space tick right image.</summary>
    private void ResetVerticalSpaceTickRight() => this.Reset("VerticalSpaceTickRightImage");

    /// <summary>Gets or sets the vertical space tick both image.</summary>
    /// <value>The vertical space tick both image.</value>
    [Description("Vertical space tick both image")]
    [Category("Images")]
    public ImageResourceReference VerticalSpaceTickBoth
    {
      get => this.GetValue<ImageResourceReference>("VerticalSpaceTickBothImage", new ImageResourceReference(typeof (TrackBarSkin), "TrackBarHORZSpace.gif"));
      set => this.SetValue("VerticalSpaceTickBothImage", (object) value);
    }

    /// <summary>Resets the vertical space tick both image.</summary>
    private void ResetVerticalSpaceTickBoth() => this.Reset("VerticalSpaceTickBothImage");

    /// <summary>
    /// Gets or sets the width of the horizontal end tick top image.
    /// </summary>
    /// <value>The width of the horizontal end tick top image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalEndTickTopWidth => this.GetValue<int>("HorizontalEndTickTopImageWidth", this.GetImageWidth(this.HorizontalEndTickTop, this.DefaultHorizontalEndTickTopImageWidth));

    /// <summary>
    /// Gets the default width of the horizontal end tick top image.
    /// </summary>
    /// <value>The default width of the horizontal end tick top image.</value>
    protected virtual int DefaultHorizontalEndTickTopImageWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal end tick bottom image.
    /// </summary>
    /// <value>The width of the horizontal end tick bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalEndTickBottomWidth => this.GetValue<int>("HorizontalEndTickBottomImageWidth", this.GetImageWidth(this.HorizontalEndTickBottom, this.DefaultHorizontalEndTickBottomWidth));

    /// <summary>
    /// Gets the default width of the horizontal end tick bottom image.
    /// </summary>
    /// <value>The default width of the horizontal end tick bottom image.</value>
    protected virtual int DefaultHorizontalEndTickBottomWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal end tick both image.
    /// </summary>
    /// <value>The width of the horizontal end tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalEndTickBothWidth => this.GetValue<int>("HorizontalEndTickBothImageWidth", this.GetImageWidth(this.HorizontalEndTickBoth, this.DefaultHorizontalEndTickBothWidth));

    /// <summary>
    /// Gets the default width of the horizontal end tick both image.
    /// </summary>
    /// <value>The default width of the horizontal end tick both image.</value>
    protected virtual int DefaultHorizontalEndTickBothWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal end tick none image.
    /// </summary>
    /// <value>The width of the horizontal end tick none image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalEndTickNoneWidth => this.GetValue<int>("HorizontalEndTickNoneImageWidth", this.GetImageWidth(this.HorizontalEndTickNone, this.DefaultHorizontalEndTickNoneWidth));

    /// <summary>
    /// Gets the default width of the horizontal end tick none image.
    /// </summary>
    /// <value>The default width of the horizontal end tick none image.</value>
    protected virtual int DefaultHorizontalEndTickNoneWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal start tick top image.
    /// </summary>
    /// <value>The width of the horizontal start tick top image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalStartTickTopWidth => this.GetValue<int>("HorizontalStartTickTopImageWidth", this.GetImageWidth(this.HorizontalStartTickTop, this.DefaultHorizontalStartTickTopWidth));

    /// <summary>
    /// Gets the default width of the horizontal start tick top image.
    /// </summary>
    /// <value>The default width of the horizontal start tick top image.</value>
    protected virtual int DefaultHorizontalStartTickTopWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal start tick bottom image.
    /// </summary>
    /// <value>The width of the horizontal start tick bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalStartTickBottomWidth => this.GetValue<int>("HorizontalStartTickBottomImageWidth", this.GetImageWidth(this.HorizontalStartTickBottom, this.DefaultHorizontalStartTickBottomWidth));

    /// <summary>
    /// Gets the default width of the horizontal start tick bottom image.
    /// </summary>
    /// <value>The default width of the horizontal start tick bottom image.</value>
    protected virtual int DefaultHorizontalStartTickBottomWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal start tick both image.
    /// </summary>
    /// <value>The width of the horizontal start tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalStartTickBothWidth => this.GetValue<int>("HorizontalStartTickBothImageWidth", this.GetImageWidth(this.HorizontalStartTickBoth, this.DefaultHorizontalStartTickBothWidth));

    /// <summary>
    /// Gets the default width of the horizontal start tick both image.
    /// </summary>
    /// <value>The default width of the horizontal start tick both image.</value>
    protected virtual int DefaultHorizontalStartTickBothWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal start tick none image.
    /// </summary>
    /// <value>The width of the horizontal start tick none image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalStartTickNoneWidth => this.GetValue<int>("HorizontalStartTickNoneImageWidth", this.GetImageWidth(this.HorizontalStartTickNone, this.DefaultHorizontalStartTickNoneWidth));

    /// <summary>
    /// Gets the default width of the horizontal start tick none image.
    /// </summary>
    /// <value>The default width of the horizontal start tick none image.</value>
    protected virtual int DefaultHorizontalStartTickNoneWidth => 6;

    /// <summary>
    /// Gets or sets the width of the horizontal middle tick top image.
    /// </summary>
    /// <value>The width of the horizontal middle tick top image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalMiddleTickTopWidth => this.GetValue<int>("HorizontalMiddleTickTopImageWidth", this.GetImageWidth(this.HorizontalMiddleTickTop, this.DefaultHorizontalMiddleTickTopWidth));

    /// <summary>
    /// Gets the default width of the horizontal middle tick top image.
    /// </summary>
    /// <value>The default width of the horizontal middle tick top image.</value>
    protected virtual int DefaultHorizontalMiddleTickTopWidth => 1;

    /// <summary>
    /// Gets or sets the width of the horizontal middle tick bottom image.
    /// </summary>
    /// <value>The width of the horizontal middle tick bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalMiddleTickBottomWidth => this.GetValue<int>("HorizontalMiddleTickBottomImageWidth", this.GetImageWidth(this.HorizontalMiddleTickBottom, this.DefaultHorizontalMiddleTickBottomWidth));

    /// <summary>
    /// Gets the default width of the horizontal middle tick bottom image.
    /// </summary>
    /// <value>The default width of the horizontal middle tick bottom image.</value>
    protected virtual int DefaultHorizontalMiddleTickBottomWidth => 1;

    /// <summary>
    /// Gets or sets the width of the horizontal middle tick both image.
    /// </summary>
    /// <value>The width of the horizontal middle tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalMiddleTickBothWidth => this.GetValue<int>("HorizontalMiddleTickBothImageWidth", this.GetImageWidth(this.HorizontalMiddleTickBoth, this.DefaultHorizontalMiddleTickBothWidth));

    /// <summary>
    /// Gets the default width of the horizontal middle tick both image.
    /// </summary>
    /// <value>The default width of the horizontal middle tick both image.</value>
    protected virtual int DefaultHorizontalMiddleTickBothWidth => 1;

    /// <summary>Gets the height of the vertical start tick top image.</summary>
    /// <value>The height of the vertical start tick top.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalStartTickTopHeight => this.GetValue<int>("VerticalStartTickTopImageHeight", this.GetImageHeight(this.VerticalStartTickTop, this.DefaultVerticalStartTickTopHeight));

    /// <summary>
    /// Gets the default height of the vertical start tick top image.
    /// </summary>
    /// <value>The default height of the vertical start tick top image.</value>
    protected virtual int DefaultVerticalStartTickTopHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical start tick bottom image.
    /// </summary>
    /// <value>The height of the vertical start tick bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalStartTickBottomHeight => this.GetValue<int>("VerticalStartTickBottomImageHeight", this.GetImageHeight(this.VerticalStartTickBottom, this.DefaultVerticalStartTickBottomHeight));

    /// <summary>
    /// Gets the default height of the vertical start tick bottom image.
    /// </summary>
    /// <value>The default height of the vertical start tick bottom image.</value>
    protected virtual int DefaultVerticalStartTickBottomHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical start tick both image.
    /// </summary>
    /// <value>The height of the vertical start tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalStartTickBothHeight => this.GetValue<int>("VerticalStartTickBothImageHeight", this.GetImageHeight(this.VerticalStartTickBoth, this.DefaultVerticalStartTickBothHeight));

    /// <summary>
    /// Gets the default height of the vertical start tick both image.
    /// </summary>
    /// <value>The default height of the vertical start tick both image.</value>
    protected virtual int DefaultVerticalStartTickBothHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical start tick none image.
    /// </summary>
    /// <value>The height of the vertical start tick none image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalStartTickNoneHeight => this.GetValue<int>("VerticalStartTickNoneImageHeight", this.GetImageHeight(this.VerticalStartTickNone, this.DefaultVerticalStartTickNoneHeight));

    /// <summary>
    /// Gets the default height of the vertical start tick none image.
    /// </summary>
    /// <value>The default height of the vertical start tick bottom image.</value>
    protected virtual int DefaultVerticalStartTickNoneHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical end tick top image.
    /// </summary>
    /// <value>The height of the vertical end tick top image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalEndTickTopHeight => this.GetValue<int>("VerticalEndTickTopImageHeight", this.GetImageHeight(this.VerticalEndTickTop, this.DefaultVerticalEndTickTopHeight));

    /// <summary>
    /// Gets the default height of the vertical end tick top image.
    /// </summary>
    /// <value>The default height of the vertical end tick top image.</value>
    protected virtual int DefaultVerticalEndTickTopHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical end tick bottom image.
    /// </summary>
    /// <value>The height of the vertical end tick bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalEndTickBottomHeight => this.GetValue<int>("VerticalEndTickBottomImageHeight", this.GetImageHeight(this.VerticalEndTickBottom, this.DefaultVerticalEndTickBottomHeight));

    /// <summary>
    /// Gets the default height of the vertical end tick bottom image.
    /// </summary>
    /// <value>The default height of the vertical end tick bottom image.</value>
    protected virtual int DefaultVerticalEndTickBottomHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical end tick both image.
    /// </summary>
    /// <value>The height of the vertical end tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalEndTickBothHeight => this.GetValue<int>("VerticalEndTickBothImageHeight", this.GetImageHeight(this.VerticalEndTickBoth, this.DefaultVerticalEndTickBothHeight));

    /// <summary>
    /// Gets the default height of the vertical end tick both image.
    /// </summary>
    /// <value>The default height of the vertical end tick both image.</value>
    protected virtual int DefaultVerticalEndTickBothHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical end tick none image.
    /// </summary>
    /// <value>The height of the vertical end tick none image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalEndTickNoneHeight => this.GetValue<int>("VerticalEndTickNoneImageHeight", this.GetImageHeight(this.VerticalEndTickNone, this.DefaultVerticalEndTickNoneHeight));

    /// <summary>
    /// Gets the default height of the vertical end tick none image.
    /// </summary>
    /// <value>The default height of the vertical end tick none image.</value>
    protected virtual int DefaultVerticalEndTickNoneHeight => 6;

    /// <summary>
    /// Gets or sets the height of the vertical middle tick left image.
    /// </summary>
    /// <value>The height of the vertical middle tick left image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalMiddleTickLeftHeight => this.GetValue<int>("VerticalMiddleTickLeftImageHeight", this.GetImageHeight(this.VerticalMiddleTickLeft, this.DefaultVerticalMiddleTickLeftHeight));

    /// <summary>
    /// Gets the default height of the vertical middle tick left image.
    /// </summary>
    /// <value>The default height of the vertical middle tick left image.</value>
    protected virtual int DefaultVerticalMiddleTickLeftHeight => 1;

    /// <summary>
    /// Gets the height of the vertical middle tick right image.
    /// </summary>
    /// <value>The height of the vertical middle tick right.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalMiddleTickRightHeight => this.GetValue<int>("VerticalMiddleTickRightImageHeight", this.GetImageHeight(this.VerticalMiddleTickRight, this.DefaultVerticalMiddleTickRightHeight));

    /// <summary>
    /// Gets the default height of the vertical middle tick right image.
    /// </summary>
    /// <value>The default height of the vertical middle tick right image.</value>
    protected virtual int DefaultVerticalMiddleTickRightHeight => 1;

    /// <summary>
    /// Gets or sets the height of the vertical middle tick both image.
    /// </summary>
    /// <value>The height of the vertical middle tick both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalMiddleTickBothHeight => this.GetValue<int>("VerticalMiddleTickBothImageHeight", this.GetImageHeight(this.VerticalMiddleTickBoth, this.DefaultVerticalMiddleTickBothHeight));

    /// <summary>
    /// Gets the default height of the vertical middle tick both image.
    /// </summary>
    /// <value>The default height of the vertical middle tick both image.</value>
    protected virtual int DefaultVerticalMiddleTickBothHeight => 1;

    /// <summary>Gets the width of the slider top image.</summary>
    /// <value>The width of the slider top image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderTopWidth => this.GetValue<int>(nameof (SliderTopWidth), this.GetImageWidth(this.SliderTop, this.DefaultSliderTopWidth));

    /// <summary>Gets the default width of the slider top image.</summary>
    /// <value>The default width of the slider top image.</value>
    protected int DefaultSliderTopWidth => 12;

    /// <summary>Gets the width of the slider bottom image.</summary>
    /// <value>The width of the slider bottom image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderBottomWidth => this.GetValue<int>(nameof (SliderBottomWidth), this.GetImageWidth(this.SliderBottom, this.DefaultSliderBottomWidth));

    /// <summary>Gets the default width of the slider bottom image.</summary>
    /// <value>The default width of the slider bottom image.</value>
    protected int DefaultSliderBottomWidth => 12;

    /// <summary>Gets the width of the slider horizontal both image.</summary>
    /// <value>The width of the slider horizontal both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderHorizontalBothWidth => this.GetValue<int>(nameof (SliderHorizontalBothWidth), this.GetImageWidth(this.SliderHorizontalBoth, this.DefaultSliderHorizontalBothWidth));

    /// <summary>
    /// Gets the default width of the slider horizontal both image.
    /// </summary>
    /// <value>The default width of the slider horizontal both image.</value>
    protected int DefaultSliderHorizontalBothWidth => 12;

    /// <summary>Gets the height of the slider left image.</summary>
    /// <value>The height of the slider left image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderLeftHeight => this.GetValue<int>(nameof (SliderLeftHeight), this.GetImageHeight(this.SliderLeft, this.DefaultSliderLeftHeight));

    /// <summary>Gets the default height of the slider left image.</summary>
    /// <value>The default height of the slider left image.</value>
    protected int DefaultSliderLeftHeight => 12;

    /// <summary>Gets the height of the slider right image.</summary>
    /// <value>The height of the slider right image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderRightHeight => this.GetValue<int>(nameof (SliderRightHeight), this.GetImageHeight(this.SliderRight, this.DefaultSliderRightHeight));

    /// <summary>Gets the default height of the slider right image.</summary>
    /// <value>The default height of the slider right image.</value>
    protected int DefaultSliderRightHeight => 12;

    /// <summary>Gets the height of the slider horizontal both image.</summary>
    /// <value>The height of the slider horizontal both image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SliderHorizontalBothHeight => this.GetValue<int>(nameof (SliderHorizontalBothHeight), this.GetImageHeight(this.SliderVerticalBoth, this.DefaultSliderHorizontalBothHeight));

    /// <summary>
    /// Gets the default height of the slider horizontal both image.
    /// </summary>
    /// <value>The default height of the slider horizontal both image.</value>
    protected int DefaultSliderHorizontalBothHeight => 12;
  }
}
