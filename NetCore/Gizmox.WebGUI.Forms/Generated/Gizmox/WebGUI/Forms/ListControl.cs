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
/// Provides a common implementation of members for the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> and <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see> classes.</summary>
	/// 1</filterpriority>
	[Serializable]
	public abstract class ListControl : Control
	{
		/// 
		/// The DataManagerInternal property registration.
		/// </summary>
		private static readonly SerializableProperty DataManagerProperty;

		/// 
		/// The DataSourceInternal property registration.
		/// </summary>
		private static readonly SerializableProperty DataSourceProperty;

		/// 
		/// The DisplayMemberInternal property registration.
		/// </summary>
		private static readonly SerializableProperty DisplayMemberProperty;

		/// 
		/// The FormatInfoInternal property registration.
		/// </summary>
		private static readonly SerializableProperty FormatInfoProperty;

		/// 
		/// The FormatStringInternal property registration.
		/// </summary>
		private static readonly SerializableProperty FormatStringProperty;

		/// 
		/// The FormattingEnabledInternal property registration.
		/// </summary>
		private static readonly SerializableProperty FormattingEnabledProperty;

		/// 
		/// The InSetDataConnectionInternal property registration.
		/// </summary>
		private static readonly SerializableProperty InSetDataConnectionProperty;

		/// 
		/// The IsDataSourceInitEventHooked property registration.
		/// </summary>
		private static readonly SerializableProperty IsDataSourceInitEventHookedProperty;

		/// 
		/// The IsDataSourceInitializedInternal property registration.
		/// </summary>
		private static readonly SerializableProperty IsDataSourceInitializedProperty;

		/// 
		/// The ValueMember property registration.
		/// </summary>
		private static readonly SerializableProperty ValueMemberProperty;

		/// 
		/// The ColorMember property registration.
		/// </summary>
		private static readonly SerializableProperty ColorMemberProperty;

		/// 
		/// The ImageMember property registration.
		/// </summary>
		private static readonly SerializableProperty ImageMemberProperty;

		/// 
		/// The DataSourceChanged event registration.
		/// </summary>
		private static readonly SerializableEvent DataSourceChangedEvent;

		/// 
		/// The DisplayMemberChanged event registration.
		/// </summary>
		private static readonly SerializableEvent DisplayMemberChangedEvent;

		/// 
		/// The Format event registration.
		/// </summary>
		private static readonly SerializableEvent FormatEvent;

		/// 
		/// The FormatInfoChanged event registration.
		/// </summary>
		private static readonly SerializableEvent FormatInfoChangedEvent;

		/// 
		/// The FormatStringChanged event registration.
		/// </summary>
		private static readonly SerializableEvent FormatStringChangedEvent;

		/// 
		/// The FormattingEnabledChanged event registration.
		/// </summary>
		private static readonly SerializableEvent FormattingEnabledChangedEvent;

		/// 
		/// The SelectedValueChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedValueChangedEvent;

		/// 
		/// The ValueMemberChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ValueMemberChangedEvent;

		/// 
		///  The ColorMemberChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ColorMemberChangedEvent;

		/// 
		/// The ImageMemberChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ImageMemberChangedEvent;

		[NonSerialized]
		private TypeConverter mobjDisplayMemberConverter;

		[NonSerialized]
		private static TypeConverter StringTypeConverter;

		[NonSerialized]
		private static TypeConverter ImageTypeConverter;

		[NonSerialized]
		private static TypeConverter ColorTypeConverter;

		/// 
		/// Gets or sets the data manager.
		/// </summary>
		/// The data manager.</value>
		private CurrencyManager DataManagerInternal
		{
			get
			{
				return GetValue(DataManagerProperty);
			}
			set
			{
				SetValue(DataManagerProperty, value);
			}
		}

		/// 
		/// Gets or sets the data source.
		/// </summary>
		/// The data source.</value>
		private object DataSourceInternal
		{
			get
			{
				return GetValue(DataSourceProperty);
			}
			set
			{
				SetValue(DataSourceProperty, value);
			}
		}

		/// 
		/// Gets or sets the display member.
		/// </summary>
		/// The display member.</value>
		private BindingMemberInfo DisplayMemberInternal
		{
			get
			{
				return GetValue(DisplayMemberProperty);
			}
			set
			{
				SetValue(DisplayMemberProperty, value);
			}
		}

		/// 
		/// Gets or sets the format info.
		/// </summary>
		/// The format info.</value>
		private IFormatProvider FormatInfoInternal
		{
			get
			{
				return GetValue(FormatInfoProperty);
			}
			set
			{
				SetValue(FormatInfoProperty, value);
			}
		}

		/// 
		/// Gets or sets the format string.
		/// </summary>
		/// The format string.</value>
		private string FormatStringInternal
		{
			get
			{
				return GetValue(FormatStringProperty);
			}
			set
			{
				SetValue(FormatStringProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether formatting is enabled.
		/// </summary>
		/// 
		/// 	true</c> if formatting is enabled; otherwise, false</c>.
		/// </value>
		private bool FormattingEnabledInternal
		{
			get
			{
				return GetValue(FormattingEnabledProperty);
			}
			set
			{
				SetValue(FormattingEnabledProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether in data connection set.
		/// </summary>
		/// 
		/// 	true</c> if in data connection set; otherwise, false</c>.
		/// </value>
		private bool InSetDataConnectionInternal
		{
			get
			{
				return GetValue(InSetDataConnectionProperty);
			}
			set
			{
				SetValue(InSetDataConnectionProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is data source init event hooked.
		/// </summary>
		/// 
		/// 	true</c> if this instance is data source init event hooked; otherwise, false</c>.
		/// </value>
		private bool IsDataSourceInitEventHookedInternal
		{
			get
			{
				return GetValue(IsDataSourceInitEventHookedProperty);
			}
			set
			{
				SetValue(IsDataSourceInitEventHookedProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is data source initialized.
		/// </summary>
		/// 
		/// 	true</c> if this instance is data source initialized; otherwise, false</c>.
		/// </value>
		private bool IsDataSourceInitializedInternal
		{
			get
			{
				return GetValue(IsDataSourceInitializedProperty);
			}
			set
			{
				SetValue(IsDataSourceInitializedProperty, value);
			}
		}

		/// 
		/// Gets or sets the value member.
		/// </summary>
		/// The value member.</value>
		private BindingMemberInfo ValueMemberInternal
		{
			get
			{
				return GetValue(ValueMemberProperty);
			}
			set
			{
				SetValue(ValueMemberProperty, value);
			}
		}

		/// 
		/// Gets or sets the color member.
		/// </summary>
		/// The value member.</value>
		private string ColorMemberInternal
		{
			get
			{
				return GetValue(ColorMemberProperty);
			}
			set
			{
				SetValue(ColorMemberProperty, value);
			}
		}

		/// 
		/// Gets or sets the image member internal.
		/// </summary>
		/// The image member internal.</value>
		private BindingMemberInfo ImageMemberInternal
		{
			get
			{
				return GetValue(ImageMemberProperty);
			}
			set
			{
				SetValue(ImageMemberProperty, value);
			}
		}

		/// Gets a value indicating whether the list enables selection of list items.</summary>
		/// true if the list enables list item selection; otherwise, false. The default is true.</returns>
		protected virtual bool AllowSelection => true;

		internal bool BindingFieldEmpty
		{
			get
			{
				if (DisplayMemberInternal.BindingField.Length <= 0)
				{
					return true;
				}
				return false;
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this control. The default is null.</returns>
		protected CurrencyManager DataManager => DataManagerInternal;

		/// Gets or sets the data source for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
		/// An object that implements the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces, such as a <see cref="T:System.Data.DataSet"></see> or an <see cref="T:System.Array"></see>. The default is null.</returns>
		/// <exception cref="T:System.ArgumentException">The assigned value does not implement the <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> interfaces.</exception>
		/// 1</filterpriority>
		[DefaultValue(null)]
		[AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
		[SRDescription("ListControlDataSourceDescr")]
		[SRCategory("CatData")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public virtual object DataSource
		{
			get
			{
				return DataSourceInternal;
			}
			set
			{
				if (value != null && !(value is IList) && !(value is IListSource))
				{
					throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
				}
				if (DataSourceInternal != value)
				{
					try
					{
						SetDataConnection(value, DisplayMemberInternal, blnForce: false);
					}
					catch
					{
						DisplayMember = "";
					}
					if (value == null)
					{
						DisplayMember = "";
					}
					FireObservableItemPropertyChanged("DataSource");
				}
			}
		}

		/// Gets or sets the property to display for this <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
		/// A <see cref="T:System.String"></see> specifying the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string (""). </returns>
		/// 1</filterpriority>
		[TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DefaultValue("")]
		[SRCategory("CatData")]
		[SRDescription("ListControlDisplayMemberDescr")]
		public string DisplayMember
		{
			get
			{
				return DisplayMemberInternal.BindingMember;
			}
			set
			{
				BindingMemberInfo displayMemberInternal = DisplayMemberInternal;
				try
				{
					SetDataConnection(DataSourceInternal, new BindingMemberInfo(value), blnForce: false);
				}
				catch
				{
					DisplayMemberInternal = displayMemberInternal;
				}
			}
		}

		private TypeConverter DisplayMemberConverter
		{
			get
			{
				if (mobjDisplayMemberConverter == null && DataManager != null)
				{
					PropertyDescriptorCollection itemProperties = DataManager.GetItemProperties();
					if (itemProperties != null)
					{
						PropertyDescriptor propertyDescriptor = itemProperties.Find(DisplayMemberInternal.BindingField, ignoreCase: true);
						if (propertyDescriptor != null)
						{
							mobjDisplayMemberConverter = propertyDescriptor.Converter;
						}
					}
				}
				return mobjDisplayMemberConverter;
			}
		}

		/// Gets or sets the <see cref="T:System.IFormatProvider"></see> that provides custom formatting behavior. </summary>
		/// The <see cref="T:System.IFormatProvider"></see> implementation that provides custom formatting behavior.</returns>
		/// 2</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		public IFormatProvider FormatInfo
		{
			get
			{
				return FormatInfoInternal;
			}
			set
			{
				if (value != FormatInfoInternal)
				{
					FormatInfoInternal = value;
					RefreshItems();
					OnFormatInfoChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets the format-specifier characters that indicate how a value is to be displayed.</summary>
		/// The string of format-specifier characters that indicates how a value is to be displayed.</returns>
		/// 2</filterpriority>
		[DefaultValue("")]
		[MergableProperty(false)]
		[SRDescription("ListControlFormatStringDescr")]
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
					RefreshItems();
					OnFormatStringChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets a value indicating whether formatting is applied to the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
		/// true if formatting of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property is enabled; otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		[SRDescription("ListControlFormattingEnabledDescr")]
		[DefaultValue(false)]
		public bool FormattingEnabled
		{
			get
			{
				return FormattingEnabledInternal;
			}
			set
			{
				if (value != FormattingEnabledInternal)
				{
					FormattingEnabledInternal = value;
					RefreshItems();
					OnFormattingEnabledChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Indicates if the list control context requires its events to cause callback
		/// </summary>
		protected virtual bool IsPostBackRequired => DataSource != null;

		/// When overridden in a derived class, gets or sets the zero-based index of the currently selected item.</summary>
		/// A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
		/// 1</filterpriority>
		[Bindable(true)]
		public abstract int SelectedIndex { get; set; }

		/// Gets or sets the value of the member property specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</summary>
		/// An object containing the value of the member of the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property.</returns>
		/// <exception cref="T:System.InvalidOperationException">The assigned value is null or the empty string ("").</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ListControlSelectedValueDescr")]
		[Bindable(true)]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		public object SelectedValue
		{
			get
			{
				if (SelectedIndex != -1 && DataManagerInternal != null)
				{
					object objItem = DataManagerInternal[SelectedIndex];
					return FilterItemOnProperty(objItem, ValueMemberInternal.BindingField);
				}
				return null;
			}
			set
			{
				if (DataManagerInternal != null)
				{
					string bindingField = ValueMemberInternal.BindingField;
					if (bindingField == null || bindingField == string.Empty)
					{
						throw new InvalidOperationException(SR.GetString("ListControlEmptyValueMemberInSettingSelectedValue"));
					}
					PropertyDescriptor objPropertyDescriptor = DataManagerInternal.GetItemProperties().Find(bindingField, ignoreCase: true);
					int selectedIndex = DataManagerInternal.Find(objPropertyDescriptor, value, blnKeepIndex: true);
					SelectedIndex = selectedIndex;
				}
			}
		}

		/// Gets or sets the property to use as the actual value for the items in the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see>.</summary>
		/// A <see cref="T:System.String"></see> representing the name of an object property that is contained in the collection specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. The default is an empty string ("").</returns>
		/// <exception cref="T:System.ArgumentException">The specified property cannot be found on the object specified by the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> property. </exception>
		/// 1</filterpriority>
		[SRDescription("ListControlValueMemberDescr")]
		[SRCategory("CatData")]
		[DefaultValue("")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string ValueMember
		{
			get
			{
				return ValueMemberInternal.BindingMember;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(value);
				if (!bindingMemberInfo.Equals(ValueMemberInternal))
				{
					if (DisplayMember.Length == 0)
					{
						SetDataConnection(DataSource, bindingMemberInfo, blnForce: false);
					}
					if (DataManagerInternal != null && value != null && value.Length != 0 && !BindingMemberInfoInDataManager(bindingMemberInfo))
					{
						throw new ArgumentException(SR.GetString("ListControlWrongValueMember"), "value");
					}
					ValueMemberInternal = bindingMemberInfo;
					OnValueMemberChanged(EventArgs.Empty);
					OnSelectedValueChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets the color member.
		/// </summary>
		/// The color member.</value>
		[SRDescription("ListControlColorMemberDescr")]
		[SRCategory("CatData")]
		[DefaultValue("")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string ColorMember
		{
			get
			{
				if (ColorMemberInternal != null)
				{
					return ColorMemberInternal;
				}
				return string.Empty;
			}
			set
			{
				if (ColorMember != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						ColorMemberInternal = null;
					}
					else
					{
						ColorMemberInternal = value;
					}
					OnColorMemberChanged(EventArgs.Empty);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the image member.
		/// </summary>
		/// The image member.</value>
		[SRDescription("ListControlImageMemberDescr")]
		[SRCategory("CatData")]
		[DefaultValue("")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string ImageMember
		{
			get
			{
				return ImageMemberInternal.BindingMember;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				BindingMemberInfo imageMemberInternal = new BindingMemberInfo(value);
				if (!imageMemberInternal.Equals(ImageMemberInternal))
				{
					ImageMemberInternal = imageMemberInternal;
					OnImageMemberChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// 
		/// Gets or sets a value indicating whether [force selected index changed on click]. 
		/// If true, then SelectedIndexChanged event will fire on every index selection, even if actual selected index did not change (WinForms behavior).
		/// </summary>
		/// 
		/// true</c> if [force selected index changed on click]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
		public bool ForceSelectedIndexChangedOnClick
		{
			get
			{
				return WinFormsCompatibility.IsForceSelectedIndexChangedOnClick;
			}
			set
			{
				WinFormsCompatibility.ForceSelectedIndexChangedOnClick = (value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False);
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new ListControlWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ListControlWinFormsCompatibility;

		/// 
		/// Gets the hanlder for the DataSourceChanged event.
		/// </summary>
		private EventHandler DataSourceChangedHandler => (EventHandler)GetHandler(DataSourceChanged);

		/// 
		/// Gets the hanlder for the DisplayMemberChanged event.
		/// </summary>
		private EventHandler DisplayMemberChangedHandler => (EventHandler)GetHandler(DisplayMemberChanged);

		/// 
		/// Gets the hanlder for the Format event.
		/// </summary>
		private ListControlConvertEventHandler FormatHandler => (ListControlConvertEventHandler)GetHandler(Format);

		/// 
		/// Gets the hanlder for the FormatInfoChanged event.
		/// </summary>
		private EventHandler FormatInfoChangedHandler => (EventHandler)GetHandler(FormatInfoChanged);

		/// 
		/// Gets the hanlder for the FormatStringChanged event.
		/// </summary>
		private EventHandler FormatStringChangedHandler => (EventHandler)GetHandler(FormatStringChanged);

		/// 
		/// Gets the hanlder for the FormattingEnabledChanged event.
		/// </summary>
		private EventHandler FormattingEnabledChangedHandler => (EventHandler)GetHandler(FormattingEnabledChanged);

		/// 
		/// Gets the hanlder for the SelectedValueChanged event.
		/// </summary>
		protected EventHandler SelectedValueChangedHandler => (EventHandler)GetHandler(SelectedValueChanged);

		/// 
		/// Gets the hanlder for the ValueMemberChanged event.
		/// </summary>
		private EventHandler ValueMemberChangedHandler => (EventHandler)GetHandler(ValueMemberChanged);

		/// 
		/// Gets the color member changed handler.
		/// </summary>
		/// The color member changed handler.</value>
		private EventHandler ColorMemberChangedHandler => (EventHandler)GetHandler(ColorMemberChangedEvent);

		/// 
		/// Gets the image member changed handler.
		/// </summary>
		/// The image member changed handler.</value>
		private EventHandler ImageMemberChangedHandler => (EventHandler)GetHandler(ImageMemberChangedEvent);

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DataSource"></see> changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ListControlOnDataSourceChangedDescr")]
		public event EventHandler DataSourceChanged
		{
			add
			{
				AddHandler(DataSourceChangedEvent, value);
			}
			remove
			{
				RemoveHandler(DataSourceChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ListControlOnDisplayMemberChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DisplayMemberChanged
		{
			add
			{
				AddHandler(DisplayMemberChangedEvent, value);
			}
			remove
			{
				RemoveHandler(DisplayMemberChangedEvent, value);
			}
		}

		/// Occurs when the control is bound to a data value.</summary>
		/// 1</filterpriority>
		[SRDescription("ListControlFormatDescr")]
		[SRCategory("CatPropertyChanged")]
		public event ListControlConvertEventHandler Format
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

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatInfo"></see> property changes.</summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ListControlFormatInfoChangedDescr")]
		public event EventHandler FormatInfoChanged
		{
			add
			{
				AddHandler(FormatInfoChangedEvent, value);
			}
			remove
			{
				RemoveHandler(FormatInfoChangedEvent, value);
			}
		}

		/// Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormatString"></see> property changes</summary>
		/// 1</filterpriority>
		[SRDescription("ListControlFormatStringChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler FormatStringChanged
		{
			add
			{
				AddHandler(FormatStringChangedEvent, value);
			}
			remove
			{
				RemoveHandler(FormatStringChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListControl.FormattingEnabled"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ListControlFormattingEnabledChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler FormattingEnabledChanged
		{
			add
			{
				AddHandler(FormattingEnabledChangedEvent, value);
			}
			remove
			{
				RemoveHandler(FormattingEnabledChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.SelectedValue"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ListControlOnSelectedValueChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler SelectedValueChanged
		{
			add
			{
				AddHandler(SelectedValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler(SelectedValueChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ValueMember"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ListControlOnValueMemberChangedDescr")]
		public event EventHandler ValueMemberChanged
		{
			add
			{
				AddHandler(ValueMemberChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ValueMemberChangedEvent, value);
			}
		}

		/// 
		/// Raises the <see cref="E:BindingContextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnBindingContextChanged(EventArgs e)
		{
			SetDataConnection(DataSourceInternal, DisplayMemberInternal, blnForce: true);
			base.OnBindingContextChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			DataSourceChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDisplayMemberChanged(EventArgs e)
		{
			DisplayMemberChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.Format"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ListControlConvertEventArgs"></see> that contains the event data. </param>
		protected virtual void OnFormat(ListControlConvertEventArgs e)
		{
			FormatHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatInfoChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnFormatInfoChanged(EventArgs e)
		{
			FormatInfoChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormatStringChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnFormatStringChanged(EventArgs e)
		{
			FormatStringChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.FormattingEnabledChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnFormattingEnabledChanged(EventArgs e)
		{
			FormattingEnabledChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnSelectedIndexChanged(EventArgs e)
		{
			OnSelectedValueChanged(EventArgs.Empty);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnSelectedValueChanged(EventArgs e)
		{
			SelectedValueChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.ValueMemberChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnValueMemberChanged(EventArgs e)
		{
			ValueMemberChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ColorMemberChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnColorMemberChanged(EventArgs e)
		{
			ColorMemberChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ImageMemberChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnImageMemberChanged(EventArgs e)
		{
			ImageMemberChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.ListControl" /> class.
		/// </summary>
		static ListControl()
		{
			DataManagerProperty = SerializableProperty.Register("DataManager", typeof(CurrencyManager), typeof(ListControl), new SerializablePropertyMetadata(null));
			DataSourceProperty = SerializableProperty.Register("DataSource", typeof(object), typeof(ListControl), new SerializablePropertyMetadata(null));
			DisplayMemberProperty = SerializableProperty.Register("DisplayMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));
			FormatInfoProperty = SerializableProperty.Register("FormatInfo", typeof(IFormatProvider), typeof(ListControl), new SerializablePropertyMetadata(null));
			FormatStringProperty = SerializableProperty.Register("FormatString", typeof(string), typeof(ListControl), new SerializablePropertyMetadata(string.Empty));
			FormattingEnabledProperty = SerializableProperty.Register("FormattingEnabledInternal", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));
			InSetDataConnectionProperty = SerializableProperty.Register("InSetDataConnection", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));
			IsDataSourceInitEventHookedProperty = SerializableProperty.Register("IsDataSourceInitEventHooked", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));
			IsDataSourceInitializedProperty = SerializableProperty.Register("IsDataSourceInitialized", typeof(bool), typeof(ListControl), new SerializablePropertyMetadata(false));
			ValueMemberProperty = SerializableProperty.Register("ValueMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));
			ColorMemberProperty = SerializableProperty.Register("ColorMember", typeof(string), typeof(ListControl), new SerializablePropertyMetadata(string.Empty));
			ImageMemberProperty = SerializableProperty.Register("ImageMember", typeof(BindingMemberInfo), typeof(ListControl), new SerializablePropertyMetadata(default(BindingMemberInfo)));
			DataSourceChanged = SerializableEvent.Register("DataSourceChanged", typeof(EventHandler), typeof(ListControl));
			DisplayMemberChanged = SerializableEvent.Register("DisplayMemberChanged", typeof(EventHandler), typeof(ListControl));
			Format = SerializableEvent.Register("Format", typeof(ListControlConvertEventHandler), typeof(ListControl));
			FormatInfoChanged = SerializableEvent.Register("FormatInfoChanged", typeof(EventHandler), typeof(ListControl));
			FormatStringChanged = SerializableEvent.Register("FormatStringChanged", typeof(EventHandler), typeof(ListControl));
			FormattingEnabledChangedEvent = SerializableEvent.Register("FormattingEnabledChanged", typeof(EventHandler), typeof(ListControl));
			SelectedValueChanged = SerializableEvent.Register("SelectedValueChanged", typeof(EventHandler), typeof(ListControl));
			ValueMemberChanged = SerializableEvent.Register("ValueMemberChanged", typeof(EventHandler), typeof(ListControl));
			ColorMemberChangedEvent = SerializableEvent.Register("ColorMemberChanged", typeof(EventHandler), typeof(ListControl));
			ImageMemberChangedEvent = SerializableEvent.Register("ImageMemberChanged", typeof(EventHandler), typeof(ListControl));
			StringTypeConverter = null;
			ImageTypeConverter = null;
			ColorTypeConverter = null;
			StringTypeConverter = TypeDescriptor.GetConverter(typeof(string));
			ImageTypeConverter = TypeDescriptor.GetConverter(typeof(ResourceHandle));
			ColorTypeConverter = TypeDescriptor.GetConverter(typeof(Color));
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> class. </summary>
		protected ListControl()
		{
		}

		private bool BindingMemberInfoInDataManager(BindingMemberInfo objBindingMemberInfo)
		{
			if (DataManagerInternal != null)
			{
				PropertyDescriptorCollection itemProperties = DataManagerInternal.GetItemProperties();
				int count = itemProperties.Count;
				for (int i = 0; i < count; i++)
				{
					if (!typeof(IList).IsAssignableFrom(itemProperties[i].PropertyType) && itemProperties[i].Name.Equals(objBindingMemberInfo.BindingField))
					{
						return true;
					}
				}
				for (int j = 0; j < count; j++)
				{
					if (!typeof(IList).IsAssignableFrom(itemProperties[j].PropertyType) && string.Compare(itemProperties[j].Name, objBindingMemberInfo.BindingField, ignoreCase: true, CultureInfo.CurrentCulture) == 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void DataManager_ItemChanged(object sender, ItemChangedEventArgs e)
		{
			if (DataManagerInternal == null)
			{
				return;
			}
			if (e.Index == -1)
			{
				SetItemsCore(DataManagerInternal.List);
				if (AllowSelection)
				{
					SelectedIndex = DataManagerInternal.Position;
				}
			}
			else
			{
				SetItemCore(e.Index, DataManagerInternal[e.Index]);
			}
		}

		private void DataManager_PositionChanged(object sender, EventArgs e)
		{
			if (DataManagerInternal != null && AllowSelection && SelectedIndex != DataManagerInternal.Position)
			{
				SelectedIndex = DataManagerInternal.Position;
				Update();
			}
		}

		private void DataSourceDisposed(object sender, EventArgs e)
		{
			SetDataConnection(null, new BindingMemberInfo(""), blnForce: true);
		}

		private void DataSourceInitialized(object sender, EventArgs e)
		{
			SetDataConnection(DataSourceInternal, DisplayMemberInternal, blnForce: true);
		}

		/// Retrieves the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object, given the item.</summary>
		/// The filtered object.</returns>
		/// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
		protected object FilterItemOnProperty(object objItem)
		{
			return FilterItemOnProperty(objItem, DisplayMemberInternal.BindingField);
		}

		/// Returns the current value of the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item, if it is a property of an object given the item and the property name.</summary>
		/// The filtered object.</returns>
		/// <param name="objItem">The object the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> item is bound to.</param>
		/// <param name="strField">The property name of the item the <see cref="T:Gizmox.WebGUI.Forms.ListControl"></see> is bound to.</param>
		protected object FilterItemOnProperty(object objItem, string strField)
		{
			return FilterItemOnProperty(DataManagerInternal, objItem, strField);
		}

		/// 
		/// Filters the item on property.
		/// </summary>
		/// <param name="objCurrencyManager">The obj currency manager.</param>
		/// <param name="objItem">The obj item.</param>
		/// <param name="strField">The STR field.</param>
		/// </returns>
		internal static object FilterItemOnProperty(CurrencyManager objCurrencyManager, object objItem, string strField)
		{
			if (objItem != null && strField.Length > 0)
			{
				try
				{
					PropertyDescriptor propertyDescriptor = ((objCurrencyManager == null) ? TypeDescriptor.GetProperties(objItem).Find(strField, ignoreCase: true) : objCurrencyManager.GetItemProperties().Find(strField, ignoreCase: true));
					if (propertyDescriptor != null)
					{
						objItem = propertyDescriptor.GetValue(objItem);
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
			return FindStringInternal(str, objItems, intStartIndex, blnExact, blnIgnorecase: true);
		}

		internal int FindStringInternal(string str, IList objI, int intStartIndex, bool blnExact, bool blnIgnorecase)
		{
			if (str != null && objI != null)
			{
				if (intStartIndex < -1 || intStartIndex >= objI.Count)
				{
					return -1;
				}
				bool flag = false;
				int length = str.Length;
				int num = 0;
				int num2 = (intStartIndex + 1) % objI.Count;
				while (num < objI.Count)
				{
					num++;
					if ((!blnExact) ? (string.Compare(str, 0, GetItemText(objI[num2]), 0, length, blnIgnorecase, CultureInfo.CurrentCulture) == 0) : (string.Compare(str, GetItemText(objI[num2]), blnIgnorecase, CultureInfo.CurrentCulture) == 0))
					{
						return num2;
					}
					num2 = (num2 + 1) % objI.Count;
				}
			}
			return -1;
		}

		/// Returns the text representation of the specified item.</summary>
		/// If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemText(System.Object)"></see> is the value of the item's ToString method. Otherwise, the method returns the string value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.DisplayMember"></see> property for the object specified in the item parameter.</returns>
		/// <param name="objItem">The object from which to get the contents to display. </param>
		/// 1</filterpriority>
		public virtual string GetItemText(object objItem)
		{
			if (!FormattingEnabledInternal)
			{
				if (objItem == null)
				{
					return string.Empty;
				}
				objItem = FilterItemOnProperty(objItem, DisplayMemberInternal.BindingField);
				if (objItem == null)
				{
					return "";
				}
				return Convert.ToString(objItem, CultureInfo.CurrentCulture);
			}
			object obj = FilterItemOnProperty(objItem, DisplayMemberInternal.BindingField);
			ListControlConvertEventArgs e = new ListControlConvertEventArgs(obj, typeof(string), objItem);
			OnFormat(e);
			if (e.Value != objItem && e.Value is string)
			{
				return (string)e.Value;
			}
			try
			{
				return (string)Formatter.FormatObject(obj, typeof(string), DisplayMemberConverter, StringTypeConverter, FormatStringInternal, FormatInfoInternal, null, DBNull.Value);
			}
			catch
			{
				return (obj != null) ? Convert.ToString(objItem, CultureInfo.CurrentCulture) : "";
			}
		}

		/// Returns the Color representation of the specified item.</summary>
		/// If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemColor(System.Object)"></see> is the value of the item as Color. Otherwise, the method returns the striColorng value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
		/// <param name="objItem">The object from which to get the contents to display. </param>
		/// 1</filterpriority>
		public virtual Color GetItemColor(object objItem)
		{
			Color result = Color.Empty;
			string colorMember = ColorMember;
			if (string.IsNullOrEmpty(colorMember))
			{
				if (objItem is Color)
				{
					result = (Color)objItem;
				}
			}
			else
			{
				object obj = FilterItemOnProperty(objItem, colorMember);
				if (obj != null)
				{
					if (obj is Color)
					{
						result = (Color)obj;
					}
					else if (ColorTypeConverter.CanConvertFrom(obj.GetType()))
					{
						result = (Color)ColorTypeConverter.ConvertFrom(obj);
					}
				}
			}
			return result;
		}

		/// Returns the Image representation of the specified item.</summary>
		/// If the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ImageMember"></see> property is not specified, the value returned by <see cref="M:Gizmox.WebGUI.Forms.ListControl.GetItemImage(System.Object)"></see> is the value of the item as Image. Otherwise, the method returns the Image value of the member specified in the <see cref="P:Gizmox.WebGUI.Forms.ListControl.ColorMember"></see> property for the object specified in the item parameter.</returns>
		/// <param name="objItem">The object from which to get the contents to display. </param>
		/// 1</filterpriority>
		public virtual ResourceHandle GetItemImage(object objItem)
		{
			ResourceHandle result = null;
			string imageMember = ImageMember;
			if (!string.IsNullOrEmpty(imageMember))
			{
				object obj = FilterItemOnProperty(objItem, imageMember);
				if (obj != null)
				{
					if (obj is ResourceHandle)
					{
						result = (ResourceHandle)obj;
					}
					else if (ImageTypeConverter.CanConvertFrom(obj.GetType()))
					{
						result = (ResourceHandle)ImageTypeConverter.ConvertFrom(obj);
					}
				}
			}
			return result;
		}

		/// When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
		/// <param name="index">The zero-based index of the item whose data to refresh. </param>
		protected abstract void RefreshItem(int index);

		/// When overridden in a derived class, resynchronizes the item data with the contents of the data source.</summary>
		protected virtual void RefreshItems()
		{
		}

		private void SetDataConnection(object objNewDataSource, BindingMemberInfo objNewDisplayMember, bool blnForce)
		{
			bool flag = DataSourceInternal != objNewDataSource;
			bool flag2 = !DisplayMemberInternal.Equals(objNewDisplayMember);
			if (InSetDataConnectionInternal)
			{
				return;
			}
			try
			{
				if (blnForce || flag || flag2)
				{
					InSetDataConnectionInternal = true;
					IList list = ((DataManager != null) ? DataManager.List : null);
					bool flag3 = DataManager == null;
					UnwireDataSource();
					DataSourceInternal = objNewDataSource;
					DisplayMemberInternal = objNewDisplayMember;
					WireDataSource();
					if (IsDataSourceInitializedInternal)
					{
						CurrencyManager currencyManager = null;
						if (objNewDataSource != null && BindingContext != null && objNewDataSource != Convert.DBNull)
						{
							currencyManager = (CurrencyManager)BindingContext[objNewDataSource, objNewDisplayMember.BindingPath];
						}
						if (DataManagerInternal != currencyManager)
						{
							if (DataManagerInternal != null)
							{
								DataManagerInternal.ItemChanged -= DataManager_ItemChanged;
								DataManagerInternal.PositionChanged -= DataManager_PositionChanged;
							}
							DataManagerInternal = currencyManager;
							if (DataManagerInternal != null)
							{
								DataManagerInternal.ItemChanged += DataManager_ItemChanged;
								DataManagerInternal.PositionChanged += DataManager_PositionChanged;
							}
						}
						if (DataManagerInternal != null && (flag2 || flag) && DisplayMemberInternal.BindingMember != null && DisplayMemberInternal.BindingMember.Length != 0 && !BindingMemberInfoInDataManager(DisplayMemberInternal))
						{
							throw new ArgumentException(SR.GetString("ListControlWrongDisplayMember"), "newDisplayMember");
						}
						if (DataManagerInternal != null && (flag || flag2 || blnForce) && (flag2 || (blnForce && (list != DataManagerInternal.List || flag3))))
						{
							DataManager_ItemChanged(DataManagerInternal, new ItemChangedEventArgs(-1));
						}
					}
					mobjDisplayMemberConverter = null;
				}
				if (flag)
				{
					OnDataSourceChanged(EventArgs.Empty);
				}
				if (flag2)
				{
					OnDisplayMemberChanged(EventArgs.Empty);
				}
			}
			finally
			{
				InSetDataConnectionInternal = false;
			}
		}

		/// When overridden in a derived class, sets the object with the specified index in the derived class.</summary>
		/// <param name="objValue">The object.</param>
		/// <param name="index">The array index of the object.</param>
		protected virtual void SetItemCore(int index, object objValue)
		{
		}

		/// When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
		/// <param name="objItems">An array of items.</param>
		protected abstract void SetItemsCore(IList objItems);

		private void UnwireDataSource()
		{
			object dataSourceInternal = DataSourceInternal;
			if (dataSourceInternal is IComponent)
			{
				((IComponent)dataSourceInternal).Disposed -= DataSourceDisposed;
			}
			if (dataSourceInternal is ISupportInitializeNotification supportInitializeNotification && IsDataSourceInitEventHookedInternal)
			{
				supportInitializeNotification.Initialized -= DataSourceInitialized;
				IsDataSourceInitEventHookedInternal = false;
			}
		}

		private void WireDataSource()
		{
			object dataSourceInternal = DataSourceInternal;
			if (dataSourceInternal is IComponent)
			{
				((IComponent)dataSourceInternal).Disposed += DataSourceDisposed;
			}
			if (dataSourceInternal is ISupportInitializeNotification { IsInitialized: false } supportInitializeNotification)
			{
				supportInitializeNotification.Initialized += DataSourceInitialized;
				IsDataSourceInitEventHookedInternal = true;
				IsDataSourceInitializedInternal = false;
			}
			else
			{
				IsDataSourceInitializedInternal = true;
			}
		}

		/// 
		/// Should render color.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool ShouldRenderColor()
		{
			return !string.IsNullOrEmpty(ColorMember);
		}

		/// 
		/// Should render image.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool ShouldRenderImage()
		{
			return !string.IsNullOrEmpty(ImageMember);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderForceSelectedIndexChangedAttribute(objWriter, blnForceRender: false);
		}

		/// 
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
				RenderForceSelectedIndexChangedAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the force selected index changed attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [p].</param>
		private void RenderForceSelectedIndexChangedAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (WinFormsCompatibility.IsForceSelectedIndexChangedOnClick || blnForceRender)
			{
				objWriter.WriteAttributeString("FSIC", WinFormsCompatibility.IsForceSelectedIndexChangedOnClick ? "1" : "0");
			}
		}

		/// 
		/// Renders the item id attribute
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objObject">The object.</param>
		protected void RenderItemIdAttribute(IResponseWriter objWriter, object objObject)
		{
			if (objObject is IClientObject clientObject)
			{
				objWriter.WriteAttributeString("CID", clientObject.ID);
			}
		}

		/// 
		/// Renders the color and image attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnShouldRenderItemImage">if set to true</c> [BLN should render item image].</param>
		/// <param name="blnShouldRenderItemColor">if set to true</c> [BLN should render item color].</param>
		/// <param name="objObject">The obj object.</param>
		protected void RenderColorAndImageAttribute(IResponseWriter objWriter, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, object objObject)
		{
			if (blnShouldRenderItemColor)
			{
				Color itemColor = GetItemColor(objObject);
				string text = null;
				text = ((!(itemColor != Color.Empty)) ? "#FFFFFF" : CommonUtils.GetHtmlColor(itemColor));
				WriteColorAttribute(objWriter, text);
			}
			if (blnShouldRenderItemImage)
			{
				ResourceHandle itemImage = GetItemImage(objObject);
				string text2 = null;
				if (itemImage != null)
				{
					text2 = itemImage.ToString();
				}
				if (!string.IsNullOrEmpty(text2))
				{
					objWriter.WriteAttributeString("IM", text2);
				}
			}
		}

		/// 
		/// Writes the color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="strColor">Color of the STR.</param>
		protected virtual void WriteColorAttribute(IResponseWriter objWriter, string strColor)
		{
			objWriter.WriteAttributeString("CO", strColor);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new ListControlWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "ForceSelectedIndexChangedOnClick")
			{
				UpdateParams(AttributeType.Events);
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}
	}
}
