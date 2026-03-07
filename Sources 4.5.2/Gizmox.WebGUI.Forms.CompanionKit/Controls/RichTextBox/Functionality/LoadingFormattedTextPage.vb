Imports System.IO

Namespace CompanionKit.Controls.RichTextBox.Functionality

    Public Class LoadingFormattedTextPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()


        End Sub

        ''' <summary>
        ''' Handles the Load event of the LoadingFormattedTextPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub LoadingFormattedTextPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strReader As StreamReader = New StreamReader(Context.Server.MapPath("~/Resources/UserData/about.html"))
            mobjRichTextBox.Html = strReader.ReadToEnd()
            strReader.Close()
        End Sub
    End Class

End Namespace