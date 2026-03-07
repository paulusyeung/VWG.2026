// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripMenuItemSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  public class ToolStripMenuItemSkin : ControlSkin
  {
    /// <summary>Gets the tool strip menu item style.</summary>
    /// <value>The tool strip menu item style.</value>
    [Category("States")]
    [SRDescription("The tool strip menu item style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemStyle => new StyleValue((CommonSkin) this, nameof (MenuItemStyle));

    /// <summary>Gets the menu item hover style.</summary>
    /// <value>The menu item hover style.</value>
    [Category("States")]
    [SRDescription("The tool strip menu item over style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemHoverStyle => new StyleValue((CommonSkin) this, nameof (MenuItemHoverStyle));

    /// <summary>Gets the menu item down style.</summary>
    /// <value>The menu item down style.</value>
    [Category("States")]
    [SRDescription("The tool strip menu item down style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemDownStyle => new StyleValue((CommonSkin) this, nameof (MenuItemDownStyle));

    /// <summary>Gets the disabled menu item style.</summary>
    /// <value>The disabled menu item style.</value>
    [Category("States")]
    [SRDescription("The tool strip menu item disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue DisabledMenuItemTextStyle => new StyleValue((CommonSkin) this, nameof (DisabledMenuItemTextStyle));

    /// <summary>Gets the arrow image width LTR.</summary>
    /// <value>The arrow image width LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int MenuItemArrowImageWidthLTR => this.GetImageWidth(this.MenuItemArrowLTR.BackgroundImage, 7);

    /// <summary>Gets the arrow image width RTL.</summary>
    /// <value>The arrow image width RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int MenuItemArrowImageWidthRTL => this.GetImageWidth(this.MenuItemArrowRTL.BackgroundImage, 7);

    /// <summary>Gets the width of the arrow image.</summary>
    /// <value>The width of the arrow image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SkinValue MenuItemArrowImageWidth => (SkinValue) new BidirectionalSkinValue<int>((Skin) this, this.MenuItemArrowImageWidthLTR, this.MenuItemArrowImageWidthRTL);

    /// <summary>Gets the menu item image style.</summary>
    /// <value>The menu item image style.</value>
    [Category("States")]
    [SRDescription("The menu item image style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinValue<StyleValue> MenuItemImageStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemImageStyleLTR, this.MenuItemImageStyleRTL);

    /// <summary>Gets the menu item image style LTR.</summary>
    /// <value>The menu item image style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemImageStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemImageStyleLTR));

    /// <summary>Gets the menu item image style RTL.</summary>
    /// <value>The menu item image style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemImageStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemImageStyleRTL));

    /// <summary>Gets the width of the tool strip menu item image.</summary>
    /// <value>The width of the tool strip menu item image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SkinValue MenuItemImageWidth => (SkinValue) new BidirectionalSkinValue<int>((Skin) this, this.MenuItemImageWidthLTR, this.MenuItemImageWidthRTL);

    /// <summary>Gets the tool strip menu item image width LTR.</summary>
    /// <value>The tool strip menu item image width LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int MenuItemImageWidthLTR => this.GetImageWidth(this.MenuItemImageStyleLTR.BackgroundImage, 32);

    /// <summary>Gets the tool strip menu item image width RTL.</summary>
    /// <value>The tool strip menu item image width RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int MenuItemImageWidthRTL => this.GetImageWidth(this.MenuItemImageStyleRTL.BackgroundImage, 32);

    private void InitializeComponent()
    {
    }

    /// <summary>Gets the menu item arrow.</summary>
    /// <value>The menu item arrow.</value>
    [Category("States")]
    [SRDescription("The menu item arrow style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinValue<StyleValue> MenuItemArrow => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemArrowLTR, this.MenuItemArrowRTL);

    /// <summary>Gets the menu item arrow LTR.</summary>
    /// <value>The menu item arrow LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemArrowLTR => new StyleValue((CommonSkin) this, nameof (MenuItemArrowLTR));

    /// <summary>Gets the menu item arrow RTL.</summary>
    /// <value>The menu item arrow RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemArrowRTL => new StyleValue((CommonSkin) this, nameof (MenuItemArrowRTL));

    /// <summary>Gets the menu item arrow disabled.</summary>
    /// <value>The menu item arrow disabled.</value>
    [Category("States")]
    [SRDescription("The menu item arrow disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinValue<StyleValue> MenuItemArrowDisabled => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemArrowDisabledLTR, this.MenuItemArrowDisabledRTL);

    /// <summary>Gets the menu item arrow disabled LTR.</summary>
    /// <value>The menu item arrow disabled LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemArrowDisabledLTR => new StyleValue((CommonSkin) this, nameof (MenuItemArrowDisabledLTR));

    /// <summary>Gets the menu item arrow disabled RTL.</summary>
    /// <value>The menu item arrow disabled RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue MenuItemArrowDisabledRTL => new StyleValue((CommonSkin) this, nameof (MenuItemArrowDisabledRTL));

    /// <summary>Gets the menu item checked.</summary>
    /// <value>The menu item checked.</value>
    [Category("States")]
    [SRDescription("The menu item checked style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemChecked => new StyleValue((CommonSkin) this, nameof (MenuItemChecked));

    /// <summary>Gets the menu item checked disabled.</summary>
    /// <value>The menu item checked disabled.</value>
    [Category("States")]
    [SRDescription("The menu item checked disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemCheckedDisabled => new StyleValue((CommonSkin) this, nameof (MenuItemCheckedDisabled));

    /// <summary>Gets the menu item indeterminate.</summary>
    /// <value>The menu item indeterminate.</value>
    [Category("States")]
    [SRDescription("The menu item indeterminate style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemIndeterminate => new StyleValue((CommonSkin) this, nameof (MenuItemIndeterminate));

    /// <summary>Gets the menu item indeterminate disabled.</summary>
    /// <value>The menu item indeterminate disabled.</value>
    [Category("States")]
    [SRDescription("The menu item indeterminate disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue MenuItemIndeterminateDisabled => new StyleValue((CommonSkin) this, nameof (MenuItemIndeterminateDisabled));

    /// <summary>Gets or sets the size of the text image gap.</summary>
    /// <value>The size of the text image gap.</value>
    [Category("Sizes")]
    [SRDescription("The size of the gap between text and image elements.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int TextImageGapSize
    {
      get => this.GetValue<int>(nameof (TextImageGapSize), this.DefaultTextImageGapSize);
      set => this.SetValue(nameof (TextImageGapSize), (object) value);
    }

    /// <summary>
    /// Gets or sets the number of pixels to add to the calculated max image width to allow spacing around images
    /// </summary>
    /// <value>The extra width in pixels added for image area in addition to calculated image width.</value>
    [Category("Sizes")]
    [SRDescription("The extra width in pixels added for image area in addition to calculated image width.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(4)]
    public int MenuItemImageExtraWidth
    {
      get => this.GetValue<int>(nameof (MenuItemImageExtraWidth), 4);
      set => this.SetValue(nameof (MenuItemImageExtraWidth), (object) value);
    }

    /// <summary>Gets or sets the size of the text image gap.</summary>
    /// <value>The size of the text image gap.</value>
    [Category("Sizes")]
    [SRDescription("The padding between the arrow and the end of the menu item.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int ArrowEdgeGapSize
    {
      get => this.GetValue<int>(nameof (ArrowEdgeGapSize), 3);
      set => this.SetValue(nameof (ArrowEdgeGapSize), (object) value);
    }

    /// <summary>Gets the size of the default text image gap.</summary>
    /// <value>The size of the default text image gap.</value>
    private int DefaultTextImageGapSize => 8;

    /// <summary>Gets or sets the size of the text shortcut gap.</summary>
    /// <value>The size of the text shortcut gap.</value>
    [Category("Sizes")]
    [SRDescription("The size of the gap between text and its shortcut.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int TextShortcutGapSize
    {
      get => this.GetValue<int>(nameof (TextShortcutGapSize), 8);
      set => this.SetValue(nameof (TextShortcutGapSize), (object) value);
    }

    /// <summary>Resets the size of the text shortcut gap.</summary>
    internal void ResetTextShortcutGapSize() => this.Reset("TextShortcutGapSize");

    /// <summary>Gets or sets the end size of the spacing.</summary>
    /// <value>The end size of the spacing.</value>
    [Category("Sizes")]
    [SRDescription("The size of the gap between text and menu item arrow.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int TextArrowGapSize
    {
      get => this.GetValue<int>(nameof (TextArrowGapSize), 10);
      set => this.SetValue(nameof (TextArrowGapSize), (object) value);
    }

    /// <summary>Resets the size of the text arrow gap.</summary>
    internal void ResetTextArrowGapSize() => this.Reset("TextArrowGapSize");
  }
}
