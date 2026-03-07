Namespace CompanionKit.Controls.CheckedListBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckOnClickPage
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
            Me.mobjCheckOnClick = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjCheckOnClick
            '
            Me.mobjCheckOnClick.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckOnClick.Location = New System.Drawing.Point(136, 11)
            Me.mobjCheckOnClick.Name = "mobjCheckOnClick"
            Me.mobjCheckOnClick.Size = New System.Drawing.Size(250, 70)
            Me.mobjCheckOnClick.TabIndex = 0
            Me.mobjCheckOnClick.Text = "Turn on CheckOnClick property for CheckedListBox"
            Me.mobjCheckOnClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjCheckOnClick.UseVisualStyleBackColor = True
            '
            'mobjCheckedListBox
            '
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(0, 70)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(320, 276)
            Me.mobjCheckedListBox.TabIndex = 2
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjCheckOnClick, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedListBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 3
            '
            'CheckOnClickPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "CheckOnClickPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjCheckOnClick As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
