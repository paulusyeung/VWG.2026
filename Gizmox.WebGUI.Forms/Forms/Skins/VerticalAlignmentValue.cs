// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// hold sthe value that represents padding space between the body of the UI element and its edge.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (VerticalAlignmentValueConverter))]
  [Serializable]
  public class VerticalAlignmentValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private VerticalAlignment menmVerticalAlignment = VerticalAlignment.Center;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue" /> class.
    /// </summary>
    /// <param name="enmVerticalAlignment">The enm vertical alignment.</param>
    public VerticalAlignmentValue(VerticalAlignment enmVerticalAlignment) => this.menmVerticalAlignment = enmVerticalAlignment;

    /// <summary>Gets or sets the padding value for all the edges.</summary>
    /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
    internal VerticalAlignment VerticalAlignment => this.menmVerticalAlignment;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition) => this.menmVerticalAlignment.ToString().ToLower();

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </returns>
    public override string ToString() => this.menmVerticalAlignment.ToString();

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue" /> to <see cref="T:System.String" />.
    /// </summary>
    /// <param name="objVerticalAlignmentValue">The padding value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator string(VerticalAlignmentValue objVerticalAlignmentValue) => objVerticalAlignmentValue.ToString();

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue" />.
    /// </summary>
    /// <param name="strFilter">The STR filter.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator VerticalAlignmentValue(string strFilter) => Enum.IsDefined(typeof (VerticalAlignment), (object) strFilter) ? new VerticalAlignmentValue((VerticalAlignment) Enum.Parse(typeof (VerticalAlignment), strFilter, true)) : throw new Exception("Illegal vertical alignment value.");

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignment" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue" />.
    /// </summary>
    /// <param name="enmVerticalAlignment">The enm vertical alignment.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator VerticalAlignmentValue(VerticalAlignment enmVerticalAlignment) => new VerticalAlignmentValue(enmVerticalAlignment);

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignmentValue" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.VerticalAlignment" />.
    /// </summary>
    /// <param name="objVerticalAlignmentValue">The obj vertical alignment value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator VerticalAlignment(
      VerticalAlignmentValue objVerticalAlignmentValue)
    {
      return objVerticalAlignmentValue.VerticalAlignment;
    }
  }
}
