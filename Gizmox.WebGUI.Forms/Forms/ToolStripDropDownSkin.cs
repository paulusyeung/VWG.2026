// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  public class ToolStripDropDownSkin : ToolStripSkin
  {
    /// <summary>Gets or sets the width of the popup window offset.</summary>
    /// <value>The width of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset width for the popup window.")]
    public virtual int DropDownOffsetWidth
    {
      get => this.GetValue<int>(nameof (DropDownOffsetWidth), this.DefaultDropDownOffsetWidth);
      set => this.SetValue(nameof (DropDownOffsetWidth), (object) value);
    }

    /// <summary>Resets the width of the popup window offset.</summary>
    private void ResetDropDownOffsetWidth() => this.Reset("DropDownOffsetWidth");

    /// <summary>Gets the default width of the popup window offset.</summary>
    /// <value>The default width of the popup window offset.</value>
    protected virtual int DefaultDropDownOffsetWidth
    {
      get
      {
        BorderWidth borderWidth = this.DropDownStyle.CenterStyle.BorderWidth;
        int left = borderWidth.Left;
        borderWidth = this.DropDownStyle.CenterStyle.BorderWidth;
        int right = borderWidth.Right;
        int num = left + right + this.DropDownStyle.CenterStyle.Padding.Horizontal;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.RightDropDownFrameWidth + this.LeftDropDownFrameWidth;
      }
    }

    /// <summary>Gets or sets the height of the popup window offset.</summary>
    /// <value>The height of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset height for the popup window.")]
    public virtual int DropDownOffsetHeight
    {
      get => this.GetValue<int>(nameof (DropDownOffsetHeight), this.DefaultDropDownOffsetHeight);
      set => this.SetValue(nameof (DropDownOffsetHeight), (object) value);
    }

    /// <summary>Resets the height of the popup window offset.</summary>
    private void ResetDropDownOffsetHeight() => this.Reset("DropDownOffsetHeight");

    /// <summary>Gets the default height of the popup window offset.</summary>
    /// <value>The default height of the popup window offset.</value>
    protected virtual int DefaultDropDownOffsetHeight
    {
      get
      {
        BorderWidth borderWidth = this.DropDownStyle.CenterStyle.BorderWidth;
        int top = borderWidth.Top;
        borderWidth = this.DropDownStyle.CenterStyle.BorderWidth;
        int bottom = borderWidth.Bottom;
        int num = top + bottom + this.DropDownStyle.CenterStyle.Padding.Vertical;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.TopDropDownFrameHeight + this.BottomDropDownFrameHeight;
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
    public virtual int LeftDropDownFrameWidth => this.GetFrameEdgeSize(this.DropDownStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Resets the width of the left popup window frame.</summary>
    internal void ResetLeftDropDownFrameWidth() => this.Reset("LeftDropDownFrameWidth");

    /// <summary>
    /// Gets or sets the width of the right popup window frame.
    /// </summary>
    /// <value>The width of the right popup window frame.</value>
    [Category("Sizes")]
    [Description("The width of the right popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightDropDownFrameWidth => this.GetFrameEdgeSize(this.DropDownStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Resets the width of the right popup window frame.</summary>
    internal void ResetRightDropDownFrameWidth() => this.Reset("RightDropDownFrameWidth");

    /// <summary>
    /// Gets or sets the height of the top popup window frame.
    /// </summary>
    /// <value>The height of the top popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the top popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int TopDropDownFrameHeight => this.GetFrameEdgeSize(this.DropDownStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Resets the height of the top popup window frame.</summary>
    internal void ResetTopDropDownFrameHeight() => this.Reset("TopDropDownFrameHeight");

    /// <summary>
    /// Gets or sets the height of the bottom popup window frame.
    /// </summary>
    /// <value>The height of the bottom popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int BottomDropDownFrameHeight => this.GetFrameEdgeSize(this.DropDownStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Resets the height of the bottom popup window frame.</summary>
    internal void ResetBottomDropDownFrameHeight() => this.Reset("BottomDropDownFrameHeight");

    /// <summary>Gets the opup window style.</summary>
    /// <value>The opup window style.</value>
    [Category("States")]
    [Description("The popup window style.")]
    public FrameStyleValue DropDownStyle => new FrameStyleValue(this.LeftBottomDropDownStyle, this.LeftDropDownStyle, this.LeftTopDropDownStyle, this.TopDropDownStyle, this.RightTopDropDownStyle, this.RightDropDownStyle, this.RightBottomDropDownStyle, this.BottomDropDownStyle, this.CenterDropDownStyle);

    /// <summary>Gets the center popup window style.</summary>
    /// <value>The center popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterDropDownStyle => new StyleValue((CommonSkin) this, nameof (CenterDropDownStyle), this.PopupSkin.CenterStyle, true);

    /// <summary>Gets the left popup window style.</summary>
    /// <value>The left popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftDropDownStyle), this.PopupSkin.LeftStyle, true);

    /// <summary>Gets the top popup window style.</summary>
    /// <value>The top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopDropDownStyle), this.PopupSkin.TopStyle, true);

    /// <summary>Gets the bottom popup window style.</summary>
    /// <value>The bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomDropDownStyle), this.PopupSkin.BottomStyle, true);

    /// <summary>Gets the right popup window style.</summary>
    /// <value>The right popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightDropDownStyle), this.PopupSkin.RightStyle, true);

    /// <summary>Gets the right top popup window style.</summary>
    /// <value>The right top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopDropDownStyle), this.PopupSkin.RightTopStyle, true);

    /// <summary>Gets the left top popup window style.</summary>
    /// <value>The left top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopDropDownStyle), this.PopupSkin.LeftTopStyle, true);

    /// <summary>Gets the left bottom popup window style.</summary>
    /// <value>The left bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomDropDownStyle), this.PopupSkin.LeftBottomStyle, true);

    /// <summary>Gets the right bottom popup window style.</summary>
    /// <value>The right bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomDropDownStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomDropDownStyle), this.PopupSkin.RightBottomStyle, true);

    /// <summary>Gets the popups skin.</summary>
    /// <value>The popups skin.</value>
    private PopupsSkin PopupSkin => SkinFactory.GetSkin(this.Owner, typeof (PopupsSkin), true) as PopupsSkin;

    private void InitializeComponent()
    {
    }
  }
}
