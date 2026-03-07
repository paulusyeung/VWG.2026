// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolBarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ToolBar Skin</summary>
  [ToolboxBitmap(typeof (ToolBar), "ToolBar.bmp")]
  [SkinDependency(typeof (ToolBarButtonSkin))]
  [SkinDependency(typeof (FlatToolBarSkin))]
  [SkinDependency(typeof (FlatToolBarButtonSkin))]
  public class ToolBarSkin : ControlSkin
  {
    /// <summary>Gets the height of the defalut.</summary>
    /// <value>The height of the defalut.</value>
    internal static int DefalutHeight => 25;

    /// <summary>Gets or sets the height of the toolbar.</summary>
    /// <value>The height of the toolbar.</value>
    [Category("Sizes")]
    [Description("The height of the main menu.")]
    public int Height
    {
      get => this.GetValue<int>(nameof (Height), ToolBarSkin.DefalutHeight);
      set => this.SetValue(nameof (Height), (object) value);
    }

    /// <summary>Resets the height of the menu.</summary>
    private void ResetHeight() => this.Reset("Height");

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

    private void InitializeComponent()
    {
    }
  }
}
