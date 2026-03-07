// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ExtendedHeaderRowData
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (ExtendedHeaderRowDataTypeConverter))]
  [Serializable]
  public class ExtendedHeaderRowData : SerializableObject
  {
    private HeightMode menuHeightMode;
    private int mintHeight;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ExtendedHeaderRowData" /> class.
    /// </summary>
    /// <param name="enuHeightSizeMode">The enu height size mode.</param>
    /// <param name="intHeight">Height of the int.</param>
    public ExtendedHeaderRowData(HeightMode enuHeightSizeMode, int intHeight)
    {
      this.menuHeightMode = enuHeightSizeMode;
      this.mintHeight = intHeight;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ExtendedHeaderRowData" /> class.
    /// </summary>
    public ExtendedHeaderRowData()
    {
      this.menuHeightMode = HeightMode.Default;
      this.mintHeight = 0;
    }

    /// <summary>
    /// Height Size Mode.
    /// If Set to Default - get value from DataGridViewRow, If set to Custom - Use user defined value in local 'Height' property
    /// </summary>
    public HeightMode HeightSizeMode
    {
      get => this.menuHeightMode;
      set => this.menuHeightMode = value;
    }

    /// <summary>Custom Height value for Row</summary>
    public int Height
    {
      get => this.mintHeight;
      set => this.mintHeight = value;
    }

    /// <summary>Renders the row.</summary>
    /// <param name="objWriter">The obj writer.</param>
    internal void RenderRow(IResponseWriter objWriter)
    {
      objWriter.WriteStartElement("R");
      objWriter.WriteAttributeString("H", (this.HeightSizeMode == HeightMode.Custom ? this.Height : this.GetDefaultRowHeight()).ToString());
      objWriter.WriteEndElement();
    }

    /// <summary>Gets the default height of the row.</summary>
    /// <returns></returns>
    private int GetDefaultRowHeight() => DataGridViewRow.GetDefaultRowHeight();

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => nameof (ExtendedHeaderRowData);
  }
}
