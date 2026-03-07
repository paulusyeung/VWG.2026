Namespace CompanionKit.Concepts.VisualEffects.GradientBackground

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class GradientBackgroundPage
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
            Me.mobjToggleButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjGradientTypeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjGradientTypeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjColor1Dialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjColor2Dialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFourthTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjThirdTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPaddingPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColor2Panel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColor2ChooseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSecondTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPaddingPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColor1Panel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColor1ChooseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFirstTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjComboBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjFourthTopPanel.SuspendLayout()
            Me.mobjThirdTopPanel.SuspendLayout()
            Me.mobjPaddingPanel2.SuspendLayout()
            Me.mobjSecondTopPanel.SuspendLayout()
            Me.mobjPaddingPanel1.SuspendLayout()
            Me.mobjFirstTopPanel.SuspendLayout()
            Me.mobjComboBoxPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjToggleButton
            ' 
            Me.mobjToggleButton.AccessibleDescription = ""
            Me.mobjToggleButton.AccessibleName = ""
            Me.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjToggleButton.Location = New System.Drawing.Point(30, 5)
            Me.mobjToggleButton.Name = "objApplyButton"
            Me.mobjToggleButton.Size = New System.Drawing.Size(231, 50)
            Me.mobjToggleButton.TabIndex = 12
            Me.mobjToggleButton.Text = "Show GradientBackground"
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.AccessibleDescription = ""
            Me.mobjListBox.AccessibleName = ""
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"Item1", "Item2", "Item3", "Item4", "Item5"})
            Me.mobjListBox.Location = New System.Drawing.Point(60, 30)
            Me.mobjListBox.Name = "objListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(171, 160)
            Me.mobjListBox.TabIndex = 13
            ' 
            ' mobjGradientTypeComboBox
            ' 
            Me.mobjGradientTypeComboBox.AccessibleDescription = ""
            Me.mobjGradientTypeComboBox.AccessibleName = ""
            Me.mobjGradientTypeComboBox.AllowDrag = False
            Me.mobjGradientTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjGradientTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjGradientTypeComboBox.FormattingEnabled = True
            Me.mobjGradientTypeComboBox.Items.AddRange(New Object() {"Linear", "Radial", "RepeatingLinearGradient", "RepeatingRadialGradient"})
            Me.mobjGradientTypeComboBox.Location = New System.Drawing.Point(15, 0)
            Me.mobjGradientTypeComboBox.Name = "objGradientTypeComboBox"
            Me.mobjGradientTypeComboBox.Size = New System.Drawing.Size(131, 21)
            Me.mobjGradientTypeComboBox.TabIndex = 3
            Me.mobjGradientTypeComboBox.Text = "Linear"
            ' 
            ' mobjGradientTypeLabel
            ' 
            Me.mobjGradientTypeLabel.AccessibleDescription = ""
            Me.mobjGradientTypeLabel.AccessibleName = ""
            Me.mobjGradientTypeLabel.AutoSize = True
            Me.mobjGradientTypeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjGradientTypeLabel.Location = New System.Drawing.Point(30, 10)
            Me.mobjGradientTypeLabel.Name = "objGradientTypeLabel"
            Me.mobjGradientTypeLabel.Size = New System.Drawing.Size(72, 13)
            Me.mobjGradientTypeLabel.TabIndex = 0
            Me.mobjGradientTypeLabel.Text = "GradientType"
            Me.mobjGradientTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.mobjGradientTypeLabel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect()
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.Controls.Add(Me.mobjFourthTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjThirdTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjSecondTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjFirstTopPanel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(291, 197)
            Me.mobjTopPanel.TabIndex = 14
            ' 
            ' mobjFourthTopPanel
            ' 
            Me.mobjFourthTopPanel.AccessibleDescription = ""
            Me.mobjFourthTopPanel.AccessibleName = ""
            Me.mobjFourthTopPanel.Controls.Add(Me.mobjToggleButton)
            Me.mobjFourthTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFourthTopPanel.DockPadding.Bottom = 5
            Me.mobjFourthTopPanel.DockPadding.Left = 30
            Me.mobjFourthTopPanel.DockPadding.Right = 30
            Me.mobjFourthTopPanel.DockPadding.Top = 5
            Me.mobjFourthTopPanel.Location = New System.Drawing.Point(0, 137)
            Me.mobjFourthTopPanel.Name = "mobjFourthTopPanel"
            Me.mobjFourthTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5)
            Me.mobjFourthTopPanel.Size = New System.Drawing.Size(291, 60)
            Me.mobjFourthTopPanel.TabIndex = 17
            ' 
            ' mobjThirdTopPanel
            ' 
            Me.mobjThirdTopPanel.AccessibleDescription = ""
            Me.mobjThirdTopPanel.AccessibleName = ""
            Me.mobjThirdTopPanel.Controls.Add(Me.mobjPaddingPanel2)
            Me.mobjThirdTopPanel.Controls.Add(Me.mobjColor2ChooseButton)
            Me.mobjThirdTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjThirdTopPanel.DockPadding.Bottom = 5
            Me.mobjThirdTopPanel.DockPadding.Left = 30
            Me.mobjThirdTopPanel.DockPadding.Top = 5
            Me.mobjThirdTopPanel.Location = New System.Drawing.Point(0, 84)
            Me.mobjThirdTopPanel.Name = "mobjThirdTopPanel"
            Me.mobjThirdTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 5, 0, 5)
            Me.mobjThirdTopPanel.Size = New System.Drawing.Size(291, 50)
            Me.mobjThirdTopPanel.TabIndex = 13
            ' 
            ' mobjPaddingPanel2
            ' 
            Me.mobjPaddingPanel2.AccessibleDescription = ""
            Me.mobjPaddingPanel2.AccessibleName = ""
            Me.mobjPaddingPanel2.Controls.Add(Me.mobjColor2Panel)
            Me.mobjPaddingPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPaddingPanel2.DockPadding.Left = 15
            Me.mobjPaddingPanel2.Location = New System.Drawing.Point(141, 5)
            Me.mobjPaddingPanel2.Name = "mobjPaddingPanel2"
            Me.mobjPaddingPanel2.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0)
            Me.mobjPaddingPanel2.Size = New System.Drawing.Size(115, 40)
            Me.mobjPaddingPanel2.TabIndex = 15
            ' 
            ' mobjColor2Panel
            ' 
            Me.mobjColor2Panel.AccessibleDescription = ""
            Me.mobjColor2Panel.AccessibleName = ""
            Me.mobjColor2Panel.BackColor = System.Drawing.Color.White
            Me.mobjColor2Panel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjColor2Panel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjColor2Panel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColor2Panel.Location = New System.Drawing.Point(15, 0)
            Me.mobjColor2Panel.Name = "objColor2Panel"
            Me.mobjColor2Panel.Size = New System.Drawing.Size(63, 40)
            Me.mobjColor2Panel.TabIndex = 13
            ' 
            ' mobjColor2ChooseButton
            ' 
            Me.mobjColor2ChooseButton.AccessibleDescription = ""
            Me.mobjColor2ChooseButton.AccessibleName = ""
            Me.mobjColor2ChooseButton.AutoSize = True
            Me.mobjColor2ChooseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColor2ChooseButton.Location = New System.Drawing.Point(30, 5)
            Me.mobjColor2ChooseButton.Name = "mobjColor2ChooseButton"
            Me.mobjColor2ChooseButton.Size = New System.Drawing.Size(111, 40)
            Me.mobjColor2ChooseButton.TabIndex = 14
            Me.mobjColor2ChooseButton.Text = "Choose Color2"
            ' 
            ' mobjSecondTopPanel
            ' 
            Me.mobjSecondTopPanel.AccessibleDescription = ""
            Me.mobjSecondTopPanel.AccessibleName = ""
            Me.mobjSecondTopPanel.Controls.Add(Me.mobjPaddingPanel1)
            Me.mobjSecondTopPanel.Controls.Add(Me.mobjColor1ChooseButton)
            Me.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSecondTopPanel.DockPadding.Bottom = 5
            Me.mobjSecondTopPanel.DockPadding.Left = 30
            Me.mobjSecondTopPanel.DockPadding.Top = 5
            Me.mobjSecondTopPanel.Location = New System.Drawing.Point(0, 37)
            Me.mobjSecondTopPanel.Name = "mobjSecondTopPanel"
            Me.mobjSecondTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 5, 0, 5)
            Me.mobjSecondTopPanel.Size = New System.Drawing.Size(291, 50)
            Me.mobjSecondTopPanel.TabIndex = 16
            ' 
            ' mobjPaddingPanel1
            ' 
            Me.mobjPaddingPanel1.AccessibleDescription = ""
            Me.mobjPaddingPanel1.AccessibleName = ""
            Me.mobjPaddingPanel1.Controls.Add(Me.mobjColor1Panel)
            Me.mobjPaddingPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPaddingPanel1.DockPadding.Left = 15
            Me.mobjPaddingPanel1.Location = New System.Drawing.Point(141, 5)
            Me.mobjPaddingPanel1.Name = "mobjPaddingPanel1"
            Me.mobjPaddingPanel1.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0)
            Me.mobjPaddingPanel1.Size = New System.Drawing.Size(115, 40)
            Me.mobjPaddingPanel1.TabIndex = 16
            ' 
            ' mobjColor1Panel
            ' 
            Me.mobjColor1Panel.AccessibleDescription = ""
            Me.mobjColor1Panel.AccessibleName = ""
            Me.mobjColor1Panel.BackColor = System.Drawing.Color.Black
            Me.mobjColor1Panel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjColor1Panel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjColor1Panel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColor1Panel.Location = New System.Drawing.Point(15, 0)
            Me.mobjColor1Panel.Name = "objColor1Panel"
            Me.mobjColor1Panel.Size = New System.Drawing.Size(63, 40)
            Me.mobjColor1Panel.TabIndex = 14
            ' 
            ' mobjColor1ChooseButton
            ' 
            Me.mobjColor1ChooseButton.AccessibleDescription = ""
            Me.mobjColor1ChooseButton.AccessibleName = ""
            Me.mobjColor1ChooseButton.AutoSize = True
            Me.mobjColor1ChooseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColor1ChooseButton.Location = New System.Drawing.Point(30, 5)
            Me.mobjColor1ChooseButton.Name = "mobjColor1ChooseButton"
            Me.mobjColor1ChooseButton.Size = New System.Drawing.Size(111, 40)
            Me.mobjColor1ChooseButton.TabIndex = 15
            Me.mobjColor1ChooseButton.Text = "Choose Color1"
            ' 
            ' mobjFirstTopPanel
            ' 
            Me.mobjFirstTopPanel.AccessibleDescription = ""
            Me.mobjFirstTopPanel.AccessibleName = ""
            Me.mobjFirstTopPanel.Controls.Add(Me.mobjComboBoxPanel)
            Me.mobjFirstTopPanel.Controls.Add(Me.mobjGradientTypeLabel)
            Me.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFirstTopPanel.DockPadding.Left = 30
            Me.mobjFirstTopPanel.DockPadding.Top = 10
            Me.mobjFirstTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstTopPanel.Name = "mobjFirstTopPanel"
            Me.mobjFirstTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 10, 0, 0)
            Me.mobjFirstTopPanel.Size = New System.Drawing.Size(291, 37)
            Me.mobjFirstTopPanel.TabIndex = 15
            ' 
            ' mobjComboBoxPanel
            ' 
            Me.mobjComboBoxPanel.AccessibleDescription = ""
            Me.mobjComboBoxPanel.AccessibleName = ""
            Me.mobjComboBoxPanel.Controls.Add(Me.mobjGradientTypeComboBox)
            Me.mobjComboBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjComboBoxPanel.DockPadding.Left = 15
            Me.mobjComboBoxPanel.Location = New System.Drawing.Point(102, 10)
            Me.mobjComboBoxPanel.Name = "mobjComboBoxPanel"
            Me.mobjComboBoxPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0)
            Me.mobjComboBoxPanel.Size = New System.Drawing.Size(159, 27)
            Me.mobjComboBoxPanel.TabIndex = 4
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjListBox)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.DockPadding.Bottom = 30
            Me.mobjBottomPanel.DockPadding.Left = 60
            Me.mobjBottomPanel.DockPadding.Right = 60
            Me.mobjBottomPanel.DockPadding.Top = 30
            Me.mobjBottomPanel.Location = New System.Drawing.Point(0, 197)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(60, 30, 60, 30)
            Me.mobjBottomPanel.Size = New System.Drawing.Size(291, 223)
            Me.mobjBottomPanel.TabIndex = 15
            ' 
            ' GradientBackgroundPage
            ' 
            Me.Controls.Add(Me.mobjBottomPanel)
            Me.Controls.Add(Me.mobjTopPanel)
            Me.Size = New System.Drawing.Size(291, 420)
            Me.Text = "GradientBackgroundPage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjFourthTopPanel.ResumeLayout(False)
            Me.mobjThirdTopPanel.ResumeLayout(False)
            Me.mobjPaddingPanel2.ResumeLayout(False)
            Me.mobjSecondTopPanel.ResumeLayout(False)
            Me.mobjPaddingPanel1.ResumeLayout(False)
            Me.mobjFirstTopPanel.ResumeLayout(False)
            Me.mobjComboBoxPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjToggleButton As Gizmox.WebGUI.Forms.Button
        Private mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjGradientTypeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjGradientTypeLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjColor1Dialog As Gizmox.WebGUI.Forms.ColorDialog
        Private WithEvents mobjColor2Dialog As Gizmox.WebGUI.Forms.ColorDialog
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjColor1Panel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjColor2Panel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFirstTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFourthTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjThirdTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjComboBoxPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjPaddingPanel2 As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjColor2ChooseButton As Gizmox.WebGUI.Forms.Button
        Private mobjPaddingPanel1 As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjColor1ChooseButton As Gizmox.WebGUI.Forms.Button


	End Class

End Namespace