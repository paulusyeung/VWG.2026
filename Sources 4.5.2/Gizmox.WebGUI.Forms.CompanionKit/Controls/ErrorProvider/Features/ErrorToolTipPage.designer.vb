Namespace CompanionKit.Controls.ErrorProvider.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ErrorToolTipPage
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
            Me.components = New System.ComponentModel.Container()
            Me.mobjHideErrorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTooltipLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjShowErrorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTooltip = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjHideErrorButton
            '
            Me.mobjHideErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHideErrorButton.Location = New System.Drawing.Point(102, 215)
            Me.mobjHideErrorButton.Margin = New Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15)
            Me.mobjHideErrorButton.MaximumSize = New System.Drawing.Size(200, 70)
            Me.mobjHideErrorButton.Name = "mobjHideErrorButton"
            Me.mobjHideErrorButton.Size = New System.Drawing.Size(200, 70)
            Me.mobjHideErrorButton.TabIndex = 4
            Me.mobjHideErrorButton.Text = "Hide Error"
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextBox.Location = New System.Drawing.Point(97, 37)
            Me.mobjTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(200, 25)
            Me.mobjTextBox.TabIndex = 0
            '
            'mobjTextLabel
            '
            Me.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTextLabel.Name = "mobjTextLabel"
            Me.mobjTextLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextLabel.Size = New System.Drawing.Size(87, 100)
            Me.mobjTextLabel.TabIndex = 1
            Me.mobjTextLabel.Text = "Text field with error"
            Me.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTooltipLabel
            '
            Me.mobjTooltipLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTooltipLabel.Location = New System.Drawing.Point(0, 300)
            Me.mobjTooltipLabel.Name = "mobjTooltipLabel"
            Me.mobjTooltipLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTooltipLabel.Size = New System.Drawing.Size(87, 100)
            Me.mobjTooltipLabel.TabIndex = 3
            Me.mobjTooltipLabel.Text = "Tooltip"
            Me.mobjTooltipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjShowErrorButton
            '
            Me.mobjShowErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowErrorButton.Location = New System.Drawing.Point(102, 115)
            Me.mobjShowErrorButton.Margin = New Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15)
            Me.mobjShowErrorButton.MaximumSize = New System.Drawing.Size(200, 70)
            Me.mobjShowErrorButton.Name = "mobjShowErrorButton"
            Me.mobjShowErrorButton.Size = New System.Drawing.Size(200, 70)
            Me.mobjShowErrorButton.TabIndex = 4
            Me.mobjShowErrorButton.Text = "Show Error"
            '
            'mobjTooltip
            '
            Me.mobjTooltip.AllowDrag = False
            Me.mobjTooltip.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTooltip.Location = New System.Drawing.Point(97, 337)
            Me.mobjTooltip.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3)
            Me.mobjTooltip.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTooltip.Name = "mobjTooltip"
            Me.mobjTooltip.Size = New System.Drawing.Size(200, 25)
            Me.mobjTooltip.TabIndex = 5
            Me.mobjTooltip.Text = "Error occured"
            '
            'mobjErrorProvider
            '
            Me.mobjErrorProvider.BlinkRate = 3
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP.Controls.Add(Me.mobjTextLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjShowErrorButton, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjTooltip, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjHideErrorButton, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextBox, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTooltipLabel, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(350, 400)
            Me.mobjTLP.TabIndex = 6
            '
            'ErrorToolTipPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(350, 400)
            Me.Text = "ErrorToolTipPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjHideErrorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTooltipLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjShowErrorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTooltip As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace