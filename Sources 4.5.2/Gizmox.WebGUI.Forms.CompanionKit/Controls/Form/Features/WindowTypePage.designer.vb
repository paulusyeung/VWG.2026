Namespace CompanionKit.Controls.Form.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WindowTypePage
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
           Me.mobjOpenModelessFormButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjOpenPopupFormButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjOpenModalFormButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjOpenModelessFormButton
            ' 
            Me.mobjOpenModelessFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenModelessFormButton.Location = New System.Drawing.Point(57, 11)
            Me.mobjOpenModelessFormButton.Name = "button1"
            Me.mobjOpenModelessFormButton.Size = New System.Drawing.Size(268, 60)
            Me.mobjOpenModelessFormButton.TabIndex = 1
            Me.mobjOpenModelessFormButton.Text = "Open modeless form"
            Me.mobjOpenModelessFormButton.UseVisualStyleBackColor = True
            ' 
            ' mobjOpenPopupFormButton
            ' 
            Me.mobjOpenPopupFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenPopupFormButton.Location = New System.Drawing.Point(57, 151)
            Me.mobjOpenPopupFormButton.Name = "button2"
            Me.mobjOpenPopupFormButton.Size = New System.Drawing.Size(268, 60)
            Me.mobjOpenPopupFormButton.TabIndex = 2
            Me.mobjOpenPopupFormButton.Text = "Open popup form"
            Me.mobjOpenPopupFormButton.UseVisualStyleBackColor = True
            ' 
            ' mobjOpenModalFormButton
            ' 
            Me.mobjOpenModalFormButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenModalFormButton.Location = New System.Drawing.Point(57, 81)
            Me.mobjOpenModalFormButton.Name = "button3"
            Me.mobjOpenModalFormButton.Size = New System.Drawing.Size(268, 60)
            Me.mobjOpenModalFormButton.TabIndex = 3
            Me.mobjOpenModalFormButton.Text = "Open modal form"
            Me.mobjOpenModalFormButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenModalFormButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenModelessFormButton, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenPopupFormButton, 1, 5)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(384, 222)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' WindowTypePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(384, 222)
            Me.Text = "WindowTypePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjOpenModelessFormButton As Global.Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjOpenPopupFormButton As Global.Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjOpenModalFormButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
