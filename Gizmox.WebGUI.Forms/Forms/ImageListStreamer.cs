// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ImageListStreamer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides the data portion of an <see cref="T:System.Windows.Forms.ImageList"></see>.</summary>
  [Serializable]
  public sealed class ImageListStreamer
  {
    private Type mobjOwnerType;
    private object mobjImages;

    /// <summary>Gets or sets the type of the owner.</summary>
    /// <value>The type of the owner.</value>
    internal Type OwnerType => this.mobjOwnerType;

    /// <summary>Gets or sets the images.</summary>
    /// <value>The images.</value>
    internal object Images => this.mobjImages;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ImageListStreamer" /> class.
    /// </summary>
    public ImageListStreamer()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ImageListStreamer" /> class.
    /// </summary>
    /// <param name="strImages">The images.</param>
    /// <param name="objOwnerType">Type of the owner.</param>
    public ImageListStreamer(object objImages, Type objOwnerType)
    {
      this.mobjImages = objImages;
      this.mobjOwnerType = objOwnerType;
    }
  }
}
