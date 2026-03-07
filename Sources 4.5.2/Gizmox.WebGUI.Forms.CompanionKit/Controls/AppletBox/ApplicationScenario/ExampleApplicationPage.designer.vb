Namespace CompanionKit.Controls.AppletBox.ApplicationScenario

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExampleApplicationPage
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
            Me.demoAppletBox = New Gizmox.WebGUI.Forms.Hosts.AppletBox
            Me.SuspendLayout()
            '
            'demoAppletBox
            '
            Me.demoAppletBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoAppletBox.Archive = "viewone.jar"
            Me.demoAppletBox.Code = "start.jiViewONE.class"
            Me.demoAppletBox.CodeBase = "http://www.daeja.com/demo/v1demo/v1files"
            Me.demoAppletBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoAppletBox.Location = New System.Drawing.Point(0, 0)
            Me.demoAppletBox.Name = "demoAppletBox"
            Me.demoAppletBox.Size = New System.Drawing.Size(391, 550)
            Me.demoAppletBox.TabIndex = 0
            '
            'ExampleApplicationPage
            '
            Me.Controls.Add(Me.demoAppletBox)
            Me.Size = New System.Drawing.Size(391, 550)
            Me.Text = "ExampleApplicationPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoAppletBox As Gizmox.WebGUI.Forms.Hosts.AppletBox

	End Class

End Namespace
