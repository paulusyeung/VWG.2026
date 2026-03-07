// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue
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
  [TypeConverter(typeof (HorizontalAlignmentValueConverter))]
  [Serializable]
  public class HorizontalAlignmentValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private HorizontalAlignment menmHorizontalAlignment = HorizontalAlignment.Center;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue" /> class.
    /// </summary>
    /// <param name="enmHorizontalAlignment">The enm horizontal alignment.</param>
    public HorizontalAlignmentValue(HorizontalAlignment enmHorizontalAlignment) => this.menmHorizontalAlignment = enmHorizontalAlignment;

    /// <summary>Gets or sets the padding value for all the edges.</summary>
    /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
    internal HorizontalAlignment HorizontalAlignment => this.menmHorizontalAlignment;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition) => this.menmHorizontalAlignment.ToString().ToLower();

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </returns>
    public override string ToString() => this.menmHorizontalAlignment.ToString();

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue" /> to <see cref="T:System.String" />.
    /// </summary>
    /// <param name="objHorizontalAlignmentValue">The padding value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator string(
      HorizontalAlignmentValue objHorizontalAlignmentValue)
    {
      return objHorizontalAlignmentValue.ToString();
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.HorizontalAlignmentValue" />.
    /// </summary>
    /// <param name="strFilter">The STR filter.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator HorizontalAlignmentValue(string strFilter) => Enum.IsDefined(typeof (HorizontalAlignment), (object) strFilter) ? new HorizontalAlignmentValue((HorizontalAlignment) Enum.Parse(typeof (HorizontalAlignment), strFilter, true)) : throw new Exception("Illegal horizontal alignment value.");
  }
}
