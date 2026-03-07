Namespace CompanionKit.Controls.ListView.Features

	Public Class CustomListViewPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' Fill up ListView
            Me.mobjListView.Items.Add(Me.GetListViewItem("1", "User1", "Photo.png", DateTime.Now, "Call #8-800-1234557", True))
            Me.mobjListView.Items.Add(Me.GetListViewItem("2", "User2", "Photo.png", DateTime.Now, "Call #8-800-9513546", False))
            Me.mobjListView.Items.Add(Me.GetListViewItem("3", "User3", "Photo.png", DateTime.Now, "Call #8-800-8524565", True))
            Me.mobjListView.Items.Add(Me.GetListViewItem("4", "User4", "Photo.png", DateTime.Now, "Call #8-800-9874614", False))
            Me.mobjListView.Items.Add(Me.GetListViewItem("5", "User5", "Photo.png", DateTime.Now, "Call #8-800-9874613", True))
            Me.mobjListView.Items.Add(Me.GetListViewItem("6", "User6", "Photo.png", DateTime.Now, "Call #8-800-9874612", False))



		End Sub

        ''' <summary>
        ''' Approve by message on button click
        ''' </summary>
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim button As Gizmox.WebGUI.Forms.Button = TryCast(sender, Gizmox.WebGUI.Forms.Button)
            If (Not button Is Nothing) Then
                Dim tag As ListViewItem = DirectCast(button.Tag, ListViewItem)
                If (Not Nothing Is tag) Then
                    MessageBox.Show(String.Format("The phone number of '{1}' is '{0}'", button.Text.Substring(5), tag.SubItems.Item(1)))
                End If
            End If
        End Sub

        ''' <summary>
        ''' Gets item for the ListView with defined data.
        ''' </summary>
        ''' <param name="userID">User ID</param>
        ''' <param name="userName">User Name</param>
        ''' <param name="filePhotoName">File name of user foto, the file should be in Resources.Icons folder</param>
        ''' <param name="visitDate">The date of user visit</param>
        ''' <param name="buttonText">User phone</param>
		''' <param name="blnVIP">Indicates whether user is VIP person</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetListViewItem(ByVal userID As String, ByVal userName As String, ByVal filePhotoName As String, ByVal visitDate As DateTime, ByVal buttonText As String, ByVal blnVIP As Boolean) As ListViewItem
            Dim listViewItem As New ListViewItem

            'prepare button for 3rd column
			Dim button1 As New Gizmox.WebGUI.Forms.Button
            button1.AutoSize = True
            button1.Text = buttonText
            AddHandler button1.Click, New EventHandler(AddressOf Me.button1_Click)
            'relate sub-item with control, for further data-extracting from Item
            button1.Tag = listViewItem

            'prepare checkbox for 4th column
            Dim box As New Gizmox.WebGUI.Forms.CheckBox
            box.Checked = blnVIP
            AddHandler box.CheckedChanged, New EventHandler(AddressOf Me.chkVIP_CheckedChanged)
            'relate sub-item with control, for further data-extracting from Item
            box.Tag = listViewItem

            listViewItem.SubItems.Add(userID)
            listViewItem.SubItems.Add(userName)
            listViewItem.SubItems.Add(GetIconForPhoto(filePhotoName))
            listViewItem.SubItems.Add(visitDate.ToShortDateString)
            listViewItem.SubItems.Add(button1)
            listViewItem.SubItems.Add(box)
            Return listViewItem
        End Function

        ''' <summary>
        ''' Approve by message on checkbox click
        ''' </summary>
        Private Sub chkVIP_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim chkVIP As Gizmox.WebGUI.Forms.CheckBox = TryCast(sender, Gizmox.WebGUI.Forms.CheckBox)
            If (Not Nothing Is chkVIP) Then
                Dim tag As ListViewItem = DirectCast(chkVIP.Tag, ListViewItem)
                If (Not Nothing Is tag) Then
                    Dim strMessage As String
                    strMessage = String.Format("The user '{0}' tagged as {1}VIP user.", _
                                tag.SubItems.Item(1), IIf(chkVIP.Checked, "", "non-"))
                    MessageBox.Show(strMessage, "Example of checkbox")
                End If
            End If
        End Sub

        ''' <summary>
        '''  Gets VWG defined name of icon for user photo.
        ''' </summary>
        Private Function GetIconForPhoto(ByVal strName As String) As String
            Return New IconResourceHandle(strName).ToString
        End Function

	End Class

End Namespace