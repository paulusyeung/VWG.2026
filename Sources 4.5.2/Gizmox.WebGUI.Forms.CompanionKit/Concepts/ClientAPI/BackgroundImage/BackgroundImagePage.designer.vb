Namespace CompanionKit.Concepts.ClientAPI.BackgroundImage

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BackgroundImagePage
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

            Me.label1 = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Padding = New Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0)
            Me.label1.Size = New System.Drawing.Size(467, 60)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Click on Panel to change background image:"
            ' 
            ' BackgroundImagePage
            ' 
            Me.Controls.Add(Me.label1)
            Me.Size = New System.Drawing.Size(467, 418)
            Me.Text = "BackgroundImagePage"
            Me.ResumeLayout(False)

		End Sub
        Friend WithEvents label1 As Gizmox.WebGUI.Forms.Label
	End Class

End Namespace