Namespace CompanionKit.Controls.HelpProvider.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ViewHelpFileOnKeyStrokePage
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
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjHelpProvider = New Gizmox.WebGUI.Forms.HelpProvider()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjTextBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDomainUpDown = New Gizmox.WebGUI.Forms.DomainUpDown()
            Me.mobjDUDLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjNUDLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLinkLabel = New Gizmox.WebGUI.Forms.LinkLabel()
            Me.mobjLinkLabelLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRadioButton1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButtonLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjCheckBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjOptionPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjOptionPanel.SuspendLayout()
            Me.mobjContainerPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjComboBox.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5"})
            Me.mobjComboBox.Location = New System.Drawing.Point(319, 88)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(309, 21)
            Me.mobjComboBox.TabIndex = 1
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBox.Location = New System.Drawing.Point(322, 53)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(303, 30)
            Me.mobjTextBox.TabIndex = 0
            ' 
            ' mobjHelpProvider
            ' 
            Me.mobjHelpProvider.HelpNamespace = Nothing
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5"})
            Me.mobjListBox.Location = New System.Drawing.Point(5, 5)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(299, 69)
            Me.mobjListBox.TabIndex = 8
            ' 
            ' mobjTextBoxLabel
            ' 
            Me.mobjTextBoxLabel.AutoSize = True
            Me.mobjTextBoxLabel.Location = New System.Drawing.Point(10, 50)
            Me.mobjTextBoxLabel.Name = "mobjTextBoxLabel"
            Me.mobjTextBoxLabel.Size = New System.Drawing.Size(47, 13)
            Me.mobjTextBoxLabel.TabIndex = 9
            Me.mobjTextBoxLabel.Text = "TextBox"
            ' 
            ' mobjListBoxLabel
            ' 
            Me.mobjListBoxLabel.AutoSize = True
            Me.mobjListBoxLabel.Location = New System.Drawing.Point(10, 316)
            Me.mobjListBoxLabel.Name = "mobjListBoxLabel"
            Me.mobjListBoxLabel.Size = New System.Drawing.Size(41, 13)
            Me.mobjListBoxLabel.TabIndex = 16
            Me.mobjListBoxLabel.Text = "ListBox"
            ' 
            ' mobjComboBoxLabel
            ' 
            Me.mobjComboBoxLabel.AutoSize = True
            Me.mobjComboBoxLabel.Location = New System.Drawing.Point(10, 88)
            Me.mobjComboBoxLabel.Name = "mobjComboBoxLabel"
            Me.mobjComboBoxLabel.Size = New System.Drawing.Size(58, 13)
            Me.mobjComboBoxLabel.TabIndex = 10
            Me.mobjComboBoxLabel.Text = "ComboBox"
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(618, 50)
            Me.mobjInfoLabel.TabIndex = 17
            Me.mobjInfoLabel.Text = "Set focus on a control and press F1 key to view the relevant help file"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjDomainUpDown
            ' 
            Me.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDomainUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDomainUpDown.Items.Add("Item 1")
            Me.mobjDomainUpDown.Items.Add("Item 2")
            Me.mobjDomainUpDown.Items.Add("Item 3")
            Me.mobjDomainUpDown.Items.Add("Item 4")
            Me.mobjDomainUpDown.Items.Add("Item 5")
            Me.mobjDomainUpDown.Location = New System.Drawing.Point(319, 126)
            Me.mobjDomainUpDown.Name = "mobjDomainUpDown"
            Me.mobjDomainUpDown.Size = New System.Drawing.Size(309, 21)
            Me.mobjDomainUpDown.TabIndex = 2
            ' 
            ' mobjDUDLabel
            ' 
            Me.mobjDUDLabel.AutoSize = True
            Me.mobjDUDLabel.Location = New System.Drawing.Point(10, 126)
            Me.mobjDUDLabel.Name = "mobjDUDLabel"
            Me.mobjDUDLabel.Size = New System.Drawing.Size(82, 13)
            Me.mobjDUDLabel.TabIndex = 11
            Me.mobjDUDLabel.Text = "DomainUpDown"
            ' 
            ' mobjNumericUpDown
            ' 
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(319, 164)
            Me.mobjNumericUpDown.Name = "mobjNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(309, 21)
            Me.mobjNumericUpDown.TabIndex = 3
            ' 
            ' mobjNUDLabel
            ' 
            Me.mobjNUDLabel.AutoSize = True
            Me.mobjNUDLabel.Location = New System.Drawing.Point(10, 164)
            Me.mobjNUDLabel.Name = "mobjNUDLabel"
            Me.mobjNUDLabel.Size = New System.Drawing.Size(85, 13)
            Me.mobjNUDLabel.TabIndex = 12
            Me.mobjNUDLabel.Text = "NumericUpDown"
            ' 
            ' mobjLinkLabel
            ' 
            Me.mobjLinkLabel.AutoSize = True
            Me.mobjLinkLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLinkLabel.LinkColor = System.Drawing.Color.Blue
            Me.mobjLinkLabel.Location = New System.Drawing.Point(319, 202)
            Me.mobjLinkLabel.Name = "mobjLinkLabel"
            Me.mobjLinkLabel.Size = New System.Drawing.Size(309, 13)
            Me.mobjLinkLabel.TabIndex = 4
            Me.mobjLinkLabel.TabStop = True
            Me.mobjLinkLabel.Text = "LinkLabel"
            ' 
            ' mobjLinkLabelLabel
            ' 
            Me.mobjLinkLabelLabel.AutoSize = True
            Me.mobjLinkLabelLabel.Location = New System.Drawing.Point(10, 202)
            Me.mobjLinkLabelLabel.Name = "mobjLinkLabelLabel"
            Me.mobjLinkLabelLabel.Size = New System.Drawing.Size(50, 13)
            Me.mobjLinkLabelLabel.TabIndex = 13
            Me.mobjLinkLabelLabel.Text = "LinkLabel"
            ' 
            ' mobjRadioButton1
            ' 
            Me.mobjRadioButton1.AutoSize = True
            Me.mobjRadioButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjRadioButton1.Location = New System.Drawing.Point(0, 0)
            Me.mobjRadioButton1.Name = "mobjRadioButton1"
            Me.mobjRadioButton1.Size = New System.Drawing.Size(55, 38)
            Me.mobjRadioButton1.TabIndex = 5
            Me.mobjRadioButton1.Text = "Case1"
            Me.mobjRadioButton1.UseVisualStyleBackColor = True
            ' 
            ' mobjRadioButton2
            ' 
            Me.mobjRadioButton2.AutoSize = True
            Me.mobjRadioButton2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjRadioButton2.Location = New System.Drawing.Point(55, 0)
            Me.mobjRadioButton2.Name = "mobjRadioButton2"
            Me.mobjRadioButton2.Size = New System.Drawing.Size(55, 38)
            Me.mobjRadioButton2.TabIndex = 6
            Me.mobjRadioButton2.Text = "Case2"
            Me.mobjRadioButton2.UseVisualStyleBackColor = True
            ' 
            ' mobjRadioButtonLabel
            ' 
            Me.mobjRadioButtonLabel.AutoSize = True
            Me.mobjRadioButtonLabel.Location = New System.Drawing.Point(10, 240)
            Me.mobjRadioButtonLabel.Name = "mobjRadioButtonLabel"
            Me.mobjRadioButtonLabel.Size = New System.Drawing.Size(66, 13)
            Me.mobjRadioButtonLabel.TabIndex = 14
            Me.mobjRadioButtonLabel.Text = "RadioButton"
            ' 
            ' mobjCheckBox
            ' 
            Me.mobjCheckBox.AutoSize = True
            Me.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjCheckBox.Location = New System.Drawing.Point(319, 278)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(309, 17)
            Me.mobjCheckBox.TabIndex = 7
            Me.mobjCheckBox.Text = "Value"
            Me.mobjCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjCheckBoxLabel
            ' 
            Me.mobjCheckBoxLabel.AutoSize = True
            Me.mobjCheckBoxLabel.Location = New System.Drawing.Point(10, 278)
            Me.mobjCheckBoxLabel.Name = "mobjCheckBoxLabel"
            Me.mobjCheckBoxLabel.Size = New System.Drawing.Size(54, 13)
            Me.mobjCheckBoxLabel.TabIndex = 15
            Me.mobjCheckBoxLabel.Text = "CheckBox"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBox, 2, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBoxLabel, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBoxLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRadioButtonLabel, 1, 6)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBoxLabel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDUDLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLinkLabel, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLinkLabelLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDomainUpDown, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNUDLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNumericUpDown, 2, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOptionPanel, 2, 6)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjListBoxLabel, 1, 8)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerPanel, 2, 8)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 9
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(638, 400)
            Me.mobjLayoutPanel.TabIndex = 18
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTopPanel, 2)
            Me.mobjTopPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(10, 0)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(618, 50)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjOptionPanel
            ' 
            Me.mobjOptionPanel.Controls.Add(Me.mobjRadioButton2)
            Me.mobjOptionPanel.Controls.Add(Me.mobjRadioButton1)
            Me.mobjOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOptionPanel.Location = New System.Drawing.Point(319, 240)
            Me.mobjOptionPanel.Name = "mobjOptionPanel"
            Me.mobjOptionPanel.Size = New System.Drawing.Size(309, 38)
            Me.mobjOptionPanel.TabIndex = 0
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.Controls.Add(Me.mobjListBox)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.DockPadding.All = 5
            Me.mobjContainerPanel.Location = New System.Drawing.Point(319, 316)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjContainerPanel.Size = New System.Drawing.Size(309, 84)
            Me.mobjContainerPanel.TabIndex = 0
            ' 
            ' ViewHelpFileOnKeyStrokePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(638, 400)
            Me.Text = "ViewHelpFileOnKeyStrokePage"
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjOptionPanel.ResumeLayout(False)
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjHelpProvider As Gizmox.WebGUI.Forms.HelpProvider
        Private mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private mobjTextBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjListBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDomainUpDown As Gizmox.WebGUI.Forms.DomainUpDown
        Private mobjDUDLabel As Gizmox.WebGUI.Forms.Label
        Private mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjNUDLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLinkLabel As Gizmox.WebGUI.Forms.LinkLabel
        Private mobjLinkLabelLabel As Gizmox.WebGUI.Forms.Label
        Private mobjRadioButton1 As Gizmox.WebGUI.Forms.RadioButton
        Private mobjRadioButton2 As Gizmox.WebGUI.Forms.RadioButton
        Private mobjRadioButtonLabel As Gizmox.WebGUI.Forms.Label
        Private mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjCheckBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjOptionPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace