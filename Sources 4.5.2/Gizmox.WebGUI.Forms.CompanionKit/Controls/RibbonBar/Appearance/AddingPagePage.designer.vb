Imports System.Drawing
Imports Gizmox.WebGUI.Forms
Imports System.ComponentModel


Namespace CompanionKit.Controls.RibbonBar.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddingPagePage
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
			Me.rbPageClipboard = New Gizmox.WebGUI.Forms.RibbonBarPage
			Me.rbPageFormatting = New Gizmox.WebGUI.Forms.RibbonBarPage
			Me.rbPageTools = New Gizmox.WebGUI.Forms.RibbonBarPage
			Me.groupBox1 = New Gizmox.WebGUI.Forms.GroupBox
			Me.lblStatus = New Gizmox.WebGUI.Forms.Label
			Me.groupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.demoRibbonBar.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.demoRibbonBar.Location = New Point(0, 0)
			Me.demoRibbonBar.Name = "demoRibbonBar"
			Me.demoRibbonBar.Pages.Add(Me.rbPageClipboard)
			Me.demoRibbonBar.Pages.Add(Me.rbPageFormatting)
			Me.demoRibbonBar.Pages.Add(Me.rbPageTools)
			Me.demoRibbonBar.SelectedIndex = 0
			Me.demoRibbonBar.TabIndex = 0
			AddHandler Me.demoRibbonBar.SelectedIndexChanged, New EventHandler(AddressOf Me.SelectedIndexChanged)
			Me.rbPageClipboard.Text = "Clipboard"
			Me.rbPageFormatting.Text = "Formatting"
			Me.rbPageTools.Text = "Tools"
			Me.groupBox1.Controls.Add(Me.lblStatus)
			Me.groupBox1.Dock = DockStyle.Fill
			Me.groupBox1.FlatStyle = FlatStyle.Flat
			Me.groupBox1.Location = New Point(0, &H73)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New Size(&H2AE, &H6F)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Location = New Point(8, &H11)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Size(&H23, 13)
			Me.lblStatus.TabIndex = 0
			Me.lblStatus.Text = "The Active page:"
			MyBase.Controls.Add(Me.groupBox1)
			MyBase.Controls.Add(Me.demoRibbonBar)
			MyBase.Size = New Size(&H2AE, &HE2)
			Me.Text = "AddingPagePage"
			Me.groupBox1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Fields
		Friend WithEvents demoRibbonBar As Gizmox.WebGUI.Forms.RibbonBar
		Friend WithEvents groupBox1 As Gizmox.WebGUI.Forms.GroupBox
		Friend WithEvents lblStatus As Gizmox.WebGUI.Forms.Label
		Friend WithEvents rbPageClipboard As Gizmox.WebGUI.Forms.RibbonBarPage
		Friend WithEvents rbPageFormatting As Gizmox.WebGUI.Forms.RibbonBarPage
		Friend WithEvents rbPageTools As Gizmox.WebGUI.Forms.RibbonBarPage

	End Class

End Namespace