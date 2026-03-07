Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ShowHelpPage
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
            Me.mobjAllowShowHelpCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjShowHelpLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjShowHelpButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjAllowShowHelpCheckBox
            ' 
            Me.mobjAllowShowHelpCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.mobjAllowShowHelpCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowShowHelpCheckBox.Location = New System.Drawing.Point(83, 111)
            Me.mobjAllowShowHelpCheckBox.Name = "mobjAllowShowHelpCheckBox"
            Me.mobjAllowShowHelpCheckBox.Size = New System.Drawing.Size(388, 70)
            Me.mobjAllowShowHelpCheckBox.TabIndex = 1
            Me.mobjAllowShowHelpCheckBox.Text = "Enable help button in FontDialog"
            Me.mobjAllowShowHelpCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjShowHelpLabel
            ' 
            Me.mobjShowHelpLabel.AutoSize = True
            Me.mobjShowHelpLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowHelpLabel.Location = New System.Drawing.Point(83, 21)
            Me.mobjShowHelpLabel.Name = "mobjShowHelpLabel"
            Me.mobjShowHelpLabel.Size = New System.Drawing.Size(388, 50)
            Me.mobjShowHelpLabel.TabIndex = 2
            Me.mobjShowHelpLabel.Text = "Font selected in the dialog:"
            ' 
            ' mobjShowHelpButton
            ' 
            Me.mobjShowHelpButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowHelpButton.Location = New System.Drawing.Point(83, 201)
            Me.mobjShowHelpButton.Name = "mobjShowHelpButton"
            Me.mobjShowHelpButton.Size = New System.Drawing.Size(388, 50)
            Me.mobjShowHelpButton.TabIndex = 3
            Me.mobjShowHelpButton.Text = "Change font for label with FontDialog"
            Me.mobjShowHelpButton.UseVisualStyleBackColor = True
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
            Me.mobjLayoutPanel.Controls.Add(Me.mobjShowHelpLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjShowHelpButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowShowHelpCheckBox, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(555, 273)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' ShowHelpPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(555, 273)
            Me.Text = "ShowHelpPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjAllowShowHelpCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjShowHelpLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjShowHelpButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
