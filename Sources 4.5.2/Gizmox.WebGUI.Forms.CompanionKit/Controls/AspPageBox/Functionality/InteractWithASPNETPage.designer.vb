Namespace CompanionKit.Controls.AspPageBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class InteractWithASPNETPage
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
            Me.demoAspPageBox = New MyAspPageBox
            Me.SuspendLayout()
            '
            'demoAspPageBox
            '
            Me.demoAspPageBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoAspPageBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoAspPageBox.Location = New System.Drawing.Point(0, 0)
            Me.demoAspPageBox.Name = "demoAspPageBox"
            Me.demoAspPageBox.Path = Nothing
            Me.demoAspPageBox.Size = New System.Drawing.Size(391, 306)
            Me.demoAspPageBox.TabIndex = 0
            '
            'InteractWithASPNETPage
            '
            Me.Controls.Add(Me.demoAspPageBox)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "InteractWithASPNETPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoAspPageBox As MyAspPageBox

	End Class

End Namespace