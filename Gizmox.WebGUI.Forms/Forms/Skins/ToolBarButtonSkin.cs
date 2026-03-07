// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolBarButtonSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  [SkinContainer(typeof (ToolBarSkin))]
  [ToolboxBitmap(typeof (Button), "Button.bmp")]
  [Serializable]
  public class ToolBarButtonSkin : ButtonSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the pushed style.</summary>
    /// <value>The pushed style.</value>
    [Category("States")]
    [Description("The pushed button style.")]
    public virtual FrameStyleValue PushedStyle => new FrameStyleValue(this.LeftBottomPushedStyle, this.LeftPushedStyle, this.LeftTopPushedStyle, this.TopPushedStyle, this.RightTopPushedStyle, this.RightPushedStyle, this.RightBottomPushedStyle, this.BottomPushedStyle, this.CenterPushedStyle);

    /// <summary>Gets the drop down button style.</summary>
    /// <value>The drop down button style.</value>
    [Category("States")]
    [Description("The drop down button sytle.")]
    public virtual StyleValue DropDownButtonStyle => new StyleValue((CommonSkin) this, nameof (DropDownButtonStyle));

    /// <summary>Gets the seperator style.</summary>
    /// <value>The seperator style.</value>
    public StyleValue SeperatorStyle => new StyleValue((CommonSkin) this, nameof (SeperatorStyle));

    /// <summary>Gets or sets the width of the seperator.</summary>
    /// <value>The width of the seperator.</value>
    [Category("Sizes")]
    [Description("The width of the seperator.")]
    public int SeperatorWidth
    {
      get => this.GetValue<int>(nameof (SeperatorWidth), 3);
      set => this.SetValue(nameof (SeperatorWidth), (object) value);
    }

    /// <summary>Gets the center pushed style.</summary>
    /// <value>The center pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterPushedStyle => new StyleValue((CommonSkin) this, nameof (CenterPushedStyle), this.CenterPressedStyle);

    /// <summary>Gets the left pushed style.</summary>
    /// <value>The left pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftPushedStyle), this.LeftPressedStyle);

    /// <summary>Gets the top pushed style.</summary>
    /// <value>The top pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopPushedStyle), this.TopPressedStyle);

    /// <summary>Gets the bottom pushed style.</summary>
    /// <value>The bottom pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomPushedStyle), this.BottomPressedStyle);

    /// <summary>Gets the right pushed style.</summary>
    /// <value>The right pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightPushedStyle), this.RightPressedStyle);

    /// <summary>Gets the right top pushed style.</summary>
    /// <value>The right top pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopPushedStyle), this.RightTopPressedStyle);

    /// <summary>Gets the left top pushed style.</summary>
    /// <value>The left top pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopPushedStyle), this.LeftTopPressedStyle);

    /// <summary>Gets the left bottom pushed style.</summary>
    /// <value>The left bottom pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomPushedStyle), this.LeftBottomPressedStyle);

    /// <summary>Gets the right bottom pushed style.</summary>
    /// <value>The right bottom pushed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomPushedStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomPushedStyle), this.RightBottomPressedStyle);

    /// <summary>Gets the size of the drop down image.</summary>
    /// <value>The size of the drop down image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size DropDownImageSize => this.GetImageSize(this.DropDownButtonStyle.BackgroundImage, Size.Empty);

    /// <summary>Gets the width of the drop down image.</summary>
    /// <value>The width of the drop down image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int DropDownImageWidth => this.DropDownImageSize.Width;
  }
}
