#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region MonthCalendar Class

    /// <summary>
    /// A calendar control.
    /// </summary>
    [System.ComponentModel.DefaultEvent("DateChanged")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(MonthCalendar), "MonthCalendar_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(MonthCalendar), "MonthCalendar.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.MonthCalendar)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.MonthCalendarSkin))]
    public class MonthCalendar : Control
    {
        #region SerializableProperty

        /// <summary>
        /// Provides a property reference to FirstDayOfWeek property.
        /// </summary>
        private static SerializableProperty FirstDayOfWeekProperty = SerializableProperty.Register("FirstDayOfWeek", typeof(Day), typeof(MonthCalendar), new SerializablePropertyMetadata(Day.Default));



        /// <summary>
        /// Provides a property reference to Form property.
        /// </summary>
        private static SerializableProperty FormProperty = SerializableProperty.Register("Form", typeof(DateTimePickerPopup), typeof(MonthCalendar));



        /// <summary>
        /// Provides a property reference to DateTimePicker property.
        /// </summary>
        private static SerializableProperty DateTimePickerProperty = SerializableProperty.Register("DateTimePicker", typeof(DateTimePicker), typeof(MonthCalendar));



        /// <summary>
        /// Provides a property reference to Position property.
        /// </summary>
        private static SerializableProperty PositionProperty = SerializableProperty.Register("Position", typeof(DateTime), typeof(MonthCalendar));



        /// <summary>
        /// Provides a property reference to Value property.
        /// </summary>
        private static SerializableProperty ValueProperty = SerializableProperty.Register("Value", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to BoldedDates property.
        /// </summary>
        private static SerializableProperty BoldedDatesProperty = SerializableProperty.Register("BoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to AnnuallyBoldedDates property.
        /// </summary>
        private static SerializableProperty AnnuallyBoldedDatesProperty = SerializableProperty.Register("AnnuallyBoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to MonthlyBoldedDates property.
        /// </summary>
        private static SerializableProperty MonthlyBoldedDatesProperty = SerializableProperty.Register("MonthlyBoldedDates", typeof(DateTime[]), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to CalanderViewType property.
        /// </summary>
        private static SerializableProperty CalanderViewTypeProperty = SerializableProperty.Register("CalanderViewType", typeof(CalanderViewTypes), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to TodayDate property.
        /// </summary>
        private static SerializableProperty TodayDateProperty = SerializableProperty.Register("TodayDate", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to SelectionStart property.
        /// </summary>
        private static SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to SelectionEnd property.
        /// </summary>
        private static SerializableProperty SelectionEndProperty = SerializableProperty.Register("SelectionEnd", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to MaxDate property.
        /// </summary>
        private static SerializableProperty MaxDateProperty = SerializableProperty.Register("MaxDate", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to MinDate property.
        /// </summary>
        private static SerializableProperty MinDateProperty = SerializableProperty.Register("MinDate", typeof(DateTime), typeof(MonthCalendar));

        /// <summary>
        /// Provides a property reference to MaxSelectionCount property.
        /// </summary>
        private static SerializableProperty MaxSelectionCountProperty = SerializableProperty.Register("MaxSelectionCount", typeof(int), typeof(MonthCalendar));

        private static SerializableProperty TodatDateProperty = SerializableProperty.Register("TodatDate", typeof(DateTime[]), typeof(MonthCalendar));

        private static SerializableProperty TodayDateSetProperty = SerializableProperty.Register("TodayDateSet", typeof(bool), typeof(MonthCalendar));

        #endregion

        #region Class Members

        private CalendarUtils.SelectDirection menmSelectionDirection = CalendarUtils.SelectDirection.None;

        /// <summary>
        /// Gets or sets the bolded dates.
        /// </summary>
        /// <value>The bolded dates.</value>
        public DateTime[] BoldedDates
        {
            get
            {
                return this.GetValue<DateTime[]>(MonthCalendar.BoldedDatesProperty, new DateTime[] { });
            }
            set
            {
                if (value != this.BoldedDates)
                {
                    if (value == null || value.Length == 0)
                    {
                        this.RemoveValue<DateTime[]>(MonthCalendar.BoldedDatesProperty);
                    }
                    else
                    {
                        this.SetValue<DateTime[]>(MonthCalendar.BoldedDatesProperty, value);
                    }

                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }


        /// <summary>
        /// Gets or sets the annually bolded dates.
        /// </summary>
        /// <value>The annually bolded dates.</value>
        public DateTime[] AnnuallyBoldedDates
        {
            get
            {
                return this.GetValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty, new DateTime[] { });
            }
            set
            {
                if (value != this.AnnuallyBoldedDates)
                {
                    if (value == null || value.Length == 0)
                    {
                        this.RemoveValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty);
                    }
                    else
                    {
                        this.SetValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty, value);
                    }

                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }



        /// <summary>
        /// Gets or sets the monthly bolded dates property.
        /// </summary>
        /// <value>The monthly bolded dates property.</value>
        public DateTime[] MonthlyBoldedDates
        {
            get
            {
                return this.GetValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty, new DateTime[] { });
            }
            set
            {
                if (value != this.MonthlyBoldedDates)
                {
                    if (value == null || value.Length == 0)
                    {
                        this.RemoveValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty);
                    }
                    else
                    {
                        this.SetValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty, value);
                    }

                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// The calendar date time value
        /// </summary>
        private DateTime ValueInternal
        {
            get
            {
                return this.GetValue<DateTime>(MonthCalendar.ValueProperty, DateTime.Now);
            }
            set
            {
                // Checking whether the value has changed
                if (this.Value != value)
                {
                    // If value is not default (DateTime.Now), set it in Serializable Property
                    if (value != DateTime.Now)
                    {
                        this.SetValue<DateTime>(MonthCalendar.ValueProperty, value);
                    }
                    //If value is Default (DateTime.Now), remove it from Serializable Property
                    else
                    {
                        this.RemoveValue<DateTime>(MonthCalendar.ValueProperty);
                    }
                }
            }
        }

        /// <summary>
        /// The calendar date time displayed position
        /// </summary>
        private DateTime Position
        {
            get
            {
                return this.GetValue<DateTime>(MonthCalendar.PositionProperty, DateTime.Now);
            }
            set
            {
                // Checking whether the value has changed
                if (value != this.Position)
                {
                    // If value is not default (DateTime.Now), set it in Serializable Property
                    if (value != DateTime.Now)
                    {
                        this.SetValue<DateTime>(MonthCalendar.PositionProperty, value);
                    }
                    //If value is Default (DateTime.Now), remove it from Serializable Property
                    else
                    {
                        this.RemoveValue<DateTime>(MonthCalendar.PositionProperty);
                    }
                }
            }
        }

        private DateTimePicker DateTimePickerInternal
        {
            get
            {
                return this.GetValue<DateTimePicker>(MonthCalendar.DateTimePickerProperty);
            }
            set
            {
                // Checking whether the value has changed
                if (this.DateTimePickerInternal != value)
                {
                    // Setting value
                    this.SetValue<DateTimePicker>(MonthCalendar.DateTimePickerProperty, value);
                }
            }
        }

        /// <summary>
        /// The calendar owner form
        /// </summary>
        private DateTimePickerPopup CalendarForm
        {
            get
            {
                return this.GetValue<DateTimePickerPopup>(MonthCalendar.FormProperty);
            }
            set
            {
                // Checking whether the value has changed from default
                if (this.CalendarForm != value)
                {
                    // Setting value
                    this.SetValue<DateTimePickerPopup>(MonthCalendar.FormProperty, value);
                }
            }
        }

        /// <summary>
        /// Occurs when the date is changed
        /// </summary>
        public event EventHandler DateChanged
        {
            add
            {
                this.AddCriticalHandler(MonthCalendar.DateChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(MonthCalendar.DateChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DateChanged event.
        /// </summary>
        private EventHandler DateChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(MonthCalendar.DateChangedEvent);
            }
        }

        /// <summary>
        /// The DateChanged event registration.
        /// </summary>
        private static readonly SerializableEvent DateChangedEvent = SerializableEvent.Register("DateChanged", typeof(EventHandler), typeof(MonthCalendar));



        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property changes.
        /// </summary>
        [SRDescription("valueChangedEventDescr"), SRCategory("CatAction")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.AddHandler(MonthCalendar.ValueChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(MonthCalendar.ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client date changed].
        /// </summary>
        [SRDescription("dateChangedEventDescr"), Category("Client")]
        public event ClientEventHandler ClientDateChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ValueChanged event.
        /// </summary>
        private EventHandler ValueChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(MonthCalendar.ValueChangedEvent);
            }
        }

        /// <summary>
        /// The ValueChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(MonthCalendar));

        /// <summary>
        /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImage"></see> property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler BackgroundImageChanged
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

        /// <summary>
        /// Occurs when the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImageLayout"></see> property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler BackgroundImageLayoutChanged
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

        /// <summary>
        /// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler Click
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

        /// <summary>
        /// Occurs when the user double-clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler DoubleClick
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

        /// <summary>
        /// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control with the mouse.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event MouseEventHandler MouseClick
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

        /// <summary>
        /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Padding"></see> property changes.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler PaddingChanged
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

        /// <summary>
        /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Text"></see> property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler TextChanged
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

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Creates a new <see cref="MonthCalendar"/> instance.
        /// </summary>
        public MonthCalendar()
        {
            Size = new System.Drawing.Size(179, 155);

            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.StandardClick, false);

            // Initializing main variables
            InitializeComponent();
        }



        /// <summary>
        /// Creates a new <see cref="MonthCalendar"/> instance.
        /// </summary>
        internal MonthCalendar(DateTimePicker objDateTimePicker, DateTimePickerPopup objCalendarForm)
        {
            Size = new System.Drawing.Size(179, 155);

            // Set owner references
            DateTimePickerInternal = objDateTimePicker;
            CalendarForm = objCalendarForm;

            // Set current startup position and value
            if (objDateTimePicker != null)
            {
                this.Position = ValueInternal = objDateTimePicker.Value;
            }

            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.StandardClick, false);

            // Initializing main variables
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            ValueInternal = Position = DateTime.Now;
        }

        #endregion C'Tor/D'Tor

        #region Render

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            int intYear = 0;
            DateTime objLast = new DateTime(Position.Year, Position.Month, 1, 0, 0, 0);

            //only in the last month of the last available year
            //Otherwise objLast.AddMonths(1) line raises an error trying to reach year 10000
            if (DateTime.MaxValue.Year == objLast.Year && DateTime.MaxValue.Month == objLast.Month)
            {
                objLast = new DateTime(9999, 12, 31, 0, 0, 0);
            }
            else
            {
                objLast = objLast.AddMonths(1);
                objLast = objLast.AddDays(-1);
            }

            int intDisplayStart = GetDisplayStartIndex();

            // add attributes to control element
            DateTime objPosition = this.Position;

            DateTime objPreviousMonthLastDay = objPosition.AddDays(-objPosition.Day);
            
            objWriter.WriteAttributeString("DisplayStart", intDisplayStart.ToString());
            objWriter.WriteAttributeString("DisplayDays", objLast.Day.ToString());
            objWriter.WriteAttributeString("DisplayMonth", objPosition.Month.ToString());
            objWriter.WriteAttributeString("DisplayPreviousMonthLastDay", objPreviousMonthLastDay.Day.ToString());

            DateTime objToday = this.TodayDate;

			// We show today only if we're in the correct month/year
            if (objPosition.Year == objToday.Year && objPosition.Month == objToday.Month)
            {
                objWriter.WriteAttributeString("TodayDay", objToday.Day.ToString());
            }

            //In case the CurrentUICulture is not a regular one(like thai)
            //and we should display years according to the Buddhist Era instead of the Georgian
            intYear = Application.CurrentUICulture.Calendar.GetYear(objPosition);

            objWriter.WriteAttributeString("DisplayYear", intYear.ToString());
            objWriter.WriteAttributeString("DisplayFirstWeekDay", DayToNumber(this.FirstDayOfWeek).ToString());

            //If the calander view type is not day
            if (this.CalanderViewType != CalanderViewTypes.Day)
            {
                //Render the view type to the client
                objWriter.WriteAttributeString(WGAttributes.CalanderViewType, ((int)this.CalanderViewType).ToString());
            }

            CultureInfo objCultureInfo = CultureInfo.InvariantCulture;

            // Check if context's culture is not null.
            if (this.Context != null && this.Context.CurrentUICulture != null)
            {
                // get current culture
                objCultureInfo = this.Context.CurrentUICulture;
            }

            // render Display YearMonth
            objWriter.WriteAttributeString(WGAttributes.DisplayYearMonth, objPosition.ToString(objCultureInfo.DateTimeFormat.YearMonthPattern, objCultureInfo));

            //Send for the silverlight client
            objWriter.WriteAttributeString(WGAttributes.DateTime, this.Value.Ticks.ToString());
        }

        private int GetDisplayStartIndex()
        {
            // Get weeks start and month week start
            DateTime objFirst = new DateTime(Position.Year, Position.Month, 1, 0, 0, 0);
            int intDislpayFirstDayOfWeek = DayToNumber(this.FirstDayOfWeek);
            int intFirstDayOfWeek = DayToNumber(objFirst.DayOfWeek);
            int intDisplayStart = 0;

            // Calculate display start
            if (intDislpayFirstDayOfWeek <= intFirstDayOfWeek)
            {
                intDisplayStart = (intFirstDayOfWeek - intDislpayFirstDayOfWeek) + 1;
            }
            else
            {
                intDisplayStart = 7 - (intDislpayFirstDayOfWeek - intFirstDayOfWeek) + 1;
            }
            return intDisplayStart;
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render the bolded dates attribute.
            RenderBoldedDatesAttribute(objWriter, false);

            // Render the selection attributes.
            RenderSelectionAttributes(objWriter);

            // Renders the min max date attributes.
            RenderMinMaxDateAttributes(objWriter, false);
        }

        /// <summary>
        /// Renders the min max date attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderMinMaxDateAttributes(IAttributeWriter objWriter, bool blnForceRender)
        {
            int intYear;
            DateTime objMinDate = this.MinDate;
            if (objMinDate != CalendarUtils.MinDateTime || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.MinimumDateDay, objMinDate.Day.ToString());
                objWriter.WriteAttributeString(WGAttributes.MinimumDateMonth, objMinDate.Month.ToString());

                //In case the CurrentUICulture is not a regular one(like thai)
                //and we should display years according to the Buddhist Era instead of the Georgian
                intYear = Application.CurrentUICulture.Calendar.GetYear(objMinDate);

                objWriter.WriteAttributeString(WGAttributes.MinimumDateYear, intYear.ToString());
            }

            DateTime objMaxDate = this.MaxDate;
            if (objMaxDate != CalendarUtils.MaxDateTime || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.MaximumDateDay, objMaxDate.Day.ToString());
                objWriter.WriteAttributeString(WGAttributes.MaximumDateMonth, objMaxDate.Month.ToString());

                //In case the CurrentUICulture is not a regular one(like thai)
                //and we should display years according to the Buddhist Era instead of the Georgian
                intYear = Application.CurrentUICulture.Calendar.GetYear(objMaxDate);

                objWriter.WriteAttributeString(WGAttributes.MaximumDateYear, intYear.ToString());
            }
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

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Render the bolded dates attribute.
                RenderBoldedDatesAttribute(objWriter, true);

                // Render the selection attributes.
                RenderSelectionAttributes(objWriter);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderMinMaxDateAttributes(objWriter, true);
            }
        }

        /// <summary>
        /// Renders the selection attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderSelectionAttributes(IAttributeWriter objWriter)
        {
            DateTime objStartSelectionDate = this.SelectionStart;
            DateTime objEndSelectionDate = this.SelectionEnd;

            // Render start selection attributes.
            objWriter.WriteAttributeString(WGAttributes.SelectionStartDay, objStartSelectionDate.Day.ToString());
            objWriter.WriteAttributeString(WGAttributes.SelectionStartMonth, objStartSelectionDate.Month.ToString());

            //In case the CurrentUICulture is not a regular one(like thai)
            //and we should display years according to the Buddhist Era instead of the Georgian
            int intYear = Application.CurrentUICulture.Calendar.GetYear(objStartSelectionDate);
            objWriter.WriteAttributeString(WGAttributes.SelectionStartYear, intYear.ToString());

            // Render end selection attributes.
            objWriter.WriteAttributeString(WGAttributes.SelectionEndDay, objEndSelectionDate.Day.ToString());
            objWriter.WriteAttributeString(WGAttributes.SelectionEndMonth, objEndSelectionDate.Month.ToString());

            //In case the CurrentUICulture is not a regular one(like thai)
            //and we should display years according to the Buddhist Era instead of the Georgian
            intYear = Application.CurrentUICulture.Calendar.GetYear(objEndSelectionDate);
            objWriter.WriteAttributeString(WGAttributes.SelectionEndYear, intYear.ToString());
        }

        /// <summary>
        /// Renders the bolded dates attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderBoldedDatesAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Get bolded dates
            string strBoldedDates = GetBoldedDatesIndexes();

            if (!string.IsNullOrEmpty(strBoldedDates) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.BoldedDays, strBoldedDates);
            }
        }

        /// <summary>
        /// Gets the bolded dates indexes.
        /// </summary>
        /// <returns></returns>
        private string GetBoldedDatesIndexes()
        {
            List<string> objDays = new List<string>();
            DateTime objPosition = this.Position;

            int intDaysInMonth = DateTime.DaysInMonth(objPosition.Year, objPosition.Month);
            int intLastMonthNumberOfDatesInDisplay = GetDisplayStartIndex();
            int intCurrentMonthLastIndex = (intLastMonthNumberOfDatesInDisplay + intDaysInMonth - 1);
            int intNextMonthNumberOfDatesInDisplay = 7 - (intCurrentMonthLastIndex % 7);
            intNextMonthNumberOfDatesInDisplay = intNextMonthNumberOfDatesInDisplay % 7;/* Optimization for not rendering the next month's dates if there's no next month displayed i.e. intNextMonthNumberOfDatesInDisplay == 7 */

            DateTime objBoldedMinDate = new DateTime(objPosition.Year, objPosition.Month,1).AddDays(-intLastMonthNumberOfDatesInDisplay);
            DateTime objBoldedMaxDate = new DateTime(objPosition.Year, objPosition.Month, intDaysInMonth).AddDays(intNextMonthNumberOfDatesInDisplay);

            // Max / Min dates are "stronger"
            DateTime minDate = this.MinDate;
            if (minDate > objBoldedMinDate)
            {
                objBoldedMinDate = minDate;
            }

            DateTime maxDate = this.MaxDate;
            if (maxDate < objBoldedMaxDate)
            {
                objBoldedMaxDate = maxDate;
            }

            // Get all relevant dates in range
            DateTime[] objTempArray = GetAllBoldedDisplayedDates(objPosition, objBoldedMinDate, objBoldedMaxDate);

            for (int i = 0; i < objTempArray.Length; i++)
            {
                DateTime objTemp = objTempArray[i];

                // Get the corretc index - If the date is in the previous month then the index will be negative.
                int intDayIndex = (objTemp - new DateTime(objPosition.Year, objPosition.Month, 1)).Days + 1;

                if (!objDays.Contains(intDayIndex.ToString()))
                {
                    objDays.Add(intDayIndex.ToString());
                }
            }

            return string.Join(",", objDays.ToArray());
        }

        /// <summary>
        /// Gets all bolded displayed dates.
        /// </summary>
        /// <param name="objCurrentPosition">The object current position.</param>
        /// <param name="objBoldedMinDate">The object bolded minimum date.</param>
        /// <param name="objBoldedMaxDate">The object bolded maximum date.</param>
        /// <returns></returns>
        private DateTime[] GetAllBoldedDisplayedDates(DateTime objCurrentPosition, DateTime objBoldedMinDate, DateTime objBoldedMaxDate)
        {
            List<DateTime> objDisplayedBoldedDates = new List<DateTime>();
            
            DateTime[] objBoldedDates = this.BoldedDates;
            DateTime[] objBoldedMonthlyDates = this.MonthlyBoldedDates;
            DateTime[] objBoldedAnnualDates = this.AnnuallyBoldedDates;

            foreach (DateTime objDate in objBoldedDates)
            {
                if (objDate > objBoldedMinDate && objDate <= objBoldedMaxDate)
                {
                    objDisplayedBoldedDates.Add(objDate);
                }
            }

            foreach (DateTime objDate in objBoldedMonthlyDates)
            {
                DateTime objNormalizedPreviousDate = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, objDate.Day).AddMonths(-1);
                DateTime objNormalizedNextDate = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, objDate.Day).AddMonths(1);
                DateTime objNormalizedDate = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, objDate.Day);

                if (objNormalizedPreviousDate > objBoldedMinDate && objNormalizedPreviousDate <= objBoldedMaxDate)
                {
                    objDisplayedBoldedDates.Add(objNormalizedPreviousDate);
                }

                if (objNormalizedNextDate > objBoldedMinDate && objNormalizedNextDate <= objBoldedMaxDate)
                {
                    objDisplayedBoldedDates.Add(objNormalizedNextDate);
                }

                if (objNormalizedDate > objBoldedMinDate && objNormalizedDate <= objBoldedMaxDate)
                {
                    objDisplayedBoldedDates.Add(objNormalizedDate);
                }
            }

            foreach (DateTime objDate in objBoldedAnnualDates)
            {
                DateTime objNormalizedDate = new DateTime(objCurrentPosition.Year, objDate.Month, objDate.Day);
                if (objNormalizedDate > objBoldedMinDate && objNormalizedDate <= objBoldedMaxDate)
                {
                    objDisplayedBoldedDates.Add(objNormalizedDate);
                }
            }

            return objDisplayedBoldedDates.ToArray();
        }

        /// <summary>
        /// Convers a day to number in week.
        /// </summary>
        /// <param name="enmDay">Enm day.</param>
        /// <returns></returns>
        private int DayToNumber(DayOfWeek enmDay)
        {
            switch (enmDay)
            {
                case DayOfWeek.Sunday: return 1;
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;
                case DayOfWeek.Saturday: return 7;
                default: return 1;
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.DateTimePicker.ValueChanged"></see> event.</summary>
        /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnValueChanged(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ValueChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Convers a day to number in week.
        /// </summary>
        /// <param name="enmDay">Enm day.</param>
        /// <returns></returns>
        private int DayToNumber(Day enmDay)
        {
            switch (enmDay)
            {
                case Day.Sunday: return 1;
                case Day.Monday: return 2;
                case Day.Tuesday: return 3;
                case Day.Wednesday: return 4;
                case Day.Thursday: return 5;
                case Day.Friday: return 6;
                case Day.Saturday: return 7;
                default: return 1;
            }
        }

        #endregion Render

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            DateTime objPosition = this.Position;

            // Select event type
            switch (objEvent.Type)
            {
                //If the move to next day/month/Year click
                case "Next":
                    Navigate(objPosition, 1);
                    break;

                case "Previous":
                    Navigate(objPosition, -1);
                    break;

                case "NavigateYear":
                    this.Position = objPosition.AddYears(int.Parse(objEvent["Year"]) - objPosition.Year);
                    Update();
                    break;

                case "NavigateMonth":
                    this.Position = objPosition.AddMonths(int.Parse(objEvent["Month"]) - objPosition.Month);
                    Update();
                    break;

                case "ValueChange":
                    //Get the day from the client
                    int intDay = objPosition.Day;

                    //Get the month from the client
                    int intMonth = objPosition.Month;

                    //Get the year from the client
                    int intYear = objPosition.Year;

                    bool blnDateSelected = false;

                    switch (this.CalanderViewType)
                    {
                        case CalanderViewTypes.Day:
                            intDay = int.Parse(objEvent["Value"] as string);
                            blnDateSelected = true;
                            break;
                        case CalanderViewTypes.Month:
                            intMonth = int.Parse(objEvent["Value"] as string);

                            //Change back the view to one level down
                            this.CalanderViewType = CalanderViewTypes.Day;
                            break;
                        case CalanderViewTypes.Year:
                            intYear = int.Parse(objEvent["Value"] as string);

                            //Change back the view to one level down
                            this.CalanderViewType = CalanderViewTypes.Month;
                            break;
                        case CalanderViewTypes.YearRange:
                            int intSelectedRange = int.Parse(objEvent["Value"] as string);
                            intYear = intSelectedRange + this.Position.Year % 10;

                            //Change back the view to one level down
                            this.CalanderViewType = CalanderViewTypes.Year;
                            break;
                    }

                    UpdateSelectionRange(intYear, intMonth, intDay, blnDateSelected, objEvent.ShiftKey);
                    break;

                case "SwitchView":
                    switch (this.CalanderViewType)
                    {
                        case CalanderViewTypes.Day:
                            this.CalanderViewType = CalanderViewTypes.Month;
                            break;
                        case CalanderViewTypes.Month:
                            this.CalanderViewType = CalanderViewTypes.Year;
                            break;
                        case CalanderViewTypes.Year:
                            this.CalanderViewType = CalanderViewTypes.YearRange;
                            break;
                    }
                    break;
            }
        }


        /// <summary>
        /// Updates the selection range.
        /// </summary>
        /// <param name="intYear">The int year.</param>
        /// <param name="intMonth">The int month.</param>
        /// <param name="intDay">The int day.</param>
        /// <param name="blnCloseCalendarForm">if set to <c>true</c> [BLN close calendar form].</param>
        /// <param name="blnRangeSelected">if set to <c>true</c> [BLN range selected].</param>
        private void UpdateSelectionRange(int intYear, int intMonth, int intDay, bool blnCloseCalendarForm, bool blnRangeSelected)
        {
            DateTimePicker objDateTimePicker = DateTimePickerInternal;
            DateTimePickerPopup objCalendarForm = this.CalendarForm;

            //Get the days in the month
            int intDaysInMonth = DateTime.DaysInMonth(intYear, intMonth);

			// Days offset
            int intOffset = 0;

			// The user clicked on a date in the previous month
            if (intDay <= 0)
            {
                intOffset = intDay - 1;
                intDay = 1;
            }

			// User clicked on a day of the next month
            if (intDaysInMonth < intDay)
            {
                intOffset = intDay - intDaysInMonth;
                //use the last day in the mounth
                intDay = intDaysInMonth;
            }

            //In case the CurrentUICulture is not a regular one(like thai)
            //and we should display years according to the Buddhist Era instead of the Georgian
            //When the date comes back from the client we must convert the year back to a regular year.
            DateTime objLocalizedDateTime = Application.CurrentUICulture.Calendar.ToDateTime(intYear, intMonth, intDay, 0, 0, 0, 0).AddDays(intOffset);
            DateTime objSelectedDate = new DateTime(objLocalizedDateTime.Year, objLocalizedDateTime.Month, objLocalizedDateTime.Day);

            // Update Value. 
            this.ValueInternal = objSelectedDate;

            // If Shift pressed
            if (blnRangeSelected)
            {
                DateTime objPivotDate;
                int intMaxSelectionCount = this.MaxSelectionCount - 1;

                // Select pivot date
                if (menmSelectionDirection == CalendarUtils.SelectDirection.RightToLeft)
                {
                    objPivotDate = this.SelectionEnd;
                }
                else
                {
                    objPivotDate = this.SelectionStart;
                }

                // Set current direction.
                menmSelectionDirection = objPivotDate < objSelectedDate ? CalendarUtils.SelectDirection.LeftToRight : CalendarUtils.SelectDirection.RightToLeft;

                // Check if new range exceed MaxSelection
                long lngSelectedDays = Math.Abs((objPivotDate - objSelectedDate).Days);
                if (lngSelectedDays > intMaxSelectionCount)
                {
                    objSelectedDate = objPivotDate.AddDays(intMaxSelectionCount * (menmSelectionDirection == CalendarUtils.SelectDirection.LeftToRight ? 1 : -1));
                }

                // Set new selectiuon range.
                SetRange(new DateTime(Math.Min(objSelectedDate.Ticks, objPivotDate.Ticks)), new DateTime(Math.Max(objSelectedDate.Ticks, objPivotDate.Ticks)));
            }

            // Single date choosen.
            else
            {
                // Set selection range to specific date.
                SetRange(objSelectedDate, objSelectedDate);

                // Reset direction.
                menmSelectionDirection = CalendarUtils.SelectDirection.None;
            }

            if (objDateTimePicker != null)
            {
                objDateTimePicker.Checked = true;
            }

            if (objCalendarForm != null)
            {
                objCalendarForm.OnMonthCalanderValueChanged(blnCloseCalendarForm);
            }

        }

        /// <summary>
        /// Navigates the specified position.
        /// </summary>
        /// <param name="objPosition">The date position.</param>
        /// <param name="intDirection">The navigation direction.</param>
        private void Navigate(DateTime objPosition, int intDirection)
        {
            switch (this.CalanderViewType)
            {
                case CalanderViewTypes.Day:
                    //Move to next month if the days are lager then 31
                    if ((DateTime.MaxValue - objPosition).Days >= 31)
                    {
                        objPosition = objPosition.AddMonths(1 * intDirection);
                        if (objPosition.Day > 1)
                        {
                            objPosition = objPosition.AddDays(1 - objPosition.Day);
                        }
                    }
                    break;
                case CalanderViewTypes.Month:
                    //Move to next year
                    objPosition = objPosition.AddYears(1 * intDirection);
                    break;
                case CalanderViewTypes.Year:
                    //Move to next decade
                    objPosition = objPosition.AddYears(10 * intDirection);
                    break;
                case CalanderViewTypes.YearRange:
                    //Move to next century
                    objPosition = objPosition.AddYears(100 * intDirection);
                    break;
            }
            this.Position = objPosition;
            UpdateSelectionRange(objPosition.Year, objPosition.Month, objPosition.Day, false, false);
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (DateChangedHandler != null) objEvents.Set(WGEvents.ValueChange);
            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }


        #endregion Events

        #region Properties

        /// <summary>Gets or sets the first day of the week as displayed in the month calendar.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
        [SRDescription("MonthCalendarFirstDayOfWeekDescr"), DefaultValue(Day.Default), SRCategory("CatBehavior"), Localizable(true)]
        public Day FirstDayOfWeek
        {
            get
            {
                return this.GetValue<Day>(MonthCalendar.FirstDayOfWeekProperty, Day.Default);
            }
            set
            {
                if (this.SetValue<Day>(MonthCalendar.FirstDayOfWeekProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of days that can be selected in a month calendar control.
        /// </summary>
        /// <value>
        /// The max selection count.
        /// </value>
        [DefaultValue(7)]
        [Category("Behavior")]
        public int MaxSelectionCount
        {
            get
            {
                // Get serialized property from store.
                return this.GetValue<int>(MonthCalendar.MaxSelectionCountProperty, 7);
            }

            set
            {
                // Cannot be less than 1.
                if (value < 1)
                {
                    object[] args = new object[] { "MaxSelectionCount", value.ToString("D", CultureInfo.CurrentCulture), 1.ToString(Application.CurrentUICulture) };
                    throw new ArgumentOutOfRangeException("MaxSelectionCount", SR.GetString("InvalidLowBoundArgumentEx", args));
                }

                if (MaxSelectionCount != value)
                {
                    // Update value in property store.
                    this.SetValue<int>(MonthCalendar.MaxSelectionCountProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the max date.
        /// </summary>
        /// <value>
        /// The max date.
        /// </value>
        [SRDescription("MonthCalendarMaxDateDescr"), SRCategory("CatBehavior")]
        public DateTime MaxDate
        {
            get
            {
                // Get serialized property from store.
                DateTime objMaxDate = this.GetValue<DateTime>(MonthCalendar.MaxDateProperty, CalendarUtils.MaxDateTime);

                // Return validated value.
                return CalendarUtils.GetEffectiveMaxDate(objMaxDate);
            }
            set
            {
                if (value != this.MaxDate)
                {
                    // Get valid bound dates.
                    DateTime objEffectiveMinDate = CalendarUtils.GetEffectiveMinDate(this.MinDate);
                    DateTime objEffectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(this.MaxDate);

                    if (value < objEffectiveMinDate)
                    {
                        throw new ArgumentOutOfRangeException("MaxDate", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "MaxDate", FormatDate(value), "MinDate" }));
                    }

                    if (value != CalendarUtils.MaxDateTime)
                    {
                        // Update value in property store.
                        this.SetValue<DateTime>(MonthCalendar.MaxDateProperty, value);
                    }

                    else
                    {
                        // Remove property from store, if equals to default value.
                        this.RemoveValue<DateTime>(MonthCalendar.MaxDateProperty);
                    }

                    // Set new minmax range.
                    this.SetMinMaxRange(objEffectiveMinDate, objEffectiveMaxDate);

                    this.UpdateParams(AttributeType.Control);

                }
            }
        }

        /// <summary>
        /// Resets the max date.
        /// </summary>
        private void ResetMaxDate()
        {
            this.MaxDate = CalendarUtils.MaxDateTime;
        }



        /// <summary>
        /// Determines whether to serialize MaxDate property.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMaxDate()
        {
            return MaxDate != CalendarUtils.MaxDateTime;
        }

        /// <summary>
        /// Gets or sets the min date.
        /// </summary>
        /// <value>
        /// The min date.
        /// </value>
        [SRDescription("MonthCalendarMinDateDescr"), SRCategory("CatBehavior")]
        public DateTime MinDate
        {
            get
            {
                // Get serialized property from store.
                DateTime objMinDate = this.GetValue<DateTime>(MonthCalendar.MinDateProperty, CalendarUtils.MinDateTime);

                // Return validated value.
                return CalendarUtils.GetEffectiveMinDate(objMinDate);
            }
            set
            {
                if (value != this.MinDate)
                {
                    // Get valid bound dates.
                    DateTime objEffectiveMinDate = CalendarUtils.GetEffectiveMinDate(this.MinDate);
                    DateTime objEffectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(this.MaxDate);

                    // If value above max date, or below available minimum, throw exception.
                    if (value > objEffectiveMaxDate)
                    {
                        throw new ArgumentOutOfRangeException("MinDate", SR.GetString("InvalidHighBoundArgument", new object[] { "MinDate", FormatDate(value), "MaxDate" }));
                    }
                    if (value < CalendarUtils.MinimumDateTime)
                    {
                        throw new ArgumentOutOfRangeException("MinDate", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "MinDate", FormatDate(value), FormatDate(CalendarUtils.MinimumDateTime) }));
                    }

                    if (value != CalendarUtils.MinDateTime)
                    {
                        // Update value in property store.
                        this.SetValue<DateTime>(MonthCalendar.MinDateProperty, value);
                    }

                    else
                    {
                        // Remove property from store, if equals to default value.
                        this.RemoveValue<DateTime>(MonthCalendar.MinDateProperty);
                    }

                    // Set new minmax range.
                    this.SetMinMaxRange(objEffectiveMinDate, objEffectiveMaxDate);

                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Resets the min date.
        /// </summary>
        private void ResetMinDate()
        {
            this.MinDate = CalendarUtils.MinDateTime;
        }



        /// <summary>
        /// Determines whether to serialize MinDate property.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMinDate()
        {
            return MinDate != CalendarUtils.MinDateTime;
        }

        /// <summary>
        /// Gets or sets the end date of the selected range of dates.
        /// </summary>
        /// <value>
        /// The selection end.
        /// </value>
        [Browsable(false)]
        public DateTime SelectionEnd
        {
            get
            {
                // Get serialized property from store.
                return this.GetValue<DateTime>(MonthCalendar.SelectionEndProperty, DateTime.Now.Date);
            }
            set
            {
                if (this.SelectionEnd != value)
                {
                    // Validate bounds.
                    if (value < this.MinDate)
                    {
                        throw new ArgumentOutOfRangeException("SelectionEnd", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SelectionEnd", FormatDate(value), "MinDate" }));
                    }

                    if (value > this.MaxDate)
                    {
                        throw new ArgumentOutOfRangeException("SelectionEnd", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "SelectionEnd", FormatDate(value), "MaxDate" }));
                    }

                    // If less than Start, update start date instead.
                    if (this.SelectionStart > value)
                    {
                        SelectionStartInternal = value;
                    }

                    // Get start-end selection dates span.
                    TimeSpan objSpan = (TimeSpan)(value - this.SelectionStart);

                    // Limit span to MaxSelectionCount by updating start.
                    if (objSpan.Days >= this.MaxSelectionCount)
                    {
                        SelectionStartInternal = value.AddDays((double)(1 - this.MaxSelectionCount));
                    }

                    // Set new selection range.
                    this.SetRange(this.SelectionStart, value);
                }
            }

        }

        /// <summary>
        /// Determines whether to serialize SelectionEnd property.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeSelectionEnd()
        {
            return SelectionEnd != DateTime.Now.Date;
        }

        /// <summary>
        /// Sets the SelectionEnd serialized property.
        /// </summary>
        /// <value>
        /// The selection End setter.
        /// </value>
        private DateTime SelectionEndInternal
        {
            set
            {
                if (value != DateTime.Now.Date)
                {
                    this.SetValue<DateTime>(MonthCalendar.SelectionEndProperty, value);
                }

                else
                {
                    this.RemoveValue<DateTime>(MonthCalendar.SelectionEndProperty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the start date of the selected range of dates.
        /// </summary>
        /// <value>
        /// The selection start.
        /// </value>
        [Browsable(false)]
        public DateTime SelectionStart
        {
            get
            {
                // Get serialized property from store.
                return this.GetValue<DateTime>(MonthCalendar.SelectionStartProperty, DateTime.Now.Date);
            }
            set
            {
                if (this.SelectionStart != value)
                {
                    // Validate bounds.
                    if (value < this.MinDate)
                    {
                        throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SelectionStart", FormatDate(value), "MinDate" }));
                    }

                    if (value > this.MaxDate)
                    {
                        throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "SelectionStart", FormatDate(value), "MaxDate" }));
                    }

                    // If greater than End, update end date instead.
                    if (this.SelectionEnd < value)
                    {
                        SelectionEndInternal = value;
                    }

                    // Get start-end selection dates span.
                    TimeSpan objSpan = (TimeSpan)(this.SelectionEnd - value);

                    // Limit span to MaxSelectionCount by updating end.
                    if (objSpan.Days >= this.MaxSelectionCount)
                    {
                        SelectionEndInternal = value.AddDays((double)(this.MaxSelectionCount - 1));
                    }

                    // Set new selection range.
                    this.SetRange(value, this.SelectionEnd);
                }
            }

        }

        /// <summary>
        /// Determines whether to serialize SelectionStart property.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeSelectionStart()
        {
            return SelectionStart != DateTime.Now.Date;
        }

        /// <summary>
        /// Sets the SelectionStart serialized property.
        /// </summary>
        /// <value>
        /// The selection start setter.
        /// </value>
        private DateTime SelectionStartInternal
        {
            set
            {
                if (value != DateTime.Now.Date)
                {
                    this.SetValue<DateTime>(MonthCalendar.SelectionStartProperty, value);
                }

                else
                {
                    this.RemoveValue<DateTime>(MonthCalendar.SelectionStartProperty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected range of dates for a month calendar control.
        /// </summary>
        /// <value>
        /// The selection range.
        /// </value>
        [BindableAttribute(true)]
        [Category("Behavior")]
        public SelectionRange SelectionRange
        {
            get
            {
                return new SelectionRange(this.SelectionStart, this.SelectionEnd);
            }

            set
            {
                SetSelectionRange(value.Start, value.End);
            }
        }

        /// <summary>
        /// Resets the selection range.
        /// </summary>
        private void ResetSelectionRange()
        {
            this.SetSelectionRange(DateTime.Now.Date, DateTime.Now.Date);
        }

        /// <summary>
        /// Determines whether to serialize SelectionRange property.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeSelectionRange()
        {
            return SelectionRange.Start != DateTime.Now.Date && SelectionRange.End != DateTime.Now.Date;
        }

        /// <summary>
        /// Gets or sets the current date.
        /// </summary>
        /// <value></value>
        [SRDescription("MonthCalendarSelectionValueDescr"), SRCategory("CatBehavior"), Bindable(true)]
        public DateTime Value
        {
            get
            {
                return this.GetValue<DateTime>(MonthCalendar.ValueProperty, DateTime.Now.Date);
            }
            set
            {
                if (Value != value)
                {
                    // If value is not default (DateTime.Now), set it in Serializable Property
                    if (value != DateTime.Now.Date)
                    {
                        this.SetValue<DateTime>(MonthCalendar.ValueProperty, value);
                    }
                    //If value is Default (DateTime.Now), remove it from Serializable Property
                    else
                    {
                        this.RemoveValue<DateTime>(MonthCalendar.ValueProperty);
                    }

                    // If Value set out of bands of selection range, set range to value.
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

        /// <summary>
        /// Resets the value.
        /// </summary>
        private void ResetValue()
        {
            this.Value = DateTime.Now.Date;
        }

        /// <summary>
        /// Gets or sets the type of the calander view.
        /// </summary>
        /// <value>The type of the calander view.</value>
        protected internal CalanderViewTypes CalanderViewType
        {
            get
            {
                return this.GetValue<CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty, CalanderViewTypes.Day);
            }
            set
            {
                if (CalanderViewType != value)
                {
                    // If value is not default (DateTime.Now), set it in Serializable Property
                    if (value != CalanderViewTypes.Day)
                    {
                        this.SetValue<CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty, value);
                    }
                    //If value is Default (DateTime.Now), remove it from Serializable Property
                    else
                    {
                        this.RemoveValue<CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty);
                    }
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the range.
        /// </summary>
        /// <param name="objMinDate">The min date.</param>
        /// <param name="objMaxDate">The max date.</param>
        private void SetMinMaxRange(DateTime objMinDate, DateTime objMaxDate)
        {
            // Validate dates bounds.
            if (this.SelectionStart < objMinDate)
            {
                this.SelectionStart = objMinDate;
            }

            if (this.SelectionStart > objMaxDate)
            {
                this.SelectionStart = objMaxDate;
            }

            if (this.SelectionEnd < objMinDate)
            {
                this.SelectionEnd = objMinDate;
            }

            if (this.SelectionEnd > objMaxDate)
            {
                this.SelectionEnd = objMaxDate;
            }

            // Set range.
            this.SetRange(this.SelectionStart, this.SelectionEnd);
        }

        /// <summary>
        /// Sets the selection range.
        /// </summary>
        /// <param name="objLowerDate">The lower date.</param>
        /// <param name="objUpperDate">The upper date.</param>
        private void SetRange(DateTime objLowerDate, DateTime objUpperDate)
        {
            bool blnDateChanged = false;

            // Update selection range.
            if ((this.SelectionStart != objLowerDate) || (this.SelectionEnd != objUpperDate))
            {
                blnDateChanged = true;

                SelectionStartInternal = objLowerDate;

                SelectionEndInternal = objUpperDate;
            }

            // Raise events, update control.
            if (blnDateChanged)
            {
                this.Position = objLowerDate;
                this.OnValueChanged(new EventArgs());
                this.OnDateChanged(EventArgs.Empty);
                this.Update();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:DateChanged"/> event.
        /// </summary>
        /// <param name="objEvents">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnDateChanged(EventArgs objEvents)
        {
            if (this.DateChangedHandler != null)
            {
                this.DateChangedHandler(this, objEvents);
            }
        }

        /// <summary>
        /// Sets the selection range.
        /// </summary>
        /// <param name="objMinDate">The min date.</param>
        /// <param name="objMaxDate">The max date.</param>
        public void SetSelectionRange(DateTime objMinDate, DateTime objMaxDate)
        {
            // Validate dates bounds.
            if (objMinDate.Ticks < this.MinDate.Ticks)
            {
                throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SelectionStart", FormatDate(objMinDate), "MinDate" }));
            }

            if (objMinDate.Ticks > this.MaxDate.Ticks)
            {
                throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "SelectionEnd", FormatDate(objMinDate), "MaxDate" }));
            }

            if (objMaxDate.Ticks < this.MinDate.Ticks)
            {
                throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidLowBoundArgumentEx", new object[] { "SelectionStart", FormatDate(objMaxDate), "MinDate" }));
            }

            if (objMaxDate.Ticks > this.MaxDate.Ticks)
            {
                throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "SelectionEnd", FormatDate(objMaxDate), "MaxDate" }));
            }

            if (objMinDate > objMaxDate)
            {
                objMaxDate = objMinDate;
            }

            // Get dates span.
            TimeSpan objSpan = (TimeSpan)(objMaxDate - objMinDate);

            // Limit span to max selection count...
            if (objSpan.Days >= this.MaxSelectionCount)
            {
                // ..by updating min date, if selection starts at min date.
                if (objMinDate.Ticks == this.SelectionStart.Ticks)
                {
                    objMinDate = objMaxDate.AddDays((double)(1 - this.MaxSelectionCount));
                }

                // otherwise, update max date.
                else
                {
                    objMaxDate = objMinDate.AddDays((double)(this.MaxSelectionCount - 1));
                }
            }
            this.SetRange(objMinDate, objMaxDate);
        }

        /// <summary>
        /// Adds a day that is displayed in bold on an annual basis in the month calendar.
        /// </summary>
        /// <param name="objDate">The date to be displayed in bold.</param>
        public void AddAnnuallyBoldedDate(DateTime objDate)
        {
            List<DateTime> objBoldedDate = new List<DateTime>();

            objBoldedDate.AddRange(this.AnnuallyBoldedDates);
            objBoldedDate.Add(objDate);

            this.AnnuallyBoldedDates = objBoldedDate.ToArray();
        }

        /// <summary>
        /// Adds a day to be displayed in bold in the month calendar.
        /// </summary>
        /// <param name="objDate">The date to be displayed in bold.</param>
        public void AddBoldedDate(DateTime objDate)
        {
            List<DateTime> objBoldedDate = new List<DateTime>();

            objBoldedDate.AddRange(this.BoldedDates);
            objBoldedDate.Add(objDate);

            this.BoldedDates = objBoldedDate.ToArray();
        }


        /// <summary>
        /// Adds a day that is displayed in bold on a monthly basis in the month calendar.
        /// </summary>
        /// <param name="objDate">The date to be displayed in bold.</param>
        public void AddMonthlyBoldedDate(DateTime objDate)
        {
            List<DateTime> objBoldedDate = new List<DateTime>();

            objBoldedDate.AddRange(this.MonthlyBoldedDates);
            objBoldedDate.Add(objDate);

            this.MonthlyBoldedDates = objBoldedDate.ToArray();
        }

        /// <summary>
        /// Shoulds the serialize annually bolded dates.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeAnnuallyBoldedDates()
        {
            return (this.AnnuallyBoldedDates.Length > 0);
        }

        /// <summary>
        /// Shoulds the serialize bolded dates.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBoldedDates()
        {
            return (this.BoldedDates.Length > 0);
        }

        /// <summary>
        /// Shoulds the serialize monthly bolded dates.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMonthlyBoldedDates()
        {
            return (this.MonthlyBoldedDates.Length > 0);
        }

        #endregion Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal enum CalanderViewTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Day = 0,
            /// <summary>
            /// 
            /// </summary>
            Month = 1,
            /// <summary>
            /// 
            /// </summary>
            Year = 2,
            /// <summary>
            /// 
            /// </summary>
            YearRange = 3
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(176, 153);
            }
        }

        /// <summary>
        /// Gets or sets the today date.
        /// </summary>
        /// <value>
        /// The today date.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// TodayDate
        /// </exception>
        [SRDescription("MonthCalendarTodayDateDescr")]
        [SRCategory("CatBehavior")]
        public DateTime TodayDate
        {
            get
            {
                if (this.TodayDateSet)
                {
                    return this.GetValue<DateTime>(MonthCalendar.TodatDateProperty);
                }

                return DateTime.Now.Date;
            }
            set
            {
                // Setting the same today date
                if (this.TodayDateSet && DateTime.Compare(value, this.GetValue<DateTime>(MonthCalendar.TodatDateProperty)) == 0)
                {
                    return;
                }

                if (DateTime.Compare(value, this.MaxDate) > 0)
                {
                    throw new ArgumentOutOfRangeException("TodayDate", SR.GetString("InvalidHighBoundArgumentEx", (object)"TodayDate", (object)MonthCalendar.FormatDate(value), (object)MonthCalendar.FormatDate(this.MaxDate)));
                }
                else if (DateTime.Compare(value, this.MinDate) < 0)
                {
                    throw new ArgumentOutOfRangeException("TodayDate", SR.GetString("InvalidLowBoundArgument", (object)"TodayDate", (object)MonthCalendar.FormatDate(value), (object)MonthCalendar.FormatDate(this.MinDate)));
                }
                else
                {
                    this.SetValue<DateTime>(MonthCalendar.TodatDateProperty, value.Date);
                    this.TodayDateSet = true;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [today date set].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [today date set]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("MonthCalendarTodayDateSetDescr")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRCategory("CatBehavior")]
        public bool TodayDateSet
        {
            get
            {
                return this.GetValue<bool>(MonthCalendar.TodayDateSetProperty, false);
            }
            private set
            {
                this.SetValue<bool>(MonthCalendar.TodayDateSetProperty, value);
            }
        }

        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="objDateTime">The obj date time.</param>
        /// <returns></returns>
        private static string FormatDate(DateTime objDateTime)
        {
            return objDateTime.ToString("d", Application.CurrentUICulture);
        }
    }

    #endregion MonthCalendar Class

    #region CalendarUtils Class

    /// <summary>
    /// DateTimePicker and MonthCalendar utils class. Stores culture-specific and default date/time related static values.
    /// </summary>
    internal static class CalendarUtils
    {
        /// <summary>
        /// Represents the selection range select direction.
        /// </summary>
        internal enum SelectDirection
        {
            LeftToRight,
            RightToLeft,
            None
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        internal static readonly DateTime MaxDateTime;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly DateTime MinDateTime;

        /// <summary>
        /// Gets the maximum date time.
        /// </summary>
        internal static DateTime MaximumDateTime
        {
            get
            {
                DateTime maxSupportedDateTime = CultureInfo.CurrentUICulture.Calendar.MaxSupportedDateTime;
                if (maxSupportedDateTime.Year > MaxDateTime.Year)
                {
                    return MaxDateTime;
                }
                return maxSupportedDateTime;
            }
        }

        /// <summary>
        /// Gets the minimum date time.
        /// </summary>
        internal static DateTime MinimumDateTime
        {
            get
            {
                DateTime objMinSupportedDateTime = CultureInfo.CurrentUICulture.Calendar.MinSupportedDateTime;
                if (objMinSupportedDateTime.Year < MinDateTime.Year)
                {
                    return MinDateTime;
                }
                return objMinSupportedDateTime;
            }
        }

        /// <summary>
        /// Initializes the <see cref="CalendarUtils"/> class.
        /// </summary>
        static CalendarUtils()
        {
            // Set default minimum and maximum dates.
            MinDateTime = new DateTime(1753, 1, 1);
            MaxDateTime = new DateTime(9998, 12, 31);
        }

        /// <summary>
        /// Gets the effective max date.
        /// </summary>
        /// <param name="objMaxDate">The max date.</param>
        /// <returns></returns>
        internal static DateTime GetEffectiveMaxDate(DateTime objMaxDate)
        {
            DateTime objMaximumDateTime = MaximumDateTime;
            if (objMaxDate > objMaximumDateTime)
            {
                return objMaximumDateTime;
            }
            return objMaxDate;
        }

        /// <summary>
        /// Gets the effective min date.
        /// </summary>
        /// <param name="objMinDate">The min date.</param>
        /// <returns></returns>
        internal static DateTime GetEffectiveMinDate(DateTime objMinDate)
        {
            DateTime objMinimumDateTime = MinimumDateTime;
            if (objMinDate < objMinimumDateTime)
            {
                return objMinimumDateTime;
            }
            return objMinDate;
        }
    }

    #endregion
}
