Namespace CompanionKit.Concepts.ClientAPI.HTMLBoxFolder

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HTMLBoxPage
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
            Me.objHTMLBox = New Gizmox.WebGUI.Forms.HtmlBox()
            Me.objTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objAddressPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objButtonPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objNavigationPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objAddressPanel.SuspendLayout()
            Me.objButtonPanel.SuspendLayout()
            Me.objNavigationPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objHTMLBox
            '
            Me.objHTMLBox.ClientId = "htmlBox"
            Me.objHTMLBox.ContentType = "text/html"
            Me.objHTMLBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objHTMLBox.Html = "<HTML>No content.</HTML>"
            Me.objHTMLBox.Location = New System.Drawing.Point(0, 72)
            Me.objHTMLBox.Name = "objHTMLBox"
            Me.objHTMLBox.Size = New System.Drawing.Size(391, 360)
            Me.objHTMLBox.TabIndex = 0
            '
            'objTextBox
            '
            Me.objTextBox.AllowDrag = False
            Me.objTextBox.ClientId = "textBox"
            Me.objTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objTextBox.Location = New System.Drawing.Point(15, 25)
            Me.objTextBox.MaximumSize = New System.Drawing.Size(0, 20)
            Me.objTextBox.Name = "objTextBox"
            Me.objTextBox.Size = New System.Drawing.Size(286, 20)
            Me.objTextBox.TabIndex = 0
            '
            'objAddressPanel
            '
            Me.objAddressPanel.Controls.Add(Me.objTextBox)
            Me.objAddressPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objAddressPanel.DockPadding.Left = 15
            Me.objAddressPanel.DockPadding.Right = 15
            Me.objAddressPanel.DockPadding.Top = 25
            Me.objAddressPanel.Location = New System.Drawing.Point(0, 0)
            Me.objAddressPanel.Name = "objAddressPanel"
            Me.objAddressPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 25, 15, 0)
            Me.objAddressPanel.Size = New System.Drawing.Size(316, 72)
            Me.objAddressPanel.TabIndex = 1
            '
            'objButton
            '
            Me.objButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objButton.Location = New System.Drawing.Point(5, 10)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(60, 52)
            Me.objButton.TabIndex = 0
            Me.objButton.Text = "Navigate"
            '
            'objButtonPanel
            '
            Me.objButtonPanel.Controls.Add(Me.objButton)
            Me.objButtonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objButtonPanel.DockPadding.Bottom = 10
            Me.objButtonPanel.DockPadding.Left = 5
            Me.objButtonPanel.DockPadding.Right = 10
            Me.objButtonPanel.DockPadding.Top = 10
            Me.objButtonPanel.Location = New System.Drawing.Point(316, 0)
            Me.objButtonPanel.Name = "objButtonPanel"
            Me.objButtonPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5, 10, 10, 10)
            Me.objButtonPanel.Size = New System.Drawing.Size(75, 72)
            Me.objButtonPanel.TabIndex = 2
            '
            'objNavigationPanel
            '
            Me.objNavigationPanel.Controls.Add(Me.objAddressPanel)
            Me.objNavigationPanel.Controls.Add(Me.objButtonPanel)
            Me.objNavigationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objNavigationPanel.Location = New System.Drawing.Point(0, 0)
            Me.objNavigationPanel.Name = "objNavigationPanel"
            Me.objNavigationPanel.Size = New System.Drawing.Size(391, 72)
            Me.objNavigationPanel.TabIndex = 1
            '
            'HTMLBoxPage
            '
            Me.Controls.Add(Me.objHTMLBox)
            Me.Controls.Add(Me.objNavigationPanel)
            Me.Size = New System.Drawing.Size(391, 432)
            Me.Text = "HTMLBoxPage"
            Me.objAddressPanel.ResumeLayout(False)
            Me.objButtonPanel.ResumeLayout(False)
            Me.objNavigationPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objHTMLBox As Gizmox.WebGUI.Forms.HtmlBox
        Private WithEvents objTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objAddressPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objButtonPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objNavigationPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace