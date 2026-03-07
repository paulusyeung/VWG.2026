Namespace CompanionKit.Controls.ListBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckBoxAndRadioButtonsPage
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
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.radioButtonViewRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.checkBoxViewRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.normalViewRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjDescritionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", "G item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "P item", "Q item", "R item", "S item", "T item", "U item", "V item", "W item", "X item", "Y item", "Z item"})
            Me.mobjListBox.Location = New System.Drawing.Point(0, 42)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(320, 186)
            Me.mobjListBox.TabIndex = 0
            '
            'mobjGroupBox
            '
            Me.mobjGroupBox.Controls.Add(Me.radioButtonViewRadioButton)
            Me.mobjGroupBox.Controls.Add(Me.checkBoxViewRadioButton)
            Me.mobjGroupBox.Controls.Add(Me.normalViewRadioButton)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 231)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(320, 189)
            Me.mobjGroupBox.TabIndex = 1
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Change listbox items view"
            '
            'radioButtonViewRadioButton
            '
            Me.radioButtonViewRadioButton.Location = New System.Drawing.Point(19, 114)
            Me.radioButtonViewRadioButton.Name = "radioButton3"
            Me.radioButtonViewRadioButton.Size = New System.Drawing.Size(165, 31)
            Me.radioButtonViewRadioButton.TabIndex = 2
            Me.radioButtonViewRadioButton.Text = "RadioButton"
            Me.radioButtonViewRadioButton.UseVisualStyleBackColor = True
            '
            'checkBoxViewRadioButton
            '
            Me.checkBoxViewRadioButton.Location = New System.Drawing.Point(20, 76)
            Me.checkBoxViewRadioButton.Name = "radioButton2"
            Me.checkBoxViewRadioButton.Size = New System.Drawing.Size(164, 31)
            Me.checkBoxViewRadioButton.TabIndex = 1
            Me.checkBoxViewRadioButton.Text = "CheckBox"
            Me.checkBoxViewRadioButton.UseVisualStyleBackColor = True
            '
            'normalViewRadioButton
            '
            Me.normalViewRadioButton.Checked = True
            Me.normalViewRadioButton.Location = New System.Drawing.Point(20, 38)
            Me.normalViewRadioButton.Name = "radioButton1"
            Me.normalViewRadioButton.Size = New System.Drawing.Size(164, 31)
            Me.normalViewRadioButton.TabIndex = 0
            Me.normalViewRadioButton.Text = "Normal"
            Me.normalViewRadioButton.UseVisualStyleBackColor = True
            '
            'mobjDescritionLabel
            '
            Me.mobjDescritionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescritionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescritionLabel.Name = "mobjDescritionLabel"
            Me.mobjDescritionLabel.Size = New System.Drawing.Size(320, 42)
            Me.mobjDescritionLabel.TabIndex = 2
            Me.mobjDescritionLabel.Text = "Listbox with items:"
            Me.mobjDescritionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjDescritionLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjGroupBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjListBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 420)
            Me.mobjTLP.TabIndex = 3
            '
            'CheckBoxAndRadioButtonsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 420)
            Me.Text = "CheckBoxAndRadioButtonsPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents checkBoxViewRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents normalViewRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents radioButtonViewRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjDescritionLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
