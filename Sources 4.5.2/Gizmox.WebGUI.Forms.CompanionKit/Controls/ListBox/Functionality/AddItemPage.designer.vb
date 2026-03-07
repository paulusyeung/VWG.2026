Namespace CompanionKit.Controls.ListBox.Functionality

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
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP2 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP1.SuspendLayout()
            Me.mobjTLP2.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item"})
            Me.mobjListBox.Location = New System.Drawing.Point(0, 35)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(320, 173)
            Me.mobjListBox.TabIndex = 0
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 35)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Extended ListBox:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextBox.Location = New System.Drawing.Point(163, 10)
            Me.mobjTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjTextBox.TabIndex = 2
            Me.mobjTextBox.Text = "Added item"
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel1.Size = New System.Drawing.Size(160, 46)
            Me.mobjLabel1.TabIndex = 3
            Me.mobjLabel1.Text = "Added item text"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjNumericUpDown
            '
            Me.mobjNumericUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(160, 58)
            Me.mobjNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjNumericUpDown.Name = "mobjNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(160, 21)
            Me.mobjNumericUpDown.TabIndex = 4
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 46)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel2.Size = New System.Drawing.Size(160, 46)
            Me.mobjLabel2.TabIndex = 5
            Me.mobjLabel2.Text = "Added item place"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjButton
            '
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(160, 92)
            Me.mobjButton.MaximumSize = New System.Drawing.Size(200, 50)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(160, 48)
            Me.mobjButton.TabIndex = 6
            Me.mobjButton.Text = "Add item into ListBox"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjTLP1
            '
            Me.mobjTLP1.ColumnCount = 1
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP1.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjListBox, 0, 1)
            Me.mobjTLP1.Controls.Add(Me.mobjTLP2, 0, 2)
            Me.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP1.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP1.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP1.Name = "mobjTLP1"
            Me.mobjTLP1.RowCount = 3
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0!))
            Me.mobjTLP1.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP1.TabIndex = 7
            '
            'mobjTLP2
            '
            Me.mobjTLP2.ColumnCount = 2
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.Controls.Add(Me.mobjLabel1, 0, 0)
            Me.mobjTLP2.Controls.Add(Me.mobjButton, 1, 2)
            Me.mobjTLP2.Controls.Add(Me.mobjLabel2, 0, 1)
            Me.mobjTLP2.Controls.Add(Me.mobjNumericUpDown, 1, 1)
            Me.mobjTLP2.Controls.Add(Me.mobjTextBox, 1, 0)
            Me.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP2.Location = New System.Drawing.Point(0, 210)
            Me.mobjTLP2.Name = "mobjTLP2"
            Me.mobjTLP2.RowCount = 3
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.Size = New System.Drawing.Size(320, 140)
            Me.mobjTLP2.TabIndex = 0
            '
            'AddItemPage
            '
            Me.Controls.Add(Me.mobjTLP1)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "AddItemPage"
            CType(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP1.ResumeLayout(False)
            Me.mobjTLP2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjTLP1 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP2 As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
