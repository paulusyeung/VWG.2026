// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabPage
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
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a single tab page in a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.
  /// </summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignTimeVisible(false)]
  [ToolboxItem(false)]
  [DefaultProperty("Text")]
  [Gizmox.WebGUI.Forms.MetadataTag("TP")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TabPageSkin))]
  [ProxyComponent(typeof (ProxyTabPage))]
  [Serializable]
  public class TabPage : Panel, IComparable
  {
    /// <summary>
    /// Provides a property reference to TabAppearance property.
    /// </summary>
    private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof (TabAppearance), typeof (TabPage), new SerializablePropertyMetadata((object) TabAppearance.Normal));
    /// <summary>Provides a property reference to Loaded property.</summary>
    private static SerializableProperty LoadedProperty = SerializableProperty.Register(nameof (Loaded), typeof (bool), typeof (TabPage), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to Visible property.</summary>
    private static SerializableProperty VisibleProperty = SerializableProperty.Register(nameof (Visible), typeof (bool), typeof (TabPage), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (TabPage), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (TabPage), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty HeaderToolTipProperty = SerializableProperty.Register(nameof (HeaderToolTip), typeof (string), typeof (TabPage), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ImageIndex property.</summary>
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (TabPage), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to ContextualTabGroup property.
    /// </summary>
    private static SerializableProperty ContextualTabGroupProperty = SerializableProperty.Register(nameof (ContextualTabGroupProperty), typeof (ContextualTabGroup), typeof (TabPage), new SerializablePropertyMetadata((object) null));

    /// <summary>Represents Image of the tab if exists</summary>
    internal ResourceHandle ImageInternal
    {
      get => this.GetValue<ResourceHandle>(TabPage.ImageProperty);
      set => this.SetValue<ResourceHandle>(TabPage.ImageProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class.
    /// </summary>
    public TabPage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class and specifies the text for the tab.
    /// </summary>
    /// <param name="strText">The text for the tab. </param>
    public TabPage(string strText) => this.Text = strText;

    /// <summary>
    /// Gets a value indicating whether this instance is redrawing its contained controls.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is redrawing; otherwise, <c>false</c>.
    /// </value>
    internal override bool Redraws => true;

    /// <summary>Gets or sets the header tool tip.</summary>
    /// <value>The header tool tip.</value>
    [DefaultValue("")]
    public string HeaderToolTip
    {
      get => this.GetValue<string>(TabPage.HeaderToolTipProperty, string.Empty);
      set
      {
        if (!this.SetValue<string>(TabPage.HeaderToolTipProperty, value))
          return;
        this.UpdateParams(AttributeType.ToolTip);
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
      get => this.GetValue<int>(TabPage.ImageIndexProperty);
      set => this.SetValue<int>(TabPage.ImageIndexProperty, value);
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
      get => this.GetValue<string>(TabPage.ImageKeyProperty);
      set => this.SetValue<string>(TabPage.ImageKeyProperty, value);
    }

    /// <summary>Gets or sets the appearance.</summary>
    /// <value>The appearance.</value>
    protected internal virtual TabAppearance Appearance
    {
      get => this.GetValue<TabAppearance>(TabPage.TabAppearanceProperty);
      set
      {
        if (!this.SetValue<TabAppearance>(TabPage.TabAppearanceProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Shows the serialize image.</summary>
    protected bool ShouldSerializeImage() => (this.TabControl == null || this.TabControl.ImageList == null) && this.ImageInternal != null;

    /// <summary>Gets or sets the image.</summary>
    /// <value>The image.</value>
    public ResourceHandle Image
    {
      get => this.GetImage(TabPage.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set => this.SetImage(TabPage.ImageProperty, value, this.ImageList);
    }

    /// <summary>Gets the image list.</summary>
    /// <value>The image list.</value>
    private ImageList ImageList => this.TabControl != null ? this.TabControl.ImageList : (ImageList) null;

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabControl" /> control.
    /// </summary>
    [Browsable(false)]
    public TabControl TabControl => (TabControl) this.InternalParent;

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the panel type.</summary>
    [Browsable(false)]
    public new PanelType PanelType
    {
      get => base.PanelType;
      set => base.PanelType = value;
    }

    /// <summary>Gets or sets the tab index.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TabPage" /> is loaded.
    /// </summary>
    /// <value><c>true</c> if loaded; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool Loaded => this.InternalLoaded;

    /// <summary>
    /// Gets or sets a value indicating whether the tabpage was loaded.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the tabpage was loaded; otherwise, <c>false</c>.
    /// </value>
    internal bool InternalLoaded
    {
      get => this.GetValue<bool>(TabPage.LoadedProperty);
      set => this.SetValue<bool>(TabPage.LoadedProperty, value);
    }

    /// <summary>Gets or sets the text to display on the tab.</summary>
    /// <returns>The text to display on the tab.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [ProxyBrowsable(true)]
    public override string Text
    {
      get => base.Text;
      set
      {
        if (!(base.Text != value))
          return;
        base.Text = value;
      }
    }

    /// <summary>Gets or sets the tab visability.</summary>
    /// <value></value>
    [DefaultValue(true)]
    [SRDescription("ControlVisibleDescr")]
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool Visible
    {
      get => base.Visible;
      set => base.Visible = value;
    }

    /// <summary>Sets the visible internal.</summary>
    /// <param name="blnValue">if set to <c>true</c> set visibility true.</param>
    internal override void SetVisibleInternal(bool blnValue)
    {
      if (this.DesignMode || !this.SetValue<bool>(TabPage.VisibleProperty, blnValue))
        return;
      this.OnVisibleChanged(EventArgs.Empty);
      this.Update();
    }

    /// <summary>Create a control.</summary>
    /// <param name="blnVisible">if set to <c>true</c> [BLN visible].</param>
    protected override void DoCreateControl(bool blnVisible)
    {
      TabControl tabControl = this.TabControl;
      if (tabControl == null)
        return;
      tabControl.Update(false, tabControl.ShouldUseClientUpdateHandler);
      if (!blnVisible || !tabControl.Created)
        return;
      this.CreateControl();
    }

    /// <summary>Returns the visibility internally</summary>
    /// <returns></returns>
    internal override bool GetVisibleCore() => this.GetValue<bool>(TabPage.VisibleProperty);

    /// <summary>This member is not meaningful for this control.</summary>
    /// <returns>A <see cref="T:GizmoxWebGUI.DockStyle"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override DockStyle Dock
    {
      get => DockStyle.Fill;
      set => base.Dock = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>
    /// Indicates the automatic sizing behavior of the control.
    /// </summary>
    /// <value></value>
    /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Localizable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override AutoSizeMode AutoSizeMode
    {
      get => AutoSizeMode.GrowOnly;
      set
      {
      }
    }

    /// <summary>Gets a value indicating whether [use preferred size].</summary>
    /// <value><c>true</c> if [use preferred size]; otherwise, <c>false</c>.</value>
    protected internal override bool UsePreferredSize => false;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.TabPage"></see> background renders using the current visual style when visual styles are enabled.</summary>
    /// <returns>true to render the background using the current visual style; otherwise, false. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("TabItemUseVisualStyleBackColorDescr")]
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    public bool UseVisualStyleBackColor
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the contextual tab group key.</summary>
    /// <value>The contextual tab group key.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [DefaultValue(null)]
    [MergableProperty(false)]
    public virtual ContextualTabGroup ContextualTabGroup
    {
      get => this.GetValue<ContextualTabGroup>(TabPage.ContextualTabGroupProperty);
      set
      {
        TabControl tabControl = this.TabControl;
        if (value != null && tabControl != null)
        {
          ContextualTabGroupCollection tabGroupsInternal = tabControl.ContextualTabGroupsInternal;
          if (tabGroupsInternal == null || !tabGroupsInternal.Contains(value))
            throw new ArgumentException(nameof (ContextualTabGroup));
        }
        if (!this.SetValue<ContextualTabGroup>(TabPage.ContextualTabGroupProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
        tabControl?.Update(true);
      }
    }

    /// <summary>Shoulds the content of the control.</summary>
    /// <returns></returns>
    protected override bool ShouldRenderContent()
    {
      if (this.TabControl.SelectedItem != this && !this.Loaded)
        return false;
      Control parentInternal = this.ParentInternal;
      return parentInternal == null || parentInternal.ShouldRenderContentInternal();
    }

    /// <summary>Render control attributes</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.TabControl.SelectedItem == this)
        this.InternalLoaded = true;
      objWriter.WriteAttributeString("LO", this.InternalLoaded ? "1" : "0");
      int fontHeight = CommonUtils.GetFontHeight(this.Font);
      if (this.Image == null && fontHeight < this.TabControl.TabControlCurrentSkin.TabHeight)
        objWriter.WriteAttributeString("TFH", fontHeight);
      ResourceHandle image = this.Image;
      if (image != null)
        objWriter.WriteAttributeString("IM", image.ToString());
      this.RenderContextualTabGroup(objWriter, false);
      this.RenderHeaderToolTip(objWriter, false);
      this.RenderAppearanceAttribute(objWriter, false);
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        this.RenderContextualTabGroup(objWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
        this.RenderHeaderToolTip(objWriter, true);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderAppearanceAttribute(objWriter, true);
    }

    /// <summary>Renders the header tool tip.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderHeaderToolTip(IAttributeWriter objWriter, bool blnForceRender)
    {
      string headerToolTip = this.HeaderToolTip;
      if (!(!string.IsNullOrEmpty(headerToolTip) | blnForceRender))
        return;
      objWriter.WriteAttributeString("HTT", headerToolTip ?? string.Empty);
    }

    /// <summary>Renders the appearance attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      TabAppearance appearance = this.Appearance;
      if (!(appearance != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("AP", (int) appearance);
    }

    /// <summary>Renders the contextual tab group.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderContextualTabGroup(IAttributeWriter objWriter, bool blnForceRender)
    {
      string empty = string.Empty;
      ContextualTabGroup contextualTabGroup = this.ContextualTabGroup;
      if (contextualTabGroup != null)
      {
        ContextualTabGroupCollection tabGroupsInternal = this.TabControl.ContextualTabGroupsInternal;
        if (tabGroupsInternal != null)
        {
          int num = tabGroupsInternal.IndexOf(contextualTabGroup);
          if (num != -1)
            empty = num.ToString();
        }
      }
      if (!(!string.IsNullOrEmpty(empty) | blnForceRender))
        return;
      objWriter.WriteAttributeString("CTG", empty.ToString());
    }

    /// <summary>
    /// Returns a string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.
    /// </summary>
    /// <returns>A string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.</returns>
    public override string ToString() => "TabPage: {" + this.Text + "}";

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new TabPageRenderer(this);

    /// <summary>
    /// Compares the current instance with another object of the same type.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="obj" /> is not the same type as this instance. </exception>
    public int CompareTo(object obj) => obj is TabPage tabPage ? this.TabIndex.CompareTo(tabPage.TabIndex) : throw new ArgumentException();

    /// <summary>Applies the pre release dock fill compatibility.</summary>
    protected internal override void ApplyPreReleaseDockFillCompatibility()
    {
    }

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.UpdateTabControl();
    }

    /// <summary>Redraw only</summary>
    /// <param name="blnRedrawOnly"></param>
    public override void Update(bool blnRedrawOnly)
    {
      base.Update(blnRedrawOnly);
      this.UpdateTabControl();
    }

    /// <summary>Updates the tab control.</summary>
    private void UpdateTabControl()
    {
      if (!(this.Parent is TabControl parent))
        return;
      parent.Update(true, parent.ShouldUseClientUpdateHandler);
    }

    /// <summary>Updates only the parameters of this instance.</summary>
    public override void UpdateParams()
    {
      base.UpdateParams();
      this.UpdateTabControl();
    }

    /// <summary>Updates the params.</summary>
    /// <param name="enmParams">The enm params.</param>
    public override void UpdateParams(AttributeType enmParams)
    {
      base.UpdateParams(enmParams);
      this.UpdateTabControl();
    }
  }
}
