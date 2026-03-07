// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DataGridViewRowStyle : SerializableObject
  {
    /// <summary>
    /// Provides a property reference to BorderColor property.
    /// </summary>
    private static SerializableProperty BorderColorProperty = SerializableProperty.Register(nameof (BorderColor), typeof (Color), typeof (DataGridViewRowStyle), new SerializablePropertyMetadata());
    /// <summary>
    /// Provides a property reference to BorderStyle property.
    /// </summary>
    private static SerializableProperty BorderStyleProperty = SerializableProperty.Register(nameof (BorderStyle), typeof (BorderStyle), typeof (DataGridViewRowStyle), new SerializablePropertyMetadata());
    /// <summary>
    /// Provides a property reference to BorderWidth property.
    /// </summary>
    private static SerializableProperty BorderWidthProperty = SerializableProperty.Register(nameof (BorderWidth), typeof (int), typeof (DataGridViewRowStyle), new SerializablePropertyMetadata());
    private DataGridViewRow mobjOwnerDataGridViewRow;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowStyle" /> class.
    /// </summary>
    /// <param name="objDataGridViewRow">The obj data grid view row.</param>
    public DataGridViewRowStyle(DataGridViewRow objDataGridViewRow) => this.mobjOwnerDataGridViewRow = objDataGridViewRow;

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderColorDescr")]
    public virtual Color BorderColor
    {
      get => this.GetValue<Color>(DataGridViewRowStyle.BorderColorProperty, this.DefaultBorderColor);
      set
      {
        if (!this.SetValue<Color>(DataGridViewRowStyle.BorderColorProperty, value, this.DefaultBorderColor) || this.mobjOwnerDataGridViewRow == null)
          return;
        this.mobjOwnerDataGridViewRow.Update();
      }
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderStyleDescr")]
    public virtual BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(DataGridViewRowStyle.BorderStyleProperty, this.DefaultBorderStyle);
      set
      {
        if (!this.SetValue<BorderStyle>(DataGridViewRowStyle.BorderStyleProperty, value, this.DefaultBorderStyle) || this.mobjOwnerDataGridViewRow == null)
          return;
        this.mobjOwnerDataGridViewRow.Update();
      }
    }

    /// <summary>Gets or sets the thickness of the border.</summary>
    /// <value>Gets or sets a border thickness.</value>
    /// <remarks>The thinkness struct can be automaticly casted to and from int for backwords compatibility.</remarks>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderWidthDescr")]
    public virtual int BorderWidth
    {
      get => this.GetValue<int>(DataGridViewRowStyle.BorderWidthProperty, this.DefaultBorderWidth);
      set
      {
        if (!this.SetValue<int>(DataGridViewRowStyle.BorderWidthProperty, value, this.DefaultBorderWidth) || this.mobjOwnerDataGridViewRow == null)
          return;
        this.mobjOwnerDataGridViewRow.Update();
      }
    }

    /// <summary>Gets the default color of the border.</summary>
    /// <value>The default color of the border.</value>
    protected virtual Color DefaultBorderColor => Color.Empty;

    /// <summary>Gets the default border style.</summary>
    /// <value>The default border style.</value>
    protected virtual BorderStyle DefaultBorderStyle => BorderStyle.None;

    /// <summary>Gets the default width of the border.</summary>
    /// <value>The default width of the border.</value>
    protected virtual int DefaultBorderWidth => 0;
  }
}
