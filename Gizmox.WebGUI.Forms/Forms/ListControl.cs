// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides a common implementation of members for the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> and <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> classes.</summary>
  /// <filterpriority>1</filterpriority>
  [Serializable]
  public abstract class ListControl : Control
  {
    /// <summary>The DataManagerInternal property registration.</summary>
    private static readonly SerializableProperty DataManagerProperty = SerializableProperty.Register(nameof (DataManager), typeof (CurrencyManager), typeof (ListControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The DataSourceInternal property registration.</summary>
    private static readonly SerializableProperty DataSourceProperty = SerializableProperty.Register(nameof (DataSource), typeof (object), typeof (ListControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The DisplayMemberInternal property registration.</summary>
    private static readonly SerializableProperty DisplayMemberProperty = SerializableProperty.Register(nameof (DisplayMember), typeof (BindingMemberInfo), typeof (ListControl), new SerializablePropertyMetadata((object) new BindingMemberInfo()));
    /// <summary>The FormatInfoInternal property registration.</summary>
    private static readonly SerializableProperty FormatInfoProperty = SerializableProperty.Register(nameof (FormatInfo), typeof (IFormatProvider), typeof (ListControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The FormatStringInternal property registration.</summary>
    private static readonly SerializableProperty FormatStringProperty = SerializableProperty.Register(nameof (FormatString), typeof (string), typeof (ListControl), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The FormattingEnabledInternal property registration.</summary>
    private static readonly SerializableProperty FormattingEnabledProperty = SerializableProperty.Register(nameof (FormattingEnabledInternal), typeof (bool), typeof (ListControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// The InSetDataConnectionInternal property registration.
    /// </summary>
    private static readonly SerializableProperty InSetDataConnectionProperty = SerializableProperty.Register("InSetDataConnection", typeof (bool), typeof (ListControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// The IsDataSourceInitEventHooked property registration.
    /// </summary>
    private static readonly SerializableProperty IsDataSourceInitEventHookedProperty = SerializableProperty.Register("IsDataSourceInitEventHooked", typeof (bool), typeof (ListControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// The IsDataSourceInitializedInternal property registration.
    /// </summary>
    private static readonly SerializableProperty IsDataSourceInitializedProperty = SerializableProperty.Register("IsDataSourceInitialized", typeof (bool), typeof (ListControl), new SerializablePropertyMetadata((object) false));
    /// <summary>The ValueMember property registration.</summary>
    private static readonly SerializableProperty ValueMemberProperty = SerializableProperty.Register(nameof (ValueMember), typeof (BindingMemberInfo), typeof (ListControl), new SerializablePropertyMetadata((object) new BindingMemberInfo()));
    /// <summary>The ColorMember property registration.</summary>
    private static readonly SerializableProperty ColorMemberProperty = SerializableProperty.Register(nameof (ColorMember), typeof (string), typeof (ListControl), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The ImageMember property registration.</summary>
    private static readonly SerializableProperty ImageMemberProperty = SerializableProperty.Register(nameof (ImageMember), typeof (BindingMemberInfo), typeof (ListControl), new SerializablePropertyMetadata((object) new BindingMemberInfo()));
    /// <summary>The DataSourceChanged event registration.</summary>
    private static readonly SerializableEvent DataSourceChangedEvent = SerializableEvent.Register("DataSourceChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The DisplayMemberChanged event registration.</summary>
    private static readonly SerializableEvent DisplayMemberChangedEvent = SerializableEvent.Register("DisplayMemberChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The Format event registration.</summary>
    private static readonly SerializableEvent FormatEvent = SerializableEvent.Register("Format", typeof (ListControlConvertEventHandler), typeof (ListControl));
    /// <summary>The FormatInfoChanged event registration.</summary>
    private static readonly SerializableEvent FormatInfoChangedEvent = SerializableEvent.Register("FormatInfoChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The FormatStringChanged event registration.</summary>
    private static readonly SerializableEvent FormatStringChangedEvent = SerializableEvent.Register("FormatStringChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The FormattingEnabledChanged event registration.</summary>
    private static readonly SerializableEvent FormattingEnabledChangedEvent = SerializableEvent.Register("FormattingEnabledChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The SelectedValueChanged event registration.</summary>
    private static readonly SerializableEvent SelectedValueChangedEvent = SerializableEvent.Register("SelectedValueChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The ValueMemberChanged event registration.</summary>
    private static readonly SerializableEvent ValueMemberChangedEvent = SerializableEvent.Register("ValueMemberChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The ColorMemberChanged event registration.</summary>
    private static readonly SerializableEvent ColorMemberChangedEvent = SerializableEvent.Register("ColorMemberChanged", typeof (EventHandler), typeof (ListControl));
    /// <summary>The ImageMemberChanged event registration.</summary>
    private static readonly SerializableEvent ImageMemberChangedEvent = SerializableEvent.Register("ImageMemberChanged", typeof (EventHandler), typeof (ListControl));
    [NonSerialized]
    private TypeConverter mobjDisplayMemberConverter;
    [NonSerialized]
    private static TypeConverter StringTypeConverter = (TypeConverter) null;
    [NonSerialized]
    private static TypeConverter ImageTypeConverter = (TypeConverter) null;
    [NonSerialized]
    private static TypeConverter ColorTypeConverter = (TypeConverter) null;

    /// <summary>Gets or sets the data manager.</summary>
    /// <value>The data manager.</value>
    private CurrencyManager DataManagerInternal
    {
      get => this.GetValue<CurrencyManager>(ListControl.DataManagerProperty);
      set => this.SetValue<CurrencyManager>(ListControl.DataManagerProperty, value);
    }

    /// <summary>Gets or sets the data source.</summary>
    /// <value>The data source.</value>
    private object DataSourceInternal
    {
      get => this.GetValue<object>(ListControl.DataSourceProperty);
      set => this.SetValue<object>(ListControl.DataSourceProperty, value);
    }

    /// <summary>Gets or sets the display member.</summary>
    /// <value>The display member.</value>
    private BindingMemberInfo DisplayMemberInternal
    {
      get => this.GetValue<BindingMemberInfo>(ListControl.DisplayMemberProperty);
      set => this.SetValue<BindingMemberInfo>(ListControl.DisplayMemberProperty, value);
    }

    /// <summary>Gets or sets the format info.</summary>
    /// <value>The format info.</value>
    private IFormatProvider FormatInfoInternal
    {
      get => this.GetValue<IFormatProvider>(ListControl.FormatInfoProperty);
      set => this.SetValue<IFormatProvider>(ListControl.FormatInfoProperty, value);
    }

    /// <summary>Gets or sets the format string.</summary>
    /// <value>The format string.</value>
    private string FormatStringInternal
    {
      get => this.GetValue<string>(ListControl.FormatStringProperty);
      set => this.SetValue<string>(ListControl.FormatStringProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether formatting is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if formatting is enabled; otherwise, <c>false</c>.
    /// </value>
    private bool FormattingEnabledInternal
    {
      get => this.GetValue<bool>(ListControl.FormattingEnabledProperty);
      set => this.SetValue<bool>(ListControl.FormattingEnabledProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether in data connection set.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if in data connection set; otherwise, <c>false</c>.
    /// </value>
    private bool InSetDataConnectionInternal
    {
      get => this.GetValue<bool>(ListControl.InSetDataConnectionProperty);
      set => this.SetValue<bool>(ListControl.InSetDataConnectionProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is data source init event hooked.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is data source init event hooked; otherwise, <c>false</c>.
    /// </value>
    private bool IsDataSourceInitEventHookedInternal
    {
      get => this.GetValue<bool>(ListControl.IsDataSourceInitEventHookedProperty);
      set => this.SetValue<bool>(ListControl.IsDataSourceInitEventHookedProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is data source initialized.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is data source initialized; otherwise, <c>false</c>.
    /// </value>
    private bool IsDataSourceInitializedInternal
    {
      get => this.GetValue<bool>(ListControl.IsDataSourceInitializedProperty);
      set => this.SetValue<bool>(ListControl.IsDataSourceInitializedProperty, value);
    }

    /// <summary>Gets or sets the value member.</summary>
    /// <value>The value member.</value>
    private BindingMemberInfo ValueMemberInternal
    {
      get => this.GetValue<BindingMemberInfo>(ListControl.ValueMemberProperty);
      set => this.SetValue<BindingMemberInfo>(ListControl.ValueMemberProperty, value);
    }

    /// <summary>Gets or sets the color member.</summary>
    /// <value>The value member.</value>
    private string ColorMemberInternal
    {
      get => this.GetValue<string>(ListControl.ColorMemberProperty);
      set => this.SetValue<string>(ListControl.ColorMemberProperty, value);
    }

    /// <summary>Gets or sets the image member internal.</summary>
    /// <value>The image member internal.</value>
    private BindingMemberInfo ImageMemberInternal
    {
      get => this.GetValue<BindingMemberInfo>(ListControl.ImageMemberProperty);
      set => this.SetValue<BindingMemberInfo>(ListControl.ImageMemberProperty, value);
    }

    /// <summary>Gets a value indicating whether the list enables selection of list items.</summary>
    /// <returns>true if the list enables list item selection; otherwise, false. The default is true.</returns>
    protected virtual bool AllowSelection => true;

    internal bool BindingFieldEmpty => this.DisplayMemberInternal.BindingField.Length <= 0;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control. The default is null.</returns>
    protected CurrencyManager DataManager => this.DataManagerInternal;

    /// <summary>Gets or sets the data source for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
    /// <returns>An object that implements the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces, such as a <see cref="T:System.Data.DataSet"></see> or an <see cref="T:System.Array"></see>. The default is null.</returns>
    /// <exception cref="T:System.ArgumentException">The assigned value does not implement the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    [AttributeProvider(typeof (Binding.IDataSourceAttributeProvider))]
    [SRDescription("ListControlDataSourceDescr")]
    [SRCategory("CatData")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public virtual object DataSource
    {
      get => this.DataSourceInternal;
      set
      {
        switch (value)
        {
          case null:
          case IList _:
          case IListSource _:
            if (this.DataSourceInternal == value)
              break;
            try
            {
              this.SetDataConnection(value, this.DisplayMemberInternal, false);
            }
            catch
            {
              this.DisplayMember = "";
            }
            if (value == null)
              this.DisplayMember = "";
            this.FireObservableItemPropertyChanged(nameof (DataSource));
            break;
          default:
            throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
        }
      }
    }

    /// <summary>Gets or sets the property to display for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
    /// <returns>A <see cref="T:System.String"></see> specifying the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string (""). </returns>
    /// <filterpriority>1</filterpriority>
    [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [DefaultValue("")]
    [SRCategory("CatData")]
    [SRDescription("ListControlDisplayMemberDescr")]
    public string DisplayMember
    {
      get => this.DisplayMemberInternal.BindingMember;
      set
      {
        BindingMemberInfo displayMemberInternal = this.DisplayMemberInternal;
        try
        {
          this.SetDataConnection(this.DataSourceInternal, new BindingMemberInfo(value), false);
        }
        catch
        {
          this.DisplayMemberInternal = displayMemberInternal;
        }
      }
    }

    private TypeConverter DisplayMemberConverter
    {
      get
      {
        if (this.mobjDisplayMemberConverter == null && this.DataManager != null)
        {
          PropertyDescriptorCollection itemProperties = this.DataManager.GetItemProperties();
          if (itemProperties != null)
          {
            PropertyDescriptor propertyDescriptor = itemProperties.Find(this.DisplayMemberInternal.BindingField, true);
            if (propertyDescriptor != null)
              this.mobjDisplayMemberConverter = propertyDescriptor.Converter;
          }
        }
        return this.mobjDisplayMemberConverter;
      }
    }

    /// <summary>Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior. </summary>
    /// <returns>The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
    /// <filterpriority>2</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    public IFormatProvider FormatInfo
    {
      get => this.FormatInfoInternal;
      set
      {
        if (value == this.FormatInfoInternal)
          return;
        this.FormatInfoInternal = value;
        this.RefreshItems();
        this.OnFormatInfoChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the format-specifier characters that indicate how a value is to be displayed.</summary>
    /// <returns>The string of format-specifier characters that indicates how a value is to be displayed.</returns>
    /// <filterpriority>2</filterpriority>
    [DefaultValue("")]
    [MergableProperty(false)]
    [SRDescription("ListControlFormatStringDescr")]
    public string FormatString
    {
      get => this.FormatStringInternal;
      set
      {
        if (value == null)
          value = string.Empty;
        if (value.Equals(this.FormatStringInternal))
          return;
        this.FormatStringInternal = value;
        this.RefreshItems();
        this.OnFormatStringChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets a value indicating whether formatting is applied to the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
    /// <returns>true if formatting of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property is enabled; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ListControlFormattingEnabledDescr")]
    [DefaultValue(false)]
    public bool FormattingEnabled
    {
      get => this.FormattingEnabledInternal;
      set
      {
        if (value == this.FormattingEnabledInternal)
          return;
        this.FormattingEnabledInternal = value;
        this.RefreshItems();
        this.OnFormattingEnabledChanged(EventArgs.Empty);
      }
    }

    /// <summary>
    /// Indicates if the list control context requires its events to cause callback
    /// </summary>
    protected virtual bool IsPostBackRequired => this.DataSource != null;

    /// <summary>When overridden in a derived class, gets or sets the zero-based index of the currently selected item.</summary>
    /// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
    /// <filterpriority>1</filterpriority>
    [Bindable(true)]
    public abstract int SelectedIndex { get; set; }

    /// <summary>Gets or sets the value of the member property specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</summary>
    /// <returns>An object containing the value of the member of the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</returns>
    /// <exception cref="T:System.InvalidOperationException">The assigned value is null or the empty string ("").</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("ListControlSelectedValueDescr")]
    [Bindable(true)]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    public object SelectedValue
    {
      get => this.SelectedIndex != -1 && this.DataManagerInternal != null ? this.FilterItemOnProperty(this.DataManagerInternal[this.SelectedIndex], this.ValueMemberInternal.BindingField) : (object) null;
      set
      {
        if (this.DataManagerInternal == null)
          return;
        string bindingField = this.ValueMemberInternal.BindingField;
        if (bindingField == null || bindingField == string.Empty)
          throw new InvalidOperationException(SR.GetString("ListControlEmptyValueMemberInSettingSelectedValue"));
        this.SelectedIndex = this.DataManagerInternal.Find(this.DataManagerInternal.GetItemProperties().Find(bindingField, true), value, true);
      }
    }

    /// <summary>Gets or sets the property to use as the actual value for the items in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string ("").</returns>
    /// <exception cref="T:System.ArgumentException">The specified property cannot be found on the object specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlValueMemberDescr")]
    [SRCategory("CatData")]
    [DefaultValue("")]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    public string ValueMember
    {
      get => this.ValueMemberInternal.BindingMember;
      set
      {
        if (value == null)
          value = "";
        BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(value);
        if (bindingMemberInfo.Equals((object) this.ValueMemberInternal))
          return;
        if (this.DisplayMember.Length == 0)
          this.SetDataConnection(this.DataSource, bindingMemberInfo, false);
        if (this.DataManagerInternal != null && value != null && value.Length != 0 && !this.BindingMemberInfoInDataManager(bindingMemberInfo))
          throw new ArgumentException(SR.GetString("ListControlWrongValueMember"), nameof (value));
        this.ValueMemberInternal = bindingMemberInfo;
        this.OnValueMemberChanged(EventArgs.Empty);
        this.OnSelectedValueChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the color member.</summary>
    /// <value>The color member.</value>
    [SRDescription("ListControlColorMemberDescr")]
    [SRCategory("CatData")]
    [DefaultValue("")]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    public string ColorMember
    {
      get => this.ColorMemberInternal != null ? this.ColorMemberInternal : string.Empty;
      set
      {
        if (!(this.ColorMember != value))
          return;
        this.ColorMemberInternal = !string.IsNullOrEmpty(value) ? value : (string) null;
        this.OnColorMemberChanged(EventArgs.Empty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the image member.</summary>
    /// <value>The image member.</value>
    [SRDescription("ListControlImageMemberDescr")]
    [SRCategory("CatData")]
    [DefaultValue("")]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    public string ImageMember
    {
      get => this.ImageMemberInternal.BindingMember;
      set
      {
        if (value == null)
          value = "";
        BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(value);
        if (bindingMemberInfo.Equals((object) this.ImageMemberInternal))
          return;
        this.ImageMemberInternal = bindingMemberInfo;
        this.OnImageMemberChanged(EventArgs.Empty);
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
    /// Gets or sets a value indicating whether [force selected index changed on click].
    /// If true, then SelectedIndexChanged event will fire on every index selection, even if actual selected index did not change (WinForms behavior).
    /// </summary>
    /// <value>
    /// <c>true</c> if [force selected index changed on click]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
    public bool ForceSelectedIndexChangedOnClick
    {
      get => this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick;
      set => this.WinFormsCompatibility.ForceSelectedIndexChangedOnClick = value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ListControlWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ListControlWinFormsCompatibility;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ListControlOnDataSourceChangedDescr")]
    public event EventHandler DataSourceChanged
    {
      add => this.AddHandler(ListControl.DataSourceChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.DataSourceChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DataSourceChanged event.</summary>
    private EventHandler DataSourceChangedHandler => (EventHandler) this.GetHandler(ListControl.DataSourceChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlOnDisplayMemberChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DisplayMemberChanged
    {
      add => this.AddHandler(ListControl.DisplayMemberChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.DisplayMemberChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DisplayMemberChanged event.</summary>
    private EventHandler DisplayMemberChangedHandler => (EventHandler) this.GetHandler(ListControl.DisplayMemberChangedEvent);

    /// <summary>Occurs when the control is bound to a data value.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlFormatDescr")]
    [SRCategory("CatPropertyChanged")]
    public event ListControlConvertEventHandler Format
    {
      add => this.AddHandler(ListControl.FormatEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.FormatEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Format event.</summary>
    private ListControlConvertEventHandler FormatHandler => (ListControlConvertEventHandler) this.GetHandler(ListControl.FormatEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatInfo"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ListControlFormatInfoChangedDescr")]
    public event EventHandler FormatInfoChanged
    {
      add => this.AddHandler(ListControl.FormatInfoChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.FormatInfoChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the FormatInfoChanged event.</summary>
    private EventHandler FormatInfoChangedHandler => (EventHandler) this.GetHandler(ListControl.FormatInfoChangedEvent);

    /// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatString"></see> property changes</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlFormatStringChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler FormatStringChanged
    {
      add => this.AddHandler(ListControl.FormatStringChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.FormatStringChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the FormatStringChanged event.</summary>
    private EventHandler FormatStringChangedHandler => (EventHandler) this.GetHandler(ListControl.FormatStringChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormattingEnabled"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlFormattingEnabledChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler FormattingEnabledChanged
    {
      add => this.AddHandler(ListControl.FormattingEnabledChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.FormattingEnabledChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the FormattingEnabledChanged event.
    /// </summary>
    private EventHandler FormattingEnabledChangedHandler => (EventHandler) this.GetHandler(ListControl.FormattingEnabledChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.SelectedValue"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListControlOnSelectedValueChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler SelectedValueChanged
    {
      add => this.AddHandler(ListControl.SelectedValueChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.SelectedValueChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the SelectedValueChanged event.</summary>
    protected EventHandler SelectedValueChangedHandler => (EventHandler) this.GetHandler(ListControl.SelectedValueChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ListControlOnValueMemberChangedDescr")]
    public event EventHandler ValueMemberChanged
    {
      add => this.AddHandler(ListControl.ValueMemberChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ListControl.ValueMemberChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ValueMemberChanged event.</summary>
    private EventHandler ValueMemberChangedHandler => (EventHandler) this.GetHandler(ListControl.ValueMemberChangedEvent);

    /// <summary>Gets the color member changed handler.</summary>
    /// <value>The color member changed handler.</value>
    private EventHandler ColorMemberChangedHandler => (EventHandler) this.GetHandler(ListControl.ColorMemberChangedEvent);

    /// <summary>Gets the image member changed handler.</summary>
    /// <value>The image member changed handler.</value>
    private EventHandler ImageMemberChangedHandler => (EventHandler) this.GetHandler(ListControl.ImageMemberChangedEvent);

    /// <summary>
    /// Raises the <see cref="E:BindingContextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnBindingContextChanged(EventArgs e)
    {
      this.SetDataConnection(this.DataSourceInternal, this.DisplayMemberInternal, true);
      base.OnBindingContextChanged(e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataSourceChanged(EventArgs e)
    {
      EventHandler sourceChangedHandler = this.DataSourceChangedHandler;
      if (sourceChangedHandler == null)
        return;
      sourceChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDisplayMemberChanged(EventArgs e)
    {
      EventHandler memberChangedHandler = this.DisplayMemberChangedHandler;
      if (memberChangedHandler == null)
        return;
      memberChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.Format"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ListControlConvertEventArgs"></see> that contains the event data. </param>
    protected virtual void OnFormat(ListControlConvertEventArgs e)
    {
      ListControlConvertEventHandler formatHandler = this.FormatHandler;
      if (formatHandler == null)
        return;
      formatHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatInfoChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnFormatInfoChanged(EventArgs e)
    {
      EventHandler infoChangedHandler = this.FormatInfoChangedHandler;
      if (infoChangedHandler == null)
        return;
      infoChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatStringChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnFormatStringChanged(EventArgs e)
    {
      EventHandler stringChangedHandler = this.FormatStringChangedHandler;
      if (stringChangedHandler == null)
        return;
      stringChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormattingEnabledChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnFormattingEnabledChanged(EventArgs e)
    {
      EventHandler enabledChangedHandler = this.FormattingEnabledChangedHandler;
      if (enabledChangedHandler == null)
        return;
      enabledChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnSelectedIndexChanged(EventArgs e) => this.OnSelectedValueChanged(EventArgs.Empty);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnSelectedValueChanged(EventArgs e)
    {
      EventHandler valueChangedHandler = this.SelectedValueChangedHandler;
      if (valueChangedHandler == null)
        return;
      valueChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.ValueMemberChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnValueMemberChanged(EventArgs e)
    {
      EventHandler memberChangedHandler = this.ValueMemberChangedHandler;
      if (memberChangedHandler == null)
        return;
      memberChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ColorMemberChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorMemberChanged(EventArgs e)
    {
      EventHandler memberChangedHandler = this.ColorMemberChangedHandler;
      if (memberChangedHandler == null)
        return;
      memberChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ImageMemberChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnImageMemberChanged(EventArgs e)
    {
      EventHandler memberChangedHandler = this.ImageMemberChangedHandler;
      if (memberChangedHandler == null)
        return;
      memberChangedHandler((object) this, e);
    }

    /// <summary>
    /// Initializes the <see cref="T:Gizmox.WebGUI.Forms.ListControl" /> class.
    /// </summary>
    static ListControl()
    {
      ListControl.StringTypeConverter = TypeDescriptor.GetConverter(typeof (string));
      ListControl.ImageTypeConverter = TypeDescriptor.GetConverter(typeof (ResourceHandle));
      ListControl.ColorTypeConverter = TypeDescriptor.GetConverter(typeof (Color));
    }

    private bool BindingMemberInfoInDataManager(BindingMemberInfo objBindingMemberInfo)
    {
      if (this.DataManagerInternal != null)
      {
        PropertyDescriptorCollection itemProperties = this.DataManagerInternal.GetItemProperties();
        int count = itemProperties.Count;
        for (int index = 0; index < count; ++index)
        {
          if (!typeof (IList).IsAssignableFrom(itemProperties[index].PropertyType) && itemProperties[index].Name.Equals(objBindingMemberInfo.BindingField))
            return true;
        }
        for (int index = 0; index < count; ++index)
        {
          if (!typeof (IList).IsAssignableFrom(itemProperties[index].PropertyType) && string.Compare(itemProperties[index].Name, objBindingMemberInfo.BindingField, true, CultureInfo.CurrentCulture) == 0)
            return true;
        }
      }
      return false;
    }

    private void DataManager_ItemChanged(object sender, ItemChangedEventArgs e)
    {
      if (this.DataManagerInternal == null)
        return;
      if (e.Index == -1)
      {
        this.SetItemsCore(this.DataManagerInternal.List);
        if (!this.AllowSelection)
          return;
        this.SelectedIndex = this.DataManagerInternal.Position;
      }
      else
        this.SetItemCore(e.Index, this.DataManagerInternal[e.Index]);
    }

    private void DataManager_PositionChanged(object sender, EventArgs e)
    {
      if (this.DataManagerInternal == null || !this.AllowSelection || this.SelectedIndex == this.DataManagerInternal.Position)
        return;
      this.SelectedIndex = this.DataManagerInternal.Position;
      this.Update();
    }

    private void DataSourceDisposed(object sender, EventArgs e) => this.SetDataConnection((object) null, new BindingMemberInfo(""), true);

    private void DataSourceInitialized(object sender, EventArgs e) => this.SetDataConnection(this.DataSourceInternal, this.DisplayMemberInternal, true);

    /// <summary>Retrieves the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object, given the item.</summary>
    /// <returns>The filtered object.</returns>
    /// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
    protected object FilterItemOnProperty(object objItem) => this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);

    /// <summary>Returns the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object given the item and the property name.</summary>
    /// <returns>The filtered object.</returns>
    /// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
    /// <param name="strField">The property name of the item the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> is bound to.</param>
    protected object FilterItemOnProperty(object objItem, string strField) => ListControl.FilterItemOnProperty(this.DataManagerInternal, objItem, strField);

    /// <summary>Filters the item on property.</summary>
    /// <param name="objCurrencyManager">The obj currency manager.</param>
    /// <param name="objItem">The obj item.</param>
    /// <param name="strField">The STR field.</param>
    /// <returns></returns>
    internal static object FilterItemOnProperty(
      CurrencyManager objCurrencyManager,
      object objItem,
      string strField)
    {
      if (objItem != null)
      {
        if (strField.Length > 0)
        {
          try
          {
            PropertyDescriptor propertyDescriptor = objCurrencyManager == null ? TypeDescriptor.GetProperties(objItem).Find(strField, true) : objCurrencyManager.GetItemProperties().Find(strField, true);
            if (propertyDescriptor != null)
              objItem = propertyDescriptor.GetValue(objItem);
          }
          catch
          {
          }
        }
      }
      return objItem;
    }

    internal int FindStringInternal(string str, IList objItems, int intStartIndex, bool blnExact) => this.FindStringInternal(str, objItems, intStartIndex, blnExact, true);

    internal int FindStringInternal(
      string str,
      IList objI,
      int intStartIndex,
      bool blnExact,
      bool blnIgnorecase)
    {
      if (str != null && objI != null && intStartIndex >= -1 && intStartIndex < objI.Count)
      {
        int length = str.Length;
        int num = 0;
        int index = (intStartIndex + 1) % objI.Count;
        while (num < objI.Count)
        {
          ++num;
          if (!blnExact ? string.Compare(str, 0, this.GetItemText(objI[index]), 0, length, blnIgnorecase, CultureInfo.CurrentCulture) == 0 : string.Compare(str, this.GetItemText(objI[index]), blnIgnorecase, CultureInfo.CurrentCulture) == 0)
            return index;
          index = (index + 1) % objI.Count;
        }
      }
      return -1;
    }

    /// <summary>Returns the text representation of the specified item.</summary>
    /// <returns>If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemText(System.Object)"></see> is the value of the item's ToString method. Otherwise, the method returns the string value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property for the object specified in the item parameter.</returns>
    /// <param name="objItem">The object from which to get the contents to display. </param>
    /// <filterpriority>1</filterpriority>
    public virtual string GetItemText(object objItem)
    {
      if (!this.FormattingEnabledInternal)
      {
        if (objItem == null)
          return string.Empty;
        objItem = this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);
        return objItem == null ? "" : Convert.ToString(objItem, (IFormatProvider) CultureInfo.CurrentCulture);
      }
      object objValue = this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);
      ListControlConvertEventArgs e = new ListControlConvertEventArgs(objValue, typeof (string), objItem);
      this.OnFormat(e);
      if (e.Value != objItem && e.Value is string)
        return (string) e.Value;
      try
      {
        return (string) Formatter.FormatObject(objValue, typeof (string), this.DisplayMemberConverter, ListControl.StringTypeConverter, this.FormatStringInternal, this.FormatInfoInternal, (object) null, (object) DBNull.Value);
      }
      catch
      {
        return objValue != null ? Convert.ToString(objItem, (IFormatProvider) CultureInfo.CurrentCulture) : "";
      }
    }

    /// <summary>Returns the Color representation of the specified item.</summary>
    /// <returns>If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemColor(System.Object)"></see> is the value of the item as Color. Otherwise, the method returns the striColorng value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
    /// <param name="objItem">The object from which to get the contents to display. </param>
    /// <filterpriority>1</filterpriority>
    public virtual Color GetItemColor(object objItem)
    {
      itemColor2 = Color.Empty;
      string colorMember = this.ColorMember;
      if (string.IsNullOrEmpty(colorMember))
      {
        if (!(objItem is Color itemColor2))
          ;
      }
      else
      {
        object obj = this.FilterItemOnProperty(objItem, colorMember);
        if (obj != null && !(obj is Color itemColor2) && ListControl.ColorTypeConverter.CanConvertFrom(obj.GetType()))
          itemColor2 = (Color) ListControl.ColorTypeConverter.ConvertFrom(obj);
      }
      return itemColor2;
    }

    /// <summary>Returns the Image representation of the specified item.</summary>
    /// <returns>If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ImageMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemImage(System.Object)"></see> is the value of the item as Image. Otherwise, the method returns the Image value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
    /// <param name="objItem">The object from which to get the contents to display. </param>
    /// <filterpriority>1</filterpriority>
    public virtual ResourceHandle GetItemImage(object objItem)
    {
      ResourceHandle itemImage = (ResourceHandle) null;
      string imageMember = this.ImageMember;
      if (!string.IsNullOrEmpty(imageMember))
      {
        object obj = this.FilterItemOnProperty(objItem, imageMember);
        if (obj != null)
        {
          if (obj is ResourceHandle)
            itemImage = (ResourceHandle) obj;
          else if (ListControl.ImageTypeConverter.CanConvertFrom(obj.GetType()))
            itemImage = (ResourceHandle) ListControl.ImageTypeConverter.ConvertFrom(obj);
        }
      }
      return itemImage;
    }

    /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
    /// <param name="index">The zero-based index of the item whose data to refresh. </param>
    protected abstract void RefreshItem(int index);

    /// <summary>When overridden in a derived class, resynchronizes the item data with the contents of the data source.</summary>
    protected virtual void RefreshItems()
    {
    }

    private void SetDataConnection(
      object objNewDataSource,
      BindingMemberInfo objNewDisplayMember,
      bool blnForce)
    {
      bool flag1 = this.DataSourceInternal != objNewDataSource;
      bool flag2 = !this.DisplayMemberInternal.Equals((object) objNewDisplayMember);
      if (this.InSetDataConnectionInternal)
        return;
      try
      {
        if (blnForce | flag1 | flag2)
        {
          this.InSetDataConnectionInternal = true;
          IList list = this.DataManager != null ? this.DataManager.List : (IList) null;
          bool flag3 = this.DataManager == null;
          this.UnwireDataSource();
          this.DataSourceInternal = objNewDataSource;
          this.DisplayMemberInternal = objNewDisplayMember;
          this.WireDataSource();
          if (this.IsDataSourceInitializedInternal)
          {
            CurrencyManager currencyManager = (CurrencyManager) null;
            if (objNewDataSource != null && this.BindingContext != null && objNewDataSource != Convert.DBNull)
              currencyManager = (CurrencyManager) this.BindingContext[objNewDataSource, objNewDisplayMember.BindingPath];
            if (this.DataManagerInternal != currencyManager)
            {
              if (this.DataManagerInternal != null)
              {
                this.DataManagerInternal.ItemChanged -= new ItemChangedEventHandler(this.DataManager_ItemChanged);
                this.DataManagerInternal.PositionChanged -= new EventHandler(this.DataManager_PositionChanged);
              }
              this.DataManagerInternal = currencyManager;
              if (this.DataManagerInternal != null)
              {
                this.DataManagerInternal.ItemChanged += new ItemChangedEventHandler(this.DataManager_ItemChanged);
                this.DataManagerInternal.PositionChanged += new EventHandler(this.DataManager_PositionChanged);
              }
            }
            if (this.DataManagerInternal != null && flag2 | flag1)
            {
              BindingMemberInfo displayMemberInternal = this.DisplayMemberInternal;
              if (displayMemberInternal.BindingMember != null)
              {
                displayMemberInternal = this.DisplayMemberInternal;
                if (displayMemberInternal.BindingMember.Length != 0 && !this.BindingMemberInfoInDataManager(this.DisplayMemberInternal))
                  throw new ArgumentException(SR.GetString("ListControlWrongDisplayMember"), "newDisplayMember");
              }
            }
            if (this.DataManagerInternal != null && flag1 | flag2 | blnForce && (flag2 || blnForce && list != this.DataManagerInternal.List | flag3))
              this.DataManager_ItemChanged((object) this.DataManagerInternal, new ItemChangedEventArgs(-1));
          }
          this.mobjDisplayMemberConverter = (TypeConverter) null;
        }
        if (flag1)
          this.OnDataSourceChanged(EventArgs.Empty);
        if (!flag2)
          return;
        this.OnDisplayMemberChanged(EventArgs.Empty);
      }
      finally
      {
        this.InSetDataConnectionInternal = false;
      }
    }

    /// <summary>When overridden in a derived class, sets the object with the specified index in the derived class.</summary>
    /// <param name="objValue">The object.</param>
    /// <param name="index">The array index of the object.</param>
    protected virtual void SetItemCore(int index, object objValue)
    {
    }

    /// <summary>When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
    /// <param name="objItems">An array of items.</param>
    protected abstract void SetItemsCore(IList objItems);

    private void UnwireDataSource()
    {
      object dataSourceInternal = this.DataSourceInternal;
      if (dataSourceInternal is IComponent)
        ((IComponent) dataSourceInternal).Disposed -= new EventHandler(this.DataSourceDisposed);
      if (!(dataSourceInternal is ISupportInitializeNotification initializeNotification) || !this.IsDataSourceInitEventHookedInternal)
        return;
      initializeNotification.Initialized -= new EventHandler(this.DataSourceInitialized);
      this.IsDataSourceInitEventHookedInternal = false;
    }

    private void WireDataSource()
    {
      object dataSourceInternal = this.DataSourceInternal;
      if (dataSourceInternal is IComponent)
        ((IComponent) dataSourceInternal).Disposed += new EventHandler(this.DataSourceDisposed);
      if (dataSourceInternal is ISupportInitializeNotification initializeNotification && !initializeNotification.IsInitialized)
      {
        initializeNotification.Initialized += new EventHandler(this.DataSourceInitialized);
        this.IsDataSourceInitEventHookedInternal = true;
        this.IsDataSourceInitializedInternal = false;
      }
      else
        this.IsDataSourceInitializedInternal = true;
    }

    /// <summary>Should render color.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool ShouldRenderColor() => !string.IsNullOrEmpty(this.ColorMember);

    /// <summary>Should render image.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool ShouldRenderImage() => !string.IsNullOrEmpty(this.ImageMember);

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderForceSelectedIndexChangedAttribute(objWriter, false);
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
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
        return;
      this.RenderForceSelectedIndexChangedAttribute(objWriter, true);
    }

    /// <summary>Renders the force selected index changed attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [p].</param>
    private void RenderForceSelectedIndexChangedAttribute(
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!(this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick | blnForceRender))
        return;
      objWriter.WriteAttributeString("FSIC", this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick ? "1" : "0");
    }

    /// <summary>Renders the item id attribute</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objObject">The object.</param>
    protected void RenderItemIdAttribute(IResponseWriter objWriter, object objObject)
    {
      if (!(objObject is IClientObject clientObject))
        return;
      objWriter.WriteAttributeString("CID", clientObject.ID);
    }

    /// <summary>Renders the color and image attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
    /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
    /// <param name="objObject">The obj object.</param>
    protected void RenderColorAndImageAttribute(
      IResponseWriter objWriter,
      bool blnShouldRenderItemImage,
      bool blnShouldRenderItemColor,
      object objObject)
    {
      if (blnShouldRenderItemColor)
      {
        Color itemColor = this.GetItemColor(objObject);
        string strColor = !(itemColor != Color.Empty) ? "#FFFFFF" : CommonUtils.GetHtmlColor(itemColor);
        this.WriteColorAttribute(objWriter, strColor);
      }
      if (!blnShouldRenderItemImage)
        return;
      ResourceHandle itemImage = this.GetItemImage(objObject);
      string strValue = (string) null;
      if (itemImage != null)
        strValue = itemImage.ToString();
      if (string.IsNullOrEmpty(strValue))
        return;
      objWriter.WriteAttributeString("IM", strValue);
    }

    /// <summary>Writes the color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="strColor">Color of the STR.</param>
    protected virtual void WriteColorAttribute(IResponseWriter objWriter, string strColor) => objWriter.WriteAttributeString("CO", strColor);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new ListControlWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "ForceSelectedIndexChangedOnClick")
        this.UpdateParams(AttributeType.Events);
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }
  }
}
