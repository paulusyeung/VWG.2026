#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// Represents the simple binding between the property value of an object and the property value of a control.</summary>
	/// 1</filterpriority>
	[Serializable]
	[TypeConverter(typeof(ListBindingConverter))]
	public class Binding : SerializableObject
	{
		/// 
		/// Provides design time attributes for the DataSource property
		/// </summary>
		[Editor("Gizmox.WebGUI.Forms.Design.DataSourceListEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.DataSourceConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		public interface IDataSourceAttributeProvider : IListSource
		{
		}

		/// 
		/// The BindingComplete event registration.
		/// </summary>
		private static readonly SerializableEvent BindingCompleteEvent;

		/// 
		/// The Format event registration.
		/// </summary>
		private static readonly SerializableEvent FormatEvent;

		/// 
		/// The Parse event registration.
		/// </summary>
		private static readonly SerializableEvent ParseEvent;

		private static readonly SerializableProperty BindingManagerBaseProperty;

		private BindToObject BindToObjectInternal;

		private static readonly SerializableProperty BoundProperty;

		private static readonly SerializableProperty ControlProperty;

		private static readonly SerializableProperty ControlUpdateModeProperty;

		private DataSourceUpdateMode DataSourceUpdateModeInternal;

		private object DataSourceNullValuePropertyInternal;

		private static readonly SerializableProperty DataSourceNullValueSetProperty;

		private IFormatProvider FormatInfoInternal;

		private string FormatStringInternal;

		private bool FormattingEnabledInternal;

		private static readonly SerializableProperty InOnBindingCompleteProperty;

		private static readonly SerializableProperty InPushOrPullProperty;

		private static readonly SerializableProperty InSetPropValueProperty;

		private static readonly SerializableProperty ModifiedProperty;

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

		/// 
		/// Gets the hanlder for the BindingComplete event.
		/// </summary>
		private BindingCompleteEventHandler BindingCompleteHandler => (BindingCompleteEventHandler)GetHandler(BindingComplete);

		/// 
		/// Gets the hanlder for the Format event.
		/// </summary>
		private ConvertEventHandler FormatHandler => (ConvertEventHandler)GetHandler(Format);

		/// 
		/// Gets the hanlder for the Parse event.
		/// </summary>
		private ConvertEventHandler ParseHandler => (ConvertEventHandler)GetHandler(Parse);

		private BindingManagerBase BindingManagerBaseInternal
		{
			get
			{
				return GetValue(BindingManagerBaseProperty);
			}
			set
			{
				SetValue(BindingManagerBaseProperty, value);
			}
		}

		private bool BoundInternal
		{
			get
			{
				return GetValue(BoundProperty);
			}
			set
			{
				SetValue(BoundProperty, value);
			}
		}

		private IBindableComponent ControlInternal
		{
			get
			{
				return GetValue(ControlProperty);
			}
			set
			{
				SetValue(ControlProperty, value);
			}
		}

		private ControlUpdateMode ControlUpdateModeInternal
		{
			get
			{
				return GetValue(ControlUpdateModeProperty);
			}
			set
			{
				SetValue(ControlUpdateModeProperty, value);
			}
		}

		private bool DataSourceNullValueSetInternal
		{
			get
			{
				return GetValue(DataSourceNullValueSetProperty);
			}
			set
			{
				SetValue(DataSourceNullValueSetProperty, value);
			}
		}

		private bool InOnBindingCompleteInternal
		{
			get
			{
				return GetValue(InOnBindingCompleteProperty);
			}
			set
			{
				SetValue(InOnBindingCompleteProperty, value);
			}
		}

		private bool InPushOrPullInternal
		{
			get
			{
				return GetValue(InPushOrPullProperty);
			}
			set
			{
				SetValue(InPushOrPullProperty, value);
			}
		}

		private bool InSetPropValueInternal
		{
			get
			{
				return GetValue(InSetPropValueProperty);
			}
			set
			{
				SetValue(InSetPropValueProperty, value);
			}
		}

		private bool ModifiedInternal
		{
			get
			{
				return GetValue(ModifiedProperty);
			}
			set
			{
				SetValue(ModifiedProperty, value);
			}
		}

		private TypeConverter PropInfoConverter
		{
			get
			{
				EnsurePropropertyInfoConverterInternal();
				if (PropropertyInfoConverterInternal == null)
				{
					EnsurePropInfoConverter();
				}
				return PropropertyInfoConverterInternal;
			}
		}

		/// Gets the control the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> is associated with.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		[DefaultValue(null)]
		public IBindableComponent BindableComponent => ControlInternal;

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.
		/// </summary>
		/// The binding manager base.</value>
		/// The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that manages this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		public BindingManagerBase BindingManagerBase => BindingManagerBaseInternal;

		/// 
		/// Gets an object that contains information about this binding based on the dataMember parameter in the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> constructor.
		/// </summary>
		/// The binding member info.</value>
		/// A <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> that contains information about this <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
		public BindingMemberInfo BindingMemberInfo => BindToObjectInternal.BindingMemberInfo;

		internal BindToObject BindToObject => BindToObjectInternal;

		internal bool ComponentCreated => IsComponentCreated(ControlInternal);

		/// Gets the control that the binding belongs to.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the binding belongs to.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		[DefaultValue(null)]
		public Control Control => ControlInternal as Control;

		/// Gets or sets when changes to the data source are propagated to the bound control property.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ControlUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnPropertyChanged"></see>.</returns>
		[DefaultValue(0)]
		public ControlUpdateMode ControlUpdateMode
		{
			get
			{
				return ControlUpdateModeInternal;
			}
			set
			{
				if (ControlUpdateModeInternal != value)
				{
					ControlUpdateModeInternal = value;
					if (IsBinding)
					{
						PushData();
					}
				}
			}
		}

		/// Gets the data source for this binding.</summary>
		/// An <see cref="T:System.Object"></see> that represents the data source.</returns>
		/// 1</filterpriority>
		public object DataSource => BindToObjectInternal.DataSource;

		/// Gets or sets the value to be stored in the data source if the control value is null or empty.</summary>
		/// The <see cref="T:System.Object"></see> to be stored in the data source when the control property is empty or null. The default is <see cref="T:System.DBNull"></see> for value types and null for non-value types.</returns>
		public object DataSourceNullValue
		{
			get
			{
				return DataSourceNullValuePropertyInternal;
			}
			set
			{
				if (object.Equals(DataSourceNullValuePropertyInternal, value))
				{
					return;
				}
				object dataSourceNullValuePropertyInternal = DataSourceNullValuePropertyInternal;
				DataSourceNullValuePropertyInternal = value;
				DataSourceNullValueSetInternal = true;
				if (IsBinding)
				{
					object value2 = BindToObjectInternal.GetValue();
					if (Formatter.IsNullData(value2, dataSourceNullValuePropertyInternal))
					{
						WriteValue();
					}
					if (Formatter.IsNullData(value2, value))
					{
						ReadValue();
					}
				}
			}
		}

		/// Gets or sets when changes to the bound control property are propagated to the data source.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ControlUpdateMode.OnValidation"></see>.</returns>
		[DefaultValue(DataSourceUpdateMode.OnPropertyChanged)]
		public DataSourceUpdateMode DataSourceUpdateMode
		{
			get
			{
				return DataSourceUpdateModeInternal;
			}
			set
			{
				if (DataSourceUpdateModeInternal != value)
				{
					DataSourceUpdateModeInternal = value;
				}
			}
		}

		/// Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior.</summary>
		/// The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
		/// 1</filterpriority>
		[DefaultValue(null)]
		public IFormatProvider FormatInfo
		{
			get
			{
				return FormatInfoInternal;
			}
			set
			{
				if (FormatInfoInternal != value)
				{
					FormatInfoInternal = value;
					if (IsBinding)
					{
						PushData();
					}
				}
			}
		}

		/// Gets or sets the format specifier characters that indicate how a value is to be displayed.</summary>
		/// The string of format specifier characters that indicate how a value is to be displayed.</returns>
		/// 1</filterpriority>
		public string FormatString
		{
			get
			{
				return FormatStringInternal;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (!value.Equals(FormatStringInternal))
				{
					FormatStringInternal = value;
					if (IsBinding)
					{
						PushData();
					}
				}
			}
		}

		/// Gets or sets a value indicating whether formatting is applied to the control property data.</summary>
		/// true if formatting of control property data is enabled; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public bool FormattingEnabled
		{
			get
			{
				return FormattingEnabledInternal;
			}
			set
			{
				if (FormattingEnabledInternal != value)
				{
					FormattingEnabledInternal = value;
					if (IsBinding)
					{
						PushData();
					}
				}
			}
		}

		internal bool IsBindable
		{
			get
			{
				if (ControlInternal != null && PropertyNameInternal.Length > 0 && BindToObjectInternal.DataSource != null)
				{
					return BindingManagerBase != null;
				}
				return false;
			}
		}

		/// Gets a value indicating whether the binding is active.</summary>
		/// true if the binding is active; otherwise, false.</returns>
		/// 1</filterpriority>
		public bool IsBinding => BoundInternal;

		/// 
		/// Gets a value indicating whether [in set prop value].
		/// </summary>
		/// true</c> if [in set prop value]; otherwise, false</c>.</value>
		internal bool InSetPropValue => InSetPropValueInternal;

		/// Gets or sets the <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. </summary>
		/// The <see cref="T:System.Object"></see> to be set as the control property when the data source contains a <see cref="T:System.DBNull"></see> value. The default is null.</returns>
		/// 1</filterpriority>
		public object NullValue
		{
			get
			{
				return NullValueInternal;
			}
			set
			{
				if (!object.Equals(NullValueInternal, value))
				{
					NullValueInternal = value;
					if (IsBinding && Formatter.IsNullData(BindToObjectInternal.GetValue(), DataSourceNullValuePropertyInternal))
					{
						PushData();
					}
				}
			}
		}

		/// Gets or sets the name of the control's data-bound property.</summary>
		/// The name of a control property to bind to.</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		public string PropertyName => PropertyNameInternal;

		/// Occurs when a binding operation is complete, such as when data is pushed to the control property from the data source or vice versa</summary>
		public event BindingCompleteEventHandler BindingComplete
		{
			add
			{
				AddHandler(BindingCompleteEvent, value);
			}
			remove
			{
				RemoveHandler(BindingCompleteEvent, value);
			}
		}

		/// Occurs when the property of a control is bound to a data value.</summary>
		/// 1</filterpriority>
		public event ConvertEventHandler Format
		{
			add
			{
				AddHandler(FormatEvent, value);
			}
			remove
			{
				RemoveHandler(FormatEvent, value);
			}
		}

		/// Occurs when the value of a data-bound control changes.</summary>
		/// 1</filterpriority>
		public event ConvertEventHandler Parse
		{
			add
			{
				AddHandler(ParseEvent, value);
			}
			remove
			{
				RemoveHandler(ParseEvent, value);
			}
		}

		private Binding()
		{
			PropertyNameInternal = "";
			FormatStringInternal = string.Empty;
			DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue(null);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that simple-binds the indicated control property to the specified data member of the data source.</summary>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
		/// <param name="strDataMember">The property or list to bind to. </param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <exception cref="T:System.Exception">propertyName is neither a valid property of a control nor an empty string (""). </exception>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.</exception>
		public Binding(string strPropertyName, object objDataSource, string strDataMember)
			: this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled: false, DataSourceUpdateMode.OnValidation, null, string.Empty, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the indicated control property to the specified data member of the data source, and optionally enables formatting to be applied.</summary>
		/// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
		/// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false. </param>
		/// <param name="strDataMember">The property or list to bind to. </param>
		/// <param name="strPropertyName">The name of the control property to bind. </param>
		/// <exception cref="T:System.Exception">Formatting is disabled and propertyName is neither a valid property of a control nor an empty string (""). </exception>
		/// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
		public Binding(string strPropertyName, object objDataSource, string strDataMember, bool blnFormattingEnabled)
			: this(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, DataSourceUpdateMode.OnValidation, null, string.Empty, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the specified control property to the specified data member of the specified data source. Optionally enables formatting and propagates values to the data source based on the specified update setting.</summary>
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

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the indicated the specified control property to the specified data member of the specified data source. Optionally enables formatting, propagates values to the data source based on the specified update setting, and sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source.</summary>
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

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class that binds the specified control property to the specified data member of the specified data source. Optionally enables formatting with the specified format string; propagates values to the data source based on the specified update setting; enables formatting with the specified format string; and sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source and sets the specified format provider.</summary>
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

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> class with the specified control property to the specified data member of the specified data source. Optionally enables formatting with the specified format string; propagates values to the data source based on the specified update setting; enables formatting with the specified format string; sets the property to the specified value when a <see cref="T:System.DBNull"></see> is returned from the data source; and sets the specified format provider.</summary>
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
			PropertyNameInternal = "";
			FormatStringInternal = string.Empty;
			DataSourceNullValuePropertyInternal = Formatter.GetDefaultDataSourceNullValue(null);
			BindToObjectInternal = new BindToObject(this, objDataSource, strDataMember);
			PropertyNameInternal = strPropertyName;
			FormattingEnabledInternal = blnFormattingEnabled;
			FormatStringInternal = strFormatString;
			NullValueInternal = objNullValue;
			FormatInfoInternal = objFormatInfo;
			FormattingEnabledInternal = blnFormattingEnabled;
			DataSourceUpdateModeInternal = enmDataSourceUpdateMode;
			CheckBinding();
		}

		private void binding_MetaDataChanged(object sender, EventArgs e)
		{
			CheckBinding();
		}

		private void BindTarget(bool bind)
		{
			EnsurePropertyInfoInternal();
			if (bind)
			{
				if (IsBinding)
				{
					if (PropertyInfoInternal != null && ControlInternal != null)
					{
						EventHandler handler = Target_PropertyChanged;
						PropertyInfoInternal.AddValueChanged(ControlInternal, handler);
					}
					EnsureValidateInfoInternal();
					if (ValidateInfoInternal != null)
					{
						CancelEventHandler value = Target_Validate;
						ValidateInfoInternal.AddEventHandler(ControlInternal, value);
					}
				}
			}
			else
			{
				if (PropertyInfoInternal != null && ControlInternal != null)
				{
					EventHandler handler2 = Target_PropertyChanged;
					PropertyInfoInternal.RemoveValueChanged(ControlInternal, handler2);
				}
				EnsureValidateInfoInternal();
				if (ValidateInfoInternal != null)
				{
					CancelEventHandler value2 = Target_Validate;
					ValidateInfoInternal.RemoveEventHandler(ControlInternal, value2);
				}
			}
		}

		private void CheckBinding()
		{
			BindToObjectInternal.CheckBinding();
			if (ControlInternal == null || PropertyNameInternal.Length <= 0)
			{
				PropertyInfoInternal = null;
				ValidateInfoInternal = null;
			}
			else
			{
				PropertyDescriptor propertyDescriptor = InitPropInfoConverter();
				if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(bool) && !propertyDescriptor.IsReadOnly)
				{
					PropropertyIsNullInfoInternal = propertyDescriptor;
					SetState(BindingState.PropropertyIsNullInfoInternal, PropropertyIsNullInfoInternal != null);
				}
				EventDescriptor eventDescriptor = null;
				string strB = "Validating";
				EventDescriptorCollection events = TypeDescriptor.GetEvents(ControlInternal);
				for (int i = 0; i < events.Count; i++)
				{
					if (eventDescriptor == null && ClientUtils.IsEquals(events[i].Name, strB, StringComparison.OrdinalIgnoreCase))
					{
						eventDescriptor = events[i];
						break;
					}
				}
				ValidateInfoInternal = eventDescriptor;
				SetState(BindingState.ValidateInfoInternal, ValidateInfoInternal != null);
			}
			UpdateIsBinding();
		}

		/// 
		/// We seperated this function from CheckBinding() because we added [NonSerialized] attr
		/// to the private TypeConverter propInfoConverter;
		/// this to support sessionState = CustomSqlDatabase.
		/// We have replaced this.propInfoConverter with a PropInfoConverter{} property,
		/// there we check if the value of propInfoConverter is null(after Deserialization)
		/// and if so we restore its value.
		/// </summary>
		/// descriptor2</returns>
		private PropertyDescriptor InitPropInfoConverter()
		{
			ControlInternal.DataBindings.CheckDuplicates(this);
			Type type = ControlInternal.GetType();
			string strB = PropertyNameInternal + "IsNull";
			PropertyDescriptor propertyDescriptor = null;
			PropertyDescriptor propertyDescriptor2 = null;
			InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(ControlInternal)[typeof(InheritanceAttribute)];
			PropertyDescriptorCollection propertyDescriptorCollection = ((inheritanceAttribute == null || inheritanceAttribute.InheritanceLevel == InheritanceLevel.NotInherited) ? TypeDescriptor.GetProperties(ControlInternal) : TypeDescriptor.GetProperties(type));
			for (int i = 0; i < propertyDescriptorCollection.Count; i++)
			{
				if (propertyDescriptor == null && ClientUtils.IsEquals(propertyDescriptorCollection[i].Name, PropertyNameInternal, StringComparison.OrdinalIgnoreCase))
				{
					propertyDescriptor = propertyDescriptorCollection[i];
					if (propertyDescriptor2 != null)
					{
						break;
					}
				}
				if (propertyDescriptor2 == null && ClientUtils.IsEquals(propertyDescriptorCollection[i].Name, strB, StringComparison.OrdinalIgnoreCase))
				{
					propertyDescriptor2 = propertyDescriptorCollection[i];
					if (propertyDescriptor != null)
					{
						break;
					}
				}
			}
			if (propertyDescriptor == null)
			{
				throw new ArgumentException(SR.GetString("ListBindingBindProperty", PropertyNameInternal), "PropertyName");
			}
			if (propertyDescriptor.IsReadOnly && ControlUpdateModeInternal != ControlUpdateMode.Never)
			{
				throw new ArgumentException(SR.GetString("ListBindingBindPropertyReadOnly", PropertyNameInternal), "PropertyName");
			}
			PropertyInfoInternal = propertyDescriptor;
			SetState(BindingState.PropertyInfoInternal, PropertyInfoInternal != null);
			Type propertyType = PropertyInfoInternal.PropertyType;
			PropropertyInfoConverterInternal = PropertyInfoInternal.Converter;
			SetState(BindingState.PropropertyInfoConverterInternal, PropropertyInfoConverterInternal != null);
			return propertyDescriptor2;
		}

		internal bool ControlAtDesignTime()
		{
			IComponent controlInternal = ControlInternal;
			if (controlInternal == null)
			{
				return false;
			}
			return controlInternal.Site?.DesignMode ?? false;
		}

		private BindingCompleteEventArgs CreateBindingCompleteEventArgs(BindingCompleteContext enmContext, Exception objException)
		{
			bool blnCancel = false;
			string empty = string.Empty;
			BindingCompleteState enmBindingCompleteState = BindingCompleteState.Success;
			if (objException != null)
			{
				empty = objException.Message;
				enmBindingCompleteState = BindingCompleteState.Exception;
				blnCancel = true;
			}
			else
			{
				empty = BindToObject.DataErrorText;
				if (!CommonUtils.IsNullOrEmpty(empty))
				{
					enmBindingCompleteState = BindingCompleteState.DataError;
				}
			}
			return new BindingCompleteEventArgs(this, enmBindingCompleteState, enmContext, empty, objException, blnCancel);
		}

		private object FormatObject(object objValue)
		{
			if (!ControlAtDesignTime())
			{
				EnsurePropertyInfoInternal();
				Type propertyType = PropertyInfoInternal.PropertyType;
				if (FormattingEnabledInternal)
				{
					ConvertEventArgs e = new ConvertEventArgs(objValue, propertyType);
					OnFormat(e);
					if (e.Value != objValue)
					{
						return e.Value;
					}
					TypeConverter objSourceConverter = null;
					if (BindToObjectInternal.FieldInfo != null)
					{
						objSourceConverter = BindToObjectInternal.FieldInfo.Converter;
					}
					return Formatter.FormatObject(objValue, propertyType, objSourceConverter, PropInfoConverter, FormatStringInternal, FormatInfoInternal, NullValueInternal, DataSourceNullValuePropertyInternal);
				}
				ConvertEventArgs e2 = new ConvertEventArgs(objValue, propertyType);
				OnFormat(e2);
				object value = e2.Value;
				if (propertyType != typeof(object))
				{
					if (value == null || (!value.GetType().IsSubclassOf(propertyType) && value.GetType() != propertyType))
					{
						TypeConverter converter = TypeDescriptor.GetConverter((objValue != null) ? objValue.GetType() : typeof(object));
						if (converter == null || !converter.CanConvertTo(propertyType))
						{
							if (objValue is IConvertible)
							{
								value = Convert.ChangeType(objValue, propertyType, CultureInfo.CurrentCulture);
								if (value != null && (value.GetType().IsSubclassOf(propertyType) || value.GetType() == propertyType))
								{
									return value;
								}
							}
							throw new FormatException(SR.GetString("ListBindingFormatFailed"));
						}
						return converter.ConvertTo(objValue, propertyType);
					}
					return value;
				}
				return objValue;
			}
			return objValue;
		}

		private void FormLoaded(object sender, EventArgs e)
		{
			CheckBinding();
		}

		private object GetDataSourceNullValue(Type objType)
		{
			if (!DataSourceNullValueSetInternal)
			{
				return Formatter.GetDefaultDataSourceNullValue(objType);
			}
			return DataSourceNullValuePropertyInternal;
		}

		private object GetPropValue()
		{
			bool flag = false;
			EnsurePropropertyIsNullInfoInternal();
			if (PropropertyIsNullInfoInternal != null)
			{
				flag = (bool)PropropertyIsNullInfoInternal.GetValue(ControlInternal);
			}
			if (flag)
			{
				return DataSourceNullValue;
			}
			EnsurePropertyInfoInternal();
			object obj = PropertyInfoInternal.GetValue(ControlInternal);
			if (obj == null)
			{
				obj = DataSourceNullValue;
			}
			return obj;
		}

		internal static bool IsComponentCreated(IBindableComponent component)
		{
			if (component is Control)
			{
				return true;
			}
			return true;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.BindingComplete"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
		protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
		{
			if (InOnBindingCompleteInternal)
			{
				return;
			}
			try
			{
				InOnBindingCompleteInternal = true;
				if (BindingCompleteHandler != null)
				{
					BindingCompleteHandler(this, e);
				}
			}
			catch (Exception objException)
			{
				if (ClientUtils.IsSecurityOrCriticalException(objException))
				{
					throw;
				}
				e.Cancel = true;
			}
			finally
			{
				InOnBindingCompleteInternal = false;
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Format"></see> event.</summary>
		/// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
		protected virtual void OnFormat(ConvertEventArgs objCevent)
		{
			FormatHandler?.Invoke(this, objCevent);
			object value = objCevent.Value;
			Type desiredType = objCevent.DesiredType;
			if (!FormattingEnabledInternal && !(value is DBNull) && desiredType != null && !desiredType.IsInstanceOfType(value) && value is IConvertible)
			{
				objCevent.Value = Convert.ChangeType(value, desiredType, CultureInfo.CurrentCulture);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Binding.Parse"></see> event.</summary>
		/// <param name="objCevent">A <see cref="T:Gizmox.WebGUI.Forms.ConvertEventArgs"></see> that contains the event data. </param>
		protected virtual void OnParse(ConvertEventArgs objCevent)
		{
			ParseHandler?.Invoke(this, objCevent);
			object value = objCevent.Value;
			Type desiredType = objCevent.DesiredType;
			if (!FormattingEnabledInternal && !(value is DBNull) && value != null && desiredType != null && !desiredType.IsInstanceOfType(value) && value is IConvertible)
			{
				objCevent.Value = Convert.ChangeType(value, desiredType, CultureInfo.CurrentCulture);
			}
		}

		/// 
		/// Ensures the property info internal.
		/// </summary>
		private void EnsurePropertyInfoInternal()
		{
			if (GetState(BindingState.PropertyInfoInternal) && PropertyInfoInternal == null)
			{
				EnsurePropInfoConverter();
			}
		}

		/// 
		/// Ensures the prop info converter.
		/// </summary>
		private void EnsurePropInfoConverter()
		{
			if (ControlInternal != null && PropertyNameInternal.Length > 0)
			{
				InitPropInfoConverter();
			}
		}

		/// 
		/// Ensures the proproperty info converter internal.
		/// </summary>
		private void EnsurePropropertyInfoConverterInternal()
		{
			if (GetState(BindingState.PropropertyInfoConverterInternal) && PropropertyInfoConverterInternal == null)
			{
				EnsurePropInfoConverter();
			}
		}

		/// 
		/// Ensures the proproperty is null info internal.
		/// </summary>
		private void EnsurePropropertyIsNullInfoInternal()
		{
			if (GetState(BindingState.PropropertyIsNullInfoInternal) && PropropertyIsNullInfoInternal == null)
			{
				CheckBinding();
			}
		}

		/// 
		/// Ensures the validate info internal.
		/// </summary>
		private void EnsureValidateInfoInternal()
		{
			if (GetState(BindingState.ValidateInfoInternal) && ValidateInfoInternal == null)
			{
				CheckBinding();
			}
		}

		/// 
		/// Sets the state.
		/// </summary>
		/// <param name="enmState">State of the enm.</param>
		/// <param name="blnValue">The flag value to set.</param>
		internal void SetState(BindingState enmState, bool blnValue)
		{
			mintControlState = (blnValue ? (mintControlState | (int)enmState) : (mintControlState & (int)(~enmState)));
		}

		/// 
		/// Gets the state.
		/// </summary>
		/// <param name="enmState">State of the enm.</param>
		/// </returns>
		internal bool GetState(BindingState enmState)
		{
			return ((uint)mintControlState & (uint)enmState) != 0;
		}

		private object ParseObject(object objValue)
		{
			Type bindToType = BindToObjectInternal.BindToType;
			if (FormattingEnabledInternal)
			{
				ConvertEventArgs e = new ConvertEventArgs(objValue, bindToType);
				OnParse(e);
				object value = e.Value;
				if (!object.Equals(objValue, value))
				{
					return value;
				}
				TypeConverter objTargetConverter = null;
				if (BindToObjectInternal.FieldInfo != null)
				{
					objTargetConverter = BindToObjectInternal.FieldInfo.Converter;
				}
				EnsurePropertyInfoInternal();
				return Formatter.ParseObject(objValue, bindToType, (objValue == null) ? PropertyInfoInternal.PropertyType : objValue.GetType(), objTargetConverter, PropInfoConverter, FormatInfoInternal, NullValueInternal, GetDataSourceNullValue(bindToType));
			}
			ConvertEventArgs e2 = new ConvertEventArgs(objValue, bindToType);
			OnParse(e2);
			if (e2.Value != null && (e2.Value.GetType().IsSubclassOf(bindToType) || e2.Value.GetType() == bindToType || e2.Value is DBNull))
			{
				return e2.Value;
			}
			TypeConverter converter = TypeDescriptor.GetConverter((objValue != null) ? objValue.GetType() : typeof(object));
			if (converter != null && converter.CanConvertTo(bindToType))
			{
				return converter.ConvertTo(objValue, bindToType);
			}
			if (objValue is IConvertible)
			{
				object obj = Convert.ChangeType(objValue, bindToType, CultureInfo.CurrentCulture);
				if (obj != null && (obj.GetType().IsSubclassOf(bindToType) || obj.GetType() == bindToType))
				{
					return obj;
				}
			}
			return null;
		}

		internal bool PullData()
		{
			return PullData(blnReformat: true, blnForce: false);
		}

		internal bool PullData(bool blnReformat)
		{
			return PullData(blnReformat, blnForce: false);
		}

		internal bool PullData(bool blnReformat, bool blnForce)
		{
			if (ControlUpdateMode == ControlUpdateMode.Never)
			{
				blnReformat = false;
			}
			bool flag = false;
			object obj = null;
			Exception ex = null;
			if (IsBinding)
			{
				if (!blnForce)
				{
					if (!CommonUtils.IsMono)
					{
						EnsurePropertyInfoInternal();
						if (PropertyInfoInternal.SupportsChangeEvents && !ModifiedInternal)
						{
							return false;
						}
					}
					if (DataSourceUpdateMode == DataSourceUpdateMode.Never)
					{
						return false;
					}
				}
				if (InPushOrPullInternal && FormattingEnabledInternal)
				{
					return false;
				}
				InPushOrPullInternal = true;
				object propValue = GetPropValue();
				try
				{
					obj = ParseObject(propValue);
				}
				catch (Exception ex2)
				{
					ex = ex2;
				}
				try
				{
					if (ex != null || (!FormattingEnabled && obj == null))
					{
						flag = true;
						obj = BindToObjectInternal.GetValue();
					}
					if (blnReformat && (!FormattingEnabled || !flag))
					{
						object obj2 = FormatObject(obj);
						if (blnForce || !FormattingEnabled || !object.Equals(obj2, propValue))
						{
							SetPropValue(obj2);
						}
					}
					if (!flag)
					{
						BindToObjectInternal.SetValue(obj);
					}
				}
				catch (Exception ex3)
				{
					ex = ex3;
					if (!FormattingEnabled)
					{
						throw;
					}
				}
				finally
				{
					InPushOrPullInternal = false;
				}
				if (FormattingEnabled)
				{
					BindingCompleteEventArgs e = CreateBindingCompleteEventArgs(BindingCompleteContext.DataSourceUpdate, ex);
					OnBindingComplete(e);
					if (e.BindingCompleteState == BindingCompleteState.Success && !e.Cancel)
					{
						ModifiedInternal = false;
					}
					return e.Cancel;
				}
				ModifiedInternal = false;
			}
			return false;
		}

		internal bool PushData()
		{
			return PushData(blnForce: false);
		}

		internal bool PushData(bool blnForce)
		{
			object obj = null;
			Exception objException = null;
			if (blnForce || ControlUpdateMode != ControlUpdateMode.Never)
			{
				if (InPushOrPullInternal && FormattingEnabledInternal)
				{
					return false;
				}
				InPushOrPullInternal = true;
				try
				{
					if (IsBinding)
					{
						obj = BindToObjectInternal.GetValue();
						object propValue = FormatObject(obj);
						SetPropValue(propValue);
						ModifiedInternal = false;
					}
					else
					{
						SetPropValue(null);
					}
				}
				catch (Exception ex)
				{
					objException = ex;
					if (!FormattingEnabled)
					{
						throw;
					}
				}
				finally
				{
					InPushOrPullInternal = false;
				}
				if (FormattingEnabled)
				{
					BindingCompleteEventArgs e = CreateBindingCompleteEventArgs(BindingCompleteContext.ControlUpdate, objException);
					OnBindingComplete(e);
					return e.Cancel;
				}
			}
			return false;
		}

		/// Sets the control property to the value read from the data source.</summary>
		public void ReadValue()
		{
			PushData(blnForce: true);
		}

		internal void SetBindableComponent(IBindableComponent value)
		{
			if (ControlInternal != value)
			{
				IBindableComponent controlInternal = ControlInternal;
				BindTarget(bind: false);
				ControlInternal = value;
				BindTarget(bind: true);
				try
				{
					CheckBinding();
				}
				catch
				{
					BindTarget(bind: false);
					ControlInternal = controlInternal;
					BindTarget(bind: true);
					throw;
				}
				BindingContext.UpdateBinding((ControlInternal != null && IsComponentCreated(ControlInternal)) ? ControlInternal.BindingContext : null, this);
				if (value is Form form)
				{
					form.Load += FormLoaded;
				}
			}
		}

		internal void SetListManager(BindingManagerBase objBindingManagerBase)
		{
			if (BindingManagerBase is CurrencyManager)
			{
				((CurrencyManager)BindingManagerBase).MetaDataChanged -= binding_MetaDataChanged;
			}
			BindingManagerBaseInternal = objBindingManagerBase;
			if (BindingManagerBase is CurrencyManager)
			{
				((CurrencyManager)BindingManagerBase).MetaDataChanged += binding_MetaDataChanged;
			}
			BindToObject.SetBindingManagerBase(objBindingManagerBase);
			CheckBinding();
		}

		private void SetPropValue(object objValue)
		{
			if (ControlAtDesignTime())
			{
				return;
			}
			InSetPropValueInternal = true;
			try
			{
				EnsurePropertyInfoInternal();
				if (objValue == null || Formatter.IsNullData(objValue, DataSourceNullValue))
				{
					EnsurePropropertyIsNullInfoInternal();
					if (PropropertyIsNullInfoInternal != null)
					{
						PropropertyIsNullInfoInternal.SetValue(ControlInternal, true);
					}
					else if (PropertyInfoInternal.PropertyType == typeof(object))
					{
						PropertyInfoInternal.SetValue(ControlInternal, DataSourceNullValue);
					}
					else
					{
						PropertyInfoInternal.SetValue(ControlInternal, null);
					}
				}
				else
				{
					PropertyInfoInternal.SetValue(ControlInternal, objValue);
				}
			}
			finally
			{
				InSetPropValueInternal = false;
			}
		}

		private bool ShouldSerializeDataSourceNullValue()
		{
			if (DataSourceNullValueSetInternal)
			{
				return DataSourceNullValuePropertyInternal != Formatter.GetDefaultDataSourceNullValue(null);
			}
			return false;
		}

		private bool ShouldSerializeFormatString()
		{
			if (FormatStringInternal != null)
			{
				return FormatStringInternal.Length > 0;
			}
			return false;
		}

		private bool ShouldSerializeNullValue()
		{
			return NullValueInternal != null;
		}

		private void Target_PropertyChanged(object sender, EventArgs e)
		{
			if (!InSetPropValueInternal && IsBinding)
			{
				ModifiedInternal = true;
				if (DataSourceUpdateMode == DataSourceUpdateMode.OnPropertyChanged)
				{
					PullData(blnReformat: false);
					ModifiedInternal = true;
				}
			}
		}

		private void Target_Validate(object sender, CancelEventArgs e)
		{
			try
			{
				if (PullData(blnReformat: true))
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
			bool flag = IsBindable && ComponentCreated && BindingManagerBase.IsBinding;
			if (BoundInternal == flag)
			{
				return;
			}
			BoundInternal = flag;
			BindTarget(flag);
			if (BoundInternal)
			{
				if (ControlUpdateModeInternal == ControlUpdateMode.Never)
				{
					PullData(blnReformat: false, blnForce: true);
				}
				else
				{
					PushData();
				}
			}
		}

		/// Reads the current value from the control property and writes it to the data source.</summary>
		public void WriteValue()
		{
			PullData(blnReformat: true, blnForce: true);
		}

		static Binding()
		{
			BindingComplete = SerializableEvent.Register("BindingComplete", typeof(BindingCompleteEventHandler), typeof(Binding));
			Format = SerializableEvent.Register("Format", typeof(ConvertEventHandler), typeof(Binding));
			Parse = SerializableEvent.Register("Parse", typeof(ConvertEventHandler), typeof(Binding));
			BindingManagerBaseProperty = SerializableProperty.Register("BindingManagerBaseProperty", typeof(BindingManagerBase), typeof(Binding));
			BoundProperty = SerializableProperty.Register("Bound", typeof(bool), typeof(Binding), new SerializablePropertyMetadata(false));
			ControlProperty = SerializableProperty.Register("Control", typeof(IBindableComponent), typeof(Binding));
			ControlUpdateModeProperty = SerializableProperty.Register("ControlUpdateMode", typeof(ControlUpdateMode), typeof(Binding));
			DataSourceNullValueSetProperty = SerializableProperty.Register("DataSourceNullValueSet", typeof(bool), typeof(Binding), new SerializablePropertyMetadata(false));
			InOnBindingCompleteProperty = SerializableProperty.Register("inOnBindingComplete", typeof(bool), typeof(Binding));
			InPushOrPullProperty = SerializableProperty.Register("inPushOrPull", typeof(bool), typeof(Binding));
			InSetPropValueProperty = SerializableProperty.Register("inSetPropValue", typeof(bool), typeof(Binding));
			ModifiedProperty = SerializableProperty.Register("modified", typeof(bool), typeof(Binding));
		}
	}
}
