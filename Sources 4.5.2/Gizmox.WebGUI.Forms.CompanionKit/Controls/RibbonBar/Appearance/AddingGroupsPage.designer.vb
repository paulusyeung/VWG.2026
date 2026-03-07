Imports System.Drawing
Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.RibbonBar.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddingGroupsPage
		Inherits UserControl

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		'Required by the Visual WebGui UserControl Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the WebGui UserControl Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Me.demoRibbonBar = New Gizmox.WebGUI.Forms.RibbonBar
			Me.rbView = New RibbonBarPage
			Me.rbGroupBookmarks = New RibbonBarGroup
			Me.rbGroupAdvanced = New RibbonBarGroup
			Me.rbEdit = New RibbonBarPage
			Me.rbGroupFind = New RibbonBarGroup
			Me.rbGroupIntelliSence = New RibbonBarGroup
			Me.lblStatus = New Label
			Me.groupBox1 = New Gizmox.WebGUI.Forms.GroupBox
			Me.lblAdvanced = New Label
			Me.groupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.demoRibbonBar.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.demoRibbonBar.Location = New Point(0, 0)
			Me.demoRibbonBar.Name = "demoRibbonBar"
			Me.demoRibbonBar.Pages.Add(Me.rbView)
			Me.demoRibbonBar.Pages.Add(Me.rbEdit)
			Me.demoRibbonBar.SelectedIndex = 0
			Me.demoRibbonBar.TabIndex = 0
			AddHandler Me.demoRibbonBar.SelectedIndexChanged, New EventHandler(AddressOf Me.SelectedIndexChanged)
			AddHandler Me.demoRibbonBar.AdvancedClicked, New EventHandler(Of RibbonBarGroupArgs)(AddressOf Me.AdvancedClicked)
			Me.rbView.Groups.Add(Me.rbGroupBookmarks)
			Me.rbView.Groups.Add(Me.rbGroupAdvanced)
			Me.rbView.Text = "View"
			Me.rbGroupBookmarks.Text = "Bookmarks"
			Me.rbGroupAdvanced.HasAdvanced = True
			Me.rbGroupAdvanced.Text = "Advanced"
			Me.rbEdit.Groups.Add(Me.rbGroupFind)
			Me.rbEdit.Groups.Add(Me.rbGroupIntelliSence)
			Me.rbEdit.Text = "Edit"
			Me.rbGroupFind.HasAdvanced = True
			Me.rbGroupFind.Text = "Find and Replace"
			Me.rbGroupIntelliSence.Text = "IntelliSence"
			Me.lblStatus.AutoSize = True
			Me.lblStatus.ForeColor = Color.RoyalBlue
			Me.lblStatus.Location = New Point(8, &H11)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Size(&H23, 13)
			Me.lblStatus.TabIndex = 0
			Me.lblStatus.Text = "The Active page:"
			Me.groupBox1.Controls.Add(Me.lblAdvanced)
			Me.groupBox1.Controls.Add(Me.lblStatus)
			Me.groupBox1.Dock = DockStyle.Fill
			Me.groupBox1.FlatStyle = FlatStyle.Flat
			Me.groupBox1.Location = New Point(0, &H73)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New Size(&H2AE, &H8E)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.lblAdvanced.AutoSize = True
			Me.lblAdvanced.ForeColor = Color.SlateBlue
			Me.lblAdvanced.Location = New Point(8, 40)
			Me.lblAdvanced.Name = "lblAdvanced"
			Me.lblAdvanced.Size = New Size(&H23, 13)
			Me.lblAdvanced.TabIndex = 0
			Me.lblAdvanced.Text = "Advanced clicked:"
			Me.lblAdvanced.Visible = False
			MyBase.Controls.Add(Me.groupBox1)
			MyBase.Controls.Add(Me.demoRibbonBar)
			MyBase.Size = New Size(&H2AE, &H101)
			Me.Text = "AddingGroupsPage"
			Me.groupBox1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Fields
		Private demoRibbonBar As Gizmox.WebGUI.Forms.RibbonBar
		Private groupBox1 As Gizmox.WebGUI.Forms.GroupBox
		Private lblAdvanced As Label
		Private lblStatus As Label
		Private rbEdit As RibbonBarPage
		Private rbGroupAdvanced As RibbonBarGroup
		Private rbGroupBookmarks As RibbonBarGroup
		Private rbGroupFind As RibbonBarGroup
		Private rbGroupIntelliSence As RibbonBarGroup
		Private rbView As RibbonBarPage
	End Class

End Namespace