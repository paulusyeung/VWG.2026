// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.CheckBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>CheckBox Skin</summary>
  [ToolboxBitmap(typeof (CheckBox), "CheckBox.bmp")]
  [Serializable]
  public class CheckBoxSkin : ButtonBaseSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the height of the check box image.</summary>
    /// <value>The height of the check box image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CheckBoxImageHeight => this.GetMaxImageHeight(16, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

    /// <summary>Gets the width of the check box image.</summary>
    /// <value>The width of the check box image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CheckBoxImageWidth => this.GetMaxImageWidth(15, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

    /// <summary>Gets or sets the checked check box image.</summary>
    /// <value>The checked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The checked checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference CheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedCheckBoxImage), new ImageResourceReference(typeof (CheckBoxSkin), "CheckBox1.gif"));
      set => this.SetValue(nameof (CheckedCheckBoxImage), (object) value);
    }

    /// <summary>Resets the checked check box image.</summary>
    private void ResetCheckedCheckBoxImage() => this.Reset("CheckedCheckBoxImage");

    /// <summary>Gets or sets the un checked check box image.</summary>
    /// <value>The un checked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The unchecked checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UnCheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UnCheckedCheckBoxImage), new ImageResourceReference(typeof (CheckBoxSkin), "CheckBox0.gif"));
      set => this.SetValue(nameof (UnCheckedCheckBoxImage), (object) value);
    }

    /// <summary>Resets the un checked check box image.</summary>
    private void ResetUnCheckedCheckBoxImage() => this.Reset("UnCheckedCheckBoxImage");

    /// <summary>Gets or sets the indeterminate check box image.</summary>
    /// <value>The indeterminate check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The Indeterminate checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference IndeterminateCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (IndeterminateCheckBoxImage), new ImageResourceReference(typeof (CheckBoxSkin), "CheckBox2.gif"));
      set => this.SetValue(nameof (IndeterminateCheckBoxImage), (object) value);
    }

    /// <summary>Resets the indeterminate check box image.</summary>
    private void ResetIndeterminateCheckBoxImage() => this.Reset("IndeterminateCheckBoxImage");

    /// <summary>Gets the label normal style.</summary>
    /// <value>The center normal style.</value>
    [Category("States")]
    [Description("The checkbox's label normal style.")]
    public virtual StyleValue LabelNormalStyle => new StyleValue((CommonSkin) this, nameof (LabelNormalStyle));

    /// <summary>Gets the label focused style.</summary>
    /// <value>The center focused style.</value>
    [Category("States")]
    [Description("The checkbox's label focused style.")]
    public virtual StyleValue LabelFocusedStyle => new StyleValue((CommonSkin) this, nameof (LabelFocusedStyle));

    /// <summary>Gets the content padding.</summary>
    /// <value>The content padding.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual PaddingValue ContentPadding => this.Padding;

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("The width of the left frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int LeftFrameWidth => this.GetFrameEdgeSize(this.NormalStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("The width of the right frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightFrameWidth => this.GetFrameEdgeSize(this.NormalStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Category("Sizes")]
    [Description("The height of the top frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int TopFrameHeight => this.GetFrameEdgeSize(this.NormalStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int BottomFrameHeight => this.GetFrameEdgeSize(this.NormalStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Gets the normal style.</summary>
    /// <value>The normal style.</value>
    [Category("States")]
    [Description("The normal button style.")]
    public FrameStyleValue NormalStyle => new FrameStyleValue(this.LeftBottomNormalStyle, this.LeftNormalStyle, this.LeftTopNormalStyle, this.TopNormalStyle, this.RightTopNormalStyle, this.RightNormalStyle, this.RightBottomNormalStyle, this.BottomNormalStyle, this.CenterNormalStyle);

    /// <summary>Gets the hover style.</summary>
    /// <value>The hover style.</value>
    [Category("States")]
    [Description("The hover button style.")]
    public FrameStyleValue HoverStyle => new FrameStyleValue(this.LeftBottomHoverStyle, this.LeftHoverStyle, this.LeftTopHoverStyle, this.TopHoverStyle, this.RightTopHoverStyle, this.RightHoverStyle, this.RightBottomHoverStyle, this.BottomHoverStyle, this.CenterHoverStyle);

    /// <summary>Gets the pressed style.</summary>
    /// <value>The pressed style.</value>
    [Category("States")]
    [Description("The pressed button style.")]
    public FrameStyleValue PressedStyle => new FrameStyleValue(this.LeftBottomPressedStyle, this.LeftPressedStyle, this.LeftTopPressedStyle, this.TopPressedStyle, this.RightTopPressedStyle, this.RightPressedStyle, this.RightBottomPressedStyle, this.BottomPressedStyle, this.CenterPressedStyle);

    /// <summary>Gets the disabled style.</summary>
    /// <value>The disabled style.</value>
    [Category("States")]
    [Description("The disabled button style.")]
    public FrameStyleValue DisabledStyle => new FrameStyleValue(this.LeftBottomDisabledStyle, this.LeftDisabledStyle, this.LeftTopDisabledStyle, this.TopDisabledStyle, this.RightTopDisabledStyle, this.RightDisabledStyle, this.RightBottomDisabledStyle, this.BottomDisabledStyle, this.CenterDisabledStyle);

    /// <summary>Gets the focused style.</summary>
    /// <value>The focused style.</value>
    [Category("States")]
    [Description("The focused button style.")]
    public FrameStyleValue FocusedStyle => new FrameStyleValue(this.LeftBottomFocusedStyle, this.LeftFocusedStyle, this.LeftTopFocusedStyle, this.TopFocusedStyle, this.RightTopFocusedStyle, this.RightFocusedStyle, this.RightBottomFocusedStyle, this.BottomFocusedStyle, this.CenterFocusedStyle);

    /// <summary>Gets the font When the button is normal.</summary>
    /// <value>The font normal.</value>
    [Browsable(false)]
    public Font FontNormal => this.CenterNormalStyle.Font;

    /// <summary>Gets the font When the button is pressed.</summary>
    /// <value>The font pressed.</value>
    [Browsable(false)]
    public Font FontPressed => this.CenterPressedStyle.Font;

    /// <summary>Gets the font When the button is hover.</summary>
    /// <value>The font hover.</value>
    [Browsable(false)]
    public Font FontHover => this.CenterHoverStyle.Font;

    /// <summary>Gets the font When the button is focused.</summary>
    /// <value>The font focused.</value>
    [Browsable(false)]
    public Font FontFocused => this.CenterFocusedStyle.Font;

    /// <summary>Gets the font When the button is disabled.</summary>
    /// <value>The font disabled.</value>
    [Browsable(false)]
    public Font FontDisabled => this.CenterDisabledStyle.Font;

    /// <summary>Gets the foreground value When the button is normal.</summary>
    /// <value>The foreground value normal.</value>
    [Browsable(false)]
    public ForegroundValue ForegroundNormal => new ForegroundValue(this.CenterNormalStyle.ForeColor);

    /// <summary>Gets the foreground value When the button is pressed.</summary>
    /// <value>The foreground value pressed.</value>
    [Browsable(false)]
    public ForegroundValue ForegroundPressed => new ForegroundValue(this.CenterPressedStyle.ForeColor);

    /// <summary>Gets the foreground value When the button is hover.</summary>
    /// <value>The foreground value hover.</value>
    [Browsable(false)]
    public ForegroundValue ForegroundHover => new ForegroundValue(this.CenterHoverStyle.ForeColor);

    /// <summary>Gets the foreground value When the button is focused.</summary>
    /// <value>The foreground value focused.</value>
    [Browsable(false)]
    public ForegroundValue ForegroundFocused => new ForegroundValue(this.CenterFocusedStyle.ForeColor);

    /// <summary>
    /// Gets the foreground value When the button is disabled.
    /// </summary>
    /// <value>The foreground value disabled.</value>
    [Browsable(false)]
    public ForegroundValue ForegroundDisabled => new ForegroundValue(this.CenterDisabledStyle.ForeColor);

    /// <summary>Gets the center normal style.</summary>
    /// <value>The center normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterNormalStyle => new StyleValue((CommonSkin) this, nameof (CenterNormalStyle));

    /// <summary>Gets the left normal style.</summary>
    /// <value>The left normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftNormalStyle));

    /// <summary>Gets the top normal style.</summary>
    /// <value>The top normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopNormalStyle));

    /// <summary>Gets the bottom normal style.</summary>
    /// <value>The bottom normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomNormalStyle));

    /// <summary>Gets the right normal style.</summary>
    /// <value>The right normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightNormalStyle));

    /// <summary>Gets the right top normal style.</summary>
    /// <value>The right top normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopNormalStyle));

    /// <summary>Gets the left top normal style.</summary>
    /// <value>The left top normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopNormalStyle));

    /// <summary>Gets the left bottom normal style.</summary>
    /// <value>The left bottom normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomNormalStyle));

    /// <summary>Gets the right bottom normal style.</summary>
    /// <value>The right bottom normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomNormalStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomNormalStyle));

    /// <summary>Gets the center hover style.</summary>
    /// <value>The center hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterHoverStyle => new StyleValue((CommonSkin) this, nameof (CenterHoverStyle), this.CenterNormalStyle);

    /// <summary>Gets the left hover style.</summary>
    /// <value>The left hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftHoverStyle), this.LeftNormalStyle);

    /// <summary>Gets the top hover style.</summary>
    /// <value>The top hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopHoverStyle), this.TopNormalStyle);

    /// <summary>Gets the bottom hover style.</summary>
    /// <value>The bottom hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomHoverStyle), this.BottomNormalStyle);

    /// <summary>Gets the right hover style.</summary>
    /// <value>The right hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightHoverStyle), this.RightNormalStyle);

    /// <summary>Gets the right top hover style.</summary>
    /// <value>The right top hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopHoverStyle), this.RightTopNormalStyle);

    /// <summary>Gets the left top hover style.</summary>
    /// <value>The left top hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopHoverStyle), this.LeftTopNormalStyle);

    /// <summary>Gets the left bottom hover style.</summary>
    /// <value>The left bottom hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomHoverStyle), this.LeftBottomNormalStyle);

    /// <summary>Gets the right bottom hover style.</summary>
    /// <value>The right bottom hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomHoverStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomHoverStyle), this.RightBottomNormalStyle);

    /// <summary>Gets the center disabled style.</summary>
    /// <value>The center disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterDisabledStyle => new StyleValue((CommonSkin) this, nameof (CenterDisabledStyle), this.CenterNormalStyle);

    /// <summary>Gets the left disabled style.</summary>
    /// <value>The left disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftDisabledStyle), this.LeftNormalStyle);

    /// <summary>Gets the top disabled style.</summary>
    /// <value>The top disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopDisabledStyle), this.TopNormalStyle);

    /// <summary>Gets the bottom disabled style.</summary>
    /// <value>The bottom disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomDisabledStyle), this.BottomNormalStyle);

    /// <summary>Gets the right disabled style.</summary>
    /// <value>The right disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightDisabledStyle), this.RightNormalStyle);

    /// <summary>Gets the right top disabled style.</summary>
    /// <value>The right top disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopDisabledStyle), this.RightTopNormalStyle);

    /// <summary>Gets the left top disabled style.</summary>
    /// <value>The left top disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopDisabledStyle), this.LeftTopNormalStyle);

    /// <summary>Gets the left bottom disabled style.</summary>
    /// <value>The left bottom disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomDisabledStyle), this.LeftBottomNormalStyle);

    /// <summary>Gets the right bottom disabled style.</summary>
    /// <value>The right bottom disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomDisabledStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomDisabledStyle), this.RightBottomNormalStyle);

    /// <summary>Gets the center focused style.</summary>
    /// <value>The center focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterFocusedStyle => new StyleValue((CommonSkin) this, nameof (CenterFocusedStyle), this.CenterNormalStyle);

    /// <summary>Gets the left focused style.</summary>
    /// <value>The left focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftFocusedStyle), this.LeftNormalStyle);

    /// <summary>Gets the top focused style.</summary>
    /// <value>The top focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopFocusedStyle), this.TopNormalStyle);

    /// <summary>Gets the bottom focused style.</summary>
    /// <value>The bottom focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomFocusedStyle), this.BottomNormalStyle);

    /// <summary>Gets the right focused style.</summary>
    /// <value>The right focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightFocusedStyle), this.RightNormalStyle);

    /// <summary>Gets the right top focused style.</summary>
    /// <value>The right top focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopFocusedStyle), this.RightTopNormalStyle);

    /// <summary>Gets the left top focused style.</summary>
    /// <value>The left top focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopFocusedStyle), this.LeftTopNormalStyle);

    /// <summary>Gets the left bottom focused style.</summary>
    /// <value>The left bottom focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomFocusedStyle), this.LeftBottomNormalStyle);

    /// <summary>Gets the right bottom focused style.</summary>
    /// <value>The right bottom focused style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomFocusedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomFocusedStyle), this.RightBottomNormalStyle);

    /// <summary>Gets the center pressed style.</summary>
    /// <value>The center pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterPressedStyle => new StyleValue((CommonSkin) this, nameof (CenterPressedStyle), this.CenterNormalStyle);

    /// <summary>Gets the left pressed style.</summary>
    /// <value>The left pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftPressedStyle), this.LeftNormalStyle);

    /// <summary>Gets the top pressed style.</summary>
    /// <value>The top pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopPressedStyle), this.TopNormalStyle);

    /// <summary>Gets the bottom pressed style.</summary>
    /// <value>The bottom pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomPressedStyle), this.BottomNormalStyle);

    /// <summary>Gets the right pressed style.</summary>
    /// <value>The right pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightPressedStyle), this.RightNormalStyle);

    /// <summary>Gets the right top pressed style.</summary>
    /// <value>The right top pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopPressedStyle), this.RightTopNormalStyle);

    /// <summary>Gets the left top pressed style.</summary>
    /// <value>The left top pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopPressedStyle), this.LeftTopNormalStyle);

    /// <summary>Gets the left bottom pressed style.</summary>
    /// <value>The left bottom pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomPressedStyle), this.LeftBottomNormalStyle);

    /// <summary>Gets the right bottom pressed style.</summary>
    /// <value>The right bottom pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomPressedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomPressedStyle), this.RightBottomNormalStyle);
  }
}
