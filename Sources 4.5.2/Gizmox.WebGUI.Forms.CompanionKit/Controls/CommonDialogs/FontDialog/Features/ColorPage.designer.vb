Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ColorPage
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
            Me.mobjColorFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeForeColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjColorFontLabel
            ' 
            Me.mobjColorFontLabel.AutoSize = True
            Me.mobjColorFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjColorFontLabel.Location = New System.Drawing.Point(88, 49)
            Me.mobjColorFontLabel.Name = "mobjColorFontLabel"
            Me.mobjColorFontLabel.Size = New System.Drawing.Size(415, 50)
            Me.mobjColorFontLabel.TabIndex = 1
            Me.mobjColorFontLabel.Text = "Font selected in the dialog:"
            Me.mobjColorFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjChangeForeColorButton
            ' 
            Me.mobjChangeForeColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeForeColorButton.Location = New System.Drawing.Point(88, 119)
            Me.mobjChangeForeColorButton.Name = "mobjChangeForeColorButton"
            Me.mobjChangeForeColorButton.Size = New System.Drawing.Size(415, 50)
            Me.mobjChangeForeColorButton.TabIndex = 2
            Me.mobjChangeForeColorButton.Text = "Open FontDialog to change foreground color of label"
            Me.mobjChangeForeColorButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoFontDialog
            ' 
            Me.mobjDemoFontDialog.MaxSize = 28
            Me.mobjDemoFontDialog.MinSize = 8
            Me.mobjDemoFontDialog.ShowColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjColorFontLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeForeColorButton, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(593, 219)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ColorPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(593, 219)
            Me.Text = "ColorPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjColorFontLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjChangeForeColorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
