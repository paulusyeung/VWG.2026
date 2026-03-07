Namespace CompanionKit.Concepts.ClientAPI.PictureBox

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PictureBoxPage
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
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjPictureBox = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.ClientId = "lb"
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"Sea", "Stone", "View"})
            Me.mobjListBox.Location = New System.Drawing.Point(15, 36)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(229, 108)
            Me.mobjListBox.TabIndex = 0
            '
            'mobjPictureBox
            '
            Me.mobjPictureBox.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjPictureBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPictureBox.ClientId = "pb"
            Me.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjPictureBox.Location = New System.Drawing.Point(15, 149)
            Me.mobjPictureBox.Name = "mobjPictureBox"
            Me.mobjPictureBox.Size = New System.Drawing.Size(229, 200)
            Me.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage
            Me.mobjPictureBox.TabIndex = 1
            Me.mobjPictureBox.TabStop = False
            '
            'mobjPanel
            '
            Me.mobjPanel.Controls.Add(Me.mobjListBox)
            Me.mobjPanel.Controls.Add(Me.mobjLabel)
            Me.mobjPanel.Controls.Add(Me.mobjPictureBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPanel.DockPadding.Bottom = 15
            Me.mobjPanel.DockPadding.Left = 15
            Me.mobjPanel.DockPadding.Right = 10
            Me.mobjPanel.DockPadding.Top = 10
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 10, 10, 15)
            Me.mobjPanel.Size = New System.Drawing.Size(254, 360)
            Me.mobjPanel.TabIndex = 2
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(15, 10)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(229, 26)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "Select PictureBox image:"
            '
            'PictureBoxPage
            '
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(439, 360)
            Me.Text = "PictureBoxPage"
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjPictureBox As Gizmox.WebGUI.Forms.PictureBox
        Private WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace