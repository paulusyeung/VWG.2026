Namespace CompanionKit.Concepts.ClientAPI.ComboBoxItems

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ComboBoxItemsPage
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
        ''' <summary>
        ''' Initializes the component.
        ''' </summary>
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjNewItemLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNewItemTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRemoveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSelectedIndexLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            '
            'mobjComboBox
            '
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.ClientId = "cb"
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Location = New System.Drawing.Point(72, 26)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(175, 21)
            Me.mobjComboBox.TabIndex = 0
            '
            'mobjNewItemLabel
            '
            Me.mobjNewItemLabel.AutoSize = True
            Me.mobjNewItemLabel.Location = New System.Drawing.Point(26, 96)
            Me.mobjNewItemLabel.Name = "mobjNewItemLabel"
            Me.mobjNewItemLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjNewItemLabel.TabIndex = 1
            Me.mobjNewItemLabel.Text = "New item text:"
            '
            'mobjNewItemTextBox
            '
            Me.mobjNewItemTextBox.AllowDrag = False
            Me.mobjNewItemTextBox.ClientId = "tb"
            Me.mobjNewItemTextBox.Location = New System.Drawing.Point(180, 93)
            Me.mobjNewItemTextBox.Name = "mobjNewItemTextBox"
            Me.mobjNewItemTextBox.Size = New System.Drawing.Size(114, 20)
            Me.mobjNewItemTextBox.TabIndex = 2
            Me.mobjNewItemTextBox.Text = "item4"
            '
            'mobjAddButton
            '
            Me.mobjAddButton.ClientId = "btnAdd"
            Me.mobjAddButton.Location = New System.Drawing.Point(224, 130)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(70, 23)
            Me.mobjAddButton.TabIndex = 3
            Me.mobjAddButton.Text = "Add"
            '
            'mobjRemoveButton
            '
            Me.mobjRemoveButton.ClientId = "btnRemove"
            Me.mobjRemoveButton.Location = New System.Drawing.Point(224, 166)
            Me.mobjRemoveButton.Name = "mobjRemoveButton"
            Me.mobjRemoveButton.Size = New System.Drawing.Size(70, 23)
            Me.mobjRemoveButton.TabIndex = 4
            Me.mobjRemoveButton.Text = "Remove"
            '
            'mobjSelectedIndexLabel
            '
            Me.mobjSelectedIndexLabel.AutoSize = True
            Me.mobjSelectedIndexLabel.ClientId = "lblSelectedIndex"
            Me.mobjSelectedIndexLabel.Location = New System.Drawing.Point(26, 171)
            Me.mobjSelectedIndexLabel.Name = "mobjSelectedIndexLabel"
            Me.mobjSelectedIndexLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjSelectedIndexLabel.TabIndex = 5
            Me.mobjSelectedIndexLabel.Text = "Selected index: 0"
            '
            'ComboBoxItemsPage
            '
            Me.Controls.Add(Me.mobjSelectedIndexLabel)
            Me.Controls.Add(Me.mobjRemoveButton)
            Me.Controls.Add(Me.mobjAddButton)
            Me.Controls.Add(Me.mobjNewItemTextBox)
            Me.Controls.Add(Me.mobjNewItemLabel)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Size = New System.Drawing.Size(392, 306)
            Me.ClientId = "uc"
            Me.Text = "ComboBoxItemsPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjNewItemLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjNewItemTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjRemoveButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjSelectedIndexLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace