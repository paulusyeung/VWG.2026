Namespace CompanionKit.Controls.Utils
	Public Class Customer
		' Methods
		Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal lastName As String, ByVal favoriteColor As Drawing.Color)
			Me.ID = id
			Me.FirstName = firstName
			Me.LastName = lastName
			Me.FavoriteColor = favoriteColor
		End Sub


		' Properties
		Public Property FavoriteColor() As Drawing.Color
			Get
				Return Me._favoriteColor
			End Get
			Set(ByVal value As Drawing.Color)
				Me._favoriteColor = value
			End Set
		End Property

		Public Property FirstName() As String
			Get
				Return Me._firstName
			End Get
			Set(ByVal value As String)
				Me._firstName = value
			End Set
		End Property

		Public Property Photo() As Global.Gizmox.WebGUI.Common.Resources.ResourceHandle
			Get
				Return Me._photo
			End Get
			Set(ByVal value As Global.Gizmox.WebGUI.Common.Resources.ResourceHandle)
				Me._photo = value
			End Set
		End Property

		Public ReadOnly Property FullName() As String
			Get
				Return String.Format("{0} {1}", Me._firstName, IIf((Me._lastName Is Nothing), "", Me._lastName))
			End Get
		End Property

		Public Property ID() As Integer
			Get
				Return Me._id
			End Get
			Set(ByVal value As Integer)
				Me._id = value
			End Set
		End Property

		Public Property LastName() As String
			Get
				Return Me._lastName
			End Get
			Set(ByVal value As String)
				Me._lastName = value
			End Set
		End Property


		' Fields
		Private _favoriteColor As Drawing.Color
		Private _firstName As String
		Private _photo As Global.Gizmox.WebGUI.Common.Resources.ResourceHandle
		Private _id As Integer
		Private _lastName As String
	End Class
End Namespace

