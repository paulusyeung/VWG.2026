// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ButtonBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Implements the basic functionality common to button controls.
  /// </summary>
  [Serializable]
  public abstract class ButtonBase : Control
  {
    /// <summary>
    /// Provides a property reference to TextImageRelation property.
    /// </summary>
    private static SerializableProperty TextImageRelationProperty = SerializableProperty.Register(nameof (TextImageRelation), typeof (TextImageRelation), typeof (ButtonBase), new SerializablePropertyMetadata((object) TextImageRelation.Overlay));
    /// <summary>Provides a property reference to TextAlign property.</summary>
    private static SerializableProperty TextAlignProperty = SerializableProperty.Register(nameof (TextAlign), typeof (ContentAlignment), typeof (ButtonBase), new SerializablePropertyMetadata((object) ContentAlignment.MiddleCenter));
    /// <summary>Provides a property reference to ImageAlign property.</summary>
    private static SerializableProperty ImageAlignProperty = SerializableProperty.Register(nameof (ImageAlign), typeof (ContentAlignment), typeof (ButtonBase), new SerializablePropertyMetadata((object) ContentAlignment.MiddleCenter));
    /// <summary>
    /// Provides a property reference to ImageListItem property.
    /// </summary>
    private static SerializableProperty ImageListItemProperty = SerializableProperty.Register("ImageListItem", typeof (ImageList), typeof (ButtonBase), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (ButtonBase), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ImageIndex property.</summary>
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (ButtonBase), new SerializablePropertyMetadata((object) -1));
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (ButtonBase), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to FlatStyle property.</summary>
    private static SerializableProperty FlatStyleProperty = SerializableProperty.Register(nameof (FlatStyle), typeof (FlatStyle), typeof (ButtonBase), new SerializablePropertyMetadata((object) FlatStyle.Standard));
    /// <summary>The UseCompatibleTextRendering property registration.</summary>
    private static readonly SerializableProperty UseCompatibleTextRenderingProperty = SerializableProperty.Register(nameof (UseCompatibleTextRendering), typeof (bool), typeof (ButtonBase), new SerializablePropertyMetadata((object) false));
    /// <summary>The UseVisualStyleBackColor property registration.</summary>
    private static readonly SerializableProperty UseVisualStyleBackColorProperty = SerializableProperty.Register(nameof (UseVisualStyleBackColor), typeof (bool), typeof (ButtonBase), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to ImageSize property.</summary>
    private static SerializableProperty ImageSizeProperty = SerializableProperty.Register(nameof (ImageSize), typeof (Size), typeof (ButtonBase), new SerializablePropertyMetadata((object) new Size(16, 16)));
    /// <summary>
    /// Provides a property reference to UseMnemonic property.
    /// </summary>
    private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register(nameof (UseMnemonic), typeof (bool), typeof (ButtonBase), new SerializablePropertyMetadata((object) true));

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
    /// </see> property changes.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRDescription("ControlOnAutoSizeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public new event EventHandler AutoSizeChanged
    {
      add => base.AutoSizeChanged += value;
      remove => base.AutoSizeChanged -= value;
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeText("TX", this.Text);
      objWriter.WriteAttributeString("TA", this.GetProxyPropertyValue<ContentAlignment>("TextAlign", this.TextAlign).ToString());
      if (this.AutoEllipsis)
        objWriter.WriteAttributeString("AE", "1");
      ResourceHandle proxyPropertyValue = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
      if (proxyPropertyValue != null)
      {
        objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
        objWriter.WriteAttributeString("IA", this.GetProxyPropertyValue<ContentAlignment>("ImageAlign", this.GetProxyPropertyValue<ContentAlignment>("ImageAlign", this.ImageAlign)).ToString());
        objWriter.WriteAttributeString("TIR", ((int) this.GetProxyPropertyValue<TextImageRelation>("TextImageRelation", this.GetProxyPropertyValue<TextImageRelation>("TextImageRelation", this.TextImageRelation))).ToString());
      }
      else
        objWriter.WriteAttributeString("TIR", "0");
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      objWriter.WriteAttributeText("TX", this.Text);
    }

    /// <summary>Shoulds the serialize image.</summary>
    /// <returns></returns>
    protected bool ShouldSerializeImage() => this.Image != null;

    /// <summary>Shoulds the size of the serialize image.</summary>
    /// <returns></returns>
    private bool ShouldSerializeImageSize() => this.ContainsValue<Size>(ButtonBase.ImageSizeProperty);

    /// <summary>Shoulds serialize the use visual style back color.</summary>
    /// <returns></returns>
    private bool ShouldSerializeUseVisualStyleBackColor() => this.UseVisualStyleBackColor;

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fitted.
    /// </summary>
    /// <param name="objProposedSize">The custom-sized area for a control.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize = base.GetPreferredSize(objProposedSize);
      if (this.AutoSize)
        preferredSize = this.GetStringMeasurements(this.Text, this.Font);
      return preferredSize;
    }

    /// <summary>Gets the string measurements.</summary>
    /// <param name="strText">The STR text.</param>
    /// <param name="objFont">The obj font.</param>
    /// <returns></returns>
    protected virtual Size GetStringMeasurements(string strText, Font objFont) => CommonUtils.GetStringMeasurements(strText, objFont);

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new ButtonBaseRenderer(this);

    /// <summary>Commits the value editing.</summary>
    /// <param name="objFormattedValue">The object formatted value.</param>
    protected override void CommitValueEditing(object objFormattedValue)
    {
      if (objFormattedValue == null || !(objFormattedValue is string))
        return;
      this.Text = objFormattedValue.ToString();
    }

    public override bool CanEditControl => true;

    /// <summary>
    /// Gets or sets the image that is displayed on a button control.
    /// </summary>
    [SRDescription("ButtonImageDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    [ProxyBrowsable(true)]
    public ResourceHandle Image
    {
      get => this.GetImage(ButtonBase.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set
      {
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.SetImage(ButtonBase.ImageProperty, value, this.ImageList);
      }
    }

    /// <summary>
    /// Gets or sets the alignment of the image on the button control.
    /// </summary>
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [ProxyBrowsable(true)]
    public ContentAlignment ImageAlign
    {
      get => this.GetValue<ContentAlignment>(ButtonBase.ImageAlignProperty);
      set
      {
        if (!this.SetValue<ContentAlignment>(ButtonBase.ImageAlignProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the text align.</summary>
    /// <value></value>
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [ProxyBrowsable(true)]
    public virtual ContentAlignment TextAlign
    {
      get => this.GetValue<ContentAlignment>(ButtonBase.TextAlignProperty);
      set
      {
        if (!this.SetValue<ContentAlignment>(ButtonBase.TextAlignProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the position of text and image relative to each other.</summary>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.Overlay"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values.</exception>
    [Localizable(false)]
    [SRCategory("CatAppearance")]
    [DefaultValue(TextImageRelation.Overlay)]
    [SRDescription("ButtonTextImageRelationDescr")]
    [ProxyBrowsable(true)]
    public TextImageRelation TextImageRelation
    {
      get => this.GetValue<TextImageRelation>(ButtonBase.TextImageRelationProperty);
      set
      {
        if (!this.SetValue<TextImageRelation>(ButtonBase.TextImageRelationProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("ListViewItemImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int ImageIndex
    {
      get => this.ImageIndexInternal;
      set
      {
        if (this.ImageIndexInternal == value)
          return;
        this.ImageKeyInternal = string.Empty;
        this.ImageIndexInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets the image index internal.</summary>
    /// <value>The image index internal.</value>
    internal int ImageIndexInternal
    {
      get => this.GetValue<int>(ButtonBase.ImageIndexProperty);
      set => this.SetValue<int>(ButtonBase.ImageIndexProperty, value);
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ButtonImageListDescr")]
    [SRCategory("CatAppearance")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get => this.GetValue<ImageList>(ButtonBase.ImageListItemProperty);
      set
      {
        if (!this.SetValue<ImageList>(ButtonBase.ImageListItemProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the size of the image.</summary>
    /// <value>The size of the image.</value>
    public Size ImageSize
    {
      get
      {
        ImageList imageList = this.ImageList;
        return imageList != null ? imageList.ImageSize : this.GetValue<Size>(ButtonBase.ImageSizeProperty);
      }
      set
      {
        if (this.ImageList != null)
          throw new ArgumentException("Cannot set image size when an ImageList is assigned.", nameof (ImageSize));
        if (!this.SetValue<Size>(ButtonBase.ImageSizeProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Resets the size of the image.</summary>
    protected virtual void ResetImageSize() => this.RemoveValue<Size>(ButtonBase.ImageSizeProperty);

    /// <summary>
    /// Gets a value indicating whether this instance has image size.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has image size; otherwise, <c>false</c>.
    /// </value>
    protected bool HasImageSize => this.ImageList != null || this.ContainsValue<Size>(ButtonBase.ImageSizeProperty);

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    public string ImageKey
    {
      get => this.ImageKeyInternal;
      set
      {
        if (!(this.ImageKeyInternal != value))
          return;
        this.ImageIndexInternal = -1;
        this.ImageKeyInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets the image key internal.</summary>
    /// <value>The image key internal.</value>
    internal string ImageKeyInternal
    {
      get => this.GetValue<string>(ButtonBase.ImageKeyProperty);
      set => this.SetValue<string>(ButtonBase.ImageKeyProperty, value);
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [SettingsBindable(true)]
    public override string Text
    {
      get => this.UseMnemonic ? this.GetCommandText(base.Text) : base.Text;
      set
      {
        if (!(base.Text != value))
          return;
        base.Text = value;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Gets or sets the flat style.</summary>
    /// <value></value>
    [DefaultValue(FlatStyle.Standard)]
    public FlatStyle FlatStyle
    {
      get => this.GetValue<FlatStyle>(ButtonBase.FlatStyleProperty);
      set
      {
        if (!this.SetValue<FlatStyle>(ButtonBase.FlatStyleProperty, value))
          return;
        if (value == FlatStyle.Flat)
          this.CustomStyle = "F";
        else
          this.CustomStyle = string.Empty;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the control, denoting that the control text extends beyond the specified length of the control.</summary>
    /// <returns>true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is true.</returns>
    [SRDescription("ButtonAutoEllipsisDescr")]
    [SRCategory("CatBehavior")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(false)]
    public bool AutoEllipsis
    {
      get => this.GetState(Component.ComponentState.AutoEllipsis);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.AutoEllipsis, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value that indicates whether the control resizes based on its contents.</summary>
    /// <returns>true if the control automatically resizes based on its contents; otherwise, false. The default is true.</returns>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set
      {
        base.AutoSize = value;
        if (!value)
          return;
        this.AutoEllipsis = false;
      }
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(75, 23);

    /// <summary>Gets the appearance of the border and the colors used to indicate check state and mouse state.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatButtonAppearance"></see> values.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonFlatAppearance")]
    public FlatButtonAppearance FlatAppearance => new FlatButtonAppearance(this);

    /// <summary>Gets or sets a value that determines whether to use the compatible text rendering engine (GDI+) or not (GDI).</summary>
    /// <returns>true if the compatible text rendering engine (GDI+) is used; otherwise, false.</returns>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("UseCompatibleTextRenderingDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool UseCompatibleTextRendering
    {
      get => this.GetValue<bool>(ButtonBase.UseCompatibleTextRenderingProperty);
      set => this.SetValue<bool>(ButtonBase.UseCompatibleTextRenderingProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether an ampersand (&amp;) is included in the text of the control.</summary>
    /// <returns>true if an ampersand is shown; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonUseMnemonicDescr")]
    public bool UseMnemonic
    {
      get => this.GetValue<bool>(ButtonBase.UseMnemonicProperty);
      set
      {
        if (!this.SetValue<bool>(ButtonBase.UseMnemonicProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value that determines if the background is drawn using visual styles, if supported.</summary>
    /// <returns>true if the background is drawn using visual styles; otherwise, false.</returns>
    [SRDescription("ButtonUseVisualStyleBackColorDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(false)]
    public bool UseVisualStyleBackColor
    {
      get => this.GetValue<bool>(ButtonBase.UseVisualStyleBackColorProperty);
      set
      {
        if (!this.SetValue<bool>(ButtonBase.UseVisualStyleBackColorProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [SRDescription("ControlBackColorDescr")]
    [SRCategory("CatAppearance")]
    public override Color BackColor
    {
      get => base.BackColor;
      set
      {
        if (this.DesignMode)
        {
          if (value != Color.Empty)
            this.UseVisualStyleBackColor = false;
        }
        else
          this.UseVisualStyleBackColor = false;
        base.BackColor = value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether raise click event on mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldRaiseClickOnRightMouseDown => false;

    /// <summary>
    /// Gets a value indicating whether [supports key navigation].
    /// </summary>
    /// <value>
    /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
    /// </value>
    protected override bool SupportsKeyNavigation => false;
  }
}
