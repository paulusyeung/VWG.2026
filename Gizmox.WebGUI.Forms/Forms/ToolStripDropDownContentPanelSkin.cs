// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownContentPanelSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Panel Skin</summary>
  [SkinContainer(typeof (ToolStripDropDownSkin))]
  [Serializable]
  public class ToolStripDropDownContentPanelSkin : PanelSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the scroll up button style.</summary>
    /// <value>The scroll up button style.</value>
    [Category("Styles")]
    [SRDescription("The scroll up button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ScrollUpButtonStyle => new StyleValue((CommonSkin) this, nameof (ScrollUpButtonStyle));

    /// <summary>Gets the scroll up button disabled style.</summary>
    /// <value>The scroll up button disabled style.</value>
    [Category("Styles")]
    [SRDescription("The scroll up button disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ScrollUpButtonDisabledStyle => new StyleValue((CommonSkin) this, nameof (ScrollUpButtonDisabledStyle));

    /// <summary>Gets the scroll down button style.</summary>
    /// <value>The scroll down button style.</value>
    [Category("Styles")]
    [SRDescription("The scroll down button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ScrollDownButtonStyle => new StyleValue((CommonSkin) this, nameof (ScrollDownButtonStyle));

    /// <summary>Gets the scroll down button disabled style.</summary>
    /// <value>The scroll down button disabled style.</value>
    [Category("Styles")]
    [SRDescription("The scroll down button disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ScrollDownButtonDisabledStyle => new StyleValue((CommonSkin) this, nameof (ScrollDownButtonDisabledStyle));

    /// <summary>Gets the height of the scroll up button.</summary>
    /// <value>The height of the scroll up button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int ScrollUpButtonHeight => this.GetMaxImageHeight(9, this.ScrollUpButtonStyle.BackgroundImage.ResourceName, this.ScrollUpButtonDisabledStyle.BackgroundImage.ResourceName);

    /// <summary>Gets the height of the scroll down button.</summary>
    /// <value>The height of the scroll down button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int ScrollDownButtonHeight => this.GetMaxImageHeight(9, this.ScrollDownButtonStyle.BackgroundImage.ResourceName, this.ScrollDownButtonDisabledStyle.BackgroundImage.ResourceName);
  }
}
