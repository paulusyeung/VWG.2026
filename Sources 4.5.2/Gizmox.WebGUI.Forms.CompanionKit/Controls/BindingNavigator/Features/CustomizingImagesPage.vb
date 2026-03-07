Namespace CompanionKit.Controls.BindingNavigator.Features

	Public Class CustomizingImagesPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' All custom images are containing inside the ImageList

            ' Set image for 'Move first' button
            mobjBindingNavigator.Buttons(0).ImageIndex = 0
            ' Set image for 'Move previous' button
            mobjBindingNavigator.Buttons(1).ImageIndex = 1
            ' Set image for 'Move next' button
            mobjBindingNavigator.Buttons(5).ImageIndex = 2
            ' Set image for 'Move last' button
            mobjBindingNavigator.Buttons(6).ImageIndex = 3
            ' Set image for 'Add new' button
            mobjBindingNavigator.Buttons(8).ImageIndex = 4
            ' Set image for 'Remove' button
            mobjBindingNavigator.Buttons(9).ImageIndex = 5

            ' Create and fill list
            Dim itemList As New ArrayList()
            itemList.Add(New Item("Item 1"))
            itemList.Add(New Item("Item 2"))
            itemList.Add(New Item("Item 3"))
            itemList.Add(New Item("Item 4"))
            itemList.Add(New Item("Item 5"))
            ' Set list as data source for BindingSource
            mobjBindingSource.DataSource = itemList
        End Sub

        ''' <summary>
        ''' Represents 'Item' BL object
        ''' </summary>
        Public Class Item
            ' Property and field to store
            ' item name
            Private _name As String
            Public Property Name() As String
                Get
                    Return Me._name
                End Get
                Set(value As String)
                    Me._name = value
                End Set
            End Property

            Public Sub New(name As String)
                Me.Name = name
            End Sub

            Public Sub New()
                Me._name = "New item"
            End Sub

            ' Returns item name
            Public Overrides Function ToString() As String
                Return Me._name
            End Function
        End Class

	End Class

End Namespace