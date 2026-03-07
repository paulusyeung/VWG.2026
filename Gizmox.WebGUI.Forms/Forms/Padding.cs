// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Padding
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents padding or margin information associated with a user interface (UI) element.
  /// </summary>
  [TypeConverter(typeof (PaddingConverter))]
  [Serializable]
  public struct Padding
  {
    private bool mblnAll;
    private int mintTop;
    private int mintLeft;
    private int mintRight;
    private int mintBottom;
    /// <summary>
    /// Provides a <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> object with no padding.
    /// </summary>
    public static readonly Padding Empty = new Padding(0);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> class using the supplied padding size for all edges.
    /// </summary>
    /// <param name="intAll">The number of pixels to be used for padding for all edges.</param>
    public Padding(int intAll)
    {
      this.mblnAll = true;
      int num;
      this.mintBottom = num = intAll;
      this.mintRight = num;
      this.mintLeft = num;
      this.mintTop = num;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> class using a separate padding size for each edge.
    /// </summary>
    /// <param name="intRight">The padding size, in pixels, for the right edge.</param>
    /// <param name="intBottom">The padding size, in pixels, for the bottom edge.</param>
    /// <param name="intLeft">The padding size, in pixels, for the left edge.</param>
    /// <param name="intTop">The padding size, in pixels, for the top edge.</param>
    public Padding(int intLeft, int intTop, int intRight, int intBottom)
    {
      this.mintTop = intTop;
      this.mintLeft = intLeft;
      this.mintRight = intRight;
      this.mintBottom = intBottom;
      this.mblnAll = this.mintTop == this.mintLeft && this.mintTop == this.mintRight && this.mintTop == this.mintBottom;
    }

    /// <summary>Gets or sets the padding value for all the edges.</summary>
    /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
    [RefreshProperties(RefreshProperties.All)]
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

    /// <summary>Gets or sets the padding value for the bottom edge.</summary>
    /// <returns>The padding, in pixels, for the bottom edge.</returns>
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

    /// <summary>Gets or sets the padding value for the left edge.</summary>
    /// <returns>The padding, in pixels, for the left edge.</returns>
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

    /// <summary>Gets or sets the padding value for the right edge.</summary>
    /// <returns>The padding, in pixels, for the right edge.</returns>
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

    /// <summary>Gets or sets the padding value for the top edge.</summary>
    /// <returns>The padding, in pixels, for the top edge.</returns>
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
    /// Gets the combined padding for the right and left edges.
    /// </summary>
    /// <returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Left"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Right"></see> padding values.</returns>
    [Browsable(false)]
    public int Horizontal => this.Left + this.Right;

    /// <summary>
    /// Gets the combined padding for the top and bottom edges.
    /// </summary>
    /// <returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Top"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Bottom"></see> padding values.</returns>
    [Browsable(false)]
    public int Vertical => this.Top + this.Bottom;

    /// <summary>
    /// Gets the padding information in the form of a <see cref="T:System.Drawing.Size"></see>.
    /// </summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the padding information.</returns>
    [Browsable(false)]
    public Size Size => new Size(this.Horizontal, this.Vertical);

    /// <summary>
    /// Computes the sum of the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that contains the sum of the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
    /// <param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
    /// <param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
    public static Padding Add(Padding objPadding1, Padding objPadding2) => objPadding1 + objPadding2;

    /// <summary>
    /// Subtracts one specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value from another.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that contains the result of the subtraction of one specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value from another.</returns>
    /// <param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
    /// <param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
    public static Padding Subtract(Padding objPadding1, Padding objPadding2) => objPadding1 - objPadding2;

    /// <summary>
    /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
    /// </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equivalent; otherwise, false.</returns>
    /// <param name="objOther">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.</param>
    public override bool Equals(object objOther) => objOther is Padding padding && padding.mblnAll == this.mblnAll && padding.mintTop == this.mintTop && padding.mintLeft == this.mintLeft && padding.mintBottom == this.mintBottom && padding.mintRight == this.mintRight;

    /// <summary>
    /// Performs vector addition on the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects, resulting in a new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
    /// </summary>
    /// <returns>A new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that results from adding p1 and p2.</returns>
    /// <param name="objPadding2">The second <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to add.</param>
    /// <param name="objPadding1">The first <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to add.</param>
    public static Padding operator +(Padding objPadding1, Padding objPadding2) => new Padding(objPadding1.Left + objPadding2.Left, objPadding1.Top + objPadding2.Top, objPadding1.Right + objPadding2.Right, objPadding1.Bottom + objPadding2.Bottom);

    /// <summary>
    /// Performs vector subtraction on the two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects, resulting in a new <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> result of subtracting p2 from p1.</returns>
    /// <param name="objPadding2">The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to subtract from (the subtrahend).</param>
    /// <param name="objPadding1">The <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to subtract from (the minuend).</param>
    public static Padding operator -(Padding objPadding1, Padding objPadding2) => new Padding(objPadding1.Left - objPadding2.Left, objPadding1.Top - objPadding2.Top, objPadding1.Right - objPadding2.Right, objPadding1.Bottom - objPadding2.Bottom);

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are equal; otherwise, false.</returns>
    /// <param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
    /// <param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
    public static bool operator ==(Padding objPadding1, Padding objPadding2) => objPadding1.Left == objPadding2.Left && objPadding1.Top == objPadding2.Top && objPadding1.Right == objPadding2.Right && objPadding1.Bottom == objPadding2.Bottom;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are not equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> objects are different; otherwise, false.</returns>
    /// <param name="objPadding2">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
    /// <param name="objPadding1">A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> to test.</param>
    public static bool operator !=(Padding objPadding1, Padding objPadding2) => !(objPadding1 == objPadding2);

    /// <summary>
    /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
    /// </summary>
    /// <returns>A 32-bit signed integer.</returns>
    public override int GetHashCode() => this.Left ^ ClientUtils.RotateLeft(this.Top, 8) ^ ClientUtils.RotateLeft(this.Right, 16) ^ ClientUtils.RotateLeft(this.Bottom, 24);

    /// <summary>
    /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>.
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
