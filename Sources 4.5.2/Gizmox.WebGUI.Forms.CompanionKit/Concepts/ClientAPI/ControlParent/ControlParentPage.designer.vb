Namespace CompanionKit.Concepts.ClientAPI.ControlParent

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ControlParentPage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjShowParentButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabelInfo = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel.SuspendLayout()
            Me.mobjPanel1.SuspendLayout()
            Me.mobjPanel2.SuspendLayout()
            Me.mobjPanel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjPanel
            '
            Me.mobjPanel.Controls.Add(Me.mobjPanel1)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel.DockPadding.All = 15
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjPanel.Size = New System.Drawing.Size(457, 204)
            Me.mobjPanel.TabIndex = 0
            '
            'mobjPanel1
            '
            Me.mobjPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel1.ClientId = "p1"
            Me.mobjPanel1.Controls.Add(Me.mobjLabel1)
            Me.mobjPanel1.Controls.Add(Me.mobjPanel2)
            Me.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel1.DockPadding.All = 30
            Me.mobjPanel1.Location = New System.Drawing.Point(15, 15)
            Me.mobjPanel1.Name = "mobjPanel1"
            Me.mobjPanel1.Padding = New Gizmox.WebGUI.Forms.Padding(30)
            Me.mobjPanel1.Size = New System.Drawing.Size(427, 174)
            Me.mobjPanel1.TabIndex = 0
            '
            'mobjLabel1
            '
            Me.mobjLabel1.AutoSize = True
            Me.mobjLabel1.ClientId = "l1"
            Me.mobjLabel1.Location = New System.Drawing.Point(0, -1)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel1.TabIndex = 1
            Me.mobjLabel1.Text = "label1"
            '
            'mobjPanel2
            '
            Me.mobjPanel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel2.ClientId = "p2"
            Me.mobjPanel2.Controls.Add(Me.mobjLabel2)
            Me.mobjPanel2.Controls.Add(Me.mobjPanel3)
            Me.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel2.DockPadding.All = 30
            Me.mobjPanel2.Location = New System.Drawing.Point(30, 30)
            Me.mobjPanel2.Name = "mobjPanel2"
            Me.mobjPanel2.Padding = New Gizmox.WebGUI.Forms.Padding(30)
            Me.mobjPanel2.Size = New System.Drawing.Size(365, 112)
            Me.mobjPanel2.TabIndex = 0
            '
            'mobjLabel2
            '
            Me.mobjLabel2.AutoSize = True
            Me.mobjLabel2.ClientId = "l2"
            Me.mobjLabel2.Location = New System.Drawing.Point(-1, -1)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel2.TabIndex = 1
            Me.mobjLabel2.Text = "label2"
            '
            'mobjPanel3
            '
            Me.mobjPanel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel3.ClientId = "p3"
            Me.mobjPanel3.Controls.Add(Me.mobjLabel3)
            Me.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel3.Location = New System.Drawing.Point(30, 30)
            Me.mobjPanel3.Name = "mobjPanel3"
            Me.mobjPanel3.Size = New System.Drawing.Size(303, 50)
            Me.mobjPanel3.TabIndex = 0
            '
            'mobjLabel3
            '
            Me.mobjLabel3.AutoSize = True
            Me.mobjLabel3.ClientId = "l3"
            Me.mobjLabel3.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel3.Name = "mobjLabel3"
            Me.mobjLabel3.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel3.TabIndex = 0
            Me.mobjLabel3.Text = "label3"
            '
            'mobjComboBox
            '
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.ClientId = "cb"
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"label1", "label2", "label3"})
            Me.mobjComboBox.Location = New System.Drawing.Point(16, 245)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(131, 21)
            Me.mobjComboBox.TabIndex = 1
            Me.mobjComboBox.Text = "-"
            '
            'mobjShowParentButton
            '
            Me.mobjShowParentButton.Location = New System.Drawing.Point(16, 283)
            Me.mobjShowParentButton.Name = "mobjShowParentButton"
            Me.mobjShowParentButton.Size = New System.Drawing.Size(131, 23)
            Me.mobjShowParentButton.TabIndex = 2
            Me.mobjShowParentButton.Text = "Show parent"
            '
            'mobjLabelInfo
            '
            Me.mobjLabelInfo.AutoSize = True
            Me.mobjLabelInfo.Location = New System.Drawing.Point(16, 218)
            Me.mobjLabelInfo.Name = "mobjLabelInfo"
            Me.mobjLabelInfo.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabelInfo.TabIndex = 3
            Me.mobjLabelInfo.Text = "Select label and click button:"
            '
            'ControlParentPage
            '
            Me.ClientId = "uc"
            Me.Controls.Add(Me.mobjLabelInfo)
            Me.Controls.Add(Me.mobjShowParentButton)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(457, 420)
            Me.Text = "ControlParentPage"
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjPanel1.ResumeLayout(False)
            Me.mobjPanel2.ResumeLayout(False)
            Me.mobjPanel3.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjPanel1 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjPanel2 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjPanel3 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjLabel3 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjShowParentButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjLabelInfo As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace