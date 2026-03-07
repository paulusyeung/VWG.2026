Namespace CompanionKit.Controls.ListBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class Transfer
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
            Me.btnToRight = New Gizmox.WebGUI.Forms.Button()
            Me.btnAllToRight = New Gizmox.WebGUI.Forms.Button()
            Me.btnToLeft = New Gizmox.WebGUI.Forms.Button()
            Me.btnAllToLeft = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP2 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP1.SuspendLayout()
            Me.mobjTLP2.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox1
            '
            Me.mobjListBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox1.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjListBox1.Location = New System.Drawing.Point(0, 52)
            Me.mobjListBox1.Name = "mobjListBox1"
            Me.mobjListBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended
            Me.mobjListBox1.Size = New System.Drawing.Size(160, 290)
            Me.mobjListBox1.Sorted = True
            Me.mobjListBox1.TabIndex = 0
            '
            'mobjListBox2
            '
            Me.mobjListBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox2.Location = New System.Drawing.Point(240, 52)
            Me.mobjListBox2.Name = "mobjListBox2"
            Me.mobjListBox2.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended
            Me.mobjListBox2.Size = New System.Drawing.Size(160, 290)
            Me.mobjListBox2.Sorted = True
            Me.mobjListBox2.TabIndex = 1
            '
            'btnToRight
            '
            Me.btnToRight.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.btnToRight.Location = New System.Drawing.Point(0, 22)
            Me.btnToRight.Name = "btnToRight"
            Me.btnToRight.Size = New System.Drawing.Size(80, 30)
            Me.btnToRight.TabIndex = 2
            Me.btnToRight.Text = ">"
            Me.btnToRight.UseVisualStyleBackColor = True
            '
            'btnAllToRight
            '
            Me.btnAllToRight.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.btnAllToRight.Location = New System.Drawing.Point(0, 96)
            Me.btnAllToRight.Name = "btnAllToRight"
            Me.btnAllToRight.Size = New System.Drawing.Size(80, 30)
            Me.btnAllToRight.TabIndex = 3
            Me.btnAllToRight.Text = ">>"
            Me.btnAllToRight.UseVisualStyleBackColor = True
            '
            'btnToLeft
            '
            Me.btnToLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.btnToLeft.Location = New System.Drawing.Point(0, 170)
            Me.btnToLeft.Name = "btnToLeft"
            Me.btnToLeft.Size = New System.Drawing.Size(80, 30)
            Me.btnToLeft.TabIndex = 4
            Me.btnToLeft.Text = "<"
            Me.btnToLeft.UseVisualStyleBackColor = True
            '
            'btnAllToLeft
            '
            Me.btnAllToLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.btnAllToLeft.Location = New System.Drawing.Point(0, 245)
            Me.btnAllToLeft.Name = "btnAllToLeft"
            Me.btnAllToLeft.Size = New System.Drawing.Size(80, 30)
            Me.btnAllToLeft.TabIndex = 5
            Me.btnAllToLeft.Text = "<<"
            Me.btnAllToLeft.UseVisualStyleBackColor = True
            '
            'mobjInfoLabel
            '
            Me.mobjTLP1.SetColumnSpan(Me.mobjInfoLabel, 3)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(400, 52)
            Me.mobjInfoLabel.TabIndex = 6
            Me.mobjInfoLabel.Text = "Transfer an item from a ListBox to another one:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP1
            '
            Me.mobjTLP1.ColumnCount = 3
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP1.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjListBox1, 0, 1)
            Me.mobjTLP1.Controls.Add(Me.mobjListBox2, 2, 1)
            Me.mobjTLP1.Controls.Add(Me.mobjTLP2, 1, 1)
            Me.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP1.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP1.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP1.Name = "mobjTLP1"
            Me.mobjTLP1.RowCount = 2
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0!))
            Me.mobjTLP1.Size = New System.Drawing.Size(400, 350)
            Me.mobjTLP1.TabIndex = 7
            '
            'mobjTLP2
            '
            Me.mobjTLP2.ColumnCount = 1
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP2.Controls.Add(Me.btnToRight, 0, 0)
            Me.mobjTLP2.Controls.Add(Me.btnAllToLeft, 0, 3)
            Me.mobjTLP2.Controls.Add(Me.btnAllToRight, 0, 1)
            Me.mobjTLP2.Controls.Add(Me.btnToLeft, 0, 2)
            Me.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP2.Location = New System.Drawing.Point(160, 52)
            Me.mobjTLP2.Name = "mobjTLP2"
            Me.mobjTLP2.RowCount = 4
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP2.Size = New System.Drawing.Size(80, 298)
            Me.mobjTLP2.TabIndex = 0
            '
            'Transfer
            '
            Me.Controls.Add(Me.mobjTLP1)
            Me.Size = New System.Drawing.Size(400, 350)
            Me.Text = "Transfer"
            Me.mobjTLP1.ResumeLayout(False)
            Me.mobjTLP2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox1 As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjListBox2 As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents btnToRight As Gizmox.WebGUI.Forms.Button
        Friend WithEvents btnAllToRight As Gizmox.WebGUI.Forms.Button
        Friend WithEvents btnToLeft As Gizmox.WebGUI.Forms.Button
        Friend WithEvents btnAllToLeft As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP1 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP2 As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
