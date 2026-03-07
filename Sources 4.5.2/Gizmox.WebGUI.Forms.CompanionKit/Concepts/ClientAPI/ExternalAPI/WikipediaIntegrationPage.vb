Imports Gizmox.WebGUI.Forms.Client

Namespace CompanionKit.Concepts.ClientAPI.ExternalAPI

    Public Class WikipediaIntegrationPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()



        End Sub

        ''' <summary>
        ''' Handles the ClientEnterKeyDown event of the mobjQueryTextBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjQueryTextBox_ClientEnterKeyDown(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjQueryTextBox.ClientEnterKeyDown
            SearchWikipedia(objArgs.Context)
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjSearchButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjSearchButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjSearchButton.ClientClick
            SearchWikipedia(objArgs.Context)
        End Sub

        ''' <summary>
        ''' Searches the wikipedia.
        ''' </summary>
        ''' <param name="objClientContext">The obj client context.</param>
        Private Sub SearchWikipedia(objClientContext As ClientContext)
            objClientContext.Invoke("invokeSearchhWikiPedia", mobjQueryTextBox.ID, mobjResultHtmlBox.ID)
        End Sub
    End Class

End Namespace