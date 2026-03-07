Imports System.IO
Imports System.Text.RegularExpressions

Namespace CompanionKit.Controls.UploadControl.Functionality

    Public Class UploadControlPage

        Inherits UserControl
        Private mobjList As New List(Of UploadFileModel)()
        Private mstrTempPath As String = System.IO.Path.GetTempPath()

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the UploadControlPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub UploadControlPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            'Some onload initialization
            mobjUploadControl.UploadTempFilePath = mstrTempPath
            mobjListBox.SelectedIndex = 0
            mobjShowFileNameCheckBox.Checked = mobjUploadControl.UploadShowFilenameOnBar
            mobjShowSpeedCheckBox.Checked = mobjUploadControl.UploadShowSpeedOnBar
        End Sub

        ''' <summary>
        ''' Handles the UploadFileCompleted event of the mobjUploadControl control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="UploadCompletedEventArgs"/> instance containing the event data.</param>
        Private Sub mobjUploadControl_UploadFileCompleted(ByVal sender As Object, ByVal e As UploadCompletedEventArgs) Handles mobjUploadControl.UploadFileCompleted
            Dim mobjResult As UploadFileResult = e.Result
            ' Adds record to the list about uploaded file
            mobjList.Add(New UploadFileModel(mobjResult.Name, mobjResult.TempFileFullName, mobjResult.Type, mobjResult.Size))
            ' Resets the data source.
            mobjListView.DataSource = Nothing
            mobjListView.DataSource = mobjList
            ' Resizes ListView's column headers
            ResizeListViewColumnHeaders()
        End Sub

        ''' <summary>
        ''' Handles the UploadError event of the mobjUploadControl control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="UploadErrorEventArgs"/> instance containing the event data.</param>
        Private Sub mobjUploadControl_UploadError(ByVal sender As Object, ByVal e As UploadErrorEventArgs) Handles mobjUploadControl.UploadError
            MessageBox.Show(e.[Error])
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjShowFileNameCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowFileNameCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjShowFileNameCheckBox.CheckedChanged
            mobjUploadControl.UploadShowFilenameOnBar = mobjShowFileNameCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjShowSpeedCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowSpeedCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjShowSpeedCheckBox.CheckedChanged
            mobjUploadControl.UploadShowSpeedOnBar = mobjShowSpeedCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Resizes the list view column headers.
        ''' </summary>
        Private Sub ResizeListViewColumnHeaders()
            If mobjListView.Columns.Count > 0 Then
                For Each mobjColumn As ColumnHeader In mobjListView.Columns
                    mobjColumn.Width = -2
                Next
            End If
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjListBox.SelectedIndexChanged
            If (mblnIsLoaded) Then
                mobjUploadControl.UploadFileTypes = mobjListBox.SelectedItem.ToString()
                DisplayCurrentUploadFileType()
            End If
        End Sub

        ''' <summary>
        ''' Displays the type of the current upload file.
        ''' </summary>
        Private Sub DisplayCurrentUploadFileType()
            mobjGroupBox.Text = String.Format("File type:{0}", mobjUploadControl.UploadFileTypes)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjDefinedRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjDefinedRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjDefinedRadioButton.CheckedChanged
            mobjCustomRadioButton.Checked = Not mobjDefinedRadioButton.Checked
            If mobjDefinedRadioButton.Checked Then
                mobjListBox_SelectedIndexChanged(Me.mobjListBox, New EventArgs())
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCustomRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCustomRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCustomRadioButton.CheckedChanged
            mobjDefinedRadioButton.Checked = Not mobjCustomRadioButton.Checked
            mobjListBox.Enabled = mobjDefinedRadioButton.Checked
            mobjTextBox.Enabled = Not mobjDefinedRadioButton.Checked
            mobjSetButton.Enabled = Not mobjDefinedRadioButton.Checked
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSetButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjSetButton.Click
            'Regular expression, which is validating entered string
            Dim mobjRegex As New Regex("^\^\..*\$$", RegexOptions.IgnoreCase)
            If Not String.IsNullOrEmpty(mobjTextBox.Text) AndAlso mobjRegex.Match(mobjTextBox.Text).Success Then
                mobjUploadControl.UploadFileTypes = mobjTextBox.Text
                DisplayCurrentUploadFileType()
            Else
                MessageBox.Show("Please, check your value for compliance of pattern ^\^\..*\$$ (should starts with '^.' and ends with '$').", "The value is not valid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub
    End Class

    Class UploadFileModel
        Public TempFullPath As String

        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Private _type As String
        Public Property Type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property

        Private _size As Integer
        Public Property Size() As Integer
            Get
                Return _size
            End Get
            Set(ByVal value As Integer)
                _size = value
            End Set
        End Property

        Private _uploadTime As DateTime
        Public Property UploadTime() As DateTime
            Get
                Return _uploadTime
            End Get
            Set(ByVal value As DateTime)
                _uploadTime = value
            End Set
        End Property

        Public Sub New(ByVal strName As String, ByVal strTempFullPath As String, ByVal strType As String, ByVal strSize As Integer)
            Me.Name = strName
            Me.TempFullPath = strTempFullPath
            Me.Type = strType
            Me.Size = strSize
            Me.UploadTime = DateTime.Now
        End Sub
    End Class

End Namespace