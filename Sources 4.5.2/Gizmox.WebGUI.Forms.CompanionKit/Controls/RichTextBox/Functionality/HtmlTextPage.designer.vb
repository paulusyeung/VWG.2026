Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HtmlTextPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjHtmlButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Click appropriate button to set Html or Text property:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTLP.SetColumnSpan(Me.mobjTextBox, 2)
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBox.Location = New System.Drawing.Point(5, 65)
            Me.mobjTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(310, 130)
            Me.mobjTextBox.TabIndex = 1
            Me.mobjTextBox.Text = "<b>This is bold text</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<ol>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <li>This is</li>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <li>ordered</li>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <li>lis" & _
        "t</li>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</ol>"
            '
            'mobjRichTextBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjRichTextBox, 2)
            Me.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextBox.Location = New System.Drawing.Point(5, 265)
            Me.mobjRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjRichTextBox.Name = "mobjRichTextBox"
            Me.mobjRichTextBox.Size = New System.Drawing.Size(310, 130)
            Me.mobjRichTextBox.TabIndex = 2
            '
            'mobjHtmlButton
            '
            Me.mobjHtmlButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHtmlButton.Location = New System.Drawing.Point(5, 205)
            Me.mobjHtmlButton.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjHtmlButton.MaximumSize = New System.Drawing.Size(0, 80)
            Me.mobjHtmlButton.Name = "mobjHtmlButton"
            Me.mobjHtmlButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjHtmlButton.TabIndex = 3
            Me.mobjHtmlButton.Text = "Set as Html"
            '
            'mobjTextButton
            '
            Me.mobjTextButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextButton.Location = New System.Drawing.Point(165, 205)
            Me.mobjTextButton.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjTextButton.MaximumSize = New System.Drawing.Size(0, 80)
            Me.mobjTextButton.Name = "mobjTextButton"
            Me.mobjTextButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjTextButton.TabIndex = 4
            Me.mobjTextButton.Text = "Set as Text"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTextButton, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjHtmlButton, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRichTextBox, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 5
            '
            'HtmlTextPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "HtmlTextPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Private WithEvents mobjHtmlButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTextButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace