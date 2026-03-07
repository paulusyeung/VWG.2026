Namespace CompanionKit.Controls.DateTimePicker.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CustomPopupPage
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
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 320.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabelPanel, 1, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(391, 386)
            Me.mobjLayoutPanel.TabIndex = 0
            ' 
            ' mobjLabelPanel
            ' 
            Me.mobjLabelPanel.Controls.Add(Me.mobjLabel)
            Me.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabelPanel.DockPadding.Bottom = 10
            Me.mobjLabelPanel.DockPadding.Right = 10
            Me.mobjLabelPanel.DockPadding.Top = 10
            Me.mobjLabelPanel.Location = New System.Drawing.Point(35, 0)
            Me.mobjLabelPanel.Name = "mobjLabelPanel"
            Me.mobjLabelPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 10, 10)
            Me.mobjLabelPanel.Size = New System.Drawing.Size(320, 117)
            Me.mobjLabelPanel.TabIndex = 0
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 10)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(310, 97)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "DateTimePicker with custom popup"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            ' 
            ' CustomPopupPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(391, 386)
            Me.Text = "CustomPopupPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjLabelPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace