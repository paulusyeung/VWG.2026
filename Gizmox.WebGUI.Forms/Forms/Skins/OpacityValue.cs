// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.OpacityValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// hold sthe value that represents padding space between the body of the UI element and its edge.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (OpacityValueConverter))]
  [Serializable]
  public class OpacityValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private int mintOpacity;
    private static OpacityValue mobjEmpty = new OpacityValue(100);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.OpacityValue" /> class.
    /// </summary>
    /// <param name="intOpacity">The int opacity(Value should be between 0 and 100).</param>
    public OpacityValue(int intOpacity) => this.mintOpacity = intOpacity;

    /// <summary>Gets the empty opacity value.</summary>
    /// <value>The empty opacity value.</value>
    public static OpacityValue Empty => OpacityValue.mobjEmpty;

    /// <summary>Gets or sets the padding value for all the edges.</summary>
    /// <returns>The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
    internal int Opacity => this.mintOpacity;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      float num = 0.0f;
      if (this.mintOpacity > 0)
        num = (float) this.mintOpacity / 100f;
      string str = string.Format("opacity:{0}{1}", (object) num.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) declarationValue);
      if (objContext.PresentationEngine == PresentationEngine.InternetExplorer)
        str += string.Format(";filter:alpha(opacity={0}){1}", (object) this.mintOpacity.ToString(), (object) declarationValue);
      return str;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </returns>
    public override string ToString() => string.Format("{0}%", (object) this.mintOpacity.ToString((IFormatProvider) CultureInfo.InvariantCulture));

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.OpacityValue" /> to <see cref="T:System.String" />.
    /// </summary>
    /// <param name="objOpacityValue">The padding value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator string(OpacityValue objOpacityValue) => objOpacityValue.ToString();

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.OpacityValue" />.
    /// </summary>
    /// <param name="strFilter">The STR filter.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator OpacityValue(string strFilter)
    {
      if (strFilter.EndsWith("%"))
        strFilter = strFilter.Substring(0, strFilter.Length - 1);
      int result = -1;
      if (int.TryParse(strFilter, out result))
        return new OpacityValue(result);
      throw new Exception("You must supply integer values.");
    }
  }
}
