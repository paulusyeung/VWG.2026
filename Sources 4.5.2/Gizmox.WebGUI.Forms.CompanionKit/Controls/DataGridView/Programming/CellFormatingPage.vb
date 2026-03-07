Imports System.Drawing

Namespace CompanionKit.Controls.DataGridView.Programming

	Public Class CellFormatingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        Private Sub CellFormatingPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up colors ComboBox with known Colors.
            Dim marrKnownColors As KnownColor() = DirectCast([Enum].GetValues(GetType(KnownColor)), KnownColor())
            Dim marrColors As Color() = New Color(marrKnownColors.Length - 1) {}
            For i As Integer = 0 To marrKnownColors.Length - 1
                marrColors(i) = Color.FromKnownColor(marrKnownColors(i))
            Next

            Me.mobjForeColorComboBox.DataSource = marrColors
            Me.mobjForeColorComboBox.ColorMember = "Name"
            Me.mobjForeColorComboBox.DisplayMember = "Name"

            Me.mobjBackColorComboBox.DataSource = marrColors.Clone()
            Me.mobjBackColorComboBox.ColorMember = "Name"
            Me.mobjBackColorComboBox.DisplayMember = "Name"

            'Fill up DataGridView
            For i As Integer = 1 To 19
                Me.mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), String.Format("8-800-236589{0}", i), "Franklin", String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                 "Tennessee", "37064")
            Next


        End Sub

        ''' <summary>
        ''' Handles CellFormatting event for a DataGridView.
        ''' Updates text of the informed label with names of new colors.
        ''' </summary>
        Private Sub mobjDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles mobjDataGridView.CellFormatting
            ' Update text of the informed label with names of new colors.
            If (e.RowIndex > -1 AndAlso e.RowIndex < Me.mobjDataGridView.Rows.Count) AndAlso (e.ColumnIndex > -1 AndAlso e.ColumnIndex < mobjDataGridView.Columns.Count) Then
                Dim selectedCell As DataGridViewCell = Me.mobjDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)

                Me.mobjInformLabel.Text = String.Format("Cell[{0},{1}] has foreground {2} and background {3} colors.", e.RowIndex, e.ColumnIndex, IIf(Not selectedCell.Style.ForeColor.IsEmpty, selectedCell.Style.ForeColor.Name, Me.mobjDataGridView.DefaultCellStyle.ForeColor.Name), IIf(Not selectedCell.Style.BackColor.IsEmpty, selectedCell.Style.BackColor.Name, Me.mobjDataGridView.DefaultCellStyle.BackColor.Name))
            End If
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event for ComboBox.
        ''' Changes foreground color for selected cells.
        ''' </summary>
        Private Sub mobjForeColorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjForeColorComboBox.SelectedIndexChanged

            ' Changes foreground color for selected cells.
            For i As Integer = 0 To Me.mobjDataGridView.SelectedCells.Count - 1
                Dim mobjCell As DataGridViewCell = Me.mobjDataGridView.SelectedCells(i)
                mobjCell.Style.ForeColor = DirectCast(Me.mobjForeColorComboBox.SelectedItem, Color)
            Next
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event for ComboBox.
        ''' Changes background color for selected cells.
        ''' </summary>
        Private Sub mobjBackColorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjBackColorComboBox.SelectedIndexChanged
            ' Change background color for selected cells.
            For i As Integer = 0 To Me.mobjDataGridView.SelectedCells.Count - 1
                Dim mobjCell As DataGridViewCell = Me.mobjDataGridView.SelectedCells(i)
                mobjCell.Style.BackColor = DirectCast(Me.mobjBackColorComboBox.SelectedItem, Color)
            Next
        End Sub

        ''' <summary>
        ''' Handles SelectionChanged event for a DataGridView.
        ''' Selects color in the ComboBox appropriate to colors of cell.
        ''' </summary>
        Private Sub mobjDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles mobjDataGridView.SelectionChanged
            If Me.mobjDataGridView.SelectedCells.Count > 0 Then
                Dim mobjFirstCell As DataGridViewCell = Me.mobjDataGridView.SelectedCells(0)

                ' Update colors ComboBox
                ' Enable color ComboBoxes only when DataGridView cell has selected and before anything cells were not selected.
                If Not Me.mobjBackColorComboBox.Enabled Then
                    Me.mobjBackColorComboBox.Enabled = True
                End If
                If Not Me.mobjForeColorComboBox.Enabled Then
                    Me.mobjForeColorComboBox.Enabled = True
                End If
                mobjForeColorComboBox.SelectedItem = IIf(Not mobjFirstCell.Style.ForeColor.IsEmpty, mobjFirstCell.Style.ForeColor, Me.mobjDataGridView.DefaultCellStyle.ForeColor)
                mobjBackColorComboBox.SelectedItem = IIf(Not mobjFirstCell.Style.BackColor.IsEmpty, mobjFirstCell.Style.BackColor, Me.mobjDataGridView.DefaultCellStyle.BackColor)
            Else
                Me.mobjBackColorComboBox.Enabled = False

                Me.mobjForeColorComboBox.Enabled = False
            End If
        End Sub
	End Class

End Namespace