// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GroupingAreaStyleProperties
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class GroupingAreaStyleProperties
  {
    private DataGridView mobjDataGridView;
    private DataGridViewSkin mobjSkin;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GroupingAreaStyleProperties" /> class.
    /// </summary>
    /// <param name="objDataGridView">The obj data grid view.</param>
    public GroupingAreaStyleProperties(DataGridView objDataGridView)
    {
      this.mobjDataGridView = objDataGridView;
      this.mobjSkin = SkinFactory.GetSkin((ISkinable) this.mobjDataGridView) as DataGridViewSkin;
    }

    /// <summary>Gets or sets the height of the grouping area.</summary>
    /// <value>The height.</value>
    [Category("Appearance")]
    [Description("Background height of data grid view grouping area.")]
    public int Height
    {
      get => this.mobjDataGridView.GroupingAreaHeight;
      set => this.mobjDataGridView.GroupingAreaHeight = value;
    }

    /// <summary>Gets or sets the backcolor of the grouping area.</summary>
    /// <value>The backcolor of the grouping area.</value>
    [Category("Appearance")]
    [Description("Background color of data grid view grouping area.")]
    public Color BackColor
    {
      get => this.mobjDataGridView.GroupingAreaBackColor;
      set => this.mobjDataGridView.GroupingAreaBackColor = value;
    }

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    [Category("Appearance")]
    [Description("Background image of data grid view grouping area.")]
    [DefaultValue(null)]
    public ResourceHandle BackgroundImage
    {
      get => this.mobjDataGridView.GroupingAreaBackgroundImage;
      set => this.mobjDataGridView.GroupingAreaBackgroundImage = value;
    }

    /// <summary>Gets or sets the background image position.</summary>
    /// <value>The background image position.</value>
    [DefaultValue(BackgroundImagePosition.MiddleCenter)]
    [Category("Appearance")]
    [Description("Position of data grid view grouping area background image.")]
    public BackgroundImagePosition BackgroundImagePosition
    {
      get => this.mobjDataGridView.GroupingAreaBackgroundImagePosition;
      set => this.mobjDataGridView.GroupingAreaBackgroundImagePosition = value;
    }

    /// <summary>Gets or sets the background image repeat.</summary>
    /// <value>The background image repeat.</value>
    [DefaultValue(BackgroundImageRepeat.Repeat)]
    [Category("Appearance")]
    [Description("Repeat style of data grid view grouping area background image.")]
    public BackgroundImageRepeat BackgroundImageRepeat
    {
      get => this.mobjDataGridView.GroupingAreaBackgroundImageRepeat;
      set => this.mobjDataGridView.GroupingAreaBackgroundImageRepeat = value;
    }

    /// <summary>Gets or sets the color of the border.</summary>
    /// <value>The color of the border.</value>
    [Category("Appearance")]
    [Description("Border color of data grid view grouping area.")]
    public BorderColor BorderColor
    {
      get => this.mobjDataGridView.GroupingAreaBorderColor;
      set => this.mobjDataGridView.GroupingAreaBorderColor = value;
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value>The border style.</value>
    [Category("Appearance")]
    [Description("Border style of data grid view grouping area.")]
    public BorderStyle BorderStyle
    {
      get => this.mobjDataGridView.GroupingAreaBorderStyle;
      set => this.mobjDataGridView.GroupingAreaBorderStyle = value;
    }

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value>The width of the border.</value>
    [Category("Appearance")]
    [Description("Border width of data grid view grouping area.")]
    public BorderWidth BorderWidth
    {
      get => this.mobjDataGridView.GroupingAreaBorderWidth;
      set => this.mobjDataGridView.GroupingAreaBorderWidth = value;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Empty;

    /// <summary>
    /// Determines whether to serialize the backcolor of grouping area.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeBackColor() => SkinFactory.GetSkin((ISkinable) this.mobjDataGridView) is DataGridViewSkin skin && this.BackColor != skin.GroupingDropAreaStyle.BackColor;

    /// <summary>
    /// Determines whether to serialize the border color of grouping area.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderColor() => this.mobjSkin != null && this.BorderColor != this.mobjSkin.GroupingDropAreaStyle.BorderColor;

    /// <summary>
    ///  Determines whether to serialize the border style of grouping area.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderStyle() => this.mobjSkin != null && this.BorderStyle != this.mobjSkin.GroupingDropAreaStyle.BorderStyle;

    /// <summary>
    ///  Determines whether to serialize the border width of grouping area.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderWidth() => this.mobjSkin != null && this.BorderWidth != this.mobjSkin.GroupingDropAreaStyle.BorderWidth;

    /// <summary>
    /// Determines whether to serialize the height of grouping area.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeHeight() => this.mobjSkin != null && this.Height != this.mobjSkin.DropAreaHeight;
  }
}
