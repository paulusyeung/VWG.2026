Namespace CompanionKit.Concepts.ControlBehavior.Resizable

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResizablePage
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

            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabelInfo = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAspectRatio = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjIsGhost = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjIsAnimated = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabelSize = New Gizmox.WebGUI.Forms.Label()
            Me.mobjResetButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDurationLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDurationNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjGridLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjGridNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            DirectCast(Me.mobjDurationNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjGridNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.BackColor = System.Drawing.Color.LightGray
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjPanel.Location = New System.Drawing.Point(12, 54)
            Me.mobjPanel.MaximumSize = New System.Drawing.Size(200, 200)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Resizable = New Gizmox.WebGUI.Forms.ResizableOptions(True)
            Me.mobjPanel.Size = New System.Drawing.Size(100, 100)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjLabelInfo
            ' 
            Me.mobjLabelInfo.AccessibleDescription = ""
            Me.mobjLabelInfo.AccessibleName = ""
            Me.mobjLabelInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabelInfo.Location = New System.Drawing.Point(9, 9)
            Me.mobjLabelInfo.Name = "mobjLabelInfo"
            Me.mobjLabelInfo.Size = New System.Drawing.Size(495, 45)
            Me.mobjLabelInfo.TabIndex = 1
            Me.mobjLabelInfo.Text = "Resizable Panel. Maximum size {200, 200}."
            ' 
            ' mobjAspectRatio
            ' 
            Me.mobjAspectRatio.AccessibleDescription = ""
            Me.mobjAspectRatio.AccessibleName = ""
            Me.mobjAspectRatio.Location = New System.Drawing.Point(9, 25)
            Me.mobjAspectRatio.Name = "mobjAspectRatio"
            Me.mobjAspectRatio.Size = New System.Drawing.Size(175, 25)
            Me.mobjAspectRatio.TabIndex = 3
            Me.mobjAspectRatio.Text = "Aspect Ratio"
            ' 
            ' mobjIsGhost
            ' 
            Me.mobjIsGhost.AccessibleDescription = ""
            Me.mobjIsGhost.AccessibleName = ""
            Me.mobjIsGhost.Location = New System.Drawing.Point(9, 52)
            Me.mobjIsGhost.Name = "mobjIsGhost"
            Me.mobjIsGhost.Size = New System.Drawing.Size(175, 25)
            Me.mobjIsGhost.TabIndex = 4
            Me.mobjIsGhost.Text = "Ghost"
            ' 
            ' mobjIsAnimated
            ' 
            Me.mobjIsAnimated.AccessibleDescription = ""
            Me.mobjIsAnimated.AccessibleName = ""
            Me.mobjIsAnimated.Location = New System.Drawing.Point(9, 79)
            Me.mobjIsAnimated.Name = "mobjIsAnimated"
            Me.mobjIsAnimated.Size = New System.Drawing.Size(175, 25)
            Me.mobjIsAnimated.TabIndex = 5
            Me.mobjIsAnimated.Text = "Animation"
            ' 
            ' mobjLabelSize
            ' 
            Me.mobjLabelSize.AccessibleDescription = ""
            Me.mobjLabelSize.AccessibleName = ""
            Me.mobjLabelSize.AutoSize = True
            Me.mobjLabelSize.Location = New System.Drawing.Point(9, 264)
            Me.mobjLabelSize.Name = "mobjLabelSize"
            Me.mobjLabelSize.Size = New System.Drawing.Size(33, 13)
            Me.mobjLabelSize.TabIndex = 6
            Me.mobjLabelSize.Text = "Size: "
            ' 
            ' mobjResetButton
            ' 
            Me.mobjResetButton.AccessibleDescription = ""
            Me.mobjResetButton.AccessibleName = ""
            Me.mobjResetButton.Location = New System.Drawing.Point(272, 257)
            Me.mobjResetButton.Name = "mobjResetButton"
            Me.mobjResetButton.Size = New System.Drawing.Size(148, 27)
            Me.mobjResetButton.TabIndex = 7
            Me.mobjResetButton.Text = "Reset Size"
            ' 
            ' mobjDurationLbl
            ' 
            Me.mobjDurationLbl.AccessibleDescription = ""
            Me.mobjDurationLbl.AccessibleName = ""
            Me.mobjDurationLbl.Location = New System.Drawing.Point(9, 112)
            Me.mobjDurationLbl.Name = "mobjDurationLbl"
            Me.mobjDurationLbl.Size = New System.Drawing.Size(138, 25)
            Me.mobjDurationLbl.TabIndex = 8
            Me.mobjDurationLbl.Text = "Animation duration:"
            ' 
            ' mobjDurationNUD
            ' 
            Me.mobjDurationNUD.AccessibleDescription = ""
            Me.mobjDurationNUD.AccessibleName = ""
            Me.mobjDurationNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDurationNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjDurationNUD.CurrentValue = New Decimal(New Integer() {500, 0, 0, 0})
            Me.mobjDurationNUD.Location = New System.Drawing.Point(147, 110)
            Me.mobjDurationNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjDurationNUD.Name = "mobjDurationNUD"
            Me.mobjDurationNUD.Size = New System.Drawing.Size(96, 17)
            Me.mobjDurationNUD.TabIndex = 9
            Me.mobjDurationNUD.Value = New Decimal(New Integer() {500, 0, 0, 0})
            ' 
            ' mobjGridLbl
            ' 
            Me.mobjGridLbl.AccessibleDescription = ""
            Me.mobjGridLbl.AccessibleName = ""
            Me.mobjGridLbl.Location = New System.Drawing.Point(9, 141)
            Me.mobjGridLbl.Name = "mobjGridLbl"
            Me.mobjGridLbl.Size = New System.Drawing.Size(109, 25)
            Me.mobjGridLbl.TabIndex = 11
            Me.mobjGridLbl.Text = "Grid"
            ' 
            ' mobjGridNUD
            ' 
            Me.mobjGridNUD.AccessibleDescription = ""
            Me.mobjGridNUD.AccessibleName = ""
            Me.mobjGridNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjGridNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjGridNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjGridNUD.Location = New System.Drawing.Point(147, 139)
            Me.mobjGridNUD.Name = "mobjGridNUD"
            Me.mobjGridNUD.Size = New System.Drawing.Size(96, 17)
            Me.mobjGridNUD.TabIndex = 13
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.AccessibleDescription = ""
            Me.mobjGroupBox.AccessibleName = ""
            Me.mobjGroupBox.Controls.Add(Me.mobjAspectRatio)
            Me.mobjGroupBox.Controls.Add(Me.mobjIsGhost)
            Me.mobjGroupBox.Controls.Add(Me.mobjIsAnimated)
            Me.mobjGroupBox.Controls.Add(Me.mobjGridNUD)
            Me.mobjGroupBox.Controls.Add(Me.mobjGridLbl)
            Me.mobjGroupBox.Controls.Add(Me.mobjDurationLbl)
            Me.mobjGroupBox.Controls.Add(Me.mobjDurationNUD)
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(211, 51)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(265, 177)
            Me.mobjGroupBox.TabIndex = 17
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Resizable opions:"
            ' 
            ' ResizablePage
            ' 
            Me.Controls.Add(Me.mobjGroupBox)
            Me.Controls.Add(Me.mobjLabelInfo)
            Me.Controls.Add(Me.mobjPanel)
            Me.Controls.Add(Me.mobjLabelSize)
            Me.Controls.Add(Me.mobjResetButton)
            Me.Size = New System.Drawing.Size(495, 364)
            Me.Text = "ResizablePage"
            DirectCast(Me.mobjDurationNUD, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjGridNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjLabelInfo As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjAspectRatio As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjIsGhost As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjIsAnimated As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjLabelSize As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjResetButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjDurationLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjDurationNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjGridLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjGridNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox


	End Class

End Namespace