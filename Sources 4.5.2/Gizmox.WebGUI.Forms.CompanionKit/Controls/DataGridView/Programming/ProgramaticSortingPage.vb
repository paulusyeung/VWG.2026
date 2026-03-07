Namespace CompanionKit.Controls.DataGridView.Programming

	Public Class ProgramaticSortingPage

		Private _sortColumn As Integer = 0
		Private _sortOrder As SortOrder = SortOrder.Ascending
        Private _stringComparer As DataGridViewItemComparer = Nothing
        Private _numericComparer As DataGridViewItemComparer = Nothing


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub ProgramaticSortingPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' compare by number
            Me._numericComparer = New NumericComparer(0, SortOrder.Ascending)

            ' compare by text
            Me._stringComparer = New StringComparer(1, SortOrder.Ascending, CaseInsensitiveComparer.Default)
            ' Fill up DataGridView
            Dim i As Integer
            For i = 1 To 19
                Me.mobjDataGridView.Rows.Add((20 - i).ToString(), String.Format("User{0}", i), _
        String.Format("user{0}@gmail.com", i), _
        String.Format("8-800-236589{0}", i), "Franklin", _
        String.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064")
            Next i
        End Sub

        Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs) Handles mobjDataGridView.ColumnHeaderMouseClick


            ' Call the sort method to manually sort.
            Me.mobjDataGridView.Sort(Me.GetComparatorForColumn(e.ColumnIndex))

        End Sub

        ''' <summary>
        ''' Gets comparator for the specified column
        ''' </summary>
        ''' <param name="columnIndex"></param>
        Private Function GetComparatorForColumn(ByVal columnIndex As Integer) As DataGridViewItemComparer
            Dim itemComparer As DataGridViewItemComparer = Nothing
            Select Case columnIndex
				Case 0
					itemComparer = Me._numericComparer
					Exit Select
                Case Else
                    itemComparer = Me._stringComparer
                    Exit Select
            End Select
            itemComparer.Column = columnIndex
            ' Determine whether the column is the same as the last column clicked.
            If (columnIndex <> Me._sortColumn) Then
                ' Set the sort column to the new column.
                Me._sortColumn = columnIndex
                ' Set the sort order to ascending by default.
                Me._sortOrder = SortOrder.Ascending
                ' Determine what the last sort order was and change it.
            ElseIf (Me._sortOrder = SortOrder.Ascending) Then
                Me._sortOrder = SortOrder.Descending
            Else
                Me._sortOrder = SortOrder.Ascending
            End If
            itemComparer.Order = Me._sortOrder
            Return itemComparer
        End Function


        ''' <summary>
        '''   Implements comparator for the custom sorting of items by columns.
        ''' </summary>
        Public MustInherit Class DataGridViewItemComparer
            Implements Global.System.Collections.IComparer

            ' Methods
            Public Sub New(ByVal Column As Integer, ByVal order As SortOrder)
                Me.Column = Column
                Me.Order = order
            End Sub

            ' Methods
            Public MustOverride Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare


            ' Properties
            Public WriteOnly Property Column() As Integer
                Set(ByVal value As Integer)
                    Me._column = value
                End Set
            End Property

            Public WriteOnly Property Order() As SortOrder
                Set(ByVal value As SortOrder)
                    Me._order = value
                End Set
            End Property


            ' Fields
            Protected _column As Integer = 0
            Protected _order As SortOrder = SortOrder.Ascending
        End Class

        ''' <summary>
        ''' Implements a class for comparison of DataGridView items
        ''' according to a numeric data in the given column
        ''' </summary>
        ''' <remarks></remarks>
        Public Class NumericComparer
            Inherits DataGridViewItemComparer
            ' Methods
            Public Sub New(ByVal Column As Integer, ByVal order As SortOrder)
                MyBase.New(Column, order)
            End Sub

            Public Overrides Function [Compare](ByVal x As Object, ByVal y As Object) As Integer
                Dim dataGridViewRow1 As DataGridViewRow = DirectCast(x, DataGridViewRow)
                Dim dataGridViewRow2 As DataGridViewRow = DirectCast(y, DataGridViewRow)
                Dim returnVal As Integer = (Integer.Parse(dataGridViewRow1.Cells.Item(MyBase._column).Value.ToString) - _
                                            Integer.Parse(dataGridViewRow2.Cells.Item(MyBase._column).Value.ToString))
                Return IIf((MyBase._order = SortOrder.Ascending), returnVal, (returnVal * -1))
            End Function

        End Class

        ''' <summary>
        ''' Implements a class for comparison of DataGridView items
        ''' according to a literal data in the given column
        ''' by the given IComparer object
        ''' </summary>
        ''' <remarks></remarks>
        Public Class StringComparer
            Inherits DataGridViewItemComparer
            ' Methods
            Public Sub New(ByVal Column As Integer, ByVal order As SortOrder, ByVal StringComparer As IComparer)
                MyBase.New(Column, order)
                Me.mobjComparer = Nothing
                Me.mobjComparer = StringComparer
            End Sub

            Public Overrides Function [Compare](ByVal x As Object, ByVal y As Object) As Integer
                Dim dataGridViewRow1 As DataGridViewRow = DirectCast(x, DataGridViewRow)
                Dim dataGridViewRow2 As DataGridViewRow = DirectCast(y, DataGridViewRow)
                Dim returnVal As Integer = Me.mobjComparer.Compare(dataGridViewRow1.Cells.Item(MyBase._column).Value.ToString, _
                                                                   dataGridViewRow2.Cells.Item(MyBase._column).Value.ToString)
                Return IIf((MyBase._order = SortOrder.Ascending), returnVal, (returnVal * -1))
            End Function


            ' Fields
            Private mobjComparer As IComparer
        End Class

	End Class

End Namespace
