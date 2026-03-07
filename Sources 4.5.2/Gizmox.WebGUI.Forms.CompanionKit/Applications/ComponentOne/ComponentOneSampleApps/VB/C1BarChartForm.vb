Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    Public Class C1BarChartForm

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Set default theme for wrapper
            mobjWrapper.Theme = "aristo"

        End Sub
        ''' <summary>
        ''' Handles the Click event of the mobjSetButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSetButton_Click(sender As Object, e As EventArgs) Handles mobjSetButton.Click
            'Set Series Label to the new text value
            mobjWrapper.SeriesList(0).Label = mobjTextBox.Text
            mobjWrapper.AspUpdate()
        End Sub
    End Class

End Namespace