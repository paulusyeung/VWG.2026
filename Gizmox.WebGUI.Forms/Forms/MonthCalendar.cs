// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MonthCalendar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A calendar control.</summary>
  [DefaultEvent("DateChanged")]
  [ToolboxBitmap(typeof (MonthCalendar), "MonthCalendar_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.MonthCalendarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.MonthCalendarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("MC")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MonthCalendarSkin))]
  [Serializable]
  public class MonthCalendar : Control
  {
    /// <summary>
    /// Provides a property reference to FirstDayOfWeek property.
    /// </summary>
    private static SerializableProperty FirstDayOfWeekProperty = SerializableProperty.Register(nameof (FirstDayOfWeek), typeof (Day), typeof (MonthCalendar), new SerializablePropertyMetadata((object) Day.Default));
    /// <summary>Provides a property reference to Form property.</summary>
    private static SerializableProperty FormProperty = SerializableProperty.Register("Form", typeof (DateTimePickerPopup), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to DateTimePicker property.
    /// </summary>
    private static SerializableProperty DateTimePickerProperty = SerializableProperty.Register("DateTimePicker", typeof (DateTimePicker), typeof (MonthCalendar));
    /// <summary>Provides a property reference to Position property.</summary>
    private static SerializableProperty PositionProperty = SerializableProperty.Register(nameof (Position), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>Provides a property reference to Value property.</summary>
    private static SerializableProperty ValueProperty = SerializableProperty.Register(nameof (Value), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to BoldedDates property.
    /// </summary>
    private static SerializableProperty BoldedDatesProperty = SerializableProperty.Register(nameof (BoldedDates), typeof (DateTime[]), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to AnnuallyBoldedDates property.
    /// </summary>
    private static SerializableProperty AnnuallyBoldedDatesProperty = SerializableProperty.Register(nameof (AnnuallyBoldedDates), typeof (DateTime[]), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to MonthlyBoldedDates property.
    /// </summary>
    private static SerializableProperty MonthlyBoldedDatesProperty = SerializableProperty.Register(nameof (MonthlyBoldedDates), typeof (DateTime[]), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to CalanderViewType property.
    /// </summary>
    private static SerializableProperty CalanderViewTypeProperty = SerializableProperty.Register(nameof (CalanderViewType), typeof (MonthCalendar.CalanderViewTypes), typeof (MonthCalendar));
    /// <summary>Provides a property reference to TodayDate property.</summary>
    private static SerializableProperty TodayDateProperty = SerializableProperty.Register(nameof (TodayDate), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to SelectionStart property.
    /// </summary>
    private static SerializableProperty SelectionStartProperty = SerializableProperty.Register(nameof (SelectionStart), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to SelectionEnd property.
    /// </summary>
    private static SerializableProperty SelectionEndProperty = SerializableProperty.Register(nameof (SelectionEnd), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>Provides a property reference to MaxDate property.</summary>
    private static SerializableProperty MaxDateProperty = SerializableProperty.Register(nameof (MaxDate), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>Provides a property reference to MinDate property.</summary>
    private static SerializableProperty MinDateProperty = SerializableProperty.Register(nameof (MinDate), typeof (DateTime), typeof (MonthCalendar));
    /// <summary>
    /// Provides a property reference to MaxSelectionCount property.
    /// </summary>
    private static SerializableProperty MaxSelectionCountProperty = SerializableProperty.Register(nameof (MaxSelectionCount), typeof (int), typeof (MonthCalendar));
    private static SerializableProperty TodatDateProperty = SerializableProperty.Register("TodatDate", typeof (DateTime[]), typeof (MonthCalendar));
    private static SerializableProperty TodayDateSetProperty = SerializableProperty.Register(nameof (TodayDateSet), typeof (bool), typeof (MonthCalendar));
    private CalendarUtils.SelectDirection menmSelectionDirection = CalendarUtils.SelectDirection.None;
    /// <summary>The DateChanged event registration.</summary>
    private static readonly SerializableEvent DateChangedEvent = SerializableEvent.Register("DateChanged", typeof (EventHandler), typeof (MonthCalendar));
    /// <summary>The ValueChanged event registration.</summary>
    private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof (EventHandler), typeof (MonthCalendar));

    /// <summary>Gets or sets the bolded dates.</summary>
    /// <value>The bolded dates.</value>
    public DateTime[] BoldedDates
    {
      get => this.GetValue<DateTime[]>(MonthCalendar.BoldedDatesProperty, new DateTime[0]);
      set
      {
        if (value == this.BoldedDates)
          return;
        if (value == null || value.Length == 0)
          this.RemoveValue<DateTime[]>(MonthCalendar.BoldedDatesProperty);
        else
          this.SetValue<DateTime[]>(MonthCalendar.BoldedDatesProperty, value);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the annually bolded dates.</summary>
    /// <value>The annually bolded dates.</value>
    public DateTime[] AnnuallyBoldedDates
    {
      get => this.GetValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty, new DateTime[0]);
      set
      {
        if (value == this.AnnuallyBoldedDates)
          return;
        if (value == null || value.Length == 0)
          this.RemoveValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty);
        else
          this.SetValue<DateTime[]>(MonthCalendar.AnnuallyBoldedDatesProperty, value);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the monthly bolded dates property.</summary>
    /// <value>The monthly bolded dates property.</value>
    public DateTime[] MonthlyBoldedDates
    {
      get => this.GetValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty, new DateTime[0]);
      set
      {
        if (value == this.MonthlyBoldedDates)
          return;
        if (value == null || value.Length == 0)
          this.RemoveValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty);
        else
          this.SetValue<DateTime[]>(MonthCalendar.MonthlyBoldedDatesProperty, value);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>The calendar date time value</summary>
    private DateTime ValueInternal
    {
      get => this.GetValue<DateTime>(MonthCalendar.ValueProperty, DateTime.Now);
      set
      {
        if (!(this.Value != value))
          return;
        if (value != DateTime.Now)
          this.SetValue<DateTime>(MonthCalendar.ValueProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.ValueProperty);
      }
    }

    /// <summary>The calendar date time displayed position</summary>
    private DateTime Position
    {
      get => this.GetValue<DateTime>(MonthCalendar.PositionProperty, DateTime.Now);
      set
      {
        if (!(value != this.Position))
          return;
        if (value != DateTime.Now)
          this.SetValue<DateTime>(MonthCalendar.PositionProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.PositionProperty);
      }
    }

    private DateTimePicker DateTimePickerInternal
    {
      get => this.GetValue<DateTimePicker>(MonthCalendar.DateTimePickerProperty);
      set
      {
        if (this.DateTimePickerInternal == value)
          return;
        this.SetValue<DateTimePicker>(MonthCalendar.DateTimePickerProperty, value);
      }
    }

    /// <summary>The calendar owner form</summary>
    private DateTimePickerPopup CalendarForm
    {
      get => this.GetValue<DateTimePickerPopup>(MonthCalendar.FormProperty);
      set
      {
        if (this.CalendarForm == value)
          return;
        this.SetValue<DateTimePickerPopup>(MonthCalendar.FormProperty, value);
      }
    }

    /// <summary>Occurs when the date is changed</summary>
    public event EventHandler DateChanged
    {
      add => this.AddCriticalHandler(MonthCalendar.DateChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(MonthCalendar.DateChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DateChanged event.</summary>
    private EventHandler DateChangedHandler => (EventHandler) this.GetHandler(MonthCalendar.DateChangedEvent);

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property changes.
    /// </summary>
    [SRDescription("valueChangedEventDescr")]
    [SRCategory("CatAction")]
    public event EventHandler ValueChanged
    {
      add => this.AddHandler(MonthCalendar.ValueChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(MonthCalendar.ValueChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client date changed].</summary>
    [SRDescription("dateChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientDateChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Gets the hanlder for the ValueChanged event.</summary>
    private EventHandler ValueChangedHandler => (EventHandler) this.GetHandler(MonthCalendar.ValueChangedEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImage"></see> property changes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler BackgroundImageChanged
    {
      add => base.BackgroundImageChanged += value;
      remove => base.BackgroundImageChanged -= value;
    }

    /// <summary>
    /// Occurs when the <see cref="P:System.Windows.Forms.MonthCalendar.BackgroundImageLayout"></see> property changes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler BackgroundImageLayoutChanged
    {
      add => base.BackgroundImageLayoutChanged += value;
      remove => base.BackgroundImageLayoutChanged -= value;
    }

    /// <summary>
    /// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler Click
    {
      add => base.Click += value;
      remove => base.Click -= value;
    }

    /// <summary>
    /// Occurs when the user double-clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler DoubleClick
    {
      add => base.DoubleClick += value;
      remove => base.DoubleClick -= value;
    }

    /// <summary>
    /// Occurs when the user clicks the <see cref="T:System.Windows.Forms.MonthCalendar"></see> control with the mouse.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event MouseEventHandler MouseClick
    {
      add => base.MouseClick += value;
      remove => base.MouseClick -= value;
    }

    /// <summary>
    /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Padding"></see> property changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler PaddingChanged
    {
      add => base.PaddingChanged += value;
      remove => base.PaddingChanged -= value;
    }

    /// <summary>
    /// Occurs when the value of the <see cref="P:System.Windows.Forms.MonthCalendar.Text"></see> property changes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MonthCalendar" /> instance.
    /// </summary>
    public MonthCalendar()
    {
      this.Size = new Size(179, 155);
      this.SetStyle(ControlStyles.UserPaint, false);
      this.SetStyle(ControlStyles.StandardClick, false);
      this.InitializeComponent();
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MonthCalendar" /> instance.
    /// </summary>
    internal MonthCalendar(DateTimePicker objDateTimePicker, DateTimePickerPopup objCalendarForm)
    {
      this.Size = new Size(179, 155);
      this.DateTimePickerInternal = objDateTimePicker;
      this.CalendarForm = objCalendarForm;
      if (objDateTimePicker != null)
        this.Position = this.ValueInternal = objDateTimePicker.Value;
      this.SetStyle(ControlStyles.UserPaint, false);
      this.SetStyle(ControlStyles.StandardClick, false);
      this.InitializeComponent();
    }

    private void InitializeComponent() => this.ValueInternal = this.Position = DateTime.Now;

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      DateTime dateTime1;
      ref DateTime local1 = ref dateTime1;
      DateTime position1 = this.Position;
      int year1 = position1.Year;
      position1 = this.Position;
      int month = position1.Month;
      local1 = new DateTime(year1, month, 1, 0, 0, 0);
      DateTime maxValue;
      if (DateTime.MaxValue.Year == dateTime1.Year)
      {
        maxValue = DateTime.MaxValue;
        if (maxValue.Month == dateTime1.Month)
        {
          dateTime1 = new DateTime(9999, 12, 31, 0, 0, 0);
          goto label_4;
        }
      }
      dateTime1 = dateTime1.AddMonths(1).AddDays(-1.0);
label_4:
      int displayStartIndex = this.GetDisplayStartIndex();
      DateTime position2 = this.Position;
      ref DateTime local2 = ref position2;
      DateTime dateTime2 = local2.AddDays((double) -local2.Day);
      objWriter.WriteAttributeString("DisplayStart", displayStartIndex.ToString());
      objWriter.WriteAttributeString("DisplayDays", dateTime1.Day.ToString());
      IResponseWriter responseWriter1 = objWriter;
      int num = position2.Month;
      string strValue1 = num.ToString();
      responseWriter1.WriteAttributeString("DisplayMonth", strValue1);
      IResponseWriter responseWriter2 = objWriter;
      num = dateTime2.Day;
      string strValue2 = num.ToString();
      responseWriter2.WriteAttributeString("DisplayPreviousMonthLastDay", strValue2);
      DateTime todayDate = this.TodayDate;
      if (position2.Year == todayDate.Year && position2.Month == todayDate.Month)
      {
        IResponseWriter responseWriter3 = objWriter;
        num = todayDate.Day;
        string strValue3 = num.ToString();
        responseWriter3.WriteAttributeString("TodayDay", strValue3);
      }
      int year2 = Application.CurrentUICulture.Calendar.GetYear(position2);
      objWriter.WriteAttributeString("DisplayYear", year2.ToString());
      IResponseWriter responseWriter4 = objWriter;
      num = this.DayToNumber(this.FirstDayOfWeek);
      string strValue4 = num.ToString();
      responseWriter4.WriteAttributeString("DisplayFirstWeekDay", strValue4);
      if (this.CalanderViewType != MonthCalendar.CalanderViewTypes.Day)
      {
        IResponseWriter responseWriter5 = objWriter;
        num = (int) this.CalanderViewType;
        string strValue5 = num.ToString();
        responseWriter5.WriteAttributeString("CVT", strValue5);
      }
      CultureInfo provider = CultureInfo.InvariantCulture;
      if (this.Context != null && this.Context.CurrentUICulture != null)
        provider = this.Context.CurrentUICulture;
      objWriter.WriteAttributeString("DYM", position2.ToString(provider.DateTimeFormat.YearMonthPattern, (IFormatProvider) provider));
      IResponseWriter responseWriter6 = objWriter;
      maxValue = this.Value;
      string strValue6 = maxValue.Ticks.ToString();
      responseWriter6.WriteAttributeString("DT", strValue6);
    }

    private int GetDisplayStartIndex()
    {
      DateTime dateTime;
      ref DateTime local = ref dateTime;
      DateTime position = this.Position;
      int year = position.Year;
      position = this.Position;
      int month = position.Month;
      local = new DateTime(year, month, 1, 0, 0, 0);
      int number1 = this.DayToNumber(this.FirstDayOfWeek);
      int number2 = this.DayToNumber(dateTime.DayOfWeek);
      return number1 > number2 ? 7 - (number1 - number2) + 1 : number2 - number1 + 1;
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderBoldedDatesAttribute(objWriter, false);
      this.RenderSelectionAttributes(objWriter);
      this.RenderMinMaxDateAttributes(objWriter, false);
    }

    /// <summary>Renders the min max date attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderMinMaxDateAttributes(IAttributeWriter objWriter, bool blnForceRender)
    {
      DateTime minDate = this.MinDate;
      if (minDate != CalendarUtils.MinDateTime | blnForceRender)
      {
        objWriter.WriteAttributeString("NDD", minDate.Day.ToString());
        objWriter.WriteAttributeString("NDM", minDate.Month.ToString());
        int year = Application.CurrentUICulture.Calendar.GetYear(minDate);
        objWriter.WriteAttributeString("NDY", year.ToString());
      }
      DateTime maxDate = this.MaxDate;
      if (!(maxDate != CalendarUtils.MaxDateTime | blnForceRender))
        return;
      objWriter.WriteAttributeString("XDD", maxDate.Day.ToString());
      objWriter.WriteAttributeString("XDM", maxDate.Month.ToString());
      int year1 = Application.CurrentUICulture.Calendar.GetYear(maxDate);
      objWriter.WriteAttributeString("XDY", year1.ToString());
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderBoldedDatesAttribute(objWriter, true);
        this.RenderSelectionAttributes(objWriter);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderMinMaxDateAttributes(objWriter, true);
    }

    /// <summary>Renders the selection attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderSelectionAttributes(IAttributeWriter objWriter)
    {
      DateTime selectionStart = this.SelectionStart;
      DateTime selectionEnd = this.SelectionEnd;
      objWriter.WriteAttributeString("SSD", selectionStart.Day.ToString());
      objWriter.WriteAttributeString("SSM", selectionStart.Month.ToString());
      int year1 = Application.CurrentUICulture.Calendar.GetYear(selectionStart);
      objWriter.WriteAttributeString("SSY", year1.ToString());
      objWriter.WriteAttributeString("ESD", selectionEnd.Day.ToString());
      objWriter.WriteAttributeString("ESM", selectionEnd.Month.ToString());
      int year2 = Application.CurrentUICulture.Calendar.GetYear(selectionEnd);
      objWriter.WriteAttributeString("ESY", year2.ToString());
    }

    /// <summary>Renders the bolded dates attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderBoldedDatesAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      string boldedDatesIndexes = this.GetBoldedDatesIndexes();
      if (!(!string.IsNullOrEmpty(boldedDatesIndexes) | blnForceRender))
        return;
      objWriter.WriteAttributeString("BD", boldedDatesIndexes);
    }

    /// <summary>Gets the bolded dates indexes.</summary>
    /// <returns></returns>
    private string GetBoldedDatesIndexes()
    {
      List<string> stringList = new List<string>();
      DateTime position = this.Position;
      int day = DateTime.DaysInMonth(position.Year, position.Month);
      int displayStartIndex = this.GetDisplayStartIndex();
      int num1 = (7 - (displayStartIndex + day - 1) % 7) % 7;
      DateTime objBoldedMinDate = new DateTime(position.Year, position.Month, 1).AddDays((double) -displayStartIndex);
      DateTime objBoldedMaxDate = new DateTime(position.Year, position.Month, day).AddDays((double) num1);
      DateTime minDate = this.MinDate;
      if (minDate > objBoldedMinDate)
        objBoldedMinDate = minDate;
      DateTime maxDate = this.MaxDate;
      if (maxDate < objBoldedMaxDate)
        objBoldedMaxDate = maxDate;
      foreach (DateTime boldedDisplayedDate in this.GetAllBoldedDisplayedDates(position, objBoldedMinDate, objBoldedMaxDate))
      {
        int num2 = (boldedDisplayedDate - new DateTime(position.Year, position.Month, 1)).Days + 1;
        if (!stringList.Contains(num2.ToString()))
          stringList.Add(num2.ToString());
      }
      return string.Join(",", stringList.ToArray());
    }

    /// <summary>Gets all bolded displayed dates.</summary>
    /// <param name="objCurrentPosition">The object current position.</param>
    /// <param name="objBoldedMinDate">The object bolded minimum date.</param>
    /// <param name="objBoldedMaxDate">The object bolded maximum date.</param>
    /// <returns></returns>
    private DateTime[] GetAllBoldedDisplayedDates(
      DateTime objCurrentPosition,
      DateTime objBoldedMinDate,
      DateTime objBoldedMaxDate)
    {
      List<DateTime> dateTimeList = new List<DateTime>();
      DateTime[] boldedDates = this.BoldedDates;
      DateTime[] monthlyBoldedDates = this.MonthlyBoldedDates;
      DateTime[] annuallyBoldedDates = this.AnnuallyBoldedDates;
      foreach (DateTime dateTime in boldedDates)
      {
        if (dateTime > objBoldedMinDate && dateTime <= objBoldedMaxDate)
          dateTimeList.Add(dateTime);
      }
      foreach (DateTime dateTime1 in monthlyBoldedDates)
      {
        DateTime dateTime2 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime1.Day);
        DateTime dateTime3 = dateTime2.AddMonths(-1);
        dateTime2 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime1.Day);
        DateTime dateTime4 = dateTime2.AddMonths(1);
        DateTime dateTime5 = new DateTime(objCurrentPosition.Year, objCurrentPosition.Month, dateTime1.Day);
        if (dateTime3 > objBoldedMinDate && dateTime3 <= objBoldedMaxDate)
          dateTimeList.Add(dateTime3);
        if (dateTime4 > objBoldedMinDate && dateTime4 <= objBoldedMaxDate)
          dateTimeList.Add(dateTime4);
        if (dateTime5 > objBoldedMinDate && dateTime5 <= objBoldedMaxDate)
          dateTimeList.Add(dateTime5);
      }
      foreach (DateTime dateTime6 in annuallyBoldedDates)
      {
        DateTime dateTime7 = new DateTime(objCurrentPosition.Year, dateTime6.Month, dateTime6.Day);
        if (dateTime7 > objBoldedMinDate && dateTime7 <= objBoldedMaxDate)
          dateTimeList.Add(dateTime7);
      }
      return dateTimeList.ToArray();
    }

    /// <summary>Convers a day to number in week.</summary>
    /// <param name="enmDay">Enm day.</param>
    /// <returns></returns>
    private int DayToNumber(DayOfWeek enmDay)
    {
      switch (enmDay)
      {
        case DayOfWeek.Sunday:
          return 1;
        case DayOfWeek.Monday:
          return 2;
        case DayOfWeek.Tuesday:
          return 3;
        case DayOfWeek.Wednesday:
          return 4;
        case DayOfWeek.Thursday:
          return 5;
        case DayOfWeek.Friday:
          return 6;
        case DayOfWeek.Saturday:
          return 7;
        default:
          return 1;
      }
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DateTimePicker.ValueChanged"></see> event.</summary>
    /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnValueChanged(EventArgs objEventArgs)
    {
      EventHandler valueChangedHandler = this.ValueChangedHandler;
      if (valueChangedHandler == null)
        return;
      valueChangedHandler((object) this, objEventArgs);
    }

    /// <summary>Convers a day to number in week.</summary>
    /// <param name="enmDay">Enm day.</param>
    /// <returns></returns>
    private int DayToNumber(Day enmDay)
    {
      switch (enmDay)
      {
        case Day.Monday:
          return 2;
        case Day.Tuesday:
          return 3;
        case Day.Wednesday:
          return 4;
        case Day.Thursday:
          return 5;
        case Day.Friday:
          return 6;
        case Day.Saturday:
          return 7;
        case Day.Sunday:
          return 1;
        default:
          return 1;
      }
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      DateTime position = this.Position;
      switch (objEvent.Type)
      {
        case "Next":
          this.Navigate(position, 1);
          break;
        case "Previous":
          this.Navigate(position, -1);
          break;
        case "NavigateYear":
          this.Position = position.AddYears(int.Parse(objEvent["Year"]) - position.Year);
          this.Update();
          break;
        case "NavigateMonth":
          this.Position = position.AddMonths(int.Parse(objEvent["Month"]) - position.Month);
          this.Update();
          break;
        case "ValueChange":
          int day = position.Day;
          int month = position.Month;
          int intYear = position.Year;
          bool blnCloseCalendarForm = false;
          switch (this.CalanderViewType)
          {
            case MonthCalendar.CalanderViewTypes.Day:
              day = int.Parse(objEvent["Value"]);
              blnCloseCalendarForm = true;
              break;
            case MonthCalendar.CalanderViewTypes.Month:
              month = int.Parse(objEvent["Value"]);
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.Day;
              break;
            case MonthCalendar.CalanderViewTypes.Year:
              intYear = int.Parse(objEvent["Value"]);
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.Month;
              break;
            case MonthCalendar.CalanderViewTypes.YearRange:
              intYear = int.Parse(objEvent["Value"]) + this.Position.Year % 10;
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.Year;
              break;
          }
          this.UpdateSelectionRange(intYear, month, day, blnCloseCalendarForm, objEvent.ShiftKey);
          break;
        case "SwitchView":
          switch (this.CalanderViewType)
          {
            case MonthCalendar.CalanderViewTypes.Day:
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.Month;
              return;
            case MonthCalendar.CalanderViewTypes.Month:
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.Year;
              return;
            case MonthCalendar.CalanderViewTypes.Year:
              this.CalanderViewType = MonthCalendar.CalanderViewTypes.YearRange;
              return;
            default:
              return;
          }
      }
    }

    /// <summary>Updates the selection range.</summary>
    /// <param name="intYear">The int year.</param>
    /// <param name="intMonth">The int month.</param>
    /// <param name="intDay">The int day.</param>
    /// <param name="blnCloseCalendarForm">if set to <c>true</c> [BLN close calendar form].</param>
    /// <param name="blnRangeSelected">if set to <c>true</c> [BLN range selected].</param>
    private void UpdateSelectionRange(
      int intYear,
      int intMonth,
      int intDay,
      bool blnCloseCalendarForm,
      bool blnRangeSelected)
    {
      DateTimePicker timePickerInternal = this.DateTimePickerInternal;
      DateTimePickerPopup calendarForm = this.CalendarForm;
      int num1 = DateTime.DaysInMonth(intYear, intMonth);
      int num2 = 0;
      if (intDay <= 0)
      {
        num2 = intDay - 1;
        intDay = 1;
      }
      if (num1 < intDay)
      {
        num2 = intDay - num1;
        intDay = num1;
      }
      DateTime dateTime1 = Application.CurrentUICulture.Calendar.ToDateTime(intYear, intMonth, intDay, 0, 0, 0, 0).AddDays((double) num2);
      DateTime dateTime2 = new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day);
      this.ValueInternal = dateTime2;
      if (blnRangeSelected)
      {
        int num3 = this.MaxSelectionCount - 1;
        DateTime dateTime3 = this.menmSelectionDirection != CalendarUtils.SelectDirection.RightToLeft ? this.SelectionStart : this.SelectionEnd;
        this.menmSelectionDirection = dateTime3 < dateTime2 ? CalendarUtils.SelectDirection.LeftToRight : CalendarUtils.SelectDirection.RightToLeft;
        if ((long) Math.Abs((dateTime3 - dateTime2).Days) > (long) num3)
          dateTime2 = dateTime3.AddDays((double) (num3 * (this.menmSelectionDirection == CalendarUtils.SelectDirection.LeftToRight ? 1 : -1)));
        this.SetRange(new DateTime(Math.Min(dateTime2.Ticks, dateTime3.Ticks)), new DateTime(Math.Max(dateTime2.Ticks, dateTime3.Ticks)));
      }
      else
      {
        DateTime dateTime4 = dateTime2;
        this.SetRange(dateTime4, dateTime4);
        this.menmSelectionDirection = CalendarUtils.SelectDirection.None;
      }
      if (timePickerInternal != null)
        timePickerInternal.Checked = true;
      calendarForm?.OnMonthCalanderValueChanged(blnCloseCalendarForm);
    }

    /// <summary>Navigates the specified position.</summary>
    /// <param name="objPosition">The date position.</param>
    /// <param name="intDirection">The navigation direction.</param>
    private void Navigate(DateTime objPosition, int intDirection)
    {
      switch (this.CalanderViewType)
      {
        case MonthCalendar.CalanderViewTypes.Day:
          if ((DateTime.MaxValue - objPosition).Days >= 31)
          {
            objPosition = objPosition.AddMonths(1 * intDirection);
            if (objPosition.Day > 1)
            {
              objPosition = objPosition.AddDays((double) (1 - objPosition.Day));
              break;
            }
            break;
          }
          break;
        case MonthCalendar.CalanderViewTypes.Month:
          objPosition = objPosition.AddYears(1 * intDirection);
          break;
        case MonthCalendar.CalanderViewTypes.Year:
          objPosition = objPosition.AddYears(10 * intDirection);
          break;
        case MonthCalendar.CalanderViewTypes.YearRange:
          objPosition = objPosition.AddYears(100 * intDirection);
          break;
      }
      this.Position = objPosition;
      this.UpdateSelectionRange(objPosition.Year, objPosition.Month, objPosition.Day, false, false);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DateChangedHandler != null)
        criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>Gets or sets the first day of the week as displayed in the month calendar.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
    [SRDescription("MonthCalendarFirstDayOfWeekDescr")]
    [DefaultValue(Day.Default)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    public Day FirstDayOfWeek
    {
      get => this.GetValue<Day>(MonthCalendar.FirstDayOfWeekProperty, Day.Default);
      set
      {
        if (!this.SetValue<Day>(MonthCalendar.FirstDayOfWeekProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the maximum number of days that can be selected in a month calendar control.
    /// </summary>
    /// <value>The max selection count.</value>
    [DefaultValue(7)]
    [Category("Behavior")]
    public int MaxSelectionCount
    {
      get => this.GetValue<int>(MonthCalendar.MaxSelectionCountProperty, 7);
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException(nameof (MaxSelectionCount), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (MaxSelectionCount), (object) value.ToString("D", (IFormatProvider) CultureInfo.CurrentCulture), (object) 1.ToString((IFormatProvider) Application.CurrentUICulture)));
        if (this.MaxSelectionCount == value)
          return;
        this.SetValue<int>(MonthCalendar.MaxSelectionCountProperty, value);
      }
    }

    /// <summary>Gets or sets the max date.</summary>
    /// <value>The max date.</value>
    [SRDescription("MonthCalendarMaxDateDescr")]
    [SRCategory("CatBehavior")]
    public DateTime MaxDate
    {
      get => CalendarUtils.GetEffectiveMaxDate(this.GetValue<DateTime>(MonthCalendar.MaxDateProperty, CalendarUtils.MaxDateTime));
      set
      {
        if (!(value != this.MaxDate))
          return;
        DateTime effectiveMinDate = CalendarUtils.GetEffectiveMinDate(this.MinDate);
        DateTime effectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(this.MaxDate);
        if (value < effectiveMinDate)
          throw new ArgumentOutOfRangeException(nameof (MaxDate), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (MaxDate), (object) MonthCalendar.FormatDate(value), (object) "MinDate"));
        if (value != CalendarUtils.MaxDateTime)
          this.SetValue<DateTime>(MonthCalendar.MaxDateProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.MaxDateProperty);
        this.SetMinMaxRange(effectiveMinDate, effectiveMaxDate);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Resets the max date.</summary>
    private void ResetMaxDate() => this.MaxDate = CalendarUtils.MaxDateTime;

    /// <summary>Determines whether to serialize MaxDate property.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMaxDate() => this.MaxDate != CalendarUtils.MaxDateTime;

    /// <summary>Gets or sets the min date.</summary>
    /// <value>The min date.</value>
    [SRDescription("MonthCalendarMinDateDescr")]
    [SRCategory("CatBehavior")]
    public DateTime MinDate
    {
      get => CalendarUtils.GetEffectiveMinDate(this.GetValue<DateTime>(MonthCalendar.MinDateProperty, CalendarUtils.MinDateTime));
      set
      {
        if (!(value != this.MinDate))
          return;
        DateTime effectiveMinDate = CalendarUtils.GetEffectiveMinDate(this.MinDate);
        DateTime effectiveMaxDate = CalendarUtils.GetEffectiveMaxDate(this.MaxDate);
        if (value > effectiveMaxDate)
          throw new ArgumentOutOfRangeException(nameof (MinDate), SR.GetString("InvalidHighBoundArgument", (object) nameof (MinDate), (object) MonthCalendar.FormatDate(value), (object) "MaxDate"));
        if (value < CalendarUtils.MinimumDateTime)
          throw new ArgumentOutOfRangeException(nameof (MinDate), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (MinDate), (object) MonthCalendar.FormatDate(value), (object) MonthCalendar.FormatDate(CalendarUtils.MinimumDateTime)));
        if (value != CalendarUtils.MinDateTime)
          this.SetValue<DateTime>(MonthCalendar.MinDateProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.MinDateProperty);
        this.SetMinMaxRange(effectiveMinDate, effectiveMaxDate);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Resets the min date.</summary>
    private void ResetMinDate() => this.MinDate = CalendarUtils.MinDateTime;

    /// <summary>Determines whether to serialize MinDate property.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMinDate() => this.MinDate != CalendarUtils.MinDateTime;

    /// <summary>
    /// Gets or sets the end date of the selected range of dates.
    /// </summary>
    /// <value>The selection end.</value>
    [Browsable(false)]
    public DateTime SelectionEnd
    {
      get => this.GetValue<DateTime>(MonthCalendar.SelectionEndProperty, DateTime.Now.Date);
      set
      {
        if (!(this.SelectionEnd != value))
          return;
        if (value < this.MinDate)
          throw new ArgumentOutOfRangeException(nameof (SelectionEnd), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SelectionEnd), (object) MonthCalendar.FormatDate(value), (object) "MinDate"));
        if (value > this.MaxDate)
          throw new ArgumentOutOfRangeException(nameof (SelectionEnd), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (SelectionEnd), (object) MonthCalendar.FormatDate(value), (object) "MaxDate"));
        if (this.SelectionStart > value)
          this.SelectionStartInternal = value;
        if ((value - this.SelectionStart).Days >= this.MaxSelectionCount)
          this.SelectionStartInternal = value.AddDays((double) (1 - this.MaxSelectionCount));
        this.SetRange(this.SelectionStart, value);
      }
    }

    /// <summary>
    /// Determines whether to serialize SelectionEnd property.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeSelectionEnd() => this.SelectionEnd != DateTime.Now.Date;

    /// <summary>Sets the SelectionEnd serialized property.</summary>
    /// <value>The selection End setter.</value>
    private DateTime SelectionEndInternal
    {
      set
      {
        if (value != DateTime.Now.Date)
          this.SetValue<DateTime>(MonthCalendar.SelectionEndProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.SelectionEndProperty);
      }
    }

    /// <summary>
    /// Gets or sets the start date of the selected range of dates.
    /// </summary>
    /// <value>The selection start.</value>
    [Browsable(false)]
    public DateTime SelectionStart
    {
      get => this.GetValue<DateTime>(MonthCalendar.SelectionStartProperty, DateTime.Now.Date);
      set
      {
        if (!(this.SelectionStart != value))
          return;
        if (value < this.MinDate)
          throw new ArgumentOutOfRangeException(nameof (SelectionStart), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SelectionStart), (object) MonthCalendar.FormatDate(value), (object) "MinDate"));
        if (value > this.MaxDate)
          throw new ArgumentOutOfRangeException(nameof (SelectionStart), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (SelectionStart), (object) MonthCalendar.FormatDate(value), (object) "MaxDate"));
        if (this.SelectionEnd < value)
          this.SelectionEndInternal = value;
        if ((this.SelectionEnd - value).Days >= this.MaxSelectionCount)
          this.SelectionEndInternal = value.AddDays((double) (this.MaxSelectionCount - 1));
        this.SetRange(value, this.SelectionEnd);
      }
    }

    /// <summary>
    /// Determines whether to serialize SelectionStart property.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeSelectionStart() => this.SelectionStart != DateTime.Now.Date;

    /// <summary>Sets the SelectionStart serialized property.</summary>
    /// <value>The selection start setter.</value>
    private DateTime SelectionStartInternal
    {
      set
      {
        if (value != DateTime.Now.Date)
          this.SetValue<DateTime>(MonthCalendar.SelectionStartProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.SelectionStartProperty);
      }
    }

    /// <summary>
    /// Gets or sets the selected range of dates for a month calendar control.
    /// </summary>
    /// <value>The selection range.</value>
    [Bindable(true)]
    [Category("Behavior")]
    public SelectionRange SelectionRange
    {
      get => new SelectionRange(this.SelectionStart, this.SelectionEnd);
      set => this.SetSelectionRange(value.Start, value.End);
    }

    /// <summary>Resets the selection range.</summary>
    private void ResetSelectionRange()
    {
      DateTime now = DateTime.Now;
      DateTime date1 = now.Date;
      now = DateTime.Now;
      DateTime date2 = now.Date;
      this.SetSelectionRange(date1, date2);
    }

    /// <summary>
    /// Determines whether to serialize SelectionRange property.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeSelectionRange() => this.SelectionRange.Start != DateTime.Now.Date && this.SelectionRange.End != DateTime.Now.Date;

    /// <summary>Gets or sets the current date.</summary>
    /// <value></value>
    [SRDescription("MonthCalendarSelectionValueDescr")]
    [SRCategory("CatBehavior")]
    [Bindable(true)]
    public DateTime Value
    {
      get => this.GetValue<DateTime>(MonthCalendar.ValueProperty, DateTime.Now.Date);
      set
      {
        if (!(this.Value != value))
          return;
        if (value != DateTime.Now.Date)
          this.SetValue<DateTime>(MonthCalendar.ValueProperty, value);
        else
          this.RemoveValue<DateTime>(MonthCalendar.ValueProperty);
        if (value > this.SelectionEnd || value < this.SelectionStart)
        {
          DateTime dateTime = value;
          this.SetRange(dateTime, dateTime);
        }
        else
          this.OnValueChanged(new EventArgs());
      }
    }

    /// <summary>Resets the value.</summary>
    private void ResetValue() => this.Value = DateTime.Now.Date;

    /// <summary>Gets or sets the type of the calander view.</summary>
    /// <value>The type of the calander view.</value>
    protected internal MonthCalendar.CalanderViewTypes CalanderViewType
    {
      get => this.GetValue<MonthCalendar.CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty, MonthCalendar.CalanderViewTypes.Day);
      set
      {
        if (this.CalanderViewType == value)
          return;
        if (value != MonthCalendar.CalanderViewTypes.Day)
          this.SetValue<MonthCalendar.CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty, value);
        else
          this.RemoveValue<MonthCalendar.CalanderViewTypes>(MonthCalendar.CalanderViewTypeProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Sets the range.</summary>
    /// <param name="objMinDate">The min date.</param>
    /// <param name="objMaxDate">The max date.</param>
    private void SetMinMaxRange(DateTime objMinDate, DateTime objMaxDate)
    {
      if (this.SelectionStart < objMinDate)
        this.SelectionStart = objMinDate;
      if (this.SelectionStart > objMaxDate)
        this.SelectionStart = objMaxDate;
      if (this.SelectionEnd < objMinDate)
        this.SelectionEnd = objMinDate;
      if (this.SelectionEnd > objMaxDate)
        this.SelectionEnd = objMaxDate;
      this.SetRange(this.SelectionStart, this.SelectionEnd);
    }

    /// <summary>Sets the selection range.</summary>
    /// <param name="objLowerDate">The lower date.</param>
    /// <param name="objUpperDate">The upper date.</param>
    private void SetRange(DateTime objLowerDate, DateTime objUpperDate)
    {
      bool flag = false;
      if (this.SelectionStart != objLowerDate || this.SelectionEnd != objUpperDate)
      {
        flag = true;
        this.SelectionStartInternal = objLowerDate;
        this.SelectionEndInternal = objUpperDate;
      }
      if (!flag)
        return;
      this.Position = objLowerDate;
      this.OnValueChanged(new EventArgs());
      this.OnDateChanged(EventArgs.Empty);
      this.Update();
    }

    /// <summary>
    /// Raises the <see cref="E:DateChanged" /> event.
    /// </summary>
    /// <param name="objEvents">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnDateChanged(EventArgs objEvents)
    {
      if (this.DateChangedHandler == null)
        return;
      this.DateChangedHandler((object) this, objEvents);
    }

    /// <summary>Sets the selection range.</summary>
    /// <param name="objMinDate">The min date.</param>
    /// <param name="objMaxDate">The max date.</param>
    public void SetSelectionRange(DateTime objMinDate, DateTime objMaxDate)
    {
      if (objMinDate.Ticks < this.MinDate.Ticks)
        throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidLowBoundArgumentEx", (object) "SelectionStart", (object) MonthCalendar.FormatDate(objMinDate), (object) "MinDate"));
      if (objMinDate.Ticks > this.MaxDate.Ticks)
        throw new ArgumentOutOfRangeException("min date", SR.GetString("InvalidHighBoundArgumentEx", (object) "SelectionEnd", (object) MonthCalendar.FormatDate(objMinDate), (object) "MaxDate"));
      if (objMaxDate.Ticks < this.MinDate.Ticks)
        throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidLowBoundArgumentEx", (object) "SelectionStart", (object) MonthCalendar.FormatDate(objMaxDate), (object) "MinDate"));
      if (objMaxDate.Ticks > this.MaxDate.Ticks)
        throw new ArgumentOutOfRangeException("max date", SR.GetString("InvalidHighBoundArgumentEx", (object) "SelectionEnd", (object) MonthCalendar.FormatDate(objMaxDate), (object) "MaxDate"));
      if (objMinDate > objMaxDate)
        objMaxDate = objMinDate;
      if ((objMaxDate - objMinDate).Days >= this.MaxSelectionCount)
      {
        if (objMinDate.Ticks == this.SelectionStart.Ticks)
          objMinDate = objMaxDate.AddDays((double) (1 - this.MaxSelectionCount));
        else
          objMaxDate = objMinDate.AddDays((double) (this.MaxSelectionCount - 1));
      }
      this.SetRange(objMinDate, objMaxDate);
    }

    /// <summary>
    /// Adds a day that is displayed in bold on an annual basis in the month calendar.
    /// </summary>
    /// <param name="objDate">The date to be displayed in bold.</param>
    public void AddAnnuallyBoldedDate(DateTime objDate)
    {
      List<DateTime> dateTimeList = new List<DateTime>();
      dateTimeList.AddRange((IEnumerable<DateTime>) this.AnnuallyBoldedDates);
      dateTimeList.Add(objDate);
      this.AnnuallyBoldedDates = dateTimeList.ToArray();
    }

    /// <summary>
    /// Adds a day to be displayed in bold in the month calendar.
    /// </summary>
    /// <param name="objDate">The date to be displayed in bold.</param>
    public void AddBoldedDate(DateTime objDate)
    {
      List<DateTime> dateTimeList = new List<DateTime>();
      dateTimeList.AddRange((IEnumerable<DateTime>) this.BoldedDates);
      dateTimeList.Add(objDate);
      this.BoldedDates = dateTimeList.ToArray();
    }

    /// <summary>
    /// Adds a day that is displayed in bold on a monthly basis in the month calendar.
    /// </summary>
    /// <param name="objDate">The date to be displayed in bold.</param>
    public void AddMonthlyBoldedDate(DateTime objDate)
    {
      List<DateTime> dateTimeList = new List<DateTime>();
      dateTimeList.AddRange((IEnumerable<DateTime>) this.MonthlyBoldedDates);
      dateTimeList.Add(objDate);
      this.MonthlyBoldedDates = dateTimeList.ToArray();
    }

    /// <summary>Shoulds the serialize annually bolded dates.</summary>
    /// <returns></returns>
    private bool ShouldSerializeAnnuallyBoldedDates() => this.AnnuallyBoldedDates.Length != 0;

    /// <summary>Shoulds the serialize bolded dates.</summary>
    /// <returns></returns>
    private bool ShouldSerializeBoldedDates() => this.BoldedDates.Length != 0;

    /// <summary>Shoulds the serialize monthly bolded dates.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMonthlyBoldedDates() => this.MonthlyBoldedDates.Length != 0;

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(176, 153);

    /// <summary>Gets or sets the today date.</summary>
    /// <value>The today date.</value>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// TodayDate
    /// </exception>
    [SRDescription("MonthCalendarTodayDateDescr")]
    [SRCategory("CatBehavior")]
    public DateTime TodayDate
    {
      get => this.TodayDateSet ? this.GetValue<DateTime>(MonthCalendar.TodatDateProperty) : DateTime.Now.Date;
      set
      {
        if (this.TodayDateSet && DateTime.Compare(value, this.GetValue<DateTime>(MonthCalendar.TodatDateProperty)) == 0)
          return;
        if (DateTime.Compare(value, this.MaxDate) > 0)
          throw new ArgumentOutOfRangeException(nameof (TodayDate), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (TodayDate), (object) MonthCalendar.FormatDate(value), (object) MonthCalendar.FormatDate(this.MaxDate)));
        if (DateTime.Compare(value, this.MinDate) < 0)
          throw new ArgumentOutOfRangeException(nameof (TodayDate), SR.GetString("InvalidLowBoundArgument", (object) nameof (TodayDate), (object) MonthCalendar.FormatDate(value), (object) MonthCalendar.FormatDate(this.MinDate)));
        this.SetValue<DateTime>(MonthCalendar.TodatDateProperty, value.Date);
        this.TodayDateSet = true;
        this.Update();
      }
    }

    /// <summary>Gets a value indicating whether [today date set].</summary>
    /// <value>
    ///   <c>true</c> if [today date set]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("MonthCalendarTodayDateSetDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatBehavior")]
    public bool TodayDateSet
    {
      get => this.GetValue<bool>(MonthCalendar.TodayDateSetProperty, false);
      private set => this.SetValue<bool>(MonthCalendar.TodayDateSetProperty, value);
    }

    /// <summary>Formats the date.</summary>
    /// <param name="objDateTime">The obj date time.</param>
    /// <returns></returns>
    private static string FormatDate(DateTime objDateTime) => objDateTime.ToString("d", (IFormatProvider) Application.CurrentUICulture);

    /// <summary>
    /// 
    /// </summary>
    protected internal enum CalanderViewTypes
    {
      /// <summary>
      /// 
      /// </summary>
      Day,
      /// <summary>
      /// 
      /// </summary>
      Month,
      /// <summary>
      /// 
      /// </summary>
      Year,
      /// <summary>
      /// 
      /// </summary>
      YearRange,
    }
  }
}
