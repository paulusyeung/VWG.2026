Namespace CompanionKit.Controls.ProgressBar.Functionality

	Public Class PerformStepPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub PerformStepPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' set initial step of the ProgressBar in the NumericUpDown that
            ' change increment step of the ProgressBar
            Me.mobjStepNumericUpDown.Value = Me.mobjDemoProgressBar.[Step]
        End Sub

        ''' <summary>
        ''' Handle Tick event of the timer that increase value of the ProgressBars.
        ''' </summary>
        Private Sub mobjIncrementTimer_Tick(sender As Object, e As EventArgs) Handles mobjIncrementTimer.Tick
            ' Validate new value of the the demonstrated ProgressBar pay attention on the set range.
            If Me.mobjDemoProgressBar.Value + Me.mobjDemoProgressBar.[Step] >= Me.mobjDemoProgressBar.Maximum Then
                Me.mobjDemoProgressBar.Value = Me.mobjDemoProgressBar.Minimum
            End If

            ' Increase value of the demonstrated ProgressBar on 
            ' a value that is set in the ProgressBar.Step property.
            Me.mobjDemoProgressBar.PerformStep()
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the ProgressBar control
        ''' </summary>
        Private Sub mobjStepNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjStepNumericUpDown.ValueChanged
            ' Change step of the demonstrated Progressbar to new value of the NumericUpDown
            Me.mobjDemoProgressBar.[Step] = Decimal.ToInt16(Me.mobjStepNumericUpDown.Value)
        End Sub
    End Class

End Namespace