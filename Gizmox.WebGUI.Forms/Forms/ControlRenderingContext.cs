// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlRenderingContext
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides contextual support for rendering</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ControlRenderingContext
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly PixelFormat menmPixelFormat;
    /// <summary>The image resource cache</summary>
    private Dictionary<string, Image> mobjImageCache = new Dictionary<string, Image>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlRenderingContext" /> class.
    /// </summary>
    /// <param name="enmPixelFormat">The pixel format.</param>
    internal ControlRenderingContext(PixelFormat enmPixelFormat) => this.menmPixelFormat = enmPixelFormat;

    /// <summary>Gets the pixel format.</summary>
    public PixelFormat PixelFormat => this.menmPixelFormat;

    /// <summary>Gets the resource image.</summary>
    /// <param name="objResourceHandle">The resource handle.</param>
    /// <returns></returns>
    internal Image GetResourceImage(ResourceHandle objResourceHandle)
    {
      Image resourceImage = (Image) null;
      if (objResourceHandle != null && objResourceHandle.CanGetImage)
      {
        string key = objResourceHandle.ToString();
        if (!string.IsNullOrEmpty(key))
        {
          if (!this.mobjImageCache.TryGetValue(key, out resourceImage))
          {
            try
            {
              resourceImage = objResourceHandle.ToImage();
            }
            catch
            {
            }
            this.mobjImageCache[key] = resourceImage;
          }
        }
      }
      return resourceImage;
    }
  }
}
