Namespace CompanionKit.Controls.CheckedListBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddItemPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddedItemText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddedItemPlace = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjAddedItemPlace, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 45)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Extended CheckedListBox:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCheckedListBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjCheckedListBox, 2)
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item"})
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(0, 45)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(320, 116)
            Me.mobjCheckedListBox.TabIndex = 1
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 165)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel1.Size = New System.Drawing.Size(160, 45)
            Me.mobjLabel1.TabIndex = 2
            Me.mobjLabel1.Text = "Added item text"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjAddedItemText
            '
            Me.mobjAddedItemText.AllowDrag = False
            Me.mobjAddedItemText.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjAddedItemText.Location = New System.Drawing.Point(170, 175)
            Me.mobjAddedItemText.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3)
            Me.mobjAddedItemText.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjAddedItemText.Name = "mobjAddedItemText"
            Me.mobjAddedItemText.Size = New System.Drawing.Size(140, 25)
            Me.mobjAddedItemText.TabIndex = 3
            Me.mobjAddedItemText.Text = "Added item"
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 210)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel2.Size = New System.Drawing.Size(160, 45)
            Me.mobjLabel2.TabIndex = 4
            Me.mobjLabel2.Text = "Added item place"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjAddedItemPlace
            '
            Me.mobjAddedItemPlace.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjAddedItemPlace.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjAddedItemPlace.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjAddedItemPlace.Location = New System.Drawing.Point(170, 222)
            Me.mobjAddedItemPlace.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjAddedItemPlace.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjAddedItemPlace.Name = "mobjAddedItemPlace"
            Me.mobjAddedItemPlace.Size = New System.Drawing.Size(140, 21)
            Me.mobjAddedItemPlace.TabIndex = 5
            '
            'mobjAddButton
            '
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(170, 265)
            Me.mobjAddButton.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjAddButton.MaximumSize = New System.Drawing.Size(200, 50)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(140, 25)
            Me.mobjAddButton.TabIndex = 6
            Me.mobjAddButton.Text = "Add item "
            Me.mobjAddButton.UseVisualStyleBackColor = True
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjAddButton, 1, 4)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedListBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjAddedItemPlace, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjAddedItemText, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 300)
            Me.mobjTLP.TabIndex = 7
            '
            'AddItemPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 300)
            Me.Text = "AddItemPage"
            CType(Me.mobjAddedItemPlace, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjAddedItemText As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjAddedItemPlace As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
