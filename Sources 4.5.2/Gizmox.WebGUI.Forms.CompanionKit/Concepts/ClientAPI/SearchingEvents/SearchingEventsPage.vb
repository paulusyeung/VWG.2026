Imports System.Text
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections.Generic

Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports System.Text.RegularExpressions

Namespace CompanionKit.Concepts.ClientAPI.SearchingEvents
    Public Class SearchingEventsPage

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objButton_Click(sender As Object, e As EventArgs) Handles objButton.Click

            'If start date more than end, then swap their values
            If objStartDateTimePicker.Value > objEndDateTimePicker.Value Then
                Dim objTempDate = objStartDateTimePicker.Value
                objStartDateTimePicker.Value = objEndDateTimePicker.Value
                objEndDateTimePicker.Value = objTempDate
            End If

            'Getting ticks from dateTimePickers
            Dim lngStartDate As Long = objStartDateTimePicker.Value.Ticks
            Dim lngEndDate As Long = objEndDateTimePicker.Value.Ticks

            'Invoking js-function with args
            VWGClientContext.Current.Invoke("getEvents", lngStartDate, lngEndDate)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SearchingEventsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub SearchingEventsPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'Setting  initial values of maskedTextBoxes
            objStartDateTimePicker.Value = DateTime.Now
            objEndDateTimePicker.Value = DateTime.Now.AddDays(2)
            objScheduleBox.FirstDate = DateTime.Now

            'Filling scheduleBox with generated events
            GenerateEvents()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the objViewModeCombo control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objViewModeCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles objViewModeCombo.SelectedIndexChanged
            'Changing view mode according to selected value from combobox
             Select DirectCast(objViewModeCombo.SelectedItem, String)
                Case "Day"
                    objScheduleBox.View = ScheduleBoxView.Day
                    Exit Select
                Case "Week"
                    objScheduleBox.View = ScheduleBoxView.Week
                    Exit Select
                Case "Month"
                    objScheduleBox.View = ScheduleBoxView.Month
                    Exit Select
                Case "FullWeek"
                    objScheduleBox.View = ScheduleBoxView.FullWeek
                    Exit Select
                Case "FullMonth"
                    objScheduleBox.View = ScheduleBoxView.FullMonth
            End Select
        End Sub


        ''' <summary>
        ''' Generates the events.
        ''' </summary>
        Private Sub GenerateEvents()
            'Method fills schedule with events  
            Dim rndValue As New Random()
            'Fills ScheduleBox with events
            AddEvent("Birthday party", Color.Green, rndValue)
            AddEvent("Interview", Color.Orange, rndValue)
            AddEvent("Business meeting", Color.Red, rndValue)
            AddEvent("Wedding", Color.Blue, rndValue)
            AddEvent("Prom", Color.Purple, rndValue)
            AddEvent("Festival", Color.Yellow, rndValue)
        End Sub


        ''' <summary>
        ''' Adds the event.
        ''' </summary>
        ''' <param name="strSubject">The STR subject.</param>
        ''' <param name="objColor">Color of the obj.</param>
        ''' <param name="rndValue">The RND value.</param>
        Private Sub AddEvent(strSubject As String, objColor As Color, rndValue As Random)
            'get random day within current month 
            Dim datStartDate As DateTime = RandomDay(rndValue)
            'adds event to schedule
            objScheduleBox.Events.Add(strSubject, datStartDate, GetRandomEndDate(datStartDate))
            'Set event's color
            objScheduleBox.Events(objScheduleBox.Events.Count - 1).BackgroundColor = objColor
        End Sub


        ''' <summary>
        ''' Randoms the day.
        ''' </summary>
        ''' <param name="random">The random.</param>
        ''' <returns>Returns random date within month</returns>
        Private Function RandomDay(random As Random) As DateTime
            Dim datNow As DateTime = DateTime.Now
            Dim intDaysInMonth As Integer = DateTime.DaysInMonth(datNow.Year, datNow.Month)
            Dim intCurrentDay As Integer = datNow.Day
            Return datNow.AddDays(random.[Next](-intCurrentDay, intDaysInMonth - intCurrentDay))
        End Function


        ''' <summary>
        ''' Gets the random end date.
        ''' </summary>
        ''' <param name="datStartDate">The dat start date.</param>
        ''' <returns>Returns the date of randomly increased on few days (1-5)</returns>
        Private Function GetRandomEndDate(datStartDate As DateTime) As DateTime
            Return datStartDate.AddDays(New Random().[Next](1, 5))
        End Function

        ''' <summary>
        ''' Handles the CheckedChanged event of the objRangeRadio control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub objRangeRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles objRangeRadio.CheckedChanged
            'If range radio checked then show second dateTimePicker, otherwise hide it
            If (objRangeRadio.Checked) Then
                objEndLabel.Visible = True
            Else
                objEndLabel.Visible = False
            End If
        End Sub
    End Class
End Namespace