Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace ComponentOneSampleAppsVB

    Public Class C1EventsCalendarForm

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Set default theme for wrapper
            mobjWrapper.Theme = "aristo"

        End Sub
        ''' <summary>
        ''' Fires when Themes is changed.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ThemeChanged(sender As Object, e As EventArgs) Handles mobjRB1.CheckedChanged, mobjRB2.CheckedChanged, mobjRB3.CheckedChanged, mobjRB4.CheckedChanged, mobjRB5.CheckedChanged, mobjRB6.CheckedChanged
            'Change ViewType Label text to reflect current ViewType property
            mobjViewTypeLabel.Text = "ViewType: " + mobjWrapper.ViewType.ToString().ToLower()
            mobjViewTypeLabel.Update()
            'Define RadioButton sender
            Dim mobjRB As RadioButton = TryCast(sender, RadioButton)
            'Set Theme property to an appropriate theme
            If mobjRB.Checked Then
                mobjWrapper.Theme = mobjRB.Text
            End If
        End Sub

    End Class

End Namespace