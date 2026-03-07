Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class FilterPage

        ''' <summary>
        ''' Represents collection of file types filters 
        ''' </summary>
        Private _filters As Dictionary(Of String, String) = New Dictionary(Of String, String)

        ''' <summary>
        ''' Represnts default file types filters 
        ''' </summary>
        Private DEFAULT_FILTER As String = "All Files(*.*)"

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example UserControl
        ''' </summary>
        Private Sub FilterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up dictionary with files filter
            _filters.Add("Image Files (JPEG,GIF,BMP)", "*.jpg;*.jpeg;*.gif;*.bmp")
            _filters.Add("JPEG Files(*.jpg;*.jpeg)", "*.jpg;*.jpeg")
            _filters.Add("GIF Files(*.gif)", "*.gif")
            _filters.Add("BMP Files(*.bmp)", "*.bmp")
            _filters.Add("All Files(*.*)", "*.*")

            ' Fill up ListBox with name filter of the file types
            For Each curentFilterKey As [String] In _filters.Keys
                Me.mobjFiltersOfFileTypesListBox.Items.Add(curentFilterKey)
            Next
            Me.mobjFiltersOfFileTypesListBox.SelectedValue = "All Files(*.*)"
        End Sub

        ''' <summary>
        ''' Handles the click event of the button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.Filter = GetSelectedFiltersAsString()
            ' Set index of default images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.FilterIndex = 1
            ' Set initial directory for Open File Dialog
            Me.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Gets string that represents filter of the file types for OpenFileDialog
        ''' </summary>
        Private Function GetSelectedFiltersAsString() As String
            Dim filters As New System.Text.StringBuilder()
            If Me.mobjFiltersOfFileTypesListBox.SelectedItems.Count > 0 Then
                For Each selectedFilterKey As String In Me.mobjFiltersOfFileTypesListBox.SelectedItems
                    AppendsFilterOfFileTypes(filters, selectedFilterKey)
                Next
            Else
                AppendsFilterOfFileTypes(filters, DEFAULT_FILTER)
            End If
            Return filters.ToString()
        End Function

        ''' <summary>
        ''' Appends filter of the file types into the Filters string builder.
        ''' </summary>
        ''' <param name="filters">string builder with filters of the file types</param>
        ''' <param name="filterKey">the filter name</param>
        Private Sub AppendsFilterOfFileTypes(filters As System.Text.StringBuilder, filterKey As String)
            If filters.Length > 0 Then
                filters.Append("|")
            End If

            filters.Append(filterKey).Append("|").Append(_filters(filterKey))
        End Sub

    End Class

End Namespace