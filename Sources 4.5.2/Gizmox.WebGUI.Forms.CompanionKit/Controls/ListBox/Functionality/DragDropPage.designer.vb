Namespace CompanionKit.Controls.ListBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DragDropPage
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
            Me.mobjListBox1 = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjListBox2 = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjAllowDrop = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox1
            '
            Me.mobjListBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox1.DragTargets = New Gizmox.WebGUI.Forms.Component() {CType(Me.mobjListBox2, Gizmox.WebGUI.Forms.Component)}
            Me.mobjListBox1.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjListBox1.Location = New System.Drawing.Point(0, 80)
            Me.mobjListBox1.Margin = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjListBox1.Name = "mobjListBox1"
            Me.mobjListBox1.Size = New System.Drawing.Size(150, 212)
            Me.mobjListBox1.TabIndex = 0
            '
            'mobjListBox2
            '
            Me.mobjListBox2.AllowDrop = True
            Me.mobjListBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox2.Location = New System.Drawing.Point(170, 80)
            Me.mobjListBox2.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjListBox2.Name = "mobjListBox2"
            Me.mobjListBox2.Size = New System.Drawing.Size(150, 212)
            Me.mobjListBox2.TabIndex = 1
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(160, 80)
            Me.mobjLabel1.TabIndex = 2
            Me.mobjLabel1.Text = "ListBox with defined drag target:"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(387, 0)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(160, 80)
            Me.mobjLabel2.TabIndex = 3
            Me.mobjLabel2.Text = "ListBox with allowed drop:"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListBox2, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListBox1, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjAllowDrop, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 23.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 62.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 4
            '
            'mobjAllowDrop
            '
            Me.mobjAllowDrop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAllowDrop.Checked = True
            Me.mobjAllowDrop.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjTLP.SetColumnSpan(Me.mobjAllowDrop, 2)
            Me.mobjAllowDrop.Location = New System.Drawing.Point(85, 298)
            Me.mobjAllowDrop.Name = "mobjAllowDrop"
            Me.mobjAllowDrop.Size = New System.Drawing.Size(150, 50)
            Me.mobjAllowDrop.TabIndex = 0
            Me.mobjAllowDrop.Text = "Alow Drop for ListBox2"
            Me.mobjAllowDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DragDropPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "DragDropPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox1 As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjListBox2 As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjAllowDrop As Gizmox.WebGUI.Forms.CheckBox

	End Class

End Namespace
