// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.SelectedIndicatorSizeValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (SelectedIndicatorSizeValueConverter))]
  [Serializable]
  public class SelectedIndicatorSizeValue
  {
    private CommonSkin mobjCommonSkin;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.SelectedIndicatorSizeValue" /> class.
    /// </summary>
    /// <param name="objCommonSkin">The obj common skin.</param>
    /// <exception cref="T:System.ArgumentNullException">objCommonSkin</exception>
    public SelectedIndicatorSizeValue(CommonSkin objCommonSkin) => this.mobjCommonSkin = objCommonSkin != null ? objCommonSkin : throw new ArgumentNullException(nameof (objCommonSkin));

    /// <summary>Gets the top Size.</summary>
    /// <value>The top Size.</value>
    public Size TopSize
    {
      get => this.mobjCommonSkin.TopSelectedIndicatorSize;
      set => this.mobjCommonSkin.TopSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the top.</summary>
    private void ResetTopSize() => this.mobjCommonSkin.ResetTopSelectedIndicatorSize();

    /// <summary>Gets the bottom Size.</summary>
    /// <value>The bottom Size.</value>
    public Size BottomSize
    {
      get => this.mobjCommonSkin.BottomSelectedIndicatorSize;
      set => this.mobjCommonSkin.BottomSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the bottom.</summary>
    private void ResetBottomSize() => this.mobjCommonSkin.ResetBottomSelectedIndicatorSize();

    /// <summary>Gets the left Size.</summary>
    /// <value>The left Size.</value>
    public Size LeftSize
    {
      get => this.mobjCommonSkin.LeftSelectedIndicatorSize;
      set => this.mobjCommonSkin.LeftSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the left.</summary>
    private void ResetLeftSize() => this.mobjCommonSkin.ResetLeftSelectedIndicatorSize();

    /// <summary>Gets the left top Size.</summary>
    /// <value>The left top Size.</value>
    public Size LeftTopSize
    {
      get => this.mobjCommonSkin.LeftTopSelectedIndicatorSize;
      set => this.mobjCommonSkin.LeftTopSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the left top.</summary>
    private void ResetLeftTopSize() => this.mobjCommonSkin.ResetLeftTopSelectedIndicatorSize();

    /// <summary>Gets the left bottom Size.</summary>
    /// <value>The left bottom Size.</value>
    public Size LeftBottomSize
    {
      get => this.mobjCommonSkin.LeftBottomSelectedIndicatorSize;
      set => this.mobjCommonSkin.LeftBottomSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the left bottom.</summary>
    private void ResetLeftBottomSize() => this.mobjCommonSkin.ResetLeftBottomSelectedIndicatorSize();

    /// <summary>Gets the right Size.</summary>
    /// <value>The right Size.</value>
    public Size RightSize
    {
      get => this.mobjCommonSkin.RightSelectedIndicatorSize;
      set => this.mobjCommonSkin.RightSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the right.</summary>
    private void ResetRightSize() => this.mobjCommonSkin.ResetRightSelectedIndicatorSize();

    /// <summary>Gets the right top Size.</summary>
    /// <value>The right top Size.</value>
    public Size RightTopSize
    {
      get => this.mobjCommonSkin.RightTopSelectedIndicatorSize;
      set => this.mobjCommonSkin.RightTopSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the right top.</summary>
    private void ResetRightTopSize() => this.mobjCommonSkin.ResetRightTopSelectedIndicatorSize();

    /// <summary>Gets the right bottom Size.</summary>
    /// <value>The right bottom Size.</value>
    public Size RightBottomSize
    {
      get => this.mobjCommonSkin.RightBottomSelectedIndicatorSize;
      set => this.mobjCommonSkin.RightBottomSelectedIndicatorSize = value;
    }

    /// <summary>Resets the size of the right bottom.</summary>
    private void ResetRightBottomSize() => this.mobjCommonSkin.ResetRightBottomSelectedIndicatorSize();
  }
}
