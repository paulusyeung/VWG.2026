Imports System.Collections.Generic

Namespace CompanionKit.Controls.BindingNavigator.Features

    Public Class BindingToDataPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

      ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub BindingToDataPage_Load(sender As Object, e As EventArgs)
            ' Create and fill list
            Dim mobjFriendList As New List(Of [Friend])()
            mobjFriendList.Add(New [Friend]("Michael"))
            mobjFriendList.Add(New [Friend]("Jack"))
            mobjFriendList.Add(New [Friend]("Kate"))
            mobjFriendList.Add(New [Friend]("John"))
            mobjFriendList.Add(New [Friend]("Hugo"))
            ' Set list as data source for BindingSource
            mobjBindingSource.DataSource = mobjFriendList
        End Sub

        ''' <summary>
        ''' Represents 'Friend' BL object
        ''' </summary>
        Public Class [Friend]
            ' Property and field to store
            ' friend's name
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
                Me._name = "New friend"
            End Sub

            ' Returns friend's name
            Public Overrides Function ToString() As String
                Return Me._name
            End Function
        End Class
    End Class
End Namespace