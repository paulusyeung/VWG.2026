Namespace CompanionKit.Controls.HtmlBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DisplayAnInternalHTMLPagePage
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
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox
            Me.mobjHtmlBox = New Gizmox.WebGUI.Forms.HtmlBox
            Me.mobjGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.mobjGroupBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjGroupBox.Controls.Add(Me.mobjHtmlBox)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "GroupBox1"
            Me.mobjGroupBox.Size = New System.Drawing.Size(576, 250)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "HtmlBox with internal HTML page"
            '
            'HtmlBox1
            '
            Me.mobjHtmlBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjHtmlBox.ContentType = "text/html"
            Me.mobjHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHtmlBox.Expires = -1
            Me.mobjHtmlBox.Html = ""
            Me.mobjHtmlBox.Location = New System.Drawing.Point(3, 17)
            Me.mobjHtmlBox.Name = "HtmlBox1"
            Me.mobjHtmlBox.Size = New System.Drawing.Size(570, 230)
            Me.mobjHtmlBox.TabIndex = 0
            Me.mobjHtmlBox.Url = "/Resources/UserData/about.html"
            '
            'DisplayAnInternalHTMLPagePage
            '
            Me.Controls.Add(Me.mobjGroupBox)
            Me.Size = New System.Drawing.Size(576, 250)
            Me.Text = "DisplayAnInternalHTMLPagePage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjGroupBox As Global.Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjHtmlBox As Global.Gizmox.WebGUI.Forms.HtmlBox

	End Class

End Namespace
