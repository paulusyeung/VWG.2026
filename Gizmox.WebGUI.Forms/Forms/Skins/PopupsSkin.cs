// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.PopupsSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides loading customization capabilities</summary>
  [ToolboxBitmap(typeof (ImageList))]
  public class PopupsSkin : CommonSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the popup frame style.</summary>
    /// <value>The popup frame style.</value>
    public FrameStyleValue FrameStyle => new FrameStyleValue(this.LeftBottomStyle, this.LeftStyle, this.LeftTopStyle, this.TopStyle, this.RightTopStyle, this.RightStyle, this.RightBottomStyle, this.BottomStyle, this.CenterStyle);

    /// <summary>Gets or sets the height of the top frame.</summary>
    /// <value>The height of the top frame.</value>
    [Category("Sizes")]
    [Description("The height of the top frame.")]
    public int TopFrameHeight
    {
      get => this.GetValue<int>(nameof (TopFrameHeight), this.GetImageWidth(this.LeftTopStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (TopFrameHeight), (object) value);
    }

    /// <summary>Gets or sets the width of the right frame.</summary>
    /// <value>The width of the right frame.</value>
    [Category("Sizes")]
    [Description("The width of the right frame.")]
    public int RightFrameWidth
    {
      get => this.GetValue<int>(nameof (RightFrameWidth), this.GetImageWidth(this.RightTopStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (RightFrameWidth), (object) value);
    }

    /// <summary>Gets or sets the height of the bottom frame.</summary>
    /// <value>The height of the bottom frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom frame.")]
    public int BottomFrameHeight
    {
      get => this.GetValue<int>(nameof (BottomFrameHeight), this.GetImageWidth(this.LeftBottomStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (BottomFrameHeight), (object) value);
    }

    /// <summary>Gets or sets the width of the left frame.</summary>
    /// <value>The width of the left frame.</value>
    [Category("Sizes")]
    [Description("The width of the left frame.")]
    public int LeftFrameWidth
    {
      get => this.GetValue<int>(nameof (LeftFrameWidth), this.GetImageWidth(this.LeftBottomStyle.BackgroundImage, 0));
      set => this.SetValue(nameof (LeftFrameWidth), (object) value);
    }

    /// <summary>Gets the popup left top style.</summary>
    /// <value>The popup left top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftTopStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopStyle));

    /// <summary>Gets the popup top style.</summary>
    /// <value>The popup top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue TopStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopStyle));

    /// <summary>Gets the popup right top style.</summary>
    /// <value>The popup right top style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightTopStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopStyle));

    /// <summary>Gets the popup left style.</summary>
    /// <value>The popup left style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftStyle));

    /// <summary>Gets the popup right style.</summary>
    /// <value>The popup right style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightStyle));

    /// <summary>Gets the popup left bottom style.</summary>
    /// <value>The popup left bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue LeftBottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomStyle));

    /// <summary>Gets the center style.</summary>
    /// <value>The center style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue CenterStyle => new StyleValue((CommonSkin) this, nameof (CenterStyle));

    /// <summary>Gets the popup bottom style.</summary>
    /// <value>The popup bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue BottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomStyle));

    /// <summary>Gets the popup right bottom style.</summary>
    /// <value>The popup right bottom style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FramePartStyleValue RightBottomStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomStyle));

    /// <summary>Gets or sets the content padding.</summary>
    /// <value>The content padding.</value>
    [Description("The popup's content padding")]
    [Category("Layout")]
    public virtual PaddingValue ContentPadding
    {
      get => this.GetValue<PaddingValue>(nameof (ContentPadding), PaddingValue.Empty);
      set => this.SetValue(nameof (ContentPadding), (object) value);
    }

    /// <summary>Gets the box shadow popup offset.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string BoxShadowPopupOffset
    {
      get
      {
        string str1 = "0";
        string str2 = "0";
        string str3 = "0";
        string str4 = "0";
        if (this.CenterStyle.BorderStyle != BorderStyle.None)
        {
          int num = this.CenterStyle.BorderWidth.Left;
          str1 = num.ToString();
          num = this.CenterStyle.BorderWidth.Top;
          str2 = num.ToString();
          num = this.CenterStyle.BorderWidth.Right;
          str3 = num.ToString();
          num = this.CenterStyle.BorderWidth.Bottom;
          str4 = num.ToString();
        }
        return string.Format("{0} {1} {2} {3}", (object) str2, (object) str3, (object) str4, (object) str1);
      }
    }
  }
}
