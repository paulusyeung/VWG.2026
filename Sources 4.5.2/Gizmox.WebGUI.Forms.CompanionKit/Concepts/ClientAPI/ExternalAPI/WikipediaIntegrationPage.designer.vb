Namespace CompanionKit.Concepts.ClientAPI.ExternalAPI

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WikipediaIntegrationPage
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
            Me.mobjResultHtmlBox = New Gizmox.WebGUI.Forms.HtmlBox()
            Me.mobjQueryTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSearchButton = New Gizmox.WebGUI.Forms.Button()
            Me.SuspendLayout()
            '
            'mobjResultHtmlBox
            '
            Me.mobjResultHtmlBox.Anchor = CType((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjResultHtmlBox.BackColor = System.Drawing.Color.White
            Me.mobjResultHtmlBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjResultHtmlBox.ContentType = "text/html"
            Me.mobjResultHtmlBox.Html = "<HTML></HTML>"
            Me.mobjResultHtmlBox.IsWindowless = True
            Me.mobjResultHtmlBox.Location = New System.Drawing.Point(13, 48)
            Me.mobjResultHtmlBox.Name = "mobjResultHtmlBox"
            Me.mobjResultHtmlBox.Size = New System.Drawing.Size(580, 375)
            Me.mobjResultHtmlBox.TabIndex = 2
            '
            'mobjQueryTextBox
            '
            Me.mobjQueryTextBox.AllowDrag = False
            Me.mobjQueryTextBox.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjQueryTextBox.Location = New System.Drawing.Point(165, 11)
            Me.mobjQueryTextBox.Name = "mobjQueryTextBox"
            Me.mobjQueryTextBox.Size = New System.Drawing.Size(428, 20)
            Me.mobjQueryTextBox.TabIndex = 1
            '
            'mobjSearchButton
            '
            Me.mobjSearchButton.Location = New System.Drawing.Point(13, 9)
            Me.mobjSearchButton.Name = "mobjSearchButton"
            Me.mobjSearchButton.Size = New System.Drawing.Size(133, 23)
            Me.mobjSearchButton.TabIndex = 0
            Me.mobjSearchButton.Text = "Search in Wikipedia"
            '
            'WikipediaIntegrationPage
            '
            Me.Controls.Add(Me.mobjSearchButton)
            Me.Controls.Add(Me.mobjQueryTextBox)
            Me.Controls.Add(Me.mobjResultHtmlBox)
            Me.Size = New System.Drawing.Size(602, 441)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjQueryTextBox As TextBox
        Friend WithEvents mobjResultHtmlBox As HtmlBox
        Friend WithEvents mobjSearchButton As Button

    End Class



End Namespace