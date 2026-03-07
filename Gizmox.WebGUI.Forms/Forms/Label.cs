// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Label
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a standard Gizmox.WebGUI label.</summary>
  [ToolboxBitmap(typeof (Label), "Label_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [SRDescription("DescriptionLabel")]
  [DefaultProperty("Text")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("L")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (LabelSkin))]
  [Serializable]
  public class Label : Control
  {
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (Label));
    /// <summary>Provides a property reference to ImageList property.</summary>
    private static SerializableProperty ImageListProperty = SerializableProperty.Register(nameof (ImageList), typeof (ImageList), typeof (Label));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (Label));
    /// <summary>Provides a property reference to ImageIndex property.</summary>
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (Label), new SerializablePropertyMetadata((object) -1));
    /// <summary>Provides a property reference to ImageAlign property.</summary>
    private static SerializableProperty ImageAlignProperty = SerializableProperty.Register(nameof (ImageAlign), typeof (ContentAlignment), typeof (Label));
    /// <summary>Provides a property reference to TextAlign property.</summary>
    private static SerializableProperty TextAlignProperty = SerializableProperty.Register(nameof (TextAlign), typeof (ContentAlignment), typeof (Label));
    /// <summary>
    /// Provides a property reference to UseMnemonic property.
    /// </summary>
    private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register(nameof (UseMnemonic), typeof (bool), typeof (Label), new SerializablePropertyMetadata((object) true));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
    /// </summary>
    public Label()
    {
      this.SetState(Control.ControlState.TabStop, false);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, this.IsOwnerDraw());
      this.SetStyle(ControlStyles.FixedHeight | ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
    /// </summary>
    /// <param name="strText">The label text.</param>
    public Label(string strText)
      : this()
    {
      this.Text = strText;
    }

    /// <summary>Determines whether is owner draw.</summary>
    /// <returns>
    /// 	<c>true</c> if is owner draw; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsOwnerDraw() => this.FlatStyle != FlatStyle.System;

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fitted.
    /// </summary>
    /// <param name="objProposedSize">The custom-sized area for a control.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize = base.GetPreferredSize(objProposedSize);
      if (this.AutoSize)
      {
        Padding padding = this.Padding;
        int intWidth = -1;
        Size maximumSize = this.MaximumSize;
        if (!maximumSize.IsEmpty)
          intWidth = maximumSize.Width - padding.Horizontal;
        preferredSize = CommonUtils.GetStringMeasurements(this.Text, this.Font, intWidth);
        if (this.AutoSizeMode == AutoSizeMode.GrowOnly)
        {
          preferredSize.Width = Math.Max(preferredSize.Width, objProposedSize.Width);
          preferredSize.Height = Math.Max(preferredSize.Height, objProposedSize.Height);
        }
        preferredSize.Width += padding.Horizontal;
        preferredSize.Height += padding.Vertical;
      }
      return preferredSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeText("TX", this.Text);
      objWriter.WriteAttributeString("TA", this.GetProxyPropertyValue<ContentAlignment>("TextAlign", this.TextAlign).ToString());
      if (this.AutoSize)
        objWriter.WriteAttributeString("AS", "1");
      ResourceHandle proxyPropertyValue = this.GetProxyPropertyValue<ResourceHandle>("Image", this.Image);
      if (proxyPropertyValue == null)
        return;
      objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
      objWriter.WriteAttributeString("IA", this.ImageAlign.ToString());
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new LabelRenderer(this);

    /// <summary>Commits the value editing.</summary>
    /// <param name="objFormattedValue">The object formatted value.</param>
    protected override void CommitValueEditing(object objFormattedValue)
    {
      if (objFormattedValue == null || !(objFormattedValue is string))
        return;
      this.Text = objFormattedValue.ToString();
    }

    /// <summary>Gets a value indicating whether [can edit control].</summary>
    /// <value>
    ///   <c>true</c> if [can edit control]; otherwise, <c>false</c>.
    /// </value>
    public override bool CanEditControl => true;

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    public override Padding Padding
    {
      get => base.Padding;
      set
      {
        if (!(base.Padding != value))
          return;
        base.Padding = value;
        if (!this.AutoSize)
          return;
        this.PerformLayout(true);
      }
    }

    /// <summary>Gets or sets the alignment of text in the label.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.TopLeft"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception>
    [SRCategory("CatAppearance")]
    [DefaultValue(ContentAlignment.TopLeft)]
    [SRDescription("LabelTextAlignDescr")]
    [Localizable(true)]
    [ProxyBrowsable(true)]
    public ContentAlignment TextAlign
    {
      get => this.GetValue<ContentAlignment>(Label.TextAlignProperty, ContentAlignment.TopLeft);
      set
      {
        if (this.TextAlign == value)
          return;
        this.Update();
        if (value != ContentAlignment.TopLeft)
          this.SetValue<ContentAlignment>(Label.TextAlignProperty, value);
        else
          this.RemoveValue<ContentAlignment>(Label.TextAlignProperty);
        this.FireObservableItemPropertyChanged(nameof (TextAlign));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
    /// </summary>
    /// <returns>true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns>
    [DefaultValue(false)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRDescription("LabelAutoSizeDescr")]
    [SRCategory("CatLayout")]
    [RefreshProperties(RefreshProperties.All)]
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    public new bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(false)]
    [Browsable(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <returns>The text associated with this control.</returns>
    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [SettingsBindable(true)]
    public override string Text
    {
      get => this.UseMnemonic ? this.GetCommandText(base.Text) : base.Text;
      set
      {
        string str = value == null ? "" : value;
        if (!(base.Text != str))
          return;
        base.Text = str;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [SRDescription("LabelBackgroundImageDescr")]
    [SRCategory("CatAppearance")]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>
    /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
    /// </summary>
    /// <value></value>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>
    /// Gets or sets the flat style appearance of the label control.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default value is Standard.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. </exception>
    [SRCategory("CatAppearance")]
    [DefaultValue(FlatStyle.Standard)]
    [SRDescription("ButtonFlatStyleDescr")]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets the alignment of the image on the button control.
    /// </summary>
    [DefaultValue(ContentAlignment.MiddleCenter)]
    public ContentAlignment ImageAlign
    {
      get => this.GetValue<ContentAlignment>(Label.ImageAlignProperty, ContentAlignment.MiddleCenter);
      set
      {
        if (this.ImageAlign == value)
          return;
        this.Update();
        if (value != ContentAlignment.MiddleCenter)
          this.SetValue<ContentAlignment>(Label.ImageAlignProperty, value);
        else
          this.RemoveValue<ContentAlignment>(Label.ImageAlignProperty);
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
      get => this.GetValue<int>(Label.ImageIndexProperty, -1);
      set
      {
        if (this.ImageIndex == value)
          return;
        if (value != -1)
          this.SetValue<int>(Label.ImageIndexProperty, value);
        else
          this.RemoveValue<int>(Label.ImageIndexProperty);
        this.RemoveValue<string>(Label.ImageKeyProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ListViewSmallImageListDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get => this.GetValue<ImageList>(Label.ImageListProperty, (ImageList) null);
      set
      {
        if (this.ImageList == value)
          return;
        if (value != null)
          this.SetValue<ImageList>(Label.ImageListProperty, value);
        else
          this.RemoveValue<ImageList>(Label.ImageListProperty);
        this.Update();
      }
    }

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
      get => this.GetValue<string>(Label.ImageKeyProperty, string.Empty);
      set
      {
        if (!(this.ImageKey != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(Label.ImageKeyProperty, value);
        else
          this.RemoveValue<string>(Label.ImageKeyProperty);
        this.RemoveValue<int>(Label.ImageIndexProperty);
        this.Update();
      }
    }

    /// <summary>Shoulds the serialize image.</summary>
    /// <returns></returns>
    protected bool ShouldSerializeImage() => this.Image != null;

    /// <summary>
    /// Gets or sets the image that is displayed on a button control.
    /// </summary>
    [SRCategory("CatAppearance")]
    [SRDescription("ButtonImageDescr")]
    [ProxyBrowsable(true)]
    public ResourceHandle Image
    {
      get => this.GetImage(Label.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set => this.SetImage(Label.ImageProperty, value, this.ImageList);
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(100, 23);

    /// <summary>
    /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
    /// </summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override AutoSizeMode AutoSizeMode => AutoSizeMode.GrowAndShrink;

    /// <summary>Gets or sets a value indicating whether the control interprets an ampersand character (&amp;) in the control's <see cref="P:System.Windows.Forms.Control.Text"></see> property to be an access key prefix character.</summary>
    /// <returns>true if the label doesn't display the ampersand character and underlines the character after the ampersand in its displayed text and treats the underlined character as an access key; otherwise, false if the ampersand character is displayed in the text of the control. The default is true.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    [SRDescription("LabelUseMnemonicDescr")]
    public bool UseMnemonic
    {
      get => this.GetValue<bool>(Label.UseMnemonicProperty);
      set
      {
        if (!this.SetValue<bool>(Label.UseMnemonicProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Gets or sets a value that specifies whether text rendering should be compatible with previous releases of Windows Forms.</summary>
    /// <returns>true if text rendering should be compatible with previous releases of Windows Forms; otherwise, false. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("UseCompatibleTextRenderingDescr")]
    public bool UseCompatibleTextRendering
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the <see cref="T:System.Windows.Forms.Label"></see>, denoting that the <see cref="T:System.Windows.Forms.Label"></see> text extends beyond the specified length of the <see cref="T:System.Windows.Forms.Label"></see>.</summary>
    /// <returns>true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("LabelAutoEllipsisDescr")]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    public bool AutoEllipsis
    {
      get => false;
      set
      {
      }
    }
  }
}
