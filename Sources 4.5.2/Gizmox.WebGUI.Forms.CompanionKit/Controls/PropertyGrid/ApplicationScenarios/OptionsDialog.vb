Public Class OptionsDialog


    Public Sub New()

        ' This call is required by the Visual WebGui UserControl Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal optionObject As Object)
        Me.New()
        Me.optionsPropertyGrid.SelectedObject = optionObject
    End Sub

End Class
