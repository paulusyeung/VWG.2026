#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Configuration;
using System.ComponentModel;
using System.Globalization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies the date and time format the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"/> control displays.
    /// </summary>
    [Serializable]
    public enum DateTimePickerFormat
    {
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in a custom format.
        /// </summary>
        Custom = 8,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the long date format set by the user's operating system.
        /// </summary>
        Long = 1,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the short date format set by the user's operating system.
        /// </summary>
        Short = 2,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the time format set by the user's operating system.
        /// </summary>
        Time = 4
    }

    #endregion Enums

    #region DateTimePicker Class

    /// <summary>
    /// Represents a Gizmox.WebGUI.Forms control that allows the user to select a date and a time and to display the date and time with a specified format.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(DateTimePicker), "DateTimePicker_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(DateTimePicker), "DateTimePicker.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DateTimePickerController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DateTimePickerController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.DateTimePicker)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DateTimePickerSkin)), Serializable()]
    public class DateTimePicker : Control
    {
        #region Class Members

        /// <summary>
        /// Provides a property reference to DateTimePickerFormat property.
        /// </summary>
        private static SerializableProperty DateTimePickerFormatProperty = SerializableProperty.Register("DateTimePickerFormat", typeof(DateTimePickerFormat), typeof(DateTimePicker), new SerializablePropertyMetadata(DateTimePickerFormat.Long));

        /// <summary>
        /// Provides a property reference to CustomFormat property.
        /// </summary>
        private static SerializableProperty CustomFormatProperty = SerializableProperty.Register("CustomFormat", typeof(string), typeof(DateTimePicker), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ShowUpDown property.
        /// </summary>
        private static SerializableProperty ShowUpDownProperty = SerializableProperty.Register("ShowUpDown", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ShowBothEditButtons property.
        /// </summary>
        private static SerializableProperty ShowBothEditButtonsProperty = SerializableProperty.Register("ShowBothEditButtons", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));
        
        /// <summary>
        /// Provides a property reference to CalendarFirstDayOfWeek property.
        /// </summary>
        private static SerializableProperty CalendarFirstDayOfWeekProperty = SerializableProperty.Register("CalendarFirstDayOfWeek", typeof(Day), typeof(DateTimePicker), new SerializablePropertyMetadata(Day.Default));

        /// <summary>
        /// Provides a property reference to EmptyDateYear property.
        /// </summary>
        private static SerializableProperty EmptyDateYearProperty = SerializableProperty.Register("EmptyDateYear", typeof(int), typeof(DateTimePicker), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to ShowCheckBox property.
        /// </summary>
        private static SerializableProperty ShowCheckBoxProperty = SerializableProperty.Register("ShowCheckBox", typeof(bool), typeof(DateTimePicker), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The CheckedChangedQueued event registration.
        /// </summary>
        private static readonly SerializableEvent CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof(EventHandler), typeof(DateTimePicker));

        /// <summary>
        /// The CheckedChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(DateTimePicker));

        /// <summary>
        /// The CloseUp event registration.
        /// </summary>
        private static readonly SerializableEvent CloseUpEvent = SerializableEvent.Register("CloseUp", typeof(EventHandler), typeof(DateTimePicker));

        /// <summary>
        /// Specifies the maximum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control. This field is read-only.
        /// </summary>
        public static DateTime MaxDateTime;

        /// <summary>
        /// Gets the minimum date value of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
        /// </summary>
        public static DateTime MinDateTime;

        /// <summary>
        /// Default time format
        /// </summary>
        private static string mstrTimeFormat = "h:mm:ss tt";

        /// <summary>
        /// Default short date format
        /// </summary>
        private static string mstrShortFormat = "M/d/yyyy";

        /// <summary>
        /// Default long date format
        /// </summary>
        private static string mstrLongFormat = "dddd , MMMM dd, yyyy";

        /// <summary>
        /// 
        /// </summary>
        private static char[] marrTokens = new char[] { 'd', 'm', 'M', 'y', 's', 't', 'h', 'H' };

        /// <summary>
        /// Occurs when the popup date windows is closed.
        /// </summary>
        public event EventHandler CloseUp
        {
            add
            {
                this.AddHandler(DateTimePicker.CloseUpEvent, value);
            }
            remove
            {
                this.RemoveHandler(DateTimePicker.CloseUpEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property changes.
        /// </summary>
        [SRDescription("valueChangedEventDescr"), SRCategory("CatAction")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.AddCriticalHandler(DateTimePicker.ValueChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(DateTimePicker.ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("valueChangedEventDescr"), Category("Client")]
        public event ClientEventHandler ClientValueChanged
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
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("checkedChangedEventDescr"), Category("Client")]
        public event ClientEventHandler ClientCheckedChanged
        {
            add
            {
                this.AddClientHandler("CheckedChange", value);
            }
            remove
            {
                this.RemoveClientHandler("CheckedChange", value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("dropDownEventDescr"), Category("Client")]
        public event ClientEventHandler ClientDropDown
        {
            add
            {
                this.AddClientHandler("Browse", value);
            }
            remove
            {
                this.RemoveClientHandler("Browse", value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ValueChanged event.
        /// </summary>
        private EventHandler ValueChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DateTimePicker.ValueChangedEvent);
            }
        }

        /// <summary>
        /// The ValueChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(DateTimePicker));

        /// <summary>
        /// Occurs when the value of the Checked property changes.
        /// </summary>
        public event EventHandler CheckedChanged
        {
            add
            {
                this.AddCriticalHandler(DateTimePicker.CheckedChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(DateTimePicker.CheckedChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the Checked property changes (Queued).
        /// </summary>
        public event EventHandler CheckedChangedQueued
        {
            add
            {
                this.AddHandler(DateTimePicker.CheckedChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(DateTimePicker.CheckedChangedQueuedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.ValueChanged"></see> property changes (queued).
        /// </summary>
        public event EventHandler ValueChangedQueued
        {
            add
            {
                this.AddHandler(DateTimePicker.ValueChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(DateTimePicker.ValueChangedQueuedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ValueChangedQueued event.
        /// </summary>
        private EventHandler ValueChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DateTimePicker.ValueChangedQueuedEvent);
            }
        }

        /// <summary>
        /// The ValueChangedQueued event registration.
        /// </summary>
        private static readonly SerializableEvent ValueChangedQueuedEvent = SerializableEvent.Register("ValueChangedQueued", typeof(EventHandler), typeof(DateTimePicker));

        /// <summary>
        /// The current datetime picker value
        /// </summary>
        [NonSerialized]
        private DateTime mobjValue;

        /// <summary>
        /// The current datetime picker max value
        /// </summary>
        [NonSerialized]
        private DateTime mobjMaxValue;

        /// <summary>
        /// The current datetime picker min value
        /// </summary>
        [NonSerialized]
        private DateTime mobjMinValue;

        /// <summary>
        /// A flag indicating whether user has set value.
        /// </summary>
        [NonSerialized]
        private bool mblnUserHasSetValue = false;

        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DateTimePicker()
        {
            DateTimePicker.MinDateTime = new DateTime(1753, 1, 1);
            DateTimePicker.MaxDateTime = new DateTime(9998, 12, 31);

            Config objConfig = Config.GetInstance();
            if (objConfig != null)
            {
                mstrTimeFormat = objConfig.DefaultTimeFormat;
                mstrShortFormat = objConfig.DefaultShortDateFormat;
                mstrLongFormat = objConfig.DefaultLongDateFormat;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> class.
        /// </summary>
        public DateTimePicker()
        {
            // Set the control initial values
            mobjValue = DateTime.Today;
            mobjMaxValue = DateTimePicker.MaxDateTime;
            mobjMinValue = DateTimePicker.MinDateTime;

            // Set the control style
            base.SetStyle(ControlStyles.FixedHeight, true);
            base.SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint, false);

            // Set the default control state
            this.SetState(ComponentState.Checked, true);
        }

        #endregion C'Tor\D'Tor

        #region Methods

        #region Serialization Methods

        /// <summary>
        /// The amount of fields the form needs to serialize
        /// </summary>
        private const int mintSerializableFieldCount = 4;

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                // Get the base requirements and add the form fields
                return base.SerializableDataInitialSize + mintSerializableFieldCount;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read serialized fields
            mobjValue = objReader.ReadDateTime();
            mobjMaxValue = objReader.ReadDateTime();
            mobjMinValue = objReader.ReadDateTime();
            mblnUserHasSetValue = objReader.ReadBoolean();
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write serializable fields
            objWriter.WriteDateTime(mobjValue);
            objWriter.WriteDateTime(mobjMaxValue);
            objWriter.WriteDateTime(mobjMinValue);
            objWriter.WriteBoolean(mblnUserHasSetValue);
        }

        #endregion

        #region General

        /// <summary>
        /// Gets the string of a date time object.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        private static string FormatDateTime(DateTime value)
        {
            return value.ToString("G");
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control.
        /// </summary>
        ///	<returns>A string that represents the current <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see>. The string includes the type and the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.Value"></see> property of the control.</returns>
        public override string ToString()
        {
            string strText1 = base.ToString();
            return (strText1 + ", Value: " + DateTimePicker.FormatDateTime(this.Value));
        }

        /// <summary>
        /// Sets the value internal.
        /// </summary>
        /// <value>The value internal.</value>
        internal bool SetValueInternal(DateTime objValue)
        {
            //If value out of range
            if ((objValue < this.MinDate) || (objValue > this.MaxDate))
            {
                throw new ArgumentOutOfRangeException();
            }

            //If value is different from current Value
            if (mobjValue != objValue)
            {
                // Set the current value
                mobjValue = objValue;

                // Set the UserHasSetValue to true.
                this.mblnUserHasSetValue = true;

                // Raise the on value changed event.
                OnValueChanged(EventArgs.Empty);

                // Raise the on value changed queued event.
                OnValueChangedQueued(EventArgs.Empty);

                // Fire observable value changed.
                FireObservableItemPropertyChanged("Value");

                // In case of show checkboxes - check the picker.
                if (this.Parent != null && this.ShowCheckBox)
                {
                    // Set the ckecked state
                    this.Checked = true;
                }

                // Return flag indicating value had changed
                return true;
            }
            else
            {
                // Return flag indicating value had not changed
                return false;
            }
        }

        /// <summary>
        /// Shoulds the serialize value.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeValue()
        {
            return this.mblnUserHasSetValue;
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new DateTimePickerRenderer(this);
        }

        /// <summary>
        /// Gets the width of the widest day.
        /// </summary>
        /// <param name="strFormat">The format.</param>
        /// <returns></returns>
        private int GetWidestDayWidth(string strFormat)
        {
            int intWidestDay = 0;

            // Get picker's font.
            Font objFont = this.Font;

            // Loop all days
            foreach (DayOfWeek enmDayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                // Get current normalized day.
                string strNormalizedDay = NormalizeDay(enmDayOfWeek, strFormat);

                // Measure current normalized day.
                int intNormalizedDayWidth = this.MeasureTextWidth(strNormalizedDay, objFont);

                // Check if current normalized day is wider then the last one found so far.
                if (intNormalizedDayWidth > intWidestDay)
                {
                    // Preserve current normalized day width.
                    intWidestDay = intNormalizedDayWidth;
                }
            }

            return intWidestDay;
        }

        /// <summary>
        /// Gets the width of the widest month.
        /// </summary>
        /// <param name="strFormat">The format.</param>
        /// <returns></returns>
        private int GetWidestMonthWidth(string strFormat)
        {
            int intLongestNormalizedMonthWidth = 0;

            // Get picker's font.
            Font objFont = this.Font;

            // Loop all months
            for (int intMonth = 1; intMonth <= 12; intMonth++)
            {
                // Get current normalized month.
                string strNormalizedMonth = NormalizeMonth(intMonth, strFormat);

                // Measure current normalized month.
                int intNormalizedMonthWidth = this.MeasureTextWidth(strNormalizedMonth, objFont);

                // Check if current normalized month is wider then the last one found so far.
                if (intNormalizedMonthWidth > intLongestNormalizedMonthWidth)
                {
                    // Preserve current normalized month width.
                    intLongestNormalizedMonthWidth = intNormalizedMonthWidth;
                }
            }

            return intLongestNormalizedMonthWidth;
        }

        /// <summary>
        /// Normalizes the month.
        /// </summary>
        /// <param name="intMonth">The int month.</param>
        /// <param name="strFormat">The STR format.</param>
        /// <returns></returns>
        private string NormalizeMonth(int intMonth, string strFormat)
        {
            if (intMonth > 0 && intMonth <= 12)
            {
                return WGLabels.GetLocalizedMonthString(intMonth, strFormat == "MMM", Common.Global.Context, true);
            }
            else
            {
                return "???";
            }
        }

        /// <summary>
        /// Gets the normalized day value
        /// </summary>
        /// <param name="enmDayOfWeek"></param>
        /// <param name="strFormat"></param>
        /// <returns></returns>
        private string NormalizeDay(DayOfWeek enmDayOfWeek, string strFormat)
        {
            if (strFormat == "ddd")
            {
                switch (enmDayOfWeek)
                {
                    case DayOfWeek.Sunday: return WGLabels.GetString("SundayShort", Common.Global.Context, true);
                    case DayOfWeek.Monday: return WGLabels.GetString("MondayShort", Common.Global.Context, true);
                    case DayOfWeek.Tuesday: return WGLabels.GetString("TuesdayShort", Common.Global.Context, true);
                    case DayOfWeek.Wednesday: return WGLabels.GetString("WednesdayShort", Common.Global.Context, true);
                    case DayOfWeek.Thursday: return WGLabels.GetString("ThursdayShort", Common.Global.Context, true);
                    case DayOfWeek.Friday: return WGLabels.GetString("FridayShort", Common.Global.Context, true);
                    case DayOfWeek.Saturday: return WGLabels.GetString("SaturdayShort", Common.Global.Context, true);
                }
            }
            else
            {
                switch (enmDayOfWeek)
                {
                    case DayOfWeek.Sunday: return WGLabels.GetString("Sunday", Common.Global.Context, true);
                    case DayOfWeek.Monday: return WGLabels.GetString("Monday", Common.Global.Context, true);
                    case DayOfWeek.Tuesday: return WGLabels.GetString("Tuesday", Common.Global.Context, true);
                    case DayOfWeek.Wednesday: return WGLabels.GetString("Wednesday", Common.Global.Context, true);
                    case DayOfWeek.Thursday: return WGLabels.GetString("Thursday", Common.Global.Context, true);
                    case DayOfWeek.Friday: return WGLabels.GetString("Friday", Common.Global.Context, true);
                    case DayOfWeek.Saturday: return WGLabels.GetString("Saturday", Common.Global.Context, true);
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
            foreach (char chrCurrentValue in arrChars)
            {
                if (chrCurrentValue == chrValue)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets a AP/PM valued hour
        /// </summary>
        /// <param name="intHour">The int hour.</param>
        /// <param name="blnShort">if set to <c>true</c> [BLN short].</param>
        /// <returns></returns>
        private string NormalizeAMPM(int intHour, bool blnShort)
        {
            if (intHour > 11)
            {
                return WGLabels.GetLocalizedAMPMDesignatorString(false, blnShort, this.Context);
            }
            else
            {
                return WGLabels.GetLocalizedAMPMDesignatorString(true, blnShort, this.Context);
            }
        }

        /// <summary>
        /// Gets a AP/PM valued hour
        /// </summary>
        /// <param name="intHour"></param>
        /// <returns></returns>
        private int NormalizeAMPMIndex(int intHour)
        {
            if (intHour > 11)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets a 0-12 valued hour
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private int NormalizeHour(int intValue)
        {
            if (intValue < 13)
            {
                if (intValue == 0) return 12;
                else return intValue;
            }
            else
            {
                return (intValue - 12);
            }
        }

        /// <summary>
        /// Normalizes the year.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <param name="intPlaces">The int places.</param>
        /// <returns></returns>
        private string NormalizeYear(int intValue, int intPlaces)
        {
            string strValue = intValue.ToString();

            switch (intPlaces)
            {
                case 1:
                    strValue = Convert.ToInt32(strValue.Substring(2)).ToString();
                    break;
                case 2:
                    strValue = strValue.Substring(2);
                    break;
            }

            return strValue;
        }

        /// <summary>
        /// Utility method for padding numbers
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <param name="intPlaces">The int places.</param>
        /// <param name="blnCrop">if set to <c>true</c> [BLN crop].</param>
        /// <returns></returns>
        private string NormalizeNumber(int intValue, int intPlaces, bool blnCrop)
        {
            return NormalizeNumber(intValue.ToString(), intPlaces, blnCrop);
        }

        /// <summary>
        /// Utility method for padding numbers
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <param name="intPlaces">The int places.</param>
        /// <param name="blnCrop">if set to <c>true</c> [BLN crop].</param>
        /// <returns></returns>
        private string NormalizeNumber(string strValue, int intPlaces, bool blnCrop)
        {
            if (strValue.Length < intPlaces)
            {
                string strPadding = "";

                for (int intIndex = strValue.Length; intIndex < intPlaces; intIndex++)
                {
                    strPadding += "0";
                }

                return strPadding + strValue;
            }
            if (strValue.Length > intPlaces && blnCrop)
            {
                return strValue.Substring(strValue.Length - intPlaces, intPlaces);
            }
            else
            {
                return strValue;
            }
        }

        #endregion General

        #region Render

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render should show checkbox attribute
            objWriter.WriteAttributeString(WGAttributes.CheckBoxes, this.ShowCheckBox ? "1" : "0");

            // If should show check box add the checked value
            if (this.ShowCheckBox)
            {
                objWriter.WriteAttributeString(WGAttributes.Checked, this.Checked ? "1" : "0");
            }

            // Renders the show up down attribute.
            RenderShowUpDownAttribute(objWriter,false);

            // Render datetime value.
            objWriter.WriteAttributeString(WGAttributes.DateTime, this.Value.Ticks.ToString());

            // Render minimum datetime value.
            if (this.MinDate != DateTimePicker.MinDateTime)
            {
                objWriter.WriteAttributeString(WGAttributes.MinDate, this.MinDate.Ticks.ToString());
            }

            // Render maximum datetime value.
            if (this.MaxDate != DateTimePicker.MaxDateTime)
            {
                objWriter.WriteAttributeString(WGAttributes.MaxDate, this.MaxDate.Ticks.ToString());
            }

            // Render calander first day of the week.
            if (this.CalendarFirstDayOfWeek != Day.Default)
            {
                objWriter.WriteAttributeString(WGAttributes.FirstDayOfWeek, this.CalendarFirstDayOfWeek.ToString());
            }

            // Render EmptyDateYear
            if (this.EmptyDateYear != 0)
            {
                objWriter.WriteAttributeString(WGAttributes.EmptyDateYear, this.EmptyDateYear.ToString());
            }
        }

        /// <summary>
        /// Renders the show up down attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderShowUpDownAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // If should show both up down and spin box
            if (this.ShowBothEditButtons)
            {
                objWriter.WriteAttributeString(WGAttributes.ShowUpDown, "2");
            }
            // If should show up down
            else if (this.ShowUpDown)
            {                
                objWriter.WriteAttributeString(WGAttributes.ShowUpDown, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ShowUpDown, "0");
            }
        }

        /// <summary>
        /// Render the datetimepicker formating
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Active formating
            string strFormat = this.CurrentFormat;

            //Loop while the format has text
            while (!string.IsNullOrEmpty(strFormat))
            {
                bool blnIsToken = false;
                string strContent = string.Empty;

                //Get the current format section
                GetNextContentPart(ref strFormat, out strContent, out blnIsToken);

                // Validate received content.
                if (!string.IsNullOrEmpty(strContent))
                {
                    //If the section is a token
                    if (blnIsToken)
                    {
                        // Write token
                        RenderToken(objWriter, strContent);
                    }
                    else
                    {
                        // Write literal
                        RenderLiteral(objWriter, strContent);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the next content part.
        /// </summary>
        /// <param name="strFormat">The format.</param>
        /// <param name="strContent">Content of the token / literal.</param>
        /// <param name="blnIsToken">if set to <c>true</c> [BLN is token].</param>
        protected void GetNextContentPart(ref string strFormat, out string strContent, out bool blnIsToken)
        {
            // Initializing return arguments.
            blnIsToken = false;
            strContent = string.Empty;

            // Validate recieved format.
            if (!string.IsNullOrEmpty(strFormat))
            {
                // Checks whether recieved format starts with a token.
                if (this.StartsWithToken(strFormat, ref strContent))
                {
                    // Flag that is token.
                    blnIsToken = true;

                    // Remove the token part off the format.
                    strFormat = strFormat.Remove(0, strContent.Length);
                }
                // Checks whether recieved format starts with an apostrophe.
                else if (strFormat.StartsWith("'", StringComparison.InvariantCulture))
                {
                    // Look for the closing apostrophe position.
                    int intClosingApostrophePosition = strFormat.IndexOf('\'', 1);

                    // Check if a closing apostrophe was found.
                    if (intClosingApostrophePosition != -1)
                    {
                        // Set the content variable.
                        strContent = strFormat.Substring(1, intClosingApostrophePosition - 1);

                        // Remove the literal part off the format.
                        strFormat = strFormat.Substring(intClosingApostrophePosition + 1);
                    }
                    else
                    {
                        // Set the content variable.
                        strContent = strFormat.Substring(1);

                        // Clear format variable.
                        strFormat = string.Empty;
                    }
                }
                else
                {
                    // Try get the the first token position.
                    int intFirstTokenCharacterIndex = strFormat.IndexOfAny(marrTokens);

                    // If any token was found.
                    if (intFirstTokenCharacterIndex != -1)
                    {
                        // Set the content variable.
                        strContent = strFormat.Substring(0, intFirstTokenCharacterIndex);

                        // Remove the literal part off the format.
                        strFormat = strFormat.Substring(intFirstTokenCharacterIndex);
                    }
                    else
                    {
                        // Set the content variable.
                        strContent = strFormat.Replace("'", "");

                        // Clear format variable.
                        strFormat = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether recieved format starts with a token.
        /// </summary>
        /// <param name="strFormat">The format.</param>
        /// <param name="strContent">Content of the token / literal.</param>
        /// <returns></returns>
        private bool StartsWithToken(string strFormat, ref string strContent)
        {
            bool blnStartsWithToken = true;

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
                blnStartsWithToken = false;
            }

            return blnStartsWithToken;
        }

        /// <summary>
        /// Renders a datetimepicker literal
        /// </summary>
        /// <param name="objWriter"></param>
        /// <param name="strLiteral"></param>
        private void RenderLiteral(IResponseWriter objWriter, string strLiteral)
        {
            // Render the token size attribute.
            if (!string.IsNullOrEmpty(strLiteral))
            {
                objWriter.WriteStartElement(WGTags.Literal);
                objWriter.WriteAttributeString(WGAttributes.Value, strLiteral);
                objWriter.WriteAttributeString(WGAttributes.Size, this.MeasureTextWidth(strLiteral, this.Font).ToString());
                objWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Measures the width of the text.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <returns></returns>
        private int MeasureTextWidth(string strText, Font objFont)
        {
            int intTextWidth = 0;

            // Validate recieved text.
            if (!string.IsNullOrEmpty(strText))
            {
                // Create a nre string format, based on a generic typographic string format.
                StringFormat objStringFormat = new StringFormat(StringFormat.GenericTypographic);

                // Add a formating flag  that will enable measuring of trailing spaces.
                objStringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

                // Measure recieved text.
                intTextWidth = CommonUtils.GetStringMeasurements(strText, this.Font, -1, Point.Empty, objStringFormat).Width;
            }

            return intTextWidth;
        }

        /// <summary>
        /// Renders a datetimepicker token
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="strLiteral">The STR literal.</param>
        private void RenderToken(IResponseWriter objWriter, string strLiteral)
        {
            objWriter.WriteStartElement(WGTags.Token);
            objWriter.WriteAttributeString(WGAttributes.Format, strLiteral);

            string strTokenValue = string.Empty;
            int intTokenWidth = 0;
            string strEffectedFormats = string.Empty;
            bool blnReadOnly = false;
            int intIndex = -1;

            switch (strLiteral)
            {
                case "d":
                    strTokenValue = this.Value.Day.ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    strEffectedFormats = "dd,ddd,dddd";
                    break;
                case "dd":
                    strTokenValue = NormalizeNumber(this.Value.Day, 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "d,ddd,dddd";
                    break;
                case "ddd":
                    intTokenWidth = GetWidestDayWidth("ddd");
                    blnReadOnly = true;
                    strTokenValue = NormalizeDay(this.Value.DayOfWeek, "ddd");
                    intIndex = Convert.ToInt32(this.Value.DayOfWeek) + 1;
                    break;
                case "dddd":
                    intTokenWidth = GetWidestDayWidth("dddd");
                    blnReadOnly = true;
                    strTokenValue = NormalizeDay(this.Value.DayOfWeek, "dddd");
                    intIndex = Convert.ToInt32(this.Value.DayOfWeek) + 1;
                    break;
                case "y":
                    //In case the CurrentUICulture is not a regular one(like thai)
                    //and we should display years according to the Buddhist Era instead of the Georgian
                    strTokenValue = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 1);
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    strEffectedFormats = "d,dd,ddd,dddd";
                    break;

                case "yy":
                    //In case the CurrentUICulture is not a regular one(like thai)
                    //and we should display years according to the Buddhist Era instead of the Georgian
                    strTokenValue = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 2);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "d,dd,ddd,dddd";
                    break;
                case "yyyy":
                    //In case the CurrentUICulture is not a regular one(like thai)
                    //and we should display years according to the Buddhist Era instead of the Georgian
                    strTokenValue = NormalizeYear(Application.CurrentUICulture.Calendar.GetYear(this.Value), 4);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "d,dd,ddd,dddd";
                    break;
                case "h":
                    strTokenValue = NormalizeHour(this.Value.Hour).ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    strEffectedFormats = "t,tt";
                    break;
                case "hh":
                    strTokenValue = NormalizeNumber(NormalizeHour(this.Value.Hour), 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "t,tt";
                    break;
                case "H":
                    strTokenValue = this.Value.Hour.ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    strEffectedFormats = "t,tt";
                    break;
                case "HH":
                    strTokenValue = NormalizeNumber(this.Value.Hour, 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "t,tt";
                    break;
                case "M":
                    strTokenValue = this.Value.Month.ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    strEffectedFormats = "d,dd,ddd,dddd,MM,MMM,MMMM";
                    break;
                case "MM":
                    strTokenValue = NormalizeNumber(this.Value.Month, 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    strEffectedFormats = "d,dd,ddd,dddd,M,MMM,MMMM";
                    break;
                case "MMM":
                    intTokenWidth = GetWidestMonthWidth("MMM");
                    strTokenValue = NormalizeMonth(this.Value.Month, "MMM");
                    intIndex = this.Value.Month;
                    strEffectedFormats = "d,dd,ddd,dddd,M,MM,MMMM";
                    break;
                case "MMMM":
                    intTokenWidth = GetWidestMonthWidth("MMMM");
                    strTokenValue = NormalizeMonth(this.Value.Month, "MMMM");
                    intIndex = this.Value.Month;
                    strEffectedFormats = "d,dd,ddd,dddd,M,MM,MMM";
                    break;
                case "m":
                    strTokenValue = this.Value.Minute.ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    break;
                case "mm":
                    strTokenValue = NormalizeNumber(this.Value.Minute, 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    break;
                case "s":
                    strTokenValue = this.Value.Second.ToString();
                    intTokenWidth = this.MeasureTextWidth(NormalizeNumber(strTokenValue, 2, false), this.Font);
                    break;
                case "ss":
                    strTokenValue = NormalizeNumber(this.Value.Second, 2, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    break;
                case "t":
                    strTokenValue = NormalizeAMPM(this.Value.Hour, true);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    intIndex = NormalizeAMPMIndex(this.Value.Hour);
                    strEffectedFormats = "H,HH";
                    break;
                case "tt":
                    strTokenValue = NormalizeAMPM(this.Value.Hour, false);
                    intTokenWidth = this.MeasureTextWidth(strTokenValue, this.Font);
                    intIndex = NormalizeAMPMIndex(this.Value.Hour);
                    strEffectedFormats = "H,HH";
                    break;
            }

            // Render the token value attribute.
            if (!string.IsNullOrEmpty(strTokenValue))
            {
                objWriter.WriteAttributeString(WGAttributes.Value, strTokenValue);
            }

            // Render the token size attribute.
            if (intTokenWidth > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.Size, intTokenWidth.ToString());
            }

            // Render the token index attribute.
            if (intIndex >= 0)
            {
                objWriter.WriteAttributeString(WGAttributes.Index, intIndex.ToString());
            }

            // Render the token EffectedFormats attribute.
            if (!string.IsNullOrEmpty(strEffectedFormats))
            {
                objWriter.WriteAttributeString(WGAttributes.EffectedFormats, strEffectedFormats);
            }

            // Render the token ReadOnly attribute.            
            if (blnReadOnly)
            {
                objWriter.WriteAttributeString(WGAttributes.ReadOnly, "1");
            }

            objWriter.WriteEndElement();
        }

        /// <summary>
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
                objWriter.WriteAttributeString(WGAttributes.CheckBoxes, ShowCheckBox ? "1" : "0");

                if (this.ShowCheckBox)
                {
                    objWriter.WriteAttributeString(WGAttributes.Checked, Checked ? "1" : "0");
                }
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the show up down attribute.
                RenderShowUpDownAttribute(objWriter, true);
            }
        }

        #endregion Render

        #region Events

        /// <summary>Raises the <see cref="E:System.Windows.Forms.DateTimePicker.CloseUp"></see> event.</summary>
        /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        internal protected virtual void OnCloseUp(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.CloseUpHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
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
        /// Raises the <see cref="E:ValueChangedQueued"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnValueChangedQueued(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ValueChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DateTimePicker.CheckedChanged"></see> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckedChanged(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.CheckedChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            base.Height = this.PreferredHeight;
        }

        /// <summary>
        /// Raises the CheckedChangedQueued event
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.CheckedChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objEventArgs);
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            //Whether this event should be cascade to base
            bool blnCascadeEventToBase = false;

            // Select event type
            switch (objEvent.Type)
            {
                case "Browse":
                    DateTimePickerPopup objPopup = this.GetDateTimePickerPopup();
                    if (objPopup != null)
                    {
                        // Check the checkBox on open.
                        if (this.ShowCheckBox && !this.Checked)
                        {
                            this.Checked = true;
                        }

                        objPopup.ShowPopup(this, DialogAlignment.Below);
                    }
                    objPopup = null;
                    break;

                case "CheckedChange":
                    bool blnChecked = false;

                    if (bool.TryParse(objEvent["Value"], out blnChecked))
                    {
                        if (this.Checked != blnChecked)
                        {
                            this.CheckedInternal = blnChecked;
                        }
                    }
                    break;

                case "ValueChange":
                    string strValue = objEvent["Value"];

                    if (!string.IsNullOrEmpty(strValue))
                    {
                        long lngTicks = -1;

                        if (long.TryParse(strValue, out lngTicks))
                        {
                            // Set the control value
                            this.SetValueInternal(new DateTime(lngTicks));
                        }
                    }
                    break;

                default:
                    blnCascadeEventToBase = true;
                    break;

            }
            if (blnCascadeEventToBase)
            {
                base.FireEvent(objEvent);
            }

        }

        /// <summary>
        /// Gets the date time picker popup.
        /// </summary>
        /// <returns></returns>
        protected virtual DateTimePickerPopup GetDateTimePickerPopup()
        {
            return new DateTimePickerPopup(this);
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (ValueChangedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            if (this.CheckedChangedHandler != null || ValueChangedHandler != null)
            {
                objEvents.Set(WGEvents.CheckedChange);
            }

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
            if (this.HasClientHandler("CheckedChange"))
            {
                objEvents.Set(WGEvents.CheckedChange);
            }

            return objEvents;
        }

        #endregion Events

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the hanlder for the CheckedChangedQueued event.
        /// </summary>
        private EventHandler CheckedChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DateTimePicker.CheckedChangedQueuedEvent);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CheckedChanged event.
        /// </summary>
        private EventHandler CheckedChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DateTimePicker.CheckedChangedEvent);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CloseUp event.
        /// </summary>
        internal EventHandler CloseUpHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DateTimePicker.CloseUpEvent);
            }
        }

        /// <summary>
        /// Gets or sets the date/time value assigned to the control.
        /// </summary>
        ///	<returns>The <see cref="T:System.DateTime"></see> value assign to the control.</returns>
        ///	<exception cref="T:System.ArgumentOutOfRangeException">The set value is less than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> or more than <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MaxDate"></see>.</exception>
        [Bindable(true), RefreshProperties(RefreshProperties.All), SRDescription("DateTimePickerValueDescr"), SRCategory("CatBehavior")]
        public virtual DateTime Value
        {
            get
            {
                return mobjValue;
            }
            set
            {
                // Set value and if value changed update control
                if (this.SetValueInternal(value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Resets the value.
        /// </summary>
        private void ResetValue()
        {
            this.Value = DateTime.Today;
        }

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
                DateTimeFormatInfo objFormatInfo = Application.CurrentUICulture.DateTimeFormat;

                //get default values from web.config
                string strLongFormat = mstrLongFormat;
                string strShortFormat = mstrShortFormat;
                string strTimeFormat = mstrTimeFormat;

                //Assigning context OS formats in case that client's web.config does not specify.
                if (strLongFormat == null) strLongFormat = objFormatInfo.LongDatePattern;
                if (strShortFormat == null) strShortFormat = objFormatInfo.ShortDatePattern;
                if (strTimeFormat == null) strTimeFormat = objFormatInfo.LongTimePattern;

                // Active formating
                string strFormat = null;

                // Get active formatting
                switch (this.Format)
                {
                    case DateTimePickerFormat.Custom:
                        strFormat = CustomFormat;
                        break;
                    case DateTimePickerFormat.Long:
                        strFormat = strLongFormat;
                        break;
                    case DateTimePickerFormat.Short:
                        strFormat = strShortFormat;
                        break;
                    case DateTimePickerFormat.Time:
                        strFormat = strTimeFormat;
                        break;
                }

                return strFormat;
            }
        }

        /// <summary>Gets or sets a value indicating whether a spin button control (also known as an up-down control) is used to adjust the date/time value.</summary>
        /// <returns>true if a spin button control is used to adjust the date/time value; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("DateTimePickerShowUpDownDescr"), SRCategory("CatAppearance"), DefaultValue(false)]
        public bool ShowUpDown
        {
            get
            {
                //Get value from the property store, Default is false
                return this.GetValue<bool>(DateTimePicker.ShowUpDownProperty);
            }
            set
            {
                //If value is different from current ShowUpDown
                if (this.SetValue<bool>(DateTimePicker.ShowUpDownProperty, value))
                {
                    // Fire observable ShowUpDown changed.
                    this.FireObservableItemPropertyChanged("ShowUpDown");

                    // Update control to reflect changes
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show both edit buttons].
        /// </summary>
        /// <value>
        /// <c>true</c> if [show both edit buttons]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("DateTimePickerShowBothEditButtonsDescr"), SRCategory("CatAppearance"), DefaultValue(false)]
        public bool ShowBothEditButtons
        {
            get
            {
                //Get value from the property store, Default is false
                return this.GetValue<bool>(DateTimePicker.ShowBothEditButtonsProperty);
            }
            set
            {
                //If value is different from current ShowUpDown
                if (this.SetValue<bool>(DateTimePicker.ShowBothEditButtonsProperty, value))
                {
                    // Update control to reflect changes
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>Gets or sets the first day of the week as displayed in the month calendar.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Day.Default"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
        [SRDescription("MonthCalendarFirstDayOfWeekDescr"), DefaultValue(Day.Default), SRCategory("CatBehavior"), Localizable(true)]
        public Day CalendarFirstDayOfWeek
        {
            get
            {
                return this.GetValue<Day>(DateTimePicker.CalendarFirstDayOfWeekProperty);
            }
            set
            {
                // If value is different from current CalendarFirstDayOfWeek
                if (this.SetValue<Day>(DateTimePicker.CalendarFirstDayOfWeekProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the year value for empty dates. Dates on or before this year are considered empty (blank) dates.
        /// By setting this value to non-default value, the DateTimePicker will change its date to current date if dropdown is started with a date considered as blank.
        /// As an example, setting this to 1900, dropping down DateTimePicker on dates on year 1900 or before will first change the value of DateTimePicker to current
        /// date, then start the dropdown, thereby starting selection from current date, not before year 1900.</summary>
        /// <returns>The year as integer. The default is 0.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.Day"></see> enumeration members. </exception>
        [SRDescription("EmptyDateYearDescr"), DefaultValue(0), SRCategory("CatBehavior"), Localizable(true)]
        public int EmptyDateYear
        {
            get
            {
                return this.GetValue<int>(DateTimePicker.EmptyDateYearProperty);
            }
            set
            {
                // Year must be less than current year
                if (value >= DateTime.Now.Year || value < 0)
                    throw new ArgumentOutOfRangeException();

                // If value is different from current EmptyDateYear
                if (this.SetValue<int>(DateTimePicker.EmptyDateYearProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DateTimePicker"/> is checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("DateTimePickerCheckedDescr"), Bindable(true), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool Checked
        {
            get
            {
                return this.GetState(ComponentState.Checked);
            }
            set
            {
                // If the checked value is diffrent
                if (this.Checked != value)
                {
                    // Set the checked value
                    this.CheckedInternal = value;

                    // Fire observable Checked changed.
                    FireObservableItemPropertyChanged("Checked");

                    UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether [checked internal].
        /// </summary>
        /// <value><c>true</c> if [checked internal]; otherwise, <c>false</c>.</value>
        internal bool CheckedInternal
        {
            set
            {
                //If value is different from current Checked
                if (this.SetStateWithCheck(ComponentState.Checked, value))
                {
                    // Raise the on value changed event.
                    OnValueChanged(new EventArgs());

                    // Raise the on value changed queued event.
                    OnValueChangedQueued(new EventArgs());

                    // Raise the checked changed event.
                    OnCheckedChanged(new EventArgs());

                    // Raise the checked changed queued event.
                    OnCheckedChangedQueued(new EventArgs());
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a check box is displayed to the left of the selected date.
        /// </summary>
        ///	<returns>true if a check box is displayed to the left of the selected date; otherwise, false. The default is false.</returns>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(false), SRDescription("DateTimePickerShowNoneDescr"), SRCategory("CatAppearance")]
        public bool ShowCheckBox
        {
            get
            {
                //Get value from the property store, If not set, default is false
                return this.GetValue<bool>(DateTimePicker.ShowCheckBoxProperty);
            }
            set
            {
                //If value is different from current ShowCheckBox
                if (this.SetValue<bool>(DateTimePicker.ShowCheckBoxProperty, value))
                {
                    // Fire observable ShowCheckBox changed.
                    FireObservableItemPropertyChanged("ShowCheckBox");

                    // Update control to reflect changes
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets the custom date/time format string.
        /// </summary>
        ///	<returns>A string that represents the custom date/time format. The default is null.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue((string)null), RefreshProperties(RefreshProperties.Repaint), SRDescription("DateTimePickerCustomFormatDescr"), Localizable(true), SRCategory("CatBehavior")]
        public string CustomFormat
        {
            get
            {
                //Get value from the property store, If not set, default is string.Empty
                return this.GetValue<string>(DateTimePicker.CustomFormatProperty);
            }
            set
            {
                //If value is different from current CustomFormat
                if (this.SetValue<string>(DateTimePicker.CustomFormatProperty, value))
                {
                    // If the control is in custom format
                    if (this.Format == DateTimePickerFormat.Custom)
                    {
                        // Update control to reflect new format
                        this.Update();

                        // Fire observable CustomFormat changed.
                        FireObservableItemPropertyChanged("CustomFormat");
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the format of the date and time displayed in the control.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePickerFormat"></see> values. The default is <see cref="F:System.Windows.Forms.DateTimePickerFormat.Long"></see>.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Windows.Forms.DateTimePickerFormat"></see> values. </exception>
        [SRDescription("DateTimePickerFormatDescr"), RefreshProperties(RefreshProperties.Repaint), SRCategory("CatAppearance"), DefaultValue(DateTimePickerFormat.Long)]
        public DateTimePickerFormat Format
        {
            get
            {
                //Get value from the property store
                return this.GetValue<DateTimePickerFormat>(DateTimePicker.DateTimePickerFormatProperty);
            }
            set
            {
                //If value is different from current Format update the control and raise events
                if (this.SetValue<DateTimePickerFormat>(DateTimePicker.DateTimePickerFormatProperty, value))
                {
                    // Update the control
                    this.Update();

                    // Fire observable Format changed.
                    FireObservableItemPropertyChanged("Format");
                }
            }
        }

        /// <summary>
        /// Indicates if format should be serialized
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeFormat()
        {
            return (this.Format != DateTimePickerFormat.Long);
        }

        /// <summary>
        /// Gets or sets the maximum date and time that can be selected in the control.
        /// </summary>
        ///	<returns>The maximum date and time that can be selected in the control. The default is 12/31/9998 23:59:59.</returns>
        ///	<exception cref="T:System.ArgumentException">The value assigned is less than the <see cref="P:Gizmox.WebGUI.Forms.DateTimePicker.MinDate"></see> value. </exception>
        ///	<exception cref="T:System.SystemException">The value assigned is greater than the <see cref="F:Gizmox.WebGUI.Forms.DateTimePicker.MaxDateTime"></see> value. </exception>
        [SRCategory("CatBehavior"), SRDescription("DateTimePickerMaxDateDescr")]
        public DateTime MaxDate
        {
            get
            {
                return mobjMaxValue;
            }
            set
            {
                //If value is different from current MaxDate
                if (DateTime.Compare(value, this.MaxDate) != 0)
                {
                    //If value is out of range 
                    if (DateTime.Compare(value, this.MinDate) == -1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    //If value is out of range
                    if (DateTime.Compare(value, DateTimePicker.MaxDateTime) == 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    // Set the max value field
                    mobjMaxValue = value;

                    this.Update();

                    //If new MaxDate is smaller than the current Value, set the Value to new MaxDate.
                    if (DateTime.Compare(value, this.Value) == -1)
                    {
                        this.Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// Resets the max date.
        /// </summary>
        private void ResetMaxDate()
        {
            this.MaxDate = DateTimePicker.MaxDateTime;
        }

        private bool ShouldSerializeMaxDate()
        {
            return (this.MaxDate != DateTimePicker.MaxDateTime);
        }

        /// <summary>Gets or sets the minimum date and time that can be selected in the control.</summary>
        /// <returns>The minimum date and time that can be selected in the control. The default is 1/1/1753 00:00:00.</returns>
        /// <exception cref="T:System.SystemException">The value assigned is less than the <see cref="F:System.Windows.Forms.DateTimePicker.MinDateTime"></see> value. </exception>
        /// <exception cref="T:System.ArgumentException">The value assigned is not less than the <see cref="P:System.Windows.Forms.DateTimePicker.MaxDate"></see> value. </exception>
        [SRDescription("DateTimePickerMinDateDescr"), SRCategory("CatBehavior")]
        public DateTime MinDate
        {
            get
            {
                return mobjMinValue;
            }
            set
            {
                //If value is different from current MinDate
                if (DateTime.Compare(value, this.MinDate) != 0)
                {
                    //Check if the new min date value is grater then the max date
                    if (DateTime.Compare(value, this.MaxDate) == 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    //If value is out of range
                    if (DateTime.Compare(value, DateTimePicker.MinDateTime) == -1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    // Set the min value field
                    mobjMinValue = value;

                    // Update control to reflect changes
                    this.Update();

                    //If new MinDate is larger than the current Value, set the Value to new MinDate. 
                    if (DateTime.Compare(value, this.Value) == 1)
                    {
                        this.Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// Resets the MinDate.
        /// </summary>
        private void ResetMinDate()
        {
            this.MinDate = DateTimePicker.MinDateTime;
        }

        /// <summary>
        /// Shoulds the serialize min date.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeMinDate()
        {
            return (this.MinDate != DateTimePicker.MinDateTime);
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <returns>The text associated with this control.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public override string Text
        {
            get
            {
                if (Value != null && !this.DesignMode)
                {
                    return this.Value.ToString(this.CurrentFormat);
                }
                else
                {
                    return base.Text;
                }
            }
            set
            {
                // Preserve current value.
                DateTime objCurrentValue = this.Value;

                // Define a new value variable.
                DateTime objNewValue = DateTime.Now;

                // Check null value.
                if (value == null || value.Length == 0)
                {
                    this.mblnUserHasSetValue = false;
                }
                else
                {
                    // WinForms uses CurrentCulture and it is missing from the context implementation.
                    objNewValue = DateTime.Parse(value, this.Context.CurrentUICulture);
                }

                // Check if current value is different from the new one.
                if (objCurrentValue != objNewValue)
                {
                    // Change value.
                    this.Value = objNewValue;

                    // Raise text change event.
                    this.OnTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the height of the preferred.
        /// </summary>
        /// <value>The height of the preferred.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PreferredHeight
        {
            get
            {
                int intPreferredHeight = 0;

                Font objFont = this.Font;
                if (objFont != null)
                {
                    intPreferredHeight = CommonUtils.GetFontHeight(objFont);
                }

                DateTimePickerSkin objDateTimePickerSkin = this.Skin as DateTimePickerSkin;
                if (objDateTimePickerSkin != null)
                {
                    intPreferredHeight += objDateTimePickerSkin.Padding.Vertical;
                }

                return intPreferredHeight;
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
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

        /// <summary>Gets or sets the font style applied to the calendar.</summary>
        /// <returns>A <see cref="T:System.Drawing.Font"></see> that represents the font style applied to the calendar.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Font CalendarFont
        {
            get
            {
                return null;
            }
            set { }
        }

        #endregion Properties

        #region Default Member Values

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, this.PreferredHeight);
            }
        }

        #endregion Default Member Values

    }

    #endregion DateTimePicker Class

    #region DateTimePickerPopup Class

    /// <summary>
    /// 
    /// </summary>
    [Skin(typeof(Gizmox.WebGUI.Forms.Skins.DateTimePickerPopupSkin)), Serializable()]
    public class DateTimePickerPopup : Form
    {
        #region Class Members

        protected MonthCalendar mobjMonthCalendar = null;

        protected DateTime mobjDate;

        protected DateTimePicker mobjDateTimePicker = null;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePickerPopup"/> class.
        /// </summary>
        public DateTimePickerPopup()
        {
            // draw control
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objDateTimePicker"></param>
        public DateTimePickerPopup(DateTimePicker objDateTimePicker) : this()
        {
            // set local variables
            mobjDateTimePicker = objDateTimePicker;

            if (mobjDateTimePicker != null)
            {
                this.mobjMonthCalendar.Value = mobjDateTimePicker.Value;
                this.mobjMonthCalendar.FirstDayOfWeek = mobjDateTimePicker.CalendarFirstDayOfWeek;

                this.mobjMonthCalendar.VisualEffect = mobjDateTimePicker.VisualEffect;

                //  Pop-up close event will only be neccecery at CloseUp event
                if (mobjDateTimePicker.CloseUpHandler != null)
                {
                    this.Closed += new EventHandler(DateTimePickerPopup_Closed);
                }

                DateTimePickerSkin objDateTimePickerSkin = mobjDateTimePicker.Skin as DateTimePickerSkin;
                if (objDateTimePickerSkin != null)
                {
                    this.Size = objDateTimePickerSkin.DropDownSize;
                }
            }
        }

        #endregion C'Tor / D'Tor

        #region Methods

        #region Initialize Component

        /// <summary>
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjMonthCalendar = new MonthCalendar(mobjDateTimePicker, this);
            this.SuspendLayout();

            //
            // mobjMonthCalendar
            //
            this.mobjMonthCalendar.Dock = DockStyle.Fill;
            this.mobjMonthCalendar.BorderStyle = BorderStyle.None;
            this.mobjMonthCalendar.BorderWidth = 0;

            this.Controls.Add(this.mobjMonthCalendar);

            this.Size = new Size(177, 154);
            this.ClientSize = new Size(177, 154);
            this.Text = WGLabels.DatePicker;
            this.ResumeLayout(false);
        }

        #endregion Initialize Component

        /// <summary>
        /// Called when [month calander value changed].
        /// </summary>
        /// <param name="blnClosePopUp">if set to <c>true</c> [BLN close pop up].</param>
        internal void OnMonthCalanderValueChanged(bool blnClosePopUp)
        {
            // save old time of day value
            TimeSpan objTimeOfDay = TimeSpan.Zero;
            if (mobjDateTimePicker != null)
            {

                objTimeOfDay = mobjDateTimePicker.Value.TimeOfDay;
                DateTime objNewDate = mobjMonthCalendar.Value.Add(objTimeOfDay);

                //only if the new date is in range between DateTimePicker min max date then update
                if (objNewDate >= mobjDateTimePicker.MinDate && objNewDate <= mobjDateTimePicker.MaxDate)
                {
                    // set datetimepicker value to new date, with the addition of the old time value
                    mobjDateTimePicker.Value = objNewDate;
                }

                //return focus to the control
                mobjDateTimePicker.Focus();
            }

            //If date value on calander was selected
            if (blnClosePopUp)
            {
                this.Close();
            }
        }

        #region Events

        void DateTimePickerPopup_Closed(object sender, EventArgs e)
        {
            this.mobjDateTimePicker.OnCloseUp(new EventArgs());
        }

        #endregion Events

        #endregion Methods
    }

    #endregion DateTimePickerPopup Class

    #region DateTimePickerRenderer Class

    /// <summary>
    /// Provides support for rendering DateTimePickeres
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class DateTimePickerRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePickerRenderer"/> class.
        /// </summary>
        /// <param name="objDateTimePicker">The up down base.</param>
        internal DateTimePickerRenderer(DateTimePicker objDateTimePicker)
            : base(objDateTimePicker)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current DateTimePicker
            DateTimePicker objDateTimePicker = this.Control as DateTimePicker;
            if (objDateTimePicker != null)
            {
                //Write the DateTimePicker text
                RenderText(objContext, objGraphics, objDateTimePicker.Text, objDateTimePicker.Font, objDateTimePicker.ForeColor, objDateTimePicker.Size, HorizontalAlignment.Left, true);
            }
        }
    }

    #endregion
}
