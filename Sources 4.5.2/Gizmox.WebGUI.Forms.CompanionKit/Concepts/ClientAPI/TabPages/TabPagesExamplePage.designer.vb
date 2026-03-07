Namespace CompanionKit.Concepts.ClientAPI.TabPages

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TabPagesExamplePage
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
            Me.objCountLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objTabPage1 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage2 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage3 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage4 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage5 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabControl = New Gizmox.WebGUI.Forms.TabControl()
            CType(Me.objTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.objTabControl.SuspendLayout()
            Me.SuspendLayout()
            '
            'objCountLabel
            '
            Me.objCountLabel.AutoSize = True
            Me.objCountLabel.ClientId = "countLabel"
            Me.objCountLabel.Location = New System.Drawing.Point(30, 321)
            Me.objCountLabel.Name = "objCountLabel"
            Me.objCountLabel.Size = New System.Drawing.Size(35, 13)
            Me.objCountLabel.TabIndex = 1
            Me.objCountLabel.Text = "5 page(s) left"
            '
            'objTabPage1
            '
            Me.objTabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage1.Location = New System.Drawing.Point(4, 22)
            Me.objTabPage1.Name = "objTabPage1"
            Me.objTabPage1.Size = New System.Drawing.Size(244, 225)
            Me.objTabPage1.TabIndex = 0
            Me.objTabPage1.Text = "tabPage1"
            '
            'objTabPage2
            '
            Me.objTabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage2.Location = New System.Drawing.Point(4, 22)
            Me.objTabPage2.Name = "objTabPage2"
            Me.objTabPage2.Size = New System.Drawing.Size(244, 225)
            Me.objTabPage2.TabIndex = 1
            Me.objTabPage2.Text = "tabPage2"
            '
            'objTabPage3
            '
            Me.objTabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage3.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage3.Name = "objTabPage3"
            Me.objTabPage3.Size = New System.Drawing.Size(244, 225)
            Me.objTabPage3.TabIndex = 2
            Me.objTabPage3.Text = "tabPage3"
            '
            'objTabPage4
            '
            Me.objTabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objTabPage4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage4.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage4.Name = "objTabPage4"
            Me.objTabPage4.Size = New System.Drawing.Size(244, 225)
            Me.objTabPage4.TabIndex = 3
            Me.objTabPage4.Text = "tabPage4"
            '
            'objTabPage5
            '
            Me.objTabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.objTabPage5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage5.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage5.Name = "objTabPage5"
            Me.objTabPage5.Size = New System.Drawing.Size(244, 225)
            Me.objTabPage5.TabIndex = 4
            Me.objTabPage5.Text = "tabPage5"
            '
            'objTabControl
            '
            Me.objTabControl.ClientId = "tab"
            Me.objTabControl.Controls.Add(Me.objTabPage1)
            Me.objTabControl.Controls.Add(Me.objTabPage2)
            Me.objTabControl.Controls.Add(Me.objTabPage3)
            Me.objTabControl.Controls.Add(Me.objTabPage4)
            Me.objTabControl.Controls.Add(Me.objTabPage5)
            Me.objTabControl.Location = New System.Drawing.Point(29, 33)
            Me.objTabControl.Name = "objTabControl"
            Me.objTabControl.SelectedIndex = 0
            Me.objTabControl.ShowCloseButton = True
            Me.objTabControl.Size = New System.Drawing.Size(252, 251)
            Me.objTabControl.TabIndex = 0
            '
            'TabPagesExamplePage
            '
            Me.Controls.Add(Me.objTabControl)
            Me.Controls.Add(Me.objCountLabel)
            Me.Size = New System.Drawing.Size(332, 365)
            Me.Text = "TabControlPage"
            CType(Me.objTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.objTabControl.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objCountLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objTabPage1 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents objTabPage2 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents objTabPage3 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents objTabPage4 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents objTabPage5 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents objTabControl As Gizmox.WebGUI.Forms.TabControl

	End Class

End Namespace