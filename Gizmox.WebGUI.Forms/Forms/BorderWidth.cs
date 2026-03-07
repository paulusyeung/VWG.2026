// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BorderWidth
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents border thickness information associated with a user interface (UI) element.
  /// </summary>
  [TypeConverter(typeof (BorderWidthConverter))]
  [Serializable]
  public struct BorderWidth
  {
    private bool mblnAll;
    private int mintTop;
    private int mintLeft;
    private int mintRight;
    private int mintBottom;
    /// <summary>
    /// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> object with no thickness.
    /// </summary>
    public static readonly BorderWidth Empty = new BorderWidth(0);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using the supplied thickness size for all edges.
    /// </summary>
    /// <param name="intAll">The number of pixels to be used for thickness for all edges.</param>
    public BorderWidth(int intAll)
    {
      this.mblnAll = true;
      int num;
      this.mintBottom = num = intAll;
      this.mintRight = num;
      this.mintLeft = num;
      this.mintTop = num;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using a separate thickness size for each edge.
    /// </summary>
    /// <param name="intRight">The thickness size, in pixels, for the right edge.</param>
    /// <param name="intBottom">The thickness size, in pixels, for the bottom edge.</param>
    /// <param name="intLeft">The thickness size, in pixels, for the left edge.</param>
    /// <param name="intTop">The thickness size, in pixels, for the top edge.</param>
    public BorderWidth(int intLeft, int intTop, int intRight, int intBottom)
    {
      this.mintTop = intTop;
      this.mintLeft = intLeft;
      this.mintRight = intRight;
      this.mintBottom = intBottom;
      this.mblnAll = this.mintTop == this.mintLeft && this.mintTop == this.mintRight && this.mintTop == this.mintBottom;
    }

    /// <summary>Gets or sets the thickness value for all the edges.</summary>
    /// <returns>The thickness, in pixels, for all edges if the same; otherwise, -1.</returns>
    [Browsable(false)]
    public int All
    {
      get => !this.mblnAll ? -1 : this.mintTop;
      set
      {
        if (this.mblnAll && this.mintTop == value)
          return;
        this.mblnAll = true;
        int num;
        this.mintBottom = num = value;
        this.mintRight = num;
        this.mintLeft = num;
        this.mintTop = num;
      }
    }

    /// <summary>Gets a value indicating whether this instance is all.</summary>
    /// <value><c>true</c> if this instance is all; otherwise, <c>false</c>.</value>
    internal bool IsAll => this.mblnAll;

    /// <summary>Gets or sets the thickness value for the bottom edge.</summary>
    /// <returns>The thickness, in pixels, for the bottom edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Bottom
    {
      get => this.mblnAll ? this.mintTop : this.mintBottom;
      set
      {
        if (!this.mblnAll && this.mintBottom == value)
          return;
        this.mblnAll = false;
        this.mintBottom = value;
      }
    }

    /// <summary>Gets or sets the thickness value for the left edge.</summary>
    /// <returns>The thickness, in pixels, for the left edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Left
    {
      get => this.mblnAll ? this.mintTop : this.mintLeft;
      set
      {
        if (!this.mblnAll && this.mintLeft == value)
          return;
        this.mblnAll = false;
        this.mintLeft = value;
      }
    }

    /// <summary>Gets or sets the thickness value for the right edge.</summary>
    /// <returns>The thickness, in pixels, for the right edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Right
    {
      get => this.mblnAll ? this.mintTop : this.mintRight;
      set
      {
        if (!this.mblnAll && this.mintRight == value)
          return;
        this.mblnAll = false;
        this.mintRight = value;
      }
    }

    /// <summary>Gets or sets the thickness value for the top edge.</summary>
    /// <returns>The thickness, in pixels, for the top edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Top
    {
      get => this.mintTop;
      set
      {
        if (!this.mblnAll && this.mintTop == value)
          return;
        this.mblnAll = false;
        this.mintTop = value;
      }
    }

    /// <summary>
    /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
    /// </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent; otherwise, false.</returns>
    /// <param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.</param>
    public override bool Equals(object other) => other is BorderWidth borderWidth && borderWidth.mblnAll == this.mblnAll && borderWidth.mintTop == this.mintTop && borderWidth.mintLeft == this.mintLeft && borderWidth.mintBottom == this.mintBottom && borderWidth.mintRight == this.mintRight;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equal; otherwise, false.</returns>
    /// <param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
    /// <param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
    public static bool operator ==(BorderWidth objWidth1, BorderWidth objWidth2) => objWidth1.Left == objWidth2.Left && objWidth1.Top == objWidth2.Top && objWidth1.Right == objWidth2.Right && objWidth1.Bottom == objWidth2.Bottom;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are not equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are different; otherwise, false.</returns>
    /// <param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
    /// <param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
    public static bool operator !=(BorderWidth objWidth1, BorderWidth objWidth2) => !(objWidth1 == objWidth2);

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.BorderWidth" /> to <see cref="T:System.Int32" />.
    /// </summary>
    /// <param name="objBorderWidth">The thickness.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator int(BorderWidth objBorderWidth) => objBorderWidth.All;

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Gizmox.WebGUI.Forms.BorderWidth" />.
    /// </summary>
    /// <param name="intBorderWidth">The thickness.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator BorderWidth(int intBorderWidth) => new BorderWidth(intBorderWidth);

    /// <summary>
    /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
    /// </summary>
    /// <returns>A 32-bit signed integer.</returns>
    public override int GetHashCode() => this.Left ^ ClientUtils.RotateLeft(this.Top, 8) ^ ClientUtils.RotateLeft(this.Right, 16) ^ ClientUtils.RotateLeft(this.Bottom, 24);

    /// <summary>
    /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
    /// </returns>
    public override string ToString() => "{Left=" + this.Left.ToString() + ",Top=" + this.Top.ToString() + ",Right=" + this.Right.ToString() + ",Bottom=" + this.Bottom.ToString() + "}";

    private void ResetAll() => this.All = 0;

    private void ResetBottom() => this.Bottom = 0;

    private void ResetLeft() => this.Left = 0;

    private void ResetRight() => this.Right = 0;

    private void ResetTop() => this.Top = 0;

    internal void Scale(float fltX, float fltY)
    {
      this.mintTop = (int) ((double) this.mintTop * (double) fltY);
      this.mintLeft = (int) ((double) this.mintLeft * (double) fltX);
      this.mintRight = (int) ((double) this.mintRight * (double) fltX);
      this.mintBottom = (int) ((double) this.mintBottom * (double) fltY);
    }

    internal bool ShouldSerializeAll() => this.mblnAll;
  }
}
