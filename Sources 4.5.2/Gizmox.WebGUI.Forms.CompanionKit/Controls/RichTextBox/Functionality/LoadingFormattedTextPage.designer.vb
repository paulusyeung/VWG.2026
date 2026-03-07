Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LoadingFormattedTextPage
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
            Me.mobjRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.SuspendLayout()
            ' 
            ' mobjRichTextBox
            ' 
            Me.mobjRichTextBox.AccessibleDescription = ""
            Me.mobjRichTextBox.AccessibleName = ""
            Me.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjRichTextBox.Name = "mobjRichTextBox"
            Me.mobjRichTextBox.Size = New System.Drawing.Size(391, 306)
            Me.mobjRichTextBox.TabIndex = 0
            ' 
            ' LoadingFormattedTextPage
            ' 
            Me.Controls.Add(Me.mobjRichTextBox)
            Me.Size = New System.Drawing.Size(320, 300)
            Me.Text = "LoadingFormattedTextPage"
            Me.ResumeLayout(False)


        End Sub
        Friend WithEvents mobjRichTextBox As Gizmox.WebGUI.Forms.RichTextBox

	End Class

End Namespace