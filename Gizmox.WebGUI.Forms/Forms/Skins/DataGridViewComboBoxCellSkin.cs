// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.DataGridViewComboBoxCellSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>DataGridView ComboBox Cell Skin</summary>
  [ToolboxBitmap(typeof (ComboBox), "ComboBox.bmp")]
  [Serializable]
  public class DataGridViewComboBoxCellSkin : ComboBoxSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the cell normal style.</summary>
    /// <value>The cell normal style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CellNormalStyle => new StyleValue((CommonSkin) this, nameof (CellNormalStyle), true);

    /// <summary>Gets or sets the color of the normal fore.</summary>
    /// <value>The color of the normal fore.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color NormalForeColor => this.CellNormalStyle.ForeColor;
  }
}
