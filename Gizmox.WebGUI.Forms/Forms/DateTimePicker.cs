// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DateTimePicker
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a Gizmox.WebGUI.Forms control that allows the user to select a date and a time and to display the date and time with a specified format.
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (DateTimePicker), "DateTimePicker_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("DP")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DateTimePickerSkin))]
  [Serializable]
  public class DateTimePicker : Control
  {
    /// <summary>
    /// Provides a property reference to DateTimePickerFormat property.
    /// </summary>
    private static SerializableProperty DateTimePickerFormatProperty = SerializableProperty.Register("DateTimePickerFormat", typeof (DateTimePickerFormat), typeof (DateTimePicker), new SerializablePropertyMetadata((object) DateTimePickerFormat.Long));
    /// <summary>
    /// Provides a property reference to CustomFormat property.
    /// </summary>
    private static SerializableProperty CustomFormatProperty = SerializableProperty.Register(nameof (CustomFormat), typeof (string), typeof (DateTimePicker), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ShowUpDown property.</summary>
    private static SerializableProperty ShowUpDownProperty = SerializableProperty.Register(nameof (ShowUpDown), typeof (bool), typeof (DateTimePicker), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ShowBothEditButtons property.
    /// </summary>
    private static SerializableProperty ShowBothEditButtonsProperty = SerializableProperty.Register(nameof (ShowBothEditButtons), typeof (bool), typeof (DateTimePicker), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to CalendarFirstDayOfWeek property.
    /// </summary>
    private static SerializableProperty CalendarFirstDayOfWeekProperty = SerializableProperty.Register(nameof (CalendarFirstDayOfWeek), typeof (Day), typeof (DateTimePicker), new SerializablePropertyMetadata((object) Day.Default));
    /// <summary>
    /// Provides a property reference to EmptyDateYear property.
    /// </summary>
    private static SerializableProperty EmptyDateYearProperty = SerializableProperty.Register(nameof (EmptyDateYear), typeof (int), typeof (DateTimePicker), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to ShowCheckBox property.
    /// </summary>
    private static SerializableProperty ShowCheckBoxProperty = SerializableProperty.Register(nameof (ShowCheckBox), typeof (bool), typeof (DateTimePicker), new SerializablePropertyMetadata((object) false));
    /// <summary>The CheckedChangedQueued event registration.</summary>
    private static readonly SerializableEvent CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof (EventHandler), typeof (DateTimePicker));
    /// <summary>The CheckedChanged event registration.</summary>
    private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof (EventHandler), typeof (DateTimePicker));
    /// <summary>The CloseUp event registration.</summary>
    private static readonly SerializableEvent CloseUpEvent = SerializableEvent.Register("CloseUp", typeof (EventHandler), typeof (DateTimePicker));
    /// <summary>
    /// Specifies the maximum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control. This field is read-only.
    /// </summary>
    public static DateTime MaxDateTime;
    /// <summary>
    /// Gets the minimum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
    /// </summary>
    public static DateTime MinDateTime;
    /// <summary>Default time format</summary>
    private static string mstrTimeFormat = "h:mm:ss tt";
    /// <summary>Default short date format</summary>
    private static string mstrShortFormat = "M/d/yyyy";
    /// <summary>Default long date format</summary>
    private static string mstrLongFormat = "dddd , MMMM dd, yyyy";
    /// <summary>
    /// 
    /// </summary>
    private static char[] marrTokens = new char[8]
    {
      'd',
      'm',
      'M',
      'y',
      's',
      't',
      'h',
      'H'
    };
    /// <summary>The ValueChanged event registration.</summary>
    private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof (EventHandler), typeof (DateTimePicker));
    /// <summary>The ValueChangedQueued event registration.</summary>
    private static readonly SerializableEvent ValueChangedQueuedEvent = SerializableEvent.Register("ValueChangedQueued", typeof (EventHandler), typeof (DateTimePicker));
    /// <summary>The current datetime picker value</summary>
    [NonSerialized]
    private DateTime mobjValue;
    /// <summary>The current datetime picker max value</summary>
    [NonSerialized]
    private DateTime mobjMaxValue;
    /// <summary>The current datetime picker min value</summary>
    [NonSerialized]
    private DateTime mobjMinValue;
    /// <summary>A flag indicating whether user has set value.</summary>
    [NonSerialized]
    private bool mblnUserHasSetValue;
    /// <summary>The amount of fields the form needs to serialize</summary>
    private const int mintSerializableFieldCount = 4;

    /// <summary>Occurs when the popup date windows is closed.</summary>
    public event EventHandler CloseUp
    {
      add => this.AddHandler(DateTimePicker.CloseUpEvent, (Delegate) value);
      remove => this.RemoveHandler(DateTimePicker.CloseUpEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property changes.
    /// </summary>
    [SRDescription("valueChangedEventDescr")]
    [SRCategory("CatAction")]
    public event EventHandler ValueChanged
    {
      add => this.AddCriticalHandler(DateTimePicker.ValueChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(DateTimePicker.ValueChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("valueChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientValueChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("checkedChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientCheckedChanged
    {
      add => this.AddClientHandler("CheckedChange", value);
      remove => this.RemoveClientHandler("CheckedChange", value);
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("dropDownEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientDropDown
    {
      add => this.AddClientHandler("Browse", value);
      remove => this.RemoveClientHandler("Browse", value);
    }

    /// <summary>Gets the hanlder for the ValueChanged event.</summary>
    private EventHandler ValueChangedHandler => (EventHandler) this.GetHandler(DateTimePicker.ValueChangedEvent);

    /// <summary>
    /// Occurs when the value of the Checked property changes.
    /// </summary>
    public event EventHandler CheckedChanged
    {
      add => this.AddCriticalHandler(DateTimePicker.CheckedChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(DateTimePicker.CheckedChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs when the value of the Checked property changes (Queued).
    /// </summary>
    public event EventHandler CheckedChangedQueued
    {
      add => this.AddHandler(DateTimePicker.CheckedChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(DateTimePicker.CheckedChangedQueuedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs when the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.ValueChanged"></see> property changes (queued).
    /// </summary>
    public event EventHandler ValueChangedQueued
    {
      add => this.AddHandler(DateTimePicker.ValueChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(DateTimePicker.ValueChangedQueuedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ValueChangedQueued event.</summary>
    private EventHandler ValueChangedQueuedHandler => (EventHandler) this.GetHandler(DateTimePicker.ValueChangedQueuedEvent);

    /// <summary>Static constructor.</summary>
    static DateTimePicker()
    {
      DateTimePicker.MinDateTime = new DateTime(1753, 1, 1);
      DateTimePicker.MaxDateTime = new DateTime(9998, 12, 31);
      Config instance = Config.GetInstance();
      if (instance == null)
        return;
      DateTimePicker.mstrTimeFormat = instance.DefaultTimeFormat;
      DateTimePicker.mstrShortFormat = instance.DefaultShortDateFormat;
      DateTimePicker.mstrLongFormat = instance.DefaultLongDateFormat;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> class.
    /// </summary>
    public DateTimePicker()
    {
      this.mobjValue = DateTime.Today;
      this.mobjMaxValue = DateTimePicker.MaxDateTime;
      this.mobjMinValue = DateTimePicker.MinDateTime;
      this.SetStyle(ControlStyles.FixedHeight, true);
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint, false);
      this.SetState(Component.ComponentState.Checked, true);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 4;

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjValue = objReader.ReadDateTime();
      this.mobjMaxValue = objReader.ReadDateTime();
      this.mobjMinValue = objReader.ReadDateTime();
      this.mblnUserHasSetValue = objReader.ReadBoolean();
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteDateTime(this.mobjValue);
      objWriter.WriteDateTime(this.mobjMaxValue);
      objWriter.WriteDateTime(this.mobjMinValue);
      objWriter.WriteBoolean(this.mblnUserHasSetValue);
    }

    /// <summary>Gets the string of a date time object.</summary>
    /// <param name="value">Value.</param>
    /// <returns></returns>
    private static string FormatDateTime(DateTime value) => value.ToString("G");

    /// <summary>
    /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
    /// </summary>
    /// <returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see>. The string includes the type and the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property of the control.</returns>
    public override string ToString() => base.ToString() + ", Value: " + DateTimePicker.FormatDateTime(this.Value);

    /// <summary>Sets the value internal.</summary>
    /// <value>The value internal.</value>
    internal bool SetValueInternal(DateTime objValue)
    {
      if (objValue < this.MinDate || objValue > this.MaxDate)
        throw new ArgumentOutOfRangeException();
      if (!(this.mobjValue != objValue))
        return false;
      this.mobjValue = objValue;
      this.mblnUserHasSetValue = true;
      this.OnValueChanged(EventArgs.Empty);
      this.OnValueChangedQueued(EventArgs.Empty);
      this.FireObservableItemPropertyChanged("Value");
      if (this.Parent != null && this.ShowCheckBox)
        this.Checked = true;
      return true;
    }

    /// <summary>Shoulds the serialize value.</summary>
    /// <returns></returns>
    private bool ShouldSerializeValue() => this.mblnUserHasSetValue;

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new DateTimePickerRenderer(this);

    /// <summary>Gets the width of the widest day.</summary>
    /// <param name="strFormat">The format.</param>
    /// <returns></returns>
    private int GetWidestDayWidth(string strFormat)
    {
      int widestDayWidth = 0;
      Font font = this.Font;
      foreach (DayOfWeek enmDayOfWeek in Enum.GetValues(typeof (DayOfWeek)))
      {
        int num = this.MeasureTextWidth(this.NormalizeDay(enmDayOfWeek, strFormat), font);
        if (num > widestDayWidth)
          widestDayWidth = num;
      }
      return widestDayWidth;
    }

    /// <summary>Gets the width of the widest month.</summary>
    /// <param name="strFormat">The format.</param>
    /// <returns></returns>
    private int GetWidestMonthWidth(string strFormat)
    {
      int widestMonthWidth = 0;
      Font font = this.Font;
      for (int intMonth = 1; intMonth <= 12; ++intMonth)
      {
        int num = this.MeasureTextWidth(this.NormalizeMonth(intMonth, strFormat), font);
        if (num > widestMonthWidth)
          widestMonthWidth = num;
      }
      return widestMonthWidth;
    }

    /// <summary>Normalizes the month.</summary>
    /// <param name="intMonth">The int month.</param>
    /// <param name="strFormat">The STR format.</param>
    /// <returns></returns>
    private string NormalizeMonth(int intMonth, string strFormat) => intMonth > 0 && intMonth <= 12 ? WGLabels.GetLocalizedMonthString(intMonth, strFormat == "MMM", Global.Context, true) : "???";

    /// <summary>Gets the normalized day value</summary>
    /// <param name="enmDayOfWeek"></param>
    /// <param name="strFormat"></param>
    /// <returns></returns>
    private string NormalizeDay(DayOfWeek enmDayOfWeek, string strFormat)
    {
      if (strFormat == "ddd")
      {
        switch (enmDayOfWeek)
        {
          case DayOfWeek.Sunday:
            return WGLabels.GetString("SundayShort", Global.Context, true);
          case DayOfWeek.Monday:
            return WGLabels.GetString("MondayShort", Global.Context, true);
          case DayOfWeek.Tuesday:
            return WGLabels.GetString("TuesdayShort", Global.Context, true);
          case DayOfWeek.Wednesday:
            return WGLabels.GetString("WednesdayShort", Global.Context, true);
          case DayOfWeek.Thursday:
            return WGLabels.GetString("ThursdayShort", Global.Context, true);
          case DayOfWeek.Friday:
            return WGLabels.GetString("FridayShort", Global.Context, true);
          case DayOfWeek.Saturday:
            return WGLabels.GetString("SaturdayShort", Global.Context, true);
        }
      }
      else
      {
        switch (enmDayOfWeek)
        {
          case DayOfWeek.Sunday:
            return WGLabels.GetString("Sunday", Global.Context, true);
          case DayOfWeek.Monday:
            return WGLabels.GetString("Monday", Global.Context, true);
          case DayOfWeek.Tuesday:
            return WGLabels.GetString("Tuesday", Global.Context, true);
          case DayOfWeek.Wednesday:
            return WGLabels.GetString("Wednesday", Global.Context, true);
          case DayOfWeek.Thursday:
            return WGLabels.GetString("Thursday", Global.Context, true);
          case DayOfWeek.Friday:
            return WGLabels.GetString("Friday", Global.Context, true);
          case DayOfWeek.Saturday:
            return WGLabels.GetString("Saturday", Global.Context, true);
        }
      }
      return "???";
    }

    /// <summary>
    /// Utility mehtod for checking it a char exists in a char array
    /// </summary>
    /// <param name="arrChars"></param>
    /// <param name="chrValue"></param>
    /// <returns></returns>
    private bool IsCharContained(char[] arrChars, char chrValue)
    {
      foreach (int arrChar in arrChars)
      {
        if (arrChar == (int) chrValue)
          return true;
      }
      return false;
    }

    /// <summary>Gets a AP/PM valued hour</summary>
    /// <param name="intHour">The int hour.</param>
    /// <param name="blnShort">if set to <c>true</c> [BLN short].</param>
    /// <returns></returns>
    private string NormalizeAMPM(int intHour, bool blnShort) => intHour > 11 ? WGLabels.GetLocalizedAMPMDesignatorString(false, blnShort, this.Context) : WGLabels.GetLocalizedAMPMDesignatorString(true, blnShort, this.Context);

    /// <summary>Gets a AP/PM valued hour</summary>
    /// <param name="intHour"></param>
    /// <returns></returns>
    private int NormalizeAMPMIndex(int intHour) => intHour > 11 ? 2 : 1;

    /// <summary>Gets a 0-12 valued hour</summary>
    /// <param name="intValue"></param>
    /// <returns></returns>
    private int NormalizeHour(int intValue)
    {
      if (intValue >= 13)
        return intValue - 12;
      return intValue == 0 ? 12 : intValue;
    }

    /// <summary>Normalizes the year.</summary>
    /// <param name="intValue">The int value.</param>
    /// <param name="intPlaces">The int places.</param>
    /// <returns></returns>
    private string NormalizeYear(int intValue, int intPlaces)
    {
      string str = intValue.ToString();
      switch (intPlaces)
      {
        case 1:
          str = Convert.ToInt32(str.Substring(2)).ToString();
          break;
        case 2:
          str = str.Substring(2);
          break;
      }
      return str;
    }

    /// <summary>Utility method for padding numbers</summary>
    /// <param name="intValue">The int value.</param>
    /// <param name="intPlaces">The int places.</param>
    /// <param name="blnCrop">if set to <c>true</c> [BLN crop].</param>
    /// <returns></returns>
    private string NormalizeNumber(int intValue, int intPlaces, bool blnCrop) => this.NormalizeNumber(intValue.ToString(), intPlaces, blnCrop);

    /// <summary>Utility method for padding numbers</summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="intPlaces">The int places.</param>
    /// <param name="blnCrop">if set to <c>true</c> [BLN crop].</param>
    /// <returns></returns>
    private string NormalizeNumber(string strValue, int intPlaces, bool blnCrop)
    {
      if (strValue.Length < intPlaces)
      {
        string str = "";
        for (int length = strValue.Length; length < intPlaces; ++length)
          str += "0";
        return str + strValue;
      }
      if (!(strValue.Length > intPlaces & blnCrop))
        return strValue;
      string str1 = strValue;
      return str1.Substring(str1.Length - intPlaces, intPlaces);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("CB", this.ShowCheckBox ? "1" : "0");
      if (this.ShowCheckBox)
        objWriter.WriteAttributeString("C", this.Checked ? "1" : "0");
      this.RenderShowUpDownAttribute(objWriter, false);
      IAttributeWriter attributeWriter1 = objWriter;
      long ticks = this.Value.Ticks;
      string strValue1 = ticks.ToString();
      attributeWriter1.WriteAttributeString("DT", strValue1);
      DateTime dateTime;
      if (this.MinDate != DateTimePicker.MinDateTime)
      {
        IAttributeWriter attributeWriter2 = objWriter;
        dateTime = this.MinDate;
        ticks = dateTime.Ticks;
        string strValue2 = ticks.ToString();
        attributeWriter2.WriteAttributeString("MND", strValue2);
      }
      if (this.MaxDate != DateTimePicker.MaxDateTime)
      {
        IAttributeWriter attributeWriter3 = objWriter;
        dateTime = this.MaxDate;
        ticks = dateTime.Ticks;
        string strValue3 = ticks.ToString();
        attributeWriter3.WriteAttributeString("MXD", strValue3);
      }
      if (this.CalendarFirstDayOfWeek != Day.Default)
        objWriter.WriteAttributeString("FDW", this.CalendarFirstDayOfWeek.ToString());
      if (this.EmptyDateYear == 0)
        return;
      objWriter.WriteAttributeString("EDY", this.EmptyDateYear.ToString());
    }

    /// <summary>Renders the show up down attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowUpDownAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.ShowBothEditButtons)
        objWriter.WriteAttributeString("SUD", "2");
      else if (this.ShowUpDown)
      {
        objWriter.WriteAttributeString("SUD", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SUD", "0");
      }
    }

    /// <summary>Render the datetimepicker formating</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      string currentFormat = this.CurrentFormat;
      while (!string.IsNullOrEmpty(currentFormat))
      {
        bool blnIsToken = false;
        string strContent = string.Empty;
        this.GetNextContentPart(ref currentFormat, out strContent, out blnIsToken);
        if (!string.IsNullOrEmpty(strContent))
        {
          if (blnIsToken)
            this.RenderToken(objWriter, strContent);
          else
            this.RenderLiteral(objWriter, strContent);
        }
      }
    }

    /// <summary>Gets the next content part.</summary>
    /// <param name="strFormat">The format.</param>
    /// <param name="strContent">Content of the token / literal.</param>
    /// <param name="blnIsToken">if set to <c>true</c> [BLN is token].</param>
    protected void GetNextContentPart(
      ref string strFormat,
      out string strContent,
      out bool blnIsToken)
    {
      blnIsToken = false;
      strContent = string.Empty;
      if (string.IsNullOrEmpty(strFormat))
        return;
      if (this.StartsWithToken(strFormat, ref strContent))
      {
        blnIsToken = true;
        ref string local = ref strFormat;
        local = local.Remove(0, strContent.Length);
      }
      else if (strFormat.StartsWith("'", StringComparison.InvariantCulture))
      {
        int num = strFormat.IndexOf('\'', 1);
        if (num != -1)
        {
          strContent = strFormat.Substring(1, num - 1);
          ref string local = ref strFormat;
          local = local.Substring(num + 1);
        }
        else
        {
          strContent = strFormat.Substring(1);
          strFormat = string.Empty;
        }
      }
      else
      {
        int num = strFormat.IndexOfAny(DateTimePicker.marrTokens);
        if (num != -1)
        {
          strContent = strFormat.Substring(0, num);
          ref string local = ref strFormat;
          local = local.Substring(num);
        }
        else
        {
          strContent = strFormat.Replace("'", "");
          strFormat = string.Empty;
        }
      }
    }

    /// <summary>Checks whether recieved format starts with a token.</summary>
    /// <param name="strFormat">The format.</param>
    /// <param name="strContent">Content of the token / literal.</param>
    /// <returns></returns>
    private bool StartsWithToken(string strFormat, ref string strContent)
    {
      bool flag = true;
      if (strFormat.StartsWith("dddd", StringComparison.InvariantCulture))
        strContent = "dddd";
      else if (strFormat.StartsWith("ddd", StringComparison.InvariantCulture))
        strContent = "ddd";
      else if (strFormat.StartsWith("dd", StringComparison.InvariantCulture))
        strContent = "dd";
      else if (strFormat.StartsWith("d", StringComparison.InvariantCulture))
        strContent = "d";
      else if (strFormat.StartsWith("yyyy", StringComparison.InvariantCulture))
        strContent = "yyyy";
      else if (strFormat.StartsWith("yy", StringComparison.InvariantCulture))
        strContent = "yy";
      else if (strFormat.StartsWith("y", StringComparison.InvariantCulture))
        strContent = "y";
      else if (strFormat.StartsWith("hh", StringComparison.InvariantCulture))
        strContent = "hh";
      else if (strFormat.StartsWith("h", StringComparison.InvariantCulture))
        strContent = "h";
      else if (strFormat.StartsWith("HH", StringComparison.InvariantCulture))
        strContent = "HH";
      else if (strFormat.StartsWith("H", StringComparison.InvariantCulture))
        strContent = "H";
      else if (strFormat.StartsWith("MMMM", StringComparison.InvariantCulture))
        strContent = "MMMM";
      else if (strFormat.StartsWith("MMM", StringComparison.InvariantCulture))
        strContent = "MMM";
      else if (strFormat.StartsWith("MM", StringComparison.InvariantCulture))
        strContent = "MM";
      else if (strFormat.StartsWith("M", StringComparison.InvariantCulture))
        strContent = "M";
      else if (strFormat.StartsWith("mm", StringComparison.InvariantCulture))
        strContent = "mm";
      else if (strFormat.StartsWith("m", StringComparison.InvariantCulture))
        strContent = "m";
      else if (strFormat.StartsWith("ss", StringComparison.InvariantCulture))
        strContent = "ss";
      else if (strFormat.StartsWith("s", StringComparison.InvariantCulture))
        strContent = "s";
      else if (strFormat.StartsWith("tt", StringComparison.InvariantCulture))
        strContent = "tt";
      else if (strFormat.StartsWith("t", StringComparison.InvariantCulture))
        strContent = "t";
      else
        flag = false;
      return flag;
    }

    /// <summary>Renders a datetimepicker literal</summary>
    /// <param name="objWriter"></param>
    /// <param name="strLiteral"></param>
    private void RenderLiteral(IResponseWriter objWriter, string strLiteral)
    {
      if (string.IsNullOrEmpty(strLiteral))
        return;
      objWriter.WriteStartElement("LT");
      objWriter.WriteAttributeString("VLB", strLiteral);
      objWriter.WriteAttributeString("SZ", this.MeasureTextWidth(strLiteral, this.Font).ToString());
      objWriter.WriteEndElement();
    }

    /// <summary>Measures the width of the text.</summary>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <returns></returns>
    private int MeasureTextWidth(string strText, Font objFont)
    {
      int num = 0;
      if (!string.IsNullOrEmpty(strText))
      {
        StringFormat enmStringFormat = new StringFormat(StringFormat.GenericTypographic);
        enmStringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        num = CommonUtils.GetStringMeasurements(strText, this.Font, -1, Point.Empty, enmStringFormat).Width;
      }
      return num;
    }

    /// <summary>Renders a datetimepicker token</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="strLiteral">The STR literal.</param>
    private void RenderToken(IResponseWriter objWriter, string strLiteral)
    {
      objWriter.WriteStartElement("TK");
      objWriter.WriteAttributeString("FMT", strLiteral);
      string str = string.Empty;
      int num1 = 0;
      string strValue = string.Empty;
      bool flag = false;
      int num2 = -1;
      switch (strLiteral)
      {
        case "H":
          str = this.Value.Hour.ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          strValue = "t,tt";
          break;
        case "HH":
          str = this.NormalizeNumber(this.Value.Hour, 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "t,tt";
          break;
        case "M":
          str = this.Value.Month.ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          strValue = "d,dd,ddd,dddd,MM,MMM,MMMM";
          break;
        case "MM":
          str = this.NormalizeNumber(this.Value.Month, 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "d,dd,ddd,dddd,M,MMM,MMMM";
          break;
        case "MMM":
          num1 = this.GetWidestMonthWidth("MMM");
          DateTime dateTime1 = this.Value;
          str = this.NormalizeMonth(dateTime1.Month, "MMM");
          dateTime1 = this.Value;
          num2 = dateTime1.Month;
          strValue = "d,dd,ddd,dddd,M,MM,MMMM";
          break;
        case "MMMM":
          num1 = this.GetWidestMonthWidth("MMMM");
          DateTime dateTime2 = this.Value;
          str = this.NormalizeMonth(dateTime2.Month, "MMMM");
          dateTime2 = this.Value;
          num2 = dateTime2.Month;
          strValue = "d,dd,ddd,dddd,M,MM,MMM";
          break;
        case "d":
          str = this.Value.Day.ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          strValue = "dd,ddd,dddd";
          break;
        case "dd":
          str = this.NormalizeNumber(this.Value.Day, 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "d,ddd,dddd";
          break;
        case "ddd":
          num1 = this.GetWidestDayWidth("ddd");
          flag = true;
          DateTime dateTime3 = this.Value;
          str = this.NormalizeDay(dateTime3.DayOfWeek, "ddd");
          dateTime3 = this.Value;
          num2 = Convert.ToInt32((object) dateTime3.DayOfWeek) + 1;
          break;
        case "dddd":
          num1 = this.GetWidestDayWidth("dddd");
          flag = true;
          DateTime dateTime4 = this.Value;
          str = this.NormalizeDay(dateTime4.DayOfWeek, "dddd");
          dateTime4 = this.Value;
          num2 = Convert.ToInt32((object) dateTime4.DayOfWeek) + 1;
          break;
        case "h":
          str = this.NormalizeHour(this.Value.Hour).ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          strValue = "t,tt";
          break;
        case "hh":
          str = this.NormalizeNumber(this.NormalizeHour(this.Value.Hour), 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "t,tt";
          break;
        case "m":
          str = this.Value.Minute.ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          break;
        case "mm":
          str = this.NormalizeNumber(this.Value.Minute, 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          break;
        case "s":
          str = this.Value.Second.ToString();
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          break;
        case "ss":
          str = this.NormalizeNumber(this.Value.Second, 2, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          break;
        case "t":
          str = this.NormalizeAMPM(this.Value.Hour, true);
          num1 = this.MeasureTextWidth(str, this.Font);
          num2 = this.NormalizeAMPMIndex(this.Value.Hour);
          strValue = "H,HH";
          break;
        case "tt":
          str = this.NormalizeAMPM(this.Value.Hour, false);
          num1 = this.MeasureTextWidth(str, this.Font);
          num2 = this.NormalizeAMPMIndex(this.Value.Hour);
          strValue = "H,HH";
          break;
        case "y":
          str = this.NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 1);
          num1 = this.MeasureTextWidth(this.NormalizeNumber(str, 2, false), this.Font);
          strValue = "d,dd,ddd,dddd";
          break;
        case "yy":
          str = this.NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 2);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "d,dd,ddd,dddd";
          break;
        case "yyyy":
          str = this.NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 4);
          num1 = this.MeasureTextWidth(str, this.Font);
          strValue = "d,dd,ddd,dddd";
          break;
      }
      if (!string.IsNullOrEmpty(str))
        objWriter.WriteAttributeString("VLB", str);
      if (num1 > 0)
        objWriter.WriteAttributeString("SZ", num1.ToString());
      if (num2 >= 0)
        objWriter.WriteAttributeString("IX", num2.ToString());
      if (!string.IsNullOrEmpty(strValue))
        objWriter.WriteAttributeString("EF", strValue);
      if (flag)
        objWriter.WriteAttributeString("RO", "1");
      objWriter.WriteEndElement();
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        objWriter.WriteAttributeString("CB", this.ShowCheckBox ? "1" : "0");
        if (this.ShowCheckBox)
          objWriter.WriteAttributeString("C", this.Checked ? "1" : "0");
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderShowUpDownAttribute(objWriter, true);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.DateTimePicker.CloseUp"></see> event.</summary>
    /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal virtual void OnCloseUp(EventArgs objEventArgs)
    {
      EventHandler closeUpHandler = this.CloseUpHandler;
      if (closeUpHandler == null)
        return;
      closeUpHandler((object) this, objEventArgs);
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

    /// <summary>
    /// Raises the <see cref="E:ValueChangedQueued" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnValueChangedQueued(EventArgs objEventArgs)
    {
      EventHandler changedQueuedHandler = this.ValueChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.CheckedChanged"></see> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckedChanged(EventArgs objEventArgs)
    {
      EventHandler checkedChangedHandler = this.CheckedChangedHandler;
      if (checkedChangedHandler == null)
        return;
      checkedChangedHandler((object) this, objEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      this.Height = this.PreferredHeight;
    }

    /// <summary>Raises the CheckedChangedQueued event</summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
    {
      EventHandler changedQueuedHandler = this.CheckedChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, objEventArgs);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      bool flag = false;
      switch (objEvent.Type)
      {
        case "Browse":
          DateTimePickerPopup dateTimePickerPopup = this.GetDateTimePickerPopup();
          if (dateTimePickerPopup != null)
          {
            if (this.ShowCheckBox && !this.Checked)
              this.Checked = true;
            int num = (int) dateTimePickerPopup.ShowPopup((Component) this, DialogAlignment.Below);
          }
          break;
        case "CheckedChange":
          bool result1 = false;
          if (bool.TryParse(objEvent["Value"], out result1) && this.Checked != result1)
          {
            this.CheckedInternal = result1;
            break;
          }
          break;
        case "ValueChange":
          string s = objEvent["Value"];
          if (!string.IsNullOrEmpty(s))
          {
            long result2 = -1;
            if (long.TryParse(s, out result2))
            {
              this.SetValueInternal(new DateTime(result2));
              break;
            }
            break;
          }
          break;
        default:
          flag = true;
          break;
      }
      if (!flag)
        return;
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the date time picker popup.</summary>
    /// <returns></returns>
    protected virtual DateTimePickerPopup GetDateTimePickerPopup() => new DateTimePickerPopup(this);

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.ValueChangedHandler != null)
        criticalEventsData.Set("VC");
      if (this.CheckedChangedHandler != null || this.ValueChangedHandler != null)
        criticalEventsData.Set("CC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      if (this.HasClientHandler("CheckedChange"))
        clientEventsData.Set("CC");
      return clientEventsData;
    }

    /// <summary>Gets the hanlder for the CheckedChangedQueued event.</summary>
    private EventHandler CheckedChangedQueuedHandler => (EventHandler) this.GetHandler(DateTimePicker.CheckedChangedQueuedEvent);

    /// <summary>Gets the hanlder for the CheckedChanged event.</summary>
    private EventHandler CheckedChangedHandler => (EventHandler) this.GetHandler(DateTimePicker.CheckedChangedEvent);

    /// <summary>Gets the hanlder for the CloseUp event.</summary>
    internal EventHandler CloseUpHandler => (EventHandler) this.GetHandler(DateTimePicker.CloseUpEvent);

    /// <summary>
    /// Gets or sets the date/time value assigned to the control.
    /// </summary>
    /// <returns>The <see cref="T:System.DateTime"></see> value assign to the control.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The set value is less than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> or more than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MaxDate"></see>.</exception>
    [Bindable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("DateTimePickerValueDescr")]
    [SRCategory("CatBehavior")]
    public virtual DateTime Value
    {
      get => this.mobjValue;
      set
      {
        if (!this.SetValueInternal(value))
          return;
        this.Update();
      }
    }

    /// <summary>Resets the value.</summary>
    private void ResetValue() => this.Value = DateTime.Today;

    /// <summary>
    /// Gets the current date/time format selected by the user and set
    /// by the user's operating system, unless defined in web.config.
    /// </summary>
    /// <returns>The current date/time format selected by the user and set
    /// by the user's operating system, unless defined in web.config.</returns>
    private string CurrentFormat
    {
      get
      {
        DateTimeFormatInfo dateTimeFormat = Application.CurrentUICulture.DateTimeFormat;
        string str1 = DateTimePicker.mstrLongFormat;
        string str2 = DateTimePicker.mstrShortFormat;
        string str3 = DateTimePicker.mstrTimeFormat;
        if (str1 == null)
          str1 = dateTimeFormat.LongDatePattern;
        if (str2 == null)
          str2 = dateTimeFormat.ShortDatePattern;
        if (str3 == null)
          str3 = dateTimeFormat.LongTimePattern;
        string currentFormat = (string) null;
        switch (this.Format)
        {
          case DateTimePickerFormat.Long:
            currentFormat = str1;
            break;
          case DateTimePickerFormat.Short:
            currentFormat = str2;
            break;
          case DateTimePickerFormat.Time:
            currentFormat = str3;
            break;
          case DateTimePickerFormat.Custom:
            currentFormat = this.CustomFormat;
            break;
        }
        return currentFormat;
      }
    }

    /// <summary>Gets or sets a value indicating whether a spin button control (also known as an up-down control) is used to adjust the date/time value.</summary>
    /// <returns>true if a spin button control is used to adjust the date/time value; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("DateTimePickerShowUpDownDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(false)]
    public bool ShowUpDown
    {
      get => this.GetValue<bool>(DateTimePicker.ShowUpDownProperty);
      set
      {
        if (!this.SetValue<bool>(DateTimePicker.ShowUpDownProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (ShowUpDown));
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show both edit buttons].
    /// </summary>
    /// <value>
    /// <c>true</c> if [show both edit buttons]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("DateTimePickerShowBothEditButtonsDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(false)]
    public bool ShowBothEditButtons
    {
      get => this.GetValue<bool>(DateTimePicker.ShowBothEditButtonsProperty);
      set
      {
        if (!this.SetValue<bool>(DateTimePicker.ShowBothEditButtonsProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the first day of the week as displayed in the month calendar.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
    [SRDescription("MonthCalendarFirstDayOfWeekDescr")]
    [DefaultValue(Day.Default)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    public Day CalendarFirstDayOfWeek
    {
      get => this.GetValue<Day>(DateTimePicker.CalendarFirstDayOfWeekProperty);
      set
      {
        if (!this.SetValue<Day>(DateTimePicker.CalendarFirstDayOfWeekProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the year value for empty dates. Dates on or before this year are considered empty (blank) dates.
    /// By setting this value to non-default value, the DateTimePicker will change its date to current date if dropdown is started with a date considered as blank.
    /// As an example, setting this to 1900, dropping down DateTimePicker on dates on year 1900 or before will first change the value of DateTimePicker to current
    /// date, then start the dropdown, thereby starting selection from current date, not before year 1900.</summary>
    /// <returns>The year as integer. The default is 0.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
    [SRDescription("EmptyDateYearDescr")]
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    public int EmptyDateYear
    {
      get => this.GetValue<int>(DateTimePicker.EmptyDateYearProperty);
      set
      {
        if (value >= DateTime.Now.Year || value < 0)
          throw new ArgumentOutOfRangeException();
        if (!this.SetValue<int>(DateTimePicker.EmptyDateYearProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker" /> is checked.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if checked; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("DateTimePickerCheckedDescr")]
    [Bindable(true)]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool Checked
    {
      get => this.GetState(Component.ComponentState.Checked);
      set
      {
        if (this.Checked == value)
          return;
        this.CheckedInternal = value;
        this.FireObservableItemPropertyChanged(nameof (Checked));
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Sets a value indicating whether [checked internal].</summary>
    /// <value><c>true</c> if [checked internal]; otherwise, <c>false</c>.</value>
    internal bool CheckedInternal
    {
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Checked, value))
          return;
        this.OnValueChanged(new EventArgs());
        this.OnValueChangedQueued(new EventArgs());
        this.OnCheckedChanged(new EventArgs());
        this.OnCheckedChangedQueued(new EventArgs());
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a check box is displayed to the left of the selected date.
    /// </summary>
    /// <returns>true if a check box is displayed to the left of the selected date; otherwise, false. The default is false.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(false)]
    [SRDescription("DateTimePickerShowNoneDescr")]
    [SRCategory("CatAppearance")]
    public bool ShowCheckBox
    {
      get => this.GetValue<bool>(DateTimePicker.ShowCheckBoxProperty);
      set
      {
        if (!this.SetValue<bool>(DateTimePicker.ShowCheckBoxProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (ShowCheckBox));
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the custom date/time format string.</summary>
    /// <returns>A string that represents the custom date/time format. The default is null.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("DateTimePickerCustomFormatDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public string CustomFormat
    {
      get => this.GetValue<string>(DateTimePicker.CustomFormatProperty);
      set
      {
        if (!this.SetValue<string>(DateTimePicker.CustomFormatProperty, value) || this.Format != DateTimePickerFormat.Custom)
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (CustomFormat));
      }
    }

    /// <summary>
    /// Gets or sets the format of the date and time displayed in the control.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePickerFormat"></see> values. The default is <see cref="F:System.Windows.Forms.DateTimePickerFormat.Long"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Windows.Forms.DateTimePickerFormat"></see> values. </exception>
    [SRDescription("DateTimePickerFormatDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRCategory("CatAppearance")]
    [DefaultValue(DateTimePickerFormat.Long)]
    public DateTimePickerFormat Format
    {
      get => this.GetValue<DateTimePickerFormat>(DateTimePicker.DateTimePickerFormatProperty);
      set
      {
        if (!this.SetValue<DateTimePickerFormat>(DateTimePicker.DateTimePickerFormatProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Format));
      }
    }

    /// <summary>Indicates if format should be serialized</summary>
    /// <returns></returns>
    private bool ShouldSerializeFormat() => this.Format != DateTimePickerFormat.Long;

    /// <summary>
    /// Gets or sets the maximum date and time that can be selected in the control.
    /// </summary>
    /// <returns>The maximum date and time that can be selected in the control. The default is 12/31/9998 23:59:59.</returns>
    /// <exception cref="T:System.ArgumentException">The value assigned is less than the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> value. </exception>
    /// <exception cref="T:System.SystemException">The value assigned is greater than the <see cref="F:Gizmox.WebGUI.Forms.DateTimePicker.MaxDateTime"></see> value. </exception>
    [SRCategory("CatBehavior")]
    [SRDescription("DateTimePickerMaxDateDescr")]
    public DateTime MaxDate
    {
      get => this.mobjMaxValue;
      set
      {
        if (DateTime.Compare(value, this.MaxDate) == 0)
          return;
        if (DateTime.Compare(value, this.MinDate) == -1)
          throw new ArgumentOutOfRangeException();
        this.mobjMaxValue = DateTime.Compare(value, DateTimePicker.MaxDateTime) != 1 ? value : throw new ArgumentOutOfRangeException();
        this.Update();
        if (DateTime.Compare(value, this.Value) != -1)
          return;
        this.Value = value;
      }
    }

    /// <summary>Resets the max date.</summary>
    private void ResetMaxDate() => this.MaxDate = DateTimePicker.MaxDateTime;

    private bool ShouldSerializeMaxDate() => this.MaxDate != DateTimePicker.MaxDateTime;

    /// <summary>Gets or sets the minimum date and time that can be selected in the control.</summary>
    /// <returns>The minimum date and time that can be selected in the control. The default is 1/1/1753 00:00:00.</returns>
    /// <exception cref="T:System.SystemException">The value assigned is less than the <see cref="F:System.Windows.Forms.DateTimePicker.MinDateTime"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">The value assigned is not less than the <see cref="P:System.Windows.Forms.DateTimePicker.MaxDate"></see> value. </exception>
    [SRDescription("DateTimePickerMinDateDescr")]
    [SRCategory("CatBehavior")]
    public DateTime MinDate
    {
      get => this.mobjMinValue;
      set
      {
        if (DateTime.Compare(value, this.MinDate) == 0)
          return;
        if (DateTime.Compare(value, this.MaxDate) == 1)
          throw new ArgumentOutOfRangeException();
        this.mobjMinValue = DateTime.Compare(value, DateTimePicker.MinDateTime) != -1 ? value : throw new ArgumentOutOfRangeException();
        this.Update();
        if (DateTime.Compare(value, this.Value) != 1)
          return;
        this.Value = value;
      }
    }

    /// <summary>Resets the MinDate.</summary>
    private void ResetMinDate() => this.MinDate = DateTimePicker.MinDateTime;

    /// <summary>Shoulds the serialize min date.</summary>
    /// <returns></returns>
    private bool ShouldSerializeMinDate() => this.MinDate != DateTimePicker.MinDateTime;

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <returns>The text associated with this control.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public override string Text
    {
      get
      {
        DateTime dateTime = this.Value;
        return !this.DesignMode ? this.Value.ToString(this.CurrentFormat) : base.Text;
      }
      set
      {
        DateTime dateTime1 = this.Value;
        DateTime now = DateTime.Now;
        if (value == null || value.Length == 0)
          this.mblnUserHasSetValue = false;
        else
          now = DateTime.Parse(value, (IFormatProvider) this.Context.CurrentUICulture);
        DateTime dateTime2 = now;
        if (!(dateTime1 != dateTime2))
          return;
        this.Value = now;
        this.OnTextChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the height of the preferred.</summary>
    /// <value>The height of the preferred.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PreferredHeight
    {
      get
      {
        int preferredHeight = 0;
        Font font = this.Font;
        if (font != null)
          preferredHeight = CommonUtils.GetFontHeight(font);
        if (this.Skin is DateTimePickerSkin skin)
          preferredHeight += skin.Padding.Vertical;
        return preferredHeight;
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>
    /// Gets a value indicating whether raise click event on mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldRaiseClickOnRightMouseDown => false;

    /// <summary>Gets or sets the font style applied to the calendar.</summary>
    /// <returns>A <see cref="T:System.Drawing.Font"></see> that represents the font style applied to the calendar.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font CalendarFont
    {
      get => (Font) null;
      set
      {
      }
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(200, this.PreferredHeight);
  }
}
