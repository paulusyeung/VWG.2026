// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Binding
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the simple binding between the property value of an object and the property value of a control.</summary>
  /// <filterpriority>1</filterpriority>
  [TypeConverter(typeof (ListBindingConverter))]
  [Serializable]
  public class Binding : SerializableObject
  {
    /// <summary>The BindingComplete event registration.</summary>
    private static readonly SerializableEvent BindingCompleteEvent = SerializableEvent.Register("BindingComplete", typeof (BindingCompleteEventHandler), typeof (Binding));
    /// <summary>The Format event registration.</summary>
    private static readonly SerializableEvent FormatEvent = SerializableEvent.Register("Format", typeof (ConvertEventHandler), typeof (Binding));
    /// <summary>The Parse event registration.</summary>
    private static readonly SerializableEvent ParseEvent = SerializableEvent.Register("Parse", typeof (ConvertEventHandler), typeof (Binding));
    private static readonly SerializableProperty BindingManagerBaseProperty = SerializableProperty.Register(nameof (BindingManagerBaseProperty), typeof (BindingManagerBase), typeof (Binding));
    private BindToObject BindToObjectInternal;
    private static readonly SerializableProperty BoundProperty = SerializableProperty.Register("Bound", typeof (bool), typeof (Binding), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty ControlProperty = SerializableProperty.Register(nameof (Control), typeof (IBindableComponent), typeof (Binding));
    private static readonly SerializableProperty ControlUpdateModeProperty = SerializableProperty.Register(nameof (ControlUpdateMode), typeof (ControlUpdateMode), typeof (Binding));
    private DataSourceUpdateMode DataSourceUpdateModeInternal;
    private object DataSourceNullValuePropertyInternal;
    private static readonly SerializableProperty DataSourceNullValueSetProperty = SerializableProperty.Register("DataSourceNullValueSet", typeof (bool), typeof (Binding), new SerializablePropertyMetadata((object) false));
    private IFormatProvider FormatInfoInternal;
    private string FormatStringInternal;
    private bool FormattingEnabledInternal;
    private static readonly SerializableProperty InOnBindingCompleteProperty = SerializableProperty.Register("inOnBindingComplete", typeof (bool), typeof (Binding));
    private static readonly SerializableProperty InPushOrPullProperty = SerializableProperty.Register("inPushOrPull", typeof (bool), typeof (Binding));
    private static readonly SerializableProperty InSetPropValueProperty = SerializableProperty.Register("inSetPropValue", typeof (bool), typeof (Binding));
    private static readonly SerializableProperty ModifiedProperty = SerializableProperty.Register("modified", typeof (bool), typeof (Binding));
    private object NullValueInternal;
    private string PropertyNameInternal = string.Empty;
    [NonSerialized]
    private PropertyDescriptor PropertyInfoInternal;
    [NonSerialized]
    private TypeConverter PropropertyInfoConverterInternal;
    [NonSerialized]
    private PropertyDescriptor PropropertyIsNullInfoInternal;
    [NonSerialized]
    private EventDescriptor ValidateInfoInternal;
    private int mintControlState;

    /// <summary>Occurs when a binding operation is complete, such as when data is pushed to the control property from the data source or vice versa</summary>
    public event BindingCompleteEventHandler BindingComplete
    {
      add => this.AddHandler(Binding.BindingCompleteEvent, (Delegate) value);
      remove => this.RemoveHandler(Binding.BindingCompleteEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BindingComplete event.</summary>
    private BindingCompleteEventHandler BindingCompleteHandler => (BindingCompleteEventHandler) this.GetHandler(Binding.BindingCompleteEvent);

    /// <summary>Occurs when the property of a control is bound to a data value.</summary>
    /// <filterpriority>1</filterpriority>
    public event ConvertEventHandler Format
    {
      add => this.AddHandler(Binding.FormatEvent, (Delegate) value);
      remove => this.RemoveHandler(Binding.FormatEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Format event.</summary>
    private ConvertEventHandler FormatHandler => (ConvertEventHandler) this.GetHandler(Binding.FormatEvent);

    /// <summary>Occurs when the value of a data-bound control changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event ConvertEventHandler Parse
    {
      add => this.AddHandler(Binding.ParseEvent, (Delegate) value);
      remove => this.RemoveHandler(Binding.ParseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Parse event.</summary>
    private ConvertEventHandler ParseHandler => (ConvertEventHandler) this.GetHandler(Binding.ParseEvent);

    private BindingManagerBase BindingManagerBaseInternal
    {
      get => this.GetValue<BindingManagerBase>(Binding.BindingManagerBaseProperty);
      set => this.SetValue<BindingManagerBase>(Binding.BindingManagerBaseProperty, value);
    }

    private bool BoundInternal
    {
      get => this.GetValue<bool>(Binding.BoundProperty);
      set => this.SetValue<bool>(Binding.BoundProperty, value);
    }

    private IBindableComponent ControlInternal
    {
      get => this.GetValue<IBindableComponent>(Binding.ControlProperty);
      set => this.SetValue<IBindableComponent>(Binding.ControlProperty, value);
    }

    private ControlUpdateMode ControlUpdateModeInternal
    {
      get => this.GetValue<ControlUpdateMode>(Binding.ControlUpdateModeProperty);
      set => this.SetValue<ControlUpdateMode>(Binding.ControlUpdateModeProperty, value);
    }

    private bool DataSourceNullValueSetInternal
    {
      get => this.GetValue<bool>(Binding.DataSourceNullValueSetProperty);
      set => this.SetValue<bool>(Binding.DataSourceNullValueSetProperty, value);
    }

    private bool InOnBindingCompleteInternal
    {
      get => this.GetValue<bool>(Binding.InOnBindingCompleteProperty);
      set => this.SetValue<bool>(Binding.InOnBindingCompleteProperty, value);
    }

    private bool InPushOrPullInternal
    {
      get => this.GetValue<bool>(Binding.InPushOrPullProperty);
      set => this.SetValue<bool>(Binding.InPushOrPullProperty, value);
    }

    private bool InSetPropValueInternal
    {
      get => this.GetValue<bool>(Binding.InSetPropValueProperty);
      set => this.SetValue<bool>(Binding.InSetPropValueProperty, value);
    }

    private bool ModifiedInternal
    {
      get => this.GetValue<bool>(Binding.ModifiedProperty);
      set => this.SetValue<bool>(Binding.ModifiedProperty, value);
    }

    private Binding()
    {
      this.PropertyNameInternal = "";
      this.FormatStringInternal = string.Empty;
      this.DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue((Type) null);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that simple-binds the indicated control property to the specified data member of the data source.</summary>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
    /// <param name="strDataMember">The property or list to bind to. </param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <exception cref="T:System.Exception">propertyName is neither a valid property of a control nor an empty string (""). </exception>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.</exception>
    public Binding(string strPropertyName, object objDataSource, string strDataMember)
      : this(strPropertyName, objDataSource, strDataMember, false, DataSourceUpdateMode.OnValidation, (object) null, string.Empty, (IFormatProvider) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the indicated control property to the specified data member of the data source, and optionally enables formatting to be applied.</summary>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false. </param>
    /// <param name="strDataMember">The property or list to bind to. </param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <exception cref="T:System.Exception">Formatting is disabled and propertyName is neither a valid property of a control nor an empty string (""). </exception>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
    public Binding(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled)
      : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, DataSourceUpdateMode.OnValidation, (object) null, string.Empty, (IFormatProvider) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the specified control property to the specified data member of the specified data source. Optionally enables formatting and propagates values to the data source based on the specified update setting.</summary>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="enmDataSourceUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The data source or data member or control property specified are associated with another binding in the collection.</exception>
    public Binding(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmDataSourceUpdateMode)
      : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, (object) null, string.Empty, (IFormatProvider) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the indicated the specified control property to the specified data member of the specified data source. Optionally enables formatting, propagates values to the data source based on the specified update setting, and sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source.</summary>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="enmDataSourceUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The data source or data member or control property specified are associated with another binding in the collection.</exception>
    public Binding(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmDataSourceUpdateMode,
      object objNullValue)
      : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, objNullValue, string.Empty, (IFormatProvider) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the specified control property to the specified data member of the specified data source. Optionally enables formatting with the specified format string; propagates values to the data source based on the specified update setting; enables formatting with the specified format string; and sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source and sets the specified format provider.</summary>
    /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed.</param>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="enmDataSourceUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The data source or data member or control property specified are associated with another binding in the collection.</exception>
    public Binding(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmDataSourceUpdateMode,
      object objNullValue,
      string strFormatString)
      : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, objNullValue, strFormatString, (IFormatProvider) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class with the specified control property to the specified data member of the specified data source. Optionally enables formatting with the specified format string; propagates values to the data source based on the specified update setting; enables formatting with the specified format string; sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source; and sets the specified format provider.</summary>
    /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed.</param>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="enmDataSourceUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="objFormatInfo">An implementation of <see cref="T:System.IFormatProvider"></see> to override default formatting behavior.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The data source or data member or control property specified are associated with another binding in the collection.</exception>
    public Binding(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmDataSourceUpdateMode,
      object objNullValue,
      string strFormatString,
      IFormatProvider objFormatInfo)
    {
      this.PropertyNameInternal = "";
      this.FormatStringInternal = string.Empty;
      this.DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue((Type) null);
      this.BindToObjectInternal = new BindToObject(this, objDataSource, strDataMember);
      this.PropertyNameInternal = strPropertyName;
      this.FormattingEnabledInternal = blnFormattingEnabled;
      this.FormatStringInternal = strFormatString;
      this.NullValueInternal = objNullValue;
      this.FormatInfoInternal = objFormatInfo;
      this.FormattingEnabledInternal = blnFormattingEnabled;
      this.DataSourceUpdateModeInternal = enmDataSourceUpdateMode;
      this.CheckBinding();
    }

    private void binding_MetaDataChanged(object sender, EventArgs e) => this.CheckBinding();

    private void BindTarget(bool bind)
    {
      this.EnsurePropertyInfoInternal();
      if (bind)
      {
        if (!this.IsBinding)
          return;
        if (this.PropertyInfoInternal != null && this.ControlInternal != null)
          this.PropertyInfoInternal.AddValueChanged((object) this.ControlInternal, new EventHandler(this.Target_PropertyChanged));
        this.EnsureValidateInfoInternal();
        if (this.ValidateInfoInternal == null)
          return;
        this.ValidateInfoInternal.AddEventHandler((object) this.ControlInternal, (Delegate) new CancelEventHandler(this.Target_Validate));
      }
      else
      {
        if (this.PropertyInfoInternal != null && this.ControlInternal != null)
          this.PropertyInfoInternal.RemoveValueChanged((object) this.ControlInternal, new EventHandler(this.Target_PropertyChanged));
        this.EnsureValidateInfoInternal();
        if (this.ValidateInfoInternal == null)
          return;
        this.ValidateInfoInternal.RemoveEventHandler((object) this.ControlInternal, (Delegate) new CancelEventHandler(this.Target_Validate));
      }
    }

    private void CheckBinding()
    {
      this.BindToObjectInternal.CheckBinding();
      if (this.ControlInternal == null || this.PropertyNameInternal.Length <= 0)
      {
        this.PropertyInfoInternal = (PropertyDescriptor) null;
        this.ValidateInfoInternal = (EventDescriptor) null;
      }
      else
      {
        PropertyDescriptor propertyDescriptor = this.InitPropInfoConverter();
        if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof (bool) && !propertyDescriptor.IsReadOnly)
        {
          this.PropropertyIsNullInfoInternal = propertyDescriptor;
          this.SetState(BindingState.PropropertyIsNullInfoInternal, this.PropropertyIsNullInfoInternal != null);
        }
        EventDescriptor eventDescriptor = (EventDescriptor) null;
        string strB = "Validating";
        EventDescriptorCollection events = TypeDescriptor.GetEvents((object) this.ControlInternal);
        for (int index = 0; index < events.Count; ++index)
        {
          if (eventDescriptor == null && ClientUtils.IsEquals(events[index].Name, strB, StringComparison.OrdinalIgnoreCase))
          {
            eventDescriptor = events[index];
            break;
          }
        }
        this.ValidateInfoInternal = eventDescriptor;
        this.SetState(BindingState.ValidateInfoInternal, this.ValidateInfoInternal != null);
      }
      this.UpdateIsBinding();
    }

    /// <summary>
    /// We seperated this function from CheckBinding() because we added [NonSerialized] attr
    /// to the private TypeConverter propInfoConverter;
    /// this to support sessionState = CustomSqlDatabase.
    /// We have replaced this.propInfoConverter with a PropInfoConverter{} property,
    /// there we check if the value of propInfoConverter is null(after Deserialization)
    /// and if so we restore its value.
    /// </summary>
    /// <returns>descriptor2</returns>
    private PropertyDescriptor InitPropInfoConverter()
    {
      this.ControlInternal.DataBindings.CheckDuplicates(this);
      Type type = this.ControlInternal.GetType();
      string strB = this.PropertyNameInternal + "IsNull";
      PropertyDescriptor propertyDescriptor1 = (PropertyDescriptor) null;
      PropertyDescriptor propertyDescriptor2 = (PropertyDescriptor) null;
      InheritanceAttribute attribute = (InheritanceAttribute) TypeDescriptor.GetAttributes((object) this.ControlInternal)[typeof (InheritanceAttribute)];
      PropertyDescriptorCollection descriptorCollection = attribute == null || attribute.InheritanceLevel == InheritanceLevel.NotInherited ? TypeDescriptor.GetProperties((object) this.ControlInternal) : TypeDescriptor.GetProperties(type);
      for (int index = 0; index < descriptorCollection.Count; ++index)
      {
        if (propertyDescriptor1 == null && ClientUtils.IsEquals(descriptorCollection[index].Name, this.PropertyNameInternal, StringComparison.OrdinalIgnoreCase))
        {
          propertyDescriptor1 = descriptorCollection[index];
          if (propertyDescriptor2 != null)
            break;
        }
        if (propertyDescriptor2 == null && ClientUtils.IsEquals(descriptorCollection[index].Name, strB, StringComparison.OrdinalIgnoreCase))
        {
          propertyDescriptor2 = descriptorCollection[index];
          if (propertyDescriptor1 != null)
            break;
        }
      }
      if (propertyDescriptor1 == null)
        throw new ArgumentException(SR.GetString("ListBindingBindProperty", (object) this.PropertyNameInternal), "PropertyName");
      if (propertyDescriptor1.IsReadOnly && this.ControlUpdateModeInternal != ControlUpdateMode.Never)
        throw new ArgumentException(SR.GetString("ListBindingBindPropertyReadOnly", (object) this.PropertyNameInternal), "PropertyName");
      this.PropertyInfoInternal = propertyDescriptor1;
      this.SetState(BindingState.PropertyInfoInternal, this.PropertyInfoInternal != null);
      Type propertyType = this.PropertyInfoInternal.PropertyType;
      this.PropropertyInfoConverterInternal = this.PropertyInfoInternal.Converter;
      this.SetState(BindingState.PropropertyInfoConverterInternal, this.PropropertyInfoConverterInternal != null);
      return propertyDescriptor2;
    }

    internal bool ControlAtDesignTime()
    {
      IComponent controlInternal = (IComponent) this.ControlInternal;
      if (controlInternal == null)
        return false;
      ISite site = controlInternal.Site;
      return site != null && site.DesignMode;
    }

    private BindingCompleteEventArgs CreateBindingCompleteEventArgs(
      BindingCompleteContext enmContext,
      Exception objException)
    {
      bool blnCancel = false;
      string empty = string.Empty;
      BindingCompleteState enmBindingCompleteState = BindingCompleteState.Success;
      string strErrorText;
      if (objException != null)
      {
        strErrorText = objException.Message;
        enmBindingCompleteState = BindingCompleteState.Exception;
        blnCancel = true;
      }
      else
      {
        strErrorText = this.BindToObject.DataErrorText;
        if (!CommonUtils.IsNullOrEmpty(strErrorText))
          enmBindingCompleteState = BindingCompleteState.DataError;
      }
      return new BindingCompleteEventArgs(this, enmBindingCompleteState, enmContext, strErrorText, objException, blnCancel);
    }

    private object FormatObject(object objValue)
    {
      if (this.ControlAtDesignTime())
        return objValue;
      this.EnsurePropertyInfoInternal();
      Type propertyType = this.PropertyInfoInternal.PropertyType;
      if (this.FormattingEnabledInternal)
      {
        ConvertEventArgs objCevent = new ConvertEventArgs(objValue, propertyType);
        this.OnFormat(objCevent);
        if (objCevent.Value != objValue)
          return objCevent.Value;
        TypeConverter objSourceConverter = (TypeConverter) null;
        if (this.BindToObjectInternal.FieldInfo != null)
          objSourceConverter = this.BindToObjectInternal.FieldInfo.Converter;
        return Formatter.FormatObject(objValue, propertyType, objSourceConverter, this.PropInfoConverter, this.FormatStringInternal, this.FormatInfoInternal, this.NullValueInternal, this.DataSourceNullValuePropertyInternal);
      }
      ConvertEventArgs objCevent1 = new ConvertEventArgs(objValue, propertyType);
      this.OnFormat(objCevent1);
      object obj1 = objCevent1.Value;
      if (!(propertyType != typeof (object)))
        return objValue;
      if (obj1 != null && (obj1.GetType().IsSubclassOf(propertyType) || !(obj1.GetType() != propertyType)))
        return obj1;
      TypeConverter converter = TypeDescriptor.GetConverter(objValue != null ? objValue.GetType() : typeof (object));
      if (converter == null || !converter.CanConvertTo(propertyType))
      {
        if (objValue is IConvertible)
        {
          object obj2 = Convert.ChangeType(objValue, propertyType, (IFormatProvider) CultureInfo.CurrentCulture);
          if (obj2 != null && (obj2.GetType().IsSubclassOf(propertyType) || obj2.GetType() == propertyType))
            return obj2;
        }
        throw new FormatException(SR.GetString("ListBindingFormatFailed"));
      }
      return converter.ConvertTo(objValue, propertyType);
    }

    private TypeConverter PropInfoConverter
    {
      get
      {
        this.EnsurePropropertyInfoConverterInternal();
        if (this.PropropertyInfoConverterInternal == null)
          this.EnsurePropInfoConverter();
        return this.PropropertyInfoConverterInternal;
      }
    }

    private void FormLoaded(object sender, EventArgs e) => this.CheckBinding();

    private object GetDataSourceNullValue(Type objType) => !this.DataSourceNullValueSetInternal ? Formatter.GetDefaultDataSourceNullValue(objType) : this.DataSourceNullValuePropertyInternal;

    private object GetPropValue()
    {
      bool flag = false;
      this.EnsurePropropertyIsNullInfoInternal();
      if (this.PropropertyIsNullInfoInternal != null)
        flag = (bool) this.PropropertyIsNullInfoInternal.GetValue((object) this.ControlInternal);
      if (flag)
        return this.DataSourceNullValue;
      this.EnsurePropertyInfoInternal();
      return this.PropertyInfoInternal.GetValue((object) this.ControlInternal) ?? this.DataSourceNullValue;
    }

    internal static bool IsComponentCreated(IBindableComponent component)
    {
      Control control = component as Control;
      return true;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
    protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
    {
      if (this.InOnBindingCompleteInternal)
        return;
      try
      {
        this.InOnBindingCompleteInternal = true;
        if (this.BindingCompleteHandler == null)
          return;
        this.BindingCompleteHandler((object) this, e);
      }
      catch (Exception ex)
      {
        if (ClientUtils.IsSecurityOrCriticalException(ex))
          throw;
        else
          e.Cancel = true;
      }
      finally
      {
        this.InOnBindingCompleteInternal = false;
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> event.</summary>
    /// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
    protected virtual void OnFormat(ConvertEventArgs objCevent)
    {
      ConvertEventHandler formatHandler = this.FormatHandler;
      if (formatHandler != null)
        formatHandler((object) this, objCevent);
      object o = objCevent.Value;
      Type desiredType = objCevent.DesiredType;
      if (this.FormattingEnabledInternal || o is DBNull || !(desiredType != (Type) null) || desiredType.IsInstanceOfType(o) || !(o is IConvertible))
        return;
      objCevent.Value = Convert.ChangeType(o, desiredType, (IFormatProvider) CultureInfo.CurrentCulture);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> event.</summary>
    /// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
    protected virtual void OnParse(ConvertEventArgs objCevent)
    {
      ConvertEventHandler parseHandler = this.ParseHandler;
      if (parseHandler != null)
        parseHandler((object) this, objCevent);
      object o = objCevent.Value;
      Type desiredType = objCevent.DesiredType;
      if (this.FormattingEnabledInternal || o is DBNull || o == null || !(desiredType != (Type) null) || desiredType.IsInstanceOfType(o) || !(o is IConvertible))
        return;
      objCevent.Value = Convert.ChangeType(o, desiredType, (IFormatProvider) CultureInfo.CurrentCulture);
    }

    /// <summary>Ensures the property info internal.</summary>
    private void EnsurePropertyInfoInternal()
    {
      if (!this.GetState(BindingState.PropertyInfoInternal) || this.PropertyInfoInternal != null)
        return;
      this.EnsurePropInfoConverter();
    }

    /// <summary>Ensures the prop info converter.</summary>
    private void EnsurePropInfoConverter()
    {
      if (this.ControlInternal == null || this.PropertyNameInternal.Length <= 0)
        return;
      this.InitPropInfoConverter();
    }

    /// <summary>Ensures the proproperty info converter internal.</summary>
    private void EnsurePropropertyInfoConverterInternal()
    {
      if (!this.GetState(BindingState.PropropertyInfoConverterInternal) || this.PropropertyInfoConverterInternal != null)
        return;
      this.EnsurePropInfoConverter();
    }

    /// <summary>Ensures the proproperty is null info internal.</summary>
    private void EnsurePropropertyIsNullInfoInternal()
    {
      if (!this.GetState(BindingState.PropropertyIsNullInfoInternal) || this.PropropertyIsNullInfoInternal != null)
        return;
      this.CheckBinding();
    }

    /// <summary>Ensures the validate info internal.</summary>
    private void EnsureValidateInfoInternal()
    {
      if (!this.GetState(BindingState.ValidateInfoInternal) || this.ValidateInfoInternal != null)
        return;
      this.CheckBinding();
    }

    /// <summary>Sets the state.</summary>
    /// <param name="enmState">State of the enm.</param>
    /// <param name="blnValue">The flag value to set.</param>
    internal void SetState(BindingState enmState, bool blnValue) => this.mintControlState = blnValue ? (int) ((BindingState) this.mintControlState | enmState) : (int) ((BindingState) this.mintControlState & ~enmState);

    /// <summary>Gets the state.</summary>
    /// <param name="enmState">State of the enm.</param>
    /// <returns></returns>
    internal bool GetState(BindingState enmState) => ((BindingState) this.mintControlState & enmState) != 0;

    private object ParseObject(object objValue)
    {
      Type bindToType = this.BindToObjectInternal.BindToType;
      if (this.FormattingEnabledInternal)
      {
        ConvertEventArgs objCevent = new ConvertEventArgs(objValue, bindToType);
        this.OnParse(objCevent);
        object objB = objCevent.Value;
        if (!object.Equals(objValue, objB))
          return objB;
        TypeConverter objTargetConverter = (TypeConverter) null;
        if (this.BindToObjectInternal.FieldInfo != null)
          objTargetConverter = this.BindToObjectInternal.FieldInfo.Converter;
        this.EnsurePropertyInfoInternal();
        return Formatter.ParseObject(objValue, bindToType, objValue == null ? this.PropertyInfoInternal.PropertyType : objValue.GetType(), objTargetConverter, this.PropInfoConverter, this.FormatInfoInternal, this.NullValueInternal, this.GetDataSourceNullValue(bindToType));
      }
      ConvertEventArgs objCevent1 = new ConvertEventArgs(objValue, bindToType);
      this.OnParse(objCevent1);
      if (objCevent1.Value != null && (objCevent1.Value.GetType().IsSubclassOf(bindToType) || objCevent1.Value.GetType() == bindToType || objCevent1.Value is DBNull))
        return objCevent1.Value;
      TypeConverter converter = TypeDescriptor.GetConverter(objValue != null ? objValue.GetType() : typeof (object));
      if (converter != null && converter.CanConvertTo(bindToType))
        return converter.ConvertTo(objValue, bindToType);
      if (objValue is IConvertible)
      {
        object obj = Convert.ChangeType(objValue, bindToType, (IFormatProvider) CultureInfo.CurrentCulture);
        if (obj != null && (obj.GetType().IsSubclassOf(bindToType) || obj.GetType() == bindToType))
          return obj;
      }
      return (object) null;
    }

    internal bool PullData() => this.PullData(true, false);

    internal bool PullData(bool blnReformat) => this.PullData(blnReformat, false);

    internal bool PullData(bool blnReformat, bool blnForce)
    {
      if (this.ControlUpdateMode == ControlUpdateMode.Never)
        blnReformat = false;
      bool flag = false;
      object objValue = (object) null;
      Exception objException = (Exception) null;
      if (this.IsBinding)
      {
        if (!blnForce)
        {
          if (!CommonUtils.IsMono)
          {
            this.EnsurePropertyInfoInternal();
            if (this.PropertyInfoInternal.SupportsChangeEvents && !this.ModifiedInternal)
              return false;
          }
          if (this.DataSourceUpdateMode == DataSourceUpdateMode.Never)
            return false;
        }
        if (this.InPushOrPullInternal && this.FormattingEnabledInternal)
          return false;
        this.InPushOrPullInternal = true;
        object propValue = this.GetPropValue();
        try
        {
          objValue = this.ParseObject(propValue);
        }
        catch (Exception ex)
        {
          objException = ex;
        }
        try
        {
          if (objException != null || !this.FormattingEnabled && objValue == null)
          {
            flag = true;
            objValue = this.BindToObjectInternal.GetValue();
          }
          if (blnReformat && (!this.FormattingEnabled || !flag))
          {
            object obj = this.FormatObject(objValue);
            if (blnForce || !this.FormattingEnabled || !object.Equals(obj, propValue))
              this.SetPropValue(obj);
          }
          if (!flag)
            this.BindToObjectInternal.SetValue(objValue);
        }
        catch (Exception ex)
        {
          objException = ex;
          if (!this.FormattingEnabled)
            throw;
        }
        finally
        {
          this.InPushOrPullInternal = false;
        }
        if (this.FormattingEnabled)
        {
          BindingCompleteEventArgs completeEventArgs = this.CreateBindingCompleteEventArgs(BindingCompleteContext.DataSourceUpdate, objException);
          this.OnBindingComplete(completeEventArgs);
          if (completeEventArgs.BindingCompleteState == BindingCompleteState.Success && !completeEventArgs.Cancel)
            this.ModifiedInternal = false;
          return completeEventArgs.Cancel;
        }
        this.ModifiedInternal = false;
      }
      return false;
    }

    internal bool PushData() => this.PushData(false);

    internal bool PushData(bool blnForce)
    {
      Exception objException = (Exception) null;
      if ((blnForce || this.ControlUpdateMode != ControlUpdateMode.Never) && (!this.InPushOrPullInternal || !this.FormattingEnabledInternal))
      {
        this.InPushOrPullInternal = true;
        try
        {
          if (this.IsBinding)
          {
            this.SetPropValue(this.FormatObject(this.BindToObjectInternal.GetValue()));
            this.ModifiedInternal = false;
          }
          else
            this.SetPropValue((object) null);
        }
        catch (Exception ex)
        {
          objException = ex;
          if (!this.FormattingEnabled)
            throw;
        }
        finally
        {
          this.InPushOrPullInternal = false;
        }
        if (this.FormattingEnabled)
        {
          BindingCompleteEventArgs completeEventArgs = this.CreateBindingCompleteEventArgs(BindingCompleteContext.ControlUpdate, objException);
          this.OnBindingComplete(completeEventArgs);
          return completeEventArgs.Cancel;
        }
      }
      return false;
    }

    /// <summary>Sets the control property to the value read from the data source.</summary>
    public void ReadValue() => this.PushData(true);

    internal void SetBindableComponent(IBindableComponent value)
    {
      if (this.ControlInternal == value)
        return;
      IBindableComponent controlInternal = this.ControlInternal;
      this.BindTarget(false);
      this.ControlInternal = value;
      this.BindTarget(true);
      try
      {
        this.CheckBinding();
      }
      catch
      {
        this.BindTarget(false);
        this.ControlInternal = controlInternal;
        this.BindTarget(true);
        throw;
      }
      BindingContext.UpdateBinding(this.ControlInternal == null || !Binding.IsComponentCreated(this.ControlInternal) ? (BindingContext) null : this.ControlInternal.BindingContext, this);
      if (!(value is Form form))
        return;
      form.Load += new EventHandler(this.FormLoaded);
    }

    internal void SetListManager(BindingManagerBase objBindingManagerBase)
    {
      if (this.BindingManagerBase is CurrencyManager)
        ((CurrencyManager) this.BindingManagerBase).MetaDataChanged -= new EventHandler(this.binding_MetaDataChanged);
      this.BindingManagerBaseInternal = objBindingManagerBase;
      if (this.BindingManagerBase is CurrencyManager)
        ((CurrencyManager) this.BindingManagerBase).MetaDataChanged += new EventHandler(this.binding_MetaDataChanged);
      this.BindToObject.SetBindingManagerBase(objBindingManagerBase);
      this.CheckBinding();
    }

    private void SetPropValue(object objValue)
    {
      if (this.ControlAtDesignTime())
        return;
      this.InSetPropValueInternal = true;
      try
      {
        this.EnsurePropertyInfoInternal();
        if (objValue == null || Formatter.IsNullData(objValue, this.DataSourceNullValue))
        {
          this.EnsurePropropertyIsNullInfoInternal();
          if (this.PropropertyIsNullInfoInternal != null)
            this.PropropertyIsNullInfoInternal.SetValue((object) this.ControlInternal, (object) true);
          else if (this.PropertyInfoInternal.PropertyType == typeof (object))
            this.PropertyInfoInternal.SetValue((object) this.ControlInternal, this.DataSourceNullValue);
          else
            this.PropertyInfoInternal.SetValue((object) this.ControlInternal, (object) null);
        }
        else
          this.PropertyInfoInternal.SetValue((object) this.ControlInternal, objValue);
      }
      finally
      {
        this.InSetPropValueInternal = false;
      }
    }

    private bool ShouldSerializeDataSourceNullValue() => this.DataSourceNullValueSetInternal && this.DataSourceNullValuePropertyInternal != Formatter.GetDefaultDataSourceNullValue((Type) null);

    private bool ShouldSerializeFormatString() => this.FormatStringInternal != null && this.FormatStringInternal.Length > 0;

    private bool ShouldSerializeNullValue() => this.NullValueInternal != null;

    private void Target_PropertyChanged(object sender, EventArgs e)
    {
      if (this.InSetPropValueInternal || !this.IsBinding)
        return;
      this.ModifiedInternal = true;
      if (this.DataSourceUpdateMode != DataSourceUpdateMode.OnPropertyChanged)
        return;
      this.PullData(false);
      this.ModifiedInternal = true;
    }

    private void Target_Validate(object sender, CancelEventArgs e)
    {
      try
      {
        if (!this.PullData(true))
          return;
        e.Cancel = true;
      }
      catch
      {
        e.Cancel = true;
      }
    }

    internal void UpdateIsBinding()
    {
      bool bind = this.IsBindable && this.ComponentCreated && this.BindingManagerBase.IsBinding;
      if (this.BoundInternal == bind)
        return;
      this.BoundInternal = bind;
      this.BindTarget(bind);
      if (!this.BoundInternal)
        return;
      if (this.ControlUpdateModeInternal == ControlUpdateMode.Never)
        this.PullData(false, true);
      else
        this.PushData();
    }

    /// <summary>Reads the current value from the control property and writes it to the data source.</summary>
    public void WriteValue() => this.PullData(true, true);

    /// <summary>Gets the control the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    [DefaultValue(null)]
    public IBindableComponent BindableComponent => this.ControlInternal;

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.
    /// </summary>
    /// <value>The binding manager base.</value>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that manages this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    public BindingManagerBase BindingManagerBase => this.BindingManagerBaseInternal;

    /// <summary>
    /// Gets an object that contains information about this binding based on the dataMember parameter in the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> constructor.
    /// </summary>
    /// <value>The binding member info.</value>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> that contains information about this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    public BindingMemberInfo BindingMemberInfo => this.BindToObjectInternal.BindingMemberInfo;

    internal BindToObject BindToObject => this.BindToObjectInternal;

    internal bool ComponentCreated => Binding.IsComponentCreated(this.ControlInternal);

    /// <summary>Gets the control that the binding belongs to.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the binding belongs to.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
    [DefaultValue(null)]
    public Control Control => this.ControlInternal as Control;

    /// <summary>Gets or sets when changes to the data source are propagated to the bound control property.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ControlUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnPropertyChanged"></see>.</returns>
    [DefaultValue(0)]
    public ControlUpdateMode ControlUpdateMode
    {
      get => this.ControlUpdateModeInternal;
      set
      {
        if (this.ControlUpdateModeInternal == value)
          return;
        this.ControlUpdateModeInternal = value;
        if (!this.IsBinding)
          return;
        this.PushData();
      }
    }

    /// <summary>Gets the data source for this binding.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the data source.</returns>
    /// <filterpriority>1</filterpriority>
    public object DataSource => this.BindToObjectInternal.DataSource;

    /// <summary>Gets or sets the value to be stored in the data source if the control value is null or empty.</summary>
    /// <returns>The <see cref="T:System.Object"></see> to be stored in the data source when the control property is empty or null. The default is <see cref="T:System.DBNull"></see> for value types and null for non-value types.</returns>
    public object DataSourceNullValue
    {
      get => this.DataSourceNullValuePropertyInternal;
      set
      {
        if (object.Equals(this.DataSourceNullValuePropertyInternal, value))
          return;
        object propertyInternal = this.DataSourceNullValuePropertyInternal;
        this.DataSourceNullValuePropertyInternal = value;
        this.DataSourceNullValueSetInternal = true;
        if (!this.IsBinding)
          return;
        object objValue = this.BindToObjectInternal.GetValue();
        if (Formatter.IsNullData(objValue, propertyInternal))
          this.WriteValue();
        if (!Formatter.IsNullData(objValue, value))
          return;
        this.ReadValue();
      }
    }

    /// <summary>Gets or sets when changes to the bound control property are propagated to the data source.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnValidation"></see>.</returns>
    [DefaultValue(DataSourceUpdateMode.OnPropertyChanged)]
    public DataSourceUpdateMode DataSourceUpdateMode
    {
      get => this.DataSourceUpdateModeInternal;
      set
      {
        if (this.DataSourceUpdateModeInternal == value)
          return;
        this.DataSourceUpdateModeInternal = value;
      }
    }

    /// <summary>Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior.</summary>
    /// <returns>The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    public IFormatProvider FormatInfo
    {
      get => this.FormatInfoInternal;
      set
      {
        if (this.FormatInfoInternal == value)
          return;
        this.FormatInfoInternal = value;
        if (!this.IsBinding)
          return;
        this.PushData();
      }
    }

    /// <summary>Gets or sets the format specifier characters that indicate how a value is to be displayed.</summary>
    /// <returns>The string of format specifier characters that indicate how a value is to be displayed.</returns>
    /// <filterpriority>1</filterpriority>
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
        if (!this.IsBinding)
          return;
        this.PushData();
      }
    }

    /// <summary>Gets or sets a value indicating whether formatting is applied to the control property data.</summary>
    /// <returns>true if formatting of control property data is enabled; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public bool FormattingEnabled
    {
      get => this.FormattingEnabledInternal;
      set
      {
        if (this.FormattingEnabledInternal == value)
          return;
        this.FormattingEnabledInternal = value;
        if (!this.IsBinding)
          return;
        this.PushData();
      }
    }

    internal bool IsBindable => this.ControlInternal != null && this.PropertyNameInternal.Length > 0 && this.BindToObjectInternal.DataSource != null && this.BindingManagerBase != null;

    /// <summary>Gets a value indicating whether the binding is active.</summary>
    /// <returns>true if the binding is active; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool IsBinding => this.BoundInternal;

    /// <summary>Gets a value indicating whether [in set prop value].</summary>
    /// <value><c>true</c> if [in set prop value]; otherwise, <c>false</c>.</value>
    internal bool InSetPropValue => this.InSetPropValueInternal;

    /// <summary>Gets or sets the <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. </summary>
    /// <returns>The <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    public object NullValue
    {
      get => this.NullValueInternal;
      set
      {
        if (object.Equals(this.NullValueInternal, value))
          return;
        this.NullValueInternal = value;
        if (!this.IsBinding || !Formatter.IsNullData(this.BindToObjectInternal.GetValue(), this.DataSourceNullValuePropertyInternal))
          return;
        this.PushData();
      }
    }

    /// <summary>Gets or sets the name of the control's data-bound property.</summary>
    /// <returns>The name of a control property to bind to.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    public string PropertyName => this.PropertyNameInternal;

    /// <summary>
    /// Provides design time attributes for the DataSource property
    /// </summary>
    [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    public interface IDataSourceAttributeProvider : IListSource
    {
    }
  }
}
