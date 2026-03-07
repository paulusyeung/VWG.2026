using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CompanionKit.Concepts.ClientAPI.SearchingEvents
{
    public partial class SearchingEventsPage : UserControl
    {
        public SearchingEventsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objButton_Click(object sender, EventArgs e)
        {

            //If start date more than end, then swap their values
            if (objStartDateTimePicker.Value > objEndDateTimePicker.Value)
            {
                DateTime objTempDate = objStartDateTimePicker.Value;
                objStartDateTimePicker.Value = objEndDateTimePicker.Value;
                objEndDateTimePicker.Value = objTempDate;
            }

            //Getting ticks from dateTimePickers
            long lngStartDate = objStartDateTimePicker.Value.Ticks;
            long lngEndDate = objEndDateTimePicker.Value.Ticks;

            //Invoking js-function with args
            VWGClientContext.Current.Invoke("getEvents", lngStartDate, lngEndDate);
        }

        /// <summary>
        /// Handles the Load event of the SearchingEventsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SearchingEventsPage_Load(object sender, EventArgs e)
        {
            //Setting  initial values of maskedTextBoxes
            objStartDateTimePicker.Value = DateTime.Now;
            objEndDateTimePicker.Value = DateTime.Now.AddDays(2);
            objScheduleBox.FirstDate = DateTime.Now;

            //Filling scheduleBox with generated events
            GenerateEvents();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objViewModeCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objViewModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changing view mode according to selected value from combobox
            switch ((string)objViewModeCombo.SelectedItem)
            {
                case "Day": objScheduleBox.View = ScheduleBoxView.Day; break;
                case "Week": objScheduleBox.View = ScheduleBoxView.Week; break;
                case "Month": objScheduleBox.View = ScheduleBoxView.Month; break;
                case "FullWeek": objScheduleBox.View = ScheduleBoxView.FullWeek; break;
                case "FullMonth": objScheduleBox.View = ScheduleBoxView.FullMonth; break;
            }
        }


        /// <summary>
        /// Generates the events.
        /// </summary>
        void GenerateEvents()
        {
            Random rndValue = new Random();
            //Fills ScheduleBox with events
            AddEvent("Birthday party", Color.Green, rndValue);
            AddEvent("Interview", Color.Orange, rndValue);
            AddEvent("Business meeting", Color.Red, rndValue);
            AddEvent("Wedding", Color.Blue, rndValue);
            AddEvent("Prom", Color.Purple, rndValue);
            AddEvent("Festival", Color.Yellow, rndValue);
        }


        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="strSubject">The STR subject.</param>
        /// <param name="objColor">The color.</param>
        /// <param name="rndValue">The random.</param>
        void AddEvent(string strSubject, Color objColor, Random rndValue)
        {
            //get random day within current month 
            DateTime datStartDate = RandomDay(rndValue);
            //adds event to schedule
            objScheduleBox.Events.Add(strSubject, datStartDate, GetRandomEndDate(datStartDate));
            //Set event's color
            objScheduleBox.Events[objScheduleBox.Events.Count-1].BackgroundColor = objColor;
        }


        /// <summary>
        /// Randoms the day.
        /// </summary>
        /// <param name="rndValue">The random.</param>
        /// <returns>Returns random date within month</returns>
        DateTime RandomDay(Random rndValue)
        {
            DateTime datNow = DateTime.Now;
            int intDaysInMonth = DateTime.DaysInMonth(datNow.Year, datNow.Month);
            int intCurrentDay = datNow.Day;
            return datNow.AddDays(rndValue.Next(-intCurrentDay,intDaysInMonth-intCurrentDay));
        }


        /// <summary>
        /// Gets the random end date.
        /// </summary>
        /// <param name="datStartDate">The start date.</param>
        /// <returns>Returns the date of randomly increased on few days (1-5)</returns>
        DateTime GetRandomEndDate(DateTime datStartDate)
        {
            return datStartDate.AddDays(new Random().Next(1, 5));   
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objRangeRadio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objRangeRadio_CheckedChanged(object sender, EventArgs e)
        {
            //If range radio checked then show second dateTimePicker, otherwise hide it
            objEndLabel.Visible = objEndDateTimePicker.Visible = objRangeRadio.Checked ? true : false;
        }
    }
}