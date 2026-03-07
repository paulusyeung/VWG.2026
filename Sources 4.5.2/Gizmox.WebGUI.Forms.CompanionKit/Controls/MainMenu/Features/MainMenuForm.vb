Namespace CompanionKit.Controls.MainMenu.Features

    Public Class MainMenuForm

        ''' <summary>
        ''' Represents type of sample app.
        ''' </summary>
        Private _mainMenuSampleTypes As MainMenuSampleTypes

        Public Sub New()
            Me.components = Nothing
            Me._mainMenuSampleTypes = MainMenuSampleTypes.Icon
            Me.InitializeComponent()
        End Sub

        ''' <summary>
        ''' Creates instance of the class.
        ''' </summary>
        ''' <param name="mainMenuSampleTypes">type of sample app.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal mainMenuSampleTypes As MainMenuSampleTypes)
            Me.New()
            Me._mainMenuSampleTypes = mainMenuSampleTypes
        End Sub

        ''' <summary>
        ''' Handles the Load event of the MainMenuForm control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MainMenuForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.menuItem10.Shortcut = Shortcut.CtrlS
            Me.menuItem11.Shortcut = Shortcut.CtrlShiftS
            Me.menuItem16.Shortcut = Shortcut.CtrlP
            Me.menuItem24.Shortcut = Shortcut.CtrlShiftN
            Me.menuItem26.Shortcut = Shortcut.CtrlN
            Me.menuItem28.Shortcut = Shortcut.CtrlShiftO
            Me.menuItem30.Shortcut = Shortcut.CtrlO
            Me.menuItem39.Shortcut = Shortcut.CtrlZ
            Me.menuItem40.Shortcut = Shortcut.CtrlY
            Me.menuItem44.Shortcut = Shortcut.CtrlX
            Me.menuItem45.Shortcut = Shortcut.CtrlC
            Me.menuItem46.Shortcut = Shortcut.CtrlV
            Me.menuItem47.Shortcut = Shortcut.CtrlShiftV
            Me.menuItem48.Shortcut = Shortcut.Del
            Me.menuItem51.Shortcut = Shortcut.CtrlA
            Me.menuItem59.Shortcut = Shortcut.CtrlG
            Me.menuItem54.Shortcut = Shortcut.CtrlF
            Me.menuItem55.Shortcut = Shortcut.CtrlH
            Me.menuItem56.Shortcut = Shortcut.CtrlShiftF
            Me.menuItem57.Shortcut = Shortcut.CtrlShiftH
            Me.menuItem58.Shortcut = Shortcut.AltF12
            Me.menuItem70.Shortcut = Shortcut.CtrlShiftU
            Me.menuItem71.Shortcut = Shortcut.CtrlU
            Me.menuItem75.Shortcut = Shortcut.CtrlI
            Select Case Me._mainMenuSampleTypes
                Case MainMenuSampleTypes.CheckBox
                    Me.mainMenu1.MenuItems.Add(Me.menuItem112)
                    Me.menuItemCheckedState.Text = String.Format("Select any menu item of the '{0}' menu!", Me.menuItem112.Text)
                    Exit Select
                Case MainMenuSampleTypes.RadioBox
                    Me.mainMenu1.MenuItems.Add(Me.menuItem117)
                    Me.menuItemCheckedState.Text = String.Format("Select any menu item of the '{0}' menu!", Me.menuItem117.Text)
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the Click event of the menuItem control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub menuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem3.Click, menuItem59.Click, menuItem58.Click, menuItem57.Click, menuItem56.Click, menuItem55.Click, menuItem54.Click, menuItem51.Click, menuItem48.Click, menuItem47.Click, menuItem46.Click, menuItem45.Click, menuItem44.Click, menuItem42.Click, menuItem41.Click, menuItem40.Click, menuItem39.Click, menuItem79.Click, menuItem78.Click, menuItem77.Click, menuItem76.Click, menuItem75.Click, menuItem74.Click, menuItem73.Click, menuItem72.Click, menuItem71.Click, menuItem70.Click, menuItem69.Click, menuItem68.Click, menuItem67.Click, menuItem66.Click, menuItem61.Click, menuItem94.Click, menuItem92.Click, menuItem91.Click, menuItem90.Click, menuItem88.Click, menuItem87.Click, menuItem85.Click, menuItem84.Click, menuItem83.Click, menuItem82.Click, menuItem81.Click, menuItem80.Click, menuItem99.Click, menuItem98.Click, menuItem97.Click, menuItem96.Click, menuItem95.Click, menuItem9.Click, menuItem7.Click, menuItem37.Click, menuItem36.Click, menuItem34.Click, menuItem33.Click, menuItem32.Click, menuItem31.Click, menuItem30.Click, menuItem29.Click, menuItem28.Click, menuItem27.Click, menuItem26.Click, menuItem25.Click, menuItem24.Click, menuItem111.Click, menuItem110.Click, menuItem109.Click, menuItem108.Click, menuItem106.Click, menuItem104.Click, menuItem103.Click, menuItem102.Click, menuItem101.Click, menuItem16.Click, menuItem15.Click, menuItem13.Click, menuItem12.Click, menuItem11.Click, menuItem10.Click
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)
            Dim clickedMenuItem As String = menuItem.Text
            Dim parentMenuItem As Menu = menuItem.Parent
            Do While ((Not parentMenuItem Is Nothing) AndAlso parentMenuItem.GetType.Equals(GetType(MenuItem)))
                clickedMenuItem = (DirectCast(parentMenuItem, MenuItem).Text & "->" & clickedMenuItem)
                parentMenuItem = DirectCast(parentMenuItem, MenuItem).Parent
            Loop
            Me.representClickedMenuItemLabel.Text = String.Format("You selected the '{0}' menu item.", clickedMenuItem)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the menuItem23 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub menuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem23.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the menuItemCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub menuItemCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItem116.Click, menuItem115.Click, menuItem114.Click, menuItem113.Click
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)
            menuItem.Checked = Not menuItem.Checked
            Me.menuItemCheckedState.Text = String.Format("Menu item '{0}' was {1} last time!", menuItem.Text, IIf(menuItem.Checked, "checked", "unchecked"))
            Me.menuItem_Click(sender, e)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the menuItemRadioCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub menuItemRadioCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItem125.Click, menuItem124.Click, menuItem123.Click, menuItem119.Click, menuItem118.Click
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)
            If (menuItem Is Me.menuItem118) Then
                Me.menuItem118.Checked = True
                Me.menuItem119.Checked = False
                Me.menuItem123.Checked = False
                Me.menuItem124.Checked = False
                Me.menuItem125.Checked = False
            ElseIf (menuItem Is Me.menuItem119) Then
                Me.menuItem118.Checked = False
                Me.menuItem119.Checked = True
                Me.menuItem123.Checked = False
                Me.menuItem124.Checked = False
                Me.menuItem125.Checked = False
            ElseIf (menuItem Is Me.menuItem123) Then
                Me.menuItem118.Checked = False
                Me.menuItem119.Checked = False
                Me.menuItem123.Checked = True
                Me.menuItem124.Checked = False
                Me.menuItem125.Checked = False
            ElseIf (menuItem Is Me.menuItem124) Then
                Me.menuItem118.Checked = False
                Me.menuItem119.Checked = False
                Me.menuItem123.Checked = False
                Me.menuItem124.Checked = True
                Me.menuItem125.Checked = False
            ElseIf (menuItem Is Me.menuItem125) Then
                Me.menuItem118.Checked = False
                Me.menuItem119.Checked = False
                Me.menuItem123.Checked = False
                Me.menuItem124.Checked = False
                Me.menuItem125.Checked = True
            End If
            Me.menuItemCheckedState.Text = String.Format("Menu item '{0}' was checked last time!", menuItem.Text)
            Me.menuItem_Click(sender, e)
        End Sub

        Public Enum MainMenuSampleTypes
            CheckBox
            Icon
            KeyBoard
            RadioBox
        End Enum

       
    End Class

End Namespace
