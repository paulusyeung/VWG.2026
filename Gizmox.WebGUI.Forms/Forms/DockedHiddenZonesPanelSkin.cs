// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedHiddenZonesPanelSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>DockedHiddenZonesPanel Skin</summary>
  [SkinContainer(typeof (DockingManagerSkin))]
  [Serializable]
  public class DockedHiddenZonesPanelSkin : PanelSkin
  {
    private HiddenZoneItemProperties mobjHiddenZoneItemProperties;

    /// <summary>Gets the font When the button is focused.</summary>
    /// <value>The font focused.</value>
    [Browsable(false)]
    public Font FontData => this.HiddenZoneItemStyle.Font;

    /// <summary>Gets the hidden zone item properties object.</summary>
    public HiddenZoneItemProperties HiddenZoneItem
    {
      get
      {
        if (this.mobjHiddenZoneItemProperties == null)
          this.mobjHiddenZoneItemProperties = new HiddenZoneItemProperties(this);
        return this.mobjHiddenZoneItemProperties;
      }
    }

    /// <summary>Gets the drop down arrow image style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneItemHoverStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneItemHoverStyle));

    /// <summary>Gets the drop down arrow image style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZonePopUpStyle => new StyleValue((CommonSkin) this, nameof (HiddenZonePopUpStyle));

    /// <summary>Gets the hidden zone scroller bottom hover style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerBottomHoverStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerBottomHoverStyle));

    /// <summary>Gets the hidden zone scroller bottom pressed style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerBottomPressedStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerBottomPressedStyle));

    /// <summary>Gets the hidden zone scroller bottom style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerBottomStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerBottomStyle));

    /// <summary>Gets the hidden zone scroller left hover style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerLeftHoverStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerLeftHoverStyle));

    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerLeftPressedStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerLeftPressedStyle));

    /// <summary>Gets the hidden zone scroller left style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerLeftStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerLeftStyle));

    /// <summary>Gets the hidden zone scroller right hover style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerRightHoverStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerRightHoverStyle));

    /// <summary>Gets the hidden zone scroller right pressed style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerRightPressedStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerRightPressedStyle));

    /// <summary>Gets the hidden zone scroller right style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerRightStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerRightStyle));

    /// <summary>Gets the hidden zone scroller top hover style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerTopHoverStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerTopHoverStyle));

    /// <summary>Gets the hidden zone scroller top pressed style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerTopPressedStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerTopPressedStyle));

    /// <summary>Gets the hidden zone scroller top style.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue HiddenZoneScrollerTopStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneScrollerTopStyle));

    /// <summary>Gets the height of the left right center content.</summary>
    /// <value>The height of the left right center content.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int LeftRightContentWidth => this.PanelThickness - this.LeftRightPanelsPadding.Left - this.LeftRightPanelsPadding.Right;

    /// <summary>Gets or sets the left right panels padding.</summary>
    /// <value>The left right panels padding.</value>
    [SRDescription("ControlPaddingDescr")]
    [Category("Layout")]
    public PaddingValue LeftRightPanelsPadding
    {
      get => this.GetValue<PaddingValue>(nameof (LeftRightPanelsPadding), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)));
      set => this.SetValue(nameof (LeftRightPanelsPadding), (object) value);
    }

    /// <summary>Gets or sets the panel item thickness.</summary>
    /// <value>The panel item thickness.</value>
    public int PanelItemThickness
    {
      get => this.GetValue<int>(nameof (PanelItemThickness), 100);
      set => this.SetValue(nameof (PanelItemThickness), (object) value);
    }

    /// <summary>Gets or sets the panel thickness.</summary>
    /// <value>The panel thickness.</value>
    public int PanelThickness
    {
      get => this.GetValue<int>(nameof (PanelThickness), 22);
      set => this.SetValue(nameof (PanelThickness), (object) value);
    }

    /// <summary>Gets or sets the scroller thickness.</summary>
    /// <value>The scroller thickness.</value>
    public int ScrollerThickness
    {
      get => this.GetValue<int>(nameof (ScrollerThickness), 22);
      set => this.SetValue(nameof (ScrollerThickness), (object) value);
    }

    /// <summary>Gets the height of the top bottom center content.</summary>
    /// <value>The height of the top bottom center content.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int TopBottomContentHeight => this.PanelThickness - this.TopBottomPanelsPadding.Top - this.TopBottomPanelsPadding.Bottom - this.HiddenZoneItemStyle.BorderWidth.Top - this.HiddenZoneItemStyle.BorderWidth.Bottom;

    /// <summary>Gets or sets the top bottom panels padding.</summary>
    /// <value>The top bottom panels padding.</value>
    [SRDescription("ControlPaddingDescr")]
    [Category("Layout")]
    public PaddingValue TopBottomPanelsPadding
    {
      get => this.GetValue<PaddingValue>(nameof (TopBottomPanelsPadding), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)));
      set => this.SetValue(nameof (TopBottomPanelsPadding), (object) value);
    }

    private void InitializeComponent()
    {
    }

    /// <summary>
    /// Gets the width of the top bottom hidden zone item image.
    /// </summary>
    /// <value>The width of the top bottom hidden zone item image.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HiddenZoneItemImageWidth => this.HiddenZoneItemImageSize.Width;

    /// <summary>
    /// Gets the height of the top bottom hidden zone item image.
    /// </summary>
    /// <value>The height of the top bottom hidden zone item image.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HiddenZoneItemImageHeight => this.HiddenZoneItemImageSize.Height;

    /// <summary>
    /// Gets or sets the size of the top bottom hidden zone item image.
    /// </summary>
    /// <value>The size of the top bottom hidden zone item image.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size HiddenZoneItemImageSize
    {
      get => this.GetValue<Size>(nameof (HiddenZoneItemImageSize), new Size(this.TopBottomContentHeight, this.TopBottomContentHeight));
      set => this.SetValue(nameof (HiddenZoneItemImageSize), (object) value);
    }

    /// <summary>Gets or sets the hidden zone item expantion delay.</summary>
    /// <value>The hidden zone item expantion delay.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HiddenZoneItemExpantionDelay
    {
      get => this.GetValue<int>(nameof (HiddenZoneItemExpantionDelay), 500);
      set => this.SetValue(nameof (HiddenZoneItemExpantionDelay), (object) value);
    }

    /// <summary>
    /// Gets or sets the width of the hidden zone item expantion.
    /// </summary>
    /// <value>The width of the hidden zone item expantion.</value>
    public int HiddenZoneItemExpantionWidth
    {
      get => this.GetValue<int>(nameof (HiddenZoneItemExpantionWidth), 300);
      set => this.SetValue(nameof (HiddenZoneItemExpantionWidth), (object) value);
    }

    /// <summary>
    /// Gets or sets the duration of the hidden zone item expantion animation.
    /// </summary>
    /// <value>The duration of the hidden zone item expantion animation.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HiddenZoneItemExpantionAnimationDuration
    {
      get => this.GetValue<int>(nameof (HiddenZoneItemExpantionAnimationDuration), 500);
      set => this.SetValue(nameof (HiddenZoneItemExpantionAnimationDuration), (object) value);
    }

    /// <summary>Gets the drop down arrow image style.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue HiddenZoneItemStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneItemStyle));

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int HiddenZoneItemStyleVerticalPadding => this.HiddenZoneItemStyle.Padding.Vertical + this.HiddenZoneItemStyle.Border.Width.Top + this.HiddenZoneItemStyle.Border.Width.Bottom;

    internal int HiddenZoneItemStyleHorizontalPadding => this.HiddenZoneItemStyle.Padding.Horizontal;

    /// <summary>Gets the hidden zone item container vertical style.</summary>
    /// <value>The hidden zone item container vertical style.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue HiddenZoneItemContainerVerticalStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneItemContainerVerticalStyle));

    /// <summary>Gets the hidden zone item container horizontal style.</summary>
    /// <value>The hidden zone item container horizontal style.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue HiddenZoneItemContainerHorizontalStyle => new StyleValue((CommonSkin) this, nameof (HiddenZoneItemContainerHorizontalStyle));
  }
}
