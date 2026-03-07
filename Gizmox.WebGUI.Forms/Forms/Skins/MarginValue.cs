// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MarginValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Holds the value for the space between controls</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (MarginValueConverter))]
  [Serializable]
  public class MarginValue : PaddingValue
  {
    /// <summary>The empty padding reference</summary>
    private static MarginValue mobjEmpty = new MarginValue(Padding.Empty);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" /> class.
    /// </summary>
    /// <param name="objValue">The padding value.</param>
    public MarginValue(Padding objValue)
      : base(objValue)
    {
    }

    /// <summary>Gets the name of the web style.</summary>
    /// <returns></returns>
    protected override string GetWebStyleName() => "margin";

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" /> to <see cref="T:Gizmox.WebGUI.Forms.Padding" />.
    /// </summary>
    /// <param name="objMarginValue">The margin value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Padding(MarginValue objMarginValue) => objMarginValue == null ? Padding.Empty : objMarginValue.Value;

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Padding" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" />.
    /// </summary>
    /// <param name="objPadding">The padding.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator MarginValue(Padding objPadding) => new MarginValue(objPadding);

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:System.String" />.
    /// </summary>
    /// <param name="objMarginValue">The margin value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator string(MarginValue objMarginValue)
    {
      if (objMarginValue.Value.IsAll)
        return objMarginValue.All.ToString();
      return string.Format("{0},{1},{2},{3}", (object) objMarginValue.Left, (object) objMarginValue.Top, (object) objMarginValue.Right, (object) objMarginValue.Bottom);
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
    /// </summary>
    /// <param name="strPadding">The padding string.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator MarginValue(string strPadding)
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
      return new MarginValue(objValue);
    }

    /// <summary>Gets an empty padding value.</summary>
    /// <value>The empty padding value.</value>
    public static MarginValue Empty => MarginValue.mobjEmpty;
  }
}
