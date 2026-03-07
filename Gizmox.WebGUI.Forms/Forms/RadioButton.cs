// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RadioButton
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Enables the user to select a single option from a group of choices when paired with other <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> controls.
  /// </summary>
  [ToolboxBitmap(typeof (RadioButton), "RadioButton_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultBindingProperty("Checked")]
  [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [SRDescription("DescriptionRadioButton")]
  [DefaultProperty("Checked")]
  [DefaultEvent("CheckedChanged")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("RB")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (RadioButtonSkin))]
  [Serializable]
  public class RadioButton : ButtonBase
  {
    /// <summary>Provides a property reference to Checked property.</summary>
    private static SerializableProperty CheckedProperty = SerializableProperty.Register(nameof (Checked), typeof (bool), typeof (RadioButton), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to CheckAlign property.</summary>
    private static SerializableProperty CheckAlignProperty = SerializableProperty.Register(nameof (CheckAlign), typeof (ContentAlignment), typeof (RadioButton), new SerializablePropertyMetadata((object) ContentAlignment.MiddleLeft));
    /// <summary>Provides a property reference to Appearance property.</summary>
    private static SerializableProperty AppearanceProperty = SerializableProperty.Register(nameof (Appearance), typeof (Appearance), typeof (RadioButton), new SerializablePropertyMetadata((object) Appearance.Normal));
    /// <summary>The AppearanceChanged event registration.</summary>
    private static readonly SerializableEvent AppearanceChangedEvent = SerializableEvent.Register("AppearanceChanged", typeof (EventHandler), typeof (RadioButton));
    /// <summary>The CheckedChanged event registration.</summary>
    private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof (EventHandler), typeof (RadioButton));

    /// <summary>Gets the hanlder for the AppearanceChanged event.</summary>
    private EventHandler AppearanceChangedHandler => (EventHandler) this.GetHandler(RadioButton.AppearanceChangedEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
    /// </summary>
    [SRDescription("RadioButtonOnAppearanceChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AppearanceChanged
    {
      add => this.AddCriticalHandler(RadioButton.AppearanceChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(RadioButton.AppearanceChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CheckedChanged event.</summary>
    private EventHandler CheckedChangedHandler => (EventHandler) this.GetHandler(RadioButton.CheckedChangedEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
    /// </summary>
    [SRDescription("RadioButtonOnCheckedChangedDescr")]
    public event EventHandler CheckedChanged
    {
      add => this.AddCriticalHandler(RadioButton.CheckedChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(RadioButton.CheckedChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("valueChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientCheckedChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Occurs when checked property value queued for change.</summary>
    public event EventHandler CheckedChangedQueued;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> class.
    /// </summary>
    public RadioButton()
    {
      this.SetStyle(ControlStyles.StandardClick, false);
      this.TextAlign = ContentAlignment.MiddleLeft;
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("C", this.Checked ? "1" : "0");
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
      if (!(proxyPropertyValue == Appearance.Button | blnForceRender))
        return;
      objWriter.WriteAttributeString("AP", ((int) proxyPropertyValue).ToString());
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
    /// </returns>
    public override string ToString() => string.Format("{0}, Checked: {1}", (object) base.ToString(), (object) this.Checked.ToString());

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
        RadioButtonSkin skin = this.Skin as RadioButtonSkin;
        Appearance appearance = this.Appearance;
        if (appearance == Appearance.Normal)
        {
          if (skin != null)
          {
            preferredSize.Width += skin.TextNormalStyle.Padding.Horizontal;
            preferredSize.Height += skin.TextNormalStyle.Padding.Vertical;
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
                ref Size local1 = ref preferredSize;
                int width1 = local1.Width;
                Size imageSize = this.ImageSize;
                int width2 = imageSize.Width;
                local1.Width = width1 + width2;
                ref Size local2 = ref preferredSize;
                imageSize = this.ImageSize;
                int num = Math.Max(imageSize.Height, preferredSize.Height);
                local2.Height = num;
                break;
            }
          }
        }
        if (skin != null)
        {
          switch (appearance)
          {
            case Appearance.Normal:
              preferredSize.Height = Math.Max(skin.RadioImageHeight, preferredSize.Height);
              preferredSize.Width += skin.RadioImageWidth;
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
        }
      }
      return preferredSize;
    }

    /// <summary>Handles the check.</summary>
    /// <param name="blnValue">if set to <c>true</c> [value].</param>
    /// <param name="blnUpdateSibling">if set to <c>true</c> [BLN update sibling].</param>
    private void SetChecked(bool blnValue, bool blnUpdateSibling)
    {
      this.InternalChecked = blnValue;
      if (blnValue && this.Parent != null)
      {
        foreach (Control control in (ArrangedElementCollection) this.Parent.Controls)
        {
          if (control is RadioButton sender && sender != this && sender.InternalChecked)
          {
            sender.InternalChecked = false;
            if (sender.CheckedChangedHandler != null)
              sender.CheckedChangedHandler((object) sender, EventArgs.Empty);
            if (sender.CheckedChangedQueued != null)
              sender.CheckedChangedQueued((object) sender, EventArgs.Empty);
            if (blnUpdateSibling)
              sender.Update();
          }
        }
      }
      this.OnCheckedChanged(EventArgs.Empty);
      if (this.CheckedChangedQueued == null)
        return;
      this.CheckedChangedQueued((object) this, EventArgs.Empty);
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new RadioButtonRenderer(this);

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "ValueChange")
        this.SetChecked(true, false);
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.CheckedChangedHandler != null)
        criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.CheckBox.CheckedChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnCheckedChanged(EventArgs e)
    {
      EventHandler checkedChangedHandler = this.CheckedChangedHandler;
      if (checkedChangedHandler == null)
        return;
      checkedChangedHandler((object) this, e);
    }

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

    /// <summary>
    /// Gets or sets a value indicating whether the control is checked.
    /// </summary>
    /// <returns>true if the check box is checked; otherwise, false.</returns>
    [DefaultValue(false)]
    [SRDescription("RadioButtonCheckedDescr")]
    [SRCategory("CatAppearance")]
    [Bindable(true)]
    public bool Checked
    {
      get => this.InternalChecked;
      set
      {
        if (this.Checked == value)
          return;
        this.SetChecked(value, true);
        this.Update();
      }
    }

    /// <summary>
    /// Sets a value indicating whether internal checked value.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if internal value is checked; otherwise, <c>false</c>.
    /// </value>
    internal bool InternalChecked
    {
      get => this.GetValue<bool>(RadioButton.CheckedProperty);
      set => this.SetValue<bool>(RadioButton.CheckedProperty, value);
    }

    /// <summary>Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> control.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
    [Bindable(true)]
    [SRCategory("CatAppearance")]
    [DefaultValue(ContentAlignment.MiddleLeft)]
    [Localizable(true)]
    [SRDescription("RadioButtonCheckAlignDescr")]
    public ContentAlignment CheckAlign
    {
      get => this.GetValue<ContentAlignment>(RadioButton.CheckAlignProperty);
      set
      {
        if (ClientUtils.GetBitCount((uint) value) != 1)
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ContentAlignment));
        if (!this.SetValue<ContentAlignment>(RadioButton.CheckAlignProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (CheckAlign));
      }
    }

    /// <summary>Gets or sets the appearance.</summary>
    /// <value>The appearance.</value>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [SRDescription("RadioButtonAppearanceDescr")]
    [DefaultValue(Appearance.Normal)]
    [ProxyBrowsable(true)]
    public Appearance Appearance
    {
      get => this.GetValue<Appearance>(RadioButton.AppearanceProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (Appearance));
        if (!this.SetValue<Appearance>(RadioButton.AppearanceProperty, value))
          return;
        this.OnAppearanceChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Visual);
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
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

    /// <summary>
    /// Gets a value indicating whether this instance is defined for tabbing as group.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is tab for group; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(false)]
    protected override bool EnableGroupTabbing => true;
  }
}
