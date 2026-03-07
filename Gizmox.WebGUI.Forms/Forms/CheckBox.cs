// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CheckBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A checkBox control.</summary>
  [ToolboxItemCategory("Common Controls")]
  [ToolboxBitmap(typeof (CheckBox), "CheckBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Gizmox.WebGUI.Forms.MetadataTag("CH")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (CheckBoxSkin))]
  [DefaultProperty("Checked")]
  [SRDescription("DescriptionCheckBox")]
  [DefaultEvent("CheckedChanged")]
  [DefaultBindingProperty("CheckState")]
  [Serializable]
  public class CheckBox : ButtonBase
  {
    /// <summary>Provides a property reference to AutoCheck property.</summary>
    private static SerializableProperty AutoCheckProperty = SerializableProperty.Register(nameof (AutoCheck), typeof (bool), typeof (CheckBox), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to ThreeState property.</summary>
    private static SerializableProperty ThreeStateProperty = SerializableProperty.Register(nameof (ThreeState), typeof (bool), typeof (CheckBox), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to CheckState property.</summary>
    private static SerializableProperty CheckStateProperty = SerializableProperty.Register(nameof (CheckState), typeof (CheckState), typeof (CheckBox), new SerializablePropertyMetadata((object) CheckState.Unchecked));
    /// <summary>Provides a property reference to CheckAlign property.</summary>
    private static SerializableProperty CheckAlignProperty = SerializableProperty.Register(nameof (CheckAlign), typeof (ContentAlignment), typeof (CheckBox), new SerializablePropertyMetadata((object) ContentAlignment.MiddleLeft));
    /// <summary>Provides a property reference to Appearance property.</summary>
    private static SerializableProperty AppearanceProperty = SerializableProperty.Register(nameof (Appearance), typeof (Appearance), typeof (CheckBox), new SerializablePropertyMetadata((object) Appearance.Normal));
    /// <summary>The CheckStateChangedQueued event registration.</summary>
    private static readonly SerializableEvent CheckStateChangedQueuedEvent = SerializableEvent.Register("CheckStateChangedQueued", typeof (EventHandler), typeof (CheckBox));
    /// <summary>The CheckStateChanged event registration.</summary>
    private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof (EventHandler), typeof (CheckBox));
    /// <summary>The CheckedChangedQueued event registration.</summary>
    private static readonly SerializableEvent CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof (EventHandler), typeof (CheckBox));
    /// <summary>The CheckedChanged event registration.</summary>
    private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof (EventHandler), typeof (CheckBox));
    /// <summary>The AppearanceChanged event registration.</summary>
    private static readonly SerializableEvent AppearanceChangedEvent = SerializableEvent.Register("AppearanceChanged", typeof (EventHandler), typeof (CheckBox));

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("checkedChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientCheckedChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>
    /// Occurs when the value of the Checked property changes.
    /// </summary>
    public event EventHandler CheckedChanged
    {
      add => this.AddCriticalHandler(CheckBox.CheckedChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(CheckBox.CheckedChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CheckedChanged event.</summary>
    private EventHandler CheckedChangedHandler => (EventHandler) this.GetHandler(CheckBox.CheckedChangedEvent);

    /// <summary>
    /// Occurs when the value of the Checked property changes (Queued).
    /// </summary>
    public event EventHandler CheckedChangedQueued
    {
      add => this.AddHandler(CheckBox.CheckedChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(CheckBox.CheckedChangedQueuedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CheckedChangedQueued event.</summary>
    private EventHandler CheckedChangedQueuedHandler => (EventHandler) this.GetHandler(CheckBox.CheckedChangedQueuedEvent);

    /// <summary>
    /// Occurs when the value of the CheckState property changes.
    /// </summary>
    public event EventHandler CheckStateChanged
    {
      add => this.AddCriticalHandler(CheckBox.CheckStateChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(CheckBox.CheckStateChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CheckStateChanged event.</summary>
    private EventHandler CheckStateChangedHandler => (EventHandler) this.GetHandler(CheckBox.CheckStateChangedEvent);

    /// <summary>
    /// Occurs when the value of the CheckState property changes (Queued).
    /// </summary>
    public event EventHandler CheckStateChangedQueued
    {
      add => this.AddHandler(CheckBox.CheckStateChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(CheckBox.CheckStateChangedQueuedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the CheckStateChangedQueued event.
    /// </summary>
    private EventHandler CheckStateChangedQueuedHandler => (EventHandler) this.GetHandler(CheckBox.CheckStateChangedQueuedEvent);

    /// <summary>
    /// Raises the <see cref="E:AppearanceChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAppearanceChanged(EventArgs e)
    {
      EventHandler appearanceChangedHandler = this.AppearanceChangedHandler;
      if (appearanceChangedHandler == null)
        return;
      appearanceChangedHandler((object) this, e);
    }

    /// <summary>Gets the hanlder for the AppearanceChanged event.</summary>
    private EventHandler AppearanceChangedHandler => (EventHandler) this.GetHandler(CheckBox.AppearanceChangedEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> property changes.
    /// </summary>
    [SRDescription("CheckBoxOnAppearanceChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AppearanceChanged
    {
      add => this.AddCriticalHandler(CheckBox.AppearanceChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(CheckBox.AppearanceChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckBox" /> instance.
    /// </summary>
    public CheckBox()
    {
      this.AutoCheck = true;
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
      this.TextAlign = ContentAlignment.MiddleLeft;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      int num = this.Checked ? 1 : 0;
      CheckState checkState = this.CheckState;
      if (num != 0)
      {
        if (checkState == CheckState.Indeterminate)
          objWriter.WriteAttributeString("C", "2");
        else
          objWriter.WriteAttributeString("C", "1");
      }
      else
        objWriter.WriteAttributeString("C", "0");
      if (!this.AutoCheck)
        objWriter.WriteAttributeString("ACK", "0");
      if (this.ThreeState)
        objWriter.WriteAttributeString("MD", "3");
      objWriter.WriteAttributeString("CA", this.CheckAlign.ToString());
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
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderAppearanceAttribute(objWriter, true);
    }

    /// <summary>Renders the appearance attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      Appearance proxyPropertyValue = this.GetProxyPropertyValue<Appearance>("Appearance", this.Appearance);
      if (!(proxyPropertyValue != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("AP", ((int) proxyPropertyValue).ToString());
    }

    /// <summary>Renders the visual template.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter)
    {
      VisualTemplate objVisualTemplate = this.GetProxyPropertyValue<VisualTemplate>("VisualTemplate", this.VisualTemplate);
      if (objVisualTemplate == null && this.Appearance == Appearance.Switch)
        objVisualTemplate = (VisualTemplate) new CheckBoxSwitchVisualTemplate(false, 50, CheckBoxSwitchVisualTemplateSwitchSizing.Percent, string.Empty, string.Empty);
      this.RenderVisualTemplate(objContext, objWriter, objVisualTemplate);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "ValueChange")
      {
        switch (objEvent["C"])
        {
          case "0":
            this.InternalCheckState = CheckState.Unchecked;
            break;
          case "1":
            this.InternalCheckState = CheckState.Checked;
            break;
          case "2":
            this.InternalCheckState = CheckState.Indeterminate;
            break;
        }
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.CheckedChangedHandler != null || this.CheckStateChangedHandler != null)
        criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckedChanged"></see> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckedChanged(EventArgs objEventArgs)
    {
      EventHandler checkedChangedHandler = this.CheckedChangedHandler;
      if (checkedChangedHandler == null)
        return;
      checkedChangedHandler((object) this, objEventArgs);
    }

    /// <summary>Raises the CheckedChangedQueued event</summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
    {
      EventHandler changedQueuedHandler = this.CheckedChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckStateChanged(EventArgs objEventArgs)
    {
      EventHandler stateChangedHandler = this.CheckStateChangedHandler;
      if (stateChangedHandler == null)
        return;
      stateChangedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckStateChangedQueued(EventArgs objEventArgs)
    {
      EventHandler changedQueuedHandler = this.CheckStateChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
    /// </returns>
    public override string ToString() => string.Format("{0}, CheckState: {1}", (object) base.ToString(), (object) ((int) this.CheckState).ToString());

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
        CheckBoxSkin skin = this.Skin as CheckBoxSkin;
        Appearance appearance = this.Appearance;
        BorderWidth borderWidth;
        if (appearance == Appearance.Normal)
        {
          if (skin != null)
          {
            preferredSize.Width += Math.Max(skin.LabelNormalStyle.Padding.Horizontal, skin.LabelFocusedStyle.Padding.Horizontal);
            ref Size local1 = ref preferredSize;
            int width = local1.Width;
            int val1_1;
            if (skin.LabelNormalStyle.BorderStyle == BorderStyle.None)
            {
              val1_1 = 0;
            }
            else
            {
              int left = skin.LabelNormalStyle.BorderWidth.Left;
              borderWidth = skin.LabelNormalStyle.BorderWidth;
              int right = borderWidth.Right;
              val1_1 = left + right;
            }
            int val2_1;
            if (skin.LabelFocusedStyle.BorderStyle == BorderStyle.None)
            {
              val2_1 = 0;
            }
            else
            {
              borderWidth = skin.LabelFocusedStyle.BorderWidth;
              int left = borderWidth.Left;
              borderWidth = skin.LabelFocusedStyle.BorderWidth;
              int right = borderWidth.Right;
              val2_1 = left + right;
            }
            int num1 = Math.Max(val1_1, val2_1);
            local1.Width = width + num1;
            preferredSize.Height += Math.Max(skin.LabelNormalStyle.Padding.Vertical, skin.LabelFocusedStyle.Padding.Vertical);
            ref Size local2 = ref preferredSize;
            int height = local2.Height;
            int val1_2;
            if (skin.LabelNormalStyle.BorderStyle == BorderStyle.None)
            {
              val1_2 = 0;
            }
            else
            {
              borderWidth = skin.LabelNormalStyle.BorderWidth;
              int top = borderWidth.Top;
              borderWidth = skin.LabelNormalStyle.BorderWidth;
              int bottom = borderWidth.Bottom;
              val1_2 = top + bottom;
            }
            int val2_2;
            if (skin.LabelFocusedStyle.BorderStyle == BorderStyle.None)
            {
              val2_2 = 0;
            }
            else
            {
              borderWidth = skin.LabelFocusedStyle.BorderWidth;
              int top = borderWidth.Top;
              borderWidth = skin.LabelFocusedStyle.BorderWidth;
              int bottom = borderWidth.Bottom;
              val2_2 = top + bottom;
            }
            int num2 = Math.Max(val1_2, val2_2);
            local2.Height = height + num2;
          }
          if (this.HasImageSize || this.Image != null)
          {
            switch (this.TextImageRelation)
            {
              case TextImageRelation.Overlay:
                preferredSize.Width = Math.Max(this.ImageSize.Width, preferredSize.Width);
                preferredSize.Height = Math.Max(this.ImageSize.Height, preferredSize.Height);
                break;
              case TextImageRelation.ImageAboveText:
              case TextImageRelation.TextAboveImage:
                preferredSize.Width = Math.Max(this.ImageSize.Width, preferredSize.Width);
                preferredSize.Height += this.ImageSize.Height;
                preferredSize.Height += skin.ButtonImageTextGap;
                break;
              case TextImageRelation.ImageBeforeText:
              case TextImageRelation.TextBeforeImage:
                ref Size local3 = ref preferredSize;
                int width1 = local3.Width;
                Size imageSize = this.ImageSize;
                int width2 = imageSize.Width;
                local3.Width = width1 + width2;
                ref Size local4 = ref preferredSize;
                imageSize = this.ImageSize;
                int num = Math.Max(imageSize.Height, preferredSize.Height);
                local4.Height = num;
                break;
            }
          }
        }
        if (skin != null)
        {
          switch (appearance)
          {
            case Appearance.Normal:
              preferredSize.Height = Math.Max(skin.CheckBoxImageHeight, preferredSize.Height);
              preferredSize.Width += skin.CheckBoxImageWidth;
              preferredSize.Width += skin.ButtonImageTextGap;
              break;
            case Appearance.Button:
              preferredSize.Height += skin.TopFrameHeight + skin.BottomFrameHeight;
              preferredSize.Width += skin.LeftFrameWidth + skin.RightFrameWidth;
              break;
          }
          PaddingValue padding = skin.Padding;
          if (padding != null)
          {
            preferredSize.Width += padding.Horizontal;
            preferredSize.Height += padding.Vertical;
          }
          if (skin.BorderStyle != BorderStyle.None)
          {
            ref Size local5 = ref preferredSize;
            int height = local5.Height;
            borderWidth = skin.BorderWidth;
            int top = borderWidth.Top;
            borderWidth = skin.BorderWidth;
            int bottom = borderWidth.Bottom;
            int num3 = top + bottom;
            local5.Height = height + num3;
            ref Size local6 = ref preferredSize;
            int width = local6.Width;
            borderWidth = skin.BorderWidth;
            int left = borderWidth.Left;
            borderWidth = skin.BorderWidth;
            int right = borderWidth.Right;
            int num4 = left + right;
            local6.Width = width + num4;
          }
        }
      }
      return preferredSize;
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new CheckBoxRenderer(this);

    /// <summary>Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> control.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
    [Bindable(true)]
    [SRCategory("CatAppearance")]
    [DefaultValue(ContentAlignment.MiddleLeft)]
    [Localizable(true)]
    [SRDescription("CheckBoxCheckAlignDescr")]
    public ContentAlignment CheckAlign
    {
      get => this.GetValue<ContentAlignment>(CheckBox.CheckAlignProperty);
      set
      {
        if (ClientUtils.GetBitCount((uint) value) != 1)
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ContentAlignment));
        if (!this.SetValue<ContentAlignment>(CheckBox.CheckAlignProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (CheckAlign));
      }
    }

    /// <summary>
    /// Sets a value indicating whether internal checked value.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if internal value is checked; otherwise, <c>false</c>.
    /// </value>
    internal CheckState InternalCheckState
    {
      get => this.GetValue<CheckState>(CheckBox.CheckStateProperty);
      set
      {
        CheckState enmValue1 = this.GetValue<CheckState>(CheckBox.CheckStateProperty);
        if (enmValue1 == value || !this.SetValue<CheckState>(CheckBox.CheckStateProperty, value))
          return;
        if (this.IsCheckedChanged(enmValue1, value))
        {
          this.OnCheckedChanged(EventArgs.Empty);
          this.OnCheckedChangedQueued(EventArgs.Empty);
          this.FireObservableItemPropertyChanged("Checked");
        }
        this.OnCheckStateChanged(EventArgs.Empty);
        this.OnCheckStateChangedQueued(EventArgs.Empty);
        this.FireObservableItemPropertyChanged("CheckState");
      }
    }

    /// <summary>Returns a flag indicating if checked has changed</summary>
    /// <param name="enmValue1"></param>
    /// <param name="enmValue2"></param>
    /// <returns></returns>
    private bool IsCheckedChanged(CheckState enmValue1, CheckState enmValue2)
    {
      if (enmValue1 != CheckState.Unchecked)
        return enmValue2 == CheckState.Unchecked;
      return enmValue2 == CheckState.Indeterminate || enmValue2 == CheckState.Checked;
    }

    /// <summary>Gets or sets the state of the check.</summary>
    /// <value>The state of the check from the CheckState enum. Default is CheckState.Unchecked.</value>
    [SRDescription("The state of the check from the CheckState enum")]
    [RefreshProperties(RefreshProperties.All)]
    [Bindable(true)]
    [SRCategory("CatAppearance")]
    [DefaultValue(CheckState.Unchecked)]
    public CheckState CheckState
    {
      get => this.InternalCheckState;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (CheckState));
        if (this.CheckState == value)
          return;
        this.InternalCheckState = value;
        this.Update();
      }
    }

    /// <summary>
    ///  Gets or sets a value indicating whether the check box will allow three check states rather than two.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [three state]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool ThreeState
    {
      get => this.GetValue<bool>(CheckBox.ThreeStateProperty);
      set
      {
        if (!this.SetValue<bool>(CheckBox.ThreeStateProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (ThreeState));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.CheckBox" /> is checked.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if checked; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("Gets or sets a value indicating whether this CheckBox is Checked")]
    [SRCategory("CatAppearance")]
    [Bindable(true)]
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.All)]
    [SettingsBindable(true)]
    public bool Checked
    {
      get => this.CheckState != 0;
      set
      {
        if (this.Checked == value)
          return;
        this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
      }
    }

    /// <summary>Gets or set a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> values and the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see>'s appearance are automatically changed when the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> is clicked.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> value or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> value and the appearance of the control are automatically changed on the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("CheckBoxAutoCheckDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool AutoCheck
    {
      get => this.GetValue<bool>(CheckBox.AutoCheckProperty);
      set
      {
        if (!this.SetValue<bool>(CheckBox.AutoCheckProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the flat style.</summary>
    /// <value></value>
    public new FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets the alignment of the text on the <see cref="T:Gizmox.WebGUI.Forms.CheckBox">
    /// </see> control.
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.
    /// </returns>
    [DefaultValue(ContentAlignment.MiddleLeft)]
    [Localizable(true)]
    public override ContentAlignment TextAlign
    {
      get => base.TextAlign;
      set => base.TextAlign = value;
    }

    /// <summary>
    /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
    /// </summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override AutoSizeMode AutoSizeMode => AutoSizeMode.GrowAndShrink;

    /// <summary>Gets or sets the appearance.</summary>
    /// <value>The appearance.</value>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [SRDescription("CheckBoxAppearanceDescr")]
    [DefaultValue(Appearance.Normal)]
    [ProxyBrowsable(true)]
    public Appearance Appearance
    {
      get => this.GetValue<Appearance>(CheckBox.AppearanceProperty);
      set
      {
        if (!this.SetValue<Appearance>(CheckBox.AppearanceProperty, value))
          return;
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (Appearance));
        this.OnAppearanceChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Visual);
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
      }
    }
  }
}
