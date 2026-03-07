Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ShowEffectsPage
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
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjShowEffectsLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAllowShowEffectsCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjShowEffectsButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoFontDialog
            ' 
            Me.mobjDemoFontDialog.MaxSize = 28
            Me.mobjDemoFontDialog.MinSize = 8
            ' 
            ' mobjShowEffectsLabel
            ' 
            Me.mobjShowEffectsLabel.AutoSize = True
            Me.mobjShowEffectsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowEffectsLabel.Location = New System.Drawing.Point(99, 28)
            Me.mobjShowEffectsLabel.Name = "mobjShowEffectsLabel"
            Me.mobjShowEffectsLabel.Size = New System.Drawing.Size(466, 50)
            Me.mobjShowEffectsLabel.TabIndex = 1
            Me.mobjShowEffectsLabel.Text = "Font selected in the dialog: "
            ' 
            ' mobjAllowShowEffectsCheckBox
            ' 
            Me.mobjAllowShowEffectsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.mobjAllowShowEffectsCheckBox.Checked = True
            Me.mobjAllowShowEffectsCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjAllowShowEffectsCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowShowEffectsCheckBox.Location = New System.Drawing.Point(99, 118)
            Me.mobjAllowShowEffectsCheckBox.Name = "mobjAllowShowEffectsCheckBox"
            Me.mobjAllowShowEffectsCheckBox.Size = New System.Drawing.Size(466, 70)
            Me.mobjAllowShowEffectsCheckBox.TabIndex = 2
            Me.mobjAllowShowEffectsCheckBox.Text = "Enable panel with effects in the FontDialog"
            Me.mobjAllowShowEffectsCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjShowEffectsButton
            ' 
            Me.mobjShowEffectsButton.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand
            Me.mobjShowEffectsButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowEffectsButton.Location = New System.Drawing.Point(99, 208)
            Me.mobjShowEffectsButton.Name = "mobjShowEffectsButton"
            Me.mobjShowEffectsButton.Size = New System.Drawing.Size(466, 50)
            Me.mobjShowEffectsButton.TabIndex = 3
            Me.mobjShowEffectsButton.Text = "Open FontDialog to change font of the label"
            Me.mobjShowEffectsButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjShowEffectsLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjShowEffectsButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowShowEffectsCheckBox, 1, 3)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(666, 287)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' ShowEffectsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(666, 287)
            Me.Text = "ShowEffectsPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjShowEffectsLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjAllowShowEffectsCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjShowEffectsButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
