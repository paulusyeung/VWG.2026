Namespace CompanionKit.Controls.ListView.Features

    ''' <summary>
    ''' 
    ''' </summary>
    Public Class LabelEditPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub
        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjEditCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjEditCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjEditCheck.CheckedChanged
            'Change ListView.LabelEdit property
            mobjListView.LabelEdit = mobjEditCheck.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the RB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub RB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjDetailsRB.CheckedChanged, mobjListRB.CheckedChanged, mobjLargeIconRB.CheckedChanged, mobjSmallIconRB.CheckedChanged
            'Set ListView.View property to selected view
            If mobjDetailsRB.Checked Then
                mobjListView.View = View.Details
            ElseIf mobjListRB.Checked Then
                mobjListView.View = View.List
            ElseIf mobjSmallIconRB.Checked Then
                mobjListView.View = View.SmallIcon
            Else
                mobjListView.View = View.LargeIcon
            End If
        End Sub
    End Class

End Namespace