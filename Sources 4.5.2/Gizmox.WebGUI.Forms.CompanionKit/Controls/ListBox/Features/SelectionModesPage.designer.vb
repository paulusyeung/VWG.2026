Namespace CompanionKit.Controls.ListBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SelectionModesPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjModeCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP2 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP1.SuspendLayout()
            Me.mobjTLP2.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjListBox.Location = New System.Drawing.Point(0, 52)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(320, 186)
            Me.mobjListBox.TabIndex = 0
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "ListBox demonstrates selection modes:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjModeLabel
            '
            Me.mobjModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjModeLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjModeLabel.Name = "mobjModeLabel"
            Me.mobjModeLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjModeLabel.Size = New System.Drawing.Size(160, 106)
            Me.mobjModeLabel.TabIndex = 4
            Me.mobjModeLabel.Text = "Selection Mode"
            Me.mobjModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjModeCB
            '
            Me.mobjModeCB.AllowDrag = False
            Me.mobjModeCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjModeCB.FormattingEnabled = True
            Me.mobjModeCB.Location = New System.Drawing.Point(160, 42)
            Me.mobjModeCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjModeCB.Name = "mobjModeCB"
            Me.mobjModeCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjModeCB.TabIndex = 5
            '
            'mobjTLP1
            '
            Me.mobjTLP1.ColumnCount = 1
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP1.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjListBox, 0, 1)
            Me.mobjTLP1.Controls.Add(Me.mobjTLP2, 0, 2)
            Me.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP1.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP1.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP1.Name = "mobjTLP1"
            Me.mobjTLP1.RowCount = 3
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP1.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP1.TabIndex = 6
            '
            'mobjTLP2
            '
            Me.mobjTLP2.ColumnCount = 2
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.Controls.Add(Me.mobjModeLabel, 0, 0)
            Me.mobjTLP2.Controls.Add(Me.mobjModeCB, 1, 0)
            Me.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP2.Location = New System.Drawing.Point(0, 244)
            Me.mobjTLP2.Name = "mobjTLP2"
            Me.mobjTLP2.RowCount = 1
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.Size = New System.Drawing.Size(320, 106)
            Me.mobjTLP2.TabIndex = 0
            '
            'SelectionModesPage
            '
            Me.Controls.Add(Me.mobjTLP1)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "SelectionModesPage"
            Me.mobjTLP1.ResumeLayout(False)
            Me.mobjTLP2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjModeLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjModeCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTLP1 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP2 As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
