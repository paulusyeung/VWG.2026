// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MenuItemSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Menu Item Skin</summary>
  [ToolboxBitmap(typeof (Menu), "MainMenu.bmp")]
  [Serializable]
  public class MenuItemSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the menu item Background LTR.</summary>
    /// <value>The menu item Background LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundStyleValue BackgroundLTR => new BackgroundStyleValue((CommonSkin) this, nameof (BackgroundLTR));

    /// <summary>Gets the menu item Background RTL.</summary>
    /// <value>The menu item Background RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundStyleValue BackgroundRTL => new BackgroundStyleValue((CommonSkin) this, nameof (BackgroundRTL), this.BackgroundLTR);

    /// <summary>Gets the menu item background.</summary>
    /// <value>The background.</value>
    [Category("States")]
    [Description("The menu item Background.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<BackgroundStyleValue> MenuItemBackground => new BidirectionalSkinValue<BackgroundStyleValue>((Skin) this, this.BackgroundLTR, this.BackgroundRTL);

    /// <summary>Gets the menu item seperator row.</summary>
    /// <value>The menu item seperator row.</value>
    [Category("States")]
    [Description("The menu item seperator row style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue MenuItemSeperator => new StyleValue((CommonSkin) this, nameof (MenuItemSeperator));

    /// <summary>Gets the seperator icon column.</summary>
    /// <value>The seperator icon column.</value>
    [Category("States")]
    [Description("The seperator icon column style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SeperatorIconColumn => new StyleValue((CommonSkin) this, nameof (SeperatorIconColumn));

    /// <summary>Gets the menu item normal.</summary>
    /// <value>The menu item normal.</value>
    [Category("States")]
    [Description("The item  normal  style.")]
    public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemNormal => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.MenuItemNormalLTR, this.MenuItemNormalRTL);

    /// <summary>Gets the item row normal LTR style.</summary>
    /// <value>The item row normal LTR style.</value>
    [Category("States")]
    [Description("The item  normal LTR style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemNormalLTR => new TripleCellFrameStyleValue(this.MenuItemNormalLeftLTR, this.MenuItemNormalRightLTR, this.MenuItemNormalCenterLTR);

    /// <summary>Gets the item row normal RTL style.</summary>
    /// <value>The item row normal RTL style.</value>
    [Category("States")]
    [Description("The item  normal RTL style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemNormalRTL => new TripleCellFrameStyleValue(this.MenuItemNormalLeftRTL, this.MenuItemNormalRightRTL, this.MenuItemNormalCenterRTL);

    /// <summary>Gets the item row normal left LTR style.</summary>
    /// <value>The item row normal left LTR style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalLeftLTR => new StyleValue((CommonSkin) this, nameof (MenuItemNormalLeftLTR));

    /// <summary>Gets the item row normal left RTL style.</summary>
    /// <value>The item row normal left RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalLeftRTL => new StyleValue((CommonSkin) this, nameof (MenuItemNormalLeftRTL));

    /// <summary>Gets the menu item normal left.</summary>
    /// <value>The menu item normal left.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemNormalLeft => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemNormalLeftLTR, this.MenuItemNormalLeftRTL);

    /// <summary>Gets the item row normal right LTR style.</summary>
    /// <value>The item row normal right LTR style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalRightLTR => new StyleValue((CommonSkin) this, nameof (MenuItemNormalRightLTR));

    /// <summary>Gets the item row normal right RTL style.</summary>
    /// <value>The item row normal right RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalRightRTL => new StyleValue((CommonSkin) this, nameof (MenuItemNormalRightRTL));

    /// <summary>Gets the menu item normal right.</summary>
    /// <value>The menu item normal right.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemNormalRight => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemNormalRightLTR, this.MenuItemNormalRightRTL);

    /// <summary>Gets the item row normal center LTR style.</summary>
    /// <value>The item row normal center LTR style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalCenterLTR => new StyleValue((CommonSkin) this, nameof (MenuItemNormalCenterLTR));

    /// <summary>Gets the item row normal center RTL style.</summary>
    /// <value>The item row normal center RTL style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemNormalCenterRTL => new StyleValue((CommonSkin) this, nameof (MenuItemNormalCenterRTL));

    /// <summary>Gets the menu item normal center.</summary>
    /// <value>The menu item normal center.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemNormalCenter => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemNormalCenterLTR, this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item hover.</summary>
    /// <value>The menu item hover.</value>
    [Category("States")]
    [Description("The item  hover  style.")]
    public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemHover => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.MenuItemHoverLTR, this.MenuItemHoverRTL);

    /// <summary>Gets the item row hover LTR style.</summary>
    /// <value>The item row hover LTR style.</value>
    [Category("States")]
    [Description("The item  Hover LTR style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemHoverLTR => new TripleCellFrameStyleValue(this.MenuItemHoverLeftLTR, this.MenuItemHoverRightLTR, this.MenuItemHoverCenterLTR);

    /// <summary>Gets the item row hover RTL style.</summary>
    /// <value>The item row hover RTL style.</value>
    [Category("States")]
    [Description("The item  Hover RTL style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemHoverRTL => new TripleCellFrameStyleValue(this.MenuItemHoverLeftRTL, this.MenuItemHoverRightRTL, this.MenuItemHoverCenterRTL);

    /// <summary>Gets the menu item row hover left LTR style.</summary>
    /// <value>The menu item row hover left LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverLeftLTR => new StyleValue((CommonSkin) this, nameof (MenuItemHoverLeftLTR), this.MenuItemNormalLeftLTR);

    /// <summary>Gets the menu item row hover left RTL style.</summary>
    /// <value>The menu item row hover left RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverLeftRTL => new StyleValue((CommonSkin) this, nameof (MenuItemHoverLeftRTL), this.MenuItemNormalLeftRTL);

    /// <summary>Gets the menu item hover left.</summary>
    /// <value>The menu item hover left.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemHoverLeft => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemHoverLeftLTR, this.MenuItemHoverLeftRTL);

    /// <summary>Gets the menu item row hover right LTR style.</summary>
    /// <value>The menu item row hover right LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverRightLTR => new StyleValue((CommonSkin) this, nameof (MenuItemHoverRightLTR), this.MenuItemNormalRightLTR);

    /// <summary>Gets the menu item row hover right RTL style.</summary>
    /// <value>The menu item row hover right RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverRightRTL => new StyleValue((CommonSkin) this, nameof (MenuItemHoverRightRTL), this.MenuItemNormalRightRTL);

    /// <summary>Gets the menu item hover right.</summary>
    /// <value>The menu item hover right.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemHoverRight => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemHoverRightLTR, this.MenuItemHoverRightRTL);

    /// <summary>Gets the menu item row hover center LTR style.</summary>
    /// <value>The menu item row hover center LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverCenterLTR => new StyleValue((CommonSkin) this, nameof (MenuItemHoverCenterLTR), this.MenuItemNormalCenterLTR);

    /// <summary>Gets the menu item row hover center RTL style.</summary>
    /// <value>The menu item row hover center RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemHoverCenterRTL => new StyleValue((CommonSkin) this, nameof (MenuItemHoverCenterRTL), this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item hover center.</summary>
    /// <value>The menu item hover center.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemHoverCenter => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemHoverCenterLTR, this.MenuItemHoverCenterRTL);

    /// <summary>Gets the menu item down.</summary>
    /// <value>The menu item down.</value>
    [Category("States")]
    [Description("The item  down  style.")]
    public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemDown => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.MenuItemDownLTR, this.MenuItemDownRTL);

    /// <summary>Gets the item row down LTR style.</summary>
    /// <value>The item row down LTR style.</value>
    [Category("States")]
    [Description("The item down LTR style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemDownLTR => new TripleCellFrameStyleValue(this.MenuItemDownLeftLTR, this.MenuItemDownRightLTR, this.MenuItemDownCenterLTR);

    /// <summary>Gets the item row down RTL style.</summary>
    /// <value>The item row down RTL style.</value>
    [Category("States")]
    [Description("The item  down RTL style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemDownRTL => new TripleCellFrameStyleValue(this.MenuItemDownLeftRTL, this.MenuItemDownRightRTL, this.MenuItemDownCenterRTL);

    /// <summary>Gets the menu item row down left LTR style.</summary>
    /// <value>The menu item row down left LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownLeftLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDownLeftLTR), this.MenuItemNormalLeftLTR);

    /// <summary>Gets the menu item row down left RTL style.</summary>
    /// <value>The menu item row down left RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownLeftRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDownLeftRTL), this.MenuItemNormalLeftRTL);

    /// <summary>Gets the menu item down left.</summary>
    /// <value>The menu item down Left.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDownLeft => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDownLeftLTR, this.MenuItemDownLeftRTL);

    /// <summary>Gets the menu item row down right LTR style.</summary>
    /// <value>The menu item row down right LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownRightLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDownRightLTR), this.MenuItemNormalRightLTR);

    /// <summary>Gets the menu item row down right style RTL.</summary>
    /// <value>The menu item row down right RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownRightRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDownRightRTL), this.MenuItemNormalRightRTL);

    /// <summary>Gets the menu item down right.</summary>
    /// <value>The menu item down right.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDownRight => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDownRightLTR, this.MenuItemDownRightRTL);

    /// <summary>Gets the menu item row down center style LTR.</summary>
    /// <value>The menu item row down center LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownCenterLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDownCenterLTR), this.MenuItemNormalCenterLTR);

    /// <summary>Gets the menu item row down center style RTL.</summary>
    /// <value>The menu item row down center RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDownCenterRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDownCenterRTL), this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item down center.</summary>
    /// <value>The menu item down center.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDownCenter => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDownCenterLTR, this.MenuItemDownCenterRTL);

    /// <summary>Gets the menu item disable.</summary>
    /// <value>The menu item disable.</value>
    [Category("States")]
    [Description("The item disable style.")]
    public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemDisable => new BidirectionalSkinValue<TripleCellFrameStyleValue>((Skin) this, this.MenuItemDisableLTR, this.MenuItemDisableRTL);

    /// <summary>Gets the item row disable LTR style.</summary>
    /// <value>The item row disable LTR style.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemDisableLTR => new TripleCellFrameStyleValue(this.MenuItemDisableLeftLTR, this.MenuItemDisableRightLTR, this.MenuItemDisableCenterLTR);

    /// <summary>Gets the item row disable RTL style.</summary>
    /// <value>The item row disable RTL style.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(false)]
    public virtual TripleCellFrameStyleValue MenuItemDisableRTL => new TripleCellFrameStyleValue(this.MenuItemDisableLeftRTL, this.MenuItemDisableRightRTL, this.MenuItemDisableCenterRTL);

    /// <summary>Gets the menu item Disable LTR.</summary>
    /// <value>The menu item Disable LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableLeftLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDisableLeftLTR), this.MenuItemNormalLeftLTR);

    /// <summary>Gets the menu item Disable RTL.</summary>
    /// <value>The menu item Disable RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableLeftRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDisableLeftRTL), this.MenuItemNormalLeftRTL);

    /// <summary>Gets the menu item down left.</summary>
    /// <value>The menu item down left.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDisableLeft => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDisableLeftLTR, this.MenuItemDisableLeftRTL);

    /// <summary>Gets the menu item Disable LTR.</summary>
    /// <value>The menu item Disable LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableRightLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDisableRightLTR), this.MenuItemNormalRightLTR);

    /// <summary>Gets the menu item Disable RTL.</summary>
    /// <value>The menu item Disable RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableRightRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDisableRightRTL), this.MenuItemNormalRightRTL);

    /// <summary>Gets the menu item disable right.</summary>
    /// <value>The menu item disable right.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDisableRight => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDisableRightLTR, this.MenuItemDisableRightRTL);

    /// <summary>Gets the menu item Disable LTR.</summary>
    /// <value>The menu item Disable LTr.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableCenterLTR => new StyleValue((CommonSkin) this, nameof (MenuItemDisableCenterLTR), this.MenuItemNormalCenterLTR);

    /// <summary>Gets the menu item Disable RTL.</summary>
    /// <value>The menu item Disable RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemDisableCenterRTL => new StyleValue((CommonSkin) this, nameof (MenuItemDisableCenterRTL), this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item disable center.</summary>
    /// <value>The menu item disable center.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue MenuItemDisableCenter => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemDisableCenterLTR, this.MenuItemDisableCenterRTL);

    /// <summary>Gets the menu item label normal style .</summary>
    /// <value>The menu item label normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Menu item label normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemLabelNormalStyleLTR, this.MenuItemLabelNormalStyleRTL);

    /// <summary>Gets the menu item label normal style LTR.</summary>
    /// <value>The menu item label normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemLabelNormalStyleLTR), this.MenuItemNormalCenterLTR);

    /// <summary>Gets the menu item label normal style RTL.</summary>
    /// <value>The menu item label normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemLabelNormalStyleRTL), this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item label hover style .</summary>
    /// <value>The menu item label hover style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Menu item label hover style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemLabelHoverStyleLTR, this.MenuItemLabelHoverStyleRTL);

    /// <summary>Gets the menu item label hover style LTR.</summary>
    /// <value>The menu item label hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemLabelHoverStyleLTR), this.MenuItemLabelNormalStyleLTR);

    /// <summary>Gets the menu item label hover style RTL.</summary>
    /// <value>The menu item label hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemLabelHoverStyleRTL), this.MenuItemLabelNormalStyleRTL);

    /// <summary>Gets the menu item label down style .</summary>
    /// <value>The menu item label down style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Menu item label down style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelDownStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemLabelDownStyleLTR, this.MenuItemLabelDownStyleRTL);

    /// <summary>Gets the menu item label down style LTR.</summary>
    /// <value>The menu item label down style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelDownStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemLabelDownStyleLTR), this.MenuItemLabelNormalStyleLTR);

    /// <summary>Gets the menu item label down style RTL.</summary>
    /// <value>The menu item label down style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelDownStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemLabelDownStyleRTL), this.MenuItemLabelNormalStyleRTL);

    /// <summary>Gets the menu item label Disable style .</summary>
    /// <value>The menu item label Disable style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Menu item label disable style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelDisableStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemLabelDisableStyleLTR, this.MenuItemLabelDisableStyleRTL);

    /// <summary>Gets the menu item label disable style LTR.</summary>
    /// <value>The menu item label disable style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelDisableStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemLabelDisableStyleLTR), this.MenuItemLabelNormalStyleLTR);

    /// <summary>Gets the menu item label disable style RTL.</summary>
    /// <value>The menu item label disable style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemLabelDisableStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemLabelDisableStyleRTL), this.MenuItemLabelNormalStyleRTL);

    /// <summary>Gets the menu item Icon LTR Padding.</summary>
    /// <value>The menu item Icon LTR Padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual PaddingValue MenuItemIconPaddingLTR
    {
      get => this.GetValue<PaddingValue>(nameof (MenuItemIconPaddingLTR), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(2, 3, 0, 0)));
      set => this.SetValue(nameof (MenuItemIconPaddingLTR), (object) value);
    }

    /// <summary>Gets the menu item Icon RTL Padding.</summary>
    /// <value>The menu item Icon RTL Padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual PaddingValue MenuItemIconPaddingRTL
    {
      get => this.GetValue<PaddingValue>(nameof (MenuItemIconPaddingRTL), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 3, 2, 0)));
      set => this.SetValue(nameof (MenuItemIconPaddingRTL), (object) value);
    }

    /// <summary>Gets the menu item Icon Padding.</summary>
    /// <value>The menu item Icon Padding.</value>
    [Category("Padding")]
    [Description("The menu item Icon Padding.")]
    public BidirectionalSkinValue<PaddingValue> MenuItemIconPadding => new BidirectionalSkinValue<PaddingValue>((Skin) this, this.MenuItemIconPaddingLTR, this.MenuItemIconPaddingRTL);

    /// <summary>Gets the menu item arrow LTR Padding.</summary>
    /// <value>The menu item arrow LTR Padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual PaddingValue MenuItemArrowPaddingLTR
    {
      get => this.GetValue<PaddingValue>(nameof (MenuItemArrowPaddingLTR), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 7, 2, 0)));
      set => this.SetValue(nameof (MenuItemArrowPaddingLTR), (object) value);
    }

    /// <summary>Gets the menu item arrow RTL Padding.</summary>
    /// <value>The menu item arrow RTL Padding.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual PaddingValue MenuItemArrowPaddingRTL
    {
      get => this.GetValue<PaddingValue>(nameof (MenuItemArrowPaddingRTL), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 7, 2, 0)));
      set => this.SetValue(nameof (MenuItemArrowPaddingRTL), (object) value);
    }

    /// <summary>Gets the menu item arrow Bidirectional style.</summary>
    /// <value>The menu item arrow Bidirectional style.</value>
    [Category("Padding")]
    [Description("The menu item arrow Padding.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinValue<PaddingValue> MenuItemArrowPadding => new BidirectionalSkinValue<PaddingValue>((Skin) this, this.MenuItemArrowPaddingLTR, this.MenuItemArrowPaddingRTL);

    /// <summary>Gets the menu item Shortcut normal style .</summary>
    /// <value>The menu item Shortcut normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BidirectionalSkinValue<StyleValue> MenuItemShortcutNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemShortcutNormalStyleLTR, this.MenuItemShortcutNormalStyleRTL);

    /// <summary>Gets the menu item shortcut normal style LTR.</summary>
    /// <value>The menu item shortcut normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutNormalStyleLTR), this.MenuItemNormalCenterLTR);

    /// <summary>Gets the menu item shortcut normal style RTL.</summary>
    /// <value>The menu item shortcut normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutNormalStyleRTL), this.MenuItemNormalCenterRTL);

    /// <summary>Gets the menu item Shortcut hover style .</summary>
    /// <value>The menu item Shortcut hover style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual SkinValue MenuItemShortcutHoverStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemShortcutHoverStyleLTR, this.MenuItemShortcutHoverStyleRTL);

    /// <summary>Gets the menu item shortcut hover style LTR.</summary>
    /// <value>The menu item shortcut hover style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutHoverStyleLTR), this.MenuItemShortcutNormalStyleLTR);

    /// <summary>Gets the menu item shortcut hover style RTL.</summary>
    /// <value>The menu item shortcut hover style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutHoverStyleRTL), this.MenuItemShortcutNormalStyleRTL);

    /// <summary>Gets the menu item Shortcut down style .</summary>
    /// <value>The menu item Shortcut down style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual SkinValue MenuItemShortcutDownStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemShortcutDownStyleLTR, this.MenuItemShortcutDownStyleRTL);

    /// <summary>Gets the menu item shortcut down style LTR.</summary>
    /// <value>The menu item shortcut down style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutDownStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutDownStyleLTR), this.MenuItemShortcutNormalStyleLTR);

    /// <summary>Gets the menu item shortcut down style RTL.</summary>
    /// <value>The menu item shortcut down style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutDownStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutDownStyleRTL), this.MenuItemShortcutNormalStyleRTL);

    /// <summary>Gets the menu item Shortcut Disable style .</summary>
    /// <value>The menu item Shortcut Disable style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual SkinValue MenuItemShortcutDisableStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.MenuItemShortcutDisableStyleLTR, this.MenuItemShortcutDisableStyleRTL);

    /// <summary>Gets the menu item shortcut disable style LTR.</summary>
    /// <value>The menu item shortcut disable style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutDisableStyleLTR => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutDisableStyleLTR), this.MenuItemShortcutNormalStyleLTR);

    /// <summary>Gets the menu item shortcut disable style RTL.</summary>
    /// <value>The menu item shortcut disable style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue MenuItemShortcutDisableStyleRTL => new StyleValue((CommonSkin) this, nameof (MenuItemShortcutDisableStyleRTL), this.MenuItemShortcutNormalStyleRTL);

    /// <summary>Gets or sets the height of the item.</summary>
    /// <value>The height of the item.</value>
    [Category("Sizes")]
    [Description("The height of a item.")]
    public int Height
    {
      get => this.GetValue<int>(nameof (Height), this.DefaultItemHeight);
      set => this.SetValue(nameof (Height), (object) value);
    }

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetItemHeight() => this.Reset("Height");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultItemHeight => 22;

    /// <summary>Gets or sets the height of the seperator.</summary>
    /// <value>The height of the seperator.</value>
    [Category("Sizes")]
    [Description("The height of the seperator.")]
    public int SeperatorHeight
    {
      get => this.GetValue<int>("SeperatorRowHeight", this.DefaultSeperatorRowHeight);
      set => this.SetValue("SeperatorRowHeight", (object) value);
    }

    /// <summary>Resets the seperator row height</summary>
    internal void ResetSeperatorRowHeight() => this.Reset("SeperatorRowHeight");

    /// <summary>Gets default Seperator row height</summary>
    protected virtual int DefaultSeperatorRowHeight => 6;

    /// <summary>Gets the arrow image width LTR.</summary>
    /// <value>The arrow image width LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int ArrowImageWidthLTR => this.GetImageWidth(this.ArrowImageLTR, 7);

    /// <summary>Gets the arrow image width RTL.</summary>
    /// <value>The arrow image width RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal int ArrowImageWidthRTL => this.GetImageWidth(this.ArrowImageRTL, 7);

    /// <summary>Gets the width of the arrow image.</summary>
    /// <value>The width of the arrow image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SkinValue ArrowImageWidth => (SkinValue) new BidirectionalSkinValue<int>((Skin) this, this.ArrowImageWidthLTR, this.ArrowImageWidthRTL);

    /// <summary>Gets the width of the menu item icons column.</summary>
    /// <value>The width of the menu item icons column.</value>
    [Category("Sizes")]
    [Description("The width of the menu item icons column.")]
    public int MenuItemIconsColumnWidth
    {
      get => this.GetValue<int>(nameof (MenuItemIconsColumnWidth), this.DefaultMenuItemIconsColumnWidth);
      set => this.SetValue(nameof (MenuItemIconsColumnWidth), (object) value);
    }

    /// <summary>Resets the width of the menu item icons column.</summary>
    internal void ResetMenuItemIconsColumnWidth() => this.Reset("MenuItemIconsColumnWidth");

    /// <summary>Gets the default width of the menu item icons column.</summary>
    /// <value>The default width of the menu item icons column.</value>
    protected virtual int DefaultMenuItemIconsColumnWidth => 32;

    /// <summary>Gets the menu item highlight left width LTR.</summary>
    /// <value>The menu item highlight left width LTR.</value>
    [Category("Sizes")]
    [Description("The width of the LTR menu item Highlight Left column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int MenuItemHighlightLeftWidthLTR => this.GetImageWidth(this.MenuItemHoverLTR.LeftStyle.BackgroundImage);

    /// <summary>Gets the menu item highlight left width RTL.</summary>
    /// <value>The menu item highlight left width RTL.</value>
    [Category("Sizes")]
    [Description("The width of the RTL menu item Highlight Left column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int MenuItemHighlightLeftWidthRTL => this.GetImageWidth(this.MenuItemHoverRTL.LeftStyle.BackgroundImage);

    /// <summary>
    /// Gets the width of the menu item Highlight Left column Width
    /// </summary>
    /// <value>The width of the menu item Highlight Left column Width.</value>
    [Category("Sizes")]
    [Description("The width of the menu item Highlight Left column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public BidirectionalSkinProperty<int> MenuItemHighlightLeftWidth => new BidirectionalSkinProperty<int>((Skin) this, "MenuItemHighlightLeftWidthLTR", "MenuItemHighlightLeftWidthRTL");

    /// <summary>Gets the menu item highlight right width LTR.</summary>
    /// <value>The menu item highlight right width LTR.</value>
    [Category("Sizes")]
    [Description("The width of the LTR menu item Highlight Right column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int MenuItemHighlightRightWidthLTR => this.GetImageWidth(this.MenuItemHoverLTR.RightStyle.BackgroundImage);

    /// <summary>Gets the menu item highlight right width RTL.</summary>
    /// <value>The menu item highlight right width RTL.</value>
    [Category("Sizes")]
    [Description("The width of the RTL menu item Highlight Right column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int MenuItemHighlightRightWidthRTL => this.GetImageWidth(this.MenuItemHoverRTL.RightStyle.BackgroundImage);

    /// <summary>
    /// Gets the width of the menu item Highlight Right column Width
    /// </summary>
    /// <value>The width of the menu item Highlight Right column Width.</value>
    [Category("Sizes")]
    [Description("The width of the menu item Highlight Right column Width")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public BidirectionalSkinProperty<int> MenuItemHighlightRightWidth => new BidirectionalSkinProperty<int>((Skin) this, "MenuItemHighlightRightWidthLTR", "MenuItemHighlightRightWidthRTL");

    /// <summary>Gets or sets menu item the checked image.</summary>
    /// <value>The checked image.</value>
    [Description("Menu item checked image")]
    [Category("Images")]
    public ImageResourceReference CheckedImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedImage), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "Checked.gif"));
      set => this.SetValue(nameof (CheckedImage), (object) value);
    }

    /// <summary>Resets the height of the menu.</summary>
    internal void ResetCheckedImage() => this.Reset("CheckedImage");

    /// <summary>Gets or sets menu item the checked Disable image.</summary>
    /// <value>The checked Disable image.</value>
    [Description("Menu item checked Disable image")]
    [Category("Images")]
    public ImageResourceReference CheckedImageDisable
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedImageDisable), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "CheckedDisabled.gif"));
      set => this.SetValue(nameof (CheckedImageDisable), (object) value);
    }

    /// <summary>Gets or sets the radio checked image.</summary>
    /// <value>The radio checked image.</value>
    [Description("Menu item radio checked image")]
    [Category("Images")]
    public ImageResourceReference RadioCheckedImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (RadioCheckedImage), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "RadioChecked.gif"));
      set => this.SetValue(nameof (RadioCheckedImage), (object) value);
    }

    /// <summary>Gets or sets the radio checked Disable image.</summary>
    /// <value>The radio checked Disable image.</value>
    [Description("Menu item radio checked Disable image")]
    [Category("Images")]
    public ImageResourceReference RadioCheckedImageDisable
    {
      get => this.GetValue<ImageResourceReference>(nameof (RadioCheckedImageDisable), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "RadioCheckedDisabled.gif"));
      set => this.SetValue(nameof (RadioCheckedImageDisable), (object) value);
    }

    /// <summary>Gets or sets the arrow image LTR.</summary>
    /// <value>The arrow image LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference ArrowImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (ArrowImageLTR), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "ArrowLTR.gif"));
      set => this.SetValue(nameof (ArrowImageLTR), (object) value);
    }

    /// <summary>Gets or sets the arrow image RTL.</summary>
    /// <value>The arrow image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImageResourceReference ArrowImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (ArrowImageRTL), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "ArrowRTL.gif"));
      set => this.SetValue(nameof (ArrowImageRTL), (object) value);
    }

    /// <summary>Gets or sets the arrow image Bidirectional.</summary>
    /// <value>The arrow image Bidirectional.</value>
    [Category("Images")]
    [Description("The menu item arrow image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> ArrowImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "ArrowImageLTR", "ArrowImageRTL");

    /// <summary>Gets or sets the arrow Disable image LTR.</summary>
    /// <value>The arrow image Disable LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageResourceReference ArrowImageLTRDisabled
    {
      get => this.GetValue<ImageResourceReference>(nameof (ArrowImageLTRDisabled), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "ArrowLTRDisabled.gif"));
      set => this.SetValue(nameof (ArrowImageLTRDisabled), (object) value);
    }

    /// <summary>Gets or sets the arrow Disable image RTL.</summary>
    /// <value>The arrow Disable image RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageResourceReference ArrowImageRTLDisabled
    {
      get => this.GetValue<ImageResourceReference>(nameof (ArrowImageRTLDisabled), (ImageResourceReference) (string) new ImageResourceReference(typeof (MenuItemSkin), "ArrowRTLDisabled.gif"));
      set => this.SetValue(nameof (ArrowImageRTLDisabled), (object) value);
    }

    /// <summary>Gets or sets the arrow Disable image Bidirectional.</summary>
    /// <value>The arrow Disable image Bidirectional.</value>
    [Category("Images")]
    [Description("The menu item disable arrow image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> ArrowImageDisabled => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "ArrowImageLTRDisabled", "ArrowImageRTLDisabled");

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageResourceReference BackgroundImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (BackgroundImage), (ImageResourceReference) "");
      set => this.SetValue(nameof (BackgroundImage), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BackgroundImageRepeat BackgroundImageRepeat
    {
      get => this.GetValue<BackgroundImageRepeat>(nameof (BackgroundImageRepeat), BackgroundImageRepeat.Repeat);
      set => this.SetValue(nameof (BackgroundImageRepeat), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BackgroundImagePosition BackgroundImagePosition
    {
      get => this.GetValue<BackgroundImagePosition>(nameof (BackgroundImagePosition), BackgroundImagePosition.MiddleCenter);
      set => this.SetValue(nameof (BackgroundImagePosition), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderWidth BorderWidth
    {
      get => base.BorderWidth;
      set => base.BorderWidth = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderColor BorderColor
    {
      get => base.BorderColor;
      set => base.BorderColor = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(nameof (BorderStyle), BorderStyle.FixedSingle);
      set => this.SetValue(nameof (BorderStyle), (object) value);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override MarginValue Margin
    {
      get => base.Margin;
      set => base.Margin = value;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override PaddingValue Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }
  }
}
