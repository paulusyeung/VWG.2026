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
	/// A calendar control.
	/// </summary>
	[Serializable]
	[DefaultEvent("DateChanged")]
	[ToolboxBitmap(typeof(MonthCalendar), "MonthCalendar_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("MC")]
	[Skin(typeof(MonthCalendarSkin))]
	public class MonthCalendar : Control
	{
		/// 
		///
		/// </summary>
		protected internal enum CalanderViewTypes
		{
			/// 
			///
			/// </summary>
			Day,
			/// 
			///
			/// </summary>
			Month,
			/// 
			///
			/// </summary>
			Year,
			/// 
			///
			/// </summary>
			YearRange
		}

		/// 
		/// Provides a property reference to FirstDayOfWeek property.
		/// </summary>
		private static SerializableProperty FirstDayOfWeekProperty = SerializableProperty.Register("FirstDayOfWeek", typeof(Day), typeof(MonthCalendar), new SerializablePropertyMetadata(Day.Default));

		/// 
		/// Provides a property reference to Form property.
		/// </summary>
		private static SerializableProperty FormProperty = SerializableProperty.Register("Form", typeof(DateTimePickerPopup), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to DateTimePicker property.
		/// </summary>
		private static SerializableProperty DateTimePickerProperty = SerializableProperty.Register("DateTimePicker", typeof(DateTimePicker), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to Position property.
		/// </summary>
		private static SerializableProperty PositionProperty = SerializableProperty.Register("Position", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to Value property.
		/// </summary>
		private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to BoldedDates property.
		/// </summary>
		private static SerializableProperty BoldedDatesProperty = SerializableProperty.Register("BoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to AnnuallyBoldedDates property.
		/// </summary>
		private static SerializableProperty AnnuallyBoldedDatesProperty = SerializableProperty.Register("AnnuallyBoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to MonthlyBoldedDates property.
		/// </summary>
		private static SerializableProperty MonthlyBoldedDatesProperty = SerializableProperty.Register("MonthlyBoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to CalanderViewType property.
		/// </summary>
		private static SerializableProperty CalanderViewTypeProperty = SerializableProperty.Register("CalanderViewType", typeof(CalanderViewTypes), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to TodayDate property.
		/// </summary>
		private static SerializableProperty TodayDateProperty = SerializableProperty.Register("TodayDate", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to SelectionStart property.
		/// </summary>
		private static SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to SelectionEnd property.
		/// </summary>
		private static SerializableProperty SelectionEndProperty = SerializableProperty.Register("SelectionEnd", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to MaxDate property.
		/// </summary>
		private static SerializableProperty MaxDateProperty = SerializableProperty.Register("MaxDate", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to MinDate property.
		/// </summary>
		private static SerializableProperty MinDateProperty = SerializableProperty.Register("MinDate", typeof(DateTime), typeof(MonthCalendar));

		/// 
		/// Provides a property reference to MaxSelectionCount property.
		/// </summary>
		private static SerializableProperty MaxSelectionCountProperty = SerializableProperty.Register("MaxSelectionCount", typeof(int), typeof(MonthCalendar));

		private static SerializableProperty TodatDateProperty = SerializableProperty.Register("TodatDate", typeof(DateTime[]), typeof(MonthCalendar));

		private static SerializableProperty TodayDateSetProperty = SerializableProperty.Register("TodayDateSet", typeof(bool), typeof(MonthCalendar));

		private CalendarUtils.SelectDirection menmSelectionDirection = CalendarUtils.SelectDirection.None;

		/// 
		/// The DateChanged event registration.
		/// </summary>
		private static readonly SerializableEvent DateChangedEvent;

		/// 
		/// The ValueChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ValueChangedEvent;

		/// 
		/// Gets or sets the bolded dates.
		/// </summary>
		/// The bolded dates.</value>
		public DateTime[] BoldedDates
		{
			get
			{
				return GetValue(BoldedDatesProperty, new DateTime[0]);
			}
			set
			{
				if (value != BoldedDates)
				{
					if (value == null || value.Length == 0)
					{
						RemoveValue<DateTime[]>(BoldedDatesProperty);
					}
					else
					{
						SetValue(BoldedDatesProperty, value);
					}
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the annually bolded dates.
		/// </summary>
		/// The annually bolded dates.</value>
		public DateTime[] AnnuallyBoldedDates
		{
			get
			{
				return GetValue(AnnuallyBoldedDatesProperty, new DateTime[0]);
			}
			set
			{
				if (value != AnnuallyBoldedDates)
				{
					if (value == null || value.Length == 0)
					{
						RemoveValue<DateTime[]>(AnnuallyBoldedDatesProperty);
					}
					else
					{
						SetValue(AnnuallyBoldedDatesProperty, value);
					}
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the monthly bolded dates property.
		/// </summary>
		/// The monthly bolded dates property.</value>
		public DateTime[] MonthlyBoldedDates
		{
			get
			{
				return GetValue(MonthlyBoldedDatesProperty, new DateTime[0]);
			}
			set
			{
				if (value != MonthlyBoldedDates)
				{
					if (value == null || value.Length == 0)
					{
						RemoveValue<DateTime[]>(MonthlyBoldedDatesProperty);
					}
					else
					{
						SetValue(MonthlyBoldedDatesProperty, value);
					}
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// The calendar date time value
		/// </summary>
		private DateTime ValueInternal
		{
			get
			{
				return GetValue(ValueProperty, DateTime.Now);
			}
			set
			{
				if (Value != value)
				{
					if (value != DateTime.Now)
					{
						SetValue(ValueProperty, value);
					}
					else
					{
						RemoveValue(ValueProperty);
					}
				}
			}
		}

		/// 
		/// The calendar date time displayed position
		/// </summary>
		private DateTime Position
		{
			get
			{
				return GetValue(PositionProperty, DateTime.Now);
			}
			set
			{
				if (value != Position)
				{
					if (value != DateTime.Now)
					{
						SetValue(PositionProperty, value);
					}
					else
					{
						RemoveValue(PositionProperty);
					}
				}
			}
		}

		private DateTimePicker DateTimePickerInternal
		{
			get
			{
				return GetValue(DateTimePickerProperty);
			}
			set
			{
				if (DateTimePickerInternal != value)
				{
					SetValue(DateTimePickerProperty, value);
				}
			}
		}

		/// 
		/// The calendar owner form
		/// </summary>
		private DateTimePickerPopup CalendarForm
		{
			get
			{
				return GetValue(FormProperty);
			}
			set
			{
				if (CalendarForm != value)
				{
					SetValue(FormProperty, value);
				}
			}
		}

		/// 
		/// Gets the hanlder for the DateChanged event.
		/// </summary>
		private EventHandler DateChangedHandler => (EventHandler)GetHandler(DateChanged);

		/// 
		/// Gets the hanlder for the ValueChanged event.
		/// </summary>
		private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChanged);

		/// Gets or sets the first day of the week as displayed in the month calendar.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
		[SRDescription("MonthCalendarFirstDayOfWeekDescr")]
		[DefaultValue(Day.Default)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		public Day FirstDayOfWeek
		{
			get
			{
				return GetValue(FirstDayOfWeekProperty, Day.Default);
			}
			set
			{
				if (SetValue(FirstDayOfWeekProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the maximum number of days that can be selected in a month calendar control.
		/// </summary>
		/// 
		/// The max selection count.
		/// </value>
		[DefaultValue(7)]
		[Category("Behavior")]
		public int MaxSelectionCount
		{
			get
			{
				return GetValue(MaxSelectionCountProperty, 7);
			}
			set
			{
				if (value < 1)
				{
					object[] arrArgs = new object[3]
					{
						"MaxSelectionCount",
						value.ToString("D", CultureInfo.CurrentCulture),
						1.ToString(Application.CurrentUICulture)
					};
					throw new ArgumentOutOfRangeException("MaxSelectionCount", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (MaxSelectionCount != value)
				{
					SetValue(MaxSelectionCountProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the max date.
		/// </summary>
		/// 
		/// The max date.
		/// </value>
		[SRDescription("MonthCalendarMaxDateDescr")]
		[SRCategory("CatBehavior")]
		public DateTime MaxDate
		{
			get
			{
				DateTime value = GetValue(MaxDateProperty, CalendarUtils.MaxDateTime);
				return CalendarUtils.GetEffectiveMaxDate(value);
			}
			set
			{
				if (value != MaxDate)
				{
					DateTime effectiveMinDate = CalendarUtils.GetEffectiveMinDate(MinDate);
					DateTime effectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(MaxDate);
					if (value < effectiveMinDate)
					{
						throw new ArgumentOutOfRangeException("MaxDate", SR.GetString("InvalidLowBoundArgumentEx", "MaxDate", FormatDate(value), "MinDate"));
					}
					if (value != CalendarUtils.MaxDateTime)
					{
						SetValue(MaxDateProperty, value);
					}
					else
					{
						RemoveValue(MaxDateProperty);
					}
					SetMinMaxRange(effectiveMinDate, effectiveMaxDate);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the min date.
		/// </summary>
		/// 
		/// The min date.
		/// </value>
		[SRDescription("MonthCalendarMinDateDescr")]
		[SRCategory("CatBehavior")]
		public DateTime MinDate
		{
			get
			{
				DateTime value = GetValue(MinDateProperty, CalendarUtils.MinDateTime);
				return CalendarUtils.GetEffectiveMinDate(value);
			}
			set
			{
				if (value != MinDate)
				{
					DateTime effectiveMinDate = CalendarUtils.GetEffectiveMinDate(MinDate);
					DateTime effectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(MaxDate);
					if (value > effectiveMaxDate)
					{
						throw new ArgumentOutOfRangeException("MinDate", SR.GetString("InvalidHighBoundArgument", "MinDate", FormatDate(value), "MaxDate"));
					}
					if (value < CalendarUtils.MinimumDateTime)
					{
						throw new ArgumentOutOfRangeException("MinDate", SR.GetString("InvalidLowBoundArgumentEx", "MinDate", FormatDate(value), FormatDate(CalendarUtils.MinimumDateTime)));
					}
					if (value != CalendarUtils.MinDateTime)
					{
						SetValue(MinDateProperty, value);
					}
					else
					{
						RemoveValue(MinDateProperty);
					}
					SetMinMaxRange(effectiveMinDate, effectiveMaxDate);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the end date of the selected range of dates.
		/// </summary>
		/// 
		/// The selection end.
		/// </value>
		[Browsable(false)]
		public DateTime SelectionEnd
		{
			get
			{
				return GetValue(SelectionEndProperty, DateTime.Now.Date);
			}
			set
			{
				if (SelectionEnd != value)
				{
					if (value < MinDate)
					{
						throw new ArgumentOutOfRangeException("SelectionEnd", SR.GetString("InvalidLowBoundArgumentEx", "SelectionEnd", FormatDate(value), "MinDate"));
					}
					if (value > MaxDate)
					{
						throw new ArgumentOutOfRangeException("SelectionEnd", SR.GetString("InvalidHighBoundArgumentEx", "SelectionEnd", FormatDate(value), "MaxDate"));
					}
					if (SelectionStart > value)
					{
						SelectionStartInternal = value;
					}
					if ((value - SelectionStart).Days >= MaxSelectionCount)
					{
						SelectionStartInternal = value.AddDays(1 - MaxSelectionCount);
					}
					SetRange(SelectionStart, value);
				}
			}
		}

		/// 
		/// Sets the SelectionEnd serialized property.
		/// </summary>
		/// 
		/// The selection End setter.
		/// </value>
		private DateTime SelectionEndInternal
		{
			set
			{
				if (value != DateTime.Now.Date)
				{
					SetValue(SelectionEndProperty, value);
				}
				else
				{
					RemoveValue(SelectionEndProperty);
				}
			}
		}

		/// 
		/// Gets or sets the start date of the selected range of dates.
		/// </summary>
		/// 
		/// The selection start.
		/// </value>
		[Browsable(false)]
		public DateTime SelectionStart
		{
			get
			{
				return GetValue(SelectionStartProperty, DateTime.Now.Date);
			}
			set
			{
				if (SelectionStart != value)
				{
					if (value < MinDate)
					{
						throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidLowBoundArgumentEx", "SelectionStart", FormatDate(value), "MinDate"));
					}
					if (value > MaxDate)
					{
						throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidHighBoundArgumentEx", "SelectionStart", FormatDate(value), "MaxDate"));
					}
					if (SelectionEnd < value)
					{
						SelectionEndInternal = value;
					}
					if ((SelectionEnd - value).Days >= MaxSelectionCount)
					{
						SelectionEndInternal = value.AddDays(MaxSelectionCount - 1);
					}
					SetRange(value, SelectionEnd);
				}
			}
		}

		/// 
		/// Sets the SelectionStart serialized property.
		/// </summary>
		/// 
		/// The selection start setter.
		/// </value>
		private DateTime SelectionStartInternal
		{
			set
			{
				if (value != DateTime.Now.Date)
				{
					SetValue(SelectionStartProperty, value);
				}
				else
				{
					RemoveValue(SelectionStartProperty);
				}
			}
		}

		/// 
		/// Gets or sets the selected range of dates for a month calendar control.
		/// </summary>
		/// 
		/// The selection range.
		/// </value>
		[Bindable(true)]
		[Category("Behavior")]
		public SelectionRange SelectionRange
		{
			get
			{
				return new SelectionRange(SelectionStart, SelectionEnd);
			}
			set
			{
				SetSelectionRange(value.Start, value.End);
			}
		}

		/// 
		/// Gets or sets the current date.
		/// </summary>
		/// </value>
		[SRDescription("MonthCalendarSelectionValueDescr")]
		[SRCategory("CatBehavior")]
		[Bindable(true)]
		public DateTime Value
		{
			get
			{
				return GetValue(ValueProperty, DateTime.Now.Date);
			}
			set
			{
				if (Value != value)
				{
					if (value != DateTime.Now.Date)
					{
						SetValue(ValueProperty, value);
					}
					else
					{
						RemoveValue(ValueProperty);
					}
					if (value > SelectionEnd || value < SelectionStart)
					{
						SetRange(value, value);
					}
					else
					{
						OnValueChanged(new EventArgs());
					}
				}
			}
		}

		/// 
		/// Gets or sets the type of the calander view.
		/// </summary>
		/// The type of the calander view.</value>
		protected internal CalanderViewTypes CalanderViewType
		{
			get
			{
				return GetValue(CalanderViewTypeProperty, CalanderViewTypes.Day);
			}
			set
			{
				if (CalanderViewType != value)
				{
					if (value != CalanderViewTypes.Day)
					{
						SetValue(CalanderViewTypeProperty, value);
					}
					else
					{
						RemoveValue(CalanderViewTypeProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(176, 153);

		/// 
		/// Gets or sets the today date.
		/// </summary>
		/// 
		/// The today date.
		/// </value>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// TodayDate
		/// </exception>
		[SRDescription("MonthCalendarTodayDateDescr")]
		[SRCategory("CatBehavior")]
		public DateTime TodayDate
		{
			get
			{
				if (TodayDateSet)
				{
					return GetValue(TodatDateProperty);
				}
				return DateTime.Now.Date;
			}
			set
			{
				if (!TodayDateSet || DateTime.Compare(value, GetValue(TodatDateProperty)) != 0)
				{
					if (DateTime.Compare(value, MaxDate) > 0)
					{
						throw new ArgumentOutOfRangeException("TodayDate", SR.GetString("InvalidHighBoundArgumentEx", "TodayDate", FormatDate(value), FormatDate(MaxDate)));
					}
					if (DateTime.Compare(value, MinDate) < 0)
					{
						throw new ArgumentOutOfRangeException("TodayDate", SR.GetString("InvalidLowBoundArgument", "TodayDate", FormatDate(value), FormatDate(MinDate)));
					}
					SetValue(TodatDateProperty, value.Date);
					TodayDateSet = true;
					Update();
				}
			}
		}

		/// 
		/// Gets a value indicating whether [today date set].
		/// </summary>
		/// 
		///   true</c> if [today date set]; otherwise, false</c>.
		/// </value>
		[SRDescription("MonthCalendarTodayDateSetDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatBehavior")]
		public bool TodayDateSet
		{
			get
			{
				return GetValue(TodayDateSetProperty, objDefault: false);
			}
			private set
			{
				SetValue(TodayDateSetProperty, value);
			}
		}

		/// 
		/// Occurs when the date is changed
		/// </summary>
		public event EventHandler DateChanged
		{
			add
			{
				AddCriticalHandler(DateChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DateChangedEvent, value);
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
				AddHandler(ValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ValueChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client date changed].
		/// </summary>
		[SRDescription("dateChangedEventDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientDateChanged
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
		/// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImage"></see> property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler BackgroundImageChanged
		{
			add
			{
				base.BackgroundImageChanged += value;
			}
			remove
			{
				base.BackgroundImageChanged -= value;
			}
		}

		/// 
		/// Occurs when the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImageLayout"></see> property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler BackgroundImageLayoutChanged
		{
			add
			{
				base.BackgroundImageLayoutChanged += value;
			}
			remove
			{
				base.BackgroundImageLayoutChanged -= value;
			}
		}

		/// 
		/// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler Click
		{
			add
			{
				base.Click += value;
			}
			remove
			{
				base.Click -= value;
			}
		}

		/// 
		/// Occurs when the user double-clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler DoubleClick
		{
			add
			{
				base.DoubleClick += value;
			}
			remove
			{
				base.DoubleClick -= value;
			}
		}

		/// 
		/// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control with the mouse.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event MouseEventHandler MouseClick
		{
			add
			{
				base.MouseClick += value;
			}
			remove
			{
				base.MouseClick -= value;
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Padding"></see> property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler PaddingChanged
		{
			add
			{
				base.PaddingChanged += value;
			}
			remove
			{
				base.PaddingChanged -= value;
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Text"></see> property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler TextChanged
		{
			add
			{
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MonthCalendar" /> instance.
		/// </summary>
		public MonthCalendar()
		{
			base.Size = new Size(179, 155);
			SetStyle(ControlStyles.UserPaint, blnValue: false);
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			InitializeComponent();
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MonthCalendar" /> instance.
		/// </summary>
		internal MonthCalendar(DateTimePicker objDateTimePicker, DateTimePickerPopup objCalendarForm)
		{
			base.Size = new Size(179, 155);
			DateTimePickerInternal = objDateTimePicker;
			CalendarForm = objCalendarForm;
			if (objDateTimePicker != null)
			{
				Position = (ValueInternal = objDateTimePicker.Value);
			}
			SetStyle(ControlStyles.UserPaint, blnValue: false);
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			DateTime valueInternal = (Position = DateTime.Now);
			ValueInternal = valueInternal;
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			int num = 0;
			DateTime dateTime = new DateTime(Position.Year, Position.Month, 1, 0, 0, 0);
			dateTime = ((DateTime.MaxValue.Year != dateTime.Year || DateTime.MaxValue.Month != dateTime.Month) ? dateTime.AddMonths(1).AddDays(-1.0) : new DateTime(9999, 12, 31, 0, 0, 0));
			int displayStartIndex = GetDisplayStartIndex();
			DateTime position = Position;
			DateTime dateTime2 = position.AddDays(-position.Day);
			objWriter.WriteAttributeString("DisplayStart", displayStartIndex.ToString());
			objWriter.WriteAttributeString("DisplayDays", dateTime.Day.ToString());
			objWriter.WriteAttributeString("DisplayMonth", position.Month.ToString());
			objWriter.WriteAttributeString("DisplayPreviousMonthLastDay", dateTime2.Day.ToString());
			DateTime todayDate = TodayDate;
			if (position.Year == todayDate.Year && position.Month == todayDate.Month)
			{
				objWriter.WriteAttributeString("TodayDay", todayDate.Day.ToString());
			}
			objWriter.WriteAttributeString("DisplayYear", Application.CurrentUICulture.Calendar.GetYear(position).ToString());
			objWriter.WriteAttributeString("DisplayFirstWeekDay", DayToNumber(FirstDayOfWeek).ToString());
			if (CalanderViewType != CalanderViewTypes.Day)
			{
				objWriter.WriteAttributeString("CVT", ((int)CalanderViewType).ToString());
			}
			CultureInfo cultureInfo = CultureInfo.InvariantCulture;
			if (Context != null && Context.CurrentUICulture != null)
			{
				cultureInfo = Context.CurrentUICulture;
			}
			objWriter.WriteAttributeString("DYM", position.ToString(cultureInfo.DateTimeFormat.YearMonthPattern, cultureInfo));
			objWriter.WriteAttributeString("DT", Value.Ticks.ToString());
		}

		private int GetDisplayStartIndex()
		{
			DateTime dateTime = new DateTime(Position.Year, Position.Month, 1, 0, 0, 0);
			int num = DayToNumber(FirstDayOfWeek);
			int num2 = DayToNumber(dateTime.DayOfWeek);
			int num3 = 0;
			if (num <= num2)
			{
				return num2 - num + 1;
			}
			return 7 - (num - num2) + 1;
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderBoldedDatesAttribute(objWriter, blnForceRender: false);
			RenderSelectionAttributes(objWriter);
			RenderMinMaxDateAttributes(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the min max date attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderMinMaxDateAttributes(IAttributeWriter objWriter, bool blnForceRender)
		{
			DateTime minDate = MinDate;
			if (minDate != CalendarUtils.MinDateTime || blnForceRender)
			{
				objWriter.WriteAttributeString("NDD", minDate.Day.ToString());
				objWriter.WriteAttributeString("NDM", minDate.Month.ToString());
				objWriter.WriteAttributeString("NDY", Application.CurrentUICulture.Calendar.GetYear(minDate).ToString());
			}
			DateTime maxDate = MaxDate;
			if (maxDate != CalendarUtils.MaxDateTime || blnForceRender)
			{
				objWriter.WriteAttributeString("XDD", maxDate.Day.ToString());
				objWriter.WriteAttributeString("XDM", maxDate.Month.ToString());
				objWriter.WriteAttributeString("XDY", Application.CurrentUICulture.Calendar.GetYear(maxDate).ToString());
			}
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
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderBoldedDatesAttribute(objWriter, blnForceRender: true);
				RenderSelectionAttributes(objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderMinMaxDateAttributes(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the selection attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderSelectionAttributes(IAttributeWriter objWriter)
		{
			DateTime selectionStart = SelectionStart;
			DateTime selectionEnd = SelectionEnd;
			objWriter.WriteAttributeString("SSD", selectionStart.Day.ToString());
			objWriter.WriteAttributeString("SSM", selectionStart.Month.ToString());
			objWriter.WriteAttributeString("SSY", Application.CurrentUICulture.Calendar.GetYear(selectionStart).ToString());
			objWriter.WriteAttributeString("ESD", selectionEnd.Day.ToString());
			objWriter.WriteAttributeString("ESM", selectionEnd.Month.ToString());
			objWriter.WriteAttributeString("ESY", Application.CurrentUICulture.Calendar.GetYear(selectionEnd).ToString());
		}

		/// 
		/// Renders the bolded dates attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderBoldedDatesAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			string boldedDatesIndexes = GetBoldedDatesIndexes();
			if (!string.IsNullOrEmpty(boldedDatesIndexes) || blnForceRender)
			{
				objWriter.WriteAttributeString("BD", boldedDatesIndexes);
			}
		}

		/// 
		/// Gets the bolded dates indexes.
		/// </summary>
		/// </returns>
		private string GetBoldedDatesIndexes()
		{
			List<object> list = new List<object><object>();
			DateTime position = Position;
			int num = DateTime.DaysInMonth(position.Year, position.Month);
			int displayStartIndex = GetDisplayStartIndex();
			int num2 = displayStartIndex + num - 1;
			int num3 = 7 - num2 % 7;
			num3 %= 7;
			DateTime dateTime = new DateTime(position.Year, position.Month, 1).AddDays(-displayStartIndex);
			DateTime dateTime2 = new DateTime(position.Year, position.Month, num).AddDays(num3);
			DateTime minDate = MinDate;
			if (minDate > dateTime)
			{
				dateTime = minDate;
			}
			DateTime maxDate = MaxDate;
			if (maxDate < dateTime2)
			{
				dateTime2 = maxDate;
			}
			DateTime[] allBoldedDisplayedDates = GetAllBoldedDisplayedDates(position, dateTime, dateTime2);
			foreach (DateTime dateTime3 in allBoldedDisplayedDates)
			{
				int num4 = (dateTime3 - new DateTime(position.Year, position.Month, 1)).Days + 1;
				if (!list.Contains(num4.ToString()))
				{
					list.Add(num4.ToString());
				}
			}
			return string.Join(",", list.ToArray());
		}

		/// 
		/// Gets all bolded displayed dates.
		/// </summary>
		/// <param name="objCurrentPosition">The object current position.</param>
		/// <param name="objBoldedMinDate">The object bolded minimum date.</param>
		/// <param name="objBoldedMaxDate">The object bolded maximum date.</param>
		/// </returns>
		private DateTime[] GetAllBoldedDisplayedDates(DateTime objCurrentPosition, DateTime objBoldedMinDate, DateTime objBoldedMaxDate)
		{
			List<object> list = new List<object><object>();
			DateTime[] boldedDates = BoldedDates;
			DateTime[] monthlyBoldedDates = MonthlyBoldedDates;
			DateTime[] annuallyBoldedDates = AnnuallyBoldedDates;
			DateTime[] array = boldedDates;
			foreach (DateTime dateTime in array)
			{
				if (dateTime > objBoldedMinDate && dateTime <= objBoldedMaxDate)
				{
					list.Add(dateTime);
				}
			}
			DateTime[] array2 = monthlyBoldedDates;
			for (int j = 0; j < array2.Length; j++)
			{
				DateTime dateTime2 = array2[j];
				DateTime dateTime3 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime2.Day).AddMonths(-1);
				DateTime dateTime4 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime2.Day).AddMonths(1);
				DateTime dateTime5 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime2.Day);
				if (dateTime3 > objBoldedMinDate && dateTime3 <= objBoldedMaxDate)
				{
					list.Add(dateTime3);
				}
				if (dateTime4 > objBoldedMinDate && dateTime4 <= objBoldedMaxDate)
				{
					list.Add(dateTime4);
				}
				if (dateTime5 > objBoldedMinDate && dateTime5 <= objBoldedMaxDate)
				{
					list.Add(dateTime5);
				}
			}
			DateTime[] array3 = annuallyBoldedDates;
			for (int k = 0; k < array3.Length; k++)
			{
				DateTime dateTime6 = array3[k];
				DateTime dateTime7 = new DateTime(objCurrentPosition.Year, dateTime6.Month, dateTime6.Day);
				if (dateTime7 > objBoldedMinDate && dateTime7 <= objBoldedMaxDate)
				{
					list.Add(dateTime7);
				}
			}
			return list.ToArray();
		}

		/// 
		/// Convers a day to number in week.
		/// </summary>
		/// <param name="enmDay">Enm day.</param>
		/// </returns>
		private int DayToNumber(DayOfWeek enmDay)
		{
			return enmDay switch
			{
				DayOfWeek.Sunday => 1, 
				DayOfWeek.Monday => 2, 
				DayOfWeek.Tuesday => 3, 
				DayOfWeek.Wednesday => 4, 
				DayOfWeek.Thursday => 5, 
				DayOfWeek.Friday => 6, 
				DayOfWeek.Saturday => 7, 
				_ => 1, 
			};
		}

		/// Raises the <see cref="E:System.Windows.Forms.DateTimePicker.ValueChanged"></see> event.</summary>
		/// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnValueChanged(EventArgs objEventArgs)
		{
			ValueChangedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Convers a day to number in week.
		/// </summary>
		/// <param name="enmDay">Enm day.</param>
		/// </returns>
		private int DayToNumber(Day enmDay)
		{
			return enmDay switch
			{
				Day.Sunday => 1, 
				Day.Monday => 2, 
				Day.Tuesday => 3, 
				Day.Wednesday => 4, 
				Day.Thursday => 5, 
				Day.Friday => 6, 
				Day.Saturday => 7, 
				_ => 1, 
			};
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			DateTime position = Position;
			switch (objEvent.Type)
			{
			case "Next":
				Navigate(position, 1);
				break;
			case "Previous":
				Navigate(position, -1);
				break;
			case "NavigateYear":
				Position = position.AddYears(int.Parse(objEvent["Year"]) - position.Year);
				Update();
				break;
			case "NavigateMonth":
				Position = position.AddMonths(int.Parse(objEvent["Month"]) - position.Month);
				Update();
				break;
			case "ValueChange":
			{
				int intDay = position.Day;
				int intMonth = position.Month;
				int intYear = position.Year;
				bool blnCloseCalendarForm = false;
				switch (CalanderViewType)
				{
				case CalanderViewTypes.Day:
					intDay = int.Parse(objEvent["Value"]);
					blnCloseCalendarForm = true;
					break;
				case CalanderViewTypes.Month:
					intMonth = int.Parse(objEvent["Value"]);
					CalanderViewType = CalanderViewTypes.Day;
					break;
				case CalanderViewTypes.Year:
					intYear = int.Parse(objEvent["Value"]);
					CalanderViewType = CalanderViewTypes.Month;
					break;
				case CalanderViewTypes.YearRange:
				{
					int num = int.Parse(objEvent["Value"]);
					intYear = num + Position.Year % 10;
					CalanderViewType = CalanderViewTypes.Year;
					break;
				}
				}
				UpdateSelectionRange(intYear, intMonth, intDay, blnCloseCalendarForm, objEvent.ShiftKey);
				break;
			}
			case "SwitchView":
				switch (CalanderViewType)
				{
				case CalanderViewTypes.Day:
					CalanderViewType = CalanderViewTypes.Month;
					break;
				case CalanderViewTypes.Month:
					CalanderViewType = CalanderViewTypes.Year;
					break;
				case CalanderViewTypes.Year:
					CalanderViewType = CalanderViewTypes.YearRange;
					break;
				}
				break;
			}
		}

		/// 
		/// Updates the selection range.
		/// </summary>
		/// <param name="intYear">The int year.</param>
		/// <param name="intMonth">The int month.</param>
		/// <param name="intDay">The int day.</param>
		/// <param name="blnCloseCalendarForm">if set to true</c> [BLN close calendar form].</param>
		/// <param name="blnRangeSelected">if set to true</c> [BLN range selected].</param>
		private void UpdateSelectionRange(int intYear, int intMonth, int intDay, bool blnCloseCalendarForm, bool blnRangeSelected)
		{
			DateTimePicker dateTimePickerInternal = DateTimePickerInternal;
			DateTimePickerPopup calendarForm = CalendarForm;
			int num = DateTime.DaysInMonth(intYear, intMonth);
			int num2 = 0;
			if (intDay <= 0)
			{
				num2 = intDay - 1;
				intDay = 1;
			}
			if (num < intDay)
			{
				num2 = intDay - num;
				intDay = num;
			}
			DateTime dateTime = Application.CurrentUICulture.Calendar.ToDateTime(intYear, intMonth, intDay, 0, 0, 0, 0).AddDays(num2);
			DateTime dateTime2 = (ValueInternal = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day));
			if (blnRangeSelected)
			{
				int num3 = MaxSelectionCount - 1;
				DateTime dateTime4 = ((menmSelectionDirection != CalendarUtils.SelectDirection.RightToLeft) ? SelectionStart : SelectionEnd);
				menmSelectionDirection = ((!(dateTime4 < dateTime2)) ? CalendarUtils.SelectDirection.RightToLeft : CalendarUtils.SelectDirection.LeftToRight);
				long num4 = Math.Abs((dateTime4 - dateTime2).Days);
				if (num4 > num3)
				{
					dateTime2 = dateTime4.AddDays(num3 * ((menmSelectionDirection == CalendarUtils.SelectDirection.LeftToRight) ? 1 : (-1)));
				}
				SetRange(new DateTime(Math.Min(dateTime2.Ticks, dateTime4.Ticks)), new DateTime(Math.Max(dateTime2.Ticks, dateTime4.Ticks)));
			}
			else
			{
				SetRange(dateTime2, dateTime2);
				menmSelectionDirection = CalendarUtils.SelectDirection.None;
			}
			if (dateTimePickerInternal != null)
			{
				dateTimePickerInternal.Checked = true;
			}
			calendarForm?.OnMonthCalanderValueChanged(blnCloseCalendarForm);
		}

		/// 
		/// Navigates the specified position.
		/// </summary>
		/// <param name="objPosition">The date position.</param>
		/// <param name="intDirection">The navigation direction.</param>
		private void Navigate(DateTime objPosition, int intDirection)
		{
			switch (CalanderViewType)
			{
			case CalanderViewTypes.Day:
				if ((DateTime.MaxValue - objPosition).Days >= 31)
				{
					objPosition = objPosition.AddMonths(intDirection);
					if (objPosition.Day > 1)
					{
						objPosition = objPosition.AddDays(1 - objPosition.Day);
					}
				}
				break;
			case CalanderViewTypes.Month:
				objPosition = objPosition.AddYears(intDirection);
				break;
			case CalanderViewTypes.Year:
				objPosition = objPosition.AddYears(10 * intDirection);
				break;
			case CalanderViewTypes.YearRange:
				objPosition = objPosition.AddYears(100 * intDirection);
				break;
			}
			Position = objPosition;
			UpdateSelectionRange(objPosition.Year, objPosition.Month, objPosition.Day, blnCloseCalendarForm: false, blnRangeSelected: false);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (DateChangedHandler != null)
			{
				criticalEventsData.Set("VC");
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
			return criticalClientEventsData;
		}

		/// 
		/// Resets the max date.
		/// </summary>
		private void ResetMaxDate()
		{
			MaxDate = CalendarUtils.MaxDateTime;
		}

		/// 
		/// Determines whether to serialize MaxDate property.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMaxDate()
		{
			return MaxDate != CalendarUtils.MaxDateTime;
		}

		/// 
		/// Resets the min date.
		/// </summary>
		private void ResetMinDate()
		{
			MinDate = CalendarUtils.MinDateTime;
		}

		/// 
		/// Determines whether to serialize MinDate property.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMinDate()
		{
			return MinDate != CalendarUtils.MinDateTime;
		}

		/// 
		/// Determines whether to serialize SelectionEnd property.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeSelectionEnd()
		{
			return SelectionEnd != DateTime.Now.Date;
		}

		/// 
		/// Determines whether to serialize SelectionStart property.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeSelectionStart()
		{
			return SelectionStart != DateTime.Now.Date;
		}

		/// 
		/// Resets the selection range.
		/// </summary>
		private void ResetSelectionRange()
		{
			SetSelectionRange(DateTime.Now.Date, DateTime.Now.Date);
		}

		/// 
		/// Determines whether to serialize SelectionRange property.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeSelectionRange()
		{
			return SelectionRange.Start != DateTime.Now.Date && SelectionRange.End != DateTime.Now.Date;
		}

		/// 
		/// Resets the value.
		/// </summary>
		private void ResetValue()
		{
			Value = DateTime.Now.Date;
		}

		/// 
		/// Sets the range.
		/// </summary>
		/// <param name="objMinDate">The min date.</param>
		/// <param name="objMaxDate">The max date.</param>
		private void SetMinMaxRange(DateTime objMinDate, DateTime objMaxDate)
		{
			if (SelectionStart < objMinDate)
			{
				SelectionStart = objMinDate;
			}
			if (SelectionStart > objMaxDate)
			{
				SelectionStart = objMaxDate;
			}
			if (SelectionEnd < objMinDate)
			{
				SelectionEnd = objMinDate;
			}
			if (SelectionEnd > objMaxDate)
			{
				SelectionEnd = objMaxDate;
			}
			SetRange(SelectionStart, SelectionEnd);
		}

		/// 
		/// Sets the selection range.
		/// </summary>
		/// <param name="objLowerDate">The lower date.</param>
		/// <param name="objUpperDate">The upper date.</param>
		private void SetRange(DateTime objLowerDate, DateTime objUpperDate)
		{
			bool flag = false;
			if (SelectionStart != objLowerDate || SelectionEnd != objUpperDate)
			{
				flag = true;
				SelectionStartInternal = objLowerDate;
				SelectionEndInternal = objUpperDate;
			}
			if (flag)
			{
				Position = objLowerDate;
				OnValueChanged(new EventArgs());
				OnDateChanged(EventArgs.Empty);
				Update();
			}
		}

		/// 
		/// Raises the <see cref="E:DateChanged" /> event.
		/// </summary>
		/// <param name="objEvents">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnDateChanged(EventArgs objEvents)
		{
			if (DateChangedHandler != null)
			{
				DateChangedHandler(this, objEvents);
			}
		}

		/// 
		/// Sets the selection range.
		/// </summary>
		/// <param name="objMinDate">The min date.</param>
		/// <param name="objMaxDate">The max date.</param>
		public void SetSelectionRange(DateTime objMinDate, DateTime objMaxDate)
		{
			if (objMinDate.Ticks < MinDate.Ticks)
			{
				throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidLowBoundArgumentEx", "SelectionStart", FormatDate(objMinDate), "MinDate"));
			}
			if (objMinDate.Ticks > MaxDate.Ticks)
			{
				throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidHighBoundArgumentEx", "SelectionEnd", FormatDate(objMinDate), "MaxDate"));
			}
			if (objMaxDate.Ticks < MinDate.Ticks)
			{
				throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidLowBoundArgumentEx", "SelectionStart", FormatDate(objMaxDate), "MinDate"));
			}
			if (objMaxDate.Ticks > MaxDate.Ticks)
			{
				throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidHighBoundArgumentEx", "SelectionEnd", FormatDate(objMaxDate), "MaxDate"));
			}
			if (objMinDate > objMaxDate)
			{
				objMaxDate = objMinDate;
			}
			if ((objMaxDate - objMinDate).Days >= MaxSelectionCount)
			{
				if (objMinDate.Ticks == SelectionStart.Ticks)
				{
					objMinDate = objMaxDate.AddDays(1 - MaxSelectionCount);
				}
				else
				{
					objMaxDate = objMinDate.AddDays(MaxSelectionCount - 1);
				}
			}
			SetRange(objMinDate, objMaxDate);
		}

		/// 
		/// Adds a day that is displayed in bold on an annual basis in the month calendar.
		/// </summary>
		/// <param name="objDate">The date to be displayed in bold.</param>
		public void AddAnnuallyBoldedDate(DateTime objDate)
		{
			List<object> list = new List<object><object>();
			list.AddRange(AnnuallyBoldedDates);
			list.Add(objDate);
			AnnuallyBoldedDates = list.ToArray();
		}

		/// 
		/// Adds a day to be displayed in bold in the month calendar.
		/// </summary>
		/// <param name="objDate">The date to be displayed in bold.</param>
		public void AddBoldedDate(DateTime objDate)
		{
			List<object> list = new List<object><object>();
			list.AddRange(BoldedDates);
			list.Add(objDate);
			BoldedDates = list.ToArray();
		}

		/// 
		/// Adds a day that is displayed in bold on a monthly basis in the month calendar.
		/// </summary>
		/// <param name="objDate">The date to be displayed in bold.</param>
		public void AddMonthlyBoldedDate(DateTime objDate)
		{
			List<object> list = new List<object><object>();
			list.AddRange(MonthlyBoldedDates);
			list.Add(objDate);
			MonthlyBoldedDates = list.ToArray();
		}

		/// 
		/// Shoulds the serialize annually bolded dates.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeAnnuallyBoldedDates()
		{
			return AnnuallyBoldedDates.Length != 0;
		}

		/// 
		/// Shoulds the serialize bolded dates.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBoldedDates()
		{
			return BoldedDates.Length != 0;
		}

		/// 
		/// Shoulds the serialize monthly bolded dates.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeMonthlyBoldedDates()
		{
			return MonthlyBoldedDates.Length != 0;
		}

		/// 
		/// Formats the date.
		/// </summary>
		/// <param name="objDateTime">The obj date time.</param>
		/// </returns>
		private static string FormatDate(DateTime objDateTime)
		{
			return objDateTime.ToString("d", Application.CurrentUICulture);
		}

		static MonthCalendar()
		{
			DateChanged = SerializableEvent.Register("DateChanged", typeof(EventHandler), typeof(MonthCalendar));
			ValueChanged = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(MonthCalendar));
		}
	}
}
