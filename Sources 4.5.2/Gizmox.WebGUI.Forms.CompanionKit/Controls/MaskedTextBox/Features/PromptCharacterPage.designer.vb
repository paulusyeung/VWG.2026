Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PromptCharacterPage
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
            Me.mobjMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjPromptCharsLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPromptCharsComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjMaskedTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjMaskedTextBox
            '
            Me.mobjMaskedTextBox.AllowDrag = False
            Me.mobjMaskedTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMaskedTextBox.CustomStyle = "Masked"
            Me.mobjMaskedTextBox.Location = New System.Drawing.Point(203, 287)
            Me.mobjMaskedTextBox.Mask = "00/00/0000 90:00"
            Me.mobjMaskedTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaskedTextBox.Name = "mobjMaskedTextBox"
            Me.mobjMaskedTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.mobjMaskedTextBox.Size = New System.Drawing.Size(194, 25)
            Me.mobjMaskedTextBox.TabIndex = 0
            Me.mobjMaskedTextBox.Text = "**/**/**** **:**"
            '
            'mobjPromptCharsLabel
            '
            Me.mobjPromptCharsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPromptCharsLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPromptCharsLabel.Name = "mobjPromptCharsLabel"
            Me.mobjPromptCharsLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjPromptCharsLabel.Size = New System.Drawing.Size(200, 200)
            Me.mobjPromptCharsLabel.TabIndex = 1
            Me.mobjPromptCharsLabel.Text = "Select Prompt Character"
            Me.mobjPromptCharsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjPromptCharsComboBox
            '
            Me.mobjPromptCharsComboBox.AllowDrag = False
            Me.mobjPromptCharsComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjPromptCharsComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjPromptCharsComboBox.Location = New System.Drawing.Point(200, 89)
            Me.mobjPromptCharsComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPromptCharsComboBox.Name = "mobjPromptCharsComboBox"
            Me.mobjPromptCharsComboBox.Size = New System.Drawing.Size(200, 25)
            Me.mobjPromptCharsComboBox.TabIndex = 2
            '
            'mobjMaskedTextLabel
            '
            Me.mobjMaskedTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaskedTextLabel.Location = New System.Drawing.Point(0, 200)
            Me.mobjMaskedTextLabel.Name = "mobjMaskedTextLabel"
            Me.mobjMaskedTextLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjMaskedTextLabel.Size = New System.Drawing.Size(200, 200)
            Me.mobjMaskedTextLabel.TabIndex = 3
            Me.mobjMaskedTextLabel.Text = "Enter masked text"
            Me.mobjMaskedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjPromptCharsLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjMaskedTextBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjPromptCharsComboBox, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjMaskedTextLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(400, 400)
            Me.mobjTLP.TabIndex = 4
            '
            'PromptCharacterPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(400, 400)
            Me.Text = "PromptCharacterPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Friend WithEvents mobjPromptCharsLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjPromptCharsComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjMaskedTextLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace