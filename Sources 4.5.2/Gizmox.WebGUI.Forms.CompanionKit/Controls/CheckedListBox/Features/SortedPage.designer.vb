Namespace CompanionKit.Controls.CheckedListBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SortedPage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIsSorted = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 52)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "The items are not sorted"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjIsSorted
            '
            Me.mobjIsSorted.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjIsSorted.Location = New System.Drawing.Point(35, 1)
            Me.mobjIsSorted.Name = "mobjIsSorted"
            Me.mobjIsSorted.Size = New System.Drawing.Size(250, 50)
            Me.mobjIsSorted.TabIndex = 1
            Me.mobjIsSorted.Text = "Turn on Sorted property for CheckedListBox"
            Me.mobjIsSorted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjIsSorted.UseVisualStyleBackColor = True
            '
            'mobjCheckedListBox
            '
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(0, 104)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(320, 244)
            Me.mobjCheckedListBox.TabIndex = 2
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjIsSorted, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedListBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 3
            '
            'SortedPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "SortedPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjIsSorted As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
