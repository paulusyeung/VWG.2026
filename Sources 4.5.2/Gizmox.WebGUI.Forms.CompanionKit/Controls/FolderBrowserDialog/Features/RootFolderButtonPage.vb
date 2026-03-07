Namespace CompanionKit.Controls.FolderBrowserDialog.Features

    Public Class RootFolderButtonPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
           ' Fill ComboBox with Environment.SpecialFolder enumerator items
            mobjRootFolderComboBox.DataSource = [Enum].GetValues(GetType(Environment.SpecialFolder))
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' </summary>
        Private Sub mobjBrowseButton_Click(sender As Object, e As EventArgs) Handles mobjBrowseButton.Click
            ' Select root folder for FolderBrowserDialog from ComboBox selected item
            mobjFolderBrowserDialog.RootFolder = DirectCast(mobjRootFolderComboBox.SelectedItem, Environment.SpecialFolder)
            ' Call dialog with an event handler as a parameter
            mobjFolderBrowserDialog.ShowDialog(AddressOf mobjFolderBrowserDialog_Closed)
        End Sub

        ''' <summary>
        ''' These event handler calls when FolderBrowserDialog windows closed
        ''' </summary>
        Private Sub mobjFolderBrowserDialog_Closed(sender As Object, e As EventArgs)
            ' Get Gizmox.WebGUI.Forms.FolderBrowserDialog object
            Dim mobjSenderDialog As Gizmox.WebGUI.Forms.FolderBrowserDialog = DirectCast(sender, Gizmox.WebGUI.Forms.FolderBrowserDialog)

            If mobjSenderDialog IsNot Nothing Then
                ' Set SelectedPath value of the FolderBrowserDialog as a text for label
                mobjSelectedDirectoryLabel.Text = String.Format("Selected path: ""{0}""", mobjSenderDialog.SelectedPath)
            End If
        End Sub
    End Class
End Namespace