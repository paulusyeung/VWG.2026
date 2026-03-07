Namespace CompanionKit.Concepts.ClientAPI.DomainUpDown

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DomainUpDownPage
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
        ''' <summary>
        ''' Initializes the component.
        ''' </summary>
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.mobjDomainUpDown = New Gizmox.WebGUI.Forms.DomainUpDown()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLabelSelectedIndex = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjDomainUpDown
            ' 
            Me.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDomainUpDown.ClientId = "dud"
            Me.mobjDomainUpDown.Items.Add("1")
            Me.mobjDomainUpDown.Items.Add("2")
            Me.mobjDomainUpDown.Items.Add("3")
            Me.mobjDomainUpDown.Items.Add("4")
            Me.mobjDomainUpDown.Items.Add("5")
            Me.mobjDomainUpDown.Items.Add("6")
            Me.mobjDomainUpDown.Location = New System.Drawing.Point(31, 139)
            Me.mobjDomainUpDown.Name = "mobjDomainUpDown"
            Me.mobjDomainUpDown.Size = New System.Drawing.Size(130, 20)
            Me.mobjDomainUpDown.TabIndex = 0
            Me.mobjDomainUpDown.Text = "-"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 15, 0, 0)
            Me.mobjLabel.Size = New System.Drawing.Size(419, 88)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Change item in ComboBox to change value in DomainUpDown:"
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.ClientId = "cb"
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"item1", "item2", "item3", "item4", "item5", "item6"})
            Me.mobjComboBox.Location = New System.Drawing.Point(31, 96)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(130, 21)
            Me.mobjComboBox.TabIndex = 2
            Me.mobjComboBox.Text = "-"
            ' 
            ' mobjLabelSelectedIndex
            ' 
            Me.mobjLabelSelectedIndex.ClientId = "lbl"
            Me.mobjLabelSelectedIndex.Location = New System.Drawing.Point(28, 181)
            Me.mobjLabelSelectedIndex.Name = "mobjLabelSelectedIndex"
            Me.mobjLabelSelectedIndex.Size = New System.Drawing.Size(165, 28)
            Me.mobjLabelSelectedIndex.TabIndex = 3
            Me.mobjLabelSelectedIndex.Text = "Selected Index: "
            ' 
            ' DomainUpDownPage
            ' 
            Me.Controls.Add(Me.mobjLabelSelectedIndex)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjDomainUpDown)
            Me.Size = New System.Drawing.Size(419, 306)
            Me.Text = "DomainUpDownPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjDomainUpDown As Gizmox.WebGUI.Forms.DomainUpDown
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjLabelSelectedIndex As Gizmox.WebGUI.Forms.Label
	End Class

End Namespace