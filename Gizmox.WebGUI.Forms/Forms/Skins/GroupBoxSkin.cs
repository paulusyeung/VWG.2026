// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.GroupBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>GroupBox Skin</summary>
  [ToolboxBitmap(typeof (GroupBox), "GroupBox.bmp")]
  [Serializable]
  public class GroupBoxSkin : ControlSkin
  {
    /// <summary>Gets the normal groupbox style.</summary>
    /// <value>The normal groupbox style.</value>
    [Category("States")]
    [Description("The normal groupbox style.")]
    public HeaderedFrameStyleValue NormalStyle => new HeaderedFrameStyleValue(this.LeftBottomNormalStyle, this.LeftNormalStyle, this.LeftTopNormalStyle, this.TopNormalStyle, this.RightTopNormalStyle, this.RightNormalStyle, this.RightBottomNormalStyle, this.BottomNormalStyle, this.CenterNormalStyle, this.HeaderLeftNormalStyle, this.HeaderCenterNormalStyle, this.HeaderRightNormalStyle);

    /// <summary>Gets the header center normal style.</summary>
    /// <value>The header center normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue HeaderCenterNormalStyle => new StyleValue((CommonSkin) this, nameof (HeaderCenterNormalStyle));

    /// <summary>Gets or sets the width of the header left cell.</summary>
    /// <value>The width of the header left cell.</value>
    [Category("Sizes")]
    [Description("The width of the header left cell.")]
    public virtual int HeaderLeftWidth
    {
      get => this.GetValue<int>(nameof (HeaderLeftWidth), this.GetImageWidth(this.NormalStyle.HeaderLeftStyle.BackgroundImage, this.DefaultHeaderLeftWidth));
      set => this.SetValue(nameof (HeaderLeftWidth), (object) value);
    }

    /// <summary>Resets the width of the header left cell.</summary>
    internal void ResetHeaderLeftWidth() => this.Reset("HeaderLeftWidth");

    /// <summary>Gets the default width of the header left.</summary>
    /// <value>The default width of the header left.</value>
    protected virtual int DefaultHeaderLeftWidth => 1;

    /// <summary>Gets the header left normal style.</summary>
    /// <value>The header left normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue HeaderLeftNormalStyle => new StyleValue((CommonSkin) this, nameof (HeaderLeftNormalStyle));

    /// <summary>Gets or sets the width of the header right cell.</summary>
    /// <value>The width of the header right cell.</value>
    [Category("Sizes")]
    [Description("The width of the header right cell.")]
    public virtual int HeaderRightWidth
    {
      get => this.GetValue<int>(nameof (HeaderRightWidth), this.GetImageWidth(this.NormalStyle.HeaderRightStyle.BackgroundImage, this.DefaultHeaderRightWidth));
      set => this.SetValue(nameof (HeaderRightWidth), (object) value);
    }

    /// <summary>Resets the width of the header right cell.</summary>
    internal void ResetHeaderRightWidth() => this.Reset("HeaderRightWidth");

    /// <summary>Gets the default width of the header right.</summary>
    /// <value>The default width of the header right.</value>
    protected virtual int DefaultHeaderRightWidth => 1;

    /// <summary>Gets the header right normal style.</summary>
    /// <value>The header right normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue HeaderRightNormalStyle => new StyleValue((CommonSkin) this, nameof (HeaderRightNormalStyle));

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

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("The width of the left frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int LeftFrameWidth => this.GetFrameEdgeSize((FrameStyleValue) this.NormalStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Resets the width of the left frame.</summary>
    internal void ResetLeftFrameWidth() => this.Reset("LeftFrameWidth");

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("The width of the right frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightFrameWidth => this.GetFrameEdgeSize((FrameStyleValue) this.NormalStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Resets the width of the right frame.</summary>
    internal void ResetRightFrameWidth() => this.Reset("RightFrameWidth");

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Category("Sizes")]
    [Description("The height of the top frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int TopFrameHeight => this.GetFrameEdgeSize((FrameStyleValue) this.NormalStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Resets the height of the top frame.</summary>
    internal void ResetTopFrameHeight() => this.Reset("TopFrameHeight");

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int BottomFrameHeight => this.GetFrameEdgeSize((FrameStyleValue) this.NormalStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Resets the height of the bottom frame.</summary>
    internal void ResetBottomFrameHeight() => this.Reset("BottomFrameHeight");

    private void InitializeComponent()
    {
    }
  }
}
