Namespace CompanionKit.Controls.DataGridView.Features

    Public Class ExtendedHeadersPage
        'Define ExtendedHeader UserControl 
        Public mobjUserControl As New ExtendedHeaderUserControl()
        'Define Add Button
        Public WithEvents mobjAddButton As New Gizmox.WebGUI.Forms.Button()
        'Define Remove Button
        Public WithEvents mobjRemoveButton As New Gizmox.WebGUI.Forms.Button()
        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()



        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNUD_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjNUD.ValueChanged
            'Change the number of column ExtendedHeader belongs to
            mobjUserControl.ColIndex = Convert.ToInt32(mobjNUD.Value) - 1
            mobjDGV.Update()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ExtendedHeadersPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub ExtendedHeadersPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Fill DGV with 3 rows of data
            mobjDGV.Rows.Add("row 1", "item 1", "value 1")
            mobjDGV.Rows.Add("row 2", "item 2", "value 2")
            mobjDGV.Rows.Add("row 3", "item 3", "value 3")

            'Add a row to ExtendedColumnHeader
            mobjDGV.ExtendedColumnHeaders.Rows.Add(New ExtendedHeaderRowData(HeightMode.[Custom], 100))
            mobjDGV.ExtendedColumnHeaders.Rows(0).Height = 50

            'Define AddButton
            mobjAddButton.Location = New System.Drawing.Point(0, 0)
            mobjAddButton.Size = New System.Drawing.Size(104, 23)
            mobjAddButton.Text = "Add row"

            'Define Remove Button
            mobjRemoveButton.Location = New System.Drawing.Point(0, 25)
            mobjRemoveButton.Size = New System.Drawing.Size(104, 23)
            mobjRemoveButton.Text = "Remove row"

            'Add buttons to ExtendedHeader UserControl
            mobjUserControl.Controls.Add(mobjRemoveButton)
            mobjUserControl.Controls.Add(mobjAddButton)
            mobjUserControl.ColIndex = 0
            'Add UserControl to ExtendedHeader
            mobjDGV.ExtendedColumnHeaders.HeaderControls.Add(mobjUserControl)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsExtHeaderVisible control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIsExtHeaderVisible_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjIsExtHeaderVisible.CheckedChanged
            'Show or hide Extended ColumnHeader
            mobjDGV.ExtendedColumnHeaders.ShowExtendedColumnHeader = mobjIsExtHeaderVisible.Checked
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            'Add row in DGV
            mobjDGV.Rows.Add("new item")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRemoveButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveButton_Click(sender As Object, e As EventArgs) Handles mobjRemoveButton.Click
            'If one row is selected in DGV
            If mobjDGV.SelectedRows.Count = 1 Then
                'If new row is selected in DGV
                If mobjDGV.SelectedRows(0).IsNewRow Then
                    MessageBox.Show("You cannot remove a new row.")
                Else
                    'If not a new row is selected in DGV
                    mobjDGV.Rows.RemoveAt(mobjDGV.SelectedRows(0).Index)
                End If
            Else
                'If more then one row is selected in DGV
                MessageBox.Show("Please select one row to remove.")
            End If
        End Sub
    End Class

End Namespace