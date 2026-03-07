
Namespace CompanionKit.Controls.DateTimePicker.Features

    Public Class MinDatePropertyPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the DateTimePicker that
        ''' represents allowed minimum date for the demonstrated DateTimePicker.
        ''' </summary>
        Private Sub mobjMinDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles mobjMinDateTimePicker.ValueChanged
            Dim mobjDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker = TryCast(sender, Gizmox.WebGUI.Forms.DateTimePicker)

            ' Change minimum limit of the DateTimePicker.
            Me.mobjDemoDateTimePicker.MinDate = mobjDateTimePicker.Value
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub MinDatePropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for the DateTimePicker as minimum date of the demonstrated DateTimePicker
            Me.mobjMinDateTimePicker.Value = Me.mobjDemoDateTimePicker.MinDate
        End Sub
    End Class

End Namespace