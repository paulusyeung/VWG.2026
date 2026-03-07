Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WordWrapPage
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WordWrapPage))
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjIsWordWrap = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 80)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Change WordWrap property of RichTextBox:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjRichTextBox
            '
            Me.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextBox.Html = resources.GetString("mobjRichTextBox.Html")
            Me.mobjRichTextBox.Location = New System.Drawing.Point(10, 90)
            Me.mobjRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjRichTextBox.Name = "mobjRichTextBox"
            Me.mobjRichTextBox.Size = New System.Drawing.Size(300, 180)
            Me.mobjRichTextBox.TabIndex = 2
            '
            'mobjIsWordWrap
            '
            Me.mobjIsWordWrap.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjIsWordWrap.Checked = True
            Me.mobjIsWordWrap.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjIsWordWrap.Location = New System.Drawing.Point(100, 315)
            Me.mobjIsWordWrap.Name = "mobjIsWordWrap"
            Me.mobjIsWordWrap.Size = New System.Drawing.Size(120, 50)
            Me.mobjIsWordWrap.TabIndex = 6
            Me.mobjIsWordWrap.Text = "WordWrap"
            Me.mobjIsWordWrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjIsWordWrap, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRichTextBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 7
            '
            'WordWrapPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "WordWrapPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Private WithEvents mobjIsWordWrap As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace