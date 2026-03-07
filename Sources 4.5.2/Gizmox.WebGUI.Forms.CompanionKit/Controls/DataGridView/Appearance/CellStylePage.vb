Imports System.Drawing
Imports Gizmox.WebGUI.Common.Resources

Namespace CompanionKit.Controls.DataGridView.Appearance

	Public Class CellStylePage

		Private _cellStyleColors As List(Of CellStyleColorProperty)
		Private _cellStyleFont As Font

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Fill up colors Combobox
            _cellStyleColors = New List(Of CellStyleColorProperty)()
            _cellStyleColors.Add(New CellStyleColorProperty(CellStyleTypes.BackColor, Me.mobjDataGridView.DefaultCellStyle.BackColor))
            _cellStyleColors.Add(New CellStyleColorProperty(CellStyleTypes.ForeColor, Me.mobjDataGridView.DefaultCellStyle.ForeColor))
            _cellStyleColors.Add(New CellStyleColorProperty(CellStyleTypes.SelectionBackColor, Me.mobjDataGridView.DefaultCellStyle.SelectionBackColor))
            _cellStyleColors.Add(New CellStyleColorProperty(CellStyleTypes.SelectionForeColor, Me.mobjDataGridView.DefaultCellStyle.SelectionForeColor))

            Me.mobjColorComboBox.DataSource = _cellStyleColors
            Me.mobjColorComboBox.ColorMember = "CellColor"
            Me.mobjColorComboBox.DisplayMember = "CellStyleColorType"
            Me.mobjColorComboBox.SelectedIndex = 0

            'Fill up Alignment ComboBox
            Me.mobjAlignComboBox.DataSource = [Enum].GetValues(GetType(DataGridViewContentAlignment))
            Me.mobjAlignComboBox.SelectedItem = Me.mobjDataGridView.DefaultCellStyle.Alignment

            _cellStyleFont = Me.mobjDataGridView.DefaultCellStyle.Font
            UpdateFontLabel(_cellStyleFont)

            Me.mobjWrapModeComboBox.DataSource = [Enum].GetValues(GetType(DataGridViewTriState))
            Me.mobjWrapModeComboBox.SelectedItem = Me.mobjDataGridView.DefaultCellStyle.WrapMode

            'Get ResourceHandle for photo of customer.
            Dim photoResource As Global.Gizmox.WebGUI.Common.Resources.ResourceHandle = New Global.Gizmox.WebGUI.Common.Resources.ImageResourceHandle("Photo.jpg")
            'Set objects collection as DataSource for ComboBox.

            Me.mobjDataGridView.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomersWithImage(photoResource)
        End Sub

        Private Sub mobjColorButton_Click(sender As Object, e As EventArgs) Handles mobjColorButton.Click
            Dim mobjCellStyleColor As CellStyleColorProperty = TryCast(Me.mobjColorComboBox.SelectedItem, CellStyleColorProperty)
            Me.mobjColorDialog.Color = mobjCellStyleColor.CellColor
            Me.mobjColorDialog.ShowDialog()
        End Sub

        Private Sub mobjColorDialog_Closed(sender As Object, e As EventArgs) Handles mobjColorDialog.Closed
            Dim mobjCellStyleColor As CellStyleColorProperty = TryCast(Me.mobjColorComboBox.SelectedItem, CellStyleColorProperty)
            Dim mobjNewColor As Color = Me.mobjColorDialog.Color
            'Update selected color in the cell property that it is selected in color property ComboBox
            UpdateCellStyle(mobjCellStyleColor.CellStyleColorType, mobjNewColor)

            'Update selected color in color ComboBox
            For Each mobjCurrentCellStyleColor As CellStyleColorProperty In _cellStyleColors
                If mobjCurrentCellStyleColor.CellStyleColorType = mobjCellStyleColor.CellStyleColorType Then
                    mobjCurrentCellStyleColor.CellColor = mobjNewColor
                    Exit For
                End If
            Next
            ' TODO: check after Beta 2 released, VWG-6520, remove call to Update()
            Me.mobjColorComboBox.Update()
        End Sub


        Private Sub mobjAlignComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjAlignComboBox.SelectedIndexChanged
            Dim mobjAlignment As DataGridViewContentAlignment = DirectCast(Me.mobjAlignComboBox.SelectedItem, DataGridViewContentAlignment)

            'Update text alignment in cell style
            UpdateCellStyle(CellStyleTypes.Alignment, mobjAlignment)
        End Sub

        Private Sub mobjFontChangeButton_Click(sender As Object, e As EventArgs) Handles mobjFontChangeButton.Click
            Me.mobjFontDialog.Font = _cellStyleFont
            Me.mobjFontDialog.ShowDialog()
        End Sub

        Private Sub mobjFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjFontDialog.Closed
            UpdateFontForCell(Me.mobjFontDialog.Font)
        End Sub

        Private Sub mobjFontDialog_Apply(sender As Object, e As EventArgs) Handles mobjFontDialog.Apply
            UpdateFontForCell(Me.mobjFontDialog.Font)
        End Sub

        Private Sub mobjDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles mobjDataGridView.SelectionChanged
            If Me.mobjDataGridView.SelectedCells.Count > 0 Then
                Dim mobjFirstCell As DataGridViewCell = Me.mobjDataGridView.SelectedCells(0)

                'Update colors ComboBox

                'Enable color ComboBox and change color Burtton only when DataGridView cell has selected and before anything cells were not selected.
                If Not Me.mobjColorComboBox.Enabled Then
                    Me.mobjColorComboBox.Enabled = True
                End If
                If Not Me.mobjColorButton.Enabled Then
                    Me.mobjColorButton.Enabled = True
                End If

                For Each mobjCurrentCellStyleColor As CellStyleColorProperty In _cellStyleColors
                    Select Case mobjCurrentCellStyleColor.CellStyleColorType
                        Case CellStyleTypes.ForeColor
                            mobjCurrentCellStyleColor.CellColor = IIf(Not mobjFirstCell.Style.ForeColor.IsEmpty, mobjFirstCell.Style.ForeColor, Me.mobjDataGridView.DefaultCellStyle.ForeColor)
                            Exit Select
                        Case CellStyleTypes.BackColor
                            mobjCurrentCellStyleColor.CellColor = IIf(Not mobjFirstCell.Style.BackColor.IsEmpty, mobjFirstCell.Style.BackColor, Me.mobjDataGridView.DefaultCellStyle.BackColor)
                            Exit Select
                        Case CellStyleTypes.SelectionForeColor
                            mobjCurrentCellStyleColor.CellColor = IIf(Not mobjFirstCell.Style.SelectionForeColor.IsEmpty, mobjFirstCell.Style.SelectionForeColor, Me.mobjDataGridView.DefaultCellStyle.SelectionForeColor)
                            Exit Select
                        Case CellStyleTypes.SelectionBackColor
                            mobjCurrentCellStyleColor.CellColor = IIf(Not mobjFirstCell.Style.SelectionBackColor.IsEmpty, mobjFirstCell.Style.SelectionBackColor, Me.mobjDataGridView.DefaultCellStyle.SelectionBackColor)
                            Exit Select
                    End Select
                Next
                ' TODO: check after Beta 2 released, VWG-6520, remove call to Update()
                Me.mobjColorComboBox.Update()

                'Enable cell text alignment ComboBox only when DataGridView cell has selected and before anything cells were not selected.
                If Not Me.mobjAlignComboBox.Enabled Then
                    Me.mobjAlignComboBox.Enabled = True
                End If
                Me.mobjAlignComboBox.SelectedItem = IIf(mobjFirstCell.Style.Alignment <> DataGridViewContentAlignment.NotSet, mobjFirstCell.Style.Alignment, Me.mobjDataGridView.DefaultCellStyle.Alignment)

                'Enable font change Button only when DataGridView cell has selected and before anything cells were not selected.
                If Not Me.mobjFontChangeButton.Enabled Then
                    Me.mobjFontChangeButton.Enabled = True
                End If
                Dim mobjCurrentCellFont As Font = IIf(mobjFirstCell.Style.Font IsNot Nothing, mobjFirstCell.Style.Font, Me.mobjDataGridView.DefaultCellStyle.Font)
                'UpdateFontLabel(currentCellFont);
                _cellStyleFont = mobjCurrentCellFont

                'Update WrapMode ComboBox
                'Enable WrapMode ComboBox only when DataGridView cell has selected and before anything cells were not selected.
                If Not Me.mobjWrapModeComboBox.Enabled Then
                    Me.mobjWrapModeComboBox.Enabled = True
                End If
                Me.mobjWrapModeComboBox.SelectedItem = IIf(mobjFirstCell.Style.WrapMode <> DataGridViewTriState.NotSet, mobjFirstCell.Style.WrapMode, Me.mobjDataGridView.DefaultCellStyle.WrapMode)
            Else
                Me.mobjFontChangeButton.Enabled = False
                Me.mobjAlignComboBox.Enabled = False
                Me.mobjColorComboBox.Enabled = False
                Me.mobjColorButton.Enabled = False
                Me.mobjWrapModeComboBox.Enabled = False
            End If
        End Sub

        Private Sub mobjWrapModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjWrapModeComboBox.SelectedIndexChanged

            Dim mobjNewWrapMode As DataGridViewTriState = DirectCast(Me.mobjWrapModeComboBox.SelectedItem, DataGridViewTriState)
            UpdateCellStyle(CellStyleTypes.WrapMode, mobjNewWrapMode)
        End Sub

        Private Sub UpdateFontLabel(newFont As Font)
            If newFont IsNot Nothing Then
                Me.mobjFontLabel.Text = String.Format("Font: {0}, {1}pt", newFont.Name, newFont.Size)
            End If
        End Sub

        Private Sub UpdateFontForCell(newFont As Font)
            If newFont Is Nothing Then
                Return
            End If

            UpdateFontLabel(newFont)
            UpdateCellStyle(CellStyleTypes.Font, newFont)
        End Sub
        ''' <summary>
        ''' Updates specified property of cell style to new <code>value</code>
        ''' </summary>
        ''' <param name="cellStyleType">Type of cell style property</param>
        ''' <param name="value">New value</param>
        Private Sub UpdateCellStyle(cellStyleType As CellStyleTypes, value As Object)
            For i As Integer = 0 To Me.mobjDataGridView.SelectedCells.Count - 1
                Dim cell As DataGridViewCell = Me.mobjDataGridView.SelectedCells(i)
                Select Case cellStyleType
                    Case CellStyleTypes.ForeColor
                        cell.Style.ForeColor = DirectCast(value, Color)
                        Exit Select
                    Case CellStyleTypes.BackColor
                        cell.Style.BackColor = DirectCast(value, Color)
                        Exit Select
                    Case CellStyleTypes.SelectionForeColor
                        cell.Style.SelectionForeColor = DirectCast(value, Color)
                        Exit Select
                    Case CellStyleTypes.SelectionBackColor
                        cell.Style.SelectionBackColor = DirectCast(value, Color)
                        Exit Select
                    Case CellStyleTypes.Font
                        cell.Style.Font = DirectCast(value, Font)
                        Exit Select
                    Case CellStyleTypes.Alignment
                        cell.Style.Alignment = DirectCast(value, DataGridViewContentAlignment)
                        Exit Select
                    Case CellStyleTypes.WrapMode
                        cell.Style.WrapMode = DirectCast(value, DataGridViewTriState)
                        Exit Select

                End Select
            Next
        End Sub
        ''' <summary>
        ''' Enum represents name of style property.
        ''' </summary>
        Private Enum CellStyleTypes
            ForeColor
            BackColor
            SelectionForeColor
            SelectionBackColor
            Alignment
            WrapMode
            Font
        End Enum

        ''' <summary>
        ''' Class represents cell style color property.
        ''' </summary>
        Private Class CellStyleColorProperty
            Private _cellStyleColorType As CellStyleTypes = CellStyleTypes.BackColor
            Private _cellColor As Color

            Public Sub New(cellStyleColorType__1 As CellStyleTypes, cellColor__2 As Color)
                CellStyleColorType = cellStyleColorType__1
                CellColor = cellColor__2
            End Sub
            ''' <summary>
            ''' Represents name color property.
            ''' </summary>
            Public Property CellStyleColorType() As CellStyleTypes
                Get
                    Return _cellStyleColorType
                End Get
                Set(value As CellStyleTypes)
                    _cellStyleColorType = value
                End Set
            End Property

            ''' <summary>
            ''' Gets or sets selected cell color.
            ''' </summary>
            Public Property CellColor() As Color
                Get
                    Return _cellColor
                End Get
                Set(value As Color)
                    _cellColor = value
                End Set
            End Property
        End Class


	End Class

End Namespace