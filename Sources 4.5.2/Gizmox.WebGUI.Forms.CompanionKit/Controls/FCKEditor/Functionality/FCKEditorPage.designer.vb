Namespace CompanionKit.Controls.FCKEditor

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FCKEditorPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFCKEditor = New Gizmox.WebGUI.Forms.Extended.FCKEditor()
            Me.mobjSendButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(669, 55)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Click button to send FCKEditor Value to RichTextBox:"
            '
            'mobjFCKEditor
            '
            Me.mobjFCKEditor.BasePath = "../../../../../../../FCKEditor/"
            Me.mobjFCKEditor.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFCKEditor.Location = New System.Drawing.Point(0, 55)
            Me.mobjFCKEditor.Name = "mobjFCKEditor"
            Me.mobjFCKEditor.Size = New System.Drawing.Size(391, 210)
            Me.mobjFCKEditor.TabIndex = 2
            Me.mobjFCKEditor.Value = "This is text..."
            '
            'mobjSendButton
            '
            Me.mobjSendButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSendButton.Location = New System.Drawing.Point(0, 267)
            Me.mobjSendButton.Name = "mobjSendButton"
            Me.mobjSendButton.Size = New System.Drawing.Size(669, 34)
            Me.mobjSendButton.TabIndex = 3
            Me.mobjSendButton.Text = "Send"
            '
            'mobjRichTextBox
            '
            Me.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjRichTextBox.Location = New System.Drawing.Point(0, 301)
            Me.mobjRichTextBox.Name = "mobjRichTextBox"
            Me.mobjRichTextBox.Size = New System.Drawing.Size(669, 117)
            Me.mobjRichTextBox.TabIndex = 4
            '
            'FCKEditorPage
            '
            Me.Controls.Add(Me.mobjRichTextBox)
            Me.Controls.Add(Me.mobjSendButton)
            Me.Controls.Add(Me.mobjFCKEditor)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Size = New System.Drawing.Size(391, 466)
            Me.Text = "FCKEditorPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjFCKEditor As Gizmox.WebGUI.Forms.Extended.FCKEditor
        Private WithEvents mobjSendButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
	End Class

End Namespace