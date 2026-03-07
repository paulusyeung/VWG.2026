// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutPanelCellStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// This class helps holding style information about each cell in table.
  /// </summary>
  internal class TableLayoutPanelCellStyle
  {
    private float fltTopPercent;
    private float fltBottomPercent;
    private float fltLeftPercent;
    private float fltRightPercent;
    private float fltTopMarginPixel;
    private float fltBottomMarginPixel;
    private float fltLeftMarginPixel;
    private float fltRightMarginPixel;

    public TableLayoutPanelCellStyle()
    {
      this.fltTopPercent = this.fltBottomPercent = this.fltLeftPercent = this.fltRightPercent = 0.0f;
      this.fltTopMarginPixel = this.fltBottomMarginPixel = this.fltLeftMarginPixel = this.fltRightMarginPixel = 0.0f;
    }

    public float TopPercent
    {
      get => this.fltTopPercent;
      set => this.fltTopPercent = value;
    }

    public float BottomPercent
    {
      get => this.fltBottomPercent;
      set => this.fltBottomPercent = value;
    }

    public float LeftPercent
    {
      get => this.fltLeftPercent;
      set => this.fltLeftPercent = value;
    }

    public float RightPercent
    {
      get => this.fltRightPercent;
      set => this.fltRightPercent = value;
    }

    public float TopMarginPixel
    {
      get => this.fltTopMarginPixel;
      set => this.fltTopMarginPixel = value;
    }

    public float BottomMarginPixel
    {
      get => this.fltBottomMarginPixel;
      set => this.fltBottomMarginPixel = value;
    }

    public float LeftMarginPixel
    {
      get => this.fltLeftMarginPixel;
      set => this.fltLeftMarginPixel = value;
    }

    public float RightMarginPixel
    {
      get => this.fltRightMarginPixel;
      set => this.fltRightMarginPixel = value;
    }
  }
}
