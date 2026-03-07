Namespace CompanionKit.Controls.Timer.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class IntervalActionPage
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
            Me.components = New System.ComponentModel.Container
            Me.Label1 = New Gizmox.WebGUI.Forms.Label
            Me.Timer1 = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.Label1.Location = New System.Drawing.Point(35, 29)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "07:25:00 PM"
            '
            'Timer1
            '
            Me.Timer1.Enabled = True
            Me.Timer1.Interval = 1000
            '
            'IntervalActionPage
            '
            Me.Controls.Add(Me.Label1)
            Me.Size = New System.Drawing.Size(238, 90)
            Me.Text = "IntervalActionPage"
            Me.ResumeLayout(False)

        End Sub
		Friend WithEvents Label1 As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents Timer1 As Global.Gizmox.WebGUI.Forms.Timer

	End Class

End Namespace
