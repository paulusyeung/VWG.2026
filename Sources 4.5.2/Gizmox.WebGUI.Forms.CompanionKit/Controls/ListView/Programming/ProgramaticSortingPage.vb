Namespace CompanionKit.Controls.ListView.Programming

	Public Class ProgramaticSortingPage

		Private Comparers As ListViewComparer() = Nothing


		Public Sub New()
			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			' compare users by name (case insensitive)
			' compare by ID
			' compare by phone (case insensitive)
			Comparers = New ListViewComparer() _
			{ _
			 New StringComparer(0, SortOrder.Ascending, CaseInsensitiveComparer.Default), _
			 New NumericComparer(1, SortOrder.Ascending), _
			 New StringComparer(2, SortOrder.Ascending, CaseInsensitiveComparer.Default) _
			}

			' Set a custom implemented sorter
            Me.mobjListView.ListViewItemSorter = Comparers(0)

			' Populate the ListView
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User A", "6", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"user B", "7", "8-800-9513546"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User C", "8", "8-800-8524563"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"user D", "9", "8-800-9874613"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User E", "10", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"user F", "12", "8-800-9513546"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User G", "11", "8-800-8524563"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"user H", "1", "8-800-9874613"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User Y", "4", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"user Z", "5", "8-800-9513546"}))

			'sort the items on initialization
            Me.mobjListView.Sort()
		End Sub

        ''' <summary>
        ''' Handles the ColumnClick event of the mobjListView control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="global.Gizmox.WebGUI.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_ColumnClick(ByVal sender As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.ColumnClickEventArgs) Handles mobjListView.ColumnClick

            ' pick the column's comparer
            Dim objComparer As ListViewComparer = Comparers(e.Column)

            ' set the comparer to the listview
            Me.mobjListView.ListViewItemSorter = objComparer

            ' change the order to opposite one
            objComparer.Order = IIf(objComparer.Order = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)

            ' Call the sort method
            Me.mobjListView.Sort()
        End Sub

	End Class

	''' <summary>
	''' Implements a base class for comparison of ListView items per column
	''' </summary>
	Public MustInherit Class ListViewComparer
		Implements System.Collections.IComparer

		' Methods
		Public Sub New(ByVal Column As Integer, ByVal Order As SortOrder)
			Me.Column = Column
			Me.Order = Order
		End Sub

		' Properties
		Public Property Column() As Integer
			Get
				Return Me._column
			End Get
			Set(ByVal value As Integer)
				Me._column = value
			End Set
		End Property

		Public Property Order() As SortOrder
			Get
				Return Me._order
			End Get
			Set(ByVal value As SortOrder)
				Me._order = value
			End Set
		End Property


		' Fields
		Protected _column As Integer
		Protected _order As SortOrder

		Public MustOverride Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

	End Class

	''' <summary>
	''' Implements a class for comparison of listview items
	''' according to a numeric data in the given column
	''' </summary>
	Public Class NumericComparer
		Inherits ListViewComparer
		' Methods
		Public Sub New(ByVal Column As Integer, ByVal order As SortOrder)
			MyBase.New(Column, order)
		End Sub

		Public Overrides Function Compare(ByVal x As Object, ByVal y As Object) As Integer
			Dim returnVal As Integer = (Integer.Parse(DirectCast(x, ListViewItem).SubItems.Item(MyBase.Column).Text) - Integer.Parse(DirectCast(y, ListViewItem).SubItems.Item(MyBase.Column).Text))
			Return IIf((MyBase.Order = SortOrder.Ascending), returnVal, (returnVal * -1))
		End Function

	End Class

	''' <summary>
	''' Implements a class for comparison of listview items
	''' according to a literal data in the given column
	''' by the given IComparer object
	''' </summary>		
	Public Class StringComparer
		Inherits ListViewComparer
		' Methods
		Public Sub New(ByVal Column As Integer, ByVal order As SortOrder, ByVal StringComparer As IComparer)
			MyBase.New(Column, order)
			Me.mobjComparer = Nothing
			Me.mobjComparer = StringComparer
		End Sub

		Public Overrides Function Compare(ByVal x As Object, ByVal y As Object) As Integer
			Dim returnVal As Integer = Me.mobjComparer.Compare(DirectCast(x, ListViewItem).SubItems.Item(MyBase.Column).Text, DirectCast(y, ListViewItem).SubItems.Item(MyBase.Column).Text)
			Return IIf((MyBase.Order = SortOrder.Ascending), returnVal, (returnVal * -1))
		End Function


		' Fields
		Private mobjComparer As IComparer
	End Class

End Namespace