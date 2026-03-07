// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolBar
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>ToolBar control.</summary>
  [ToolboxBitmap(typeof (ToolBar), "ToolBar_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [ToolboxItemCategory("Menus & Toolbars")]
  [Gizmox.WebGUI.Forms.MetadataTag("T1")]
  [DefaultEvent("ButtonClick")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ToolBarSkin))]
  [ProxyComponent(typeof (ProxyToolBar))]
  [Serializable]
  public class ToolBar : Control
  {
    /// <summary>Provides a property reference to MenuHandle property.</summary>
    private static SerializableProperty MenuHandleProperty = SerializableProperty.Register(nameof (MenuHandle), typeof (bool), typeof (ToolBar));
    /// <summary>Provides a property reference to DragHandle property.</summary>
    private static SerializableProperty DragHandleProperty = SerializableProperty.Register(nameof (DragHandle), typeof (bool), typeof (ToolBar));
    /// <summary>Provides a property reference to TextAlign property.</summary>
    private static SerializableProperty TextAlignProperty = SerializableProperty.Register(nameof (TextAlign), typeof (ToolBarTextAlign), typeof (ToolBar));
    /// <summary>Provides a property reference to Appearance property.</summary>
    private static SerializableProperty AppearanceProperty = SerializableProperty.Register(nameof (Appearance), typeof (ToolBarAppearance), typeof (ToolBar));
    /// <summary>
    /// Provides a property reference to RightToLeft property.
    /// </summary>
    private static SerializableProperty RightToLeftProperty = SerializableProperty.Register(nameof (RightToLeft), typeof (bool), typeof (ToolBar));
    /// <summary>Provides a property reference to ButtonSize property.</summary>
    private static SerializableProperty ButtonSizeProperty = SerializableProperty.Register(nameof (ButtonSize), typeof (Size), typeof (ToolBar));
    /// <summary>Provides a property reference to ImageSize property.</summary>
    private static SerializableProperty ImageSizeProperty = SerializableProperty.Register(nameof (ImageSize), typeof (Size), typeof (ToolBar));
    /// <summary>Provides a property reference to ImageList property.</summary>
    private static SerializableProperty ImageListProperty = SerializableProperty.Register(nameof (ImageList), typeof (ImageList), typeof (ToolBar));
    /// <summary>
    /// Provides a property reference to ButtonsSizeAttribute property.
    /// </summary>
    private static SerializableProperty ButtonsSizeAttributeProperty = SerializableProperty.Register(nameof (ButtonsSizeAttribute), typeof (string), typeof (ToolBar));
    /// <summary>
    /// Provides a property reference to ButtonsDock property.
    /// </summary>
    private static SerializableProperty ButtonsDockProperty = SerializableProperty.Register(nameof (ButtonsDock), typeof (string), typeof (ToolBar));
    /// <summary>Provides a property reference to Buttons property.</summary>
    private static SerializableProperty ButtonsProperty = SerializableProperty.Register(nameof (Buttons), typeof (ToolBarItemCollection), typeof (ToolBar));
    /// <summary>The ButtonClick event registration.</summary>
    private static readonly SerializableEvent ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof (ToolBarButtonClickEventHandler), typeof (ToolBar));

    /// <summary>Occurs when a user clicks on a button</summary>
    public event ToolBarButtonClickEventHandler ButtonClick
    {
      add => this.AddCriticalHandler(ToolBar.ButtonClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolBar.ButtonClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ButtonClick event.</summary>
    internal ToolBarButtonClickEventHandler ButtonClickHandler => (ToolBarButtonClickEventHandler) this.GetHandler(ToolBar.ButtonClickEvent);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ToolBar" /> instance.
    /// </summary>
    public ToolBar()
    {
      this.SetValue<ToolBarItemCollection>(ToolBar.ButtonsProperty, this.CreateButtonCollection());
      this.Dock = DockStyle.Top;
      this.AutoSize = true;
      this.SetStyle(ControlStyles.UserPaint, false);
      this.SetStyle(ControlStyles.FixedHeight, this.AutoSize);
      this.SetStyle(ControlStyles.FixedWidth, false);
      this.TabStop = false;
    }

    /// <summary>Fires an contained event.</summary>
    /// <param name="objEvent">event.</param>
    /// <param name="objButton">The obj button.</param>
    internal void FireEvent(IEvent objEvent, ToolBarButton objButton)
    {
      if (!(objEvent.Type == "Click"))
        return;
      if (objButton != null)
        this.OnButtonClick(new ToolBarButtonClickEventArgs(objButton));
      this.OnClick(EventArgs.Empty);
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected override string ClientEventsPropogationTags => string.Format("WC:{0}", (object) "T2");

    /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolBar.ButtonClick"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.ToolBarButtonClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnButtonClick(ToolBarButtonClickEventArgs e)
    {
      ToolBarButtonClickEventHandler buttonClickHandler = this.ButtonClickHandler;
      if (buttonClickHandler == null)
        return;
      buttonClickHandler((object) this, e);
    }

    /// <summary>Gets the tool bar button skin.</summary>
    /// <value>The tool bar button skin.</value>
    private ToolBarButtonSkin ToolBarButtonSkin
    {
      get
      {
        ToolBarButtonSkin toolBarButtonSkin = (ToolBarButtonSkin) null;
        if (this.Buttons.Count > 0)
          toolBarButtonSkin = SkinFactory.GetSkin((ISkinable) this.Buttons[0], typeof (ToolBarButtonSkin)) as ToolBarButtonSkin;
        return toolBarButtonSkin;
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [SRDescription("ToolBarAutoSizeDescr")]
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
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
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>
    /// 
    /// </summary>
    internal string ButtonsDock
    {
      get => this.GetValue<string>(ToolBar.ButtonsDockProperty, "L");
      private set
      {
        if (!(this.ButtonsDock != value))
          return;
        if (value != "L")
          this.SetValue<string>(ToolBar.ButtonsDockProperty, value);
        else
          this.RemoveValue<string>(ToolBar.ButtonsDockProperty);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal string ButtonsSizeAttribute
    {
      get => this.GetValue<string>(ToolBar.ButtonsSizeAttributeProperty, "W");
      private set
      {
        if (!(this.ButtonsSizeAttribute != value))
          return;
        if (value != "W")
          this.SetValue<string>(ToolBar.ButtonsSizeAttributeProperty, value);
        else
          this.RemoveValue<string>(ToolBar.ButtonsSizeAttributeProperty);
      }
    }

    /// <summary>Gets or sets the toolbar image list.</summary>
    /// <value></value>
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get => this.GetValue<ImageList>(ToolBar.ImageListProperty, (ImageList) null);
      set
      {
        if (this.ImageList == value)
          return;
        this.Update();
        if (value != null)
          this.SetValue<ImageList>(ToolBar.ImageListProperty, value);
        else
          this.RemoveValue<ImageList>(ToolBar.ImageListProperty);
      }
    }

    /// <summary>Gets the size of the images in the image list assigned to the toolbar.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the size of the images (in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>) assigned to the <see cref="T:Gizmox.WebGUI.Forms.ToolBar"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolBarImageSizeDescr")]
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Size ImageSize
    {
      get
      {
        if (this.ImageList != null)
          return this.ImageList.ImageSize;
        Size size = this.GetValue<Size>(ToolBar.ImageSizeProperty, Size.Empty);
        return size != Size.Empty ? size : new Size(16, 16);
      }
      set
      {
        if (this.ImageList != null)
          throw new ArgumentException("Cannot set image size when an ImageList is assigned.", nameof (ImageSize));
        if (!(this.GetValue<Size>(ToolBar.ImageSizeProperty, Size.Empty) != value))
          return;
        if (value != Size.Empty)
          this.SetValue<Size>(ToolBar.ImageSizeProperty, value);
        else
          this.RemoveValue<Size>(ToolBar.ImageSizeProperty);
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Determines if image size serialization is required.</summary>
    private bool ShouldSerializeImageSize() => this.ImageList == null && this.ImageSize != Size.Empty;

    /// <summary>Resets the size of the image.</summary>
    private void ResetImageSize()
    {
      if (this.ImageList != null)
        this.ImageSize = this.ImageList.ImageSize;
      else
        this.ImageSize = Size.Empty;
    }

    /// <summary>Gets or sets the size of the buttons.</summary>
    /// <value></value>
    public Size ButtonSize
    {
      get
      {
        Size buttonSizeInternal = this.ButtonSizeInternal;
        if (!buttonSizeInternal.IsEmpty)
          return buttonSizeInternal;
        if (this.Buttons != null && this.Buttons.Count > 0)
          return this.CalculateSize();
        return this.TextAlign == ToolBarTextAlign.Underneath ? new Size(39, 36) : new Size(23, 22);
      }
      set
      {
        if (!(this.ButtonSizeInternal != value))
          return;
        this.ButtonSizeInternal = value;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    internal Size ButtonSizeInternal
    {
      get => this.GetValue<Size>(ToolBar.ButtonSizeProperty, Size.Empty);
      set
      {
        if (value != Size.Empty)
          this.SetValue<Size>(ToolBar.ButtonSizeProperty, value);
        else
          this.RemoveValue<Size>(ToolBar.ButtonSizeProperty);
      }
    }

    /// <summary>Gets the toolbar button collecction</summary>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public virtual ToolBarItemCollection Buttons => this.GetValue<ToolBarItemCollection>(ToolBar.ButtonsProperty, (ToolBarItemCollection) null);

    /// <summary>
    /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
    /// </summary>
    /// <value></value>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override RightToLeft RightToLeft
    {
      get => base.RightToLeft;
      set => base.RightToLeft = value;
    }

    /// <summary>Gets or sets the toolbar appearance.</summary>
    /// <value></value>
    [DefaultValue(ToolBarAppearance.Normal)]
    public ToolBarAppearance Appearance
    {
      get => this.GetValue<ToolBarAppearance>(ToolBar.AppearanceProperty, ToolBarAppearance.Normal);
      set
      {
        if (this.Appearance == value)
          return;
        this.Update();
        if (value != ToolBarAppearance.Normal)
          this.SetValue<ToolBarAppearance>(ToolBar.AppearanceProperty, value);
        else
          this.RemoveValue<ToolBarAppearance>(ToolBar.AppearanceProperty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to show tooltips.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to show tooltips; otherwise, <c>false</c>.
    /// </value>
    public bool ShowToolTips
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to display dropdown arrows.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to display dropdown arrows; otherwise, <c>false</c>.
    /// </value>
    public bool DropDownArrows
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets the default text align.</summary>
    /// <value>The default text align.</value>
    protected virtual ToolBarTextAlign DefaultTextAlign => ToolBarTextAlign.Underneath;

    /// <summary>Specifies the alignment of text on the toolbar button control.</summary>
    /// <value></value>
    public ToolBarTextAlign TextAlign
    {
      get => this.GetValue<ToolBarTextAlign>(ToolBar.TextAlignProperty, this.DefaultTextAlign);
      set
      {
        if (this.TextAlign == value)
          return;
        if (value != this.DefaultTextAlign)
          this.SetValue<ToolBarTextAlign>(ToolBar.TextAlignProperty, value, this.DefaultTextAlign);
        else
          this.RemoveValue<ToolBarTextAlign>(ToolBar.TextAlignProperty);
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Resets the text align.</summary>
    private void ResetTextAlign() => this.TextAlign = this.DefaultTextAlign;

    /// <summary>
    /// Gets a value indicating whether this instance is horizontal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is horizontal; otherwise, <c>false</c>.
    /// </value>
    internal new bool IsHorizontalDocked(DockStyle enmDock) => !this.IsLeftDocked(enmDock) && !this.IsRightDocked(enmDock);

    /// <summary>
    /// Gets or sets a value indicating whether to display drag handle.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to display drag handle; otherwise, <c>false</c>.
    /// </value>
    public bool DragHandle
    {
      get => this.GetValue<bool>(ToolBar.DragHandleProperty, true);
      set
      {
        if (this.DragHandle == value)
          return;
        this.Update();
        if (!value)
          this.SetValue<bool>(ToolBar.DragHandleProperty, value);
        else
          this.RemoveValue<bool>(ToolBar.DragHandleProperty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to display menu handle.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to display menu handle; otherwise, <c>false</c>.
    /// </value>
    public bool MenuHandle
    {
      get => this.GetValue<bool>(ToolBar.MenuHandleProperty, true);
      set
      {
        if (this.MenuHandle == value)
          return;
        this.Update();
        if (!value)
          this.SetValue<bool>(ToolBar.MenuHandleProperty, value);
        else
          this.RemoveValue<bool>(ToolBar.MenuHandleProperty);
      }
    }

    /// <summary>Gets the height of the tool bar.</summary>
    /// <value>The height of the tool bar.</value>
    internal int ToolBarHeight => this.Skin is ToolBarSkin skin ? skin.Height : 25;

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(false)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Indicates if to render padding attribute</summary>
    /// <returns></returns>
    protected override bool ShouldRenderPaddingAttribute(Padding objPadding) => (Padding) PaddingValue.Empty != objPadding;

    /// <summary>Gets/Sets the controls docking style</summary>
    /// <value></value>
    [DefaultValue(DockStyle.Top)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(100, 22);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ToolBarWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ToolBarWinFormsCompatibility;

    /// <summary>Resets the size of the button.</summary>
    private void ResetButtonSize() => this.ButtonSize = Size.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected internal override void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>ToolBar render implementation</summary>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RegisterBatch((ICollection) this.Buttons);
      int appearance = (int) this.Appearance;
      if (this.Appearance == ToolBarAppearance.Flat)
        objWriter.WriteAttributeString("S", "F");
      objWriter.WriteAttributeString("IH", this.ImageSize.Height.ToString());
      IResponseWriter responseWriter1 = objWriter;
      int num = this.ImageSize.Width;
      string strValue1 = num.ToString();
      responseWriter1.WriteAttributeString("IW", strValue1);
      if (this.TextAlign == ToolBarTextAlign.Underneath)
      {
        IResponseWriter responseWriter2 = objWriter;
        num = 1;
        string strValue2 = num.ToString();
        responseWriter2.WriteAttributeString("TIR", strValue2);
      }
      else
      {
        IResponseWriter responseWriter3 = objWriter;
        num = 4;
        string strValue3 = num.ToString();
        responseWriter3.WriteAttributeString("TIR", strValue3);
      }
      this.RenderControls(objContext, objWriter, lngRequestID);
    }

    /// <summary>Render buttons</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (ToolBarButton button in (IEnumerable) this.Buttons)
        button.RenderButton(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("TBIASPP", this.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
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
      objWriter.WriteAttributeString("TBIASPP", this.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
    }

    /// <summary>Creates the button collection.</summary>
    /// <returns></returns>
    [Browsable(false)]
    protected virtual ToolBarItemCollection CreateButtonCollection() => new ToolBarItemCollection(this);

    /// <summary>Gets the preferred size.</summary>
    /// <param name="objProposedSize">Size of the proposed.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize = objProposedSize;
      if (this.Buttons == null || this.Buttons.Count == 0)
        preferredSize = this.ButtonSize;
      else if (this.AutoSize)
        preferredSize = this.CalculateSize();
      return preferredSize;
    }

    /// <summary>
    /// Layout the internal controls to reflect parent changes
    /// </summary>
    /// <param name="objEventArgs">The layout arguments.</param>
    /// <param name="objNewSize">The new parent size.</param>
    /// <param name="objOldSize">The old parent size.</param>
    protected override void OnLayoutControls(
      LayoutEventArgs objEventArgs,
      ref Size objNewSize,
      ref Size objOldSize)
    {
    }

    /// <summary>Calculates the size.</summary>
    /// <returns></returns>
    private Size CalculateSize()
    {
      Size empty = Size.Empty;
      Size size;
      ref Size local = ref size;
      Size imageSize = this.ImageSize;
      int width1 = imageSize.Width;
      imageSize = this.ImageSize;
      int height = imageSize.Height;
      local = new Size(width1, height);
      ToolBarButtonSkin toolBarButtonSkin = this.ToolBarButtonSkin;
      if (this.Skin is ToolBarSkin skin)
      {
        bool flag = false;
        int val1 = 0;
        int num = 0;
        foreach (ToolBarButton button in (IEnumerable) this.Buttons)
        {
          if (button.Text != string.Empty)
          {
            flag = true;
            int width2 = CommonUtils.GetStringMeasurements(button.Text, button.Font).Width;
            if (width2 > val1)
              val1 = width2;
            int fontHeight = CommonUtils.GetFontHeight(button.Font);
            if (fontHeight > num)
              num = fontHeight;
          }
        }
        if (this.TextAlign == ToolBarTextAlign.Underneath)
        {
          empty.Height = size.Height;
          if (flag)
            empty.Height += num;
          empty.Width = Math.Max(val1, size.Width);
        }
        else
        {
          empty.Height = Math.Max(CommonUtils.GetFontHeight(skin.Font), size.Height);
          empty.Width = val1 + size.Width;
        }
        empty.Height += skin.Padding.Vertical;
        empty.Width += skin.Padding.Horizontal;
        empty.Height += skin.TopFrameHeight + skin.BottomFrameHeight;
        empty.Width += skin.LeftFrameWidth + skin.RightFrameWidth;
        if (toolBarButtonSkin != null)
        {
          DockStyle dock = this.Dock;
          if (dock == DockStyle.Top || dock == DockStyle.Bottom || dock == DockStyle.Fill)
          {
            empty.Height += toolBarButtonSkin.TopFrameHeight + toolBarButtonSkin.BottomFrameHeight;
            empty.Height += toolBarButtonSkin.Padding.Vertical + toolBarButtonSkin.Margin.Vertical;
          }
          else if (dock == DockStyle.Right || dock == DockStyle.Left || dock == DockStyle.Fill)
          {
            empty.Width += toolBarButtonSkin.LeftFrameWidth + toolBarButtonSkin.RightFrameWidth;
            empty.Width += toolBarButtonSkin.Padding.Horizontal + toolBarButtonSkin.Margin.Horizontal;
          }
        }
      }
      return empty;
    }

    internal void InternalRemove(ToolBarButton objToolBarButton) => this.UnRegisterComponent((IRegisteredComponent) objToolBarButton);

    internal void InternalClear(ICollection objToolBarButtons)
    {
      this.UnRegisterBatch(objToolBarButtons);
      this.InvalidateLayout(new LayoutEventArgs(false, true, true));
      this.Update();
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      ToolBarItemCollection buttons = this.Buttons;
      if (buttons == null)
        return;
      this.RegisterBatch((ICollection) buttons);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      ToolBarItemCollection buttons = this.Buttons;
      if (buttons == null)
        return;
      this.UnRegisterBatch((ICollection) buttons);
    }

    /// <summary>Do not serialize the size on docked mode</summary>
    /// <returns></returns>
    protected override bool ShouldSerializeClientSize() => this.Dock == DockStyle.None;

    /// <summary>Do not serialize the button size if is empty</summary>
    /// <returns></returns>
    private bool ShouldSerializeButtonSize() => !this.ButtonSizeInternal.IsEmpty;

    /// <summary>Shoulds the text align serialize.</summary>
    /// <returns></returns>
    private bool ShouldSerializeTextAlign() => this.TextAlign != this.DefaultTextAlign;

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.Buttons;

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new ToolBarWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "ToolBarItemAutoSizePreservedPlaceholders")
        this.Update();
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }
  }
}
