Namespace CompanionKit.Concepts.VisualEffects.TextShadow

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextShadowPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(TextShadowPage))
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjColorPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjToggleButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjColorDialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFirstPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColorContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjShadowColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjSecondPanel.SuspendLayout()
            Me.mobjFirstPanel.SuspendLayout()
            Me.mobjColorContainerPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTextLabel
            ' 
            Me.mobjTextLabel.AccessibleDescription = ""
            Me.mobjTextLabel.AccessibleName = ""
            Me.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLabel.Location = New System.Drawing.Point(30, 0)
            Me.mobjTextLabel.Name = "objTextLabel"
            Me.mobjTextLabel.Size = New System.Drawing.Size(267, 140)
            Me.mobjTextLabel.TabIndex = 12
            Me.mobjTextLabel.Text = resources.GetString("mobjTextLabel.Text")
            Me.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjColorPanel
            ' 
            Me.mobjColorPanel.AccessibleDescription = ""
            Me.mobjColorPanel.AccessibleName = ""
            Me.mobjColorPanel.BackColor = System.Drawing.Color.LightGray
            Me.mobjColorPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjColorPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjColorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColorPanel.Location = New System.Drawing.Point(15, 0)
            Me.mobjColorPanel.Name = "objColorPanel"
            Me.mobjColorPanel.Size = New System.Drawing.Size(59, 41)
            Me.mobjColorPanel.TabIndex = 11
            ' 
            ' mobjToggleButton
            ' 
            Me.mobjToggleButton.AccessibleDescription = ""
            Me.mobjToggleButton.AccessibleName = ""
            Me.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjToggleButton.Location = New System.Drawing.Point(30, 5)
            Me.mobjToggleButton.Name = "objApplyButton"
            Me.mobjToggleButton.Size = New System.Drawing.Size(267, 45)
            Me.mobjToggleButton.TabIndex = 8
            Me.mobjToggleButton.Text = "Show TextShadow"
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.Controls.Add(Me.mobjSecondPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjFirstPanel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(327, 126)
            Me.mobjTopPanel.TabIndex = 13
            ' 
            ' mobjSecondPanel
            ' 
            Me.mobjSecondPanel.AccessibleDescription = ""
            Me.mobjSecondPanel.AccessibleName = ""
            Me.mobjSecondPanel.Controls.Add(Me.mobjToggleButton)
            Me.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondPanel.DockPadding.Bottom = 5
            Me.mobjSecondPanel.DockPadding.Left = 30
            Me.mobjSecondPanel.DockPadding.Right = 30
            Me.mobjSecondPanel.DockPadding.Top = 5
            Me.mobjSecondPanel.Location = New System.Drawing.Point(0, 71)
            Me.mobjSecondPanel.Name = "mobjSecondPanel"
            Me.mobjSecondPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5)
            Me.mobjSecondPanel.Size = New System.Drawing.Size(327, 55)
            Me.mobjSecondPanel.TabIndex = 13
            ' 
            ' mobjFirstPanel
            ' 
            Me.mobjFirstPanel.AccessibleDescription = ""
            Me.mobjFirstPanel.AccessibleName = ""
            Me.mobjFirstPanel.Controls.Add(Me.mobjColorContainerPanel)
            Me.mobjFirstPanel.Controls.Add(Me.mobjShadowColorButton)
            Me.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFirstPanel.DockPadding.Bottom = 5
            Me.mobjFirstPanel.DockPadding.Left = 30
            Me.mobjFirstPanel.DockPadding.Top = 25
            Me.mobjFirstPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstPanel.Name = "mobjFirstPanel"
            Me.mobjFirstPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 25, 0, 5)
            Me.mobjFirstPanel.Size = New System.Drawing.Size(327, 71)
            Me.mobjFirstPanel.TabIndex = 12
            ' 
            ' panel1
            ' 
            Me.mobjColorContainerPanel.AccessibleDescription = ""
            Me.mobjColorContainerPanel.AccessibleName = ""
            Me.mobjColorContainerPanel.Controls.Add(Me.mobjColorPanel)
            Me.mobjColorContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColorContainerPanel.DockPadding.Left = 15
            Me.mobjColorContainerPanel.Location = New System.Drawing.Point(176, 25)
            Me.mobjColorContainerPanel.Name = "panel1"
            Me.mobjColorContainerPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0)
            Me.mobjColorContainerPanel.Size = New System.Drawing.Size(121, 41)
            Me.mobjColorContainerPanel.TabIndex = 13
            ' 
            ' mobjShadowColorButton
            ' 
            Me.mobjShadowColorButton.AccessibleDescription = ""
            Me.mobjShadowColorButton.AccessibleName = ""
            Me.mobjShadowColorButton.AutoSize = True
            Me.mobjShadowColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjShadowColorButton.Location = New System.Drawing.Point(30, 25)
            Me.mobjShadowColorButton.Name = "mobjShadowColorButton"
            Me.mobjShadowColorButton.Size = New System.Drawing.Size(146, 41)
            Me.mobjShadowColorButton.TabIndex = 12
            Me.mobjShadowColorButton.Text = "Choose ShadowColor"
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjTextLabel)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.DockPadding.Left = 30
            Me.mobjBottomPanel.DockPadding.Right = 30
            Me.mobjBottomPanel.Location = New System.Drawing.Point(0, 126)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 0, 30, 0)
            Me.mobjBottomPanel.Size = New System.Drawing.Size(327, 140)
            Me.mobjBottomPanel.TabIndex = 14
            ' 
            ' TextShadowPage
            ' 
            Me.Controls.Add(Me.mobjBottomPanel)
            Me.Controls.Add(Me.mobjTopPanel)
            Me.Size = New System.Drawing.Size(327, 266)
            Me.Text = "TextShadowPage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjSecondPanel.ResumeLayout(False)
            Me.mobjFirstPanel.ResumeLayout(False)
            Me.mobjColorContainerPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjColorPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjToggleButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjColorDialog As Gizmox.WebGUI.Forms.ColorDialog
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFirstPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjShadowColorButton As Gizmox.WebGUI.Forms.Button
        Private mobjColorContainerPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace