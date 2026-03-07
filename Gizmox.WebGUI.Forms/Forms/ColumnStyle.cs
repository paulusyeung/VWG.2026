// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ColumnStyle : TableLayoutStyle
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnStyle" /> class.
    /// </summary>
    /// <param name="objSizeType">Type of the size.</param>
    /// <param name="fltWidth">The width.</param>
    public ColumnStyle(SizeType objSizeType, float fltWidth)
    {
      this.SizeType = objSizeType;
      this.Width = fltWidth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnStyle" /> class.
    /// </summary>
    /// <param name="objSizeType">Type of the size.</param>
    public ColumnStyle(SizeType objSizeType) => this.SizeType = objSizeType;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnStyle" /> instance.
    /// </summary>
    /// <param name="strWidth">Width of the current column.</param>
    public ColumnStyle(string strWidth) => this.Width = float.Parse(strWidth, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnStyle" /> instance.
    /// </summary>
    /// <param name="intWidth">Width of the current column.</param>
    public ColumnStyle(int intWidth) => this.Width = (float) intWidth;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnStyle" /> class.
    /// </summary>
    public ColumnStyle()
    {
    }

    /// <summary>Gets or sets the width.</summary>
    /// <value>The width.</value>
    public float Width
    {
      get => this.Size;
      set
      {
        if ((double) this.Size == (double) value)
          return;
        this.Size = value;
        this.FireObservableItemPropertyChanged(nameof (Width));
      }
    }
  }
}
