// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BorderColor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents color information associated with a user interface (UI) element.
  /// </summary>
  [TypeConverter(typeof (BorderColorConverter))]
  [WebEditor(typeof (BorderColorEditor), typeof (WebUITypeEditor))]
  [Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Serializable]
  public struct BorderColor
  {
    private bool mblnAll;
    private Color mobjTop;
    private Color mobjLeft;
    private Color mobjRight;
    private Color mobjBottom;
    /// <summary>
    /// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> object with no color.
    /// </summary>
    public static readonly BorderColor Empty = new BorderColor(Color.Empty);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> struct.
    /// </summary>
    /// <param name="objAll">All.</param>
    public BorderColor(Color objAll)
    {
      this.mblnAll = true;
      Color color;
      this.mobjBottom = color = objAll;
      this.mobjRight = color;
      this.mobjLeft = color;
      this.mobjTop = color;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> struct.
    /// </summary>
    /// <param name="objLeft">The left.</param>
    /// <param name="objTop">The top.</param>
    /// <param name="objRight">The right.</param>
    /// <param name="objBottom">The bottom.</param>
    public BorderColor(Color objLeft, Color objTop, Color objRight, Color objBottom)
    {
      this.mobjTop = objTop;
      this.mobjLeft = objLeft;
      this.mobjRight = objRight;
      this.mobjBottom = objBottom;
      this.mblnAll = !(this.mobjTop != this.mobjLeft) && !(this.mobjTop != this.mobjRight) && this.mobjTop == this.mobjBottom;
    }

    /// <summary>Gets or sets all.</summary>
    /// <value>All.</value>
    [RefreshProperties(RefreshProperties.All)]
    [Browsable(false)]
    public Color All
    {
      get => !this.mblnAll ? Color.Empty : this.mobjTop;
      set
      {
        if (this.mblnAll && !(this.mobjTop != value))
          return;
        this.mblnAll = true;
        Color color;
        this.mobjBottom = color = value;
        this.mobjRight = color;
        this.mobjLeft = color;
        this.mobjTop = color;
      }
    }

    /// <summary>Gets a value indicating whether this instance is all.</summary>
    /// <value><c>true</c> if this instance is all; otherwise, <c>false</c>.</value>
    internal bool IsAll => this.mblnAll;

    /// <summary>Gets or sets the bottom.</summary>
    /// <value>The bottom.</value>
    [RefreshProperties(RefreshProperties.All)]
    public Color Bottom
    {
      get => this.mblnAll ? this.mobjTop : this.mobjBottom;
      set
      {
        if (!this.mblnAll && !(this.mobjBottom != value))
          return;
        this.mblnAll = false;
        this.mobjBottom = value;
      }
    }

    /// <summary>Gets or sets the left.</summary>
    /// <value>The left.</value>
    [RefreshProperties(RefreshProperties.All)]
    public Color Left
    {
      get => this.mblnAll ? this.mobjTop : this.mobjLeft;
      set
      {
        if (!this.mblnAll && !(this.mobjLeft != value))
          return;
        this.mblnAll = false;
        this.mobjLeft = value;
      }
    }

    /// <summary>Gets or sets the right.</summary>
    /// <value>The right.</value>
    [RefreshProperties(RefreshProperties.All)]
    public Color Right
    {
      get => this.mblnAll ? this.mobjTop : this.mobjRight;
      set
      {
        if (!this.mblnAll && !(this.mobjRight != value))
          return;
        this.mblnAll = false;
        this.mobjRight = value;
      }
    }

    /// <summary>Gets or sets the top.</summary>
    /// <value>The top.</value>
    [RefreshProperties(RefreshProperties.All)]
    public Color Top
    {
      get => this.mobjTop;
      set
      {
        if (!this.mblnAll && !(this.mobjTop != value))
          return;
        this.mblnAll = false;
        this.mobjTop = value;
      }
    }

    /// <summary>
    /// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
    /// </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent; otherwise, false.</returns>
    /// <param name="objOther">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.</param>
    public override bool Equals(object objOther) => objOther is BorderColor borderColor && borderColor.mblnAll == this.mblnAll && borderColor.mobjTop == this.mobjTop && borderColor.mobjLeft == this.mobjLeft && borderColor.mobjBottom == this.mobjBottom && borderColor.mobjRight == this.mobjRight;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equal; otherwise, false.</returns>
    /// <param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
    /// <param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
    public static bool operator ==(BorderColor objColor1, BorderColor objColor2) => objColor1.Left == objColor2.Left && objColor1.Top == objColor2.Top && objColor1.Right == objColor2.Right && objColor1.Bottom == objColor2.Bottom;

    /// <summary>
    /// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are not equivalent.
    /// </summary>
    /// <returns>true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are different; otherwise, false.</returns>
    /// <param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
    /// <param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
    public static bool operator !=(BorderColor objColor1, BorderColor objColor2) => !(objColor1 == objColor2);

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> to <see cref="T:System.Int32" />.
    /// </summary>
    /// <param name="objBorderColor">The color.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Color(BorderColor objBorderColor) => objBorderColor.All;

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Gizmox.WebGUI.Forms.BorderColor" />.
    /// </summary>
    /// <param name="objBorderColor">The color.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator BorderColor(Color objBorderColor) => new BorderColor(objBorderColor);

    /// <summary>
    /// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
    /// </summary>
    /// <returns>A 32-bit signed integer.</returns>
    public override int GetHashCode()
    {
      Color color = this.Top;
      int hashCode1 = color.GetHashCode();
      color = this.Right;
      int hashCode2 = color.GetHashCode();
      int num1 = hashCode1 + hashCode2;
      color = this.Bottom;
      int hashCode3 = color.GetHashCode();
      int num2 = num1 + hashCode3;
      color = this.Left;
      int hashCode4 = color.GetHashCode();
      return num2 + hashCode4;
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
    /// </returns>
    public override string ToString() => "{Left=" + this.Left.ToString() + ",Top=" + this.Top.ToString() + ",Right=" + this.Right.ToString() + ",Bottom=" + this.Bottom.ToString() + "}";

    private void ResetAll() => this.All = Color.Empty;

    private void ResetBottom() => this.Bottom = Color.Empty;

    private void ResetLeft() => this.Left = Color.Empty;

    private void ResetRight() => this.Right = Color.Empty;

    private void ResetTop() => this.Top = Color.Empty;

    internal bool ShouldSerializeAll() => this.mblnAll;
  }
}
