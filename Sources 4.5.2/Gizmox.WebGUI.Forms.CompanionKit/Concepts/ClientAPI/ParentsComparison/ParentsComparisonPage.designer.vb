Namespace CompanionKit.Concepts.ClientAPI.ParentsComparison

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ParentsComparisonPage
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
            Me.objLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.objLabel4 = New Gizmox.WebGUI.Forms.Label()
            Me.objLabel3 = New Gizmox.WebGUI.Forms.Label()
            Me.objTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objFirstComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.objSecondComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.objMiddlePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objLabel5 = New Gizmox.WebGUI.Forms.Label()
            Me.objLabel6 = New Gizmox.WebGUI.Forms.Label()
            Me.objTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objThirdPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objSecondPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.objFirstPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objBottomPanel.SuspendLayout()
            Me.objMiddlePanel.SuspendLayout()
            Me.objTopPanel.SuspendLayout()
            Me.objThirdPanel.SuspendLayout()
            Me.objSecondPanel.SuspendLayout()
            Me.objFirstPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objLabel2
            '
            Me.objLabel2.AutoSize = True
            Me.objLabel2.ClientId = "label2"
            Me.objLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objLabel2.Location = New System.Drawing.Point(293, 10)
            Me.objLabel2.Name = "objLabel2"
            Me.objLabel2.Size = New System.Drawing.Size(46, 13)
            Me.objLabel2.TabIndex = 1
            Me.objLabel2.Text = "Label#2"
            '
            'objLabel4
            '
            Me.objLabel4.AutoSize = True
            Me.objLabel4.ClientId = "label4"
            Me.objLabel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objLabel4.Location = New System.Drawing.Point(273, 10)
            Me.objLabel4.Name = "objLabel4"
            Me.objLabel4.Size = New System.Drawing.Size(46, 13)
            Me.objLabel4.TabIndex = 1
            Me.objLabel4.Text = "Label#4"
            '
            'objLabel3
            '
            Me.objLabel3.AutoSize = True
            Me.objLabel3.ClientId = "label3"
            Me.objLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLabel3.Location = New System.Drawing.Point(10, 10)
            Me.objLabel3.Name = "objLabel3"
            Me.objLabel3.Size = New System.Drawing.Size(46, 13)
            Me.objLabel3.TabIndex = 1
            Me.objLabel3.Text = "Label#3"
            '
            'objTextLabel
            '
            Me.objTextLabel.AutoSize = True
            Me.objTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objTextLabel.Location = New System.Drawing.Point(0, 15)
            Me.objTextLabel.Name = "objTextLabel"
            Me.objTextLabel.Size = New System.Drawing.Size(99, 13)
            Me.objTextLabel.TabIndex = 5
            Me.objTextLabel.Text = "Have same parent:"
            '
            'objStateLabel
            '
            Me.objStateLabel.AutoSize = True
            Me.objStateLabel.ClientId = "state"
            Me.objStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objStateLabel.Location = New System.Drawing.Point(246, 15)
            Me.objStateLabel.Name = "objStateLabel"
            Me.objStateLabel.Size = New System.Drawing.Size(43, 13)
            Me.objStateLabel.TabIndex = 6
            Me.objStateLabel.Text = "<bool>"
            '
            'objBottomPanel
            '
            Me.objBottomPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objBottomPanel.Controls.Add(Me.objTextLabel)
            Me.objBottomPanel.Controls.Add(Me.objStateLabel)
            Me.objBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objBottomPanel.DockPadding.Top = 15
            Me.objBottomPanel.Location = New System.Drawing.Point(10, 63)
            Me.objBottomPanel.Name = "objBottomPanel"
            Me.objBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 15, 0, 0)
            Me.objBottomPanel.Size = New System.Drawing.Size(289, 34)
            Me.objBottomPanel.TabIndex = 9
            '
            'objFirstComboBox
            '
            Me.objFirstComboBox.AllowDrag = False
            Me.objFirstComboBox.ClientId = "firstCombo"
            Me.objFirstComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objFirstComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.objFirstComboBox.FormattingEnabled = True
            Me.objFirstComboBox.Items.AddRange(New Object() {"Label#1", "Label#2", "Label#3", "Label#4", "Label#5", "Label#6"})
            Me.objFirstComboBox.Location = New System.Drawing.Point(0, 0)
            Me.objFirstComboBox.Name = "objFirstComboBox"
            Me.objFirstComboBox.Size = New System.Drawing.Size(106, 21)
            Me.objFirstComboBox.TabIndex = 2
            Me.objFirstComboBox.Text = "Label#1"
            '
            'objSecondComboBox
            '
            Me.objSecondComboBox.AllowDrag = False
            Me.objSecondComboBox.ClientId = "secondCombo"
            Me.objSecondComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objSecondComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.objSecondComboBox.FormattingEnabled = True
            Me.objSecondComboBox.Items.AddRange(New Object() {"Label#1", "Label#2", "Label#3", "Label#4", "Label#5", "Label#6"})
            Me.objSecondComboBox.Location = New System.Drawing.Point(183, 0)
            Me.objSecondComboBox.Name = "objSecondComboBox"
            Me.objSecondComboBox.Size = New System.Drawing.Size(106, 21)
            Me.objSecondComboBox.TabIndex = 3
            Me.objSecondComboBox.Text = "Label#2"
            '
            'objMiddlePanel
            '
            Me.objMiddlePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objMiddlePanel.Controls.Add(Me.objFirstComboBox)
            Me.objMiddlePanel.Controls.Add(Me.objSecondComboBox)
            Me.objMiddlePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objMiddlePanel.Location = New System.Drawing.Point(10, 40)
            Me.objMiddlePanel.Name = "objMiddlePanel"
            Me.objMiddlePanel.Size = New System.Drawing.Size(289, 23)
            Me.objMiddlePanel.TabIndex = 8
            '
            'objLabel5
            '
            Me.objLabel5.AutoSize = True
            Me.objLabel5.ClientId = "label5"
            Me.objLabel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLabel5.Location = New System.Drawing.Point(0, 0)
            Me.objLabel5.Name = "objLabel5"
            Me.objLabel5.Size = New System.Drawing.Size(46, 13)
            Me.objLabel5.TabIndex = 1
            Me.objLabel5.Text = "Label#5"
            '
            'objLabel6
            '
            Me.objLabel6.AutoSize = True
            Me.objLabel6.ClientId = "label6"
            Me.objLabel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objLabel6.Location = New System.Drawing.Point(243, 0)
            Me.objLabel6.Name = "objLabel6"
            Me.objLabel6.Size = New System.Drawing.Size(46, 13)
            Me.objLabel6.TabIndex = 1
            Me.objLabel6.Text = "Label#6"
            '
            'objTopPanel
            '
            Me.objTopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objTopPanel.Controls.Add(Me.objLabel5)
            Me.objTopPanel.Controls.Add(Me.objLabel6)
            Me.objTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objTopPanel.Location = New System.Drawing.Point(10, 10)
            Me.objTopPanel.Name = "objTopPanel"
            Me.objTopPanel.Size = New System.Drawing.Size(289, 30)
            Me.objTopPanel.TabIndex = 7
            '
            'objButton
            '
            Me.objButton.Location = New System.Drawing.Point(13, 105)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(96, 23)
            Me.objButton.TabIndex = 4
            Me.objButton.Text = "Compare"
            '
            'objThirdPanel
            '
            Me.objThirdPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objThirdPanel.Controls.Add(Me.objBottomPanel)
            Me.objThirdPanel.Controls.Add(Me.objMiddlePanel)
            Me.objThirdPanel.Controls.Add(Me.objTopPanel)
            Me.objThirdPanel.Controls.Add(Me.objButton)
            Me.objThirdPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objThirdPanel.DockPadding.All = 10
            Me.objThirdPanel.Location = New System.Drawing.Point(10, 76)
            Me.objThirdPanel.Name = "objThirdPanel"
            Me.objThirdPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objThirdPanel.Size = New System.Drawing.Size(309, 138)
            Me.objThirdPanel.TabIndex = 7
            '
            'objSecondPanel
            '
            Me.objSecondPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objSecondPanel.Controls.Add(Me.objLabel4)
            Me.objSecondPanel.Controls.Add(Me.objLabel3)
            Me.objSecondPanel.Controls.Add(Me.objThirdPanel)
            Me.objSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objSecondPanel.DockPadding.All = 10
            Me.objSecondPanel.Location = New System.Drawing.Point(10, 52)
            Me.objSecondPanel.Name = "objSecondPanel"
            Me.objSecondPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objSecondPanel.Size = New System.Drawing.Size(329, 224)
            Me.objSecondPanel.TabIndex = 7
            '
            'objLabel1
            '
            Me.objLabel1.AutoSize = True
            Me.objLabel1.ClientId = "label1"
            Me.objLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLabel1.Location = New System.Drawing.Point(10, 10)
            Me.objLabel1.Name = "objLabel1"
            Me.objLabel1.Size = New System.Drawing.Size(46, 13)
            Me.objLabel1.TabIndex = 0
            Me.objLabel1.Text = "Label#1"
            '
            'objFirstPanel
            '
            Me.objFirstPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objFirstPanel.Controls.Add(Me.objLabel2)
            Me.objFirstPanel.Controls.Add(Me.objLabel1)
            Me.objFirstPanel.Controls.Add(Me.objSecondPanel)
            Me.objFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objFirstPanel.DockPadding.All = 10
            Me.objFirstPanel.Location = New System.Drawing.Point(0, 0)
            Me.objFirstPanel.MaximumSize = New System.Drawing.Size(349, 286)
            Me.objFirstPanel.Name = "objFirstPanel"
            Me.objFirstPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objFirstPanel.Size = New System.Drawing.Size(349, 286)
            Me.objFirstPanel.TabIndex = 0
            '
            'ParentsComparisonPage
            '
            Me.Controls.Add(Me.objFirstPanel)
            Me.Size = New System.Drawing.Size(398, 306)
            Me.Text = "ParentsComparisonPage"
            Me.objBottomPanel.ResumeLayout(False)
            Me.objMiddlePanel.ResumeLayout(False)
            Me.objTopPanel.ResumeLayout(False)
            Me.objThirdPanel.ResumeLayout(False)
            Me.objSecondPanel.ResumeLayout(False)
            Me.objFirstPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objLabel2 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objLabel4 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objLabel3 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objStateLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objFirstComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents objSecondComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents objMiddlePanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objLabel5 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objLabel6 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objTopPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objThirdPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objSecondPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objLabel1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents objFirstPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace