// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MainMenuSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>MainMenu Skin</summary>
  [ToolboxBitmap(typeof (MainMenu), "MainMenu.bmp")]
  [Serializable]
  public class MainMenuSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the height of the menu.</summary>
    /// <value>The height of the menu.</value>
    [Category("Sizes")]
    [Description("The height of the main menu.")]
    public virtual int Height
    {
      get => this.GetValue<int>(nameof (Height), this.DefaultHeight);
      set => this.SetValue(nameof (Height), (object) value);
    }

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetHeight() => this.Reset("Height");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultHeight => 22;

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("Gets or sets the width of the left frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int LeftFrameWidth => this.GetImageWidth(this.LeftFrameStyle.BackgroundImage);

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetLeftFrameWidth() => this.Reset("LeftFrameWidth");

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("Gets or sets the width of the right frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightFrameWidth => this.GetImageWidth(this.RightFrameStyle.BackgroundImage);

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetRightFrameWidth() => this.Reset("RightFrameWidth");

    /// <summary>Gets or sets the width of the seperator.</summary>
    /// <value>The width of the seperator.</value>
    [Category("Sizes")]
    [Description("The width of the seperator.")]
    public virtual int SeperatorWidth
    {
      get => this.GetValue<int>(nameof (SeperatorWidth), this.DefaultSeperatorWidth);
      set => this.SetValue(nameof (SeperatorWidth), (object) value);
    }

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetSeperatorWidth() => this.Reset("SeperatorWidth");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultSeperatorWidth => 0;

    /// <summary>Gets the top menu item hover style.</summary>
    /// <value>The top menu item hover style.</value>
    [Category("States")]
    [Description("The top menu item hover style.")]
    public virtual SimpleFrameStyleValue FrameStyle => new SimpleFrameStyleValue(this.LeftFrameStyle, this.RightFrameStyle, this.CenterFrameStyle);

    /// <summary>Gets the right frame style.</summary>
    /// <value>The right frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightFrameStyle => new StyleValue((CommonSkin) this, nameof (RightFrameStyle));

    /// <summary>Gets the left frame style.</summary>
    /// <value>The left frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftFrameStyle => new StyleValue((CommonSkin) this, nameof (LeftFrameStyle));

    /// <summary>Gets the center frame style.</summary>
    /// <value>The center frame style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterFrameStyle => new StyleValue((CommonSkin) this, nameof (CenterFrameStyle));

    /// <summary>Gets the top menu item normal style.</summary>
    /// <value>The top menu item normal style.</value>
    [Category("States")]
    [Description("The top menu item normal style.")]
    public virtual SimpleFrameStyleValue MenuItemNormalStyle => new SimpleFrameStyleValue(this.LeftMenuItemNormalStyle, this.RightMenuItemNormalStyle, this.CenterMenuItemNormalStyle);

    /// <summary>Gets the top menu item pressed style.</summary>
    /// <value>The top menu item pressed style.</value>
    [Category("States")]
    [Description("The top menu item pressed style.")]
    public virtual SimpleFrameStyleValue MenuItemPressedStyle => new SimpleFrameStyleValue(this.LeftMenuItemPressedStyle, this.RightMenuItemPressedStyle, this.CenterMenuItemPressedStyle);

    /// <summary>Gets the top menu item hover style.</summary>
    /// <value>The top menu item hover style.</value>
    [Category("States")]
    [Description("The top menu item hover style.")]
    public virtual SimpleFrameStyleValue MenuItemHoverStyle => new SimpleFrameStyleValue(this.LeftMenuItemHoverStyle, this.RightMenuItemHoverStyle, this.CenterMenuItemHoverStyle);

    /// <summary>Gets the top menu item disable style.</summary>
    /// <value>The top menu item disable style.</value>
    [Category("States")]
    [Description("The top menu item disable style.")]
    public virtual SimpleFrameStyleValue MenuItemDisableStyle => new SimpleFrameStyleValue(this.LeftMenuItemDisableStyle, this.RightMenuItemDisableStyle, this.CenterMenuItemDisableStyle);

    /// <summary>Gets the right menu item normal style.</summary>
    /// <value>The right menu item normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightMenuItemNormalStyle => new StyleValue((CommonSkin) this, nameof (RightMenuItemNormalStyle));

    /// <summary>Gets the right menu item pressed style.</summary>
    /// <value>The right menu item pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightMenuItemPressedStyle => new StyleValue((CommonSkin) this, nameof (RightMenuItemPressedStyle), this.RightMenuItemNormalStyle);

    /// <summary>Gets the right menu item hover style.</summary>
    /// <value>The right menu item hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightMenuItemHoverStyle => new StyleValue((CommonSkin) this, nameof (RightMenuItemHoverStyle), this.RightMenuItemNormalStyle);

    /// <summary>Gets the left menu item normal style.</summary>
    /// <value>The left menu item normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftMenuItemNormalStyle => new StyleValue((CommonSkin) this, nameof (LeftMenuItemNormalStyle));

    /// <summary>Gets the left menu item pressed style.</summary>
    /// <value>The left menu item pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftMenuItemPressedStyle => new StyleValue((CommonSkin) this, nameof (LeftMenuItemPressedStyle), this.LeftMenuItemNormalStyle);

    /// <summary>Gets the left menu item hover style.</summary>
    /// <value>The left menu item hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftMenuItemHoverStyle => new StyleValue((CommonSkin) this, nameof (LeftMenuItemHoverStyle), this.LeftMenuItemNormalStyle);

    /// <summary>Gets or sets the width of the left menu item.</summary>
    /// <value>The width of the left menu item.</value>
    [Category("Sizes")]
    [Description("The width of the left menu item.")]
    public virtual int LeftMenuItemWidth
    {
      get => this.GetValue<int>(nameof (LeftMenuItemWidth), this.GetImageWidth(this.LeftMenuItemNormalStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (LeftMenuItemWidth), (object) value);
    }

    /// <summary>Gets or sets the width of the right menu item.</summary>
    /// <value>The width of the right menu item.</value>
    [Category("Sizes")]
    [Description("The width of the right menu item.")]
    public virtual int RightMenuItemWidth
    {
      get => this.GetValue<int>(nameof (RightMenuItemWidth), this.GetImageWidth(this.RightMenuItemNormalStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (RightMenuItemWidth), (object) value);
    }

    /// <summary>Gets the center menu item normal style.</summary>
    /// <value>The center menu item normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterMenuItemNormalStyle => new StyleValue((CommonSkin) this, nameof (CenterMenuItemNormalStyle));

    /// <summary>Gets the center menu item pressed style.</summary>
    /// <value>The center menu item pressed style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterMenuItemPressedStyle => new StyleValue((CommonSkin) this, nameof (CenterMenuItemPressedStyle), this.CenterMenuItemNormalStyle);

    /// <summary>Gets the center menu item hover style.</summary>
    /// <value>The center menu item hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterMenuItemHoverStyle => new StyleValue((CommonSkin) this, nameof (CenterMenuItemHoverStyle), this.CenterMenuItemNormalStyle);

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue LeftMenuItemDisableStyle => new StyleValue((CommonSkin) this, nameof (LeftMenuItemDisableStyle), this.LeftMenuItemNormalStyle);

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterMenuItemDisableStyle => new StyleValue((CommonSkin) this, nameof (CenterMenuItemDisableStyle), this.CenterMenuItemNormalStyle);

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue RightMenuItemDisableStyle => new StyleValue((CommonSkin) this, nameof (RightMenuItemDisableStyle), this.RightMenuItemNormalStyle);

    /// <summary>Gets the seperator style.</summary>
    /// <value>The seperator style.</value>
    public virtual StyleValue SeperatorStyle => new StyleValue((CommonSkin) this, nameof (SeperatorStyle));
  }
}
