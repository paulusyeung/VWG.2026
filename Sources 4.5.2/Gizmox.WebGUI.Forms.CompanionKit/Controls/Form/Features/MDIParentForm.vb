Namespace CompanionKit.Controls.Form.Features
	Public Class MDIParentForm

        ' TODO: check after fix issue VWG-4758, remove the field.
        ''' <summary>
        ''' Represents shourtcut on the active MDI Child Form
        ''' </summary>
        Private activeForm As Gizmox.WebGUI.Forms.Form = Nothing

        ' TODO: check after fix issue VWG-4758, remove the field.
        ''' <summary>
        ''' Represents List of MDI Child Forms
        ''' </summary>
        Private MdiChildren As List(Of Gizmox.WebGUI.Forms.Form)

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            Me.MdiChildren = New List(Of Gizmox.WebGUI.Forms.Form)


		End Sub

        ''' <summary>
        ''' Handles Click event of 'Open MDI Child Form' menu item.
        ''' Opens the MDI Child Form with MDI Parent as this Form.
        ''' </summary>
        Private Sub mobjOpenMDIChildFormMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjOpenMDIChildFormMenuItem.Click

            Dim mdiChild As New MDIChildForm
            MDIChildForm._idxChildForm += 1
            mdiChild.MdiParent = Me
            AddHandler mdiChild.Closed, New EventHandler(AddressOf Me.OnCloseMdiForm)

            ' TODO: check after fix issue VWG-5954, remove the registering of the following two handler.
            AddHandler mdiChild.Activated, New EventHandler(AddressOf Me.MDIChildForm_Activated)
            AddHandler mdiChild.Deactivate, New EventHandler(AddressOf Me.MDIChildForm_Deactivated)
            AddHandler mdiChild.Load, New EventHandler(AddressOf Me.MDIChildForm_Load)
            Me.MdiChildren.Add(mdiChild)
            mdiChild.Show()
        End Sub

        ''' <summary>
        ''' Handles Click event of 'Close Active MDI Child Form' menu item.
        ''' Closes the active MDI Child Form.
        ''' </summary>
        Private Sub mobjCloseActiveMDIChildFormMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCloseActiveMDIChildFormMenuItem.Click
            If (Not Me.activeForm Is Nothing) Then
                Me.activeForm.Close()
            End If

        End Sub

        ''' <summary>
        ''' Handles click event for 'Close All MDI Child Forms' menu item.
        ''' </summary>
        Private Sub mobjCloseAllMDIChildFormsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCloseAllMDIChildFormsMenuItem.Click
            Dim form As Global.Gizmox.WebGUI.Forms.Form
            For Each form In Me.MdiChildren.ToArray
                form.Close()
            Next
        End Sub

        ''' <summary>
        ''' Handles Activated event of the MDI Child Form.
        ''' </summary>
		Private Sub MDIChildForm_Activated(ByVal sender As Object, ByVal e As EventArgs)
            Me.activeForm = TryCast(sender, Gizmox.WebGUI.Forms.Form)
		End Sub

        ''' <summary>
        ''' Handles Deactivated event of the MDI Child Form.
        ''' </summary>
		Private Sub MDIChildForm_Deactivated(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        ''' <summary>
        ''' Handles Load event of MDI Child Form
        ''' Updates enable status of menu items according to number of MDI Child Forms.
        ''' </summary>
		Private Sub MDIChildForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetMenuItemEnable(Me.mobjCloseActiveMDIChildFormMenuItem, True)
            Me.SetMenuItemEnable(Me.mobjCloseAllMDIChildFormsMenuItem, True)
		End Sub

        ''' <summary>
        ''' Handles Closed event of MDI Child Form
        ''' </summary>
        Public Sub OnCloseMdiForm(ByVal sender As Object, ByVal e As EventArgs)
            Dim closedMDIFrom As Gizmox.WebGUI.Forms.Form = TryCast(sender, Gizmox.WebGUI.Forms.Form)

            ' Remove closed MDI Child form from list, that contains all MDI Children
            Me.MdiChildren.Remove(closedMDIFrom)

            ' Update enable status of menu items according to number of MDI Child Forms
            If (Me.MdiChildren.Count > 0) Then
                Me.SetMenuItemEnable(Me.mobjCloseActiveMDIChildFormMenuItem, True)
                Me.SetMenuItemEnable(Me.mobjCloseAllMDIChildFormsMenuItem, True)
            Else
                Me.SetMenuItemEnable(Me.mobjCloseActiveMDIChildFormMenuItem, False)
                Me.SetMenuItemEnable(Me.mobjCloseAllMDIChildFormsMenuItem, False)
            End If
        End Sub

        ''' <summary>
        ''' Sets enable status for <code>menuItem</code> menu item according to 
        ''' value of the parameter <code>isEnable</code>.
        ''' </summary>
        ''' <param name="menuItem">The menu item</param>
        ''' <param name="isEnable">Indicates whether the menu items should be enable</param>
		Private Sub SetMenuItemEnable(ByVal menuItem As MenuItem, ByVal isEnable As Boolean)
			If (menuItem.Enabled <> isEnable) Then
				menuItem.Enabled = isEnable
			End If
		End Sub


	End Class
End Namespace
