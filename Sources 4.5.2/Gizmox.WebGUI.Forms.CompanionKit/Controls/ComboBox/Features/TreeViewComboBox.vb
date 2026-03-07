Namespace CompanionKit.Controls.ComboBox.Features

	Public Class TreeViewComboBox
		Inherits Gizmox.WebGUI.Forms.ComboBox
		' Events
		''' <summary>
		''' Occurs when selected item changed.
		''' </summary>
		''' <remarks></remarks>
		Public Shadows Event SelectedItemChanged As EventHandler

		' Methods
		''' <summary>
		''' Initializes a new instance of the <see cref="TreeViewComboBox"/> class.
		''' </summary>
		''' <remarks></remarks>
		Public Sub New()
			Me._treeViewForm = New TreeViewComboBoxForm
			AddHandler Me._treeViewForm.Closed, New EventHandler(AddressOf Me.OnFormClosed)
			MyBase.DropDownStyle = ComboBoxStyle.DropDown
		End Sub

		''' <summary>
		''' Gets the custom form to display as drop down
		''' </summary>
		''' <returns></returns>
		''' <remarks></remarks>
        Protected Overrides Function GetCustomDropDown() As WebGUI.Forms.Form
            Me._treeViewForm.DialogResult = DialogResult.None
            Me._treeViewForm.Width = Math.Max(MyBase.Width, Me._treeViewForm.Width)
            Return Me._treeViewForm
        End Function

		''' <summary>
		''' Called when form is closed.
		''' </summary>
		''' <param name="sender">The sender.</param>
		''' <param name="e">instance containing the event data.</param>
		''' <remarks></remarks>
		Private Sub OnFormClosed(ByVal sender As Object, ByVal e As EventArgs)
            If (DirectCast(sender, WebGUI.Forms.Form).DialogResult = DialogResult.OK) Then
                If (Not Me.SelectedItem Is Nothing) Then
                    Me.Text = Me.SelectedItem.Text
                End If
                RaiseEvent SelectedItemChanged(Me, EventArgs.Empty)
            End If
		End Sub


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

		''' <summary>
		''' Gets the collection of parent node contained within the TreeView.
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Overloads ReadOnly Property Items() As TreeNodeCollection
			Get
				Return Me._treeViewForm.Tree.Nodes
			End Get
		End Property

		''' <summary>
		''' Gets the currently selected item index.
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Overloads Property SelectedItem() As TreeNode
			Get
				Return Me._treeViewForm.Tree.SelectedNode
			End Get
			Set(ByVal value As TreeNode)
				Me._treeViewForm.Tree.SelectedNode = value
			End Set
		End Property


		' Fields
		''' <summary>
		''' The form is used as custom DropDown control.
		''' </summary>
		''' <remarks></remarks>
		Private _treeViewForm As TreeViewComboBoxForm = Nothing
	End Class

End Namespace


