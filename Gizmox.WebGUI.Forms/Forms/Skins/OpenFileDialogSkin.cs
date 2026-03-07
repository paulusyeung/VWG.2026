// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.OpenFileDialogSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>OpenFileDialog Skin</summary>
  [ToolboxBitmap(typeof (OpenFileDialog), "OpenFileDialog.bmp")]
  [Serializable]
  public class OpenFileDialogSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the uploading image.</summary>
    /// <value>The uploading image.</value>
    [Category("Images")]
    [Description("Uploading animation image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference UploadingImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UploadingImage), new ImageResourceReference(typeof (OpenFileDialogSkin), "Uploading.gif"));
      set => this.SetValue(nameof (UploadingImage), (object) value);
    }

    /// <summary>Gets the width of the uploading image.</summary>
    /// <value>The width of the uploading image.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int UploadingImageWidth => this.GetImageWidth(this.UploadingImage);

    /// <summary>Gets Flash Add button font style.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string FlashAddButtonFont
    {
      get
      {
        Font font = this.Font;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("font-size:").Append(font.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        switch (font.Unit)
        {
          case GraphicsUnit.Pixel:
            stringBuilder.Append("px");
            break;
          case GraphicsUnit.Point:
            stringBuilder.Append("pt");
            break;
        }
        stringBuilder.Append(";font-family:").Append(font.Name);
        if (font.Bold)
          stringBuilder.Append(";font-weight:bold");
        if (font.Italic)
          stringBuilder.Append(";font-style:italic");
        if (this.ForeColor != Color.Black)
          stringBuilder.Append(";color:#").Append(CommonUtils.GetRGBColor(this.ForeColor));
        return stringBuilder.ToString();
      }
    }

    /// <summary>Gets the upload list frame style.</summary>
    /// <value>The upload list frame style.</value>
    [Category("Styles")]
    [Description("The upload list frame style.")]
    public virtual StyleValue UploadListFrameStyle => new StyleValue((CommonSkin) this, nameof (UploadListFrameStyle));

    /// <summary>Resets the upload list frame style.</summary>
    internal void ResetUploadListFrameStyle() => this.Reset("UploadListFrameStyle");

    /// <summary>Gets the upload button style.</summary>
    /// <value>The upload button style.</value>
    [Category("Styles")]
    [Description("The upload button style.")]
    public virtual StyleValue UploadButtonStyle => new StyleValue((CommonSkin) this, nameof (UploadButtonStyle));

    /// <summary>Resets the upload button style.</summary>
    internal void ResetUploadButtonStyle() => this.Reset("UploadButtonStyle");

    /// <summary>Gets the upload label style.</summary>
    /// <value>The upload label style.</value>
    [Category("Styles")]
    [Description("The upload label style.")]
    public virtual StyleValue UploadLabelStyle => new StyleValue((CommonSkin) this, nameof (UploadLabelStyle));

    /// <summary>Resets the upload label style.</summary>
    internal void ResetUploadLabelStyle() => this.Reset("UploadLabelStyle");
  }
}
