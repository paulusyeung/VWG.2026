Namespace CompanionKit.Controls.CheckedListBox.Features

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
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjSelectionModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectionModesComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjCheckedListBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjCheckedListBox, 2)
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(0, 70)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(320, 276)
            Me.mobjCheckedListBox.TabIndex = 0
            '
            'mobjSelectionModeLabel
            '
            Me.mobjSelectionModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectionModeLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSelectionModeLabel.Name = "mobjSelectionModeLabel"
            Me.mobjSelectionModeLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjSelectionModeLabel.Size = New System.Drawing.Size(160, 70)
            Me.mobjSelectionModeLabel.TabIndex = 4
            Me.mobjSelectionModeLabel.Text = "Change the selection mode: "
            Me.mobjSelectionModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjSelectionModesComboBox
            '
            Me.mobjSelectionModesComboBox.AllowDrag = False
            Me.mobjSelectionModesComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjSelectionModesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjSelectionModesComboBox.Location = New System.Drawing.Point(160, 24)
            Me.mobjSelectionModesComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjSelectionModesComboBox.Name = "mobjSelectionModesComboBox"
            Me.mobjSelectionModesComboBox.Size = New System.Drawing.Size(160, 25)
            Me.mobjSelectionModesComboBox.TabIndex = 5
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjSelectionModeLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedListBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjSelectionModesComboBox, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 6
            '
            'SelectionModesPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "SelectionModesPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Friend WithEvents mobjSelectionModeLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjSelectionModesComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
