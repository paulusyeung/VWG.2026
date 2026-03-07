// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.DateTimePickerSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>DateTimePicker Skin</summary>
  [ToolboxBitmap(typeof (DateTimePicker), "Button.bmp")]
  [Serializable]
  public class DateTimePickerSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the buttons' normal container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons normal container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerNormalStyleLTR, this.ButtonsContainerNormalStyleRTL);

    /// <summary>Gets the buttons container normal style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerNormalStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerNormalStyleLTR));

    /// <summary>Gets the buttons container normal style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerNormalStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerNormalStyleRTL));

    /// <summary>Gets The buttons hover container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons hover container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerHoverStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerHoverStyleLTR, this.ButtonsContainerHoverStyleRTL);

    /// <summary>Gets the buttons container hover style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerHoverStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerHoverStyleLTR));

    /// <summary>Gets the buttons container hover style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerHoverStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerHoverStyleRTL));

    /// <summary>Gets The buttons pressed container style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The buttons pressed container style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerPressedStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.ButtonsContainerPressedStyleLTR, this.ButtonsContainerPressedStyleRTL);

    /// <summary>Gets the buttons container pressed style LTR.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerPressedStyleLTR => new StyleValue((CommonSkin) this, nameof (ButtonsContainerPressedStyleLTR));

    /// <summary>Gets the buttons container pressed style RTL.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue ButtonsContainerPressedStyleRTL => new StyleValue((CommonSkin) this, nameof (ButtonsContainerPressedStyleRTL));

    /// <summary>Gets the input value style.</summary>
    /// <value>The input value style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The input value style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue InputValueStyle => new StyleValue((CommonSkin) this, nameof (InputValueStyle));

    /// <summary>Gets or sets the width of up down icon container.</summary>
    /// <value>The width of up down icon container.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int UpDownIconContainerWidth => this.GetImageWidth(this.UpDownDownNormalImage, this.DefaultUpDownIconContainerWidth);

    /// <summary>Resets the width of up down icon container.</summary>
    private void ResetUpDownIconContainerWidth() => this.Reset("UpDownIconContainerWidth");

    /// <summary>Gets the default width of up down icon container.</summary>
    /// <value>The default width of up down icon container.</value>
    protected virtual int DefaultUpDownIconContainerWidth => 16;

    /// <summary>Gets or sets the width of up down icon.</summary>
    /// <value>The width of up down icon.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int UpDownIconWidth => this.GetImageWidth(this.UpDownUpNormalImage, this.DefaultUpDownIconWidth);

    /// <summary>Gets the default width of up down icon.</summary>
    /// <value>The default width of up down icon.</value>
    protected virtual int DefaultUpDownIconWidth => 15;

    /// <summary>Gets or sets the height of up icon.</summary>
    /// <value>The height of up icon.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int UpIconHeight => this.GetImageHeight(this.UpDownUpNormalImage, this.DefaultUpIconHeight);

    /// <summary>Gets the default height of up  icon.</summary>
    /// <value>The default height of up  icon.</value>
    protected virtual int DefaultUpIconHeight => 8;

    /// <summary>Gets or sets the height of down icon.</summary>
    /// <value>The height of down icon.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DownIconHeight => this.GetImageHeight(this.UpDownDownNormalImage, this.DefaultDownIconHeight);

    /// <summary>Gets the default height of up down icon.</summary>
    /// <value>The default height of up down icon.</value>
    protected virtual int DefaultDownIconHeight => 9;

    /// <summary>
    /// Gets or sets the width of the drop down icon container.
    /// </summary>
    /// <value>The width of the drop down icon container.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DropDownIconContainerWidth => this.GetImageWidth(this.DropDownNormalImage, this.DefaultDropDownIconContainerWidth);

    /// <summary>Resets the width of the drop down icon container.</summary>
    private void ResetDropDownIconContainerWidth() => this.Reset("DropDownIconContainerWidth");

    /// <summary>
    /// Gets the default width of the drop down icon container.
    /// </summary>
    /// <value>The default width of the drop down icon container.</value>
    protected virtual int DefaultDropDownIconContainerWidth => 17;

    /// <summary>
    /// Gets or sets the width of the check box icon container.
    /// </summary>
    /// <value>The width of the check box icon container.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The check box icon container width.")]
    public virtual int CheckBoxIconContainerWidth
    {
      get => this.GetValue<int>(nameof (CheckBoxIconContainerWidth), this.DefaultCheckBoxIconContainerWidth);
      set => this.SetValue(nameof (CheckBoxIconContainerWidth), (object) value);
    }

    /// <summary>The picker drop down size</summary>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The picker drop down size.")]
    public Size DropDownSize
    {
      get => this.GetValue<Size>(nameof (DropDownSize), Size.Empty);
      set => this.SetValue(nameof (DropDownSize), (object) value);
    }

    /// <summary>Resets the width of the check box icon container.</summary>
    private void ResetCheckBoxIconContainerWidth() => this.Reset("CheckBoxIconContainerWidth");

    /// <summary>
    /// Gets the default width of the check box icon container.
    /// </summary>
    /// <value>The default width of the check box icon container.</value>
    protected virtual int DefaultCheckBoxIconContainerWidth => 20;

    /// <summary>Gets or sets the width of the check box icon.</summary>
    /// <value>The width of the check box icon.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The check box icon width.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxIconWidth => this.GetMaxImageWidth(this.DefaultCheckBoxIconWidth, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

    /// <summary>Gets the default width of the check box icon.</summary>
    /// <value>The default width of the check box icon.</value>
    protected virtual int DefaultCheckBoxIconWidth => 15;

    /// <summary>Gets or sets the height of the check box icon.</summary>
    /// <value>The height of the check box icon.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The check box icon height.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxIconHeight => this.GetMaxImageHeight(this.DefaultCheckBoxIconHeight, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

    /// <summary>Gets the default height of the check box icon.</summary>
    /// <value>The default height of the check box icon.</value>
    protected virtual int DefaultCheckBoxIconHeight => 15;

    /// <summary>Gets or sets up down up over image.</summary>
    /// <value>Up down up over image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown up over image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UpDownUpOverImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownUpOverImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownUpOver.gif"));
      set => this.SetValue(nameof (UpDownUpOverImage), (object) value);
    }

    /// <summary>Resets up down up over image.</summary>
    private void ResetUpDownUpOverImage() => this.Reset("UpDownUpOverImage");

    /// <summary>Gets or sets up down up normal image.</summary>
    /// <value>Up down up normal image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown up normal image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UpDownUpNormalImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownUpNormalImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownUpNormal.gif"));
      set => this.SetValue(nameof (UpDownUpNormalImage), (object) value);
    }

    /// <summary>Resets up down up normal image.</summary>
    private void ResetUpDownUpNormalImage() => this.Reset("UpDownUpNormalImage");

    /// <summary>Gets or sets up down up down image.</summary>
    /// <value>Up down up down image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown up down image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UpDownUpDownImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownUpDownImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownUpDown.gif"));
      set => this.SetValue(nameof (UpDownUpDownImage), (object) value);
    }

    /// <summary>Resets up down up down image.</summary>
    private void ResetUpDownUpDownImage() => this.Reset("UpDownUpDownImage");

    /// <summary>Gets or sets up down down over image.</summary>
    /// <value>Up down down over image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown down over image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UpDownDownOverImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownDownOverImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownDownOver.gif"));
      set => this.SetValue(nameof (UpDownDownOverImage), (object) value);
    }

    /// <summary>Resets up down down over image.</summary>
    private void ResetUpDownDownOverImage() => this.Reset("UpDownDownOverImage");

    /// <summary>Gets or sets up down down normal image.</summary>
    /// <value>Up down down normal image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown down normal image")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public ImageResourceReference UpDownDownNormalImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownDownNormalImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownDownNormal.gif"));
      set => this.SetValue(nameof (UpDownDownNormalImage), (object) value);
    }

    /// <summary>Resets up down down normal image.</summary>
    private void ResetUpDownDownNormalImage() => this.Reset("UpDownDownNormalImage");

    /// <summary>Gets or sets up down down down image.</summary>
    /// <value>Up down down down image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("UpDown down down image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UpDownDownDownImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UpDownDownDownImage), new ImageResourceReference(typeof (DateTimePickerSkin), "UpDownDownDown.gif"));
      set => this.SetValue(nameof (UpDownDownDownImage), (object) value);
    }

    /// <summary>Resets up down down down image.</summary>
    private void ResetUpDownDownDownImage() => this.Reset("UpDownDownDownImage");

    /// <summary>Gets or sets the drop down normal image.</summary>
    /// <value>The drop down normal image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Drop down normal image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference DropDownNormalImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownNormalImage), new ImageResourceReference(typeof (DateTimePickerSkin), "DropDownNormal.gif"));
      set => this.SetValue(nameof (DropDownNormalImage), (object) value);
    }

    /// <summary>Resets the drop down normal image.</summary>
    private void ResetDropDownNormalImage() => this.Reset("DropDownNormalImage");

    /// <summary>Gets or sets the drop down over image.</summary>
    /// <value>The drop down over image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Drop down over image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference DropDownOverImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownOverImage), new ImageResourceReference(typeof (DateTimePickerSkin), "DropDownOver.gif"));
      set => this.SetValue(nameof (DropDownOverImage), (object) value);
    }

    /// <summary>Resets the drop down over image.</summary>
    private void ResetDropDownOverImage() => this.Reset("DropDownOverImage");

    /// <summary>Gets or sets the drop down down image.</summary>
    /// <value>The drop down down image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Drop down down image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference DropDownDownImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (DropDownDownImage), new ImageResourceReference(typeof (DateTimePickerSkin), "DropDownDown.gif"));
      set => this.SetValue(nameof (DropDownDownImage), (object) value);
    }

    /// <summary>Resets the drop down down image.</summary>
    private void ResetDropDownDownImage() => this.Reset("DropDownDownImage");

    /// <summary>Gets or sets the checked check box image.</summary>
    /// <value>The checked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The checked checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference CheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (CheckedCheckBoxImage), new ImageResourceReference(typeof (DateTimePickerSkin), "CheckBox1.gif"));
      set => this.SetValue(nameof (CheckedCheckBoxImage), (object) value);
    }

    /// <summary>Resets the checked check box image.</summary>
    private void ResetCheckedCheckBoxImage() => this.Reset("CheckedCheckBoxImage");

    /// <summary>Gets or sets the un checked check box image.</summary>
    /// <value>The un checked check box image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The unchecked checkbox image.")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public ImageResourceReference UnCheckedCheckBoxImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (UnCheckedCheckBoxImage), new ImageResourceReference(typeof (DateTimePickerSkin), "CheckBox0.gif"));
      set => this.SetValue(nameof (UnCheckedCheckBoxImage), (object) value);
    }

    /// <summary>Resets the un checked check box image.</summary>
    private void ResetUnCheckedCheckBoxImage() => this.Reset("UnCheckedCheckBoxImage");
  }
}
