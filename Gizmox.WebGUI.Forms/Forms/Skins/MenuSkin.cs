// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MenuSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Hosting;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Menu Skin</summary>
  [ToolboxBitmap(typeof (Menu), "MainMenu.bmp")]
  [Serializable]
  public class MenuSkin : ControlSkin
  {
    /// <summary>Gets or sets the width of the popup window offset.</summary>
    /// <value>The width of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset width for the popup window.")]
    public virtual int PopupWindowOffsetWidth
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetWidth), this.DefaultPopupWindowOffsetWidth);
      set => this.SetValue(nameof (PopupWindowOffsetWidth), (object) value);
    }

    /// <summary>Resets the width of the popup window offset.</summary>
    private void ResetPopupWindowOffsetWidth() => this.Reset("PopupWindowOffsetWidth");

    /// <summary>Gets the default width of the popup window offset.</summary>
    /// <value>The default width of the popup window offset.</value>
    protected virtual int DefaultPopupWindowOffsetWidth
    {
      get
      {
        BorderWidth borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int left = borderWidth.Left;
        borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int right = borderWidth.Right;
        int num = left + right + this.PopupWindowStyle.CenterStyle.Padding.Horizontal;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.RightPopupWindowFrameWidth + this.LeftPopupWindowFrameWidth;
      }
    }

    /// <summary>Gets or sets the height of the popup window offset.</summary>
    /// <value>The height of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset height for the popup window.")]
    public virtual int PopupWindowOffsetHeight
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetHeight), this.DefaultPopupWindowOffsetHeight);
      set => this.SetValue(nameof (PopupWindowOffsetHeight), (object) value);
    }

    /// <summary>Resets the height of the popup window offset.</summary>
    private void ResetPopupWindowOffsetHeight() => this.Reset("PopupWindowOffsetHeight");

    /// <summary>Gets the default height of the popup window offset.</summary>
    /// <value>The default height of the popup window offset.</value>
    protected virtual int DefaultPopupWindowOffsetHeight
    {
      get
      {
        BorderWidth borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int top = borderWidth.Top;
        borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int bottom = borderWidth.Bottom;
        int num = top + bottom + this.PopupWindowStyle.CenterStyle.Padding.Vertical;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.TopPopupWindowFrameHeight + this.BottomPopupWindowFrameHeight;
      }
    }

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
    public FrameStyleValue PopupWindowStyle => new FrameStyleValue(this.LeftBottomPopupWindowStyle, this.LeftPopupWindowStyle, this.LeftTopPopupWindowStyle, this.TopPopupWindowStyle, this.RightTopPopupWindowStyle, this.RightPopupWindowStyle, this.RightBottomPopupWindowStyle, this.BottomPopupWindowStyle, this.CenterPopupWindowStyle);

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

    /// <summary>Gets the background.</summary>
    /// <value>The background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BackgroundValue Background => new BackgroundValue()
    {
      BackColor = this.BackColor,
      BackgroundImage = this.BackgroundImage,
      BackgroundImagePosition = this.BackgroundImagePosition,
      BackgroundImageRepeat = this.BackgroundImageRepeat
    };

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageResourceReference BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>Gets or sets the background image repeat.</summary>
    /// <value>The background image repeat.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BackgroundImageRepeat BackgroundImageRepeat
    {
      get => base.BackgroundImageRepeat;
      set => base.BackgroundImageRepeat = value;
    }

    /// <summary>Gets or sets the background image position.</summary>
    /// <value>The background image position.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BackgroundImagePosition BackgroundImagePosition
    {
      get => base.BackgroundImagePosition;
      set => base.BackgroundImagePosition = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderWidth BorderWidth
    {
      get => this.GetValue<BorderWidth>(nameof (BorderWidth), new BorderWidth(0));
      set => this.SetValue(nameof (BorderWidth), (object) value);
    }

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderColor BorderColor
    {
      get => this.GetValue<BorderColor>(nameof (BorderColor), new BorderColor(Color.Black));
      set => this.SetValue(nameof (BorderColor), (object) value);
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets or sets the space between controls.</summary>
    /// <value>The space between controls.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override MarginValue Margin
    {
      get => base.Margin;
      set => base.Margin = value;
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value>The control padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override PaddingValue Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    private void InitializeComponent()
    {
    }
  }
}
