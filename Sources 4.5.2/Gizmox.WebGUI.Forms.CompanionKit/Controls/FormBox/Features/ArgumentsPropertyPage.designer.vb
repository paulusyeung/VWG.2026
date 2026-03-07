Namespace CompanionKit.Controls.FormBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ArgumentsPropertyPage
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
            Me.aspPageBox = New Gizmox.WebGUI.Forms.Hosts.AspPageBox
            Me.SuspendLayout()
            '
            'aspPageBox
            '
            Me.aspPageBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.aspPageBox.Location = New System.Drawing.Point(0, 0)
            Me.aspPageBox.Name = "aspPageBox"
            Me.aspPageBox.Path = "Controls\FormBox\Features\ArgumentsPropertyWebFormVB.aspx"
            Me.aspPageBox.Size = New System.Drawing.Size(400, 300)
            Me.aspPageBox.TabIndex = 0
            '
            'ArgumentsPropertyPage
            '
            Me.Controls.Add(Me.aspPageBox)
            Me.Size = New System.Drawing.Size(400, 300)
            Me.Text = "ArgumentsPropertyPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents aspPageBox As Gizmox.WebGUI.Forms.Hosts.AspPageBox

	End Class

End Namespace