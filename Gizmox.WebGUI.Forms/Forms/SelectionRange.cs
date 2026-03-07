// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SelectionRange
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (SelectionRangeConverter))]
  public sealed class SelectionRange
  {
    private DateTime end;
    private DateTime start;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SelectionRange" /> class.
    /// </summary>
    /// <param name="lower">The lower.</param>
    /// <param name="upper">The upper.</param>
    public SelectionRange(DateTime lower, DateTime upper)
    {
      this.start = DateTime.MinValue.Date;
      this.end = DateTime.MaxValue.Date;
      if (lower < upper)
      {
        this.start = lower.Date;
        this.end = upper.Date;
      }
      else
      {
        this.start = upper.Date;
        this.end = lower.Date;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SelectionRange" /> class.
    /// </summary>
    /// <param name="range">The range.</param>
    public SelectionRange(SelectionRange range)
    {
      this.start = DateTime.MinValue.Date;
      this.end = DateTime.MaxValue.Date;
      this.start = range.start;
      this.end = range.end;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SelectionRange" /> class.
    /// </summary>
    public SelectionRange()
    {
      this.start = DateTime.MinValue.Date;
      this.end = DateTime.MaxValue.Date;
    }

    /// <summary>Gets or sets the end.</summary>
    /// <value>The end.</value>
    public DateTime End
    {
      get => this.end;
      set => this.end = value.Date;
    }

    /// <summary>Gets or sets the start.</summary>
    /// <value>The start.</value>
    public DateTime Start
    {
      get => this.start;
      set => this.start = value.Date;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "SelectionRange: Start: " + this.start.ToString() + ", End: " + this.end.ToString();
  }
}
