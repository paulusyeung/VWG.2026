Imports System.Drawing

Namespace CompanionKit.Concepts.ControlBehavior.Selectable

    Public Class SelectablePage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub


       ''' <summary>
        ''' Handles the Click event of the SelectablePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub SelectablePage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            mobjPanel_ControlSelected(Me, New ControlsEventArgs(New Control(-1) {}))
        End Sub

        ''' <summary>
        ''' Handles the ControlSelected event of the mobjPanel control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        Private Sub mobjPanel_ControlSelected(ByVal sender As Object, ByVal e As ControlsEventArgs) Handles Me.ControlSelected
            'For each label inside of a panel
            For Each mobjControl As Control In mobjPanel.Controls
                mobjControl.BackColor = Color.Transparent
            Next

            Dim intLabelsCount As Integer = 0

            For Each objControl As Control In e.Controls
                If objControl.Tag IsNot Nothing Then
                    objControl.BackColor = Color.Lavender
                    intLabelsCount += 1
                End If
            Next

            Dim infoText As String = String.Empty

            If intLabelsCount = 0 Then
                infoText = "Selected: None"
            ElseIf intLabelsCount = 1 Then
                infoText = "Selected: 1 item"
            Else
                infoText = String.Format("Selected: {0} items", intLabelsCount)
            End If

            'Show currently selected label
            mobjSelectedInfo.Text = infoText
        End Sub
    End Class

End Namespace