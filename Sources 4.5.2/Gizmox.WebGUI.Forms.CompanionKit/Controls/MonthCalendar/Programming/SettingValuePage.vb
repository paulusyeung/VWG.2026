Namespace CompanionKit.Controls.MonthCalendar.Programming

	Public Class SettingValuePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the Button that set date for the select MonthCalendar
        ''' </summary>
        Private Sub mobjSetDateButton_Click(sender As Object, e As EventArgs) Handles mobjSetDateButton.Click
            If Me.mobjEnableMonthCalendarRadioButton.Checked Then
                ' Set date of the DateTimePicker for the enable MonthCalendar
                Me.mobjEnableMonthCalendar.Value = Me.mobjSelectDateDateTimePicker.Value
            Else
                ' Set date of the DateTimePicker for the disable MonthCalendar
                Me.mobjDisableMonthCalendar.Value = Me.mobjSelectDateDateTimePicker.Value
            End If
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub SettingValuePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set checked state of the Radiobutton that indicates whether selected date will be set for enable MonthCalendar
            Me.mobjEnableMonthCalendarRadioButton.Checked = True
        End Sub
    End Class

End Namespace