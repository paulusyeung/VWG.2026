// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FlatButtonAppearance
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides properties that specify the appearance of <see cref="T:Gizmox.WebGUI.Forms.Button"></see> controls whose <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>.</summary>
  [TypeConverter(typeof (FlatButtonAppearanceConverter))]
  public class FlatButtonAppearance
  {
    /// <summary>
    /// 
    /// </summary>
    private ButtonBase mobjOwner;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FlatButtonAppearance" /> class.
    /// </summary>
    /// <param name="objOwner">The owner.</param>
    internal FlatButtonAppearance(ButtonBase objOwner) => this.mobjOwner = objOwner;

    /// <summary>Gets or sets the color of the border around the button.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the border around the button.</returns>
    [DefaultValue(typeof (Color), "")]
    [NotifyParentProperty(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonBorderColorDescr")]
    public Color BorderColor
    {
      get => (Color) this.mobjOwner.BorderColor;
      set => this.mobjOwner.BorderColor = (Gizmox.WebGUI.Forms.BorderColor) value;
    }

    /// <summary>Gets or sets a value that specifies the size, in pixels, of the border around the button.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the size, in pixels, of the border around the button.</returns>
    [Browsable(true)]
    [DefaultValue(1)]
    [NotifyParentProperty(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonBorderSizeDescr")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public int BorderSize
    {
      get => (int) this.mobjOwner.BorderWidth;
      set => this.mobjOwner.BorderWidth = (BorderWidth) value;
    }

    /// <summary>Gets or sets the color of the client area of the button when the button is checked and the mouse pointer is outside the bounds of the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(typeof (Color), "")]
    [NotifyParentProperty(true)]
    [SRDescription("ButtonCheckedBackColorDescr")]
    [Browsable(true)]
    [SRCategory("CatAppearance")]
    public Color CheckedBackColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the color of the client area of the button when the mouse is pressed within the bounds of the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
    [SRCategory("CatAppearance")]
    [DefaultValue(typeof (Color), "")]
    [Browsable(true)]
    [NotifyParentProperty(true)]
    [SRDescription("ButtonMouseDownBackColorDescr")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color MouseDownBackColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the color of the client area of the button when the mouse pointer is within the bounds of the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
    [Browsable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonMouseOverBackColorDescr")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [NotifyParentProperty(true)]
    [DefaultValue(typeof (Color), "")]
    public Color MouseOverBackColor
    {
      get => Color.Empty;
      set
      {
      }
    }
  }
}
