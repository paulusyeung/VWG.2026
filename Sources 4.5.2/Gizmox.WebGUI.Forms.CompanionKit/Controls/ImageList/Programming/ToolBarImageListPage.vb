Namespace CompanionKit.Controls.ImageListFolder.Programming

    Public Class ToolBarImageListPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub
        ''' <summary>
        ''' Handles ButtonClick event for the ToolBar
        ''' </summary>
        Private Sub mobjToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs) Handles mobjToolBar.ButtonClick
            ' Show ImageKey property value of the button being clicked
            MessageBox.Show(String.Format("Button ImageKey: {0}", e.Button.ImageKey))
        End Sub
    End Class

End Namespace