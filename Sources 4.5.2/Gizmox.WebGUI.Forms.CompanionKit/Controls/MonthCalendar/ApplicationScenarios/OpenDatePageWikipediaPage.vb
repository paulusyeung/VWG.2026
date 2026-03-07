Namespace CompanionKit.Controls.MonthCalendar.ApplicationScenarios

	Public Class OpenDatePageWikipediaPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		' set the initial value
            Me.mobjDemoMonthCalendar.Value = DateTime.Now
        End Sub

        Public Function GetUrl(objDate As DateTime) As String
            Dim mobjCulture As New Globalization.CultureInfo("en-US")
            Return String.Format("http://en.wikipedia.org/wiki/{0}", objDate.ToString("MMMM_d", mobjCulture))
        End Function

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub OpenDatePageWikipediaPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial pages for HTLMBox
            Me.mobjWikiPageHtmlBox.Url = Me.GetUrl(Me.mobjDemoMonthCalendar.Value)
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the demonstrated MonthCalendar
        ''' </summary>
        Private Sub mobjDemoMonthCalendar_ValueChanged(sender As Object, e As EventArgs) Handles mobjDemoMonthCalendar.ValueChanged
            Me.mobjWikiPageHtmlBox.Url = Me.GetUrl(Me.mobjDemoMonthCalendar.Value)
        End Sub
    End Class

End Namespace