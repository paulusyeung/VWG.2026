Namespace CompanionKit.Concepts.ClientAPI.PropertyAndId

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PropertyAndIdPage
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
            Me.mobjTestButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPrintButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPrintPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTextBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGroupPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPrintPanel.SuspendLayout()
            Me.mobjTextBoxPanel.SuspendLayout()
            Me.mobjGroupPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            ' mobjTestButton
            '
            Me.mobjTestButton.AccessibleDescription = ""
            Me.mobjTestButton.AccessibleName = ""
            Me.mobjTestButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTestButton.ClientId = "button"
            Me.mobjTestButton.Location = New System.Drawing.Point(19, 80)
            Me.mobjTestButton.Name = "mobjTestButton"
            Me.mobjTestButton.Size = New System.Drawing.Size(130, 81)
            Me.mobjTestButton.TabIndex = 1
            Me.mobjTestButton.Text = "Normal"
            '
            ' mobjTextBox
            '
            Me.mobjTextBox.AccessibleDescription = ""
            Me.mobjTextBox.AccessibleName = ""
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.ClientId = "text"
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBox.Location = New System.Drawing.Point(20, 5)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(146, 93)
            Me.mobjTextBox.TabIndex = 2
            '
            ' mobjPrintButton
            '
            Me.mobjPrintButton.AccessibleDescription = ""
            Me.mobjPrintButton.AccessibleName = ""
            Me.mobjPrintButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPrintButton.Location = New System.Drawing.Point(20, 5)
            Me.mobjPrintButton.MaximumSize = New System.Drawing.Size(0, 90)
            Me.mobjPrintButton.Name = "mobjPrintButton"
            Me.mobjPrintButton.Size = New System.Drawing.Size(146, 70)
            Me.mobjPrintButton.TabIndex = 3
            Me.mobjPrintButton.Text = "PrintProperties"
            '
            ' mobjLayoutPanel
            '
            Me.mobjLayoutPanel.AccessibleDescription = ""
            Me.mobjLayoutPanel.AccessibleName = ""
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPrintPanel, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBoxPanel, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.15624F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.68752F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.15624F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(571, 306)
            Me.mobjLayoutPanel.TabIndex = 4
            '
            ' mobjPrintPanel
            '
            Me.mobjPrintPanel.AccessibleDescription = ""
            Me.mobjPrintPanel.AccessibleName = ""
            Me.mobjPrintPanel.Controls.Add(Me.mobjPrintButton)
            Me.mobjPrintPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPrintPanel.DockPadding.Bottom = 5
            Me.mobjPrintPanel.DockPadding.Left = 20
            Me.mobjPrintPanel.DockPadding.Right = 5
            Me.mobjPrintPanel.DockPadding.Top = 5
            Me.mobjPrintPanel.Location = New System.Drawing.Point(285, 61)
            Me.mobjPrintPanel.Name = "mobjPrintPanel"
            Me.mobjPrintPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20, 5, 5, 5)
            Me.mobjPrintPanel.Size = New System.Drawing.Size(171, 80)
            Me.mobjPrintPanel.TabIndex = 0
            '
            ' mobjTextBoxPanel
            '
            Me.mobjTextBoxPanel.AccessibleDescription = ""
            Me.mobjTextBoxPanel.AccessibleName = ""
            Me.mobjTextBoxPanel.Controls.Add(Me.mobjTextBox)
            Me.mobjTextBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBoxPanel.DockPadding.Bottom = 5
            Me.mobjTextBoxPanel.DockPadding.Left = 20
            Me.mobjTextBoxPanel.DockPadding.Right = 5
            Me.mobjTextBoxPanel.DockPadding.Top = 5
            Me.mobjTextBoxPanel.Location = New System.Drawing.Point(285, 141)
            Me.mobjTextBoxPanel.Name = "mobjTextBoxPanel"
            Me.mobjTextBoxPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20, 5, 5, 5)
            Me.mobjTextBoxPanel.Size = New System.Drawing.Size(171, 103)
            Me.mobjTextBoxPanel.TabIndex = 0
            '
            ' mobjGroupPanel
            '
            Me.mobjGroupPanel.AccessibleDescription = ""
            Me.mobjGroupPanel.AccessibleName = ""
            Me.mobjGroupPanel.Controls.Add(Me.mobjTestButton)
            Me.mobjGroupPanel.Controls.Add(Me.mobjLabel)
            Me.mobjGroupPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupPanel.DockPadding.All = 5
            Me.mobjGroupPanel.Location = New System.Drawing.Point(114, 61)
            Me.mobjGroupPanel.Name = "mobjGroupPanel"
            Me.mobjGroupPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjGroupPanel, 2)
            Me.mobjGroupPanel.Size = New System.Drawing.Size(171, 183)
            Me.mobjGroupPanel.TabIndex = 0
            '
            ' mobjLabel
            '
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(5, 5)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(161, 70)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Click on button to change its Button Style:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            ' PropertyAndIdPage
            '
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(571, 306)
            Me.Text = "PropertyAndIdPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPrintPanel.ResumeLayout(False)
            Me.mobjTextBoxPanel.ResumeLayout(False)
            Me.mobjGroupPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjTestButton As Gizmox.WebGUI.Forms.Button
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjPrintButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPrintPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTextBoxPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjGroupPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace