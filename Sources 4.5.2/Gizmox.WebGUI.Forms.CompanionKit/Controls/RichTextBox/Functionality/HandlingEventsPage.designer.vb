Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HandlingEventsPage
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
            Me.mobjDemoRTB = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjSaverRTB = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjSendButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSavedLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 42)
            Me.mobjInfoLabel.TabIndex = 4
            Me.mobjInfoLabel.Text = "Press button to save changed text:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjDemoRTB
            '
            Me.mobjDemoRTB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoRTB.Location = New System.Drawing.Point(10, 52)
            Me.mobjDemoRTB.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjDemoRTB.Name = "mobjDemoRTB"
            Me.mobjDemoRTB.Size = New System.Drawing.Size(300, 106)
            Me.mobjDemoRTB.TabIndex = 5
            '
            'mobjSaverRTB
            '
            Me.mobjSaverRTB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSaverRTB.Location = New System.Drawing.Point(10, 283)
            Me.mobjSaverRTB.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjSaverRTB.Name = "mobjSaverRTB"
            Me.mobjSaverRTB.ReadOnly = True
            Me.mobjSaverRTB.Size = New System.Drawing.Size(300, 107)
            Me.mobjSaverRTB.TabIndex = 6
            '
            'mobjSendButton
            '
            Me.mobjSendButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSendButton.Location = New System.Drawing.Point(10, 178)
            Me.mobjSendButton.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjSendButton.MaximumSize = New System.Drawing.Size(0, 50)
            Me.mobjSendButton.Name = "mobjSendButton"
            Me.mobjSendButton.Size = New System.Drawing.Size(300, 43)
            Me.mobjSendButton.TabIndex = 7
            Me.mobjSendButton.Text = "Send"
            '
            'mobjSavedLabel
            '
            Me.mobjSavedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSavedLabel.Location = New System.Drawing.Point(0, 231)
            Me.mobjSavedLabel.Name = "label1"
            Me.mobjSavedLabel.Size = New System.Drawing.Size(320, 42)
            Me.mobjSavedLabel.TabIndex = 8
            Me.mobjSavedLabel.Text = "Saved text:"
            Me.mobjSavedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjSendButton, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjSavedLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjDemoRTB, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjSaverRTB, 0, 4)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.52632!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 31.57895!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.78947!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.52632!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 31.57895!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 9
            '
            'HandlingEventsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "HandlingEventsPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjDemoRTB As Gizmox.WebGUI.Forms.RichTextBox
        Friend WithEvents mobjSaverRTB As Gizmox.WebGUI.Forms.RichTextBox
        Friend WithEvents mobjSendButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjSavedLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
