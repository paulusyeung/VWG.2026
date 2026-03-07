Namespace CompanionKit.Controls.ErrorProvider.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ErrorProviderValidatingAFormPage
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorProviderValidatingAFormPage))
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTLPGroup = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjFNLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjEmailTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjGenderCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjEmailLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLNLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPasswordTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjUsernameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjUsernameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPassLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLastNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjGenderLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFirstNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjAgreeTermsCheck = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjRegisterButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjErrorProviderSuccess = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjErrorProviderFailed = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjTLPMain = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjTLPGroup.SuspendLayout()
            Me.mobjTLPMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjGroupBox
            '
            Me.mobjTLPMain.SetColumnSpan(Me.mobjGroupBox, 2)
            Me.mobjGroupBox.Controls.Add(Me.mobjTLPGroup)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(320, 320)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Registration Data"
            '
            'mobjTLPGroup
            '
            Me.mobjTLPGroup.ColumnCount = 2
            Me.mobjTLPGroup.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLPGroup.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0!))
            Me.mobjTLPGroup.Controls.Add(Me.mobjFNLabel, 0, 0)
            Me.mobjTLPGroup.Controls.Add(Me.mobjEmailTextBox, 1, 5)
            Me.mobjTLPGroup.Controls.Add(Me.mobjGenderCB, 1, 4)
            Me.mobjTLPGroup.Controls.Add(Me.mobjEmailLabel, 0, 5)
            Me.mobjTLPGroup.Controls.Add(Me.mobjLNLabel, 0, 1)
            Me.mobjTLPGroup.Controls.Add(Me.mobjPasswordTextBox, 1, 3)
            Me.mobjTLPGroup.Controls.Add(Me.mobjUsernameLabel, 0, 2)
            Me.mobjTLPGroup.Controls.Add(Me.mobjUsernameTextBox, 1, 2)
            Me.mobjTLPGroup.Controls.Add(Me.mobjPassLabel, 0, 3)
            Me.mobjTLPGroup.Controls.Add(Me.mobjLastNameTextBox, 1, 1)
            Me.mobjTLPGroup.Controls.Add(Me.mobjGenderLabel, 0, 4)
            Me.mobjTLPGroup.Controls.Add(Me.mobjFirstNameTextBox, 1, 0)
            Me.mobjTLPGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLPGroup.Location = New System.Drawing.Point(3, 17)
            Me.mobjTLPGroup.Name = "mobjTLPGroup"
            Me.mobjTLPGroup.RowCount = 6
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 16.66667!))
            Me.mobjTLPGroup.Size = New System.Drawing.Size(314, 300)
            Me.mobjTLPGroup.TabIndex = 12
            '
            'mobjFNLabel
            '
            Me.mobjFNLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFNLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFNLabel.Name = "mobjFNLabel"
            Me.mobjFNLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjFNLabel.Size = New System.Drawing.Size(125, 49)
            Me.mobjFNLabel.TabIndex = 0
            Me.mobjFNLabel.Text = "First Name"
            Me.mobjFNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjEmailTextBox
            '
            Me.mobjEmailTextBox.AllowDrag = False
            Me.mobjEmailTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjEmailTextBox.Location = New System.Drawing.Point(135, 260)
            Me.mobjEmailTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjEmailTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjEmailTextBox.Name = "mobjEmailTextBox"
            Me.mobjEmailTextBox.Size = New System.Drawing.Size(139, 25)
            Me.mobjEmailTextBox.TabIndex = 9
            '
            'mobjGenderCB
            '
            Me.mobjGenderCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjGenderCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjGenderCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjGenderCB.FormattingEnabled = True
            Me.mobjGenderCB.Location = New System.Drawing.Point(135, 210)
            Me.mobjGenderCB.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 40, 0)
            Me.mobjGenderCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjGenderCB.Name = "mobjGenderCB"
            Me.mobjGenderCB.Size = New System.Drawing.Size(139, 25)
            Me.mobjGenderCB.TabIndex = 10
            '
            'mobjEmailLabel
            '
            Me.mobjEmailLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjEmailLabel.Location = New System.Drawing.Point(0, 245)
            Me.mobjEmailLabel.Name = "mobjEmailLabel"
            Me.mobjEmailLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjEmailLabel.Size = New System.Drawing.Size(125, 55)
            Me.mobjEmailLabel.TabIndex = 11
            Me.mobjEmailLabel.Text = "Email"
            Me.mobjEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjLNLabel
            '
            Me.mobjLNLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLNLabel.Location = New System.Drawing.Point(0, 49)
            Me.mobjLNLabel.Name = "mobjLNLabel"
            Me.mobjLNLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLNLabel.Size = New System.Drawing.Size(125, 49)
            Me.mobjLNLabel.TabIndex = 2
            Me.mobjLNLabel.Text = "Last Name"
            Me.mobjLNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjPasswordTextBox
            '
            Me.mobjPasswordTextBox.AllowDrag = False
            Me.mobjPasswordTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjPasswordTextBox.Location = New System.Drawing.Point(135, 159)
            Me.mobjPasswordTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjPasswordTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPasswordTextBox.Name = "mobjPasswordTextBox"
            Me.mobjPasswordTextBox.Size = New System.Drawing.Size(139, 25)
            Me.mobjPasswordTextBox.TabIndex = 8
            '
            'mobjUsernameLabel
            '
            Me.mobjUsernameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUsernameLabel.Location = New System.Drawing.Point(0, 98)
            Me.mobjUsernameLabel.Name = "mobjUsernameLabel"
            Me.mobjUsernameLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjUsernameLabel.Size = New System.Drawing.Size(125, 49)
            Me.mobjUsernameLabel.TabIndex = 3
            Me.mobjUsernameLabel.Text = "Username"
            Me.mobjUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjUsernameTextBox
            '
            Me.mobjUsernameTextBox.AllowDrag = False
            Me.mobjUsernameTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjUsernameTextBox.Location = New System.Drawing.Point(135, 110)
            Me.mobjUsernameTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjUsernameTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjUsernameTextBox.Name = "mobjUsernameTextBox"
            Me.mobjUsernameTextBox.Size = New System.Drawing.Size(139, 25)
            Me.mobjUsernameTextBox.TabIndex = 7
            '
            'mobjPassLabel
            '
            Me.mobjPassLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPassLabel.Location = New System.Drawing.Point(0, 147)
            Me.mobjPassLabel.Name = "mobjPassLabel"
            Me.mobjPassLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjPassLabel.Size = New System.Drawing.Size(125, 49)
            Me.mobjPassLabel.TabIndex = 4
            Me.mobjPassLabel.Text = "Password"
            Me.mobjPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjLastNameTextBox
            '
            Me.mobjLastNameTextBox.AllowDrag = False
            Me.mobjLastNameTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjLastNameTextBox.Location = New System.Drawing.Point(135, 61)
            Me.mobjLastNameTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjLastNameTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjLastNameTextBox.Name = "mobjLastNameTextBox"
            Me.mobjLastNameTextBox.Size = New System.Drawing.Size(139, 25)
            Me.mobjLastNameTextBox.TabIndex = 6
            '
            'mobjGenderLabel
            '
            Me.mobjGenderLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGenderLabel.Location = New System.Drawing.Point(0, 196)
            Me.mobjGenderLabel.Name = "mobjGenderLabel"
            Me.mobjGenderLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjGenderLabel.Size = New System.Drawing.Size(125, 49)
            Me.mobjGenderLabel.TabIndex = 5
            Me.mobjGenderLabel.Text = "Gender"
            Me.mobjGenderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjFirstNameTextBox
            '
            Me.mobjFirstNameTextBox.AllowDrag = False
            Me.mobjFirstNameTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjFirstNameTextBox.Location = New System.Drawing.Point(135, 12)
            Me.mobjFirstNameTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjFirstNameTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjFirstNameTextBox.Name = "mobjFirstNameTextBox"
            Me.mobjFirstNameTextBox.Size = New System.Drawing.Size(139, 25)
            Me.mobjFirstNameTextBox.TabIndex = 1
            '
            'mobjAgreeTermsCheck
            '
            Me.mobjAgreeTermsCheck.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjAgreeTermsCheck.Location = New System.Drawing.Point(13, 335)
            Me.mobjAgreeTermsCheck.Margin = New Gizmox.WebGUI.Forms.Padding(0, 15, 15, 0)
            Me.mobjAgreeTermsCheck.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjAgreeTermsCheck.Name = "mobjAgreeTermsCheck"
            Me.mobjAgreeTermsCheck.Size = New System.Drawing.Size(100, 50)
            Me.mobjAgreeTermsCheck.TabIndex = 1
            Me.mobjAgreeTermsCheck.Text = "I agree terms"
            Me.mobjAgreeTermsCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjAgreeTermsCheck.UseVisualStyleBackColor = True
            '
            'mobjRegisterButton
            '
            Me.mobjRegisterButton.Location = New System.Drawing.Point(143, 335)
            Me.mobjRegisterButton.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjRegisterButton.MaximumSize = New System.Drawing.Size(150, 50)
            Me.mobjRegisterButton.Name = "mobjRegisterButton"
            Me.mobjRegisterButton.Size = New System.Drawing.Size(130, 50)
            Me.mobjRegisterButton.TabIndex = 2
            Me.mobjRegisterButton.Text = "Register"
            Me.mobjRegisterButton.UseVisualStyleBackColor = True
            '
            'mobjErrorProviderSuccess
            '
            Me.mobjErrorProviderSuccess.BlinkRate = 3
            Me.mobjErrorProviderSuccess.Icon = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjErrorProviderSuccess.Icon"))
            '
            'mobjErrorProviderFailed
            '
            Me.mobjErrorProviderFailed.BlinkRate = 3
            Me.mobjErrorProviderFailed.Icon = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjErrorProviderFailed.Icon"))
            '
            'mobjTLPMain
            '
            Me.mobjTLPMain.ColumnCount = 2
            Me.mobjTLPMain.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLPMain.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0!))
            Me.mobjTLPMain.Controls.Add(Me.mobjGroupBox, 0, 0)
            Me.mobjTLPMain.Controls.Add(Me.mobjAgreeTermsCheck, 0, 1)
            Me.mobjTLPMain.Controls.Add(Me.mobjRegisterButton, 1, 1)
            Me.mobjTLPMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLPMain.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLPMain.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLPMain.Name = "mobjTLPMain"
            Me.mobjTLPMain.RowCount = 2
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0!))
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPMain.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLPMain.TabIndex = 3
            '
            'ErrorProviderValidatingAFormPage
            '
            Me.Controls.Add(Me.mobjTLPMain)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ErrorProviderValidatingAFormPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjTLPGroup.ResumeLayout(False)
            Me.mobjTLPMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjGenderLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjPassLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjUsernameLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLNLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjFirstNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjFNLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjEmailLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjGenderCB As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjEmailTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjPasswordTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjUsernameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjLastNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjAgreeTermsCheck As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjRegisterButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjErrorProviderSuccess As Gizmox.WebGUI.Forms.ErrorProvider
        Private WithEvents mobjErrorProviderFailed As Gizmox.WebGUI.Forms.ErrorProvider
        Private WithEvents mobjTLPMain As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjTLPGroup As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace