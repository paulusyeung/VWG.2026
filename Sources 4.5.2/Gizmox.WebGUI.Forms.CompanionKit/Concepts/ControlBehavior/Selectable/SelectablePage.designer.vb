Namespace CompanionKit.Concepts.ControlBehavior.Selectable

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SelectablePage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel5 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel4 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectedInfo = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjLabel5)
            Me.mobjPanel.Controls.Add(Me.mobjLabel4)
            Me.mobjPanel.Controls.Add(Me.mobjLabel3)
            Me.mobjPanel.Controls.Add(Me.mobjLabel2)
            Me.mobjPanel.Controls.Add(Me.mobjLabel1)
            Me.mobjPanel.Location = New System.Drawing.Point(33, 102)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(182, 194)
            Me.mobjPanel.TabIndex = 1
            ' 
            ' mobjLabel5
            ' 
            Me.mobjLabel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel5.Location = New System.Drawing.Point(0, 120)
            Me.mobjLabel5.Name = "mobjLabel5"
            Me.mobjLabel5.Size = New System.Drawing.Size(182, 30)
            Me.mobjLabel5.TabIndex = 4
            Me.mobjLabel5.Tag = True
            Me.mobjLabel5.Text = "item5"
            Me.mobjLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel4
            ' 
            Me.mobjLabel4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel4.Location = New System.Drawing.Point(0, 90)
            Me.mobjLabel4.Name = "mobjLabel4"
            Me.mobjLabel4.Size = New System.Drawing.Size(182, 30)
            Me.mobjLabel4.TabIndex = 3
            Me.mobjLabel4.Tag = True
            Me.mobjLabel4.Text = "item4"
            Me.mobjLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel3
            ' 
            Me.mobjLabel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel3.Location = New System.Drawing.Point(0, 60)
            Me.mobjLabel3.Name = "mobjLabel3"
            Me.mobjLabel3.Size = New System.Drawing.Size(182, 30)
            Me.mobjLabel3.TabIndex = 2
            Me.mobjLabel3.Tag = True
            Me.mobjLabel3.Text = "item3"
            Me.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel2
            ' 
            Me.mobjLabel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 30)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(182, 30)
            Me.mobjLabel2.TabIndex = 1
            Me.mobjLabel2.Tag = True
            Me.mobjLabel2.Text = "item2"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel1
            ' 
            Me.mobjLabel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(182, 30)
            Me.mobjLabel1.TabIndex = 0
            Me.mobjLabel1.Tag = True
            Me.mobjLabel1.Text = "item1"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjSelectedInfo
            ' 
            Me.mobjSelectedInfo.Location = New System.Drawing.Point(33, 70)
            Me.mobjSelectedInfo.Name = "mobjSelectedInfo"
            Me.mobjSelectedInfo.Size = New System.Drawing.Size(182, 32)
            Me.mobjSelectedInfo.TabIndex = 2
            Me.mobjSelectedInfo.Text = "Selected: None"
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(391, 70)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "Click any label on panel to select it. Selected label changes background color:"
            ' 
            ' SelectablePage
            ' 
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjSelectedInfo)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(391, 330)
            Me.Text = "SelectablePage"
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjPanel As Panel
        Private WithEvents mobjLabel3 As Label
        Private WithEvents mobjLabel2 As Label
        Private WithEvents mobjLabel1 As Label
        Private WithEvents mobjLabel5 As Label
        Private WithEvents mobjLabel4 As Label
        Private WithEvents mobjSelectedInfo As Label
        Private WithEvents mobjInfoLabel As Label

	End Class

End Namespace