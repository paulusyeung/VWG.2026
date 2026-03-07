// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolBarButton
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

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for ToolBarButton.</summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignTimeVisible(false)]
  [DefaultEvent("Click")]
  [Skin(typeof (ToolBarButtonSkin))]
  [Serializable]
  public class ToolBarButton : Component, ISkinable
  {
    private static SerializableProperty NameProperty = SerializableProperty.Register(nameof (Name), typeof (string), typeof (ToolBarButton));
    private static SerializableProperty LabelProperty = SerializableProperty.Register("Label", typeof (string), typeof (ToolBarButton));
    private static SerializableProperty FontProperty = SerializableProperty.Register(nameof (Font), typeof (Font), typeof (ToolBarButton));
    private static SerializableProperty ForeColorProperty = SerializableProperty.Register(nameof (ForeColor), typeof (Color), typeof (ToolBarButton));
    private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register(nameof (ToolTipText), typeof (string), typeof (ToolBarButton));
    private static SerializableProperty SizeProperty = SerializableProperty.Register(nameof (Size), typeof (int), typeof (ToolBarButton));
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (ToolBarButton));
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (ToolBarButton));
    private static SerializableProperty StyleProperty = SerializableProperty.Register(nameof (Style), typeof (ToolBarButtonStyle), typeof (ToolBarButton));
    private static SerializableProperty DropDownProperty = SerializableProperty.Register("DropDown", typeof (ContextMenu), typeof (ToolBarButton));
    private static SerializableProperty CustomStyleProperty = SerializableProperty.Register(nameof (CustomStyle), typeof (string), typeof (ToolBarButton));
    /// <summary>
    /// 
    /// </summary>
    public static readonly SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (ToolBarButton));
    /// <summary>The Click event registration.</summary>
    private static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof (EventHandler), typeof (ToolBarButton));
    /// <summary>The parent toolbar</summary>
    private ToolBar mobjToolBar;

    /// <summary>Occurs on clicking the button.</summary>
    public event EventHandler Click
    {
      add => this.AddCriticalHandler(ToolBarButton.ClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolBarButton.ClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Click event.</summary>
    private EventHandler ClickHandler => (EventHandler) this.GetHandler(ToolBarButton.ClickEvent);

    /// <summary>
    /// 
    /// </summary>
    public ToolBarButton() => this.InitializeButton();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    public ToolBarButton(string strName, string strLabel)
    {
      this.Name = strName;
      this.SetValue<string>(ToolBarButton.LabelProperty, strLabel);
      this.InitializeButton();
    }

    /// <summary>Initializes the button.</summary>
    private void InitializeButton() => this.SetState(Component.ComponentState.Visible | Component.ComponentState.Enabled, true);

    /// <summary>Invalidates the tool bar layout.</summary>
    private void InvalidateToolBarLayout() => this.ToolBar?.InvalidateLayout(new LayoutEventArgs(false, true, true));

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
    /// </value>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool IsEventsEnabled => this.Enabled && this.Visible && base.IsEventsEnabled;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "Click") || new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0).Button == MouseButtons.Right)
        return;
      ToolBarButton objButton = this;
      if (this.DropDownMenu != null)
      {
        this.DropDownMenu.Show((Component) this, Point.Empty, DialogAlignment.Below);
        objButton = (ToolBarButton) null;
      }
      else
        this.OnClick();
      if (this.ToolBar == null)
        return;
      this.ToolBar.FireEvent(objEvent, objButton);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnClick()
    {
      if (this.ClickHandler == null)
        return;
      this.ClickHandler((object) this, new EventArgs());
    }

    /// <summary>
    /// Gets or sets the text that appears as a ToolTip for the button.
    ///  </summary>
    [Localizable(true)]
    [SRDescription("ToolBarButtonToolTipTextDescr")]
    public string ToolTipText
    {
      get => this.GetValue<string>(ToolBarButton.ToolTipTextProperty, string.Empty);
      set
      {
        if (!(this.ToolTipText != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(ToolBarButton.ToolTipTextProperty, value);
        else
          this.RemoveValue<string>(ToolBarButton.ToolTipTextProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the button style.</summary>
    /// <value></value>
    [DefaultValue(ToolBarButtonStyle.PushButton)]
    public ToolBarButtonStyle Style
    {
      get => this.GetValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty, ToolBarButtonStyle.PushButton);
      set
      {
        ToolBarButtonStyle style = this.Style;
        if (style == value)
          return;
        if (style == ToolBarButtonStyle.ToggleButton)
          this.Click -= new EventHandler(this.PushButton_Click);
        if (value != ToolBarButtonStyle.PushButton)
          this.SetValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty, value);
        else
          this.RemoveValue<ToolBarButtonStyle>(ToolBarButton.StyleProperty);
        if (value == ToolBarButtonStyle.ToggleButton)
          this.Click += new EventHandler(this.PushButton_Click);
        this.Update();
      }
    }

    /// <summary>Sets the current button fore color</summary>
    public Color ForeColor
    {
      get => this.GetValue<Color>(ToolBarButton.ForeColorProperty, Color.Empty);
      set
      {
        if (!(this.ForeColor != value))
          return;
        if (value != Color.Empty)
          this.SetValue<Color>(ToolBarButton.ForeColorProperty, value);
        else
          this.RemoveValue<Color>(ToolBarButton.ForeColorProperty);
        this.Update();
      }
    }

    /// <summary>Shoulds the color of the serialize fore.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeForeColor() => this.ForeColor != Color.Empty;

    /// <summary>Sets the current toolbar button font</summary>
    [DefaultValue(null)]
    public Font Font
    {
      get => this.GetValue<Font>(ToolBarButton.FontProperty, (Font) null) ?? this.GetOwnerFont();
      set
      {
        if (this.Font == value)
          return;
        if (value != null)
          this.SetValue<Font>(ToolBarButton.FontProperty, value);
        else
          this.RemoveValue<Font>(ToolBarButton.FontProperty);
        this.Update();
      }
    }

    /// <summary>Gets the owner font.</summary>
    /// <returns></returns>
    private Font GetOwnerFont() => this.ToolBar != null ? this.ToolBar.Font : (Font) null;

    /// <summary>
    /// 
    /// </summary>
    public virtual string CustomStyle
    {
      get => this.GetValue<string>(ToolBarButton.CustomStyleProperty, string.Empty);
      set
      {
        if (!(this.CustomStyle != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(ToolBarButton.CustomStyleProperty, value);
        else
          this.RemoveValue<string>(ToolBarButton.CustomStyleProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("ToolBar.ImageList")]
    [SRDescription("ToolBarButtonImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int ImageIndex
    {
      get => this.GetValue<int>(ToolBarButton.ImageIndexProperty, -1);
      set
      {
        if (this.ImageIndex == value)
          return;
        this.SetValue<int>(ToolBarButton.ImageIndexProperty, value, -1);
        this.RemoveValue<string>(ToolBarButton.ImageKeyProperty);
        this.InvalidateToolBarLayout();
        this.Update();
      }
    }

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue("")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("ToolBar.ImageList")]
    [SRDescription("ToolBarButtonImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public string ImageKey
    {
      get => this.GetValue<string>(ToolBarButton.ImageKeyProperty, string.Empty);
      set
      {
        if (!(this.ImageKey != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(ToolBarButton.ImageKeyProperty, value);
        else
          this.RemoveValue<string>(ToolBarButton.ImageKeyProperty);
        this.RemoveValue<int>(ToolBarButton.ImageIndexProperty);
        this.InvalidateToolBarLayout();
        this.Update();
      }
    }

    /// <summary>Gets or sets the toolbar.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public ToolBar ToolBar
    {
      get => this.mobjToolBar;
      set => this.mobjToolBar = value;
    }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [DefaultValue("")]
    public string Name
    {
      get => this.Site != null ? this.Site.Name : this.GetValue<string>(ToolBarButton.NameProperty, string.Empty);
      set
      {
        if (!(this.Name != value))
          return;
        this.Update();
        if (value != string.Empty)
          this.SetValue<string>(ToolBarButton.NameProperty, value);
        else
          this.RemoveValue<string>(ToolBarButton.NameProperty);
      }
    }

    /// <summary>Gets or sets the size.</summary>
    /// <value>The size.</value>
    [DefaultValue(30)]
    public int Size
    {
      get => this.GetValue<int>(ToolBarButton.SizeProperty, 24);
      set
      {
        if (this.Size == value)
          return;
        if (value != 24)
          this.SetValue<int>(ToolBarButton.SizeProperty, value);
        else
          this.RemoveValue<int>(ToolBarButton.SizeProperty);
        this.Update();
      }
    }

    private ImageList ImageList => this.ToolBar != null && this.ToolBar.ImageList != null ? this.ToolBar.ImageList : (ImageList) null;

    /// <summary>
    /// Gets a value indicating whether this instance is a seperator.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is a seperator; otherwise, <c>false</c>.
    /// </value>
    private bool IsSeperator => this.Style == ToolBarButtonStyle.Separator;

    /// <summary>Gets or sets the small image that is displayed for the item.</summary>
    /// <returns>The small image that is displayed for the <see cref="T:System.Windows.Forms.ListViewItem"></see>.</returns>
    /// <remarks>This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
    public ResourceHandle Image
    {
      get => this.GetImage(ToolBarButton.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set => this.SetImage(ToolBarButton.ImageProperty, value, this.ImageList);
    }

    /// <summary>Shoulds the serialize image.</summary>
    /// <returns></returns>
    protected bool ShouldSerializeImage() => (this.ToolBar == null || this.ToolBar.ImageList == null) && this.GetValue<ResourceHandle>(ToolBarButton.ImageProperty, (ResourceHandle) null) != null;

    /// <summary>
    /// 
    /// </summary>
    [DefaultValue("")]
    [SRDescription("ToolBarButtonTextDescr")]
    [Localizable(true)]
    public string Text
    {
      get => this.GetValue<string>(ToolBarButton.LabelProperty, string.Empty);
      set
      {
        if (!(this.Text != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(ToolBarButton.LabelProperty, value);
        else
          this.RemoveValue<string>(ToolBarButton.LabelProperty);
        if (value == "-")
          this.Style = ToolBarButtonStyle.Separator;
        this.InvalidateToolBarLayout();
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton" /> is pushed.
    /// </summary>
    /// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public bool Pushed
    {
      get => this.GetState(Component.ComponentState.Selected);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Selected, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(true)]
    public bool Visible
    {
      get => this.GetState(Component.ComponentState.Visible);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Visible, value))
          return;
        if (this.ToolBar != null)
          this.ToolBar.Update();
        else
          this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool Enabled
    {
      get => this.GetState(Component.ComponentState.Enabled);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Enabled, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the drop down menu.</summary>
    /// <value>The drop down menu.</value>
    [DefaultValue(null)]
    public ContextMenu DropDownMenu
    {
      get => this.GetValue<ContextMenu>(ToolBarButton.DropDownProperty, (ContextMenu) null);
      set
      {
        ContextMenu objValue = this.DropDownMenu;
        if (objValue != value)
        {
          if (value != null)
          {
            objValue = value;
            this.SetValue<ContextMenu>(ToolBarButton.DropDownProperty, objValue);
          }
          else
            this.RemoveValue<ContextMenu>(ToolBarButton.DropDownProperty);
          this.Update();
        }
        if (objValue == null || objValue.InternalParent != null)
          return;
        objValue.InternalParent = (Component) this;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PushButton_Click(object sender, EventArgs e) => this.Pushed = !this.Pushed;

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      ContextMenu dropDownMenu = this.DropDownMenu;
      if (dropDownMenu == null)
        return;
      this.RegisterComponent((IRegisteredComponent) dropDownMenu);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      ContextMenu dropDownMenu = this.DropDownMenu;
      if (dropDownMenu == null)
        return;
      this.UnRegisterComponent((IRegisteredComponent) dropDownMenu);
    }

    /// <summary>Renders the button.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    internal void RenderButton(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      if (!this.IsDirty(lngRequestID))
        return;
      ToolBar toolBar1 = this.ToolBar;
      if (toolBar1 == null)
        return;
      objWriter.WriteStartElement(WGConst.ControlsPrefix, "T2", WGConst.ControlsNamespace);
      this.RenderComponentAttributes(objContext, (IAttributeWriter) objWriter);
      System.Drawing.Size size = this.GetSize();
      ToolBar toolBar2 = toolBar1;
      int num;
      if (toolBar2.IsHorizontalDocked(toolBar2.Dock))
      {
        objWriter.WriteAttributeString("D", this.GetHorizontalDocking(objContext, toolBar1));
        objWriter.WriteAttributeString("W", size.Width.ToString());
      }
      else
      {
        objWriter.WriteAttributeString("D", "T");
        IResponseWriter responseWriter = objWriter;
        num = size.Height;
        string strValue = num.ToString();
        responseWriter.WriteAttributeString("H", strValue);
      }
      if (!this.Visible)
        objWriter.WriteAttributeString("V", "0");
      if (!this.Enabled)
        objWriter.WriteAttributeString("En", "0");
      string customStyle = this.CustomStyle;
      if (customStyle != string.Empty)
        objWriter.WriteAttributeString("ES", customStyle);
      string toolTipText = this.ToolTipText;
      if (toolTipText != string.Empty)
        objWriter.WriteAttributeText("TT", toolTipText);
      ToolBarButtonStyle style = this.Style;
      if (style != ToolBarButtonStyle.PushButton)
      {
        IResponseWriter responseWriter = objWriter;
        num = (int) style;
        string strValue = num.ToString();
        responseWriter.WriteAttributeString("S", strValue);
      }
      if (style == ToolBarButtonStyle.ToggleButton)
        objWriter.WriteAttributeString("PU", this.Pushed ? "1" : "0");
      Color foreColor = this.ForeColor;
      if (foreColor != Color.Empty)
        objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(foreColor));
      objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(this.Font));
      ResourceHandle resourceHandle = this.Image;
      if (resourceHandle == null && this.CustomStyle != "Label" && this.ToolBar != null && this.ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders)
        resourceHandle = (ResourceHandle) Component.EmptyGif;
      if (resourceHandle != null)
        objWriter.WriteAttributeString("IM", resourceHandle.ToString());
      if (this.Text != string.Empty)
        objWriter.WriteAttributeText("TX", this.Text);
      if (this.DropDownMenu != null)
      {
        objWriter.WriteAttributeString("DD", "1");
        objWriter.WriteStartElement("B");
        objWriter.WriteAttributeString("mId", "1");
        objWriter.WriteEndElement();
      }
      objWriter.WriteEndElement();
    }

    /// <summary>Gets the width of the seperator.</summary>
    /// <value>The width of the seperator.</value>
    private int SeperatorWidth => SkinFactory.GetSkin((ISkinable) this) is ToolBarButtonSkin skin ? skin.SeperatorWidth + skin.SeperatorStyle.Padding.Horizontal : 3;

    /// <summary>Gets the size.</summary>
    /// <returns></returns>
    protected virtual System.Drawing.Size GetSize()
    {
      ToolBarButtonSkin skin = (ToolBarButtonSkin) SkinFactory.GetSkin((ISkinable) this);
      System.Drawing.Size size1 = new System.Drawing.Size();
      if (skin != null)
      {
        if (this.IsSeperator)
        {
          size1.Width = this.SeperatorWidth;
        }
        else
        {
          System.Drawing.Size imageSize = this.ToolBar.ImageSize;
          size1.Height = Math.Max(this.CustomStyle != "Label" || this.Image != null ? imageSize.Height : 0, size1.Height);
          if (this.CustomStyle != "Label" && this.ToolBar != null && this.ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders || this.Image != null)
            size1.Width += imageSize.Width;
          System.Drawing.Size size2 = System.Drawing.Size.Empty;
          size2 = !string.IsNullOrEmpty(this.Text) ? CommonUtils.GetStringMeasurements(this.Text, this.Font, true) : new System.Drawing.Size(0, CommonUtils.GetFontHeight(this.Font));
          if (this.ToolBar.TextAlign == ToolBarTextAlign.Right)
          {
            size1.Height = Math.Max(size1.Height, size2.Height);
            size1.Width += size2.Width;
          }
          else
          {
            size1.Width = Math.Max(size1.Width, size2.Width);
            size1.Height += size2.Height;
          }
          if (this.DropDownMenu != null)
          {
            System.Drawing.Size dropDownImageSize = skin.DropDownImageSize;
            size1.Width += dropDownImageSize.Width;
            size1.Height += dropDownImageSize.Height;
          }
          MarginValue margin = skin.Margin;
          PaddingValue padding = skin.Padding;
          size1.Height += padding.Vertical + margin.Vertical;
          size1.Height += skin.TopFrameHeight + skin.BottomFrameHeight;
          size1.Width += padding.Horizontal + margin.Horizontal;
          size1.Width += skin.LeftFrameWidth + skin.RightFrameWidth;
        }
      }
      else
      {
        size1.Width = this.ToolBar.ToolBarHeight;
        size1.Height = this.ToolBar.ToolBarHeight;
      }
      return size1;
    }

    /// <summary>Gets the button docking.</summary>
    /// <param name="strDocking">The STR docking.</param>
    /// <returns></returns>
    protected virtual string GetButtonDocking(string strDocking) => strDocking;

    /// <summary>
    /// 
    /// </summary>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.ClickHandler != null || this.DropDownMenu != null || this.ToolBar != null && this.ToolBar.ButtonClickHandler != null)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("Click"))
        clientEventsData.Set("CL");
      return clientEventsData;
    }

    /// <summary>Gets the horizontal docking.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objToolbar">The obj toolbar.</param>
    /// <returns></returns>
    private string GetHorizontalDocking(IContext objContext, ToolBar objToolbar)
    {
      string strDocking = "L";
      if (objToolbar.HasRightToLeft)
      {
        if (this.ToolBar.RightToLeft == RightToLeft.Yes)
          strDocking = "R";
      }
      else if (objContext.RightToLeft)
        strDocking = "R";
      return this.GetButtonDocking(strDocking);
    }

    string ISkinable.Theme
    {
      get
      {
        ISkinable toolBar = (ISkinable) this.ToolBar;
        return toolBar != null ? toolBar.Theme : string.Empty;
      }
    }
  }
}
