// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneCloseButtonSkin
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
  /// <summary>Button Skin</summary>
  [SkinContainer(typeof (DockingManagerSkin))]
  [Serializable]
  public class ZoneCloseButtonSkin : ButtonSkin
  {
    /// <summary>Gets the width of the expand button image.</summary>
    /// <value>The width of the expand button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Size TotalSize
    {
      get
      {
        Size imageSize = this.GetImageSize(this.NormalStyle.CenterStyle.BackgroundImage, Size.Empty);
        ref Size local1 = ref imageSize;
        int width = local1.Width;
        BorderWidth borderWidth1 = this.NormalStyle.CenterStyle.BorderWidth;
        int left = borderWidth1.Left;
        borderWidth1 = this.NormalStyle.CenterStyle.BorderWidth;
        int right = borderWidth1.Right;
        int num1 = left + right;
        local1.Width = width + num1;
        ref Size local2 = ref imageSize;
        int height = local2.Height;
        BorderWidth borderWidth2 = this.NormalStyle.CenterStyle.BorderWidth;
        int top = borderWidth2.Top;
        borderWidth2 = this.NormalStyle.CenterStyle.BorderWidth;
        int bottom = borderWidth2.Bottom;
        int num2 = top + bottom;
        local2.Height = height + num2;
        imageSize.Width += this.NormalStyle.CenterStyle.Padding.Horizontal;
        imageSize.Height += this.NormalStyle.CenterStyle.Padding.Vertical;
        return imageSize;
      }
    }

    private void InitializeComponent()
    {
    }
  }
}
