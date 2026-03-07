// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ComboBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Hosting;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ComboBox Skin</summary>
  [ToolboxBitmap(typeof (ComboBox), "ComboBox.bmp")]
  [Serializable]
  public class ComboBoxSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the data container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("ComboBox ListBox section style.")]
    public virtual BidirectionalSkinValue<StyleValue> ItemsContainerStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ListBoxContainerStyleLTR, this.ListBoxContainerStyleRTL);

    /// <summary>Gets the data container style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ListBoxContainerStyleLTR => new StyleValue((CommonSkin) this, nameof (ListBoxContainerStyleLTR));

    /// <summary>Gets the data container style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue ListBoxContainerStyleRTL => new StyleValue((CommonSkin) this, nameof (ListBoxContainerStyleRTL));

    /// <summary>Gets the data container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("ComboBox Data section style.")]
    public virtual BidirectionalSkinValue<StyleValue> DataContainerDropDownListModeStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DataContainerDropDownListModeStyleLTR, this.DataContainerDropDownListModeStyleRTL);

    /// <summary>Gets the data container style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerDropDownListModeStyleLTR => new StyleValue((CommonSkin) this, nameof (DataContainerDropDownListModeStyleLTR));

    /// <summary>Gets the data container style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerDropDownListModeStyleRTL => new StyleValue((CommonSkin) this, nameof (DataContainerDropDownListModeStyleRTL));

    /// <summary>Gets the data container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("ComboBox Data section style.")]
    public virtual BidirectionalSkinValue<StyleValue> DataContainerDropDownModeStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DataContainerDropDownModeStyleLTR, this.DataContainerDropDownModeStyleRTL);

    /// <summary>Gets the data container style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerDropDownModeStyleLTR => new StyleValue((CommonSkin) this, nameof (DataContainerDropDownModeStyleLTR));

    /// <summary>Gets the data container style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerDropDownModeStyleRTL => new StyleValue((CommonSkin) this, nameof (DataContainerDropDownModeStyleRTL));

    /// <summary>Gets the data container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("ComboBox Data section style in Simple mode.")]
    public virtual BidirectionalSkinValue<StyleValue> DataContainerSimpleModeStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DataContainerSimpleModeStyleLTR, this.DataContainerSimpleModeStyleRTL);

    /// <summary>Gets the data container style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerSimpleModeStyleLTR => new StyleValue((CommonSkin) this, nameof (DataContainerSimpleModeStyleLTR));

    /// <summary>Gets the data container style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DataContainerSimpleModeStyleRTL => new StyleValue((CommonSkin) this, nameof (DataContainerSimpleModeStyleRTL));

    /// <summary>Gets the drop down normal image container.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container.")]
    public virtual BidirectionalSkinValue<StyleValue> DropDownContainerNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DropDownContainerNormalStyleLTR, this.DropDownContainerNormalStyleRTL);

    /// <summary>Gets the drop down container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DropDownContainerNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (DropDownContainerNormalStyleLTR));

    /// <summary>Gets the drop down container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DropDownContainerNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (DropDownContainerNormalStyleRTL));

    /// <summary>Gets the drop down normal image container.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container hover.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DropDownContainerHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DropDownContainerHoverStyleLTR, this.DropDownContainerHoverStyleRTL);

    /// <summary>Gets the drop down container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container.")]
    public virtual StyleValue DropDownContainerHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (DropDownContainerHoverStyleLTR));

    /// <summary>Gets the drop down container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container.")]
    public virtual StyleValue DropDownContainerHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (DropDownContainerHoverStyleRTL));

    /// <summary>Gets the drop down normal image container.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container down.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DropDownContainerPressedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DropDownContainerPressedStyleLTR, this.DropDownContainerPressedStyleRTL);

    /// <summary>Gets the drop down container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container.")]
    public virtual StyleValue DropDownContainerPressedStyleLTR => new StyleValue((CommonSkin) this, nameof (DropDownContainerPressedStyleLTR));

    /// <summary>Gets the drop down container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DropDownContainerPressedStyleRTL => new StyleValue((CommonSkin) this, nameof (DropDownContainerPressedStyleRTL));

    /// <summary>Gets the drop down normal image container.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image container disabled.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DropDownContainerDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DropDownContainerDisabledStyleLTR, this.DropDownContainerDisabledStyleRTL);

    /// <summary>Gets the drop down container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DropDownContainerDisabledStyleLTR => new StyleValue((CommonSkin) this, nameof (DropDownContainerDisabledStyleLTR));

    /// <summary>Gets the drop down container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue DropDownContainerDisabledStyleRTL => new StyleValue((CommonSkin) this, nameof (DropDownContainerDisabledStyleRTL));

    /// <summary>Gets the pop up body style.</summary>
    /// <value>The pop up body style.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual StyleValue PopupBodyStyle => new StyleValue((CommonSkin) this, nameof (PopupBodyStyle));

    /// <summary>Gets the pop up item style.</summary>
    /// <value>The pop up item style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The popup item style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PopupItemStyle => new StyleValue((CommonSkin) this, nameof (PopupItemStyle));

    /// <summary>Gets the pop up item enter style.</summary>
    /// <value>The pop up item enter style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The popup item enter style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PopupItemEnterStyle => new StyleValue((CommonSkin) this, nameof (PopupItemEnterStyle), this.PopupItemStyle);

    /// <summary>Gets the color of the popup item enter fore.</summary>
    /// <value>The color of the popup item enter fore.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual Color PopupItemEnterForeColor => this.PopupItemEnterStyle.ForeColor;

    /// <summary>Gets the pop up item selected style.</summary>
    /// <value>The pop up item selected style.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual StyleValue PopupItemSelectedStyle => new StyleValue((CommonSkin) this, nameof (PopupItemSelectedStyle), this.PopupItemStyle);

    /// <summary>Gets the pop up item down style.</summary>
    /// <value>The pop up item down style.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual StyleValue PopupItemDownStyle => new StyleValue((CommonSkin) this, nameof (PopupItemDownStyle), this.PopupItemStyle);

    /// <summary>Gets the selected popup item.</summary>
    /// <value>The selected popup item.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual StyleValue SelectedPopupItem => new StyleValue((CommonSkin) this, nameof (SelectedPopupItem), this.PopupItemStyle);

    /// <summary>Gets the simple combo box text box border style.</summary>
    /// <value>The simple combo box text box border style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The simple combobox textbox border style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ComboBoxTextBoxContainerStyle => new StyleValue((CommonSkin) this, nameof (ComboBoxTextBoxContainerStyle));

    /// <summary>Gets the drop down list text box style.</summary>
    /// <value>The drop down list text box style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down list text box style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> DropDownListTextBoxStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.DropDownListTextBoxStyleLTR, this.DropDownListTextBoxStyleRTL);

    /// <summary>Gets the drop down list text box style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DropDownListTextBoxStyleLTR => new StyleValue((CommonSkin) this, nameof (DropDownListTextBoxStyleLTR));

    /// <summary>Gets the drop down list text box style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StyleValue DropDownListTextBoxStyleRTL => new StyleValue((CommonSkin) this, nameof (DropDownListTextBoxStyleRTL));

    /// <summary>Gets the text box style.</summary>
    /// <value>The text box style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The TextBox style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TextBoxStyle => new StyleValue((CommonSkin) this, nameof (TextBoxStyle));

    /// <summary>Gets the focused drop down list text box style.</summary>
    /// <value>The focused drop down list text box style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The focused drop down list text box style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FocusedDropDownListTextBoxStyle => new StyleValue((CommonSkin) this, nameof (FocusedDropDownListTextBoxStyle));

    /// <summary>Gets the text box disable style.</summary>
    /// <value>The text box disable style.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual StyleValue TextBoxDisableStyle => new StyleValue((CommonSkin) this, nameof (TextBoxDisableStyle));

    /// <summary>Gets the color box style.</summary>
    /// <value>The color box style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The color box style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ColorBoxStyle => new StyleValue((CommonSkin) this, nameof (ColorBoxStyle));

    /// <summary>Gets the drop down normal image.</summary>
    /// <value>The drop down normal image.</value>
    [Category("Images")]
    [Description("drop down normal image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> DropDownNormalImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "DropDownNormalImageLTR", "DropDownNormalImageRTL");

    /// <summary>
    /// Gets or sets the left to right drop down normal image.
    /// </summary>
    /// <value>The left to right drop down normal image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownNormalImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownNormalImageLTR), new ImageResourceReference(typeof (ComboBoxSkin), "DropDownNormal.gif"));
      set => this.SetValue(nameof (DropDownNormalImageLTR), (object) value);
    }

    /// <summary>
    /// Gets or sets the right to left drop down normal image.
    /// </summary>
    /// <value>The right to left drop down normal image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownNormalImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownNormalImageRTL), this.DropDownNormalImageLTR);
      set => this.SetValue(nameof (DropDownNormalImageRTL), (object) value);
    }

    /// <summary>Resets the drop down normal image.</summary>
    private void ResetDropDownNormalImage() => this.Reset("DropDownNormalImage");

    /// <summary>Gets the drop down over image.</summary>
    /// <value>The drop down over image.</value>
    [Category("Images")]
    [Description("The DropDown over Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> DropDownOverImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "DropDownOverImageLTR", "DropDownOverImageRTL");

    /// <summary>Gets or sets the drop down over image LTR.</summary>
    /// <value>The drop down over image LTR.</value>
    [Description("Drop down left to right over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownOverImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownOverImageLTR), new ImageResourceReference(typeof (ComboBoxSkin), "DropDownOver.gif"));
      set => this.SetValue(nameof (DropDownOverImageLTR), (object) value);
    }

    /// <summary>Gets or sets the drop down over image RTL.</summary>
    /// <value>The drop down over image RTL.</value>
    [Description("Drop down right to left over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownOverImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownOverImageRTL), this.DropDownOverImageLTR);
      set => this.SetValue(nameof (DropDownOverImageRTL), (object) value);
    }

    /// <summary>Resets the drop down over image.</summary>
    private void ResetDropDownOverImage() => this.Reset("DropDownOverImage");

    /// <summary>Gets the drop down down image.</summary>
    /// <value>The drop down down image.</value>
    [Category("Images")]
    [Description("The DropDown down Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> DropDownDownImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "DropDownDownImageLTR", "DropDownDownImageRTL");

    /// <summary>Gets or sets the drop down down image LTR.</summary>
    /// <value>The drop down down image LTR.</value>
    [Description("Drop down left to right down image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownDownImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownDownImageLTR), new ImageResourceReference(typeof (ComboBoxSkin), "DropDownDown.gif"));
      set => this.SetValue(nameof (DropDownDownImageLTR), (object) value);
    }

    /// <summary>Gets or sets the drop down down image RTL.</summary>
    /// <value>The drop down down image RTL.</value>
    [Description("Drop down down right to left image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownDownImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownDownImageRTL), this.DropDownDownImageLTR);
      set => this.SetValue(nameof (DropDownDownImageRTL), (object) value);
    }

    /// <summary>Resets the drop down down image.</summary>
    private void ResetDropDownDownImage() => this.Reset("DropDownDownImage");

    /// <summary>Gets the drop down image disable.</summary>
    /// <value>The drop down image disable.</value>
    [Category("Images")]
    [Description("The DropDown disable Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> DropDownImageDisable => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "DropDownImageDisableLTR", "DropDownImageDisableRTL");

    /// <summary>Gets or sets the drop down image disable LTR.</summary>
    /// <value>The drop down image disable LTR.</value>
    [Description("Drop down left to right image Disable")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownImageDisableLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownImageDisableLTR), new ImageResourceReference(typeof (ComboBoxSkin), "DropDownDisable.gif"));
      set => this.SetValue(nameof (DropDownImageDisableLTR), (object) value);
    }

    /// <summary>Gets or sets the drop down image disable RTL.</summary>
    /// <value>The drop down image disable RTL.</value>
    [Description("Drop down right to left image Disable")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference DropDownImageDisableRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownImageDisableRTL), this.DropDownImageDisableLTR);
      set => this.SetValue(nameof (DropDownImageDisableRTL), (object) value);
    }

    /// <summary>Resets the drop down down image disable.</summary>
    private void ResetDropDownDownImageDisable() => this.Reset("DropDownImageDisable");

    /// <summary>Gets or sets the width of the drop down image.</summary>
    /// <value>The width of the drop down image.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The drop down image width.")]
    public virtual int DropDownImageWidth
    {
      get => this.GetValue<int>(nameof (DropDownImageWidth), this.DefaultDropDownImageWidth);
      set => this.SetValue(nameof (DropDownImageWidth), (object) value);
    }

    /// <summary>Resets the width of the drop down image.</summary>
    private void ResetDropDownImageWidth() => this.Reset("DropDownImageWidth");

    /// <summary>Gets the default width of the drop down image.</summary>
    /// <value>The default width of the drop down image.</value>
    protected virtual int DefaultDropDownImageWidth => 15;

    /// <summary>Gets or sets the height of the drop down image.</summary>
    /// <value>The height of the drop down image.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual int DropDownImageHeight
    {
      get => this.GetValue<int>(nameof (DropDownImageHeight), this.DefaultDropDownImageHeight);
      set => this.SetValue(nameof (DropDownImageHeight), (object) value);
    }

    /// <summary>Resets the height of the drop down image.</summary>
    private void ResetDropDownImageHeight() => this.Reset("DropDownImageHeight");

    /// <summary>Gets the default height of the drop down image.</summary>
    /// <value>The default height of the drop down image.</value>
    protected virtual int DefaultDropDownImageHeight => 17;

    /// <summary>Gets or sets the width of the drop down image cell.</summary>
    /// <value>The width of the drop down image cell.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual int DropDownImageCellWidth
    {
      get => this.GetValue<int>(nameof (DropDownImageCellWidth), this.DefaultDropDownImageCellWidth);
      set => this.SetValue(nameof (DropDownImageCellWidth), (object) value);
    }

    /// <summary>Resets the width of the drop down image cell.</summary>
    private void ResetDropDownImageCellWidth() => this.Reset("DropDownImageCellWidth");

    /// <summary>Gets the default width of the drop down image cell.</summary>
    /// <value>The default width of the drop down image cell.</value>
    protected virtual int DefaultDropDownImageCellWidth => 16;

    /// <summary>Gets or sets the width of the color box.</summary>
    /// <value>The width of the color box.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The color box width.")]
    public virtual int ColorBoxWidth
    {
      get => this.GetValue<int>(nameof (ColorBoxWidth), this.DefaultColorBoxWidth);
      set => this.SetValue(nameof (ColorBoxWidth), (object) value);
    }

    /// <summary>Resets the width of the color box.</summary>
    private void ResetColorBoxWidth() => this.Reset("ColorBoxWidth");

    /// <summary>Gets or sets the height of the color box.</summary>
    /// <value>The height of the color box.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The color box height.")]
    public virtual int ColorBoxHeight
    {
      get => this.GetValue<int>(nameof (ColorBoxHeight), this.DefaultColorBoxHeight);
      set => this.SetValue(nameof (ColorBoxHeight), (object) value);
    }

    /// <summary>Resets the height of the color box.</summary>
    private void ResetColorBoxHeight() => this.Reset("ColorBoxHeight");

    /// <summary>Gets or sets the width of the image box.</summary>
    /// <value>The width of the image box.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The image box width.")]
    public virtual int ImageBoxWidth
    {
      get => this.GetValue<int>(nameof (ImageBoxWidth), this.DefaultColorBoxWidth);
      set => this.SetValue(nameof (ImageBoxWidth), (object) value);
    }

    /// <summary>Resets the width of the image box.</summary>
    private void ResetImageBoxWidth() => this.Reset("ImageBoxWidth");

    /// <summary>Gets or sets the height of the image box.</summary>
    /// <value>The height of the image box.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The Image box height.")]
    public virtual int ImageBoxHeight
    {
      get => this.GetValue<int>(nameof (ImageBoxHeight), this.DefaultImageBoxHeight);
      set => this.SetValue(nameof (ImageBoxHeight), (object) value);
    }

    private void ResetImageBoxHeight() => this.Reset("ImageBoxHeight");

    /// <summary>Gets the default width of the color box.</summary>
    /// <value>The default width of the color box.</value>
    protected virtual int DefaultColorBoxWidth => 20;

    /// <summary>Gets the default height of the color box.</summary>
    /// <value>The default height of the color box.</value>
    protected virtual int DefaultColorBoxHeight => 14;

    /// <summary>Gets the default height of the Image box.</summary>
    /// <value>The default height of the Image box.</value>
    protected virtual int DefaultImageBoxHeight => 16;

    /// <summary>Gets the default width of the image box.</summary>
    /// <value>The default width of the image box.</value>
    protected virtual int DefaultImageBoxWidth => 16;

    /// <summary>Gets the width of the preferd image box.</summary>
    /// <value>The width of the preferd image box.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreferdImageBoxWidth => this.ImageBoxWidth + this.PopupItemStyle.Padding.Horizontal;

    /// <summary>Gets the width of the preferd color box.</summary>
    /// <value>The width of the preferd color box.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreferdColorBoxWidth => this.ColorBoxWidth + this.PopupItemStyle.Padding.Horizontal;

    /// <summary>
    /// Gets or sets the height of the simple combo box input.
    /// </summary>
    /// <value>The height of the simple combo box input.</value>
    [Category("Sizes")]
    [Description("The height of the simple combo box input.")]
    public int SimpleComboBoxInputHeight
    {
      get => this.GetValue<int>(nameof (SimpleComboBoxInputHeight), this.DefaultSimpleComboBoxInputHeight);
      set => this.SetValue(nameof (SimpleComboBoxInputHeight), (object) value);
    }

    /// <summary>
    /// Gets the default height of the simple combo box input.
    /// </summary>
    /// <value>The default height of the simple combo box input.</value>
    protected virtual int DefaultSimpleComboBoxInputHeight => 17;

    /// <summary>Gets or sets the width of the popup window offset.</summary>
    /// <value>The width of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset width for the popup window.")]
    public virtual int PopupWindowOffsetWidth
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetWidth), this.DefaultPopupWindowOffsetWidth);
      set => this.SetValue(nameof (PopupWindowOffsetWidth), (object) value);
    }

    /// <summary>Resets the width of the popup window offset.</summary>
    private void ResetPopupWindowOffsetWidth() => this.Reset("PopupWindowOffsetWidth");

    /// <summary>Gets the default width of the popup window offset.</summary>
    /// <value>The default width of the popup window offset.</value>
    protected virtual int DefaultPopupWindowOffsetWidth
    {
      get
      {
        BorderWidth borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int left = borderWidth.Left;
        borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int right = borderWidth.Right;
        int num = left + right + this.PopupWindowStyle.CenterStyle.Padding.Horizontal;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.RightPopupWindowFrameWidth + this.LeftPopupWindowFrameWidth;
      }
    }

    /// <summary>Gets or sets the height of the popup window offset.</summary>
    /// <value>The height of the popup window offset.</value>
    [Category("Sizes")]
    [Description("The offset height for the popup window.")]
    public virtual int PopupWindowOffsetHeight
    {
      get => this.GetValue<int>(nameof (PopupWindowOffsetHeight), this.DefaultPopupWindowOffsetHeight);
      set => this.SetValue(nameof (PopupWindowOffsetHeight), (object) value);
    }

    /// <summary>Resets the height of the popup window offset.</summary>
    private void ResetPopupWindowOffsetHeight() => this.Reset("PopupWindowOffsetHeight");

    /// <summary>Gets the default height of the popup window offset.</summary>
    /// <value>The default height of the popup window offset.</value>
    protected virtual int DefaultPopupWindowOffsetHeight
    {
      get
      {
        BorderWidth borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int top = borderWidth.Top;
        borderWidth = this.PopupWindowStyle.CenterStyle.BorderWidth;
        int bottom = borderWidth.Bottom;
        int num = top + bottom + this.PopupWindowStyle.CenterStyle.Padding.Vertical;
        return HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow ? num : num + this.TopPopupWindowFrameHeight + this.BottomPopupWindowFrameHeight;
      }
    }

    /// <summary>
    /// Gets or sets the width of the left popup window frame.
    /// </summary>
    /// <value>The width of the left popup window frame.</value>
    [Category("Sizes")]
    [Description("The width of the left popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int LeftPopupWindowFrameWidth => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Left);

    /// <summary>Resets the width of the left popup window frame.</summary>
    internal void ResetLeftPopupWindowFrameWidth() => this.Reset("LeftPopupWindowFrameWidth");

    /// <summary>
    /// Gets or sets the width of the right popup window frame.
    /// </summary>
    /// <value>The width of the right popup window frame.</value>
    [Category("Sizes")]
    [Description("The width of the right popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int RightPopupWindowFrameWidth => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Right);

    /// <summary>Resets the width of the right popup window frame.</summary>
    internal void ResetRightPopupWindowFrameWidth() => this.Reset("RightPopupWindowFrameWidth");

    /// <summary>
    /// Gets or sets the height of the top popup window frame.
    /// </summary>
    /// <value>The height of the top popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the top popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int TopPopupWindowFrameHeight => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Top);

    /// <summary>Resets the height of the top popup window frame.</summary>
    internal void ResetTopPopupWindowFrameHeight() => this.Reset("TopPopupWindowFrameHeight");

    /// <summary>
    /// Gets or sets the height of the bottom popup window frame.
    /// </summary>
    /// <value>The height of the bottom popup window frame.</value>
    [Category("Sizes")]
    [Description("The height of the bottom popup window frame.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual int BottomPopupWindowFrameHeight => this.GetFrameEdgeSize(this.PopupWindowStyle, CommonSkin.FrameEdge.Bottom);

    /// <summary>Resets the height of the bottom popup window frame.</summary>
    internal void ResetBottomPopupWindowFrameHeight() => this.Reset("BottomPopupWindowFrameHeight");

    /// <summary>Gets the opup window style.</summary>
    /// <value>The opup window style.</value>
    [Category("States")]
    [Description("The popup window style.")]
    public FrameStyleValue PopupWindowStyle => new FrameStyleValue(this.LeftBottomPopupWindowStyle, this.LeftPopupWindowStyle, this.LeftTopPopupWindowStyle, this.TopPopupWindowStyle, this.RightTopPopupWindowStyle, this.RightPopupWindowStyle, this.RightBottomPopupWindowStyle, this.BottomPopupWindowStyle, this.CenterPopupWindowStyle);

    /// <summary>Gets the center popup window style.</summary>
    /// <value>The center popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual StyleValue CenterPopupWindowStyle => new StyleValue((CommonSkin) this, nameof (CenterPopupWindowStyle), this.PopupSkin.CenterStyle, true);

    /// <summary>Gets the left popup window style.</summary>
    /// <value>The left popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftPopupWindowStyle), this.PopupSkin.LeftStyle, true);

    /// <summary>Gets the top popup window style.</summary>
    /// <value>The top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue TopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (TopPopupWindowStyle), this.PopupSkin.TopStyle, true);

    /// <summary>Gets the bottom popup window style.</summary>
    /// <value>The bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue BottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (BottomPopupWindowStyle), this.PopupSkin.BottomStyle, true);

    /// <summary>Gets the right popup window style.</summary>
    /// <value>The right popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightPopupWindowStyle), this.PopupSkin.RightStyle, true);

    /// <summary>Gets the right top popup window style.</summary>
    /// <value>The right top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightTopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightTopPopupWindowStyle), this.PopupSkin.RightTopStyle, true);

    /// <summary>Gets the left top popup window style.</summary>
    /// <value>The left top popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftTopPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftTopPopupWindowStyle), this.PopupSkin.LeftTopStyle, true);

    /// <summary>Gets the left bottom popup window style.</summary>
    /// <value>The left bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue LeftBottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (LeftBottomPopupWindowStyle), this.PopupSkin.LeftBottomStyle, true);

    /// <summary>Gets the right bottom popup window style.</summary>
    /// <value>The right bottom popup window style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual FramePartStyleValue RightBottomPopupWindowStyle => new FramePartStyleValue((CommonSkin) this, nameof (RightBottomPopupWindowStyle), this.PopupSkin.RightBottomStyle, true);

    /// <summary>Gets the popups skin.</summary>
    /// <value>The popups skin.</value>
    private PopupsSkin PopupSkin => SkinFactory.GetSkin(this.Owner, typeof (PopupsSkin), true) as PopupsSkin;
  }
}
