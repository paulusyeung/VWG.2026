Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    Public Class C1LineChartForm

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
            'Define new random value
            Dim mobjRandom As New Random()
            'Set Y Data to random values
            mobjWrapper.SeriesList(0).Data.Y.Values(0).DoubleValue = 10 + mobjRandom.[Next](40)
            mobjWrapper.SeriesList(0).Data.Y.Values(1).DoubleValue = 10 + mobjRandom.[Next](40)
            mobjWrapper.SeriesList(0).Data.Y.Values(2).DoubleValue = 10 + mobjRandom.[Next](40)
            mobjWrapper.SeriesList(0).Data.Y.Values(3).DoubleValue = 10 + mobjRandom.[Next](40)
            mobjWrapper.SeriesList(0).Data.Y.Values(4).DoubleValue = 10 + mobjRandom.[Next](40)
            'Update the wrapper
            mobjWrapper.AspUpdate()
        End Sub
    End Class

End Namespace