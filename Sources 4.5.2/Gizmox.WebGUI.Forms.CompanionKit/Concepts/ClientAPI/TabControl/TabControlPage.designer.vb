Namespace CompanionKit.Concepts.ClientAPI.TabControl

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TabControlPage
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
            Me.objTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.objTabPage1 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage2 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage3 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage4 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objTabPage5 = New Gizmox.WebGUI.Forms.TabPage()
            Me.objSelectedIndexLabelText = New Gizmox.WebGUI.Forms.Label()
            Me.objPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.objTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.objTabControl.SuspendLayout()
            Me.objPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' objTabControl
            ' 
            Me.objTabControl.AccessibleDescription = ""
            Me.objTabControl.AccessibleName = ""
            Me.objTabControl.ClientId = "tab"
            Me.objTabControl.Controls.Add(Me.objTabPage1)
            Me.objTabControl.Controls.Add(Me.objTabPage2)
            Me.objTabControl.Controls.Add(Me.objTabPage3)
            Me.objTabControl.Controls.Add(Me.objTabPage4)
            Me.objTabControl.Controls.Add(Me.objTabPage5)
            Me.objTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabControl.Location = New System.Drawing.Point(15, 15)
            Me.objTabControl.MaximumSize = New System.Drawing.Size(325, 217)
            Me.objTabControl.Name = "objTabControl"
            Me.objTabControl.SelectedIndex = 0
            Me.objTabControl.Size = New System.Drawing.Size(325, 217)
            Me.objTabControl.TabIndex = 0
            ' 
            ' objTabPage1
            ' 
            Me.objTabPage1.AccessibleDescription = ""
            Me.objTabPage1.AccessibleName = ""
            Me.objTabPage1.BackColor = System.Drawing.Color.Yellow
            Me.objTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage1.Location = New System.Drawing.Point(4, 22)
            Me.objTabPage1.Name = "objTabPage1"
            Me.objTabPage1.Size = New System.Drawing.Size(317, 191)
            Me.objTabPage1.TabIndex = 0
            Me.objTabPage1.Text = "tabPage1"
            ' 
            ' objTabPage2
            ' 
            Me.objTabPage2.AccessibleDescription = ""
            Me.objTabPage2.AccessibleName = ""
            Me.objTabPage2.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(128)), CInt(CByte(0)))
            Me.objTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage2.Location = New System.Drawing.Point(4, 22)
            Me.objTabPage2.Name = "objTabPage2"
            Me.objTabPage2.Size = New System.Drawing.Size(289, 229)
            Me.objTabPage2.TabIndex = 1
            Me.objTabPage2.Text = "tabPage2"
            ' 
            ' objTabPage3
            ' 
            Me.objTabPage3.AccessibleDescription = ""
            Me.objTabPage3.AccessibleName = ""
            Me.objTabPage3.BackColor = System.Drawing.Color.Red
            Me.objTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage3.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage3.Name = "objTabPage3"
            Me.objTabPage3.Size = New System.Drawing.Size(289, 229)
            Me.objTabPage3.TabIndex = 2
            Me.objTabPage3.Text = "tabPage3"
            ' 
            ' objTabPage4
            ' 
            Me.objTabPage4.AccessibleDescription = ""
            Me.objTabPage4.AccessibleName = ""
            Me.objTabPage4.BackColor = System.Drawing.Color.Purple
            Me.objTabPage4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage4.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage4.Name = "objTabPage4"
            Me.objTabPage4.Size = New System.Drawing.Size(289, 229)
            Me.objTabPage4.TabIndex = 3
            Me.objTabPage4.Text = "tabPage4"
            ' 
            ' objTabPage5
            ' 
            Me.objTabPage5.AccessibleDescription = ""
            Me.objTabPage5.AccessibleName = ""
            Me.objTabPage5.BackColor = System.Drawing.Color.Blue
            Me.objTabPage5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTabPage5.Location = New System.Drawing.Point(0, 0)
            Me.objTabPage5.Name = "objTabPage5"
            Me.objTabPage5.Size = New System.Drawing.Size(283, 191)
            Me.objTabPage5.TabIndex = 4
            Me.objTabPage5.Text = "tabPage5"
            ' 
            ' objSelectedIndexLabelText
            ' 
            Me.objSelectedIndexLabelText.AccessibleDescription = ""
            Me.objSelectedIndexLabelText.AccessibleName = ""
            Me.objSelectedIndexLabelText.ClientId = "indexLabel"
            Me.objSelectedIndexLabelText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objSelectedIndexLabelText.Location = New System.Drawing.Point(20, 20)
            Me.objSelectedIndexLabelText.Name = "objSelectedIndexLabelText"
            Me.objSelectedIndexLabelText.Size = New System.Drawing.Size(285, 60)
            Me.objSelectedIndexLabelText.TabIndex = 2
            Me.objSelectedIndexLabelText.Text = "Index of selected tabPage:<index>"
            ' 
            ' objPanel
            ' 
            Me.objPanel.AccessibleDescription = ""
            Me.objPanel.AccessibleName = ""
            Me.objPanel.Controls.Add(Me.objSelectedIndexLabelText)
            Me.objPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objPanel.DockPadding.All = 20
            Me.objPanel.Location = New System.Drawing.Point(15, 232)
            Me.objPanel.Name = "objPanel"
            Me.objPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20)
            Me.objPanel.Size = New System.Drawing.Size(325, 100)
            Me.objPanel.TabIndex = 5
            ' 
            ' TabControlPage
            ' 
            Me.Controls.Add(Me.objTabControl)
            Me.Controls.Add(Me.objPanel)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(355, 347)
            Me.Text = "TabPagesExamplePage"
            DirectCast(Me.objTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.objTabControl.ResumeLayout(False)
            Me.objPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents objTabControl As Gizmox.WebGUI.Forms.TabControl
        Private objTabPage1 As Gizmox.WebGUI.Forms.TabPage
        Private objTabPage2 As Gizmox.WebGUI.Forms.TabPage
        Private objTabPage3 As Gizmox.WebGUI.Forms.TabPage
        Private objTabPage4 As Gizmox.WebGUI.Forms.TabPage
        Private objTabPage5 As Gizmox.WebGUI.Forms.TabPage
        Private objSelectedIndexLabelText As Gizmox.WebGUI.Forms.Label
        Private objPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace