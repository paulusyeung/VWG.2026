Namespace CompanionKit.Controls.ComboBox.Features
	Public Class FormComboBox
		Inherits Gizmox.WebGUI.Forms.ComboBox
		' Methods
		''' <summary>
		''' Initializes a new instance of the <see cref="FormComboBox"/> class.
		''' </summary>
		''' <remarks></remarks>
		Public Sub New()
			MyBase.DropDownStyle = ComboBoxStyle.DropDown
		End Sub

		''' <summary>
		''' Gets the custom form to display as drop down
		''' </summary>
		''' <returns></returns>
		''' <remarks></remarks>
        Protected Overrides Function GetCustomDropDown() As WebGUI.Forms.Form
            Me._comboBoxForm.DialogResult = DialogResult.None
            Me._comboBoxForm.Width = Math.Max(MyBase.Width, Me._comboBoxForm.Width)
            Return Me._comboBoxForm
        End Function


		' Properties
		''' <summary>
		''' Gets a value indicating whether this instance has a custom drop down.
		''' </summary>
		''' <value><c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.</value>
		''' <returns></returns>
		''' <remarks></remarks>
		Protected Overrides ReadOnly Property IsCustomDropDown() As Boolean
			Get
				Return True
			End Get
		End Property


		' Fields
		Private _comboBoxForm As ComboBoxForm = New ComboBoxForm
	End Class
End Namespace

