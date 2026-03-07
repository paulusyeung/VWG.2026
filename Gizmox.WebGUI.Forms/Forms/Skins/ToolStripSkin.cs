// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolStripSkin
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
  /// <summary>ToolStrip Skin</summary>
  [SkinDependency(typeof (ToolStripButtonSkin))]
  [SkinDependency(typeof (ToolStripDropDownButtonSkin))]
  [SkinDependency(typeof (ToolStripLabelSkin))]
  [SkinDependency(typeof (ToolStripSeparatorSkin))]
  [SkinDependency(typeof (ToolStripSplitButtonSkin))]
  [SkinDependency(typeof (ToolStripControlHostSkin))]
  [SkinDependency(typeof (ToolStripMenuItemSkin))]
  [SkinDependency(typeof (ToolStripDropDownSkin))]
  [SkinDependency(typeof (ToolStripDropDownContentPanelSkin))]
  [Serializable]
  public class ToolStripSkin : ControlSkin
  {
    internal const int IMAGE_SCALING_SIZE = 16;

    private void InitializeComponent()
    {
    }

    /// <summary>Gets the frame frame style.</summary>
    /// <value>The frame frame style.</value>
    public FrameStyleValue FrameStyle => new FrameStyleValue(this.LeftBottomStyle, this.LeftStyle, this.LeftTopStyle, this.TopStyle, this.RightTopStyle, this.RightStyle, this.RightBottomStyle, this.BottomStyle, this.CenterStyle);

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Category("Sizes")]
    [Description("The height of the top frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int TopFrameHeight => this.GetFrameEdgeSize(this.FrameStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("The width of the right frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int RightFrameWidth => this.GetFrameEdgeSize(this.FrameStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int BottomFrameHeight => this.GetFrameEdgeSize(this.FrameStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("The width of the left frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int LeftFrameWidth => this.GetFrameEdgeSize(this.FrameStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Gets the frame left top style.</summary>
    /// <value>The frame left top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftTopStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopStyle));

    /// <summary>Gets the frame top style.</summary>
    /// <value>The frame top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue TopStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopStyle));

    /// <summary>Gets the frame right top style.</summary>
    /// <value>The frame right top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightTopStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopStyle));

    /// <summary>Gets the frame left style.</summary>
    /// <value>The frame left style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftStyle));

    /// <summary>Gets the frame right style.</summary>
    /// <value>The frame right style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightStyle));

    /// <summary>Gets the frame left bottom style.</summary>
    /// <value>The frame left bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftBottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomStyle));

    /// <summary>Gets the center style.</summary>
    /// <value>The center style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue CenterStyle => new StyleValue((CommonSkin) this, nameof (CenterStyle));

    /// <summary>Gets the frame bottom style.</summary>
    /// <value>The frame bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue BottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomStyle));

    /// <summary>Gets the frame right bottom style.</summary>
    /// <value>The frame right bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightBottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomStyle));

    /// <summary>Gets the horizontal drop down button style.</summary>
    /// <value>The horizontal drop down button style.</value>
    public StyleValue HorizontalDropDownButtonStyle => new StyleValue((CommonSkin) this, nameof (HorizontalDropDownButtonStyle));

    /// <summary>Gets the vertical drop down button style.</summary>
    /// <value>The vertical drop down button style.</value>
    public StyleValue VerticalDropDownButtonStyle => new StyleValue((CommonSkin) this, nameof (VerticalDropDownButtonStyle));

    /// <summary>Gets the width of the horizontal drop down button.</summary>
    /// <value>The width of the horizontal drop down button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalDropDownButtonWidth => this.GetImageWidth(this.HorizontalDropDownButtonStyle.BackgroundImage);

    /// <summary>Gets the height of the vertical drop down button.</summary>
    /// <value>The height of the vertical drop down button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalDropDownButtonHeight => this.GetImageHeight(this.VerticalDropDownButtonStyle.BackgroundImage);

    /// <summary>Gets the vertical grip style.</summary>
    /// <value>The vertical grip style.</value>
    public StyleValue VerticalGripStyle => new StyleValue((CommonSkin) this, nameof (VerticalGripStyle));

    /// <summary>Gets the horizontal grip style.</summary>
    /// <value>The horizontal grip style.</value>
    public StyleValue HorizontalGripStyle => new StyleValue((CommonSkin) this, nameof (HorizontalGripStyle));

    /// <summary>Gets the width of the drop down button.</summary>
    /// <value>The width of the drop down button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalGripWidth => this.GetImageWidth(this.HorizontalGripStyle.BackgroundImage);

    /// <summary>Gets the height of the vertical grip.</summary>
    /// <value>The height of the vertical grip.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalGripHeight => this.GetImageHeight(this.VerticalGripStyle.BackgroundImage);

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

    /// <summary>Resets the height of the popup window offset.</summary>
    private void ResetPopupWindowOffsetHeight() => this.Reset("PopupWindowOffsetHeight");

    /// <summary>Gets the default height of the popup window offset.</summary>
    /// <value>The default height of the popup window offset.</value>
    protected virtual int DefaultPopupWindowOffsetHeight
    {
      get
      {
        BorderWidth borderWidth = this.CenterPopupWindowStyle.BorderWidth;
        int top = borderWidth.Top;
        borderWidth = this.CenterPopupWindowStyle.BorderWidth;
        int bottom = borderWidth.Bottom;
        int num = top + bottom + this.CenterPopupWindowStyle.Padding.Vertical;
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

    /// <summary>Gets or sets the size of the image scaling.</summary>
    /// <value>The size of the image scaling.</value>
    public Size ImageScalingSize
    {
      get => this.GetValue<Size>(nameof (ImageScalingSize), new Size(16, 16));
      set => this.SetValue(nameof (ImageScalingSize), (object) value);
    }
  }
}
