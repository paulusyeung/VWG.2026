Imports System.Drawing

Namespace CompanionKit.Controls.Form.Features

    Public Class MinimumSizePage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the objOpenDialogButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjOpenDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenDialogButton.Click
            'Creates and displays MinimumSizeForm instance
            Dim mobjDialog As New MinimumSizeForm()
            mobjDialog.MinimumSize = Me.MinimumSize
            mobjDialog.mobjBorderPanel.Size = Me.MinimumSize
            mobjDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the objWidthNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjWidthNUD_ValueChanged(sender As Object, e As EventArgs) Handles mobjWidthNUD.ValueChanged
            'Applies Minimum Height of form
            Me.MinimumSize = New Size(CInt(mobjWidthNUD.Value), Me.MinimumSize.Height)
            'Updates panel's size according to form's MinimumSize
            mobjBorderPanel.Size = Me.MinimumSize
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the objHeightNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjHeightNUD_ValueChanged(sender As Object, e As EventArgs) Handles mobjHeightNUD.ValueChanged
            'Applies Minimum Width of form
            Me.MinimumSize = New Size(Me.MinimumSize.Width, CInt(mobjHeightNUD.Value))
            'Updates panel's size according to form's MinimumSize
            mobjBorderPanel.Size = Me.MinimumSize
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objBorderButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjBorderButton_Click(sender As Object, e As EventArgs) Handles mobjBorderButton.Click
            'Gets visibility state of panel
            Dim IsBorderVisible As Boolean = mobjBorderPanel.Visible
            'If Border is invisible - show it
            If Not IsBorderVisible Then
                mobjBorderPanel.Visible = True
                mobjBorderButton.Text = "Hide minimum size border"
            Else
                'If visible - hide it
                mobjBorderPanel.Visible = False
                mobjBorderButton.Text = "Show minimum size border"
            End If
        End Sub
    End Class

End Namespace