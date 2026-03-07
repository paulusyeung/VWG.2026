Imports System.Drawing
Imports System.ComponentModel

Namespace CompanionKit.Controls.PropertyGrid.Functionality

	''' <summary>
	''' The enum to use to demostrate editing of a property in the PropertyGrid
	''' </summary>
	Public Enum DemoEnum
		EnumValueA = 1
		EnumValueB = 2
		EnumValueC = 4
	End Enum

	''' <summary>
	''' A demo object to use to demostrate editing of a property 
	''' in the PropertyGrid.
	''' </summary>
    <TypeConverter(GetType(DemoObjectConverter))> _
	Public Class DemoObject


		' Fields
		Private menmColor As Color = Color.LawnGreen
		Private menmValueD As DemoEnum = DemoEnum.EnumValueA
		Private mintValueA As Integer = 1
		Private mintValueB As Integer = 2
		Private mintValueC As Integer = 3
		Private mstrValueA As String = "Initial A"
		Private mstrValueB As String = "Initial B"
		Private mstrValueC As String = "Initial C"

		' Properties
		<Description("The property with enum type - Color"), _
		   Category("Enums")> _
		Public Property Color() As Color
			Get
				Return Me.menmColor
			End Get
			Set(ByVal value As Color)
				Me.menmColor = value
			End Set
		End Property

		<Description("The property with enum type"), _
		Category("Enums")> _
		Public Property EnumProperty() As DemoEnum
			Get
				Return Me.menmValueD
			End Get
			Set(ByVal value As DemoEnum)
				Me.menmValueD = value
			End Set
		End Property

		<Category("Strings"), _
		Description("String - 'A' Read/Write property in Strings category")> _
		Public Property StringValueA() As String
			Get
				Return Me.mstrValueA
			End Get
			Set(ByVal value As String)
				Me.mstrValueA = value
			End Set
		End Property

		<Category("Strings"), _
		Description("String - 'B' Read/Write property in Strings category")> _
		Public Property StringValueB() As String
			Get
				Return Me.mstrValueB
			End Get
			Set(ByVal value As String)
				Me.mstrValueB = value
			End Set
		End Property

		<Category("Advanced"), _
		Description("String - 'C' Read/Write property in Advanced category")> _
		Public Property StringValueC() As String
			Get
				Return Me.mstrValueC
			End Get
			Set(ByVal value As String)
				Me.mstrValueC = value
			End Set
		End Property

		<Description("Integer ReadOnly property"), _
		Browsable(True), _
		[ReadOnly](True), _
		Category("Int Properties")> _
		Public Property ValueA() As Integer
			Get
				Return Me.mintValueA
			End Get
			Set(ByVal value As Integer)
				Me.mintValueA = value
			End Set
		End Property

		<Category("Int Properties"), _
		Description("Integer Read/Write property")> _
		Public Property ValueB() As Integer
			Get
				Return Me.mintValueB
			End Get
			Set(ByVal value As Integer)
				Me.mintValueB = value
			End Set
		End Property

		<Category("Advanced"), _
		Description("Integer Read/Write property in Advanced category")> _
		Public Property ValueC() As Integer
			Get
				Return Me.mintValueC
			End Get
			Set(ByVal value As Integer)
				Me.mintValueC = value
			End Set
		End Property


		''' <summary>
		''' String presentation of DemoObject
		''' </summary>
		Public Overrides Function ToString() As String
			Return String.Format(vbCrLf + "StringValueA:{0}" + vbCrLf + "StringValueB:{1}" + vbCrLf _
			  + "StringValueC:{2}" + vbCrLf + "ValueA:{3}" + vbCrLf + "ValueB:{4}" + vbCrLf _
			  + "ValueC:{5}" + vbCrLf + "Color:{6}" + vbCrLf + "EnumProperty:{7}" + vbCrLf, _
			  New Object() {Me.StringValueA, Me.StringValueB, Me.StringValueC, Me.ValueA, Me.ValueB, _
			  Me.ValueC, Me.Color.ToString, Me.EnumProperty.ToString})
		End Function
	End Class
End Namespace

