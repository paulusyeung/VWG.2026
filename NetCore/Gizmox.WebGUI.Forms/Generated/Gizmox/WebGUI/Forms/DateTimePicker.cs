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
/// 
	/// Represents a Gizmox.WebGUI.Forms control that allows the user to select a date and a time and to display the date and time with a specified format.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DateTimePicker), "DateTimePicker_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("DP")]
	[Skin(typeof(DateTimePickerSkin))]
	public class DateTimePicker : Control
	{
		/// 
		/// Provides a property reference to DateTimePickerFormat property.
		/// </summary>
		private static SerializableProperty DateTimePickerFormatProperty;

		/// 
		/// Provides a property reference to CustomFormat property.
		/// </summary>
		private static SerializableProperty CustomFormatProperty;

		/// 
		/// Provides a property reference to ShowUpDown property.
		/// </summary>
		private static SerializableProperty ShowUpDownProperty;

		/// 
		/// Provides a property reference to ShowBothEditButtons property.
		/// </summary>
		private static SerializableProperty ShowBothEditButtonsProperty;

		/// 
		/// Provides a property reference to CalendarFirstDayOfWeek property.
		/// </summary>
		private static SerializableProperty CalendarFirstDayOfWeekProperty;

		/// 
		/// Provides a property reference to EmptyDateYear property.
		/// </summary>
		private static SerializableProperty EmptyDateYearProperty;

		/// 
		/// Provides a property reference to ShowCheckBox property.
		/// </summary>
		private static SerializableProperty ShowCheckBoxProperty;

		/// 
		/// The CheckedChangedQueued event registration.
		/// </summary>
		private static readonly SerializableEvent CheckedChangedQueuedEvent;

		/// 
		/// The CheckedChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CheckedChangedEvent;

		/// 
		/// The CloseUp event registration.
		/// </summary>
		private static readonly SerializableEvent CloseUpEvent;

		/// 
		/// Specifies the maximum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control. This field is read-only.
		/// </summary>
		public static DateTime MaxDateTime;

		/// 
		/// Gets the minimum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
		/// </summary>
		public static DateTime MinDateTime;

		/// 
		/// Default time format
		/// </summary>
		private static string mstrTimeFormat;

		/// 
		/// Default short date format
		/// </summary>
		private static string mstrShortFormat;

		/// 
		/// Default long date format
		/// </summary>
		private static string mstrLongFormat;

		/// 
		///
		/// </summary>
		private static char[] marrTokens;

		/// 
		/// The ValueChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ValueChangedEvent;

		/// 
		/// The ValueChangedQueued event registration.
		/// </summary>
		private static readonly SerializableEvent ValueChangedQueuedEvent;

		/// 
		/// The current datetime picker value
		/// </summary>
		[NonSerialized]
		private DateTime mobjValue;

		/// 
		/// The current datetime picker max value
		/// </summary>
		[NonSerialized]
		private DateTime mobjMaxValue;

		/// 
		/// The current datetime picker min value
		/// </summary>
		[NonSerialized]
		private DateTime mobjMinValue;

		/// 
		/// A flag indicating whether user has set value.
		/// </summary>
		[NonSerialized]
		private bool mblnUserHasSetValue = false;

		/// 
		/// The amount of fields the form needs to serialize
		/// </summary>
		private const int mintSerializableFieldCount = 4;

		/// 
		/// Gets the hanlder for the ValueChanged event.
		/// </summary>
		private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChangedEvent);

		/// 
		/// Gets the hanlder for the ValueChangedQueued event.
		/// </summary>
		private EventHandler ValueChangedQueuedHandler => (EventHandler)GetHandler(ValueChangedQueuedEvent);

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 4;

		/// 
		/// Gets the hanlder for the CheckedChangedQueued event.
		/// </summary>
		private EventHandler CheckedChangedQueuedHandler => (EventHandler)GetHandler(CheckedChangedQueuedEvent);

		/// 
		/// Gets the hanlder for the CheckedChanged event.
		/// </summary>
		private EventHandler CheckedChangedHandler => (EventHandler)GetHandler(CheckedChangedEvent);

		/// 
		/// Gets the hanlder for the CloseUp event.
		/// </summary>
		internal EventHandler CloseUpHandler => (EventHandler)GetHandler(CloseUpEvent);

		/// 
		/// Gets or sets the date/time value assigned to the control.
		/// </summary>
		/// The <see cref="T:System.DateTime"></see> value assign to the control.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> or more than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MaxDate"></see>.</exception>
		[Bindable(true)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("DateTimePickerValueDescr")]
		[SRCategory("CatBehavior")]
		public virtual DateTime Value
		{
			get
			{
				return mobjValue;
			}
			set
			{
				if (SetValueInternal(value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets the current date/time format selected by the user and set 
		/// by the user's operating system, unless defined in web.config.
		/// </summary>
		/// The current date/time format selected by the user and set 
		/// by the user's operating system, unless defined in web.config.</returns>
		private string CurrentFormat
		{
			get
			{
				DateTimeFormatInfo dateTimeFormat = Application.CurrentUICulture.DateTimeFormat;
				string longDatePattern = mstrLongFormat;
				string shortDatePattern = mstrShortFormat;
				string longTimePattern = mstrTimeFormat;
				if (longDatePattern == null)
				{
					longDatePattern = dateTimeFormat.LongDatePattern;
				}
				if (shortDatePattern == null)
				{
					shortDatePattern = dateTimeFormat.ShortDatePattern;
				}
				if (longTimePattern == null)
				{
					longTimePattern = dateTimeFormat.LongTimePattern;
				}
				string result = null;
				switch (Format)
				{
				case DateTimePickerFormat.Custom:
					result = CustomFormat;
					break;
				case DateTimePickerFormat.Long:
					result = longDatePattern;
					break;
				case DateTimePickerFormat.Short:
					result = shortDatePattern;
					break;
				case DateTimePickerFormat.Time:
					result = longTimePattern;
					break;
				}
				return result;
			}
		}

		/// Gets or sets a value indicating whether a spin button control (also known as an up-down control) is used to adjust the date/time value.</summary>
		/// true if a spin button control is used to adjust the date/time value; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("DateTimePickerShowUpDownDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(false)]
		public bool ShowUpDown
		{
			get
			{
				return GetValue(ShowUpDownProperty);
			}
			set
			{
				if (SetValue(ShowUpDownProperty, value))
				{
					FireObservableItemPropertyChanged("ShowUpDown");
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show both edit buttons].
		/// </summary>
		/// 
		/// true</c> if [show both edit buttons]; otherwise, false</c>.
		/// </value>
		[SRDescription("DateTimePickerShowBothEditButtonsDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(false)]
		public bool ShowBothEditButtons
		{
			get
			{
				return GetValue(ShowBothEditButtonsProperty);
			}
			set
			{
				if (SetValue(ShowBothEditButtonsProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the first day of the week as displayed in the month calendar.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
		[SRDescription("MonthCalendarFirstDayOfWeekDescr")]
		[DefaultValue(Day.Default)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		public Day CalendarFirstDayOfWeek
		{
			get
			{
				return GetValue(CalendarFirstDayOfWeekProperty);
			}
			set
			{
				if (SetValue(CalendarFirstDayOfWeekProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the year value for empty dates. Dates on or before this year are considered empty (blank) dates.
		/// By setting this value to non-default value, the DateTimePicker will change its date to current date if dropdown is started with a date considered as blank.
		/// As an example, setting this to 1900, dropping down DateTimePicker on dates on year 1900 or before will first change the value of DateTimePicker to current
		/// date, then start the dropdown, thereby starting selection from current date, not before year 1900.</summary>
		/// The year as integer. The default is 0.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
		[SRDescription("EmptyDateYearDescr")]
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		public int EmptyDateYear
		{
			get
			{
				return GetValue(EmptyDateYearProperty);
			}
			set
			{
				if (value >= DateTime.Now.Year || value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (SetValue(EmptyDateYearProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker" /> is checked.
		/// </summary>
		/// 
		/// 	true</c> if checked; otherwise, false</c>.
		/// </value>
		[SRDescription("DateTimePickerCheckedDescr")]
		[Bindable(true)]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool Checked
		{
			get
			{
				return GetState(ComponentState.Checked);
			}
			set
			{
				if (Checked != value)
				{
					CheckedInternal = value;
					FireObservableItemPropertyChanged("Checked");
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Sets a value indicating whether [checked internal].
		/// </summary>
		/// true</c> if [checked internal]; otherwise, false</c>.</value>
		internal bool CheckedInternal
		{
			set
			{
				if (SetStateWithCheck(ComponentState.Checked, value))
				{
					OnValueChanged(new EventArgs());
					OnValueChangedQueued(new EventArgs());
					OnCheckedChanged(new EventArgs());
					OnCheckedChangedQueued(new EventArgs());
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether a check box is displayed to the left of the selected date.
		/// </summary>
		/// true if a check box is displayed to the left of the selected date; otherwise, false. The default is false.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(false)]
		[SRDescription("DateTimePickerShowNoneDescr")]
		[SRCategory("CatAppearance")]
		public bool ShowCheckBox
		{
			get
			{
				return GetValue(ShowCheckBoxProperty);
			}
			set
			{
				if (SetValue(ShowCheckBoxProperty, value))
				{
					FireObservableItemPropertyChanged("ShowCheckBox");
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the custom date/time format string.
		/// </summary>
		/// A string that represents the custom date/time format. The default is null.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(null)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("DateTimePickerCustomFormatDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public string CustomFormat
		{
			get
			{
				return GetValue(CustomFormatProperty);
			}
			set
			{
				if (SetValue(CustomFormatProperty, value) && Format == DateTimePickerFormat.Custom)
				{
					Update();
					FireObservableItemPropertyChanged("CustomFormat");
				}
			}
		}

		/// 
		/// Gets or sets the format of the date and time displayed in the control.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePickerFormat"></see> values. The default is <see cref="F:System.Windows.Forms.DateTimePickerFormat.Long"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Windows.Forms.DateTimePickerFormat"></see> values. </exception>
		[SRDescription("DateTimePickerFormatDescr")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRCategory("CatAppearance")]
		[DefaultValue(DateTimePickerFormat.Long)]
		public DateTimePickerFormat Format
		{
			get
			{
				return GetValue(DateTimePickerFormatProperty);
			}
			set
			{
				if (SetValue(DateTimePickerFormatProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("Format");
				}
			}
		}

		/// 
		/// Gets or sets the maximum date and time that can be selected in the control.
		/// </summary>
		/// The maximum date and time that can be selected in the control. The default is 12/31/9998 23:59:59.</returns>
		/// <exception cref="T:System.ArgumentException">The value assigned is less than the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> value. </exception>
		/// <exception cref="T:System.SystemException">The value assigned is greater than the <see cref="F:Gizmox.WebGUI.Forms.DateTimePicker.MaxDateTime"></see> value. </exception>
		[SRCategory("CatBehavior")]
		[SRDescription("DateTimePickerMaxDateDescr")]
		public DateTime MaxDate
		{
			get
			{
				return mobjMaxValue;
			}
			set
			{
				if (DateTime.Compare(value, MaxDate) != 0)
				{
					if (DateTime.Compare(value, MinDate) == -1)
					{
						throw new ArgumentOutOfRangeException();
					}
					if (DateTime.Compare(value, MaxDateTime) == 1)
					{
						throw new ArgumentOutOfRangeException();
					}
					mobjMaxValue = value;
					Update();
					if (DateTime.Compare(value, Value) == -1)
					{
						Value = value;
					}
				}
			}
		}

		/// Gets or sets the minimum date and time that can be selected in the control.</summary>
		/// The minimum date and time that can be selected in the control. The default is 1/1/1753 00:00:00.</returns>
		/// <exception cref="T:System.SystemException">The value assigned is less than the <see cref="F:System.Windows.Forms.DateTimePicker.MinDateTime"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">The value assigned is not less than the <see cref="P:System.Windows.Forms.DateTimePicker.MaxDate"></see> value. </exception>
		[SRDescription("DateTimePickerMinDateDescr")]
		[SRCategory("CatBehavior")]
		public DateTime MinDate
		{
			get
			{
				return mobjMinValue;
			}
			set
			{
				if (DateTime.Compare(value, MinDate) != 0)
				{
					if (DateTime.Compare(value, MaxDate) == 1)
					{
						throw new ArgumentOutOfRangeException();
					}
					if (DateTime.Compare(value, MinDateTime) == -1)
					{
						throw new ArgumentOutOfRangeException();
					}
					mobjMinValue = value;
					Update();
					if (DateTime.Compare(value, Value) == 1)
					{
						Value = value;
					}
				}
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// The text associated with this control.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override string Text
		{
			get
			{
				_ = Value;
				if (!base.DesignMode)
				{
					return Value.ToString(CurrentFormat);
				}
				return base.Text;
			}
			set
			{
				DateTime value2 = Value;
				DateTime dateTime = DateTime.Now;
				if (value == null || value.Length == 0)
				{
					mblnUserHasSetValue = false;
				}
				else
				{
					dateTime = DateTime.Parse(value, Context.CurrentUICulture);
				}
				if (value2 != dateTime)
				{
					Value = dateTime;
					OnTextChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets the height of the preferred.
		/// </summary>
		/// The height of the preferred.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int PreferredHeight
		{
			get
			{
				int num = 0;
				Font font = Font;
				if (font != null)
				{
					num = CommonUtils.GetFontHeight(font);
				}
				if (base.Skin is DateTimePickerSkin dateTimePickerSkin)
				{
					num += dateTimePickerSkin.Padding.Vertical;
				}
				return num;
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// Gets or sets the font style applied to the calendar.</summary>
		/// A <see cref="T:System.Drawing.Font"></see> that represents the font style applied to the calendar.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Font CalendarFont
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// 
		/// The default size.
		/// </value>
		protected override Size DefaultSize => new Size(200, PreferredHeight);

		/// 
		/// Occurs when the popup date windows is closed.
		/// </summary>
		public event EventHandler CloseUp
		{
			add
			{
				AddHandler(CloseUpEvent, value);
			}
			remove
			{
				RemoveHandler(CloseUpEvent, value);
			}
		}

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property changes.
		/// </summary>
		[SRDescription("valueChangedEventDescr")]
		[SRCategory("CatAction")]
		public event EventHandler ValueChanged
		{
			add
			{
				AddCriticalHandler(ValueChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValueChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("valueChangedEventDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientValueChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("checkedChangedEventDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientCheckedChanged
		{
			add
			{
				AddClientHandler("CheckedChange", value);
			}
			remove
			{
				RemoveClientHandler("CheckedChange", value);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("dropDownEventDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientDropDown
		{
			add
			{
				AddClientHandler("Browse", value);
			}
			remove
			{
				RemoveClientHandler("Browse", value);
			}
		}

		/// 
		/// Occurs when the value of the Checked property changes.
		/// </summary>
		public event EventHandler CheckedChanged
		{
			add
			{
				AddCriticalHandler(CheckedChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CheckedChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the Checked property changes (Queued).
		/// </summary>
		public event EventHandler CheckedChangedQueued
		{
			add
			{
				AddHandler(CheckedChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(CheckedChangedQueuedEvent, value);
			}
		}

		/// 
		/// Occurs when the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.ValueChanged"></see> property changes (queued).
		/// </summary>
		public event EventHandler ValueChangedQueued
		{
			add
			{
				AddHandler(ValueChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(ValueChangedQueuedEvent, value);
			}
		}

		/// 
		/// Static constructor.
		/// </summary>
		static DateTimePicker()
		{
			DateTimePickerFormatProperty = SerializableProperty.Register("DateTimePickerFormat", typeof(DateTimePickerFormat), typeof(DateTimePicker), new SerializablePropertyMetadata(DateTimePickerFormat.Long));
			CustomFormatProperty = SerializableProperty.Register("CustomFormat", typeof(string), typeof(DateTimePicker), new SerializablePropertyMetadata(string.Empty));
			ShowUpDownProperty = SerializableProperty.Register("ShowUpDown", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));
			ShowBothEditButtonsProperty = SerializableProperty.Register("ShowBothEditButtons", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));
			CalendarFirstDayOfWeekProperty = SerializableProperty.Register("CalendarFirstDayOfWeek", typeof(Day), typeof(DateTimePicker), new SerializablePropertyMetadata(Day.Default));
			EmptyDateYearProperty = SerializableProperty.Register("EmptyDateYear", typeof(int), typeof(DateTimePicker), new SerializablePropertyMetadata(0));
			ShowCheckBoxProperty = SerializableProperty.Register("ShowCheckBox", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));
			CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof(EventHandler), typeof(DateTimePicker));
			CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(DateTimePicker));
			CloseUpEvent = SerializableEvent.Register("CloseUp", typeof(EventHandler), typeof(DateTimePicker));
			mstrTimeFormat = "h:mm:ss tt";
			mstrShortFormat = "M/d/yyyy";
			mstrLongFormat = "dddd , MMMM dd, yyyy";
			marrTokens = new char[8] { 'd', 'm', 'M', 'y', 's', 't', 'h', 'H' };
			ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(DateTimePicker));
			ValueChangedQueuedEvent = SerializableEvent.Register("ValueChangedQueued", typeof(EventHandler), typeof(DateTimePicker));
			MinDateTime = new DateTime(1753, 1, 1);
			MaxDateTime = new DateTime(9998, 12, 31);
			Config instance = Config.GetInstance();
			if (instance != null)
			{
				mstrTimeFormat = instance.DefaultTimeFormat;
				mstrShortFormat = instance.DefaultShortDateFormat;
				mstrLongFormat = instance.DefaultLongDateFormat;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> class.
		/// </summary>
		public DateTimePicker()
		{
			mobjValue = DateTime.Today;
			mobjMaxValue = MaxDateTime;
			mobjMinValue = MinDateTime;
			SetStyle(ControlStyles.FixedHeight, blnValue: true);
			SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint, blnValue: false);
			SetState(ComponentState.Checked, blnValue: true);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mobjValue = objReader.ReadDateTime();
			mobjMaxValue = objReader.ReadDateTime();
			mobjMinValue = objReader.ReadDateTime();
			mblnUserHasSetValue = objReader.ReadBoolean();
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteDateTime(mobjValue);
			objWriter.WriteDateTime(mobjMaxValue);
			objWriter.WriteDateTime(mobjMinValue);
			objWriter.WriteBoolean(mblnUserHasSetValue);
		}

		/// 
		/// Gets the string of a date time object.
		/// </summary>
		/// <param name="value">Value.</param>
		/// </returns>
		private static string FormatDateTime(DateTime value)
		{
			return value.ToString("G");
		}

		/// 
		/// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
		/// </summary>
		/// A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see>. The string includes the type and the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property of the control.</returns>
		public override string ToString()
		{
			string text = base.ToString();
			return text + ", Value: " + FormatDateTime(Value);
		}

		/// 
		/// Sets the value internal.
		/// </summary>
		/// The value internal.</value>
		internal bool SetValueInternal(DateTime objValue)
		{
			if (objValue < MinDate || objValue > MaxDate)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (mobjValue != objValue)
			{
				mobjValue = objValue;
				mblnUserHasSetValue = true;
				OnValueChanged(EventArgs.Empty);
				OnValueChangedQueued(EventArgs.Empty);
				FireObservableItemPropertyChanged("Value");
				if (base.Parent != null && ShowCheckBox)
				{
					Checked = true;
				}
				return true;
			}
			return false;
		}

		/// 
		/// Shoulds the serialize value.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeValue()
		{
			return mblnUserHasSetValue;
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new DateTimePickerRenderer(this);
		}

		/// 
		/// Gets the width of the widest day.
		/// </summary>
		/// <param name="strFormat">The format.</param>
		/// </returns>
		private int GetWidestDayWidth(string strFormat)
		{
			int num = 0;
			Font font = Font;
			foreach (DayOfWeek value in Enum.GetValues(typeof(DayOfWeek)))
			{
				string strText = NormalizeDay(value, strFormat);
				int num2 = MeasureTextWidth(strText, font);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		/// 
		/// Gets the width of the widest month.
		/// </summary>
		/// <param name="strFormat">The format.</param>
		/// </returns>
		private int GetWidestMonthWidth(string strFormat)
		{
			int num = 0;
			Font font = Font;
			for (int i = 1; i <= 12; i++)
			{
				string strText = NormalizeMonth(i, strFormat);
				int num2 = MeasureTextWidth(strText, font);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		/// 
		/// Normalizes the month.
		/// </summary>
		/// <param name="intMonth">The int month.</param>
		/// <param name="strFormat">The STR format.</param>
		/// </returns>
		private string NormalizeMonth(int intMonth, string strFormat)
		{
			if (intMonth > 0 && intMonth <= 12)
			{
				return WGLabels.GetLocalizedMonthString(intMonth, strFormat == "MMM", Global.Context, blnGenitiveName: true);
			}
			return "???";
		}

		/// 
		/// Gets the normalized day value
		/// </summary>
		/// <param name="enmDayOfWeek"></param>
		/// <param name="strFormat"></param>
		/// </returns>
		private string NormalizeDay(DayOfWeek enmDayOfWeek, string strFormat)
		{
			if (strFormat == "ddd")
			{
				switch (enmDayOfWeek)
				{
				case DayOfWeek.Sunday:
					return WGLabels.GetString("SundayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Monday:
					return WGLabels.GetString("MondayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Tuesday:
					return WGLabels.GetString("TuesdayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Wednesday:
					return WGLabels.GetString("WednesdayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Thursday:
					return WGLabels.GetString("ThursdayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Friday:
					return WGLabels.GetString("FridayShort", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Saturday:
					return WGLabels.GetString("SaturdayShort", Global.Context, blnApplyCultureInfoValues: true);
				}
			}
			else
			{
				switch (enmDayOfWeek)
				{
				case DayOfWeek.Sunday:
					return WGLabels.GetString("Sunday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Monday:
					return WGLabels.GetString("Monday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Tuesday:
					return WGLabels.GetString("Tuesday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Wednesday:
					return WGLabels.GetString("Wednesday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Thursday:
					return WGLabels.GetString("Thursday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Friday:
					return WGLabels.GetString("Friday", Global.Context, blnApplyCultureInfoValues: true);
				case DayOfWeek.Saturday:
					return WGLabels.GetString("Saturday", Global.Context, blnApplyCultureInfoValues: true);
				}
			}
			return "???";
		}

		/// 
		/// Utility mehtod for checking it a char exists in a char array
		/// </summary>
		/// <param name="arrChars"></param>
		/// <param name="chrValue"></param>
		/// </returns>
		private bool IsCharContained(char[] arrChars, char chrValue)
		{
			foreach (char c in arrChars)
			{
				if (c == chrValue)
				{
					return true;
				}
			}
			return false;
		}

		/// 
		/// Gets a AP/PM valued hour
		/// </summary>
		/// <param name="intHour">The int hour.</param>
		/// <param name="blnShort">if set to true</c> [BLN short].</param>
		/// </returns>
		private string NormalizeAMPM(int intHour, bool blnShort)
		{
			if (intHour > 11)
			{
				return WGLabels.GetLocalizedAMPMDesignatorString(blnAM: false, blnShort, Context);
			}
			return WGLabels.GetLocalizedAMPMDesignatorString(blnAM: true, blnShort, Context);
		}

		/// 
		/// Gets a AP/PM valued hour
		/// </summary>
		/// <param name="intHour"></param>
		/// </returns>
		private int NormalizeAMPMIndex(int intHour)
		{
			if (intHour > 11)
			{
				return 2;
			}
			return 1;
		}

		/// 
		/// Gets a 0-12 valued hour
		/// </summary>
		/// <param name="intValue"></param>
		/// </returns>
		private int NormalizeHour(int intValue)
		{
			if (intValue < 13)
			{
				if (intValue == 0)
				{
					return 12;
				}
				return intValue;
			}
			return intValue - 12;
		}

		/// 
		/// Normalizes the year.
		/// </summary>
		/// <param name="intValue">The int value.</param>
		/// <param name="intPlaces">The int places.</param>
		/// </returns>
		private string NormalizeYear(int intValue, int intPlaces)
		{
			string text = intValue.ToString();
			switch (intPlaces)
			{
			case 1:
				text = Convert.ToInt32(text.Substring(2)).ToString();
				break;
			case 2:
				text = text.Substring(2);
				break;
			}
			return text;
		}

		/// 
		/// Utility method for padding numbers
		/// </summary>
		/// <param name="intValue">The int value.</param>
		/// <param name="intPlaces">The int places.</param>
		/// <param name="blnCrop">if set to true</c> [BLN crop].</param>
		/// </returns>
		private string NormalizeNumber(int intValue, int intPlaces, bool blnCrop)
		{
			return NormalizeNumber(intValue.ToString(), intPlaces, blnCrop);
		}

		/// 
		/// Utility method for padding numbers
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <param name="intPlaces">The int places.</param>
		/// <param name="blnCrop">if set to true</c> [BLN crop].</param>
		/// </returns>
		private string NormalizeNumber(string strValue, int intPlaces, bool blnCrop)
		{
			if (strValue.Length < intPlaces)
			{
				string text = "";
				for (int i = strValue.Length; i < intPlaces; i++)
				{
					text += "0";
				}
				return text + strValue;
			}
			if (strValue.Length > intPlaces && blnCrop)
			{
				return strValue.Substring(strValue.Length - intPlaces, intPlaces);
			}
			return strValue;
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("CB", ShowCheckBox ? "1" : "0");
			if (ShowCheckBox)
			{
				objWriter.WriteAttributeString("C", Checked ? "1" : "0");
			}
			RenderShowUpDownAttribute(objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("DT", Value.Ticks.ToString());
			if (MinDate != MinDateTime)
			{
				objWriter.WriteAttributeString("MND", MinDate.Ticks.ToString());
			}
			if (MaxDate != MaxDateTime)
			{
				objWriter.WriteAttributeString("MXD", MaxDate.Ticks.ToString());
			}
			if (CalendarFirstDayOfWeek != Day.Default)
			{
				objWriter.WriteAttributeString("FDW", CalendarFirstDayOfWeek.ToString());
			}
			if (EmptyDateYear != 0)
			{
				objWriter.WriteAttributeString("EDY", EmptyDateYear.ToString());
			}
		}

		/// 
		/// Renders the show up down attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowUpDownAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (ShowBothEditButtons)
			{
				objWriter.WriteAttributeString("SUD", "2");
			}
			else if (ShowUpDown)
			{
				objWriter.WriteAttributeString("SUD", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SUD", "0");
			}
		}

		/// 
		/// Render the datetimepicker formating
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			string strFormat = CurrentFormat;
			while (!string.IsNullOrEmpty(strFormat))
			{
				bool blnIsToken = false;
				string strContent = string.Empty;
				GetNextContentPart(ref strFormat, out strContent, out blnIsToken);
				if (!string.IsNullOrEmpty(strContent))
				{
					if (blnIsToken)
					{
						RenderToken(objWriter, strContent);
					}
					else
					{
						RenderLiteral(objWriter, strContent);
					}
				}
			}
		}

		/// 
		/// Gets the next content part.
		/// </summary>
		/// <param name="strFormat">The format.</param>
		/// <param name="strContent">Content of the token / literal.</param>
		/// <param name="blnIsToken">if set to true</c> [BLN is token].</param>
		protected void GetNextContentPart(ref string strFormat, out string strContent, out bool blnIsToken)
		{
			blnIsToken = false;
			strContent = string.Empty;
			if (string.IsNullOrEmpty(strFormat))
			{
				return;
			}
			if (StartsWithToken(strFormat, ref strContent))
			{
				blnIsToken = true;
				strFormat = strFormat.Remove(0, strContent.Length);
			}
			else if (strFormat.StartsWith("'", StringComparison.InvariantCulture))
			{
				int num = strFormat.IndexOf('\'', 1);
				if (num != -1)
				{
					strContent = strFormat.Substring(1, num - 1);
					strFormat = strFormat.Substring(num + 1);
				}
				else
				{
					strContent = strFormat.Substring(1);
					strFormat = string.Empty;
				}
			}
			else
			{
				int num2 = strFormat.IndexOfAny(marrTokens);
				if (num2 != -1)
				{
					strContent = strFormat.Substring(0, num2);
					strFormat = strFormat.Substring(num2);
				}
				else
				{
					strContent = strFormat.Replace("'", "");
					strFormat = string.Empty;
				}
			}
		}

		/// 
		/// Checks whether recieved format starts with a token.
		/// </summary>
		/// <param name="strFormat">The format.</param>
		/// <param name="strContent">Content of the token / literal.</param>
		/// </returns>
		private bool StartsWithToken(string strFormat, ref string strContent)
		{
			bool result = true;
			if (strFormat.StartsWith("dddd", StringComparison.InvariantCulture))
			{
				strContent = "dddd";
			}
			else if (strFormat.StartsWith("ddd", StringComparison.InvariantCulture))
			{
				strContent = "ddd";
			}
			else if (strFormat.StartsWith("dd", StringComparison.InvariantCulture))
			{
				strContent = "dd";
			}
			else if (strFormat.StartsWith("d", StringComparison.InvariantCulture))
			{
				strContent = "d";
			}
			else if (strFormat.StartsWith("yyyy", StringComparison.InvariantCulture))
			{
				strContent = "yyyy";
			}
			else if (strFormat.StartsWith("yy", StringComparison.InvariantCulture))
			{
				strContent = "yy";
			}
			else if (strFormat.StartsWith("y", StringComparison.InvariantCulture))
			{
				strContent = "y";
			}
			else if (strFormat.StartsWith("hh", StringComparison.InvariantCulture))
			{
				strContent = "hh";
			}
			else if (strFormat.StartsWith("h", StringComparison.InvariantCulture))
			{
				strContent = "h";
			}
			else if (strFormat.StartsWith("HH", StringComparison.InvariantCulture))
			{
				strContent = "HH";
			}
			else if (strFormat.StartsWith("H", StringComparison.InvariantCulture))
			{
				strContent = "H";
			}
			else if (strFormat.StartsWith("MMMM", StringComparison.InvariantCulture))
			{
				strContent = "MMMM";
			}
			else if (strFormat.StartsWith("MMM", StringComparison.InvariantCulture))
			{
				strContent = "MMM";
			}
			else if (strFormat.StartsWith("MM", StringComparison.InvariantCulture))
			{
				strContent = "MM";
			}
			else if (strFormat.StartsWith("M", StringComparison.InvariantCulture))
			{
				strContent = "M";
			}
			else if (strFormat.StartsWith("mm", StringComparison.InvariantCulture))
			{
				strContent = "mm";
			}
			else if (strFormat.StartsWith("m", StringComparison.InvariantCulture))
			{
				strContent = "m";
			}
			else if (strFormat.StartsWith("ss", StringComparison.InvariantCulture))
			{
				strContent = "ss";
			}
			else if (strFormat.StartsWith("s", StringComparison.InvariantCulture))
			{
				strContent = "s";
			}
			else if (strFormat.StartsWith("tt", StringComparison.InvariantCulture))
			{
				strContent = "tt";
			}
			else if (strFormat.StartsWith("t", StringComparison.InvariantCulture))
			{
				strContent = "t";
			}
			else
			{
				result = false;
			}
			return result;
		}

		/// 
		/// Renders a datetimepicker literal
		/// </summary>
		/// <param name="objWriter"></param>
		/// <param name="strLiteral"></param>
		private void RenderLiteral(IResponseWriter objWriter, string strLiteral)
		{
			if (!string.IsNullOrEmpty(strLiteral))
			{
				objWriter.WriteStartElement("LT");
				objWriter.WriteAttributeString("VLB", strLiteral);
				objWriter.WriteAttributeString("SZ", MeasureTextWidth(strLiteral, Font).ToString());
				objWriter.WriteEndElement();
			}
		}

		/// 
		/// Measures the width of the text.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// </returns>
		private int MeasureTextWidth(string strText, Font objFont)
		{
			int result = 0;
			if (!string.IsNullOrEmpty(strText))
			{
				StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				result = CommonUtils.GetStringMeasurements(strText, Font, -1, Point.Empty, stringFormat).Width;
			}
			return result;
		}

		/// 
		/// Renders a datetimepicker token
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="strLiteral">The STR literal.</param>
		private void RenderToken(IResponseWriter objWriter, string strLiteral)
		{
			objWriter.WriteStartElement("TK");
			objWriter.WriteAttributeString("FMT", strLiteral);
			string text = string.Empty;
			int num = 0;
			string text2 = string.Empty;
			bool flag = false;
			int num2 = -1;
			switch (strLiteral)
			{
			case "d":
				text = Value.Day.ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				text2 = "dd,ddd,dddd";
				break;
			case "dd":
				text = NormalizeNumber(Value.Day, 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				text2 = "d,ddd,dddd";
				break;
			case "ddd":
				num = GetWidestDayWidth("ddd");
				flag = true;
				text = NormalizeDay(Value.DayOfWeek, "ddd");
				num2 = Convert.ToInt32(Value.DayOfWeek) + 1;
				break;
			case "dddd":
				num = GetWidestDayWidth("dddd");
				flag = true;
				text = NormalizeDay(Value.DayOfWeek, "dddd");
				num2 = Convert.ToInt32(Value.DayOfWeek) + 1;
				break;
			case "y":
				text = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(Value), 1);
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				text2 = "d,dd,ddd,dddd";
				break;
			case "yy":
				text = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(Value), 2);
				num = MeasureTextWidth(text, Font);
				text2 = "d,dd,ddd,dddd";
				break;
			case "yyyy":
				text = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(Value), 4);
				num = MeasureTextWidth(text, Font);
				text2 = "d,dd,ddd,dddd";
				break;
			case "h":
				text = NormalizeHour(Value.Hour).ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				text2 = "t,tt";
				break;
			case "hh":
				text = NormalizeNumber(NormalizeHour(Value.Hour), 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				text2 = "t,tt";
				break;
			case "H":
				text = Value.Hour.ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				text2 = "t,tt";
				break;
			case "HH":
				text = NormalizeNumber(Value.Hour, 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				text2 = "t,tt";
				break;
			case "M":
				text = Value.Month.ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				text2 = "d,dd,ddd,dddd,MM,MMM,MMMM";
				break;
			case "MM":
				text = NormalizeNumber(Value.Month, 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				text2 = "d,dd,ddd,dddd,M,MMM,MMMM";
				break;
			case "MMM":
				num = GetWidestMonthWidth("MMM");
				text = NormalizeMonth(Value.Month, "MMM");
				num2 = Value.Month;
				text2 = "d,dd,ddd,dddd,M,MM,MMMM";
				break;
			case "MMMM":
				num = GetWidestMonthWidth("MMMM");
				text = NormalizeMonth(Value.Month, "MMMM");
				num2 = Value.Month;
				text2 = "d,dd,ddd,dddd,M,MM,MMM";
				break;
			case "m":
				text = Value.Minute.ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				break;
			case "mm":
				text = NormalizeNumber(Value.Minute, 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				break;
			case "s":
				text = Value.Second.ToString();
				num = MeasureTextWidth(NormalizeNumber(text, 2, blnCrop: false), Font);
				break;
			case "ss":
				text = NormalizeNumber(Value.Second, 2, blnCrop: false);
				num = MeasureTextWidth(text, Font);
				break;
			case "t":
				text = NormalizeAMPM(Value.Hour, blnShort: true);
				num = MeasureTextWidth(text, Font);
				num2 = NormalizeAMPMIndex(Value.Hour);
				text2 = "H,HH";
				break;
			case "tt":
				text = NormalizeAMPM(Value.Hour, blnShort: false);
				num = MeasureTextWidth(text, Font);
				num2 = NormalizeAMPMIndex(Value.Hour);
				text2 = "H,HH";
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				objWriter.WriteAttributeString("VLB", text);
			}
			if (num > 0)
			{
				objWriter.WriteAttributeString("SZ", num.ToString());
			}
			if (num2 >= 0)
			{
				objWriter.WriteAttributeString("IX", num2.ToString());
			}
			if (!string.IsNullOrEmpty(text2))
			{
				objWriter.WriteAttributeString("EF", text2);
			}
			if (flag)
			{
				objWriter.WriteAttributeString("RO", "1");
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeString("CB", ShowCheckBox ? "1" : "0");
				if (ShowCheckBox)
				{
					objWriter.WriteAttributeString("C", Checked ? "1" : "0");
				}
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderShowUpDownAttribute(objWriter, blnForceRender: true);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DateTimePicker.CloseUp"></see> event.</summary>
		/// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal virtual void OnCloseUp(EventArgs objEventArgs)
		{
			CloseUpHandler?.Invoke(this, objEventArgs);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DateTimePicker.ValueChanged"></see> event.</summary>
		/// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnValueChanged(EventArgs objEventArgs)
		{
			ValueChangedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:ValueChangedQueued" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnValueChangedQueued(EventArgs objEventArgs)
		{
			ValueChangedQueuedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.CheckedChanged"></see> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckedChanged(EventArgs objEventArgs)
		{
			CheckedChangedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			base.Height = PreferredHeight;
		}

		/// 
		/// Raises the CheckedChangedQueued event
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
		{
			CheckedChangedQueuedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			bool flag = false;
			switch (objEvent.Type)
			{
			case "Browse":
			{
				DateTimePickerPopup dateTimePickerPopup = GetDateTimePickerPopup();
				if (dateTimePickerPopup != null)
				{
					if (ShowCheckBox && !Checked)
					{
						Checked = true;
					}
					dateTimePickerPopup.ShowPopup(this, DialogAlignment.Below);
				}
				dateTimePickerPopup = null;
				break;
			}
			case "CheckedChange":
			{
				bool result2 = false;
				if (bool.TryParse(objEvent["Value"], out result2) && Checked != result2)
				{
					CheckedInternal = result2;
				}
				break;
			}
			case "ValueChange":
			{
				string text = objEvent["Value"];
				if (!string.IsNullOrEmpty(text))
				{
					long result = -1L;
					if (long.TryParse(text, out result))
					{
						SetValueInternal(new DateTime(result));
					}
				}
				break;
			}
			default:
				flag = true;
				break;
			}
			if (flag)
			{
				base.FireEvent(objEvent);
			}
		}

		/// 
		/// Gets the date time picker popup.
		/// </summary>
		/// </returns>
		protected virtual DateTimePickerPopup GetDateTimePickerPopup()
		{
			return new DateTimePickerPopup(this);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (ValueChangedHandler != null)
			{
				criticalEventsData.Set("VC");
			}
			if (CheckedChangedHandler != null || ValueChangedHandler != null)
			{
				criticalEventsData.Set("CC");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			if (HasClientHandler("CheckedChange"))
			{
				criticalClientEventsData.Set("CC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Resets the value.
		/// </summary>
		private void ResetValue()
		{
			Value = DateTime.Today;
		}

		/// 
		/// Indicates if format should be serialized
		/// </summary>
		/// </returns>
		private bool ShouldSerializeFormat()
		{
			return Format != DateTimePickerFormat.Long;
		}

		/// 
		/// Resets the max date.
		/// </summary>
		private void ResetMaxDate()
		{
			MaxDate = MaxDateTime;
		}

		private bool ShouldSerializeMaxDate()
		{
			return MaxDate != MaxDateTime;
		}

		/// 
		/// Resets the MinDate.
		/// </summary>
		private void ResetMinDate()
		{
			MinDate = MinDateTime;
		}

		/// 
		/// Shoulds the serialize min date.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMinDate()
		{
			return MinDate != MinDateTime;
		}
	}
}
