#region Using

using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Permissions;
using System.Collections;
using System.Reflection;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Forms.Serialization;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    [Flags]
    internal enum BindingState : int
    {
        /// <summary>
        /// The PropertyInfoInternal flag
        /// </summary>
        PropertyInfoInternal = 1,

        /// <summary>
        /// The PropropertyInfoConverterInternal flag
        /// </summary>
        PropropertyInfoConverterInternal = 2,

        /// <summary>
        /// The PropropertyIsNullInfoInternal flag
        /// </summary>
        PropropertyIsNullInfoInternal = 4,

        /// <summary>
        /// The ValidateInfoInternal flag
        /// </summary>
        ValidateInfoInternal = 8
    }

    /// <summary>Specifies the direction of the binding operation.</summary>
    /// <filterpriority>2</filterpriority>    
    public enum BindingCompleteContext
    {
        /// <summary>
        /// ControlUpdate
        /// </summary>
        ControlUpdate,
        /// <summary>
        /// DataSourceUpdate
        /// </summary>
        DataSourceUpdate
    }

    /// <summary>Indicates the result of a completed binding operation.</summary>
    /// <filterpriority>2</filterpriority>    
    public enum BindingCompleteState
    {
        /// <summary>
        /// Success
        /// </summary>
        Success,
        /// <summary>
        /// DataError
        /// </summary>
        DataError,
        /// <summary>
        /// Exception
        /// </summary>
        Exception
    }

    #endregion

    #region Classes

    #region Binding Class

    /// <summary>Represents the simple binding between the property value of an object and the property value of a control.</summary>
    /// <filterpriority>1</filterpriority>
    [TypeConverter(typeof(ListBindingConverter))]
    [Serializable()]
    public class Binding : SerializableObject
    {

        /// <summary>
        /// Provides design time attributes for the DataSource property
        /// </summary>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        public interface IDataSourceAttributeProvider : IListSource
        {

        }

        /// <summary>Occurs when a binding operation is complete, such as when data is pushed to the control property from the data source or vice versa</summary>
        public event BindingCompleteEventHandler BindingComplete
        {
            add
            {
                this.AddHandler(Binding.BindingCompleteEvent, value);
            }
            remove
            {
                this.RemoveHandler(Binding.BindingCompleteEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BindingComplete event.
        /// </summary>
        private BindingCompleteEventHandler BindingCompleteHandler
        {
            get
            {
                return (BindingCompleteEventHandler)this.GetHandler(Binding.BindingCompleteEvent);
            }
        }

        /// <summary>
        /// The BindingComplete event registration.
        /// </summary>
        private static readonly SerializableEvent BindingCompleteEvent = SerializableEvent.Register("BindingComplete", typeof(BindingCompleteEventHandler), typeof(Binding));


        /// <summary>Occurs when the property of a control is bound to a data value.</summary>
        /// <filterpriority>1</filterpriority>
        public event ConvertEventHandler Format
        {
            add
            {
                this.AddHandler(Binding.FormatEvent, value);
            }
            remove
            {
                this.RemoveHandler(Binding.FormatEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Format event.
        /// </summary>
        private ConvertEventHandler FormatHandler
        {
            get
            {
                return (ConvertEventHandler)this.GetHandler(Binding.FormatEvent);
            }
        }

        /// <summary>
        /// The Format event registration.
        /// </summary>
        private static readonly SerializableEvent FormatEvent = SerializableEvent.Register("Format", typeof(ConvertEventHandler), typeof(Binding));


        /// <summary>Occurs when the value of a data-bound control changes.</summary>
        /// <filterpriority>1</filterpriority>
        public event ConvertEventHandler Parse
        {
            add
            {
                this.AddHandler(Binding.ParseEvent, value);
            }
            remove
            {
                this.RemoveHandler(Binding.ParseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Parse event.
        /// </summary>
        private ConvertEventHandler ParseHandler
        {
            get
            {
                return (ConvertEventHandler)this.GetHandler(Binding.ParseEvent);
            }
        }

        /// <summary>
        /// The Parse event registration.
        /// </summary>
        private static readonly SerializableEvent ParseEvent = SerializableEvent.Register("Parse", typeof(ConvertEventHandler), typeof(Binding));

        private static readonly SerializableProperty BindingManagerBaseProperty = SerializableProperty.Register("BindingManagerBaseProperty", typeof(BindingManagerBase), typeof(Binding));

        private BindingManagerBase BindingManagerBaseInternal
        {
            get
            {
                return this.GetValue<BindingManagerBase>(Binding.BindingManagerBaseProperty);
            }
            set
            {
                this.SetValue<BindingManagerBase>(Binding.BindingManagerBaseProperty, value);
            }
        }

        private BindToObject BindToObjectInternal;

        private static readonly SerializableProperty BoundProperty = SerializableProperty.Register("Bound", typeof(bool), typeof(Binding), new SerializablePropertyMetadata(false));

        private bool BoundInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.BoundProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.BoundProperty, value);
            }
        }

        private static readonly SerializableProperty ControlProperty = SerializableProperty.Register("Control", typeof(IBindableComponent), typeof(Binding));

        private IBindableComponent ControlInternal
        {
            get
            {
                return this.GetValue<IBindableComponent>(Binding.ControlProperty);
            }
            set
            {
                this.SetValue<IBindableComponent>(Binding.ControlProperty, value);
            }
        }

        private static readonly SerializableProperty ControlUpdateModeProperty = SerializableProperty.Register("ControlUpdateMode", typeof(ControlUpdateMode), typeof(Binding));

        private ControlUpdateMode ControlUpdateModeInternal
        {
            get
            {
                return this.GetValue<ControlUpdateMode>(Binding.ControlUpdateModeProperty);
            }
            set
            {
                this.SetValue<ControlUpdateMode>(Binding.ControlUpdateModeProperty, value);
            }
        }

        private DataSourceUpdateMode DataSourceUpdateModeInternal;
        private object DataSourceNullValuePropertyInternal;

        private static readonly SerializableProperty DataSourceNullValueSetProperty = SerializableProperty.Register("DataSourceNullValueSet", typeof(bool), typeof(Binding), new SerializablePropertyMetadata(false));

        private bool DataSourceNullValueSetInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.DataSourceNullValueSetProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.DataSourceNullValueSetProperty, value);
            }
        }

        private IFormatProvider FormatInfoInternal;
        private string FormatStringInternal;
        private bool FormattingEnabledInternal;

        private static readonly SerializableProperty InOnBindingCompleteProperty = SerializableProperty.Register("inOnBindingComplete", typeof(bool), typeof(Binding));

        private bool InOnBindingCompleteInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.InOnBindingCompleteProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.InOnBindingCompleteProperty, value);
            }
        }

        private static readonly SerializableProperty InPushOrPullProperty = SerializableProperty.Register("inPushOrPull", typeof(bool), typeof(Binding));

        private bool InPushOrPullInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.InPushOrPullProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.InPushOrPullProperty, value);
            }
        }

        private static readonly SerializableProperty InSetPropValueProperty = SerializableProperty.Register("inSetPropValue", typeof(bool), typeof(Binding));

        private bool InSetPropValueInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.InSetPropValueProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.InSetPropValueProperty, value);
            }
        }

        private static readonly SerializableProperty ModifiedProperty = SerializableProperty.Register("modified", typeof(bool), typeof(Binding));

        private bool ModifiedInternal
        {
            get
            {
                return this.GetValue<bool>(Binding.ModifiedProperty);
            }
            set
            {
                this.SetValue<bool>(Binding.ModifiedProperty, value);
            }
        }

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
        private int mintControlState = 0;

        private Binding()
        {
            this.PropertyNameInternal = "";
            this.FormatStringInternal = string.Empty;
            this.DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue(null);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that simple-binds the indicated control property to the specified data member of the data source.</summary>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
        /// <param name="strDataMember">The property or list to bind to. </param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <exception cref="T:System.Exception">propertyName is neither a valid property of a control nor an empty string (""). </exception>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.</exception>
        public Binding(string strPropertyName, object objDataSource, string strDataMember)
            : this(strPropertyName, objDataSource, strDataMember, false, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation, null, string.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the indicated control property to the specified data member of the data source, and optionally enables formatting to be applied.</summary>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false. </param>
        /// <param name="strDataMember">The property or list to bind to. </param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <exception cref="T:System.Exception">Formatting is disabled and propertyName is neither a valid property of a control nor an empty string (""). </exception>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
        public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled)
            : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation, null, string.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the specified control property to the specified data member of the specified data source. Optionally enables formatting and propagates values to the data source based on the specified update setting.</summary>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="enmDataSourceUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The data source or data member or control property specified are associated with another binding in the collection.</exception>
        public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmDataSourceUpdateMode)
            : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, null, string.Empty, null)
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
        public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmDataSourceUpdateMode, object objNullValue)
            : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, objNullValue, string.Empty, null)
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
        public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmDataSourceUpdateMode, object objNullValue, string strFormatString)
            : this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmDataSourceUpdateMode, objNullValue, strFormatString, null)
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
        public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmDataSourceUpdateMode, object objNullValue, string strFormatString, IFormatProvider objFormatInfo)
        {
            this.PropertyNameInternal = "";
            this.FormatStringInternal = string.Empty;
            this.DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue(null);
            this.BindToObjectInternal = new Gizmox.WebGUI.Forms.BindToObject(this, objDataSource, strDataMember);
            this.PropertyNameInternal = strPropertyName;
            this.FormattingEnabledInternal = blnFormattingEnabled;
            this.FormatStringInternal = strFormatString;
            this.NullValueInternal = objNullValue;
            this.FormatInfoInternal = objFormatInfo;
            this.FormattingEnabledInternal = blnFormattingEnabled;
            this.DataSourceUpdateModeInternal = enmDataSourceUpdateMode;
            this.CheckBinding();
        }

        private void binding_MetaDataChanged(object sender, EventArgs e)
        {
            this.CheckBinding();
        }

        private void BindTarget(bool bind)
        {
            EnsurePropertyInfoInternal();

            if (bind)
            {
                if (this.IsBinding)
                {
                    if ((this.PropertyInfoInternal != null) && (this.ControlInternal != null))
                    {
                        EventHandler objEventHandler1 = new EventHandler(this.Target_PropertyChanged);
                        this.PropertyInfoInternal.AddValueChanged(this.ControlInternal, objEventHandler1);
                    }

                    EnsureValidateInfoInternal();

                    if (this.ValidateInfoInternal != null)
                    {
                        CancelEventHandler objEventHandler2 = new CancelEventHandler(this.Target_Validate);
                        this.ValidateInfoInternal.AddEventHandler(this.ControlInternal, objEventHandler2);
                    }
                }
            }
            else
            {
                if ((this.PropertyInfoInternal != null) && (this.ControlInternal != null))
                {
                    EventHandler objEventHandler3 = new EventHandler(this.Target_PropertyChanged);
                    this.PropertyInfoInternal.RemoveValueChanged(this.ControlInternal, objEventHandler3);
                }

                EnsureValidateInfoInternal();

                if (this.ValidateInfoInternal != null)
                {
                    CancelEventHandler objEventHandler4 = new CancelEventHandler(this.Target_Validate);
                    this.ValidateInfoInternal.RemoveEventHandler(this.ControlInternal, objEventHandler4);
                }
            }
        }

        private void CheckBinding()
        {
            this.BindToObjectInternal.CheckBinding();
            if ((this.ControlInternal == null) || (this.PropertyNameInternal.Length <= 0))
            {
                this.PropertyInfoInternal = null;
                this.ValidateInfoInternal = null;
            }
            else
            {

                PropertyDescriptor objPropertyDescriptor2 = InitPropInfoConverter();

                if (((objPropertyDescriptor2 != null) && (objPropertyDescriptor2.PropertyType == typeof(bool))) && !objPropertyDescriptor2.IsReadOnly)
                {
                    this.PropropertyIsNullInfoInternal = objPropertyDescriptor2;
                    this.SetState(BindingState.PropropertyIsNullInfoInternal, this.PropropertyIsNullInfoInternal != null);
                }
                EventDescriptor descriptor3 = null;
                string strText2 = "Validating";
                EventDescriptorCollection objCollection2 = TypeDescriptor.GetEvents(this.ControlInternal);
                for (int num2 = 0; num2 < objCollection2.Count; num2++)
                {

                    if ((descriptor3 == null) && ClientUtils.IsEquals(objCollection2[num2].Name, strText2, StringComparison.OrdinalIgnoreCase))
                    {
                        descriptor3 = objCollection2[num2];
                        break;
                    }
                }
                this.ValidateInfoInternal = descriptor3;
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
            PropertyDescriptorCollection objCollection1;
            this.ControlInternal.DataBindings.CheckDuplicates(this);
            Type objType1 = this.ControlInternal.GetType();
            string strText1 = this.PropertyNameInternal + "IsNull";
            PropertyDescriptor objPropertyDescriptor1 = null;
            PropertyDescriptor objPropertyDescriptor2 = null;
            InheritanceAttribute attribute1 = (InheritanceAttribute)TypeDescriptor.GetAttributes(this.ControlInternal)[typeof(InheritanceAttribute)];

            if ((attribute1 != null) && (attribute1.InheritanceLevel != InheritanceLevel.NotInherited))
            {
                objCollection1 = TypeDescriptor.GetProperties(objType1);
            }
            else
            {
                objCollection1 = TypeDescriptor.GetProperties(this.ControlInternal);
            }
            for (int num1 = 0; num1 < objCollection1.Count; num1++)
            {
                if ((objPropertyDescriptor1 == null) && ClientUtils.IsEquals(objCollection1[num1].Name, this.PropertyNameInternal, StringComparison.OrdinalIgnoreCase))
                {
                    objPropertyDescriptor1 = objCollection1[num1];
                    if (objPropertyDescriptor2 != null)
                    {
                        break;
                    }
                }
                if ((objPropertyDescriptor2 == null) && ClientUtils.IsEquals(objCollection1[num1].Name, strText1, StringComparison.OrdinalIgnoreCase))
                {
                    objPropertyDescriptor2 = objCollection1[num1];
                    if (objPropertyDescriptor1 != null)
                    {
                        break;
                    }
                }
            }
            if (objPropertyDescriptor1 == null)
            {
                throw new ArgumentException(SR.GetString("ListBindingBindProperty", new object[] { this.PropertyNameInternal }), "PropertyName");
            }
            if (objPropertyDescriptor1.IsReadOnly && (this.ControlUpdateModeInternal != ControlUpdateMode.Never))
            {
                throw new ArgumentException(SR.GetString("ListBindingBindPropertyReadOnly", new object[] { this.PropertyNameInternal }), "PropertyName");
            }
            this.PropertyInfoInternal = objPropertyDescriptor1;
            this.SetState(BindingState.PropertyInfoInternal, this.PropertyInfoInternal != null);

            Type objType2 = this.PropertyInfoInternal.PropertyType;
            this.PropropertyInfoConverterInternal = this.PropertyInfoInternal.Converter;
            this.SetState(BindingState.PropropertyInfoConverterInternal, this.PropropertyInfoConverterInternal != null);

            return objPropertyDescriptor2;
        }

        internal bool ControlAtDesignTime()
        {
            IComponent component1 = this.ControlInternal;
            if (component1 == null)
            {
                return false;
            }
            ISite objSite = component1.Site;
            if (objSite == null)
            {
                return false;
            }
            return objSite.DesignMode;
        }

        private BindingCompleteEventArgs CreateBindingCompleteEventArgs(BindingCompleteContext enmContext, Exception objException)
        {
            bool blnFlag1 = false;
            string strText1 = string.Empty;
            BindingCompleteState enmBindingCompleteState = BindingCompleteState.Success;
            if (objException != null)
            {
                strText1 = objException.Message;
                enmBindingCompleteState = BindingCompleteState.Exception;
                blnFlag1 = true;
            }
            else
            {
                strText1 = this.BindToObject.DataErrorText;
                if (!CommonUtils.IsNullOrEmpty(strText1))
                {
                    enmBindingCompleteState = BindingCompleteState.DataError;
                }
            }
            return new BindingCompleteEventArgs(this, enmBindingCompleteState, enmContext, strText1, objException, blnFlag1);
        }

        private object FormatObject(object objValue)
        {
            if (!this.ControlAtDesignTime())
            {
                EnsurePropertyInfoInternal();

                Type objType1 = this.PropertyInfoInternal.PropertyType;
                if (this.FormattingEnabledInternal)
                {
                    ConvertEventArgs args1 = new ConvertEventArgs(objValue, objType1);
                    this.OnFormat(args1);
                    if (args1.Value != objValue)
                    {
                        return args1.Value;
                    }
                    TypeConverter objConverter1 = null;
                    if (this.BindToObjectInternal.FieldInfo != null)
                    {
                        objConverter1 = this.BindToObjectInternal.FieldInfo.Converter;
                    }
                    return Formatter.FormatObject(objValue, objType1, objConverter1, PropInfoConverter, this.FormatStringInternal, this.FormatInfoInternal, this.NullValueInternal, this.DataSourceNullValuePropertyInternal);
                }
                ConvertEventArgs args2 = new ConvertEventArgs(objValue, objType1);
                this.OnFormat(args2);
                object obj1 = args2.Value;
                if (objType1 != typeof(object))
                {
                    if ((obj1 == null) || (!obj1.GetType().IsSubclassOf(objType1) && (obj1.GetType() != objType1)))
                    {
                        TypeConverter objConverter2 = TypeDescriptor.GetConverter((objValue != null) ? objValue.GetType() : typeof(object));
                        if ((objConverter2 == null) || !objConverter2.CanConvertTo(objType1))
                        {
                            if (objValue is IConvertible)
                            {
                                obj1 = Convert.ChangeType(objValue, objType1, CultureInfo.CurrentCulture);
                                if ((obj1 != null) && (obj1.GetType().IsSubclassOf(objType1) || (obj1.GetType() == objType1)))
                                {
                                    return obj1;
                                }
                            }
                            throw new FormatException(SR.GetString("ListBindingFormatFailed"));
                        }
                        return objConverter2.ConvertTo(objValue, objType1);
                    }
                    return obj1;
                }
                return objValue;
            }
            return objValue;
        }

        private TypeConverter PropInfoConverter
        {

            get
            {
                EnsurePropropertyInfoConverterInternal();

                if (this.PropropertyInfoConverterInternal == null)
                {
                    // Ensure property infor converter.
                    EnsurePropInfoConverter();
                }

                return this.PropropertyInfoConverterInternal;
            }
        }


        private void FormLoaded(object sender, EventArgs e)
        {
            this.CheckBinding();
        }

        private object GetDataSourceNullValue(Type objType)
        {
            if (!this.DataSourceNullValueSetInternal)
            {
                return Formatter.GetDefaultDataSourceNullValue(objType);
            }
            return this.DataSourceNullValuePropertyInternal;
        }

        private object GetPropValue()
        {
            bool blnFlag1 = false;

            EnsurePropropertyIsNullInfoInternal();

            if (this.PropropertyIsNullInfoInternal != null)
            {
                blnFlag1 = (bool)this.PropropertyIsNullInfoInternal.GetValue(this.ControlInternal);
            }
            if (blnFlag1)
            {
                return this.DataSourceNullValue;
            }

            EnsurePropertyInfoInternal();

            object obj1 = this.PropertyInfoInternal.GetValue(this.ControlInternal);
            if (obj1 == null)
            {
                obj1 = this.DataSourceNullValue;
            }
            return obj1;
        }

        internal static bool IsComponentCreated(IBindableComponent component)
        {
            Control objControl1 = component as Control;
            if (objControl1 != null)
            {
                //TODO:BINDING
                return true;//control1.Created;
            }
            return true;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
        protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
        {
            if (!this.InOnBindingCompleteInternal)
            {
                try
                {
                    this.InOnBindingCompleteInternal = true;
                    if (this.BindingCompleteHandler != null)
                    {
                        this.BindingCompleteHandler(this, e);
                    }
                }
                catch (Exception objException1)
                {
                    if (Gizmox.WebGUI.Forms.ClientUtils.IsSecurityOrCriticalException(objException1))
                    {
                        throw;
                    }
                    e.Cancel = true;
                    return;
                }
                finally
                {
                    this.InOnBindingCompleteInternal = false;
                }
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> event.</summary>
        /// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
        protected virtual void OnFormat(ConvertEventArgs objCevent)
        {

            // Raise event if needed
            ConvertEventHandler objEventHandler = this.FormatHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objCevent);
            }

            object objValue = objCevent.Value;
            Type objType = objCevent.DesiredType;

            if (((!this.FormattingEnabledInternal && !(objValue is DBNull)) && ((objType != null) && !objType.IsInstanceOfType(objValue))) && (objValue is IConvertible))
            {
                objCevent.Value = Convert.ChangeType(objValue, objType, CultureInfo.CurrentCulture);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> event.</summary>
        /// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
        protected virtual void OnParse(ConvertEventArgs objCevent)
        {

            // Raise event if needed
            ConvertEventHandler objEventHandler = this.ParseHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objCevent);
            }

            object objValue = objCevent.Value;
            Type objType = objCevent.DesiredType;

            if (((!this.FormattingEnabledInternal && !(objValue is DBNull)) && ((objValue != null) && (objType != null))) && (!objType.IsInstanceOfType(objValue) && (objValue is IConvertible)))
            {
                objCevent.Value = Convert.ChangeType(objValue, objType, CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Ensures the property info internal.
        /// </summary>
        private void EnsurePropertyInfoInternal()
        {
            if (this.GetState(BindingState.PropertyInfoInternal) && PropertyInfoInternal == null)
            {
                // Ensure property infor converter.
                EnsurePropInfoConverter();
            }
        }

        /// <summary>
        /// Ensures the prop info converter.
        /// </summary>
        private void EnsurePropInfoConverter()
        {
            if ((this.ControlInternal != null) && (this.PropertyNameInternal.Length > 0))
            {
                InitPropInfoConverter();
            }
        }

        /// <summary>
        /// Ensures the proproperty info converter internal.
        /// </summary>
        private void EnsurePropropertyInfoConverterInternal()
        {
            if (this.GetState(BindingState.PropropertyInfoConverterInternal) && PropropertyInfoConverterInternal == null)
            {
                // Ensure property infor converter.
                EnsurePropInfoConverter();
            }
        }

        /// <summary>
        /// Ensures the proproperty is null info internal.
        /// </summary>
        private void EnsurePropropertyIsNullInfoInternal()
        {
            if (this.GetState(BindingState.PropropertyIsNullInfoInternal) && PropropertyIsNullInfoInternal == null)
            {
                CheckBinding();
            }
        }

        /// <summary>
        /// Ensures the validate info internal.
        /// </summary>
        private void EnsureValidateInfoInternal()
        {
            if (this.GetState(BindingState.ValidateInfoInternal) && ValidateInfoInternal == null)
            {
                CheckBinding();
            }
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="enmState">State of the enm.</param>
        /// <param name="blnValue">The flag value to set.</param>
        internal void SetState(BindingState enmState, bool blnValue)
        {
            this.mintControlState = blnValue ? (this.mintControlState | ((int)enmState)) : (this.mintControlState & ~((int)enmState));
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="enmState">State of the enm.</param>
        /// <returns></returns>
        internal bool GetState(BindingState enmState)
        {
            return ((this.mintControlState & ((int)enmState)) != 0);
        }

        private object ParseObject(object objValue)
        {
            Type objType1 = this.BindToObjectInternal.BindToType;
            if (this.FormattingEnabledInternal)
            {
                ConvertEventArgs args1 = new ConvertEventArgs(objValue, objType1);
                this.OnParse(args1);
                object obj1 = args1.Value;
                if (!object.Equals(objValue, obj1))
                {
                    return obj1;
                }
                TypeConverter objConverter1 = null;
                if (this.BindToObjectInternal.FieldInfo != null)
                {
                    objConverter1 = this.BindToObjectInternal.FieldInfo.Converter;
                }

                EnsurePropertyInfoInternal();

                return Formatter.ParseObject(objValue, objType1, (objValue == null) ? this.PropertyInfoInternal.PropertyType : objValue.GetType(), objConverter1, PropInfoConverter, this.FormatInfoInternal, this.NullValueInternal, this.GetDataSourceNullValue(objType1));
            }
            ConvertEventArgs args2 = new ConvertEventArgs(objValue, objType1);
            this.OnParse(args2);
            if ((args2.Value != null) && ((args2.Value.GetType().IsSubclassOf(objType1) || (args2.Value.GetType() == objType1)) || (args2.Value is DBNull)))
            {
                return args2.Value;
            }
            TypeConverter objConverter2 = TypeDescriptor.GetConverter((objValue != null) ? objValue.GetType() : typeof(object));
            if ((objConverter2 != null) && objConverter2.CanConvertTo(objType1))
            {
                return objConverter2.ConvertTo(objValue, objType1);
            }
            if (objValue is IConvertible)
            {
                object obj2 = Convert.ChangeType(objValue, objType1, CultureInfo.CurrentCulture);
                if ((obj2 != null) && (obj2.GetType().IsSubclassOf(objType1) || (obj2.GetType() == objType1)))
                {
                    return obj2;
                }
            }
            return null;
        }

        internal bool PullData()
        {
            return this.PullData(true, false);
        }

        internal bool PullData(bool blnReformat)
        {
            return this.PullData(blnReformat, false);
        }

        internal bool PullData(bool blnReformat, bool blnForce)
        {
            if (this.ControlUpdateMode == ControlUpdateMode.Never)
            {
                blnReformat = false;
            }
            bool blnFlag1 = false;
            object obj1 = null;
            Exception objException1 = null;
            if (this.IsBinding)
            {
                if (!blnForce)
                {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46) && !WG_MONO
                    if (!CommonUtils.IsMono)
                    {
                        EnsurePropertyInfoInternal();

                        if (this.PropertyInfoInternal.SupportsChangeEvents && !this.ModifiedInternal)
                        {
                            return false;
                        }
                    }
#else
                    if (false && !this.modified)
                    {
                        return false;
                    }
#endif
                    if (this.DataSourceUpdateMode == Gizmox.WebGUI.Forms.DataSourceUpdateMode.Never)
                    {
                        return false;
                    }
                }
                if (this.InPushOrPullInternal && this.FormattingEnabledInternal)
                {
                    return false;
                }
                this.InPushOrPullInternal = true;
                object obj2 = this.GetPropValue();
                try
                {
                    obj1 = this.ParseObject(obj2);
                }
                catch (Exception objException2)
                {
                    objException1 = objException2;
                }
                try
                {
                    if ((objException1 != null) || (!this.FormattingEnabled && (obj1 == null)))
                    {
                        blnFlag1 = true;
                        obj1 = this.BindToObjectInternal.GetValue();
                    }
                    if (blnReformat && (!this.FormattingEnabled || !blnFlag1))
                    {
                        object obj3 = this.FormatObject(obj1);
                        if ((blnForce || !this.FormattingEnabled) || !object.Equals(obj3, obj2))
                        {
                            this.SetPropValue(obj3);
                        }
                    }
                    if (!blnFlag1)
                    {
                        this.BindToObjectInternal.SetValue(obj1);
                    }
                }
                catch (Exception objException3)
                {
                    objException1 = objException3;
                    if (!this.FormattingEnabled)
                    {
                        throw;
                    }
                }
                finally
                {
                    this.InPushOrPullInternal = false;
                }
                if (this.FormattingEnabled)
                {
                    BindingCompleteEventArgs args1 = this.CreateBindingCompleteEventArgs(BindingCompleteContext.DataSourceUpdate, objException1);
                    this.OnBindingComplete(args1);
                    if ((args1.BindingCompleteState == BindingCompleteState.Success) && !args1.Cancel)
                    {
                        this.ModifiedInternal = false;
                    }
                    return args1.Cancel;
                }
                this.ModifiedInternal = false;
            }
            return false;
        }

        internal bool PushData()
        {
            return this.PushData(false);
        }

        internal bool PushData(bool blnForce)
        {
            object obj1 = null;
            Exception objException1 = null;
            if (blnForce || (this.ControlUpdateMode != ControlUpdateMode.Never))
            {
                if (this.InPushOrPullInternal && this.FormattingEnabledInternal)
                {
                    return false;
                }
                this.InPushOrPullInternal = true;
                try
                {
                    if (this.IsBinding)
                    {
                        obj1 = this.BindToObjectInternal.GetValue();
                        object obj2 = this.FormatObject(obj1);
                        this.SetPropValue(obj2);
                        this.ModifiedInternal = false;
                    }
                    else
                    {
                        this.SetPropValue(null);
                    }
                }
                catch (Exception objException2)
                {
                    objException1 = objException2;
                    if (!this.FormattingEnabled)
                    {
                        throw;
                    }
                }
                finally
                {
                    this.InPushOrPullInternal = false;
                }
                if (this.FormattingEnabled)
                {
                    BindingCompleteEventArgs args1 = this.CreateBindingCompleteEventArgs(BindingCompleteContext.ControlUpdate, objException1);
                    this.OnBindingComplete(args1);
                    return args1.Cancel;
                }
            }
            return false;
        }

        /// <summary>Sets the control property to the value read from the data source.</summary>
        public void ReadValue()
        {
            this.PushData(true);
        }

        internal void SetBindableComponent(IBindableComponent value)
        {
            if (this.ControlInternal != value)
            {
                IBindableComponent component1 = this.ControlInternal;
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
                    this.ControlInternal = component1;
                    this.BindTarget(true);
                    throw;
                }
                BindingContext.UpdateBinding(((this.ControlInternal != null) && Binding.IsComponentCreated(this.ControlInternal)) ? this.ControlInternal.BindingContext : null, this);
                Form objForm = value as Form;
                if (objForm != null)
                {
                    objForm.Load += new EventHandler(this.FormLoaded);
                }
            }
        }

        internal void SetListManager(BindingManagerBase objBindingManagerBase)
        {
            if (this.BindingManagerBase is CurrencyManager)
            {
                ((CurrencyManager)this.BindingManagerBase).MetaDataChanged -= new EventHandler(this.binding_MetaDataChanged);
            }
            this.BindingManagerBaseInternal = objBindingManagerBase;
            if (this.BindingManagerBase is CurrencyManager)
            {
                ((CurrencyManager)this.BindingManagerBase).MetaDataChanged += new EventHandler(this.binding_MetaDataChanged);
            }
            this.BindToObject.SetBindingManagerBase(objBindingManagerBase);
            this.CheckBinding();
        }

        private void SetPropValue(object objValue)
        {
            if (!this.ControlAtDesignTime())
            {
                this.InSetPropValueInternal = true;
                try
                {
                    EnsurePropertyInfoInternal();

                    if ((objValue == null) || Formatter.IsNullData(objValue, this.DataSourceNullValue))
                    {
                        EnsurePropropertyIsNullInfoInternal();

                        if (this.PropropertyIsNullInfoInternal != null)
                        {
                            this.PropropertyIsNullInfoInternal.SetValue(this.ControlInternal, true);
                        }
                        else if (this.PropertyInfoInternal.PropertyType == typeof(object))
                        {
                            this.PropertyInfoInternal.SetValue(this.ControlInternal, this.DataSourceNullValue);
                        }
                        else
                        {
                            this.PropertyInfoInternal.SetValue(this.ControlInternal, null);
                        }
                    }
                    else
                    {
                        this.PropertyInfoInternal.SetValue(this.ControlInternal, objValue);
                    }
                }
                finally
                {
                    this.InSetPropValueInternal = false;
                }
            }
        }

        private bool ShouldSerializeDataSourceNullValue()
        {
            if (this.DataSourceNullValueSetInternal)
            {
                return (this.DataSourceNullValuePropertyInternal != Formatter.GetDefaultDataSourceNullValue(null));
            }
            return false;
        }

        private bool ShouldSerializeFormatString()
        {
            if (this.FormatStringInternal != null)
            {
                return (this.FormatStringInternal.Length > 0);
            }
            return false;
        }

        private bool ShouldSerializeNullValue()
        {
            return (this.NullValueInternal != null);
        }

        private void Target_PropertyChanged(object sender, EventArgs e)
        {
            if (!this.InSetPropValueInternal && this.IsBinding)
            {
                this.ModifiedInternal = true;
                if (this.DataSourceUpdateMode == Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnPropertyChanged)
                {
                    this.PullData(false);
                    this.ModifiedInternal = true;
                }
            }
        }

        private void Target_Validate(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.PullData(true))
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        internal void UpdateIsBinding()
        {
            bool blnFlag1 = (this.IsBindable && this.ComponentCreated) && this.BindingManagerBase.IsBinding;
            if (this.BoundInternal != blnFlag1)
            {
                this.BoundInternal = blnFlag1;
                this.BindTarget(blnFlag1);
                if (this.BoundInternal)
                {
                    if (this.ControlUpdateModeInternal == ControlUpdateMode.Never)
                    {
                        this.PullData(false, true);
                    }
                    else
                    {
                        this.PushData();
                    }
                }
            }
        }

        /// <summary>Reads the current value from the control property and writes it to the data source.</summary>
        public void WriteValue()
        {
            this.PullData(true, true);
        }


        /// <summary>Gets the control the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        [DefaultValue((string)null)]
        public IBindableComponent BindableComponent
        {
            get
            {
                return this.ControlInternal;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.
        /// </summary>
        /// <value>The binding manager base.</value>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that manages this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        public BindingManagerBase BindingManagerBase
        {
            get
            {
                return this.BindingManagerBaseInternal;
            }
        }

        /// <summary>
        /// Gets an object that contains information about this binding based on the dataMember parameter in the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> constructor.
        /// </summary>
        /// <value>The binding member info.</value>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> that contains information about this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        public BindingMemberInfo BindingMemberInfo
        {
            get
            {
                return this.BindToObjectInternal.BindingMemberInfo;
            }
        }

        internal BindToObject BindToObject
        {
            get
            {
                return this.BindToObjectInternal;
            }
        }

        internal bool ComponentCreated
        {
            get
            {
                return Binding.IsComponentCreated(this.ControlInternal);
            }
        }

        /// <summary>Gets the control that the binding belongs to.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the binding belongs to.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        [DefaultValue((string)null)]
        public Control Control
        {
            get
            {
                return (this.ControlInternal as Control);
            }
        }

        /// <summary>Gets or sets when changes to the data source are propagated to the bound control property.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ControlUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnPropertyChanged"></see>.</returns>
        [DefaultValue(0)]
        public ControlUpdateMode ControlUpdateMode
        {
            get
            {
                return this.ControlUpdateModeInternal;
            }
            set
            {
                if (this.ControlUpdateModeInternal != value)
                {
                    this.ControlUpdateModeInternal = value;
                    if (this.IsBinding)
                    {
                        this.PushData();
                    }
                }
            }
        }

        /// <summary>Gets the data source for this binding.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the data source.</returns>
        /// <filterpriority>1</filterpriority>
        public object DataSource
        {
            get
            {
                return this.BindToObjectInternal.DataSource;
            }
        }

        /// <summary>Gets or sets the value to be stored in the data source if the control value is null or empty.</summary>
        /// <returns>The <see cref="T:System.Object"></see> to be stored in the data source when the control property is empty or null. The default is <see cref="T:System.DBNull"></see> for value types and null for non-value types.</returns>
        public object DataSourceNullValue
        {
            get
            {
                return this.DataSourceNullValuePropertyInternal;
            }
            set
            {
                if (!object.Equals(this.DataSourceNullValuePropertyInternal, value))
                {
                    object obj1 = this.DataSourceNullValuePropertyInternal;
                    this.DataSourceNullValuePropertyInternal = value;
                    this.DataSourceNullValueSetInternal = true;
                    if (this.IsBinding)
                    {
                        object obj2 = this.BindToObjectInternal.GetValue();
                        if (Formatter.IsNullData(obj2, obj1))
                        {
                            this.WriteValue();
                        }
                        if (Formatter.IsNullData(obj2, value))
                        {
                            this.ReadValue();
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets when changes to the bound control property are propagated to the data source.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnValidation"></see>.</returns>
        [DefaultValue(Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnPropertyChanged)]
        public DataSourceUpdateMode DataSourceUpdateMode
        {
            get
            {
                return this.DataSourceUpdateModeInternal;
            }
            set
            {
                if (this.DataSourceUpdateModeInternal != value)
                {
                    this.DataSourceUpdateModeInternal = value;
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior.</summary>
        /// <returns>The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null)]
        public IFormatProvider FormatInfo
        {
            get
            {
                return this.FormatInfoInternal;
            }
            set
            {
                if (this.FormatInfoInternal != value)
                {
                    this.FormatInfoInternal = value;
                    if (this.IsBinding)
                    {
                        this.PushData();
                    }
                }
            }
        }

        /// <summary>Gets or sets the format specifier characters that indicate how a value is to be displayed.</summary>
        /// <returns>The string of format specifier characters that indicate how a value is to be displayed.</returns>
        /// <filterpriority>1</filterpriority>
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
                    if (this.IsBinding)
                    {
                        this.PushData();
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether formatting is applied to the control property data.</summary>
        /// <returns>true if formatting of control property data is enabled; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public bool FormattingEnabled
        {
            get
            {
                return this.FormattingEnabledInternal;
            }
            set
            {
                if (this.FormattingEnabledInternal != value)
                {
                    this.FormattingEnabledInternal = value;
                    if (this.IsBinding)
                    {
                        this.PushData();
                    }
                }
            }
        }

        internal bool IsBindable
        {
            get
            {
                if (((this.ControlInternal != null) && (this.PropertyNameInternal.Length > 0)) && (this.BindToObjectInternal.DataSource != null))
                {
                    return (this.BindingManagerBase != null);
                }
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the binding is active.</summary>
        /// <returns>true if the binding is active; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool IsBinding
        {
            get
            {
                return this.BoundInternal;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [in set prop value].
        /// </summary>
        /// <value><c>true</c> if [in set prop value]; otherwise, <c>false</c>.</value>
        internal bool InSetPropValue
        {
            get
            {
                return this.InSetPropValueInternal;
            }
        }

        /// <summary>Gets or sets the <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. </summary>
        /// <returns>The <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        public object NullValue
        {
            get
            {
                return this.NullValueInternal;
            }
            set
            {
                if (!object.Equals(this.NullValueInternal, value))
                {
                    this.NullValueInternal = value;
                    if (this.IsBinding && Formatter.IsNullData(this.BindToObjectInternal.GetValue(), this.DataSourceNullValuePropertyInternal))
                    {
                        this.PushData();
                    }
                }
            }
        }

        /// <summary>Gets or sets the name of the control's data-bound property.</summary>
        /// <returns>The name of a control property to bind to.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue("")]
        public string PropertyName
        {
            get
            {
                return this.PropertyNameInternal;
            }
        }

    }
    #endregion

    #region BindingContext Class

    /// <summary>Manages the collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for any object that inherits from the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class.</summary>
    /// <filterpriority>2</filterpriority>
    [DefaultEvent("CollectionChanged")]
    [Serializable()]
    public class BindingContext : ICollection, IEnumerable
    {
        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private Hashtable listManagers;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> class.</summary>
        public BindingContext()
        {
            this.listManagers = new Hashtable();
        }

        /// <summary>Occurs when the collection has changed.</summary>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), SRDescription("collectionChangedEventDescr"), Browsable(false)]
        public event CollectionChangeEventHandler CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }
            remove
            {
            }
        }



        /// <summary>Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
        /// <param name="objDataSource">The <see cref="T:System.Object"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add. </param>
        protected internal void Add(object objDataSource, BindingManagerBase objListManager)
        {
            this.AddCore(objDataSource, objListManager);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataSource));
        }

        /// <summary>Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
        /// <param name="objDataSource">The object associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add.</param>
        /// <exception cref="T:System.ArgumentNullException">dataSource is null.-or-listManager is null.</exception>
        protected virtual void AddCore(object objDataSource, BindingManagerBase objListManager)
        {
            if (objDataSource == null)
            {
                throw new ArgumentNullException("dataSource");
            }
            if (objListManager == null)
            {
                throw new ArgumentNullException("listManager");
            }
            this.listManagers[this.GetKey(objDataSource, "")] = new WeakReference(objListManager, false);
        }

        private static void CheckPropertyBindingCycles(BindingContext newBindingContext, Binding propBinding)
        {
            if (((newBindingContext != null) && (propBinding != null)) && newBindingContext.Contains(propBinding.BindableComponent, ""))
            {
                BindingManagerBase objBindingManagerBase = newBindingContext.EnsureListManager(propBinding.BindableComponent, "");
                for (int num1 = 0; num1 < objBindingManagerBase.Bindings.Count; num1++)
                {
                    Binding objBinding = objBindingManagerBase.Bindings[num1];
                    if (objBinding.DataSource == propBinding.BindableComponent)
                    {
                        if (propBinding.BindToObject.BindingMemberInfo.BindingMember.Equals(objBinding.PropertyName))
                        {
                            throw new ArgumentException(SR.GetString("DataBindingCycle", new object[] { objBinding.PropertyName }), "propBinding");
                        }
                    }
                    else if (propBinding.BindToObject.BindingManagerBase is PropertyManager)
                    {
                        BindingContext.CheckPropertyBindingCycles(newBindingContext, objBinding);
                    }
                }
            }
        }

        /// <summary>Clears the collection of any <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects.</summary>
        protected internal void Clear()
        {
            this.ClearCore();
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>Clears the collection.</summary>
        protected virtual void ClearCore()
        {
            this.listManagers.Clear();
        }

        /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(object objDataSource)
        {
            return this.Contains(objDataSource, "");
        }

        /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source and data member.</summary>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
        /// <param name="strDataMember">The information needed to resolve to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(object objDataSource, string strDataMember)
        {
            return this.listManagers.ContainsKey(this.GetKey(objDataSource, strDataMember));
        }

        internal BindingManagerBase EnsureListManager(object objDataSource, string strDataMember)
        {
            BindingManagerBase objBindingManagerBase1 = null;
            if (strDataMember == null)
            {
                strDataMember = "";
            }
            if (objDataSource is ICurrencyManagerProvider)
            {
                objBindingManagerBase1 = (objDataSource as ICurrencyManagerProvider).GetRelatedCurrencyManager(strDataMember);
                if (objBindingManagerBase1 != null)
                {
                    return objBindingManagerBase1;
                }
            }
            HashKey key1 = this.GetKey(objDataSource, strDataMember);
            if (this.listManagers == null)
            {
                this.listManagers = new Hashtable();
            }
            WeakReference reference1 = this.listManagers[key1] as WeakReference;
            if (reference1 != null)
            {
                objBindingManagerBase1 = (BindingManagerBase)reference1.Target;
            }
            if (objBindingManagerBase1 == null)
            {
                if (strDataMember.Length == 0)
                {
                    if ((objDataSource is IList) || (objDataSource is IListSource))
                    {
                        objBindingManagerBase1 = new CurrencyManager(objDataSource);
                    }
                    else
                    {
                        objBindingManagerBase1 = new PropertyManager(objDataSource);
                    }
                }
                else
                {
                    int num1 = strDataMember.LastIndexOf(".");
                    string strText1 = (num1 == -1) ? "" : strDataMember.Substring(0, num1);
                    string strText2 = strDataMember.Substring(num1 + 1);
                    BindingManagerBase objBindingManagerBase2 = this.EnsureListManager(objDataSource, strText1);
                    PropertyDescriptor objPropertyDescriptor1 = objBindingManagerBase2.GetItemProperties().Find(strText2, true);
                    if (objPropertyDescriptor1 == null)
                    {
                        throw new ArgumentException(SR.GetString("RelatedListManagerChild", new object[] { strText2 }));
                    }
                    if (typeof(IList).IsAssignableFrom(objPropertyDescriptor1.PropertyType))
                    {
                        objBindingManagerBase1 = new RelatedCurrencyManager(objBindingManagerBase2, strText2);
                    }
                    else
                    {
                        objBindingManagerBase1 = new RelatedPropertyManager(objBindingManagerBase2, strText2);
                    }
                }
                if (reference1 == null)
                {
                    this.listManagers.Add(key1, new WeakReference(objBindingManagerBase1, false));
                    return objBindingManagerBase1;
                }
                reference1.Target = objBindingManagerBase1;
            }
            return objBindingManagerBase1;
        }

        internal HashKey GetKey(object objDataSource, string strDataMember)
        {
            return new HashKey(objDataSource, strDataMember);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingContext.CollectionChanged"></see> event.</summary>
        /// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
        {
        }

        /// <summary>Deletes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
        /// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove. </param>
        protected internal void Remove(object objDataSource)
        {
            this.RemoveCore(objDataSource);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objDataSource));
        }

        /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
        /// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove.</param>
        protected virtual void RemoveCore(object objDataSource)
        {
            this.listManagers.Remove(this.GetKey(objDataSource, ""));
        }

        private void ScrubWeakRefs()
        {
            object[] arrObjects1 = new object[this.listManagers.Count];
            this.listManagers.CopyTo(arrObjects1, 0);
            for (int num1 = 0; num1 < arrObjects1.Length; num1++)
            {
                DictionaryEntry entry1 = (DictionaryEntry)arrObjects1[num1];
                WeakReference reference1 = (WeakReference)entry1.Value;
                if (reference1.Target == null)
                {
                    this.listManagers.Remove(entry1.Key);
                }
            }
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            //TODO:BINDING
            //Gizmox.WebGUI.Forms.IntSecurity.UnmanagedCode.Demand();
            this.ScrubWeakRefs();
            this.listManagers.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //TODO:BINDING
            //Gizmox.WebGUI.Forms.IntSecurity.UnmanagedCode.Demand();
            this.ScrubWeakRefs();
            return this.listManagers.GetEnumerator();
        }

        /// <summary>Associates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> with a new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</summary>
        /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to associate with the new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</param>
        /// <param name="objNewBindingContext">The new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> to associate with the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public static void UpdateBinding(BindingContext objNewBindingContext, Binding objBinding)
        {
            BindingManagerBase objBase1 = objBinding.BindingManagerBase;
            if (objBase1 != null)
            {
                objBase1.Bindings.Remove(objBinding);
            }
            if (objNewBindingContext != null)
            {
                if (objBinding.BindToObject.BindingManagerBase is PropertyManager)
                {
                    BindingContext.CheckPropertyBindingCycles(objNewBindingContext, objBinding);
                }
                BindToObject obj1 = objBinding.BindToObject;
                BindingManagerBase objBase2 = objNewBindingContext.EnsureListManager(obj1.DataSource, obj1.BindingMemberInfo.BindingPath);
                objBase2.Bindings.Add(objBinding);
            }
        }


        /// <summary>Gets a value indicating whether the collection is read-only.</summary>
        /// <returns>true if the collection is read-only; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source.</returns>
        /// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <filterpriority>1</filterpriority>
        public BindingManagerBase this[object objDataSource]
        {
            get
            {
                return this[objDataSource, ""];
            }
        }

        /// <summary>Gets a <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source and data member.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source and data member.</returns>
        /// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <param name="strDataMember">A navigation path containing the information that resolves to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
        /// <exception cref="T:System.Exception">The specified dataMember does not exist within the data source. </exception>
        /// <filterpriority>1</filterpriority>
        public BindingManagerBase this[object objDataSource, string strDataMember]
        {
            get
            {
                return this.EnsureListManager(objDataSource, strDataMember);
            }
        }

        int ICollection.Count
        {
            get
            {
                this.ScrubWeakRefs();
                return this.listManagers.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return null;
            }
        }

        [Serializable()]
        internal class HashKey
        {
            private string mstrDataMember;
            private int mintDataSourceHashCode;
            private WeakReference wRef;

            internal HashKey(object objDataSource, string strDataMember)
            {
                if (objDataSource == null)
                {
                    throw new ArgumentNullException("dataSource");
                }
                if (strDataMember == null)
                {
                    strDataMember = "";
                }
                this.wRef = new WeakReference(objDataSource, false);
                this.mintDataSourceHashCode = objDataSource.GetHashCode();
                this.mstrDataMember = strDataMember.ToLower(CultureInfo.InvariantCulture);
            }

            public override bool Equals(object objTarget)
            {
                if (objTarget is BindingContext.HashKey)
                {
                    BindingContext.HashKey key1 = (BindingContext.HashKey)objTarget;
                    if (this.wRef.Target == key1.wRef.Target)
                    {
                        return (this.mstrDataMember == key1.mstrDataMember);
                    }
                }
                return false;
            }

            public override int GetHashCode()
            {
                return (this.mintDataSourceHashCode * this.mstrDataMember.GetHashCode());
            }

        }
    }

    #endregion

    #region BindingManagerBase Class

    /// <summary>Manages all <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects that are bound to the same data source and data member. This class is abstract.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public abstract class BindingManagerBase : SerializableObject
    {
        private BindingsCollection mobjBindings;
        private bool mblnPullingData;

        /// <summary>Occurs at the completion of a data-binding operation.</summary>
        public event BindingCompleteEventHandler BindingComplete;
        /// <summary>Occurs when the currently bound item changes.</summary>
        /// <filterpriority>1</filterpriority>
        public event EventHandler CurrentChanged;
        /// <summary>Occurs when the state of the currently bound item changes.</summary>
        /// <filterpriority>1</filterpriority>
        public event EventHandler CurrentItemChanged;
        /// <summary>Occurs when an <see cref="T:System.Exception"></see> is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </summary>
        public event BindingManagerDataErrorEventHandler DataError;
        /// <summary>Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingManagerBase.Position"></see> property has changed.</summary>
        /// <filterpriority>1</filterpriority>
        public event EventHandler PositionChanged;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> class.</summary>
        public BindingManagerBase()
        {
        }

        internal BindingManagerBase(object objDataSource)
        {
            this.SetDataSource(objDataSource);
        }

        /// <summary>When overridden in a derived class, adds a new item to the underlying list.</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void AddNew();
        internal void Binding_BindingComplete(object sender, BindingCompleteEventArgs args)
        {
            this.OnBindingComplete(args);
        }

        /// <summary>When overridden in a derived class, cancels the current edit.</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void CancelCurrentEdit();
        /// <summary>When overridden in a derived class, ends the current edit.</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void EndCurrentEdit();
        /// <summary>When overridden in a derived class, gets the collection of property descriptors for the binding.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual PropertyDescriptorCollection GetItemProperties()
        {
            return this.GetItemProperties(null);
        }

        internal abstract PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors);
        /// <summary>Gets the collection of property descriptors for the binding using the specified <see cref="T:System.Collections.ArrayList"></see>.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
        /// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
        /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
        protected internal virtual PropertyDescriptorCollection GetItemProperties(ArrayList objDataSources, ArrayList objListAccessors)
        {
            IList objList = null;
            if (this is CurrencyManager)
            {
                objList = ((CurrencyManager)this).List;
            }
            if (objList is ITypedList)
            {
                PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[objListAccessors.Count];
                objListAccessors.CopyTo(arrDescriptors, 0);
                return ((ITypedList)objList).GetItemProperties(arrDescriptors);
            }
            return this.GetItemProperties(this.BindType, 0, objDataSources, objListAccessors);
        }

        /// <summary>Gets the list of properties of the items managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
        /// <param name="intOffset">A counter used to recursively call the method. </param>
        /// <param name="objListType">The <see cref="T:System.Type"></see> of the bound list. </param>
        /// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
        /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
        protected virtual PropertyDescriptorCollection GetItemProperties(Type objListType, int intOffset, ArrayList objDataSources, ArrayList objListAccessors)
        {
            if (objListAccessors.Count >= intOffset)
            {
                if (objListAccessors.Count == intOffset)
                {
                    if (!typeof(IList).IsAssignableFrom(objListType))
                    {
                        return TypeDescriptor.GetProperties(objListType);
                    }
                    PropertyInfo[] arrPropertyInfos1 = objListType.GetProperties();
                    for (int num1 = 0; num1 < arrPropertyInfos1.Length; num1++)
                    {
                        if ("Item".Equals(arrPropertyInfos1[num1].Name) && (arrPropertyInfos1[num1].PropertyType != typeof(object)))
                        {
                            return TypeDescriptor.GetProperties(arrPropertyInfos1[num1].PropertyType, new Attribute[] { new BrowsableAttribute(true) });
                        }
                    }
                    IList objList1 = objDataSources[intOffset - 1] as IList;
                    if ((objList1 == null) || (objList1.Count <= 0))
                    {
                        return null;
                    }
                    return TypeDescriptor.GetProperties(objList1[0]);
                }
                PropertyInfo[] arrPropertyInfos2 = objListType.GetProperties();
                if (typeof(IList).IsAssignableFrom(objListType))
                {
                    PropertyDescriptorCollection objCollection1 = null;
                    for (int num2 = 0; num2 < arrPropertyInfos2.Length; num2++)
                    {
                        if ("Item".Equals(arrPropertyInfos2[num2].Name) && (arrPropertyInfos2[num2].PropertyType != typeof(object)))
                        {
                            objCollection1 = TypeDescriptor.GetProperties(arrPropertyInfos2[num2].PropertyType, new Attribute[] { new BrowsableAttribute(true) });
                        }
                    }
                    if (objCollection1 == null)
                    {
                        IList objList2;
                        if (intOffset == 0)
                        {
                            objList2 = this.DataSource as IList;
                        }
                        else
                        {
                            objList2 = objDataSources[intOffset - 1] as IList;
                        }
                        if ((objList2 != null) && (objList2.Count > 0))
                        {
                            objCollection1 = TypeDescriptor.GetProperties(objList2[0]);
                        }
                    }
                    if (objCollection1 != null)
                    {
                        for (int num3 = 0; num3 < objCollection1.Count; num3++)
                        {
                            if (objCollection1[num3].Equals(objListAccessors[intOffset]))
                            {
                                return this.GetItemProperties(objCollection1[num3].PropertyType, intOffset + 1, objDataSources, objListAccessors);
                            }
                        }
                    }
                }
                else
                {
                    for (int num4 = 0; num4 < arrPropertyInfos2.Length; num4++)
                    {
                        if (arrPropertyInfos2[num4].Name.Equals(((PropertyDescriptor)objListAccessors[intOffset]).Name))
                        {
                            return this.GetItemProperties(arrPropertyInfos2[num4].PropertyType, intOffset + 1, objDataSources, objListAccessors);
                        }
                    }
                }
            }
            return null;
        }

        internal abstract string GetListName();
        /// <summary>When overridden in a derived class, gets the name of the list supplying the data for the binding.</summary>
        /// <returns>The name of the list supplying the data for the binding.</returns>
        /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
        protected internal abstract string GetListName(ArrayList objListAccessors);
        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.BindingComplete"></see> event. </summary>
        /// <param name="objEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
        protected internal void OnBindingComplete(BindingCompleteEventArgs objEventArgs)
        {
            if (this.BindingComplete != null)
            {
                this.BindingComplete(this, objEventArgs);
            }
        }

        private void OnBindingsCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            Binding objBinding = e.Element as Binding;
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    objBinding.BindingComplete += new BindingCompleteEventHandler(this.Binding_BindingComplete);
                    return;

                case CollectionChangeAction.Remove:
                    objBinding.BindingComplete -= new BindingCompleteEventHandler(this.Binding_BindingComplete);
                    return;

                case CollectionChangeAction.Refresh:
                    foreach (Binding objBinding2 in this.mobjBindings)
                    {
                        objBinding2.BindingComplete += new BindingCompleteEventHandler(this.Binding_BindingComplete);
                    }
                    return;
            }
        }

        private void OnBindingsCollectionChanging(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Refresh)
            {
                foreach (Binding objBinding in this.mobjBindings)
                {
                    objBinding.BindingComplete -= new BindingCompleteEventHandler(this.Binding_BindingComplete);
                }
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.</summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected internal abstract void OnCurrentChanged(EventArgs e);
        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected internal abstract void OnCurrentItemChanged(EventArgs e);
        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event.</summary>
        /// <param name="objException">An <see cref="T:System.Exception"></see> that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to occur.</param>
        protected internal void OnDataError(Exception objException)
        {

            // Raise event if needed
            BindingManagerDataErrorEventHandler objEventHandler = this.DataError;
            if (objEventHandler != null)
            {
                objEventHandler(this, new BindingManagerDataErrorEventArgs(objException));
            }
        }

        /// <summary>Pulls data from the data-bound control into the data source, returning no information.</summary>
        protected void PullData()
        {
            bool blnFlag1;
            this.PullData(out blnFlag1);
        }

        internal void PullData(out bool blnSuccess)
        {
            blnSuccess = true;
            this.mblnPullingData = true;
            try
            {
                this.UpdateIsBinding();
                int num1 = this.Bindings.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    if (this.Bindings[num2].PullData())
                    {
                        blnSuccess = false;
                    }
                }
            }
            finally
            {
                this.mblnPullingData = false;
            }
        }

        /// <summary>Pushes data from the data source into the data-bound control, returning no information.</summary>
        protected void PushData()
        {
            bool blnFlag1;
            this.PushData(out blnFlag1);
        }

        internal void PushData(out bool blnSuccess)
        {
            blnSuccess = true;
            if (!this.mblnPullingData)
            {
                this.UpdateIsBinding();
                int num1 = this.Bindings.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    if (this.Bindings[num2].PushData())
                    {
                        blnSuccess = false;
                    }
                }
            }
        }

        /// <summary>When overridden in a derived class, deletes the row at the specified index from the underlying list.</summary>
        /// <param name="index">The index of the row to delete. </param>
        /// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
        /// <filterpriority>1</filterpriority>
        public abstract void RemoveAt(int index);
        /// <summary>When overridden in a derived class, resumes data binding.</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void ResumeBinding();
        internal abstract void SetDataSource(object objDataSource);
        /// <summary>When overridden in a derived class, suspends data binding.</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void SuspendBinding();
        /// <summary>When overridden in a derived class, updates the binding.</summary>
        protected abstract void UpdateIsBinding();

        /// <summary>Gets the collection of bindings being managed.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public BindingsCollection Bindings
        {
            get
            {
                if (this.mobjBindings == null)
                {
                    this.mobjBindings = new ListManagerBindingsCollection(this);
                    this.mobjBindings.CollectionChanging += new CollectionChangeEventHandler(this.OnBindingsCollectionChanging);
                    this.mobjBindings.CollectionChanged += new CollectionChangeEventHandler(this.OnBindingsCollectionChanged);
                }
                return this.mobjBindings;
            }
        }

        internal int BindingsCount
        {
            get
            {
                if (this.mobjBindings != null)
                {
                    return this.mobjBindings.Count;
                }

                return 0;
            }
        }

        internal abstract Type BindType { get; }

        /// <summary>When overridden in a derived class, gets the number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
        /// <returns>The number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public abstract int Count { get; }

        /// <summary>When overridden in a derived class, gets the current object.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the current object.</returns>
        /// <filterpriority>1</filterpriority>
        public abstract object Current { get; }

        internal abstract object DataSource { get; }

        internal abstract bool IsBinding { get; }

        /// <summary>Gets a value indicating whether binding is suspended.</summary>
        /// <returns>true if binding is suspended; otherwise, false.</returns>
        public bool IsBindingSuspended
        {
            get
            {
                return !this.IsBinding;
            }
        }

        /// <summary>When overridden in a derived class, gets or sets the position in the underlying list that controls bound to this data source point to.</summary>
        /// <returns>A zero-based index that specifies a position in the underlying list.</returns>
        /// <filterpriority>1</filterpriority>
        public abstract int Position { get; set; }


        /// <summary>
        /// Fires the current changed.
        /// </summary>
        /// <param name="objSource">The obj source.</param>
        /// <param name="objArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void FireCurrentChanged(object objSource, EventArgs objArgs)
        {
            if (CurrentChanged != null)
            {
                CurrentChanged(objSource, objArgs);
            }
        }

        /// <summary>
        /// Fires the current item changed.
        /// </summary>
        /// <param name="objSource">The obj source.</param>
        /// <param name="objArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void FireCurrentItemChanged(object objSource, EventArgs objArgs)
        {
            if (CurrentItemChanged != null)
            {
                CurrentItemChanged(objSource, objArgs);
            }
        }

        /// <summary>
        /// Fires the position changed.
        /// </summary>
        /// <param name="objSource">The obj source.</param>
        /// <param name="objArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void FirePositionChanged(object objSource, EventArgs objArgs)
        {
            if (PositionChanged != null)
            {
                PositionChanged(objSource, objArgs);
            }
        }
    }
    #endregion

    #region BindingMemberInfo Class

    /// <summary>Contains information that enables a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to resolve a data binding to either the property of an object or the property of the current object in a list of objects.</summary>
    /// <filterpriority>2</filterpriority>
    [StructLayout(LayoutKind.Sequential)]
    [Serializable()]
    public struct BindingMemberInfo
    {
        private string mstrDataList;
        private string mstrDataField;
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> class.</summary>
        /// <param name="strDataMember">A navigation path that resolves to either the property of an object or the property of the current object in a list of objects. </param>
        public BindingMemberInfo(string strDataMember)
        {
            if (strDataMember == null)
            {
                strDataMember = "";
            }
            int num1 = strDataMember.LastIndexOf(".");
            if (num1 != -1)
            {
                this.mstrDataList = strDataMember.Substring(0, num1);
                this.mstrDataField = strDataMember.Substring(num1 + 1);
            }
            else
            {
                this.mstrDataList = "";
                this.mstrDataField = strDataMember;
            }
        }

        /// <summary>Gets the property name, or the period-delimited hierarchy of property names, that comes before the property name of the data-bound object.</summary>
        /// <returns>The property name, or the period-delimited hierarchy of property names, that comes before the data-bound object property name.</returns>
        /// <filterpriority>1</filterpriority>
        public string BindingPath
        {
            get
            {
                if (this.mstrDataList == null)
                {
                    return "";
                }
                return this.mstrDataList;
            }
        }
        /// <summary>Gets the property name of the data-bound object.</summary>
        /// <returns>The property name of the data-bound object. This can be an empty string ("").</returns>
        /// <filterpriority>1</filterpriority>
        public string BindingField
        {
            get
            {
                if (this.mstrDataField == null)
                {
                    return "";
                }
                return this.mstrDataField;
            }
        }
        /// <summary>Gets the information that is used to specify the property name of the data-bound object.</summary>
        /// <returns>An empty string (""), a single property name, or a hierarchy of period-delimited property names that resolves to the property name of the final data-bound object.</returns>
        /// <filterpriority>1</filterpriority>
        public string BindingMember
        {
            get
            {
                if (this.BindingPath.Length <= 0)
                {
                    return this.BindingField;
                }
                return (this.BindingPath + "." + this.BindingField);
            }
        }
        /// <summary>Determines whether the specified object is equal to this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
        /// <returns>true if otherObject is a <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> and both <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings are equal; otherwise false.</returns>
        /// <param name="otherObject">The object to compare for equality.</param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object otherObject)
        {
            if (otherObject is BindingMemberInfo)
            {
                BindingMemberInfo objBindingMemberInfo = (BindingMemberInfo)otherObject;
                return ClientUtils.IsEquals(this.BindingMember, objBindingMemberInfo.BindingMember, StringComparison.OrdinalIgnoreCase);

            }
            return false;
        }

        /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are equal.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are equal; otherwise false.</returns>
        /// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
        /// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
        public static bool operator ==(BindingMemberInfo BindingMemberInfo1, BindingMemberInfo BindingMemberInfo2)
        {
            return BindingMemberInfo1.Equals(BindingMemberInfo2);
        }

        /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are not equal.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are not equal; otherwise false.</returns>
        /// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
        /// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
        public static bool operator !=(BindingMemberInfo BindingMemberInfo1, BindingMemberInfo BindingMemberInfo2)
        {
            return !BindingMemberInfo1.Equals(BindingMemberInfo2);
        }

        /// <summary>Returns the hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
        /// <returns>The hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    #endregion

    #region BindingsCollection Class

    /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for a control.</summary>
    /// <filterpriority>2</filterpriority>
    [DefaultEvent("CollectionChanged")]
    [Serializable()]
    public class BindingsCollection : BaseCollection
    {

        private ArrayList mobjList;

        /// <summary>Occurs when the collection has changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("collectionChangedEventDescr")]
        public event CollectionChangeEventHandler CollectionChanged;
        /// <summary>Occurs when the collection is about to change.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("collectionChangingEventDescr")]
        public event CollectionChangeEventHandler CollectionChanging;

        internal BindingsCollection()
        {
        }

        /// <summary>Adds the specified binding to the collection.</summary>
        /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection. </param>
        protected internal void Add(Binding objBinding)
        {
            CollectionChangeEventArgs args1 = new CollectionChangeEventArgs(CollectionChangeAction.Add, objBinding);
            this.OnCollectionChanging(args1);
            this.AddCore(objBinding);
            this.OnCollectionChanged(args1);
        }

        /// <summary>Adds a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
        /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection.</param>
        /// <exception cref="T:System.ArgumentNullException">The dataBinding argument was null. </exception>
        protected virtual void AddCore(Binding objDataBinding)
        {
            if (objDataBinding == null)
            {
                throw new ArgumentNullException("dataBinding");
            }
            this.List.Add(objDataBinding);
        }

        /// <summary>Clears the collection of binding objects.</summary>
        protected internal void Clear()
        {
            CollectionChangeEventArgs args1 = new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null);
            this.OnCollectionChanging(args1);
            this.ClearCore();
            this.OnCollectionChanged(args1);
        }

        /// <summary>Clears the collection of any members.</summary>
        protected virtual void ClearCore()
        {
            this.List.Clear();
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanged"></see> event.</summary>
        /// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
        {

            // Raise event if needed
            CollectionChangeEventHandler objEventHandler = this.CollectionChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, objCcevent);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanging"></see> event. </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains event data.</param>
        protected virtual void OnCollectionChanging(CollectionChangeEventArgs e)
        {

            // Raise event if needed
            CollectionChangeEventHandler objEventHandler = this.CollectionChanging;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Deletes the specified binding from the collection.</summary>
        /// <param name="objBinding">The Binding to remove from the collection. </param>
        protected internal void Remove(Binding objBinding)
        {
            CollectionChangeEventArgs args1 = new CollectionChangeEventArgs(CollectionChangeAction.Remove, objBinding);
            this.OnCollectionChanging(args1);
            this.RemoveCore(objBinding);
            this.OnCollectionChanged(args1);
        }

        /// <summary>Deletes the binding from the collection at the specified index.</summary>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
        protected internal void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.</summary>
        /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
        protected virtual void RemoveCore(Binding objDataBinding)
        {
            this.List.Remove(objDataBinding);
        }

        /// <summary>Gets a value that indicates whether the collection should be serialized.</summary>
        /// <returns>true if the collection count is greater than zero; otherwise, false.</returns>
        protected internal bool ShouldSerializeMyAll()
        {
            return (this.Count > 0);
        }


        /// <summary>Gets the total number of bindings in the collection.</summary>
        /// <returns>The total number of bindings in the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public override int Count
        {
            get
            {
                if (this.mobjList == null)
                {
                    return 0;
                }
                return base.Count;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</returns>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to find. </param>
        /// <exception cref="T:System.IndexOutOfRangeException">The collection doesn't contain an item at the specified index. </exception>
        /// <filterpriority>1</filterpriority>
        public Binding this[int index]
        {
            get
            {
                return (Binding)this.List[index];
            }
        }

        /// <summary>Gets the bindings in the collection as an object.</summary>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing all of the collection members.</returns>
        protected override ArrayList List
        {
            get
            {
                if (this.mobjList == null)
                {
                    this.mobjList = new ArrayList();
                }
                return this.mobjList;
            }
        }
    }

    #endregion

    #region BindToObject Class


    [Serializable()]
    internal class BindToObject : SerializableObject
    {
        private static readonly SerializableProperty bindingManagerProperty = SerializableProperty.Register("bindingManager", typeof(BindingManagerBase), typeof(BindToObject));

        private BindingManagerBase bindingManager
        {
            get
            {
                return this.GetValue<BindingManagerBase>(BindToObject.bindingManagerProperty);
            }
            set
            {
                this.SetValue<BindingManagerBase>(BindToObject.bindingManagerProperty, value);
            }
        }

        private BindingMemberInfo mobjDataMember;
        private object mobjDataSource;

        private static readonly SerializableProperty dataSourceInitializedProperty = SerializableProperty.Register("dataSourceInitialized", typeof(bool), typeof(BindToObject));

        private bool dataSourceInitialized
        {
            get
            {
                return this.GetValue<bool>(BindToObject.dataSourceInitializedProperty);
            }
            set
            {
                this.SetValue<bool>(BindToObject.dataSourceInitializedProperty, value);
            }
        }

        private string mstrErrorText;
        [NonSerialized]
        private PropertyDescriptor mobjFieldInfo;
        private bool mblnFieldInfoInitialized = false;
        private Binding mobjOwner;

        private static readonly SerializableProperty waitingOnDataSourceProperty = SerializableProperty.Register("waitingOnDataSource", typeof(bool), typeof(BindToObject));

        private bool waitingOnDataSource
        {
            get
            {
                return this.GetValue<bool>(BindToObject.waitingOnDataSourceProperty);
            }
            set
            {
                this.SetValue<bool>(BindToObject.waitingOnDataSourceProperty, value);
            }
        }

        internal BindToObject(Binding objOwner, object objDataSource, string strDataMember)
        {
            this.mstrErrorText = string.Empty;
            this.mobjOwner = objOwner;
            this.mobjDataSource = objDataSource;
            this.mobjDataMember = new Gizmox.WebGUI.Forms.BindingMemberInfo(strDataMember);
            this.CheckBinding();
        }

        internal void CheckBinding()
        {
            if (((this.mobjOwner == null) || (this.mobjOwner.BindableComponent == null)) || !this.mobjOwner.ControlAtDesignTime())
            {
            if (((this.mobjOwner.BindingManagerBase != null) && (this.mobjFieldInfo != null)) && (this.mobjOwner.BindingManagerBase.IsBinding && !(this.mobjOwner.BindingManagerBase is CurrencyManager)))
            {
                this.mobjFieldInfo.RemoveValueChanged(this.mobjOwner.BindingManagerBase.Current, new EventHandler(this.PropValueChanged));
            }
            if ((((this.mobjOwner != null) && (this.mobjOwner.BindingManagerBase != null)) && ((this.mobjOwner.BindableComponent != null) && this.mobjOwner.ComponentCreated)) && this.IsDataSourceInitialized)
            {
                string strText1 = this.mobjDataMember.BindingField;
                this.mobjFieldInfo = this.mobjOwner.BindingManagerBase.GetItemProperties().Find(strText1, true);
                if (((this.mobjOwner.BindingManagerBase.DataSource != null) && (this.mobjFieldInfo == null)) && (strText1.Length > 0))
                {
                    throw new ArgumentException(SR.GetString("ListBindingBindField", new object[] { strText1 }), "dataMember");
                }
                if (((this.mobjFieldInfo != null) && this.mobjOwner.BindingManagerBase.IsBinding) && !(this.mobjOwner.BindingManagerBase is CurrencyManager))
                {
                    this.mobjFieldInfo.AddValueChanged(this.mobjOwner.BindingManagerBase.Current, new EventHandler(this.PropValueChanged));
                }
            }
            else
            {
                this.mobjFieldInfo = null;
            }

            mblnFieldInfoInitialized = true;
        }
        }

        /// <summary>
        /// Ensures the field info.
        /// </summary>
        private void EnsureFieldInfo()
        {
            if (mblnFieldInfoInitialized && this.mobjFieldInfo == null)
            {
                this.CheckBinding();
            }
        }

        private void DataSource_Initialized(object sender, EventArgs e)
        {
            ISupportInitializeNotification notification1 = this.mobjDataSource as ISupportInitializeNotification;
            if (notification1 != null)
            {
                notification1.Initialized -= new EventHandler(this.DataSource_Initialized);
            }
            this.waitingOnDataSource = false;
            this.dataSourceInitialized = true;
            this.CheckBinding();
        }

        private string GetErrorText(object objValue)
        {
            IDataErrorInfo objIDataErrorInfo = objValue as IDataErrorInfo;
            string strText1 = string.Empty;
            if (objIDataErrorInfo != null)
            {
                EnsureFieldInfo();

                if (this.mobjFieldInfo == null)
                {
                    strText1 = objIDataErrorInfo.Error;
                }
                else
                {
                    strText1 = objIDataErrorInfo[this.mobjFieldInfo.Name];
                }
            }
            return (strText1 != null ? strText1 : string.Empty);
        }

        internal object GetValue()
        {
            object obj1 = this.bindingManager.Current;
            this.mstrErrorText = this.GetErrorText(obj1);

            EnsureFieldInfo();

            if (this.mobjFieldInfo != null)
            {
                obj1 = this.mobjFieldInfo.GetValue(obj1);
            }
            return obj1;
        }

        private void PropValueChanged(object sender, EventArgs e)
        {
            this.bindingManager.OnCurrentChanged(EventArgs.Empty);
        }

        internal void SetBindingManagerBase(BindingManagerBase lManager)
        {
            if (this.bindingManager != lManager)
            {
                EnsureFieldInfo();

                if (((this.bindingManager != null) && (this.mobjFieldInfo != null)) && (this.bindingManager.IsBinding && !(this.bindingManager is CurrencyManager)))
                {
                    this.mobjFieldInfo.RemoveValueChanged(this.bindingManager.Current, new EventHandler(this.PropValueChanged));
                    this.mobjFieldInfo = null;
                }
                this.bindingManager = lManager;
                this.CheckBinding();
            }
        }

        internal void SetValue(object objValue)
        {
            object obj1 = null;

            EnsureFieldInfo();

            if (this.mobjFieldInfo != null)
            {
                obj1 = this.bindingManager.Current;
                if (obj1 is IEditableObject)
                {
                    ((IEditableObject)obj1).BeginEdit();
                }
                if (!this.mobjFieldInfo.IsReadOnly)
                {
                    this.mobjFieldInfo.SetValue(obj1, objValue);
                }
            }
            else
            {
                CurrencyManager manager1 = this.bindingManager as CurrencyManager;
                if (manager1 != null)
                {
                    manager1[manager1.Position] = objValue;
                    obj1 = objValue;
                }
            }
            this.mstrErrorText = this.GetErrorText(obj1);
        }


        internal BindingManagerBase BindingManagerBase
        {
            get
            {
                return this.bindingManager;
            }
        }

        internal BindingMemberInfo BindingMemberInfo
        {
            get
            {
                return this.mobjDataMember;
            }
        }

        internal Type BindToType
        {
            get
            {
                if (this.mobjDataMember.BindingField.Length == 0)
                {
                    Type objType1 = this.bindingManager.BindType;
                    if (typeof(Array).IsAssignableFrom(objType1))
                    {
                        objType1 = objType1.GetElementType();
                    }
                    return objType1;
                }

                EnsureFieldInfo();

                if (this.mobjFieldInfo != null)
                {
                    return this.mobjFieldInfo.PropertyType;
                }
                return null;
            }
        }

        internal string DataErrorText
        {
            get
            {
                return this.mstrErrorText;
            }
        }

        internal object DataSource
        {
            get
            {
                return this.mobjDataSource;
            }
        }

        internal PropertyDescriptor FieldInfo
        {
            get
            {
                EnsureFieldInfo();

                return this.mobjFieldInfo;
            }
        }

        private bool IsDataSourceInitialized
        {
            get
            {
                if (this.dataSourceInitialized)
                {
                    return true;
                }
                ISupportInitializeNotification notification1 = this.mobjDataSource as ISupportInitializeNotification;
                if ((notification1 == null) || notification1.IsInitialized)
                {
                    this.dataSourceInitialized = true;
                    return true;
                }
                if (!this.waitingOnDataSource)
                {
                    notification1.Initialized += new EventHandler(this.DataSource_Initialized);
                    this.waitingOnDataSource = true;
                }
                return false;
            }
        }
    }

    #endregion

    #region Formatter Class


    [Serializable()]
    internal class Formatter : SerializableObject
    {
        private static Type mobjBooleanType;
        private static Type mobjCheckStateType;
        private static object mobjDefaultDataSourceNullValue;
        private static object mobjParseMethodNotFound;
        private static Type mobjStringType;

        static Formatter()
        {
            Formatter.mobjStringType = typeof(string);
            Formatter.mobjBooleanType = typeof(bool);
            Formatter.mobjCheckStateType = typeof(CheckState);
            Formatter.mobjParseMethodNotFound = new object();
            Formatter.mobjDefaultDataSourceNullValue = DBNull.Value;
        }

        private static object ChangeType(object objValue, Type objType, IFormatProvider objFormatInfo)
        {
            object obj1;
            try
            {
                if (objFormatInfo == null)
                {
                    objFormatInfo = CultureInfo.CurrentCulture;
                }
                obj1 = Convert.ChangeType(objValue, objType, objFormatInfo);
            }
            catch (InvalidCastException objException1)
            {
                throw new FormatException(objException1.Message, objException1);
            }
            return obj1;
        }

        private static bool EqualsFormattedNullValue(object objValue, object objFormattedNullValue, IFormatProvider objFormatInfo)
        {
            if ((objFormattedNullValue is string) && (objValue is string))
            {
                return (string.Compare((string)objValue, (string)objFormattedNullValue, true, Formatter.GetFormatterCulture(objFormatInfo)) == 0);
            }
            return object.Equals(objValue, objFormattedNullValue);
        }

        public static object FormatObject(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
        {
            if (Formatter.IsNullData(objValue, objDataSourceNullValue))
            {
                objValue = DBNull.Value;
            }
            Type objType1 = objTargetType;
            objTargetType = Formatter.NullableUnwrap(objTargetType);
            objSourceConverter = Formatter.NullableUnwrap(objSourceConverter);
            objTargetConverter = Formatter.NullableUnwrap(objTargetConverter);
            bool blnFlag1 = objTargetType != objType1;
            object obj1 = Formatter.FormatObjectInternal(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue);
            if ((objType1.IsValueType && (obj1 == null)) && !blnFlag1)
            {
                throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
            }
            return obj1;
        }

        private static object FormatObjectInternal(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue)
        {
            if ((objValue == DBNull.Value) || (objValue == null))
            {
                if (objFormattedNullValue != null)
                {
                    return objFormattedNullValue;
                }
                if (objTargetType == Formatter.mobjStringType)
                {
                    return string.Empty;
                }

                if (objTargetType == Formatter.mobjCheckStateType)
                {
                    return CheckState.Indeterminate;
                }
                return null;
            }
            if (((objTargetType == Formatter.mobjStringType) && (objValue is IFormattable)) && !CommonUtils.IsNullOrEmpty(strFormatString))
            {
                return (objValue as IFormattable).ToString(strFormatString, objFormatInfo);
            }
            Type objType1 = objValue.GetType();
            TypeConverter objConverter1 = TypeDescriptor.GetConverter(objType1);
            if (((objSourceConverter != null) && (objSourceConverter != objConverter1)) && objSourceConverter.CanConvertTo(objTargetType))
            {
                return objSourceConverter.ConvertTo(null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
            }
            TypeConverter objConverter2 = TypeDescriptor.GetConverter(objTargetType);
            if (((objTargetConverter != null) && (objTargetConverter != objConverter2)) && objTargetConverter.CanConvertFrom(objType1))
            {
                return objTargetConverter.ConvertFrom(null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
            }
            if (objTargetType == Formatter.mobjCheckStateType)
            {
                if (objType1 == Formatter.mobjBooleanType)
                {
                    return (((bool)objValue) ? CheckState.Checked : CheckState.Unchecked);
                }
                if (objSourceConverter == null)
                {
                    objSourceConverter = objConverter1;
                }
                if ((objSourceConverter != null) && objSourceConverter.CanConvertTo(Formatter.mobjBooleanType))
                {
                    return (((bool)objSourceConverter.ConvertTo(null, Formatter.GetFormatterCulture(objFormatInfo), objValue, Formatter.mobjBooleanType)) ? CheckState.Checked : CheckState.Unchecked);
                }
            }
            if (!objTargetType.IsAssignableFrom(objType1))
            {
                if (objSourceConverter == null)
                {
                    objSourceConverter = objConverter1;
                }
                if (objTargetConverter == null)
                {
                    objTargetConverter = objConverter2;
                }
                if ((objSourceConverter == null) || !objSourceConverter.CanConvertTo(objTargetType))
                {
                    if ((objTargetConverter == null) || !objTargetConverter.CanConvertFrom(objType1))
                    {
                        if (!(objValue is IConvertible))
                        {
                            throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
                        }
                        return Formatter.ChangeType(objValue, objTargetType, objFormatInfo);
                    }
                    return objTargetConverter.ConvertFrom(null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
                }
                return objSourceConverter.ConvertTo(null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
            }
            return objValue;
        }

        private static string GetCantConvertMessage(object objValue, Type objTargetType)
        {
            string strText1 = (objValue == null) ? "Formatter_CantConvertNull" : "Formatter_CantConvert";
            return string.Format(CultureInfo.CurrentCulture, SR.GetString(strText1), new object[] { objValue, objTargetType.Name });
        }

        public static object GetDefaultDataSourceNullValue(Type objType)
        {
            if ((objType != null) && !objType.IsValueType)
            {
                return null;
            }
            return Formatter.mobjDefaultDataSourceNullValue;
        }

        private static CultureInfo GetFormatterCulture(IFormatProvider objFormatInfo)
        {
            if (objFormatInfo is CultureInfo)
            {
                return (objFormatInfo as CultureInfo);
            }
            return CultureInfo.CurrentCulture;
        }

        public static object InvokeStringParseMethod(object objValue, Type objTargetType, IFormatProvider objFormatInfo)
        {
            object obj1;
            try
            {
                MethodInfo objMethodInfo = objTargetType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new Type[] { Formatter.mobjStringType, typeof(NumberStyles), typeof(IFormatProvider) }, null);
                if (objMethodInfo != null)
                {
                    return objMethodInfo.Invoke(null, new object[] { (string)objValue, NumberStyles.Any, objFormatInfo });
                }
                objMethodInfo = objTargetType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new Type[] { Formatter.mobjStringType, typeof(IFormatProvider) }, null);
                if (objMethodInfo != null)
                {
                    return objMethodInfo.Invoke(null, new object[] { (string)objValue, objFormatInfo });
                }
                objMethodInfo = objTargetType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new Type[] { Formatter.mobjStringType }, null);
                if (objMethodInfo != null)
                {
                    return objMethodInfo.Invoke(null, new object[] { (string)objValue });
                }
                obj1 = Formatter.mobjParseMethodNotFound;
            }
            catch (TargetInvocationException objException1)
            {
                throw new FormatException(objException1.InnerException.Message, objException1.InnerException);
            }
            return obj1;
        }

        public static bool IsNullData(object objValue, object objDataSourceNullValue)
        {
            if ((objValue != null) && (objValue != DBNull.Value))
            {
                return object.Equals(objValue, Formatter.NullData(objValue.GetType(), objDataSourceNullValue));
            }
            return true;
        }

        private static TypeConverter NullableUnwrap(TypeConverter objTypeConverter)
        {
            if (objTypeConverter != null)
            {
                Type objNullableConverterType = typeof(NullableConverter);
                if (objNullableConverterType != null)
                {
                    Type objTypeConverterType = objTypeConverter.GetType();
                    if (objTypeConverterType.IsSubclassOf(objNullableConverterType) || objTypeConverterType == objNullableConverterType)
                    {
                        PropertyInfo prop = objNullableConverterType.GetProperty("UnderlyingTypeConverter", BindingFlags.Public | BindingFlags.Instance);
                        objTypeConverter = (TypeConverter)prop.GetValue(objTypeConverter, null);
                    }
                }
            }
            return objTypeConverter;
        }

        private static Type NullableUnwrap(Type objType)
        {
            if (objType == Formatter.mobjStringType)
            {
                return Formatter.mobjStringType;
            }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            Type objType1 = Nullable.GetUnderlyingType(objType);
            return (objType1 != null ? objType1 : objType);
#endif
        }

        public static object NullData(Type objType, object objDataSourceNullValue)
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (!objType.IsGenericType || (objType.GetGenericTypeDefinition() != typeof(Nullable<>)))
            {
                return objDataSourceNullValue;
            }
#endif
            if ((objDataSourceNullValue != null) && (objDataSourceNullValue != DBNull.Value))
            {
                return objDataSourceNullValue;
            }
            return null;
        }

        public static object ParseObject(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
        {
            Type objType1 = objTargetType;
            objSourceType = Formatter.NullableUnwrap(objSourceType);
            objTargetType = Formatter.NullableUnwrap(objTargetType);
            objSourceConverter = Formatter.NullableUnwrap(objSourceConverter);
            objTargetConverter = Formatter.NullableUnwrap(objTargetConverter);
            object obj1 = Formatter.ParseObjectInternal(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue);
            if (obj1 == DBNull.Value)
            {
                return Formatter.NullData(objType1, objDataSourceNullValue);
            }
            return obj1;
        }

        private static object ParseObjectInternal(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue)
        {
            if (Formatter.EqualsFormattedNullValue(objValue, objFormattedNullValue, objFormatInfo) || (objValue == DBNull.Value))
            {
                return DBNull.Value;
            }
            TypeConverter objConverter1 = TypeDescriptor.GetConverter(objTargetType);
            if (((objTargetConverter == null) || (objConverter1 == objTargetConverter)) || !objTargetConverter.CanConvertFrom(objSourceType))
            {
                TypeConverter objConverter2 = TypeDescriptor.GetConverter(objSourceType);
                if (((objSourceConverter != null) && (objConverter2 != objSourceConverter)) && objSourceConverter.CanConvertTo(objTargetType))
                {
                    return objSourceConverter.ConvertTo(null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
                }
                if (objValue is string)
                {
                    object obj1 = Formatter.InvokeStringParseMethod(objValue, objTargetType, objFormatInfo);
                    if (obj1 != Formatter.mobjParseMethodNotFound)
                    {
                        return obj1;
                    }
                }
                else if (objValue is CheckState)
                {
                    CheckState state1 = (CheckState)objValue;
                    if (state1 == CheckState.Indeterminate)
                    {
                        return DBNull.Value;
                    }
                    if (objTargetType == Formatter.mobjBooleanType)
                    {
                        return (state1 == CheckState.Checked);
                    }
                    if (objTargetConverter == null)
                    {
                        objTargetConverter = objConverter1;
                    }
                    if ((objTargetConverter != null) && objTargetConverter.CanConvertFrom(Formatter.mobjBooleanType))
                    {
                        return objTargetConverter.ConvertFrom(null, Formatter.GetFormatterCulture(objFormatInfo), state1 == CheckState.Checked);
                    }
                }
                else if ((objValue != null) && objTargetType.IsAssignableFrom(objValue.GetType()))
                {
                    return objValue;
                }
                if (objTargetConverter == null)
                {
                    objTargetConverter = objConverter1;
                }
                if (objSourceConverter == null)
                {
                    objSourceConverter = objConverter2;
                }
                if ((objTargetConverter == null) || !objTargetConverter.CanConvertFrom(objSourceType))
                {
                    if ((objSourceConverter == null) || !objSourceConverter.CanConvertTo(objTargetType))
                    {
                        if (!(objValue is IConvertible))
                        {
                            throw new FormatException(Formatter.GetCantConvertMessage(objValue, objTargetType));
                        }
                        return Formatter.ChangeType(objValue, objTargetType, objFormatInfo);
                    }
                    return objSourceConverter.ConvertTo(null, Formatter.GetFormatterCulture(objFormatInfo), objValue, objTargetType);
                }
            }
            return objTargetConverter.ConvertFrom(null, Formatter.GetFormatterCulture(objFormatInfo), objValue);
        }
    }

    #endregion

    #region ListBindingConverter Class

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects to and from various other representations.
    /// </summary>
    [Serializable()]
    public class ListBindingConverter : TypeConverter
    {

        private static string[] marrCtorParamProps;
        private static Type[] marrCtorTypes;

        /// <filterpriority>1</filterpriority>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <filterpriority>1</filterpriority>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is Binding))
            {
                Binding objBinding = (Binding)objValue;
                return this.GetInstanceDescriptorFromValues(objBinding);
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <filterpriority>1</filterpriority>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            object obj1;
            try
            {
                obj1 = new Binding((string)objPropertyValues["PropertyName"], objPropertyValues["DataSource"], (string)objPropertyValues["DataMember"]);
            }
            catch (InvalidCastException objException1)
            {
                throw new ArgumentException(SR.GetString("PropertyValueInvalidEntry"), objException1);
            }
            catch (NullReferenceException objException2)
            {
                throw new ArgumentException(SR.GetString("PropertyValueInvalidEntry"), objException2);
            }
            return obj1;
        }

        /// <filterpriority>1</filterpriority>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        private InstanceDescriptor GetInstanceDescriptorFromValues(Binding objBinding)
        {
            objBinding.FormattingEnabled = true;
            bool blnFlag1 = true;
            int num1 = ListBindingConverter.ConstructorParameterProperties.Length - 1;
            while (num1 >= 0)
            {
                if (ListBindingConverter.ConstructorParameterProperties[num1] == null)
                {
                    break;
                }
                PropertyDescriptor objPropertyDescriptor1 = TypeDescriptor.GetProperties(objBinding)[ListBindingConverter.ConstructorParameterProperties[num1]];
                if ((objPropertyDescriptor1 != null) && objPropertyDescriptor1.ShouldSerializeValue(objBinding))
                {
                    break;
                }
                num1--;
            }
            Type[] arrTypes = new Type[num1 + 1];
            Array.Copy(ListBindingConverter.ConstructorParamaterTypes, 0, arrTypes, 0, arrTypes.Length);
            ConstructorInfo objConstructorInfo = typeof(Binding).GetConstructor(arrTypes);
            if (objConstructorInfo == null)
            {
                blnFlag1 = false;
                objConstructorInfo = typeof(Binding).GetConstructor(new Type[] { typeof(string), typeof(object), typeof(string) });
            }
            object[] arrObjects1 = new object[arrTypes.Length];
            for (int num2 = 0; num2 < arrObjects1.Length; num2++)
            {
                object obj1 = null;
                switch (num2)
                {
                    case 0:
                        obj1 = objBinding.PropertyName;
                        break;

                    case 1:
                        obj1 = objBinding.BindToObject.DataSource;
                        break;

                    case 2:
                        obj1 = objBinding.BindToObject.BindingMemberInfo.BindingMember;
                        break;

                    default:
                        obj1 = TypeDescriptor.GetProperties(objBinding)[ListBindingConverter.ConstructorParameterProperties[num2]].GetValue(objBinding);
                        break;
                }
                arrObjects1[num2] = obj1;
            }
            return new InstanceDescriptor(objConstructorInfo, arrObjects1, blnFlag1);
        }


        private static Type[] ConstructorParamaterTypes
        {
            get
            {
                if (ListBindingConverter.marrCtorTypes == null)
                {
                    ListBindingConverter.marrCtorTypes = new Type[] { typeof(string), typeof(object), typeof(string), typeof(bool), typeof(DataSourceUpdateMode), typeof(object), typeof(string), typeof(IFormatProvider) };
                }
                return ListBindingConverter.marrCtorTypes;
            }
        }

        private static string[] ConstructorParameterProperties
        {
            get
            {
                if (ListBindingConverter.marrCtorParamProps == null)
                {
                    string[] arrText = new string[8];
                    arrText[3] = "FormattingEnabled";
                    arrText[4] = "DataSourceUpdateMode";
                    arrText[5] = "NullValue";
                    arrText[6] = "FormatString";
                    arrText[7] = "FormatInfo";
                    ListBindingConverter.marrCtorParamProps = arrText;
                }
                return ListBindingConverter.marrCtorParamProps;
            }
        }


    }

    #endregion

    #region ListBindingHelper Class

    /// <summary>Provides functionality to discover a bindable list and the properties of the items contained in the list when they differ from the public properties of the object to which they bind.</summary>

    [Serializable()]
    public class ListBindingHelper
    {
        private static object GetFirstItemByEnumerable(IEnumerable enumerable)
        {
            object obj1 = null;
            if (enumerable is IList)
            {
                IList objList1 = enumerable as IList;
                return ((objList1.Count > 0) ? objList1[0] : null);
            }
            try
            {
                IEnumerator enumerator1 = enumerable.GetEnumerator();
                enumerator1.Reset();
                if (enumerator1.MoveNext())
                {
                    obj1 = enumerator1.Current;
                }
                enumerator1.Reset();
            }
            catch (NotSupportedException)
            {
                obj1 = null;
            }
            return obj1;
        }

        /// <summary>Returns a list associated with the specified data source.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the underlying list if it exists; otherwise, the original data source specified by list.</returns>
        /// <param name="objList">The data source to examine for its underlying list.</param>
        public static object GetList(object objList)
        {
            if (objList is IListSource)
            {
                return (objList as IListSource).GetList();
            }
            return objList;
        }

        /// <summary>Returns an object, typically a list, from the evaluation of a specified data source and optional data member.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the underlying list if it was found; otherwise, dataSource.</returns>
        /// <param name="objDataSource">The data source from which to find the list.</param>
        /// <param name="strDataMember">The name of the data source property that contains the list. This can be null.</param>
        /// <exception cref="T:System.ArgumentException">The specified data member name did not match any of the properties found for the data source.</exception>
        public static object GetList(object objDataSource, string strDataMember)
        {
            object obj1;
            objDataSource = ListBindingHelper.GetList(objDataSource);
            if (((objDataSource == null) || (objDataSource is Type)) || CommonUtils.IsNullOrEmpty(strDataMember))
            {
                return objDataSource;
            }
            PropertyDescriptor objPropertyDescriptor1 = ListBindingHelper.GetListItemProperties(objDataSource).Find(strDataMember, true);
            if (objPropertyDescriptor1 == null)
            {
                throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", new object[] { strDataMember }));
            }
            if (objDataSource is ICurrencyManagerProvider)
            {
                CurrencyManager manager1 = (objDataSource as ICurrencyManagerProvider).CurrencyManager;
                obj1 = (((manager1 != null) && (manager1.Position >= 0)) && (manager1.Position <= (manager1.Count - 1))) ? manager1.Current : null;
            }
            else if (objDataSource is IEnumerable)
            {
                obj1 = ListBindingHelper.GetFirstItemByEnumerable(objDataSource as IEnumerable);
            }
            else
            {
                obj1 = objDataSource;
            }
            if (obj1 != null)
            {
                return objPropertyDescriptor1.GetValue(obj1);
            }
            return null;
        }

        /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a specified data source, or properties of the specified data source.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> containing the properties of the items contained in list, or properties of list.</returns>
        /// <param name="objList">The data source to examine for property information.</param>
        public static PropertyDescriptorCollection GetListItemProperties(object objList)
        {
            if (objList == null)
            {
                return new PropertyDescriptorCollection(null);
            }
            if (objList is Type)
            {
                return ListBindingHelper.GetListItemPropertiesByType(objList as Type);
            }
            object obj1 = ListBindingHelper.GetList(objList);
            if (obj1 is ITypedList)
            {
                return (obj1 as ITypedList).GetItemProperties(null);
            }
            if (obj1 is IEnumerable)
            {
                return ListBindingHelper.GetListItemPropertiesByEnumerable(obj1 as IEnumerable);
            }
            return TypeDescriptor.GetProperties(obj1);
        }

        /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a collection property of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of the item type contained in a collection property of the data source.</returns>
        /// <param name="objList">The data source to be examined for property information.</param>
        /// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data source to examine. This can be null.</param>
        public static PropertyDescriptorCollection GetListItemProperties(object objList, PropertyDescriptor[] arrListAccessors)
        {
            if ((arrListAccessors == null) || (arrListAccessors.Length == 0))
            {
                return ListBindingHelper.GetListItemProperties(objList);
            }
            if (objList is Type)
            {
                return ListBindingHelper.GetListItemPropertiesByType(objList as Type, arrListAccessors);
            }
            object obj1 = ListBindingHelper.GetList(objList);
            if (obj1 is ITypedList)
            {
                return (obj1 as ITypedList).GetItemProperties(arrListAccessors);
            }
            if (obj1 is IEnumerable)
            {
                return ListBindingHelper.GetListItemPropertiesByEnumerable(obj1 as IEnumerable, arrListAccessors);
            }
            return ListBindingHelper.GetListItemPropertiesByInstance(obj1, arrListAccessors, 0);
        }

        /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in the specified data member of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of an item type contained in a collection property of the specified data source.</returns>
        /// <param name="objDataSource">The data source to be examined for property information.</param>
        /// <param name="strDataMember">The optional data member to be examined for property information. This can be null.</param>
        /// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data member to examine. This can be null.</param>
        /// <exception cref="T:System.ArgumentException">The specified data member could not be found in the specified data source.</exception>
        public static PropertyDescriptorCollection GetListItemProperties(object objDataSource, string strDataMember, PropertyDescriptor[] arrListAccessors)
        {
            objDataSource = ListBindingHelper.GetList(objDataSource);
            if (!CommonUtils.IsNullOrEmpty(strDataMember))
            {
                PropertyDescriptor objPropertyDescriptor1 = ListBindingHelper.GetListItemProperties(objDataSource).Find(strDataMember, true);
                if (objPropertyDescriptor1 == null)
                {
                    throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", new object[] { strDataMember }));
                }
                int num1 = (arrListAccessors == null) ? 1 : (arrListAccessors.Length + 1);
                PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[num1];
                arrDescriptors[0] = objPropertyDescriptor1;
                for (int num2 = 1; num2 < num1; num2++)
                {
                    arrDescriptors[num2] = arrListAccessors[num2 - 1];
                }
                arrListAccessors = arrDescriptors;
            }
            return ListBindingHelper.GetListItemProperties(objDataSource, arrListAccessors);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable enumerable)
        {
            PropertyDescriptorCollection objCollection1 = null;
            Type objType1 = enumerable.GetType();
            if (typeof(Array).IsAssignableFrom(objType1))
            {
                objCollection1 = TypeDescriptor.GetProperties(objType1.GetElementType(), ListBindingHelper.BrowsableAttributeList);
            }
            else
            {
                ITypedList objList1 = enumerable as ITypedList;
                if (objList1 != null)
                {
                    objCollection1 = objList1.GetItemProperties(null);
                }
                else
                {
                    PropertyInfo objPropertyInfo = ListBindingHelper.GetTypedIndexer(objType1);
                    if ((objPropertyInfo != null) && !typeof(ICustomTypeDescriptor).IsAssignableFrom(objPropertyInfo.PropertyType))
                    {
                        objCollection1 = TypeDescriptor.GetProperties(objPropertyInfo.PropertyType, ListBindingHelper.BrowsableAttributeList);
                    }
                }
            }
            if (objCollection1 != null)
            {
                return objCollection1;
            }
            object obj1 = ListBindingHelper.GetFirstItemByEnumerable(enumerable);
            if (!(enumerable is string))
            {
                if (obj1 == null)
                {
                    return new PropertyDescriptorCollection(null);
                }
                objCollection1 = TypeDescriptor.GetProperties(obj1, ListBindingHelper.BrowsableAttributeList);
                if ((enumerable is IList) || ((objCollection1 != null) && (objCollection1.Count != 0)))
                {
                    return objCollection1;
                }
            }
            return TypeDescriptor.GetProperties(enumerable, ListBindingHelper.BrowsableAttributeList);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable enumerable, PropertyDescriptor[] arrListAccessors)
        {
            if ((arrListAccessors == null) || (arrListAccessors.Length == 0))
            {
                return ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable);
            }
            ITypedList objList1 = enumerable as ITypedList;
            if (objList1 != null)
            {
                return objList1.GetItemProperties(arrListAccessors);
            }
            return ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable, arrListAccessors, 0);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable iEnumerable, PropertyDescriptor[] arrListAccessors, int intStartIndex)
        {
            object obj1 = null;
            object obj2 = ListBindingHelper.GetFirstItemByEnumerable(iEnumerable);
            if (obj2 != null)
            {
                obj1 = ListBindingHelper.GetList(arrListAccessors[intStartIndex].GetValue(obj2));
            }
            if (obj1 == null)
            {
                return ListBindingHelper.GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType, arrListAccessors, intStartIndex);
            }
            intStartIndex++;
            IEnumerable enumerable1 = obj1 as IEnumerable;
            if (enumerable1 != null)
            {
                if (intStartIndex == arrListAccessors.Length)
                {
                    return ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable1);
                }
                return ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable1, arrListAccessors, intStartIndex);
            }
            return ListBindingHelper.GetListItemPropertiesByInstance(obj1, arrListAccessors, intStartIndex);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByInstance(object objTarget, PropertyDescriptor[] arrListAccessors, int intStartIndex)
        {
            if ((arrListAccessors != null) && (arrListAccessors.Length > intStartIndex))
            {
                object obj1 = arrListAccessors[intStartIndex].GetValue(objTarget);
                if (obj1 == null)
                {
                    return ListBindingHelper.GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType);
                }
                PropertyDescriptor[] arrDescriptors = null;
                if (arrListAccessors.Length > (intStartIndex + 1))
                {
                    int num1 = arrListAccessors.Length - (intStartIndex + 1);
                    arrDescriptors = new PropertyDescriptor[num1];
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        arrDescriptors[num2] = arrListAccessors[(intStartIndex + 1) + num2];
                    }
                }
                return ListBindingHelper.GetListItemProperties(obj1, arrDescriptors);
            }
            return TypeDescriptor.GetProperties(objTarget, ListBindingHelper.BrowsableAttributeList);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType)
        {
            return TypeDescriptor.GetProperties(ListBindingHelper.GetListItemType(objType), ListBindingHelper.BrowsableAttributeList);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType, PropertyDescriptor[] arrListAccessors)
        {
            if ((arrListAccessors == null) || (arrListAccessors.Length == 0))
            {
                return ListBindingHelper.GetListItemPropertiesByType(objType);
            }
            return ListBindingHelper.GetListItemPropertiesByType(objType, arrListAccessors, 0);
        }

        private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType, PropertyDescriptor[] arrListAccessors, int intStartIndex)
        {
            Type objType1 = arrListAccessors[intStartIndex].PropertyType;
            intStartIndex++;
            if (intStartIndex >= arrListAccessors.Length)
            {
                return ListBindingHelper.GetListItemProperties(objType1);
            }
            return ListBindingHelper.GetListItemPropertiesByType(objType1, arrListAccessors, intStartIndex);
        }

        /// <summary>Returns the data type of the items in the specified list.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the items contained in the list.</returns>
        /// <param name="objList">The list to be examined for type information. </param>
        public static Type GetListItemType(object objList)
        {
            if (objList == null)
            {
                return null;
            }
            Type objType2 = (objList is Type) ? (objList as Type) : objList.GetType();
            object obj1 = (objList is Type) ? null : objList;
            if (typeof(Array).IsAssignableFrom(objType2))
            {
                return objType2.GetElementType();
            }
            PropertyInfo objPropertyInfo = ListBindingHelper.GetTypedIndexer(objType2);
            if (objPropertyInfo != null)
            {
                return objPropertyInfo.PropertyType;
            }
            if (obj1 is IEnumerable)
            {
                return ListBindingHelper.GetListItemTypeByEnumerable(obj1 as IEnumerable);
            }
            return objType2;
        }

        /// <summary>Returns the data type of the items in the specified data source.</summary>
        /// <returns>For complex data binding, the <see cref="T:System.Type"></see> of the items represented by the dataMember in the data source; otherwise, the <see cref="T:System.Type"></see> of the item in the list itself.</returns>
        /// <param name="objDataSource">The data source to examine for items. </param>
        /// <param name="strDataMember">The optional name of the property on the data source that is to be used as the data member. This can be null.</param>
        public static Type GetListItemType(object objDataSource, string strDataMember)
        {
            if (objDataSource != null)
            {
                if (CommonUtils.IsNullOrEmpty(strDataMember))
                {
                    return ListBindingHelper.GetListItemType(objDataSource);
                }
                PropertyDescriptorCollection objCollection1 = ListBindingHelper.GetListItemProperties(objDataSource);
                if (objCollection1 == null)
                {
                    return typeof(object);
                }
                PropertyDescriptor objPropertyDescriptor1 = objCollection1.Find(strDataMember, true);
                if ((objPropertyDescriptor1 != null) && !(objPropertyDescriptor1.PropertyType is ICustomTypeDescriptor))
                {
                    return ListBindingHelper.GetListItemType(objPropertyDescriptor1.PropertyType);
                }
            }
            return typeof(object);
        }

        private static Type GetListItemTypeByEnumerable(IEnumerable iEnumerable)
        {
            object obj1 = ListBindingHelper.GetFirstItemByEnumerable(iEnumerable);
            if (obj1 == null)
            {
                return typeof(object);
            }
            return obj1.GetType();
        }

        /// <summary>Returns the name of an underlying list, given a data source and optional <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array.</summary>
        /// <returns>The name of the list in the data source, as described by listAccessors, orthe name of the data source type.</returns>
        /// <param name="objList">The data source to examine for the list name.</param>
        /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the data source. This can be null.</param>
        public static string GetListName(object objList, PropertyDescriptor[] arrListAccessors)
        {
            Type objType1;
            if (objList == null)
            {
                return string.Empty;
            }
            ITypedList objList1 = objList as ITypedList;
            if (objList1 != null)
            {
                return objList1.GetListName(arrListAccessors);
            }
            if ((arrListAccessors == null) || (arrListAccessors.Length == 0))
            {
                Type objType2 = objList as Type;
                if (objType2 != null)
                {
                    objType1 = objType2;
                }
                else
                {
                    objType1 = objList.GetType();
                }
            }
            else
            {
                PropertyDescriptor objPropertyDescriptor1 = arrListAccessors[0];
                objType1 = objPropertyDescriptor1.PropertyType;
            }
            return ListBindingHelper.GetListNameFromType(objType1);
        }

        private static string GetListNameFromType(Type objType)
        {
            if (typeof(Array).IsAssignableFrom(objType))
            {
                return objType.GetElementType().Name;
            }
            if (typeof(IList).IsAssignableFrom(objType))
            {
                PropertyInfo objPropertyInfo = ListBindingHelper.GetTypedIndexer(objType);
                if (objPropertyInfo != null)
                {
                    return objPropertyInfo.PropertyType.Name;
                }
                return objType.Name;
            }
            return objType.Name;
        }

        private static PropertyInfo GetTypedIndexer(Type objType)
        {
            if ((!typeof(IList).IsAssignableFrom(objType) && !typeof(ITypedList).IsAssignableFrom(objType)) && !typeof(IListSource).IsAssignableFrom(objType))
            {
                return null;
            }
            PropertyInfo objPropertyInfo = null;
            PropertyInfo[] arrPropertyInfos = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int num1 = 0; num1 < arrPropertyInfos.Length; num1++)
            {
                if ((arrPropertyInfos[num1].GetIndexParameters().Length > 0) && (arrPropertyInfos[num1].PropertyType != typeof(object)))
                {
                    objPropertyInfo = arrPropertyInfos[num1];
                    if (objPropertyInfo.Name == "Item")
                    {
                        return objPropertyInfo;
                    }
                }
            }
            return objPropertyInfo;
        }


        private static Attribute[] BrowsableAttributeList
        {
            get
            {
                if (ListBindingHelper.marrBrowsableAttribute == null)
                {
                    ListBindingHelper.marrBrowsableAttribute = new Attribute[] { new BrowsableAttribute(true) };
                }
                return ListBindingHelper.marrBrowsableAttribute;
            }
        }


        private static Attribute[] marrBrowsableAttribute;
    }

    #endregion

    #region PropertyManager Class

    /// <summary>Maintains a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between an object's property and a data-bound control property.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class PropertyManager : BindingManagerBase
    {
        private static readonly SerializableProperty boundProperty = SerializableProperty.Register("bound", typeof(bool), typeof(PropertyManager));

        private bool bound
        {
            get
            {
                return this.GetValue<bool>(PropertyManager.boundProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyManager.boundProperty, value);
            }
        }

        private static readonly SerializableProperty dataSourceProperty = SerializableProperty.Register("dataSource", typeof(object), typeof(PropertyManager));

        private object dataSource
        {
            get
            {
                return this.GetValue<object>(PropertyManager.dataSourceProperty);
            }
            set
            {
                this.SetValue<object>(PropertyManager.dataSourceProperty, value);
            }
        }

        [NonSerialized]
        private PropertyDescriptor mobjPropertyDescriptor;
        private string mstrPropName;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyManager"></see> class.</summary>
        public PropertyManager()
        {
        }

        internal PropertyManager(object objDataSource)
            : base(objDataSource)
        {
        }

        internal PropertyManager(object objDataSource, string strPropName)
        {
            this.mstrPropName = strPropName;
            this.SetDataSource(objDataSource);
        }

        /// <filterpriority>1</filterpriority>
        public override void AddNew()
        {
            throw new NotSupportedException(SR.GetString("DataBindingAddNewNotSupportedOnPropertyManager"));
        }

        /// <filterpriority>1</filterpriority>
        public override void CancelCurrentEdit()
        {
            IEditableObject obj1 = this.Current as IEditableObject;
            if (obj1 != null)
            {
                obj1.CancelEdit();
            }
            base.PushData();
        }

        /// <filterpriority>1</filterpriority>
        public override void EndCurrentEdit()
        {
            bool blnFlag1;
            base.PullData(out blnFlag1);
            if (blnFlag1)
            {
                IEditableObject obj1 = this.Current as IEditableObject;
                if (obj1 != null)
                {
                    obj1.EndEdit();
                }
            }
        }

        internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
        {
            return ListBindingHelper.GetListItemProperties(this.dataSource, arrListAccessors);
        }

        internal override string GetListName()
        {
            return (TypeDescriptor.GetClassName(this.dataSource) + "." + this.mstrPropName);
        }

        /// <summary>
        /// When overridden in a derived class, gets the name of the list supplying the data for the binding.
        /// </summary>
        /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties.</param>
        /// <returns>
        /// The name of the list supplying the data for the binding.
        /// </returns>
        protected internal override string GetListName(ArrayList objListAccessors)
        {
            return "";
        }

        /// <summary>
        /// Raises the <see cref="E:CurrentChanged"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected internal override void OnCurrentChanged(EventArgs objEventArgs)
        {
            base.PushData();
            FireCurrentChanged(this, objEventArgs);
            FireCurrentItemChanged(this, objEventArgs);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
        /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> containing the event data.</param>
        protected internal override void OnCurrentItemChanged(EventArgs objEventArgs)
        {
            base.PushData();
            FireCurrentItemChanged(this, objEventArgs);
        }

        private void PropertyChanged(object sender, EventArgs ea)
        {
            this.EndCurrentEdit();
            this.OnCurrentChanged(EventArgs.Empty);
        }

        /// <filterpriority>1</filterpriority>
        public override void RemoveAt(int index)
        {
            throw new NotSupportedException(SR.GetString("DataBindingRemoveAtNotSupportedOnPropertyManager"));
        }

        /// <filterpriority>1</filterpriority>
        public override void ResumeBinding()
        {
            this.OnCurrentChanged(new EventArgs());
            if (!this.bound)
            {
                try
                {
                    this.bound = true;
                    this.UpdateIsBinding();
                }
                catch
                {
                    this.bound = false;
                    this.UpdateIsBinding();
                    throw;
                }
            }
        }

        internal override void SetDataSource(object objDataSource)
        {
            if ((this.dataSource != null) && !CommonUtils.IsNullOrEmpty(this.mstrPropName))
            {
                this.mobjPropertyDescriptor.RemoveValueChanged(this.dataSource, new EventHandler(this.PropertyChanged));
                this.mobjPropertyDescriptor = null;
            }
            this.dataSource = objDataSource;
            if ((this.dataSource != null) && !CommonUtils.IsNullOrEmpty(this.mstrPropName))
            {
                this.mobjPropertyDescriptor = TypeDescriptor.GetProperties(objDataSource).Find(this.mstrPropName, true);
                if (this.mobjPropertyDescriptor == null)
                {
                    throw new ArgumentException(SR.GetString("PropertyManagerPropDoesNotExist", new object[] { this.mstrPropName, objDataSource.ToString() }));
                }
                this.mobjPropertyDescriptor.AddValueChanged(objDataSource, new EventHandler(this.PropertyChanged));
            }
        }

        /// <summary>Suspends the data binding between a data source and a data-bound property.</summary>
        /// <filterpriority>1</filterpriority>
        public override void SuspendBinding()
        {
            this.EndCurrentEdit();
            if (this.bound)
            {
                try
                {
                    this.bound = false;
                    this.UpdateIsBinding();
                }
                catch
                {
                    this.bound = true;
                    this.UpdateIsBinding();
                    throw;
                }
            }
        }

        /// <summary>Updates the current <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between a data binding and a data-bound property.</summary>
        protected override void UpdateIsBinding()
        {
            for (int num1 = 0; num1 < base.Bindings.Count; num1++)
            {
                base.Bindings[num1].UpdateIsBinding();
            }
        }


        internal override Type BindType
        {
            get
            {
                return this.dataSource.GetType();
            }
        }

        /// <filterpriority>1</filterpriority>
        public override int Count
        {
            get
            {
                return 1;
            }
        }

        /// <summary>Gets the object to which the data-bound property belongs.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the object to which the property belongs.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Current
        {
            get
            {
                return this.dataSource;
            }
        }

        internal override object DataSource
        {
            get
            {
                return this.dataSource;
            }
        }

        internal override bool IsBinding
        {
            get
            {
                return (this.dataSource != null);
            }
        }

        /// <filterpriority>1</filterpriority>
        public override int Position
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }



    }

    #endregion

    #region RelatedCurrencyManager Class


    [Serializable()]
    internal class RelatedCurrencyManager : CurrencyManager
    {
        private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register("dataField", typeof(string), typeof(RelatedCurrencyManager));

        private string dataField
        {
            get
            {
                return this.GetValue<string>(RelatedCurrencyManager.dataFieldProperty);
            }
            set
            {
                this.SetValue<string>(RelatedCurrencyManager.dataFieldProperty, value);
            }
        }

        [NonSerialized]
        private PropertyDescriptor fieldInfo;
        private bool mblnFieldInfoInitialized = false;

        private static readonly SerializableProperty ignoreParentCurrentItemChangedProperty = SerializableProperty.Register("ignoreParentCurrentItemChanged", typeof(bool), typeof(RelatedCurrencyManager));

        private bool ignoreParentCurrentItemChanged
        {
            get
            {
                return this.GetValue<bool>(RelatedCurrencyManager.ignoreParentCurrentItemChangedProperty);
            }
            set
            {
                this.SetValue<bool>(RelatedCurrencyManager.ignoreParentCurrentItemChangedProperty, value);
            }
        }

        private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register("parentManager", typeof(BindingManagerBase), typeof(RelatedCurrencyManager));

        private BindingManagerBase parentManager
        {
            get
            {
                return this.GetValue<BindingManagerBase>(RelatedCurrencyManager.parentManagerProperty);
            }
            set
            {
                this.SetValue<BindingManagerBase>(RelatedCurrencyManager.parentManagerProperty, value);
            }
        }

        internal RelatedCurrencyManager(BindingManagerBase objParentManager, string strDataField)
            : base(null)
        {
            this.Bind(objParentManager, strDataField);
        }

        internal void Bind(BindingManagerBase objParentManager, string strDataField)
        {
            this.UnwireParentManager(this.parentManager);
            this.parentManager = objParentManager;
            this.dataField = strDataField;
            this.fieldInfo = objParentManager.GetItemProperties().Find(strDataField, true);
            mblnFieldInfoInitialized = true;
            if ((this.fieldInfo == null) || !typeof(IList).IsAssignableFrom(this.fieldInfo.PropertyType))
            {
                throw new ArgumentException(SR.GetString("RelatedListManagerChild", new object[] { strDataField }));
            }
            base.finalType = this.fieldInfo.PropertyType;
            this.WireParentManager(this.parentManager);
            this.ParentManager_CurrentItemChanged(objParentManager, EventArgs.Empty);
        }

        /// <summary>
        /// Ensures the field info.
        /// </summary>
        private void EnsureFieldInfo()
        {
            if (mblnFieldInfoInitialized && this.fieldInfo == null)
            {
                this.Bind(this.parentManager, this.dataField);
            }
        }

        public override PropertyDescriptorCollection GetItemProperties()
        {
            return this.GetItemProperties(null);
        }

        internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
        {
            PropertyDescriptor[] arrDescriptors;
            if ((arrListAccessors != null) && (arrListAccessors.Length > 0))
            {
                arrDescriptors = new PropertyDescriptor[arrListAccessors.Length + 1];
                arrListAccessors.CopyTo(arrDescriptors, 1);
            }
            else
            {
                arrDescriptors = new PropertyDescriptor[1];
            }

            EnsureFieldInfo();

            arrDescriptors[0] = this.fieldInfo;
            return this.parentManager.GetItemProperties(arrDescriptors);
        }

        internal override string GetListName()
        {
            string strText1 = this.GetListName(new ArrayList());
            if (strText1.Length > 0)
            {
                return strText1;
            }
            return base.GetListName();
        }

        protected internal override string GetListName(ArrayList objListAccessors)
        {
            EnsureFieldInfo();
            objListAccessors.Insert(0, this.fieldInfo);
            return this.parentManager.GetListName(objListAccessors);
        }

        private void ParentManager_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.ignoreParentCurrentItemChanged)
            {
                return;
            }
            int num1 = base.listposition;
            try
            {
                base.PullData();
            }
            catch (Exception objException1)
            {
                base.OnDataError(objException1);
            }

            EnsureFieldInfo();

            if (this.parentManager is CurrencyManager)
            {
                CurrencyManager manager1 = (CurrencyManager)this.parentManager;
                if (manager1.Count > 0)
                {
                    this.SetDataSource(this.fieldInfo.GetValue(manager1.Current));
                    base.listposition = (this.Count > 0) ? 0 : -1;
                    goto Label_00BC;
                }
                manager1.AddNew();
                try
                {
                    this.ignoreParentCurrentItemChanged = true;
                    manager1.CancelCurrentEdit();
                    goto Label_00BC;
                }
                finally
                {
                    this.ignoreParentCurrentItemChanged = false;
                }
            }
            this.SetDataSource(this.fieldInfo.GetValue(this.parentManager.Current));
            base.listposition = (this.Count > 0) ? 0 : -1;
        Label_00BC:
            if (num1 != base.listposition)
            {
                this.OnPositionChanged(EventArgs.Empty);
            }
            this.OnCurrentChanged(EventArgs.Empty);
            this.OnCurrentItemChanged(EventArgs.Empty);
        }

        private void ParentManager_MetaDataChanged(object sender, EventArgs e)
        {
            base.OnMetaDataChanged(e);
        }

        private void UnwireParentManager(BindingManagerBase objBindingManagerBase)
        {
            if (objBindingManagerBase != null)
            {
                objBindingManagerBase.CurrentItemChanged -= new EventHandler(this.ParentManager_CurrentItemChanged);
                if (objBindingManagerBase is CurrencyManager)
                {
                    (objBindingManagerBase as CurrencyManager).MetaDataChanged -= new EventHandler(this.ParentManager_MetaDataChanged);
                }
            }
        }

        private void WireParentManager(BindingManagerBase objBindingManagerBase)
        {
            if (objBindingManagerBase != null)
            {
                objBindingManagerBase.CurrentItemChanged += new EventHandler(this.ParentManager_CurrentItemChanged);
                if (objBindingManagerBase is CurrencyManager)
                {
                    (objBindingManagerBase as CurrencyManager).MetaDataChanged += new EventHandler(this.ParentManager_MetaDataChanged);
                }
            }
        }
    }

    #endregion

    #region RelatedPropertyManager Class


    [Serializable()]
    internal class RelatedPropertyManager : PropertyManager
    {
        private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register("dataField", typeof(string), typeof(RelatedPropertyManager));

        private string dataField
        {
            get
            {
                return this.GetValue<string>(RelatedPropertyManager.dataFieldProperty);
            }
            set
            {
                this.SetValue<string>(RelatedPropertyManager.dataFieldProperty, value);
            }
        }

        [NonSerialized]
        private PropertyDescriptor fieldInfo;
        private bool mblnFieldInfoInitialized = false;

        private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register("parentManager", typeof(BindingManagerBase), typeof(RelatedPropertyManager));

        private BindingManagerBase parentManager
        {
            get
            {
                return this.GetValue<BindingManagerBase>(RelatedPropertyManager.parentManagerProperty);
            }
            set
            {
                this.SetValue<BindingManagerBase>(RelatedPropertyManager.parentManagerProperty, value);
            }
        }

        internal RelatedPropertyManager(BindingManagerBase objParentManager, string strDataField)
            : base(RelatedPropertyManager.GetCurrentOrNull(objParentManager), strDataField)
        {
            this.Bind(objParentManager, strDataField);
        }

        private void Bind(BindingManagerBase objParentManager, string strDataField)
        {
            this.parentManager = objParentManager;
            this.dataField = strDataField;
            this.fieldInfo = objParentManager.GetItemProperties().Find(strDataField, true);
            if (this.fieldInfo == null)
            {
                throw new ArgumentException(SR.GetString("RelatedListManagerChild", new object[] { strDataField }));
            }
            objParentManager.CurrentItemChanged += new EventHandler(this.ParentManager_CurrentItemChanged);
            this.Refresh();
        }

        /// <summary>
        /// Ensures the field info.
        /// </summary>
        private void EnsureFieldInfo()
        {
            if (mblnFieldInfoInitialized && this.fieldInfo == null)
            {
                this.Bind(this.parentManager, this.dataField);
            }
        }

        private static object GetCurrentOrNull(BindingManagerBase objParentManager)
        {
            if ((objParentManager.Position < 0) || (objParentManager.Position >= objParentManager.Count))
            {
                return null;
            }
            return objParentManager.Current;
        }

        internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
        {
            PropertyDescriptor[] arrDescriptors;
            if ((arrListAccessors != null) && (arrListAccessors.Length > 0))
            {
                arrDescriptors = new PropertyDescriptor[arrListAccessors.Length + 1];
                arrListAccessors.CopyTo(arrDescriptors, 1);
            }
            else
            {
                arrDescriptors = new PropertyDescriptor[1];
            }

            EnsureFieldInfo();

            arrDescriptors[0] = this.fieldInfo;
            return this.parentManager.GetItemProperties(arrDescriptors);
        }

        internal override string GetListName()
        {
            string strText1 = this.GetListName(new ArrayList());
            if (strText1.Length > 0)
            {
                return strText1;
            }
            return base.GetListName();
        }

        protected internal override string GetListName(ArrayList objListAccessors)
        {
            EnsureFieldInfo();

            objListAccessors.Insert(0, this.fieldInfo);
            return this.parentManager.GetListName(objListAccessors);
        }

        private void ParentManager_CurrentItemChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Refresh()
        {
            this.EndCurrentEdit();
            this.SetDataSource(RelatedPropertyManager.GetCurrentOrNull(this.parentManager));
            this.OnCurrentChanged(EventArgs.Empty);
        }


        internal override Type BindType
        {
            get
            {
                EnsureFieldInfo();

                return this.fieldInfo.PropertyType;
            }
        }

        public override object Current
        {
            get
            {
                if (this.DataSource == null)
                {
                    return null;
                }

                EnsureFieldInfo();

                return this.fieldInfo.GetValue(this.DataSource);
            }
        }
    }

    #endregion

    #region ListManagerBindingsCollection Class
    [DefaultEvent("CollectionChanged"), Serializable()]

    internal class ListManagerBindingsCollection : BindingsCollection
    {
        internal ListManagerBindingsCollection(BindingManagerBase objBindingManagerBase)
        {
            this.mobjBindingManagerBase = objBindingManagerBase;
        }

        protected override void AddCore(Binding objDataBinding)
        {
            if (objDataBinding == null)
            {
                throw new ArgumentNullException("dataBinding");
            }
            if (objDataBinding.BindingManagerBase == this.mobjBindingManagerBase)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionAdd1"), "dataBinding");
            }
            if (objDataBinding.BindingManagerBase != null)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionAdd2"), "dataBinding");
            }
            objDataBinding.SetListManager(this.mobjBindingManagerBase);
            base.AddCore(objDataBinding);
        }

        protected override void ClearCore()
        {
            int num1 = this.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                base[num2].SetListManager(null);
            }
            base.ClearCore();
        }

        protected override void RemoveCore(Binding objDataBinding)
        {
            if (objDataBinding.BindingManagerBase != this.mobjBindingManagerBase)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionForeign"));
            }
            objDataBinding.SetListManager(null);
            base.RemoveCore(objDataBinding);
        }


        private BindingManagerBase mobjBindingManagerBase;
    }
    #endregion

    #region ControlBindingsCollection Class

    /// <summary>Represents the collection of data bindings for a control.</summary>
    /// <filterpriority>2</filterpriority>
    [DefaultEvent("CollectionChanged")]
#if WG_NET46
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET452
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET451
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET45
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET40
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET35
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET2
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif

    [Serializable()]
    public class ControlBindingsCollection : BindingsCollection
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> class with the specified bindable control.</summary>
        /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</param>
        public ControlBindingsCollection(IBindableComponent objControl)
        {
            this.mobjControl = objControl;
        }

        /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
        /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
        /// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
        /// <exception cref="T:System.ArgumentException">The control property is already data-bound. </exception>
        /// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> does not specify a valid column of the <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSource"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        new public void Add(Binding objBinding)
        {
            base.Add(objBinding);
        }

        /// <summary>Creates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> using the specified control property name, data source, and data member, and adds it to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
        /// <param name="strDataMember">The property or list to bind to. </param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <exception cref="T:System.Exception">The propertyName is already data-bound. </exception>
        /// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
        /// <exception cref="T:System.Exception">The dataMember doesn't specify a valid member of the dataSource. </exception>
        /// <filterpriority>1</filterpriority>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember)
        {
            return this.Add(strPropertyName, objDataSource, strDataMember, false, this.DefaultDataSourceUpdateMode, null, string.Empty, null);
        }

        /// <summary>Creates a binding with the specified control property name, data source, data member, and information about whether formatting is enabled, and adds the binding to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind.</param>
        /// <exception cref="T:System.Exception">If formatting is disabled and the propertyName is neither a valid property of a control nor an empty string (""). </exception>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
        /// <filterpriority>1</filterpriority>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled)
        {
            return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, this.DefaultDataSourceUpdateMode, null, string.Empty, null);
        }

        /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, and adding the binding to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
        /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode)
        {
            return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, null, string.Empty, null);
        }

        /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
        /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue)
        {
            return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, string.Empty, null);
        }

        /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
        /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed.</param>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
        /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue, string strFormatString)
        {
            return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, null);
        }

        /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, setting the specified format provider, and adding the binding to the collection.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
        /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed</param>
        /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
        /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
        /// <param name="objFormatInfo">An implementation of <see cref="T:System.IFormatProvider"></see> to override default formatting behavior.</param>
        /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
        /// <param name="strDataMember">The property or list to bind to.</param>
        /// <param name="strPropertyName">The name of the control property to bind. </param>
        /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
        /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
        public Binding Add(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled, DataSourceUpdateMode enmUpdateMode, object objNullValue, string strFormatString, IFormatProvider objFormatInfo)
        {
            if (objDataSource == null)
            {
                throw new ArgumentNullException("dataSource");
            }
            Binding objBinding = new Binding(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, objFormatInfo);
            this.Add(objBinding);
            return objBinding;
        }

        /// <summary>Adds a binding to the collection.</summary>
        /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
        protected override void AddCore(Binding objDataBinding)
        {
            if (objDataBinding == null)
            {
                throw new ArgumentNullException("dataBinding");
            }
            if (objDataBinding.BindableComponent == this.mobjControl)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionAdd1"));
            }
            if (objDataBinding.BindableComponent != null)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionAdd2"));
            }
            objDataBinding.SetBindableComponent(this.mobjControl);
            base.AddCore(objDataBinding);
        }

        internal void CheckDuplicates(Binding objBinding)
        {
            if (objBinding.PropertyName.Length != 0)
            {
                for (int intNum = 0; intNum < this.Count; intNum++)
                {
                    if (((objBinding != base[intNum]) && (base[intNum].PropertyName.Length > 0)) && (string.Compare(objBinding.PropertyName, base[intNum].PropertyName, false, CultureInfo.InvariantCulture) == 0))
                    {
                        throw new ArgumentException(SR.GetString("BindingsCollectionDup"), "binding");
                    }
                }
            }
        }

        /// <summary>
        /// Clears the collection of any bindings.
        /// </summary>
        new public void Clear()
        {
            base.Clear();
        }

        /// <summary>Clears the bindings in the collection.</summary>
        protected override void ClearCore()
        {
            int num1 = this.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                base[num2].SetBindableComponent(null);
            }
            base.ClearCore();
        }

        /// <summary>
        /// Deletes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.
        /// </summary>
        /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove.</param>
        /// <exception cref="T:System.NullReferenceException">The binding is null. </exception>
        new public void Remove(Binding objBinding)
        {
            base.Remove(objBinding);
        }

        /// <summary>
        /// Deletes the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0, or it is greater than the number of bindings in the collection. </exception>
        new public void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        /// <summary>Removes the specified binding from the collection.</summary>
        /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove from the collection.</param>
        /// <exception cref="T:System.ArgumentException">The binding belongs to another <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see>.</exception>
        protected override void RemoveCore(Binding objDataBinding)
        {
            if (objDataBinding.BindableComponent != this.mobjControl)
            {
                throw new ArgumentException(SR.GetString("BindingsCollectionForeign"));
            }
            objDataBinding.SetBindableComponent(null);
            base.RemoveCore(objDataBinding);
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</returns>
        /// <filterpriority>1</filterpriority>
        public IBindableComponent BindableComponent
        {
            get
            {
                return this.mobjControl;
            }
        }

        /// <summary>Gets the control that the collection belongs to.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the collection belongs to.</returns>
        /// <filterpriority>1</filterpriority>
        public Control Control
        {
            get
            {
                return (this.mobjControl as Control);
            }
        }

        /// <summary>Gets or sets the default <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSourceUpdateMode"></see> for a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> in the collection.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</returns>
        public DataSourceUpdateMode DefaultDataSourceUpdateMode
        {
            get
            {
                return this.menmDefaultDataSourceUpdateMode;
            }
            set
            {
                this.menmDefaultDataSourceUpdateMode = value;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> specified by the control's property name.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> that binds the specified control property to a data source.</returns>
        /// <param name="strPropertyName">The name of the property on the data-bound control. </param>
        /// <filterpriority>1</filterpriority>
        public Binding this[string strPropertyName]
        {
            get
            {
                foreach (Binding objBinding in this)
                {
                    if (ClientUtils.IsEquals(objBinding.PropertyName, strPropertyName, StringComparison.OrdinalIgnoreCase))
                    {
                        return objBinding;
                    }
                }
                return null;
            }
        }


        internal IBindableComponent mobjControl;
        private DataSourceUpdateMode menmDefaultDataSourceUpdateMode;
    }
    #endregion

    #region CurrencyManager Class
    /// <summary>Manages a list of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class CurrencyManager : BindingManagerBase
    {
        /// <summary>Occurs when the current item has been altered.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatData")]
        public event ItemChangedEventHandler ItemChanged;
        /// <summary>Occurs when the list changes or an item in the list changes.</summary>
        /// <filterpriority>1</filterpriority>
        public event ListChangedEventHandler ListChanged;
        /// <summary>Occurs when the metadata of the <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.List"></see> has changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatData")]
        public event EventHandler MetaDataChanged;

        private bool mblnBound;
        private object mobjDataSource;
        /// <summary>Specifies the data type of the list.</summary>
        protected Type finalType;
        private bool mblnInChangeRecordState;
        private int mintLastGoodKnownRow;
        [NonSerialized]
        private IList mobjList;
        /// <summary>Specifies the current position of the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> in the list.</summary>
        protected int listposition;
        private bool mblnPullingData;
        private ItemChangedEventArgs mobjResetEvent;
        private bool mblnShouldBind;
        private bool mblnSuspendPushDataInCurrentChanged;

        internal CurrencyManager(object objDataSource)
        {
            this.mblnShouldBind = true;
            this.listposition = -1;
            this.mintLastGoodKnownRow = -1;
            this.mobjResetEvent = new ItemChangedEventArgs(-1);
            this.SetDataSource(objDataSource);
        }

        /// <summary>
        /// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
        /// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
        /// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
        /// and deserialized.
        /// </summary>
        private object[] marrSerializedDataViewNewRowValues;
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            marrSerializedDataViewNewRowValues = null;
            try
            {
                if ((this.List != null) && (this.List.GetType() == typeof(System.Data.DataView)))
                {
                    if (this.Position >= 0 && this.Position < this.List.Count && ((System.Data.DataRowView)this[this.Position]).IsNew)
                    {
                        marrSerializedDataViewNewRowValues = ((System.Data.DataRowView)this[this.Position]).Row.ItemArray;
                    }
                }
            }
            catch { }

            base.OnSerializableObjectSerializing(objWriter);
        }
        protected override void OnSerializableObjectDeserialized()
        {
            base.OnSerializableObjectDeserialized();
            if (marrSerializedDataViewNewRowValues != null)
            {
                object[] arrSerializedDataViewNewRowValues = marrSerializedDataViewNewRowValues;
                marrSerializedDataViewNewRowValues = null;

                // Add new row and load serialized row values
                this.UnwireEvents(this.List);
                if (this.List.GetType() == typeof(System.Data.DataView))
                {
                    System.Data.DataRowView objRowView = ((System.Data.DataView)this.List).AddNew();
                    objRowView.Row.ItemArray = arrSerializedDataViewNewRowValues;
                }
                this.WireEvents(this.List);

                marrSerializedDataViewNewRowValues = null;
            }
        }

        /// <summary>Adds a new item to the underlying list.</summary>
        /// <exception cref="T:System.NotSupportedException">The underlying data source does not implement <see cref="T:System.ComponentModel.IBindingList"></see>, or the data source has thrown an exception because the user has attempted to add a row to a read-only or fixed-size <see cref="T:System.Data.DataView"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        public override void AddNew()
        {
            IBindingList objList1 = this.List as IBindingList;
            if (objList1 == null)
            {
                throw new NotSupportedException(SR.GetString("CurrencyManagerCantAddNew"));
            }
            objList1.AddNew();
            this.ChangeRecordState(this.List.Count - 1, this.Position != (this.List.Count - 1), this.Position != (this.List.Count - 1), true, true);
        }

        /// <summary>Cancels the current edit operation.</summary>
        /// <filterpriority>1</filterpriority>
        public override void CancelCurrentEdit()
        {
            if (this.Count > 0)
            {
                object obj1 = ((this.Position >= 0) && (this.Position < this.List.Count)) ? this.List[this.Position] : null;
                IEditableObject obj2 = obj1 as IEditableObject;
                if (obj2 != null)
                {
                    obj2.CancelEdit();
                }
                if (!CommonUtils.IsMono)
                {
#if !WG_MONO
                    ICancelAddNew new1 = this.List as ICancelAddNew;
                    if (new1 != null)
                    {
                        new1.CancelNew(this.Position);
                    }
#endif
                }
                this.OnItemChanged(new ItemChangedEventArgs(this.Position));
                if (this.Position != -1)
                {
                    this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.Position));
                }
            }
        }

        private void ChangeRecordState(int intNewPosition, bool blnValidating, bool blnEndCurrentEdit, bool blnFirePositionChange, bool blnPullData)
        {
            if ((intNewPosition == -1) && (this.List.Count == 0))
            {
                if (this.listposition != -1)
                {
                    this.listposition = -1;
                    this.OnPositionChanged(EventArgs.Empty);
                }
            }
            else
            {
                if (((intNewPosition < 0) || (intNewPosition >= this.Count)) && this.IsBinding)
                {
                    throw new IndexOutOfRangeException(SR.GetString("ListManagerBadPosition"));
                }
                int num1 = this.listposition;
                if (blnEndCurrentEdit)
                {
                    this.mblnInChangeRecordState = true;
                    try
                    {
                        this.EndCurrentEdit();
                    }
                    finally
                    {
                        this.mblnInChangeRecordState = false;
                    }
                }
                if (blnValidating && blnPullData)
                {
                    this.CurrencyManager_PullData();
                }
                this.listposition = Math.Min(intNewPosition, this.Count - 1);
                if (blnValidating)
                {
                    this.OnCurrentChanged(EventArgs.Empty);
                }
                if ((num1 != this.listposition) && blnFirePositionChange)
                {
                    this.OnPositionChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>Throws an exception if there is no list, or the list is empty.</summary>
        /// <exception cref="T:System.Exception">There is no list, or the list is empty. </exception>
        protected void CheckEmpty()
        {
            if (((this.mobjDataSource == null) || (this.List == null)) || (this.List.Count == 0))
            {
                throw new InvalidOperationException(SR.GetString("ListManagerEmptyList"));
            }
        }

        private bool CurrencyManager_PullData()
        {
            bool blnFlag1 = true;
            this.mblnPullingData = true;
            try
            {
                base.PullData(out blnFlag1);
            }
            finally
            {
                this.mblnPullingData = false;
            }
            return blnFlag1;
        }

        private bool CurrencyManager_PushData()
        {
            if (this.mblnPullingData)
            {
                return false;
            }
            int num1 = this.listposition;
            if (this.mintLastGoodKnownRow == -1)
            {
                try
                {
                    base.PushData();
                }
                catch (Exception objException1)
                {
                    base.OnDataError(objException1);
                    this.FindGoodRow();
                }
                this.mintLastGoodKnownRow = this.listposition;
            }
            else
            {
                try
                {
                    base.PushData();
                }
                catch (Exception objException2)
                {
                    base.OnDataError(objException2);
                    this.listposition = this.mintLastGoodKnownRow;
                    base.PushData();
                }
                this.mintLastGoodKnownRow = this.listposition;
            }
            return (num1 != this.listposition);
        }

        /// <summary>Ends the current edit operation.</summary>
        /// <filterpriority>1</filterpriority>
        public override void EndCurrentEdit()
        {
            if ((this.Count > 0) && this.CurrencyManager_PullData())
            {
                object obj1 = ((this.Position >= 0) && (this.Position < this.List.Count)) ? this.List[this.Position] : null;
                IEditableObject obj2 = obj1 as IEditableObject;
                if (obj2 != null)
                {
                    obj2.EndEdit();
                }
#if !WG_MONO
                if (!CommonUtils.IsMono)
                {
                    ICancelAddNew new1 = this.List as ICancelAddNew;
                    if (new1 != null)
                    {
                        new1.EndNew(this.Position);
                    }
                }
#endif
            }
        }

        internal int Find(PropertyDescriptor objPropertyDescriptor, object objKey, bool blnKeepIndex)
        {
            if (objKey == null)
            {
                throw new ArgumentNullException("key");
            }
            if (((objPropertyDescriptor != null) && (this.List is IBindingList)) && ((IBindingList)this.List).SupportsSearching)
            {
                return ((IBindingList)this.List).Find(objPropertyDescriptor, objKey);
            }
            for (int num1 = 0; num1 < this.List.Count; num1++)
            {
                object obj1 = objPropertyDescriptor.GetValue(this.List[num1]);
                if (objKey.Equals(obj1))
                {
                    return num1;
                }
            }
            return -1;
        }

        private void FindGoodRow()
        {
            int num1 = this.List.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                this.listposition = num2;
                try
                {
                    base.PushData();
                }
                catch (Exception objException1)
                {
                    base.OnDataError(objException1);
                    goto Label_0031;
                }
                this.listposition = num2;
                return;
            Label_0031: ;
            }
            this.SuspendBinding();
            throw new InvalidOperationException(SR.GetString("DataBindingPushDataException"));
        }

        /// <summary>Gets the property descriptor collection for the underlying list.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> for the list.</returns>
        /// <filterpriority>1</filterpriority>
        public override PropertyDescriptorCollection GetItemProperties()
        {
            return this.GetItemProperties(null);
        }

        internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
        {
            return ListBindingHelper.GetListItemProperties(this.List, arrListAccessors);
        }

        internal override string GetListName()
        {
            if (this.List is ITypedList)
            {
                return ((ITypedList)this.List).GetListName(null);
            }
            return this.finalType.Name;
        }

        /// <summary>Gets the name of the list supplying the data for the binding using the specified set of bound properties.</summary>
        /// <returns>If successful, a <see cref="T:System.String"></see> containing name of the list supplying the data for the binding; otherwise, an <see cref="F:System.String.Empty"></see> string.</returns>
        /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> of properties to be found in the data source.</param>
        protected internal override string GetListName(ArrayList objListAccessors)
        {
            if (this.List is ITypedList)
            {
                PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[objListAccessors.Count];
                objListAccessors.CopyTo(arrDescriptors, 0);
                return ((ITypedList)this.List).GetListName(arrDescriptors);
            }
            return "";
        }

        internal ListSortDirection GetSortDirection()
        {
            if ((this.List is IBindingList) && ((IBindingList)this.List).SupportsSorting)
            {
                return ((IBindingList)this.List).SortDirection;
            }
            return ListSortDirection.Ascending;
        }

        internal PropertyDescriptor GetSortProperty()
        {
            if ((this.List is IBindingList) && ((IBindingList)this.List).SupportsSorting)
            {
                return ((IBindingList)this.List).SortProperty;
            }
            return null;
        }

        private void List_ListChanged(object sender, ListChangedEventArgs e)
        {
            ListChangedEventArgs args1;
            if ((e.ListChangedType == ListChangedType.ItemMoved) && (e.OldIndex < 0))
            {
                args1 = new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewIndex, e.OldIndex);
            }
            else if ((e.ListChangedType == ListChangedType.ItemMoved) && (e.NewIndex < 0))
            {
                args1 = new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldIndex, e.NewIndex);
            }
            else
            {
                args1 = e;
            }
            int num1 = this.listposition;
            this.UpdateLastGoodKnownRow(args1);
            this.UpdateIsBinding();
            if (this.List.Count == 0)
            {
                this.listposition = -1;
                if (num1 != -1)
                {
                    this.OnPositionChanged(EventArgs.Empty);
                    this.OnCurrentChanged(EventArgs.Empty);
                }
                if ((args1.ListChangedType == ListChangedType.Reset) && (e.NewIndex == -1))
                {
                    this.OnItemChanged(this.mobjResetEvent);
                }
                if (args1.ListChangedType == ListChangedType.ItemDeleted)
                {
                    this.OnItemChanged(this.mobjResetEvent);
                }
                if (((e.ListChangedType == ListChangedType.PropertyDescriptorAdded) || (e.ListChangedType == ListChangedType.PropertyDescriptorDeleted)) || (e.ListChangedType == ListChangedType.PropertyDescriptorChanged))
                {
                    this.OnMetaDataChanged(EventArgs.Empty);
                }
                this.OnListChanged(args1);
            }
            else
            {
                this.mblnSuspendPushDataInCurrentChanged = true;
                try
                {
                    switch (args1.ListChangedType)
                    {
                        case ListChangedType.Reset:
                            if ((this.listposition != -1) || (this.List.Count <= 0))
                            {
                                break;
                            }
                            this.ChangeRecordState(0, true, false, true, false);
                            goto Label_0174;

                        case ListChangedType.ItemAdded:
                            if ((args1.NewIndex > this.listposition) || (this.listposition >= (this.List.Count - 1)))
                            {
                                goto Label_0212;
                            }
                            this.ChangeRecordState(this.listposition + 1, true, true, this.listposition != (this.List.Count - 2), false);
                            this.UpdateIsBinding();
                            this.OnItemChanged(this.mobjResetEvent);
                            if (this.listposition == (this.List.Count - 1))
                            {
                                this.OnPositionChanged(EventArgs.Empty);
                            }
                            goto Label_040B;

                        case ListChangedType.ItemDeleted:
                            if (args1.NewIndex != this.listposition)
                            {
                                goto Label_02B0;
                            }
                            this.ChangeRecordState(Math.Min(this.listposition, this.Count - 1), true, false, true, false);
                            this.OnItemChanged(this.mobjResetEvent);
                            goto Label_040B;

                        case ListChangedType.ItemMoved:
                            if (args1.OldIndex != this.listposition)
                            {
                                goto Label_035F;
                            }
                            this.ChangeRecordState(args1.NewIndex, true, (this.Position > -1) && (this.Position < this.List.Count), true, false);
                            goto Label_039B;

                        case ListChangedType.ItemChanged:
                            if (args1.NewIndex == this.listposition)
                            {
                                this.OnCurrentItemChanged(EventArgs.Empty);
                            }
                            this.OnItemChanged(new ItemChangedEventArgs(args1.NewIndex));
                            goto Label_040B;

                        case ListChangedType.PropertyDescriptorAdded:
                        case ListChangedType.PropertyDescriptorDeleted:
                        case ListChangedType.PropertyDescriptorChanged:
                            this.mintLastGoodKnownRow = -1;
                            if ((this.listposition != -1) || (this.List.Count <= 0))
                            {
                                goto Label_03D4;
                            }
                            this.ChangeRecordState(0, true, false, true, false);
                            goto Label_0400;

                        default:
                            goto Label_040B;
                    }
                    this.ChangeRecordState(Math.Min(this.listposition, this.List.Count - 1), true, false, true, false);
                Label_0174:
                    this.UpdateIsBinding(false);
                    this.OnItemChanged(this.mobjResetEvent);
                    goto Label_040B;
                Label_0212:
                    if (((args1.NewIndex == this.listposition) && (this.listposition == (this.List.Count - 1))) && (this.listposition != -1))
                    {
                        this.OnCurrentItemChanged(EventArgs.Empty);
                    }
                    if (this.listposition == -1)
                    {
                        this.ChangeRecordState(0, false, false, true, false);
                    }
                    this.UpdateIsBinding();
                    this.OnItemChanged(this.mobjResetEvent);
                    goto Label_040B;
                Label_02B0:
                    if (args1.NewIndex < this.listposition)
                    {
                        this.ChangeRecordState(this.listposition - 1, true, false, true, false);
                        this.OnItemChanged(this.mobjResetEvent);
                        goto Label_040B;
                    }
                    this.OnItemChanged(this.mobjResetEvent);
                    goto Label_040B;
                Label_035F:
                    if (args1.NewIndex == this.listposition)
                    {
                        this.ChangeRecordState(args1.OldIndex, true, (this.Position > -1) && (this.Position < this.List.Count), true, false);
                    }
                Label_039B:
                    this.OnItemChanged(this.mobjResetEvent);
                    goto Label_040B;
                Label_03D4:
                    if (this.listposition > (this.List.Count - 1))
                    {
                        this.ChangeRecordState(this.List.Count - 1, true, false, true, false);
                    }
                Label_0400:
                    this.OnMetaDataChanged(EventArgs.Empty);
                Label_040B:
                    this.OnListChanged(args1);
                }
                finally
                {
                    this.mblnSuspendPushDataInCurrentChanged = false;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected internal override void OnCurrentChanged(EventArgs e)
        {
            if (!this.mblnInChangeRecordState)
            {
                int num1 = this.mintLastGoodKnownRow;
                bool blnFlag1 = false;
                if (!this.mblnSuspendPushDataInCurrentChanged)
                {
                    blnFlag1 = this.CurrencyManager_PushData();
                }
                if (this.Count > 0)
                {
                    object obj1 = this.List[this.Position];
                    if (obj1 is IEditableObject)
                    {
                        ((IEditableObject)obj1).BeginEdit();
                    }
                }
                try
                {
                    if (!blnFlag1 || (blnFlag1 && (num1 != -1)))
                    {

                        base.FireCurrentChanged(this, e);

                        base.FireCurrentItemChanged(this, e);

                    }
                }
                catch (Exception objException1)
                {
                    base.OnDataError(objException1);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected internal override void OnCurrentItemChanged(EventArgs e)
        {
            base.FireCurrentItemChanged(this, e);

        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.ItemChangedEventArgs"></see> that contains the event data. </param>
        protected virtual void OnItemChanged(ItemChangedEventArgs e)
        {
            bool blnFlag1 = false;
            if (((e.Index == this.listposition) || ((e.Index == -1) && (this.Position < this.Count))) && !this.mblnInChangeRecordState)
            {
                blnFlag1 = this.CurrencyManager_PushData();
            }
            try
            {

                // Raise event if needed
                ItemChangedEventHandler objEventHandler = this.ItemChanged;
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }
            }
            catch (Exception objException1)
            {
                base.OnDataError(objException1);
            }
            if (blnFlag1)
            {
                this.OnPositionChanged(EventArgs.Empty);
            }
        }

        private void OnListChanged(ListChangedEventArgs e)
        {

            // Raise event if needed
            ListChangedEventHandler objEventHandler = this.ListChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.MetaDataChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected internal void OnMetaDataChanged(EventArgs e)
        {

            // Raise event if needed
            EventHandler objEventHandler = this.MetaDataChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.PositionChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnPositionChanged(EventArgs e)
        {
            try
            {

                base.FirePositionChanged(this, e);
            }
            catch (Exception objException1)
            {
                base.OnDataError(objException1);
            }
        }

        /// <summary>Forces a repopulation of the data-bound list.</summary>
        /// <filterpriority>1</filterpriority>
        public void Refresh()
        {
            if (this.List.Count > 0)
            {
                if (this.listposition >= this.List.Count)
                {
                    this.mintLastGoodKnownRow = -1;
                    this.listposition = 0;
                }
            }
            else
            {
                this.listposition = -1;
            }
            this.List_ListChanged(this.List, new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        internal void Release()
        {
            this.UnwireEvents(this.List);
        }

        /// <summary>Removes the item at the specified index.</summary>
        /// <param name="index">The index of the item to remove from the list. </param>
        /// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
        /// <filterpriority>1</filterpriority>
        public override void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        /// <summary>Resumes data binding.</summary>
        /// <filterpriority>1</filterpriority>
        public override void ResumeBinding()
        {
            this.mintLastGoodKnownRow = -1;
            try
            {
                if (!this.mblnShouldBind)
                {
                    this.mblnShouldBind = true;
                    this.listposition = ((this.List != null) && (this.List.Count != 0)) ? 0 : -1;
                    this.UpdateIsBinding();
                }
            }
            catch
            {
                this.mblnShouldBind = false;
                this.UpdateIsBinding();
                throw;
            }
        }

        /// <summary>
        /// Sets the data source.
        /// </summary>
        /// <param name="objDataSource">The obj data source.</param>
        internal override void SetDataSource(object objDataSource)
        {
            if (this.mobjDataSource != objDataSource)
            {
                this.Release();
                this.mobjDataSource = objDataSource;
                this.mobjList = null;
                this.finalType = null;
                SetDataSourceInternal(objDataSource, true);
            }
        }

        /// <summary>
        /// Sets the data source internal.
        /// </summary>
        /// <param name="objDataSource">The obj data source.</param>
        /// <param name="blnUpdate">if set to <c>true</c> [BLN update].</param>
        private void SetDataSourceInternal(object objDataSource, bool blnUpdate)
        {
            object obj1 = objDataSource;
            if (obj1 is Array)
            {
                this.finalType = obj1.GetType();
                obj1 = (Array)obj1;
            }
            if (obj1 is IListSource)
            {
                obj1 = ((IListSource)obj1).GetList();
            }
            if (obj1 is IList)
            {
                if (this.finalType == null)
                {
                    this.finalType = obj1.GetType();
                }
                this.mobjList = (IList)obj1;
                this.WireEvents(this.mobjList);
                if (blnUpdate)
                {
                    if (this.mobjList.Count > 0)
                    {
                        this.listposition = 0;
                    }
                    else
                    {
                        this.listposition = -1;
                    }
                    this.OnItemChanged(this.mobjResetEvent);
                    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1, -1));
                    this.UpdateIsBinding();
                }
            }
            else
            {
                if (obj1 == null)
                {
                    throw new ArgumentNullException("dataSource");
                }
                throw new ArgumentException(SR.GetString("ListManagerSetDataSource", new object[] { obj1.GetType().FullName }), "dataSource");
            }
        }

        internal void SetSort(PropertyDescriptor objPropertyDescriptor, ListSortDirection sortDirection)
        {
            if ((this.List is IBindingList) && ((IBindingList)this.List).SupportsSorting)
            {
                ((IBindingList)this.List).ApplySort(objPropertyDescriptor, sortDirection);
            }
        }

        /// <summary>Suspends data binding to prevents changes from updating the bound data source.</summary>
        /// <filterpriority>1</filterpriority>
        public override void SuspendBinding()
        {
            this.mintLastGoodKnownRow = -1;
            if (this.mblnShouldBind)
            {
                this.mblnShouldBind = false;
                this.UpdateIsBinding();
            }
        }

        internal void UnwireEvents(IList objList)
        {
            if ((objList is IBindingList) && ((IBindingList)objList).SupportsChangeNotification)
            {
                ((IBindingList)objList).ListChanged -= new ListChangedEventHandler(this.List_ListChanged);
            }
        }

        /// <summary>Updates the status of the binding.</summary>
        protected override void UpdateIsBinding()
        {
            this.UpdateIsBinding(true);
        }

        private void UpdateIsBinding(bool blnRaiseItemChangedEvent)
        {
            bool blnFlag1 = (((this.List != null) && (this.List.Count > 0)) && this.mblnShouldBind) && (this.listposition != -1);
            if ((this.List != null) && (this.mblnBound != blnFlag1))
            {
                this.mblnBound = blnFlag1;
                int num1 = blnFlag1 ? 0 : -1;
                this.ChangeRecordState(num1, this.mblnBound, this.Position != num1, true, false);
                int num2 = base.Bindings.Count;
                for (int num3 = 0; num3 < num2; num3++)
                {
                    base.Bindings[num3].UpdateIsBinding();
                }
                if (blnRaiseItemChangedEvent)
                {
                    this.OnItemChanged(this.mobjResetEvent);
                }
            }
        }

        private void UpdateLastGoodKnownRow(ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    this.mintLastGoodKnownRow = -1;
                    return;

                case ListChangedType.ItemAdded:
                    if ((e.NewIndex <= this.mintLastGoodKnownRow) && (this.mintLastGoodKnownRow < (this.List.Count - 1)))
                    {
                        this.mintLastGoodKnownRow++;
                        return;
                    }
                    return;

                case ListChangedType.ItemDeleted:
                    if (e.NewIndex == this.mintLastGoodKnownRow)
                    {
                        this.mintLastGoodKnownRow = -1;
                        return;
                    }
                    return;

                case ListChangedType.ItemMoved:
                    if (e.OldIndex == this.mintLastGoodKnownRow)
                    {
                        this.mintLastGoodKnownRow = e.NewIndex;
                        return;
                    }
                    return;

                case ListChangedType.ItemChanged:
                    if (e.NewIndex == this.mintLastGoodKnownRow)
                    {
                        this.mintLastGoodKnownRow = -1;
                    }
                    return;
            }
        }

        internal void WireEvents(IList objList)
        {
            if ((objList is IBindingList) && ((IBindingList)objList).SupportsChangeNotification)
            {
                ((IBindingList)objList).ListChanged += new ListChangedEventHandler(this.List_ListChanged);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [allow add].
        /// </summary>
        /// <value><c>true</c> if [allow add]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool AllowAdd
        {
            get
            {
                if (this.List is IBindingList)
                {
                    return ((IBindingList)this.List).AllowNew;
                }
                if ((this.List != null) && !this.List.IsReadOnly)
                {
                    return !this.List.IsFixedSize;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [allow edit].
        /// </summary>
        /// <value><c>true</c> if [allow edit]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool AllowEdit
        {
            get
            {
                if (this.List is IBindingList)
                {
                    return ((IBindingList)this.List).AllowEdit;
                }
                if (this.List == null)
                {
                    return false;
                }
                return !this.List.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [allow remove].
        /// </summary>
        /// <value><c>true</c> if [allow remove]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool AllowRemove
        {
            get
            {
                if (this.List is IBindingList)
                {
                    return ((IBindingList)this.List).AllowRemove;
                }
                if ((this.List != null) && !this.List.IsReadOnly)
                {
                    return !this.List.IsFixedSize;
                }
                return false;
            }
        }

        internal override Type BindType
        {
            get
            {
                return ListBindingHelper.GetListItemType(this.List);
            }
        }

        /// <summary>Gets the number of items in the list.</summary>
        /// <returns>The number of items in the list.</returns>
        /// <filterpriority>1</filterpriority>
        public override int Count
        {
            get
            {
                if (this.List == null)
                {
                    return 0;
                }
                return this.List.Count;
            }
        }

        /// <summary>Gets the current item in the list.</summary>
        /// <returns>A list item of type <see cref="T:System.Object"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Current
        {
            get
            {
                return this[this.Position];
            }
        }

        internal override object DataSource
        {
            get
            {
                return this.mobjDataSource;
            }
        }

        internal override bool IsBinding
        {
            get
            {
                return this.mblnBound;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public object this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.List.Count))
                {
                    throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", new object[] { index.ToString(CultureInfo.CurrentCulture) }));
                }
                return this.List[index];
            }
            set
            {
                if ((index < 0) || (index >= this.List.Count))
                {
                    throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", new object[] { index.ToString(CultureInfo.CurrentCulture) }));
                }
                this.List[index] = value;
            }
        }

        /// <summary>Gets the list for this <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see>.</summary>
        /// <returns>An <see cref="T:System.Collections.IList"></see> that contains the list.</returns>
        /// <filterpriority>1</filterpriority>
        public IList List
        {
            get
            {
                if (mobjList == null && mobjDataSource != null)
                {
                    // Will only occur from serialization
                    SetDataSourceInternal(mobjDataSource, false);
                }
                return this.mobjList;
            }
        }

        /// <summary>Gets or sets the position you are at within the list.</summary>
        /// <returns>A number between 0 and <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.Count"></see> minus 1.</returns>
        /// <filterpriority>1</filterpriority>
        public override int Position
        {
            get
            {
                return this.listposition;
            }
            set
            {
                if (this.listposition != -1)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    int num1 = this.List.Count;
                    if (value >= num1)
                    {
                        value = num1 - 1;
                    }
                    this.ChangeRecordState(value, this.listposition != value, true, true, false);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [should bind].
        /// </summary>
        /// <value><c>true</c> if [should bind]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldBind
        {
            get
            {
                return this.mblnShouldBind;
            }
        }



    }
    #endregion

    #endregion

    #region Interfaces

    #region IBindableComponent Inteface

    /// <summary>Enables a non-control component to emulate the data-binding behavior of a Windows Forms control.</summary>
    /// <filterpriority>2</filterpriority>
    public interface IBindableComponent : IComponent, IDisposable
    {
        /// <summary>Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>. </summary>
        /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        Gizmox.WebGUI.Forms.BindingContext BindingContext { get; set; }

        /// <summary>Gets the collection of data-binding objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>. </returns>
        /// <filterpriority>1</filterpriority>
        ControlBindingsCollection DataBindings { get; }

    }

    #endregion

    #region ICurrencyManagerProvider Interface

    /// <summary>Provides custom binding management for components.</summary>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ICurrencyManagerProviderDescr")]
    public interface ICurrencyManagerProvider
    {
        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> for this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see> and the specified data member.</summary>
        /// <returns>The related <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> obtained from this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see> and the specified data member.</returns>
        /// <param name="strDataMember">The name of the column or list, within the data source, to obtain the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> for.</param>
        CurrencyManager GetRelatedCurrencyManager(string strDataMember);

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see>. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        CurrencyManager CurrencyManager { get; }

    }

    #endregion

    #endregion

    #region Events

    #region BindingManagerDataErrorEventArgs Class

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
    public delegate void BindingManagerDataErrorEventHandler(object sender, BindingManagerDataErrorEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event. </summary>
    public class BindingManagerDataErrorEventArgs : EventArgs
    {
        /// <summary>
        /// The internal exception
        /// </summary>
        private Exception mobjException;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs"></see> class. </summary>
        /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred in the binding process that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised.</param>
        public BindingManagerDataErrorEventArgs(Exception objException)
        {
            this.mobjException = objException;
        }


        /// <summary>Gets the <see cref="T:System.Exception"></see> caught in the binding process that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised.</summary>
        /// <returns>The <see cref="T:System.Exception"></see> that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to be raised. </returns>
        public Exception Exception
        {
            get
            {
                return this.mobjException;
            }
        }
    }

    #endregion

    #region BindingCompleteEventArgs Class

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event in data-binding scenarios. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void BindingCompleteEventHandler(object sender, BindingCompleteEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
    /// <filterpriority>2</filterpriority>
    public class BindingCompleteEventArgs : CancelEventArgs
    {
        private Binding mobjBinding;
        private BindingCompleteContext menmContext;
        private string mstrErrorText;
        private Exception mobjException;
        private BindingCompleteState menmState;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state, and binding context.</summary>
        /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
        /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
        /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
        public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext)
            : this(objBinding, enmBindingCompleteState, enmContext, string.Empty, null, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, and binding context.</summary>
        /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
        /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
        /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
        /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
        public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText)
            : this(objBinding, enmBindingCompleteState, enmContext, strErrorText, null, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, and exception.</summary>
        /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
        /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
        /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
        /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
        /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
        public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText, Exception objException)
            : this(objBinding, enmBindingCompleteState, enmContext, strErrorText, objException, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see> class with the specified binding, error state and text, binding context, exception, and whether the binding should be cancelled.</summary>
        /// <param name="objException">The <see cref="T:System.Exception"></see> that occurred during the binding.</param>
        /// <param name="enmContext">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </param>
        /// <param name="enmBindingCompleteState">One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</param>
        /// <param name="strErrorText">The error text or exception message for errors that occurred during the binding.</param>
        /// <param name="objBinding">The binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</param>
        /// <param name="blnCancel">true to cancel the binding and keep focus on the current control; false to allow focus to shift to another control.</param>
        public BindingCompleteEventArgs(Binding objBinding, BindingCompleteState enmBindingCompleteState, BindingCompleteContext enmContext, string strErrorText, Exception objException, bool blnCancel)
            : base(blnCancel)
        {
            this.mobjBinding = objBinding;
            this.menmState = enmBindingCompleteState;
            this.menmContext = enmContext;
            this.mstrErrorText = (strErrorText == null) ? string.Empty : strErrorText;
            this.mobjException = objException;
        }


        /// <summary>Gets the binding associated with this occurrence of a <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>.</returns>
        public Binding Binding
        {
            get
            {
                return this.mobjBinding;
            }
        }

        /// <summary>Gets the direction of the binding operation.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteContext"></see> values. </returns>
        public BindingCompleteContext BindingCompleteContext
        {
            get
            {
                return this.menmContext;
            }
        }

        /// <summary>Gets the completion state of the binding operation.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteState"></see> values.</returns>
        public BindingCompleteState BindingCompleteState
        {
            get
            {
                return this.menmState;
            }
        }

        /// <summary>Gets the text description of the error that occurred during the binding operation.</summary>
        /// <returns>The text description of the error that occurred during the binding operation.</returns>
        /// <filterpriority>1</filterpriority>
        public string ErrorText
        {
            get
            {
                return this.mstrErrorText;
            }
        }

        /// <summary>Gets the exception that occurred during the binding operation.</summary>
        /// <returns>The <see cref="T:System.Exception"></see> that occurred during the binding operation.</returns>
        /// <filterpriority>1</filterpriority>
        public Exception Exception
        {
            get
            {
                return this.mobjException;
            }
        }
    }
    #endregion

    #region ItemChangedEventArgs Class
    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> class.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ItemChangedEventHandler(object sender, ItemChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class ItemChangedEventArgs : EventArgs
    {
        internal ItemChangedEventArgs(int index)
        {
            this.index = index;
        }


        /// <summary>Indicates the position of the item being changed within the list.</summary>
        /// <returns>The zero-based index to the item being changed.</returns>
        /// <filterpriority>1</filterpriority>
        public int Index
        {
            get
            {
                return this.index;
            }
        }


        private int index;
    }
    #endregion

    #region ConvertEventArgs Class
    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> and <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> events.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class ConvertEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> class.</summary>
        /// <param name="objDesiredType">The <see cref="T:System.Type"></see> of the value. </param>
        /// <param name="objValue">An <see cref="T:System.Object"></see> that contains the value of the current property. </param>
        public ConvertEventArgs(object objValue, Type objDesiredType)
        {
            this.mobjValue = objValue;
            this.mobjDesiredType = objDesiredType;
        }


        /// <summary>Gets the data type of the desired value.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the desired value.</returns>
        /// <filterpriority>1</filterpriority>
        public Type DesiredType
        {
            get
            {
                return this.mobjDesiredType;
            }
        }

        /// <summary>Gets or sets the value of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see>.</summary>
        /// <returns>The value of the <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public object Value
        {
            get
            {
                return this.mobjValue;
            }
            set
            {
                this.mobjValue = value;
            }
        }


        private Type mobjDesiredType;
        private object mobjValue;
    }

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> and <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void ConvertEventHandler(object sender, ConvertEventArgs e);
    #endregion

    #endregion
}
