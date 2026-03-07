// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.UpDownBaseSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>UpDown Base Skin</summary>
  [ToolboxBitmap(typeof (DomainUpDown), "DomainUpDown.bmp")]
  [Serializable]
  public class UpDownBaseSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the buttons' normal container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons normal container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerNormalStyleLTR, this.ButtonsContainerNormalStyleRTL);

    /// <summary>Gets the buttons container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerNormalStyleLTR));

    /// <summary>Gets the buttons container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerNormalStyleRTL));

    /// <summary>Gets The buttons hover container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons hover container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerHoverStyleLTR, this.ButtonsContainerHoverStyleRTL);

    /// <summary>Gets the buttons container hover style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerHoverStyleLTR));

    /// <summary>Gets the buttons container hover style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerHoverStyleRTL));

    /// <summary>Gets The buttons pressed container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons pressed container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerPressedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerPressedStyleLTR, this.ButtonsContainerPressedStyleRTL);

    /// <summary>Gets the buttons container pressed style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerPressedStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerPressedStyleLTR));

    /// <summary>Gets the buttons container pressed style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerPressedStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerPressedStyleRTL));

    /// <summary>Gets down normal style.</summary>
    /// <value>Down normal style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Lower image Normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue DownNormalStyle => new StyleValue((CommonSkin) this, nameof (DownNormalStyle));

    /// <summary>Gets down over style.</summary>
    /// <value>Down over style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Lower image Over style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue DownOverStyle => new StyleValue((CommonSkin) this, nameof (DownOverStyle), this.DownNormalStyle);

    /// <summary>Gets down down style.</summary>
    /// <value>Down down style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Lower image Down style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue DownDownStyle => new StyleValue((CommonSkin) this, nameof (DownDownStyle), this.DownNormalStyle);

    /// <summary>Gets up normal style.</summary>
    /// <value>Up normal style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Upper image Normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue UpNormalStyle => new StyleValue((CommonSkin) this, nameof (UpNormalStyle));

    /// <summary>Gets up over style.</summary>
    /// <value>Up over style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Upper image Over style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue UpOverStyle => new StyleValue((CommonSkin) this, nameof (UpOverStyle), this.UpNormalStyle);

    /// <summary>Gets up down style.</summary>
    /// <value>Up down style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("Upper image down style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue UpDownStyle => new StyleValue((CommonSkin) this, nameof (UpDownStyle), this.UpNormalStyle);

    /// <summary>Gets or sets the width of the image cell.</summary>
    /// <value>The width of the image cell.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The image cell width.")]
    public int ImageCellWidth
    {
      get => this.GetValue<int>(nameof (ImageCellWidth), 15);
      set => this.SetValue(nameof (ImageCellWidth), (object) value);
    }
  }
}
