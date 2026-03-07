namespace Gizmox.WebGUI.Forms
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Gizmox.WebGUI.Forms.Skins;
    using System.Drawing;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Configuration;

    /// <summary>Represents the method that will handle converting a <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ListControlConvertEventHandler(object sender, ListControlConvertEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListControl.Format"></see> event. </summary>
    /// <filterpriority>2</filterpriority>    
    [Serializable()]
    public class ListControlConvertEventArgs : ConvertEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListControlConvertEventArgs"></see> class with the specified object, type, and list item.</summary>
        /// <param name="objDesiredType">The <see cref="T:System.Type"></see> for the displayed item.</param>
        /// <param name="objListItem">The data source item to be displayed in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</param>
        /// <param name="objValue">The value displayed in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</param>
        public ListControlConvertEventArgs(object objValue, Type objDesiredType, object objListItem)
            : base(objValue, objDesiredType)
        {
            this.mobjListItem = objListItem;
        }


        /// <summary>Gets a data source item.</summary>
        /// <returns>The <see cref="T:System.Object"></see> that represents an item in the data source.</returns>
        /// <filterpriority>1</filterpriority>
        public object ListItem
        {
            get
            {
                return this.mobjListItem;
            }
        }


        private object mobjListItem;
    }

    /// <summary>Provides a common implementation of members for the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> and <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> classes.</summary>
    /// <filterpriority>1</filterpriority>
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    //Does not work in mono
    //[LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "SelectedValue")]
#endif
    [Serializable()]
    public abstract class ListControl : Control
    {
        #region Serializable Properties
        
        /// <summary>
        /// The DataManagerInternal property registration.
        /// </summary>
        private static readonly SerializableProperty DataManagerProperty = SerializableProperty.Register("DataManager", typeof(CurrencyManager), typeof(ListControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The DataSourceInternal property registration.
        /// </summary>
        private static readonly SerializableProperty DataSourceProperty = SerializableProperty.Register("DataSource", typeof(object), typeof(ListControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The DisplayMemberInternal property registration.
        /// </summary>
        private static readonly SerializableProperty DisplayMemberProperty = SerializableProperty.Register("DisplayMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));

        /// <summary>
        /// The FormatInfoInternal property registration.
        /// </summary>
        private static readonly SerializableProperty FormatInfoProperty = SerializableProperty.Register("FormatInfo", typeof(IFormatProvider), typeof(ListControl), new SerializablePropertyMetadata(null));

        /// <summary>
        /// The FormatStringInternal property registration.
        /// </summary>
        private static readonly SerializableProperty FormatStringProperty = SerializableProperty.Register("FormatString", typeof(string), typeof(ListControl), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// The FormattingEnabledInternal property registration.
        /// </summary>
        private static readonly SerializableProperty FormattingEnabledProperty = SerializableProperty.Register("FormattingEnabledInternal", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The InSetDataConnectionInternal property registration.
        /// </summary>
        private static readonly SerializableProperty InSetDataConnectionProperty = SerializableProperty.Register("InSetDataConnection", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The IsDataSourceInitEventHooked property registration.
        /// </summary>
        private static readonly SerializableProperty IsDataSourceInitEventHookedProperty = SerializableProperty.Register("IsDataSourceInitEventHooked", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The IsDataSourceInitializedInternal property registration.
        /// </summary>
        private static readonly SerializableProperty IsDataSourceInitializedProperty = SerializableProperty.Register("IsDataSourceInitialized", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The ValueMember property registration.
        /// </summary>
        private static readonly SerializableProperty ValueMemberProperty = SerializableProperty.Register("ValueMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));
        
        /// <summary>
        /// The ColorMember property registration.
        /// </summary>
        private static readonly SerializableProperty ColorMemberProperty = SerializableProperty.Register("ColorMember", typeof(string), typeof(ListControl), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// The ImageMember property registration.
        /// </summary>
        private static readonly SerializableProperty ImageMemberProperty = SerializableProperty.Register("ImageMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));

        #endregion

        #region Serializable Events

        /// <summary>
        /// The DataSourceChanged event registration.
        /// </summary>
        private static readonly SerializableEvent DataSourceChangedEvent = SerializableEvent.Register("DataSourceChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The DisplayMemberChanged event registration.
        /// </summary>
        private static readonly SerializableEvent DisplayMemberChangedEvent = SerializableEvent.Register("DisplayMemberChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The Format event registration.
        /// </summary>
        private static readonly SerializableEvent FormatEvent = SerializableEvent.Register("Format", typeof(ListControlConvertEventHandler), typeof(ListControl));

        /// <summary>
        /// The FormatInfoChanged event registration.
        /// </summary>
        private static readonly SerializableEvent FormatInfoChangedEvent = SerializableEvent.Register("FormatInfoChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The FormatStringChanged event registration.
        /// </summary>
        private static readonly SerializableEvent FormatStringChangedEvent = SerializableEvent.Register("FormatStringChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The FormattingEnabledChanged event registration.
        /// </summary>
        private static readonly SerializableEvent FormattingEnabledChangedEvent = SerializableEvent.Register("FormattingEnabledChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The SelectedValueChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedValueChangedEvent = SerializableEvent.Register("SelectedValueChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The ValueMemberChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ValueMemberChangedEvent = SerializableEvent.Register("ValueMemberChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        ///  The ColorMemberChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ColorMemberChangedEvent = SerializableEvent.Register("ColorMemberChanged", typeof(EventHandler), typeof(ListControl));

        /// <summary>
        /// The ImageMemberChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ImageMemberChangedEvent = SerializableEvent.Register("ImageMemberChanged", typeof(EventHandler), typeof(ListControl));
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
		private CurrencyManager DataManagerInternal
        {
            get
            {
                return this.GetValue<CurrencyManager>(ListControl.DataManagerProperty);
            }
            set
            {
                this.SetValue<CurrencyManager>(ListControl.DataManagerProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
		private object DataSourceInternal
        {
            get
            {
                return this.GetValue<object>(ListControl.DataSourceProperty);
            }
            set
            {
                this.SetValue<object>(ListControl.DataSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the display member.
        /// </summary>
        /// <value>The display member.</value>
		private BindingMemberInfo DisplayMemberInternal
        {
            get
            {
                return this.GetValue<BindingMemberInfo>(ListControl.DisplayMemberProperty);
            }
            set
            {
                this.SetValue<BindingMemberInfo>(ListControl.DisplayMemberProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the format info.
        /// </summary>
        /// <value>The format info.</value>
		private IFormatProvider FormatInfoInternal
        {
            get
            {
                return this.GetValue<IFormatProvider>(ListControl.FormatInfoProperty);
            }
            set
            {
                this.SetValue<IFormatProvider>(ListControl.FormatInfoProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the format string.
        /// </summary>
        /// <value>The format string.</value>
		private string FormatStringInternal
        {
            get
            {
                return this.GetValue<string>(ListControl.FormatStringProperty);
            }
            set
            {
                this.SetValue<string>(ListControl.FormatStringProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether formatting is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if formatting is enabled; otherwise, <c>false</c>.
        /// </value>
		private bool FormattingEnabledInternal
        {
            get
            {
                return this.GetValue<bool>(ListControl.FormattingEnabledProperty);
            }
            set
            {
                this.SetValue<bool>(ListControl.FormattingEnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether in data connection set.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if in data connection set; otherwise, <c>false</c>.
        /// </value>
        private bool InSetDataConnectionInternal
        {
            get
            {
                return this.GetValue<bool>(ListControl.InSetDataConnectionProperty);
            }
            set
            {
                this.SetValue<bool>(ListControl.InSetDataConnectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is data source init event hooked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is data source init event hooked; otherwise, <c>false</c>.
        /// </value>
        private bool IsDataSourceInitEventHookedInternal
        {
            get
            {
                return this.GetValue<bool>(ListControl.IsDataSourceInitEventHookedProperty);
            }
            set
            {
                this.SetValue<bool>(ListControl.IsDataSourceInitEventHookedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is data source initialized.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is data source initialized; otherwise, <c>false</c>.
        /// </value>
		private bool IsDataSourceInitializedInternal
        {
            get
            {
                return this.GetValue<bool>(ListControl.IsDataSourceInitializedProperty);
            }
            set
            {
                this.SetValue<bool>(ListControl.IsDataSourceInitializedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the value member.
        /// </summary>
        /// <value>The value member.</value>
		private BindingMemberInfo ValueMemberInternal
        {
            get
            {
                return this.GetValue<BindingMemberInfo>(ListControl.ValueMemberProperty);
            }
            set
            {
                this.SetValue<BindingMemberInfo>(ListControl.ValueMemberProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color member.
        /// </summary>
        /// <value>The value member.</value>
        private string ColorMemberInternal
        {
            get
            {
                return this.GetValue<string>(ListControl.ColorMemberProperty);
            }
            set
            {
                this.SetValue<string>(ListControl.ColorMemberProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the image member internal.
        /// </summary>
        /// <value>The image member internal.</value>
        private BindingMemberInfo ImageMemberInternal
        {
            get
            {
                return this.GetValue<BindingMemberInfo>(ListControl.ImageMemberProperty);
            }
            set
            {
                this.SetValue<BindingMemberInfo>(ListControl.ImageMemberProperty, value);
            }
        }


        /// <summary>Gets a value indicating whether the list enables selection of list items.</summary>
        /// <returns>true if the list enables list item selection; otherwise, false. The default is true.</returns>
        protected virtual bool AllowSelection
        {
            get
            {
                return true;
            }
        }

        internal bool BindingFieldEmpty
        {
            get
            {
                if (this.DisplayMemberInternal.BindingField.Length <= 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control. The default is null.</returns>
        protected CurrencyManager DataManager
        {
            get
            {
                return this.DataManagerInternal;
            }
        }

        /// <summary>Gets or sets the data source for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
        /// <returns>An object that implements the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces, such as a <see cref="T:System.Data.DataSet"></see> or an <see cref="T:System.Array"></see>. The default is null.</returns>
        /// <exception cref="T:System.ArgumentException">The assigned value does not implement the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null), AttributeProvider(typeof(Binding.IDataSourceAttributeProvider)), Gizmox.WebGUI.Forms.SRDescription("ListControlDataSourceDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), RefreshProperties(RefreshProperties.Repaint)]
        public virtual object DataSource
        {
            get
            {
                return this.DataSourceInternal;
            }
            set
            {
                if (((value != null) && !(value is IList)) && !(value is IListSource))
                {
                    throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
                }
                if (this.DataSourceInternal != value)
                {
                    try
                    {
                        this.SetDataConnection(value, this.DisplayMemberInternal, false);
                    }
                    catch
                    {
                        this.DisplayMember = "";
                    }
                    if (value == null)
                    {
                        this.DisplayMember = "";
                    }

                    FireObservableItemPropertyChanged("DataSource");
                }
            }
        }


        /// <summary>Gets or sets the property to display for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
        /// <returns>A <see cref="T:System.String"></see> specifying the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string (""). </returns>
        /// <filterpriority>1</filterpriority>
#if WG_NET46
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET452
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET451
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET45
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET40
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET35
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        // Editor definition
#if WG_NET2 || WG_NET35
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        [DefaultValue("")]
        [Gizmox.WebGUI.Forms.SRCategory("CatData")]
        [Gizmox.WebGUI.Forms.SRDescription("ListControlDisplayMemberDescr")]
        public string DisplayMember
        {
            get
            {
                return this.DisplayMemberInternal.BindingMember;
            }
            set
            {
                BindingMemberInfo BindingMemberInfo = this.DisplayMemberInternal;
                try
                {
                    this.SetDataConnection(this.DataSourceInternal, new BindingMemberInfo(value), false);
                }
                catch
                {
                    this.DisplayMemberInternal = BindingMemberInfo;
                }
            }
        }

        private TypeConverter DisplayMemberConverter
        {
            get
            {
                if ((this.mobjDisplayMemberConverter == null) && (this.DataManager != null))
                {
                    PropertyDescriptorCollection objCollection1 = this.DataManager.GetItemProperties();
                    if (objCollection1 != null)
                    {
                        PropertyDescriptor objPropertyDescriptor1 = objCollection1.Find(this.DisplayMemberInternal.BindingField, true);
                        if (objPropertyDescriptor1 != null)
                        {
                            this.mobjDisplayMemberConverter = objPropertyDescriptor1.Converter;
                        }
                    }
                }
                return this.mobjDisplayMemberConverter;
            }
        }

        /// <summary>Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior. </summary>
        /// <returns>The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
        /// <filterpriority>2</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DefaultValue((string)null)]
        public IFormatProvider FormatInfo
        {
            get
            {
                return this.FormatInfoInternal;
            }
            set
            {
                if (value != this.FormatInfoInternal)
                {
                    this.FormatInfoInternal = value;
                    this.RefreshItems();
                    this.OnFormatInfoChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>Gets or sets the format-specifier characters that indicate how a value is to be displayed.</summary>
        /// <returns>The string of format-specifier characters that indicates how a value is to be displayed.</returns>
        /// <filterpriority>2</filterpriority>
        [DefaultValue("")]
        [MergableProperty(false)]
        [Gizmox.WebGUI.Forms.SRDescription("ListControlFormatStringDescr")]
        public string FormatString
        {
            get
            {
                return this.FormatStringInternal;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!value.Equals(this.FormatStringInternal))
                {
                    this.FormatStringInternal = value;
                    this.RefreshItems();
                    this.OnFormatStringChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether formatting is applied to the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
        /// <returns>true if formatting of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property is enabled; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("ListControlFormattingEnabledDescr"), DefaultValue(false)]
        public bool FormattingEnabled
        {
            get
            {
                return this.FormattingEnabledInternal;
            }
            set
            {
                if (value != this.FormattingEnabledInternal)
                {
                    this.FormattingEnabledInternal = value;
                    this.RefreshItems();
                    this.OnFormattingEnabledChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Indicates if the list control context requires its events to cause callback
        /// </summary>
        protected virtual bool IsPostBackRequired
        {
            get
            {
                return this.DataSource != null;
            }
        }

        /// <summary>When overridden in a derived class, gets or sets the zero-based index of the currently selected item.</summary>
        /// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.Bindable(true)]
        public abstract int SelectedIndex { get; set; }

        /// <summary>Gets or sets the value of the member property specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</summary>
        /// <returns>An object containing the value of the member of the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</returns>
        /// <exception cref="T:System.InvalidOperationException">The assigned value is null or the empty string ("").</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), Gizmox.WebGUI.Forms.SRDescription("ListControlSelectedValueDescr"), Bindable(true), DefaultValue((string)null), Gizmox.WebGUI.Forms.SRCategory("CatData")]
        public object SelectedValue
        {
            get
            {
                if ((this.SelectedIndex != -1) && (this.DataManagerInternal != null))
                {
                    object obj1 = this.DataManagerInternal[this.SelectedIndex];
                    return this.FilterItemOnProperty(obj1, this.ValueMemberInternal.BindingField);
                }
                return null;
            }
            set
            {
                if (this.DataManagerInternal != null)
                {
                    string strText1 = this.ValueMemberInternal.BindingField;
                    if (strText1 == null || strText1 == string.Empty)
                    {
                        throw new InvalidOperationException(SR.GetString("ListControlEmptyValueMemberInSettingSelectedValue"));
                    }
                    PropertyDescriptor objPropertyDescriptor1 = this.DataManagerInternal.GetItemProperties().Find(strText1, true);
                    int num1 = this.DataManagerInternal.Find(objPropertyDescriptor1, value, true);
                    this.SelectedIndex = num1;
                }
            }
        }

        /// <summary>Gets or sets the property to use as the actual value for the items in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
        /// <returns>A <see cref="T:System.String"></see> representing the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string ("").</returns>
        /// <exception cref="T:System.ArgumentException">The specified property cannot be found on the object specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. </exception>
        /// <filterpriority>1</filterpriority>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Gizmox.WebGUI.Forms.SRDescription("ListControlValueMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Gizmox.WebGUI.Forms.SRDescription("ListControlValueMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        public string ValueMember
        {
            get
            {
                return this.ValueMemberInternal.BindingMember;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                BindingMemberInfo BindingMemberInfo = new BindingMemberInfo(value);
                if (!BindingMemberInfo.Equals(this.ValueMemberInternal))
                {
                    if (this.DisplayMember.Length == 0)
                    {
                        this.SetDataConnection(this.DataSource, BindingMemberInfo, false);
                    }
                    if (((this.DataManagerInternal != null) && (value != null)) && ((value.Length != 0) && !this.BindingMemberInfoInDataManager(BindingMemberInfo)))
                    {
                        throw new ArgumentException(SR.GetString("ListControlWrongValueMember"), "value");
                    }
                    this.ValueMemberInternal = BindingMemberInfo;
                    this.OnValueMemberChanged(EventArgs.Empty);
                    this.OnSelectedValueChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color member.
        /// </summary>
        /// <value>The color member.</value>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Gizmox.WebGUI.Forms.SRDescription("ListControlColorMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Gizmox.WebGUI.Forms.SRDescription("ListControlColorMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        public string ColorMember
        {
            get
            {
                //If we have a ColorMember
                if (this.ColorMemberInternal != null)
                {
                    //return the ColorMember
                    return this.ColorMemberInternal;
                }
                //Return default empty string
                return string.Empty;
            }
            set
            {
                if (this.ColorMember != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        this.ColorMemberInternal = null;
                    }
                    else
                    {
                        this.ColorMemberInternal = value;
                    }

                    //Raise the on color member changed event
                    this.OnColorMemberChanged(EventArgs.Empty);

                    //Update the control
                    this.Update();
                }
            }

        }

        /// <summary>
        /// Gets or sets the image member.
        /// </summary>
        /// <value>The image member.</value>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Gizmox.WebGUI.Forms.SRDescription("ListControlImageMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Gizmox.WebGUI.Forms.SRDescription("ListControlImageMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        public string ImageMember
        {
            get
            {
                return this.ImageMemberInternal.BindingMember;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                BindingMemberInfo BindingMemberInfo = new BindingMemberInfo(value);
                if (!BindingMemberInfo.Equals(this.ImageMemberInternal))
                {
                    this.ImageMemberInternal = BindingMemberInfo;
                    this.OnImageMemberChanged(EventArgs.Empty);
                }
            }

        }

        /// <summary>
        /// Gets a value indicating whether raise click event on mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [force selected index changed on click]. 
        /// If true, then SelectedIndexChanged event will fire on every index selection, even if actual selected index did not change (WinForms behavior).
        /// </summary>
        /// <value>
        /// <c>true</c> if [force selected index changed on click]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        [Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
        public bool ForceSelectedIndexChangedOnClick
        {
            get
            {
                return this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick;
            }
            set
            {
                this.WinFormsCompatibility.ForceSelectedIndexChangedOnClick = value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ListControlWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as ListControlWinFormsCompatibility;
            }
        }

        #endregion

        #region Fields

        [NonSerialized]
        private TypeConverter mobjDisplayMemberConverter;
        
        #region static fields

        [NonSerialized]
        private static TypeConverter StringTypeConverter = null;

        [NonSerialized]
        private static TypeConverter ImageTypeConverter = null;

        [NonSerialized]
        private static TypeConverter ColorTypeConverter = null;

        #endregion

        #endregion

        #region Events Handlers

        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged"), Gizmox.WebGUI.Forms.SRDescription("ListControlOnDataSourceChangedDescr")]
		public event EventHandler DataSourceChanged
        {
            add
            {
                this.AddHandler(ListControl.DataSourceChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.DataSourceChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DataSourceChanged event.
        /// </summary>
        private EventHandler DataSourceChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.DataSourceChangedEvent);
            }
        }


		/// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRDescription("ListControlOnDisplayMemberChangedDescr"), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged")]
		public event EventHandler DisplayMemberChanged
        {
            add
            {
                this.AddHandler(ListControl.DisplayMemberChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.DisplayMemberChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DisplayMemberChanged event.
        /// </summary>
        private EventHandler DisplayMemberChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.DisplayMemberChangedEvent);
            }
        }


		/// <summary>Occurs when the control is bound to a data value.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRDescription("ListControlFormatDescr"), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged")]
		public event ListControlConvertEventHandler Format
        {
            add
            {
                this.AddHandler(ListControl.FormatEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.FormatEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Format event.
        /// </summary>
        private ListControlConvertEventHandler FormatHandler
        {
            get
            {
                return (ListControlConvertEventHandler)this.GetHandler(ListControl.FormatEvent);
            }
        }



		/// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatInfo"></see> property changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged"), Gizmox.WebGUI.Forms.SRDescription("ListControlFormatInfoChangedDescr")]
		public event EventHandler FormatInfoChanged
        {
            add
            {
                this.AddHandler(ListControl.FormatInfoChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.FormatInfoChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the FormatInfoChanged event.
        /// </summary>
        private EventHandler FormatInfoChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.FormatInfoChangedEvent);
            }
        }



		/// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatString"></see> property changes</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRDescription("ListControlFormatStringChangedDescr"), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged")]
		public event EventHandler FormatStringChanged
        {
            add
            {
                this.AddHandler(ListControl.FormatStringChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.FormatStringChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the FormatStringChanged event.
        /// </summary>
        private EventHandler FormatStringChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.FormatStringChangedEvent);
            }
        }



		/// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormattingEnabled"></see> property changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRDescription("ListControlFormattingEnabledChangedDescr"), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged")]
		public event EventHandler FormattingEnabledChanged
        {
            add
            {
                this.AddHandler(ListControl.FormattingEnabledChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.FormattingEnabledChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the FormattingEnabledChanged event.
        /// </summary>
        private EventHandler FormattingEnabledChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.FormattingEnabledChangedEvent);
            }
        }



		/// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.SelectedValue"></see> property changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRDescription("ListControlOnSelectedValueChangedDescr"), Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged")]
		public event EventHandler SelectedValueChanged
        {
            add
            {
                this.AddHandler(ListControl.SelectedValueChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.SelectedValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectedValueChanged event.
        /// </summary>
        protected EventHandler SelectedValueChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.SelectedValueChangedEvent);
            }
        }


		/// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property changes.</summary>
		/// <filterpriority>1</filterpriority>
		[Gizmox.WebGUI.Forms.SRCategory("CatPropertyChanged"), Gizmox.WebGUI.Forms.SRDescription("ListControlOnValueMemberChangedDescr")]
		public event EventHandler ValueMemberChanged
        {
            add
            {
                this.AddHandler(ListControl.ValueMemberChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ListControl.ValueMemberChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ValueMemberChanged event.
        /// </summary>
        private EventHandler ValueMemberChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.ValueMemberChangedEvent);
            }
        }

        /// <summary>
        /// Gets the color member changed handler.
        /// </summary>
        /// <value>The color member changed handler.</value>
        private EventHandler ColorMemberChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.ColorMemberChangedEvent);
            }
        }

        /// <summary>
        /// Gets the image member changed handler.
        /// </summary>
        /// <value>The image member changed handler.</value>
        private EventHandler ImageMemberChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ListControl.ImageMemberChangedEvent);
            }
        }

		#endregion

        #region Events

        /// <summary>
        /// Raises the <see cref="E:BindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnBindingContextChanged(EventArgs e)
        {
            this.SetDataConnection(this.DataSourceInternal, this.DisplayMemberInternal, true);
            base.OnBindingContextChanged(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.DataSourceChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDisplayMemberChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.DisplayMemberChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.Format"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ListControlConvertEventArgs"></see> that contains the event data. </param>
        protected virtual void OnFormat(ListControlConvertEventArgs e)
        {
            // Raise event if needed
            ListControlConvertEventHandler objEventHandler = this.FormatHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatInfoChanged"></see> event. </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnFormatInfoChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.FormatInfoChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatStringChanged"></see> event. </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnFormatStringChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.FormatStringChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormattingEnabledChanged"></see> event. </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnFormattingEnabledChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.FormattingEnabledChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            this.OnSelectedValueChanged(EventArgs.Empty);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnSelectedValueChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.SelectedValueChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.ValueMemberChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnValueMemberChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ValueMemberChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ColorMemberChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnColorMemberChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ColorMemberChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ImageMemberChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnImageMemberChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ImageMemberChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #endregion

        #region C'Tor

        /// <summary>
        /// Initializes the <see cref="ListControl"/> class.
        /// </summary>
        static ListControl()
        {
            //Get the string type convertor
            ListControl.StringTypeConverter = TypeDescriptor.GetConverter(typeof(string));
            
            //Get the image type convertor
            ListControl.ImageTypeConverter = TypeDescriptor.GetConverter(typeof(ResourceHandle));

            //Get the color type convertor
            ListControl.ColorTypeConverter = TypeDescriptor.GetConverter(typeof(Color));
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> class. </summary>
        protected ListControl()
        {

        }

        #endregion

        #region Methods

        private bool BindingMemberInfoInDataManager(BindingMemberInfo objBindingMemberInfo)
        {
            if (this.DataManagerInternal != null)
            {
                PropertyDescriptorCollection objCollection1 = this.DataManagerInternal.GetItemProperties();
                int num1 = objCollection1.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    if (!typeof(IList).IsAssignableFrom(objCollection1[num2].PropertyType) && objCollection1[num2].Name.Equals(objBindingMemberInfo.BindingField))
                    {
                        return true;
                    }
                }
                for (int num3 = 0; num3 < num1; num3++)
                {
                    if (!typeof(IList).IsAssignableFrom(objCollection1[num3].PropertyType) && (string.Compare(objCollection1[num3].Name, objBindingMemberInfo.BindingField, true, CultureInfo.CurrentCulture) == 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void DataManager_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            if (this.DataManagerInternal != null)
            {
                if (e.Index == -1)
                {
                    this.SetItemsCore(this.DataManagerInternal.List);
                    if (this.AllowSelection)
                    {
                        this.SelectedIndex = this.DataManagerInternal.Position;
                    }
                }
                else
                {
                    this.SetItemCore(e.Index, this.DataManagerInternal[e.Index]);
                }
            }
        }

        private void DataManager_PositionChanged(object sender, EventArgs e)
        {
            if ((this.DataManagerInternal != null) && this.AllowSelection)
            {
                if (this.SelectedIndex != this.DataManagerInternal.Position)
                {
                    this.SelectedIndex = this.DataManagerInternal.Position;
                    this.Update();
                }
            }
        }

        private void DataSourceDisposed(object sender, EventArgs e)
        {
            this.SetDataConnection(null, new BindingMemberInfo(""), true);
        }

        private void DataSourceInitialized(object sender, EventArgs e)
        {
            this.SetDataConnection(this.DataSourceInternal, this.DisplayMemberInternal, true);
        }

        /// <summary>Retrieves the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object, given the item.</summary>
        /// <returns>The filtered object.</returns>
        /// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
        protected object FilterItemOnProperty(object objItem)
        {
            return this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);
        }

        /// <summary>Returns the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object given the item and the property name.</summary>
        /// <returns>The filtered object.</returns>
        /// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
        /// <param name="strField">The property name of the item the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> is bound to.</param>
        protected object FilterItemOnProperty(object objItem, string strField)
        {
            return ListControl.FilterItemOnProperty(this.DataManagerInternal, objItem, strField);
        }

        /// <summary>
        /// Filters the item on property.
        /// </summary>
        /// <param name="objCurrencyManager">The obj currency manager.</param>
        /// <param name="objItem">The obj item.</param>
        /// <param name="strField">The STR field.</param>
        /// <returns></returns>
        internal static object FilterItemOnProperty(CurrencyManager objCurrencyManager, object objItem, string strField)
        {
            if ((objItem != null) && (strField.Length > 0))
            {
                try
                {
                    PropertyDescriptor objPropertyDescriptor1;
                    if (objCurrencyManager != null)
                    {
                        objPropertyDescriptor1 = objCurrencyManager.GetItemProperties().Find(strField, true);
                    }
                    else
                    {
                        objPropertyDescriptor1 = TypeDescriptor.GetProperties(objItem).Find(strField, true);
                    }
                    if (objPropertyDescriptor1 != null)
                    {
                        objItem = objPropertyDescriptor1.GetValue(objItem);
                    }
                }
                catch
                {
                }
            }
            return objItem;
        }

        internal int FindStringInternal(string str, IList objItems, int intStartIndex, bool blnExact)
        {
            return this.FindStringInternal(str, objItems, intStartIndex, blnExact, true);
        }

        internal int FindStringInternal(string str, IList objI, int intStartIndex, bool blnExact, bool blnIgnorecase)
        {
            if ((str != null) && (objI != null))
            {
                if ((intStartIndex < -1) || (intStartIndex >= objI.Count))
                {
                    return -1;
                }
                bool blnFlag1 = false;
                int num1 = str.Length;
                int num2 = 0;
                for (int num3 = (intStartIndex + 1) % objI.Count; num2 < objI.Count; num3 = (num3 + 1) % objI.Count)
                {
                    num2++;
                    if (blnExact)
                    {
                        blnFlag1 = string.Compare(str, this.GetItemText(objI[num3]), blnIgnorecase, CultureInfo.CurrentCulture) == 0;
                    }
                    else
                    {
                        blnFlag1 = string.Compare(str, 0, this.GetItemText(objI[num3]), 0, num1, blnIgnorecase, CultureInfo.CurrentCulture) == 0;
                    }
                    if (blnFlag1)
                    {
                        return num3;
                    }
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
                {
                    return string.Empty;
                }
                objItem = this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);
                if (objItem == null)
                {
                    return "";
                }
                return Convert.ToString(objItem, CultureInfo.CurrentCulture);
            }
            object obj1 = this.FilterItemOnProperty(objItem, this.DisplayMemberInternal.BindingField);
            ListControlConvertEventArgs args1 = new ListControlConvertEventArgs(obj1, typeof(string), objItem);
            this.OnFormat(args1);
            if ((args1.Value != objItem) && (args1.Value is string))
            {
                return (string) args1.Value;
            }
            try
            {
                return (string) Formatter.FormatObject(obj1, typeof(string), this.DisplayMemberConverter, ListControl.StringTypeConverter, this.FormatStringInternal, this.FormatInfoInternal, null, DBNull.Value);
            }
            catch
            {
//                if (Gizmox.WebGUI.Forms.ClientUtils.IsSecurityOrCriticalException(exception1))
//                {
//                    throw;
//                }
                return ((obj1 != null) ? Convert.ToString(objItem, CultureInfo.CurrentCulture) : "");
            }
        }

        /// <summary>Returns the Color representation of the specified item.</summary>
        /// <returns>If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemColor(System.Object)"></see> is the value of the item as Color. Otherwise, the method returns the striColorng value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
        /// <param name="objItem">The object from which to get the contents to display. </param>
        /// <filterpriority>1</filterpriority>
        public virtual Color GetItemColor(object objItem)
        {
            // Color reference for method return value
            Color objColor = Color.Empty;

            // Get the color member defined for this listcontrol
            string strColorMember = this.ColorMember;

            // If color member is not valid
            if (string.IsNullOrEmpty(strColorMember))
            {
                // if item is color return itme
                if (objItem is Color)
                {
                    // Get item as color
                    objColor = (Color)objItem;
                }
            }
            else
            {
                // Get the mapped property value
                object objPropertyValue = this.FilterItemOnProperty(objItem, strColorMember);
                
                // If property value is not null
                if (objPropertyValue != null)
                {
                    // If property value is color
                    if (objPropertyValue is Color)
                    {
                        // Get the protpery as color and set it to the return value
                        objColor = (Color)objPropertyValue;
                    }
                    else
                    {
                        // If can convert from type
                        if (ListControl.ColorTypeConverter.CanConvertFrom(objPropertyValue.GetType()))
                        {
                            // Convert the property value to color and set it to the return value
                            objColor = (Color)ListControl.ColorTypeConverter.ConvertFrom(objPropertyValue);
                        }
                    }
                }
            }

            // Return the color
            return objColor;
        }

        /// <summary>Returns the Image representation of the specified item.</summary>
        /// <returns>If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ImageMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemImage(System.Object)"></see> is the value of the item as Image. Otherwise, the method returns the Image value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
        /// <param name="objItem">The object from which to get the contents to display. </param>
        /// <filterpriority>1</filterpriority>
        public virtual ResourceHandle GetItemImage(object objItem)
        {
            // ResourceHandle for method return value
            ResourceHandle objResourceHandle = null;

            // Get the Image member defined for this listcontrol
            string strImageMember = this.ImageMember;

            // If Image member is not empty
            if (!string.IsNullOrEmpty(strImageMember))
            {
                // Get the mapped property value
                object objPropertyValue = this.FilterItemOnProperty(objItem, strImageMember);

                // If property value is not null
                if (objPropertyValue != null)
                {
                    // If property value is ResourceHandle
                    if (objPropertyValue is ResourceHandle)
                    {
                        // Get the protpery as ResourceHandle and set it to the return value
                        objResourceHandle = (ResourceHandle)objPropertyValue;
                    }
                    else
                    {
                        // If can convert from type
                        if (ListControl.ImageTypeConverter.CanConvertFrom(objPropertyValue.GetType()))
                        {
                            // Convert the property value to ResourceHandle and set it to the return value
                            objResourceHandle = (ResourceHandle)ListControl.ImageTypeConverter.ConvertFrom(objPropertyValue);
                        }
                    }
                }
            }
            return objResourceHandle;
        }

        /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
        /// <param name="index">The zero-based index of the item whose data to refresh. </param>
        protected abstract void RefreshItem(int index);
        /// <summary>When overridden in a derived class, resynchronizes the item data with the contents of the data source.</summary>
        protected virtual void RefreshItems()
        {
        }

        private void SetDataConnection(object objNewDataSource, BindingMemberInfo objNewDisplayMember, bool blnForce)
        {
            // A flag indicating a change in data source
            bool blnFlag1 = this.DataSourceInternal != objNewDataSource;

            // A flag indicating a change in display member
            bool blnFlag2 = !this.DisplayMemberInternal.Equals(objNewDisplayMember);

            if (!this.InSetDataConnectionInternal)
            {
                try
                {
                    if ((blnForce || blnFlag1) || blnFlag2)
                    {
                        this.InSetDataConnectionInternal = true;
                        IList objList = (this.DataManager != null) ? this.DataManager.List : null;
                        bool blnFlag3 = this.DataManager == null;
                        this.UnwireDataSource();
                        this.DataSourceInternal = objNewDataSource;
                        this.DisplayMemberInternal = objNewDisplayMember;
                        this.WireDataSource();
                        if (this.IsDataSourceInitializedInternal)
                        {
                            CurrencyManager manager1 = null;
                            if (((objNewDataSource != null) && (this.BindingContext != null)) && (objNewDataSource != Convert.DBNull))
                            {
                                manager1 = (CurrencyManager) this.BindingContext[objNewDataSource, objNewDisplayMember.BindingPath];
                            }
                            if (this.DataManagerInternal != manager1)
                            {
                                if (this.DataManagerInternal != null)
                                {
                                    this.DataManagerInternal.ItemChanged -= new ItemChangedEventHandler(this.DataManager_ItemChanged);
                                    this.DataManagerInternal.PositionChanged -= new EventHandler(this.DataManager_PositionChanged);
                                }
                                this.DataManagerInternal = manager1;
                                if (this.DataManagerInternal != null)
                                {
                                    this.DataManagerInternal.ItemChanged += new ItemChangedEventHandler(this.DataManager_ItemChanged);
                                    this.DataManagerInternal.PositionChanged += new EventHandler(this.DataManager_PositionChanged);
                                }
                            }
                            if (((this.DataManagerInternal != null) && (blnFlag2 || blnFlag1)) && (((this.DisplayMemberInternal.BindingMember != null) && (this.DisplayMemberInternal.BindingMember.Length != 0)) && !this.BindingMemberInfoInDataManager(this.DisplayMemberInternal)))
                            {
                                throw new ArgumentException(SR.GetString("ListControlWrongDisplayMember"), "newDisplayMember");
                            }
                            if (((this.DataManagerInternal != null) && ((blnFlag1 || blnFlag2) || blnForce)) && (blnFlag2 || (blnForce && ((objList != this.DataManagerInternal.List) || blnFlag3))))
                            {
                                this.DataManager_ItemChanged(this.DataManagerInternal, new ItemChangedEventArgs(-1));
                            }
                        }
                        this.mobjDisplayMemberConverter = null;
                    }
                    if (blnFlag1)
                    {
                        this.OnDataSourceChanged(EventArgs.Empty);
                    }
                    if (blnFlag2)
                    {
                        this.OnDisplayMemberChanged(EventArgs.Empty);
                    }
                }
                finally
                {
                    this.InSetDataConnectionInternal = false;
                }
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
			// Get the internal data source.
            object objDataSourceInternal = this.DataSourceInternal;

            if (objDataSourceInternal is IComponent)
            {
                ((IComponent)objDataSourceInternal).Disposed -= new EventHandler(this.DataSourceDisposed);
            }
            ISupportInitializeNotification objDataSource = objDataSourceInternal as ISupportInitializeNotification;
            if ((objDataSource != null) && this.IsDataSourceInitEventHookedInternal)
            {
                objDataSource.Initialized -= new EventHandler(this.DataSourceInitialized);
                this.IsDataSourceInitEventHookedInternal = false;
            }
        }

        private void WireDataSource()
        {
			// Get the internal data source.
            object objDataSourceInternal = this.DataSourceInternal;

            if (objDataSourceInternal is IComponent)
            {
                ((IComponent)objDataSourceInternal).Disposed += new EventHandler(this.DataSourceDisposed);
            }
            ISupportInitializeNotification objDataSource = objDataSourceInternal as ISupportInitializeNotification;
            if ((objDataSource != null) && !objDataSource.IsInitialized)
            {
                objDataSource.Initialized += new EventHandler(this.DataSourceInitialized);
                this.IsDataSourceInitEventHookedInternal = true;
                this.IsDataSourceInitializedInternal = false;
            }
            else
            {
                this.IsDataSourceInitializedInternal = true;
            }
        }

        /// <summary>
        /// Should render color.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool ShouldRenderColor()
        {
            return !string.IsNullOrEmpty(this.ColorMember);
        }

        /// <summary>
        /// Should render image.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool ShouldRenderImage()
        {
            return !string.IsNullOrEmpty(this.ImageMember);
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render ForceSelectedIndexChanged attribute.
            RenderForceSelectedIndexChangedAttribute(objWriter, false);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Events))
            {
                // Render the ForceSelectedIndexChanged attribute
                RenderForceSelectedIndexChangedAttribute(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the force selected index changed attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [p].</param>
        private void RenderForceSelectedIndexChangedAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ForceSelectedIndexChanged, this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the item id attribute
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objObject">The object.</param>
        protected void RenderItemIdAttribute(IResponseWriter objWriter, object objObject)
        {
            // Try to get client object
            IClientObject objClientObject = objObject as IClientObject;
            
            // If there is a valid client object
            if (objClientObject != null)
            {
                // Render the client id
                objWriter.WriteAttributeString(WGAttributes.ClientId, objClientObject.ID);
            }
        }


        /// <summary>
        /// Renders the color and image attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
        /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
        /// <param name="objObject">The obj object.</param>
        protected void RenderColorAndImageAttribute(IResponseWriter objWriter, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, object objObject)
        {
            //Should we render the color value
            if (blnShouldRenderItemColor)
            {
                //Get the item color
                Color objColor = this.GetItemColor(objObject);

                string strColor = null;

                //If we got a color
                if (objColor != Color.Empty)
                {
                    //set the color to the string we render
                    strColor = CommonUtils.GetHtmlColor(objColor);
                }
                else
                {
                    //set a default color
                    strColor = "#FFFFFF";
                }

                //Render the color attribute
                WriteColorAttribute(objWriter, strColor);
            }

            //Should we render the image value
            if (blnShouldRenderItemImage)
            {
                //get the resource handle
                ResourceHandle objResourceHandle = this.GetItemImage(objObject);

                string strResourceHandle = null;

                //If we have a resource handle
                if (objResourceHandle != null)
                {
                    //Get the resource handle string
                    strResourceHandle = objResourceHandle.ToString();
                }

                //if the str Resource Handle is not empty
                if (!string.IsNullOrEmpty(strResourceHandle))
                {
                    //Set the image attribute
                    objWriter.WriteAttributeString(WGAttributes.Image, strResourceHandle);
                }
            }
        }

        /// <summary>
        /// Writes the color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="strColor">Color of the STR.</param>
        protected virtual void WriteColorAttribute(IResponseWriter objWriter, string strColor)
        {
            objWriter.WriteAttributeString(WGAttributes.Color, strColor);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new ListControlWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.ForceSelectedIndexChangedOnClick)
            {
                // We need to update params with events attribute type.
                UpdateParams(AttributeType.Events);
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion
    }
}