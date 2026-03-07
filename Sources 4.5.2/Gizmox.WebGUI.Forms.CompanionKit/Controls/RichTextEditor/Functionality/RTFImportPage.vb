Imports System.IO
Imports Gizmox.WebGUI.Converters.Itenso

Namespace CompanionKit.Controls.RichTextEditor.Functionality

    Public Class RTFImportPage

        Private mstrFilePath As String = String.Empty

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Gets full path to rtf file
            mstrFilePath = AppDomain.CurrentDomain.BaseDirectory + "Controls\RichTextEditor\Functionality\" + mobjComboBox.SelectedItem.ToString()
            'Creates a new stream
            Dim objInputStream As Stream = File.OpenRead(mstrFilePath)
            'Creates formatConverter object
            Dim objFormatConverter As New FormatConverter()
            'Converting rtf to Html and sets result to richTextEditor control
            Dim objOutputStream As Stream = objFormatConverter.Convert(Gizmox.WebGUI.Common.Interfaces.FormatConvertionType.Rtf, Gizmox.WebGUI.Common.Interfaces.FormatConvertionType.Html, objInputStream, Nothing)
            Dim objStreamReader As New StreamReader(objOutputStream)
            Dim strContent As String = objStreamReader.ReadToEnd()
            mobjRichTextEditor.Value = strContent
        End Sub

        ''' <summary>
        ''' Handles the Load event of the RTFImportPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub RTFImportPage_Load(sender As Object, e As EventArgs)
            mobjComboBox.SelectedIndex = 1
        End Sub

    End Class

End Namespace