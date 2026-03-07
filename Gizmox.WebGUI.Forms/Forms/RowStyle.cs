// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RowStyle
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
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class RowStyle : TableLayoutStyle
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RowStyle" /> class.
    /// </summary>
    /// <param name="objSizeType">Type of the size.</param>
    /// <param name="fltHeight">The height.</param>
    public RowStyle(SizeType objSizeType, float fltHeight)
    {
      this.SizeType = objSizeType;
      this.Height = fltHeight;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RowStyle" /> class.
    /// </summary>
    /// <param name="objSizeType">Type of the size.</param>
    public RowStyle(SizeType objSizeType) => this.SizeType = objSizeType;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strHight"></param>
    public RowStyle(string strHight) => this.Height = float.Parse(strHight, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intHight"></param>
    public RowStyle(int intHight) => this.Height = (float) intHight;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RowStyle" /> class.
    /// </summary>
    public RowStyle()
    {
    }

    /// <summary>Gets or sets the height.</summary>
    /// <value>The height.</value>
    public float Height
    {
      get => this.Size;
      set
      {
        if ((double) this.Size == (double) value)
          return;
        this.Size = value;
        this.FireObservableItemPropertyChanged(nameof (Height));
      }
    }
  }
}
