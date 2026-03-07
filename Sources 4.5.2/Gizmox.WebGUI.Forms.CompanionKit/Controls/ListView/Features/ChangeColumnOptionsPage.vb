Namespace CompanionKit.Controls.ListView.Features

    Public Class ChangeColumnOptionsPage

        Private mobjRandomData As RandomData = Nothing

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' Set icon images for ListView column headers
            Me.mobjColumnImportant.Image = New Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Important.gif")
            Me.mobjColumnOpened.Image = New Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Opened.gif")
            Me.mobjColumnAttached.Image = New Gizmox.WebGUI.Common.Resources.IconResourceHandle("Headers.Attachment.gif")


            Me.mobjRandomData = New RandomData
            ' Fill up ListView
            Dim i As Integer
            For i = 0 To 60 - 1
                Me.AddItem()
            Next i
            ' Set enable automatically resize for ListView columns by column content
            Dim objCol As ColumnHeader
            For Each objCol In Me.mobjListView.Columns
                If (objCol.Type <> ListViewColumnType.Control) Then
                    objCol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                End If
            Next



        End Sub

        ''' <summary>
        ''' Adds row to ListView
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AddItem()
            Dim objItem As ListViewItem = Nothing
            Dim objPanel As New ListViewControlPanel
            objPanel.Visible = False
            If Me.mobjRandomData.GetBoolean Then
                objItem = Me.mobjListView.Items.Add(objPanel, Me.GetIcon("ImportantMail.gif"))
                objPanel.Important = True
            Else
                objItem = Me.mobjListView.Items.Add(objPanel, "")
                objPanel.Important = False
            End If
            If Me.mobjRandomData.GetBoolean Then
                objItem.SubItems.Add(Me.GetIcon("OpenedMail.gif"))
                objPanel.Read = True
            Else
                objItem.SubItems.Add(Me.GetIcon("ClosedMail.gif"))
                objPanel.Read = False
            End If
            If Me.mobjRandomData.GetBoolean Then
                objItem.SubItems.Add(Me.GetIcon("AttachedMail.gif"))
                objPanel.Attachemnts = True
            Else
                objItem.SubItems.Add("")
                objPanel.Attachemnts = False
            End If
            objPanel.Subject = "This is a test message."
            objItem.SubItems.Add(objPanel.Subject)
            objPanel.From = "test@visualwebgui.com"
            objItem.SubItems.Add(objPanel.From)
            objItem.SubItems.Add(Me.mobjRandomData.GetDate.ToString)
            objPanel.MailSize = Me.mobjRandomData.GetSize
            objItem.SubItems.Add(objPanel.MailSize)
            Dim objButton As New Gizmox.WebGUI.Forms.Button
            AddHandler objButton.Click, New EventHandler(AddressOf Me.OnEditButtonClick)
            objButton.Tag = objItem
            objButton.Text = "Edit"
            objItem.SubItems.Add(objButton)
            If Me.mobjRandomData.GetBoolean Then
                objItem.UseItemStyleForSubItems = False
                objItem.SubItems.Item(2).BackColor = System.Drawing.Color.Yellow()
            End If
            If Me.mobjRandomData.GetBoolean Then
                objItem.UseItemStyleForSubItems = False
                objItem.SubItems.Item(4).BackColor = System.Drawing.Color.LightGreen
            End If
        End Sub

        ''' <summary>
        ''' Gets resource string for specified icon name
        ''' </summary>
        ''' <param name="strName">icon name</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetIcon(ByVal strName As String) As String
            Return (New IconResourceHandle(strName)).ToString
        End Function

        ''' <summary>
        ''' Handles click event of the Button that is in action column in ListView.
        ''' The method opens panel for editing row data and after editting save changed data
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub OnEditButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim objButton As Gizmox.WebGUI.Forms.Button = TryCast(sender, Gizmox.WebGUI.Forms.Button)
            If objButton IsNot Nothing Then
                Dim objPanelItem As ListViewPanelItem = TryCast(objButton.Tag, ListViewPanelItem)
                If objPanelItem IsNot Nothing Then
                    objPanelItem.Panel.Visible = Not objPanelItem.Panel.Visible
                    If objPanelItem.Panel.Visible Then
                        objButton.Text = "Commit"
                    Else
                        objButton.Text = "Edit"

                        Dim objPanel As ListViewControlPanel = TryCast(objPanelItem.Panel, ListViewControlPanel)
                        If objPanel IsNot Nothing Then
                            If objPanel.IsPanelDirty Then
                                If objPanel.Important Then
                                    objPanelItem.SubItems(0).Text = GetIcon("ImportantMail.gif")
                                Else
                                    objPanelItem.SubItems(0).Text = ""
                                End If

                                If objPanel.Read Then
                                    objPanelItem.SubItems(1).Text = GetIcon("OpenedMail.gif")
                                Else
                                    objPanelItem.SubItems(1).Text = GetIcon("ClosedMail.gif")
                                End If

                                If objPanel.Attachemnts Then
                                    objPanelItem.SubItems(2).Text = GetIcon("AttachedMail.gif")
                                Else
                                    objPanelItem.SubItems(2).Text = ""
                                End If

                                objPanelItem.SubItems(3).Text = objPanel.Subject
                                objPanelItem.SubItems(4).Text = objPanel.From
                                objPanelItem.SubItems(6).Text = objPanel.MailSize


                                objPanel.SetPrevValues()
                            End If
                            mobjListView.Update()
                        End If
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' Hanles click event for ContexMenu item and open dialog 
        ''' to change column options for demonstrated ListView
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub menuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem1.Click
            Dim objListViewColumnOptions As New Gizmox.WebGUI.Forms.Dialogs.ListViewColumnOptions(Me.mobjListView)
            objListViewColumnOptions.ShowDialog()

        End Sub
    End Class

End Namespace