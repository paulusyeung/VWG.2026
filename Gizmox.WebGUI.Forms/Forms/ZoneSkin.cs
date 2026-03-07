// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  [SkinContainer(typeof (DockingManagerSkin))]
  [Serializable]
  public class ZoneSkin : ContainerControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue TopDockIndicator => new StyleValue((CommonSkin) this, nameof (TopDockIndicator));

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue TopDockIndicatorHover => new StyleValue((CommonSkin) this, nameof (TopDockIndicatorHover));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopDockIndicatorWidth => this.GetImageSize(this.TopDockIndicator.BackgroundImage, Size.Empty).Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopDockIndicatorHeight => this.GetImageSize(this.TopDockIndicator.BackgroundImage, Size.Empty).Height;

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue RightDockIndicator => new StyleValue((CommonSkin) this, nameof (RightDockIndicator));

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue RightDockIndicatorHover => new StyleValue((CommonSkin) this, nameof (RightDockIndicatorHover));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightDockIndicatorWidth => this.GetImageSize(this.RightDockIndicator.BackgroundImage, Size.Empty).Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightDockIndicatorHeight => this.GetImageSize(this.RightDockIndicator.BackgroundImage, Size.Empty).Height;

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue BottomDockIndicator => new StyleValue((CommonSkin) this, nameof (BottomDockIndicator));

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue BottomDockIndicatorHover => new StyleValue((CommonSkin) this, nameof (BottomDockIndicatorHover));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int BottomDockIndicatorWidth => this.GetImageSize(this.BottomDockIndicator.BackgroundImage, Size.Empty).Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int BottomDockIndicatorHeight => this.GetImageSize(this.BottomDockIndicator.BackgroundImage, Size.Empty).Height;

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue LeftDockIndicator => new StyleValue((CommonSkin) this, nameof (LeftDockIndicator));

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue LeftDockIndicatorHover => new StyleValue((CommonSkin) this, nameof (LeftDockIndicatorHover));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftDockIndicatorWidth => this.GetImageSize(this.LeftDockIndicator.BackgroundImage, Size.Empty).Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftDockIndicatorHeight => this.GetImageSize(this.LeftDockIndicator.BackgroundImage, Size.Empty).Height;

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue CenterDockIndicator => new StyleValue((CommonSkin) this, nameof (CenterDockIndicator));

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue CenterDockIndicatorHover => new StyleValue((CommonSkin) this, nameof (CenterDockIndicatorHover));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CenterDockIndicatorWidth => this.GetImageSize(this.CenterDockIndicator.BackgroundImage, Size.Empty).Width;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CenterDockIndicatorHeight => this.GetImageSize(this.CenterDockIndicator.BackgroundImage, Size.Empty).Height;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LeftColumnWidth => this.LeftDockIndicatorWidth;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MiddleColumnWidth => Math.Max(this.TopDockIndicatorWidth, Math.Max(this.CenterDockIndicatorWidth, this.BottomDockIndicatorWidth));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int RightColumnWidth => this.RightDockIndicatorWidth;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopRowHeight => this.TopDockIndicatorHeight;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int MiddleRowHeight => Math.Max(this.LeftDockIndicatorHeight, Math.Max(this.CenterDockIndicatorHeight, this.RightDockIndicatorHeight));

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int BottomRowHeight => this.BottomDockIndicatorHeight;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TotalWidth => this.LeftColumnWidth + this.CenterDockIndicatorWidth + this.RightColumnWidth;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TotalHeight => this.TopDockIndicatorHeight + this.CenterDockIndicatorHeight + this.BottomRowHeight;
  }
}
