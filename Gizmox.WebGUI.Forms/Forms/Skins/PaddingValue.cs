// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.PaddingValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// hold sthe value that represents padding space between the body of the UI element and its edge.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (PaddingValueConverter))]
  [Serializable]
  public class PaddingValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private Padding mobjValue;
    /// <summary>The empty padding reference</summary>
    private static PaddingValue mobjEmpty = new PaddingValue(Padding.Empty);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> class.
    /// </summary>
    /// <param name="objValue">The padding value.</param>
    public PaddingValue(Padding objValue) => this.mobjValue = objValue;

    /// <summary>Gets or sets the padding value for the bottom edge.</summary>
    /// <returns>The padding, in pixels, for the bottom edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Bottom
    {
      get => this.mobjValue.Bottom;
      set => this.mobjValue.Bottom = value;
    }

    /// <summary>Gets or sets the padding value for all the edges.</summary>
    /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int All
    {
      get => this.mobjValue.All;
      set => this.mobjValue.All = value;
    }

    /// <summary>Gets or sets the padding value for the left edge.</summary>
    /// <returns>The padding, in pixels, for the left edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Left
    {
      get => this.mobjValue.Left;
      set => this.mobjValue.Left = value;
    }

    /// <summary>Gets or sets the padding value for the right edge.</summary>
    /// <returns>The padding, in pixels, for the right edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Right
    {
      get => this.mobjValue.Right;
      set => this.mobjValue.Right = value;
    }

    /// <summary>Gets or sets the padding value for the top edge.</summary>
    /// <returns>The padding, in pixels, for the top edge.</returns>
    [RefreshProperties(RefreshProperties.All)]
    public int Top
    {
      get => this.mobjValue.Top;
      set => this.mobjValue.Top = value;
    }

    /// <summary>
    /// Gets the combined padding for the right and left edges.
    /// </summary>
    /// <returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Left"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Right"></see> padding values.</returns>
    [Browsable(false)]
    public int Horizontal => this.mobjValue.Horizontal;

    /// <summary>
    /// Gets the combined padding for the top and bottom edges.
    /// </summary>
    /// <returns>Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Top"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Bottom"></see> padding values.</returns>
    [Browsable(false)]
    public int Vertical => this.mobjValue.Vertical;

    /// <summary>
    /// Gets the padding information in the form of a <see cref="T:System.Drawing.Size"></see>.
    /// </summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the padding information.</returns>
    [Browsable(false)]
    public Size Size => this.mobjValue.Size;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      if (this.mobjValue.IsAll)
        return string.Format("{0}:{1}px{2}", (object) this.GetWebStyleName(), (object) this.mobjValue.All, (object) declarationValue);
      return string.Format("{0}:{1}px {2}px {3}px {4}px{5}", (object) this.GetWebStyleName(), (object) this.mobjValue.Top, (object) this.mobjValue.Right, (object) this.mobjValue.Bottom, (object) this.mobjValue.Left, (object) declarationValue);
    }

    /// <summary>Gets the name of the web style.</summary>
    /// <returns></returns>
    protected virtual string GetWebStyleName() => "padding";

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </returns>
    public override string ToString() => this.mobjValue.ToString();

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:Gizmox.WebGUI.Forms.Padding" />.
    /// </summary>
    /// <param name="objPaddingValue">The padding value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Padding(PaddingValue objPaddingValue) => objPaddingValue == null ? Padding.Empty : objPaddingValue.Value;

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Padding" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
    /// </summary>
    /// <param name="objPadding">The padding.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator PaddingValue(Padding objPadding) => new PaddingValue(objPadding);

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:System.String" />.
    /// </summary>
    /// <param name="objPaddingValue">The padding value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator string(PaddingValue objPaddingValue)
    {
      if (objPaddingValue.Value.IsAll)
        return objPaddingValue.All.ToString();
      return string.Format("{0},{1},{2},{3}", (object) objPaddingValue.Left, (object) objPaddingValue.Top, (object) objPaddingValue.Right, (object) objPaddingValue.Bottom);
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
    /// </summary>
    /// <param name="strPadding">The padding string.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator PaddingValue(string strPadding)
    {
      Padding objValue = Padding.Empty;
      if (!string.IsNullOrEmpty(strPadding))
      {
        string[] strArray = strPadding.Split(',');
        if (strArray.Length == 4)
          objValue = new Padding(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        else if (strArray.Length == 1)
          objValue = new Padding(int.Parse(strArray[0]));
      }
      return new PaddingValue(objValue);
    }

    /// <summary>Gets an empty padding value.</summary>
    /// <value>The empty padding value.</value>
    public static PaddingValue Empty => PaddingValue.mobjEmpty;

    /// <summary>Gets the value.</summary>
    /// <value>The value.</value>
    [Browsable(false)]
    public Padding Value => this.mobjValue;
  }
}
