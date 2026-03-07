Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FontPage
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
            Me.mobjChangeFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjChangeFontLabel
            ' 
            Me.mobjChangeFontLabel.AutoSize = True
            Me.mobjChangeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeFontLabel.Location = New System.Drawing.Point(84, 40)
            Me.mobjChangeFontLabel.Name = "mobjChangeFontLabel"
            Me.mobjChangeFontLabel.Size = New System.Drawing.Size(393, 50)
            Me.mobjChangeFontLabel.TabIndex = 1
            Me.mobjChangeFontLabel.Text = "Font selected in the dialog: "
            Me.mobjChangeFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjChangeFontButton
            ' 
            Me.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeFontButton.Location = New System.Drawing.Point(84, 110)
            Me.mobjChangeFontButton.Name = "mobjChangeFontButton"
            Me.mobjChangeFontButton.Size = New System.Drawing.Size(393, 50)
            Me.mobjChangeFontButton.TabIndex = 2
            Me.mobjChangeFontButton.Text = "Change font for label with FontDialog"
            Me.mobjChangeFontButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoFontDialog
            ' 
            Me.mobjDemoFontDialog.MaxSize = 28
            Me.mobjDemoFontDialog.MinSize = 8
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeFontLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeFontButton, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(562, 201)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' FontPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(562, 201)
            Me.Text = "FontPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjChangeFontLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjChangeFontButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
