Imports System.Text.RegularExpressions

Namespace CompanionKit.Concepts.ClientAPI.ScheduleBoxEvents

    Public Class ScheduleBoxEventsPage

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

            'Putting ticks from dateTimePickers into variables
            Dim lngStartDate As Long = objStartDateTimePicker.Value.Ticks
            Dim lngEndDate As Long = objEndDateTimePicker.Value.Ticks

            'If fields are not empty, then invoke js-function
            If Not String.IsNullOrEmpty(objSubjectTextBox.Text) AndAlso Not String.IsNullOrEmpty(objTagTextBox.Text) Then
                'Invoking js-function with arguments
                VWGClientContext.Current.Invoke("addEvent", lngStartDate, lngEndDate)
            Else
                MessageBox.Show("Please fill all required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ScheduleBoxEventsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ScheduleBoxEventsPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'Setting  initial values of dateTimePickers
            objStartDateTimePicker.Value = DateTime.Now
            objEndDateTimePicker.Value = DateTime.Now.AddHours(2)
            objScheduleBox.FirstDate = DateTime.Now
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the viewModeCombo control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objViewModeCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles objViewModeCombo.SelectedIndexChanged
            'Updating schedule's source, after view's mode is changed (VB: Special flag serves for prevent premature triggering)
            If (blnLoadFlag) Then VWGClientContext.Current.Invoke("updateSchedule", objViewModeCombo.SelectedItem)
        End Sub
    End Class

End Namespace