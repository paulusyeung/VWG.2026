// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HiddenZoneItemProperties
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (ExpandableObjectConverter))]
  public class HiddenZoneItemProperties
  {
    private DockedHiddenZonesPanelSkin mobjHiddenZonePanelSkin;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HiddenZoneItemProperties" /> class.
    /// </summary>
    /// <param name="objHiddenZonePanelSkin">The obj hidden zone panel skin.</param>
    public HiddenZoneItemProperties(DockedHiddenZonesPanelSkin objHiddenZonePanelSkin) => this.mobjHiddenZonePanelSkin = objHiddenZonePanelSkin;

    /// <summary>Gets the item container vertical style.</summary>
    /// <value>The item container vertical style.</value>
    public StyleValue ItemContainerVerticalStyle => this.mobjHiddenZonePanelSkin.HiddenZoneItemContainerVerticalStyle;

    /// <summary>Gets the item container horizontal style.</summary>
    /// <value>The item container horizontal style.</value>
    public StyleValue ItemContainerHorizontalStyle => this.mobjHiddenZonePanelSkin.HiddenZoneItemContainerHorizontalStyle;

    /// <summary>Gets or sets the duration of the animation.</summary>
    /// <value>The duration of the animation.</value>
    public int AnimationDuration
    {
      get => this.mobjHiddenZonePanelSkin.HiddenZoneItemExpantionAnimationDuration;
      set => this.mobjHiddenZonePanelSkin.HiddenZoneItemExpantionAnimationDuration = value;
    }

    /// <summary>Gets or sets the expantion delay.</summary>
    /// <value>The expantion delay.</value>
    public int ExpantionDelay
    {
      get => this.mobjHiddenZonePanelSkin.HiddenZoneItemExpantionDelay;
      set => this.mobjHiddenZonePanelSkin.HiddenZoneItemExpantionDelay = value;
    }

    /// <summary>
    /// Gets or sets the size of the horizontal panels item image.
    /// </summary>
    /// <value>The size of the horizontal panels item image.</value>
    public Size HorizontalPanelsItemImageSize
    {
      get => this.mobjHiddenZonePanelSkin.HiddenZoneItemImageSize;
      set => this.mobjHiddenZonePanelSkin.HiddenZoneItemImageSize = value;
    }

    /// <summary>Gets the item style.</summary>
    public StyleValue ItemStyle => this.mobjHiddenZonePanelSkin.HiddenZoneItemStyle;
  }
}
