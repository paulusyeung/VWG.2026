Namespace CompanionKit.Controls.ErrorProvider.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BlinkStylePropertyPage
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
            Me.mobjShowErrorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBlinkStyleLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjBlinkStyleCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjHideErrorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjShowErrorButton
            '
            Me.mobjShowErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowErrorButton.Location = New System.Drawing.Point(102, 115)
            Me.mobjShowErrorButton.Margin = New Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15)
            Me.mobjShowErrorButton.MaximumSize = New System.Drawing.Size(200, 70)
            Me.mobjShowErrorButton.Name = "mobjShowErrorButton"
            Me.mobjShowErrorButton.Size = New System.Drawing.Size(200, 70)
            Me.mobjShowErrorButton.TabIndex = 4
            Me.mobjShowErrorButton.Text = "Show Error"
            '
            'mobjBlinkStyleLabel
            '
            Me.mobjBlinkStyleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBlinkStyleLabel.Location = New System.Drawing.Point(0, 300)
            Me.mobjBlinkStyleLabel.Name = "mobjBlinkStyleLabel"
            Me.mobjBlinkStyleLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjBlinkStyleLabel.Size = New System.Drawing.Size(87, 100)
            Me.mobjBlinkStyleLabel.TabIndex = 3
            Me.mobjBlinkStyleLabel.Text = "Blink style"
            Me.mobjBlinkStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTextLabel
            '
            Me.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTextLabel.Name = "mobjTextLabel"
            Me.mobjTextLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextLabel.Size = New System.Drawing.Size(87, 100)
            Me.mobjTextLabel.TabIndex = 1
            Me.mobjTextLabel.Text = "Text field with error"
            Me.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextBox.Location = New System.Drawing.Point(97, 37)
            Me.mobjTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(200, 25)
            Me.mobjTextBox.TabIndex = 0
            '
            'mobjBlinkStyleCB
            '
            Me.mobjBlinkStyleCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjBlinkStyleCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjBlinkStyleCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjBlinkStyleCB.FormattingEnabled = True
            Me.mobjBlinkStyleCB.Location = New System.Drawing.Point(97, 339)
            Me.mobjBlinkStyleCB.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 40, 0)
            Me.mobjBlinkStyleCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjBlinkStyleCB.Name = "mobjBlinkStyleCB"
            Me.mobjBlinkStyleCB.Size = New System.Drawing.Size(200, 25)
            Me.mobjBlinkStyleCB.TabIndex = 5
            '
            'mobjErrorProvider
            '
            Me.mobjErrorProvider.BlinkRate = 3
            '
            'mobjHideErrorButton
            '
            Me.mobjHideErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHideErrorButton.Location = New System.Drawing.Point(102, 215)
            Me.mobjHideErrorButton.Margin = New Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15)
            Me.mobjHideErrorButton.MaximumSize = New System.Drawing.Size(200, 70)
            Me.mobjHideErrorButton.Name = "mobjHideErrorButton"
            Me.mobjHideErrorButton.Size = New System.Drawing.Size(200, 70)
            Me.mobjHideErrorButton.TabIndex = 4
            Me.mobjHideErrorButton.Text = "Hide Error"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP.Controls.Add(Me.mobjTextLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTextBox, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjHideErrorButton, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjShowErrorButton, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjBlinkStyleLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjBlinkStyleCB, 1, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(350, 400)
            Me.mobjTLP.TabIndex = 6
            '
            'BlinkStylePropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(350, 400)
            Me.Text = "BlinkStylePropertyPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjShowErrorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjBlinkStyleLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjBlinkStyleCB As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private WithEvents mobjHideErrorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace