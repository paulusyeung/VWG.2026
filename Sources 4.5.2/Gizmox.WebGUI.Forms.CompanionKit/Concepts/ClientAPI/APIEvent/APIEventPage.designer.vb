Namespace CompanionKit.Concepts.ClientAPI.APIEvent

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class APIEventPage
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
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.SuspendLayout()
            '
            'objLabel
            '
            Me.objLabel.AutoSize = True
            Me.objLabel.ClientId = "label"
            Me.objLabel.Location = New System.Drawing.Point(157, 49)
            Me.objLabel.Name = "objLabel"
            Me.objLabel.Size = New System.Drawing.Size(35, 13)
            Me.objLabel.TabIndex = 2
            Me.objLabel.Text = "Index:<int>, Text:<string>"
            '
            'objComboBox
            '
            Me.objComboBox.ClientId = "combo"
            Me.objComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.objComboBox.FormattingEnabled = True
            Me.objComboBox.Items.AddRange(New Object() {"Item1", "Item2", "Item3", "Item4", "Item5", "Item6"})
            Me.objComboBox.Location = New System.Drawing.Point(30, 46)
            Me.objComboBox.Name = "objComboBox"
            Me.objComboBox.Size = New System.Drawing.Size(100, 21)
            Me.objComboBox.TabIndex = 0
            Me.objComboBox.Text = "Item1"
            '
            'ClientDOMEventPage
            '
            Me.ClientId = "form"
            Me.Controls.Add(Me.objComboBox)
            Me.Controls.Add(Me.objLabel)
            Me.Size = New System.Drawing.Size(343, 182)
            Me.Text = "ClientDOMEventPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objComboBox As Gizmox.WebGUI.Forms.ComboBox

	End Class

End Namespace