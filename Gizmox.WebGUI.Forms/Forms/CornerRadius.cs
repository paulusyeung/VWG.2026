// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CornerRadius
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents corner information associated with a user interface (UI) element.
  /// </summary>
  [TypeConverter(typeof (CornerRadiusConverter))]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public struct CornerRadius
  {
    private bool mblnAll;
    private int mintTopLeft;
    private int mintBottomLeft;
    private int mintTopRight;
    private int mintBottomRight;
    /// <summary>
    /// Provides a <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> object with no corner.
    /// </summary>
    public static readonly CornerRadius Empty = new CornerRadius(0);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using the supplied corner size for all edges.
    /// </summary>
    /// <param name="intAll">The number of pixels to be used for corner for all edges.</param>
    public CornerRadius(int intAll)
    {
      this.mblnAll = true;
      this.mintBottomRight = intAll;
      this.mintTopRight = intAll;
      this.mintBottomLeft = intAll;
      this.mintTopLeft = intAll;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using a separate corner size for each edge.
    /// </summary>
    /// <param name="topLeft">The corner size, in pixels, for the top left edge.</param>
    /// <param name="topRight">The corner size, in pixels, for the top right edge.</param>
    /// <param name="intBottomRight">The corner size, in pixels, for the bottom right edge.</param>
    /// <param name="intBottomLeft">The corner size, in pixels, for the bottom left edge.</param>
    public CornerRadius(int topLeft, int topRight, int intBottomRight, int intBottomLeft)
    {
      this.mintTopLeft = topLeft;
      this.mintBottomLeft = intBottomLeft;
      this.mintTopRight = topRight;
      this.mintBottomRight = intBottomRight;
      this.mblnAll = this.mintTopLeft == this.mintBottomLeft && this.mintTopLeft == this.mintTopRight && this.mintTopLeft == this.mintBottomRight;
    }

    /// <summary>Gets or sets the corner value for all the edges.</summary>
    /// <returns>The corner, in pixels, for all edges if the same; otherwise, -1.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int All
    {
      get => !this.mblnAll ? -1 : this.mintTopLeft;
      set
      {
        if (this.mblnAll && this.mintTopLeft == value)
          return;
        this.mblnAll = true;
        int num;
        this.mintBottomRight = num = value;
        this.mintTopRight = num;
        this.mintBottomLeft = num;
        this.mintTopLeft = num;
      }
    }

    /// <summary>Gets a value indicating whether this instance is all.</summary>
    /// <value><c>true</c> if this instance is all; otherwise, <c>false</c>.</value>
    internal bool IsAll => this.mblnAll;

    /// <summary>
    /// Gets or sets the corner value for the bottom right corner.
    /// </summary>
    /// <returns>The corner, in pixels, for the bottom right corner.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int BottomRight
    {
      get => this.mblnAll ? this.mintTopLeft : this.mintBottomRight;
      set
      {
        if (!this.mblnAll && this.mintBottomRight == value)
          return;
        this.mblnAll = false;
        this.mintBottomRight = value;
      }
    }

    /// <summary>
    /// Gets or sets the corner value for the bottom left corner.
    /// </summary>
    /// <returns>The corner, in pixels, for the bottom left corner.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int BottomLeft
    {
      get => this.mblnAll ? this.mintTopLeft : this.mintBottomLeft;
      set
      {
        if (!this.mblnAll && this.mintBottomLeft == value)
          return;
        this.mblnAll = false;
        this.mintBottomLeft = value;
      }
    }

    /// <summary>
    /// Gets or sets the corner value for the top right corner.
    /// </summary>
    /// <returns>The corner, in pixels, for the top right corner.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int TopRight
    {
      get => this.mblnAll ? this.mintTopLeft : this.mintTopRight;
      set
      {
        if (!this.mblnAll && this.mintTopRight == value)
          return;
        this.mblnAll = false;
        this.mintTopRight = value;
      }
    }

    /// <summary>
    /// Gets or sets the corner value for the top left corner.
    /// </summary>
    /// <returns>The corner, in pixels, for the top left corner.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int TopLeft
    {
      get => this.mintTopLeft;
      set
      {
        if (!this.mblnAll && this.mintTopLeft == value)
          return;
        this.mblnAll = false;
        this.mintTopLeft = value;
      }
    }

    /// <summary>
    /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
    /// </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent; otherwise, false.</returns>
    /// <param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.</param>
    public override bool Equals(object other) => other is CornerRadius cornerRadius && cornerRadius.mblnAll == this.mblnAll && cornerRadius.mintTopLeft == this.mintTopLeft && cornerRadius.mintBottomLeft == this.mintBottomLeft && cornerRadius.mintBottomRight == this.mintBottomRight && cornerRadius.mintTopRight == this.mintTopRight;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equal; otherwise, false.</returns>
    /// <param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
    /// <param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
    public static bool operator ==(CornerRadius objRadius1, CornerRadius objRadius2) => objRadius1.BottomLeft == objRadius2.BottomLeft && objRadius1.TopLeft == objRadius2.TopLeft && objRadius1.TopRight == objRadius2.TopRight && objRadius1.BottomRight == objRadius2.BottomRight;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are not equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are different; otherwise, false.</returns>
    /// <param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
    /// <param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
    public static bool operator !=(CornerRadius objRadius1, CornerRadius objRadius2) => !(objRadius1 == objRadius2);

    /// <summary>
    /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
    /// </summary>
    /// <returns>A 32-bit signed integer.</returns>
    public override int GetHashCode() => this.BottomLeft ^ ClientUtils.RotateLeft(this.TopLeft, 8) ^ ClientUtils.RotateLeft(this.TopRight, 16) ^ ClientUtils.RotateLeft(this.BottomRight, 24);

    /// <summary>
    /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
    /// </returns>
    public override string ToString() => "{TopLeft=" + this.TopLeft.ToString() + ",TopRight=" + this.TopRight.ToString() + ",BottomRight=" + this.BottomRight.ToString() + ",BottomLeft=" + this.BottomLeft.ToString() + "}";

    private void ResetAll() => this.All = 0;

    private void ResetBottomRight() => this.BottomRight = 0;

    private void ResetBottomLeft() => this.BottomLeft = 0;

    private void ResetTopRight() => this.TopRight = 0;

    private void ResetTopLeft() => this.TopLeft = 0;

    internal void Scale(float fltX, float fltY)
    {
      this.mintTopLeft = (int) ((double) this.mintTopLeft * (double) fltY);
      this.mintBottomLeft = (int) ((double) this.mintBottomLeft * (double) fltX);
      this.mintTopRight = (int) ((double) this.mintTopRight * (double) fltX);
      this.mintBottomRight = (int) ((double) this.mintBottomRight * (double) fltY);
    }

    internal bool ShouldSerializeAll() => this.mblnAll;
  }
}
