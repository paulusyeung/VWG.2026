Namespace CompanionKit.Concepts.ClientAPI.ScheduleFirstDate

	Public Class ScheduleFirstDatePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub


        ''' <summary>
        ''' Handles the Load event of the ScheduleFirstDatePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub ScheduleFirstDatePage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Set ScheduleBox.FirstDate to Today's date by default
            mobjScheduleBox.FirstDate = Date.Today
        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjButtonBack control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonBack_Click(sender As System.Object, e As System.EventArgs) Handles mobjButtonBack.Click
            VWGClientContext.Current.Invoke("navigateDate", -1)
        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjButtonForward control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonForward_Click(sender As System.Object, e As System.EventArgs) Handles mobjButtonForward.Click
            VWGClientContext.Current.Invoke("navigateDate", 1)
        End Sub
    End Class

End Namespace