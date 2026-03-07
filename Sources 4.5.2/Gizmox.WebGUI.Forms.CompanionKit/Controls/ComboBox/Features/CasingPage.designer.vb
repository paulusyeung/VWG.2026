Namespace CompanionKit.Controls.ComboBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CasingPage
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
            Me.mobjTestComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCasingComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCasingLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTestLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTestComboBox
            ' 
            Me.mobjTestComboBox.AllowDrag = False
            Me.mobjTestComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTestComboBox.FormattingEnabled = True
            Me.mobjTestComboBox.Items.AddRange(New Object() {"aBcD", "BcDa", "cDaB", "DaBc"})
            Me.mobjTestComboBox.Location = New System.Drawing.Point(103, 63)
            Me.mobjTestComboBox.Name = "objComboBox"
            Me.mobjTestComboBox.Size = New System.Drawing.Size(150, 21)
            Me.mobjTestComboBox.TabIndex = 0
            ' 
            ' mobjCasingComboBox
            ' 
            Me.mobjCasingComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCasingComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjCasingComboBox.FormattingEnabled = True
            Me.mobjCasingComboBox.Items.AddRange(New Object() {"Normal", "Upper", "Lower"})
            Me.mobjCasingComboBox.Location = New System.Drawing.Point(103, 153)
            Me.mobjCasingComboBox.Name = "S"
            Me.mobjCasingComboBox.Size = New System.Drawing.Size(150, 21)
            Me.mobjCasingComboBox.TabIndex = 1
            Me.mobjCasingComboBox.Text = "Normal"
            ' 
            ' mobjCasingLabel
            ' 
            Me.mobjCasingLabel.AutoSize = True
            Me.mobjCasingLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCasingLabel.Location = New System.Drawing.Point(103, 113)
            Me.mobjCasingLabel.Name = "objCasingLabel"
            Me.mobjCasingLabel.Size = New System.Drawing.Size(150, 40)
            Me.mobjCasingLabel.TabIndex = 2
            Me.mobjCasingLabel.Text = "Casing"
            Me.mobjCasingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjTestLabel
            ' 
            Me.mobjTestLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTestLabel, 2)
            Me.mobjTestLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTestLabel.Location = New System.Drawing.Point(103, 23)
            Me.mobjTestLabel.Name = "objTestLabel"
            Me.mobjTestLabel.Size = New System.Drawing.Size(253, 40)
            Me.mobjTestLabel.TabIndex = 3
            Me.mobjTestLabel.Text = "Test ComboBox"
            Me.mobjTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 150.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTestLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCasingComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCasingLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTestComboBox, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(356, 206)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' CasingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(356, 206)
            Me.Text = "CasingPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTestComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjCasingComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjCasingLabel As Gizmox.WebGUI.Forms.Label
        Private mobjTestLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace