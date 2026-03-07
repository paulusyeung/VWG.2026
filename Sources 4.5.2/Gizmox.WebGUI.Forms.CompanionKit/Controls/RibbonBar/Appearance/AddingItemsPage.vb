Namespace CompanionKit.Controls.RibbonBar.Appearance

	Public Class AddingItemsPage
		Inherits UserControl
		' Methods
		Public Sub New()
			Me.InitializeComponent()
			Me.PostInitialize()
		End Sub

		'''<summary>
		''' Post initialize actions and tweaking appearance of underlying controls
		'''</summary>
		Private Sub PostInitialize()

			'Work around for VWG-8391
			'remove and add from/to collection to cause width recalculate
			Me.rbGroupIntelliSence.Items.Remove(Me.rbIntelliSense)
			Me.rbGroupIntelliSence.Items.Add(Me.rbIntelliSense)

			' Expand the group (to ensure visibility when width will be changed)
			TryCast(Me.rbGroupIntelliSence.Control, Gizmox.WebGUI.Forms.GroupBox).Width = 520

			' Align checkbox with other controls
			TryCast(Me.rbSItemCase.Control, Gizmox.WebGUI.Forms.CheckBox).Margin = New Padding(3, 3, 0, 0)
			' set initial state
			Me.demoRibbonBar.SelectedIndex = 0
			Me.SelectedIndexChanged(Me.demoRibbonBar, New EventArgs)

			' Set combo to disable text editing, select first Item, add space between
			Dim objCombo As Gizmox.WebGUI.Forms.ComboBox = DirectCast(Me.rbSItemCmb.Control, Gizmox.WebGUI.Forms.ComboBox)
			objCombo.DropDownStyle = ComboBoxStyle.DropDownList
			objCombo.SelectedIndex = 0

			' Preserve initial margin (bottom) and add space to the right side
			objCombo.Margin = New Padding(0, 0, 3, 7)
			AddHandler objCombo.SelectedIndexChanged, New EventHandler(AddressOf Me.Combo_SelectedIndexChanged)
		End Sub

		''' <summary>
		''' Provide logic for Where to search selection.
		''' "All" item drops all other checks
		''' </summary>
		Private Sub menuWhere_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (sender Is Me.menuWhereAll) Then
				Me.menuWhereAll.Checked = True
				Me.menuWhereCode.Checked = False
				Me.menuWhereDocs.Checked = False
				Me.menuWhereImages.Checked = False
			Else
				Me.menuWhereAll.Checked = False
				DirectCast(sender, MenuItem).Checked = True
			End If
		End Sub


		''' <summary>
		''' Set initial value to the width of RibbonBarFlowItem
		''' </summary>
		Private Sub Width_SetInitial(ByVal sender As Object, ByVal e As EventArgs)
			Me.rbIntelliSense.Width = Me.mobjTrackWidth.Value = 230
			Me.rbIntelliSense.Control.BorderStyle = BorderStyle.None
		End Sub

		''' <summary>
		''' Set value to the width of RibbonBarFlowItem
		''' </summary>		
		Private Sub Width_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.rbIntelliSense.Width = Me.mobjTrackWidth.Value
			Me.lblWidth.Text = String.Format("RibbonBarFlowItem width: {0}", Me.mobjTrackWidth.Value)
			Me.rbIntelliSense.Control.BorderColor = System.Drawing.Color.LightSteelBlue
			Me.rbIntelliSense.Control.BorderStyle = BorderStyle.FixedSingle
			Me.rbIntelliSense.Control.BorderWidth = 1
		End Sub

		'''<summary>
		''' Display text in the label with event handler message
		'''</summary>
		Private Sub MessageEventHandler(ByVal [text] As String)
			Me.lblEventHandler.Text = String.Format("Event handler: {0}", [text])
		End Sub

#Region "1) RibbonBar control Event Handlers"

		''' <summary>
		''' Reflect the active page switch
		''' </summary>
		Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.demoRibbonBar.SelectedIndex > -1) Then
				Dim resources As RibbonBarPage = Me.demoRibbonBar.Pages.Item(Me.demoRibbonBar.SelectedIndex)
				If (Not resources Is Nothing) Then
					Me.lblStatus.Text = String.Format("The active page: {0}", resources.Text)
				End If
				Me.mobjGrpWidth.Visible = (resources Is Me.rbEdit)
			End If
		End Sub

#End Region

#Region "2) RibbonBar Aggregating Event Handlers"

		''' <summary>
		''' RibbonBar "advanced" anchor clicked aggregating event handler
		''' </summary>
		Private Sub AdvancedClicked(ByVal sender As Object, ByVal e As RibbonBarGroupArgs)
			If ((Not e Is Nothing) AndAlso (Not e.Group Is Nothing)) Then
				Me.lblEventHandler.Visible = True
				Me.MessageEventHandler(String.Format("The advanced anchor: {0}", e.Group.Text))
			End If
		End Sub


		''' <summary>
		''' RibbonBar ButtonClick aggregating event handler of any RibbonBarButtonItem inherited item
		''' </summary>
		Private Sub rb_ButtonClick(ByVal sender As Object, ByVal e As RibbonBarButtonItemArgs)
			Dim message As String = String.Empty
			If e.Button.Control.Text.Length > 0 Then
				message = e.Button.Control.Text
			ElseIf Not String.IsNullOrEmpty(TryCast(e.Button.Tag, String)) Then
				message = e.Button.Tag.ToString()
			End If
			Me.MessageEventHandler(message)
		End Sub

		''' <summary>
		''' RibbonBar CheckedChanged aggregating event handler of any RibbonBarCheckBoxItem
		''' </summary>	
		Private Sub rb_CheckedChanged(ByVal sender As Object, ByVal e As RibbonBarCheckBoxItemArgs)
			Dim flag As Boolean = DirectCast(e.CheckBox.Control, Gizmox.WebGUI.Forms.CheckBox).Checked
			Me.MessageEventHandler(String.Format("The check changed: {0}", IIf(flag, "checked", "not checked")))
		End Sub

		Private Sub rb_TextChanged(ByVal sender As Object, ByVal e As RibbonBarTextBoxItemArgs)
			Me.MessageEventHandler(String.Format("The text changed: {0}", e.TextBox.Control.Text))
		End Sub

#End Region

#Region "3) Item and SubItem objects events"

		''' <summary>
		''' SubItem specific RibbonBarDropDownButtonItem MenuClick event handler
		''' </summary>	
		Private Sub rb_MenuClick(ByVal objSource As Object, ByVal objArgs As MenuItemEventArgs)
			Me.MessageEventHandler(String.Format("The menu item clicked: {0}", objArgs.MenuItem.Text))
		End Sub
#End Region

#Region "4) Item and SubItem underlying control events (like Button, CheckBox, TextBox, ComboBox)"

		''' <summary>
		''' SubItem event handler of underlying Combobox
		''' </summary>	
		Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim control As Gizmox.WebGUI.Forms.ComboBox = DirectCast(Me.rbSItemCmb.Control, Gizmox.WebGUI.Forms.ComboBox)
			Me.MessageEventHandler(String.Format("The index changed: {0} - {1}", control.SelectedIndex, control.SelectedItem))
		End Sub
#End Region


	End Class

End Namespace